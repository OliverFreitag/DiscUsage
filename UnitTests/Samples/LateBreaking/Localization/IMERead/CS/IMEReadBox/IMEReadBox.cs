//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
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
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace IMEReadingStringBox
{
    public partial class IMEReadingStringBox : System.Windows.Forms.TextBox
    {
        /// <summary>
        /// Custom TextBox control
        /// </summary>
        public IMEReadingStringBox()
        {
            InitializeComponent();
        }
        /// <summary>
        ///     Occurs when the value of the ReadingString property has changed
        /// </summary>
        [Category("Default")]
        public event EventHandler ReadingStringChanged;
        private string clauseReadingString;
        private string readingString = "";
        public string ReadingString
        {
            get
            {
                return readingString;
            }
        }


        // Declaration to call Win32 API.
        [System.Runtime.InteropServices.DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr ImmGetContext(IntPtr Hwnd);
        [System.Runtime.InteropServices.DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        static extern int ImmGetCompositionString(IntPtr Himc, uint Index, byte[] Buffer, uint BufLen);

        // Constants defined in Imm.h
        const int WM_IME_COMPOSITION = 0x010f;
        const int GCS_RESULTREADSTR = 0x0200;

        // Called when receiving WM_IME_COMPOSITION message.
        private void OnImeComposition(Message m)
        {
            // Skip messages unless resulted reading string is updated.
            if (((int)m.LParam & GCS_RESULTREADSTR) != 0)
            {
                IntPtr context = ImmGetContext(this.Handle);
                int size = ImmGetCompositionString(context, GCS_RESULTREADSTR, null, 0);
                byte[] buffer = new byte[size];

                // Retrieve reading string from IME
                size = ImmGetCompositionString(context, GCS_RESULTREADSTR, buffer, (uint)size);
                clauseReadingString = new System.Text.UnicodeEncoding().GetString(buffer, 0, size);

                // Update ReadingString property
                readingString += clauseReadingString;

                // Notify change of ReadingString property
                OnReadingStringChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Raises the ReadingStringChanged event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected virtual void OnReadingStringChanged(EventArgs e)
        {
            if (ReadingStringChanged != null)
            {
                ReadingStringChanged(this, e);
            }
        }

        // Override WndProc to process WM_IME_COMPOSITION message.
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_IME_COMPOSITION:
                    OnImeComposition(m);
                    break;
            }
            DefWndProc(ref m);
        }
    }
}
