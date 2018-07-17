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

  File:      OPForm.cs

  Summary:   .NET Client App for JITA/Object Pooling Demo

=====================================================================*/

using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.EnterpriseServices;

namespace Microsoft.Samples.Technologies.ComponentServices.ObjectPooling
{
    public class OPForm : Form
    {
        private Button startWrite;
        private Button stopWrite;
        private Label label;
        private Timer timer;
        private bool flag = false;

        public OPForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.startWrite = new Button();
            this.stopWrite = new Button();
            this.label  = new Label();

            startWrite.Location = new System.Drawing.Point(24, 40);
            startWrite.Size = new System.Drawing.Size(96, 24);
            startWrite.TabIndex = 1;
            startWrite.Text = "Start Writing";
            startWrite.Click += new System.EventHandler(this.Start_Click);

            stopWrite.Location = new System.Drawing.Point(24, 70);
            stopWrite.Size = new System.Drawing.Size(96, 24);
            stopWrite.TabIndex = 1;
            stopWrite.Text = "Stop Writing";
            stopWrite.Click += new EventHandler(this.Stop_Click);
            stopWrite.Enabled = false;

            label.Location = new System.Drawing.Point (140, 60);
            label.Size = new System.Drawing.Size (96, 24);
            label.TabIndex = 1;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler (this.OnTick);

            this.Text = "JIT/Object Pooling Demo";
            this.AutoScaleDimensions = new SizeF (5, 13);
            this.ClientSize = new System.Drawing.Size (240, 170);
            this.Controls.Add (this.stopWrite);
            this.Controls.Add (this.startWrite);
            this.Controls.Add (this.label);
        }
       

        private void Start_Click (object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            try
            {
                // enable our timer
                timer.Start();

                // set our buttons to their startup condition
                stopWrite.Enabled = true;
                startWrite.Enabled = false;
            
            } 
            catch (Exception ex) 
            {
                if (null != timer)
                    timer.Stop();

                MessageBox.Show("PooledLogFile creation generated an exception : "+ex.Message);
                this.Cursor = Cursors.Arrow;
            }

        }


        private void Stop_Click (object sender, System.EventArgs e)
        {
            // reset button state
            stopWrite.Enabled = false;
            startWrite.Enabled = true;
        
            //disable timer
            if (null != timer)
                timer.Stop();

            this.Cursor = Cursors.Arrow;

            // reset UI activity indicator
            label.Text = "";
        }


        private void OnTick(object sender, System.EventArgs e)
        {
            // On calling this method, COM+ will activate an object
            // (just in time) from the object pool when one is
            // available and we will call into it. On return from the
            // call, COM+ will deactivate the object and query it
            // to see whether it can be returned to the pool
        
            try 
            {
                // The 'using' construct below results in a call to Dispose on exiting the 
                // curly braces. It could be replaced with an explicit call to Object.Dispose
                // This is a C#-specific construct.
                //
                // It is important to dispose COM+ objects as soon as possible so that
                // COM+ metadata such as context does not remain in memory unnecessarily
                // and so that COM+ services such as Object Pooling work properly.
                using(PooledLogFile log = new PooledLogFile())
                {
                    log.Write("Hello! from Process : " + 
                        Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture));
                }
                // our high-powered UI for indicating activity
                if (flag == true) 
                {
                    label.Text = "Writing :";
                } 
                else 
                {
                    label.Text = "Writing : ***";
                }
                flag = !flag;
            }
            catch (Exception ex)
            {
                if (null != timer)
                    timer.Stop();

                MessageBox.Show("An exception was caught: "+ex.Message, "Error");

                label.Text = "Error!";
                this.Cursor = Cursors.Arrow;
            }
        }
 

        [STAThread]
        public static void Main(string[] args) 
        {
            Application.Run(new OPForm());
        }
    }
}