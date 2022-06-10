using System;
using System.Windows.Forms;
namespace Kütüphane_Kayıt_Programı
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.vtyol == null || Properties.Settings.Default.vtyol == "")
            {
                Application.Run(new frmVTE());
            }
            else
            {
                Application.Run(new frmGiris());
            }
        }
    }
}