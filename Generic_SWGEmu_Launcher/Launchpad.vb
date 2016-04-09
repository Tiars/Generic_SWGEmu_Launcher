Imports System
Imports System.IO
Imports System.Net
Imports System.Object
Imports System.Security.Cryptography
Imports System.Text
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

    'Save the results of the game installed test
    Dim gameInstalled As Boolean = False

    'Save the results of the game installed test
    Dim testInstalled As Boolean = False

    ' Allocate the shared Manifest memory
    Dim manifest_file As String = ""
    Dim num_rows As Long = 0
    Dim one_line As Object
    Dim num_cols As Long = 0

    Dim EulaForm As confirmEULA

    'DECLARE THIS WITHEVENTS SO WE GET EVENTS ABOUT DOWNLOAD PROGRESS
    Private WithEvents _Downloader As WebFileDownloader

    'Internal error number documentation
    ' 1001 Invalid value of serverNumber found when trying to launch game client
    ' 1002 Invalid value of serverNumber found when trying to launch game configuration tool
    ' 1003 Invalid value of serverNumber found when trying to install or verify the play or test clients

    Private Function PrintByteArray(ByVal array() As Byte) As String
        ' Return the checksum converted in a string 
        Dim i As Integer
        Dim pcksum As String = ""
        For i = 0 To array.Length - 1
            pcksum = pcksum & Format(String.Format("{0:X2}", array(i)))
        Next i
        Return pcksum
    End Function 'PrintByteArray

    Private Sub getManifest(ByRef array As String, ByRef rows As Long, ByRef cols As Long, ByVal URL As String)
        Dim localLines As Object
        Dim oneLine As Object

        ' Load the Live manifest file into memory
        Dim request As WebRequest = WebRequest.Create(URL)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                array = reader.ReadToEnd()
            End Using
        End Using


        ' split it into individual lines
        localLines = Split(array, vbCrLf)
        ' determine the number of files
        ' num_rows becoming non-zero indicates that the manifest has been downloaded and placed into memory
        rows = UBound(localLines)
        ' break the first line into fields 
        oneLine = Split(localLines(0), ",")
        ' determine the number of fields
        cols = UBound(oneLine)

    End Sub 'getManifest

    Private Function verifyLegal(ByRef array As String, ByRef rows As Integer, ByRef cols As Integer) As Boolean
        Dim localLines As Object
        Dim oneLine As Object
        Dim iCount As Integer = 0
        Dim index As Integer = 0
        Dim legal As Boolean = False
        Dim soeSWG As String = getLauncherSOEPath()

        presentStatus(StatusText, "Checking " & soeSWG & "For Legal copy of Star Wars Galaxies", 2000)

        ' split it into individual lines
        localLines = Split(array, vbCrLf)


        ' Count the number of verification files
        ' First reset the index
        index = 0

        Do While index < rows
            'Parse out the current line into columns
            oneLine = Split(localLines(index), ",")


            'Check to see if it is a file to verify the legal copy
            If oneLine(1) = "2" Then
                iCount = iCount + 1
            End If
            index = index + 1
        Loop

        ' Initialize the overall progress bar now that the number of 
        ' files are known
        OverallProgressBar.Value = 0
        OverallProgressBar.Maximum = iCount

        ' Initialize a md5 hash object. 
        Dim md5Hash As MD5 = MD5.Create()
        Dim hashValue() As Byte

        ' Verify the files
        ' First reset the index
        index = 0

        Do While index < rows

            'Parse out the current line into columns
            oneLine = Split(localLines(index), ",")

            'Check to see if it is a file to verify the legal copy
            If oneLine(1) = "2" Then
                'Since there are files to check to see if there is a legal copy in the manifest
                'change the default return from False to True
                legal = True

                'Display progress
                'Bump the overall progress
                OverallProgressBar.Value = OverallProgressBar.Value + 1
                'Display the file being checked
                presentStatus(StatusText, soeSWG & oneLine(0), 1)

                ' See if the file exists
                If File.Exists(soeSWG & oneLine(0)) Then
                    ' Create a fileStream for the file. 
                    Dim fileStream As FileStream = File.Open(soeSWG & oneLine(0), FileMode.Open, FileAccess.Read, FileShare.None)

                    ' Be sure it's positioned to the beginning of the stream.
                    fileStream.Position = 0
                    ' Compute the hash of the fileStream.
                    hashValue = md5Hash.ComputeHash(fileStream)

                    ' Close the file.
                    fileStream.Close()

                    ' Verify that the hash values match

                    If Not StrComp(oneLine(2), PrintByteArray(hashValue), CompareMethod.Text) = 0 Then
                        ' File fails checksum so return that no legal copy was found
                        OverallProgressBar.Value = OverallProgressBar.Maximum
                        Return False
                    End If
                Else
                    OverallProgressBar.Value = OverallProgressBar.Maximum
                    Return False
                End If
            End If
            index = index + 1
        Loop

        OverallProgressBar.Value = OverallProgressBar.Maximum
        Return legal

    End Function 'verifyLegal

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
                If lVersion >= serverVersion Then Return True
            End Using
        End Using

        Return False ' False buy default
    End Function 'getServerGameVersion

    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' For test purposes set the working directory
        Directory.SetCurrentDirectory("D:\Users\Public\Games\SWG Tiars Launcher")

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

        'See if the game has been installed 
        If File.Exists(getGamePath() & GameClient) Then
            gameInstalled = True
            InstallToolStripMenuItem.Text = "Verify"
        Else
            gameInstalled = False
            InstallToolStripMenuItem.Text = "Install"
        End If

        ' Only ask for Test Server information if the server has a test server
        If getLauncherHasTest() Then
            testUpToDate = getVersionUpToDate(localVersion, getTestVersion(), getTestURL())
            testServerVersion = localVersion

            'See if the game has been installed 
            If File.Exists(getTestPath() & GameClient) Then
                testInstalled = True
            Else
                testInstalled = False
            End If

        End If

    End Sub

    Private Sub SWGEmu_Launcher_Running(sender As Object, e As EventArgs) Handles MyBase.Shown

        If Not launcherUpToDate Then
            presentStatus(StatusText, "Updating Launcher to version " & launcherServerVersion, 1)

            Dim oVersion = getLauncherVersion()

            Try
                _Downloader = New WebFileDownloader
                _Downloader.DownloadFileWithProgress(getLauncherURL() & "LaunchPad.exe", "LaunchPadNew.exe")
                OverallProgressBar.Value = OverallProgressBar.Value + 1
            Catch ex As Exception
                presentStatus(StatusText, "Error updating launcher. Exiting", 10000)
                Application.Exit()
            End Try

            presentStatus(StatusText, "Restarting Launcher", 1000)
            ' Launch the update helper
            Dim updater As New ProcessStartInfo
            updater.FileName = "LauncherUpdateHelper.exe"

            ' Use a hidden window
            updater.WindowStyle = ProcessWindowStyle.Hidden
            Try
                Process.Start(updater)
                ' Update registry
                ' This should be moved to the updater
                setLauncherVersion(launcherServerVersion)
                ' Exit the launcher so that the updater can do its job
                Application.Exit()
            Catch ex As Exception
                ' Launch was not successful so report the error and suggest a solution
                setLauncherVersion(oVersion)
                presentStatus(StatusText, "Could not copmplete update: Try reinstalling the launcher.", 1)
            End Try

        End If

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
        'Open the EULA and confirm reading
        EulaForm = New confirmEULA()

        'Present the EULA
        EulaForm.Show()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'VERIFY A DIRECTORY WAS PICKED AND THAT IT EXISTS
        If Not IO.Directory.Exists("c:\mtmp") Then
            MessageBox.Show("Not a valid directory to download to, please pick a valid directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Initialize the overall progress bar
        OverallProgressBar.Value = 0
        OverallProgressBar.Maximum = 3

        'DO THE DOWNLOAD
        Try
            _Downloader = New WebFileDownloader
            _Downloader.DownloadFileWithProgress("http://10.0.0.8/Game/patch_10.tre", "c:\mtmp\patch_10.tre")
            OverallProgressBar.Value = OverallProgressBar.Value + 1
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        Try
            _Downloader = New WebFileDownloader
            _Downloader.DownloadFileWithProgress("http://10.0.0.8/Game/patch_11_00.tre", "c:\mtmp\patch_11_00.tre")
            OverallProgressBar.Value = OverallProgressBar.Value + 1
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        Try
            _Downloader = New WebFileDownloader
            _Downloader.DownloadFileWithProgress("http://10.0.0.8/Game/patch_12_00.tre", "c:\mtmp\patch_12_00.tre")
            OverallProgressBar.Value = OverallProgressBar.Value + 1
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        OverallProgressBar.Value = OverallProgressBar.Maximum
    End Sub

    'Start Routines to support WebFileDownloader.vb module

    'FIRES WHEN WE HAVE GOTTEN THE DOWNLOAD SIZE, SO WE KNOW WHAT BOUNDS TO GIVE THE PROGRESS BAR
    Private Sub _Downloader_FileDownloadSizeObtained(ByVal iFileSize As Long) Handles _Downloader.FileDownloadSizeObtained
        IndividualProgressBar.Value = 0
        IndividualProgressBar.Maximum = Convert.ToInt32(iFileSize)
    End Sub

    'FIRES WHEN DOWNLOAD IS COMPLETE
    Private Sub _Downloader_FileDownloadComplete() Handles _Downloader.FileDownloadComplete
        IndividualProgressBar.Value = IndividualProgressBar.Maximum
    End Sub

    'FIRES WHEN DOWNLOAD FAILES. PASSES IN EXCEPTION INFO
    Private Sub _Downloader_FileDownloadFailed(ByVal ex As System.Exception) Handles _Downloader.FileDownloadFailed
        MessageBox.Show("An error has occured during download: " & ex.Message)
    End Sub

    'FIRES WHEN MORE OF THE FILE HAS BEEN DOWNLOADED
    Private Sub _Downloader_AmountDownloadedChanged(ByVal iNewProgress As Long) Handles _Downloader.AmountDownloadedChanged
        IndividualProgressBar.Value = Convert.ToInt32(iNewProgress)
        ' StatusText.Text = WebFileDownloader.FormatFileSize(iNewProgress) & " of " & WebFileDownloader.FormatFileSize(IndividualProgressBar.Maximum) & " downloaded"
        Application.DoEvents()
    End Sub

    'End Routines to support WebFileDownloader.vb module

    Private Sub InstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallToolStripMenuItem.Click

        Select Case serverNumber
            Case 0
                ' verify the game install if the game has been installed
                ' otherwise see if a legal copy of SWG is on the machine
                '  and if so them install the game
                If gameInstalled Then
                    getManifest(manifest_file, num_rows, num_cols, getGameManifest())
                    ' installVerify(manifest_file)
                Else
                    getManifest(manifest_file, num_rows, num_cols, getGameManifest())
                    ' get SOE SWG location and set environment variable
                    If verifyLegal(manifest_file, num_rows, num_cols) Then
                        ' installVerify(manifest_file, num_rows, num_cols)
                    End If
                End If
            Case 1
                ' verify the test install if the test has been installed
                ' otherwise see if the main is on the machine
                '  and if so them install the game
                If testInstalled Then
                    getManifest(manifest_file, num_rows, num_cols, getTestManifest())
                    ' installVerify(manifest_file, num_rows, num_cols)
                Else
                    ' If the play client has been installed then it is safe to
                    '  conclude that the person has a legal copy
                    If gameInstalled Then
                        getManifest(manifest_file, num_rows, num_cols, getTestManifest())
                        ' installVerify(manifest_file)
                    End If
                End If
            Case Else
                presentStatus(StatusText, "Internal Error 1003", 1)
                Return
        End Select

        'For Debug purposes display Manifest information
        MsgBox("Minifest file contains" & vbCrLf &
               Format(num_rows + 1, "G") & " Lines of " &
               Format(num_cols + 1, "G") & " Elements")
    End Sub


End Class
