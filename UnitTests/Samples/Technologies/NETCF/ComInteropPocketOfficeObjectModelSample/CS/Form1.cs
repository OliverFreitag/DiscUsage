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
//
// This sample depends on an assembly called PocketOutlook (contained in 
// PocketOutlook.dll).  PocketOutlook is an "interop assembly generated
// by the Type Library Importer Tool (tlbimp.exe) in the .NET Framework
// SDK.  Should you need to regenerate PocketOutlook.dll, the source
// file needed to build the type library that is input to tlbimp.exe can
// be found at: http://blogs.msdn.com/windowsmobile/archive/2004/08/05/209268.aspx 
//
//---------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using PocketOutlook;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Microsoft.Samples.POOMComInterop
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        ApplicationClass outlookApp = null;
        IFolder contactsFolder = null;
        IFolder tasksFolder = null;
        IFolder calendarFolder = null;

        public Form1()
        {
            try
            {
                InitializeComponent();

                // Create an instance of the PocketOutlook application object and log on
                outlookApp = new PocketOutlook.ApplicationClass();
                outlookApp.Logon(0);

                // Get the contacts, tasks, and calendar folders.
                contactsFolder = outlookApp.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                tasksFolder = outlookApp.GetDefaultFolder(OlDefaultFolders.olFolderTasks);
                calendarFolder = outlookApp.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);

                // Add event handlers used to parse phone numbers after they 
                // are entered.
                homePhoneTextBox.LostFocus += new EventHandler(phone_LostFocus);
                workPhoneTextBox.LostFocus += new EventHandler(phone_LostFocus);
                cellPhoneTextBox.LostFocus += new EventHandler(phone_LostFocus);

                // Clear the fields in the UI.
                ClearContact();
                ClearTask();
                ClearAppointment();
            }
            // Failure HRESULTS returned from COM objects result in COMExceptions in managed code.
            // Catching COMExceptions allows you to examine the HRESULT returned from the Com object
            catch (COMException cex)
            {
                MessageBox.Show("A Com error occurred while initializing PocketOutlook: " + cex.ToString());
            }
        }

        ~Form1()
        {
            // Log out of Pocket Outlook.
            if (outlookApp != null)
            {
                outlookApp.Logoff();
                outlookApp = null;
            }
        }
        #region Contact Region

        // This code region contains properties to get and set the
        // various fields of a PocketOutlook Contact based on data
        // entered on the Contacts tab of the UI.
        private string ContactFirstName
        {
            get
            {
                return firstNameTextBox.Text.Trim();
            }

            set
            {
                if (value != null)
                {
                    firstNameTextBox.Text = value.Trim();
                }
                else
                {
                    firstNameTextBox.Text = "";
                }
            }
        }

        private string ContactLastName
        {
            get
            {
                return lastNameTextBox.Text.Trim();
            }

            set
            {
                if (value != null)
                {
                    lastNameTextBox.Text = value.Trim();
                }
                else
                {
                    lastNameTextBox.Text = value;
                }
            }
        }

        private bool ContactFirstNameSpecified
        {
            get
            {
                return ContactFirstName.Length > 0;
            }

            set
            {
                if (!value)
                {
                    ContactFirstName = null;
                }
            }
        }

        private bool ContactLastNameSpecified
        {
            get
            {
                return ContactLastName.Length > 0;
            }

            set
            {
                if (!value)
                {
                    ContactLastName = null;
                }
            }
        }

        // As the contact name is edited, populate the "FileAs" combo
        // box with the combinations of first and last name
        private void Name_TextChanged(object sender, EventArgs e)
        {
            int selected = fileAsCombo.SelectedIndex;
            fileAsCombo.Items.Clear();

            if (ContactFirstNameSpecified)
            {
                fileAsCombo.Items.Add(ContactFirstName);
            }

            if (ContactLastNameSpecified)
            {
                fileAsCombo.Items.Add(ContactLastName);
            }

            if (ContactFirstNameSpecified && ContactLastNameSpecified)
            {
                fileAsCombo.Items.Add(String.Format(CultureInfo.InvariantCulture, "{0} {1}", ContactFirstName, ContactLastName));
                fileAsCombo.Items.Add(String.Format(CultureInfo.InvariantCulture, "{0}, {1}", ContactLastName, ContactFirstName));
            }

            if (selected > 0)
            {
                if (selected < fileAsCombo.Items.Count)
                {
                    fileAsCombo.SelectedIndex = selected;
                }
                else
                {
                    fileAsCombo.SelectedIndex = fileAsCombo.Items.Count - 1;
                }
            }
            else
            {
                if (fileAsCombo.Items.Count > 0)
                {
                    fileAsCombo.SelectedIndex = fileAsCombo.Items.Count - 1;
                }
                else
                {
                    fileAsCombo.SelectedIndex = -1;
                }
            }
        }


        private void ClearContact()
        {
            ContactFirstNameSpecified = false;
            ContactLastNameSpecified = false;
            homePhoneTextBox.Text = "";
            cellPhoneTextBox.Text = "";
            workPhoneTextBox.Text = "";
        }

        private void clearContactButton_Click(object sender, EventArgs e)
        {
            ClearContact();
        }

        // Add a new contact.  Creates a new instance of a Pocket
        // Outlook contact and populate its fields based on the 
        // values entered in the user interface.
        private void addContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ContactFirstNameSpecified || ContactLastNameSpecified)
                {
                    IContact newContact = (IContact)contactsFolder.Items.Add();

                    if (ContactFirstNameSpecified)
                    {
                        newContact.FirstName = ContactFirstName;
                    }

                    if (ContactLastNameSpecified)
                    {
                        newContact.LastName = ContactLastName;
                    }

                    if (homePhoneTextBox.Text.Trim().Length > 0)
                    {
                        newContact.HomeTelephoneNumber = homePhoneTextBox.Text.Trim();
                    }

                    if (cellPhoneTextBox.Text.Trim().Length > 0)
                    {
                        newContact.MobileTelephoneNumber = cellPhoneTextBox.Text.Trim();
                    }

                    if (workPhoneTextBox.Text.Trim().Length > 0)
                    {
                        newContact.BusinessTelephoneNumber = workPhoneTextBox.Text.Trim();
                    }

                    newContact.FileAs = fileAsCombo.Text;

                    newContact.Save();
                    ClearContact();
                }
            }
            catch (COMException cex)
            {
                Console.WriteLine("Failed to add the new contact.  PocketOutlook returned the following error: " + cex.ToString());
            }

        }

        // Parse the phone number after it is entered.
        private void phone_LostFocus(object sender, EventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;
            senderTextBox.Text = PhoneParser.ParseText(senderTextBox.Text);
        }

        #endregion

        #region Task Region
        // This code region contains properties to get and set the
        // various fields of a PocketOutlook Task based on data
        // entered on the Tasks tab of the UI.
        private void ClearTask()
        {
            TaskSubjectSpecified = false;
            TaskDueSpecified = false;
            TaskImportance = OlImportance.olImportanceNormal;
            TaskReminder = false;
            TaskNotesSpecified = false;
        }

        private string TaskSubject
        {
            get
            {
                return subjectTextBox.Text.Trim();
            }
            set
            {
                if (value == null)
                {
                    subjectTextBox.Text = "";
                }
                else
                {
                    subjectTextBox.Text = value.Trim();
                }
            }
        }
        private bool TaskSubjectSpecified
        {
            get
            {
                return TaskSubject.Length > 0;
            }
            set
            {
                if (!value)
                {
                    TaskSubject = null;
                }
            }
        }
        private DateTime TaskDue
        {
            get
            {
                return taskDueDatePicker.Value;
            }
        }
        private bool TaskDueSpecified
        {
            get
            {
                return (TaskDue > DateTime.Today);
            }
            set
            {
                if (!value)
                {
                    taskDueDatePicker.MinDate = DateTime.Today;
                    taskDueDatePicker.Value = DateTime.Today;
                }
            }
        }
        private OlImportance TaskImportance
        {
            get
            {
                switch (importanceCombo.SelectedIndex)
                {
                    case 0:
                        return OlImportance.olImportanceLow;
                    case 2:
                        return OlImportance.olImportanceHigh;
                    default:
                        return OlImportance.olImportanceNormal;
                }
            }
            set
            {
                switch (value)
                {
                    case OlImportance.olImportanceLow:
                        importanceCombo.SelectedIndex = 0;
                        break;
                    case OlImportance.olImportanceNormal:
                        importanceCombo.SelectedIndex = 1;
                        break;
                    case OlImportance.olImportanceHigh:
                        importanceCombo.SelectedIndex = 2;
                        break;
                }
            }
        }
        private bool TaskReminder
        {
            get
            {
                return reminderCheckBox.Checked;
            }
            set
            {
                reminderCheckBox.Checked = value;
            }
        }
        private string TaskNotes
        {
            get
            {
                return notesTextBox.Text.Trim();
            }
            set
            {
                if (value == null)
                {
                    notesTextBox.Text = "";
                }
                else
                {
                    notesTextBox.Text = value.Trim();
                }
            }
        }
        private bool TaskNotesSpecified
        {
            get
            {
                return TaskNotes.Length > 0;
            }
            set
            {
                if (!value)
                {
                    TaskNotes = null;
                }
            }
        }


        private void addTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TaskSubjectSpecified)
                {
                    ITask newTask = (ITask)tasksFolder.Items.Add();

                    newTask.Subject = TaskSubject;

                    if (TaskDueSpecified)
                    {
                        newTask.StartDate = TaskDue;
                        newTask.DueDate = TaskDue;
                        newTask.ReminderSet = TaskReminder;

                        if (TaskReminder)
                        {
                            newTask.ReminderOptions = OlReminderOptions.olSound | OlReminderOptions.olDialog;
                            newTask.ReminderTime = TaskDue;
                        }
                    }
                    else
                    {
                        newTask.ReminderSet = false;
                    }

                    newTask.Importance = TaskImportance;

                    if (TaskNotesSpecified)
                    {
                        newTask.Body = TaskNotes;
                    }

                    newTask.Save();
                    ClearTask();
                }
            }
            catch (COMException cex)
            {
                Console.WriteLine("Failed to add the new task.  PocketOutlook returned the following error: " + cex.ToString());
            }
        }

        private void clearTaskButton_Click(object sender, EventArgs e)
        {
            ClearTask();
        }

        #endregion

        #region Appointment Region

        // This code region contains properties to get and set the
        // various fields of a PocketOutlook Appointment based on data
        // entered on the Calendar tab of the UI.

        private string AppointmentSubject
        {
            get
            {
                return appointmentSubjectTextBox.Text.Trim();
            }
            set
            {
                if (value == null)
                {
                    appointmentSubjectTextBox.Text = "";
                }
                else
                {
                    appointmentSubjectTextBox.Text = value.Trim();
                }
            }
        }

        private bool AppointmentSubjectSet
        {
            get
            {
                return AppointmentSubject.Length > 0;
            }
            set
            {
                if (!value)
                {
                    AppointmentSubject = null;
                }
            }
        }

        private DateTime AppointmentStart
        {
            get
            {
                return new DateTime(startDatePicker.Value.Year,
                    startDatePicker.Value.Month,
                    startDatePicker.Value.Day,
                    startTimePicker.Value.Hour,
                    startTimePicker.Value.Minute,
                    startTimePicker.Value.Second);
            }
            set
            {
                if (value >= DateTime.Today)
                {
                    startDatePicker.Value = value;
                    startTimePicker.Value = value;
                }
            }
        }

        private bool AppointmentStartSet
        {
            get
            {
                return AppointmentStart > DateTime.Now;
            }
            set
            {
                if (!value)
                {
                    AppointmentStart = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month,
                        DateTime.Now.Day,
                        DateTime.Now.Hour,
                        0, 0);
                }
            }
        }

        private int AppointmentDuration
        {
            get
            {
                switch (durationCombo.Text)
                {
                    case "15 Minutes":
                        return 15;
                    case "30 Minutes":
                        return 30;
                    case "1 Hour":
                        return 60;
                    case "1 1/2 Hours":
                        return 90;
                    case "2 Hours":
                        return 120;
                    case "2 1/2 Hours":
                        return 150;
                    case "3 Hours":
                        return 180;
                    case "4 Hours":
                        return 240;
                    default:
                        return 30;
                }
            }
            set
            {
                switch (value)
                {
                    case 15:
                        durationCombo.SelectedIndex = 0;
                        return;
                    case 30:
                        durationCombo.SelectedIndex = 1;
                        return;
                    case 60:
                        durationCombo.SelectedIndex = 2;
                        return;
                    case 90:
                        durationCombo.SelectedIndex = 3;
                        return;
                    case 120:
                        durationCombo.SelectedIndex = 4;
                        return;
                    case 150:
                        durationCombo.SelectedIndex = 5;
                        break;
                    case 180:
                        durationCombo.SelectedIndex = 6;
                        break;
                    case 240:
                        durationCombo.SelectedIndex = 7;
                        break;
                    default:
                        durationCombo.SelectedIndex = 1;
                        break;
                }

            }
        }

        private bool AppointmentReoccurs
        {
            get
            {
                return occursCombo.SelectedIndex != 0;
            }
            set
            {
                if (!value)
                {
                    occursCombo.SelectedIndex = 0;
                }
            }
        }

        private OlRecurrenceType AppointmentRecurrence
        {
            get
            {
                switch (occursCombo.SelectedIndex)
                {
                    case 1:
                        return OlRecurrenceType.olRecursDaily;
                    case 2:
                        return OlRecurrenceType.olRecursWeekly;
                    case 3:
                        return OlRecurrenceType.olRecursMonthly;
                    case 4:
                        return OlRecurrenceType.olRecursYearly;
                    default:
                        throw new System.ApplicationException("Not a Recurring Appointment");
                }
            }
        }

        private DateTime AppointmentRecurrenceEndDate
        {
            get
            {
                return endDatePicker.Value;
            }
        }

        private bool AppointmentRecurrenceEndDateSet
        {
            get
            {
                return endsCheckBox.Checked;
            }
        }

        private string AppointmentNotes
        {
            get
            {
                return appointmentNotesTextBox.Text.Trim();
            }
            set
            {
                if (value == null)
                {
                    appointmentNotesTextBox.Text = "";
                }
                else
                {
                    appointmentNotesTextBox.Text = value.Trim();
                }
            }
        }

        private bool AppointmentNotesSet
        {
            get
            {
                return AppointmentNotes.Length > 0;
            }
            set
            {
                if (!value)
                {
                    AppointmentNotes = null;
                }
            }
        }

        private void ClearAppointment()
        {
            AppointmentSubjectSet = false;
            AppointmentStartSet = false;
            AppointmentDuration = 30;
            AppointmentReoccurs = false;
            AppointmentNotesSet = false;
        }


        // Adds a new appointment.  After a new appointment is created, it's
        // fields are populated based on values entered in the UI.
        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppointmentSubjectSet && AppointmentStartSet)
                {
                    IAppointment newAppointment = (IAppointment)calendarFolder.Items.Add();

                    newAppointment.Subject = AppointmentSubject;
                    newAppointment.Start = AppointmentStart;
                    newAppointment.Duration = AppointmentDuration;

                    if (AppointmentNotesSet)
                    {
                        newAppointment.Body = AppointmentNotes;
                    }

                    if (AppointmentReoccurs)
                    {
                        IRecurrencePattern recurrence = newAppointment.GetRecurrencePattern();
                        recurrence.RecurrenceType = AppointmentRecurrence;
                        recurrence.PatternStartDate = AppointmentStart.Date;
                        if (AppointmentRecurrenceEndDateSet)
                        {
                            recurrence.NoEndDate = false;
                            recurrence.PatternEndDate = AppointmentRecurrenceEndDate;
                        }
                        else
                        {
                            recurrence.NoEndDate = true;
                        }

                        recurrence.Interval = 1;

                        if (AppointmentRecurrence == OlRecurrenceType.olRecursWeekly)
                        {
                            switch (AppointmentStart.Date.DayOfWeek)
                            {
                                case DayOfWeek.Sunday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olSunday;
                                    break;

                                case DayOfWeek.Monday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olMonday;
                                    break;

                                case DayOfWeek.Tuesday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olTuesday;
                                    break;

                                case DayOfWeek.Wednesday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olWednesday;
                                    break;

                                case DayOfWeek.Thursday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olThursday;
                                    break;

                                case DayOfWeek.Friday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olFriday;
                                    break;

                                case DayOfWeek.Saturday:
                                    recurrence.DayOfWeekMask = OlDaysOfWeek.olSaturday;
                                    break;
                            }
                        }

                        if (AppointmentRecurrence == OlRecurrenceType.olRecursMonthly ||
                            AppointmentRecurrence == OlRecurrenceType.olRecursYearly)
                        {
                            recurrence.DayOfMonth = AppointmentStart.Day;
                        }

                        if (AppointmentRecurrence == OlRecurrenceType.olRecursYearly)
                        {
                            recurrence.MonthOfYear = AppointmentStart.Month;
                        }

                    }

                    newAppointment.Save();
                    ClearAppointment();

                }
            }
            catch (COMException cex)
            {
                Console.WriteLine("Failed to add the new appointment.  PocketOutlook returned the following error: " + cex.ToString());
            }
        }

        private void clearAppointmentButton_Click(object sender, EventArgs e)
        {
            ClearAppointment();
        }

        private void occurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (occursCombo.SelectedIndex > 0)
            {
                endsLabel.Visible = true;
                endsCheckBox.Visible = true;
            }
            else
            {
                endsLabel.Visible = false;
                endsCheckBox.Visible = false;
                endsCheckBox.Checked = false;
            }
        }

        private void ends_CheckStateChanged(object sender, EventArgs e)
        {
            if (endsCheckBox.Checked)
            {
                endDatePicker.Visible = true;
                endDatePicker.Value = startDatePicker.Value;
            }
            else
            {
                endDatePicker.Visible = false;
            }
        }

        #endregion
    }
}

