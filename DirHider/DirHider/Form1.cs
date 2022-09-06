using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DirHider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"files\TextFile1.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (String line in lines)
            {
                listBox1.Items.Add(line);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path_ = textBox1.Text;

            string path = @"files\TextFile1.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            lines.Add(path_);
            File.WriteAllLines(path,lines);
            listBox1.Items.Clear();
            foreach (String line in lines)
            {
                listBox1.Items.Add(line);
            }

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("attrib +r +h +s " + path_);
            label1.Text = "File has been hide (Please F5)";
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path_ = textBox1.Text;

            string path = @"files\TextFile1.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                if (line == path_)
                {
                    lines.Remove(line);
                    break;
                }
            }

            File.WriteAllLines(path, lines);
            listBox1.Items.Clear();
            foreach (String line in lines)
            {
                listBox1.Items.Add(line);
            }

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.StandardInput.WriteLine("attrib -r -h -s " + path_);
            label1.Text = "File has been show (Please F5)";
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            textBox1.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
