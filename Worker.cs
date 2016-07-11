using System.Threading;
using System;
using System.Windows.Forms;

namespace Mofi
{
    internal static class Worker
    {
        public static bool S { get; set; }
        public static bool A { get; set; }
        public static bool B { get; set; }

        public static readonly frmMain mainWindow;
        public static readonly frmNotify notifyWindow;

        static Worker()
        {
            mainWindow = new frmMain();
            notifyWindow = new frmNotify();
            notifyWindow.Show();
        }

        internal static void Invoke(ushort p)
        {
            Console.WriteLine(p);

            if (p == 0)
            {
                Worker.Invoke("");
                return;
            }

            if (Worker.S && Data.S.ContainsKey(p))
            {
                Worker.Invoke(Data.S[p]);
                return;
            }

            if (Worker.A && Data.A.ContainsKey(p))
            {
                Worker.Invoke(Data.A[p]);
                return;
            }

            if (Worker.B && Data.B.ContainsKey(p))
            {
                Worker.Invoke(Data.B[p]);
                return;
            }
        }

        internal static void Invoke(string name)
        {
            notifyWindow.Invoke(new Action<string>(notifyWindow.SetText), name);
        }
    }
}
