namespace 验车帝
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch { }
           
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkSame = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.myLove = new System.Windows.Forms.CheckBox();
            this.HistoryListBox = new System.Windows.Forms.ListBox();
            this.returnBtn = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.labelVideoNum = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.workStatus = new System.Windows.Forms.Label();
            this.videoDirTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_size = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_like = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_locate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.label_size = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkSame);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.myLove);
            this.panel1.Controls.Add(this.HistoryListBox);
            this.panel1.Controls.Add(this.returnBtn);
            this.panel1.Controls.Add(this.logBox);
            this.panel1.Controls.Add(this.labelVideoNum);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.workStatus);
            this.panel1.Controls.Add(this.videoDirTextbox);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 830);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkSame
            // 
            this.checkSame.AutoSize = true;
            this.checkSame.Location = new System.Drawing.Point(3, 401);
            this.checkSame.Name = "checkSame";
            this.checkSame.Size = new System.Drawing.Size(72, 16);
            this.checkSame.TabIndex = 18;
            this.checkSame.Text = "查看重复";
            this.checkSame.UseVisualStyleBackColor = true;
            this.checkSame.CheckedChanged += new System.EventHandler(this.checkSame_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "试试手气";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // myLove
            // 
            this.myLove.AutoSize = true;
            this.myLove.Location = new System.Drawing.Point(3, 379);
            this.myLove.Name = "myLove";
            this.myLove.Size = new System.Drawing.Size(72, 16);
            this.myLove.TabIndex = 16;
            this.myLove.Text = "查看喜欢";
            this.myLove.UseVisualStyleBackColor = true;
            this.myLove.CheckedChanged += new System.EventHandler(this.myLove_CheckedChanged);
            // 
            // HistoryListBox
            // 
            this.HistoryListBox.FormattingEnabled = true;
            this.HistoryListBox.ItemHeight = 12;
            this.HistoryListBox.Location = new System.Drawing.Point(3, 213);
            this.HistoryListBox.Name = "HistoryListBox";
            this.HistoryListBox.Size = new System.Drawing.Size(108, 160);
            this.HistoryListBox.TabIndex = 15;
            this.HistoryListBox.Click += new System.EventHandler(this.HistoryListBox_Click);
            this.HistoryListBox.DoubleClick += new System.EventHandler(this.HistoryListBox_DoubleClick);
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(0, 184);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(109, 23);
            this.returnBtn.TabIndex = 14;
            this.returnBtn.Text = "清空";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logBox.Location = new System.Drawing.Point(1, 688);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(108, 141);
            this.logBox.TabIndex = 13;
            this.logBox.Text = "2025年7月9日\r\n支持搜索记录 \r\n2025年7月17日\r\n支持喜欢\r\n2026年1月12日\r\n支持大小写 删除进回收站\r\n2026年3月11日\r\n支持去重，" +
    "支持获取列表自动重启";
            // 
            // labelVideoNum
            // 
            this.labelVideoNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVideoNum.ForeColor = System.Drawing.Color.Fuchsia;
            this.labelVideoNum.Location = new System.Drawing.Point(0, 449);
            this.labelVideoNum.Name = "labelVideoNum";
            this.labelVideoNum.Size = new System.Drawing.Size(73, 21);
            this.labelVideoNum.TabIndex = 6;
            this.labelVideoNum.Text = "数据加载中.";
            this.labelVideoNum.Click += new System.EventHandler(this.labelVideoNum_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "遍历子目录文件";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(0, 150);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(109, 28);
            this.searchBox.TabIndex = 11;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 128);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.Text = "文件名";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 106);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "最大";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 84);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "最新";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // workStatus
            // 
            this.workStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.workStatus.AutoSize = true;
            this.workStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.workStatus.ForeColor = System.Drawing.Color.Lime;
            this.workStatus.Location = new System.Drawing.Point(0, 669);
            this.workStatus.Name = "workStatus";
            this.workStatus.Size = new System.Drawing.Size(39, 16);
            this.workStatus.TabIndex = 7;
            this.workStatus.Text = "状态";
            // 
            // videoDirTextbox
            // 
            this.videoDirTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.videoDirTextbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoDirTextbox.Location = new System.Drawing.Point(0, 473);
            this.videoDirTextbox.Multiline = true;
            this.videoDirTextbox.Name = "videoDirTextbox";
            this.videoDirTextbox.Size = new System.Drawing.Size(114, 355);
            this.videoDirTextbox.TabIndex = 5;
            this.videoDirTextbox.Text = "D:\\Projects\\验车帝\\验车帝\\bin\\Debug\\video";
            this.videoDirTextbox.TextChanged += new System.EventHandler(this.videoDirTextbox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "刷新截图";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "获取列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(116, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1404, 830);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_refresh,
            this.toolStripMenuItem_rename,
            this.toolStripMenuItem_size,
            this.toolStripMenuItem_like,
            this.toolStripMenuItem_locate,
            this.toolStripMenuItem_delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 158);
            this.contextMenuStrip1.Text = "刷新截图";
            // 
            // toolStripMenuItem_refresh
            // 
            this.toolStripMenuItem_refresh.Name = "toolStripMenuItem_refresh";
            this.toolStripMenuItem_refresh.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_refresh.Text = "刷新截图";
            this.toolStripMenuItem_refresh.Click += new System.EventHandler(this.toolStripMenuItem_refresh_Click);
            // 
            // toolStripMenuItem_rename
            // 
            this.toolStripMenuItem_rename.Name = "toolStripMenuItem_rename";
            this.toolStripMenuItem_rename.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_rename.Text = "重命名";
            this.toolStripMenuItem_rename.Click += new System.EventHandler(this.toolStripMenuItem_rename_Click);
            // 
            // toolStripMenuItem_size
            // 
            this.toolStripMenuItem_size.Name = "toolStripMenuItem_size";
            this.toolStripMenuItem_size.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_size.Text = "文件大小";
            // 
            // toolStripMenuItem_like
            // 
            this.toolStripMenuItem_like.Name = "toolStripMenuItem_like";
            this.toolStripMenuItem_like.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_like.Text = "★喜欢★";
            this.toolStripMenuItem_like.Click += new System.EventHandler(this.toolStripMenuItem_like_Click);
            // 
            // toolStripMenuItem_locate
            // 
            this.toolStripMenuItem_locate.Name = "toolStripMenuItem_locate";
            this.toolStripMenuItem_locate.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_locate.Text = "定位文件";
            this.toolStripMenuItem_locate.Click += new System.EventHandler(this.toolStripMenuItem_locate_Click);
            // 
            // toolStripMenuItem_delete
            // 
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            this.toolStripMenuItem_delete.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_delete.Text = "X删除文件X";
            this.toolStripMenuItem_delete.Click += new System.EventHandler(this.toolStripMenuItem_delete_Click);
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_size.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_size.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_size.Location = new System.Drawing.Point(116, 814);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(79, 16);
            this.label_size.TabIndex = 5;
            this.label_size.Text = "文件信息.";
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(116, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1404, 830);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.Visible = false;
            this.listView2.Click += new System.EventHandler(this.listView2_Click);
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 830);
            this.Controls.Add(this.label_size);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验车帝 V1.4 支持搜索记录 支持喜欢 搜索大小写";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox videoDirTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelVideoNum;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label workStatus;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_refresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_size;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_locate;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_rename;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button returnBtn;
        public System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListBox HistoryListBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_like;
        private System.Windows.Forms.CheckBox myLove;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkSame;
    }
}

