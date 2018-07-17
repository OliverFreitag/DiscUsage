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
using System.IO;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace Microsoft.Samples{

    [System.ComponentModel.Localizable(true)]
    public sealed  class CalendarNavigator : Form {
    
        private ArrayList    _calendarFormList = new ArrayList(10);
        private NotifyIcon   _notifyIcon;
        private IContainer   _components;
        private ContextMenu  _contextMenu;
        private DateTime     _today;
        private int          _calendarIndex = 0;
        private Graphics     _paintGraphics;
        private Icon         _calendarIcon;
        private LinkLabel [] _calendarLabels;
        private int          _dateHeight;
        
        private static StringFormat _stringFormat       = new StringFormat();
        private static Font         _font               = new Font("Arial",11);
        private static Color        _backColor          = Color.White;
        private static SolidBrush   _windowBrush        = new SolidBrush(_backColor);
        private static int          _dateYPos           = 50;

        [STAThread]
        public static void Main(String[] args) {
            Application.Run(new CalendarNavigator());
        }

        public CalendarNavigator() {
        
            _today          = DateTime.Today;

            Stream stream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream("CalendarNavigator.calendar.ico");
            _calendarIcon   =  new Icon(stream);
        
            _components     = new Container();
            _contextMenu    = new ContextMenu();

            CreateMenus();

            _notifyIcon              = new NotifyIcon(_components);
            _notifyIcon.Icon         = _calendarIcon;
            _notifyIcon.ContextMenu  = _contextMenu;
            _notifyIcon.Text         = "Calendars Navigator";
            _notifyIcon.Visible      = false;
            _notifyIcon.DoubleClick += new EventHandler(OnIconDoubleClick);
            _notifyIcon.MouseMove   += new MouseEventHandler(OnIconMouseMove);
            
            Icon                    = _calendarIcon;
            Text                    = "Calendar Navigator";
            BackColor               = _backColor;
            ClientSize              = new Size(400, 270);
            Resize                 += new System.EventHandler(OnResize);

            //
            // Graphics Intializing
            //
            _paintGraphics = Graphics.FromHwnd(this.Handle);

            //
            // Timer Setting
            //
            
            Timer timer = new Timer();
            timer.Tick += new EventHandler(OnTimer);
            timer.Interval = 1000;
            timer.Start();

            //
            // Labels (Hyperlinks)
            //
            
            Graphics g = Graphics.FromHwnd(Handle);
            _stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            _stringFormat.Alignment   = StringAlignment.Near;
            SizeF stringSize = g.MeasureString("W", _font, 0x100000, _stringFormat);
            _dateHeight  = (int) Math.Ceiling(stringSize.Height) + 2;
            _dateYPos = 2 * _dateHeight - 3;

            int yPos = _dateYPos;
            
            _calendarLabels = new LinkLabel[CalendarStatics.CalendarsInfo.Length];
            for (int i=0; i<CalendarStatics.CalendarsInfo.Length; i++) {
            
                string s = GetTodayDate(i);
            
                _calendarLabels[i] = new LinkLabel();

                _calendarLabels[i].Font                 = _font;
                _calendarLabels[i].Location             = new Point(1, yPos);
                _calendarLabels[i].Size                 = new Size(ClientRectangle.Width - 2, _dateHeight);
                _calendarLabels[i].AutoSize             = true;
                _calendarLabels[i].DisabledLinkColor    = Color.Red;
                _calendarLabels[i].VisitedLinkColor     = Color.Blue;
                _calendarLabels[i].LinkBehavior         = LinkBehavior.HoverUnderline;
                _calendarLabels[i].LinkColor            = Color.Navy;
                _calendarLabels[i].TabIndex             = i;
                _calendarLabels[i].TabStop              = true;
                _calendarLabels[i].LinkClicked         += new LinkLabelLinkClickedEventHandler(OnHyperLink);
                _calendarLabels[i].LinkArea             = new LinkArea(0, s.Length);
                _calendarLabels[i].Links[0].Visited     = true;
                _calendarLabels[i].Text                 = s;

                if (i % 2 == 0) {
                    _calendarLabels[i].BackColor = SystemColors.Control;
                }

                Controls.Add(_calendarLabels[i]);

                yPos += _dateHeight;
            }
        }

        private void ResetDateLabels()  {
        
            for (int i=0; i<CalendarStatics.CalendarsInfo.Length; i++) {
                _calendarLabels[i].Text = GetTodayDate(i);
            }
        }

        private void OnHyperLink(object sender, LinkLabelLinkClickedEventArgs e) {
        
            LinkLabel o = sender as LinkLabel;
            for (int i=CalendarStatics.CalendarsInfo.Length-1;  i>=0; i--) {
            
                if ( String.Compare(
                            o.Text, 2,
                            CalendarStatics.CalendarsInfo[i].Name, 0,
                            CalendarStatics.CalendarsInfo[i].Name.Length, false,
                            CultureInfo.InvariantCulture) == 0) {
                            
                    CalendarFormShow(i);
                    return;
                }
            }
        }

        private string GetTodayDate(int calendarIndex) {
        
            StringBuilder stringBuilder  = new StringBuilder(150);
            _today                       = DateTime.Today;

            Calendar           calendar   = CalendarStatics.CalendarsInfo[calendarIndex].Calendar;
            DateTimeFormatInfo format     = CalendarStatics.CalendarsInfo[calendarIndex].Format;

            string calendarName = CalendarStatics.GetCalendarName(CalendarStatics.CalendarsInfo[calendarIndex].Calendar);  

            stringBuilder.Append("  ");
            stringBuilder.Append(calendarName);
            stringBuilder.Append(": ");

            if (CalendarStatics.CalendarsInfo[calendarIndex].IsCompatibleCalendar) {
                stringBuilder.Append(_today.ToString("D", format));
                stringBuilder.Append(_today.ToString(" gg", format));
            } else {
                stringBuilder.Append(calendar.GetMonth(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("/");
                stringBuilder.Append(calendar.GetDayOfMonth(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("/");
                stringBuilder.Append(calendar.GetYear(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append(" ");
                stringBuilder.Append(format.GetEraName(calendar.GetEra(_today)));
            }
            
            return stringBuilder.ToString();
        }


        private string GetTodayFromNextCalendar() {
        
            StringBuilder      stringBuilder    = new StringBuilder(150);
            Calendar           calendar         = CalendarStatics.CalendarsInfo[_calendarIndex].Calendar;
            DateTimeFormatInfo format           = CalendarStatics.CalendarsInfo[_calendarIndex].Format;
            string calendarName                 = CalendarStatics.GetCalendarName(CalendarStatics.CalendarsInfo[_calendarIndex].Calendar);  

            stringBuilder.Append("  ");
            stringBuilder.Append(calendarName);
            stringBuilder.Append(": ");
            
            if (CalendarStatics.CalendarsInfo[_calendarIndex].IsCompatibleCalendar) {
                stringBuilder.Append(_today.ToString("dd MMMM yyyy gg", format));
            } else {
                stringBuilder.Append("[");
                stringBuilder.Append(calendar.GetEra(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("] ");
                stringBuilder.Append(calendar.GetMonth(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("/");
                stringBuilder.Append(calendar.GetDayOfMonth(_today).ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("/");
                stringBuilder.Append(calendar.GetYear(_today).ToString(CultureInfo.InvariantCulture));
            }
            
            stringBuilder.Append("  ");

            _calendarIndex++;

            if (_calendarIndex >= CalendarStatics.CalendarsInfo.Length)
                _calendarIndex = 0;
            
            return stringBuilder.ToString();
        }

        protected override void Dispose( bool disposing ) {
        
            if (disposing && _components != null)
                _components.Dispose();            

            _paintGraphics.Dispose();

            base.Dispose( disposing );
        }


        public void CreateMenus() {
        
            MenuItem exitItem = new MenuItem("Exit");
            exitItem.Click += new System.EventHandler(OnExit);
            
            MenuItem[] subMenus = new MenuItem[1];
            subMenus[0] = exitItem;
            MenuItem menuFile = new MenuItem("&File", subMenus);
            MenuItem menuCalendar = new MenuItem("&Calendars", CalendarStatics.GetCalendarMenu(new System.EventHandler(OnCalendarClick)));

            MainMenu mainMenu = new MainMenu();
            mainMenu.MenuItems.Add(menuFile);
            mainMenu.MenuItems.Add(menuCalendar);
           
            Menu = mainMenu;   
            
            _contextMenu.MenuItems.AddRange(new MenuItem[] {
                                                exitItem.CloneMenu(), 
                                                new MenuItem("&Calendar", CalendarStatics.GetCalendarMenu(new System.EventHandler(OnCalendarClick)))}
                                           );
            
        }

        private void OnIconDoubleClick(object Sender, EventArgs e) {
        
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Activate();
            _notifyIcon.Visible = false;
        }

        private void OnIconMouseMove(object Sender, MouseEventArgs e) {
            _notifyIcon.Text = GetTodayFromNextCalendar();
        }

        private void CalendarFormShow(int index) {
        
            if (CalendarStatics.CalendarsInfo[index].IsCompatibleCalendar) {
                CalendarStatics.CalendarsInfo[index].Format.Calendar = CalendarStatics.CalendarsInfo[index].Calendar;
            }
                
            CalendarContainer cf = new CalendarContainer(
                                    CalendarStatics.CalendarsInfo[index].Calendar, 
                                    CalendarStatics.CalendarsInfo[index].Format, 
                                    CalendarStatics.CalendarsInfo[index].IsCompatibleCalendar);
            cf.Show();
            _calendarFormList.Add(cf);
        }

        private void OnResize(object sender, System.EventArgs e) {
        
            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                _notifyIcon.Visible = true;
            } else {
                if (_paintGraphics != null) {
                    try { }
                    finally
                    {
                        _paintGraphics.Dispose();
                    }
                }
                _paintGraphics = Graphics.FromHwnd(this.Handle);
                Invalidate();
            }
        }

        private void PaintDates(Graphics graphics, bool paintBackground) {
        
            if (graphics == null)         { return; }

            BitmapPainter painter = new BitmapPainter(graphics, ClientRectangle);
            Graphics g = painter.Graphics;
            if (g == null) return;

            _stringFormat.Alignment      = StringAlignment.Center;

            string currentDateTime = "Calendars Today's Date" + Environment.NewLine + DateTime.Now.ToString(CultureInfo.InvariantCulture);

            if (paintBackground) {
            
                SizeF stringSize = g.MeasureString(
                                        currentDateTime,
                                        _font,
                                        ClientRectangle.Width,
                                        _stringFormat);

                int x = (int) ((ClientRectangle.Width - Math.Ceiling(stringSize.Width)) / 2);
                
                g.FillRectangle(
                        _windowBrush,  
                        new Rectangle(
                            x,
                            ClientRectangle.Y,
                            x + (int) Math.Ceiling(stringSize.Width),
                            ClientRectangle.Y + (int) Math.Ceiling(stringSize.Height)));

                for (int i=0; i<CalendarStatics.CalendarsInfo.Length; i += 2) {
                    g.FillRectangle(
                            CalendarStatics.ControlBrush,  
                            new Rectangle(
                                1,
                                i * _dateHeight + _dateYPos,
                                ClientRectangle.Width - 2,
                                _dateHeight));
                        
                }
            }
            
            g.DrawString(
                    currentDateTime,
                    _font, 
                    Brushes.Black, 
                    ClientRectangle,
                    _stringFormat);

            if (_today != DateTime.Today) { 
            
                _today = DateTime.Today;
                ResetDateLabels();
            }

            painter.Flush();
        }
        
        protected override void OnPaint(PaintEventArgs e) {
        
            PaintDates(e.Graphics, false);
            base.OnPaint(e);
        }


        private void OnExit(object sender, System.EventArgs e) {

            try
            {
                foreach (object o in _calendarFormList)
                {
                    try { }
                    finally
                    {
                        ((Form)o).Close();
                    }
                }
            }
            finally
            {
                Close();
            }
        }
        
        
        private void OnTimer(Object myObject, EventArgs myEventArgs) { 
            PaintDates(_paintGraphics, true);
        }

        private void OnCalendarClick(object sender, System.EventArgs e) { 
            CalendarFormShow( (sender as MenuItem).Index ); 
        }
    }
}
