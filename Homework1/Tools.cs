////////////////////////////////////////////////////////////////////////////////
/// 
/// Project:   Homework 1
/// File Name: Tools.cs
/// Description: Contains static methods. To be used in serveral projects.
/// Course: CSCI 2210-001
/// Author: Raven Foster, fosterrn@etsu.edu
/// Created: February 16, 2020
/// Copyright: Raven Foster, 2020
/// 
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{   /// <summary>
    /// Implements the tokenize method and format Text method.
    /// </summary>
    class Tools
    {   /// <summary>
    /// Parameterized method that tokenizes a sentence and 
    /// places it into a list of strings.
    /// </summary>
    /// <param name="Line">A line of text to be tokenized</param>
    /// <param name="delimeter"> delimeters such as puncuation marks that are taken out of the list of strings</param>
    /// <returns>A list of tokenized tokens </returns>
        public static String[] Tokenize(String Line, String delimeter)
        {
            List<String> Tokens = new List<String>();
            String Delims = Line.Trim("\t".ToCharArray());

            while (!String.IsNullOrEmpty(Delims))
            {
                int Col = Delims.IndexOfAny(delimeter.ToCharArray());

                if (Col == -1)
                {
                    if(!String.IsNullOrWhiteSpace(Delims))
                    {
                        Tokens.Add(Delims);
                        break;
                    }
                    
                }
                if (Col != 0)
                {
                    Tokens.Add(Delims.Substring(0, Col));
                }
                if (!String.IsNullOrWhiteSpace(Delims[Col].ToString()))
                {
                    Tokens.Add(Delims[Col].ToString());
                }

                Delims = Delims.Substring(Col + 1, Delims.Length - Col - 1);
            }

            return Tokens.ToArray();

        }
        /// <summary>
        /// formats texts
        /// </summary>
        /// <param name="text">original text to be formatted</param>
        /// <param name="leftMargin">text formatting</param>
        /// <param name="rightMargin">text formatting</param>
        /// <returns></returns>
        public static string formatText(string text, int leftMargin = 0, int rightMargin = 80)
        {
            return text.PadLeft(rightMargin).PadLeft(rightMargin);
            
        }
    }
}
