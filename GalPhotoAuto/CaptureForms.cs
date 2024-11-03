using System;
using System.Drawing;
using System.Windows.Forms;

namespace GalPhotoAuto
{
	// Token: 0x020000BC RID: 188
	public partial class CaptureForms : Form
	{
		// Token: 0x06000261 RID: 609 RVA: 0x00025F0C File Offset: 0x0002410C
		public CaptureForms()
		{
			this.a = new Label();
			this.b = new Label();
			this.c = new Label();
			this.d = new Label();
			this.a();
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
			Screen primaryScreen = Screen.PrimaryScreen;
			Rectangle bounds = primaryScreen.Bounds;
			int width = bounds.Width;
			int height = bounds.Height;
			this.Size = primaryScreen.Bounds.Size;
			string multiLingual = x.ad.getMultiLingual("CaptureForms_Label_Text_1");
			string multiLingual2 = x.ad.getMultiLingual("CaptureForms_Label_Text_2");
			int width2 = 77;
			int num = 14;
			float emSize = (float)num;
			FontStyle style = this.a.Font.Style;
			Point location;
			location.X = 0;
			location.Y = 0;
			this.a.Location = location;
			this.a.Text = multiLingual;
			this.a.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
			this.a.Width = width2;
			this.a.Height = num;
			this.a.BackColor = Color.White;
			this.a.ForeColor = Color.Black;
			this.a.AutoSize = true;
			this.b.Text = multiLingual2;
			this.b.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
			this.b.Width = width2;
			this.b.Height = num;
			this.b.BackColor = Color.White;
			this.b.ForeColor = Color.Black;
			this.b.AutoSize = true;
			checked
			{
				location.X = width - this.b.PreferredWidth;
				location.Y = 0;
				this.b.Location = location;
				this.c.Text = multiLingual;
				this.c.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
				this.c.Width = width2;
				this.c.Height = num;
				this.c.BackColor = Color.White;
				this.c.ForeColor = Color.Black;
				this.c.AutoSize = true;
				location.X = 0;
				location.Y = height - this.c.PreferredHeight;
				this.c.Location = location;
				this.d.Text = multiLingual2;
				this.d.Font = new Font("Microsoft YaHei", emSize, style, GraphicsUnit.Pixel);
				this.d.Width = width2;
				this.d.Height = num;
				this.d.BackColor = Color.White;
				this.d.ForeColor = Color.Black;
				this.d.AutoSize = true;
				location.X = width - this.d.PreferredWidth;
				location.Y = height - this.d.PreferredHeight;
				this.d.Location = location;
				this.Controls.Add(this.a);
				this.Controls.Add(this.b);
				this.Controls.Add(this.c);
				this.Controls.Add(this.d);
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0002626C File Offset: 0x0002446C
		private void a()
		{
			this.SuspendLayout();
			this.AutoScaleMode = AutoScaleMode.None;
			Size clientSize = new Size(284, 262);
			this.ClientSize = clientSize;
			this.ControlBox = false;
			this.DoubleBuffered = true;
			this.FormBorderStyle = FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DBForms";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.ResumeLayout(false);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000262E4 File Offset: 0x000244E4
		public void updateLabelText()
		{
			this.a.Text = x.ad.getMultiLingual("CaptureForms_Label_Text_1");
			this.c.Text = x.ad.getMultiLingual("CaptureForms_Label_Text_1");
			this.b.Text = x.ad.getMultiLingual("CaptureForms_Label_Text_2");
			this.d.Text = x.ad.getMultiLingual("CaptureForms_Label_Text_2");
		}

		// Token: 0x040002C2 RID: 706
		private Label a;

		// Token: 0x040002C3 RID: 707
		private Label b;

		// Token: 0x040002C4 RID: 708
		private Label c;

		// Token: 0x040002C5 RID: 709
		private Label d;
	}
}
