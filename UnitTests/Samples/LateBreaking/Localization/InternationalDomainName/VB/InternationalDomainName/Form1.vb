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
'
'A range of different International Domain Names you can try:
'    http://www.bücher.de - a German Internet bookstore
'    http://理容ナカムラ.com - Nakamura Barber Shop: Japanese company site
'    http://www.푸른소아과.com - Poorunsoahkwa: Korean pediatric medicine site
'
'More information on the technology behind International Domain Names is available on:
'    http://www.verisign.com/products-services/naming-and-directory-services/naming-services/internationalized-domain-names/
'  
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class Form1
    Inherits Form

    Private Sub ButtonGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGo.Click
        ' This code section extracts the protocol, host section and extension of the string that is
        ' entered in the address control
        ' A more sophisticated verification is recommended to make this adapt for all possible erroneous input
        Dim r As New Regex("(?<proto>\w+)://(?<host>[\w.]+)/*(?<ext>\S*)", RegexOptions.Compiled)
        Dim proto As String = r.Match(Me.TextBoxAddress.Text).Result("${proto}")
        Dim host As String = r.Match(Me.TextBoxAddress.Text).Result("${host}")
        Dim ext As String = r.Match(Me.TextBoxAddress.Text).Result("${ext}")

        ' Convert the entered IDN host name to Punycode
        Dim mapping As New IdnMapping()
        Dim puny As String = mapping.GetAscii(host)

        ' Assemble the URL and navigate to the specified site
        Me.TextBoxPunycode.Text = proto + "://" + puny + "/" + ext
        Me.WebBrowser1.Navigate(Me.TextBoxPunycode.Text)
    End Sub
End Class
