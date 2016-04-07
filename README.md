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

Based on research the SOE installer stores the path to the game in the "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\StarWarsGalaxies\Path" and HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\SWG_Client\Path". This was observerd with a clean install of Windows 10 and then
installing from the original 3 CD set.

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

# Manifest format and Flags

The manifest is a CSV file with four fields.

Field 1 = Relative path to file or directory
          Registry entry
Field 2 = Action Flag
Field 3 = Action 0 - 1, 6 - Comment
          Action 2 - 4    - MD5 Checksum
          Action 5        - String Value for registry entry


Flag - Action

0  = Delete file or directory if it exists
     This flag is allocated to allow for cleaning up a directory. For example
     it was decided to merge two .tre files and this was used to remove the now
     unneeded file.

1  = Directories to create
     These are directories to create to speed up the initial launch of the game.

2  = Verify Legal Copy
     All files with this flag must exist in the SOE install directory and match
     the provided checksum for the launcher to consider a legal copy to have been
     installed.

     At install time the files are copied from the SOE directory to getGamePath().
     At verify time if the file in getGamePath() does not match the checksum the 
     file is copied from the SOE directory if the SOE install directory has not 
     been removed. An additional test will be done at verify time with files
     copied from the install directory. They will be tested to see if they are
     undamaged and match the checksum. If the SOE install directory has been 
     removed to save disk space or does not match the checksum it is then 
     downloaded from the game server.

     One additional note. The various retail distributions included more and more
     of the .tre files to speed up the install by downloading fewer files from
     the server. The original distribution disks included the following .tre files
     which are checked to verify a legal distribution:

     bottom.tre
     data_animation_00.tre
     data_music_00.tre
     data_other_00.tre
     data_sample_00.tre
     data_sample_01.tre
     data_sample_02.tre
     data_sample_03.tre
     data_sample_04.tre
     data_skeletal_mesh_00.tre
     data_skeletal_mesh_01.tre
     data_static_mesh_00.tre
     data_static_mesh_01.tre
     data_texture_00.tre
     data_texture_01.tre
     data_texture_02.tre
     data_texture_03.tre
     data_texture_04.tre
     data_texture_05.tre
     data_texture_06.tre
     data_texture_07.tre
     default_patch.tre
     patch_00.tre
     patch_01.tre

     If you want you can also add the following client executables to
     this catagory, but most were updated for versions of the client
     that were shipped between the initial disk and Publish 14.1. If
     you add them to this catagory they probably need to be in 
     catagory 2 also so that you make sure that the correct version for
     the client is downloaded with the client.

     The Launcher manifest has no need to use this action.

3  = SOE static files
     This catagory is all of the client executables, dlls, config files
     and executables associated with Publish 14.1.\

     SOE layered .tre files so that each new publish that had additional
     items in the .tre files added new .tre files. It is recommended that
     SWGEmu custom servers continue to use this philosophy.

     Files in this catagory will be checked to see if they exist in the
     SOE install directory. If they do and match the checksum they will
     be copied instead of downloaded to speed things up for people with
     later versions of the install disks or still have their fully installed
     directory from when they played the live game.

     The Launcher manifest has no need to use this action.

4  = Server extension files
     For servers that are adding items to their server this is the catagory
     for lumping the additional .tre files.

     It would also be used for the server specific swgemu.cfg, swgemu_live.cfg,
     swgemu_login.cfg, swgemu_preload.cfg and user.cfg files. These will
     exist in a legacy SOE install directory from when the game was still running
     but will also not neccisarily match your SWGEmu server. They may even be
     different between the play and test versions of the server. All of these 
     are reasons to place them into this catagory.

     The Launcher manifest would use this for supplemental files, like a 
     profession calculator stored in the launcher directory.

5  = Add new registry entry
     Location has no real meaning with this action. Location 0 is recommended.

     Only used by the Launcher manifest

6  = Delete registry entry
     Location has no real meaning with this action. Location 0 is recommended.

     Only used by the Launcher manifest

7+ = Set aside for future use

# TestServer directory

To save disk space it is best to set up the swgemu_live.cfg in the Test Server
path to point to the Game client directory for the publish 14.1 and other .tre
files that you are not changing. If you make the Test Server directory a
sub directory of the game client directory, as SOE did, the unchanging .tre
files can be referenced by prepending "../" to each entry in the file.

If you decide to operate multiple test clients that are working on different
things and needing different versions of files, you can have multiple sub directories
in the game server directory.

When talking about install and verifying the game files I will expect that this 
is how the directories are structured. This system also means that for every file
listed in the swgemu_live.cfg file as being taken from the game client directory
it can be ommited from the test client manifest. This will make the install and
verify for the test client go faster in addition to saving disk space.

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