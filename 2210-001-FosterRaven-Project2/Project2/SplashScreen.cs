//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// 
///    Project:     Project 2 - NameList GUI
///    File Name   SplashScreen.cs
///    Description: Displays an image for a couple seconds when the program first starts
///     Course: CSCI 2210-001 - Data Structures
///     Author: Raven Foster, fosterrn@etsu.edu, Department of Computing, East Tennessee State University
///     Created:    3/12/2020
///     Copyright: Raven Foster, 2020
/// 
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    /// <summary>Displays an image for a couple seconds when the program first starts</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SplashScreen : Form
    {
        /// <summary>Initializes a splash screen/&gt; class.</summary>
        public SplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>Loads a splash screen.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        /// <summary>Timer for splash screen.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SplashScreenTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
