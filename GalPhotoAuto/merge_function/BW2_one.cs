using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x0200002F RID: 47
	public class BW2_one
	{
		// Token: 0x0600007F RID: 127 RVA: 0x0000AEB8 File Offset: 0x000090B8
		public static bool merge_image_in(ref Form1 myForm1, int iMod = 1)
		{
			BW2_one.l l = new BW2_one.l();
			l.d = iMod;
			l.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				l.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				l.a = myForm1.BackgroundWorker2;
				l.e = 0;
				l.f = 0;
				if (5 == l.d)
				{
					l.e = x.ab;
					l.f = x.ac;
				}
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.l.a a = new BW2_one.l.a(a);
					string text = array3[i];
					a.f = l;
					Interlocked.Add(ref x.i, 1);
					if (l.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (l.a.CancellationPending)
						{
							return true;
						}
					}
					a.e = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						a.b = bitmap.Width;
						a.a = bitmap.Height;
						a.d = bitmap.PixelFormat;
						bitmap.Save(a.e, ImageFormat.Png);
					}
					a.c = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a.g));
					a.e.Dispose();
					if (@checked)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
					}
				}
				return l.c;
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000B100 File Offset: 0x00009300
		public static bool merge_m(ref Form1 myForm1, bool bBALpha = false)
		{
			BW2_one.e e = new BW2_one.e();
			e.b = bBALpha;
			e.c = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			e.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(e.d));
			return e.c;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000B190 File Offset: 0x00009390
		public static bool merge_sou_plus_alpha(ref Form1 myForm1, bool bReverse = false)
		{
			BW2_one.d d = new BW2_one.d();
			d.b = bReverse;
			d.c = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			d.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(d.d));
			return d.c;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000B220 File Offset: 0x00009420
		public static bool merge_xxx_mxxx(ref Form1 myForm1)
		{
			BW2_one.j j = new BW2_one.j();
			j.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			j.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(j.c));
			return j.b;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000B2A8 File Offset: 0x000094A8
		public static bool scan_image_find_area_merge(ref Form1 myForm1, int iMode = 0)
		{
			BW2_one.f f = new BW2_one.f(f);
			f.d = iMode;
			f.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				f.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				f.a = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.f.a a = new BW2_one.f.a(a);
					string text = array3[i];
					a.i = f;
					Interlocked.Add(ref x.i, 1);
					if (f.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (f.a.CancellationPending)
						{
							return true;
						}
					}
					a.h = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						a.e = bitmap.Width;
						a.b = bitmap.Height;
						a.g = bitmap.PixelFormat;
						bitmap.Save(a.h, ImageFormat.Png);
					}
					a.f = Path.GetFileNameWithoutExtension(text);
					a.a = false;
					a.c = -1;
					a.d = -1;
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a.j));
					a.h.Dispose();
					if (a.a && @checked)
					{
						ArrayList f2 = x.f;
						lock (f2)
						{
							x.f.Add(text);
						}
					}
				}
				return f.c;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000B4E8 File Offset: 0x000096E8
		public static bool merge_image_noWhitelookBlack(ref Form1 myForm1)
		{
			BW2_one.b b = new BW2_one.b();
			b.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				b.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				b.a = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.b.a a = new BW2_one.b.a(a);
					string text = array3[i];
					a.f = b;
					Interlocked.Add(ref x.i, 1);
					if (b.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (b.a.CancellationPending)
						{
							return true;
						}
					}
					a.e = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						a.b = bitmap.Width;
						a.a = bitmap.Height;
						a.d = bitmap.PixelFormat;
						bitmap.Save(a.e, ImageFormat.Png);
					}
					a.c = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a.g));
					a.e.Dispose();
					if (@checked)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
					}
				}
				return b.c;
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000B6FC File Offset: 0x000098FC
		public static bool merge_image_M_and_xy(ref Form1 myForm1)
		{
			BW2_one.g g = new BW2_one.g();
			g.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			g.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(g.c));
			return g.b;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000B784 File Offset: 0x00009984
		public static bool scan_b_scan_f_find_line_merge(ref Form1 myForm1, int iMode = 0)
		{
			BW2_one.a a = new BW2_one.a(a);
			a.d = iMode;
			a.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				a.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				a.a = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.a.a a2 = new BW2_one.a.a(a2);
					string text = array3[i];
					a2.k = a;
					Interlocked.Add(ref x.i, 1);
					if (a.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (a.a.CancellationPending)
						{
							return true;
						}
					}
					a2.j = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						a2.g = bitmap.Width;
						a2.d = bitmap.Height;
						a2.i = bitmap.PixelFormat;
						bitmap.Save(a2.j, ImageFormat.Png);
					}
					a2.a = false;
					PixelFormat i2 = a2.i;
					if (i2 == PixelFormat.Format24bppRgb)
					{
						a2.a = false;
					}
					else if (i2 == PixelFormat.Format32bppArgb)
					{
						a2.a = true;
					}
					else if (i2 == PixelFormat.Format16bppArgb1555)
					{
						a2.a = true;
					}
					else if (i2 == PixelFormat.Format32bppPArgb)
					{
						a2.a = true;
					}
					else if (i2 == PixelFormat.PAlpha)
					{
						a2.a = true;
					}
					else if (i2 == PixelFormat.Format64bppArgb)
					{
						a2.a = true;
					}
					else if (i2 == PixelFormat.Format64bppPArgb)
					{
						a2.a = true;
					}
					a2.c = new byte[a2.g + 1, a2.d + 1];
					if (a2.a)
					{
						FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(a2.j));
						int num = 0;
						int num2 = a2.g - 1;
						for (int j = num; j <= num2; j++)
						{
							int num3 = 0;
							int num4 = a2.d - 1;
							for (int k = num3; k <= num4; k++)
							{
								Color pixel = fastBitmap.GetPixel(j, k);
								a2.c[j, k] = pixel.A;
							}
						}
						fastBitmap.Dispose();
					}
					a2.h = Path.GetFileNameWithoutExtension(text);
					a2.b = false;
					a2.e = -1;
					a2.f = -1;
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a2.l));
					a2.j.Dispose();
					if (a2.b && @checked)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
					}
				}
				return a.c;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000BAF8 File Offset: 0x00009CF8
		public static bool merge_L_alpha_R_image(ref Form1 myForm1, int iMod = 0)
		{
			BW2_one.k k = new BW2_one.k();
			k.d = iMod;
			k.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				k.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				k.a = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.k.a a = new BW2_one.k.a(a);
					string text = array3[i];
					a.c = k;
					Interlocked.Add(ref x.i, 1);
					if (k.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (k.a.CancellationPending)
						{
							return true;
						}
					}
					a.b = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						bitmap.Save(a.b, ImageFormat.Png);
					}
					a.a = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a.d));
					a.b.Dispose();
					if (@checked)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
					}
				}
				return k.c;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000BCEC File Offset: 0x00009EEC
		public static bool merge_MS_M(ref Form1 myForm1)
		{
			BW2_one.h h = new BW2_one.h();
			h.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				h.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_one.h.a a = new BW2_one.h.a(a);
					string text = array2[i];
					Interlocked.Add(ref x.i, 1);
					if (h.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (h.a.CancellationPending)
						{
							return true;
						}
					}
					string directoryName = Path.GetDirectoryName(text);
					a.a = Path.GetFileNameWithoutExtension(text);
					string text2 = "_" + x.ak.Split(a.a).Last<string>();
					if (0 == string.Compare("_MS", text2, StringComparison.Ordinal) | 0 == string.Compare("_M", text2, StringComparison.Ordinal))
					{
						string path = a.a.Substring(0, a.a.Length - text2.Length);
						string strA = Path.Combine(directoryName, path);
						ArrayList arrayList = new ArrayList();
						try
						{
							foreach (object value in x.e)
							{
								string text3 = Conversions.ToString(value);
								if (0 != string.Compare(text3, text, StringComparison.Ordinal))
								{
									string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text3);
									if (Strings.InStr(1, fileNameWithoutExtension, "_", CompareMethod.Binary) > 0)
									{
										text2 = "_" + x.ak.Split(fileNameWithoutExtension).Last<string>();
										path = fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - text2.Length);
										string strB = Path.Combine(directoryName, path);
										if (0 == string.Compare(strA, strB, StringComparison.Ordinal))
										{
											arrayList.Add(text3);
										}
									}
								}
							}
						}
						finally
						{
							IEnumerator enumerator;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						if (0 < arrayList.Count)
						{
							BW2_one.h.a.a a2 = new BW2_one.h.a.a();
							a2.c = a;
							a2.b = h;
							a2.a = new MemoryStream();
							using (Bitmap bitmap = x.a(text))
							{
								bitmap.Save(a2.a, ImageFormat.Png);
							}
							Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.d));
							a2.a.Dispose();
							x.f.Add(text);
						}
					}
				}
				return h.b;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		public static bool merge_image_white_alpha_to_tran(ref Form1 myForm1)
		{
			BW2_one.c c = new BW2_one.c();
			c.c = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				c.b = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				ParallelOptions parallelOptions = x.a();
				c.a = myForm1.BackgroundWorker2;
				c.d = x.ab;
				c.e = x.ac;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one.c.a a = new BW2_one.c.a(a);
					string text = array3[i];
					a.e = c;
					Interlocked.Add(ref x.i, 1);
					if (c.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (c.a.CancellationPending)
						{
							return true;
						}
					}
					a.d = new MemoryStream();
					using (Bitmap bitmap = x.a(text))
					{
						a.b = bitmap.Width;
						a.a = bitmap.Height;
						PixelFormat pixelFormat = bitmap.PixelFormat;
						bitmap.Save(a.d, ImageFormat.Png);
					}
					a.c = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a.f));
					a.d.Dispose();
					if (@checked)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
					}
				}
				return c.c;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000C1F0 File Offset: 0x0000A3F0
		public static bool merge_image_abc_01_abc_xy(ref Form1 myForm1)
		{
			BW2_one.i i = new BW2_one.i();
			i.c = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			i.a = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref x.i, 1);
				if (i.a.CancellationPending)
				{
					return true;
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (i.a.CancellationPending)
					{
						return true;
					}
				}
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				i.b = Path.GetDirectoryName(text);
				string[] source = x.ak.Split(fileNameWithoutExtension);
				string text2 = source.Last<string>();
				if (Versioned.IsNumeric(text2) && 1 == Conversions.ToInteger(text2))
				{
					BW2_one.i.a a = new BW2_one.i.a();
					a.f = i;
					a.e = source.First<string>();
					a.c = new MemoryStream();
					Bitmap bitmap = x.a(text);
					a.d = bitmap.PixelFormat;
					a.b = bitmap.Width;
					a.a = bitmap.Height;
					Rectangle rect = new Rectangle(0, 0, a.b, a.a);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, a.d);
					Bitmap bitmap2 = new Bitmap(a.b, a.a, bitmapData.Stride, x.a(a.d), bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					bitmap2.Save(a.c, ImageFormat.Png);
					bitmap2.Dispose();
					bitmap.Dispose();
					Parallel.For(2, 100, parallelOptions, new Action<int, ParallelLoopState>(a.g));
					a.c.Dispose();
				}
			}
			x.aa = string.Empty;
			x.z = string.Empty;
			return i.c;
		}

		// Token: 0x02000030 RID: 48
		[CompilerGenerated]
		internal class l
		{
			// Token: 0x040000B3 RID: 179
			public BackgroundWorker a;

			// Token: 0x040000B4 RID: 180
			public bool b;

			// Token: 0x040000B5 RID: 181
			public bool c;

			// Token: 0x040000B6 RID: 182
			public int d;

			// Token: 0x040000B7 RID: 183
			public int e;

			// Token: 0x040000B8 RID: 184
			public int f;

			// Token: 0x02000031 RID: 49
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600008C RID: 140 RVA: 0x0000C428 File Offset: 0x0000A628
				public a(BW2_one.l.a A_0)
				{
					if (A_0 != null)
					{
						this.e = A_0.e;
						this.a = A_0.a;
						this.b = A_0.b;
						this.d = A_0.d;
						this.c = A_0.c;
					}
				}

				// Token: 0x0600008D RID: 141 RVA: 0x0000C47C File Offset: 0x0000A67C
				[CompilerGenerated]
				public void g(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.f.a.CancellationPending)
					{
						this.f.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.f.a.CancellationPending)
						{
							this.f.c = true;
							A_1.Stop();
						}
					}
					Bitmap bitmap = x.a(A_0);
					int x = 0;
					int y = 0;
					checked
					{
						switch (this.f.d)
						{
						case 2:
							y = this.a - bitmap.Height;
							break;
						case 3:
							x = this.b - bitmap.Width;
							break;
						case 4:
							x = this.b - bitmap.Width;
							y = this.a - bitmap.Height;
							break;
						case 5:
							x = this.f.e;
							y = this.f.f;
							break;
						}
						Bitmap bitmap2 = new Bitmap(this.b, this.a, this.d);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.Clear(Color.Transparent);
						MemoryStream obj = this.e;
						lock (obj)
						{
							graphics.DrawImage(Image.FromStream(this.e), 0, 0, this.b, this.a);
						}
						graphics.DrawImage(bitmap, x, y, bitmap.Width, bitmap.Height);
						graphics.Dispose();
						string str = x.a(this.c, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.c) + "_" + str;
						x.a(a_, ref bitmap2, true);
						Interlocked.Add(ref x.k, 1);
						bitmap2.Dispose();
						bitmap.Dispose();
						if (this.f.b)
						{
							ArrayList obj2 = x.f;
							lock (obj2)
							{
								x.f.Add(A_0);
							}
						}
						this.f.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x040000B9 RID: 185
				public int a;

				// Token: 0x040000BA RID: 186
				public int b;

				// Token: 0x040000BB RID: 187
				public string c;

				// Token: 0x040000BC RID: 188
				public PixelFormat d;

				// Token: 0x040000BD RID: 189
				public MemoryStream e;

				// Token: 0x040000BE RID: 190
				public BW2_one.l f;
			}
		}

		// Token: 0x02000032 RID: 50
		[CompilerGenerated]
		internal class e
		{
			// Token: 0x0600008F RID: 143 RVA: 0x0000C6E4 File Offset: 0x0000A8E4
			[CompilerGenerated]
			public void d(string A_0, ParallelLoopState A_1)
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
				bool flag = false;
				string directoryName = Path.GetDirectoryName(A_0);
				string path = Path.GetFileNameWithoutExtension(A_0) + "_m";
				string text = Path.Combine(directoryName, path);
				try
				{
					foreach (object obj in x.e)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						if (Strings.InStr(1, objectValue.ToString(), text, CompareMethod.Binary) > 0)
						{
							text = objectValue.ToString();
							flag = true;
							break;
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				checked
				{
					if (flag)
					{
						Interlocked.Add(ref x.i, 1);
						bool flag2 = false;
						try
						{
							Bitmap bitmap = x.a(A_0);
							FastBitmap fastBitmap = new FastBitmap(bitmap);
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							Bitmap bitmap2 = x.a(text);
							FastBitmap fastBitmap2 = new FastBitmap(bitmap2);
							Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
							int num = 0;
							int num2 = iWidth - 1;
							for (int i = num; i <= num2; i++)
							{
								int num3 = 0;
								int num4 = iHeight - 1;
								for (int j = num3; j <= num4; j++)
								{
									Color pixel = fastBitmap.GetPixel(i, j);
									Color pixel2 = fastBitmap2.GetPixel(i, j);
									int alpha;
									if (this.b)
									{
										alpha = 255 - x.c(ref pixel2);
									}
									else
									{
										alpha = x.c(ref pixel2);
									}
									fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
								}
							}
							x.a(A_0 + ".merge", ref fastBitmap3);
							fastBitmap3.Dispose();
							bitmap3.Dispose();
							fastBitmap2.Dispose();
							bitmap2.Dispose();
							fastBitmap.Dispose();
							bitmap.Dispose();
							flag2 = true;
						}
						catch (Exception ex)
						{
							flag2 = false;
							x.c("_m合成出错: " + ex.Message);
							throw new Exception(ex.Message);
						}
						if (flag2)
						{
							x.f.Add(A_0);
							x.f.Add(text);
							Interlocked.Add(ref x.k, 1);
						}
					}
					this.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}
			}

			// Token: 0x040000BF RID: 191
			public BackgroundWorker a;

			// Token: 0x040000C0 RID: 192
			public bool b;

			// Token: 0x040000C1 RID: 193
			public bool c;
		}

		// Token: 0x02000033 RID: 51
		[CompilerGenerated]
		internal class d
		{
			// Token: 0x06000091 RID: 145 RVA: 0x0000C990 File Offset: 0x0000AB90
			[CompilerGenerated]
			public void d(string A_0, ParallelLoopState A_1)
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
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				int num = 0;
				int num2 = 0;
				using (Bitmap bitmap = x.a(A_0))
				{
					num = bitmap.Width / 2;
					num2 = bitmap.Height;
					Rectangle rect = new Rectangle(0, 0, num, num2);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
					Bitmap bitmap2 = new Bitmap(num, num2, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					bitmap2.Save(memoryStream, ImageFormat.Png);
					bitmap2.Dispose();
					rect = new Rectangle(num, 0, num, num2);
					bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
					Bitmap bitmap3 = new Bitmap(num, num2, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					bitmap3.Save(memoryStream2, ImageFormat.Png);
					bitmap3.Dispose();
				}
				FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
				FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(memoryStream2));
				Bitmap bitmap4 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
				FastBitmap fastBitmap3 = new FastBitmap(bitmap4);
				int num3 = 0;
				checked
				{
					int num4 = num - 1;
					for (int i = num3; i <= num4; i++)
					{
						int num5 = 0;
						int num6 = num2 - 1;
						for (int j = num5; j <= num6; j++)
						{
							Color pixel = fastBitmap.GetPixel(i, j);
							Color pixel2 = fastBitmap2.GetPixel(i, j);
							int alpha;
							if (this.b)
							{
								alpha = 255 - x.c(ref pixel2);
							}
							else
							{
								alpha = x.c(ref pixel2);
							}
							fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
						}
					}
					x.a(A_0 + ".merge", ref fastBitmap3);
					Interlocked.Add(ref x.k, 1);
					fastBitmap3.Dispose();
					bitmap4.Dispose();
					fastBitmap2.Dispose();
					fastBitmap.Dispose();
					memoryStream2.Dispose();
					memoryStream.Dispose();
					ArrayList f = x.f;
					lock (f)
					{
						x.f.Add(A_0);
					}
					this.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}
			}

			// Token: 0x040000C2 RID: 194
			public BackgroundWorker a;

			// Token: 0x040000C3 RID: 195
			public bool b;

			// Token: 0x040000C4 RID: 196
			public bool c;
		}

		// Token: 0x02000034 RID: 52
		[CompilerGenerated]
		internal class j
		{
			// Token: 0x06000093 RID: 147 RVA: 0x0000CC50 File Offset: 0x0000AE50
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
				string directoryName = Path.GetDirectoryName(A_0);
				string path = "m" + Path.GetFileNameWithoutExtension(A_0);
				string text = Path.Combine(directoryName, path);
				try
				{
					foreach (object obj in x.e)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						if (Strings.InStr(1, objectValue.ToString(), text, CompareMethod.Binary) > 0)
						{
							text = objectValue.ToString();
							flag = true;
							break;
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				checked
				{
					if (flag)
					{
						Interlocked.Add(ref x.i, 1);
						bool flag2 = false;
						try
						{
							Bitmap bitmap = x.a(A_0);
							FastBitmap fastBitmap = new FastBitmap(bitmap);
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							Bitmap bitmap2 = x.a(text);
							FastBitmap fastBitmap2 = new FastBitmap(bitmap2);
							Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
							int num = 0;
							int num2 = iWidth - 1;
							for (int i = num; i <= num2; i++)
							{
								int num3 = 0;
								int num4 = iHeight - 1;
								for (int j = num3; j <= num4; j++)
								{
									Color pixel = fastBitmap.GetPixel(i, j);
									Color pixel2 = fastBitmap2.GetPixel(i, j);
									int alpha = x.c(ref pixel2);
									fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
								}
							}
							x.a(A_0 + ".merge", ref fastBitmap3);
							fastBitmap3.Dispose();
							bitmap3.Dispose();
							fastBitmap2.Dispose();
							bitmap2.Dispose();
							fastBitmap.Dispose();
							bitmap.Dispose();
							flag2 = true;
						}
						catch (Exception ex)
						{
							flag2 = false;
							x.c("mxxx合成出错: " + ex.Message);
							throw new Exception(ex.Message);
						}
						if (flag2)
						{
							x.f.Add(A_0);
							x.f.Add(text);
							Interlocked.Add(ref x.k, 1);
						}
					}
					this.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}
			}

			// Token: 0x040000C5 RID: 197
			public BackgroundWorker a;

			// Token: 0x040000C6 RID: 198
			public bool b;
		}

		// Token: 0x02000035 RID: 53
		[CompilerGenerated]
		internal class f
		{
			// Token: 0x06000094 RID: 148 RVA: 0x0000CEC4 File Offset: 0x0000B0C4
			public f(BW2_one.f A_0)
			{
				if (A_0 != null)
				{
					this.c = A_0.c;
					this.b = A_0.b;
					this.a = A_0.a;
					this.d = A_0.d;
				}
			}

			// Token: 0x040000C7 RID: 199
			public BackgroundWorker a;

			// Token: 0x040000C8 RID: 200
			public bool b;

			// Token: 0x040000C9 RID: 201
			public bool c;

			// Token: 0x040000CA RID: 202
			public int d;

			// Token: 0x02000036 RID: 54
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000095 RID: 149 RVA: 0x0000CF00 File Offset: 0x0000B100
				public a(BW2_one.f.a A_0)
				{
					if (A_0 != null)
					{
						this.h = A_0.h;
						this.e = A_0.e;
						this.b = A_0.b;
						this.g = A_0.g;
						this.c = A_0.c;
						this.a = A_0.a;
						this.f = A_0.f;
						this.d = A_0.d;
					}
				}

				// Token: 0x06000096 RID: 150 RVA: 0x0000CF78 File Offset: 0x0000B178
				[CompilerGenerated]
				public void j(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.i.a.CancellationPending)
					{
						this.i.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.i.a.CancellationPending)
						{
							this.i.c = true;
							A_1.Stop();
						}
					}
					MemoryStream memoryStream = new MemoryStream();
					int width;
					int height;
					using (Bitmap bitmap = x.a(A_0))
					{
						width = bitmap.Width;
						height = bitmap.Height;
						bitmap.Save(memoryStream, ImageFormat.Png);
					}
					checked
					{
						if (-1 == this.c | -1 == this.d)
						{
							MemoryStream obj = this.h;
							lock (obj)
							{
								FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(this.h));
								FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
								if (!(-1 < this.c & -1 < this.d))
								{
									int num = 1;
									int num2 = this.e - 1;
									for (int i = num; i <= num2; i++)
									{
										int num3 = 1;
										int num4 = this.b - 1;
										for (int j = num3; j <= num4; j++)
										{
											if (fastBitmap.GetPixel(i, j).A == 0 && fastBitmap.GetPixel(i - 1, j).A == 255 && fastBitmap.GetPixel(i, j - 1).A == 255)
											{
												if (1 == this.i.d && fastBitmap.GetPixel(i + width - 1, j).A == 0 && fastBitmap.GetPixel(i + width, j).A > 0 && fastBitmap.GetPixel(i + width - 1, j - 1).A > 0)
												{
													this.c = i;
													this.d = j;
													this.a = true;
													goto IL_2C9;
												}
												int num5 = 0;
												int num6 = 0;
												int num7 = width - 1;
												for (int k = num6; k <= num7; k++)
												{
													int num8 = 0;
													int num9 = height - 1;
													for (int l = num8; l <= num9; l++)
													{
														Color pixel = fastBitmap2.GetPixel(k, l);
														Color pixel2 = fastBitmap.GetPixel(k + i, l + j);
														if (255 - pixel.A == pixel2.A)
														{
															num5++;
														}
													}
												}
												if (num5 == width * height)
												{
													this.c = i;
													this.d = j;
													this.a = true;
												}
											}
											if (-1 < this.c & -1 < this.d)
											{
												goto IL_2C9;
											}
										}
									}
								}
								IL_2C9:
								fastBitmap2.Dispose();
								fastBitmap.Dispose();
							}
						}
						if (-1 == this.c | -1 == this.d)
						{
							return;
						}
						Bitmap bitmap2 = new Bitmap(this.e, this.b, this.g);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.Clear(Color.Transparent);
						MemoryStream obj2 = this.h;
						lock (obj2)
						{
							graphics.DrawImage(Image.FromStream(this.h), 0, 0, this.e, this.b);
						}
						graphics.DrawImage(Image.FromStream(memoryStream), this.c, this.d, width, height);
						graphics.Dispose();
						string str = x.a(this.f, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.f) + "_" + str;
						x.a(a_, ref bitmap2, true);
						Interlocked.Add(ref x.k, 1);
						bitmap2.Dispose();
						memoryStream.Dispose();
						if (this.i.b)
						{
							ArrayList obj3 = x.f;
							lock (obj3)
							{
								x.f.Add(A_0);
							}
						}
						this.i.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x040000CB RID: 203
				public bool a;

				// Token: 0x040000CC RID: 204
				public int b;

				// Token: 0x040000CD RID: 205
				public int c;

				// Token: 0x040000CE RID: 206
				public int d;

				// Token: 0x040000CF RID: 207
				public int e;

				// Token: 0x040000D0 RID: 208
				public string f;

				// Token: 0x040000D1 RID: 209
				public PixelFormat g;

				// Token: 0x040000D2 RID: 210
				public MemoryStream h;

				// Token: 0x040000D3 RID: 211
				public BW2_one.f i;
			}
		}

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x040000D4 RID: 212
			public BackgroundWorker a;

			// Token: 0x040000D5 RID: 213
			public bool b;

			// Token: 0x040000D6 RID: 214
			public bool c;

			// Token: 0x02000038 RID: 56
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000098 RID: 152 RVA: 0x0000D42C File Offset: 0x0000B62C
				public a(BW2_one.b.a A_0)
				{
					if (A_0 != null)
					{
						this.e = A_0.e;
						this.c = A_0.c;
						this.b = A_0.b;
						this.a = A_0.a;
						this.d = A_0.d;
					}
				}

				// Token: 0x06000099 RID: 153 RVA: 0x0000D480 File Offset: 0x0000B680
				[CompilerGenerated]
				public void g(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.f.a.CancellationPending)
					{
						this.f.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.f.a.CancellationPending)
						{
							this.f.c = true;
							A_1.Stop();
						}
					}
					Bitmap bitmap = new Bitmap(this.b, this.a, this.d);
					FastBitmap fastBitmap = new FastBitmap(bitmap);
					MemoryStream obj = this.e;
					FastBitmap fastBitmap2;
					lock (obj)
					{
						fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(this.e));
					}
					FastBitmap fastBitmap3 = new FastBitmap(x.a(A_0));
					int num = 0;
					checked
					{
						int num2 = this.b - 1;
						for (int i = num; i <= num2; i++)
						{
							int num3 = 0;
							int num4 = this.a - 1;
							for (int j = num3; j <= num4; j++)
							{
								Color pixel = fastBitmap2.GetPixel(i, j);
								Color pixel2 = fastBitmap3.GetPixel(i, j);
								if (pixel2.A == 255)
								{
									fastBitmap.SetPixel(i, j, pixel2);
								}
								else
								{
									fastBitmap.SetPixel(i, j, pixel);
								}
							}
						}
						string str = x.a(this.c, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.c) + "_" + str;
						x.a(a_, ref fastBitmap);
						Interlocked.Add(ref x.k, 1);
						fastBitmap3.Dispose();
						fastBitmap2.Dispose();
						fastBitmap.Dispose();
						bitmap.Dispose();
						if (this.f.b)
						{
							ArrayList obj2 = x.f;
							lock (obj2)
							{
								x.f.Add(A_0);
							}
						}
						this.f.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x040000D7 RID: 215
				public int a;

				// Token: 0x040000D8 RID: 216
				public int b;

				// Token: 0x040000D9 RID: 217
				public string c;

				// Token: 0x040000DA RID: 218
				public PixelFormat d;

				// Token: 0x040000DB RID: 219
				public MemoryStream e;

				// Token: 0x040000DC RID: 220
				public BW2_one.b f;
			}
		}

		// Token: 0x02000039 RID: 57
		[CompilerGenerated]
		internal class g
		{
			// Token: 0x0600009B RID: 155 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
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
				string directoryName = Path.GetDirectoryName(A_0);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				string[] array = null;
				string text = string.Empty;
				checked
				{
					if (Strings.InStr(1, fileNameWithoutExtension, "Mx", CompareMethod.Binary) > 0)
					{
						array = fileNameWithoutExtension.Split(new char[]
						{
							'M'
						});
						text = array[0];
						if (string.IsNullOrEmpty(text))
						{
							return;
						}
						string text2 = Path.Combine(directoryName, text);
						string str = text2;
						try
						{
							foreach (object value in x.e)
							{
								string text3 = Conversions.ToString(value);
								if (0 != string.Compare(text3, A_0, StringComparison.Ordinal) && Strings.InStr(1, text3, text2, CompareMethod.Binary) > 0)
								{
									text2 = text3;
									flag = true;
									break;
								}
							}
						}
						finally
						{
							IEnumerator enumerator;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						if (flag)
						{
							text = array[1].Substring(1);
							array = text.Split(new char[]
							{
								'y'
							});
							if (!(Versioned.IsNumeric(array[0]) & Versioned.IsNumeric(array[1])))
							{
								return;
							}
							int num = Conversions.ToInteger(array[0]);
							int num2 = Conversions.ToInteger(array[1]);
							text = Path.GetFileNameWithoutExtension(text2);
							array = text.Split(new char[]
							{
								'x'
							});
							text = array[1];
							array = text.Split(new char[]
							{
								'y'
							});
							if (!(Versioned.IsNumeric(array[0]) & Versioned.IsNumeric(array[1])))
							{
								return;
							}
							int num3 = Conversions.ToInteger(array[0]);
							int num4 = Conversions.ToInteger(array[1]);
							Interlocked.Add(ref x.i, 1);
							bool flag2 = false;
							try
							{
								Bitmap bitmap = x.a(text2);
								FastBitmap fastBitmap = new FastBitmap(bitmap);
								int iWidth = fastBitmap.iWidth;
								int iHeight = fastBitmap.iHeight;
								Bitmap bitmap2 = x.a(A_0);
								FastBitmap fastBitmap2 = new FastBitmap(bitmap2);
								Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
								FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
								int num5 = 0;
								int num6 = iWidth - 1;
								for (int i = num5; i <= num6; i++)
								{
									int num7 = 0;
									int num8 = iHeight - 1;
									for (int j = num7; j <= num8; j++)
									{
										Color pixel = fastBitmap.GetPixel(i, j);
										Color pixel2 = fastBitmap2.GetPixel(i + num3 - num, j + num4 - num2);
										int alpha = x.c(ref pixel2);
										fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
									}
								}
								x.a(str + ".merge", ref fastBitmap3);
								fastBitmap3.Dispose();
								bitmap3.Dispose();
								fastBitmap2.Dispose();
								bitmap2.Dispose();
								fastBitmap.Dispose();
								bitmap.Dispose();
								flag2 = true;
							}
							catch (Exception ex)
							{
								flag2 = false;
								x.c("文件名中间带M和后面带xy坐标合成出错: " + ex.Message);
								throw new Exception(ex.Message);
							}
							if (flag2)
							{
								x.f.Add(A_0);
								x.f.Add(text2);
								Interlocked.Add(ref x.k, 1);
							}
						}
						this.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}
			}

			// Token: 0x040000DD RID: 221
			public BackgroundWorker a;

			// Token: 0x040000DE RID: 222
			public bool b;
		}

		// Token: 0x0200003A RID: 58
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x0600009C RID: 156 RVA: 0x0000DA4C File Offset: 0x0000BC4C
			public a(BW2_one.a A_0)
			{
				if (A_0 != null)
				{
					this.d = A_0.d;
					this.c = A_0.c;
					this.b = A_0.b;
					this.a = A_0.a;
				}
			}

			// Token: 0x040000DF RID: 223
			public BackgroundWorker a;

			// Token: 0x040000E0 RID: 224
			public bool b;

			// Token: 0x040000E1 RID: 225
			public bool c;

			// Token: 0x040000E2 RID: 226
			public int d;

			// Token: 0x0200003B RID: 59
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600009D RID: 157 RVA: 0x0000DA88 File Offset: 0x0000BC88
				public a(BW2_one.a.a A_0)
				{
					if (A_0 != null)
					{
						this.j = A_0.j;
						this.h = A_0.h;
						this.g = A_0.g;
						this.d = A_0.d;
						this.i = A_0.i;
						this.a = A_0.a;
						this.c = A_0.c;
						this.e = A_0.e;
						this.f = A_0.f;
						this.b = A_0.b;
					}
				}

				// Token: 0x0600009E RID: 158 RVA: 0x0000DB18 File Offset: 0x0000BD18
				[CompilerGenerated]
				public void l(string A_0, ParallelLoopState A_1)
				{
					int num = 0;
					Interlocked.Add(ref x.i, 1);
					checked
					{
						MemoryStream memoryStream;
						int width;
						int height;
						for (;;)
						{
							if (this.k.a.CancellationPending)
							{
								this.k.c = true;
								A_1.Stop();
							}
							while (x.a)
							{
								Thread.Sleep(500);
								if (this.k.a.CancellationPending)
								{
									this.k.c = true;
									A_1.Stop();
								}
							}
							memoryStream = new MemoryStream();
							using (Bitmap bitmap = x.a(A_0))
							{
								width = bitmap.Width;
								height = bitmap.Height;
								bitmap.Save(memoryStream, ImageFormat.Png);
							}
							if (-1 == this.e | -1 == this.f)
							{
								MemoryStream obj = this.j;
								lock (obj)
								{
									if (!(-1 < this.e & -1 < this.f))
									{
										FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(this.j));
										FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
										Color pixel;
										if (2 == this.k.d)
										{
											pixel = fastBitmap2.GetPixel(0, height - 1);
										}
										else if (4 == this.k.d)
										{
											pixel = fastBitmap2.GetPixel(width - 1, 0);
										}
										else
										{
											pixel = fastBitmap2.GetPixel(0, 0);
										}
										int num2 = 0;
										int num3 = this.g - 1;
										for (int i = num2; i <= num3; i++)
										{
											int num4 = 0;
											int num5 = this.d - 1;
											for (int j = num4; j <= num5; j++)
											{
												Color pixel2 = fastBitmap.GetPixel(i, j);
												if (pixel2.R == pixel.R & pixel2.G == pixel.G & pixel2.B == pixel.B)
												{
													if (1 == this.k.d)
													{
														int num6 = 0;
														int num7 = width - 1;
														for (int k = num6; k <= num7; k++)
														{
															pixel2 = fastBitmap2.GetPixel(k, 0);
															Color pixel3 = fastBitmap.GetPixel(k + i, j);
															if (!(pixel2.R == pixel3.R & pixel2.G == pixel3.G & pixel2.B == pixel3.B))
															{
																this.b = false;
																this.e = -1;
																this.f = -1;
																break;
															}
															this.b = true;
															this.e = i;
															this.f = j;
														}
													}
													else if (2 == this.k.d)
													{
														int num8 = 0;
														int num9 = width - 1;
														for (int l = num8; l <= num9; l++)
														{
															pixel2 = fastBitmap2.GetPixel(l, height - 1);
															Color pixel3 = fastBitmap.GetPixel(l + i, j);
															if (!(pixel2.R == pixel3.R & pixel2.G == pixel3.G & pixel2.B == pixel3.B))
															{
																this.b = false;
																this.e = -1;
																this.f = -1;
																break;
															}
															this.b = true;
															this.e = i;
															this.f = j - height + 1;
														}
													}
													else if (3 == this.k.d)
													{
														int num10 = 0;
														int num11 = height - 1;
														for (int m = num10; m <= num11; m++)
														{
															pixel2 = fastBitmap2.GetPixel(0, m);
															Color pixel3 = fastBitmap.GetPixel(i, m + j);
															if (!(pixel2.R == pixel3.R & pixel2.G == pixel3.G & pixel2.B == pixel3.B))
															{
																this.b = false;
																this.e = -1;
																this.f = -1;
																break;
															}
															this.b = true;
															this.e = i;
															this.f = j;
														}
													}
													else if (4 == this.k.d)
													{
														int num12 = 0;
														int num13 = height - 1;
														for (int n = num12; n <= num13; n++)
														{
															pixel2 = fastBitmap2.GetPixel(width - 1, n);
															Color pixel3 = fastBitmap.GetPixel(i, n + j);
															if (!(pixel2.R == pixel3.R & pixel2.G == pixel3.G & pixel2.B == pixel3.B))
															{
																this.b = false;
																this.e = -1;
																this.f = -1;
																break;
															}
															this.b = true;
															this.e = i - width + 1;
															this.f = j;
														}
													}
												}
												if (-1 < this.e & -1 < this.f)
												{
													goto IL_4EA;
												}
											}
										}
										fastBitmap2.Dispose();
										fastBitmap.Dispose();
									}
								}
							}
							IL_4EA:
							if (!(-1 == this.e | -1 == this.f))
							{
								goto IL_50E;
							}
							if (10 <= num)
							{
								break;
							}
							num++;
						}
						return;
						IL_50E:
						Bitmap bitmap2 = new Bitmap(this.g, this.d, this.i);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.Clear(Color.Transparent);
						MemoryStream obj2 = this.j;
						lock (obj2)
						{
							graphics.DrawImage(Image.FromStream(this.j), 0, 0, this.g, this.d);
						}
						graphics.DrawImage(Image.FromStream(memoryStream), this.e, this.f, width, height);
						graphics.Dispose();
						string str = x.a(this.h, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.h) + "_" + str;
						if (this.a)
						{
							FastBitmap fastBitmap3 = new FastBitmap(bitmap2);
							int num14 = 0;
							int num15 = this.g - 1;
							for (int num16 = num14; num16 <= num15; num16++)
							{
								int num17 = 0;
								int num18 = this.d - 1;
								for (int num19 = num17; num19 <= num18; num19++)
								{
									Color pixel4 = fastBitmap3.GetPixel(num16, num19);
									fastBitmap3.SetPixel(num16, num19, Color.FromArgb((int)this.c[num16, num19], pixel4));
								}
							}
							x.a(a_, ref fastBitmap3);
							fastBitmap3.Dispose();
						}
						else
						{
							x.a(a_, ref bitmap2, true);
						}
						Interlocked.Add(ref x.k, 1);
						bitmap2.Dispose();
						memoryStream.Dispose();
						if (this.k.b)
						{
							ArrayList obj3 = x.f;
							lock (obj3)
							{
								x.f.Add(A_0);
							}
						}
						this.k.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x040000E3 RID: 227
				public bool a;

				// Token: 0x040000E4 RID: 228
				public bool b;

				// Token: 0x040000E5 RID: 229
				public byte[,] c;

				// Token: 0x040000E6 RID: 230
				public int d;

				// Token: 0x040000E7 RID: 231
				public int e;

				// Token: 0x040000E8 RID: 232
				public int f;

				// Token: 0x040000E9 RID: 233
				public int g;

				// Token: 0x040000EA RID: 234
				public string h;

				// Token: 0x040000EB RID: 235
				public PixelFormat i;

				// Token: 0x040000EC RID: 236
				public MemoryStream j;

				// Token: 0x040000ED RID: 237
				public BW2_one.a k;
			}
		}

		// Token: 0x0200003C RID: 60
		[CompilerGenerated]
		internal class k
		{
			// Token: 0x040000EE RID: 238
			public BackgroundWorker a;

			// Token: 0x040000EF RID: 239
			public bool b;

			// Token: 0x040000F0 RID: 240
			public bool c;

			// Token: 0x040000F1 RID: 241
			public int d;

			// Token: 0x0200003D RID: 61
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x060000A0 RID: 160 RVA: 0x0000E268 File Offset: 0x0000C468
				public a(BW2_one.k.a A_0)
				{
					if (A_0 != null)
					{
						this.b = A_0.b;
						this.a = A_0.a;
					}
				}

				// Token: 0x060000A1 RID: 161 RVA: 0x0000E28C File Offset: 0x0000C48C
				[CompilerGenerated]
				public void d(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.c.a.CancellationPending)
					{
						this.c.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.c.a.CancellationPending)
						{
							this.c.c = true;
							A_1.Stop();
						}
					}
					MemoryStream obj = this.b;
					Bitmap bitmap;
					lock (obj)
					{
						bitmap = (Bitmap)Image.FromStream(this.b);
					}
					FastBitmap fastBitmap = new FastBitmap(bitmap);
					int iWidth = fastBitmap.iWidth;
					int iHeight = fastBitmap.iHeight;
					Bitmap bitmap2 = x.a(A_0);
					FastBitmap fastBitmap2 = new FastBitmap(bitmap2);
					Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
					FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
					int num = 0;
					checked
					{
						int num2 = iWidth - 1;
						for (int i = num; i <= num2; i++)
						{
							int num3 = 0;
							int num4 = iHeight - 1;
							for (int j = num3; j <= num4; j++)
							{
								Color pixel = fastBitmap.GetPixel(i, j);
								Color pixel2 = fastBitmap2.GetPixel(i, j);
								int alpha;
								if (1 == this.c.d)
								{
									alpha = 255 - x.c(ref pixel);
								}
								else
								{
									alpha = x.c(ref pixel);
								}
								fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel2));
							}
						}
						string str = x.a(this.a, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.a) + "_" + str;
						x.a(a_, ref fastBitmap3);
						fastBitmap3.Dispose();
						bitmap3.Dispose();
						fastBitmap2.Dispose();
						bitmap2.Dispose();
						fastBitmap.Dispose();
						bitmap.Dispose();
						Interlocked.Add(ref x.k, 1);
						if (this.c.b)
						{
							ArrayList f = x.f;
							lock (f)
							{
								x.f.Add(A_0);
							}
						}
						this.c.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x040000F2 RID: 242
				public string a;

				// Token: 0x040000F3 RID: 243
				public MemoryStream b;

				// Token: 0x040000F4 RID: 244
				public BW2_one.k c;
			}
		}

		// Token: 0x0200003E RID: 62
		[CompilerGenerated]
		internal class h
		{
			// Token: 0x040000F5 RID: 245
			public BackgroundWorker a;

			// Token: 0x040000F6 RID: 246
			public bool b;

			// Token: 0x0200003F RID: 63
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x060000A3 RID: 163 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
				public a(BW2_one.h.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x040000F7 RID: 247
				public string a;

				// Token: 0x02000040 RID: 64
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x060000A5 RID: 165 RVA: 0x0000E4FF File Offset: 0x0000C6FF
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void d(object A_0, ParallelLoopState A_1)
					{
						new ac<string, ParallelLoopState>(this.d)(Conversions.ToString(A_0), A_1);
					}

					// Token: 0x060000A6 RID: 166 RVA: 0x0000E51C File Offset: 0x0000C71C
					[CompilerGenerated]
					public void d(string A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref x.i, 1);
						if (this.b.a.CancellationPending)
						{
							this.b.b = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.b.a.CancellationPending)
							{
								this.b.b = true;
								A_1.Stop();
							}
						}
						MemoryStream obj = this.a;
						Bitmap bitmap;
						lock (obj)
						{
							bitmap = (Bitmap)Image.FromStream(this.a);
						}
						FastBitmap fastBitmap = new FastBitmap(bitmap);
						int iWidth = fastBitmap.iWidth;
						int iHeight = fastBitmap.iHeight;
						Bitmap bitmap2 = x.a(A_0);
						FastBitmap fastBitmap2 = new FastBitmap(bitmap2);
						Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
						FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
						int num = 0;
						checked
						{
							int num2 = iWidth - 1;
							for (int i = num; i <= num2; i++)
							{
								int num3 = 0;
								int num4 = iHeight - 1;
								for (int j = num3; j <= num4; j++)
								{
									Color pixel = fastBitmap.GetPixel(i, j);
									Color pixel2 = fastBitmap2.GetPixel(i, j);
									int alpha = 255 - x.c(ref pixel);
									fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel2));
								}
							}
							string str = x.a(this.c.a, Path.GetFileNameWithoutExtension(A_0), 0);
							string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.c.a) + "_" + str;
							x.a(a_, ref fastBitmap3);
							fastBitmap3.Dispose();
							bitmap3.Dispose();
							fastBitmap2.Dispose();
							bitmap2.Dispose();
							fastBitmap.Dispose();
							bitmap.Dispose();
							Interlocked.Add(ref x.k, 1);
							ArrayList f = x.f;
							lock (f)
							{
								x.f.Add(A_0);
							}
							this.b.a.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}

					// Token: 0x040000F8 RID: 248
					public MemoryStream a;

					// Token: 0x040000F9 RID: 249
					public BW2_one.h b;

					// Token: 0x040000FA RID: 250
					public BW2_one.h.a c;
				}
			}
		}

		// Token: 0x02000041 RID: 65
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x040000FB RID: 251
			public BackgroundWorker a;

			// Token: 0x040000FC RID: 252
			public bool b;

			// Token: 0x040000FD RID: 253
			public bool c;

			// Token: 0x040000FE RID: 254
			public int d;

			// Token: 0x040000FF RID: 255
			public int e;

			// Token: 0x02000042 RID: 66
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x060000A8 RID: 168 RVA: 0x0000E754 File Offset: 0x0000C954
				public a(BW2_one.c.a A_0)
				{
					if (A_0 != null)
					{
						this.d = A_0.d;
						this.b = A_0.b;
						this.a = A_0.a;
						this.c = A_0.c;
					}
				}

				// Token: 0x060000A9 RID: 169 RVA: 0x0000E790 File Offset: 0x0000C990
				[CompilerGenerated]
				public void f(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.e.a.CancellationPending)
					{
						this.e.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.e.a.CancellationPending)
						{
							this.e.c = true;
							A_1.Stop();
						}
					}
					MemoryStream obj = this.d;
					FastBitmap fastBitmap;
					lock (obj)
					{
						fastBitmap = new FastBitmap((Bitmap)Image.FromStream(this.d));
					}
					FastBitmap fastBitmap2 = new FastBitmap(x.a(A_0));
					checked
					{
						int num = fastBitmap2.iWidth - 1;
						int num2 = fastBitmap2.iHeight - 1;
						int num3 = 0;
						int num4 = this.b - 1;
						int num5 = num3;
						while (num5 <= num4 && num5 <= num)
						{
							int num6 = 0;
							int num7 = this.a - 1;
							int num8 = num6;
							while (num8 <= num7 && num8 <= num2)
							{
								Color pixel = fastBitmap2.GetPixel(num5, num8);
								int num9 = (int)pixel.A;
								if (255 == num9)
								{
									fastBitmap.SetPixel(num5 + this.e.d, num8 + this.e.e, Color.FromArgb(num9, pixel));
								}
								num8++;
							}
							num5++;
						}
						string str = x.a(this.c, Path.GetFileNameWithoutExtension(A_0), 0);
						string a_ = Path.Combine(Path.GetDirectoryName(A_0), this.c) + "_" + str;
						x.a(a_, ref fastBitmap);
						Interlocked.Add(ref x.k, 1);
						fastBitmap2.Dispose();
						fastBitmap.Dispose();
						if (this.e.b)
						{
							ArrayList f = x.f;
							lock (f)
							{
								x.f.Add(A_0);
							}
						}
						this.e.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x04000100 RID: 256
				public int a;

				// Token: 0x04000101 RID: 257
				public int b;

				// Token: 0x04000102 RID: 258
				public string c;

				// Token: 0x04000103 RID: 259
				public MemoryStream d;

				// Token: 0x04000104 RID: 260
				public BW2_one.c e;
			}
		}

		// Token: 0x02000043 RID: 67
		[CompilerGenerated]
		internal class i
		{
			// Token: 0x04000105 RID: 261
			public BackgroundWorker a;

			// Token: 0x04000106 RID: 262
			public string b;

			// Token: 0x04000107 RID: 263
			public bool c;

			// Token: 0x02000044 RID: 68
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x060000AC RID: 172 RVA: 0x0000E9BC File Offset: 0x0000CBBC
				[CompilerGenerated]
				public void g(int A_0, ParallelLoopState A_1)
				{
					if (this.f.a.CancellationPending)
					{
						this.f.c = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.f.a.CancellationPending)
						{
							this.f.c = true;
							A_1.Stop();
						}
					}
					string text = A_0.ToString("D2");
					string a_ = Path.Combine(this.f.b, this.e + "_" + text);
					text = x.a(a_, "");
					if (string.IsNullOrEmpty(text))
					{
						return;
					}
					Bitmap bitmap = new Bitmap(this.b, this.a, this.d);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.Clear(Color.Transparent);
					MemoryStream obj = this.c;
					lock (obj)
					{
						using (Bitmap bitmap2 = (Bitmap)Image.FromStream(this.c))
						{
							graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
						}
					}
					using (Bitmap bitmap3 = x.a(text))
					{
						int width = bitmap3.Width;
						int height = bitmap3.Height;
						Rectangle rect = new Rectangle(0, 0, width, height);
						BitmapData bitmapData = bitmap3.LockBits(rect, ImageLockMode.ReadOnly, bitmap3.PixelFormat);
						Bitmap bitmap4 = new Bitmap(width, height, bitmapData.Stride, x.a(bitmap3.PixelFormat), bitmapData.Scan0);
						bitmap3.UnlockBits(bitmapData);
						graphics.DrawImage(bitmap4, 0, 0, bitmap4.Width, bitmap4.Height);
						bitmap4.Dispose();
					}
					graphics.Dispose();
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					string[] source = x.ak.Split(fileNameWithoutExtension);
					string a_2 = Path.Combine(this.f.b, source.First<string>() + "_01_" + source.Last<string>());
					x.a(a_2, ref bitmap, true);
					bitmap.Dispose();
					ArrayList obj2 = x.f;
					lock (obj2)
					{
						x.f.Add(text);
					}
					Interlocked.Add(ref x.k, 1);
					this.f.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}

				// Token: 0x04000108 RID: 264
				public int a;

				// Token: 0x04000109 RID: 265
				public int b;

				// Token: 0x0400010A RID: 266
				public MemoryStream c;

				// Token: 0x0400010B RID: 267
				public PixelFormat d;

				// Token: 0x0400010C RID: 268
				public string e;

				// Token: 0x0400010D RID: 269
				public BW2_one.i f;
			}
		}
	}
}
