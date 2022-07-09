////////////////////////////////////////////////////////////////////////////////
/// 
/// Project:    Project 2
/// File Name: SplashScreen.Designer.cs
/// Description: Takes information from the user and stores it.
/// Course: CSCI 2210-001
/// Author: Raven Foster, fosterrn@etsu.edu
/// Created: October 15, 2019
/// Copyright: Raven Foster, 2019
/// 
////////////////////////////////////////////////////////////////////////////////

namespace Project2
{
    /// <summary>screen to appear at the start of the program and only last 3 seconds</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SplashScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SplashScreenTimer
            // 
            this.SplashScreenTimer.Enabled = true;
            this.SplashScreenTimer.Interval = 3000;
            this.SplashScreenTimer.Tick += new System.EventHandler(this.SplashScreenTimer_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Project2.Properties.Resources.PROJ2;
            this.ClientSize = new System.Drawing.Size(435, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>The splash screen timer</summary>
        private System.Windows.Forms.Timer SplashScreenTimer;
    }
}