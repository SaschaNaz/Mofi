using System;

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
        }

        public static void Init()
        {
            notifyWindow.Left = -100;
            notifyWindow.Top = -100;
            notifyWindow.Show();
        }

        internal static void Invoke(ushort p)
        {
            Console.WriteLine(p);

            if (p == 0)
            {
                notifyWindow.Invoke(new Action<string>(notifyWindow.SetText), null);
                return;
            }

            if (Worker.S && Data.S.ContainsKey(p))
            {
                notifyWindow.Invoke(new Action<string>(notifyWindow.SetText), Data.S[p]);
                return;
            }

            if (Worker.A && Data.A.ContainsKey(p))
            {
                notifyWindow.Invoke(new Action<string>(notifyWindow.SetText), Data.A[p]);
                return;
            }

            if (Worker.B && Data.B.ContainsKey(p))
            {
                notifyWindow.Invoke(new Action<string>(notifyWindow.SetText), Data.B[p]);
                return;
            }
        }
    }
}
