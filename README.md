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

Based on research the SOE installer stores the path to the game in the "Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\StarWarsGalaxies\Path", or Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\SWG_Client\Path" but I think that this may be set by the SWGEmu launcher, Location. The existance of this path will be made part of the verification. I have a clean install of Windows 10 that has never had SWG or SWGEmu installed on it so the registry entry will be verified before this project is considered complete.
