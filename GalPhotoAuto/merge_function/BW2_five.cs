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
	// Token: 0x02000045 RID: 69
	public class BW2_five
	{
		// Token: 0x060000AE RID: 174 RVA: 0x0000EC70 File Offset: 0x0000CE70
		public static bool crass_PJADV(ref Form1 myForm1)
		{
			BW2_five.b b = new BW2_five.b();
			b.c = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			bool flag = false;
			if (0 == string.Compare(x.aa, "ikedukuri", StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
			}
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			b.a = myForm1.BackgroundWorker2;
			string[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				string text = array2[i];
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
				b.b = Path.GetDirectoryName(text);
				ArrayList arrayList = new ArrayList();
				using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					fileStream.Seek(0L, SeekOrigin.Begin);
					string strA = new string(binaryReader.ReadChars(12));
					if (0 != string.Compare(strA, "PJGraphicDef", StringComparison.Ordinal))
					{
						goto IL_336;
					}
					int num = 72;
					fileStream.Seek((long)num, SeekOrigin.Current);
					int num2 = 384;
					int num3 = 2896;
					int num4 = 8;
					if (flag)
					{
						num2 = 2305;
						num4 = 11;
						num3 = 3328;
					}
					while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
					{
						string[] array3 = new string[7];
						string text2 = new string(binaryReader.ReadChars(32));
						string text3 = text2.Replace("\0", "");
						array3[0] = text3;
						text2 = new string(binaryReader.ReadChars(32));
						text3 = text2.Replace("\0", "");
						array3[1] = text3;
						fileStream.Seek((long)num2, SeekOrigin.Current);
						text2 = new string(binaryReader.ReadChars(32));
						text3 = text2.Replace("\0", "");
						array3[2] = text3;
						fileStream.Seek((long)num4, SeekOrigin.Current);
						int value = binaryReader.ReadInt32();
						array3[3] = Conversions.ToString(value);
						value = binaryReader.ReadInt32();
						array3[4] = Conversions.ToString(value);
						value = binaryReader.ReadInt32();
						array3[5] = Conversions.ToString(value);
						value = binaryReader.ReadInt32();
						array3[6] = Conversions.ToString(value);
						if (0.0 == Conversions.ToDouble(array3[3]) & 0.0 == Conversions.ToDouble(array3[4]) & 0.0 == Conversions.ToDouble(array3[5]) & 0.0 == Conversions.ToDouble(array3[6]))
						{
							break;
						}
						arrayList.Add(array3);
						fileStream.Seek((long)num3, SeekOrigin.Current);
					}
					binaryReader.Dispose();
				}
				goto IL_2E6;
				IL_336:
				checked
				{
					i++;
					continue;
					IL_2E6:
					x.c(Conversions.ToString(arrayList.Count));
					if (0 < arrayList.Count)
					{
						x.j = arrayList.Count;
						Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(b.d));
						x.f.Add(text);
						goto IL_336;
					}
					goto IL_336;
				}
			}
			x.z = string.Empty;
			return b.c;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000EFF0 File Offset: 0x0000D1F0
		public static bool crass_NScripter(ref Form1 myForm1)
		{
			BW2_five.d d = new BW2_five.d();
			d.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				d.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_five.d.a a = new BW2_five.d.a(a);
					string path = array2[i];
					a.d = d;
					Interlocked.Add(ref x.i, 1);
					if (d.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (d.a.CancellationPending)
						{
							return true;
						}
					}
					if (0 == string.Compare(Path.GetFileName(path), "nscript.txt", StringComparison.Ordinal))
					{
						string directoryName = Path.GetDirectoryName(path);
						a.c = 0;
						a.a = 0;
						ArrayList arrayList = new ArrayList();
						a.b = new ArrayList();
						using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, x.o))
							{
								while (!streamReader.EndOfStream)
								{
									string text = streamReader.ReadLine();
									if (0 == a.c)
									{
										string[] array3 = x.ap.Split(text);
										if (0 == string.Compare(array3[0], "setwindow", StringComparison.Ordinal))
										{
											string[] array4 = array3[1].Split(new char[]
											{
												','
											});
											a.a = Conversions.ToInteger(array4.Last<string>());
											a.c = Conversions.ToInteger(array4[array4.Count<string>() - 2]);
										}
									}
									if (Strings.InStr(1, text, ";", CompareMethod.Binary) > 0 & Strings.InStr(1, text, ".bmp", CompareMethod.Binary) > 0)
									{
										string value = text.Split(new char[]
										{
											';'
										}).Last<string>();
										arrayList.Add(value);
									}
								}
							}
						}
						if (0 != a.c)
						{
							try
							{
								IEnumerator enumerator = arrayList.GetEnumerator();
								while (enumerator.MoveNext())
								{
									BW2_five.d.a.a a2 = new BW2_five.d.a.a(a2);
									string text2 = Conversions.ToString(enumerator.Current);
									a2.c = a;
									a2.a = text2.Split(new char[]
									{
										','
									});
									a2.b = a2.a[0].Split(new char[]
									{
										'/'
									});
									if (3 <= a2.b.Count<string>())
									{
										if (Strings.InStr(1, a2.a[0], "$", CompareMethod.Binary) > 0)
										{
											a2.b = a2.a[0].Replace("/", "\\").Split(new char[]
											{
												'"'
											});
											string path2 = Path.Combine(directoryName, Path.GetDirectoryName(a2.b[0]));
											if (Directory.Exists(path2))
											{
												string[] files = Directory.GetFiles(path2);
												Parallel.ForEach<string>(files, parallelOptions, new Action<string>(a2.d));
											}
										}
										else
										{
											string[] value2 = new string[]
											{
												Path.Combine(directoryName, a2.a[0].Replace("\"", string.Empty)).Replace("/", "\\"),
												a2.a[1],
												a2.a[2]
											};
											a.b.Add(value2);
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
							Parallel.ForEach<object>(a.b.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a.e));
						}
					}
				}
				x.z = string.Empty;
				return d.b;
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000F444 File Offset: 0x0000D644
		public static bool crass_PJADV_anm(ref Form1 myForm1)
		{
			BW2_five.a a = new BW2_five.a();
			a.b = false;
			x.h = x.e.Count;
			checked
			{
				x.j = x.h * 3;
				x.i = 0;
				x.k = 0;
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				a.a = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(a.c));
				x.aa = string.Empty;
				x.z = string.Empty;
				return a.b;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		public static bool crass_DDSystem_tga(ref Form1 myForm1)
		{
			BW2_five.c c = new BW2_five.c();
			c.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			c.a = myForm1.BackgroundWorker2;
			c.c = new ArrayList(10);
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(c.d));
			Parallel.ForEach<object>(c.c.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(c.d));
			x.aa = string.Empty;
			x.z = string.Empty;
			return c.b;
		}

		// Token: 0x02000046 RID: 70
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x060000B3 RID: 179 RVA: 0x0000F5B4 File Offset: 0x0000D7B4
			[CompilerGenerated]
			[DebuggerStepThrough]
			public void d(object A_0, ParallelLoopState A_1)
			{
				new g<string[], ParallelLoopState>(this.d)((string[])A_0, A_1);
			}

			// Token: 0x060000B4 RID: 180 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
			[CompilerGenerated]
			public void d(string[] A_0, ParallelLoopState A_1)
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
				string text = Path.Combine(this.b, Path.ChangeExtension(A_0[1], "png"));
				if (File.Exists(text))
				{
					string text2 = Path.Combine(this.b, Path.ChangeExtension(A_0[2], "png"));
					if (File.Exists(text2))
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text2);
						}
						Bitmap bitmap2;
						Graphics graphics;
						using (Bitmap bitmap = x.a(text))
						{
							bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
							graphics = Graphics.FromImage(bitmap2);
							graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
						}
						using (Bitmap bitmap3 = x.a(text2))
						{
							graphics.DrawImage(bitmap3, Conversions.ToInteger(A_0[3]), Conversions.ToInteger(A_0[4]), Conversions.ToInteger(A_0[5]), Conversions.ToInteger(A_0[6]));
						}
						graphics.Dispose();
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0[1]);
						string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(A_0[2]);
						string a_ = Path.Combine(this.b, fileNameWithoutExtension + "_" + fileNameWithoutExtension2);
						x.a(a_, ref bitmap2, true);
						Interlocked.Add(ref x.k, 1);
						bitmap2.Dispose();
					}
				}
				this.a.ReportProgress(x.i);
				Thread.Sleep(x.c);
			}

			// Token: 0x0400010E RID: 270
			public BackgroundWorker a;

			// Token: 0x0400010F RID: 271
			public string b;

			// Token: 0x04000110 RID: 272
			public bool c;
		}

		// Token: 0x02000047 RID: 71
		[CompilerGenerated]
		internal class d
		{
			// Token: 0x04000111 RID: 273
			public BackgroundWorker a;

			// Token: 0x04000112 RID: 274
			public bool b;

			// Token: 0x02000048 RID: 72
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x060000B6 RID: 182 RVA: 0x0000F7D4 File Offset: 0x0000D9D4
				public a(BW2_five.d.a A_0)
				{
					if (A_0 != null)
					{
						this.c = A_0.c;
						this.a = A_0.a;
						this.b = A_0.b;
					}
				}

				// Token: 0x060000B7 RID: 183 RVA: 0x0000F803 File Offset: 0x0000DA03
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void e(object A_0, ParallelLoopState A_1)
				{
					new v<string[], ParallelLoopState>(this.e)((string[])A_0, A_1);
				}

				// Token: 0x060000B8 RID: 184 RVA: 0x0000F820 File Offset: 0x0000DA20
				[CompilerGenerated]
				public void e(string[] A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.d.a.CancellationPending)
					{
						this.d.b = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.d.a.CancellationPending)
						{
							this.d.b = true;
							A_1.Stop();
						}
					}
					checked
					{
						if (File.Exists(A_0[0]))
						{
							Bitmap bitmap = new Bitmap(this.c, this.a, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							Bitmap bitmap2 = x.a(A_0[0]);
							int width = bitmap2.Width;
							int height = bitmap2.Height;
							if (this.c == width & this.a == height)
							{
								return;
							}
							Color pixel = bitmap2.GetPixel(0, 0);
							int x = Conversions.ToInteger(A_0[1]);
							int y = Conversions.ToInteger(A_0[2]);
							if (width > this.c & (pixel.R == 255 & pixel.G == 255 & pixel.B == 255))
							{
								graphics.Clear(Color.White);
								int num = width / 2;
								Rectangle rect = new Rectangle(num, 0, num, height);
								BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
								Bitmap bitmap3 = new Bitmap(num, height, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
								bitmap2.UnlockBits(bitmapData);
								graphics.DrawImage(bitmap3, x, y, num, height);
								bitmap3.Dispose();
							}
							else
							{
								int num2 = width / 2;
								Rectangle rect2 = new Rectangle(num2, 0, num2, height);
								BitmapData bitmapData2 = bitmap2.LockBits(rect2, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
								Bitmap bitmap4 = new Bitmap(num2, height, bitmapData2.Stride, bitmap2.PixelFormat, bitmapData2.Scan0);
								bitmap2.UnlockBits(bitmapData2);
								int num3 = 0;
								int num4 = 0;
								int num5 = 0;
								int num6 = 0;
								int num7 = num2 - 1;
								for (int i = num6; i <= num7; i++)
								{
									int num8 = 0;
									int num9 = height - 1;
									for (int j = num8; j <= num9; j++)
									{
										Color pixel2 = bitmap4.GetPixel(i, j);
										if (pixel2.R == 255 & pixel2.G == 255 & pixel2.B == 255)
										{
											num3++;
										}
										else if (pixel2.R == 0 & pixel2.G == 0 & pixel2.B == 0)
										{
											num4++;
										}
										else
										{
											num5++;
										}
									}
								}
								if (0 == num5 | num5 < num3 + num4)
								{
									Bitmap bitmap5 = new Bitmap(num2, height, PixelFormat.Format32bppArgb);
									int num10 = 0;
									int num11 = num2 - 1;
									for (int k = num10; k <= num11; k++)
									{
										int num12 = 0;
										int num13 = height - 1;
										for (int l = num12; l <= num13; l++)
										{
											Color pixel2 = bitmap2.GetPixel(k, l);
											Color pixel3 = bitmap4.GetPixel(k, l);
											int alpha = 255 - x.c(ref pixel3);
											bitmap5.SetPixel(k, l, Color.FromArgb(alpha, pixel2));
										}
									}
									graphics.DrawImage(bitmap5, x, y, num2, height);
									bitmap5.Dispose();
								}
								else
								{
									graphics.DrawImage(bitmap2, x, y, width, height);
								}
								bitmap4.Dispose();
							}
							bitmap2.Dispose();
							graphics.Dispose();
							x.a(A_0[0], ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref x.k, 1);
							ArrayList f = x.f;
							lock (f)
							{
								x.f.Add(A_0[0]);
							}
							this.d.a.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}
				}

				// Token: 0x04000113 RID: 275
				public int a;

				// Token: 0x04000114 RID: 276
				public ArrayList b;

				// Token: 0x04000115 RID: 277
				public int c;

				// Token: 0x04000116 RID: 278
				public BW2_five.d d;

				// Token: 0x02000049 RID: 73
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x060000B9 RID: 185 RVA: 0x0000FC0C File Offset: 0x0000DE0C
					public a(BW2_five.d.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.a = A_0.a;
						}
					}

					// Token: 0x060000BA RID: 186 RVA: 0x0000FC30 File Offset: 0x0000DE30
					[CompilerGenerated]
					public void d(string A_0)
					{
						if (Strings.InStr(1, A_0, this.b[0], CompareMethod.Binary) > 0)
						{
							string[] value = new string[]
							{
								A_0,
								this.a[1],
								this.a[2]
							};
							ArrayList obj = this.c.b;
							lock (obj)
							{
								this.c.b.Add(value);
							}
						}
					}

					// Token: 0x04000117 RID: 279
					public string[] a;

					// Token: 0x04000118 RID: 280
					public string[] b;

					// Token: 0x04000119 RID: 281
					public BW2_five.d.a c;
				}
			}
		}

		// Token: 0x0200004A RID: 74
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x060000BC RID: 188 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
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
				string directoryName = Path.GetDirectoryName(A_0);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				string text = x.a(Path.Combine(directoryName, fileNameWithoutExtension), "");
				checked
				{
					if (File.Exists(text))
					{
						int num = 3;
						if (Strings.InStr(1, fileNameWithoutExtension, "Seye", CompareMethod.Binary) > 0)
						{
							num = 4;
						}
						string text2 = x.a(Path.Combine(directoryName, fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - num)), "");
						if (File.Exists(text2))
						{
							int num3;
							int num4;
							int num5;
							int num6;
							using (FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
							{
								using (BinaryReader binaryReader = new BinaryReader(fileStream))
								{
									long num2 = binaryReader.BaseStream.Length - 48L;
									if (32L > num2)
									{
										return;
									}
									fileStream.Seek(num2, SeekOrigin.Begin);
									num3 = binaryReader.ReadInt32();
									num4 = binaryReader.ReadInt32();
									num5 = binaryReader.ReadInt32();
									num6 = binaryReader.ReadInt32();
								}
							}
							if (0 == num5 & 0 == num6 & 0 == num3 & 0 == num4)
							{
								return;
							}
							Interlocked.Add(ref x.i, 2);
							x.f.Add(text2);
							x.f.Add(text);
							Bitmap bitmap = x.a(text2);
							Graphics graphics = Graphics.FromImage(bitmap);
							using (Bitmap bitmap2 = x.a(text))
							{
								int num7 = bitmap2.Height / num6;
								int num8 = 0;
								int num9 = num7 - 1;
								for (int i = num8; i <= num9; i++)
								{
									Rectangle rect = new Rectangle(0, i * num6, num5, num6);
									BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
									Bitmap bitmap3 = new Bitmap(num5, num6, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
									bitmap2.UnlockBits(bitmapData);
									graphics.DrawImage(bitmap3, num3, num4, num5, num6);
									bitmap3.Dispose();
									string text3 = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(text2));
									if (4 == num)
									{
										text3 = text3 + "S_" + i.ToString("D3");
									}
									else
									{
										text3 = text3 + "_" + i.ToString("D3");
									}
									x.a(text3, ref bitmap, true);
									Interlocked.Add(ref x.k, 1);
									this.a.ReportProgress(x.i);
									Thread.Sleep(x.c);
								}
							}
							bitmap.Dispose();
							x.f.Add(A_0);
						}
					}
				}
			}

			// Token: 0x0400011A RID: 282
			public BackgroundWorker a;

			// Token: 0x0400011B RID: 283
			public bool b;
		}

		// Token: 0x0200004B RID: 75
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x060000BE RID: 190 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
			[CompilerGenerated]
			public void d(string A_0, ParallelLoopState A_1)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				if (Versioned.IsNumeric(fileNameWithoutExtension) && Conversions.ToInteger(fileNameWithoutExtension) == 0)
				{
					ArrayList obj = this.c;
					lock (obj)
					{
						this.c.Add(A_0);
					}
				}
			}

			// Token: 0x060000BF RID: 191 RVA: 0x00010040 File Offset: 0x0000E240
			[DebuggerStepThrough]
			[CompilerGenerated]
			public void d(object A_0, ParallelLoopState A_1)
			{
				new j<string, ParallelLoopState>(this.e)(Conversions.ToString(A_0), A_1);
			}

			// Token: 0x060000C0 RID: 192 RVA: 0x0001005C File Offset: 0x0000E25C
			[CompilerGenerated]
			public void e(string A_0, ParallelLoopState A_1)
			{
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
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				string directoryName = Path.GetDirectoryName(A_0);
				int length = fileNameWithoutExtension.Length;
				Bitmap bitmap = x.a(A_0);
				if (x.b(A_0))
				{
					x.a(Path.Combine(directoryName, fileNameWithoutExtension), ref bitmap, true);
					Interlocked.Add(ref x.k, 1);
					Interlocked.Add(ref x.i, 1);
					ArrayList f = x.f;
					lock (f)
					{
						x.f.Add(A_0);
					}
				}
				Graphics graphics = Graphics.FromImage(bitmap);
				int num = 0;
				checked
				{
					for (;;)
					{
						num++;
						string text = x.a(Path.Combine(directoryName, num.ToString("D6")), "");
						if (string.IsNullOrEmpty(text))
						{
							break;
						}
						using (Bitmap bitmap2 = x.a(text))
						{
							graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
						}
						string a_ = Path.Combine(directoryName, fileNameWithoutExtension + "_" + num.ToString("D6"));
						x.a(a_, ref bitmap, true);
						ArrayList f2 = x.f;
						lock (f2)
						{
							x.f.Add(text);
						}
						Interlocked.Add(ref x.k, 1);
						Interlocked.Add(ref x.i, 1);
						this.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
					graphics.Dispose();
					bitmap.Dispose();
				}
			}

			// Token: 0x0400011C RID: 284
			public BackgroundWorker a;

			// Token: 0x0400011D RID: 285
			public bool b;

			// Token: 0x0400011E RID: 286
			public ArrayList c;
		}
	}
}
