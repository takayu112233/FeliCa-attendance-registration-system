using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFC_READ
{

    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]


        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Main_Read Main_Form = new Main_Read();
            Main_Form.StartPosition = FormStartPosition.CenterScreen;
            Main_Form.ShowDialog();

        }


    }
}
