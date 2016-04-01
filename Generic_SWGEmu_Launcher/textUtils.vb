Imports System
Imports System.Text
Imports System.Threading

Module textUtils

    Public Sub clearStatus(ByVal text As TextBox)
        ' Clear and Refresh the text box
        text.Clear()
        text.Refresh()

    End Sub 'presentStatus

    Public Sub presentStatus(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Clear the text box
        clearStatus(text)

        ' Output the string to the text box
        text.Text = status
        text.Refresh()

        ' Give the user a chance to see the status
        If delay < 1 Then delay = 1
        Thread.Sleep(delay)

    End Sub 'presentStatus

    Public Sub extendStatus(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Output the string to the text box without clearing current content
        text.Text = text.Text & status
        text.Refresh()

        ' Give the user a chance to see the status
        If delay < 1 Then delay = 1
        Thread.Sleep(delay)

    End Sub 'extendStatus

    Public Sub presentText(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Clear text and output a string with a newline attached
        presentStatus(text, status & vbCrLf, delay)

    End Sub 'presentText

    Public Sub extendText(ByVal text As TextBox, ByVal status As String, ByVal delay As Double)
        ' Output a string with a newline attached
        extendStatus(text, status & vbCrLf, delay)

    End Sub 'extendText

    Public Sub blankLine(ByVal text As TextBox, ByVal delay As Double)
        ' Output a blank line
        extendStatus(text, vbCrLf, delay)

    End Sub 'blankLine

End Module
