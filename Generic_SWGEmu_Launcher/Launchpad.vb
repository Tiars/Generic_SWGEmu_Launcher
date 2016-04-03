Imports System
Imports System.IO
Imports System.Net
Imports System.Object
Imports System.Windows.Forms

Public Class Launchpad

    ' serverNumber denotes live or test servers
    '   Using and Integer instead of Boolean to allow for expansion to support 
    '   multiple test servers to be defined
    ' 0 = Live Server
    ' 1 = Test Server

    Dim serverNumber As Integer = 0 ' Initialize to Live Server

    'The name of the SWG executable
    'This is configurable to allow for game management applications like Raptr
    '  to recognize SWGEmu as an installed game.
    '  To make this happen change the name of SWGEmu.exe and SWGEmu_Setup.exe
    '  to SWGClient_r.exe and SWGClientSetup_r.exe. The best way to do this
    '  is to change the name in the repository and Manifest.
    '  The default will be the names that the SWGEmu project uses for these
    '  executables
    Public Const GameClient As String = "SWGEmu.exe"
    'The name of the SWG configuration executable
    Public Const GameSetup As String = "SWGEmu_Setup.exe"

    'Globals to reduce network calls
    Dim launcherServerVersion As String = Nothing
    Dim launcherUpToDate As Boolean = False
    Dim gameServerVersion As String = Nothing
    Dim gameUpToDate As Boolean = False
    Dim testServerVersion As String = Nothing
    Dim testUpToDate As Boolean = False

    'Internal error number documentation
    ' 1001 Invalid value of serverNumber found when trying to launch game client
    ' 1002 Invalid value of serverNumber found when trying to launch game configuration tool


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
            SwitchToTestserverToolStripMenuItem.Text = "Switch to Test Server"
        Else
            getTestnotesText()
            getTestStatusText()
            SwitchToTestserverToolStripMenuItem.Text = "Switch to Main Server"
        End If

    End Sub

    Private Function getVersionUpToDate(ByRef serverVersion As String, ByVal lVersion As String, ByVal vURL As String) As Boolean
        'Determine if the local version matches the server version
        'The first parameter points to a string to store the server version into
        'The local version and server URL are read only

        'If False then the local files need to be updated

        ' The name of the file that holds the version information on the server
        ' Could be paramatarized but there is little reason to change it
        Dim request As WebRequest = WebRequest.Create(vURL & "Version")
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                serverVersion = reader.ReadToEnd()
                If lVersion = serverVersion Then Return True
            End Using
        End Using

        Return False ' False buy default
    End Function 'getServerGameVersion

    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the window name
        Me.Text = "Launcher " & getLauncherVersion()

        setGameTestInfo(serverNumber) ' At start serverNumber is always 0 for Main Server

        ' Hide unused toolbar items
        If Not getLauncherHasForum() Then
            ' Item not configured so hide
            ForumToolStripMenuItem.Visible = False
        End If
        If Not getLauncherHasEULA() Then
            ' Item not configured so hide
            EULAToolStripMenuItem.Visible = False
        End If
        If Not getLauncherHasCalc() Then
            ' Item not configured so hide
            ProfessionCalculatorToolStripMenuItem.Visible = False
        End If
        If Not getLauncherHasTest() Then
            ' Item not configured so hide
            SwitchToTestserverToolStripMenuItem.Visible = False
        End If

        Dim localVersion As String = Nothing

        launcherUpToDate = getVersionUpToDate(localVersion, getLauncherVersion(), getLauncherURL())
        launcherServerVersion = localVersion

        gameUpToDate = getVersionUpToDate(localVersion, getGameVersion(), getGameURL())
        gameServerVersion = localVersion

        ' Only ask for Test Server information if the server has a test server
        If getLauncherHasTest() Then
            testUpToDate = getVersionUpToDate(localVersion, getTestVersion(), getTestURL())
            testServerVersion = localVersion
        End If
    End Sub

    Private Sub SWGEmu_Launcher_Running(sender As Object, e As EventArgs) Handles MyBase.Shown

        ' Refresh Patch notes
        PatchNotesBox.Refresh()
        ' Refresh Server Status
        StatusTextBox.Refresh()

    End Sub

    Private Sub SwitchToTestserverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchToTestserverToolStripMenuItem.Click

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

    End Sub ' SwitchToTestserverToolStripMenuItem_Click

    Private Sub ProfessionCalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfessionCalculatorToolStripMenuItem.Click
        'Launch Kodian's Profession Calculator

        If Not getLauncherHasCalc() Then
            ' Should not get here but if we do simply return
            Return
        End If

        ' Get the full path to the profession calculator executable

        Dim filePath As String = getLauncherCalc()

        ' New ProcessStartInfo created
        Dim calc As New ProcessStartInfo
        calc.FileName = Path.GetFileName(filePath)
        calc.WorkingDirectory = Path.GetDirectoryName(filePath)
        ' Use a hidden window
        calc.WindowStyle = ProcessWindowStyle.Hidden
        Try
            Process.Start(calc)
        Catch ex As Exception
            ' Launch was not successful so report the error and suggest a solution
            presentStatus(StatusText, "Could not Launch Profession Calculator: Try reinstalling the launcher.", 1)
        End Try

    End Sub ' ProfessionCalculatorToolStripMenuItem_Click

    Private Sub EULAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EULAToolStripMenuItem.Click
        'Launch Browser showing EULA

        If Not getLauncherHasEULA() Then
            ' Should not get here but if we do simply return
            Return
        End If

        'Launch the system default browser and go to the server forums
        Try
            Process.Start(getLauncherEULA())
        Catch ex As Exception
            ' Failed to launch the system default browser and connect to the forums. Report the problem.
            presentStatus(StatusText, "Could not Launch a web browser to the EULA.", 1)
        End Try

    End Sub ' EULAToolStripMenuItem_Click

    Private Sub ForumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForumToolStripMenuItem.Click
        'Launch Browser to the Forums

        If Not getLauncherHasForum() Then
            ' Should not get here but if we do simply return
            Return
        End If

        'Launch the system default browser and go to the server forums
        Try
            Process.Start(getLauncherForum())
        Catch ex As Exception
            ' Failed to launch the system default browser and connect to the forums. Report the problem.
            presentStatus(StatusText, "Could not Launch a web browser to the Forums.", 1)
        End Try

    End Sub ' ForumToolStripMenuItem_Click

    Private Sub startGameButton_Click(sender As Object, e As EventArgs) Handles startGameButton.Click
        ' Allocate data storage for the file to execute
        ' This will be set based on the value of serverNumber

        Dim filepath As String = Nothing

        ' Using a case statement so that this is ready for more than one test server location
        Select Case serverNumber
            Case 0
                filepath = getGamePath()
            Case 1
                filepath = getTestPath()
            Case Else
                presentStatus(StatusText, "Internal Error 1001", 1)
                Return
        End Select

        'Launch Game client

        ' New ProcessStartInfo created
        Dim calc As New ProcessStartInfo
        calc.FileName = GameClient
        calc.WorkingDirectory = filepath
        ' Use a hidden window
        calc.WindowStyle = ProcessWindowStyle.Hidden
        Try
            Process.Start(calc)
        Catch ex As Exception
            ' Launch was not successful so report the error and suggest a solution
            presentStatus(StatusText, "Could not start the game: Try verifying the install.", 1)
        End Try

    End Sub ' startGameButton_Click

    Private Sub GameConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GameConfigurationToolStripMenuItem.Click
        ' Allocate data storage for the file to execute
        ' This will be set based on the value of serverNumber

        Dim filepath As String = Nothing

        ' Using a case statement so that this is ready for more than one test server location
        Select Case serverNumber
            Case 0
                filepath = getGamePath()
            Case 1
                filepath = getTestPath()
            Case Else
                presentStatus(StatusText, "Internal Error 1002", 1)
                Return
        End Select

        'Launch Game client

        ' New ProcessStartInfo created
        Dim calc As New ProcessStartInfo
        calc.FileName = GameSetup
        calc.WorkingDirectory = filepath
        ' Use a hidden window
        calc.WindowStyle = ProcessWindowStyle.Hidden
        Try
            Process.Start(calc)
        Catch ex As Exception
            ' Launch was not successful so report the error and suggest a solution
            presentStatus(StatusText, "Could not start the game configuration tool: Try verifying the install.", 1)
        End Try

    End Sub ' GameConfigurationToolStripMenuItem_Click

End Class
