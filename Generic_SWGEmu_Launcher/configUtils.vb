Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System
Imports System.Collections
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Serialization

Public Class configUtils

    Public Const SWGServer As String = "SWG Tiars"
    Public clientPath As String

    Public Function getServerName() As String
        Return SWGServer
    End Function 'getServerName

    Public Function getClientPath() As String
        Return clientPath
    End Function 'getClientPath

    Public Sub setClientPath(ByVal path As String)
        clientPath = path
    End Sub 'setClientPath

    Public Function getSWGLocation() As String

        Try
            ' Get from the registry the location of where SWG was installed
            ' No need to paramatarize this since it should not change
            Dim readValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\StarWarsGalaxies", "Path", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return "ERROR - Value does not exist."
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return "ERROR - Security Exception: " & vbCrLf & vbCrLf & e.Message
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return "ERROR - Empty Key Name: " & vbCrLf & vbCrLf & e.Message
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return "ERROR - Key Name Too Long: " & vbCrLf & vbCrLf & e.Message
        End Try

    End Function 'getSWGLocation

    Public Function getLauncherVersion() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "Version", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getLauncherVersion

    Public Sub setLauncherVersion(ByVal setValue As String)

        Try
            ' Get from the registry the Version String
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "Version", setValue)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return
        End Try

    End Sub 'setLauncherVersion

    Public Function getLauncherURL() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "URL", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getLauncherURL

    Public Function getLauncherHasTest() As Boolean

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "HasTest", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is Yes
            Return readValue Like "[Yy][Ee][Ss]"

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return False
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return False
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return False
        End Try

    End Function 'getLauncherHasTest

    Public Function getLauncherHasEULA() As Boolean

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "HasEULA", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is Yes
            Return readValue Like "[Yy][Ee][Ss]"

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return False
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return False
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return False
        End Try

    End Function 'getLauncherHasEULA


    Public Function getLauncherReadEULA() As Boolean

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "readEULA", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is Yes
            Return readValue Like "[Yy][Ee][Ss]"

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return False
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return False
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return False
        End Try

    End Function 'getLauncherReadEULA

    Public Sub setLauncherReadEula(ByVal setValue As String)

        Try
            ' Get from the registry the Version String
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "readEULA", setValue)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return
        End Try

    End Sub 'setLauncherReadEULA

    Public Function getLauncherEULA() As String

        Return "EULA.txt"

    End Function 'getLauncherEULA

    Public Function getLauncherHasCalc() As Boolean

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "HasCalc", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is Yes
            Return readValue Like "[Yy][Ee][Ss]"

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return False
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return False
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return False
        End Try

    End Function 'getLauncherHasCalc

    Public Function getLauncherCalc() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "Calc", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getLauncherCalc

    Public Function getLauncherHasForum() As Boolean

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "HasForum", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is Yes
            Return readValue Like "[Yy][Ee][Ss]"

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return False
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return False
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return False
        End Try

    End Function 'getLauncherHasForum

    Public Function getLauncherForum() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Launcher", "Forum", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getLauncherForum

    Public Function getGameVersion() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Version", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getGameVersion

    Public Sub setGameVersion(ByVal setValue As String)

        Try
            ' Get from the registry the Version String
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Version", setValue)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return
        End Try

    End Sub 'setGameVersion

    Public Function getGameURL() As String

        Try
            ' Get from the registry the URL base for downloading game components
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "URL", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getGameURL

    Public Function getGameManifest() As String

        Dim readValue = getGameURL() & "Manifest"

        If readValue = "Manifest" Then
            Return Nothing
        Else
            Return readValue
        End If

    End Function 'getGameManifest

    Public Function getGamePatchNotes() As String

        Try
            ' Get from the registry the URL of the Patch Notes
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Patchnotes", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getGamePatchNotes

    Public Function getGameStatus() As String

        Try
            ' Get from the registry the URL of the server status information
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Status", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getGameStatus

    Public Function getGamePath() As String

        Try
            ' Get from the registry the local path to the game files
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Path", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getGamePath

    Public Sub setGamePath(ByVal setValue As String)

        Try
            ' Get from the registry the Version String
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Path", setValue)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return
        End Try

    End Sub 'setGamePath

    Public Function getTestVersion() As String

        Try
            ' Get from the registry the Version String
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Version", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getTestVersion

    Public Sub setTestVersion(ByVal setValue As String)

        Try
            ' Get from the registry the Version String
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Version", setValue)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return
        End Try

    End Sub 'setTestVersion

    Public Function getTestURL() As String

        Try
            ' Get from the registry the URL base for downloading game components
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "URL", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getTestURL

    Public Function getTestManifest() As String


        Dim readValue = getTestURL() & "Manifest"

        If readValue = "Manifest" Then
            Return Nothing
        Else
            Return readValue
        End If


    End Function 'getTestManifest

    Public Function getTestPatchNotes() As String

        Try
            ' Get from the registry the URL of the Patch Notes
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Patchnotes", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getTestPatchNotes

    Public Function getTestStatus() As String

        Try
            ' Get from the registry the URL of the server status information
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Status", Nothing)

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getTestStatus

    Public Function getTestPath() As String

        Try
            ' Get from the registry the local path to the game files
            Dim readValue = getGamePath() & "Testserver\"

            ' Will not get here if exception is thrown

            ' Check to see if the entry is empty
            ' Debug code
            'If readValue Is Nothing Then
            '    Return Nothing
            'End If

            ' Return the value, Nothing or Error message
            Return readValue

        Catch e As SecurityException
            ' Handle the user does not have permissions to read from registry keys
            Return Nothing
        Catch e As ArgumentNullException
            ' Handle the name of the key is Nothing
            Return Nothing
        Catch e As ArgumentException
            ' Handle the key name exceeds the 255-character limit 
            Return Nothing
        End Try

    End Function 'getTestPath

End Class
