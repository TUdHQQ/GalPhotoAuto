using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GalPhotoAuto.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D7 RID: 215
	[DesignerGenerated]
	public partial class Form2 : CaptureForms
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x0003743C File Offset: 0x0003563C
		public Form2()
		{
			base.MouseMove += this.Form2_MouseMove;
			base.Load += this.Form2_Load;
			base.MouseClick += this.Png_MouseClick;
			base.KeyDown += this.Form2_KeyDownd;
			base.LostFocus += this.Form2_LostFocus;
			this.InitializeComponent();
		}

		// Token: 0x0600041A RID: 1050
		[DllImport("gdi32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetPixel(int hdc, int x, int y);

		// Token: 0x0600041B RID: 1051
		[DllImport("gdi32", CharSet = CharSet.Ansi, EntryPoint = "CreateDCA", ExactSpelling = true, SetLastError = true)]
		private static extern int CreateDC([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDriverName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDeviceName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpOutput, ref Form2.DEVMODE lpInitData);

		// Token: 0x0600041C RID: 1052
		[DllImport("gdi32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int DeleteDC(ref int hdc);

		// Token: 0x0600041D RID: 1053 RVA: 0x00037562 File Offset: 0x00035762
		private void Form2_MouseMove(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00037564 File Offset: 0x00035764
		private void Png_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Form2.DEVMODE devmode = default(Form2.DEVMODE);
				int x = Cursor.Position.X;
				int y = Cursor.Position.Y;
				try
				{
					string text = "DISPLAY";
					string text2 = null;
					string text3 = null;
					int hdc = Form2.CreateDC(ref text, ref text2, ref text3, ref devmode);
					Color backColor = ColorTranslator.FromWin32(Form2.GetPixel(hdc, x, y));
					Form2.DeleteDC(ref hdc);
					MyProject.get_Forms().get_Form1().Panel7.BackColor = backColor;
					MyProject.get_Forms().get_Form1().ToolTip1.SetToolTip(MyProject.get_Forms().get_Form1().Panel7, MyProject.get_Forms().get_Form1().Panel7.BackColor.ToString());
				}
				catch (Exception ex)
				{
					PublicModule.addLog(ex.Message);
				}
			}
			this.Close();
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00037668 File Offset: 0x00035868
		private void Form2_Load(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Cross;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00037675 File Offset: 0x00035875
		private void Form2_KeyDownd(object sender, KeyEventArgs e)
		{
			this.Close();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0003767D File Offset: 0x0003587D
		private void Form2_LostFocus(object sender, EventArgs e)
		{
			this.Focus();
		}

		// Token: 0x04000411 RID: 1041
		private const short CCDEVICENAME = 32;

		// Token: 0x04000412 RID: 1042
		private const short CCFORMNAME = 32;

		// Token: 0x020000D8 RID: 216
		private struct DEVMODE
		{
			// Token: 0x04000413 RID: 1043
			[VBFixedString(32)]
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string dmDeviceName;

			// Token: 0x04000414 RID: 1044
			public short dmSpecVersion;

			// Token: 0x04000415 RID: 1045
			public short dmDriverVersion;

			// Token: 0x04000416 RID: 1046
			public short dmSize;

			// Token: 0x04000417 RID: 1047
			public short dmDriverExtra;

			// Token: 0x04000418 RID: 1048
			public int dmFields;

			// Token: 0x04000419 RID: 1049
			public short dmOrientation;

			// Token: 0x0400041A RID: 1050
			public short dmPaperSize;

			// Token: 0x0400041B RID: 1051
			public short dmPaperLength;

			// Token: 0x0400041C RID: 1052
			public short dmPaperWidth;

			// Token: 0x0400041D RID: 1053
			public short dmScale;

			// Token: 0x0400041E RID: 1054
			public short dmCopies;

			// Token: 0x0400041F RID: 1055
			public short dmDefaultSource;

			// Token: 0x04000420 RID: 1056
			public short dmPrintQuality;

			// Token: 0x04000421 RID: 1057
			public short dmColor;

			// Token: 0x04000422 RID: 1058
			public short dmDuplex;

			// Token: 0x04000423 RID: 1059
			public short dmYResolution;

			// Token: 0x04000424 RID: 1060
			public short dmTTOption;

			// Token: 0x04000425 RID: 1061
			public short dmCollate;

			// Token: 0x04000426 RID: 1062
			[VBFixedString(32)]
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string dmFormName;

			// Token: 0x04000427 RID: 1063
			public short dmUnusedPadding;

			// Token: 0x04000428 RID: 1064
			public short dmBitsPerPel;

			// Token: 0x04000429 RID: 1065
			public int dmPelsWidth;

			// Token: 0x0400042A RID: 1066
			public int dmPelsHeight;

			// Token: 0x0400042B RID: 1067
			public int dmDisplayFlags;

			// Token: 0x0400042C RID: 1068
			public int dmDisplayFrequency;
		}
	}
}
