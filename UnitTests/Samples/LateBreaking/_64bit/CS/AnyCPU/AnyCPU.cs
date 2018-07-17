//---------------------------------------------------------------------
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
//---------------------------------------------------------------------


#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Microsoft.Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This applications is compiled to run on all processors.");

            Console.WriteLine("Checking IntPtr.Size to see if this application is running as a 32bit or 64bit application.");
            
            Console.WriteLine("IntPtr.Size = " + IntPtr.Size);

	        if (IntPtr.Size == 4)
		        Console.WriteLine("This application is running as a 32bit Process.");
    	
	        if (IntPtr.Size == 8)
		        Console.WriteLine("This application is running as a 64bit Process!!!");

        }
    }
}
