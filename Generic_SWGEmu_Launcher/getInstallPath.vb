Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Object
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Public Class getInstallPath
    Public Property Path As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Dim cUtils As New configUtils

    Private Sub acceptButton_Click(sender As Object, e As EventArgs) Handles acceptButton.Click

    End Sub

    Private Sub getInstallPath_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        Dim FolderBrowser As New FolderBrowserDialog

        ' Set the Help text description for the FolderBrowserDialog.
        FolderBrowser.Description =
            "Select where to install the Play Server Client"
        ' Make shure that they can create a folder
        FolderBrowser.ShowNewFolderButton = True
        ' Initialize with recommended location

        If (FolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            TextBox1.Text = FolderBrowser.SelectedPath & "\"
        End If
    End Sub
End Class