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

namespace Microsoft.Samples.POOMComInterop
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private void InitializeComponent()
        {
            this.foldersTabControl = new System.Windows.Forms.TabControl();
            this.contactsTabPage = new System.Windows.Forms.TabPage();
            this.cellPhoneTextBox = new System.Windows.Forms.TextBox();
            this.workPhoneTextBox = new System.Windows.Forms.TextBox();
            this.homePhoneTextBox = new System.Windows.Forms.TextBox();
            this.cellLabel = new System.Windows.Forms.Label();
            this.workLabel = new System.Windows.Forms.Label();
            this.homeLabel = new System.Windows.Forms.Label();
            this.clearContactButton = new System.Windows.Forms.Button();
            this.addContactButton = new System.Windows.Forms.Button();
            this.fileAsCombo = new System.Windows.Forms.ComboBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.fileAsLabel = new System.Windows.Forms.Label();
            this.tasksTabPage = new System.Windows.Forms.TabPage();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.clearTaskButton = new System.Windows.Forms.Button();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.reminderCheckBox = new System.Windows.Forms.CheckBox();
            this.reminderLabel = new System.Windows.Forms.Label();
            this.importanceLabel = new System.Windows.Forms.Label();
            this.importanceCombo = new System.Windows.Forms.ComboBox();
            this.dueLabel = new System.Windows.Forms.Label();
            this.taskDueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.appointmentsTabPage = new System.Windows.Forms.TabPage();
            this.appointmentNotesLabel = new System.Windows.Forms.Label();
            this.appointmentNotesTextBox = new System.Windows.Forms.TextBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endsCheckBox = new System.Windows.Forms.CheckBox();
            this.endsLabel = new System.Windows.Forms.Label();
            this.occursLabel = new System.Windows.Forms.Label();
            this.occursCombo = new System.Windows.Forms.ComboBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationCombo = new System.Windows.Forms.ComboBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.appointmentSubjectTextBox = new System.Windows.Forms.TextBox();
            this.appointmentSubjectLabel = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.clearAppointmentButton = new System.Windows.Forms.Button();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.foldersTabControl.SuspendLayout();
            this.contactsTabPage.SuspendLayout();
            this.tasksTabPage.SuspendLayout();
            this.appointmentsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldersTabControl
            // 
            this.foldersTabControl.Controls.Add(this.contactsTabPage);
            this.foldersTabControl.Controls.Add(this.tasksTabPage);
            this.foldersTabControl.Controls.Add(this.appointmentsTabPage);
            this.foldersTabControl.Location = new System.Drawing.Point(0, 0);
            this.foldersTabControl.Name = "foldersTabControl";
            this.foldersTabControl.SelectedIndex = 0;
            this.foldersTabControl.Size = new System.Drawing.Size(240, 268);
            this.foldersTabControl.TabIndex = 0;
            // 
            // contactsTabPage
            // 
            this.contactsTabPage.Controls.Add(this.cellPhoneTextBox);
            this.contactsTabPage.Controls.Add(this.workPhoneTextBox);
            this.contactsTabPage.Controls.Add(this.homePhoneTextBox);
            this.contactsTabPage.Controls.Add(this.cellLabel);
            this.contactsTabPage.Controls.Add(this.workLabel);
            this.contactsTabPage.Controls.Add(this.homeLabel);
            this.contactsTabPage.Controls.Add(this.clearContactButton);
            this.contactsTabPage.Controls.Add(this.addContactButton);
            this.contactsTabPage.Controls.Add(this.fileAsCombo);
            this.contactsTabPage.Controls.Add(this.lastNameTextBox);
            this.contactsTabPage.Controls.Add(this.lastNameLabel);
            this.contactsTabPage.Controls.Add(this.firstNameTextBox);
            this.contactsTabPage.Controls.Add(this.firstNameLabel);
            this.contactsTabPage.Controls.Add(this.fileAsLabel);
            this.contactsTabPage.Location = new System.Drawing.Point(0, 0);
            this.contactsTabPage.Name = "contactsTabPage";
            this.contactsTabPage.Size = new System.Drawing.Size(240, 245);
            this.contactsTabPage.Text = "Contacts";
            // 
            // cellPhoneTextBox
            // 
            this.cellPhoneTextBox.Location = new System.Drawing.Point(54, 158);
            this.cellPhoneTextBox.Name = "cellPhoneTextBox";
            this.cellPhoneTextBox.Size = new System.Drawing.Size(179, 21);
            this.cellPhoneTextBox.TabIndex = 22;
            // 
            // workPhoneTextBox
            // 
            this.workPhoneTextBox.Location = new System.Drawing.Point(54, 131);
            this.workPhoneTextBox.Name = "workPhoneTextBox";
            this.workPhoneTextBox.Size = new System.Drawing.Size(179, 21);
            this.workPhoneTextBox.TabIndex = 21;
            // 
            // homePhoneTextBox
            // 
            this.homePhoneTextBox.Location = new System.Drawing.Point(54, 105);
            this.homePhoneTextBox.Name = "homePhoneTextBox";
            this.homePhoneTextBox.Size = new System.Drawing.Size(179, 21);
            this.homePhoneTextBox.TabIndex = 20;
            // 
            // cellLabel
            // 
            this.cellLabel.Location = new System.Drawing.Point(4, 158);
            this.cellLabel.Name = "cellLabel";
            this.cellLabel.Size = new System.Drawing.Size(46, 20);
            this.cellLabel.Text = "Cell:";
            // 
            // workLabel
            // 
            this.workLabel.Location = new System.Drawing.Point(4, 131);
            this.workLabel.Name = "workLabel";
            this.workLabel.Size = new System.Drawing.Size(46, 20);
            this.workLabel.Text = "Work:";
            // 
            // homeLabel
            // 
            this.homeLabel.Location = new System.Drawing.Point(4, 105);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(46, 20);
            this.homeLabel.Text = "Home:";
            // 
            // clearContactButton
            // 
            this.clearContactButton.Location = new System.Drawing.Point(161, 212);
            this.clearContactButton.Name = "clearContactButton";
            this.clearContactButton.Size = new System.Drawing.Size(72, 20);
            this.clearContactButton.TabIndex = 16;
            this.clearContactButton.Text = "Clear";
            this.clearContactButton.Click += new System.EventHandler(this.clearContactButton_Click);
            // 
            // addContactButton
            // 
            this.addContactButton.Location = new System.Drawing.Point(82, 212);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(72, 20);
            this.addContactButton.TabIndex = 15;
            this.addContactButton.Text = "Add";
            this.addContactButton.Click += new System.EventHandler(this.addContactButton_Click);
            // 
            // fileAsCombo
            // 
            this.fileAsCombo.Location = new System.Drawing.Point(4, 65);
            this.fileAsCombo.Name = "fileAsCombo";
            this.fileAsCombo.Size = new System.Drawing.Size(229, 22);
            this.fileAsCombo.TabIndex = 11;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(120, 19);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(113, 21);
            this.lastNameTextBox.TabIndex = 7;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.Name_TextChanged);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Location = new System.Drawing.Point(120, 4);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(100, 20);
            this.lastNameLabel.Text = "Last Name:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(4, 19);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(109, 21);
            this.firstNameTextBox.TabIndex = 4;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.Name_TextChanged);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Location = new System.Drawing.Point(4, 4);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(100, 20);
            this.firstNameLabel.Text = "First Name:";
            // 
            // fileAsLabel
            // 
            this.fileAsLabel.Location = new System.Drawing.Point(4, 47);
            this.fileAsLabel.Name = "fileAsLabel";
            this.fileAsLabel.Size = new System.Drawing.Size(100, 20);
            this.fileAsLabel.Text = "File As:";
            // 
            // tasksTabPage
            // 
            this.tasksTabPage.Controls.Add(this.notesTextBox);
            this.tasksTabPage.Controls.Add(this.notesLabel);
            this.tasksTabPage.Controls.Add(this.clearTaskButton);
            this.tasksTabPage.Controls.Add(this.addTaskButton);
            this.tasksTabPage.Controls.Add(this.reminderCheckBox);
            this.tasksTabPage.Controls.Add(this.reminderLabel);
            this.tasksTabPage.Controls.Add(this.importanceLabel);
            this.tasksTabPage.Controls.Add(this.importanceCombo);
            this.tasksTabPage.Controls.Add(this.dueLabel);
            this.tasksTabPage.Controls.Add(this.taskDueDatePicker);
            this.tasksTabPage.Controls.Add(this.subjectTextBox);
            this.tasksTabPage.Controls.Add(this.subjectLabel);
            this.tasksTabPage.Location = new System.Drawing.Point(0, 0);
            this.tasksTabPage.Name = "tasksTabPage";
            this.tasksTabPage.Size = new System.Drawing.Size(232, 245);
            this.tasksTabPage.Text = "Tasks";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(4, 139);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(229, 66);
            this.notesTextBox.TabIndex = 20;
            // 
            // notesLabel
            // 
            this.notesLabel.Location = new System.Drawing.Point(4, 119);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new System.Drawing.Size(100, 20);
            this.notesLabel.Text = "Notes:";
            // 
            // clearTaskButton
            // 
            this.clearTaskButton.Location = new System.Drawing.Point(161, 212);
            this.clearTaskButton.Name = "clearTaskButton";
            this.clearTaskButton.Size = new System.Drawing.Size(72, 20);
            this.clearTaskButton.TabIndex = 18;
            this.clearTaskButton.Text = "Clear";
            this.clearTaskButton.Click += new System.EventHandler(this.clearTaskButton_Click);
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(82, 212);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(72, 20);
            this.addTaskButton.TabIndex = 17;
            this.addTaskButton.Text = "Add";
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // reminderCheckBox
            // 
            this.reminderCheckBox.Location = new System.Drawing.Point(83, 92);
            this.reminderCheckBox.Name = "reminderCheckBox";
            this.reminderCheckBox.Size = new System.Drawing.Size(100, 20);
            this.reminderCheckBox.TabIndex = 8;
            // 
            // reminderLabel
            // 
            this.reminderLabel.Location = new System.Drawing.Point(4, 94);
            this.reminderLabel.Name = "reminderLabel";
            this.reminderLabel.Size = new System.Drawing.Size(100, 20);
            this.reminderLabel.Text = "Reminder:";
            // 
            // importanceLabel
            // 
            this.importanceLabel.Location = new System.Drawing.Point(4, 67);
            this.importanceLabel.Name = "importanceLabel";
            this.importanceLabel.Size = new System.Drawing.Size(76, 20);
            this.importanceLabel.Text = "Importance:";
            // 
            // importanceCombo
            // 
            this.importanceCombo.Items.Add("Low");
            this.importanceCombo.Items.Add("Normal");
            this.importanceCombo.Items.Add("High");
            this.importanceCombo.Location = new System.Drawing.Point(83, 63);
            this.importanceCombo.Name = "importanceCombo";
            this.importanceCombo.Size = new System.Drawing.Size(100, 22);
            this.importanceCombo.TabIndex = 4;
            // 
            // dueLabel
            // 
            this.dueLabel.Location = new System.Drawing.Point(4, 39);
            this.dueLabel.Name = "dueLabel";
            this.dueLabel.Size = new System.Drawing.Size(72, 19);
            this.dueLabel.Text = "Due:";
            // 
            // taskDueDatePicker
            // 
            this.taskDueDatePicker.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.taskDueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.taskDueDatePicker.Location = new System.Drawing.Point(83, 35);
            this.taskDueDatePicker.Name = "taskDueDatePicker";
            this.taskDueDatePicker.Size = new System.Drawing.Size(150, 22);
            this.taskDueDatePicker.TabIndex = 2;
            this.taskDueDatePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(83, 8);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(150, 21);
            this.subjectTextBox.TabIndex = 1;
            // 
            // subjectLabel
            // 
            this.subjectLabel.Location = new System.Drawing.Point(4, 8);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(100, 20);
            this.subjectLabel.Text = "Subject:";
            // 
            // appointmentsTabPage
            // 
            this.appointmentsTabPage.Controls.Add(this.appointmentNotesLabel);
            this.appointmentsTabPage.Controls.Add(this.appointmentNotesTextBox);
            this.appointmentsTabPage.Controls.Add(this.endDatePicker);
            this.appointmentsTabPage.Controls.Add(this.endsCheckBox);
            this.appointmentsTabPage.Controls.Add(this.endsLabel);
            this.appointmentsTabPage.Controls.Add(this.occursLabel);
            this.appointmentsTabPage.Controls.Add(this.occursCombo);
            this.appointmentsTabPage.Controls.Add(this.durationLabel);
            this.appointmentsTabPage.Controls.Add(this.durationCombo);
            this.appointmentsTabPage.Controls.Add(this.startLabel);
            this.appointmentsTabPage.Controls.Add(this.appointmentSubjectTextBox);
            this.appointmentsTabPage.Controls.Add(this.appointmentSubjectLabel);
            this.appointmentsTabPage.Controls.Add(this.startTimePicker);
            this.appointmentsTabPage.Controls.Add(this.startDatePicker);
            this.appointmentsTabPage.Controls.Add(this.clearAppointmentButton);
            this.appointmentsTabPage.Controls.Add(this.addAppointmentButton);
            this.appointmentsTabPage.Location = new System.Drawing.Point(0, 0);
            this.appointmentsTabPage.Name = "appointmentsTabPage";
            this.appointmentsTabPage.Size = new System.Drawing.Size(232, 245);
            this.appointmentsTabPage.Text = "Calendar";
            // 
            // appointmentNotesLabel
            // 
            this.appointmentNotesLabel.Location = new System.Drawing.Point(4, 165);
            this.appointmentNotesLabel.Name = "appointmentNotesLabel";
            this.appointmentNotesLabel.Size = new System.Drawing.Size(60, 14);
            this.appointmentNotesLabel.Text = "Notes:";
            // 
            // appointmentNotesTextBox
            // 
            this.appointmentNotesTextBox.Location = new System.Drawing.Point(69, 164);
            this.appointmentNotesTextBox.Multiline = true;
            this.appointmentNotesTextBox.Name = "appointmentNotesTextBox";
            this.appointmentNotesTextBox.Size = new System.Drawing.Size(164, 41);
            this.appointmentNotesTextBox.TabIndex = 35;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.endDatePicker.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(90, 135);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(139, 22);
            this.endDatePicker.TabIndex = 34;
            this.endDatePicker.Visible = false;
            // 
            // endsCheckBox
            // 
            this.endsCheckBox.Location = new System.Drawing.Point(69, 134);
            this.endsCheckBox.Name = "endsCheckBox";
            this.endsCheckBox.Size = new System.Drawing.Size(27, 20);
            this.endsCheckBox.TabIndex = 33;
            this.endsCheckBox.Visible = false;
            this.endsCheckBox.CheckStateChanged += new System.EventHandler(this.ends_CheckStateChanged);
            // 
            // endsLabel
            // 
            this.endsLabel.Location = new System.Drawing.Point(4, 138);
            this.endsLabel.Name = "endsLabel";
            this.endsLabel.Size = new System.Drawing.Size(60, 14);
            this.endsLabel.Text = "Ends:";
            this.endsLabel.Visible = false;
            // 
            // occursLabel
            // 
            this.occursLabel.Location = new System.Drawing.Point(4, 109);
            this.occursLabel.Name = "occursLabel";
            this.occursLabel.Size = new System.Drawing.Size(60, 14);
            this.occursLabel.Text = "Occurs:";
            // 
            // occursCombo
            // 
            this.occursCombo.Items.Add("Only Once");
            this.occursCombo.Items.Add("Daily");
            this.occursCombo.Items.Add("Weekly");
            this.occursCombo.Items.Add("Monthly");
            this.occursCombo.Items.Add("Yearly");
            this.occursCombo.Location = new System.Drawing.Point(69, 106);
            this.occursCombo.Name = "occursCombo";
            this.occursCombo.Size = new System.Drawing.Size(164, 22);
            this.occursCombo.TabIndex = 29;
            this.occursCombo.SelectedIndexChanged += new System.EventHandler(this.occurs_SelectedIndexChanged);
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(4, 80);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(60, 20);
            this.durationLabel.Text = "Duration:";
            // 
            // durationCombo
            // 
            this.durationCombo.Items.Add("15 Minutes");
            this.durationCombo.Items.Add("30 Minutes");
            this.durationCombo.Items.Add("1 Hour");
            this.durationCombo.Items.Add("1 1/2 Hours");
            this.durationCombo.Items.Add("2 Hours");
            this.durationCombo.Items.Add("2 1/2 Hours");
            this.durationCombo.Items.Add("3 Hours");
            this.durationCombo.Items.Add("4 Hours");
            this.durationCombo.Location = new System.Drawing.Point(69, 78);
            this.durationCombo.Name = "durationCombo";
            this.durationCombo.Size = new System.Drawing.Size(164, 22);
            this.durationCombo.TabIndex = 26;
            // 
            // startLabel
            // 
            this.startLabel.Location = new System.Drawing.Point(4, 31);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(100, 13);
            this.startLabel.Text = "Start:";
            // 
            // appointmentSubjectTextBox
            // 
            this.appointmentSubjectTextBox.Location = new System.Drawing.Point(54, 3);
            this.appointmentSubjectTextBox.Name = "appointmentSubjectTextBox";
            this.appointmentSubjectTextBox.Size = new System.Drawing.Size(179, 21);
            this.appointmentSubjectTextBox.TabIndex = 24;
            // 
            // appointmentSubjectLabel
            // 
            this.appointmentSubjectLabel.Location = new System.Drawing.Point(4, 7);
            this.appointmentSubjectLabel.Name = "appointmentSubjectLabel";
            this.appointmentSubjectLabel.Size = new System.Drawing.Size(100, 20);
            this.appointmentSubjectLabel.Text = "Subject:";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(120, 49);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(113, 22);
            this.startTimePicker.TabIndex = 22;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(4, 49);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(105, 22);
            this.startDatePicker.TabIndex = 21;
            // 
            // clearAppointmentButton
            // 
            this.clearAppointmentButton.Location = new System.Drawing.Point(161, 212);
            this.clearAppointmentButton.Name = "clearAppointmentButton";
            this.clearAppointmentButton.Size = new System.Drawing.Size(72, 20);
            this.clearAppointmentButton.TabIndex = 20;
            this.clearAppointmentButton.Text = "Clear";
            this.clearAppointmentButton.Click += new System.EventHandler(this.clearAppointmentButton_Click);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(82, 212);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(72, 20);
            this.addAppointmentButton.TabIndex = 19;
            this.addAppointmentButton.Text = "Add";
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.foldersTabControl);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "PPC Poom Sample";
            this.foldersTabControl.ResumeLayout(false);
            this.contactsTabPage.ResumeLayout(false);
            this.tasksTabPage.ResumeLayout(false);
            this.appointmentsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        private System.Windows.Forms.TabControl foldersTabControl;
        private System.Windows.Forms.TabPage contactsTabPage;
        private System.Windows.Forms.TabPage tasksTabPage;
        private System.Windows.Forms.TabPage appointmentsTabPage;
        private System.Windows.Forms.Label fileAsLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.ComboBox fileAsCombo;
        private System.Windows.Forms.Button clearContactButton;
        private System.Windows.Forms.Button addContactButton;
        private System.Windows.Forms.Label cellLabel;
        private System.Windows.Forms.Label workLabel;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.TextBox homePhoneTextBox;
        private System.Windows.Forms.TextBox cellPhoneTextBox;
        private System.Windows.Forms.TextBox workPhoneTextBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label dueLabel;
        private System.Windows.Forms.DateTimePicker taskDueDatePicker;
        private System.Windows.Forms.ComboBox importanceCombo;
        private System.Windows.Forms.CheckBox reminderCheckBox;
        private System.Windows.Forms.Label reminderLabel;
        private System.Windows.Forms.Label importanceLabel;
        private System.Windows.Forms.Button clearTaskButton;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.Button clearAppointmentButton;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.TextBox appointmentSubjectTextBox;
        private System.Windows.Forms.Label appointmentSubjectLabel;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.ComboBox durationCombo;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label occursLabel;
        private System.Windows.Forms.ComboBox occursCombo;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.CheckBox endsCheckBox;
        private System.Windows.Forms.Label endsLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.TextBox appointmentNotesTextBox;
        private System.Windows.Forms.Label appointmentNotesLabel;
        private System.Windows.Forms.MainMenu mainMenu1;
    }
}

