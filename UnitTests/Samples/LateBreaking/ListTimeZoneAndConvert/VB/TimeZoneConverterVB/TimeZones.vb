Imports System.Runtime.InteropServices
Imports Microsoft.Win32

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
''' TimeZoneList
''' 
''' implements a sorted list of TimeZones by reading the Windows Registry - which is currently the only place where thery are stored
''' </summary>
''' <remarks></remarks>
Public Class TimeZoneList
    Inherits System.Collections.ArrayList


    Public Sub New()
        Me.Initialize()
    End Sub

    Public Overloads ReadOnly Property Item(ByVal StandardName As String) As TimeZone
        Get
            Dim i As Integer
            ' Look for the Item by StandardName
            For i = 0 To MyBase.Count - 1
                If (CType(MyBase.Item(i), TimeZone).StandardName = StandardName) Then
                    ' Return it if found
                    Return CType(MyBase.Item(i), TimeZone)
                End If
            Next
            ' Return nothing if not found
            Return Nothing
        End Get
    End Property

    Private Sub Initialize()
        Dim hKeyRoot As RegistryKey
        Dim hKeyTZ As RegistryKey
        Dim hKey As RegistryKey

        Dim tz As TimeZone

        Dim stTZKey As String
        Dim KeySet() As String

        Dim i As Integer


        hKeyRoot = Registry.LocalMachine

        ' Hack Hack - reading the registry ...
        ' first try with NT/2k/Xp key
        stTZKey = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones"
        hKeyTZ = hKeyRoot.OpenSubKey(stTZKey)
        If hKeyTZ Is Nothing Then
            'else try with 9x key
            stTZKey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Time Zones"
            hKeyTZ = hKeyRoot.OpenSubKey(stTZKey)
            If hKeyTZ Is Nothing Then
                Dim e As New Exception(String.Format("No <{0}> registry key found!", stTZKey))
                Throw e
            End If
        End If


        'now add all subkeys
        KeySet = hKeyTZ.GetSubKeyNames()
        For i = 0 To hKeyTZ.SubKeyCount - 1
            hKey = hKeyTZ.OpenSubKey(KeySet(i))
            '... with some properties
            tz = New TimeZone(hKey)
            hKey.Close()

            ' Add in list sorted by Order/Index property
            If i = 0 Then
                ' add anyway if it's the first item
                MyBase.Add(tz)
            Else
                ' look for the right place to insert the new item
                Dim j As Integer
                For j = 0 To MyBase.Count - 1
                    ' try inserting before
                    If tz.Order < CType(MyBase.Item(j), TimeZone).Order Then
                        Exit For
                    End If
                Next
                'else check if it has to be added after or it's the first one
                If j >= MyBase.Count Then
                    MyBase.Add(tz)
                Else
                    MyBase.Insert(j, tz)
                End If
            End If

            tz = Nothing
        Next
        hKeyTZ.Close()

        hKey = Nothing
        hKeyTZ = Nothing
        hKeyRoot = Nothing
    End Sub

End Class


''' <summary>
''' TimeZone
''' exposes all properties for a TimeZone, based on the Windows Registry information
''' </summary>
''' <remarks></remarks>

Public Class TimeZone

    Public Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    Public Structure REG_TIMEZONE_INFO
        Public Bias As Int32
        Public StandardBias As Int32
        Public DaylightBias As Int32
        Public StandardDate As SYSTEMTIME
        Public DaylightDate As SYSTEMTIME
    End Structure

    Private Declare Sub RtlMoveMemory Lib "kernel32" (ByRef pDest As REG_TIMEZONE_INFO, ByRef pSource As Byte, ByVal ByteLen As Integer)


    Private m_stDisplayName As String
    Private m_stStandardName As String
    Private m_stDaylightName As String
    Private m_index As Integer
    Private m_tzi As REG_TIMEZONE_INFO
    Private m_Order As Integer

    ' Static methods that returns the list of timezones
    Public Shared Function GetTimeZones() As TimeZoneList
        Return New TimeZoneList
    End Function



    ' Internal constructor that initializes the TimeZone from a registry key
    Public Sub New(ByVal key As RegistryKey)
        m_DaylightName = key.GetValue("Dlt").ToString()
        m_StandardName = key.GetValue("Std").ToString()
        m_DisplayName = key.GetValue("Display").ToString()
        m_Order = CInt(key.GetValue("Index"))

        Dim bytes() As Byte = DirectCast(key.GetValue("TZI"), Byte())
        RtlMoveMemory(m_tzi, bytes(0), Marshal.SizeOf(m_tzi))
    End Sub

    ' The DisplayName property 
    Private m_DisplayName As String

    Public ReadOnly Property DisplayName() As String
        Get
            Return m_DisplayName
        End Get
    End Property

    ' The StandardName property 
    Private m_StandardName As String

    Public ReadOnly Property StandardName() As String
        Get
            Return m_StandardName
        End Get
    End Property

    ' The DaylightName property 
    Private m_DaylightName As String

    Public ReadOnly Property DaylightName() As String
        Get
            Return m_DaylightName
        End Get
    End Property

    ' The Bias property
    Public ReadOnly Property Bias() As Integer
        Get
            Return -m_tzi.Bias
        End Get
    End Property

    ' The StandardBias property
    Public ReadOnly Property StandardBias() As Integer
        Get
            Return m_tzi.StandardBias
        End Get
    End Property

    ' The DaylightBias property
    Public ReadOnly Property DaylightBias() As Integer
        Get
            Return m_tzi.DaylightBias
        End Get
    End Property

    ' The StandardDate property
    Public ReadOnly Property StandardDate() As SYSTEMTIME
        Get
            Return m_tzi.StandardDate
        End Get
    End Property

    ' The DaylightDate property
    Public ReadOnly Property DaylightDate() As SYSTEMTIME
        Get
            Return m_tzi.DaylightDate
        End Get
    End Property

    ' The Order (Index) property
    Public ReadOnly Property Order() As Integer
        Get
            Order = m_Order
        End Get
    End Property

    ' overriding default Tostring to retun the DisplayName
    Public Overrides Function ToString() As String
        Return m_DisplayName
    End Function

End Class
