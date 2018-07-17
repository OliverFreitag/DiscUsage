'-----------------------------------------------------------------------
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
'
'=====================================================================
'  File:      OPObj.vb
'
'  Summary:   OP Demo Pooled Object Code
'
'=====================================================================

Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

' the ApplicationName attribute specifies the name of the
' COM+ Application which will hold assembly components
<Assembly: ApplicationName("OPDemoSvr")>

'Setting the ApplicationAccessControl Attribute to false switches off
'role based security, a real app should turn it in, and configure roles.
<assembly: ApplicationAccessControl(false)>

' the ApplicationActivation.ActivationOption attribute specifies 
' where assembly components are loaded on activation
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe
<Assembly: ApplicationActivation(ActivationOption.Server)>

Namespace Microsoft.Samples.Technologies.ComponentServices.ObjectPooling

    <ComVisible(True)> _
    Public Interface IPooledLogFile
        Sub Write(ByVal message As String)
    End Interface
    ' We use the ObjectPooling attribute to specify the default
    ' minimum and maximum pool size (0 and 1 objects)

    ' JustInTimeActivation enables Just In Time 
    ' Activation for the component

    ' ConstructionEnabled enables object construction strings.
    ' We use ours to specify a file name and (possibly) location.
    ' The default file is named 'OPSvrLogVB.txt' and will be created
    ' in the System32 subdirectory. See the SDK Object
    ' Construction sample for more information on construction strings.

    <ObjectPooling(MinPoolSize:=0, MaxPoolSize:=1), JustInTimeActivation(True), _
    ConstructionEnabled([Default]:="OPSvrLogVB.txt"), ClassInterface(ClassInterfaceType.None), _
    ComVisible(True), _
    CLSCompliant(False)> _
    Public Class PooledLogFile

        Inherits ServicedComponent
        Implements IPooledLogFile
        Private w As StreamWriter


        Protected Overrides Sub Construct(ByVal constructString As String)
            ' This StreamWriter constructor opens a file named in the 
            ' first argument, the file is created if it does not exist.
            ' The second argument indicates we permit appending.
            w = New StreamWriter(constructString, True, Encoding.Default)

            ' set the file pointer to the end
            w.BaseStream.Seek(0, SeekOrigin.End)
        End Sub 'Construct


        ' Using the AutoComplete attribute will automatically return
        ' the object to the pool on return from the method. Without
        ' AutoComplete, a caller is required to set the object's
        ' done bit to true by calling SetComplete.
        <AutoComplete()> _
        Public Sub Write(ByVal message As String) Implements IPooledLogFile.Write
            w.WriteLine(("Client called PooledLogFile::Write() with message: " & message))
        End Sub 'Write



        ' COM+ calls IObjectControl::Activate before any call 
        ' into a JIT-activated object by a new caller
        Protected Overrides Sub Activate()
            w.WriteLine("COM+   called IObjectControl::Activate()")
        End Sub 'Activate



        ' COM+ calls IObjectControl::Deactivate immediately after a
        ' caller has indicated it is finished with a JIT-activated object. 
        ' This might be accomplished by calling SetComplete or it 
        ' might occur automatically on return from a method which 
        ' has had the AutoComplete attribute applied to it.
        Protected Overrides Sub Deactivate()
            w.WriteLine("COM+   called IObjectControl::Deactivate()")
        End Sub 'Deactivate



        ' COM+ calls IObjectControl::CanBePooled after object 
        ' deactivation to allow the object to indicate whether 
        ' or not it can be returned to the pool
        Protected Overrides Function CanBePooled() As Boolean

            w.WriteLine("COM+   called IObjectControl::CanBePooled()")
            w.WriteLine("")

            w.Flush() ' update underlying file
            ' due to simplicity of this example, we can always be
            ' returned to the pool
            Return True
        End Function 'CanBePooled
    End Class 'PooledLogFile
End Namespace 'OPDemoServerVB
