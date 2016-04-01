Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Collections
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Threading

Public Class textUtils

    Public Function clearStatus(ByVal text As TextBox)
        ' Clear and Refresh the text box
        text.Clear()
        text.Refresh()
    End Function 'presentStatus

    Public Function presentStatus(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Clear the text box
        clearStatus(text)

        ' Output the string to the text box
        text.Text = status
        text.Refresh()

        ' Give the user a chance to see the status
        If delay < 1 Then delay = 1
        Thread.Sleep(delay)
    End Function 'presentStatus

    Public Function extendStatus(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Output the string to the text box without clearing current content
        text.Text = text.Text & status
        text.Refresh()

        ' Give the user a chance to see the status
        If delay < 1 Then delay = 1
        Thread.Sleep(delay)
    End Function 'extendStatus

    Public Function presentText(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Clear text and output a string with a newline attached
        presentStatus(text, status & vbCrLf, delay)

    End Function 'presentText

    Public Function extendText(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Output a string with a newline attached
        extendStatus(text, status & vbCrLf, delay)

    End Function 'extendText

    Public Function blankLine(ByVal text As TextBox, ByVal delay As Double)
        ' Output a blank line
        extendStatus(text, vbCrLf, delay)

    End Function 'blankLine

End Class
