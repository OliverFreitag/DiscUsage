Partial Public Class TZConv
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
        Me.TxtSourceDate = New System.Windows.Forms.TextBox
        Me.CmbDestTZ = New System.Windows.Forms.ComboBox
        Me.LblDestDate = New System.Windows.Forms.Label
        Me.BtnConvert = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUTCDate = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtSourceDate
        '
        Me.TxtSourceDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSourceDate.Location = New System.Drawing.Point(12, 32)
        Me.TxtSourceDate.Name = "TxtSourceDate"
        Me.TxtSourceDate.Size = New System.Drawing.Size(268, 23)
        Me.TxtSourceDate.TabIndex = 1
        '
        'CmbDestTZ
        '
        Me.CmbDestTZ.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbDestTZ.FormattingEnabled = True
        Me.CmbDestTZ.Location = New System.Drawing.Point(12, 81)
        Me.CmbDestTZ.Name = "CmbDestTZ"
        Me.CmbDestTZ.Size = New System.Drawing.Size(365, 24)
        Me.CmbDestTZ.TabIndex = 2
        '
        'LblDestDate
        '
        Me.LblDestDate.AutoSize = True
        Me.LblDestDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDestDate.Location = New System.Drawing.Point(383, 84)
        Me.LblDestDate.Name = "LblDestDate"
        Me.LblDestDate.Size = New System.Drawing.Size(10, 18)
        Me.LblDestDate.TabIndex = 3
        Me.LblDestDate.Text = "."
        '
        'BtnConvert
        '
        Me.BtnConvert.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConvert.Location = New System.Drawing.Point(12, 123)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(95, 27)
        Me.BtnConvert.TabIndex = 4
        Me.BtnConvert.Text = "&Convert"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(471, 123)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(95, 27)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "&Exit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Target TimeZone"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Source Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(383, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Target Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "UTC Date"
        '
        'lblUTCDate
        '
        Me.lblUTCDate.AutoSize = True
        Me.lblUTCDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTCDate.Location = New System.Drawing.Point(383, 35)
        Me.lblUTCDate.Name = "lblUTCDate"
        Me.lblUTCDate.Size = New System.Drawing.Size(10, 18)
        Me.lblUTCDate.TabIndex = 10
        Me.lblUTCDate.Text = "."
        '
        'TZConv
        '
        Me.ClientSize = New System.Drawing.Size(578, 163)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUTCDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnConvert)
        Me.Controls.Add(Me.LblDestDate)
        Me.Controls.Add(Me.CmbDestTZ)
        Me.Controls.Add(Me.TxtSourceDate)
        Me.Name = "TZConv"
        Me.Text = "Convert Dates between TimeZones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSourceDate As System.Windows.Forms.TextBox
    Friend WithEvents CmbDestTZ As System.Windows.Forms.ComboBox
    Friend WithEvents LblDestDate As System.Windows.Forms.Label
    Friend WithEvents BtnConvert As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUTCDate As System.Windows.Forms.Label

End Class
