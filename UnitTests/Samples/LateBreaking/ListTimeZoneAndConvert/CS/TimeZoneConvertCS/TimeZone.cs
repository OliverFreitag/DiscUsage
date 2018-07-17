/*
---------------------------------------------------------------------
  This file is part of the Microsoft .NET Framework SDK Code Samples.
 
  Copyright (C) Microsoft Corporation.  All rights reserved.
 
This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.
 
THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
---------------------------------------------------------------------
*/
using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;


namespace Microsoft.Samples.TimeZoneConvertCS
{
    /// <summary>
    /// TimeZoneCollection
    /// implements a sorted list of TimeZones by reading the Windows Registry (there's currently no other way to do it)
    /// </summary>
    public class TimeZoneList : System.Collections.ArrayList 
    {

        public TimeZoneList()
        {
            //initialize the list
            this.Initialize();    
        }

        public TimeZone this[string name]
        {
            get
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (((TimeZone)base[i]).StandardName == name)
                    {
                        break;
                    }
                }
                if (i == this.Count)
                {
                    return null;
                }
                else
                {
                    return (TimeZone)base[i];
                }
            }

            set { base.Add(this); }
        }


        private void Initialize()
        {
            RegistryKey hKeyRoot;
           

            RegistryKey hKeyTZ;
            RegistryKey  hKey;

            TimeZone tz;

            String stTZKey;
            String[] KeySet;

            int i;
            int m_count;
          
            
            hKeyRoot = Registry.LocalMachine;
            // Hack Hack - reading the registry ...
            // first try with NT/2k/Xp key
            stTZKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Time Zones";
            hKeyTZ = hKeyRoot.OpenSubKey(stTZKey);
            if (hKeyTZ == null) 
            {
                //else try with 9x key
                stTZKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Time Zones";
                hKeyTZ = hKeyRoot.OpenSubKey(stTZKey);
                if (hKeyTZ == null) 
                {
                    Exception e = new Exception(string.Format("No <{0}> registry key found!", stTZKey));
                    throw e;
                }
            }
            
           
            //now add all subkeys
            KeySet = hKeyTZ.GetSubKeyNames();
            m_count = hKeyTZ.SubKeyCount;
            for (i = 0; i <= (m_count - 1); i++)
            {
                hKey = hKeyTZ.OpenSubKey(KeySet[i]);
                //... with some properties
                tz = new TimeZone(hKey);
                hKey.Close();

                if (i == 0)
                    base.Add(tz);
                else
                {
                    int j;
                    for (j = 0; (j < i); )
                    {
                        if (tz.Order > ((TimeZone)base[j]).Order)
                            j++;
                        else
                            break;
                    }

                    if (j >= i)
                        base.Add(tz);
                    else
                        base.Insert(j, tz);
                }
                tz = null;
            }
            
            hKeyTZ.Close();

            hKey = null;
            hKeyTZ = null;
            hKeyRoot = null;
        }


    }

    /// <summary>
    /// TimeZone
    /// exposes all properties for a TimeZone, based on the Windows Registry information
    /// </summary>
	public class TimeZone
	{
		
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        public struct REG_TIMEZONE_INFO
        {
            public Int32 Bias;
            public Int32 StandardBias;
            public Int32 DaylightBias;
            public SYSTEMTIME StardardDate;
            public SYSTEMTIME DaylightDate;
        }

        private REG_TIMEZONE_INFO m_tzi;
        private int m_Order;

        [ DllImport("KERNEL32.DLL", EntryPoint="RtlMoveMemory")]
        private static extern void RtlMoveMemory(ref REG_TIMEZONE_INFO pDest, ref byte pSource, int ByteLen); 

        // Static methods that returns the list of timezones
        public TimeZoneList GetTimeZones()
        {
            return new TimeZoneList();
        }

        // Internal constructor that initializes the TimeZone from a registry key
        public TimeZone( RegistryKey key )
        {
            m_DaylightName = key.GetValue("Dlt").ToString();
            m_StandardName = key.GetValue("Std").ToString();
            m_DisplayName = key.GetValue("Display").ToString();
            m_Order = (int)(key.GetValue("Index"));

            byte[] bytes = (byte[])key.GetValue("TZI");
            RtlMoveMemory(ref m_tzi, ref bytes[0], Marshal.SizeOf(m_tzi));
        }

        //
        // The DisplayName property 
        private string m_DisplayName;

        public string DisplayName        {
            get { return m_DisplayName; }
        }

    
        // The StandardName property 
        private string m_StandardName;

        public string StandardName        {
            get { return m_StandardName; }
        }

        // The DaylightName property 
        private string m_DaylightName;

        public string DaylightName        {
            get { return m_DaylightName; }
        }

        // The Bias property
        public int Bias         {
            get { return -m_tzi.Bias; }
        }

        // The StandardBias property
        public int StandardBias        {
            get { return -m_tzi.StandardBias; }
        }

        // The DaylightBias property
        public int DaylightBias        {
            get { return -m_tzi.DaylightBias; }
        }

        // The StandardDate property
        public SYSTEMTIME StandardDate        {
            get { return m_tzi.StardardDate; }
        }
 
        // The DaylightDate property
        public SYSTEMTIME DaylightDate        {
            get { return m_tzi.DaylightDate; }
        }

        // The Order (Index) property
        public int Order        {
            get { return m_Order; }
        }

        // overriding default Tostring to retun the DisplayName
        public override string ToString()
        {
            return m_DisplayName;
        }

	}
}
