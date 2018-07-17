
Partial Public Class UmAlQuraCalendar
    Inherits System.Windows.Forms.UserControl



    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UmAlQuraCalendar))
        Me.HeaderPanel = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.FrontButton = New System.Windows.Forms.Button
        Me.BackButton = New System.Windows.Forms.Button
        Me.HeaderLabel = New System.Windows.Forms.Label
        Me.FooterPanel = New System.Windows.Forms.FlowLayoutPanel
        Me.FooterLabel = New System.Windows.Forms.Label
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Daylabel1 = New System.Windows.Forms.Label
        Me.Daylabel2 = New System.Windows.Forms.Label
        Me.Daylabel3 = New System.Windows.Forms.Label
        Me.Daylabel4 = New System.Windows.Forms.Label
        Me.Daylabel5 = New System.Windows.Forms.Label
        Me.Daylabel6 = New System.Windows.Forms.Label
        Me.Daylabel7 = New System.Windows.Forms.Label
        Me.DayNo1 = New System.Windows.Forms.Label
        Me.DayNo2 = New System.Windows.Forms.Label
        Me.DayNo3 = New System.Windows.Forms.Label
        Me.DayNo4 = New System.Windows.Forms.Label
        Me.DayNo5 = New System.Windows.Forms.Label
        Me.DayNo6 = New System.Windows.Forms.Label
        Me.DayNo7 = New System.Windows.Forms.Label
        Me.DayNo8 = New System.Windows.Forms.Label
        Me.DayNo9 = New System.Windows.Forms.Label
        Me.DayNo10 = New System.Windows.Forms.Label
        Me.DayNo11 = New System.Windows.Forms.Label
        Me.DayNo12 = New System.Windows.Forms.Label
        Me.DayNo13 = New System.Windows.Forms.Label
        Me.DayNo14 = New System.Windows.Forms.Label
        Me.DayNo15 = New System.Windows.Forms.Label
        Me.DayNo16 = New System.Windows.Forms.Label
        Me.DayNo17 = New System.Windows.Forms.Label
        Me.DayNo18 = New System.Windows.Forms.Label
        Me.DayNo19 = New System.Windows.Forms.Label
        Me.DayNo20 = New System.Windows.Forms.Label
        Me.DayNo21 = New System.Windows.Forms.Label
        Me.DayNo22 = New System.Windows.Forms.Label
        Me.DayNo23 = New System.Windows.Forms.Label
        Me.DayNo24 = New System.Windows.Forms.Label
        Me.DayNo25 = New System.Windows.Forms.Label
        Me.DayNo26 = New System.Windows.Forms.Label
        Me.DayNo27 = New System.Windows.Forms.Label
        Me.DayNo28 = New System.Windows.Forms.Label
        Me.DayNo29 = New System.Windows.Forms.Label
        Me.DayNo30 = New System.Windows.Forms.Label
        Me.DayNo31 = New System.Windows.Forms.Label
        Me.DayNo32 = New System.Windows.Forms.Label
        Me.DayNo33 = New System.Windows.Forms.Label
        Me.DayNo34 = New System.Windows.Forms.Label
        Me.DayNo35 = New System.Windows.Forms.Label
        Me.HeaderPanel.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FooterPanel.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.HeaderPanel.Controls.Add(Me.TableLayoutPanel2)
        resources.ApplyResources(Me.HeaderPanel, "HeaderPanel")
        Me.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.HeaderPanel.Name = "HeaderPanel"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.FrontButton, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BackButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.HeaderLabel, 1, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        '
        'FrontButton
        '
        resources.ApplyResources(Me.FrontButton, "FrontButton")
        Me.FrontButton.ForeColor = System.Drawing.Color.Black
        Me.FrontButton.Name = "FrontButton"
        '
        'BackButton
        '
        resources.ApplyResources(Me.BackButton, "BackButton")
        Me.BackButton.ForeColor = System.Drawing.Color.Black
        Me.BackButton.Name = "BackButton"
        '
        'HeaderLabel
        '
        resources.ApplyResources(Me.HeaderLabel, "HeaderLabel")
        Me.HeaderLabel.Name = "HeaderLabel"
        '
        'FooterPanel
        '
        Me.FooterPanel.BackColor = System.Drawing.Color.White
        Me.FooterPanel.Controls.Add(Me.FooterLabel)
        resources.ApplyResources(Me.FooterPanel, "FooterPanel")
        Me.FooterPanel.Name = "FooterPanel"
        '
        'FooterLabel
        '
        resources.ApplyResources(Me.FooterLabel, "FooterLabel")
        Me.FooterLabel.BackColor = System.Drawing.Color.White
        Me.FooterLabel.Name = "FooterLabel"
        '
        'tableLayoutPanel1
        '
        resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
        Me.tableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3!))
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel2, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel3, 2, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel4, 3, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel5, 4, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel6, 5, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Daylabel7, 6, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo2, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo3, 2, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo4, 3, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo5, 4, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo6, 5, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo7, 6, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo8, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo9, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo10, 2, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo11, 3, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo12, 4, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo13, 5, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo14, 6, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo15, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo16, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo17, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo18, 3, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo19, 4, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo20, 5, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo21, 6, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo22, 0, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo23, 1, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo24, 2, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo25, 3, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo26, 4, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo27, 5, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo28, 6, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo29, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo30, 1, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo31, 2, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo32, 3, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo33, 4, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo34, 5, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.DayNo35, 6, 5)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.82868!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426!))
        '
        'Daylabel1
        '
        resources.ApplyResources(Me.Daylabel1, "Daylabel1")
        Me.Daylabel1.BackColor = System.Drawing.Color.White
        Me.Daylabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel1.Name = "Daylabel1"
        '
        'Daylabel2
        '
        resources.ApplyResources(Me.Daylabel2, "Daylabel2")
        Me.Daylabel2.BackColor = System.Drawing.Color.White
        Me.Daylabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel2.Name = "Daylabel2"
        '
        'Daylabel3
        '
        resources.ApplyResources(Me.Daylabel3, "Daylabel3")
        Me.Daylabel3.BackColor = System.Drawing.Color.White
        Me.Daylabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel3.Name = "Daylabel3"
        '
        'Daylabel4
        '
        resources.ApplyResources(Me.Daylabel4, "Daylabel4")
        Me.Daylabel4.BackColor = System.Drawing.Color.White
        Me.Daylabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel4.Name = "Daylabel4"
        '
        'Daylabel5
        '
        resources.ApplyResources(Me.Daylabel5, "Daylabel5")
        Me.Daylabel5.BackColor = System.Drawing.Color.White
        Me.Daylabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel5.Name = "Daylabel5"
        '
        'Daylabel6
        '
        resources.ApplyResources(Me.Daylabel6, "Daylabel6")
        Me.Daylabel6.BackColor = System.Drawing.Color.White
        Me.Daylabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel6.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel6.Name = "Daylabel6"
        '
        'Daylabel7
        '
        resources.ApplyResources(Me.Daylabel7, "Daylabel7")
        Me.Daylabel7.BackColor = System.Drawing.Color.White
        Me.Daylabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Daylabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.Daylabel7.Name = "Daylabel7"
        '
        'DayNo1
        '
        resources.ApplyResources(Me.DayNo1, "DayNo1")
        Me.DayNo1.BackColor = System.Drawing.Color.White
        Me.DayNo1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DayNo1.Name = "DayNo1"
        '
        'DayNo2
        '
        resources.ApplyResources(Me.DayNo2, "DayNo2")
        Me.DayNo2.BackColor = System.Drawing.Color.White
        Me.DayNo2.Name = "DayNo2"
        '
        'DayNo3
        '
        resources.ApplyResources(Me.DayNo3, "DayNo3")
        Me.DayNo3.BackColor = System.Drawing.Color.White
        Me.DayNo3.Name = "DayNo3"
        '
        'DayNo4
        '
        resources.ApplyResources(Me.DayNo4, "DayNo4")
        Me.DayNo4.BackColor = System.Drawing.Color.White
        Me.DayNo4.Name = "DayNo4"
        '
        'DayNo5
        '
        resources.ApplyResources(Me.DayNo5, "DayNo5")
        Me.DayNo5.BackColor = System.Drawing.Color.White
        Me.DayNo5.Name = "DayNo5"
        '
        'DayNo6
        '
        resources.ApplyResources(Me.DayNo6, "DayNo6")
        Me.DayNo6.BackColor = System.Drawing.Color.White
        Me.DayNo6.Name = "DayNo6"
        '
        'DayNo7
        '
        resources.ApplyResources(Me.DayNo7, "DayNo7")
        Me.DayNo7.BackColor = System.Drawing.Color.White
        Me.DayNo7.Name = "DayNo7"
        '
        'DayNo8
        '
        resources.ApplyResources(Me.DayNo8, "DayNo8")
        Me.DayNo8.BackColor = System.Drawing.Color.White
        Me.DayNo8.Name = "DayNo8"
        '
        'DayNo9
        '
        resources.ApplyResources(Me.DayNo9, "DayNo9")
        Me.DayNo9.BackColor = System.Drawing.Color.White
        Me.DayNo9.Name = "DayNo9"
        '
        'DayNo10
        '
        resources.ApplyResources(Me.DayNo10, "DayNo10")
        Me.DayNo10.BackColor = System.Drawing.Color.White
        Me.DayNo10.Name = "DayNo10"
        '
        'DayNo11
        '
        resources.ApplyResources(Me.DayNo11, "DayNo11")
        Me.DayNo11.BackColor = System.Drawing.Color.White
        Me.DayNo11.Name = "DayNo11"
        '
        'DayNo12
        '
        resources.ApplyResources(Me.DayNo12, "DayNo12")
        Me.DayNo12.BackColor = System.Drawing.Color.White
        Me.DayNo12.Name = "DayNo12"
        '
        'DayNo13
        '
        resources.ApplyResources(Me.DayNo13, "DayNo13")
        Me.DayNo13.BackColor = System.Drawing.Color.White
        Me.DayNo13.Name = "DayNo13"
        '
        'DayNo14
        '
        resources.ApplyResources(Me.DayNo14, "DayNo14")
        Me.DayNo14.BackColor = System.Drawing.Color.White
        Me.DayNo14.Name = "DayNo14"
        '
        'DayNo15
        '
        resources.ApplyResources(Me.DayNo15, "DayNo15")
        Me.DayNo15.BackColor = System.Drawing.Color.White
        Me.DayNo15.Name = "DayNo15"
        '
        'DayNo16
        '
        resources.ApplyResources(Me.DayNo16, "DayNo16")
        Me.DayNo16.BackColor = System.Drawing.Color.White
        Me.DayNo16.Name = "DayNo16"
        '
        'DayNo17
        '
        resources.ApplyResources(Me.DayNo17, "DayNo17")
        Me.DayNo17.BackColor = System.Drawing.Color.White
        Me.DayNo17.Name = "DayNo17"
        '
        'DayNo18
        '
        resources.ApplyResources(Me.DayNo18, "DayNo18")
        Me.DayNo18.BackColor = System.Drawing.Color.White
        Me.DayNo18.Name = "DayNo18"
        '
        'DayNo19
        '
        resources.ApplyResources(Me.DayNo19, "DayNo19")
        Me.DayNo19.BackColor = System.Drawing.Color.White
        Me.DayNo19.Name = "DayNo19"
        '
        'DayNo20
        '
        resources.ApplyResources(Me.DayNo20, "DayNo20")
        Me.DayNo20.BackColor = System.Drawing.Color.White
        Me.DayNo20.Name = "DayNo20"
        '
        'DayNo21
        '
        resources.ApplyResources(Me.DayNo21, "DayNo21")
        Me.DayNo21.BackColor = System.Drawing.Color.White
        Me.DayNo21.Name = "DayNo21"
        '
        'DayNo22
        '
        resources.ApplyResources(Me.DayNo22, "DayNo22")
        Me.DayNo22.BackColor = System.Drawing.Color.White
        Me.DayNo22.Name = "DayNo22"
        '
        'DayNo23
        '
        resources.ApplyResources(Me.DayNo23, "DayNo23")
        Me.DayNo23.BackColor = System.Drawing.Color.White
        Me.DayNo23.Name = "DayNo23"
        '
        'DayNo24
        '
        resources.ApplyResources(Me.DayNo24, "DayNo24")
        Me.DayNo24.BackColor = System.Drawing.Color.White
        Me.DayNo24.Name = "DayNo24"
        '
        'DayNo25
        '
        resources.ApplyResources(Me.DayNo25, "DayNo25")
        Me.DayNo25.BackColor = System.Drawing.Color.White
        Me.DayNo25.Name = "DayNo25"
        '
        'DayNo26
        '
        resources.ApplyResources(Me.DayNo26, "DayNo26")
        Me.DayNo26.BackColor = System.Drawing.Color.White
        Me.DayNo26.Name = "DayNo26"
        '
        'DayNo27
        '
        resources.ApplyResources(Me.DayNo27, "DayNo27")
        Me.DayNo27.BackColor = System.Drawing.Color.White
        Me.DayNo27.Name = "DayNo27"
        '
        'DayNo28
        '
        resources.ApplyResources(Me.DayNo28, "DayNo28")
        Me.DayNo28.BackColor = System.Drawing.Color.White
        Me.DayNo28.Name = "DayNo28"
        '
        'DayNo29
        '
        resources.ApplyResources(Me.DayNo29, "DayNo29")
        Me.DayNo29.BackColor = System.Drawing.Color.White
        Me.DayNo29.Name = "DayNo29"
        '
        'DayNo30
        '
        resources.ApplyResources(Me.DayNo30, "DayNo30")
        Me.DayNo30.BackColor = System.Drawing.Color.White
        Me.DayNo30.Name = "DayNo30"
        '
        'DayNo31
        '
        resources.ApplyResources(Me.DayNo31, "DayNo31")
        Me.DayNo31.BackColor = System.Drawing.Color.White
        Me.DayNo31.Name = "DayNo31"
        '
        'DayNo32
        '
        resources.ApplyResources(Me.DayNo32, "DayNo32")
        Me.DayNo32.BackColor = System.Drawing.Color.White
        Me.DayNo32.Name = "DayNo32"
        '
        'DayNo33
        '
        resources.ApplyResources(Me.DayNo33, "DayNo33")
        Me.DayNo33.BackColor = System.Drawing.Color.White
        Me.DayNo33.Name = "DayNo33"
        '
        'DayNo34
        '
        resources.ApplyResources(Me.DayNo34, "DayNo34")
        Me.DayNo34.BackColor = System.Drawing.Color.White
        Me.DayNo34.Name = "DayNo34"
        '
        'DayNo35
        '
        resources.ApplyResources(Me.DayNo35, "DayNo35")
        Me.DayNo35.BackColor = System.Drawing.Color.White
        Me.DayNo35.Name = "DayNo35"
        '
        'UmAlQuraCalendar
        '
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Controls.Add(Me.FooterPanel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Name = "UmAlQuraCalendar"
        resources.ApplyResources(Me, "$this")
        Me.HeaderPanel.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FooterPanel.ResumeLayout(False)
        Me.FooterPanel.PerformLayout()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents FooterPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FooterLabel As System.Windows.Forms.Label
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Daylabel1 As System.Windows.Forms.Label
    Friend WithEvents Daylabel2 As System.Windows.Forms.Label
    Friend WithEvents Daylabel3 As System.Windows.Forms.Label
    Friend WithEvents Daylabel4 As System.Windows.Forms.Label
    Friend WithEvents Daylabel5 As System.Windows.Forms.Label
    Friend WithEvents Daylabel6 As System.Windows.Forms.Label
    Friend WithEvents Daylabel7 As System.Windows.Forms.Label
    Friend WithEvents DayNo1 As System.Windows.Forms.Label
    Friend WithEvents DayNo2 As System.Windows.Forms.Label
    Friend WithEvents DayNo3 As System.Windows.Forms.Label
    Friend WithEvents DayNo4 As System.Windows.Forms.Label
    Friend WithEvents DayNo5 As System.Windows.Forms.Label
    Friend WithEvents DayNo6 As System.Windows.Forms.Label
    Friend WithEvents DayNo7 As System.Windows.Forms.Label
    Friend WithEvents DayNo8 As System.Windows.Forms.Label
    Friend WithEvents DayNo9 As System.Windows.Forms.Label
    Friend WithEvents DayNo10 As System.Windows.Forms.Label
    Friend WithEvents DayNo11 As System.Windows.Forms.Label
    Friend WithEvents DayNo12 As System.Windows.Forms.Label
    Friend WithEvents DayNo13 As System.Windows.Forms.Label
    Friend WithEvents DayNo14 As System.Windows.Forms.Label
    Friend WithEvents DayNo15 As System.Windows.Forms.Label
    Friend WithEvents DayNo16 As System.Windows.Forms.Label
    Friend WithEvents DayNo17 As System.Windows.Forms.Label
    Friend WithEvents DayNo18 As System.Windows.Forms.Label
    Friend WithEvents DayNo19 As System.Windows.Forms.Label
    Friend WithEvents DayNo20 As System.Windows.Forms.Label
    Friend WithEvents DayNo21 As System.Windows.Forms.Label
    Friend WithEvents DayNo22 As System.Windows.Forms.Label
    Friend WithEvents DayNo23 As System.Windows.Forms.Label
    Friend WithEvents DayNo24 As System.Windows.Forms.Label
    Friend WithEvents DayNo25 As System.Windows.Forms.Label
    Friend WithEvents DayNo26 As System.Windows.Forms.Label
    Friend WithEvents DayNo27 As System.Windows.Forms.Label
    Friend WithEvents DayNo28 As System.Windows.Forms.Label
    Friend WithEvents DayNo29 As System.Windows.Forms.Label
    Friend WithEvents DayNo30 As System.Windows.Forms.Label
    Friend WithEvents DayNo31 As System.Windows.Forms.Label
    Friend WithEvents DayNo32 As System.Windows.Forms.Label
    Friend WithEvents DayNo33 As System.Windows.Forms.Label
    Friend WithEvents DayNo34 As System.Windows.Forms.Label
    Friend WithEvents DayNo35 As System.Windows.Forms.Label

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FrontButton As System.Windows.Forms.Button
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents HeaderLabel As System.Windows.Forms.Label
End Class

