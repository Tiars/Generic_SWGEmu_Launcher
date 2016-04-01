# Generic_SWGEmu_Launcher
Port of the SWGChoice Launcher to a generic format

This work will include the following:

1. Split the text update routines into a seperate module file and make reusable.
2. Split the xml and configuration routines into a seperate module file and make reusable.
3. Split the MD5 routines into a seperate module file and make reusable.
4. Create manifest routines in a seperate module and add human readable translations.
5. Split the file download routines into a seperate module file and make reusable.

By creating these modules code that is common between the manifest tool and the launcher can be readily shared which will improve maintainability and speed tool creation.
