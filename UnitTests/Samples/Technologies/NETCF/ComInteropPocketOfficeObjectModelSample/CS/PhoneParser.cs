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

#region Using directives

using System;
using System.Text;
using System.Collections;
using System.Globalization;

#endregion

namespace Microsoft.Samples.POOMComInterop
{
    // PhoneParser is a utility class used to parse a Contact's 
    // phone numbers as they are entered.
    static class  PhoneParser
    {

        private static string GetDigits(char[] digits, int skip, int count)
        {
            if (digits.Length <= skip)
            {
                return null;
            }

            else if (digits.Length < skip + count)
            {
                return new String(digits, 0, digits.Length - skip);
            }

            else
            {
                return new String(digits, digits.Length - (skip + count), count);
            }
        }

        public static string ParseText(string text)
        {
            char[] chars = text.ToCharArray();
            ArrayList digits = new ArrayList();
            string internalText;

            foreach (char c in chars)
            {
                if (Char.IsDigit(c))
                {
                    digits.Add(c);
                }
            }

            char[] NumberDigits = (char[])digits.ToArray(typeof(char));

            string ExtraDigits = GetDigits(NumberDigits, 10, 5);
            string AreaCode = GetDigits(NumberDigits, 7, 3);
            string Prefix = GetDigits(NumberDigits, 4, 3);
            string Number = GetDigits(NumberDigits, 0, 4);

            if (ExtraDigits != null)
            {
                internalText = String.Format(CultureInfo.InvariantCulture, "{0}({1}){2}-{3}", ExtraDigits, AreaCode, Prefix, Number);
            }
            else if (AreaCode != null)
            {
                internalText = String.Format(CultureInfo.InvariantCulture, "({0}){1}-{2}", AreaCode, Prefix, Number);
            }
            else if (Prefix != null)
            {
                internalText = String.Format(CultureInfo.InvariantCulture, "{0}-{1}", Prefix, Number);
            }
            else if (Number != null)
            {
                internalText = String.Format(CultureInfo.InvariantCulture, "{0}", Number);
            }
            else
            {
                internalText = "";
            }

            return internalText;
        }
    }
}
