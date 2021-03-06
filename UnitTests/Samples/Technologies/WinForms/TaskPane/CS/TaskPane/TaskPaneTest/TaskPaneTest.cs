//=====================================================================
//  File:      TaskPaneTest.cs
//
//  Summary:   This provides a lot of the advanced design time 
//             functionality desired/seen in our TaskPane control.
//
//---------------------------------------------------------------------
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
//---------------------------------------------------------------------

using Microsoft.Samples.Windows.Forms.TaskPane;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace Microsoft.Samples.Windows.Forms.TaskPaneTest
{
    public partial class TaskPaneTest : System.Windows.Forms.Form
    {
        //=------------------------------------------------------------------=
        // addAndRemoveButton_Click
        //=------------------------------------------------------------------=
        /// <summary>
        ///   In this function, we will add, remove and reorder frames from
        ///   the TaskPane control, so you can see how it's done.  Basically,
        ///   it's just a collection like any other control with a collection
        ///   of controls hanging off it.  We will show you a few different
        ///   ways to do this.
        /// </summary>
        /// 
        private void addAndRemoveButton_Click
        (
            System.Object sender,
            System.EventArgs e
        )
        {
            TaskFrame tf;

            //
            // first, we'll go and create a new TaskFrame control to add to
            // our parent TaskPane.  This isn't terribly difficult, and
            // mirrors closely what is done in the code generated by the
            // Forms Designer.
            //
            tf = new TaskFrame();
            tf.BackColor = Color.Blue;
            tf.CollapseButtonVisible = true;
            tf.Text = "Newly Added Frame";

            // Add it to the parent .  You could also use the code:
            // Me.TaskPane1.Controls.Add(tf)
            //
            this.TaskPane1.TaskFrames.Add(tf);

            //
            // now, let's go and delete one of the frames that we don't want
            //
            this.TaskPane1.TaskFrames.Remove(this.TaskFrame0);

            //
            // Did you notice in the designer that there was a hidden
            // TaskFrame there with its Visible property set to False?
            // It still shows up in the Designer, but not at runtime until
            // its Visible property is set to True ...
            //
            this.hiddenTaskFrame.Visible = true;

            //
            // okay, let's go and add TaskFrame0 back, but this time at the
            // end of the list of frames ...
            //
            this.TaskPane1.Controls.Add(this.TaskFrame0);
        }



        //=------------------------------------------------------------------=
        // expandAndCollapseFramesButton_Click
        //=------------------------------------------------------------------=
        /// <summary>
        ///    We'll do a little bit now with expanding and collapsing frames.
        ///   There's not too much in the way of excitement here, but it does
        ///   show that this can all be manipulated programmatically if you so 
        ///   desire. 
        /// </summary>
        /// 
        private void expandAndCollapseFramesButton_Click
        (
            System.Object sender,
            System.EventArgs e
        )
        {
            // Toggle IsExpanded for known TaskFrames
            // Note: TaskFrames created by clicking 'Add, Remove and Reorder' not included.

            this.TaskFrame0.IsExpanded = !this.TaskFrame0.IsExpanded;
            this.TaskFrame1.IsExpanded = !this.TaskFrame1.IsExpanded;
            this.TaskFrame2.IsExpanded = !this.TaskFrame2.IsExpanded;
            if (this.hiddenTaskFrame.Visible)
                this.hiddenTaskFrame.IsExpanded = !this.hiddenTaskFrame.IsExpanded;
        }


        //=------------------------------------------------------------------=
        // sysDefCornerStyleRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes the corner style on the captionbar
        /// </summary>
        /// 
        private void sysDefCornerStyleRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.CornerStyle = TaskFrameCornerStyle.SystemDefault;
        }

        //=------------------------------------------------------------------=
        // roundedCornerStyleRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes the corner style on the captionbar
        /// </summary>
        /// 
        private void roundedCornerStyleRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.CornerStyle = TaskFrameCornerStyle.Rounded;
        }

        //=------------------------------------------------------------------=
        // squaredCornerStyleRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes the corner style on the captionbar
        /// </summary>
        /// 
        private void squaredCornerStyleRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.CornerStyle = TaskFrameCornerStyle.Squared;
        }

        //=------------------------------------------------------------------=
        // leftDockRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes where the task pane is docked.
        /// </summary>
        /// 
        private void leftDockRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.Dock = DockStyle.Left;
            this.testPanel.Dock = DockStyle.Fill;
        }

        //=------------------------------------------------------------------=
        // topDockRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes where the task pane is docked.
        /// </summary>
        /// 
        private void topDockRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.Height = 150;
            this.TaskPane1.Dock = DockStyle.Top;
            this.testPanel.Dock = DockStyle.Fill;

        }

        //=------------------------------------------------------------------=
        // bottomDockRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes where the task pane is docked.
        /// </summary>
        /// 
        private void bottomDockRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.Height = 150;
            this.TaskPane1.Dock = DockStyle.Bottom;
            this.testPanel.Dock = DockStyle.Fill;
        }

        //=------------------------------------------------------------------=
        // rightDockRadio_CheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Changes where the task pane is docked.
        /// </summary>
        /// 
        private void rightDockRadio_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            this.TaskPane1.Dock = DockStyle.Right;
            this.testPanel.Dock = DockStyle.Fill;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link Clicked");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link Clicked");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link Clicked");

        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link Clicked");

        }

    }
}
