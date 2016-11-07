using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WordCounterSpace;

namespace WordCounterGUI
{
    public partial class WordCounterGUI : Form
    {
        public WordCounterGUI()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;
            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.Title = "Open Text File";

            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.Cancel && ofd.FileName != "")
                fileBox.Text = ofd.FileName;
        }

        private void countBtn_Click(object sender, EventArgs e)
        {
            string file = fileBox.Text;
            string text = "";
            try
            {
                StreamReader sr = new StreamReader(file);
                text = sr.ReadToEnd();

                WordCounter counter = new WordCounter();
                string NL = Environment.NewLine;
                textBox.Text =
                    "Original text:" + NL +
                    text + NL +
                    NL +
                     "Count:" + NL +
                    counter.count(text);
            }
            catch(FileNotFoundException)
            {
                // File is not found
                MessageBox.Show("The file was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Text = "";
            }
            catch (UnauthorizedAccessException)
            {
                // You don't have acces to this file
                MessageBox.Show("You don't have acces to this file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Text = "";
            }
            catch
            { 
                // Some error!
                MessageBox.Show("Something is not right!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Text = "";
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileBox_TextChanged(object sender, EventArgs e)
        {
            if(fileBox.Text == "")
                countBtn.Enabled = false;
            else
                countBtn.Enabled = true;
        }
    }
}
