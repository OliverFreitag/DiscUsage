' ===================================
'   File:      IdRefConverter.vb
'  
'   Summary:   Demonstrates translating between 
'              SecurityIdentifier and NTAccount objects.
'  
' ---------------------------------------------------------------------
'   This file is part of the Microsoft .NET SDK Code Samples.
'  
'   Copyright (C) Microsoft Corporation.  All rights reserved.
'  
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
'  
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
' ===================================

Option Strict On
Option Explicit On


Imports System
Imports System.Security.Permissions
Imports System.Security.Principal

<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: EnvironmentPermission(SecurityAction.RequestMinimum, _
								  Read:="USERNAME;USERDOMAIN")> 



Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class IdRefConverter

        Private Sub New()
        End Sub


        Public Shared Sub Main(ByVal args() As String)
            Dim idRef As IdentityReference = Nothing

            '
            ' Get the parameters
            '
            If args.Length <> 2 OrElse (args(0).ToLower() <> "sid" And _
            							args(0).ToLower() <> "nt") Then
                Console.WriteLine("Usage: IdRefConverter sid <SID> or " + _
                						 "IdRefConverter nt <ntAccount>")

                Console.WriteLine("For example:" + vbCrLf + _
                			      "IdRefConverter nt " + _
                Environment.ExpandEnvironmentVariables("%USERDOMAIN%\%USERNAME%") _
                                 + vbCrLf + "IdRefConverter sid S-1-1-0")

                Return
            End If

            '
            ' Translate the identity reference
            '
            Try
                '
                ' Translate SecurityIdentifier to NTAccount
                '
                If args(0).ToLower() = "sid" Then
                    idRef = New SecurityIdentifier(args(1))
                    idRef = CType(idRef.Translate(GetType(NTAccount)), _
                    									  NTAccount)

                '
                ' Translate NTAccount to SecurityIdentifier
                '
                ElseIf args(0).ToLower() = "nt" Then
                    idRef = New NTAccount(args(1))
                    idRef = CType(idRef.Translate(GetType(SecurityIdentifier)), _
                                                          SecurityIdentifier)
                End If

                '
                ' Display the result
                '
                Console.WriteLine(idRef)
            '
            ' If the translation fails, it will be catched here
            '
            Catch e As IdentityNotMappedException
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            Catch e As Exception
                Console.WriteLine(vbCrLf + "Unexpected exception occured:" + _
                			vbCrLf + vbTab + e.GetType().Name + ":" + e.Message)
            End Try
        End Sub

    End Class

End Namespace
