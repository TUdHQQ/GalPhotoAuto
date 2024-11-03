using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevIL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x02000022 RID: 34
	public class BW1
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000089DC File Offset: 0x00006BDC
		public static bool cutImage(ref Form1 myForm1)
		{
			BW1.c c = new BW1.c();
			c.b = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			c.e = Convert.ToInt32(myForm1.NumericUpDown1.Value);
			c.f = Convert.ToInt32(myForm1.NumericUpDown2.Value);
			c.d = Convert.ToInt32(myForm1.NumericUpDown3.Value);
			c.c = Convert.ToInt32(myForm1.NumericUpDown4.Value);
			c.a = myForm1.BackgroundWorker1;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(c.g));
			return c.b;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00008AE4 File Offset: 0x00006CE4
		public static bool scan32BitImage(ref Form1 myForm1)
		{
			BW1.b b = new BW1.b(b);
			b.c = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			b.b = myForm1.CheckBox1.Checked;
			b.a = myForm1.BackgroundWorker1;
			b.d = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown5.Value, 1m));
			b.e = myForm1.RadioButton6;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(b.f));
			return b.c;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00008BD0 File Offset: 0x00006DD0
		public static bool TransparentImage(ref Form1 myForm1)
		{
			BW1.f f = new BW1.f();
			f.b = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			f.a = myForm1.BackgroundWorker1;
			f.c = Color.Transparent;
			if (myForm1.RadioButton9.Checked)
			{
				f.c = myForm1.Panel4.BackColor;
			}
			else if (myForm1.RadioButton10.Checked)
			{
				f.c = myForm1.Panel5.BackColor;
			}
			else if (myForm1.RadioButton11.Checked)
			{
				f.c = myForm1.Panel6.BackColor;
			}
			else if (myForm1.RadioButton12.Checked)
			{
				f.c = myForm1.Panel7.BackColor;
			}
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(f.d));
			return f.b;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00008D0C File Offset: 0x00006F0C
		public static bool ConvertImageFormatToX(ref Form1 myForm1, ref ArrayList arr)
		{
			BW1.g g = new BW1.g();
			g.e = false;
			g.c = Conversions.ToInteger(arr[0]);
			int num = Conversions.ToInteger(arr[1]);
			g.d = Conversions.ToInteger(arr[2]);
			g.b = Conversions.ToBoolean(arr[4]);
			if (0 == num | 0 == g.d | num == g.d)
			{
				x.c(x.ad.getMultiLingual("BW1_ConvertImageFormat_errmsg_1"));
				return g.e;
			}
			x.z = Conversions.ToString(arr[3]);
			if (string.IsNullOrWhiteSpace(x.z))
			{
				return g.e;
			}
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			g.f = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown6.Value, 1m));
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				g.a = myForm1.BackgroundWorker1;
				g.g = x.c * parallelOptions.MaxDegreeOfParallelism;
				if (100 > g.g)
				{
					g.g = 100;
				}
				g.h = RuntimeHelpers.GetObjectValue(new object());
				Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(g.i));
				return g.e;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00008EB0 File Offset: 0x000070B0
		public static bool checkBlackAlphaCutImage(ref Form1 myForm1)
		{
			BW1.h h = new BW1.h();
			h.b = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			h.a = myForm1.BackgroundWorker1;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(h.c));
			return h.b;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00008F5C File Offset: 0x0000715C
		public static bool defineWidthCutImage(ref Form1 myForm1)
		{
			BW1.d d = new BW1.d();
			d.d = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			d.h = x.a();
			d.a = myForm1.BackgroundWorker1;
			d.b = myForm1.RadioButton18.Checked;
			d.g = Convert.ToInt32(myForm1.NumericUpDown7.Value);
			d.f = Convert.ToInt32(myForm1.NumericUpDown9.Value);
			if (d.b)
			{
				if (0 >= d.g)
				{
					return d.d;
				}
			}
			else if (0 >= d.f)
			{
				return d.d;
			}
			d.c = myForm1.RadioButton17.Checked;
			d.e = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown8.Value, 1m));
			Parallel.ForEach<string>(array, d.h, new Action<string, ParallelLoopState>(d.i));
			return d.d;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000090A8 File Offset: 0x000072A8
		public static bool defineHeightCutImage(ref Form1 myForm1)
		{
			BW1.a a = new BW1.a();
			a.d = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			a.h = x.a();
			a.a = myForm1.BackgroundWorker1;
			a.b = myForm1.RadioButton21.Checked;
			a.f = Convert.ToInt32(myForm1.NumericUpDown10.Value);
			a.g = Convert.ToInt32(myForm1.NumericUpDown11.Value);
			if (a.b)
			{
				if (0 >= a.f)
				{
					return a.d;
				}
			}
			else if (0 >= a.g)
			{
				return a.d;
			}
			a.c = myForm1.RadioButton24.Checked;
			a.e = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown12.Value, 1m));
			Parallel.ForEach<string>(array, a.h, new Action<string, ParallelLoopState>(a.i));
			return a.d;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000091F4 File Offset: 0x000073F4
		public static bool reSizeImage(ref Form1 myForm1)
		{
			BW1.e e = new BW1.e();
			e.d = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			x.a(ref listBox, ref x.e);
			form.ListBox1 = listBox;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			e.a = myForm1.BackgroundWorker1;
			e.b = myForm1.CheckBox5.Checked;
			e.f = 0;
			e.g = 0;
			if (myForm1.RadioButton8.Checked)
			{
				e.f = 1;
				e.g = Convert.ToInt32(myForm1.NumericUpDown14.Value);
			}
			else if (myForm1.RadioButton25.Checked)
			{
				e.f = 2;
				e.g = Convert.ToInt32(myForm1.NumericUpDown15.Value);
			}
			else if (myForm1.RadioButton26.Checked)
			{
				e.f = 3;
				e.g = Convert.ToInt32(myForm1.NumericUpDown16.Value);
			}
			if (0 == e.f | 0 == e.g)
			{
				return e.d;
			}
			e.c = myForm1.RadioButton28.Checked;
			e.e = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown17.Value, 1m));
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(e.h));
			return e.d;
		}

		// Token: 0x02000023 RID: 35
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x06000069 RID: 105 RVA: 0x000093A0 File Offset: 0x000075A0
			[CompilerGenerated]
			public void g(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.b = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.b = true;
						A_1.Stop();
					}
				}
				bool flag = false;
				try
				{
					Bitmap bitmap = x.a(A_0);
					if (checked(bitmap.Width < this.d + this.e | bitmap.Height < this.c + this.f))
					{
						bitmap.Dispose();
						return;
					}
					Rectangle rect = new Rectangle(this.e, this.f, this.d, this.c);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
					Bitmap bitmap2 = new Bitmap(this.d, this.c, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					bitmap2.Save(A_0 + ".cut.bmp", ImageFormat.Bmp);
					bitmap.Dispose();
					bitmap2.Dispose();
					flag = true;
				}
				catch (Exception ex)
				{
					flag = false;
					x.c(x.ad.getMultiLingual("BW1_cutImage_errmsg") + ex.Message + " : " + A_0);
					throw new Exception(ex.Message);
				}
				if (flag)
				{
					Interlocked.Add(ref x.k, 1);
					ArrayList obj = x.f;
					lock (obj)
					{
						x.f.Add(A_0);
					}
				}
				this.a.ReportProgress(x.i);
				Thread.Sleep(x.c);
			}

			// Token: 0x04000076 RID: 118
			public BackgroundWorker a;

			// Token: 0x04000077 RID: 119
			public bool b;

			// Token: 0x04000078 RID: 120
			public int c;

			// Token: 0x04000079 RID: 121
			public int d;

			// Token: 0x0400007A RID: 122
			public int e;

			// Token: 0x0400007B RID: 123
			public int f;
		}

		// Token: 0x02000024 RID: 36
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x0600006A RID: 106 RVA: 0x00009578 File Offset: 0x00007778
			public b(BW1.b A_0)
			{
				if (A_0 != null)
				{
					this.d = A_0.d;
					this.e = A_0.e;
					this.c = A_0.c;
					this.a = A_0.a;
					this.b = A_0.b;
				}
			}

			// Token: 0x0600006B RID: 107 RVA: 0x000095CC File Offset: 0x000077CC
			[CompilerGenerated]
			public void f(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.c = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.c = true;
						A_1.Stop();
					}
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				bool flag = false;
				try
				{
					MemoryStream memoryStream = new MemoryStream();
					using (Bitmap bitmap = x.a(A_0))
					{
						bitmap.Save(memoryStream, ImageFormat.Bmp);
					}
					Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
					if (bitmap2.PixelFormat == PixelFormat.Format32bppArgb | bitmap2.PixelFormat == PixelFormat.Format32bppRgb)
					{
						FastBitmap fastBitmap = new FastBitmap(bitmap2);
						int iWidth = fastBitmap.iWidth;
						int iHeight = fastBitmap.iHeight;
						bool flag2;
						checked
						{
							if (!this.b)
							{
								int num4 = 0;
								int num5 = iWidth - 1;
								for (int i = num4; i <= num5; i++)
								{
									int num6 = 0;
									int num7 = iHeight - 1;
									for (int j = num6; j <= num7; j++)
									{
										num3++;
										Color pixel = fastBitmap.GetPixel(i, j);
										if (pixel.A == 255)
										{
											num++;
										}
										else if (pixel.A == 0)
										{
											num2++;
										}
									}
								}
								flag2 = false;
								if (num == 0 & num3 == num2)
								{
									flag2 = true;
								}
								else if (num2 == 0 & num3 == num)
								{
									flag2 = true;
								}
							}
						}
						if (flag2 | this.b)
						{
							if (this.e.Checked)
							{
								Encoder quality = Encoder.Quality;
								EncoderParameters encoderParameters = new EncoderParameters(1);
								EncoderParameter encoderParameter = new EncoderParameter(quality, (long)this.d);
								encoderParameters.Param[0] = encoderParameter;
								ImageCodecInfo encoder = x.a(ImageFormat.Jpeg);
								fastBitmap.Image.Save(A_0 + ".32to24.jpg", encoder, encoderParameters);
								encoderParameter.Dispose();
								encoderParameters.Dispose();
							}
							else
							{
								Rectangle rect = new Rectangle(0, 0, iWidth, iHeight);
								using (Bitmap bitmap3 = fastBitmap.Image.Clone(rect, PixelFormat.Format24bppRgb))
								{
									bitmap3.Save(A_0 + ".32to24.bmp", ImageFormat.Bmp);
								}
							}
							flag = true;
						}
						fastBitmap.Dispose();
					}
					bitmap2.Dispose();
					memoryStream.Dispose();
				}
				catch (Exception ex)
				{
					flag = false;
					x.c(x.ad.getMultiLingual("BW1_scan32BitImage_errmsg") + ex.Message + " : " + A_0);
					throw new Exception(ex.Message);
				}
				if (flag)
				{
					Interlocked.Add(ref x.k, 1);
					ArrayList f = x.f;
					lock (f)
					{
						x.f.Add(A_0);
					}
				}
				this.a.ReportProgress(x.i);
				Thread.Sleep(x.c);
			}

			// Token: 0x0400007C RID: 124
			public BackgroundWorker a;

			// Token: 0x0400007D RID: 125
			public bool b;

			// Token: 0x0400007E RID: 126
			public bool c;

			// Token: 0x0400007F RID: 127
			public int d;

			// Token: 0x04000080 RID: 128
			public RadioButton e;
		}

		// Token: 0x02000025 RID: 37
		[CompilerGenerated]
		internal class f
		{
			// Token: 0x0600006D RID: 109 RVA: 0x00009914 File Offset: 0x00007B14
			[CompilerGenerated]
			public void d(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.b = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.b = true;
						A_1.Stop();
					}
				}
				bool flag = false;
				try
				{
					Bitmap bitmap = x.a(A_0);
					bitmap.MakeTransparent(this.c);
					bitmap.Save(A_0 + ".tran.bmp", ImageFormat.Bmp);
					bitmap.Dispose();
					flag = true;
				}
				catch (Exception ex)
				{
					flag = false;
					x.c(x.ad.getMultiLingual("BW1_TransparentImage_errmsg") + ex.Message + " : " + A_0);
				}
				if (flag)
				{
					Interlocked.Add(ref x.k, 1);
					ArrayList f = x.f;
					lock (f)
					{
						x.f.Add(A_0);
					}
				}
				this.a.ReportProgress(x.i);
				Thread.Sleep(x.c);
			}

			// Token: 0x04000081 RID: 129
			public BackgroundWorker a;

			// Token: 0x04000082 RID: 130
			public bool b;

			// Token: 0x04000083 RID: 131
			public Color c;
		}

		// Token: 0x02000026 RID: 38
		[CompilerGenerated]
		internal class g
		{
			// Token: 0x0600006F RID: 111 RVA: 0x00009A58 File Offset: 0x00007C58
			[CompilerGenerated]
			public void i(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.e = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.e = true;
						A_1.Stop();
					}
				}
				bool flag = false;
				try
				{
					Bitmap bitmap;
					if (x.b(A_0))
					{
						object obj = this.h;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							bitmap = DevIL.LoadBitmap(A_0);
							goto IL_D0;
						}
					}
					FileInfo fileInfo = new FileInfo(A_0);
					FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
					MemoryStream memoryStream = new MemoryStream();
					fileStream.CopyTo(memoryStream);
					fileStream.Dispose();
					bitmap = (Bitmap)Image.FromStream(memoryStream);
					memoryStream.Dispose();
					IL_D0:
					PixelFormat pixelFormat = bitmap.PixelFormat;
					bool flag3 = false;
					bool flag4 = false;
					switch (this.c)
					{
					case 0:
						flag3 = true;
						if (PixelFormat.Format1bppIndexed == pixelFormat | PixelFormat.Format4bppIndexed == pixelFormat | PixelFormat.Format8bppIndexed == pixelFormat)
						{
							flag4 = true;
						}
						break;
					case 1:
						if (pixelFormat == PixelFormat.Format32bppArgb | pixelFormat == PixelFormat.Format32bppRgb)
						{
							flag3 = true;
						}
						break;
					case 2:
						if (pixelFormat == PixelFormat.Format24bppRgb)
						{
							flag3 = true;
						}
						break;
					}
					if (flag3)
					{
						int width = bitmap.Width;
						int height = bitmap.Height;
						PixelFormat pixelFormat2 = x.a(pixelFormat);
						Bitmap bitmap2;
						if (flag4)
						{
							bitmap2 = new Bitmap(width, height, pixelFormat2);
							Graphics graphics = Graphics.FromImage(bitmap2);
							graphics.Clear(Color.Transparent);
							graphics.DrawImage(bitmap, 0, 0, width, height);
							graphics.Dispose();
						}
						else
						{
							Rectangle rect = new Rectangle(0, 0, width, height);
							BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
							bitmap2 = new Bitmap(width, height, bitmapData.Stride, pixelFormat2, bitmapData.Scan0);
							bitmap.UnlockBits(bitmapData);
						}
						FastBitmap fastBitmap = new FastBitmap(bitmap2);
						checked
						{
							if (this.b && (pixelFormat2 == PixelFormat.Format32bppArgb | pixelFormat2 == PixelFormat.Format32bppRgb))
							{
								int num = 0;
								int num2 = width - 1;
								for (int i = num; i <= num2; i++)
								{
									int num3 = 0;
									int num4 = height - 1;
									for (int j = num3; j <= num4; j++)
									{
										Color pixel = fastBitmap.GetPixel(i, j);
										int alpha = (int)(byte.MaxValue - pixel.A);
										fastBitmap.SetPixel(i, j, Color.FromArgb(alpha, pixel));
									}
								}
							}
							string sPath = string.Empty;
						}
						switch (this.d)
						{
						case 1:
						{
							string sPath = Path.ChangeExtension(A_0, "bmp");
							fastBitmap.Save(sPath, ImageFormat.Bmp);
							break;
						}
						case 2:
						{
							string sPath = Path.ChangeExtension(A_0, "png");
							fastBitmap.Save(sPath, ImageFormat.Png);
							break;
						}
						case 3:
						{
							Encoder quality = Encoder.Quality;
							EncoderParameters encoderParameters = new EncoderParameters(1);
							EncoderParameter encoderParameter = new EncoderParameter(quality, (long)this.f);
							encoderParameters.Param[0] = encoderParameter;
							ImageCodecInfo imgci = x.a(ImageFormat.Jpeg);
							string sPath = Path.ChangeExtension(A_0, "jpg");
							fastBitmap.Save(sPath, imgci, ref encoderParameters);
							encoderParameter.Dispose();
							encoderParameters.Dispose();
							break;
						}
						}
						fastBitmap.Dispose();
						bitmap2.Dispose();
						flag = true;
					}
					bitmap.Dispose();
				}
				catch (Exception ex)
				{
					flag = false;
					x.c(x.ad.getMultiLingual("BW1_ConvertImageFormat_errmsg_2") + ex.Message + " : " + A_0);
				}
				if (flag)
				{
					Interlocked.Add(ref x.k, 1);
					ArrayList obj2 = x.f;
					lock (obj2)
					{
						x.f.Add(A_0);
					}
				}
				this.a.ReportProgress(x.i);
				Thread.Sleep(this.g);
			}

			// Token: 0x04000084 RID: 132
			public BackgroundWorker a;

			// Token: 0x04000085 RID: 133
			public bool b;

			// Token: 0x04000086 RID: 134
			public int c;

			// Token: 0x04000087 RID: 135
			public int d;

			// Token: 0x04000088 RID: 136
			public bool e;

			// Token: 0x04000089 RID: 137
			public int f;

			// Token: 0x0400008A RID: 138
			public int g;

			// Token: 0x0400008B RID: 139
			public object h;
		}

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		internal class h
		{
			// Token: 0x06000071 RID: 113 RVA: 0x00009E74 File Offset: 0x00008074
			[CompilerGenerated]
			public void c(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.b = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.b = true;
						A_1.Stop();
					}
				}
				bool flag = false;
				MemoryStream memoryStream = new MemoryStream();
				checked
				{
					try
					{
						PixelFormat pixelFormat;
						using (Bitmap bitmap = x.a(A_0))
						{
							pixelFormat = bitmap.PixelFormat;
							bitmap.Save(memoryStream, ImageFormat.Png);
						}
						if (pixelFormat == PixelFormat.Format32bppArgb | pixelFormat == PixelFormat.Format32bppRgb)
						{
							FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							Color transparent = Color.Transparent;
							int num = 0;
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							bool flag2 = false;
							int num5 = 0;
							int num6 = 0;
							int num7 = 0;
							int num8 = iHeight - 1;
							for (int i = num7; i <= num8; i++)
							{
								int num9 = 0;
								int num10 = iWidth - 1;
								for (int j = num9; j <= num10; j++)
								{
									num5++;
									if (fastBitmap.GetPixel(j, i).A > 0)
									{
										num6++;
										if (!flag2)
										{
											num = j;
											num2 = i;
											flag2 = true;
										}
										if (flag2 && j < num)
										{
											num = j;
										}
										if (j > num3)
										{
											num3 = j;
										}
										if (i > num4)
										{
											num4 = i;
										}
									}
								}
							}
							fastBitmap.Dispose();
							if (num5 > num6 & num6 > 0)
							{
								int width = num3 - num + 1;
								int height = num4 - num2 + 1;
								Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
								Rectangle rect = new Rectangle(num, num2, width, height);
								BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
								Bitmap bitmap3 = new Bitmap(width, height, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
								bitmap2.UnlockBits(bitmapData);
								bitmap3.Save(A_0 + ".cut.bmp", ImageFormat.Bmp);
								bitmap3.Dispose();
								bitmap2.Dispose();
								flag = true;
							}
						}
					}
					catch (Exception ex)
					{
						flag = false;
						x.c(x.ad.getMultiLingual("BW1_checkBlackAlphaCutImage_errmsg") + ex.Message + " : " + A_0);
					}
					memoryStream.Dispose();
					if (flag)
					{
						Interlocked.Add(ref x.k, 1);
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(A_0);
						}
					}
					this.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}
			}

			// Token: 0x0400008C RID: 140
			public BackgroundWorker a;

			// Token: 0x0400008D RID: 141
			public bool b;
		}

		// Token: 0x02000028 RID: 40
		[CompilerGenerated]
		internal class d
		{
			// Token: 0x06000073 RID: 115 RVA: 0x0000A16C File Offset: 0x0000836C
			[CompilerGenerated]
			public void i(string A_0, ParallelLoopState A_1)
			{
				BW1.d.a a = new BW1.d.a();
				a.a = A_0;
				BW1.d.a.a a2 = new BW1.d.a.a();
				a2.f = this;
				a2.e = a;
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.d = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.d = true;
						A_1.Stop();
					}
				}
				a2.d = new MemoryStream();
				using (Bitmap bitmap = x.a(a.a))
				{
					a2.b = bitmap.Width;
					a2.a = bitmap.Height;
					bitmap.Save(a2.d, ImageFormat.Png);
				}
				a2.c = 0;
				checked
				{
					int num;
					if (this.b)
					{
						a2.c = this.g;
						num = (int)Math.Round((double)a2.b / (double)a2.c);
						double num2 = (double)a2.b / (double)a2.c;
						if (num2 > (double)num)
						{
							num++;
						}
					}
					else
					{
						a2.c = (int)Math.Round((double)a2.b / (double)this.f);
						num = this.f;
						double num2 = (double)a2.b / (double)this.f;
						if (num2 > (double)a2.c)
						{
							num++;
						}
					}
					Parallel.For(0, num, this.h, new Action<int, ParallelLoopState>(a2.g));
					a2.d.Dispose();
				}
			}

			// Token: 0x0400008E RID: 142
			public BackgroundWorker a;

			// Token: 0x0400008F RID: 143
			public bool b;

			// Token: 0x04000090 RID: 144
			public bool c;

			// Token: 0x04000091 RID: 145
			public bool d;

			// Token: 0x04000092 RID: 146
			public int e;

			// Token: 0x04000093 RID: 147
			public int f;

			// Token: 0x04000094 RID: 148
			public int g;

			// Token: 0x04000095 RID: 149
			public ParallelOptions h;

			// Token: 0x02000029 RID: 41
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x04000096 RID: 150
				public string a;

				// Token: 0x0200002A RID: 42
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000076 RID: 118 RVA: 0x0000A314 File Offset: 0x00008514
					[CompilerGenerated]
					public void g(int A_0, ParallelLoopState A_1)
					{
						if (this.f.a.CancellationPending)
						{
							this.f.d = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.f.a.CancellationPending)
							{
								this.f.d = true;
								A_1.Stop();
							}
						}
						bool flag = false;
						int width = this.c;
						checked
						{
							int num = A_0 * this.c + this.c;
							if (num > this.b)
							{
								width = this.c - (num - this.b);
							}
							try
							{
								MemoryStream obj = this.d;
								Bitmap bitmap;
								lock (obj)
								{
									bitmap = (Bitmap)Image.FromStream(this.d);
								}
								Rectangle rect = new Rectangle(A_0 * this.c, 0, width, this.a);
								BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
								Bitmap bitmap2 = new Bitmap(width, this.a, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
								bitmap.UnlockBits(bitmapData);
								string str = Path.Combine(Path.GetDirectoryName(this.e.a), Path.GetFileNameWithoutExtension(this.e.a) + "_" + A_0.ToString("D3"));
								if (this.f.c)
								{
									bitmap2.Save(str + ".bmp", ImageFormat.Bmp);
								}
								else
								{
									Encoder quality = Encoder.Quality;
									EncoderParameters encoderParameters = new EncoderParameters(1);
									EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)this.f.e));
									encoderParameters.Param[0] = encoderParameter;
									ImageCodecInfo encoder = x.a(ImageFormat.Jpeg);
									bitmap2.Save(str + ".jpg", encoder, encoderParameters);
									encoderParameter.Dispose();
									encoderParameters.Dispose();
								}
								bitmap2.Dispose();
								bitmap.Dispose();
								flag = true;
							}
							catch (Exception ex)
							{
								flag = false;
								x.c(ex.Message);
							}
							if (flag)
							{
								Interlocked.Add(ref x.k, 1);
								ArrayList obj2 = x.f;
								lock (obj2)
								{
									x.f.Add(this.e.a);
								}
							}
							this.f.a.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}

					// Token: 0x04000097 RID: 151
					public int a;

					// Token: 0x04000098 RID: 152
					public int b;

					// Token: 0x04000099 RID: 153
					public int c;

					// Token: 0x0400009A RID: 154
					public MemoryStream d;

					// Token: 0x0400009B RID: 155
					public BW1.d.a e;

					// Token: 0x0400009C RID: 156
					public BW1.d f;
				}
			}
		}

		// Token: 0x0200002B RID: 43
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x06000078 RID: 120 RVA: 0x0000A5E4 File Offset: 0x000087E4
			[CompilerGenerated]
			public void i(string A_0, ParallelLoopState A_1)
			{
				BW1.a.a a = new BW1.a.a();
				a.a = A_0;
				BW1.a.a.a a2 = new BW1.a.a.a();
				a2.f = this;
				a2.e = a;
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.d = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.d = true;
						A_1.Stop();
					}
				}
				a2.d = new MemoryStream();
				using (Bitmap bitmap = x.a(a.a))
				{
					a2.a = bitmap.Width;
					a2.b = bitmap.Height;
					bitmap.Save(a2.d, ImageFormat.Png);
				}
				a2.c = 0;
				checked
				{
					int num;
					if (this.b)
					{
						a2.c = this.f;
						num = (int)Math.Round((double)a2.b / (double)a2.c);
						double num2 = (double)a2.b / (double)a2.c;
						if (num2 > (double)num)
						{
							num++;
						}
					}
					else
					{
						a2.c = (int)Math.Round((double)a2.b / (double)this.g);
						num = this.g;
						double num2 = (double)a2.b / (double)this.g;
						if (num2 > (double)a2.c)
						{
							num++;
						}
					}
					Parallel.For(0, num, this.h, new Action<int, ParallelLoopState>(a2.g));
					a2.d.Dispose();
				}
			}

			// Token: 0x0400009D RID: 157
			public BackgroundWorker a;

			// Token: 0x0400009E RID: 158
			public bool b;

			// Token: 0x0400009F RID: 159
			public bool c;

			// Token: 0x040000A0 RID: 160
			public bool d;

			// Token: 0x040000A1 RID: 161
			public int e;

			// Token: 0x040000A2 RID: 162
			public int f;

			// Token: 0x040000A3 RID: 163
			public int g;

			// Token: 0x040000A4 RID: 164
			public ParallelOptions h;

			// Token: 0x0200002C RID: 44
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x040000A5 RID: 165
				public string a;

				// Token: 0x0200002D RID: 45
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600007B RID: 123 RVA: 0x0000A78C File Offset: 0x0000898C
					[CompilerGenerated]
					public void g(int A_0, ParallelLoopState A_1)
					{
						if (this.f.a.CancellationPending)
						{
							this.f.d = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.f.a.CancellationPending)
							{
								this.f.d = true;
								A_1.Stop();
							}
						}
						bool flag = false;
						int height = this.c;
						checked
						{
							int num = A_0 * this.c + this.c;
							if (num > this.b)
							{
								height = this.c - (num - this.b);
							}
							try
							{
								MemoryStream obj = this.d;
								Bitmap bitmap;
								lock (obj)
								{
									bitmap = (Bitmap)Image.FromStream(this.d);
								}
								Rectangle rect = new Rectangle(0, A_0 * this.c, this.a, height);
								BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
								Bitmap bitmap2 = new Bitmap(this.a, height, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
								bitmap.UnlockBits(bitmapData);
								string str = Path.Combine(Path.GetDirectoryName(this.e.a), Path.GetFileNameWithoutExtension(this.e.a) + "_" + A_0.ToString("D3"));
								if (this.f.c)
								{
									bitmap2.Save(str + ".bmp", ImageFormat.Bmp);
								}
								else
								{
									Encoder quality = Encoder.Quality;
									EncoderParameters encoderParameters = new EncoderParameters(1);
									EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)this.f.e));
									encoderParameters.Param[0] = encoderParameter;
									ImageCodecInfo encoder = x.a(ImageFormat.Jpeg);
									bitmap2.Save(str + ".jpg", encoder, encoderParameters);
									encoderParameter.Dispose();
									encoderParameters.Dispose();
								}
								bitmap2.Dispose();
								bitmap.Dispose();
								flag = true;
							}
							catch (Exception ex)
							{
								flag = false;
								x.c(ex.Message);
							}
							if (flag)
							{
								Interlocked.Add(ref x.k, 1);
								ArrayList obj2 = x.f;
								lock (obj2)
								{
									x.f.Add(this.e.a);
								}
							}
							this.f.a.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}

					// Token: 0x040000A6 RID: 166
					public int a;

					// Token: 0x040000A7 RID: 167
					public int b;

					// Token: 0x040000A8 RID: 168
					public int c;

					// Token: 0x040000A9 RID: 169
					public MemoryStream d;

					// Token: 0x040000AA RID: 170
					public BW1.a.a e;

					// Token: 0x040000AB RID: 171
					public BW1.a f;
				}
			}
		}

		// Token: 0x0200002E RID: 46
		[CompilerGenerated]
		internal class e
		{
			// Token: 0x0600007D RID: 125 RVA: 0x0000AA5C File Offset: 0x00008C5C
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			public void h(string A_0, ParallelLoopState A_1)
			{
				Interlocked.Add(ref x.i, 1);
				if (this.a.CancellationPending)
				{
					this.d = true;
					A_1.Stop();
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.d = true;
						A_1.Stop();
					}
				}
				Bitmap bitmap = x.a(A_0);
				int width = bitmap.Width;
				int height = bitmap.Height;
				PixelFormat pixelFormat = bitmap.PixelFormat;
				PixelFormat format = x.a(pixelFormat);
				int num;
				int height2;
				bool flag;
				string str;
				checked
				{
					if (this.f == 1)
					{
						num = this.g;
						height2 = (int)Math.Round(unchecked((double)this.g / (double)width * (double)height));
					}
					else if (this.f == 2)
					{
						num = (int)Math.Round(unchecked((double)this.g / (double)height * (double)width));
						height2 = this.g;
					}
					else if (this.f == 3)
					{
						num = (int)Math.Round((double)(width * this.g) / 100.0);
						height2 = (int)Math.Round((double)(height * this.g) / 100.0);
					}
					if (0 == num | 0 == num)
					{
						this.d = true;
						A_1.Stop();
					}
					flag = false;
					str = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0) + ".gpa");
				}
				try
				{
					Rectangle rect = new Rectangle(0, 0, width, height);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
					Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, format, bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					Bitmap bitmap3 = new Bitmap(num, height2, format);
					Graphics graphics = Graphics.FromImage(bitmap3);
					graphics.Clear(Color.Transparent);
					graphics.DrawImage(bitmap2, 0, 0, num, height2);
					graphics.Dispose();
					if (this.c)
					{
						bitmap3.Save(str + ".bmp", ImageFormat.Bmp);
					}
					else
					{
						Encoder quality = Encoder.Quality;
						EncoderParameters encoderParameters = new EncoderParameters(1);
						EncoderParameter encoderParameter = new EncoderParameter(quality, (long)this.e);
						encoderParameters.Param[0] = encoderParameter;
						ImageCodecInfo encoder = x.a(ImageFormat.Jpeg);
						bitmap3.Save(str + ".jpg", encoder, encoderParameters);
						encoderParameter.Dispose();
						encoderParameters.Dispose();
					}
					bitmap3.Dispose();
					bitmap2.Dispose();
					flag = true;
				}
				catch (Exception ex)
				{
					flag = false;
					x.c(ex.Message);
				}
				if (flag)
				{
					Interlocked.Add(ref x.k, 1);
					flag = false;
					if (this.b)
					{
						try
						{
							if (File.Exists(A_0))
							{
								File.Delete(A_0);
								flag = true;
							}
							goto IL_35B;
						}
						catch (Exception ex2)
						{
							flag = false;
							x.c(ex2.Message + " : " + A_0);
							goto IL_35B;
						}
					}
					string text = Path.Combine(Path.GetDirectoryName(A_0), "0_YouCanDel");
					try
					{
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
							x.c(x.ad.getMultiLingual("Form1_Thread_Mkdir_Msg") + text);
						}
					}
					catch (Exception ex3)
					{
						flag = false;
						x.c(ex3.Message);
					}
					text = Path.Combine(text, Path.GetFileName(A_0));
					try
					{
						if (File.Exists(A_0))
						{
							File.Move(A_0, text);
							flag = true;
						}
					}
					catch (Exception ex4)
					{
						flag = false;
						x.c(ex4.Message);
					}
					IL_35B:
					if (flag)
					{
						if (this.c)
						{
							FileSystem.Rename(str + ".bmp", Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0) + ".bmp"));
						}
						else
						{
							FileSystem.Rename(str + ".jpg", Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0) + ".jpg"));
						}
					}
				}
				bitmap.Dispose();
				this.a.ReportProgress(x.i);
				Thread.Sleep(x.c);
			}

			// Token: 0x040000AC RID: 172
			public BackgroundWorker a;

			// Token: 0x040000AD RID: 173
			public bool b;

			// Token: 0x040000AE RID: 174
			public bool c;

			// Token: 0x040000AF RID: 175
			public bool d;

			// Token: 0x040000B0 RID: 176
			public int e;

			// Token: 0x040000B1 RID: 177
			public int f;

			// Token: 0x040000B2 RID: 178
			public int g;
		}
	}
}
