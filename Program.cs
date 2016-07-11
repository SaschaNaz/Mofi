using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Mofi
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var writer = new StreamWriter("mofi.log", true, Encoding.UTF8);

            Console.SetOut(writer);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Worker.mainWindow);

            writer.Flush();

            writer.Close();
        }
    }
}
