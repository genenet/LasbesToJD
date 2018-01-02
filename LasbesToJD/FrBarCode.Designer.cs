namespace LasbesToJD
{
    partial class FrBarCode
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
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrBarCode));
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtInfos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileLabel = new System.Windows.Forms.OpenFileDialog();
            this.saveFileLabel = new System.Windows.Forms.SaveFileDialog();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.tabProLabel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl2 = new FastReport.Preview.PreviewControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInfoOther = new System.Windows.Forms.TextBox();
            this.report2 = new FastReport.Report();
            this.priDialog = new System.Windows.Forms.PrintDialog();
            this.preLabel = new System.Windows.Forms.Panel();
            this.toolBar.SuspendLayout();
            this.tabProLabel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(53, 6);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(367, 21);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            // 
            // txtInfos
            // 
            this.txtInfos.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfos.Location = new System.Drawing.Point(53, 44);
            this.txtInfos.Multiline = true;
            this.txtInfos.Name = "txtInfos";
            this.txtInfos.Size = new System.Drawing.Size(367, 217);
            this.txtInfos.TabIndex = 2;
            this.txtInfos.TextChanged += new System.EventHandler(this.txtInfos_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "条码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "信息：";
            // 
            // openFileLabel
            // 
            this.openFileLabel.Filter = "标签|*.ltj";
            // 
            // saveFileLabel
            // 
            this.saveFileLabel.Filter = "标签|*.ltj";
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpen,
            this.tbSave,
            this.tbSaveAs,
            this.btnPrint});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(834, 25);
            this.toolBar.TabIndex = 9;
            this.toolBar.Text = "toolStrip1";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(36, 22);
            this.tbOpen.Text = "打开";
            this.tbOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(36, 22);
            this.tbSave.Text = "保存";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbSaveAs
            // 
            this.tbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tbSaveAs.Image")));
            this.tbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveAs.Name = "tbSaveAs";
            this.tbSaveAs.Size = new System.Drawing.Size(48, 22);
            this.tbSaveAs.Text = "另存为";
            this.tbSaveAs.Click += new System.EventHandler(this.tbSaveAs_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(36, 22);
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tabProLabel
            // 
            this.tabProLabel.Controls.Add(this.tabPage1);
            this.tabProLabel.Controls.Add(this.tabPage2);
            this.tabProLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabProLabel.Location = new System.Drawing.Point(0, 25);
            this.tabProLabel.Name = "tabProLabel";
            this.tabProLabel.SelectedIndex = 0;
            this.tabProLabel.Size = new System.Drawing.Size(834, 305);
            this.tabProLabel.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.preLabel);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtBarCode);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtInfos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "商品标签(40*30)";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.previewControl2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtInfoOther);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他标签";
            // 
            // previewControl2
            // 
            this.previewControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.previewControl2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.previewControl2.Buttons = FastReport.PreviewButtons.Zoom;
            this.previewControl2.Font = new System.Drawing.Font("宋体", 9F);
            this.previewControl2.Location = new System.Drawing.Point(435, 3);
            this.previewControl2.Margin = new System.Windows.Forms.Padding(0);
            this.previewControl2.Name = "previewControl2";
            this.previewControl2.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl2.Size = new System.Drawing.Size(335, 254);
            this.previewControl2.StatusbarVisible = false;
            this.previewControl2.TabIndex = 8;
            this.previewControl2.ToolbarVisible = false;
            this.previewControl2.UIStyle = FastReport.Utils.UIStyle.Office2013;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "信息：";
            // 
            // txtInfoOther
            // 
            this.txtInfoOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfoOther.Location = new System.Drawing.Point(48, 6);
            this.txtInfoOther.Multiline = true;
            this.txtInfoOther.Name = "txtInfoOther";
            this.txtInfoOther.Size = new System.Drawing.Size(367, 251);
            this.txtInfoOther.TabIndex = 3;
            this.txtInfoOther.TextChanged += new System.EventHandler(this.txtInfoOther_TextChanged);
            // 
            // report2
            // 
            this.report2.NeedRefresh = false;
            this.report2.ReportResourceString = resources.GetString("report2.ReportResourceString");
            // 
            // priDialog
            // 
            this.priDialog.AllowPrintToFile = false;
            this.priDialog.ShowNetwork = false;
            // 
            // preLabel
            // 
            this.preLabel.Location = new System.Drawing.Point(502, 6);
            this.preLabel.Name = "preLabel";
            this.preLabel.Size = new System.Drawing.Size(263, 255);
            this.preLabel.TabIndex = 7;
            // 
            // FrBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 330);
            this.Controls.Add(this.tabProLabel);
            this.Controls.Add(this.toolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrBarCode";
            this.Text = "京东入仓商品标签打印 barCode";
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.tabProLabel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtInfos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileLabel;
        private System.Windows.Forms.SaveFileDialog saveFileLabel;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbSaveAs;
        private System.Windows.Forms.TabControl tabProLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInfoOther;
        private FastReport.Preview.PreviewControl previewControl2;
        private FastReport.Report report2;
        private System.Windows.Forms.PrintDialog priDialog;
        private System.Windows.Forms.Panel preLabel;
    }
}

