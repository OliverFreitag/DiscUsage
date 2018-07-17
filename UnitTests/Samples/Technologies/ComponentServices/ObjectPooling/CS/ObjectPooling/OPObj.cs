//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//
/*=====================================================================

  File:      OPObj.cs

  Summary:   OP Demo Pooled Object Code

=====================================================================*/

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.EnterpriseServices;


// the ApplicationName attribute specifies the name of the
// COM+ Application which will hold assembly components
[assembly: ApplicationName("OPDemoSvr")]

//Setting the ApplicationAccessControl Attribute to false switches off
//role based security, a real app should turn it in, and configure roles.
[assembly: ApplicationAccessControl(false)]

// the ApplicationActivation.ActivationOption attribute specifies 
// where assembly components are loaded on activation
// Library : components run in the creator's process
// Server : components run in a system process, dllhost.exe
[assembly: ApplicationActivation(ActivationOption.Server)]

namespace Microsoft.Samples.Technologies.ComponentServices.ObjectPooling
{
    [ComVisible(true)]
    public interface IPooledLogFile
    {
        void Write(string message);
    }
    // We use the ObjectPooling attribute to specify the default
    // minimum and maximum pool size (0 and 1 objects)
    [ObjectPooling(MinPoolSize=0, MaxPoolSize=1)]

    // JustInTimeActivation enables Just In Time 
    // Activation for the component
    [JustInTimeActivation(true)]

    // ConstructionEnabled enables object construction strings.
    // We use ours to specify a file name and (possibly) location.
    // The default file is named 'OPSvrLogCS.txt' and will be created
    // in the System32 subdirectory. See the SDK Object
    // Construction sample for more information on construction strings.
    [ConstructionEnabled(Default="OPSvrLogCS.txt")]

    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class PooledLogFile : ServicedComponent, IPooledLogFile
    {
       private StreamWriter w;

       protected override void Construct(string constructString)
       {
           // This StreamWriter constructor opens a file named in the 
           // first argument, the file is created if it does not exist.
           // The second argument indicates we permit appending.
           w = new StreamWriter(constructString, true, Encoding.Default);               

           // set the file pointer to the end
           w.BaseStream.Seek(0, SeekOrigin.End);   
       }

       // Using the AutoComplete attribute will automatically return
       // the object to the pool on return from the method. Without
       // AutoComplete, a caller is required to set the object's
       // done bit to true by calling SetComplete.
       [AutoComplete]
       public void Write (string message)
       {
           w.WriteLine("Client called PooledLogFile::Write() with message: " + message);
       } 


       // COM+ calls IObjectControl::Activate before any call 
       // into a JIT-activated object by a new caller
       protected  override void Activate()
       {
           w.WriteLine("COM+   called IObjectControl::Activate()");
       }


       // COM+ calls IObjectControl::Deactivate immediately after a
       // caller has indicated it is finished with a JIT-activated object. 
       // This might be accomplished by calling SetComplete or it 
       // might occur automatically on return from a method which 
       // has had the AutoComplete attribute applied to it.
       protected override void Deactivate()
       {
           w.WriteLine("COM+   called IObjectControl::Deactivate()");
       }


       // COM+ calls IObjectControl::CanBePooled after object 
       // deactivation to allow the object to indicate whether 
       // or not it can be returned to the pool
       protected override bool CanBePooled()
       {

           w.WriteLine("COM+   called IObjectControl::CanBePooled()");
           w.WriteLine("");

           w.Flush();  // update underlying file

           // due to simplicity of this example, we can always be
           // returned to the pool
           return true; 
       }
    }
}
