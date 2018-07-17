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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

/// <summary>
/// This sample demonstrates how to use the System.Text.Encoding class to
/// safely convert text files between two encodings.
/// </summary>

namespace Microsoft.Samples.EncodingConverter
{

	class encodingConverter
	{
		private static bool IsSilent;
		private static string inputFile, outputFile;
		private static string userInputCodepage, userOutputCodepage;
		private static string tempFile = "encconv.tmp";

		static void Main(string[] args)
		{
			try
			{
				// Restrict input to between one and five parameters.
				if ((args.Length == 0) | (args.Length > 5))
				{
					ShowInstructions();
					return;
				}
				else if (args.Length == 1)
				{
					if (args[0] == "-l")
					{
						GetEncodingList();
						return;
					}
				}
				else if ((args.Length >= 4))
				{
					userInputCodepage = args[0];
					inputFile = args[1];
					userOutputCodepage = args[2];
					outputFile = args[3];
					if (args.Length > 4)
					{
						if (args[4] == "-s")
						{
							// Omit all non-error messages from console output.
							IsSilent = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine
					("Operation cancelled due to the following error:");
				Console.WriteLine
					("-----------------------------------------------");
				Console.WriteLine(ex.Message);
			}

			try
			{
				// Cast the strings as encodings and perform the conversion.
				// Use ExceptionFallback parameters to prevent character loss.
				ChangeEncoding(Encoding.GetEncoding(userInputCodepage,
					EncoderFallback.ExceptionFallback,
					DecoderFallback.ExceptionFallback),
					Encoding.GetEncoding(userOutputCodepage,
					EncoderFallback.ExceptionFallback,
					DecoderFallback.ExceptionFallback));
			}
			catch (Exception ex)
			{
				File.Delete(tempFile);
				Console.WriteLine
					("Operation cancelled due to the following error:");
				Console.WriteLine
					("-----------------------------------------------------");
				Console.WriteLine(ex.Message);
			}
		}

		static void ShowInstructions()
		{
			Console.WriteLine
				("Description: Converts text files between specified encodings.");
			Console.WriteLine
				("Usage: encconv [input enc] [input file] [output enc] [output file] {-s}");
			Console.WriteLine
				("Ex: encconv shift_jis japanese.txt utf-8 unicode.txt -s");
			Console.WriteLine("");
			Console.WriteLine("Input options:");
			Console.WriteLine
				("  [input enc]  Read from source file using specified encoding");
			Console.WriteLine("");
			Console.WriteLine("Output options:");
			Console.WriteLine
				("  [output enc] Write to target file using specified encoding");
			Console.WriteLine("");
			Console.WriteLine("Other options:");
			Console.WriteLine
				("  -s          Suppress warning and information messages");
			Console.WriteLine
				("  -l          List supported encodings");
			Console.WriteLine("");
			Console.WriteLine
				("Warning: Converting files either to or between non-Unicode ");
			Console.WriteLine
				("encodings may cause character data to be lost.");
		}

		static void GetEncodingList()
		{
			EncodingInfo[] EncodingsList = Encoding.GetEncodings();
			Console.WriteLine("Encoding Name and Display Name");
			Console.WriteLine("------------------------------");
			foreach (EncodingInfo enc in EncodingsList)
			{
				// Output the encoding name and language for each codepage
				Console.WriteLine(enc.Name + 
					CultureInfo.CurrentCulture.TextInfo.ListSeparator +
					" " + enc.DisplayName);
			}
		}

		static void ChangeEncoding(Encoding SourceEncoding,
			Encoding TargetEncoding)
		{
			string tempString;
			// Create StreamReader object based on input file and encoding.
			StreamReader sr = new StreamReader(inputFile,
				SourceEncoding, true);
			// Create StreamWriter object based on output file and encoding.
			// Write to temporary file in case input and output files are same
			// name.
			StreamWriter sw = new StreamWriter(tempFile, false,
				TargetEncoding);
			// Read input file contents into temporary string object.
			tempString = sr.ReadToEnd();
			sr.Close();
			// Write output file from temporary string object.
			sw.WriteLine(tempString);
			sw.Close();

			if (outputFile == inputFile)
			{			
				if (IsSilent == false)
				{
					Console.WriteLine
						("Are you sure you want to overwrite the file '{0}'? (Y/N)",
						inputFile);
					// Perform case-insensitive comparison of input value.
					if (String.Compare("Y", Console.ReadLine(), true,
						CultureInfo.InvariantCulture) == 0)
					{
							// Input value matched, so delete source file to allow
							// temporary file renaming.
							File.Delete(inputFile);
						}
						else
						{
							File.Delete(tempFile);
							Console.WriteLine("Operation cancelled.");
							return;
						}
					}
					else
					{
						// Running in silent mode, so delete the source file
						// without showing warning message.
						File.Delete(inputFile);
					}
				}

				// Create new file using name specified for output file.
				File.Move(tempFile, outputFile);
				if (IsSilent == false)
				{
					Console.WriteLine("Converted '{0}' from {1} to {2}.",
						inputFile, SourceEncoding.EncodingName,
						TargetEncoding.EncodingName);
				}	
		}
	}
}