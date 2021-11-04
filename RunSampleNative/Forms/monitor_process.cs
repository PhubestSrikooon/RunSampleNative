using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RunSampleNative.Forms
{
    public partial class monitor_process : Form
    {
        int tabIndex = 0;
        public List<string> selectedProcess = new List<string>(); 

        public monitor_process()
        {
            InitializeComponent();
            refresh.MouseDown += (s, e) => {
                refreshProcess();
            };
            search.MouseDown += (s, e) => {
                searchProcess();
            };
            this.ControlBox = false;
        }

        void addList(string processName,bool checkState)
        {
            Size panelSize = new Size();
            panelSize.Height = 43;

            Panel panel = new Panel();
            panel.TabIndex = tabIndex;
            panel.Parent = all_process;
            panel.Name = processName;
            panel.Dock = DockStyle.Top;
            panel.Size = panelSize;
            panel.BackColor = Color.Transparent;

            Size iconSize = new Size();
            iconSize.Width = 43;

            PictureBox process_Icn = new PictureBox();
            process_Icn.Parent = panel;
            process_Icn.Dock = DockStyle.Left;
            process_Icn.Size = iconSize;

            Size labelSize = new Size();
            labelSize.Width = 100;

            Label processLabel = new Label();
            processLabel.Parent = panel;
            processLabel.Text = processName;
            processLabel.Dock = DockStyle.Left;
            processLabel.TextAlign = ContentAlignment.MiddleCenter;
            processLabel.Size = labelSize;
            tabIndex++;

            CheckBox checkx = new CheckBox();
            checkx.Parent = panel;
            checkx.Dock = DockStyle.Right;
            checkx.Checked = checkState;

            checkx.CheckedChanged += (s, e) => { 
                if (checkx.Checked)
                {
                    selectedProcess.Add(processName);
                }
                else
                {
                    for (int i = 0; i < selectedProcess.Count; i++)
                    {
                        if (selectedProcess[i].Equals(processName))
                        {
                            selectedProcess.RemoveAt(i);
                        }
                    }
                }
            };

        }
        void RemoveAll()
        {
            all_process.Controls.Clear();
            tabIndex = 0;
        }

        void refreshProcess()
        {
            this.Invoke((MethodInvoker)delegate
            {
                RemoveAll();
                Process[] process = Process.GetProcesses();
                foreach (Process p in process)
                {
                    for (int i = 0; i < selectedProcess.Count; i++)
                    {
                        if (selectedProcess[i].Equals(p))
                        {
                            addList(p.ProcessName,true);
                            return;
                        }
                    }
                    addList(p.ProcessName, false);
                }
            });
        }

        void searchProcess()
        {
            this.Invoke((MethodInvoker)delegate
            {
                RemoveAll();
                Process[] process = Process.GetProcesses();
                foreach (Process p in process)
                {
                    if (p.ProcessName.Contains(textBox1.Text))
                    {
                        for (int i = 0; i < selectedProcess.Count; i++)
                        {
                            if (selectedProcess[i].Equals(textBox1.Text))
                            {
                                addList(p.ProcessName, true);
                                return;
                            }
                        }
                        addList(p.ProcessName, false);
                    }
                }
            });
        }

        private void save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
