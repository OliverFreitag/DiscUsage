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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Microsoft.Samples.Remoting.SharedImplementation;

namespace Microsoft.Samples.Remoting.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ITest ssTcp = null;
			IDictionary dict = new Hashtable();
			dict["secure"] = true;
			dict["tokenImpersonationLevel"] = System.Security.Principal.TokenImpersonationLevel.Impersonation;
			ChannelServices.RegisterChannel(new TcpChannel(dict, null, null), true /*ensureSecurity*/);
			Console.WriteLine("Connect to objects...");
			ssTcp = (ITest)Activator.GetObject(typeof(ITest), "tcp://"+Environment.MachineName+":3300/server.rem");

			ssTcp.Echo("Hello");
		}
	}
}
