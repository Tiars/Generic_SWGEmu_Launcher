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
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Game\Manifest
	The current location of the Game install Manifest file
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
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Manifest
	The current location of the Test install Manifest file
HKEY_CURRENT_USER\SOFTWARE\<SWG Emu>\Test\Path
	The current location of the Test executables

Interesting Update:

After wasting an entire day trying to cause the Patchnotes and server status
windows to toggle between the live and test servers I discovered a problem with
the Visual Studio WebBrowser widget. It uses the actual browser configuration for
several things. If the browser is set like mine you can not update the URL
easily. So I converted the status and Parch notes windows to use the RichTextBox
widget.