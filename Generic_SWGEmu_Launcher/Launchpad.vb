Imports System

Public Class Launchpad

    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the window name
        Me.Text = "Version 1.00.00"

    End Sub

    Private Sub SWGEmu_Launcher_Running(sender As Object, e As EventArgs) Handles MyBase.Shown

        presentText(StatusText, "Hello World", 100)
        blankLine(StatusText, 100)
        extendText(StatusText, "Good Progress", 100)
        blankLine(StatusText, 100)
        extendText(StatusText, getSWGLocation(), 100)

    End Sub

End Class
