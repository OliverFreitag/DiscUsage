Chinese Lunar Calenar Sample
============================
     This sample demonstrates how to use GetSexagenaryYear(), GetCelestialStem() and GetTerrestrialBranch() in the ChineseLunisolarCalendar class to create an application that needs to work with a Sexagenary Year, and also support the Lunar term.


Sample Language Implementations
===============================
     This sample is available in the following language implementations:
     C#
     Visual Basic


To build the sample using the command prompt:
=============================================
     1. Open the Command Prompt window and navigate to one of the language-specific subdirectories under the ChineseCalendarSample directory.
     2. Type msbuild ChineseLunarCalendarCS.sln or msbuild ChineseLunarCalendarVB.sln, depending on your choice of programming language.


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to one of the language-specific subdirectories under the ChineseCalendarSample directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The application will be built in the default \bin or \bin\Debug directory.

     Additional things to consider when building this sample are:
     If you use Visual Basic .NET, please compile the ChineseLunarCalendarVB.proj first and then compile  ChineseCalendarFormVB.proj. 
     If you use Visual C# .NET,  please  compile the ChineseLunarCalendarCS.proj first and then compile  ChineseCalendarFormCS.proj.


To run the sample:
=================
     1. Navigate to the directory that contains the new executable, using the command prompt or Windows Explorer.
     2. Type ChineseLunarCalendar.exe at the command line, or double-click the icon for ChineseCalendar.exe to launch it from Windows Explorer. 


Remarks
=================
     The valid year range is from 2000 to 2020.
     This sample also demonstrates multilanguage support in .NET Framework 2.0.