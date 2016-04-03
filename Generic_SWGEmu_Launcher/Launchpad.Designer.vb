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
        Me.WebBrowserStatus = New System.Windows.Forms.WebBrowser()
        Me.ServerButton = New System.Windows.Forms.Button()
        Me.WebBrowserTest = New System.Windows.Forms.WebBrowser()
        Me.PatchNotesBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.SystemColors.WindowText
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusText.CausesValidation = False
        Me.StatusText.ForeColor = System.Drawing.SystemColors.Window
        Me.StatusText.Location = New System.Drawing.Point(12, 253)
        Me.StatusText.Margin = New System.Windows.Forms.Padding(5)
        Me.StatusText.Multiline = True
        Me.StatusText.Name = "StatusText"
        Me.StatusText.ReadOnly = True
        Me.StatusText.Size = New System.Drawing.Size(663, 44)
        Me.StatusText.TabIndex = 0
        '
        'IndividualProgressBar
        '
        Me.IndividualProgressBar.BackColor = System.Drawing.Color.White
        Me.IndividualProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IndividualProgressBar.Location = New System.Drawing.Point(10, 332)
        Me.IndividualProgressBar.Name = "IndividualProgressBar"
        Me.IndividualProgressBar.Size = New System.Drawing.Size(663, 12)
        Me.IndividualProgressBar.TabIndex = 1
        '
        'OverallProgressBar
        '
        Me.OverallProgressBar.BackColor = System.Drawing.Color.White
        Me.OverallProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OverallProgressBar.Location = New System.Drawing.Point(11, 305)
        Me.OverallProgressBar.Name = "OverallProgressBar"
        Me.OverallProgressBar.Size = New System.Drawing.Size(663, 12)
        Me.OverallProgressBar.TabIndex = 2
        '
        'WebBrowserStatus
        '
        Me.WebBrowserStatus.CausesValidation = False
        Me.WebBrowserStatus.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowserStatus.Location = New System.Drawing.Point(681, 8)
        Me.WebBrowserStatus.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserStatus.Name = "WebBrowserStatus"
        Me.WebBrowserStatus.ScrollBarsEnabled = False
        Me.WebBrowserStatus.Size = New System.Drawing.Size(214, 140)
        Me.WebBrowserStatus.TabIndex = 4
        '
        'ServerButton
        '
        Me.ServerButton.AutoEllipsis = True
        Me.ServerButton.BackColor = System.Drawing.Color.White
        Me.ServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ServerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerButton.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ServerButton.Location = New System.Drawing.Point(680, 305)
        Me.ServerButton.Name = "ServerButton"
        Me.ServerButton.Size = New System.Drawing.Size(100, 39)
        Me.ServerButton.TabIndex = 5
        Me.ServerButton.Text = "Switch to Testserver"
        Me.ServerButton.UseVisualStyleBackColor = False
        '
        'WebBrowserTest
        '
        Me.WebBrowserTest.CausesValidation = False
        Me.WebBrowserTest.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowserTest.Location = New System.Drawing.Point(680, 154)
        Me.WebBrowserTest.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserTest.Name = "WebBrowserTest"
        Me.WebBrowserTest.ScrollBarsEnabled = False
        Me.WebBrowserTest.Size = New System.Drawing.Size(214, 140)
        Me.WebBrowserTest.TabIndex = 6
        '
        'PatchNotesBox
        '
        Me.PatchNotesBox.Location = New System.Drawing.Point(12, 8)
        Me.PatchNotesBox.Name = "PatchNotesBox"
        Me.PatchNotesBox.Size = New System.Drawing.Size(661, 286)
        Me.PatchNotesBox.TabIndex = 7
        Me.PatchNotesBox.Text = ""
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
        Me.Controls.Add(Me.PatchNotesBox)
        Me.Controls.Add(Me.WebBrowserTest)
        Me.Controls.Add(Me.ServerButton)
        Me.Controls.Add(Me.WebBrowserStatus)
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
    Friend WithEvents WebBrowserStatus As WebBrowser
    Friend WithEvents ServerButton As Button
    Friend WithEvents WebBrowserTest As WebBrowser
    Friend WithEvents PatchNotesBox As RichTextBox
End Class
