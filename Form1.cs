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

namespace Abrir_apps_e_paginas
{
    public partial class Form1 : Form
    {
        String url;
        int i;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            label2.Visible = false;
            if (Isconnected())
            {
                textBox2.BackColor = Color.Green;
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "Conectado";
            }
            else
            {

                textBox2.BackColor = Color.Red;
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "Conectado";
            }
        }
       
        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        public static Boolean Isconnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            url = textBox1.Text;
            if (textBox1.Text != "")
            {
                if (i == 1)
                {
                    switch (comboBox1.Text)
                    {
                        case "Google Chrome":
                            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\Chrome.exe", url);
                            break;
                        case "Internt Explorer":
                            System.Diagnostics.Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", url);
                            break;
                        case "Opera Mini GX":
                            System.Diagnostics.Process.Start(@"C:\Users\guima\AppData\Local\Programs\Opera GX\launcher.exe", url);
                            break;
                        case "Microsoft Edge":
                            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", url);
                            break;
                        default:
                            MessageBox.Show("Tem algo de errado");
                            break;
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos");
            }
            
        }

        private void RBP_CheckedChanged(object sender, EventArgs e)
        {
            i = 0;
            comboBox1.Visible = false;
            label2.Visible = false;
        }

        private void RBS_CheckedChanged(object sender, EventArgs e)
        {
            i = 1;
            comboBox1.Visible = true;
            label2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
