Public NotInheritable Class SplashScreen

    Dim cUtils As New configUtils

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'Set Version info
        Version.Text = "Version: " & cUtils.getLauncherVersion()
    End Sub

End Class
