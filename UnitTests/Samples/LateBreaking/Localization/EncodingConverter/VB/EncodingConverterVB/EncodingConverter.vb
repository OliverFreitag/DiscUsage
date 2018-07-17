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

Imports System.IO
Imports System.Text
Imports System.Globalization

''' <summary>
''' This sample demonstrates how to use the System.Text.Encoding class to
''' safely convert text files between two encodings.
''' </summary>

Module EncodingConverter

    Dim IsSilent As Boolean
    Dim inputFile, outputFile As String
    Dim userInputCodepage, userOutputCodepage As String
    Dim tempFile As String = "netenc.tmp"

    Function Main(ByVal Args() As String) As Integer
        Try
            ' Restrict input to between one and five parameters.
            If Args.Length = 0 Or Args.Length > 5 Then
                ShowInstructions()
                Exit Function
            ElseIf Args.Length = 1 Then
                If Args(0) = "-l" Then
                    GetEncodingsList()
                    Exit Function
                Else
                    ShowInstructions()
                    Exit Function
                End If
            ElseIf Args.Length >= 4 Then
                userInputCodepage = Args(0)
                inputFile = Args(1)
                userOutputCodepage = Args(2)
                outputFile = Args(3)
                If Args.Length > 4 Then
                    If Args(4) = "-s" Then
                        ' Omit all non-error messages from console output.
                        IsSilent = True
                    End If
                End If
            Else
                ShowInstructions()
                Exit Function
            End If
        Catch ex As Exception
            Console.WriteLine _
            ("Operation cancelled due to the following error:")
            Console.WriteLine _
            ("--------------------------------------------------------------")
            Console.WriteLine(ex.Message)
        End Try

        Try
            ' Cast the strings as encodings and perform the conversion.
            ' Use ExceptionFallback parameters to prevent character loss.
            ChangeEncoding(Encoding.GetEncoding(userInputCodepage, _
            EncoderFallback.ExceptionFallback, _
            DecoderFallback.ExceptionFallback), _
            Encoding.GetEncoding(userOutputCodepage, _
            EncoderFallback.ExceptionFallback, _
            DecoderFallback.ExceptionFallback))

        Catch ex As Exception

            Kill(tempFile)
            Console.WriteLine _
            ("Operation cancelled due to the following error:")
            Console.WriteLine _
            ("--------------------------------------------------------------")
            Console.WriteLine(ex.Message)
        End Try

    End Function

    Sub ShowInstructions()
        Console.WriteLine _
        ("Description: Converts text files between specified encodings.")
        Console.WriteLine _
        ("Usage: encconv [input enc] [input file] [output enc] [output file] {-s}")
        Console.WriteLine _
        ("Ex: encconv shift_jis japanese.txt utf-8 unicode.txt -s")
        Console.WriteLine("")
        Console.WriteLine("Input options:")
        Console.WriteLine _
        ("  [input enc]  Read from source file using specified codepage")
        Console.WriteLine("")
        Console.WriteLine("Output options:")
        Console.WriteLine _
        ("  [output enc] Write to target file using specified codepage")
        Console.WriteLine("")
        Console.WriteLine("Other options:")
        Console.WriteLine _
        ("  -s      Suppress warning and information messages")
        Console.WriteLine _
        ("  -l      List supported codepages")
        Console.WriteLine("")
        Console.WriteLine _
        ("Warning: Converting files either to or between non-Unicode ")
        Console.WriteLine _
        ("encodings may cause character data to be lost.")
    End Sub

    Sub GetEncodingsList()
        Dim EncodingsList(), enc As EncodingInfo
        EncodingsList = Encoding.GetEncodings()

        Console.WriteLine("Encoding Name and Display Name")
        Console.WriteLine("------------------------------")
        For Each enc In EncodingsList
            ' Output the number and friendly name for each available codepage.
            Console.WriteLine(enc.Name & _
            CultureInfo.CurrentCulture.TextInfo.ListSeparator & _
            " " & enc.DisplayName())
        Next
    End Sub

    Sub ChangeEncoding(ByVal SourceEncoding As Encoding, _
    ByVal TargetEncoding As Encoding)
        Dim tempString As String
        ' Create StreamReader object based on input file and encoding
        Dim sr As New StreamReader(inputFile, SourceEncoding, True)
        ' Create StreamWriter object based on output file and encoding
        ' Write to temporary file in case input and output files are same name
        Dim sw As New StreamWriter(tempFile, False, TargetEncoding)
        ' Read input file contents into temporary string object
        tempString = sr.ReadToEnd()
        sr.Close()
        ' Write output file from temporary string object
        sw.WriteLine(tempString)
        sw.Close()

        If outputFile = inputFile Then
            If IsSilent = False Then
                Console.WriteLine _
                ("Are you sure you want to overwrite the file '{0}'? (Y/N)", _
                inputFile)
                ' Perform case-insensitive comparison of input value
                If String.Compare("Y", Console.ReadLine(), True, _
                CultureInfo.InvariantCulture) = 0 Then
                    ' Input value matched, so delete source file to allow
                    ' temporary file renaming
                    Kill(inputFile)
                Else
                    Console.WriteLine("Operation cancelled.")
                    Exit Sub
                End If
            Else
                ' Running in silent mode, so delete the source file without
                ' showing warning message
                Kill(inputFile)
            End If
        End If

        ' Create new file using name specified for output file
        File.Move(tempFile, outputFile)

        If IsSilent = False Then
            Console.WriteLine("Converted '{0}' from {1} to {2}.", inputFile, _
            SourceEncoding.EncodingName, TargetEncoding.EncodingName)
        End If
    End Sub

End Module



