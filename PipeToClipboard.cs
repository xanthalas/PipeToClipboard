/*****************************************************************************
/* Copyright (c) 2017 xanthalas.co.uk                                       */
/*                                                                          */
/* Author: Xanthalas                                                        */
/* Date  : May 2017                                                         */
/*                                                                          */
/*  This file is part of PipeToClipboard                                    */
/*                                                                          */
/*  PipeToClipboard is free software: you can redistribute it and/or modify */
/*  it under the terms of the GNU General Public License as published by    */
/*  the Free Software Foundation, either version 3 of the License, or       */
/*  (at your option) any later version.                                     */
/*                                                                          */
/*  PipeToClipboard is distributed in the hope that it will be useful,      */
/*  but WITHOUT ANY WARRANTY; without even the implied warranty of          */
/*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           */
/*  GNU General Public License for more details.                            */
/*                                                                          */
/*  You should have received a copy of the GNU General Public License       */
/*  along with PipeToClipboard.  If not, see <http://www.gnu.org/licenses/>.*/
/*                                                                          */
/****************************************************************************/
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Xanthalas
{
    public class PipeToClipboard
    {
        [STAThreadAttribute]
        public static void Main(string[] args)
        {
            string filter = String.Empty;

            if (args.Length == 1)
            {
                if (args[0] == "-h" || args[0] == "--help" || args[0] == "/?")
                {
                    Console.WriteLine("PipeToClipboard v 1.0 (c) Xanthalas 2017");
                    Console.WriteLine("\nReads stdin and copies the contents to the clipboard.\n");
                    Console.WriteLine("Usage: command | PipeToClipboard <filter>");
                    Console.WriteLine("For example: dir | PipeToClipboard .exe");
                    return;
                }
                else
                {
                    filter = args[0].ToLower();
                }
            }

            StringBuilder output = new StringBuilder(String.Empty);

            string line;

            while ((line = Console.ReadLine()) != null)
            {
                if (filter.Length > 0)
                {
                    if (line.ToLower().Contains(filter))
                    {
                        output.AppendLine(line);
                    }
                }
                else
                {
                    output.AppendLine(line);
                }
            }

            var finalString = output.ToString();

            if (finalString != null && finalString.Length > 0)
            {
                Clipboard.SetText(output.ToString());
            }

            //Console.WriteLine(output.ToString());
        }

    }
}