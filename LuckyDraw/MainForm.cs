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
using System.Configuration;

//timer 可实现同样效果

namespace LuckyDraw
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lp1, string lp2);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);

        private IntPtr hTray;
        private Thread thread;
        private User tempUser;

        public MainForm()
        {
            InitializeComponent();
            //this.Enabled = false;
            InitLayout();
            try
            {
                allUsers = ADO.GetEntity().DataMultipleSelect("select * from [User] where IsLuckyDog = 0");
                allAward = ADO.GetEntity().DataGetAwards("select * from Award where AwardNumber <> 0");
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
            this.lbcon.Hide();
            this.Size = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            MainForm.CheckForIllegalCrossThreadCalls = false;
            if (allAward.Count > 0)
            {
                nowAward = allAward[0];
            }
            else
            {
                DrawOver();
            }
        }


        #region property

        private List<User> _allUsers;
        public List<User> allUsers
        {
            get
            {
                return _allUsers;
            }
            set
            {
                _allUsers = value;
            }
        }

        private List<Award> _allAward;
        public List<Award> allAward
        {
            get { return _allAward; }
            set
            {
                _allAward = value;
            }
        }

        private bool _lockDragLabel;
        public bool lockDragLabel
        {
            get { return _lockDragLabel; }
            set { _lockDragLabel = value; }
        }

        private Award _nowAward;

        public Award nowAward
        {
            get { return _nowAward; }
            set { _nowAward = value; this.lbDrawType.Text = nowAward.AwardType; this.lbDrawType.Refresh(); }
        }

        #endregion

        #region events

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.btnStart.Text == "开始")
            {
                startDraw();
            }
            else
            {
                stopDraw();
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ToolStripMenuItemFullScreen_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            this.lbTitle.Focus();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.btnStart.Location = new Point((this.Width - this.btnStart.Width) / 2, this.Height - this.btnStart.Height - 80);
            this.lbTitle.Location = GetLabelLocation(lbTitle.Name);
            this.lbNumber.Location = GetLabelLocation(lbNumber.Name);
            this.lbLuckyDog.Location = GetLabelLocation(lbLuckyDog.Name);
            this.lbDrawType.Location = GetLabelLocation(lbDrawType.Name);
            this.lbcon.Location = GetLabelLocation(lbcon.Name);
        }

        #endregion

        #region Layout

        private void InitLayout()
        {
            ChangeDragLalel();
        }

        private void ChangeDragLalel()
        {
            this.lbTitle.dragFlag = _lockDragLabel;
            this.lbNumber.dragFlag = _lockDragLabel;
            this.lbLuckyDog.dragFlag = _lockDragLabel;
            this.lbDrawType.dragFlag = _lockDragLabel;
            this.lbcon.dragFlag = _lockDragLabel;
        }

        #endregion

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
        private const int VK_F = 0x46; //F
        private const int VK_TAB = 0x09;//TAB
        private const int VK_L = 0x4c;//L
        int drawKey = 33;
        int fullScreenKey = 34;
        int changeAwardKey = 35;
        int lockDragLabelKey = 36;

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
                            //MessageBox.Show("Hot Key : Ctrl + Alt + Shift + Space");
                            break;
                        case 33:
                            if (thread.ThreadState == ThreadState.Unstarted || thread.ThreadState == ThreadState.Suspended)
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
                        case 35:
                            ChangeNowAward();
                            break;
                        case 36:
                            _lockDragLabel = !_lockDragLabel;
                            ChangeDragLalel();
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    RegKey(Handle, fullScreenKey, MOD_CONTROL, VK_F); //注册热键
                    RegAllKey();
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    UnRegKey(Handle, fullScreenKey); //销毁热键
                    UnRegAllKey();
                    break;
                default:
                    break;
            }
        }

        private void RegAllKey()
        {
            RegKey(Handle, Space, MOD_ALT | MOD_CONTROL | MOD_SHIFT, VK_SPACE); //注册热键
            RegKey(Handle, drawKey, 0x0, VK_SPACE); //注册热键
            RegKey(Handle, changeAwardKey, MOD_CONTROL, VK_TAB); //注册热键
            RegKey(Handle, lockDragLabelKey, MOD_CONTROL, VK_L); //注册热键
        }

        private void UnRegAllKey()
        {
            UnRegKey(Handle, Space); //销毁热键
            UnRegKey(Handle, drawKey); //销毁热键
            UnRegKey(Handle, changeAwardKey); //销毁热键
            UnRegKey(Handle, lockDragLabelKey); //销毁热键
        }

        #endregion

        #region Common methods

        private void ChangeNowAward()
        {
            for (int i = 0; i < allAward.Count; i++)
            {
                if (nowAward == allAward[i])
                {
                    if (i + 1 == allAward.Count)
                    {
                        nowAward = allAward[0];
                    }
                    else
                    {
                        nowAward = allAward[i + 1];
                    }
                    break;
                }
            }
        }

        private void ChangeNowAward(string awardType)
        {
            foreach (Award award in allAward)
            {
                if (award.AwardType == awardType)
                {
                    nowAward = award;
                    break;
                }
            }
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
                InitLayout();
            }
            else
            {
                //隐藏任务栏
                MainForm.ShowWindow(hTray, 0);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.menuStrip.Hide();
                InitLayout();
            }

        }

        private void startDraw()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                this.btnStart.Text = "结束";
                thread.Start();
                if (allAward.Count > 0)
                {
                    nowAward = allAward[0];
                }
                else
                {
                    DrawOver();
                }
            }
            if (thread.ThreadState == ThreadState.Suspended)
            {
                this.btnStart.Text = "结束";
                thread.Resume();
                if (allAward.Count > 0)
                {
                    nowAward = allAward[0];
                }
                else
                {
                    DrawOver();
                }
            }
        }

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

        private void stopDraw()
        {
            if (thread.ThreadState != ThreadState.Unstarted)
            {
                this.btnStart.Text = "开始";
                thread.Suspend();
                try
                {
                    foreach (User user in _allUsers)
                    {
                        if (user.Assigned == nowAward.AwardType)
                        {
                            tempUser = user;
                        }
                    }
                    tempUser.IsLuckyDog = 1;
                    tempUser.LuckyDog = nowAward.AwardType;
                    ADO.GetEntity().DataUpdate(tempUser);
                    nowAward.AwardNumber--;
                    ADO.GetEntity().DataUpdateAward(nowAward);
                    if (nowAward.AwardNumber <= 0)
                    {
                        allAward.Remove(nowAward);
                        if (allAward.Count <= 0)
                        {
                            DrawOver();
                        }
                    }
                }
                catch (ADOException ex)
                {
                    MessageBox.Show(ex.msg);
                }
                this.lbLuckyDog.Text = tempUser.UserDescribe + "——" + tempUser.UserName;

                allUsers.Remove(tempUser);
            }
        }

        private void DrawOpen()
        {
            this.lbDrawType.Show();
            this.lbLuckyDog.Show();
            this.lbNumber.Show();
            this.btnStart.Show();
            this.lbcon.Hide();
            RegAllKey();
        }

        private void DrawOver()
        {
            this.lbDrawType.Hide();
            this.lbLuckyDog.Hide();
            this.lbNumber.Hide();
            this.btnStart.Hide();
            this.lbcon.Show();
            UnRegAllKey();
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

        private Point GetLabelLocation(string name)
        {
            string location = ConfigurationManager.AppSettings[name + ".Location"].ToString();
            string[] array = location.Split(new char[1] { ',' });
            return new Point(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
        }

        #endregion

    }

}