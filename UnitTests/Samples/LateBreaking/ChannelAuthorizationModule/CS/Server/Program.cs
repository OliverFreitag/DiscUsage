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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Samples.Remoting.SharedImplementation;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace Microsoft.Samples.Remoting.Server
{
	class Implementation : MarshalByRefObject, ITest
	{

		#region ITest Members

		public string Echo(string input)
		{
			Console.WriteLine("Input: {0}", input);
			return input + input;
		}

		#endregion
	}
	class Program
	{
		static void Main(string[] args)
		{
			IDictionary dict = new Hashtable();
			dict["port"] = 3300;
			dict["secure"] = true;
			dict["machineName"] = Environment.MachineName;
			dict["authorizationModule"] = "AuthorizationModule.Authorizer, AuthorizationModule";
			ChannelServices.RegisterChannel(new TcpServerChannel(dict, null), true /*ensureSecurity*/);
			dict["port"] = 3301;
			dict["name"] = "Tcp2";
			ChannelServices.RegisterChannel(new TcpServerChannel(dict, null), true /*ensureSecurity*/);
			Console.WriteLine(typeof(Implementation).Assembly.FullName);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(Implementation), "server.rem", WellKnownObjectMode.SingleCall);

			Console.WriteLine("Waiting for Client!");
			Console.ReadLine();

		}
	}
}
