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
namespace Microsoft.Samples.ComCallback.BankClient
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.balanceTextBox = new System.Windows.Forms.TextBox();
            this.depositButton = new System.Windows.Forms.Button();
            this.withdrawalButton = new System.Windows.Forms.Button();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.transactionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // balanceLabel
            // 
            this.balanceLabel.Location = new System.Drawing.Point(19, 221);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Text = "Current Balance:";
            // 
            // balanceTextBox
            // 
            this.balanceTextBox.Location = new System.Drawing.Point(126, 221);
            this.balanceTextBox.Name = "balanceTextBox";
            this.balanceTextBox.ReadOnly = true;
            this.balanceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.balanceTextBox.Size = new System.Drawing.Size(100, 21);
            this.balanceTextBox.TabIndex = 1;
            // 
            // depositButton
            // 
            this.depositButton.Location = new System.Drawing.Point(19, 88);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(85, 20);
            this.depositButton.TabIndex = 2;
            this.depositButton.Text = "Deposit";
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // withdrawalButton
            // 
            this.withdrawalButton.Location = new System.Drawing.Point(126, 88);
            this.withdrawalButton.Name = "withdrawalButton";
            this.withdrawalButton.Size = new System.Drawing.Size(85, 20);
            this.withdrawalButton.TabIndex = 3;
            this.withdrawalButton.Text = "Withdraw";
            this.withdrawalButton.Click += new System.EventHandler(this.withdrawalButton_Click);
            // 
            // amountLabel
            // 
            this.amountLabel.Location = new System.Drawing.Point(4, 16);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(165, 20);
            this.amountLabel.Text = "Enter Transaction Amount:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(163, 15);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.amountTextBox.Size = new System.Drawing.Size(74, 21);
            this.amountTextBox.TabIndex = 6;
            this.amountTextBox.Text = "25";
            // 
            // transactionLabel
            // 
            this.transactionLabel.Location = new System.Drawing.Point(4, 61);
            this.transactionLabel.Name = "transactionLabel";
            this.transactionLabel.Size = new System.Drawing.Size(115, 20);
            this.transactionLabel.Text = "Select Transaction";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.transactionLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.withdrawalButton);
            this.Controls.Add(this.depositButton);
            this.Controls.Add(this.balanceTextBox);
            this.Controls.Add(this.balanceLabel);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Com Callback Sample";
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.TextBox balanceTextBox;
        private System.Windows.Forms.Button depositButton;
        private System.Windows.Forms.Button withdrawalButton;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label transactionLabel;
    }
}

