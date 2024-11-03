using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000BE RID: 190
	public class FastBitmap
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00026374 File Offset: 0x00024574
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00026387 File Offset: 0x00024587
		public Bitmap Image
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00026390 File Offset: 0x00024590
		public FastBitmap(Bitmap image)
		{
			this.b = IntPtr.Zero;
			this.c = null;
			Bitmap image2 = null;
			this.Image = image2;
			this.Image = image;
			this.iWidth = this.Image.Width;
			this.iHeight = this.Image.Height;
			this.pFormat = this.Image.PixelFormat;
			PixelFormat pixelFormat = this.pFormat;
			if (pixelFormat != PixelFormat.Format32bppArgb && pixelFormat != PixelFormat.Format32bppRgb && pixelFormat != PixelFormat.Format24bppRgb && pixelFormat != PixelFormat.Format8bppIndexed && pixelFormat != PixelFormat.Format4bppIndexed && pixelFormat != PixelFormat.Format1bppIndexed)
			{
				throw new NotSupportedException(Conversions.ToString((int)this.pFormat) + " 不支持。");
			}
			this.a();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00026450 File Offset: 0x00024650
		public FastBitmap()
		{
			this.b = IntPtr.Zero;
			this.c = null;
			Bitmap image = null;
			this.Image = image;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00026480 File Offset: 0x00024680
		private void a()
		{
			if (this.Image == null)
			{
				throw new Exception("调用Lock方法,前必须先设置Image属性!");
			}
			Rectangle rect = new Rectangle(0, 0, this.iWidth, this.iHeight);
			this.a = this.Image.LockBits(rect, ImageLockMode.ReadWrite, this.pFormat);
			this.b = this.a.Scan0;
			checked
			{
				this.d = Math.Abs(this.a.Stride) * this.iHeight;
				this.c = new byte[this.d - 1 + 1];
				Marshal.Copy(this.b, this.c, 0, this.d);
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0002652C File Offset: 0x0002472C
		public Color GetPixel(int x, int y)
		{
			if (this.b == IntPtr.Zero)
			{
				throw new Exception("读写操作前必须先调用Lock方法!");
			}
			long num = this.a(x, y);
			checked
			{
				if (PixelFormat.Format32bppArgb == this.pFormat | PixelFormat.Format32bppRgb == this.pFormat)
				{
					return Color.FromArgb((int)this.c[(int)(num + 3L)], (int)this.c[(int)(num + 2L)], (int)this.c[(int)(num + 1L)], (int)this.c[(int)num]);
				}
				return Color.FromArgb((int)this.c[(int)(num + 2L)], (int)this.c[(int)(num + 1L)], (int)this.c[(int)num]);
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000265D8 File Offset: 0x000247D8
		public void SetPixel(int x, int y, Color color)
		{
			if (this.b == IntPtr.Zero)
			{
				throw new Exception("读写操作前必须先调用Lock方法!");
			}
			long num = this.a(x, y);
			checked
			{
				this.c[(int)num] = color.B;
				this.c[(int)(num + 1L)] = color.G;
				this.c[(int)(num + 2L)] = color.R;
				if (PixelFormat.Format32bppArgb == this.pFormat | PixelFormat.Format32bppRgb == this.pFormat)
				{
					this.c[(int)(num + 3L)] = color.A;
				}
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00026674 File Offset: 0x00024874
		private long a(int A_0, int A_1)
		{
			PixelFormat pixelFormat = this.pFormat;
			if (pixelFormat == PixelFormat.Format32bppArgb || pixelFormat == PixelFormat.Format32bppRgb)
			{
				return (long)(checked(A_1 * this.a.Stride + A_0 * 4));
			}
			if (pixelFormat == PixelFormat.Format24bppRgb)
			{
				return (long)(checked(A_1 * this.a.Stride + A_0 * 3));
			}
			if (pixelFormat == PixelFormat.Format8bppIndexed)
			{
				return (long)(checked(A_1 * this.a.Stride + A_0));
			}
			if (pixelFormat == PixelFormat.Format4bppIndexed)
			{
				return checked((long)Math.Round(unchecked((double)(checked(A_1 * this.a.Stride)) + (double)A_0 / 2.0)));
			}
			if (pixelFormat == PixelFormat.Format1bppIndexed)
			{
				return (long)(checked(A_1 * this.a.Stride + A_0 * 8));
			}
			return 0L;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00026728 File Offset: 0x00024928
		public void Dispose()
		{
			if (this.b == IntPtr.Zero)
			{
				return;
			}
			try
			{
				Marshal.Copy(this.c, 0, this.b, this.d);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			this.Image.UnlockBits(this.a);
			this.Image.Dispose();
			this.b = IntPtr.Zero;
			this.c = new byte[1];
			this.c = null;
			this.a = null;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000267C8 File Offset: 0x000249C8
		public void Save(string sPath, ImageFormat imgFormat)
		{
			try
			{
				Marshal.Copy(this.c, 0, this.b, this.d);
				this.Image.Save(sPath, imgFormat);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00026820 File Offset: 0x00024A20
		public void Save(ref MemoryStream stream, ImageFormat imgFormat)
		{
			try
			{
				Marshal.Copy(this.c, 0, this.b, this.d);
				this.Image.Save(stream, imgFormat);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00026878 File Offset: 0x00024A78
		public void Save(string sPath, ImageCodecInfo imgci, ref EncoderParameters ep)
		{
			try
			{
				Marshal.Copy(this.c, 0, this.b, this.d);
				this.Image.Save(sPath, imgci, ep);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000268D4 File Offset: 0x00024AD4
		public Bitmap getImage()
		{
			Bitmap image;
			try
			{
				Marshal.Copy(this.c, 0, this.b, this.d);
				image = this.Image;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return image;
		}

		// Token: 0x040002C6 RID: 710
		private BitmapData a;

		// Token: 0x040002C7 RID: 711
		private IntPtr b;

		// Token: 0x040002C8 RID: 712
		private byte[] c;

		// Token: 0x040002C9 RID: 713
		private int d;

		// Token: 0x040002CA RID: 714
		public int iWidth;

		// Token: 0x040002CB RID: 715
		public int iHeight;

		// Token: 0x040002CC RID: 716
		public PixelFormat pFormat;

		// Token: 0x040002CD RID: 717
		[CompilerGenerated]
		private Bitmap e;
	}
}
