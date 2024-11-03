using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000BB RID: 187
	public class FastBitmap
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00024DC4 File Offset: 0x00022FC4
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00024DD7 File Offset: 0x00022FD7
		public Bitmap Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				this._Image = value;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00024DE0 File Offset: 0x00022FE0
		public FastBitmap(Bitmap image)
		{
			this.ptr = IntPtr.Zero;
			this.rgbValues = null;
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
			this.Lock();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00024EA0 File Offset: 0x000230A0
		public FastBitmap()
		{
			this.ptr = IntPtr.Zero;
			this.rgbValues = null;
			Bitmap image = null;
			this.Image = image;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00024ED0 File Offset: 0x000230D0
		private void Lock()
		{
			if (this.Image == null)
			{
				throw new Exception("调用Lock方法,前必须先设置Image属性!");
			}
			Rectangle rect = new Rectangle(0, 0, this.iWidth, this.iHeight);
			this.bmpData = this.Image.LockBits(rect, ImageLockMode.ReadWrite, this.pFormat);
			this.ptr = this.bmpData.Scan0;
			checked
			{
				this.bytes = Math.Abs(this.bmpData.Stride) * this.iHeight;
				this.rgbValues = new byte[this.bytes - 1 + 1];
				Marshal.Copy(this.ptr, this.rgbValues, 0, this.bytes);
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00024F7C File Offset: 0x0002317C
		public Color GetPixel(int x, int y)
		{
			if (this.ptr == IntPtr.Zero)
			{
				throw new Exception("读写操作前必须先调用Lock方法!");
			}
			long num = this.CalcOffset(x, y);
			checked
			{
				if (PixelFormat.Format32bppArgb == this.pFormat | PixelFormat.Format32bppRgb == this.pFormat)
				{
					return Color.FromArgb((int)this.rgbValues[(int)(num + 3L)], (int)this.rgbValues[(int)(num + 2L)], (int)this.rgbValues[(int)(num + 1L)], (int)this.rgbValues[(int)num]);
				}
				return Color.FromArgb((int)this.rgbValues[(int)(num + 2L)], (int)this.rgbValues[(int)(num + 1L)], (int)this.rgbValues[(int)num]);
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00025028 File Offset: 0x00023228
		public void SetPixel(int x, int y, Color color)
		{
			if (this.ptr == IntPtr.Zero)
			{
				throw new Exception("读写操作前必须先调用Lock方法!");
			}
			long num = this.CalcOffset(x, y);
			checked
			{
				this.rgbValues[(int)num] = color.B;
				this.rgbValues[(int)(num + 1L)] = color.G;
				this.rgbValues[(int)(num + 2L)] = color.R;
				if (PixelFormat.Format32bppArgb == this.pFormat | PixelFormat.Format32bppRgb == this.pFormat)
				{
					this.rgbValues[(int)(num + 3L)] = color.A;
				}
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000250C4 File Offset: 0x000232C4
		private long CalcOffset(int x, int y)
		{
			PixelFormat pixelFormat = this.pFormat;
			if (pixelFormat == PixelFormat.Format32bppArgb || pixelFormat == PixelFormat.Format32bppRgb)
			{
				return (long)(checked(y * this.bmpData.Stride + x * 4));
			}
			if (pixelFormat == PixelFormat.Format24bppRgb)
			{
				return (long)(checked(y * this.bmpData.Stride + x * 3));
			}
			if (pixelFormat == PixelFormat.Format8bppIndexed)
			{
				return (long)(checked(y * this.bmpData.Stride + x));
			}
			if (pixelFormat == PixelFormat.Format4bppIndexed)
			{
				return checked((long)Math.Round(unchecked((double)(checked(y * this.bmpData.Stride)) + (double)x / 2.0)));
			}
			if (pixelFormat == PixelFormat.Format1bppIndexed)
			{
				return (long)(checked(y * this.bmpData.Stride + x * 8));
			}
			return 0L;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00025178 File Offset: 0x00023378
		public void Dispose()
		{
			if (this.ptr == IntPtr.Zero)
			{
				return;
			}
			try
			{
				Marshal.Copy(this.rgbValues, 0, this.ptr, this.bytes);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			this.Image.UnlockBits(this.bmpData);
			this.Image.Dispose();
			this.ptr = IntPtr.Zero;
			this.rgbValues = new byte[1];
			this.rgbValues = null;
			this.bmpData = null;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00025218 File Offset: 0x00023418
		public void Save(string sPath, ImageFormat imgFormat)
		{
			try
			{
				Marshal.Copy(this.rgbValues, 0, this.ptr, this.bytes);
				this.Image.Save(sPath, imgFormat);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00025270 File Offset: 0x00023470
		public void Save(ref MemoryStream stream, ImageFormat imgFormat)
		{
			try
			{
				Marshal.Copy(this.rgbValues, 0, this.ptr, this.bytes);
				this.Image.Save(stream, imgFormat);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000252C8 File Offset: 0x000234C8
		public void Save(string sPath, ImageCodecInfo imgci, ref EncoderParameters ep)
		{
			try
			{
				Marshal.Copy(this.rgbValues, 0, this.ptr, this.bytes);
				this.Image.Save(sPath, imgci, ep);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00025324 File Offset: 0x00023524
		public Bitmap getImage()
		{
			Bitmap image;
			try
			{
				Marshal.Copy(this.rgbValues, 0, this.ptr, this.bytes);
				image = this.Image;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return image;
		}

		// Token: 0x04000288 RID: 648
		private BitmapData bmpData;

		// Token: 0x04000289 RID: 649
		private IntPtr ptr;

		// Token: 0x0400028A RID: 650
		private byte[] rgbValues;

		// Token: 0x0400028B RID: 651
		private int bytes;

		// Token: 0x0400028C RID: 652
		public int iWidth;

		// Token: 0x0400028D RID: 653
		public int iHeight;

		// Token: 0x0400028E RID: 654
		public PixelFormat pFormat;
	}
}
