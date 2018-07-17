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
Option Explicit On
Option Strict On

Imports System
Imports System.Collections
Imports System.Text
Imports System.Security.Permissions

<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, _
Assertion:=True)> 
<Module: CLSCompliant(True)> 
Namespace Microsoft.Samples.GB18030EncodingVB
    'In order to see the DBCS characters in your Console Window, you need
    'change the code page to 936, even when this is done, you could only 
    'see GB18030-only characters as ?
    Class GB18030Encoding

        Shared unicode As Encoding = Encoding.Unicode
        Shared GB18030 As Encoding = Encoding.GetEncoding(54936)
        Shared GB2312 As Encoding = Encoding.GetEncoding(936)
        Shared bUnicode(128) As Byte
        Shared bGB18030(128) As Byte
        Shared bGB2312(128) As Byte

        'Private Sub GB18030Encoding()
        'End Sub

        Public Shared Sub Main()
            Dim sGB18030, sUnicode, sGB2312 As String
            Dim cGB18030(64) As Char
            Dim sl1 As SortedList = New SortedList()
            Dim sl2 As SortedList = New SortedList()
            Dim sl4 As SortedList = New SortedList()
            Dim i, byteCount, charCount, bn As Integer

            'This part of the sample will demonstrate that .NET Framework
            'supported GB18030 encoding as one of its encodings, so it awares
            'that GB18030 encoding is a variable length format which allows
            '1, 2 and 4 bytes
            Console.Write("First Part: GB18030 is a variable length")
            Console.WriteLine(" formating")
            'The Unicode string which contains 1/2/4-bytes in GB18030 
            'encoding is \u3400 \u0061 \u0061 \u554A 
            '\u554A \u3400 \u3400 \u554A \u0061
            'In GB18030 encoding \u3400 is encoded as 8139EE39
            'which is 4 bytes
            'In GB18030 encoding \u0061 is encoded as 61 which is 1 byte
            'In GB18030 encoding \u5541 is encoded as B0A1 which is 2 byte
            sUnicode = ChrW(&H3400) & ChrW(&H61) & ChrW(&H61) & ChrW(&H554A) & _
                       ChrW(&H554A) & ChrW(&H3400) & ChrW(&H3400) & ChrW(&H554A) & _
                       ChrW(&H61)
            'Get Unicode byte array from Unicode string
            bUnicode = unicode.GetBytes(sUnicode)
            'Get GB18030 byte array from Unicode byte array            
            bGB18030 = Encoding.Convert(unicode, GB18030, bUnicode)
            'Get GB18030 encoded string from GB18030 byte array
            sGB18030 = GB18030.GetString(bGB18030)
            Console.WriteLine("The GB18030 string is {0}", sGB18030)
            'Get the char count of GB18030 encoded byte array
            charCount = GB18030.GetCharCount(bGB18030)
            'Get the byte count of GB18030 encoded string
            byteCount = GB18030.GetByteCount(sGB18030)
            Console.WriteLine("It has {0} chars, {1} bytes", charCount, _
                            byteCount)
            'Get GB18030 char array from GB18030 byte array  
            cGB18030 = GB18030.GetChars(bGB18030)
            For i = 0 To charCount - 1 Step 1
                bn = GB18030.GetByteCount(cGB18030(i).ToString())
                Console.WriteLine("No.{0} char is {1}, it has {2} bytes", i, _
                                cGB18030(i), bn)
                Select Case bn
                    'Add 1-byte GB18030 encoded char to sl1
                    Case 1
                        sl1.Add(i, cGB18030(i))
                        'Add 2-byte GB18030 encoded char to sl1
                    Case 2
                        sl2.Add(i, cGB18030(i))
                        'Add 4-byte GB18030 encoded char to sl1
                    Case 4
                        sl4.Add(i, cGB18030(i))
                    Case Else
                        Console.WriteLine("Invalid GB18030 encoding!")
                End Select
            Next
            Console.WriteLine("The string has {0} 1-byte characters, they are" _
                            , sl1.Count)
            PrintKeysAndValues(sl1)
            Console.WriteLine("The string has {0} 2-byte characters, they are" _
                            , sl2.Count)
            PrintKeysAndValues(sl2)
            Console.WriteLine("The string has {0} 4-byte characters, they are" _
                            , sl2.Count)
            PrintKeysAndValues(sl4)

            'Below part sample demonstrate to convert a Unicode string
            'to GB18030 and then to GB2312 and then back to Unicode 
            Console.WriteLine()
            Console.WriteLine("Second Part: Encoding Conversion")
            sUnicode = ChrW(&H4E02) & ChrW(&H4E90) & ChrW(&H9CCC) & ChrW(&H9F44) & _
                       ChrW(&H4E96) & ChrW(&H6C49) & ChrW(&H724B) & ChrW(&H9F22) & _
                       ChrW(&H8140) & ChrW(&H512C) & ChrW(&H7218) & ChrW(&H7222) & _
                       ChrW(&H4E06) & ChrW(&H9C49) & ChrW(&H71EC) & ChrW(&H716A) & _
                       ChrW(&H4F04) & ChrW(&H7667) & ChrW(&H76F6) & ChrW(&H7788) & _
                       ChrW(&H7789) & ChrW(&H8A3D) & ChrW(&H8B20) & ChrW(&H9C78) & _
                       ChrW(&H5FA0) & ChrW(&H74EA) & ChrW(&H74D9) & ChrW(&H616F) & _
                       ChrW(&H616B) & ChrW(&H6142)
            Console.WriteLine("The original Unicode string is {0}", sUnicode)
            sGB18030 = UnicodeToGB18030(sUnicode)
            Console.WriteLine("Convert to GB18030 the string is {0}", _
                            sGB18030)
            sGB2312 = GB18030ToGB2312(sGB18030)
            Console.WriteLine("Convert to GB2312 the string is {0}", sGB2312)
            sUnicode = GB2312ToUnicode(sGB2312)
            Console.WriteLine("Convert back to Unicode the string is {0}", _
                            sUnicode)
        End Sub 'Main

        'Print the Key and Value in the SortedList
        Public Shared Sub PrintKeysAndValues(ByVal myList As SortedList)
            Dim i As Integer
            Console.WriteLine(vbTab & "-KEY-" & vbTab & "-VALUE-")
            For i = 0 To myList.Count - 1 Step 1
                Console.WriteLine(vbTab & "{0}:" & vbTab & "{1}", _
                                myList.GetKey(i), myList.GetByIndex(i))
            Next
            Console.WriteLine()
        End Sub

        'Print the contents of the byte array in hexadecimal format
        Public Shared Sub PrintByte(ByVal bytes As Byte())
            Dim i As Integer
            For i = 0 To bytes.Length - 1 Step 1
                Console.Write("({0:X}) ", bytes(i))
            Next
            Console.WriteLine()
        End Sub

        Public Shared Function UnicodeToGB18030(ByVal sUnicode As String) As String
            Try
                bUnicode = unicode.GetBytes(sUnicode)
                Console.WriteLine("The Unicode Encoding of the string is as" _
                            & " below, it has {0} bytes:", bUnicode.Length)
                PrintByte(bUnicode)
                'Convert Unicode to GB18030
                bGB18030 = Encoding.Convert(unicode, GB18030, bUnicode)
                Console.WriteLine("The GB18030 Encoding of the string is as" _
                            & " below, it has {0} bytes:", bGB18030.Length)
                PrintByte(bGB18030)
                Return GB18030.GetString(bGB18030)
            Catch e As System.IndexOutOfRangeException
                Console.WriteLine(e.Message)
                Return "Converstion Failed"
            End Try
        End Function

        Public Shared Function GB18030ToGB2312(ByVal sGB18030 As String) As String
            Try
                bGB18030 = GB18030.GetBytes(sGB18030)
                Console.WriteLine("The GB18030 Encoding of the string is as" _
                            & " below, it has {0} bytes:", bGB18030.Length)
                PrintByte(bGB18030)
                'Convert GB18030 to GB2312
                bGB2312 = Encoding.Convert(GB18030, GB2312, bGB18030)
                Console.WriteLine("The GB2312 Encoding of the string is as" _
                            & " below, it has {0} bytes:", bGB2312.Length)
                PrintByte(bGB2312)
                Return GB2312.GetString(bGB2312)
            Catch e As System.IndexOutOfRangeException
                Console.WriteLine(e.Message)
                Return "Converstion Failed"
            End Try
        End Function

        Public Shared Function GB2312ToUnicode(ByVal sGB2312 As String) As String
            Try
                bGB2312 = GB2312.GetBytes(sGB2312)
                Console.WriteLine("The GB2312 Encoding of the string is as" _
                            & " below, it has {0} bytes:", bGB2312.Length)
                PrintByte(bGB2312)
                'Convert GB2312 to Unicode
                bUnicode = Encoding.Convert(GB2312, unicode, bGB2312)
                Console.WriteLine("The Unicode Encoding of the string is as" _
                            & " below, it has {0} bytes:", bGB2312.Length)
                PrintByte(bUnicode)
                Return unicode.GetString(bUnicode)
            Catch e As System.IndexOutOfRangeException
                Console.WriteLine(e.Message)
                Return "Converstion Failed"
            End Try
        End Function

    End Class

End Namespace
