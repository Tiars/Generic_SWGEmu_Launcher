Imports System
Imports System.IO
Imports System.Net
Imports System.Object
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms

Public Class installUtils

    Private Function PrintByteArray(ByVal array() As Byte) As String
        ' Return the checksum converted in a string 
        Dim i As Integer
        Dim pcksum As String = ""
        For i = 0 To array.Length - 1
            pcksum = pcksum & Format(String.Format("{0:X2}", array(i)))
        Next i
        Return pcksum

    End Function 'PrintByteArray

    Private Function getFileMD5(ByVal lfile As String) As String

        ' Initialize a md5 hash object. 
        Dim md5Hash As MD5 = MD5.Create()
        Dim hashValue() As Byte

        ' See if the file exists
        If File.Exists(lfile) Then
            ' Create a fileStream for the file. 
            Dim fileStream As FileStream = File.Open(lfile, FileMode.Open, FileAccess.Read, FileShare.None)

            ' Be sure it's positioned to the beginning of the stream.
            fileStream.Position = 0
            ' Compute the hash of the fileStream.
            hashValue = md5Hash.ComputeHash(fileStream)

            ' Close the file.
            fileStream.Close()

            Return PrintByteArray(hashValue)
        Else
            ' File does not exist so return nothing
            Return Nothing
        End If

    End Function 'getFileMD5

    Public Function isGoodFile(ByVal lfile As String, ByVal cSum As String) As Boolean
        Dim fSum As String = Nothing
        ' Return False if the file does not exist
        If Not My.Computer.FileSystem.FileExists(lfile) Then Return False

        fSum = getFileMD5(lfile)

        'File did not exist or could not be read so checksum could not be created
        ' so return False
        If fSum = Nothing Then Return False

        'If the checksum strings match return True
        If StrComp(cSum, fSum, CompareMethod.Text) = 0 Then Return True

        'Default to return False
        Return False

    End Function 'isGoodFile

End Class
