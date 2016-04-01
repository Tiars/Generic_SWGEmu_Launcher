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
Imports Generic_SWGEmu_Launcher

Public Class Launchpad


    Private Sub SWGEmu_Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the window name
        Me.Text = "Version 1.00.00"

        presentText(TextBox1, "Hello World", 100)
        blankLine(TextBox1, 100)
        extendText(TextBox1, "Good Progress", 100)

    End Sub
End Class
