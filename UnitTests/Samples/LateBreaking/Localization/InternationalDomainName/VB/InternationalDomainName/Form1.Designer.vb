Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelAddress = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxAddress = New System.Windows.Forms.TextBox
        Me.TextBoxPunycode = New System.Windows.Forms.TextBox
        Me.ButtonGo = New System.Windows.Forms.Button
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'LabelAddress
        '
        Me.LabelAddress.AutoSize = True
        Me.LabelAddress.Location = New System.Drawing.Point(13, 13)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Size = New System.Drawing.Size(84, 24)
        Me.LabelAddress.TabIndex = 0
        Me.LabelAddress.Text = "Address:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Punycode:"
        '
        'TextBoxAddress
        '
        Me.TextBoxAddress.Location = New System.Drawing.Point(116, 7)
        Me.TextBoxAddress.Name = "TextBoxAddress"
        Me.TextBoxAddress.Size = New System.Drawing.Size(505, 29)
        Me.TextBoxAddress.TabIndex = 2
        Me.TextBoxAddress.Text = "http://www.bücher.de/"
        '
        'TextBoxPunycode
        '
        Me.TextBoxPunycode.Location = New System.Drawing.Point(116, 44)
        Me.TextBoxPunycode.Name = "TextBoxPunycode"
        Me.TextBoxPunycode.Size = New System.Drawing.Size(505, 29)
        Me.TextBoxPunycode.TabIndex = 3
        '
        'ButtonGo
        '
        Me.ButtonGo.Location = New System.Drawing.Point(643, 7)
        Me.ButtonGo.Name = "ButtonGo"
        Me.ButtonGo.Size = New System.Drawing.Size(75, 30)
        Me.ButtonGo.TabIndex = 4
        Me.ButtonGo.Text = "Go"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(13, 80)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(719, 329)
        Me.WebBrowser1.TabIndex = 5
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(744, 421)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.ButtonGo)
        Me.Controls.Add(Me.TextBoxPunycode)
        Me.Controls.Add(Me.TextBoxAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelAddress)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "International Domain Name Browser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelAddress As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAddress As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPunycode As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGo As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

End Class
