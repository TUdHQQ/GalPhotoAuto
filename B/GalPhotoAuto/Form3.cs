using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GalPhotoAuto.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D9 RID: 217
	[DesignerGenerated]
	public partial class Form3 : Form
	{
		// Token: 0x06000422 RID: 1058 RVA: 0x00037688 File Offset: 0x00035888
		public Form3()
		{
			base.Load += this.Form3_Load;
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
			this.aeGameExeArr = array;
			this.InitializeComponent();
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000383E8 File Offset: 0x000365E8
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x000383FB File Offset: 0x000365FB
		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this._GroupBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00038404 File Offset: 0x00036604
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00038417 File Offset: 0x00036617
		internal virtual FlowLayoutPanel FlowLayoutPanel1
		{
			get
			{
				return this._FlowLayoutPanel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel1 = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00038420 File Offset: 0x00036620
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x00038433 File Offset: 0x00036633
		internal virtual Label Label1
		{
			get
			{
				return this._Label1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0003843C File Offset: 0x0003663C
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00038450 File Offset: 0x00036650
		internal virtual NumericUpDown NumericUpDown1
		{
			get
			{
				return this._NumericUpDown1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown1_ValueChanged);
				if (this._NumericUpDown1 != null)
				{
					this._NumericUpDown1.ValueChanged -= value2;
				}
				this._NumericUpDown1 = value;
				if (this._NumericUpDown1 != null)
				{
					this._NumericUpDown1.ValueChanged += value2;
				}
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0003849C File Offset: 0x0003669C
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x000384AF File Offset: 0x000366AF
		internal virtual Label Label2
		{
			get
			{
				return this._Label2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000384B8 File Offset: 0x000366B8
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x000384CC File Offset: 0x000366CC
		internal virtual NumericUpDown NumericUpDown2
		{
			get
			{
				return this._NumericUpDown2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown2_ValueChanged);
				if (this._NumericUpDown2 != null)
				{
					this._NumericUpDown2.ValueChanged -= value2;
				}
				this._NumericUpDown2 = value;
				if (this._NumericUpDown2 != null)
				{
					this._NumericUpDown2.ValueChanged += value2;
				}
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00038518 File Offset: 0x00036718
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0003852C File Offset: 0x0003672C
		internal virtual LinkLabel LinkLabel1
		{
			get
			{
				return this._LinkLabel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
				if (this._LinkLabel1 != null)
				{
					this._LinkLabel1.LinkClicked -= value2;
				}
				this._LinkLabel1 = value;
				if (this._LinkLabel1 != null)
				{
					this._LinkLabel1.LinkClicked += value2;
				}
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00038578 File Offset: 0x00036778
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0003858B File Offset: 0x0003678B
		internal virtual GroupBox GroupBox2
		{
			get
			{
				return this._GroupBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox2 = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00038594 File Offset: 0x00036794
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000385A7 File Offset: 0x000367A7
		internal virtual FlowLayoutPanel FlowLayoutPanel2
		{
			get
			{
				return this._FlowLayoutPanel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel2 = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x000385B0 File Offset: 0x000367B0
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x000385C3 File Offset: 0x000367C3
		internal virtual Label Label3
		{
			get
			{
				return this._Label3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x000385CC File Offset: 0x000367CC
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x000385DF File Offset: 0x000367DF
		internal virtual TextBox TextBox1
		{
			get
			{
				return this._TextBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox1 = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x000385E8 File Offset: 0x000367E8
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x000385FC File Offset: 0x000367FC
		internal virtual Button Button1
		{
			get
			{
				return this._Button1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click);
				if (this._Button1 != null)
				{
					this._Button1.Click -= value2;
				}
				this._Button1 = value;
				if (this._Button1 != null)
				{
					this._Button1.Click += value2;
				}
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00038648 File Offset: 0x00036848
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0003865B File Offset: 0x0003685B
		internal virtual GroupBox GroupBox3
		{
			get
			{
				return this._GroupBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox3 = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00038664 File Offset: 0x00036864
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00038678 File Offset: 0x00036878
		internal virtual CheckBox CheckBox1
		{
			get
			{
				return this._CheckBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.CheckBox1_CheckedChanged);
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.CheckedChanged -= value2;
				}
				this._CheckBox1 = value;
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000386C4 File Offset: 0x000368C4
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x000386D7 File Offset: 0x000368D7
		internal virtual Label Label4
		{
			get
			{
				return this._Label4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000386E0 File Offset: 0x000368E0
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x000386F4 File Offset: 0x000368F4
		internal virtual LinkLabel LinkLabel2
		{
			get
			{
				return this._LinkLabel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
				if (this._LinkLabel2 != null)
				{
					this._LinkLabel2.LinkClicked -= value2;
				}
				this._LinkLabel2 = value;
				if (this._LinkLabel2 != null)
				{
					this._LinkLabel2.LinkClicked += value2;
				}
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00038740 File Offset: 0x00036940
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00038753 File Offset: 0x00036953
		internal virtual Label Label5
		{
			get
			{
				return this._Label5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0003875C File Offset: 0x0003695C
		public void initLanguage()
		{
			this.Text = PublicModule.thisLang.getMultiLingual("GUI_Button7_Text");
			this.GroupBox1.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_GroupBox1_Text");
			this.Label4.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_Label4_Text");
			this.Label5.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_Label5_Text");
			this.LinkLabel1.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_112");
			this.LinkLabel2.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_120");
			this.GroupBox2.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_GroupBox2_Text");
			this.Label3.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_Label3_Text");
			this.Button1.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_Button1_Text");
			this.GroupBox3.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_GroupBox3_Text");
			this.CheckBox1.Text = PublicModule.thisLang.getMultiLingual("Form3_GUI_CheckBox1_Text");
			this.CheckBox1.Checked = (PublicModule.i2CheckHash != 0);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00038895 File Offset: 0x00036A95
		private void Form3_Load(object sender, EventArgs e)
		{
			this.initLanguage();
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000388A0 File Offset: 0x00036AA0
		public void Form3_HandleCreated(object sender, EventArgs e)
		{
			bool flag = false;
			string value = PublicModule.galConfig.getValue("iF3NumUpDown1");
			if (string.IsNullOrEmpty(value))
			{
				PublicModule.galConfig.Remove("iF3NumUpDown1");
				PublicModule.galConfig.Add("iF3NumUpDown1", "0");
				this.NumericUpDown1.Value = 0m;
				flag = true;
			}
			else if (Versioned.IsNumeric(value))
			{
				this.NumericUpDown1.Value = new decimal(Conversions.ToInteger(value));
				PublicModule.iForm3Tx = Convert.ToInt32(this.NumericUpDown1.Value);
			}
			else
			{
				PublicModule.galConfig.Remove("iF3NumUpDown1");
				PublicModule.galConfig.Add("iF3NumUpDown1", "0");
				this.NumericUpDown1.Value = 0m;
				flag = true;
			}
			value = PublicModule.galConfig.getValue("iF3NumUpDown2");
			if (string.IsNullOrEmpty(value))
			{
				PublicModule.galConfig.Remove("iF3NumUpDown2");
				PublicModule.galConfig.Add("iF3NumUpDown2", "0");
				this.NumericUpDown2.Value = 0m;
				flag = true;
			}
			else if (Versioned.IsNumeric(value))
			{
				this.NumericUpDown2.Value = new decimal(Conversions.ToInteger(value));
				PublicModule.iForm3Ty = Convert.ToInt32(this.NumericUpDown2.Value);
			}
			else
			{
				PublicModule.galConfig.Remove("iF3NumUpDown2");
				PublicModule.galConfig.Add("iF3NumUpDown2", "0");
				this.NumericUpDown2.Value = 0m;
				flag = true;
			}
			if (flag)
			{
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00038A2E File Offset: 0x00036C2E
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.selectDoubleBufferTreeView1SelectedNode("one_112");
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00038A3B File Offset: 0x00036C3B
		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.selectDoubleBufferTreeView1SelectedNode("one_120");
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00038A48 File Offset: 0x00036C48
		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.iForm3Tx = Convert.ToInt32(this.NumericUpDown1.Value);
				PublicModule.galConfig.Update("iF3NumUpDown1", Conversions.ToString(this.NumericUpDown1.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00038A9C File Offset: 0x00036C9C
		private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.iForm3Ty = Convert.ToInt32(this.NumericUpDown2.Value);
				PublicModule.galConfig.Update("iF3NumUpDown2", Conversions.ToString(this.NumericUpDown2.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00038AF0 File Offset: 0x00036CF0
		private void Button1_Click(object sender, EventArgs e)
		{
			string text = this.TextBox1.Text.ToLower();
			if (2 > text.Length)
			{
				PublicModule.sGameExe = string.Empty;
				MyProject.get_Forms().get_Form1().ToolStripStatusLabel2.Text = string.Empty;
				return;
			}
			string text2 = string.Empty;
			int num = 0;
			checked
			{
				int num2 = this.aeGameExeArr.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (0 == string.Compare(this.aeGameExeArr[i, 0].ToLower(), text, StringComparison.Ordinal))
					{
						text2 = this.aeGameExeArr[i, 1];
						break;
					}
				}
				if (4 < text2.Length)
				{
					PublicModule.sGameExe = text;
					MyProject.get_Forms().get_Form1().ToolStripStatusLabel2.Text = text;
					this.selectDoubleBufferTreeView1SelectedNode(text2);
				}
				else
				{
					PublicModule.sGameExe = string.Empty;
					MyProject.get_Forms().get_Form1().ToolStripStatusLabel2.Text = string.Empty;
					Interaction.MsgBox("NO!", MsgBoxStyle.OkOnly, null);
				}
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00038BE8 File Offset: 0x00036DE8
		private void selectDoubleBufferTreeView1SelectedNode(string sName)
		{
			PublicModule.SetForegroundWindow(MyProject.get_Forms().get_Form1().Handle);
			if (MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectLess(0, MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.SelectedNode.Tag, false))
			{
				MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.SelectedNode.ForeColor = MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.ForeColor;
				MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.SelectedNode.BackColor = MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.BackColor;
			}
			Form1 form = MyProject.get_Forms().get_Form1();
			TreeNodeCollection nodes = MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.Nodes;
			form.DoubleBufferTreeView1SelectedNode(sName, ref nodes);
			MyProject.get_Forms().get_Form1().DoubleBufferTreeView1.Focus();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00038CE0 File Offset: 0x00036EE0
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			PublicModule.i2CheckHash = Conversions.ToInteger(Conversion.Int(this.CheckBox1.Checked));
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("i2CheckHash", Conversions.ToString(PublicModule.i2CheckHash));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x0400042E RID: 1070
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		// Token: 0x0400042F RID: 1071
		[AccessedThroughProperty("FlowLayoutPanel1")]
		private FlowLayoutPanel _FlowLayoutPanel1;

		// Token: 0x04000430 RID: 1072
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x04000431 RID: 1073
		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown _NumericUpDown1;

		// Token: 0x04000432 RID: 1074
		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		// Token: 0x04000433 RID: 1075
		[AccessedThroughProperty("NumericUpDown2")]
		private NumericUpDown _NumericUpDown2;

		// Token: 0x04000434 RID: 1076
		[AccessedThroughProperty("LinkLabel1")]
		private LinkLabel _LinkLabel1;

		// Token: 0x04000435 RID: 1077
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		// Token: 0x04000436 RID: 1078
		[AccessedThroughProperty("FlowLayoutPanel2")]
		private FlowLayoutPanel _FlowLayoutPanel2;

		// Token: 0x04000437 RID: 1079
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x04000438 RID: 1080
		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		// Token: 0x04000439 RID: 1081
		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		// Token: 0x0400043A RID: 1082
		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		// Token: 0x0400043B RID: 1083
		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		// Token: 0x0400043C RID: 1084
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x0400043D RID: 1085
		[AccessedThroughProperty("LinkLabel2")]
		private LinkLabel _LinkLabel2;

		// Token: 0x0400043E RID: 1086
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x0400043F RID: 1087
		private readonly string[,] aeGameExeArr;
	}
}
