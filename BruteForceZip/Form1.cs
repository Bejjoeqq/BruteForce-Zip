using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace BruteForceRar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string azup = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string azlw = "abcdefghijklmnopqrstuvwxyz";
        private string numb = "0123456789";
        private string symb = "!@#$%^&*()-_=+{[}]|:;<>,.?/";
        private string area = "";
        string[] custm;

        private static string zipFile = "";
        private string targetDirectory = "";
        ZipFile zip;
        private string text = "";
        private string texttotal = "";
        private int x = 0;
        private int last = 0;
        private void cstmForce()
        {
            foreach(string x in custm)
            {
                Console.WriteLine(x);
                try
                {
                    if (ZipFile.CheckZipPassword(zipFile, x))
                    {
                        zip.Password = x;
                        zip.ExtractAll(targetDirectory, ExtractExistingFileAction.DoNotOverwrite);
                        MessageBox.Show("Extracted !", ":)");
                        Console.WriteLine("Password : " + x);
                        Console.WriteLine("Press enter to exit ...");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
                catch
                {
                }
            }
        }
        private void bruteForce(int xx)
        {
            if (x == xx)
            {
                foreach(char chrx in area)
                {
                    texttotal = text + chrx;
                    Console.WriteLine(texttotal);
                    try
                    {
                        if (ZipFile.CheckZipPassword(zipFile, texttotal))
                        {
                            zip.Password = texttotal;
                            zip.ExtractAll(targetDirectory, ExtractExistingFileAction.DoNotOverwrite);
                            MessageBox.Show("Extracted !", ":)");
                            Console.WriteLine("Password : " + texttotal);
                            Console.WriteLine("Press enter to exit ...");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                xx--;
                foreach(char chrx in area)
                {
                    text += chrx;
                    bruteForce(xx);
                    text = text.Substring(0, text.Length - 1);
                }
            }
        }
        private void extract()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                area += azlw;
            }
            if(checkBox1.Checked)
            {
                area += azup;
            }
            if(checkBox3.Checked)
            {
                area += numb;
            }
            if(checkBox4.Checked)
            {
                area += symb;
            }
            AllocConsole();
            if (textBox3.Text == "")
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    bruteForce(i);
                }
            }
            else
            {
                cstmForce();
            }
            if (last == 0)
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
                {
                    if (textBox3.Text != "")
                    {
                        Console.WriteLine("Password not found");
                    }
                    else
                    {
                        Console.WriteLine("Please select an Area");
                    }
                }
                else
                {
                    Console.WriteLine("Password not found");
                }
                Console.WriteLine("Press enter to exit ...");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value.ToString() == "0" || textBox1.Text == "" || textBox2.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "ZIP Folder (*.zip)|*.zip";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zipFile = dlg.FileName;
                textBox1.Text = zipFile;
                zip = ZipFile.Read(zipFile);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                targetDirectory = fbd.SelectedPath;
                textBox2.Text = targetDirectory;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && numericUpDown1.Value.ToString() != "0")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "" && numericUpDown1.Value.ToString() != "0")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            numericUpDown1.Enabled = false;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Documents (*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dlg.FileName;
                custm = File.ReadAllLines(dlg.FileName, Encoding.UTF8);
            }
        }
    }
}
