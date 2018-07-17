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
Imports System.Globalization

Module Module1

    Sub Main()
        ' Creates and initializes a CultureInfo.
        Dim jCI As New CultureInfo("ja-JP")

        ' Associate a Japanese Calendar to the CultureInfo.
        jCI.DateTimeFormat.Calendar = New JapaneseCalendar()

        ' Creates a DateTime with the Gregorian date January 3, 2002 (year=2002, month=1, day=3).
        Dim DT As New DateTime(2002, 1, 3)

        ' Shown with Gregorian date by Default.
        Console.WriteLine(DT.ToString("gg yyyy.MM.dd"))
        ' Shown with Japanese ERA by using Japanese CultureInfo.
        Console.WriteLine(DT.ToString("gg yyyy.MM.dd", jCI))

        ' If you do not provide a DateTimeFormatter, DateTime.Parse will parse strings by referring
        ' Control panel settings. 
        ' The string will be parsed as Oct 5, 2006 (year=2006, month=10, day=5) if the regional setting
        ' is default English (United States).
        ' If the regional setting is default Japanese, it will be parsed as May 6, 2010.
        DT = DateTime.Parse("10/5/6")
        Console.WriteLine(DT.ToString())

        ' Will be parsed as a Japanese date May 6, Heisei 10 (year=1998)
        DT = DateTime.Parse("10/5/6", jCI)
        Console.WriteLine(DT.ToString())

        ' Will be parsed as a Japanese date May 6, Showa 60 (year=1985)
        DT = DateTime.Parse("S60/5/6", jCI)
        Console.WriteLine(DT.ToString())

    End Sub

End Module
