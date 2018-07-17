
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------


Module AnyCPU

    Sub Main()


        Console.WriteLine("This applications is compiled to run on all processors.")

        Console.WriteLine("Checking IntPtr.Size to see if this application is running as a 32bit or 64bit application.")

        Console.WriteLine("IntPtr.Size = " + IntPtr.Size.ToString())

        If (IntPtr.Size = 4) Then
            Console.WriteLine("This application is running as a 32bit Process.")

        End If

        If (IntPtr.Size = 8) Then
            Console.WriteLine("This application is running as a 64bit Process!!!")
        End If

    End Sub

End Module
