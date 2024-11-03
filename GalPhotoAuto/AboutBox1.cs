using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D4 RID: 212
	[DesignerGenerated]
	public sealed partial class AboutBox1 : Form
	{
		// Token: 0x0600040F RID: 1039 RVA: 0x00036ECB File Offset: 0x000350CB
		public AboutBox1()
		{
			base.Load += this.b;
			this.a();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00036F2C File Offset: 0x0003512C
		[DebuggerStepThrough]
		private void a()
		{
			this.TextBoxDescription = new TextBox();
			this.LabelCopyright = new Label();
			this.LabelVersion = new Label();
			this.LabelProductName = new Label();
			this.OKButton = new Button();
			this.TableLayoutPanel1 = new TableLayoutPanel();
			this.LinkLabel1 = new LinkLabel();
			this.LabelAuthorize = new Label();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.TextBoxDescription.BackColor = SystemColors.Window;
			this.TextBoxDescription.Dock = DockStyle.Fill;
			this.TextBoxDescription.ForeColor = SystemColors.WindowText;
			Control textBoxDescription = this.TextBoxDescription;
			Point location = new Point(3, 123);
			textBoxDescription.Location = location;
			this.TextBoxDescription.Multiline = true;
			this.TextBoxDescription.Name = "TextBoxDescription";
			this.TextBoxDescription.ReadOnly = true;
			this.TextBoxDescription.ScrollBars = ScrollBars.Both;
			Control textBoxDescription2 = this.TextBoxDescription;
			Size size = new Size(360, 78);
			textBoxDescription2.Size = size;
			this.TextBoxDescription.TabIndex = 0;
			this.TextBoxDescription.TabStop = false;
			this.TextBoxDescription.Text = "本软件用于转换或合成GALGAME解包后的图片。\r\n\r\n如果有需要或问题可Email至：ztjal@ztjal.info";
			this.LabelCopyright.Dock = DockStyle.Fill;
			Control labelCopyright = this.LabelCopyright;
			location = new Point(3, 44);
			labelCopyright.Location = location;
			Control labelCopyright2 = this.LabelCopyright;
			size = new Size(0, 16);
			labelCopyright2.MaximumSize = size;
			this.LabelCopyright.Name = "LabelCopyright";
			Control labelCopyright3 = this.LabelCopyright;
			size = new Size(360, 16);
			labelCopyright3.Size = size;
			this.LabelCopyright.TabIndex = 0;
			this.LabelCopyright.Text = "版权";
			this.LabelCopyright.TextAlign = ContentAlignment.MiddleLeft;
			this.LabelVersion.Dock = DockStyle.Fill;
			Control labelVersion = this.LabelVersion;
			location = new Point(3, 22);
			labelVersion.Location = location;
			Control labelVersion2 = this.LabelVersion;
			size = new Size(0, 16);
			labelVersion2.MaximumSize = size;
			this.LabelVersion.Name = "LabelVersion";
			Control labelVersion3 = this.LabelVersion;
			size = new Size(360, 16);
			labelVersion3.Size = size;
			this.LabelVersion.TabIndex = 0;
			this.LabelVersion.Text = "版本";
			this.LabelVersion.TextAlign = ContentAlignment.MiddleLeft;
			this.LabelProductName.Dock = DockStyle.Fill;
			Control labelProductName = this.LabelProductName;
			location = new Point(3, 0);
			labelProductName.Location = location;
			Control labelProductName2 = this.LabelProductName;
			size = new Size(0, 16);
			labelProductName2.MaximumSize = size;
			this.LabelProductName.Name = "LabelProductName";
			Control labelProductName3 = this.LabelProductName;
			size = new Size(360, 16);
			labelProductName3.Size = size;
			this.LabelProductName.TabIndex = 0;
			this.LabelProductName.Text = "产品名称";
			this.LabelProductName.TextAlign = ContentAlignment.MiddleLeft;
			this.OKButton.DialogResult = DialogResult.Cancel;
			this.OKButton.Dock = DockStyle.Fill;
			Control okbutton = this.OKButton;
			location = new Point(3, 207);
			okbutton.Location = location;
			this.OKButton.Name = "OKButton";
			Control okbutton2 = this.OKButton;
			size = new Size(360, 36);
			okbutton2.Size = size;
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK(&O)";
			this.TableLayoutPanel1.ColumnCount = 1;
			this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel1.Controls.Add(this.LabelProductName, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.OKButton, 0, 6);
			this.TableLayoutPanel1.Controls.Add(this.LabelVersion, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.TextBoxDescription, 0, 5);
			this.TableLayoutPanel1.Controls.Add(this.LabelCopyright, 0, 2);
			this.TableLayoutPanel1.Controls.Add(this.LinkLabel1, 0, 3);
			this.TableLayoutPanel1.Controls.Add(this.LabelAuthorize, 0, 4);
			this.TableLayoutPanel1.Dock = DockStyle.Fill;
			Control tableLayoutPanel = this.TableLayoutPanel1;
			location = new Point(9, 8);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 7;
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42f));
			Control tableLayoutPanel2 = this.TableLayoutPanel1;
			size = new Size(366, 246);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 2;
			this.LinkLabel1.AutoSize = true;
			this.LinkLabel1.Dock = DockStyle.Left;
			Control linkLabel = this.LinkLabel1;
			location = new Point(3, 66);
			linkLabel.Location = location;
			this.LinkLabel1.Name = "LinkLabel1";
			Control linkLabel2 = this.LinkLabel1;
			size = new Size(197, 22);
			linkLabel2.Size = size;
			this.LinkLabel1.TabIndex = 5;
			this.LinkLabel1.TabStop = true;
			this.LinkLabel1.Text = "官方博客：http://blog.ztjal.info";
			this.LabelAuthorize.Dock = DockStyle.Fill;
			Control labelAuthorize = this.LabelAuthorize;
			location = new Point(3, 88);
			labelAuthorize.Location = location;
			this.LabelAuthorize.Name = "LabelAuthorize";
			Control labelAuthorize2 = this.LabelAuthorize;
			size = new Size(360, 32);
			labelAuthorize2.Size = size;
			this.LabelAuthorize.TabIndex = 6;
			this.LabelAuthorize.Text = "授权";
			SizeF autoScaleDimensions = new SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(384, 262);
			this.ClientSize = size;
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox1";
			Padding padding = new Padding(9, 8, 9, 8);
			this.Padding = padding;
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "AboutBox1";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00037618 File Offset: 0x00035818
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x0003762B File Offset: 0x0003582B
		internal TextBox TextBoxDescription
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

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00037634 File Offset: 0x00035834
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x00037647 File Offset: 0x00035847
		internal Label LabelCopyright
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

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00037650 File Offset: 0x00035850
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x00037663 File Offset: 0x00035863
		internal Label LabelVersion
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

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0003766C File Offset: 0x0003586C
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x0003767F File Offset: 0x0003587F
		internal Label LabelProductName
		{
			get
			{
				return this.e;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00037688 File Offset: 0x00035888
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0003769B File Offset: 0x0003589B
		internal Button OKButton
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

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x000376A4 File Offset: 0x000358A4
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x000376B7 File Offset: 0x000358B7
		internal TableLayoutPanel TableLayoutPanel1
		{
			get
			{
				return this.g;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x000376C0 File Offset: 0x000358C0
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x000376D4 File Offset: 0x000358D4
		internal LinkLabel LinkLabel1
		{
			get
			{
				return this.h;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.a);
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

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00037720 File Offset: 0x00035920
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00037733 File Offset: 0x00035933
		internal Label LabelAuthorize
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

		// Token: 0x06000422 RID: 1058 RVA: 0x0003773C File Offset: 0x0003593C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void b(object A_0, EventArgs A_1)
		{
			string arg;
			if (Operators.CompareString(t.d().Info.Title, "", false) != 0)
			{
				arg = t.d().Info.Title;
			}
			else
			{
				arg = Path.GetFileNameWithoutExtension(t.d().Info.AssemblyName);
			}
			this.LabelProductName.Text = t.d().Info.ProductName;
			this.LabelCopyright.Text = t.d().Info.Copyright;
			if (0 == string.Compare(x.ae, "zh-CN", StringComparison.Ordinal))
			{
				this.Text = string.Format("关于 {0}", arg);
				this.LabelVersion.Text = string.Format("版本 {0} Beta", t.d().Info.Version.ToString());
				this.LinkLabel1.Text = "官方博客：http://blog.ztjal.info";
				this.TextBoxDescription.Text = "本软件用于转换或合成GALGAME解包后的图片。\r\n\r\n如果有需要或问题可Email至: ztjal@ztjal.info";
				this.LabelAuthorize.Text = string.Format("本软件授权给 {0} 进行非商业性的免费使用", Environment.UserName);
			}
			else
			{
				this.Text = string.Format("About {0}", t.b().n().Text);
				this.LabelVersion.Text = string.Format("Version {0} Beta", t.d().Info.Version.ToString());
				this.LinkLabel1.Text = "Official blog：http://blog.ztjal.info";
				this.LabelAuthorize.Text = string.Format("This software licensing to {0} for free for non-commercial use.", Environment.UserName);
				this.TextBoxDescription.Text = "This software is used to convert or synthetic GALGAME unpacked picture.\r\n\r\nIf you need help or have questions you can Email to: ztjal@ztjal.info";
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000378CF File Offset: 0x00035ACF
		private void a(object A_0, EventArgs A_1)
		{
			this.Close();
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000378D7 File Offset: 0x00035AD7
		private void a(object A_0, LinkLabelLinkClickedEventArgs A_1)
		{
			Process.Start("http://blog.ztjal.info");
		}

		// Token: 0x040003F7 RID: 1015
		[AccessedThroughProperty("TextBoxDescription")]
		private TextBox b;

		// Token: 0x040003F8 RID: 1016
		[AccessedThroughProperty("LabelCopyright")]
		private Label c;

		// Token: 0x040003F9 RID: 1017
		[AccessedThroughProperty("LabelVersion")]
		private Label d;

		// Token: 0x040003FA RID: 1018
		[AccessedThroughProperty("LabelProductName")]
		private Label e;

		// Token: 0x040003FB RID: 1019
		[AccessedThroughProperty("OKButton")]
		private Button f;

		// Token: 0x040003FC RID: 1020
		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel g;

		// Token: 0x040003FD RID: 1021
		[AccessedThroughProperty("LinkLabel1")]
		private LinkLabel h;

		// Token: 0x040003FE RID: 1022
		[AccessedThroughProperty("LabelAuthorize")]
		private Label i;
	}
}
