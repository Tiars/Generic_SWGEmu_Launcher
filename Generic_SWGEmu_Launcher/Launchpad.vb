Imports System

Public Class Launchpad


    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the window name
        Me.Text = "Version 1.00.00"

    End Sub

    Private Sub SWGEmu_Launcher_Running(sender As Object, e As EventArgs) Handles MyBase.Shown

        presentText(TextBox1, "Hello World", 100)
        blankLine(TextBox1, 100)
        extendText(TextBox1, "Good Progress", 100)
        blankLine(TextBox1, 100)
        extendText(TextBox1, getSWGLocation(), 100)

    End Sub
End Class
