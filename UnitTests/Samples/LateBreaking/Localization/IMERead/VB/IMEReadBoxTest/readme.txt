IME Reading String Sample
=========================
     This sample demonstrates a TextBox control with a property and an event to retrieve IME reading string. It includes two samples: the IMEReadingStringBox and a test container. 

The IMEReadingStringBox needs to be built first, before building the test container.


Sample Language Implementations
===============================
     This sample is available in the following language implementations:
     C#
     Visual Basic


To build the sample using the command prompt:
=============================================
     1. Open the Command Prompt window and navigate to one of the language-specific subdirectories under the IMEReadingString directory.
     2. Type msbuild IMEReadingStringCS.sln or msbuild IMEReadingStringVB.sln depending on your choice of programming language.


To build each sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to one of the language-specific subdirectories under the IMEReadingString directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The application will be built in the default \bin or \bin\Debug directory.

To run the sample:
=================
     1. Navigate to the directory that contains the new executable, using the command prompt or Windows Explorer.
     2. Type IMEReadingStringBox.exe or IMEReadingStringBoxTest.exe at the command line, or double-click the icon for IMEReadingStringBox.exe or IMEReadingStringBoxTest.exe to launch it from Windows Explorer. 


Remarks
=================
     This sample works only if Japanese IME is activated, otherwise it works as a standard TextBox control.
     IMEReadingStringBox doesn't implement design time support required to keep it simple.

Demonstrates
============
     This sample demonstrates the following:
     IME


