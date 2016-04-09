<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class confirmEULA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(confirmEULA))
        Me.RichTextBoxEULA = New System.Windows.Forms.RichTextBox()
        Me.ButtonAccept = New System.Windows.Forms.Button()
        Me.ButtonDecline = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RichTextBoxEULA
        '
        Me.RichTextBoxEULA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxEULA.Location = New System.Drawing.Point(250, 15)
        Me.RichTextBoxEULA.Name = "RichTextBoxEULA"
        Me.RichTextBoxEULA.Size = New System.Drawing.Size(670, 300)
        Me.RichTextBoxEULA.TabIndex = 0
        Me.RichTextBoxEULA.Text = ""
        '
        'ButtonAccept
        '
        Me.ButtonAccept.Location = New System.Drawing.Point(664, 321)
        Me.ButtonAccept.Name = "ButtonAccept"
        Me.ButtonAccept.Size = New System.Drawing.Size(125, 25)
        Me.ButtonAccept.TabIndex = 1
        Me.ButtonAccept.Text = "Accept EULA"
        Me.ButtonAccept.UseVisualStyleBackColor = True
        '
        'ButtonDecline
        '
        Me.ButtonDecline.Location = New System.Drawing.Point(795, 321)
        Me.ButtonDecline.Name = "ButtonDecline"
        Me.ButtonDecline.Size = New System.Drawing.Size(125, 25)
        Me.ButtonDecline.TabIndex = 2
        Me.ButtonDecline.Text = "Decline EULA"
        Me.ButtonDecline.UseVisualStyleBackColor = True
        '
        'confirmEULA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Generic_SWGEmu_Launcher.My.Resources.Resources.logo_yellow
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(932, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonDecline)
        Me.Controls.Add(Me.ButtonAccept)
        Me.Controls.Add(Me.RichTextBoxEULA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "confirmEULA"
        Me.Text = "confirmEULA"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RichTextBoxEULA As RichTextBox
    Friend WithEvents ButtonAccept As Button
    Friend WithEvents ButtonDecline As Button
End Class
