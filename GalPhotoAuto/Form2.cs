using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D5 RID: 213
	[DesignerGenerated]
	public partial class Form2 : CaptureForms
	{
		// Token: 0x06000425 RID: 1061 RVA: 0x000378E4 File Offset: 0x00035AE4
		public Form2()
		{
			base.MouseMove += this.b;
			base.Load += this.b;
			base.MouseClick += this.a;
			base.KeyDown += this.a;
			base.LostFocus += this.a;
			this.a();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0003799C File Offset: 0x00035B9C
		[DebuggerStepThrough]
		private void a()
		{
			this.SuspendLayout();
			SizeF autoScaleDimensions = new SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			Size clientSize = new Size(284, 262);
			this.ClientSize = clientSize;
			this.Name = "Form2";
			this.Text = "SnippingForm";
			this.TopMost = true;
			this.ResumeLayout(false);
		}

		// Token: 0x06000428 RID: 1064
		[DllImport("gdi32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetPixel(int A_0, int A_1, int A_2);

		// Token: 0x06000429 RID: 1065
		[DllImport("gdi32", CharSet = CharSet.Ansi, EntryPoint = "CreateDCA", ExactSpelling = true, SetLastError = true)]
		private static extern int CreateDC([MarshalAs(UnmanagedType.VBByRefStr)] ref string A_0, [MarshalAs(UnmanagedType.VBByRefStr)] ref string A_1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string A_2, ref Form2.a A_3);

		// Token: 0x0600042A RID: 1066
		[DllImport("gdi32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int DeleteDC(ref int A_0);

		// Token: 0x0600042B RID: 1067 RVA: 0x00037A0A File Offset: 0x00035C0A
		private void b(object A_0, MouseEventArgs A_1)
		{
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00037A0C File Offset: 0x00035C0C
		private void a(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Left)
			{
				Form2.a a = default(Form2.a);
				int x = Cursor.Position.X;
				int y = Cursor.Position.Y;
				try
				{
					string text = "DISPLAY";
					string text2 = null;
					string text3 = null;
					int a_ = Form2.CreateDC(ref text, ref text2, ref text3, ref a);
					Color backColor = ColorTranslator.FromWin32(Form2.GetPixel(a_, x, y));
					Form2.DeleteDC(ref a_);
					t.b().n().Panel7.BackColor = backColor;
					t.b().n().ToolTip1.SetToolTip(t.b().n().Panel7, t.b().n().Panel7.BackColor.ToString());
				}
				catch (Exception ex)
				{
					x.c(ex.Message);
				}
			}
			this.Close();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00037B10 File Offset: 0x00035D10
		private void b(object A_0, EventArgs A_1)
		{
			this.Cursor = Cursors.Cross;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00037B1D File Offset: 0x00035D1D
		private void a(object A_0, KeyEventArgs A_1)
		{
			this.Close();
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00037B25 File Offset: 0x00035D25
		private void a(object A_0, EventArgs A_1)
		{
			this.Focus();
		}

		// Token: 0x04000400 RID: 1024
		private const short b = 32;

		// Token: 0x04000401 RID: 1025
		private const short c = 32;

		// Token: 0x020000D6 RID: 214
		private struct a
		{
			// Token: 0x04000402 RID: 1026
			[VBFixedString(32)]
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string a;

			// Token: 0x04000403 RID: 1027
			public short b;

			// Token: 0x04000404 RID: 1028
			public short c;

			// Token: 0x04000405 RID: 1029
			public short d;

			// Token: 0x04000406 RID: 1030
			public short e;

			// Token: 0x04000407 RID: 1031
			public int f;

			// Token: 0x04000408 RID: 1032
			public short g;

			// Token: 0x04000409 RID: 1033
			public short h;

			// Token: 0x0400040A RID: 1034
			public short i;

			// Token: 0x0400040B RID: 1035
			public short j;

			// Token: 0x0400040C RID: 1036
			public short k;

			// Token: 0x0400040D RID: 1037
			public short l;

			// Token: 0x0400040E RID: 1038
			public short m;

			// Token: 0x0400040F RID: 1039
			public short n;

			// Token: 0x04000410 RID: 1040
			public short o;

			// Token: 0x04000411 RID: 1041
			public short p;

			// Token: 0x04000412 RID: 1042
			public short q;

			// Token: 0x04000413 RID: 1043
			public short r;

			// Token: 0x04000414 RID: 1044
			public short s;

			// Token: 0x04000415 RID: 1045
			[VBFixedString(32)]
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string t;

			// Token: 0x04000416 RID: 1046
			public short u;

			// Token: 0x04000417 RID: 1047
			public short v;

			// Token: 0x04000418 RID: 1048
			public int w;

			// Token: 0x04000419 RID: 1049
			public int x;

			// Token: 0x0400041A RID: 1050
			public int y;

			// Token: 0x0400041B RID: 1051
			public int z;
		}
	}
}
