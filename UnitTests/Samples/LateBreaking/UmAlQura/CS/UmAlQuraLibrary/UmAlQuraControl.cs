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

using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;
namespace Microsoft.Samples.UmAlQuraLibrary
{
	public partial class UmAlQuraControl
	{
		public UmAlQuraControl()
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		private static System.Globalization.UmAlQuraCalendar UmAlQuraInstance = new System.Globalization.UmAlQuraCalendar();
		private int m_selectedMonth, m_selectedYear, m_selectedDay;
		// GetDayAndWeek: returns the day number and week number for the selected Month and Year and the given Date.
		private void GetDayAndWeek(int Date, ref int Day, ref int Week)
		{
			Day = GetDayNumber(Date);
			int FirstDayInMonth = GetDayNumber(1);
			int Temp = 0; 
			Temp = Date - (7 - FirstDayInMonth);
			if (Temp <= 0)
				Week = 1;
			else
				Week = (Temp/7) + 2;
			if (Week > 5)
			    Week = 5;
		}
		private void DayNo_Click(object sender, System.EventArgs e)
		{
			int day = 0;
			int week = 0;
			Label selectedLabel = ((Label)(sender));
			String selectedLabelText = selectedLabel.Text;
			if (selectedLabelText.Length > 0)
			{
				GetDayAndWeek(m_selectedDay, ref day, ref week);
				Label previousLabel = (Label)tableLayoutPanel1.GetControlFromPosition(day, week);
				int index = selectedLabelText.IndexOf("/");
				if (index>-1)
					selectedLabelText = selectedLabelText.Remove(index, selectedLabelText.Length-index);
				try
				{
					m_selectedDay = int.Parse(selectedLabelText, System.Threading.Thread.CurrentThread.CurrentUICulture);
				}
				catch 
				{
					m_selectedDay = 10;
				}
				//deselects the currently selected cell
				previousLabel.ForeColor = Color.Black;
				previousLabel.BackColor = Color.White;
				previousLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
				//selects the desired cell
				selectedLabel.ForeColor = Color.White;
				selectedLabel.BackColor = Color.Blue;
				selectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				Titles();
			}
		}
		private void Painter()
		{
			this.tableLayoutPanel1.SuspendLayout();
			// This loops to clear the selected text
			Label selectedLabel = new Label();
			for (int i = 1; i <= 5; i++)
			{
				for (int j = 0; j <= 6; j++)
				{
					//each cell containing a date in the calendar is set to it's default settings
					selectedLabel = (Label)tableLayoutPanel1.GetControlFromPosition(j, i);
					selectedLabel.Text = selectedLabel.Text.Remove(0, selectedLabel.Text.Length);
					selectedLabel.ForeColor = Color.Black;
					selectedLabel.BackColor = Color.White;
					selectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
				}
			}
			WriteDates();
			Titles();
			int Day = 0;
			int Week = 0;
			//Highlight the selected date
			GetDayAndWeek(m_selectedDay, ref Day, ref Week);
			selectedLabel = (Label)tableLayoutPanel1.GetControlFromPosition(Day, Week);
			selectedLabel.ForeColor = Color.White;
			selectedLabel.BackColor = Color.Blue;
			selectedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
		}
		private void WriteDates()
		{
			//the day value is used to write the dates on the calendar, the init value is used to tell us where 
			//to start in the calendar
			int day = 1;
			int init = GetDayNumber(1);
			for (int i = init; i <= 6; i++)
			{
				//writes out the dates in the first row starting from the correct position
				tableLayoutPanel1.GetControlFromPosition(i, 1).Text = day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture);
				day += 1;
			}
			int daysInMonth;
			try
			{
				daysInMonth = UmAlQuraInstance.GetDaysInMonth(m_selectedYear, m_selectedMonth);
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
				return;
			}
			for (int i = 2; i <= 5; i++)
			{
				for (int j = 0; j <= 6; j++)
				{
					//writes out the remaining dates in the calendar watching out for the number of day in the month*/
					if (day <= daysInMonth)
					{
						tableLayoutPanel1.GetControlFromPosition(j, i).Text = day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture);
						day ++;
					}
				}
			}
			// There is an extra day we need to write
			init = 0;
			string previousDay;
			while (daysInMonth >= day) 
			{
				previousDay = tableLayoutPanel1.GetControlFromPosition(init, 5).Text;
				tableLayoutPanel1.GetControlFromPosition(init, 5).Text = previousDay + "/" + day.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture);
				day++;
				init++;
			}
		}

		public int GetDayNumber(int Day)
		{
			try
			{
				switch (UmAlQuraInstance.GetDayOfWeek(new System.DateTime(m_selectedYear, m_selectedMonth, Day, UmAlQuraInstance)))
				{
					case DayOfWeek.Saturday:
						return 0;
					case DayOfWeek.Sunday:
						return 1;
					case DayOfWeek.Monday:
						return 2;
					case DayOfWeek.Tuesday:
						return 3;
					case DayOfWeek.Wednesday:
						return 4;
					case DayOfWeek.Thursday:
						return 5;
					case DayOfWeek.Friday:
						return 6;
				}
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
			return 0;
		}
		private void Titles()
		{
			//creates a DateTimeFormatInfo object to get the names of the months then use it in the labels above and
			//below the calendar, after which the label at the top is relocated to centre it in the panel
			try
			{
				System.Globalization.DateTimeFormatInfo dtf = new System.Globalization.CultureInfo("ar-sa", false).DateTimeFormat;
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UmAlQuraControl));
				FooterLabel.Text = (resources.GetString("TodayName") + m_selectedDay.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture) + " " + dtf.GetMonthName(m_selectedMonth) + ", " + m_selectedYear.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture));
				HeaderLabel.Text = (dtf.GetMonthName(m_selectedMonth) + ", " + m_selectedYear.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture));
				HeaderLabel.Location = (new Point((this.HeaderPanel.Width / 2) - (HeaderLabel.Width / 2), 3));
				tableLayoutPanel1.ResumeLayout();
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void UmAlQuraCalendar_Load(object sender, System.EventArgs e)
		{
			try
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UmAlQuraControl));
				//created a DateTimeFormatInfo object to retrieve the names of the days and applied
				System.Globalization.DateTimeFormatInfo dtf = new CultureInfo("ar-SA").DateTimeFormat;
				Daylabel1.Text = (dtf.GetDayName(System.DayOfWeek.Saturday));
				Daylabel2.Text = (dtf.GetDayName(System.DayOfWeek.Sunday));
				Daylabel3.Text = (dtf.GetDayName(System.DayOfWeek.Monday));
				Daylabel4.Text = (dtf.GetDayName(System.DayOfWeek.Tuesday));
				Daylabel5.Text = (dtf.GetDayName(System.DayOfWeek.Wednesday));
				Daylabel6.Text = (dtf.GetDayName(System.DayOfWeek.Thursday));
				Daylabel7.Text = (dtf.GetDayName(System.DayOfWeek.Friday));
				Painter();
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void BackButton_Click(object sender, System.EventArgs e)
		{
			//if condition checks whehter increasing the month takes it into the next year and acts accordingly
			try
			{
				if (m_selectedMonth == UmAlQuraInstance.GetMonthsInYear(m_selectedYear))
				{
					m_selectedYear += 1;
					m_selectedMonth = 1;
				}
				else
				{
					m_selectedMonth += 1;
				}
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
			try
			{
				if (m_selectedDay == 30 && UmAlQuraInstance.GetDaysInMonth(m_selectedYear, m_selectedMonth)<30)
				{
					m_selectedDay = 29;
				}
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
			Painter();
		}

		private void FrontButton_Click(object sender, System.EventArgs e)
		{

			if (m_selectedMonth == 1)
			{
				m_selectedYear -= 1;
				try
				{
					m_selectedMonth = UmAlQuraInstance.GetMonthsInYear(m_selectedYear);
				}
				catch (ArgumentException exception)
				{
					MessageBox.Show(exception.Message);					
				}
			}
			else
			{
				m_selectedMonth -= 1;
			}
			try
			{
				if (m_selectedDay == 30 && UmAlQuraInstance.GetDaysInMonth(m_selectedYear, m_selectedMonth) < 30)
				{
					m_selectedDay = 29;
				}
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
			Painter();
		}
		[Description("Set or get the calendar day"), Category("Data")]
		public int Day
		{
			get
			{
				if (m_selectedDay == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
						m_selectedDay = 1;
					}
				}
				return m_selectedDay;
			}
			set 
			{
				if (m_selectedDay == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
					}
				}
				if (value <= UmAlQuraInstance.GetDaysInMonth(m_selectedYear, m_selectedMonth) && value > 0)
				{
					m_selectedDay = value;
					Painter();
				}
				else
				{
					throw new ArgumentException("Days has to be between 1 and " + UmAlQuraInstance.GetDaysInMonth(m_selectedYear, m_selectedMonth).ToString(System.Threading.Thread.CurrentThread.CurrentUICulture));
				}
			}
		}
		[Description("Set or get the calendar month"), Category("Data")]
		public int Month
		{
			get
			{
				if (m_selectedMonth == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
					}				
				}
				return m_selectedMonth;
			}
			set
			{
				if (m_selectedMonth == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
					}
				}
				if (value < 13 && value > 0)
				{
					m_selectedMonth = value;
					Painter();
				}
				else
				{
					throw new ArgumentException("Months has to be between 1 and 12");
				}
			}
		}
		[Description("Set or get the calendar year"), Category("Data")]
		public int Year
		{
			get
			{
				if (m_selectedYear == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
					}
				}
				return m_selectedYear;
			}
			set
			{
				if (m_selectedYear == 0)
				{
					try
					{
						m_selectedMonth = UmAlQuraInstance.GetMonth(System.DateTime.Now);
						m_selectedYear = UmAlQuraInstance.GetYear(System.DateTime.Now);
						m_selectedDay = UmAlQuraInstance.GetDayOfMonth(System.DateTime.Now);
					}
					catch (ArgumentException exception)
					{
						MessageBox.Show(exception.Message);
					}
				}
				try
				{
									CultureInfo cc = new CultureInfo("ar-SA");
				cc.DateTimeFormat.Calendar = UmAlQuraInstance;
				DateTime dt = new DateTime(value, 1, 1, UmAlQuraInstance);
				if (dt.Year <= UmAlQuraInstance.MaxSupportedDateTime.Year && dt.Year >= UmAlQuraInstance.MinSupportedDateTime.Year)
				{
					m_selectedYear = value;
					Painter();
				}
				else
				{
					throw new ArgumentException("Years has to be between " + UmAlQuraInstance.MinSupportedDateTime.Year.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture) + " and " + UmAlQuraInstance.MaxSupportedDateTime.Year.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture));
				}
				}
				catch (ArgumentException exception)
				{
					MessageBox.Show(exception.Message);			
				}
			}
		}
	}
}
