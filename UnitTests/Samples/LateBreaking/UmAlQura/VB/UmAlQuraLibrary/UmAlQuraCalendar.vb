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

Imports System.Globalization
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
<Assembly: CLSCompliant(True)> 
<Assembly: Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.RequestMinimum)> 

Public Class UmAlQuraCalendar

    Private UmAlQuraInstance As System.Globalization.UmAlQuraCalendar = New System.Globalization.UmAlQuraCalendar()
    Private CurrMonth As Integer = UmAlQuraInstance.GetMonth(Date.Now())
    Private CurrYear As Integer = UmAlQuraInstance.GetYear(Date.Now())
    Private CurrDay As Integer = UmAlQuraInstance.GetDayOfMonth(Date.Now())

    Private Sub GetCurrentDayAndWeek(ByVal SelDay As Integer, ByRef Day As Integer, ByRef Week As Integer)
        Dim FirstDayInMonth As Integer = DayNumber(1)
        Day = DayNumber(SelDay)
        Dim Calc As Integer = 0
        Calc = SelDay - (7 - FirstDayInMonth)
        If Calc <= 0 Then
            Week = 1
        Else
            Week = (Calc / 7) + 2
        End If
        If Week > 5 Then
            Week = 5
        End If
    End Sub

    Private Sub tableLayoutPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayNo1.Click, DayNo2.Click, DayNo3.Click, DayNo4.Click, DayNo5.Click, DayNo6.Click, DayNo7.Click, DayNo8.Click, DayNo9.Click, DayNo10.Click, DayNo11.Click, DayNo12.Click, DayNo13.Click, DayNo14.Click, DayNo15.Click, DayNo16.Click, DayNo17.Click, DayNo18.Click, DayNo19.Click, DayNo20.Click, DayNo21.Click, DayNo22.Click, DayNo23.Click, DayNo24.Click, DayNo25.Click, DayNo26.Click, DayNo27.Click, DayNo28.Click, DayNo29.Click, DayNo30.Click, DayNo31.Click, DayNo32.Click, DayNo33.Click, DayNo34.Click, DayNo35.Click
        Dim day As Integer = 0
        Dim week As Integer = 0
        Dim selectedLabel As Label = (CType((sender), Label))
        Dim selectedLabelText As String = selectedLabel.Text
        If selectedLabelText.Length > 0 Then
            GetCurrentDayAndWeek(CurrDay, day, week)
            Dim previousLabel As Label = CType(tableLayoutPanel1.GetControlFromPosition(day, week), Label)
            Dim index As Integer = selectedLabelText.IndexOf("/")
            If index > -1 Then
                selectedLabelText = selectedLabelText.Remove(index, selectedLabelText.Length - index)
            End If
            Try
                CurrDay = Integer.Parse(selectedLabelText, System.Threading.Thread.CurrentThread.CurrentUICulture)
            Catch
                CurrDay = 10
            End Try
            'deselects the currently selected cell
            previousLabel.ForeColor = Color.Black
            previousLabel.BackColor = Color.White
            previousLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
            'selects the desired cell
            selectedLabel.ForeColor = Color.White
            selectedLabel.BackColor = Color.Blue
            selectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Titles()
        End If
    End Sub

    Private Sub Painter()
        Me.tableLayoutPanel1.SuspendLayout()
        ' This loops to clear the selected text
        Dim SelectedLabel As Label
        For i As Integer = 1 To 5
            For j As Integer = 0 To 6
                'each cell containing a date in the calendar is set to it's default settings*/
                SelectedLabel = tableLayoutPanel1.GetControlFromPosition(j, i)
                SelectedLabel.Text = SelectedLabel.Text.Remove(0, SelectedLabel.Text.Length)
                SelectedLabel.ForeColor = Color.Black
                SelectedLabel.BackColor = Color.White
                SelectedLabel.BorderStyle = Windows.Forms.BorderStyle.None
            Next j
        Next i
        WriteDates()
        Titles()
        Dim init As Integer = DayNumber(1)
        Dim Day, Week As Integer
        'Highlight the selected date
        GetCurrentDayAndWeek(CurrDay, Day, Week)
        SelectedLabel = tableLayoutPanel1.GetControlFromPosition(Day, Week)
        SelectedLabel.ForeColor = Color.White
        SelectedLabel.BackColor = Color.Blue
        SelectedLabel.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
    End Sub


    Private Sub WriteDates()

        'the day value is used to write the dates on the calendar, the init value is used to tell us where 
        'to start in the calendar
        Dim day As Integer = 1
        Dim init As Integer = DayNumber(1)
        Dim i As Integer
        For i = init To 6
            'writes out the dates in the first row starting from the correct position
            tableLayoutPanel1.GetControlFromPosition(i, 1).Text = day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture)
            day += 1
        Next i
        Dim daysInMonth As Integer
        Try
            daysInMonth = UmAlQuraInstance.GetDaysInMonth(CurrYear, CurrMonth)
        Catch exception As ArgumentException
            MessageBox.Show(exception.Message)
            Return
        End Try
        For i = 2 To 5
            Dim j As Integer
            For j = 0 To 6
                'writes out the remaining dates in the calendar watching out for the number of day in the month*/
                If day <= daysInMonth Then
                    tableLayoutPanel1.GetControlFromPosition(j, i).Text = day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture)
                    day = day + 1
                End If
            Next j
        Next i
        ' There is an extra day we need to write
        init = 0
        Dim previousDay As String
        While daysInMonth >= day
            previousDay = tableLayoutPanel1.GetControlFromPosition(init, 5).Text
            tableLayoutPanel1.GetControlFromPosition(init, 5).Text = previousDay + "/" + day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture)
            day = day + 1
            init = init + 1
        End While
    End Sub

    Function DayNumber(ByVal Day As Integer) As Integer
        'Select Case UmAlQuraInstance.GetDayOfWeek(New System.DateTime(CurrYear, CurrMonth, Day, UmAlQuraInstance))
        Try
            Select Case UmAlQuraInstance.GetDayOfWeek(New System.DateTime(CurrYear, CurrMonth, Day, UmAlQuraInstance))
                Case DayOfWeek.Saturday
                    Return 0
                Case DayOfWeek.Sunday
                    Return 1
                Case DayOfWeek.Monday
                    Return 2
                Case DayOfWeek.Tuesday
                    Return 3
                Case DayOfWeek.Wednesday
                    Return 4
                Case DayOfWeek.Thursday
                    Return 5
                Case DayOfWeek.Friday
                    Return 6
            End Select
        Catch exception As ArgumentException
            MessageBox.Show(exception.Message)
        End Try
        Return 0
    End Function
    Private Sub Titles()
        'creates a DateTimeFormatInfo object to get the names of the months then use it in the labels above and
        'below the calendar, after which the label at the top is relocated to centre it in the panel

        Dim dtf As System.Globalization.DateTimeFormatInfo = New System.Globalization.CultureInfo("ar-sa", False).DateTimeFormat()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UmAlQuraCalendar))
        FooterLabel.Text = (resources.GetString("TodayName") + CurrDay.ToString(My.Resources.Culture) + " " + dtf.GetMonthName(CurrMonth) + ", " + CurrYear.ToString(My.Resources.Culture))
        HeaderLabel.Text = (dtf.GetMonthName(CurrMonth) + ", " + CurrYear.ToString(My.Resources.Culture))
        HeaderLabel.Location = (New Point((Me.HeaderPanel.Width() / 2) - (HeaderLabel.Width() / 2), 3))
        tableLayoutPanel1.ResumeLayout()

    End Sub


    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load
        'created a DateTimeFormatInfo object to retrieve the names of the days and applied
        Dim dtf As System.Globalization.DateTimeFormatInfo = New CultureInfo("ar-SA").DateTimeFormat()
        Daylabel1.Text = (dtf.GetDayName(DayOfWeek.Saturday))
        Daylabel2.Text = (dtf.GetDayName(DayOfWeek.Sunday))
        Daylabel3.Text = (dtf.GetDayName(DayOfWeek.Monday))
        Daylabel4.Text = (dtf.GetDayName(DayOfWeek.Tuesday))
        Daylabel5.Text = (dtf.GetDayName(DayOfWeek.Wednesday))
        Daylabel6.Text = (dtf.GetDayName(DayOfWeek.Thursday))
        Daylabel7.Text = (dtf.GetDayName(DayOfWeek.Friday))
        Painter()
    End Sub

    <Description("Set or get the calendar day"), Category("Data")> _
    Public Property Day() As Integer
        Get
            Day = CurrDay
        End Get
        Set(ByVal value As Integer)
            If value <= UmAlQuraInstance.GetDaysInMonth(CurrYear, CurrMonth) And value > 0 Then
                CurrDay = value
                Painter()
            Else
                Throw New ArgumentException("Days has to be between 1 and " + UmAlQuraInstance.GetDaysInMonth(CurrYear, CurrMonth).ToString(My.Resources.Culture))
            End If
        End Set
    End Property
    <Description("Set or get the calendar month"), Category("Data")> _
   Public Property Month() As Integer
        Get
            Month = CurrMonth
        End Get
        Set(ByVal value As Integer)
            If value < 13 And value > 0 Then
                CurrMonth = value
                Painter()
            Else
                Throw New ArgumentException("Months has to be between 1 and 12")
            End If
        End Set
    End Property
    <Description("Set or get the calendar year"), Category("Data")> _
     Public Property Year() As Integer
        Get
            Year = CurrYear
        End Get
        Set(ByVal value As Integer)
            Dim cc As CultureInfo = New CultureInfo("ar-SA")
            cc.DateTimeFormat.Calendar = UmAlQuraInstance
            Dim dt As DateTime = New DateTime(value, 1, 1, UmAlQuraInstance)
            If dt.Year <= UmAlQuraInstance.MaxSupportedDateTime.Year And dt.Year >= UmAlQuraInstance.MinSupportedDateTime.Year Then
                CurrYear = value
                Painter()
            Else
                Throw New ArgumentException("Years has to be between " + UmAlQuraInstance.MinSupportedDateTime.Year.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture) + " and " + UmAlQuraInstance.MaxSupportedDateTime.Year.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture))
            End If
        End Set
    End Property

    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
        'if condition checks whehter increasing the month takes it into the next year and acts accordingly
        Try
            If CurrMonth = UmAlQuraInstance.GetMonthsInYear(CurrYear) Then
                CurrYear += 1
                CurrMonth = 1
            Else
                CurrMonth += 1
            End If
        Catch exception As ArgumentException
            MessageBox.Show(exception.Message)
        End Try
        Try
            If CurrDay = 30 And UmAlQuraInstance.GetDaysInMonth(CurrYear, CurrMonth) < 30 Then
                CurrDay = 29
            End If
        Catch exception As ArgumentException
            MessageBox.Show(exception.Message)
        End Try
        Painter()
    End Sub

    Private Sub FrontButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrontButton.Click
        If CurrMonth = 1 Then
            CurrYear = CurrYear - 1
            Try
                CurrMonth = UmAlQuraInstance.GetMonthsInYear(CurrYear)
            Catch exception As ArgumentException
                MessageBox.Show(exception.Message)
            End Try
        Else
            CurrMonth = CurrMonth - 1
        End If
        Try
            If CurrDay = 30 And UmAlQuraInstance.GetDaysInMonth(CurrYear, CurrMonth) < 30 Then
                CurrDay = 29
            End If
        Catch exception As ArgumentException
            MessageBox.Show(exception.Message)
        End Try
        Painter()

    End Sub
End Class

