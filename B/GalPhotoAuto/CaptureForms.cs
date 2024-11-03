using System;
using System.Drawing;
using System.Windows.Forms;

namespace GalPhotoAuto
{
	// Token: 0x020000B9 RID: 185
	public partial class CaptureForms : Form
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0002495C File Offset: 0x00022B5C
		public CaptureForms()
		{
			this.f2label1 = new Label();
			this.f2label2 = new Label();
			this.f2label3 = new Label();
			this.f2label4 = new Label();
			this.InitializeComponent();
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			Screen primaryScreen = Screen.PrimaryScreen;
			Rectangle bounds = primaryScreen.Bounds;
			int width = bounds.Width;
			int height = bounds.Height;
			this.Size = primaryScreen.Bounds.Size;
			string multiLingual = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_1");
			string multiLingual2 = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_2");
			int width2 = 77;
			int num = 14;
			float emSize = (float)num;
			FontStyle style = this.f2label1.Font.Style;
			Point location;
			location.X = 0;
			location.Y = 0;
			this.f2label1.Location = location;
			this.f2label1.Text = multiLingual;
			this.f2label1.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
			this.f2label1.Width = width2;
			this.f2label1.Height = num;
			this.f2label1.BackColor = Color.White;
			this.f2label1.ForeColor = Color.Black;
			this.f2label1.AutoSize = true;
			this.f2label2.Text = multiLingual2;
			this.f2label2.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
			this.f2label2.Width = width2;
			this.f2label2.Height = num;
			this.f2label2.BackColor = Color.White;
			this.f2label2.ForeColor = Color.Black;
			this.f2label2.AutoSize = true;
			checked
			{
				location.X = width - this.f2label2.PreferredWidth;
				location.Y = 0;
				this.f2label2.Location = location;
				this.f2label3.Text = multiLingual;
				this.f2label3.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
				this.f2label3.Width = width2;
				this.f2label3.Height = num;
				this.f2label3.BackColor = Color.White;
				this.f2label3.ForeColor = Color.Black;
				this.f2label3.AutoSize = true;
				location.X = 0;
				location.Y = height - this.f2label3.PreferredHeight;
				this.f2label3.Location = location;
				this.f2label4.Text = multiLingual2;
				this.f2label4.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
				this.f2label4.Width = width2;
				this.f2label4.Height = num;
				this.f2label4.BackColor = Color.White;
				this.f2label4.ForeColor = Color.Black;
				this.f2label4.AutoSize = true;
				location.X = width - this.f2label4.PreferredWidth;
				location.Y = height - this.f2label4.PreferredHeight;
				this.f2label4.Location = location;
				this.Controls.Add(this.f2label1);
				this.Controls.Add(this.f2label2);
				this.Controls.Add(this.f2label3);
				this.Controls.Add(this.f2label4);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00024D34 File Offset: 0x00022F34
		public void updateLabelText()
		{
			this.f2label1.Text = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_1");
			this.f2label3.Text = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_1");
			this.f2label2.Text = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_2");
			this.f2label4.Text = PublicModule.thisLang.getMultiLingual("CaptureForms_Label_Text_2");
		}

		// Token: 0x04000284 RID: 644
		private Label f2label1;

		// Token: 0x04000285 RID: 645
		private Label f2label2;

		// Token: 0x04000286 RID: 646
		private Label f2label3;

		// Token: 0x04000287 RID: 647
		private Label f2label4;
	}
}
