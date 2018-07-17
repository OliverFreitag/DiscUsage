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
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Threading
Imports System.Resources
Imports System.Reflection
Imports System.Security.Permissions



<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, _
Assertion:=True)> 
<Module: CLSCompliant(True)> 
Namespace Microsoft.Samples.ChineseCalendarVB

    Public Class ChineseLunarCalendar
        Inherits System.Globalization.ChineseLunisolarCalendar

        Public Sub ChineseLunarCalendar()

        End Sub


        '/ <summary>
        '/ Get the Chinese Sexagenay Year name.
	'/ Lunisolar calendars for other East Asian regions with similar functionality
	'/ are also available and this sample can be adapted for them. 
	'/ Please check the documentation or local websites for more information.
        '/ </summary>
        '/ <param name="time">DateTime value</param>
        '/ <returns>Sexagenary Year name</returns>
        Public Function GetChineseSexagenaryYear(ByVal time As DateTime) As String
            Dim intSexagenary As Integer = MyBase.GetSexagenaryYear(time)
            Dim indexOfCelestial As Integer = MyBase.GetCelestialStem(intSexagenary)
            Dim indexOfTerrestrial As Integer = MyBase.GetTerrestrialBranch(intSexagenary)

            Dim celestialStemFromRes As String = rmStrings.GetString("CelestialStem")
            Dim terrestrialBranchFromRes As String = rmStrings.GetString("TerrestrialBranch")
            Dim celestialStem As String() = celestialStemFromRes.Split(","c)
            Dim terrestrialBranch As String() = terrestrialBranchFromRes.Split(","c)
            Return celestialStem((indexOfCelestial - 1)) + terrestrialBranch((indexOfTerrestrial - 1))
        End Function 'GetChineseSexagenaryYear
        '/ <summary>
        '/ Get the index in solar term list by passing 
        '/ </summary>
        '/ <param name="time">Current datetime</param>
        '/ <returns>Index of "LunarHolDayName"</returns>
        Private Function GetTermIndex(ByVal time As DateTime) As Integer
            Dim iMonth, iDay, isFirst As Integer
            isFirst = 0

            iMonth = time.Month
            iDay = time.Day
            If iDay < 15 Then
                isFirst = 1
            End If
            'Compare current day with real solar term day.If current date is valid solar term,
            'return the according index in "LunarHolDayName" array.
            If iDay = GetTermDate(time) Then
                Return iMonth * 2 - isFirst - 1

            Else
                Return -1
            End If
        End Function 'GetTermIndex
        '/ <summary>
        '/ Get term day of current month from data table.
        '/ </summary>
        '/ <param name="time">DateTime type</param>
        '/ <returns>Day of term</returns>
        Private Function GetTermDate(ByVal time As DateTime) As Integer
            Dim Offset As Byte
            Dim iYear, iMonth, iDay, TermDay, isFirst As Integer
            isFirst = 0
            iYear = time.Year
            iMonth = time.Month
            iDay = time.Day

            Try
                'Get the according offset in static data table.
                Offset = SolarTermData((iYear - MIN_YEAR.Year))(((iMonth - 1) \ 2))

                'According to the day of month to separate one bit to 
                'four pieces to indicate the right offset. 
                If iMonth Mod 2 <> 0 Then
                    If iDay < 15 Then
                        Offset = CByte(Offset >> 6)
                        isFirst = 1
                    Else
                        Offset = CByte(CByte(Offset And &H3F) >> 4)
                    End If
                Else
                    If iDay < 15 Then
                        Offset = CByte(CByte(Offset And &HC) >> 2)
                        isFirst = 1
                    Else
                        Offset = CByte(Offset And &H3)
                    End If
                End If
                'From baseday and offset,get the real solar term day.
                If isFirst = 1 Then
                    TermDay = BaseDay(((iMonth - 1) * 2)) + Offset
                Else
                    TermDay = BaseDay(((iMonth - 1) * 2 + 1)) + Offset
                End If

            Catch CastExcep As InvalidCastException
                Throw New InvalidCastException(rmStrings.GetString("CastError"))

            End Try
            Return TermDay
        End Function 'GetTermDate 

        '/ <summary>
        '/ Get the ChineseZodiac name.
        '/ </summary>
        '/ <param name="time">DateTime value</param>
        '/ <returns>Chinese Zodiac name</returns>
        Public Function GetChineseZodiac(ByVal time As DateTime) As String
            Dim intSexagenary As Integer = MyBase.GetSexagenaryYear(time)
            Dim indexOfTerrestrial As Integer = MyBase.GetTerrestrialBranch(intSexagenary)
            Dim zodiacFromRes As String = rmStrings.GetString("ChineseZodiac")
            Dim zodiacArray As String() = zodiacFromRes.Split(","c)
            Return zodiacArray((indexOfTerrestrial - 1))
        End Function 'GetChineseZodiac
        '/ <summary>
        '/ Get the right solar term by passing one valid datetime parameter.
        '/ </summary>
        '/ <param name="selectedDate">Datetime value</param>
        '/ <returns>Chinese name of solar term</returns>
        Public Function GetSolarTerms(ByVal selectedDate As DateTime) As String
            If selectedDate > MAX_YEAR Or selectedDate < MIN_YEAR Then
                Throw New ArgumentOutOfRangeException(rmStrings.GetString("ExceptionName"), _
                rmStrings.GetString("OutOfRangeException"))
            End If
            If selectedDate = BLANK_YEAR Then
                Return ""
            End If
            Dim solarTermIndex As Integer = GetTermIndex(selectedDate)
            If solarTermIndex < 0 Then
                Return ""
            End If
            Dim solarTermsFromRes As String = rmStrings.GetString("SolarTerms")
            Dim solarTermsArray As String() = solarTermsFromRes.Split(","c)
            Return solarTermsArray(solarTermIndex)
        End Function 'GetSolarTerms 
        '/ <summary>
        '/ Return the datetime of next term according to the current datetime.
        '/ </summary>
        '/ <param name="time">Current datetime</param>
        '/ <returns>The datetime of next term</returns>
        Public Function GetNextTermDate(ByVal time As DateTime) As DateTime
            If time > MAX_YEAR Or time < MIN_YEAR Then
                Throw New ArgumentOutOfRangeException(rmStrings.GetString("ExceptionName"), _
                rmStrings.GetString("OutOfRangeException"))
            Else
                If time > New DateTime(2020, 12, 21) Then
                    Return BLANK_YEAR 'Return the invalid datetime
                End If
            End If
            Dim CurrentTermDay, iDay As Integer
            iDay = time.Day
            CurrentTermDay = GetTermDate(time)

            If iDay < CurrentTermDay Then
                Return time.AddDays((CurrentTermDay - iDay))
            Else
                If iDay > 15 Then
                    'Cacluate the next term of next month.
                    Dim nextMonthTermDate As New DateTime(time.Year, time.Month, GetTermDate(time.AddDays(14)))
                    Return nextMonthTermDate.AddMonths(1)
                Else
                    Return New DateTime(time.Year, time.Month, GetTermDate(time.AddDays(15)))
                End If
            End If
        End Function 'GetNextTermDate 

        Private MAX_YEAR As New DateTime(2020, 12, 31)
        Private MIN_YEAR As New DateTime(2000, 1, 1)
        Private BLANK_YEAR As New DateTime(1, 1, 1)

        'The minimum solar term day of every month,two digitals every month.
        Private BaseDay() As Integer = {5, 19, 3, 18, 5, 20, 4, 19, 5, 20, 5, _
        20, 6, 22, 7, 22, 7, 22, 7, 22, 7, 21, 6, 21}


        'Manager to manage the local string resources.
        Private rmStrings As New Resources.ResourceManager("Strings", _
        Assembly.GetExecutingAssembly())

        'Stored 21X6 size matrix to record solar term offset every month from 2000-1-1 to 2020-12-31
        'Every bit represents two months or four solar terms offsets.
        Private SolarTermData As Byte()() = { _
        New Byte() {&H65, &H1, &H11, &H41, &H15, &H14}, _
        New Byte() {&H14, &H5, &H11, &H51, &H15, &H15}, _
        New Byte() {&H15, &H55, &H55, &H55, &H55, &H15}, _
        New Byte() {&H55, &H55, &H56, &H55, &H5A, &H65}, _
        New Byte() {&H65, &H1, &H11, &H41, &H15, &H14}, _
        New Byte() {&H14, &H5, &H11, &H51, &H15, &H15}, _
        New Byte() {&H15, &H55, &H15, &H51, &H55, &H15}, _
        New Byte() {&H55, &H55, &H56, &H55, &H5A, &H65}, _
        New Byte() {&H65, &H1, &H11, &H41, &H5, &H14}, _
        New Byte() {&H14, &H1, &H11, &H51, &H15, &H15}, _
        New Byte() {&H15, &H55, &H15, &H51, &H55, &H15}, _
        New Byte() {&H55, &H55, &H56, &H55, &H56, &H65}, _
        New Byte() {&H65, &H1, &H1, &H41, &H5, &H14}, _
        New Byte() {&H14, &H1, &H11, &H41, &H15, &H15}, _
        New Byte() {&H15, &H55, &H15, &H51, &H55, &H15}, _
        New Byte() {&H55, &H55, &H56, &H55, &H56, &H55}, _
        New Byte() {&H55, &H0, &H1, &H41, &H5, &H14}, _
        New Byte() {&H10, &H1, &H11, &H41, &H15, &H15}, _
        New Byte() {&H15, &H15, &H15, &H51, &H55, &H15}, _
        New Byte() {&H15, &H55, &H55, &H55, &H56, &H55}, _
        New Byte() {&H55, &H0, &H1, &H0, &H5, &H14}}
    End Class
End Namespace