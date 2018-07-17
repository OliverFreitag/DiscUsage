Imports System.Threading

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
''' <summary>
''' simple form to show the usage of the TimeZone and the TimeZoneCollection classes 
''' </summary>
''' <remarks></remarks>
Public Class TZConv

    Private Sub TZConv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tzs As New TimeZoneList
        Dim i As Integer

        For i = 0 To tzs.Count - 1
            Me.CmbDestTZ.Items.Add(tzs.Item(i))

            Debug.Print(tzs.Item(i).DisplayName)

        Next
        Me.TxtSourceDate.Text = Now.ToString(Thread.CurrentThread.CurrentCulture)
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConvert.Click

        ' check if a target TimeZone has been selected
        If IsNothing(Me.CmbDestTZ.SelectedItem) Then
            MessageBox.Show("Please select a target timezone", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
        Else
            Call DoConvert()
        End If

    End Sub

    ''' <summary>
    ''' Executes date conversion based on selected Source and Destination TimeZones
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoConvert()

        Dim d, UTCd As DateTime
        Try
            d = DateTime.Parse(TxtSourceDate.Text, Thread.CurrentThread.CurrentCulture)
        Catch ex As FormatException
            MessageBox.Show(ex.Message + " - Please enter a valid date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
            Exit Sub
        End Try

        ' get the UTC date/time equivalent of the Source Date and show it
        UTCd = d.ToUniversalTime()
        Me.lblUTCDate.Text = UTCd.ToString(Thread.CurrentThread.CurrentCulture)

        ' get the Destination Bias (number of minutes from UTC)
        Dim DestBias As Integer
        DestBias = CType(Me.CmbDestTZ.SelectedItem, TimeZone).Bias

        ' Add difference between timezones to specified date
        Me.LblDestDate.Text = UTCd.AddMinutes(DestBias).ToString(Thread.CurrentThread.CurrentCulture)
    End Sub

End Class
