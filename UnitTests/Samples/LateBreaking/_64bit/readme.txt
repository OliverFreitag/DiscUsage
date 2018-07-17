64-bit .Net Framework Application Sample
=======================================
     This sample demonstrates the different ways to build .Net Framework applications that run on 32-bit and 64-bit CPU types. This sample also demonstrates how to detect if your application is running as a 32-bit or a 64-bit process on a 64-bit CPU.


Sample Language Implementations
===============================
     This sample is available in the following language implementations:
     C#
     Visual Basic


To build the sample using the command prompt:
=============================================
     1. Open the Command Prompt window and navigate to one of the language-specific subdirectories under the 64bit Application directory.
     2. Type msbuild 64bit_ApplicationCS.sln or msbuild 64bit_ApplicationVB.sln, depending on your choice of programming language.


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to one of the language-specific subdirectories under the 64bit Application directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The application will be built in the default \bin or \bin\Debug directory.

To run the sample:
=================
     1. Navigate to the directory that contains the new executable, using the command prompt or Windows Explorer.
     2. Type 64bit_ApplicationCS.exe or 64-bitApplicationVB.exe at the command line, or double-click the icon for 64bit_ApplicationCS.exe or 64bit_ApplicationVB.exe to launch it from Windows Explorer. 


Remarks
=================
     This sample builds binary files that only run on the appropriate CPU architecture. This sample builds four binaries:
• An x86 binary that runs as a 32-bit application on all processor types
• An IA64 binary that will only run as a 64-bit process on Itanium processors
• An x64 binary that will run as a 64-bit process on X64 processors
• A compiled binary that will run as a 32-bit application on x86 processors and as a 64-bit application on 64-bit processors.


Demonstrates
============
     This sample demonstrates the following:
     64-bit CLR (Common Language Runtime)


See Also
============
     Other topics related to this sample that you may want to look up in the documentation are:
     IntPtr.Size,  PropertyGroup Element (MSBuild) , /platform


