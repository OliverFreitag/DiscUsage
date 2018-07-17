//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
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
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Microsoft.Samples.TimeZoneConvertCS
{
	partial class TZConv : Form
	{
		public TZConv()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TZConv_Load(object sender, EventArgs e)
		{
			
			TimeZoneList tzs = new TimeZoneList();

			int i;

			for (i=1; i < tzs.Count; i++)
            {
				this.cmbDestTZ.Items.Add(tzs[i]);
			}
            this.txtSourceDate.Text = DateTime.Now.ToString(Thread.CurrentThread.CurrentCulture);
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
            // Check if the target TimeZone was selected
            if (this.cmbDestTZ.SelectedItem == null)
                MessageBox.Show("Please select a target timezone", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
            else 
			    DoConvert();
		}

		private void DoConvert()
		{
			DateTime d, UTCd;
            try 
            {
                d = DateTime.Parse(txtSourceDate.Text, Thread.CurrentThread.CurrentCulture);
            }
			catch (FormatException Ex) 
            {
                MessageBox.Show(Ex.Message + " - Please enter a valid date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
			    return;
            }

            // get the UTC date/time equivalent to the SourceDate 
            UTCd = d.ToUniversalTime();
            this.lblUTCDate.Text = UTCd.ToString(Thread.CurrentThread.CurrentCulture);

			// get the Destination Bias (number of minutes from UTC)
			int DestBias;
			DestBias = ((TimeZone)this.cmbDestTZ.SelectedItem).Bias;

			// Add the Destination Bias to the UTC date/time
            this.lblDestDate.Text = UTCd.AddMinutes(DestBias).ToString(Thread.CurrentThread.CurrentCulture);
        }
	}
}