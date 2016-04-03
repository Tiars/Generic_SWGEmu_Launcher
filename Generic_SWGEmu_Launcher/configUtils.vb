Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Win32

Module configUtils

    Const SWGServer As String = "SWG Tiars"

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

        Try
            ' Get from the registry the local copy of the Manifest file
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Game", "Manifest", Nothing)

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

        Try
            ' Get from the registry the local copy of the Manifest file
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Manifest", Nothing)

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
            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\" & SWGServer & "\Test", "Path", Nothing)

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

End Module
