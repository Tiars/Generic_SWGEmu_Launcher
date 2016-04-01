Imports Microsoft.VisualBasic
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Win32

Module configUtils

    Public Function getSWGLocation() As String

        Try
            ' Get from the registry the location of where SWG was installed
            Dim readValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\StarWarsGalaxies",
"Path", Nothing)

            ' Check to see if the entry is empty
            If readValue Is Nothing Then
                Return "Value does not exist."
            End If

            ' Return the non-null value
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

    Public Function setEMULocation() As String

        Return "Not Implemented yet"

    End Function 'setEMULocation

End Module
