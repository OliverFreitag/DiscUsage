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
'  File:      OPForm.vb
'
'  Summary:   .NET Client App for JITA/Object Pooling Demo
'
'=====================================================================

Option Explicit On
Option Strict On

Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Globalization
Imports System.Windows.Forms
Imports System.ComponentModel
'Imports System.EnterpriseServices


Namespace Microsoft.Samples.Technologies.ComponentServices.ObjectPooling

Public Class OPForm
        Inherits Form
        Private WithEvents startWrite As Button
        Private WithEvents stopWrite As Button
        Private label As Label
        Private WithEvents timer As Timer
        Private flag As Boolean = False


        Public Sub New()
            InitializeComponent()
        End Sub 'New



        Private Sub InitializeComponent()
            Me.startWrite = New Button
            Me.stopWrite = New Button
            Me.label = New Label

            startWrite.Location = New Point(24, 40)
            startWrite.Size = New Size(96, 24)
            startWrite.TabIndex = 1
            startWrite.Text = "Start Writing"

            stopWrite.Location = New System.Drawing.Point(24, 70)
            stopWrite.Size = New System.Drawing.Size(96, 24)
            stopWrite.TabIndex = 1
            stopWrite.Text = "Stop Writing"
            stopWrite.Enabled = False

            label.Location = New Point(140, 60)
            label.Size = New Size(96, 24)
            label.TabIndex = 1

            timer = New Timer
            timer.Interval = 1000

            Me.Text = "JIT/Object Pooling Demo"
            Me.AutoScaleDimensions = New SizeF(5, 13)
            Me.ClientSize = New Size(240, 170)
            Me.Controls.Add(stopWrite)
            Me.Controls.Add(startWrite)
            Me.Controls.Add(label)
        End Sub 'InitializeComponent



        Private Sub Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles startWrite.Click
            Me.Cursor = Cursors.AppStarting

            Try
                ' enable our timer
                timer.Start()

                ' set our buttons to their startup condition
                stopWrite.Enabled = True
                startWrite.Enabled = False

            Catch ex As Exception
                If Not timer Is Nothing Then
                    timer.Stop()
                End If

                MessageBox.Show("PooledLogFile creation generated an exception : " & ex.Message, "Error")
                Me.Cursor = Cursors.Arrow
            End Try
        End Sub 'Start_Click



        Private Sub Stop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles stopWrite.Click
            ' reset button state
            stopWrite.Enabled = False
            startWrite.Enabled = True

            'disable timer
            If Not timer Is Nothing Then
                timer.Stop()
            End If
            Me.Cursor = Cursors.Arrow

            ' reset UI activity indicator
            label.Text = ""
        End Sub 'Stop_Click



        Private Sub OnTick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer.Tick
            ' On calling this method, COM+ will activate an object
            ' (just in time) from the object pool when one is
            ' available and we will call into it. On return from the
            ' call, COM+ will deactivate the object and query it
            ' to see whether it can be returned to the pool

            Dim log As PooledLogFile = Nothing
            Try
		log = new PooledLogFile
                log.Write(("Hello! from Process : " & _
                    Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture)))

                ' our high-powered UI for indicating activity
                If flag = True Then
                    label.Text = "Writing :"
                Else
                    label.Text = "Writing : ***"
                End If
                flag = Not flag
            Catch ex As Exception
                If Not timer Is Nothing Then
                    timer.Stop()
                End If

                MessageBox.Show("An exception was caught :" & ex.Message, "Error")

                label.Text = "Error!"
                Me.Cursor = Cursors.Arrow
	    Finally
                'It is important to dispose COM+ objects as soon as possible so that
                'COM+ metadata such as context does not remain in memory unnecessarily
                'and so that COM+ services such as Object Pooling work properly.
                If Not log is Nothing
			log.Dispose()
		End If
            End Try
        End Sub 'OnTick

        Public Shared Sub Main(ByVal args() As String)
            Application.Run(New OPForm)
        End Sub 'Main
    End Class 'OPForm
End Namespace
