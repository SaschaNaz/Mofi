using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App;

namespace Mofi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Network m_network;
        private Process m_ffxiv;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.m_network = new Network();

            this.FindFFXIVProcess();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(30 * 1000);

                    if ((this.m_ffxiv == null) || this.m_ffxiv.HasExited)
                    {
                        this.m_ffxiv = null;

                        this.Invoke(new Action(this.FindFFXIVProcess));
                    }
                    else
                    {
                        // FFXIVProcess is alive

                        if (this.m_network.IsRunning)
                        {
                            this.m_network.UpdateGameConnections(this.m_ffxiv);
                        }
                        else
                        {
                            this.m_network.StartCapture(this.m_ffxiv);
                        }
                    }
                }
            });

            this.ctlS.Checked = this.ctlA.Checked = this.ctlB.Checked = true;
        }

        private void ctlS_CheckedChanged(object sender, EventArgs e)
        {
            Worker.S = this.ctlS.Checked;
        }

        private void ctlA_CheckedChanged(object sender, EventArgs e)
        {
            Worker.A = this.ctlA.Checked;
        }

        private void ctlB_CheckedChanged(object sender, EventArgs e)
        {
            Worker.B = this.ctlB.Checked;
        }

        private void FindFFXIVProcess()
        {
            comboBox_Process.Items.Clear();
            Console.WriteLine("파이널판타지14 프로세스를 찾는 중...");

            var processes = new List<Process>();
            processes.AddRange(Process.GetProcessesByName("ffxiv"));
            processes.AddRange(Process.GetProcessesByName("ffxiv_dx11"));

            if (processes.Count == 0)
            {
                Console.WriteLine("파이널판타지14 프로세스를 찾을 수 없습니다");
                button_SelectProcess.Enabled = false;
                comboBox_Process.Enabled = false;
            }
            else if (processes.Count >= 2)
            {
                Console.WriteLine("파이널판타지14가 2개 이상 실행중입니다");
                button_SelectProcess.Enabled = true;
                comboBox_Process.Enabled = true;

                foreach (var process in processes)
                {
                    using (process)
                        comboBox_Process.Items.Add(string.Format("{0}:{1}", process.ProcessName, process.Id));
                }
                comboBox_Process.SelectedIndex = 0;
            }
            else
            {
                SetFFXIVProcess(processes[0]);
            }
        }

        private void SetFFXIVProcess(Process process)
        {
            if (this.m_ffxiv != null)
                this.m_ffxiv.Dispose();

            this.m_ffxiv = process;

            var name = string.Format("{0}:{1}", this.m_ffxiv.ProcessName, this.m_ffxiv.Id);
            Console.WriteLine("파이널판타지14 프로세스가 선택되었습니다: {0}", name);

            comboBox_Process.Enabled = false;
            button_SelectProcess.Enabled = false;

            comboBox_Process.Items.Clear();
            comboBox_Process.Items.Add(name);
            comboBox_Process.SelectedIndex = 0;

            this.m_network.StartCapture(this.m_ffxiv);
        }

        private void button_ResetProcess_Click(object sender, EventArgs e)
        {
            this.m_network.StopCapture();
            this.m_ffxiv = null;
            FindFFXIVProcess();
        }

        private void button_SelectProcess_Click(object sender, EventArgs e)
        {
            try
            {
                SetFFXIVProcess(Process.GetProcessById(int.Parse(((string)comboBox_Process.SelectedItem).Split(':')[1])));
            }
            catch
            {
                Console.WriteLine("파이널판타지14 프로세스 설정에 실패했습니다");
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            Worker.notifyWindow.Left = this.Left;
            Worker.notifyWindow.Top = this.Top;
        }
    }
}
