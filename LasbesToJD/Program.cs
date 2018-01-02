using System;
using System.Windows.Forms;
using System.Configuration;

namespace LasbesToJD
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (ConfigurationManager.AppSettings["startProgram"].ToString() == "FrMain")
            {
                Application.Run(new FrMain());
            }
            else {
                Application.Run(new FrBarCode());
            }

            
        }
    }
}
