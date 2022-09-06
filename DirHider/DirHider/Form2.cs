using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DirHider
{
    public partial class Form2 : Form
    {
        Thread th;
        public Form2()
        {
            InitializeComponent();
        }
       
        public void openForm()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"files\TextFile2.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();

            if (textBox1.Text == lines[0] && textBox2.Text == lines[1])
            {
                this.Close();
                th = new Thread(openForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"files\TextFile2.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();


            string path2 = @"files\TextFile3.txt";
            List<string> lines2 = new List<string>();
            lines2 = File.ReadAllLines(path2).ToList();

            string answer = Interaction.InputBox(lines2[0], "Private Question");
            if (answer == lines2[1])
            {
                MessageBox.Show("username = " + lines[0] + "\npassword = " + lines[1]);
            }
            else
            {
                MessageBox.Show("wrong answer");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = @"files\TextFile2.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();


            string path2 = @"files\TextFile3.txt";
            List<string> lines2 = new List<string>();
            lines2 = File.ReadAllLines(path2).ToList();

            string answer = Interaction.InputBox(lines2[0], "Private Question");
            if (answer == lines2[1])
            {
                string answer1 = Interaction.InputBox("Enter Your New Username", "Username");
                string answer2 = Interaction.InputBox("Enter Your New Password", "Password");
                string answer3 = Interaction.InputBox("Enter Your New Question", "Question");
                string answer4 = Interaction.InputBox("Enter Your New Answer", "Answer");

                if (answer1 == "" || answer2 == "" || answer3 == "" || answer4 == "")
                {

                }
                else
                {
                    lines[0] = answer1;
                    lines[1] = answer2;
                    lines2[0] = answer3;
                    lines2[1] = answer4;

                    File.WriteAllLines(path, lines);
                    File.WriteAllLines(path2, lines2);

                }
            }
            else
            {
                MessageBox.Show("wrong answer");
            }
        }
    }
}
