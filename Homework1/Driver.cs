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
using Tools;

namespace Homework1
{
    /// <summary>Runs the driver code.</summary>
    class Driver
    {
        /// <summary>Defines the entry point of the application.
        /// Runs the code in the driver.</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "CSCI 2210 - Data Structures: Classwork 1 by Raven Foster";

            Console.WriteLine("Enter text to be processed.");
            String userInput = Console.ReadLine();
            String[] outPut = Tools.Tools.Tokenize(userInput, " .,?!-");

            for (int i = 0; i < outPut.Length; i++)
            {
                Console.WriteLine($"{i+1}.{outPut[i]}");
            }

            Console.ReadLine();
            
        }
    }
}
