<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.launcherName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Copyright
        '
        Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.Yellow
        Me.Copyright.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Copyright.Location = New System.Drawing.Point(30, 273)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(454, 21)
        Me.Copyright.TabIndex = 3
        Me.Copyright.Text = "Copyright ©  2015 - 2016"
        '
        'Version
        '
        Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.Yellow
        Me.Version.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Version.Location = New System.Drawing.Point(30, 252)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(454, 21)
        Me.Version.TabIndex = 4
        Me.Version.Text = "Version 0.00.000"
        '
        'launcherName
        '
        Me.launcherName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.launcherName.BackColor = System.Drawing.Color.Transparent
        Me.launcherName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.launcherName.ForeColor = System.Drawing.Color.Yellow
        Me.launcherName.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.launcherName.Location = New System.Drawing.Point(30, 200)
        Me.launcherName.Name = "launcherName"
        Me.launcherName.Size = New System.Drawing.Size(454, 42)
        Me.launcherName.TabIndex = 5
        Me.launcherName.Text = "Generic SWGEmu Launcher"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Generic_SWGEmu_Launcher.My.Resources.Resources.logo_yellow
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.launcherName)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Copyright)
        Me.ForeColor = System.Drawing.Color.Yellow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Copyright As Label
    Friend WithEvents Version As Label
    Friend WithEvents launcherName As Label
End Class
