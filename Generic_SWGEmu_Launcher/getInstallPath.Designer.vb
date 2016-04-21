<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class getInstallPath
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(getInstallPath))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.acceptButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(590, 22)
        Me.TextBox1.TabIndex = 0
        '
        'BrowseButton
        '
        Me.BrowseButton.BackColor = System.Drawing.Color.LightGray
        Me.BrowseButton.ForeColor = System.Drawing.Color.Black
        Me.BrowseButton.Location = New System.Drawing.Point(610, 10)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 25)
        Me.BrowseButton.TabIndex = 1
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = False
        '
        'acceptButton
        '
        Me.acceptButton.BackColor = System.Drawing.Color.LightGray
        Me.acceptButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.acceptButton.ForeColor = System.Drawing.Color.Black
        Me.acceptButton.Location = New System.Drawing.Point(695, 10)
        Me.acceptButton.Name = "acceptButton"
        Me.acceptButton.Size = New System.Drawing.Size(75, 25)
        Me.acceptButton.TabIndex = 2
        Me.acceptButton.Text = "Accept"
        Me.acceptButton.UseVisualStyleBackColor = False
        '
        'getInstallPath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.acceptButton
        Me.ClientSize = New System.Drawing.Size(777, 46)
        Me.Controls.Add(Me.acceptButton)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.TextBox1)
        Me.ForeColor = System.Drawing.Color.Yellow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "getInstallPath"
        Me.Text = "Location to Install Game"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BrowseButton As Button
    Friend WithEvents acceptButton As Button
End Class
