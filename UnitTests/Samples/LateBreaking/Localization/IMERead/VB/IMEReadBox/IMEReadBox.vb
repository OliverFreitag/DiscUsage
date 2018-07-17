'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
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
'-----------------------------------------------------------------------
Public Class IMEReadingStringBox
    Inherits System.Windows.Forms.TextBox
    Private readingStr As String = ""
    Private clauseReadingString As String = ""
    ''' <summary>
    '''  Occurs when the value of the ReadingString property has changed
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.Category("Default")> _
    Public Event ReadingStringChanged As EventHandler

    Public ReadOnly Property ReadingString() As String
        Get
            Return readingStr
        End Get
    End Property

    ' Declaration to call Win32 API.
    <DllImport("imm32.dll", CharSet:=CharSet.Unicode)> _
    Shared Function ImmGetContext(ByVal Hwnd As IntPtr) As IntPtr
    End Function
    <DllImport("imm32.dll", CharSet:=CharSet.Unicode)> _
    Shared Function ImmGetCompositionString(ByVal Himc As IntPtr, ByVal Index As Integer, ByVal Buffer As Byte(), ByVal BufferSize As Integer) As IntPtr
    End Function

    ' Constants defined in Imm.h
    Const WM_IME_COMPOSITION As Integer = &H10F
    Const GCS_RESULTREADSTR As Integer = &H200

    ' Called when receiving WM_IME_COMPOSITION message.
    Private Sub OnImeComposition(ByVal m As Message)
        ' Skip messages unless resulted reading string is updated.
        If ((CInt(m.LParam) And GCS_RESULTREADSTR) <> 0) Then
            Dim context As IntPtr = ImmGetContext(Me.Handle)
            Dim size As Integer = ImmGetCompositionString(context, GCS_RESULTREADSTR, Nothing, 0)
            Dim buffer(size) As Byte

            ' Retrieve reading string from IME
            size = ImmGetCompositionString(context, GCS_RESULTREADSTR, buffer, CUInt(size))
            clauseReadingString = New System.Text.UnicodeEncoding().GetString(buffer, 0, size)

            ' Update ReadingString property
            readingStr = readingStr & clauseReadingString

            ' Notify change of ReadingString property
            OnReadingStringChanged(New EventArgs())
        End If
    End Sub
    ''' <summary>
    ''' Raises the ReadingStringChanged event.
    ''' </summary>
    ''' <param name="e">An System.EventArgs that contains the event data.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnReadingStringChanged(ByVal e As EventArgs)
        RaiseEvent ReadingStringChanged(Me, e)
    End Sub
    ' Override WndProc to process WM_IME_COMPOSITION message.
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case (m.Msg)
            Case WM_IME_COMPOSITION
                OnImeComposition(m)
        End Select
        DefWndProc(m)
    End Sub

End Class
