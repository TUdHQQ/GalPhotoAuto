using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D7 RID: 215
	[DesignerGenerated]
	public partial class Form3 : Form
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x00037B30 File Offset: 0x00035D30
		public Form3()
		{
			base.Load += this.e;
			base.HandleCreated += this.Form3_HandleCreated;
			string[,] array = new string[11, 2];
			array[0, 0] = "perseus";
			array[0, 1] = "four_402";
			array[1, 0] = "suigetsu_2";
			array[1, 1] = "three_314";
			array[2, 0] = "rebirth_colony";
			array[2, 1] = "three_311";
			array[3, 0] = "triagain";
			array[3, 1] = "three_315";
			array[4, 0] = "まじこいＡ－１";
			array[4, 1] = "four_403";
			array[5, 0] = "MaterialBraveIgnition";
			array[5, 1] = "four_403";
			array[6, 0] = "Nirvana";
			array[6, 1] = "five_502";
			array[7, 0] = "星彩のレゾナンス";
			array[7, 1] = "four_406";
			array[8, 0] = "祝祭の歌姫";
			array[8, 1] = "three_315";
			array[9, 0] = "逆王道";
			array[9, 1] = "three_317";
			array[10, 0] = "ikedukuri";
			array[10, 1] = "five_500";
			this.s = array;
			this.a();
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00037CE4 File Offset: 0x00035EE4
		[DebuggerStepThrough]
		private void a()
		{
			this.GroupBox1 = new GroupBox();
			this.LinkLabel1 = new LinkLabel();
			this.FlowLayoutPanel1 = new FlowLayoutPanel();
			this.Label1 = new Label();
			this.NumericUpDown1 = new NumericUpDown();
			this.Label2 = new Label();
			this.NumericUpDown2 = new NumericUpDown();
			this.GroupBox2 = new GroupBox();
			this.Button1 = new Button();
			this.FlowLayoutPanel2 = new FlowLayoutPanel();
			this.Label3 = new Label();
			this.TextBox1 = new TextBox();
			this.GroupBox3 = new GroupBox();
			this.CheckBox1 = new CheckBox();
			this.Label4 = new Label();
			this.Label5 = new Label();
			this.LinkLabel2 = new LinkLabel();
			this.GroupBox1.SuspendLayout();
			this.FlowLayoutPanel1.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown1).BeginInit();
			((ISupportInitialize)this.NumericUpDown2).BeginInit();
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
			Control groupBox = this.GroupBox1;
			Point location = new Point(12, 12);
			groupBox.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			Control groupBox2 = this.GroupBox1;
			Size size = new Size(477, 151);
			groupBox2.Size = size;
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "定义起点 X，Y 坐标 / X，Y 偏移量";
			this.LinkLabel1.AutoSize = true;
			Control linkLabel = this.LinkLabel1;
			location = new Point(4, 75);
			linkLabel.Location = location;
			this.LinkLabel1.Name = "LinkLabel1";
			Control linkLabel2 = this.LinkLabel1;
			size = new Size(353, 12);
			linkLabel2.Size = size;
			this.LinkLabel1.TabIndex = 1;
			this.LinkLabel1.TabStop = true;
			this.LinkLabel1.Text = "模式一：手动添加底面，面图片的起点 X，Y 在\"特别设定\"里设定";
			this.FlowLayoutPanel1.AutoSize = true;
			this.FlowLayoutPanel1.Controls.Add(this.Label1);
			this.FlowLayoutPanel1.Controls.Add(this.NumericUpDown1);
			this.FlowLayoutPanel1.Controls.Add(this.Label2);
			this.FlowLayoutPanel1.Controls.Add(this.NumericUpDown2);
			Control flowLayoutPanel = this.FlowLayoutPanel1;
			location = new Point(6, 20);
			flowLayoutPanel.Location = location;
			this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
			Control flowLayoutPanel2 = this.FlowLayoutPanel1;
			size = new Size(271, 27);
			flowLayoutPanel2.Size = size;
			this.FlowLayoutPanel1.TabIndex = 2;
			this.Label1.AutoSize = true;
			Control label = this.Label1;
			location = new Point(3, 7);
			label.Location = location;
			Control label2 = this.Label1;
			Padding margin = new Padding(3, 7, 3, 0);
			label2.Margin = margin;
			this.Label1.Name = "Label1";
			Control label3 = this.Label1;
			size = new Size(23, 12);
			label3.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "X：";
			Control numericUpDown = this.NumericUpDown1;
			location = new Point(32, 3);
			numericUpDown.Location = location;
			NumericUpDown numericUpDown2 = this.NumericUpDown1;
			decimal num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown2.Maximum = num;
			NumericUpDown numericUpDown3 = this.NumericUpDown1;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				int.MinValue
			});
			numericUpDown3.Minimum = num;
			this.NumericUpDown1.Name = "NumericUpDown1";
			Control numericUpDown4 = this.NumericUpDown1;
			size = new Size(70, 21);
			numericUpDown4.Size = size;
			this.NumericUpDown1.TabIndex = 1;
			this.Label2.AutoSize = true;
			Control label4 = this.Label2;
			location = new Point(113, 7);
			label4.Location = location;
			Control label5 = this.Label2;
			margin = new Padding(8, 7, 3, 0);
			label5.Margin = margin;
			this.Label2.Name = "Label2";
			Control label6 = this.Label2;
			size = new Size(23, 12);
			label6.Size = size;
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Y：";
			Control numericUpDown5 = this.NumericUpDown2;
			location = new Point(142, 3);
			numericUpDown5.Location = location;
			NumericUpDown numericUpDown6 = this.NumericUpDown2;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown6.Maximum = num;
			NumericUpDown numericUpDown7 = this.NumericUpDown2;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				int.MinValue
			});
			numericUpDown7.Minimum = num;
			this.NumericUpDown2.Name = "NumericUpDown2";
			Control numericUpDown8 = this.NumericUpDown2;
			size = new Size(70, 21);
			numericUpDown8.Size = size;
			this.NumericUpDown2.TabIndex = 3;
			this.GroupBox2.AutoSize = true;
			this.GroupBox2.Controls.Add(this.Button1);
			this.GroupBox2.Controls.Add(this.FlowLayoutPanel2);
			Control groupBox3 = this.GroupBox2;
			location = new Point(12, 169);
			groupBox3.Location = location;
			this.GroupBox2.Name = "GroupBox2";
			Control groupBox4 = this.GroupBox2;
			size = new Size(363, 111);
			groupBox4.Size = size;
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "针对个别游戏";
			Control button = this.Button1;
			location = new Point(127, 61);
			button.Location = location;
			this.Button1.Name = "Button1";
			Control button2 = this.Button1;
			size = new Size(100, 30);
			button2.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "验 证";
			this.Button1.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel2.AutoSize = true;
			this.FlowLayoutPanel2.Controls.Add(this.Label3);
			this.FlowLayoutPanel2.Controls.Add(this.TextBox1);
			Control flowLayoutPanel3 = this.FlowLayoutPanel2;
			location = new Point(6, 20);
			flowLayoutPanel3.Location = location;
			this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
			Control flowLayoutPanel4 = this.FlowLayoutPanel2;
			size = new Size(319, 32);
			flowLayoutPanel4.Size = size;
			this.FlowLayoutPanel2.TabIndex = 0;
			this.Label3.AutoSize = true;
			Control label7 = this.Label3;
			location = new Point(3, 7);
			label7.Location = location;
			Control label8 = this.Label3;
			margin = new Padding(3, 7, 3, 0);
			label8.Margin = margin;
			this.Label3.Name = "Label3";
			Control label9 = this.Label3;
			size = new Size(71, 12);
			label9.Size = size;
			this.Label3.TabIndex = 0;
			this.Label3.Text = "游戏exe名：";
			Control textBox = this.TextBox1;
			location = new Point(80, 3);
			textBox.Location = location;
			this.TextBox1.MaxLength = 256;
			this.TextBox1.Name = "TextBox1";
			Control textBox2 = this.TextBox1;
			size = new Size(160, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 1;
			this.GroupBox3.AutoSize = true;
			this.GroupBox3.Controls.Add(this.CheckBox1);
			Control groupBox5 = this.GroupBox3;
			location = new Point(12, 284);
			groupBox5.Location = location;
			this.GroupBox3.Name = "GroupBox3";
			Control groupBox6 = this.GroupBox3;
			size = new Size(363, 56);
			groupBox6.Size = size;
			this.GroupBox3.TabIndex = 3;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "其它";
			this.CheckBox1.AutoSize = true;
			Control checkBox = this.CheckBox1;
			location = new Point(10, 20);
			checkBox.Location = location;
			this.CheckBox1.Name = "CheckBox1";
			Control checkBox2 = this.CheckBox1;
			size = new Size(180, 16);
			checkBox2.Size = size;
			this.CheckBox1.TabIndex = 0;
			this.CheckBox1.Text = "创建文件时排除相同Hash文件";
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.Label4.AutoSize = true;
			Control label10 = this.Label4;
			location = new Point(4, 57);
			label10.Location = location;
			Control label11 = this.Label4;
			margin = new Padding(3, 7, 3, 0);
			label11.Margin = margin;
			this.Label4.Name = "Label4";
			Control label12 = this.Label4;
			size = new Size(71, 12);
			label12.Size = size;
			this.Label4.TabIndex = 3;
			this.Label4.Text = "起点 X，Y：";
			this.Label5.AutoSize = true;
			Control label13 = this.Label5;
			location = new Point(4, 103);
			label13.Location = location;
			Control label14 = this.Label5;
			margin = new Padding(3, 7, 3, 0);
			label14.Margin = margin;
			this.Label5.Name = "Label5";
			Control label15 = this.Label5;
			size = new Size(71, 12);
			label15.Size = size;
			this.Label5.TabIndex = 4;
			this.Label5.Text = "偏移 X，Y：";
			this.LinkLabel2.AutoSize = true;
			Control linkLabel3 = this.LinkLabel2;
			location = new Point(4, 122);
			linkLabel3.Location = location;
			this.LinkLabel2.Name = "LinkLabel2";
			Control linkLabel4 = this.LinkLabel2;
			size = new Size(467, 12);
			linkLabel4.Size = size;
			this.LinkLabel2.TabIndex = 5;
			this.LinkLabel2.TabStop = true;
			this.LinkLabel2.Text = "模式一：手动添加底面，两张图直接合成，仅复制面图片ALPHA为白色值的颜色到底图片";
			SizeF autoScaleDimensions = new SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			size = new Size(391, 365);
			this.ClientSize = size;
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.DoubleBuffered = true;
			this.ImeMode = ImeMode.Off;
			this.MaximizeBox = false;
			this.Name = "Form3";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "特别设定";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.FlowLayoutPanel1.ResumeLayout(false);
			this.FlowLayoutPanel1.PerformLayout();
			((ISupportInitialize)this.NumericUpDown1).EndInit();
			((ISupportInitialize)this.NumericUpDown2).EndInit();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.FlowLayoutPanel2.ResumeLayout(false);
			this.FlowLayoutPanel2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00038890 File Offset: 0x00036A90
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x000388A3 File Offset: 0x00036AA3
		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this.b;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000388AC File Offset: 0x00036AAC
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000388BF File Offset: 0x00036ABF
		internal virtual FlowLayoutPanel FlowLayoutPanel1
		{
			get
			{
				return this.c;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x000388C8 File Offset: 0x00036AC8
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x000388DB File Offset: 0x00036ADB
		internal virtual Label Label1
		{
			get
			{
				return this.d;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x000388E4 File Offset: 0x00036AE4
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x000388F8 File Offset: 0x00036AF8
		internal virtual NumericUpDown NumericUpDown1
		{
			get
			{
				return this.e;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.d);
				if (this.e != null)
				{
					this.e.ValueChanged -= value2;
				}
				this.e = value;
				if (this.e != null)
				{
					this.e.ValueChanged += value2;
				}
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00038944 File Offset: 0x00036B44
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00038957 File Offset: 0x00036B57
		internal virtual Label Label2
		{
			get
			{
				return this.f;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.f = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00038960 File Offset: 0x00036B60
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00038974 File Offset: 0x00036B74
		internal virtual NumericUpDown NumericUpDown2
		{
			get
			{
				return this.g;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.c);
				if (this.g != null)
				{
					this.g.ValueChanged -= value2;
				}
				this.g = value;
				if (this.g != null)
				{
					this.g.ValueChanged += value2;
				}
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x000389C0 File Offset: 0x00036BC0
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x000389D4 File Offset: 0x00036BD4
		internal virtual LinkLabel LinkLabel1
		{
			get
			{
				return this.h;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.b);
				if (this.h != null)
				{
					this.h.LinkClicked -= value2;
				}
				this.h = value;
				if (this.h != null)
				{
					this.h.LinkClicked += value2;
				}
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00038A20 File Offset: 0x00036C20
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00038A33 File Offset: 0x00036C33
		internal virtual GroupBox GroupBox2
		{
			get
			{
				return this.i;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.i = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00038A3C File Offset: 0x00036C3C
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00038A4F File Offset: 0x00036C4F
		internal virtual FlowLayoutPanel FlowLayoutPanel2
		{
			get
			{
				return this.j;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.j = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00038A58 File Offset: 0x00036C58
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00038A6B File Offset: 0x00036C6B
		internal virtual Label Label3
		{
			get
			{
				return this.k;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.k = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00038A74 File Offset: 0x00036C74
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x00038A87 File Offset: 0x00036C87
		internal virtual TextBox TextBox1
		{
			get
			{
				return this.l;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.l = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00038A90 File Offset: 0x00036C90
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00038AA4 File Offset: 0x00036CA4
		internal virtual Button Button1
		{
			get
			{
				return this.m;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.b);
				if (this.m != null)
				{
					this.m.Click -= value2;
				}
				this.m = value;
				if (this.m != null)
				{
					this.m.Click += value2;
				}
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00038AF0 File Offset: 0x00036CF0
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00038B03 File Offset: 0x00036D03
		internal virtual GroupBox GroupBox3
		{
			get
			{
				return this.n;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.n = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00038B0C File Offset: 0x00036D0C
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00038B20 File Offset: 0x00036D20
		internal virtual CheckBox CheckBox1
		{
			get
			{
				return this.o;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.a);
				if (this.o != null)
				{
					this.o.CheckedChanged -= value2;
				}
				this.o = value;
				if (this.o != null)
				{
					this.o.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x00038B6C File Offset: 0x00036D6C
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x00038B7F File Offset: 0x00036D7F
		internal virtual Label Label4
		{
			get
			{
				return this.p;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.p = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00038B88 File Offset: 0x00036D88
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x00038B9C File Offset: 0x00036D9C
		internal virtual LinkLabel LinkLabel2
		{
			get
			{
				return this.q;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.a);
				if (this.q != null)
				{
					this.q.LinkClicked -= value2;
				}
				this.q = value;
				if (this.q != null)
				{
					this.q.LinkClicked += value2;
				}
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00038BE8 File Offset: 0x00036DE8
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x00038BFB File Offset: 0x00036DFB
		internal virtual Label Label5
		{
			get
			{
				return this.r;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.r = value;
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00038C04 File Offset: 0x00036E04
		public void initLanguage()
		{
			this.Text = x.ad.getMultiLingual("GUI_Button7_Text");
			this.GroupBox1.Text = x.ad.getMultiLingual("Form3_GUI_GroupBox1_Text");
			this.Label4.Text = x.ad.getMultiLingual("Form3_GUI_Label4_Text");
			this.Label5.Text = x.ad.getMultiLingual("Form3_GUI_Label5_Text");
			this.LinkLabel1.Text = x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_112");
			this.LinkLabel2.Text = x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_120");
			this.GroupBox2.Text = x.ad.getMultiLingual("Form3_GUI_GroupBox2_Text");
			this.Label3.Text = x.ad.getMultiLingual("Form3_GUI_Label3_Text");
			this.Button1.Text = x.ad.getMultiLingual("Form3_GUI_Button1_Text");
			this.GroupBox3.Text = x.ad.getMultiLingual("Form3_GUI_GroupBox3_Text");
			this.CheckBox1.Text = x.ad.getMultiLingual("Form3_GUI_CheckBox1_Text");
			this.CheckBox1.Checked = (x.x != 0);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00038D3D File Offset: 0x00036F3D
		private void e(object A_0, EventArgs A_1)
		{
			this.initLanguage();
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00038D48 File Offset: 0x00036F48
		public void Form3_HandleCreated(object sender, EventArgs e)
		{
			bool flag = false;
			string value = x.ag.getValue("iF3NumUpDown1");
			if (string.IsNullOrEmpty(value))
			{
				x.ag.Remove("iF3NumUpDown1");
				x.ag.Add("iF3NumUpDown1", "0");
				this.NumericUpDown1.Value = 0m;
				flag = true;
			}
			else if (Versioned.IsNumeric(value))
			{
				this.NumericUpDown1.Value = new decimal(Conversions.ToInteger(value));
				x.ab = Convert.ToInt32(this.NumericUpDown1.Value);
			}
			else
			{
				x.ag.Remove("iF3NumUpDown1");
				x.ag.Add("iF3NumUpDown1", "0");
				this.NumericUpDown1.Value = 0m;
				flag = true;
			}
			value = x.ag.getValue("iF3NumUpDown2");
			if (string.IsNullOrEmpty(value))
			{
				x.ag.Remove("iF3NumUpDown2");
				x.ag.Add("iF3NumUpDown2", "0");
				this.NumericUpDown2.Value = 0m;
				flag = true;
			}
			else if (Versioned.IsNumeric(value))
			{
				this.NumericUpDown2.Value = new decimal(Conversions.ToInteger(value));
				x.ac = Convert.ToInt32(this.NumericUpDown2.Value);
			}
			else
			{
				x.ag.Remove("iF3NumUpDown2");
				x.ag.Add("iF3NumUpDown2", "0");
				this.NumericUpDown2.Value = 0m;
				flag = true;
			}
			if (flag)
			{
				x.ag.Save();
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00038ED6 File Offset: 0x000370D6
		private void b(object A_0, LinkLabelLinkClickedEventArgs A_1)
		{
			this.a("one_112");
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00038EE3 File Offset: 0x000370E3
		private void a(object A_0, LinkLabelLinkClickedEventArgs A_1)
		{
			this.a("one_120");
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00038EF0 File Offset: 0x000370F0
		private void d(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				x.ab = Convert.ToInt32(this.NumericUpDown1.Value);
				x.ag.Update("iF3NumUpDown1", Conversions.ToString(this.NumericUpDown1.Value));
				x.ag.Save();
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00038F44 File Offset: 0x00037144
		private void c(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				x.ac = Convert.ToInt32(this.NumericUpDown2.Value);
				x.ag.Update("iF3NumUpDown2", Conversions.ToString(this.NumericUpDown2.Value));
				x.ag.Save();
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00038F98 File Offset: 0x00037198
		private void b(object A_0, EventArgs A_1)
		{
			string text = this.TextBox1.Text.ToLower();
			if (2 > text.Length)
			{
				x.aa = string.Empty;
				t.b().n().ToolStripStatusLabel2.Text = string.Empty;
				return;
			}
			string text2 = string.Empty;
			int num = 0;
			checked
			{
				int num2 = this.s.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (0 == string.Compare(this.s[i, 0].ToLower(), text, StringComparison.Ordinal))
					{
						text2 = this.s[i, 1];
						break;
					}
				}
				if (4 < text2.Length)
				{
					x.aa = text;
					t.b().n().ToolStripStatusLabel2.Text = text;
					this.a(text2);
				}
				else
				{
					x.aa = string.Empty;
					t.b().n().ToolStripStatusLabel2.Text = string.Empty;
					Interaction.MsgBox("NO!", MsgBoxStyle.OkOnly, null);
				}
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00039090 File Offset: 0x00037290
		private void a(string A_0)
		{
			x.SetForegroundWindow(t.b().n().Handle);
			if (t.b().n().DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectLess(0, t.b().n().DoubleBufferTreeView1.SelectedNode.Tag, false))
			{
				t.b().n().DoubleBufferTreeView1.SelectedNode.ForeColor = t.b().n().DoubleBufferTreeView1.ForeColor;
				t.b().n().DoubleBufferTreeView1.SelectedNode.BackColor = t.b().n().DoubleBufferTreeView1.BackColor;
			}
			Form1 form = t.b().n();
			TreeNodeCollection nodes = t.b().n().DoubleBufferTreeView1.Nodes;
			form.DoubleBufferTreeView1SelectedNode(A_0, ref nodes);
			t.b().n().DoubleBufferTreeView1.Focus();
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00039188 File Offset: 0x00037388
		private void a(object A_0, EventArgs A_1)
		{
			x.x = Conversions.ToInteger(Conversion.Int(this.CheckBox1.Checked));
			if (this.IsHandleCreated)
			{
				x.ag.Update("i2CheckHash", Conversions.ToString(x.x));
				x.ag.Save();
			}
		}

		// Token: 0x0400041D RID: 1053
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox b;

		// Token: 0x0400041E RID: 1054
		[AccessedThroughProperty("FlowLayoutPanel1")]
		private FlowLayoutPanel c;

		// Token: 0x0400041F RID: 1055
		[AccessedThroughProperty("Label1")]
		private Label d;

		// Token: 0x04000420 RID: 1056
		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown e;

		// Token: 0x04000421 RID: 1057
		[AccessedThroughProperty("Label2")]
		private Label f;

		// Token: 0x04000422 RID: 1058
		[AccessedThroughProperty("NumericUpDown2")]
		private NumericUpDown g;

		// Token: 0x04000423 RID: 1059
		[AccessedThroughProperty("LinkLabel1")]
		private LinkLabel h;

		// Token: 0x04000424 RID: 1060
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox i;

		// Token: 0x04000425 RID: 1061
		[AccessedThroughProperty("FlowLayoutPanel2")]
		private FlowLayoutPanel j;

		// Token: 0x04000426 RID: 1062
		[AccessedThroughProperty("Label3")]
		private Label k;

		// Token: 0x04000427 RID: 1063
		[AccessedThroughProperty("TextBox1")]
		private TextBox l;

		// Token: 0x04000428 RID: 1064
		[AccessedThroughProperty("Button1")]
		private Button m;

		// Token: 0x04000429 RID: 1065
		[AccessedThroughProperty("GroupBox3")]
		private GroupBox n;

		// Token: 0x0400042A RID: 1066
		[AccessedThroughProperty("CheckBox1")]
		private CheckBox o;

		// Token: 0x0400042B RID: 1067
		[AccessedThroughProperty("Label4")]
		private Label p;

		// Token: 0x0400042C RID: 1068
		[AccessedThroughProperty("LinkLabel2")]
		private LinkLabel q;

		// Token: 0x0400042D RID: 1069
		[AccessedThroughProperty("Label5")]
		private Label r;

		// Token: 0x0400042E RID: 1070
		private readonly string[,] s;
	}
}
