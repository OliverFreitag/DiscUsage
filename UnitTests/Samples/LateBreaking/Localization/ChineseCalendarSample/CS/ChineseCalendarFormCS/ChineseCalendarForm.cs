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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Security.Permissions;
using System.Globalization;
using Microsoft.Samples.ChineseCalendarCS;

[assembly: CLSCompliant(true)]
[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum,
Assertion = true)]
namespace Microsoft.Samples.ChineseCalendarCS
{
	public partial class ChineseCalendarForm : Form
	{


		private ChineseLunarCalendar Calendar = new ChineseLunarCalendar();
		public ChineseCalendarForm()
		{
			InitializeComponent();

		}



		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
			DateTime selectedDate = e.End;
			try
			{
				textBoxDate.Text = String.Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}"
					, Calendar.GetYear(selectedDate), Calendar.GetMonth(selectedDate)
					, Calendar.GetDayOfMonth(selectedDate));


				textBoxYear.Text = Calendar.GetChineseSexagenaryYear(selectedDate);

				textBoxZodiac.Text = Calendar.GetChineseZodiac(selectedDate);

				string strTermName = Calendar.GetSolarTerms(selectedDate);
				if (string.IsNullOrEmpty(strTermName))
				{
					textBoxTerm.Visible = label4.Visible = false;
				}
				else
				{
					textBoxTerm.Visible = label4.Visible = true;
					textBoxTerm.Text = strTermName;
				}
				if (selectedDate >= new DateTime(2020, 12, 21))
				{
					textBoxNextTerm.Visible = label5.Visible = false;
				}
				else
				{
					textBoxNextTerm.Visible = label5.Visible = true;
					string NextTermInfo;
					if (Thread.CurrentThread.CurrentUICulture.Equals(new CultureInfo("zh-TW")))
					{
						NextTermInfo = string.Format(
					   CultureInfo.CurrentCulture,
					   "{0}({1})", Calendar.GetSolarTerms(Calendar.GetNextTermDate(selectedDate)),
					   Calendar.GetNextTermDate(selectedDate).GetDateTimeFormats('D', new CultureInfo("zh-CN"))[2]);

					}
					else
					{
						NextTermInfo = string.Format(
						   CultureInfo.CurrentCulture,
						   "{0}({1})", Calendar.GetSolarTerms(Calendar.GetNextTermDate(selectedDate)),
						   Calendar.GetNextTermDate(selectedDate).GetDateTimeFormats('D', Thread.CurrentThread.CurrentUICulture)[2]);
					}
					textBoxNextTerm.Text = NextTermInfo;
					
				}

			}
			catch (ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation
									, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

			}
			catch (InvalidCastException ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation
									, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
			}
		}




	}
}