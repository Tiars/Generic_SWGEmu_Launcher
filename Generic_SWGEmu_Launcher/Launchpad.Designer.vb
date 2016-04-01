<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Launchpad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusText = New System.Windows.Forms.TextBox()
        Me.IndividualProgressBar = New System.Windows.Forms.ProgressBar()
        Me.OverallProgressBar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.SystemColors.WindowText
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusText.CausesValidation = False
        Me.StatusText.ForeColor = System.Drawing.SystemColors.Window
        Me.StatusText.Location = New System.Drawing.Point(40, 262)
        Me.StatusText.Margin = New System.Windows.Forms.Padding(5)
        Me.StatusText.Multiline = True
        Me.StatusText.Name = "StatusText"
        Me.StatusText.ReadOnly = True
        Me.StatusText.Size = New System.Drawing.Size(497, 44)
        Me.StatusText.TabIndex = 0
        '
        'IndividualProgressBar
        '
        Me.IndividualProgressBar.BackColor = System.Drawing.Color.White
        Me.IndividualProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IndividualProgressBar.Location = New System.Drawing.Point(40, 332)
        Me.IndividualProgressBar.Name = "IndividualProgressBar"
        Me.IndividualProgressBar.Size = New System.Drawing.Size(497, 12)
        Me.IndividualProgressBar.TabIndex = 1
        '
        'OverallProgressBar
        '
        Me.OverallProgressBar.BackColor = System.Drawing.Color.White
        Me.OverallProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OverallProgressBar.Location = New System.Drawing.Point(40, 314)
        Me.OverallProgressBar.Name = "OverallProgressBar"
        Me.OverallProgressBar.Size = New System.Drawing.Size(497, 12)
        Me.OverallProgressBar.TabIndex = 2
        '
        'Launchpad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(909, 352)
        Me.Controls.Add(Me.OverallProgressBar)
        Me.Controls.Add(Me.IndividualProgressBar)
        Me.Controls.Add(Me.StatusText)
        Me.ForeColor = System.Drawing.SystemColors.Window
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Launchpad"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowIcon = False
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusText As TextBox
    Friend WithEvents IndividualProgressBar As ProgressBar
    Friend WithEvents OverallProgressBar As ProgressBar
End Class
