using System;
using System.Windows.Forms;
using UniVision.Forms;

namespace UniVision;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Frm_Main());
    }
}
