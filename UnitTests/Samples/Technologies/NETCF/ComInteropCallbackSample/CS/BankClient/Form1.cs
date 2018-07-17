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
using System.Collections;
using System.Windows.Forms;
using System.Data;
using BankObjectsLib;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Microsoft.Samples.ComCallback.BankClient
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;

        // private variables to store instances of the Account Com Object
        // and our object that receives the callback.
        private Account accountComObject;
        private AccountChangedNotification accountNotify;

        private const int initialBalance = 1000;

        // Custom HRESULTS for erroroneous transactions
        private const int ERROR_INSUFFICIENT_FUNDS  = unchecked((int)0x80041000);
        private const int ERROR_INVALID_TRANSACTION = unchecked((int)0x80041001);

        public Form1()
        {
            InitializeComponent();

            // Create an instance of the Account Com Object
            accountComObject = new Account();

            // Create an instance of our AccountChangedNotification object
            // and pass it to the Account Com Object.  The Account
            // object will call our implementation of IAccountChanged
            // whenever a deposit or withdrawl is made.
            accountNotify = new AccountChangedNotification();
            accountNotify.AccountChanged += new AccountChangedNotification.AccountChangedEventHandler(AccountChangedMsg);

            accountComObject.Initialize(initialBalance, (IAccountCallback)accountNotify);

        }

        // Called when the notification object fires the event indicating that the account balance
        // has been changed.  Update the balance field in the user interface with the new balance.
        private void AccountChangedMsg(Object sender, AccountChangedEventArgs args)
        {
            balanceTextBox.Text = args.NewBalance.ToString(CultureInfo.InvariantCulture);
        }

        // Call the Account Com Object to record a deposit.
        private void depositButton_Click(object sender, EventArgs e)
        {
            // Catch all instances of COMException to help 
            // diagnose failures that occur when calling the
            // Account Com Object.
            try
            {
                accountComObject.Deposit(Convert.ToInt32(amountTextBox.Text,CultureInfo.InvariantCulture));
            }
            catch (COMException cex)
            {
                if (cex.ErrorCode == ERROR_INVALID_TRANSACTION)
                    MessageBox.Show("Invalid deposit amount.  Please enter a value greater than 0");
                else
                    MessageBox.Show("General error occurred while performing deposit: " + cex.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format(CultureInfo.InvariantCulture, "\"{0}\" is not a valid Transaction Amount", amountTextBox.Text));
            }
            catch (OverflowException)
            {
                MessageBox.Show(String.Format(CultureInfo.InvariantCulture, "\"{0}\" is not a valid Transaction Amount", amountTextBox.Text));
            }
        }

        // Call the Bank Com Object to record a withdrawal.
        private void withdrawalButton_Click(object sender, EventArgs e)
        {
            // Catch all instances of COMException to help 
            // diagnose failures that occur when calling the
            // Account Com Object.
            try
            {
                accountComObject.Withdraw(Convert.ToInt32(amountTextBox.Text, CultureInfo.InvariantCulture));
            }
            catch (COMException cex)
            {
                if (cex.ErrorCode == ERROR_INVALID_TRANSACTION)
                    MessageBox.Show("Invalid withdrawal amount.  Please enter a value greater than 0");
                else if (cex.ErrorCode == ERROR_INSUFFICIENT_FUNDS)
                    MessageBox.Show("Not enough funds are available to complete the withdrawal");
                else
                    MessageBox.Show("General error occurred while performing withdrawal: " + cex.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format(CultureInfo.InvariantCulture, "\"{0}\" is not a valid Transaction Amount", amountTextBox.Text));
            }
            catch (OverflowException)
            {
                MessageBox.Show(String.Format(CultureInfo.InvariantCulture, "\"{0}\" is not a valid Transaction Amount", amountTextBox.Text));
            }
        }

    }


    // This object implements the callback interface that the Account
    // Com object uses to send notification that the account balance
    // has changed.  The IAccountCallback interface is defined in the
    // interop assembly generated from the BankObjects type library.  This
    // class defines an event (AccountChanged) that is raises whenever it is 
    // notified that the balance has changed.  The main form registers for
    // the AccountChanged event in order to display the new balance in the
    // user interface.
    public class AccountChangedNotification : IAccountCallback
    {

        public delegate void AccountChangedEventHandler(Object sender, AccountChangedEventArgs e);

        public event AccountChangedEventHandler AccountChanged;

        // BalanceChanged is called by the Account Com object
        // whenever the balance of the account has been changed.
        // Fire the AccountChanged event to notify the main form
        // that the balance has changed.
        public void BalanceChanged(int newBalance)
        {
            AccountChangedEventArgs args = new AccountChangedEventArgs(newBalance);

            if (AccountChanged != null)
                AccountChanged(this, args);
        }
    }

    // The event args for the AccountChanged event.  These
    // arguments are used by the main form to receive the
    // new account balance.
    public class AccountChangedEventArgs : EventArgs
    {
        private int newBalance;

        public AccountChangedEventArgs(int balance)
        {
            newBalance = balance;
        }

        public int NewBalance
        {
            get { return newBalance; }
        }
    }
}

