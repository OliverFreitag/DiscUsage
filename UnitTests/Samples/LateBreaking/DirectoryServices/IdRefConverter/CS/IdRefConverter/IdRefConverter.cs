/*=====================================================================
  File:      IdRefConverter.cs

  Summary:   Demonstrates translating between 
             SecurityIdentifier and NTAccount objects.

---------------------------------------------------------------------
  This file is part of the Microsoft .NET SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/


using System;
using System.Security.Permissions;
using System.Security.Principal;

[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: EnvironmentPermission(SecurityAction.RequestMinimum,
                                 Read="USERNAME;USERDOMAIN")]

namespace Microsoft.Samples.DirectoryServices
{

public static class IdRefConverter
{
    public static void Main(string[] args)
    {
        IdentityReference idRef = null;

        //
        // Get the parameters
        //
        if (args.Length != 2 || (args[0].ToLower() != "sid" && 
                                  args[0].ToLower() != "nt"))
        {
            Console.WriteLine("Usage: IdRefConverter sid <SID> or "+
                                     "IdRefConverter nt <ntAccount>");
            
            Console.WriteLine("For example:\r\nIdRefConverter nt " + 
            Environment.ExpandEnvironmentVariables("%USERDOMAIN%\\%USERNAME%") +
                              "\r\nIdRefConverter sid S-1-1-0");
            
            return;
        }

        //
        // Translate the identity reference
        //
        try
        {
            //
            // Translate SecurityIdentifier to NTAccount
            //
            if (args[0].ToLower() == "sid")
            {
                idRef = new SecurityIdentifier(args[1]);
                idRef = (NTAccount)idRef.Translate(typeof(NTAccount));                
            }
            //
            // Translate NTAccount to SecurityIdentifier
            //
            else if (args[0].ToLower() == "nt")
            {
                idRef = new NTAccount(args[1]);
                idRef = (SecurityIdentifier)idRef.Translate
                                                   (typeof(SecurityIdentifier));
            }

            //
            // Display the result
            //
            Console.WriteLine(idRef);
        }
        //
        // If the translation fails, it will be catched here
        //
        catch (IdentityNotMappedException e)
        {
            Console.WriteLine(e.GetType().Name + ":" + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                              e.GetType().Name + ":" + e.Message);
        }
        
    }
}

}