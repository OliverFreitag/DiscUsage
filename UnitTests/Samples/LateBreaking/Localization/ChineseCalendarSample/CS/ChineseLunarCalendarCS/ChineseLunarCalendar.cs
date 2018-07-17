
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Security.Permissions;

[assembly: CLSCompliant(true)]
[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum,
Assertion = true)]
namespace Microsoft.Samples.ChineseCalendarCS
{
	
	public class ChineseLunarCalendar : System.Globalization.ChineseLunisolarCalendar
	{
		// Summary:
		// Initializes a new instance of the
		// ChineseLunarCalendar class.
		public ChineseLunarCalendar()
		{
		}


		/// <summary>
		/// Get the right solar term by passing one valid datetime parameter.
		/// </summary>
		/// <param name="selectedDate">Datetime value</param>
		/// <returns>Chinese name of solar term</returns>
		public string GetSolarTerms(DateTime selectedDate)
		{
			if (selectedDate > MAX_YEAR ||selectedDate<MIN_YEAR)
			{
				throw new ArgumentOutOfRangeException(rmStrings.GetString("ExceptionName"),
					rmStrings.GetString("OutOfRangeException"));
			}
			if (selectedDate==BLANK_YEAR)
			{
				return "";
			}
			int solarTermIndex = GetTermIndex(selectedDate);
			if (solarTermIndex < 0)
				return "";
			string solarTermsFromRes = rmStrings.GetString("SolarTerms");
			string[] solarTermsArray = solarTermsFromRes.Split(',');
			return solarTermsArray[solarTermIndex];

		}
		/// <summary>
		/// Get the index in solar term list by passing 
		/// </summary>
		/// <param name="time">Current datetime</param>
		/// <returns>Index of "LunarHolDayName"</returns>
		private int GetTermIndex(DateTime time)
		{
			int iMonth, iDay,isFirst;
			isFirst = 0;
			
			iMonth = time.Month;
			iDay = time.Day;
			if (iDay<15)
			{
				isFirst = 1;
			}
			//Compare current day with real solar term day.If current date is valid solar term,
			//return the according index in "LunarHolDayName" array.
			if (iDay == GetTermDate(time))
			{
				return (iMonth) * 2 - isFirst - 1;

			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// Get term day of current month from data table.
		/// </summary>
		/// <param name="time">DateTime type</param>
		/// <returns>Day of term</returns>
		private int GetTermDate(DateTime time)
		{
			byte Offset;
			int iYear, iMonth, iDay, TermDay, isFirst;
			isFirst = 0;
			iYear = time.Year;
			iMonth = time.Month;
			iDay = time.Day;

			try
			{
				//Get the according offset in static data table.
				Offset = SolarTermData[iYear - MIN_YEAR.Year][(iMonth - 1) / 2];

				//According to the day of month to separate one bit to 
				//four pieces to indicate the right offset. 
				if (iMonth % 2 != 0)
				{
					if (iDay < 15)
					{
						Offset = (byte)(Offset >> 6);
						isFirst = 1;
					}
					else
						Offset = (byte)((byte)(Offset & 0x3F) >> 4);
				}
				else
				{
					if (iDay < 15)
					{
						Offset = (byte)((byte)(Offset & 0xC) >> 2);
						isFirst = 1;
					}
					else
					{
						Offset = (byte)(Offset & 0x3);
					}
				}
				//From baseday and offset,get the real solar term day.
				if (isFirst == 1)
				{
					TermDay = BaseDay[(iMonth - 1) * 2] + Offset;
				}
				else
				{
					TermDay = BaseDay[(iMonth - 1) * 2 + 1] + Offset;
				}
			}

			catch (InvalidCastException)
			{
				throw new InvalidCastException(rmStrings.GetString("CastError"));
			}
			return TermDay;
			

		}
		/// <summary>
		/// Return the datetime of next term according to the current datetime.
		/// </summary>
		/// <param name="time">Current datetime</param>
		/// <returns>The datetime of next term</returns>
		public DateTime GetNextTermDate(DateTime time)
		{
			if (time>MAX_YEAR||time<MIN_YEAR)
			{
				throw new ArgumentOutOfRangeException(rmStrings.GetString("ExceptionName"), 
					rmStrings.GetString("OutOfRangeException"));
			}
			else if (time>new DateTime(2020,12,21))
			{
				return BLANK_YEAR;			//Return the invalid datetime
			}			
			int CurrentTermDay, iDay;
			iDay = time.Day;
			CurrentTermDay = GetTermDate(time);
			
			if (iDay < CurrentTermDay)
			{				
				return time.AddDays(CurrentTermDay - iDay);
			}
			else
			{				
				if (iDay>15)
				{					
					//Cacluate the next term of next month.
					DateTime nextMonthTermDate = new DateTime(time.Year, time.Month,
						GetTermDate(time.AddDays(14)));
					return nextMonthTermDate.AddMonths(1);
				}
				else
				{
					return new DateTime(time.Year, time.Month,
						GetTermDate(time.AddDays(15))); 
				}
				
			}
		}
		/// <summary>
		/// Get the Chinese Sexagenay Year name.
		/// Lunisolar calendars for other East Asian regions with similar functionality
		/// are also available and this sample can be adapted for them. 
		/// Please check the documentation or local websites for more information. 
		/// </summary>
		/// <param name="time">DateTime value</param>
		/// <returns>Sexagenary Year name</returns>
		public string GetChineseSexagenaryYear(DateTime time)
		{
			int intSexagenary = base.GetSexagenaryYear(time);
			int indexOfCelestial = base.GetCelestialStem(intSexagenary);
			int indexOfTerrestrial = base.GetTerrestrialBranch(intSexagenary);

			string celestialStemFromRes = rmStrings.GetString("CelestialStem");
			string terrestrialBranchFromRes = rmStrings.GetString("TerrestrialBranch");
			string[] celestialStem = celestialStemFromRes.Split(',');
			string[] terrestrialBranch = terrestrialBranchFromRes.Split(',');
			return celestialStem[indexOfCelestial - 1] + terrestrialBranch[indexOfTerrestrial - 1];
		}
		/// <summary>
		/// Get the ChineseZodiac name.
		/// </summary>
		/// <param name="time">DateTime value</param>
		/// <returns>Chinese Zodiac name</returns>
		public string GetChineseZodiac(DateTime time)
		{
			int intSexagenary = base.GetSexagenaryYear(time);
			int indexOfTerrestrial = base.GetTerrestrialBranch(intSexagenary);
			string zodiacFromRes = rmStrings.GetString("ChineseZodiac");
			string[] zodiacArray = zodiacFromRes.Split(',');
			return zodiacArray[indexOfTerrestrial - 1];
		}

		//Define the Max and Min supported date.
		private readonly DateTime MAX_YEAR = new DateTime(2020, 12, 31);
		private readonly DateTime MIN_YEAR = new DateTime(2000, 1, 1);
		private readonly DateTime BLANK_YEAR = new DateTime(1,1,1);

		//The minimum solar term day of every month,two digitals every month.
		private readonly int[] BaseDay = new int[24] {
				5,19,//1
				3,18,//2
				5,20,//3
				4,19,//4
				5,20,//5
				5,20,//6
				6,22,//7
				7,22,//8
				7,22,//9
				7,22,//10
				7,21,//11
				6,21 //12
		};

		//Manager to manage the local string resources.
		private ResourceManager rmStrings = new ResourceManager("ChineseLunarCalendarCS.Strings", Assembly.GetExecutingAssembly());

		//Stored 21X6 size matrix to record solar term offset every month from 2000-1-1 to 2020-12-31
		//Every bit represents two months or four solar terms offsets.
		private readonly byte[][] SolarTermData = {
			new byte[]{0x65,0x01,0x11,0x41,0x15,0x14},
			new byte[]{0x14,0x05,0x11,0x51,0x15,0x15},
			new byte[]{0x15,0x55,0x55,0x55,0x55,0x15},
			new byte[]{0x55,0x55,0x56,0x55,0x5A,0x65},
			new byte[]{0x65,0x01,0x11,0x41,0x15,0x14},
			new byte[]{0x14,0x05,0x11,0x51,0x15,0x15},
			new byte[]{0x15,0x55,0x15,0x51,0x55,0x15},
			new byte[]{0x55,0x55,0x56,0x55,0x5A,0x65},
			new byte[]{0x65,0x01,0x11,0x41,0x05,0x14},
			new byte[]{0x14,0x01,0x11,0x51,0x15,0x15},
			new byte[]{0x15,0x55,0x15,0x51,0x55,0x15},
			new byte[]{0x55,0x55,0x56,0x55,0x56,0x65},
			new byte[]{0x65,0x01,0x01,0x41,0x05,0x14},
			new byte[]{0x14,0x01,0x11,0x41,0x15,0x15},
			new byte[]{0x15,0x55,0x15,0x51,0x55,0x15},
			new byte[]{0x55,0x55,0x56,0x55,0x56,0x55},
			new byte[]{0x55,0x00,0x01,0x41,0x05,0x14},
			new byte[]{0x10,0x01,0x11,0x41,0x15,0x15},
			new byte[]{0x15,0x15,0x15,0x51,0x55,0x15},
			new byte[]{0x15,0x55,0x55,0x55,0x56,0x55},
			new byte[]{0x55,0x00,0x01,0x00,0x05,0x14} };
			
			
	}		
}
