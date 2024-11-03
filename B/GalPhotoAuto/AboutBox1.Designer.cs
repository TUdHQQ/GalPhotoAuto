namespace GalPhotoAuto
{
	// Token: 0x020000D6 RID: 214
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public sealed partial class AboutBox1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x00036A44 File Offset: 0x00034C44
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

		// Token: 0x06000403 RID: 1027 RVA: 0x00036A84 File Offset: 0x00034C84
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.TextBoxDescription = new global::System.Windows.Forms.TextBox();
			this.LabelCopyright = new global::System.Windows.Forms.Label();
			this.LabelVersion = new global::System.Windows.Forms.Label();
			this.LabelProductName = new global::System.Windows.Forms.Label();
			this.OKButton = new global::System.Windows.Forms.Button();
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.LinkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.LabelAuthorize = new global::System.Windows.Forms.Label();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.TextBoxDescription.BackColor = global::System.Drawing.SystemColors.Window;
			this.TextBoxDescription.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.TextBoxDescription.ForeColor = global::System.Drawing.SystemColors.WindowText;
			global::System.Windows.Forms.Control textBoxDescription = this.TextBoxDescription;
			global::System.Drawing.Point location = new global::System.Drawing.Point(3, 123);
			textBoxDescription.Location = location;
			this.TextBoxDescription.Multiline = true;
			this.TextBoxDescription.Name = "TextBoxDescription";
			this.TextBoxDescription.ReadOnly = true;
			this.TextBoxDescription.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			global::System.Windows.Forms.Control textBoxDescription2 = this.TextBoxDescription;
			global::System.Drawing.Size size = new global::System.Drawing.Size(360, 78);
			textBoxDescription2.Size = size;
			this.TextBoxDescription.TabIndex = 0;
			this.TextBoxDescription.TabStop = false;
			this.TextBoxDescription.Text = "本软件用于转换或合成GALGAME解包后的图片。\r\n\r\n如果有需要或问题可Email至：ztjal@ztjal.info";
			this.LabelCopyright.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control labelCopyright = this.LabelCopyright;
			location = new global::System.Drawing.Point(3, 44);
			labelCopyright.Location = location;
			global::System.Windows.Forms.Control labelCopyright2 = this.LabelCopyright;
			size = new global::System.Drawing.Size(0, 16);
			labelCopyright2.MaximumSize = size;
			this.LabelCopyright.Name = "LabelCopyright";
			global::System.Windows.Forms.Control labelCopyright3 = this.LabelCopyright;
			size = new global::System.Drawing.Size(360, 16);
			labelCopyright3.Size = size;
			this.LabelCopyright.TabIndex = 0;
			this.LabelCopyright.Text = "版权";
			this.LabelCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.LabelVersion.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control labelVersion = this.LabelVersion;
			location = new global::System.Drawing.Point(3, 22);
			labelVersion.Location = location;
			global::System.Windows.Forms.Control labelVersion2 = this.LabelVersion;
			size = new global::System.Drawing.Size(0, 16);
			labelVersion2.MaximumSize = size;
			this.LabelVersion.Name = "LabelVersion";
			global::System.Windows.Forms.Control labelVersion3 = this.LabelVersion;
			size = new global::System.Drawing.Size(360, 16);
			labelVersion3.Size = size;
			this.LabelVersion.TabIndex = 0;
			this.LabelVersion.Text = "版本";
			this.LabelVersion.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.LabelProductName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control labelProductName = this.LabelProductName;
			location = new global::System.Drawing.Point(3, 0);
			labelProductName.Location = location;
			global::System.Windows.Forms.Control labelProductName2 = this.LabelProductName;
			size = new global::System.Drawing.Size(0, 16);
			labelProductName2.MaximumSize = size;
			this.LabelProductName.Name = "LabelProductName";
			global::System.Windows.Forms.Control labelProductName3 = this.LabelProductName;
			size = new global::System.Drawing.Size(360, 16);
			labelProductName3.Size = size;
			this.LabelProductName.TabIndex = 0;
			this.LabelProductName.Text = "产品名称";
			this.LabelProductName.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.OKButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.OKButton.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control okbutton = this.OKButton;
			location = new global::System.Drawing.Point(3, 207);
			okbutton.Location = location;
			this.OKButton.Name = "OKButton";
			global::System.Windows.Forms.Control okbutton2 = this.OKButton;
			size = new global::System.Drawing.Size(360, 36);
			okbutton2.Size = size;
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK(&O)";
			this.TableLayoutPanel1.ColumnCount = 1;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.TableLayoutPanel1.Controls.Add(this.LabelProductName, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.OKButton, 0, 6);
			this.TableLayoutPanel1.Controls.Add(this.LabelVersion, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.TextBoxDescription, 0, 5);
			this.TableLayoutPanel1.Controls.Add(this.LabelCopyright, 0, 2);
			this.TableLayoutPanel1.Controls.Add(this.LinkLabel1, 0, 3);
			this.TableLayoutPanel1.Controls.Add(this.LabelAuthorize, 0, 4);
			this.TableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control tableLayoutPanel = this.TableLayoutPanel1;
			location = new global::System.Drawing.Point(9, 8);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 7;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 32f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 42f));
			global::System.Windows.Forms.Control tableLayoutPanel2 = this.TableLayoutPanel1;
			size = new global::System.Drawing.Size(366, 246);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 2;
			this.LinkLabel1.AutoSize = true;
			this.LinkLabel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			global::System.Windows.Forms.Control linkLabel = this.LinkLabel1;
			location = new global::System.Drawing.Point(3, 66);
			linkLabel.Location = location;
			this.LinkLabel1.Name = "LinkLabel1";
			global::System.Windows.Forms.Control linkLabel2 = this.LinkLabel1;
			size = new global::System.Drawing.Size(197, 22);
			linkLabel2.Size = size;
			this.LinkLabel1.TabIndex = 5;
			this.LinkLabel1.TabStop = true;
			this.LinkLabel1.Text = "官方博客：http://blog.ztjal.info";
			this.LabelAuthorize.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control labelAuthorize = this.LabelAuthorize;
			location = new global::System.Drawing.Point(3, 88);
			labelAuthorize.Location = location;
			this.LabelAuthorize.Name = "LabelAuthorize";
			global::System.Windows.Forms.Control labelAuthorize2 = this.LabelAuthorize;
			size = new global::System.Drawing.Size(360, 32);
			labelAuthorize2.Size = size;
			this.LabelAuthorize.TabIndex = 6;
			this.LabelAuthorize.Text = "授权";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(384, 262);
			this.ClientSize = size;
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox1";
			global::System.Windows.Forms.Padding padding = new global::System.Windows.Forms.Padding(9, 8, 9, 8);
			this.Padding = padding;
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutBox1";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
		}

		// Token: 0x04000407 RID: 1031
		private global::System.ComponentModel.IContainer components;
	}
}
