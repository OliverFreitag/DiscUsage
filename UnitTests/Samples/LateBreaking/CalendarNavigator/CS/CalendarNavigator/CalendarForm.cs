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
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Microsoft.Samples {

    public interface ICalendarOwner {
    
        DateTime MaxMinimumDate { get; }
        DateTime MinMaximumDate { get; }
        void CloseForm(CalendarForm form);
        void Synchronize(DateTime startDate, DateTime endDate, int markedDay, CalendarForm sentBy);
        bool GetSyncedDates(ref DateTime startDate, ref DateTime endDate, ref int markedDay, CalendarForm sentBy);
        void OnMouseDown(object sender, MouseEventArgs e);
        void OnMouseUp(object sender, MouseEventArgs e);
        void OnMouseMove(object sender, MouseEventArgs e);
    }

    [System.ComponentModel.Localizable(true)]
    public sealed class CalendarContainer : Form, ICalendarOwner {
    
        private ContextMenu         _contextMenu;
        private Point               _dragPosition    = new Point(0, 0);
        private bool                _isFormMoving    = false;

        public CalendarContainer(
            Calendar            calendar, 
            DateTimeFormatInfo  dateFormatInfo,
            bool                canBeOptionalCalendar) : base() {
            
            ShowInTaskbar               = false;
            FormBorderStyle             = FormBorderStyle.None;
            ClientSize                  = new Size( CalendarStatics.ClientWidth  + 2 * CalendarStatics.Margin, 
                                                    CalendarStatics.ClientHeight + 2 * CalendarStatics.Margin);

            _contextMenu = new ContextMenu(CalendarStatics.GetCalendarMenu(new EventHandler(OnCalendarClick)));

            CalendarForm form  = new CalendarForm(this as ICalendarOwner, calendar, dateFormatInfo, canBeOptionalCalendar);
            form.Location      = new Point(CalendarStatics.Margin, CalendarStatics.Margin);
            form.ClientSize    = new Size(CalendarStatics.ClientWidth, CalendarStatics.ClientHeight);
            Controls.Add(form);
        }


        private void OnCalendarClick(object sender, EventArgs e) { 
        
            MenuItem item = sender as MenuItem;
            if (item == null) return;

            CalendarForm form  = new CalendarForm(
                                        this as ICalendarOwner, 
                                        CalendarStatics.CalendarsInfo[item.Index].Calendar, 
                                        CalendarStatics.CalendarsInfo[item.Index].Format, 
                                        CalendarStatics.CalendarsInfo[item.Index].IsCompatibleCalendar);
                                        
            form.ClientSize    = new Size(CalendarStatics.ClientWidth, CalendarStatics.ClientHeight);

            int startPosition = CalendarStatics.Margin;
            foreach (Control control in Controls) {
                CalendarForm currentForm = control as CalendarForm;
                if (currentForm != null) {
                    startPosition += CalendarStatics.ClientWidth + CalendarStatics.Gap;
                }
            }
            
            ClientSize = new Size(  startPosition + CalendarStatics.ClientWidth + CalendarStatics.Margin , 
                                    CalendarStatics.ClientHeight + 2 * CalendarStatics.Margin);

            form.Location      = new Point(startPosition, CalendarStatics.Margin);
            Controls.Add(form);

            Invalidate();
        }

        private bool IsCalendarExist(string calendarName)
        {
            foreach (Control control in Controls) {
                CalendarForm form = control as CalendarForm;
                if (form != null && form.IsSameCalendar(calendarName))
                    return true;
            }

            return false;
        }

        private void ShowContextMenu(CalendarForm form, Point position) {
        
            bool moreToShow = false;
            foreach (MenuItem item in _contextMenu.MenuItems) {
                if ( IsCalendarExist(item.Text) )
                    item.Enabled = false;
                else
                    item.Enabled = true;

                moreToShow = moreToShow || item.Enabled;
            }

            if (moreToShow) {
                _contextMenu.Show(form, position);
            }
        }

        void ICalendarOwner.OnMouseDown(object sender, MouseEventArgs e) {
        
            if (e.Button == MouseButtons.Left) { 
                _dragPosition.X = e.X;
                _dragPosition.Y = e.Y;
                _isFormMoving   = true;
            } else if (e.Button == MouseButtons.Right) {
                ShowContextMenu(sender as CalendarForm, new Point(e.X, e.Y));
            }
        }

        void ICalendarOwner.OnMouseUp(object sender, MouseEventArgs e) {
        
            if (e.Button == MouseButtons.Left) { 
                _isFormMoving = false; 
            }
        }

        void ICalendarOwner.OnMouseMove(object sender, MouseEventArgs e) {
        
            if (_isFormMoving) {
                Left += e.X - _dragPosition.X;
                Top  += e.Y - _dragPosition.Y;
            }
        }

        void ICalendarOwner.Synchronize(DateTime startDate, DateTime endDate, int markedDay, CalendarForm sentBy) {
        
            foreach (Control control in Controls) {
                CalendarForm form = control as CalendarForm;
                if (form != null && form != sentBy) {
                    if (!form.Synchronize(startDate, endDate, markedDay))
                        return;
                }
            }
        }

        bool ICalendarOwner.GetSyncedDates(ref DateTime startDate, ref DateTime endDate, ref int markedDay, CalendarForm sentBy) {
            foreach (Control control in Controls) {
                CalendarForm form = control as CalendarForm;
                if (form != null && form != sentBy) {
                    startDate   = form.StartDate;
                    endDate     = form.EndDate;
                    markedDay   = form.MarkedDay;
                    return true;
                }
            }
            return false;
        }

        DateTime ICalendarOwner.MaxMinimumDate {
        
            get {
                DateTime maxMinDate = DateTime.MinValue;

                foreach (Control control in Controls) {
                    CalendarForm form = control as CalendarForm;
                    if (form != null && maxMinDate < form.MinDate) {
                        maxMinDate = form.MinDate;
                    }
                }
                return maxMinDate;
            }
        }

        DateTime ICalendarOwner.MinMaximumDate {
            get {
                DateTime minMaxDate = DateTime.MaxValue;

                foreach (Control control in Controls) {
                    CalendarForm form = control as CalendarForm;
                    if (form != null && minMaxDate < form.MaxDate) {
                        minMaxDate = form.MaxDate;
                    }
                }
                return minMaxDate;
            }
        }

        void ICalendarOwner.CloseForm(CalendarForm form) {

            try 
            {
                Controls.Remove(form);
            } finally {
                if (Controls.Count == 0) { Close(); }
            }

            int startPosition = CalendarStatics.Margin;
            foreach (Control control in Controls) {
            
                CalendarForm currentForm = control as CalendarForm;
                if (currentForm != null) {
                    currentForm.Location = new Point(startPosition, CalendarStatics.Margin);
                    startPosition += CalendarStatics.ClientWidth + CalendarStatics.Gap;
                }
            }
            
            ClientSize = new Size(  startPosition + CalendarStatics.Margin - CalendarStatics.Gap, 
                                    CalendarStatics.ClientHeight + 2 * CalendarStatics.Margin);
            
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
        
            BitmapPainter painter = new BitmapPainter(e);
            Graphics g = painter.Graphics;

            if (g == null) return;

            //
            // Draw the client area and frames
            //
            
            Rectangle rect = ClientRectangle;

            g.DrawRectangle(CalendarStatics.DarkDarkPen, rect);
            g.FillRectangle(CalendarStatics.WindowBrush, rect);
            g.DrawRectangle(CalendarStatics.DarkDarkPen, rect);
            g.DrawRectangle(CalendarStatics.DarkPen, new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1));
            g.DrawRectangle(CalendarStatics.LightLightPen, new Rectangle(rect.Left, rect.Top, rect.Width - 2, rect.Height - 2));
            g.DrawRectangle(CalendarStatics.ControlPen, new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 3, rect.Height - 3));
            g.DrawLine(CalendarStatics.DarkPen, new Point(rect.Left + 2, rect.Top + 2), new Point(rect.Right - 5 ,rect.Top + 2));
            g.DrawLine(CalendarStatics.DarkPen, new Point(rect.Left + 2, rect.Top + 2), new Point(rect.Left + 2 ,rect.Bottom - 5));

            painter.Flush();

            base.OnPaint(e);
        }
        
    }

    [System.ComponentModel.Localizable(true)]
    public sealed class CalendarForm : Control {
    
        private DateTime            _startDate;
        private DateTime            _endDate;
        private int                 _markedDay;
        private Calendar            _hostedCalendar;
        private DateTimeFormatInfo  _formatInfo;
        private string              _calendarName;
        private ICalendarOwner      _container;
        private TextBox             _yearTextBox;
        private string []           _dayNames; 
        private bool                _canBeOptionalCalendar;
        private int                 _daysYPosition   = 1000000;
        private DateNavigator       _dateNavigator   = new DateNavigator();
        private StringFormat        _stringFormat    = new StringFormat();
        private bool                _nonNumberEntered= true;

        
        public CalendarForm(
                    ICalendarOwner      navigator, 
                    Calendar            calendar, 
                    DateTimeFormatInfo  dateFormatInfo,
                    bool                canBeOptionalCalendar) : base() {

            _hostedCalendar             = calendar;
            _formatInfo                 = dateFormatInfo;
            _container                  = navigator;
            _canBeOptionalCalendar      = canBeOptionalCalendar;
            _dayNames                   = _formatInfo.ShortestDayNames;
            _calendarName               = CalendarStatics.GetCalendarName(_hostedCalendar);

            //
            // Notifications events
            //
            MouseDown  += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            MouseUp    += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
            MouseMove  += new System.Windows.Forms.MouseEventHandler(OnMouseMove);

            //
            // Close button
            //
            
            Button closeButton      = new Button();
            closeButton.ClientSize  = new Size(15, 18);
            closeButton.Location    = new Point(CalendarStatics.ClientWidth - 20, 4);
            closeButton.Text        = "X";
            closeButton.TabStop     = false;
            closeButton.Font        = CalendarStatics.Arial825Font;
            closeButton.BackColor   = Color.Red;
            closeButton.ForeColor   = Color.White;
            closeButton.Click      += new EventHandler(OnClose);
            Controls.Add(closeButton);

            //
            // Year Label
            //
            
            Label yearLabel         = new Label();
            yearLabel.Text          = "Year/Month/Era";
            yearLabel.Location      = new Point(CalendarStatics.Margin, CalendarStatics.ClientHeight - 49);
            yearLabel.ClientSize    = new Size(83, 15);
            yearLabel.BackColor     = SystemColors.Window;
            Controls.Add(yearLabel);
            
            //
            // Year TextBox
            //
            
            _yearTextBox = new TextBox();
            _yearTextBox.MaxLength    = 9;
            _yearTextBox.Location     = new Point(CalendarStatics.Margin + 84, CalendarStatics.ClientHeight - 49);
            _yearTextBox.ClientSize   = new Size(53, 17);
            _yearTextBox.KeyDown     += new KeyEventHandler(OnKeyDown);
            _yearTextBox.KeyPress    += new KeyPressEventHandler(OnKeyPress);
            Controls.Add(_yearTextBox);

            //
            // Navigator bar
            //
            
            _dateNavigator.Location = new Point(3, CalendarStatics.ClientHeight - 27);
            _dateNavigator.Changed += new EventHandler(OnNotification);
            Controls.Add(_dateNavigator);

            if (!navigator.GetSyncedDates(ref _startDate, ref _endDate, ref _markedDay, this)) {
                GoToToday();
            } else {
                ValidateDates();
            }

            SetYearText();
        }


        public DateTime MinDate {
            get { return _hostedCalendar.MinSupportedDateTime; } 
        }
        
        public DateTime MaxDate {
            get { return _hostedCalendar.MaxSupportedDateTime; } 
        }

        internal bool IsSameCalendar(string calendarName) {
            return calendarName.Equals(_calendarName);
        }

        private void ValidateDates() {
        
            if (_startDate < _hostedCalendar.MinSupportedDateTime) {
                _startDate = _container.MaxMinimumDate;
                
                if (_startDate < _hostedCalendar.MinSupportedDateTime)
                    _startDate = _hostedCalendar.MinSupportedDateTime;
                
                int monthLength = _hostedCalendar.GetDaysInMonth(
                                        _hostedCalendar.GetYear(_startDate), 
                                        _hostedCalendar.GetMonth(_startDate),
                                        _hostedCalendar.GetEra(_startDate))-1;
                                        
                _endDate   = _startDate.AddDays(monthLength);

                _container.Synchronize(_startDate, _endDate, _markedDay, this);

                return;
            }
            
            if (_endDate > _hostedCalendar.MaxSupportedDateTime) {
                _endDate = _container.MinMaximumDate;
                
                if (_endDate > _hostedCalendar.MaxSupportedDateTime)
                    _endDate = _hostedCalendar.MaxSupportedDateTime;
                
                _startDate = _hostedCalendar.AddMonths(_endDate, -1);

                _container.Synchronize(_startDate, _endDate, _markedDay, this);
            }
            
        }

        private void SetYearText() {
        
            _yearTextBox.Text = _hostedCalendar.GetYear(_startDate).ToString(CultureInfo.InvariantCulture) + "/" + 
                                _hostedCalendar.GetMonth(_startDate).ToString(CultureInfo.InvariantCulture) + "/" + 
                                _hostedCalendar.GetEra(_startDate).ToString(CultureInfo.InvariantCulture);
        }

        private void GoToToday() {
        
            int year, month, monthLength;
            
            _startDate = DateTime.Today;
            _markedDay = _hostedCalendar.GetDayOfMonth(_startDate);
            year  = _hostedCalendar.GetYear(_startDate);
            month = _hostedCalendar.GetMonth(_startDate);
            monthLength = _hostedCalendar.GetDaysInMonth(year, month, _hostedCalendar.GetEra(_startDate))-1;
            _startDate = _hostedCalendar.ToDateTime(year, month, 1, 0, 0, 0, 0, _hostedCalendar.GetEra(_startDate));
            _endDate   = _startDate.AddDays(monthLength);
        }

        public bool Synchronize(DateTime startDate, DateTime endDate, int markedDay) {
        
            bool result = true;
            
            if (_startDate == startDate && _endDate == endDate && _markedDay == markedDay) {
                return result;
            }

            _startDate = startDate;
            _endDate   = endDate;
            _markedDay = markedDay;
            ValidateDates();
            if (_startDate != startDate ||  _endDate != endDate) {
                result = false;
            }
            
            Invalidate();
            Update();

            return result;
        }

        public void SetMarkedDay(int x, int y) {
        
            if ( x < CalendarStatics.Indent                     || 
                 x > (CalendarStatics.Indent + 7 * CalendarStatics.CellWidth)   ||
                 y < _daysYPosition             ||
                 y > (_daysYPosition + 6 * (CalendarStatics.CellHeight + 2))) {
                 
                return;
            }

            DateTime date = new DateTime(_startDate.Year, _startDate.Month, _startDate.Day);
            int j = (int) CalendarStatics.gregorian.GetDayOfWeek(date);

            int rowNumber   = 1;
            int days        = 0;

            do {
                if (y < _daysYPosition + rowNumber * (CalendarStatics.CellHeight + 2)) {
                
                    int day = (x - CalendarStatics.Indent) / CalendarStatics.CellWidth;
                    if (day < j || day > 6) {
                        return;
                    }

                    day = days + day - j + 1;

                    date = date.AddDays(day - 1);

                    if (date <= _endDate) {
                    
                        if (_markedDay != day) {
                        
                            _markedDay = day;
                            _container.Synchronize(_startDate, _endDate, _markedDay, this);
                            Invalidate();
                            Update();
                        }
                        return;
                    }
                }

                rowNumber++;
                days += 7 - j;
                j = 0;
            } while (rowNumber < 7);
        
        }
        

        public DateTime StartDate { get { return _startDate; } }
        public DateTime EndDate   { get { return _endDate; } }
        public int      MarkedDay { get { return _markedDay; } }

        private void OnClose(object Sender, EventArgs e) {
            _container.CloseForm(this);
        }

        private int GetSlashCount(string s) {
        
            int count = 0;
            for (int i=0; i<s.Length; i++) {
                if (s[i] == '/') count++;
            }
            return count;
        }

        private bool IsNonNumber(KeyEventArgs e) {
        
            return ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                     ( e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && 
                       e.KeyCode  != Keys.Back &&
                     ((e.KeyCode != Keys.OemQuestion && e.KeyCode != Keys.Divide) || GetSlashCount(_yearTextBox.Text)>=2)
                     );
        
        }

        private bool IsInvalidTokens(string [] array) {
        
            if (array.Length > 3) {
                return true;
            }
            
            for (int i=0; i<array.Length; i++) {
                if (array[i].Length > 0)
                    return false;
            }
                    
            return true;
        }

        private void OnKeyDown(object sender, KeyEventArgs e) {
        
            _nonNumberEntered = true;
            
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) {
                try {
                   string [] tokens = _yearTextBox.Text.Split('/');
                   if (IsInvalidTokens( tokens )) {
                        SetYearText();
                        return;
                   }

                   int year;
                   if (tokens[0].Length > 0) {
                       year = int.Parse(tokens[0], CultureInfo.InvariantCulture);
                   } else {
                       year = _hostedCalendar.GetYear(_startDate);
                   }

                   int month;
                   if (tokens.Length > 1 && tokens[1].Length>0) {
                       month = int.Parse(tokens[1], CultureInfo.InvariantCulture);
                   } else {
                       month = _hostedCalendar.GetMonth(_startDate);
                   }

                   int era;
                   if (tokens.Length > 2 && tokens[2].Length>0) {
                       era = int.Parse(tokens[2], CultureInfo.InvariantCulture);
                   } else {
                       era = _hostedCalendar.GetEra(_startDate);
                   }

                   _startDate = _hostedCalendar.ToDateTime(
                                 year, 
                                 month, 
                                 1, 
                                 0, 0, 0, 0, era);


                   int daysToAdd = _hostedCalendar.GetDaysInMonth(
                                           _hostedCalendar.GetYear(_startDate), 
                                           _hostedCalendar.GetMonth(_startDate),
                                           _hostedCalendar.GetEra(_startDate))-1;

                                 
                   _endDate   = _startDate.AddDays(daysToAdd);
                } catch (ArgumentNullException)         {
                } catch (FormatException)               {
                } catch (OverflowException)             {
                } catch (InvalidOperationException)     {
                } catch (ArgumentOutOfRangeException)   {
                  
                    ValidateDates();
                    SetYearText();
                }
                
                 _container.Synchronize(_startDate, _endDate, _markedDay, this);
                
                Invalidate();
                Update();
            } else {
                _nonNumberEntered = IsNonNumber(e);
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e) {
            if (_nonNumberEntered) { e.Handled = true; }
        }
        

        private void OnNotification(object Sender, EventArgs e) {
        
            if (_dateNavigator.Notification == Notification.MonthDecrement || 
                _dateNavigator.Notification == Notification.MonthIncrement) {
                
                int month = _dateNavigator.Notification == Notification.MonthIncrement ? 1 : -1;
                int year;

                try { 
                    _startDate = _hostedCalendar.AddMonths(_startDate, month); 

                    year  = _hostedCalendar.GetYear(_startDate);
                    month = _hostedCalendar.GetMonth(_startDate);
                
                
                    if (_hostedCalendar.GetDayOfMonth(_startDate) != 1) {
                    
                        _startDate = _hostedCalendar.ToDateTime(year, month, 1, 0, 0, 0, 0);
                    }

                    int daysToAdd = _hostedCalendar.GetDaysInMonth(
                                            _hostedCalendar.GetYear(_startDate), 
                                            _hostedCalendar.GetMonth(_startDate),
                                            _hostedCalendar.GetEra(_startDate))-1;

                    _endDate = _startDate.AddDays(daysToAdd);
                    
                } catch (ArgumentOutOfRangeException) {
                
                    ValidateDates(); 
                }
                
            } else if (_dateNavigator.Notification == Notification.Today) {
                GoToToday();
            }
            
            _container.Synchronize(_startDate, _endDate, _markedDay, this);
            
            Invalidate();
            Update();
        }

        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            _container.OnMouseDown(sender, e);
        }
        
        private void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
        
            if (e.Button == MouseButtons.Left) { 
                SetMarkedDay(e.X , e.Y);
            }
            
            _container.OnMouseUp(sender, e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e) { 
            _container.OnMouseMove(sender, e); 
        }

        protected override void OnPaint(PaintEventArgs e) {
        
            BitmapPainter painter = new BitmapPainter(e);
            Graphics g = painter.Graphics;

            if (g == null) return;

            //
            // Brushes
            //
            
            Brush textHightLight    = CalendarStatics.DarkDarkBrush;
            Brush textBrush         = CalendarStatics.WindowTextBrush;
            Brush hightLightBrush   = CalendarStatics.ControlBrush;

            //
            // String Format
            //
            
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;

            //
            // DateTimeFormatInfo
            //
            
            String[] MonthNames = _formatInfo.MonthNames;

            
            Rectangle rect = ClientRectangle;
            g.FillRectangle(CalendarStatics.WindowBrush, rect);
            
            rect.Width--; 

            // Paint Calendar Name
            
            rect.X = 6; rect.Width -= 12; rect.Y = 4; rect.Height = 17;
            
            g.FillRectangle(hightLightBrush, rect);
            g.DrawString(_calendarName, Font, textBrush, rect, _stringFormat);
            
            //
            // Paint start, End dates
            //

            string formattedStartDate, formattedEndDate;
            
            formattedStartDate = _hostedCalendar.GetMonth(_startDate).ToString(CultureInfo.InvariantCulture)      + "/" +
                                 _hostedCalendar.GetDayOfMonth(_startDate).ToString(CultureInfo.InvariantCulture) + "/" +
                                 _hostedCalendar.GetYear(_startDate).ToString(CultureInfo.InvariantCulture);
                                 
            formattedEndDate  =  _hostedCalendar.GetMonth(_endDate).ToString(CultureInfo.InvariantCulture)        + "/" +
                                 _hostedCalendar.GetDayOfMonth(_endDate).ToString(CultureInfo.InvariantCulture)   + "/" +
                                 _hostedCalendar.GetYear(_endDate).ToString(CultureInfo.InvariantCulture);

            rect.Y += 17;
            g.DrawString(formattedStartDate, Font, textBrush, rect, _stringFormat);
            rect.Y += 17;
            g.DrawString(formattedEndDate, Font, textBrush, rect, _stringFormat);

            //
            // Paint Day of Week title
            //
            
            rect.Y += 17;
                
            g.FillRectangle(hightLightBrush, rect);

            rect.X = 0;
            rect.Width  = CalendarStatics.CellWidth;
            rect.Height = CalendarStatics.CellHeight;

            _stringFormat.Alignment = StringAlignment.Far;

            for (int i = 0; i < _dayNames.GetLength(0); i++) {
                rect.X = CalendarStatics.Indent + (CalendarStatics.CellWidth * i);
                g.DrawString(_dayNames[i], Font, textBrush, rect, _stringFormat);
            }

            rect.Y += 19;
            g.DrawLine(CalendarStatics.DarkPen, CalendarStatics.Indent, rect.Y , 132, rect.Y);

            // Paint the days

            DateTime date = new DateTime(_startDate.Year, _startDate.Month, _startDate.Day);
            int j = (int) CalendarStatics.gregorian.GetDayOfWeek(date);

            rect.Width = CalendarStatics.CellWidth; rect.Height = CalendarStatics.CellHeight;

            _daysYPosition = rect.Y;

            int whichDay = 1;
                
            do {
                rect.X = CalendarStatics.Indent + (CalendarStatics.CellWidth * j);

                if (whichDay == _markedDay)
                {
                    g.DrawRectangle(CalendarStatics.DarkDarkPen, rect);
                    g.FillRectangle(CalendarStatics.DarkBrush, rect);
                }
                whichDay++;
                
                g.DrawString(_hostedCalendar.GetDayOfMonth(date).ToString(CultureInfo.InvariantCulture), Font, textBrush, rect, _stringFormat);
                
                j++;
        
                if (j == 7) {
                    j = 0;
                    rect.Y += CalendarStatics.CellHeight + 2;
                }
                
                date = date.AddDays(1);
            } while (date < _endDate);
            
            if (date <= _hostedCalendar.MaxSupportedDateTime)
            {
                rect.X = CalendarStatics.Indent + (CalendarStatics.CellWidth * j);

                if (whichDay == _markedDay) {
                
                    g.DrawRectangle(CalendarStatics.DarkDarkPen, rect);
                    g.FillRectangle(CalendarStatics.DarkBrush, rect);
                }
                
                g.DrawString(_hostedCalendar.GetDayOfMonth(date).ToString(CultureInfo.InvariantCulture), Font, textBrush, rect, _stringFormat);
            }
            
            rect.Y += 19;
            g.DrawLine(CalendarStatics.DarkPen, CalendarStatics.Indent, rect.Y , 132, rect.Y);

            //
            // Draw the Era and month names
            //
            _stringFormat.Alignment = StringAlignment.Near;
            
            rect.X = CalendarStatics.Indent;
            rect.Y += 2;
            rect.Width = CalendarStatics.ClientWidth - rect.X; 

            int era = _hostedCalendar.GetEra(_startDate);
            g.DrawString("Era: "+ era.ToString(CultureInfo.InvariantCulture) + " " + _formatInfo.GetEraName(era), Font, textBrush, rect, _stringFormat);

            rect.Y += 17;

            if (_canBeOptionalCalendar) {
            
                formattedStartDate = _startDate.ToString("MMMM", _formatInfo) + " ~ " + _endDate.ToString("MMMM", _formatInfo); 
                g.DrawString(formattedStartDate, Font, textBrush, rect, _stringFormat);
            }
            
            painter.Flush();

            // Year TextBox        
            SetYearText();
        }
    }

    [System.ComponentModel.Localizable(false)]
    public sealed class DateNavigator : Control {
    
        private DateTime        value = DateTime.MinValue;
        private Rectangle       leftRect;
        private Rectangle       rightRect;
        private Rectangle       centerRect;
        private Timer           Timer = new Timer();
        private bool            mouseDown = false;
        private Notification    notification;
        private StringFormat    StringFormat = new StringFormat();

        public event EventHandler Changed;
        
        public DateNavigator() {
        
            Font = CalendarStatics.Tahoma825Font;
            ClientSize = new Size(143, 18);
            

            leftRect    = new Rectangle(0, 0, 20, ClientSize.Height);
            rightRect   = new Rectangle(ClientSize.Width - 20, 0, 20, ClientSize.Height);

            Graphics g = Graphics.FromHwnd(Handle);
            try 
            {
                int textWidth = (int) Math.Ceiling(g.MeasureString(CalendarStatics.TodayString, Font).Width);
                centerRect  = new Rectangle(
                                    (int) ((ClientRectangle.Width - textWidth) / 2), 
                                    ClientRectangle.Top,
                                    textWidth,
                                    ClientRectangle.Height);
            } finally {
                g.Dispose();
            }
            
            Timer.Interval = 250;
            Timer.Tick += new EventHandler(OnTimer);
        }
        
        protected override void OnMouseDown(MouseEventArgs e) {
        
            if (Scroll()) {
                Timer.Start();
                mouseDown = true;
                Invalidate();
            } else {
                Capture = false;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e) {
        
            Timer.Stop();
            mouseDown = false;
            Invalidate();
            base.OnMouseUp(e);      
        }

        public Notification Notification {
            set { notification = value; }
            get { return notification; }
        }

        public Boolean Scroll() {
            if (MouseButtons != MouseButtons.Left) return false;
            Point p = PointToClient(MousePosition);

            if (leftRect.Contains(p)) { 
                Notification = Notification.MonthDecrement;
                if (IsHandleCreated) Changed(this, null);
                return true; 
            }
            
            if (rightRect.Contains(p)) { 
                Notification = Notification.MonthIncrement;
                if (IsHandleCreated) Changed(this, null);
                return true; 
            }

            if (centerRect.Contains(p)) {
                Notification = Notification.Today;
                if (IsHandleCreated) Changed(this, null);
                return true; 
            }
            
            return false;
        }

        private void OnTimer(Object Sender, EventArgs e) { Scroll(); }

        protected override void OnPaint(PaintEventArgs e) {
            BitmapPainter v = new BitmapPainter(e);
            Graphics g = v.Graphics;          

            if (g == null) return;
            
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;

            Rectangle r = ClientRectangle;

            g.FillRectangle(CalendarStatics.ControlBrush, r);
            
            if (mouseDown) {
            
                g.DrawLine(CalendarStatics.DarkPen, r.Left, r.Top, r.Right - 1, r.Top);
                g.DrawLine(CalendarStatics.DarkPen, r.Left, r.Top, r.Left, r.Bottom - 1);
                g.DrawLine(CalendarStatics.LightLightPen, r.Left, r.Bottom - 1, r.Right - 1, r.Bottom - 1);
                g.DrawLine(CalendarStatics.LightLightPen, r.Right - 1, r.Top, r.Right - 1, r.Bottom - 1);    
            } else {
                g.DrawLine(CalendarStatics.LightLightPen, r.Left, r.Top, r.Right - 1, r.Top);
                g.DrawLine(CalendarStatics.LightLightPen, r.Left, r.Top, r.Left, r.Bottom - 1);
                g.DrawLine(CalendarStatics.DarkPen, r.Left, r.Bottom - 1, r.Right - 1, r.Bottom - 1);
                g.DrawLine(CalendarStatics.DarkPen, r.Right - 1, r.Top, r.Right - 1, r.Bottom - 1);    
            }
            
            g.DrawString(CalendarStatics.TodayString, Font, CalendarStatics.BlackBrush, r.Left + (r.Width / 2), r.Top + (r.Height / 2), StringFormat);

            Point[] p0 = { new Point(6,  (ClientSize.Height / 2)), new Point(11, (ClientSize.Height / 2) + 5), new Point(11, (ClientSize.Height / 2) - 5) };
            g.FillPolygon(CalendarStatics.BlackBrush, p0);
            Point[] p1 = { new Point(ClientSize.Width - 6,  (ClientSize.Height / 2)), new Point(ClientSize.Width - 11, (ClientSize.Height / 2) + 5), new Point(ClientSize.Width - 11, (ClientSize.Height / 2) - 5) };
            g.FillPolygon(CalendarStatics.BlackBrush, p1);

            v.Flush();
        }    

        protected override void OnPaintBackground(PaintEventArgs e) { }
    }


    public sealed class BitmapPainter {
    
        private Graphics    graphic = null;
        private Graphics    target = null;
        private Rectangle   clipRectangle = new Rectangle(0, 0, 0, 0);
        private Bitmap      bitmap = null;

        public BitmapPainter(PaintEventArgs e) {
        
            clipRectangle = e.ClipRectangle;

            if (clipRectangle.Width <= 0 || clipRectangle.Height <= 0) { return; }
            
            target   = e.Graphics;
            Graphics = e.Graphics;
            bitmap = new Bitmap(clipRectangle.Width, clipRectangle.Height, target);
            Graphics = Graphics.FromImage(bitmap);
            Graphics.TranslateTransform(-clipRectangle.X, -clipRectangle.Y);
            Graphics.SetClip(clipRectangle);
        }

        public BitmapPainter(Graphics g, Rectangle rectangle) {
        
            clipRectangle = rectangle;

            if (clipRectangle.Width <= 0 || clipRectangle.Height <= 0) { return; }
            
            target   = g;
            Graphics = g;
            bitmap = new Bitmap(clipRectangle.Width, clipRectangle.Height, target);
            Graphics = Graphics.FromImage(bitmap);
            Graphics.TranslateTransform(-clipRectangle.X, -clipRectangle.Y);
            Graphics.SetClip(clipRectangle);
        }

        public Graphics Graphics {
        
            set { graphic = value; }
            get { return graphic;  }
        }

        public void Flush() {

            try {
                target.DrawImageUnscaled(bitmap, clipRectangle.X, clipRectangle.Y);
            } finally {
                Graphics.Dispose();
                bitmap.Dispose();
            }
        }
    }

    public sealed class CalendarInfo {
    
        private bool               _compatibleCalendar;
        private string             _name;
        private Calendar           _calendar;
        private DateTimeFormatInfo _format;

        public CalendarInfo(Calendar calendar, DateTimeFormatInfo format, bool compatibleCalendar) {
        
            _format             = format;
            _calendar           = calendar;
            _compatibleCalendar = compatibleCalendar;
            _name               = CalendarStatics.GetCalendarName(_calendar);
        }

        public Calendar             Calendar                { get { return _calendar; } }
        public string               Name                    { get { return _name;     } }
        public DateTimeFormatInfo   Format                  { get { return _format;   } }
        public bool                 IsCompatibleCalendar    { get { return _compatibleCalendar; } }
    }


    internal sealed class CalendarStatics {
        //
        // Constants
        //

        internal const int CellWidth     = 17;
        internal const int CellHeight    = 15;
        internal const int Indent        = 14;
        internal const int Margin        = 3;
        internal const int Gap           = 3;
        
        //
        // static fields
        //

        static internal GregorianCalendar    gregorian       = new GregorianCalendar();
        static internal Font                 Tahoma825Font   = new Font("Tahoma", 8.25f);
        static internal Font                 Arial825Font    = new Font("Arial", 8.25f, FontStyle.Bold);
        static internal SolidBrush           DarkDarkBrush   = new SolidBrush(SystemColors.ControlDarkDark);
        static internal SolidBrush           WindowTextBrush = new SolidBrush(SystemColors.WindowText);
        static internal SolidBrush           ControlBrush    = new SolidBrush(SystemColors.Control);
        static internal SolidBrush           WindowBrush     = new SolidBrush(SystemColors.Window);
        static internal SolidBrush           DarkBrush       = new SolidBrush(SystemColors.ControlDark);
        static internal SolidBrush           BlackBrush      = new SolidBrush(Color.Black);
        static internal Pen                  DarkDarkPen     = new Pen(SystemColors.ControlDarkDark, 1);
        static internal Pen                  DarkPen         = new Pen(SystemColors.ControlDark, 1);
        static internal Pen                  LightLightPen   = new Pen(SystemColors.ControlLightLight, 1);
        static internal Pen                  ControlPen      = new Pen(SystemColors.Control, 1);
        static internal string               TodayString     = "Today";
        static internal int                  ClientWidth     = 150;
        static internal int                  ClientHeight    = 265;

        internal static CalendarInfo [] _allCalendars  = new CalendarInfo[] {
            // 0  Gregorian
            new CalendarInfo(
                    new GregorianCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("en-US").DateTimeFormat.Clone(),
                    true),

            // 1  Julian
            new CalendarInfo(
                    new JulianCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("en-US").DateTimeFormat.Clone(),
                    false),

            // 2  Hijri
            new CalendarInfo(
                    new HijriCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ar-SA").DateTimeFormat.Clone(),
                    true),
                    
            // 3  Um AlQura
            new CalendarInfo(
                    new UmAlQuraCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ar-SA").DateTimeFormat.Clone(),
                    false),
            
            // 4  Japanese
            new CalendarInfo(
                    new JapaneseCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ja-JP").DateTimeFormat.Clone(),
                    true),

            // 5  Hebrew
            new CalendarInfo(
                    new HebrewCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("he-IL").DateTimeFormat.Clone(),
                    true),

            // 6  Persian
            new CalendarInfo(
                    new PersianCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("fa-IR").DateTimeFormat.Clone(),
                    false),

            // 7  ChineseLunisolar
            new CalendarInfo(
                    new ChineseLunisolarCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("zh-CN").DateTimeFormat.Clone(),
                    false),

            // 8  JapaneseLunisolar
            new CalendarInfo(
                    new JapaneseLunisolarCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ja-JP").DateTimeFormat.Clone(),
                    false),

            // 9  Korean
            new CalendarInfo(
                    new KoreanCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ko-KR").DateTimeFormat.Clone(),
                    true),

            // 10 KoreanLunisolar
            new CalendarInfo(
                    new KoreanLunisolarCalendar(), 
                    (DateTimeFormatInfo) CultureInfo.GetCultureInfo("ko-KR").DateTimeFormat.Clone(),
                    false),
                    
        };

        static CalendarStatics() {
            _allCalendars[2].Format.Calendar = _allCalendars[2].Calendar;
            _allCalendars[3].Format.Calendar = _allCalendars[2].Calendar;
            _allCalendars[4].Format.Calendar = _allCalendars[4].Calendar;
            _allCalendars[5].Format.Calendar = _allCalendars[5].Calendar;
            _allCalendars[7].Format.Calendar = new GregorianCalendar();
            _allCalendars[8].Format.Calendar = _allCalendars[4].Calendar;
            _allCalendars[9].Format.Calendar = _allCalendars[9].Calendar;
            _allCalendars[10].Format.Calendar= _allCalendars[9].Calendar;
        }


        public static CalendarInfo [] CalendarsInfo {
            get { return _allCalendars; }
        }

        internal static string GetCalendarName(Calendar hostedCalendar) {
        
            string s = hostedCalendar.ToString();
            int lastPeriod = s.LastIndexOf('.');
            if (lastPeriod == -1) lastPeriod = 0;
            
            int lastCalendar = s.LastIndexOf("Calendar");
            if (lastCalendar == -1) lastCalendar = 0;

            if (lastPeriod+1 < lastCalendar) {
                return s.Substring(lastPeriod+1, lastCalendar-lastPeriod-1);
            }

            if (lastPeriod > lastCalendar) {
                return s.Substring(lastPeriod+1, s.Length - lastPeriod);
            }

            return s;
        }
        
        internal static MenuItem [] GetCalendarMenu(EventHandler handler) {
        
            MenuItem [] supportedCalendarsSubMenus = new MenuItem[_allCalendars.Length];

            MenuItem current = new MenuItem(_allCalendars[0].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[0] = current;

            current = new MenuItem(_allCalendars[1].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[1] = current;
            
            current = new MenuItem(_allCalendars[2].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[2] = current;

            current = new MenuItem(_allCalendars[3].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[3] = current;

            current = new MenuItem(_allCalendars[4].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[4] = current;

            current = new MenuItem(_allCalendars[5].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[5] = current;

            current = new MenuItem(_allCalendars[6].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[6] = current;

            current = new MenuItem(_allCalendars[7].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[7] = current;

            current = new MenuItem(_allCalendars[8].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[8] = current;

            current = new MenuItem(_allCalendars[9].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[9] = current;
            
            current = new MenuItem(_allCalendars[10].Name);
            current.Click += handler;
            supportedCalendarsSubMenus[10] = current;
            
            return supportedCalendarsSubMenus;
        }
        
    }

    public enum Notification {
        MonthIncrement,
        MonthDecrement,
        Today
    }
}
