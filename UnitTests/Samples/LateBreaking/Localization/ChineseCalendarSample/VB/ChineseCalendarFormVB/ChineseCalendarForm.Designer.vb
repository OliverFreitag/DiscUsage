<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ChineseCalendarForm
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChineseCalendarForm))
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.textBoxTerm = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.textBoxNextTerm = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label1 = New System.Windows.Forms.Label
        Me.textBoxZodiac = New System.Windows.Forms.TextBox
        Me.textBoxDate = New System.Windows.Forms.TextBox
        Me.textBoxYear = New System.Windows.Forms.TextBox
        Me.monthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label2
        '
        resources.ApplyResources(Me.label2, "label2")
        Me.label2.Font = CType(resources.GetObject("label2.Font"), System.Drawing.Font)
        Me.label2.Name = "label2"
        Me.label2.RightToLeft = CType(resources.GetObject("label2.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'groupBox2
        '
        resources.ApplyResources(Me.groupBox2, "groupBox2")
        Me.groupBox2.Controls.Add(Me.textBoxTerm)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.textBoxNextTerm)
        Me.groupBox2.Font = CType(resources.GetObject("groupBox2.Font"), System.Drawing.Font)
        Me.groupBox2.ImeMode = CType(resources.GetObject("groupBox2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.RightToLeft = CType(resources.GetObject("groupBox2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.groupBox2.TabStop = False
        '
        'textBoxTerm
        '
        resources.ApplyResources(Me.textBoxTerm, "textBoxTerm")
        Me.textBoxTerm.Font = CType(resources.GetObject("textBoxTerm.Font"), System.Drawing.Font)
        Me.textBoxTerm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textBoxTerm.Name = "textBoxTerm"
        Me.textBoxTerm.ReadOnly = True
        Me.textBoxTerm.RightToLeft = CType(resources.GetObject("textBoxTerm.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'label4
        '
        resources.ApplyResources(Me.label4, "label4")
        Me.label4.Font = CType(resources.GetObject("label4.Font"), System.Drawing.Font)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = CType(resources.GetObject("label4.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'label5
        '
        resources.ApplyResources(Me.label5, "label5")
        Me.label5.Font = CType(resources.GetObject("label5.Font"), System.Drawing.Font)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = CType(resources.GetObject("label5.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'textBoxNextTerm
        '
        resources.ApplyResources(Me.textBoxNextTerm, "textBoxNextTerm")
        Me.textBoxNextTerm.Font = CType(resources.GetObject("textBoxNextTerm.Font"), System.Drawing.Font)
        Me.textBoxNextTerm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textBoxNextTerm.Name = "textBoxNextTerm"
        Me.textBoxNextTerm.ReadOnly = True
        Me.textBoxNextTerm.RightToLeft = CType(resources.GetObject("textBoxNextTerm.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'label3
        '
        resources.ApplyResources(Me.label3, "label3")
        Me.label3.Font = CType(resources.GetObject("label3.Font"), System.Drawing.Font)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = CType(resources.GetObject("label3.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'groupBox1
        '
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.textBoxZodiac)
        Me.groupBox1.Controls.Add(Me.textBoxDate)
        Me.groupBox1.Controls.Add(Me.textBoxYear)
        Me.groupBox1.Font = CType(resources.GetObject("groupBox1.Font"), System.Drawing.Font)
        Me.groupBox1.ImeMode = CType(resources.GetObject("groupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.RightToLeft = CType(resources.GetObject("groupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.groupBox1.TabStop = False
        '
        'label1
        '
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Font = CType(resources.GetObject("label1.Font"), System.Drawing.Font)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = CType(resources.GetObject("label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'textBoxZodiac
        '
        resources.ApplyResources(Me.textBoxZodiac, "textBoxZodiac")
        Me.textBoxZodiac.Font = CType(resources.GetObject("textBoxZodiac.Font"), System.Drawing.Font)
        Me.textBoxZodiac.Name = "textBoxZodiac"
        Me.textBoxZodiac.ReadOnly = True
        Me.textBoxZodiac.RightToLeft = CType(resources.GetObject("textBoxZodiac.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'textBoxDate
        '
        resources.ApplyResources(Me.textBoxDate, "textBoxDate")
        Me.textBoxDate.Font = CType(resources.GetObject("textBoxDate.Font"), System.Drawing.Font)
        Me.textBoxDate.Name = "textBoxDate"
        Me.textBoxDate.ReadOnly = True
        Me.textBoxDate.RightToLeft = CType(resources.GetObject("textBoxDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'textBoxYear
        '
        resources.ApplyResources(Me.textBoxYear, "textBoxYear")
        Me.textBoxYear.Font = CType(resources.GetObject("textBoxYear.Font"), System.Drawing.Font)
        Me.textBoxYear.Name = "textBoxYear"
        Me.textBoxYear.ReadOnly = True
        Me.textBoxYear.RightToLeft = CType(resources.GetObject("textBoxYear.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'monthCalendar1
        '
        resources.ApplyResources(Me.monthCalendar1, "monthCalendar1")
        Me.monthCalendar1.Font = CType(resources.GetObject("monthCalendar1.Font"), System.Drawing.Font)
        Me.monthCalendar1.Margin = New System.Windows.Forms.Padding(1)
        Me.monthCalendar1.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.monthCalendar1.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.monthCalendar1.Name = "monthCalendar1"
        Me.monthCalendar1.RightToLeft = CType(resources.GetObject("monthCalendar1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.monthCalendar1.ShowTodayCircle = False
        '
        'ChineseCalendarForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.monthCalendar1)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Name = "ChineseCalendarForm"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents textBoxTerm As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents textBoxNextTerm As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents textBoxZodiac As System.Windows.Forms.TextBox
    Friend WithEvents textBoxDate As System.Windows.Forms.TextBox
    Friend WithEvents textBoxYear As System.Windows.Forms.TextBox
    Friend WithEvents monthCalendar1 As System.Windows.Forms.MonthCalendar
End Class
