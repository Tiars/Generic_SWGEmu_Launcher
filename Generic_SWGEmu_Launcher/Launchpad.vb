Imports System
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Public Class Launchpad

    ' serverNumber denotes live or test servers
    '   Using and Integer instead of Boolean to allow for expansion to support 
    '   multiple test servers to be defined
    ' 0 = Live Server
    ' 1 = Test Server

    Dim serverNumber As Integer = 0 ' Initialize to Live Server

    Private Sub getGamenotesText()
        Dim request As WebRequest = WebRequest.Create(getGamePatchNotes())
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                PatchNotesBox.Rtf = reader.ReadToEnd()
            End Using
        End Using
    End Sub 'getGamenotesText

    Private Sub getGameStatusText()
        Dim request As WebRequest = WebRequest.Create(getGameStatus())
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                StatusTextBox.Rtf = reader.ReadToEnd()
            End Using
        End Using
    End Sub 'getGameStatusText

    Private Sub getTestnotesText()
        Dim request As WebRequest = WebRequest.Create(getTestPatchNotes())
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                PatchNotesBox.Rtf = reader.ReadToEnd()
            End Using
        End Using
    End Sub 'getTestnotesText

    Private Sub getTestStatusText()
        Dim request As WebRequest = WebRequest.Create(getTestStatus())
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                StatusTextBox.Rtf = reader.ReadToEnd()
            End Using
        End Using
    End Sub 'getTestStatusText

    Private Sub setGameTestInfo(ByRef flag As Integer)
        Dim localURI As Uri = Nothing

        If flag = 0 Then
            getGamenotesText()
            getGameStatusText()
            ServerButton.Text = "Switch to Testserver"
        Else
            getTestnotesText()
            getTestStatusText()
            ServerButton.Text = "Switch to Main Server"
        End If

    End Sub

    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the window name
        Me.Text = "Launcher " & getLauncherVersion()

        setGameTestInfo(serverNumber)

    End Sub

    Private Sub SWGEmu_Launcher_Running(sender As Object, e As EventArgs) Handles MyBase.Shown

        ' Refresh Patch notes
        PatchNotesBox.Refresh()
        ' Refresh Server Status
        StatusTextBox.Refresh()

    End Sub

    Private Sub ServerButton_Click(sender As Object, e As EventArgs) Handles ServerButton.Click

        ' Switch between live and Test Server

        ' First check to see if there is a Test Server
        If getLauncherHasTest() Then
            If serverNumber = 0 Then ' If set to Main
                serverNumber = 1 ' Set to Test Server 1
            Else
                serverNumber = 0 ' Set to Main Server
            End If
        Else
            serverNumber = 0 'Force Main Server when there is no Test Server
        End If

        ' Update view
        setGameTestInfo(serverNumber)

        ' Refresh Patch notes
        PatchNotesBox.Refresh()
        ' Refresh Server Status
        StatusTextBox.Refresh()

        Me.Refresh()

    End Sub

End Class
