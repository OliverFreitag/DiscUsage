//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
//
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.XPath;
using System.Threading;


namespace Microsoft.Samples.Remoting.AuthorizationModule
{
	public class Authorizer : IAuthorizeRemotingConnection
	{
		static string semaphoreName = "AuthorizerSemaphore";
		static Semaphore sem = new Semaphore(0,1,semaphoreName);
		static string fileName = @"C:\temp\aclCheckFile.acl";

		static Authorizer()
		{
			BuildAcldSemaphoreFromConfig();			
		}

		public bool IsConnectingEndPointAuthorized(EndPoint endpoint)
		{
			Console.WriteLine("Connecting IP:" + endpoint);
			IPEndPoint ipe = (IPEndPoint)endpoint;

			return InLocalSubnet(ipe);
		}

		bool InLocalSubnet(IPEndPoint endPoint)
		{
			IPAddress addr = endPoint.Address;
			if (addr.AddressFamily == AddressFamily.InterNetworkV6)
			{
				if (endPoint.Address.Equals(IPAddress.IPv6Loopback))
					return true;

				if (addr.IsIPv6LinkLocal)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (addr.AddressFamily == AddressFamily.InterNetwork)
			{
				if (endPoint.Address.Equals(IPAddress.Loopback))
					return true;

				List<IPAddress> subnetMasks = new List<IPAddress>();
				List<IPAddress> maskedLocalAddrs = new List<IPAddress>();

				foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
				{
					if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;

					Console.WriteLine("NIC: {0}", nic.Name);
					foreach (UnicastIPAddressInformation uIpInfo in nic.GetIPProperties().UnicastAddresses)
					{
						Console.WriteLine("\tIP Addr: {0}", uIpInfo.Address);
						Console.WriteLine("\tMask: {0}", uIpInfo.IPv4Mask);

						subnetMasks.Add(uIpInfo.IPv4Mask);
						long bitMaskedAddr = uIpInfo.Address.Address & uIpInfo.IPv4Mask.Address;
						IPAddress maskedAddr = new IPAddress(bitMaskedAddr);

						Console.WriteLine("\tMasked Addr: {0}", maskedAddr);
						maskedLocalAddrs.Add(maskedAddr);
					}
				}

				foreach (IPAddress mask in subnetMasks)
				{
					IPAddress maskedRemoteAddr = new IPAddress(mask.Address & endPoint.Address.Address);

					foreach (IPAddress maskedLocalIP in maskedLocalAddrs)
					{
						if (maskedRemoteAddr.Equals(maskedLocalIP))
							return true;
					}

				}

				return false;
				
			}
			else
			{
				return false;
			}
		}

		public bool IsConnectingIdentityAuthorized(IIdentity identity)
		{
			bool allowed = false;

			WindowsImpersonationContext impCtx = (identity as WindowsIdentity).Impersonate();
			try
			{
				Semaphore sem2 = Semaphore.OpenExisting(semaphoreName, SemaphoreRights.Synchronize);
				allowed = true;
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Access denied for: {0}", WindowsIdentity.GetCurrent().Name);				
				allowed = false;
			}
			finally
			{
				impCtx.Undo();
			}			

			return allowed;

		}

		static void BuildAcldSemaphoreFromConfig()
		{
			SemaphoreSecurity semSec = new SemaphoreSecurity();

			string authorizationLocation = @".\Server\AuthorizationList.xml";
			XPathDocument xpathDoc = new XPathDocument(authorizationLocation);
			XPathNavigator xpathNav = xpathDoc.CreateNavigator();

			xpathNav = xpathNav.SelectSingleNode("remotingAuthorization");

			if (xpathNav.HasChildren)
			{
				xpathNav.MoveToChild(XPathNodeType.Element);

				do
				{
					AccessControlType accessType = (AccessControlType)Enum.Parse(typeof(AccessControlType), xpathNav.Name, true);
					xpathNav.MoveToAttribute("users", xpathNav.NamespaceURI);
					NTAccount account = new NTAccount(xpathNav.Value);
					SemaphoreAccessRule semRule = new SemaphoreAccessRule(
						(IdentityReference)account,
						SemaphoreRights.Synchronize,
						accessType);
					Console.WriteLine("{0} access for: {1}", accessType.ToString(), account.Value);
					xpathNav.MoveToParent();
					semSec.AddAccessRule(semRule);

				} while (xpathNav.MoveToNext(XPathNodeType.Element));

			}
			sem.SetAccessControl(semSec);
		}


#region Other ACL Approaches
		static DiscretionaryAcl BuildAclFromConfig()
		{
			DiscretionaryAcl dacl = new DiscretionaryAcl(false, false, 1);
			string authorizationLocation = @"..\..\AuthorizationList.xml";
			XPathDocument xpathDoc = new XPathDocument(authorizationLocation);
			XPathNavigator xpathNav = xpathDoc.CreateNavigator();

			xpathNav = xpathNav.SelectSingleNode("remotingAuthorization");

			if (xpathNav.HasChildren)
			{
				xpathNav.MoveToChild(XPathNodeType.Element);

				do
				{
					AccessControlType accessType = (AccessControlType)Enum.Parse(typeof(AccessControlType), xpathNav.Name);
					Console.WriteLine(xpathNav.Name);
					xpathNav.MoveToAttribute("users", xpathNav.NamespaceURI);
					Console.WriteLine(xpathNav.Name);
					Console.WriteLine(xpathNav.Value);
					NTAccount account = new NTAccount(xpathNav.Value);
					dacl.AddAccess(
						accessType,
						(SecurityIdentifier)account.Translate(typeof(SecurityIdentifier)),
						-1, InheritanceFlags.None,
						PropagationFlags.None);

					xpathNav.MoveToParent();

				} while (xpathNav.MoveToNext(XPathNodeType.Element));

			}
			return dacl;
		}

		static void BuildAcldFileFromConfig()
		{
			StreamWriter w = File.CreateText(fileName);
			w.WriteLine("Access Granted");
			w.Close();

			FileSecurity fileSec = new FileSecurity();

			string authorizationLocation = @"..\..\AuthorizationList.xml";
			XPathDocument xpathDoc = new XPathDocument(authorizationLocation);
			XPathNavigator xpathNav = xpathDoc.CreateNavigator();

			xpathNav = xpathNav.SelectSingleNode("remotingAuthorization");

			if (xpathNav.HasChildren)
			{
				xpathNav.MoveToChild(XPathNodeType.Element);

				do
				{
					AccessControlType accessType = (AccessControlType)Enum.Parse(typeof(AccessControlType), xpathNav.Name, true);
					Console.WriteLine(xpathNav.Name);
					xpathNav.MoveToAttribute("users", xpathNav.NamespaceURI);
					Console.WriteLine(xpathNav.Name);
					Console.WriteLine(xpathNav.Value);
					NTAccount account = new NTAccount(xpathNav.Value);
					FileSystemAccessRule rule = new FileSystemAccessRule(
						(IdentityReference)account,
						FileSystemRights.ListDirectory | FileSystemRights.Read,
						accessType);
					xpathNav.MoveToParent();
					fileSec.AddAccessRule(rule);

				} while (xpathNav.MoveToNext(XPathNodeType.Element));

			}
			File.SetAccessControl(fileName, fileSec);
		}

#endregion

	}
}
