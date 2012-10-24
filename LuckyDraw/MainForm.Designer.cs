namespace LuckyDraw
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPanle = new System.Windows.Forms.ToolStripMenuItem();
            this.主标题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.副标题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTitle = new DevExpress.XtraEditors.LabelControl();
            this.lbNumber = new DevExpress.XtraEditors.LabelControl();
            this.sbtnStart = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEnd = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.说明ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1161, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPanle,
            this.ToolStripMenuItemUser,
            this.ToolStripMenuItemAward,
            this.ToolStripMenuItemMusic});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // ToolStripMenuItemPanle
            // 
            this.ToolStripMenuItemPanle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主标题ToolStripMenuItem,
            this.副标题ToolStripMenuItem,
            this.背景图片ToolStripMenuItem,
            this.ToolStripMenuItemFullScreen});
            this.ToolStripMenuItemPanle.Name = "ToolStripMenuItemPanle";
            this.ToolStripMenuItemPanle.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemPanle.Text = "版面设置";
            // 
            // 主标题ToolStripMenuItem
            // 
            this.主标题ToolStripMenuItem.Name = "主标题ToolStripMenuItem";
            this.主标题ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.主标题ToolStripMenuItem.Text = "主标题";
            // 
            // 副标题ToolStripMenuItem
            // 
            this.副标题ToolStripMenuItem.Name = "副标题ToolStripMenuItem";
            this.副标题ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.副标题ToolStripMenuItem.Text = "副标题";
            // 
            // 背景图片ToolStripMenuItem
            // 
            this.背景图片ToolStripMenuItem.Name = "背景图片ToolStripMenuItem";
            this.背景图片ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.背景图片ToolStripMenuItem.Text = "背景图片";
            // 
            // ToolStripMenuItemFullScreen
            // 
            this.ToolStripMenuItemFullScreen.Name = "ToolStripMenuItemFullScreen";
            this.ToolStripMenuItemFullScreen.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemFullScreen.Text = "全屏";
            this.ToolStripMenuItemFullScreen.Click += new System.EventHandler(this.ToolStripMenuItemFullScreen_Click);
            // 
            // ToolStripMenuItemUser
            // 
            this.ToolStripMenuItemUser.Name = "ToolStripMenuItemUser";
            this.ToolStripMenuItemUser.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemUser.Text = "人员设置";
            // 
            // ToolStripMenuItemAward
            // 
            this.ToolStripMenuItemAward.Name = "ToolStripMenuItemAward";
            this.ToolStripMenuItemAward.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemAward.Text = "奖项设置";
            // 
            // ToolStripMenuItemMusic
            // 
            this.ToolStripMenuItemMusic.Name = "ToolStripMenuItemMusic";
            this.ToolStripMenuItemMusic.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemMusic.Text = "音效";
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.说明ToolStripMenuItem.Text = "说明";
            // 
            // lbTitle
            // 
            this.lbTitle.Appearance.Font = new System.Drawing.Font("华文行楷", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbTitle.Appearance.Options.UseFont = true;
            this.lbTitle.Appearance.Options.UseForeColor = true;
            this.lbTitle.Location = new System.Drawing.Point(475, 55);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(160, 59);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "xxx公司";
            // 
            // lbNumber
            // 
            this.lbNumber.Appearance.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbNumber.Appearance.Options.UseFont = true;
            this.lbNumber.Appearance.Options.UseForeColor = true;
            this.lbNumber.Location = new System.Drawing.Point(475, 274);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(198, 75);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "000000";
            // 
            // sbtnStart
            // 
            this.sbtnStart.Location = new System.Drawing.Point(466, 590);
            this.sbtnStart.Name = "sbtnStart";
            this.sbtnStart.Size = new System.Drawing.Size(75, 23);
            this.sbtnStart.TabIndex = 3;
            this.sbtnStart.Text = "开始";
            this.sbtnStart.Click += new System.EventHandler(this.sbtnStart_Click);
            // 
            // sbtnEnd
            // 
            this.sbtnEnd.Location = new System.Drawing.Point(645, 590);
            this.sbtnEnd.Name = "sbtnEnd";
            this.sbtnEnd.Size = new System.Drawing.Size(75, 23);
            this.sbtnEnd.TabIndex = 4;
            this.sbtnEnd.Text = "结束";
            this.sbtnEnd.Click += new System.EventHandler(this.sbtnEnd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::LuckyDraw.Properties.Resources.中国结;
            this.ClientSize = new System.Drawing.Size(1161, 687);
            this.Controls.Add(this.sbtnEnd);
            this.Controls.Add(this.sbtnStart);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPanle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAward;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMusic;
        private System.Windows.Forms.ToolStripMenuItem 主标题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 副标题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景图片ToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lbTitle;
        private DevExpress.XtraEditors.LabelControl lbNumber;
        private DevExpress.XtraEditors.SimpleButton sbtnStart;
        private DevExpress.XtraEditors.SimpleButton sbtnEnd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFullScreen;
    }
}