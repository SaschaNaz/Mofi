using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mofi
{
    public partial class frmNotify : Form
    {
        private class NativeMethods
        {
            [DllImport("user32.dll", SetLastError=true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", SetLastError=true)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        }

        public frmNotify()
        {
            InitializeComponent();
        }

        private void frmNotify_Load(object sender, EventArgs e)
        {
            this.Hide();

            int initialStyle = NativeMethods.GetWindowLong(this.Handle, -20);
            NativeMethods.SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        public void SetText(string text)
        {
            if (text == null)
            {
                this.Hide();
                this.timer1.Enabled = false;
            }
            else if (this.m_tmr > 0)
            {
                return;
            }

            this.label1.Text = text;
            this.timer1.Enabled = true;

            this.m_tmr = 10;

            this.Show();

            this.WindowState = FormWindowState.Normal;

            this.Left = Worker.mainWindow.Left;
            this.Top = Worker.mainWindow.Top;

            NativeMethods.SetWindowPos(this.Handle, new IntPtr(/*HWND_NOTOPMOST*/ -2), 0, 0, 0, 0, /*SWP_NOMOVE | SWP_NOSIZE*/ 3);
            NativeMethods.SetWindowPos(this.Handle, new IntPtr(/*HWND_TOPMOST*/   -1), 0, 0, 0, 0, /*SWP_NOMOVE | SWP_NOSIZE*/ 3);
        }

        private bool m_tick = false;
        private int m_tmr = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = (this.m_tick = !this.m_tick) ? Color.Black : Color.Red;

            if (--m_tmr == 0)
            {
                this.Hide();
                this.timer1.Enabled = false;
            }
        }
    }
}
