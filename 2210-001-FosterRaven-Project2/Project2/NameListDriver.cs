/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///        
///     Project:    Project 2 - NameList Forum
///     File Name:  NameListDriver.cs
///     Description:  Runs the Windows forum and Splash screen
///     Course:     CSCI 2210-001 - Data Structures
///     Author:     Raven Foster, fosterrn@etsu.edu, Department of computing, East Tennessee State University
///     Created:    3/12/2020
///     Copyright:  Raven Foster, 2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    /// <summary>Runs the Windows forum and Splash screen</summary>
    static class NameListDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
            Application.Run(new NameListForum());
        }
    }
}
