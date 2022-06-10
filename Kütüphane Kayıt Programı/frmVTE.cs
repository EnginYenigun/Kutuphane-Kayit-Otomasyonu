using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kütüphane_Kayıt_Programı
{
    public partial class frmVTE : Form
    {
        public frmVTE()
        {
            InitializeComponent();
        }

        private void frmVTE_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            Properties.Settings.Default.vtyol = ofd.FileName;
            Properties.Settings.Default.Save();
            Process.Start(Application.StartupPath + "\\Kütüphane Kayıt Programı.exe");
            Application.Exit();
        }
    }
}