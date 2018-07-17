ChannelAuthorizationModule
==========================
     The Channel Authorization Module samples shows how to construct a TcpChannel authorization module to allow or deny incoming .NET Remoting connections based on IPEndPoints or client identity.  The IAuthorizeRemotingConnection interface is used to inspect the incoming requests and allow or deny the connection.  EndPoint authorization is available on all tcp channel requests.  Identity authorization is only supported for a secure connection.  The sample shows how to ACL a resource for a configuration file and use the ACL'd resource to control access.


Sample Language Implementations
===============================
     This sample is available in the following language implementations:
     C#


To build the sample using the command prompt:
=============================================
     1. Open the Command Prompt window and navigate to the Technologies\Remoting\Advanced\ChannelAuthorizationModule directory.
     2. Type msbuild [Solution Filename].


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to the Technologies\Remoting\Advanced\ChannelAuthorizationModule directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The application will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Navigate to the directory that contains the new "Server.exe" executable, using the command prompt or Windows Explorer.
     2. Type [ExecutableFile] at the command line, or double-click the icon for [SampleExecutable] to launch it from Windows Explorer.
     3. Navigate to the directory that contains the new "Client.exe" executable, using the command prompt or Windows Explorer.
     4. Type [ExecutableFile] at the command line, or double-click the icon for [SampleExecutable] to launch it from Windows Explorer.