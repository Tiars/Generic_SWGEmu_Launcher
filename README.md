# Generic_SWGEmu_Launcher
Port of the SWGChoice Launcher to a generic format

This work will include the following:

1. Split the text update routines into a seperate module file and make reusable.
2. Split the xml and configuration routines into a seperate module file and make reusable.
3. Split the MD5 routines into a seperate module file and make reusable.
4. Create manifest routines in a seperate module and add human readable translations.
5. Split the file download routines into a seperate module file and make reusable.

By creating these modules code that is common between the manifest tool and the launcher can be readily shared which will improve maintainability and speed tool creation.

The original thought was to make the code as portable as possible. This concept has been abandoned but reusability is still a priority.

So instead of storing some configuration information in an XML config file the program will store the information in the Microsoft Windows Registry. But since the information will be put and gathered using functions the functions can be modified to use the original XML configuration file scheme simply by changing just the function code.

With this change the relationship between the launcher and the game code will be removed. In the SWGChoice version of the launcher the instal and execute code of the launcher required that the game code be installed in the same subdirectory that had the launcher. The requested location to install the game will now be requested and stored in the registry for future use.

Based on research the SOE installer stores the path to the game in the "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\StarWarsGalaxies\Path", or HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\SWG_Client\Path" but I think that this may be set by the SWGEmu launcher, Location. The existance of this path will be made part of the verification. I have a clean install of Windows 10 that has never had SWG or SWGEmu installed on it so the registry entry will be verified before this project is considered complete.

The installer will set up the following Registry entries:
(The value of <SWG Emu> should be changed for each SWGEmu game provider.)

HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\Version
	The version of the Launcher
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\URL
	The URL to use to get Launcher files
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\HasTest
	Yes/No answer to if the server has a seperate Test Server
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\Version
	The current version of the Game client files
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\URL
	The URL to use to get Game files
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\Patchnotes
	The URL to use to get Game Patchnotes
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\Status
	The current Game status information URL
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\Path
	The current location of the Game executables
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Version
	The current version of the Test client files
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\URL
	The URL to use to get Test files
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Patchnotes
	The URL to use to get Test Patchnotes
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Status
	The current Test status information URL
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Path
	The current location of the Test executables

Interesting Update:

After wasting an entire day trying to cause the Patchnotes and server status
windows to toggle between the live and test servers I discovered a problem with
the Visual Studio WebBrowser widget. It uses the actual browser configuration for
several things. If the browser is set like mine you can not update the URL
easily. So I converted the status and Parch notes windows to use the RichTextBox
widget.

I decided to go with rtf for several reasons.

1. It could be readily edited using winpad so no need to purchase an editor.
2. It would be trivial to change the sample get status code to 
   generate rtf instead of html.
3. I was using Microsoft Word to edit the Patch Notes and saving it as
   html so it would be trivial to save it as rtf instead.
4. Just like html the rtf format supported setting font, font size, text
   color and decent formatting so nothing would be lost.

Launcher Buttons

The Choice Launcher had buttons for Launching a browser to show the EULA,
Launching the Profession Calculator, Launching a browser to the forums,
Launching the game configuration and Installing or repairing the install.

I have decided to add registry entries to determine if these buttons should
be displayed and what they do. The game configuration and Install/repair
buttons will always be there so only the other three will be configurable.

The new registry entries are:

HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\HasForum
	Is there a forums
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\Forum
	The URL to the forum
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\HasCalc
	Is there a Profession Calculator
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\Calc
	The assumption is that it will be Kodan's calculator and installed locally
	This is the path to the executable
	Eventually I can check to see if it starts with http: and if it does then
	launch the default browser to the URL
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\HasEULA
	Is there a EULA for this server
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Launcher\EULA
	The URL to the EULA. Since URLs can point to a local file there is no need
	for this to reside on a web server.

Update

Removed the registry entry for the local copy of the manifest file since if it
is used it will be copied into memory. Now it is copied directly into memory and
not cached locally. Since this code, unlike the Choice server code, checks the
version instead of blindly rechecking the checksum there is no performance to be
gained by keeping a local copy.

# Design Clarification

At start the version of the launcher will be checked to see if it needs updating.
If the launcher needs updating it will download and update the launcher.

If the game client has not been installed there will be no check of the local
version against the server version. The install verify button will be labeled
Install.

If the game client has been installed the local and server versions will be
compared and if the server version is newer than the local copy the manifest will
be downloaded and the client updated.

Since not everyone will want the test server client installing is a three step process.

First the play client must be installed.
Second the launcher must be set to test server using the tool bar button.
Third the Install of the test client will need to be done.

The robust test for a legal copy of SWG is done as part of the play client install so 
it is reasonable to use a successful install of the play client as a quick test for a
legal copy when installing the test client.

Since the static .tre files up through Publish 14.1 only need one copy, the test Server
will save space by pointing to those .tre files in the play directory. So the test client
directory will be smaller as will an efficient manifest.