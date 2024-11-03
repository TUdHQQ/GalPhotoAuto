using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GalPhotoAuto.My;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D6 RID: 214
	[DesignerGenerated]
	public sealed partial class AboutBox1 : Form
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x00036A23 File Offset: 0x00034C23
		public AboutBox1()
		{
			base.Load += this.AboutBox1_Load;
			this.InitializeComponent();
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00037170 File Offset: 0x00035370
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x00037183 File Offset: 0x00035383
		internal TextBox TextBoxDescription
		{
			get
			{
				return this._TextBoxDescription;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBoxDescription = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0003718C File Offset: 0x0003538C
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x0003719F File Offset: 0x0003539F
		internal Label LabelCopyright
		{
			get
			{
				return this._LabelCopyright;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelCopyright = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x000371A8 File Offset: 0x000353A8
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x000371BB File Offset: 0x000353BB
		internal Label LabelVersion
		{
			get
			{
				return this._LabelVersion;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelVersion = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x000371C4 File Offset: 0x000353C4
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x000371D7 File Offset: 0x000353D7
		internal Label LabelProductName
		{
			get
			{
				return this._LabelProductName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelProductName = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x000371E0 File Offset: 0x000353E0
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x000371F3 File Offset: 0x000353F3
		internal Button OKButton
		{
			get
			{
				return this._OKButton;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._OKButton = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x000371FC File Offset: 0x000353FC
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x0003720F File Offset: 0x0003540F
		internal TableLayoutPanel TableLayoutPanel1
		{
			get
			{
				return this._TableLayoutPanel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00037218 File Offset: 0x00035418
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x0003722C File Offset: 0x0003542C
		internal LinkLabel LinkLabel1
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

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00037278 File Offset: 0x00035478
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x0003728B File Offset: 0x0003548B
		internal Label LabelAuthorize
		{
			get
			{
				return this._LabelAuthorize;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelAuthorize = value;
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00037294 File Offset: 0x00035494
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void AboutBox1_Load(object sender, EventArgs e)
		{
			string arg;
			if (Operators.CompareString(MyProject.get_Application().Info.Title, "", false) != 0)
			{
				arg = MyProject.get_Application().Info.Title;
			}
			else
			{
				arg = Path.GetFileNameWithoutExtension(MyProject.get_Application().Info.AssemblyName);
			}
			this.LabelProductName.Text = MyProject.get_Application().Info.ProductName;
			this.LabelCopyright.Text = MyProject.get_Application().Info.Copyright;
			if (0 == string.Compare(PublicModule.strCultureLangName, "zh-CN", StringComparison.Ordinal))
			{
				this.Text = string.Format("关于 {0}", arg);
				this.LabelVersion.Text = string.Format("版本 {0} Beta", MyProject.get_Application().Info.Version.ToString());
				this.LinkLabel1.Text = "官方博客：http://blog.ztjal.info";
				this.TextBoxDescription.Text = "本软件用于转换或合成GALGAME解包后的图片。\r\n\r\n如果有需要或问题可Email至: ztjal@ztjal.info";
				this.LabelAuthorize.Text = string.Format("本软件授权给 {0} 进行非商业性的免费使用", Environment.UserName);
			}
			else
			{
				this.Text = string.Format("About {0}", MyProject.get_Forms().get_Form1().Text);
				this.LabelVersion.Text = string.Format("Version {0} Beta", MyProject.get_Application().Info.Version.ToString());
				this.LinkLabel1.Text = "Official blog：http://blog.ztjal.info";
				this.LabelAuthorize.Text = string.Format("This software licensing to {0} for free for non-commercial use.", Environment.UserName);
				this.TextBoxDescription.Text = "This software is used to convert or synthetic GALGAME unpacked picture.\r\n\r\nIf you need help or have questions you can Email to: ztjal@ztjal.info";
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00037427 File Offset: 0x00035627
		private void OKButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0003742F File Offset: 0x0003562F
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://blog.ztjal.info");
		}

		// Token: 0x04000408 RID: 1032
		[AccessedThroughProperty("TextBoxDescription")]
		private TextBox _TextBoxDescription;

		// Token: 0x04000409 RID: 1033
		[AccessedThroughProperty("LabelCopyright")]
		private Label _LabelCopyright;

		// Token: 0x0400040A RID: 1034
		[AccessedThroughProperty("LabelVersion")]
		private Label _LabelVersion;

		// Token: 0x0400040B RID: 1035
		[AccessedThroughProperty("LabelProductName")]
		private Label _LabelProductName;

		// Token: 0x0400040C RID: 1036
		[AccessedThroughProperty("OKButton")]
		private Button _OKButton;

		// Token: 0x0400040D RID: 1037
		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		// Token: 0x0400040E RID: 1038
		[AccessedThroughProperty("LinkLabel1")]
		private LinkLabel _LinkLabel1;

		// Token: 0x0400040F RID: 1039
		[AccessedThroughProperty("LabelAuthorize")]
		private Label _LabelAuthorize;
	}
}
