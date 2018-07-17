Partial Public Class TestingForm
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
        Me.UmAlQuraCalendar1 = New Microsoft.Samples.UmAlQuraCalendar
        Me.SuspendLayout()
        '
        'UmAlQuraCalendar1
        '
        Me.UmAlQuraCalendar1.Day = 22
        Me.UmAlQuraCalendar1.Location = New System.Drawing.Point(11, 12)
        Me.UmAlQuraCalendar1.Month = 9
        Me.UmAlQuraCalendar1.Name = "UmAlQuraCalendar1"
        Me.UmAlQuraCalendar1.Size = New System.Drawing.Size(301, 187)
        Me.UmAlQuraCalendar1.TabIndex = 0
        Me.UmAlQuraCalendar1.Year = 1425
        '
        'TestingForm
        '
        Me.ClientSize = New System.Drawing.Size(324, 224)
        Me.Controls.Add(Me.UmAlQuraCalendar1)
        Me.Name = "TestingForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "تقويم أم القرى الهجري "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UmAlQuraCalendar1 As Microsoft.Samples.UmAlQuraCalendar
End Class
