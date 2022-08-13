using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace CafeCafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            // Se inician los eventos de sistema
            this.SizeChanged += new EventHandler(form1_sizeeventhandler);
            this.notifyIcon1.Click += new EventHandler(notifyIcon1_Click);
        }

        private void form1_sizeeventhandler(object sender, EventArgs e)

        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SimuladorTecla.F15Key();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.activar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.desactivar();
        }

        private void activar()
        {
            timer1.Interval = 6000; //Un minuto
            timer1.Start();
            this.Text = "Café-Café  --Activado--";
            this.notifyIcon1.Text = "Café-Café Activado";
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            this.button1.Enabled = false;
        }

        private void desactivar()
        {
            timer1.Stop();
            this.Text = "Café-Café  --Desactivado--";
            this.notifyIcon1.Text = "Café-Café Desactivado";
            this.button1.Enabled = true;
        }

        private void apagar(int minutos)
        {
            Process.Start("shutdown", $"/s /t {minutos * 60}"); // El argumento /s indica que es un apagado. El argumento /t indica el tiempo en segundos. 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxMinutos_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxMinutos.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor ingrese solo números.");
                textBoxMinutos.Text = textBoxMinutos.Text.Remove(textBoxMinutos.Text.Length - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int minutos = int.Parse(textBoxMinutos.Text);
            
            if (minutos > 0)
            {
                MessageBox.Show($"El equipo se apagará en {minutos} minuto/s...");
                this.Text = "Café-Café  --Apagado programado--";
                this.notifyIcon1.Text = "Café-Café -Apagado programado-";
                apagar(int.Parse(textBoxMinutos.Text));
            } else {
                MessageBox.Show("Ingrese un valor en minutos.");
            }
       
        }
    }
    public class SimuladorTecla
    //Esta clase tiene un método que simula que se presiona la tecla F15
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

        private const int VK_F15 = 0x7E;

        public static void F15Key()
        {
            keybd_event(VK_F15, 0, 0, 0);
        }

    }
}