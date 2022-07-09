/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///        
///     Project:    Project 2 - NameList Forum
///     File Name:  NameListForm.cs
///     Description:  holds methods to operate the name list forum
///     Course:     CSCI 2210-001 - Data Structures
///     Author:     Raven Foster, fosterrn@etsu.edu, Department of computing, East Tennessee State University
///     Created:    3/12/2020
///     Copyright:  Raven Foster, 2020
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    /// <summary>holds methods to operate the name list forum</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NameListForum : Form
    {
        public NameList ListOfName = new NameList();
        public bool Changed = false;
        public String Edited = "";
        public bool Changer = false;
        /// <summary>Initializes the name list forum.</summary>
        public NameListForum()
        {

            InitializeComponent();
            CountStatus.Text = $"Name in the list: {ListOfName.Count}";
        }

        /// <summary>creates an open file dialog for the tool strip.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Application.StartupPath + @"..\..\DataFiles";
            dlg.Filter = "text files|*.txt;*.text";

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;

            Name toBeAdded = null;

            try
            {

                StreamReader reader = new StreamReader(dlg.FileName);
                while (reader.Peek() != -1)
                {
                    string[] fields = reader.ReadLine().Split('|');
                    toBeAdded = new Name(fields[0]);
                    ListOfName = ListOfName + toBeAdded;
                }

                dlg.Dispose();

                ListBox(Changed);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error has occurred!");
            }
        }

        /// <summary>uploads names into list box</summary>
        /// <param name="chang">if true names in list box have been changed</param>
        private void ListBox(bool chang)
        {
            NameListBox.Items.Clear();
            if (Changer == false)
            {
                List<String> trial = ListOfName.SortedLast();
                for (int i = 0; i < ListOfName.Count; i++)
                {
                    NameListBox.Items.Add(ListOfName[i].FormatLast());
                }
            }
            else
            {
                for (int i = 0; i < ListOfName.Count; i++)
                {
                    NameListBox.Items.Add(ListOfName[i].FormatFirstLast());
                }
            }

            CountStatus.Text = $"Name in the list: {ListOfName.Count}";
        }

        /// <summary>fills the text boxes when you select a name with there rest of name, last name and suffix.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OriginalBox.Text = ListOfName[NameListBox.SelectedIndex].Name1;
                RestBox.Text = ListOfName[NameListBox.SelectedIndex].RestOfName;
                LastBox.Text = ListOfName[NameListBox.SelectedIndex].LastName;
                SuffixBox.Text = ListOfName[NameListBox.SelectedIndex].Suffix;
            }
            catch(Exception)
            {
                //nothing
            }
        }

        /// <summary>control button that switches names from last first to first last</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SwitchButton_Click(object sender, EventArgs e)
        {
            
            if(Changer == false)
            {
                Changer = true;
                ListBox(Changer);
                SwitchButton.Text = "Switch to last name first";
            }
            else
            {
                Changer = false;
                ListBox(Changer);
                SwitchButton.Text = "Switch to first name first";

            }
        }

        /// <summary>Controls the date and time label on the status strip</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateStatus.Text = DateTime.Now.ToString("MM/dd/yy H:mm:ss");
        }

        /// <summary>Adds a name to the list</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Name newName = new Name("Blank Name");
            ListOfName += newName;
            ListBox(Changer);
            Changed = true;
        }

        /// <summary>Deletes a name from the list.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeleteNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListOfName = ListOfName - (NameListBox.SelectedIndex + 1);
                ListBox(Changer);
                Changed = true;
            }
            catch(Exception)
            {
                //nothing
            }
        }

        /// <summary>Edits the selected name when clicked on. It then changes when you click off of it.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OriginalBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!Edited.Equals(OriginalBox.Text))
                {
                    ListOfName = ListOfName - (NameListBox.SelectedIndex + 1);
                    Name newName = new Name(OriginalBox.Text);
                    ListOfName = ListOfName + newName;
                    ListBox(Changer);
                    Changed = true;
                }
            }
            catch(Exception)
            {
                //nothing
            }
        }

        /// <summary>allows the user to save in a text file.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = Application.StartupPath;
            save.Title = "Don't forget to save!";
            save.Filter = "text files (*.txt)|*.txt|text files(*.text)|*.text";

            if (save.ShowDialog() == DialogResult.Cancel)
                return;

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(new FileStream(save.FileName, FileMode.Create, FileAccess.Write));
                for (int i = 0; i < ListOfName.Count; i++)
                {
                    Name nam = ListOfName[i];
                    writer.WriteLine(nam.Name1 + '|');
                }


            }
            catch
            {
                Console.WriteLine("An Error has occurred.");
                Console.ReadLine();
                Application.Exit();

            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>Reminds users to save before closing.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remember to save!!!");

            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = Application.StartupPath;
            save.Title = "Don't forget to save!";
            save.Filter = "text files (*.txt)|*.txt|text files(*.text)|*.text";

            if (save.ShowDialog() == DialogResult.Cancel)
                return;

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(new FileStream(save.FileName, FileMode.Create, FileAccess.Write));
                for (int i = 0; i < ListOfName.Count; i++)
                {
                    Name nam = ListOfName[i];
                    writer.WriteLine(nam.Name1 + '|');
                }


            }
            catch
            {
                Console.WriteLine("An Error has occurred.");
                Console.ReadLine();
                Application.Exit();

            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

            this.Close();
        }


        /// <summary>  Displays the about box.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        /// <summary>
        /// Handles the Enter event of the OriginalBox control.
        /// Controls if someone hits enter in the original box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OriginalBox_Enter(object sender, EventArgs e)
        {
            Edited = OriginalBox.Text;
        }

       
    }
}
