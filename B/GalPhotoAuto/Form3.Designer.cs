namespace GalPhotoAuto
{
	// Token: 0x020000D9 RID: 217
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class Form3 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x000377FC File Offset: 0x000359FC
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0003783C File Offset: 0x00035A3C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.LinkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.FlowLayoutPanel1 = new global::System.Windows.Forms.FlowLayoutPanel();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.NumericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.NumericUpDown2 = new global::System.Windows.Forms.NumericUpDown();
			this.GroupBox2 = new global::System.Windows.Forms.GroupBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.FlowLayoutPanel2 = new global::System.Windows.Forms.FlowLayoutPanel();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.GroupBox3 = new global::System.Windows.Forms.GroupBox();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.Label4 = new global::System.Windows.Forms.Label();
			this.Label5 = new global::System.Windows.Forms.Label();
			this.LinkLabel2 = new global::System.Windows.Forms.LinkLabel();
			this.GroupBox1.SuspendLayout();
			this.FlowLayoutPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.NumericUpDown2).BeginInit();
			this.GroupBox2.SuspendLayout();
			this.FlowLayoutPanel2.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.SuspendLayout();
			this.GroupBox1.AutoSize = true;
			this.GroupBox1.Controls.Add(this.LinkLabel2);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.LinkLabel1);
			this.GroupBox1.Controls.Add(this.FlowLayoutPanel1);
			global::System.Windows.Forms.Control groupBox = this.GroupBox1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(12, 12);
			groupBox.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			global::System.Windows.Forms.Control groupBox2 = this.GroupBox1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(477, 151);
			groupBox2.Size = size;
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "定义起点 X，Y 坐标 / X，Y 偏移量";
			this.LinkLabel1.AutoSize = true;
			global::System.Windows.Forms.Control linkLabel = this.LinkLabel1;
			location = new global::System.Drawing.Point(4, 75);
			linkLabel.Location = location;
			this.LinkLabel1.Name = "LinkLabel1";
			global::System.Windows.Forms.Control linkLabel2 = this.LinkLabel1;
			size = new global::System.Drawing.Size(353, 12);
			linkLabel2.Size = size;
			this.LinkLabel1.TabIndex = 1;
			this.LinkLabel1.TabStop = true;
			this.LinkLabel1.Text = "模式一：手动添加底面，面图片的起点 X，Y 在\"特别设定\"里设定";
			this.FlowLayoutPanel1.AutoSize = true;
			this.FlowLayoutPanel1.Controls.Add(this.Label1);
			this.FlowLayoutPanel1.Controls.Add(this.NumericUpDown1);
			this.FlowLayoutPanel1.Controls.Add(this.Label2);
			this.FlowLayoutPanel1.Controls.Add(this.NumericUpDown2);
			global::System.Windows.Forms.Control flowLayoutPanel = this.FlowLayoutPanel1;
			location = new global::System.Drawing.Point(6, 20);
			flowLayoutPanel.Location = location;
			this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
			global::System.Windows.Forms.Control flowLayoutPanel2 = this.FlowLayoutPanel1;
			size = new global::System.Drawing.Size(271, 27);
			flowLayoutPanel2.Size = size;
			this.FlowLayoutPanel1.TabIndex = 2;
			this.Label1.AutoSize = true;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(3, 7);
			label.Location = location;
			global::System.Windows.Forms.Control label2 = this.Label1;
			global::System.Windows.Forms.Padding margin = new global::System.Windows.Forms.Padding(3, 7, 3, 0);
			label2.Margin = margin;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label3 = this.Label1;
			size = new global::System.Drawing.Size(23, 12);
			label3.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "X：";
			global::System.Windows.Forms.Control numericUpDown = this.NumericUpDown1;
			location = new global::System.Drawing.Point(32, 3);
			numericUpDown.Location = location;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.NumericUpDown1;
			decimal num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown2.Maximum = num;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.NumericUpDown1;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				int.MinValue
			});
			numericUpDown3.Minimum = num;
			this.NumericUpDown1.Name = "NumericUpDown1";
			global::System.Windows.Forms.Control numericUpDown4 = this.NumericUpDown1;
			size = new global::System.Drawing.Size(70, 21);
			numericUpDown4.Size = size;
			this.NumericUpDown1.TabIndex = 1;
			this.Label2.AutoSize = true;
			global::System.Windows.Forms.Control label4 = this.Label2;
			location = new global::System.Drawing.Point(113, 7);
			label4.Location = location;
			global::System.Windows.Forms.Control label5 = this.Label2;
			margin = new global::System.Windows.Forms.Padding(8, 7, 3, 0);
			label5.Margin = margin;
			this.Label2.Name = "Label2";
			global::System.Windows.Forms.Control label6 = this.Label2;
			size = new global::System.Drawing.Size(23, 12);
			label6.Size = size;
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Y：";
			global::System.Windows.Forms.Control numericUpDown5 = this.NumericUpDown2;
			location = new global::System.Drawing.Point(142, 3);
			numericUpDown5.Location = location;
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.NumericUpDown2;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown6.Maximum = num;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.NumericUpDown2;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				int.MinValue
			});
			numericUpDown7.Minimum = num;
			this.NumericUpDown2.Name = "NumericUpDown2";
			global::System.Windows.Forms.Control numericUpDown8 = this.NumericUpDown2;
			size = new global::System.Drawing.Size(70, 21);
			numericUpDown8.Size = size;
			this.NumericUpDown2.TabIndex = 3;
			this.GroupBox2.AutoSize = true;
			this.GroupBox2.Controls.Add(this.Button1);
			this.GroupBox2.Controls.Add(this.FlowLayoutPanel2);
			global::System.Windows.Forms.Control groupBox3 = this.GroupBox2;
			location = new global::System.Drawing.Point(12, 169);
			groupBox3.Location = location;
			this.GroupBox2.Name = "GroupBox2";
			global::System.Windows.Forms.Control groupBox4 = this.GroupBox2;
			size = new global::System.Drawing.Size(363, 111);
			groupBox4.Size = size;
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "针对个别游戏";
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(127, 61);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(100, 30);
			button2.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "验 证";
			this.Button1.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel2.AutoSize = true;
			this.FlowLayoutPanel2.Controls.Add(this.Label3);
			this.FlowLayoutPanel2.Controls.Add(this.TextBox1);
			global::System.Windows.Forms.Control flowLayoutPanel3 = this.FlowLayoutPanel2;
			location = new global::System.Drawing.Point(6, 20);
			flowLayoutPanel3.Location = location;
			this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
			global::System.Windows.Forms.Control flowLayoutPanel4 = this.FlowLayoutPanel2;
			size = new global::System.Drawing.Size(319, 32);
			flowLayoutPanel4.Size = size;
			this.FlowLayoutPanel2.TabIndex = 0;
			this.Label3.AutoSize = true;
			global::System.Windows.Forms.Control label7 = this.Label3;
			location = new global::System.Drawing.Point(3, 7);
			label7.Location = location;
			global::System.Windows.Forms.Control label8 = this.Label3;
			margin = new global::System.Windows.Forms.Padding(3, 7, 3, 0);
			label8.Margin = margin;
			this.Label3.Name = "Label3";
			global::System.Windows.Forms.Control label9 = this.Label3;
			size = new global::System.Drawing.Size(71, 12);
			label9.Size = size;
			this.Label3.TabIndex = 0;
			this.Label3.Text = "游戏exe名：";
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(80, 3);
			textBox.Location = location;
			this.TextBox1.MaxLength = 256;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(160, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 1;
			this.GroupBox3.AutoSize = true;
			this.GroupBox3.Controls.Add(this.CheckBox1);
			global::System.Windows.Forms.Control groupBox5 = this.GroupBox3;
			location = new global::System.Drawing.Point(12, 284);
			groupBox5.Location = location;
			this.GroupBox3.Name = "GroupBox3";
			global::System.Windows.Forms.Control groupBox6 = this.GroupBox3;
			size = new global::System.Drawing.Size(363, 56);
			groupBox6.Size = size;
			this.GroupBox3.TabIndex = 3;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "其它";
			this.CheckBox1.AutoSize = true;
			global::System.Windows.Forms.Control checkBox = this.CheckBox1;
			location = new global::System.Drawing.Point(10, 20);
			checkBox.Location = location;
			this.CheckBox1.Name = "CheckBox1";
			global::System.Windows.Forms.Control checkBox2 = this.CheckBox1;
			size = new global::System.Drawing.Size(180, 16);
			checkBox2.Size = size;
			this.CheckBox1.TabIndex = 0;
			this.CheckBox1.Text = "创建文件时排除相同Hash文件";
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.Label4.AutoSize = true;
			global::System.Windows.Forms.Control label10 = this.Label4;
			location = new global::System.Drawing.Point(4, 57);
			label10.Location = location;
			global::System.Windows.Forms.Control label11 = this.Label4;
			margin = new global::System.Windows.Forms.Padding(3, 7, 3, 0);
			label11.Margin = margin;
			this.Label4.Name = "Label4";
			global::System.Windows.Forms.Control label12 = this.Label4;
			size = new global::System.Drawing.Size(71, 12);
			label12.Size = size;
			this.Label4.TabIndex = 3;
			this.Label4.Text = "起点 X，Y：";
			this.Label5.AutoSize = true;
			global::System.Windows.Forms.Control label13 = this.Label5;
			location = new global::System.Drawing.Point(4, 103);
			label13.Location = location;
			global::System.Windows.Forms.Control label14 = this.Label5;
			margin = new global::System.Windows.Forms.Padding(3, 7, 3, 0);
			label14.Margin = margin;
			this.Label5.Name = "Label5";
			global::System.Windows.Forms.Control label15 = this.Label5;
			size = new global::System.Drawing.Size(71, 12);
			label15.Size = size;
			this.Label5.TabIndex = 4;
			this.Label5.Text = "偏移 X，Y：";
			this.LinkLabel2.AutoSize = true;
			global::System.Windows.Forms.Control linkLabel3 = this.LinkLabel2;
			location = new global::System.Drawing.Point(4, 122);
			linkLabel3.Location = location;
			this.LinkLabel2.Name = "LinkLabel2";
			global::System.Windows.Forms.Control linkLabel4 = this.LinkLabel2;
			size = new global::System.Drawing.Size(467, 12);
			linkLabel4.Size = size;
			this.LinkLabel2.TabIndex = 5;
			this.LinkLabel2.TabStop = true;
			this.LinkLabel2.Text = "模式一：手动添加底面，两张图直接合成，仅复制面图片ALPHA为白色值的颜色到底图片";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			size = new global::System.Drawing.Size(391, 365);
			this.ClientSize = size;
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.DoubleBuffered = true;
			this.ImeMode = global::System.Windows.Forms.ImeMode.Off;
			this.MaximizeBox = false;
			this.Name = "Form3";
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "特别设定";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.FlowLayoutPanel1.ResumeLayout(false);
			this.FlowLayoutPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.NumericUpDown2).EndInit();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.FlowLayoutPanel2.ResumeLayout(false);
			this.FlowLayoutPanel2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		// Token: 0x0400042D RID: 1069
		private global::System.ComponentModel.IContainer components;
	}
}
