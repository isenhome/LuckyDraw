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
            this.lbDrawType = new DevExpress.XtraEditors.LabelControl();
            this.lbLuckyDog = new DevExpress.XtraEditors.LabelControl();
            this.lbcon = new DevExpress.XtraEditors.LabelControl();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.menuStrip.Size = new System.Drawing.Size(1192, 24);
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
            this.ToolStripMenuItemPanle.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItemPanle.Text = "版面设置";
            // 
            // 主标题ToolStripMenuItem
            // 
            this.主标题ToolStripMenuItem.Name = "主标题ToolStripMenuItem";
            this.主标题ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.主标题ToolStripMenuItem.Text = "主标题";
            // 
            // 副标题ToolStripMenuItem
            // 
            this.副标题ToolStripMenuItem.Name = "副标题ToolStripMenuItem";
            this.副标题ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.副标题ToolStripMenuItem.Text = "副标题";
            // 
            // 背景图片ToolStripMenuItem
            // 
            this.背景图片ToolStripMenuItem.Name = "背景图片ToolStripMenuItem";
            this.背景图片ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.背景图片ToolStripMenuItem.Text = "背景图片";
            // 
            // ToolStripMenuItemFullScreen
            // 
            this.ToolStripMenuItemFullScreen.Name = "ToolStripMenuItemFullScreen";
            this.ToolStripMenuItemFullScreen.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItemFullScreen.Text = "全屏";
            this.ToolStripMenuItemFullScreen.Click += new System.EventHandler(this.ToolStripMenuItemFullScreen_Click);
            // 
            // ToolStripMenuItemUser
            // 
            this.ToolStripMenuItemUser.Name = "ToolStripMenuItemUser";
            this.ToolStripMenuItemUser.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItemUser.Text = "人员设置";
            // 
            // ToolStripMenuItemAward
            // 
            this.ToolStripMenuItemAward.Name = "ToolStripMenuItemAward";
            this.ToolStripMenuItemAward.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItemAward.Text = "奖项设置";
            // 
            // ToolStripMenuItemMusic
            // 
            this.ToolStripMenuItemMusic.Name = "ToolStripMenuItemMusic";
            this.ToolStripMenuItemMusic.Size = new System.Drawing.Size(118, 22);
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
            this.lbTitle.Location = new System.Drawing.Point(183, 80);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(840, 59);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "二零一二年昆山中创软件公司晚会";
            // 
            // lbNumber
            // 
            this.lbNumber.Appearance.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbNumber.Appearance.Options.UseFont = true;
            this.lbNumber.Appearance.Options.UseForeColor = true;
            this.lbNumber.Location = new System.Drawing.Point(582, 153);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(198, 75);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "000000";
            // 
            // lbDrawType
            // 
            this.lbDrawType.Appearance.Font = new System.Drawing.Font("华文行楷", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDrawType.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbDrawType.Appearance.Options.UseFont = true;
            this.lbDrawType.Appearance.Options.UseForeColor = true;
            this.lbDrawType.Location = new System.Drawing.Point(373, 169);
            this.lbDrawType.Name = "lbDrawType";
            this.lbDrawType.Size = new System.Drawing.Size(168, 59);
            this.lbDrawType.TabIndex = 5;
            this.lbDrawType.Text = "一等奖";
            // 
            // lbLuckyDog
            // 
            this.lbLuckyDog.Appearance.Font = new System.Drawing.Font("华文行楷", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLuckyDog.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbLuckyDog.Appearance.Options.UseFont = true;
            this.lbLuckyDog.Appearance.Options.UseForeColor = true;
            this.lbLuckyDog.Location = new System.Drawing.Point(270, 286);
            this.lbLuckyDog.Name = "lbLuckyDog";
            this.lbLuckyDog.Size = new System.Drawing.Size(616, 59);
            this.lbLuckyDog.TabIndex = 7;
            this.lbLuckyDog.Text = "中创软件——昆山分公司";
            // 
            // lbcon
            // 
            this.lbcon.Appearance.Font = new System.Drawing.Font("华文行楷", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbcon.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbcon.Appearance.Options.UseFont = true;
            this.lbcon.Appearance.Options.UseForeColor = true;
            this.lbcon.Location = new System.Drawing.Point(228, 409);
            this.lbcon.Name = "lbcon";
            this.lbcon.Size = new System.Drawing.Size(672, 101);
            this.lbcon.TabIndex = 8;
            this.lbcon.Text = "祝大会圆满成功";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = global::LuckyDraw.Properties.Resources.button1;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("楷体_GB2312", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.Yellow;
            this.btnStart.Location = new System.Drawing.Point(453, 516);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(317, 136);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::LuckyDraw.Properties.Resources.中国结;
            this.ClientSize = new System.Drawing.Size(1192, 673);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbcon);
            this.Controls.Add(this.lbLuckyDog);
            this.Controls.Add(this.lbDrawType);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFullScreen;
        private DevExpress.XtraEditors.LabelControl lbDrawType;
        private DevExpress.XtraEditors.LabelControl lbLuckyDog;
        private DevExpress.XtraEditors.LabelControl lbcon;
        private System.Windows.Forms.Button btnStart;
    }
}