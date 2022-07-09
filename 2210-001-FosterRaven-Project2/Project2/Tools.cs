//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// 
///    Project:     Project 2 - NameList GUI
///    File Name   Tools.cs
///    Description: holds methods to be able to help and assist in other files.
///     Course: CSCI 2210-001 - Data Structures
///     Author: Raven Foster, fosterrn@etsu.edu, Department of Computing, East Tennessee State University
///     Created:    3/12/2020
///     Copyright: Raven Foster, 2020
/// 
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;



namespace Project2
   
{
    /// <summary>
    /// A class of tools to edit list of strings and their delimiters.
    /// </summary>
    public static class Tools
    {

        /// <summary>
        /// Parameterized constructor: accepts a string and list of delimiters
        /// edits the sentence a returns it in a list
        /// </summary>
        /// <param name="Line">lines of strings</param>
        /// <param name="delims">delimiters in the sentences</param>
        /// <returns>list of edited strings</returns>
        public static List<String> Tokenize(String Line, String delims)
        {
            List<String> tookens = new List<String>();
            String Work = Line.Trim("\t".ToCharArray());

            while (!String.IsNullOrEmpty(Work))
            {
                int Col = Work.IndexOfAny(delims.ToCharArray());

                if (Col == -1)
                {
                    tookens.Add(Work);
                    break;
                }
                if (Col != 0)
                {
                    tookens.Add(Work.Substring(0, Col));
                }
                if (!String.IsNullOrWhiteSpace(Work[Col].ToString()))
                {
                    tookens.Add(Work[Col].ToString());
                }

                Work = Work.Substring(Col + 1, Work.Length - Col - 1);
            }

            return tookens;

        }
        /// <summary>
        /// Parameterized constructor: takes a list of strings and puts it
        /// into a sentence and returns a string of the sentences
        /// </summary>
        /// <param name="tookens">list of strings</param>
        /// <returns>string of formated sentences</returns>
        public static String Format(List<String> tookens)
        {
            String word = " ";
            bool perim = true;
            int num = 0;

            while (perim)
            {

                if (num < tookens.Count)
                {
                    if (word.Length <= 80)
                    {
                        word += tookens.ElementAt(num) + " ";
                        num++;
                    }
                    else
                    {
                        word += "\n";
                    }
                }
                else
                {
                    perim = false;
                }
            }
            return word;

        }


        /// <summary>  Validates the phone number of the user.</summary>
        /// <param name="phone">The phone.</param>
        /// <returns>True if valid</returns>
        public static bool phoneValid(string phone)
        {
            Regex phonePattern = new Regex(@"\d{10} | \d{7} | \d{3}-\d{3}-\d{4} |\d{3}-\d{4}");

            Match match = phonePattern.Match(phone);
            if(match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>  Validates the email of the user.</summary>
        /// <param name="Email">The email.</param>
        /// <returns>true if valid</returns>
        public static bool emailValid(string Email)
        {
            Regex emailPattern = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");

            Match match = emailPattern.Match(Email);
            if(match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
       
        /// <summary>
        /// Implements a welcome statement that welcomes the user
        /// </summary>
        public static string Welcome()
        {
            return "Welcome to the Name List program created by Raven Foster";
 

        }
        /// <summary>
        /// A program to say goodbye to the user and display their information
        /// </summary>
        public static string GoodBye(string name,string email, string phone)
        {

            return $"Goodbye! {name} look forward to us contacting you at your Email:{email} or Phone:{phone}";
        }

       
    }
}
