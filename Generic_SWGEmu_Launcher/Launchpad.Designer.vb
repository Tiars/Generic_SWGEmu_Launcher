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
        Me.ServerButton = New System.Windows.Forms.Button()
        Me.PatchNotesBox = New System.Windows.Forms.RichTextBox()
        Me.StatusTextBox = New System.Windows.Forms.RichTextBox()
        Me.startGameButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.SystemColors.WindowText
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusText.CausesValidation = False
        Me.StatusText.ForeColor = System.Drawing.SystemColors.Window
        Me.StatusText.Location = New System.Drawing.Point(10, 280)
        Me.StatusText.Margin = New System.Windows.Forms.Padding(5)
        Me.StatusText.Multiline = True
        Me.StatusText.Name = "StatusText"
        Me.StatusText.ReadOnly = True
        Me.StatusText.Size = New System.Drawing.Size(660, 15)
        Me.StatusText.TabIndex = 0
        Me.StatusText.WordWrap = False
        '
        'IndividualProgressBar
        '
        Me.IndividualProgressBar.BackColor = System.Drawing.Color.White
        Me.IndividualProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IndividualProgressBar.Location = New System.Drawing.Point(10, 330)
        Me.IndividualProgressBar.Name = "IndividualProgressBar"
        Me.IndividualProgressBar.Size = New System.Drawing.Size(660, 12)
        Me.IndividualProgressBar.TabIndex = 1
        '
        'OverallProgressBar
        '
        Me.OverallProgressBar.BackColor = System.Drawing.Color.White
        Me.OverallProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OverallProgressBar.Location = New System.Drawing.Point(10, 305)
        Me.OverallProgressBar.Name = "OverallProgressBar"
        Me.OverallProgressBar.Size = New System.Drawing.Size(660, 12)
        Me.OverallProgressBar.TabIndex = 2
        '
        'ServerButton
        '
        Me.ServerButton.AutoEllipsis = True
        Me.ServerButton.BackColor = System.Drawing.Color.White
        Me.ServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ServerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerButton.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ServerButton.Location = New System.Drawing.Point(680, 305)
        Me.ServerButton.Name = "ServerButton"
        Me.ServerButton.Size = New System.Drawing.Size(100, 40)
        Me.ServerButton.TabIndex = 5
        Me.ServerButton.Text = "Switch to Testserver"
        Me.ServerButton.UseVisualStyleBackColor = False
        '
        'PatchNotesBox
        '
        Me.PatchNotesBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PatchNotesBox.Location = New System.Drawing.Point(10, 80)
        Me.PatchNotesBox.Name = "PatchNotesBox"
        Me.PatchNotesBox.ReadOnly = True
        Me.PatchNotesBox.Size = New System.Drawing.Size(660, 185)
        Me.PatchNotesBox.TabIndex = 7
        Me.PatchNotesBox.Text = ""
        '
        'StatusTextBox
        '
        Me.StatusTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusTextBox.BackColor = System.Drawing.Color.Black
        Me.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusTextBox.ForeColor = System.Drawing.Color.Yellow
        Me.StatusTextBox.Location = New System.Drawing.Point(695, 80)
        Me.StatusTextBox.Name = "StatusTextBox"
        Me.StatusTextBox.ReadOnly = True
        Me.StatusTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.StatusTextBox.Size = New System.Drawing.Size(200, 125)
        Me.StatusTextBox.TabIndex = 8
        Me.StatusTextBox.Text = ""
        '
        'startGameButton
        '
        Me.startGameButton.AutoEllipsis = True
        Me.startGameButton.BackColor = System.Drawing.Color.White
        Me.startGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.startGameButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startGameButton.ForeColor = System.Drawing.SystemColors.WindowText
        Me.startGameButton.Location = New System.Drawing.Point(795, 305)
        Me.startGameButton.Name = "startGameButton"
        Me.startGameButton.Size = New System.Drawing.Size(100, 40)
        Me.startGameButton.TabIndex = 9
        Me.startGameButton.Text = "Launch Game"
        Me.startGameButton.UseVisualStyleBackColor = False
        '
        'Launchpad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(908, 352)
        Me.Controls.Add(Me.startGameButton)
        Me.Controls.Add(Me.StatusTextBox)
        Me.Controls.Add(Me.PatchNotesBox)
        Me.Controls.Add(Me.ServerButton)
        Me.Controls.Add(Me.OverallProgressBar)
        Me.Controls.Add(Me.IndividualProgressBar)
        Me.Controls.Add(Me.StatusText)
        Me.ForeColor = System.Drawing.SystemColors.Window
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Launchpad"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusText As TextBox
    Friend WithEvents IndividualProgressBar As ProgressBar
    Friend WithEvents OverallProgressBar As ProgressBar
    Friend WithEvents ServerButton As Button
    Friend WithEvents PatchNotesBox As RichTextBox
    Friend WithEvents StatusTextBox As RichTextBox
    Friend WithEvents startGameButton As Button
End Class
