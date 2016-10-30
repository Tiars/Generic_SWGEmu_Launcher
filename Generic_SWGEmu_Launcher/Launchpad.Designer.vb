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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Launchpad))
        Me.StatusText = New System.Windows.Forms.TextBox()
        Me.IndividualProgressBar = New System.Windows.Forms.ProgressBar()
        Me.OverallProgressBar = New System.Windows.Forms.ProgressBar()
        Me.PatchNotesBox = New System.Windows.Forms.RichTextBox()
        Me.StatusTextBox = New System.Windows.Forms.RichTextBox()
        Me.startGameButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuTop = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallFromSWGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.SystemColors.WindowText
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusText.CausesValidation = False
        Me.StatusText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.StatusText.Location = New System.Drawing.Point(7, 227)
        Me.StatusText.Margin = New System.Windows.Forms.Padding(4)
        Me.StatusText.Multiline = True
        Me.StatusText.Name = "StatusText"
        Me.StatusText.ReadOnly = True
        Me.StatusText.Size = New System.Drawing.Size(495, 12)
        Me.StatusText.TabIndex = 0
        Me.StatusText.WordWrap = False
        '
        'IndividualProgressBar
        '
        Me.IndividualProgressBar.BackColor = System.Drawing.Color.White
        Me.IndividualProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IndividualProgressBar.Location = New System.Drawing.Point(7, 248)
        Me.IndividualProgressBar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.IndividualProgressBar.Name = "IndividualProgressBar"
        Me.IndividualProgressBar.Size = New System.Drawing.Size(495, 10)
        Me.IndividualProgressBar.TabIndex = 1
        '
        'OverallProgressBar
        '
        Me.OverallProgressBar.BackColor = System.Drawing.Color.White
        Me.OverallProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OverallProgressBar.Location = New System.Drawing.Point(7, 270)
        Me.OverallProgressBar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OverallProgressBar.Name = "OverallProgressBar"
        Me.OverallProgressBar.Size = New System.Drawing.Size(495, 10)
        Me.OverallProgressBar.TabIndex = 2
        '
        'PatchNotesBox
        '
        Me.PatchNotesBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PatchNotesBox.Location = New System.Drawing.Point(7, 65)
        Me.PatchNotesBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PatchNotesBox.Name = "PatchNotesBox"
        Me.PatchNotesBox.ReadOnly = True
        Me.PatchNotesBox.Size = New System.Drawing.Size(495, 150)
        Me.PatchNotesBox.TabIndex = 7
        Me.PatchNotesBox.Text = ""
        '
        'StatusTextBox
        '
        Me.StatusTextBox.BackColor = System.Drawing.Color.Black
        Me.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusTextBox.ForeColor = System.Drawing.Color.Yellow
        Me.StatusTextBox.Location = New System.Drawing.Point(536, 65)
        Me.StatusTextBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StatusTextBox.Name = "StatusTextBox"
        Me.StatusTextBox.ReadOnly = True
        Me.StatusTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.StatusTextBox.Size = New System.Drawing.Size(150, 101)
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
        Me.startGameButton.Location = New System.Drawing.Point(596, 248)
        Me.startGameButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.startGameButton.Name = "startGameButton"
        Me.startGameButton.Size = New System.Drawing.Size(75, 32)
        Me.startGameButton.TabIndex = 9
        Me.startGameButton.Text = "Launch Game"
        Me.startGameButton.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.AutoEllipsis = True
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Button1.Location = New System.Drawing.Point(517, 248)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Test Download"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MenuTop
        '
        Me.MenuTop.BackColor = System.Drawing.Color.Transparent
        Me.MenuTop.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuTop.Location = New System.Drawing.Point(4, 4)
        Me.MenuTop.Name = "MenuTop"
        Me.MenuTop.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuTop.Size = New System.Drawing.Size(805, 24)
        Me.MenuTop.TabIndex = 12
        Me.MenuTop.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.InstallFromSWGToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.OptionsToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'InstallFromSWGToolStripMenuItem
        '
        Me.InstallFromSWGToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.InstallFromSWGToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.InstallFromSWGToolStripMenuItem.Name = "InstallFromSWGToolStripMenuItem"
        Me.InstallFromSWGToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.InstallFromSWGToolStripMenuItem.Text = "Install from SWG"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Launchpad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(813, 287)
        Me.Controls.Add(Me.MenuTop)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.startGameButton)
        Me.Controls.Add(Me.StatusTextBox)
        Me.Controls.Add(Me.PatchNotesBox)
        Me.Controls.Add(Me.OverallProgressBar)
        Me.Controls.Add(Me.IndividualProgressBar)
        Me.Controls.Add(Me.StatusText)
        Me.ForeColor = System.Drawing.Color.Yellow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Launchpad"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = """SWGEmu Launcher Version {0}.{1:00}.{2:000}.{3:0000}"""
        Me.MenuTop.ResumeLayout(False)
        Me.MenuTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusText As TextBox
    Friend WithEvents IndividualProgressBar As ProgressBar
    Friend WithEvents OverallProgressBar As ProgressBar
    Friend WithEvents PatchNotesBox As RichTextBox
    Friend WithEvents StatusTextBox As RichTextBox
    Friend WithEvents startGameButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents MenuTop As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallFromSWGToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
