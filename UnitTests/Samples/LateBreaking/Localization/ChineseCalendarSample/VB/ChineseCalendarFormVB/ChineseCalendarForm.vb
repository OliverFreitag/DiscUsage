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

Imports System.Security.Permissions
Imports System.Globalization
Imports System.Threading

<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, _
Assertion:=True)> 
<Module: CLSCompliant(True)> 

Public Class ChineseCalendarForm


    Private Calendar As New Microsoft.Samples.ChineseCalendarVB.ChineseLunarCalendar()

    Private Sub monthCalendar1_DateChanged(ByVal sender As System.Object, _
    ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles monthCalendar1.DateChanged
        Dim selectedDate As DateTime = e.End
        Try
            textBoxDate.Text = [String].Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}", Calendar.GetYear(selectedDate), Calendar.GetMonth(selectedDate), Calendar.GetDayOfMonth(selectedDate))


            textBoxYear.Text = Calendar.GetChineseSexagenaryYear(selectedDate)

            textBoxZodiac.Text = Calendar.GetChineseZodiac(selectedDate)

            Dim strTermName As String = Calendar.GetSolarTerms(selectedDate)
            If String.IsNullOrEmpty(strTermName) Then
                textBoxTerm.Visible = False
                label4.Visible = False
            Else
                textBoxTerm.Visible = True
                label4.Visible = True
                textBoxTerm.Text = strTermName
            End If
            If selectedDate >= New DateTime(2020, 12, 21) Then
                textBoxNextTerm.Visible = False
                label5.Visible = False
            Else
                textBoxNextTerm.Visible = True
                label5.Visible = True
                Dim NextTermInfo As String
                If Thread.CurrentThread.CurrentUICulture.Equals(New CultureInfo("zh-TW")) Then
                    NextTermInfo = String.Format(CultureInfo.CurrentCulture, "{0}({1})", _
                    Calendar.GetSolarTerms(Calendar.GetNextTermDate(selectedDate)), _
                    Calendar.GetNextTermDate(selectedDate).GetDateTimeFormats("D"c, New CultureInfo("zh-CN"))(2))

                Else
                    NextTermInfo = String.Format(CultureInfo.CurrentCulture, "{0}({1})", _
                    Calendar.GetSolarTerms(Calendar.GetNextTermDate(selectedDate)), _
                    Calendar.GetNextTermDate(selectedDate).GetDateTimeFormats("D"c, Thread.CurrentThread.CurrentUICulture)(2))
                End If
                textBoxNextTerm.Text = NextTermInfo
            End If

        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, _
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)

        Catch ex As InvalidCastException
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, _
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try

    End Sub
End Class
