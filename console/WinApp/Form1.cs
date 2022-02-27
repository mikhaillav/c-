using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi;
                psi = new ProcessStartInfo("cmd", @$"/k echo off&{textBox1.Text}");
                Process.Start(psi);
                label3.Visible = true;
                label3.Text = "успех!";
                await Task.Delay(2000);
                label3.Visible = false;

            }
            catch
            {
                label3.Visible = true;
                label3.Text = "упсс... ошибка при запуске консоли(";
                await Task.Delay(2000);
                label3.Visible = false;
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("cmd"))
                {
                    try
                    {
                        proc.Kill();
                        label3.Visible = true;
                        label3.Text = "успех!";
                        await Task.Delay(2000);
                        label3.Visible = false;
                        break;
                    }
                    catch
                    {
                        label3.Visible = true;
                        label3.Text = "упсс... ошибка при закрытии консоли(";
                        await Task.Delay(2000);
                        label3.Visible = false;
                    }
                    

                }
            }
            catch
            {
                label3.Visible = true;
                label3.Text = "упсс... ошибка при обнаружении процесса консоли(";
                await Task.Delay(2000);
                label3.Visible = false;
            }
        }
    }
}
