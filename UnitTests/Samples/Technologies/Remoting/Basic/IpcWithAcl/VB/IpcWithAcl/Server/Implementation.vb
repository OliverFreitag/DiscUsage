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
Imports System
Imports System.Security.Principal
Imports Microsoft.Samples.SharedInterface



Friend Class ImplementationClass
    Inherits MarshalByRefObject
    Implements ISharedInterface
    
    Function HelloWorld(ByVal input As String) As String  Implements Microsoft.Samples.SharedInterface.ISharedInterface.HelloWorld
        Console.WriteLine("Client says: " + input)
        Return "Hello to you too, client"
    
    End Function 'Microsoft.Samples.SharedInterface.ISharedInterface.HelloWorld
End Class 'ImplementationClass