using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Configuration;

namespace LuckyDraw
{
    public class DrawLabel : LabelControl
    {
        public DrawLabel()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawLabel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawLabel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawLabel_MouseUp);
        }

        #region 拖动

        private Point m_MousePoint;
        private Point m_LastPoint;
        private bool _dragFlag;
        public bool dragFlag
        {
            get { return _dragFlag; }
            set { _dragFlag = value; }
        }

        private void DrawLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.m_LastPoint = this.Location;
                this.m_MousePoint = this.PointToScreen(e.Location);
            }
        }

        private void DrawLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point t = this.PointToScreen(e.Location);
                Point l = this.m_LastPoint;

                l.Offset(t.X - this.m_MousePoint.X, t.Y - this.m_MousePoint.Y);

                if (_dragFlag)
                {
                    this.Location = l;
                }
            }
        }

        private void DrawLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _dragFlag)
            {
                Point t = this.PointToScreen(e.Location);
                Point l = this.m_LastPoint;

                l.Offset(t.X - this.m_MousePoint.X, t.Y - this.m_MousePoint.Y);

                if (_dragFlag)
                {
                    this.Location = l;
                    UpdateAppConfig(this.Name + ".Location", l.X + "," + l.Y);
                }
            }
        }

        ///<summary>  
        ///在＊.exe.config文件中appSettings配置节增加一对键、值对  
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        private void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable  
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it  
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.  
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.  
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.  
            ConfigurationManager.RefreshSection("appSettings");
        }

        #endregion
    }
}
