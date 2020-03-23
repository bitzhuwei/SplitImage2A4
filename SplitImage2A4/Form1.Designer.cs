namespace SplitImage2A4
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
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnOpen = new System.Windows.Forms.Button();
			this.imgSource = new System.Windows.Forms.PictureBox();
			this.txtImageInfo = new System.Windows.Forms.TextBox();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.btnSplit = new System.Windows.Forms.Button();
			this.rdoVertical = new System.Windows.Forms.RadioButton();
			this.rdoHorizontal = new System.Windows.Forms.RadioButton();
			this.cmbSolution = new System.Windows.Forms.ComboBox();
			this.btnCreate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.imgSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Font = new System.Drawing.Font("宋体", 14F);
			this.btnOpen.Location = new System.Drawing.Point(12, 12);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(106, 34);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// imgSource
			// 
			this.imgSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imgSource.Location = new System.Drawing.Point(12, 110);
			this.imgSource.Name = "imgSource";
			this.imgSource.Size = new System.Drawing.Size(964, 524);
			this.imgSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgSource.TabIndex = 1;
			this.imgSource.TabStop = false;
			// 
			// txtImageInfo
			// 
			this.txtImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImageInfo.Font = new System.Drawing.Font("宋体", 16F);
			this.txtImageInfo.Location = new System.Drawing.Point(12, 52);
			this.txtImageInfo.Multiline = true;
			this.txtImageInfo.Name = "txtImageInfo";
			this.txtImageInfo.ReadOnly = true;
			this.txtImageInfo.Size = new System.Drawing.Size(964, 52);
			this.txtImageInfo.TabIndex = 2;
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = "*.*|*.*";
			// 
			// btnSplit
			// 
			this.btnSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSplit.Font = new System.Drawing.Font("宋体", 14F);
			this.btnSplit.Location = new System.Drawing.Point(870, 12);
			this.btnSplit.Name = "btnSplit";
			this.btnSplit.Size = new System.Drawing.Size(106, 34);
			this.btnSplit.TabIndex = 0;
			this.btnSplit.Text = "Split";
			this.btnSplit.UseVisualStyleBackColor = true;
			this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
			// 
			// rdoVertical
			// 
			this.rdoVertical.AutoSize = true;
			this.rdoVertical.Checked = true;
			this.rdoVertical.Font = new System.Drawing.Font("宋体", 14F);
			this.rdoVertical.Location = new System.Drawing.Point(124, 18);
			this.rdoVertical.Name = "rdoVertical";
			this.rdoVertical.Size = new System.Drawing.Size(65, 23);
			this.rdoVertical.TabIndex = 4;
			this.rdoVertical.TabStop = true;
			this.rdoVertical.Text = "纵向";
			this.rdoVertical.UseVisualStyleBackColor = true;
			this.rdoVertical.CheckedChanged += new System.EventHandler(this.rdoVertical_CheckedChanged);
			// 
			// rdoHorizontal
			// 
			this.rdoHorizontal.AutoSize = true;
			this.rdoHorizontal.Font = new System.Drawing.Font("宋体", 14F);
			this.rdoHorizontal.Location = new System.Drawing.Point(195, 18);
			this.rdoHorizontal.Name = "rdoHorizontal";
			this.rdoHorizontal.Size = new System.Drawing.Size(65, 23);
			this.rdoHorizontal.TabIndex = 4;
			this.rdoHorizontal.Text = "横向";
			this.rdoHorizontal.UseVisualStyleBackColor = true;
			this.rdoHorizontal.CheckedChanged += new System.EventHandler(this.rdoHorizontal_CheckedChanged);
			// 
			// cmbSolution
			// 
			this.cmbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSolution.Font = new System.Drawing.Font("宋体", 14F);
			this.cmbSolution.FormattingEnabled = true;
			this.cmbSolution.Location = new System.Drawing.Point(266, 17);
			this.cmbSolution.Name = "cmbSolution";
			this.cmbSolution.Size = new System.Drawing.Size(477, 27);
			this.cmbSolution.TabIndex = 5;
			// 
			// btnCreate
			// 
			this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreate.Font = new System.Drawing.Font("宋体", 14F);
			this.btnCreate.Location = new System.Drawing.Point(749, 12);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(93, 34);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "New...";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(988, 646);
			this.Controls.Add(this.cmbSolution);
			this.Controls.Add(this.rdoHorizontal);
			this.Controls.Add(this.rdoVertical);
			this.Controls.Add(this.txtImageInfo);
			this.Controls.Add(this.imgSource);
			this.Controls.Add(this.btnSplit);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.btnOpen);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Split Image to A4 size.";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.imgSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.PictureBox imgSource;
		private System.Windows.Forms.TextBox txtImageInfo;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.Button btnSplit;
		private System.Windows.Forms.RadioButton rdoVertical;
		private System.Windows.Forms.RadioButton rdoHorizontal;
		private System.Windows.Forms.ComboBox cmbSolution;
		private System.Windows.Forms.Button btnCreate;
	}
}

