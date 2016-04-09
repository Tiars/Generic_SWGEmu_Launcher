Imports System
Imports System.IO
Imports System.Net
Imports System.Object
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class confirmEULA

    Dim mClass As New Launchpad

    Private Sub confirmEULA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open the file as Read Only Shared
        Dim stream As New System.IO.FileStream("EULA.rtf", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        Dim reader As New System.IO.StreamReader(stream)

        RichTextBoxEULA.Rtf = reader.ReadToEnd
        RichTextBoxEULA.Refresh()

        stream.Close()
        reader.Close()
    End Sub

    Private Sub ButtonAccept_Click(sender As Object, e As EventArgs) Handles ButtonAccept.Click

        ' Send event that the EULA was Accepted
        setLauncherReadEula("Yes")

        ' Close the window now that we have an answer
        'Me.Hide()
        Me.Close()

    End Sub

    Private Sub ButtonDecline_Click(sender As Object, e As EventArgs) Handles ButtonDecline.Click

        ' Send event that the EULA was Declined
        setLauncherReadEula("No")

        ' Close the window now that we have an answer
        'Me.Hide()
        Me.Close()
    End Sub
End Class