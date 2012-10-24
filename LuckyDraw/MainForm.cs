using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using LuckyDraw.Models;
using LuckyDraw.Exceptions;
using System.Threading;


//timer 可实现

namespace LuckyDraw
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lp1, string lp2);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);

        private IntPtr hTray;
        private List<User> allUsers;
        private Thread thread;

        public MainForm()
        {
            try
            {
                allUsers = ADO.GetEntity().DataMultipleSelect("select * from [User] where IsLuckyDog = 0");
            }
            catch (ADOException ex)
            {
                MessageBox.Show(ex.msg);
                System.Environment.Exit(0);
            }
            thread = new Thread(new ThreadStart(ChangeNumberLable));
            thread.IsBackground = false;
            //获取任务栏
            hTray = MainForm.FindWindowA("Shell_TrayWnd", String.Empty);
            InitializeComponent();
            this.Size = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            MainForm.CheckForIllegalCrossThreadCalls = false;
        }

        public void FullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                //显示任务栏
                MainForm.ShowWindow(hTray, 5);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;
                this.menuStrip.Show();
            }
            else
            {
                //隐藏任务栏
                MainForm.ShowWindow(hTray, 0);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.menuStrip.Hide();
            }

        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.I:
                        break;
                }
            }
            if (e.KeyCode == Keys.F11)
            {
                FullScreen();
            }
        }

        private void sbtnStart_Click(object sender, EventArgs e)
        {
            startDraw();
        }

        private void startDraw()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                thread.Start();
            }
            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
        }

        private User tempUser;
        private void ChangeNumberLable()
        {
            allUsers = RandomSort(allUsers);
            int i = allUsers.Count - 1;
            while (true)
            {
                tempUser = allUsers[i];
                lbNumber.Text = tempUser.UserID;
                lbNumber.Refresh();
                Thread.Sleep(30);
                i--;
                if (i < 0)
                {
                    i = allUsers.Count - 1;
                }
            }
        }

        private void sbtnEnd_Click(object sender, EventArgs e)
        {
            stopDraw();
        }

        private void stopDraw()
        {
            if (thread.ThreadState != ThreadState.Unstarted)
            {
                thread.Suspend();
                try
                {
                    tempUser.IsLuckyDog = 1;
                    tempUser.LuckyDog = "一等奖";
                    ADO.GetEntity().DataUpdate(tempUser);
                }
                catch (ADOException ex)
                {
                    MessageBox.Show(ex.msg);
                }
                allUsers.Remove(tempUser);
            }
        }

        /// <summary>
        /// 数组打乱顺序（返回arraylist)
        /// </summary>
        ///   
        public List<User> RandomSort(List<User> array)
        {
            int len = array.Count;
            System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
            List<User> newlist = new List<User>();
            Random rand = new Random();
            int i = 0;
            while (list.Count < len)
            {
                int iter = rand.Next(0, len);
                if (!list.Contains(iter))
                {
                    list.Add(iter);
                    newlist.Add(array[iter]);
                    i++;
                }
            }
            return newlist;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ToolStripMenuItemFullScreen_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        #region register hotkeys

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
        int Space = 32; //热键ID
        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        private const int WM_CREATE = 0x1; //窗口消息-创建
        private const int WM_DESTROY = 0x2; //窗口消息-销毁
        private const int MOD_ALT = 0x1; //ALT
        private const int MOD_CONTROL = 0x2; //CTRL
        private const int MOD_SHIFT = 0x4; //SHIFT
        private const int VK_SPACE = 0x20; //SPACE
        private const int VK_F = 0x46; //SPACE
        int DrawKey = 33;
        int fullScreenKey = 34;

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        /// <param name="fsModifiers">组合键</param>
        /// <param name="vk">热键</param>
        private void RegKey(IntPtr hwnd, int hotKey_id, int fsModifiers, int vk)
        {
            bool result;
            if (RegisterHotKey(hwnd, hotKey_id, fsModifiers, vk) == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            if (!result)
            {
                MessageBox.Show("注册热键失败！");
            }
        }
        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        private void UnRegKey(IntPtr hwnd, int hotKey_id)
        {
            UnregisterHotKey(hwnd, hotKey_id);
        }
        //三、重写WndProc方法，实现注册
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键
                    switch (m.WParam.ToInt32())
                    {
                        case 32: //热键ID
                            MessageBox.Show("Hot Key : Ctrl + Alt + Shift + Space");
                            break;
                        case 33:
                            if (thread.ThreadState == ThreadState.Unstarted || thread.ThreadState ==ThreadState.Suspended)
                            {
                                startDraw();
                            }
                            else if (thread.ThreadState != ThreadState.Unstarted && thread.ThreadState != ThreadState.Suspended)
                            {
                                stopDraw();
                            }
                            break;
                        case 34:
                            FullScreen();
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    RegKey(Handle, Space, MOD_ALT | MOD_CONTROL | MOD_SHIFT, VK_SPACE); //注册热键
                    RegKey(Handle, DrawKey,0x0, VK_SPACE); //注册热键
                    RegKey(Handle, fullScreenKey,MOD_CONTROL, VK_F); //注册热键
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    UnRegKey(Handle, Space); //销毁热键
                    UnRegKey(Handle, DrawKey); //销毁热键
                    UnRegKey(Handle, fullScreenKey); //销毁热键
                    break;
                default:
                    break;
            }
        }

        #endregion

    }

}