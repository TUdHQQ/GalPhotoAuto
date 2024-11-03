using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x0200008D RID: 141
	public class BW2_two
	{
		// Token: 0x0600018E RID: 398 RVA: 0x00021CA4 File Offset: 0x0001FEA4
		public static bool RioShiina_ZeaS_mode1(ref Form1 myForm1, bool bNegativeX = false, bool bNegativeY = false)
		{
			BW2_two.b b = new BW2_two.b(b);
			b.d = bNegativeX;
			b.e = bNegativeY;
			b.g = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				b.f = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				string[] array2 = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(array2, 0);
				b.i = string.Empty;
				b.b = 0;
				b.c = 0;
				ParallelOptions parallelOptions = x.a();
				b.a = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_two.b.a a = new BW2_two.b.a(a);
					string text = array3[i];
					a.e = b;
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
					string[] array4 = BW2_two.b(text);
					if (array4 != null)
					{
						b.h = array4[0];
						b.i = array4[1];
						b.b = Conversions.ToInteger(array4[2]);
						b.c = Conversions.ToInteger(array4[3]);
						if (!(0 == b.b & 0 == b.c))
						{
							a.d = new MemoryStream();
							using (Bitmap bitmap = x.a(text))
							{
								a.b = bitmap.Width;
								a.a = bitmap.Height;
								a.c = bitmap.PixelFormat;
								bitmap.Save(a.d, ImageFormat.Png);
							}
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
					}
				}
				return b.g;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00021F30 File Offset: 0x00020130
		public static bool RioShiina_ZeaS_mode2(ref Form1 myForm1, int iMode)
		{
			bool result = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			int a_;
			switch (iMode)
			{
			case 203:
				a_ = 200;
				break;
			case 204:
				a_ = 500;
				break;
			default:
				return false;
			}
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string a_2 in array)
			{
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
				}
				if (!x.b(ref x.f, a_2))
				{
					if (BW2_two.a(ref myForm1, a_2, a_))
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00022014 File Offset: 0x00020214
		private static bool a(ref Form1 A_0, string A_1, int A_2)
		{
			BW2_two.a a = new BW2_two.a();
			a.a = A_2;
			bool result = false;
			string[] array = BW2_two.b(A_1);
			if (array == null)
			{
				return false;
			}
			a.c = array[0];
			string text = array[1];
			int num = Conversions.ToInteger(array[2]);
			int num2 = Conversions.ToInteger(array[3]);
			if (0 == num & 0 == num2)
			{
				return false;
			}
			a.b = new ArrayList(100);
			a.d = new ArrayList(100);
			string[] array2 = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array2, 0);
			Parallel.ForEach<string>(array2, new Action<string>(a.e));
			if (0 >= a.d.Count)
			{
				return false;
			}
			if (BW2_two.a(ref A_0, a.b, a.d, a.a, true))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x000220F0 File Offset: 0x000202F0
		private static bool a(ref Form1 A_0, ArrayList A_1, ArrayList A_2, int A_3, bool A_4 = true)
		{
			BW2_two.c c = new BW2_two.c(c);
			c.c = A_3;
			c.a = A_4;
			c.b = false;
			if (0 >= A_1.Count | 0 >= A_2.Count)
			{
				return false;
			}
			checked
			{
				if (0 < A_1.Count & 0 < A_2.Count)
				{
					BW2_two.c.a a = new BW2_two.c.a(a);
					string[] array = new string[A_1.Count - 1 + 1];
					A_1.CopyTo(array, 0);
					string[] array2 = new string[A_2.Count - 1 + 1];
					A_2.CopyTo(array2, 0);
					a.b = 0;
					a.c = 0;
					a.d = 0;
					a.e = new ArrayList(100);
					a.h = new ArrayList(100);
					ParallelOptions parallelOptions = x.a();
					a.a = A_0.BackgroundWorker2;
					string[] array3 = array;
					for (int i = 0; i < array3.Length; i++)
					{
						BW2_two.c.a.a a2 = new BW2_two.c.a.a(a2);
						string a_ = array3[i];
						a2.f = a;
						a2.e = c;
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
						string[] array4 = BW2_two.b(a_);
						if (array4 != null)
						{
							a.f = array4[0];
							a.g = array4[1];
							a.b = Conversions.ToInteger(array4[2]);
							a.c = Conversions.ToInteger(array4[3]);
							a.d = (BW2_two.a(a.g) / 100 + 1) * 100 + 99;
							a2.d = new MemoryStream();
							using (Bitmap bitmap = x.a(a_))
							{
								a2.b = bitmap.Width;
								a2.a = bitmap.Height;
								a2.c = bitmap.PixelFormat;
								bitmap.Save(a2.d, ImageFormat.Png);
							}
							Parallel.ForEach<string>(array2, parallelOptions, new Action<string, ParallelLoopState>(a2.g));
							a2.d.Dispose();
						}
					}
					if (c.b)
					{
						return true;
					}
					if (BW2_two.a(ref A_0, a.e, a.h, c.c, false))
					{
						c.b = true;
					}
				}
				return c.b;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0002236C File Offset: 0x0002056C
		private static string[] b(string A_0)
		{
			string text = Path.GetFileNameWithoutExtension(A_0);
			string[] array;
			if (Strings.InStr(1, text, ".", CompareMethod.Binary) > 0)
			{
				array = x.al.Split(text);
				text = array[0];
			}
			array = x.aj.Split(text);
			if (array.Length != 2)
			{
				return null;
			}
			string text2 = array[0];
			string input = array[1];
			array = x.am.Split(input);
			string text3 = array[0];
			input = array[1];
			array = x.ak.Split(input);
			int value = Conversions.ToInteger(array[1]);
			int value2 = Conversions.ToInteger(array[2]);
			return new string[]
			{
				text2,
				text3,
				Conversions.ToString(value),
				Conversions.ToString(value2)
			};
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00022430 File Offset: 0x00020630
		private static int a(string A_0)
		{
			string[] array = x.ak.Split(A_0);
			string value = array[checked(array.Length - 2)];
			return Conversions.ToInteger(value);
		}

		// Token: 0x0200008E RID: 142
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x06000194 RID: 404 RVA: 0x00022458 File Offset: 0x00020658
			public b(BW2_two.b A_0)
			{
				if (A_0 != null)
				{
					this.b = A_0.b;
					this.h = A_0.h;
					this.i = A_0.i;
					this.c = A_0.c;
					this.g = A_0.g;
					this.f = A_0.f;
					this.d = A_0.d;
					this.a = A_0.a;
					this.e = A_0.e;
				}
			}

			// Token: 0x04000238 RID: 568
			public BackgroundWorker a;

			// Token: 0x04000239 RID: 569
			public int b;

			// Token: 0x0400023A RID: 570
			public int c;

			// Token: 0x0400023B RID: 571
			public bool d;

			// Token: 0x0400023C RID: 572
			public bool e;

			// Token: 0x0400023D RID: 573
			public bool f;

			// Token: 0x0400023E RID: 574
			public bool g;

			// Token: 0x0400023F RID: 575
			public string h;

			// Token: 0x04000240 RID: 576
			public string i;

			// Token: 0x0200008F RID: 143
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000195 RID: 405 RVA: 0x000224DA File Offset: 0x000206DA
				public a(BW2_two.b.a A_0)
				{
					if (A_0 != null)
					{
						this.c = A_0.c;
						this.b = A_0.b;
						this.a = A_0.a;
						this.d = A_0.d;
					}
				}

				// Token: 0x06000196 RID: 406 RVA: 0x00022518 File Offset: 0x00020718
				[CompilerGenerated]
				public void f(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
					if (this.e.a.CancellationPending)
					{
						this.e.g = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.e.a.CancellationPending)
						{
							this.e.g = true;
							A_1.Stop();
						}
					}
					string text = string.Empty;
					string[] array = BW2_two.b(A_0);
					checked
					{
						if (array != null)
						{
							text = array[1];
							int num = Conversions.ToInteger(array[2]);
							int num2 = Conversions.ToInteger(array[3]);
							Bitmap bitmap = x.a(A_0);
							int num3 = Math.Abs(this.e.b - num);
							int num4 = Math.Abs(this.e.c - num2);
							int width = this.b;
							int height = this.a;
							int x = num3;
							int y = num4;
							if (this.e.d)
							{
								width = this.b + num3;
								x = 0;
							}
							if (this.e.e)
							{
								if (bitmap.Width + num3 > this.b)
								{
									width = bitmap.Width + num3;
								}
								height = this.a + num4;
								y = 0;
							}
							Bitmap bitmap2 = new Bitmap(width, height, this.c);
							Graphics graphics = Graphics.FromImage(bitmap2);
							graphics.Clear(Color.Transparent);
							MemoryStream obj = this.d;
							lock (obj)
							{
								if (this.e.e)
								{
									graphics.DrawImage(Image.FromStream(this.d), 0, num4, this.b, this.a);
								}
								else if (this.e.d)
								{
									graphics.DrawImage(Image.FromStream(this.d), num3, 0, this.b, this.a);
								}
								else
								{
									graphics.DrawImage(Image.FromStream(this.d), 0, 0, this.b, this.a);
								}
							}
							graphics.DrawImage(bitmap, x, y, bitmap.Width, bitmap.Height);
							graphics.Dispose();
							string directoryName = Path.GetDirectoryName(A_0);
							string text2 = string.Concat(new string[]
							{
								Path.Combine(directoryName, this.e.h),
								"@",
								this.e.i,
								text,
								"pos_"
							});
							if (this.e.d)
							{
								text2 += Conversions.ToString(this.e.b - num3);
							}
							else
							{
								text2 += Conversions.ToString(this.e.b);
							}
							text2 += "_";
							if (this.e.e)
							{
								text2 += Conversions.ToString(this.e.c - num4);
							}
							else
							{
								text2 += Conversions.ToString(this.e.c);
							}
							x.a(text2, ref bitmap2, true);
							Interlocked.Add(ref x.k, 1);
							bitmap2.Dispose();
							bitmap.Dispose();
							if (this.e.f)
							{
								ArrayList f = x.f;
								lock (f)
								{
									x.f.Add(A_0);
								}
							}
							this.e.a.ReportProgress(x.i);
						}
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x04000241 RID: 577
				public int a;

				// Token: 0x04000242 RID: 578
				public int b;

				// Token: 0x04000243 RID: 579
				public PixelFormat c;

				// Token: 0x04000244 RID: 580
				public MemoryStream d;

				// Token: 0x04000245 RID: 581
				public BW2_two.b e;
			}
		}

		// Token: 0x02000090 RID: 144
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x06000198 RID: 408 RVA: 0x000228CC File Offset: 0x00020ACC
			[CompilerGenerated]
			public void e(string A_0)
			{
				string[] array = BW2_two.b(A_0);
				string text = array[0];
				if (Operators.CompareString(this.c, text, false) == 0)
				{
					text = array[1];
					int num = BW2_two.a(text);
					if (num < 100)
					{
						ArrayList obj = this.b;
						lock (obj)
						{
							this.b.Add(A_0);
							goto IL_8B;
						}
					}
					ArrayList obj2 = this.d;
					lock (obj2)
					{
						this.d.Add(A_0);
					}
					IL_8B:
					if (num < this.a)
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(A_0);
						}
					}
				}
			}

			// Token: 0x04000246 RID: 582
			public int a;

			// Token: 0x04000247 RID: 583
			public ArrayList b;

			// Token: 0x04000248 RID: 584
			public string c;

			// Token: 0x04000249 RID: 585
			public ArrayList d;
		}

		// Token: 0x02000091 RID: 145
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x06000199 RID: 409 RVA: 0x000229C4 File Offset: 0x00020BC4
			public c(BW2_two.c A_0)
			{
				if (A_0 != null)
				{
					this.b = A_0.b;
					this.c = A_0.c;
					this.a = A_0.a;
				}
			}

			// Token: 0x0400024A RID: 586
			public bool a;

			// Token: 0x0400024B RID: 587
			public bool b;

			// Token: 0x0400024C RID: 588
			public int c;

			// Token: 0x02000092 RID: 146
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600019A RID: 410 RVA: 0x000229F4 File Offset: 0x00020BF4
				public a(BW2_two.c.a A_0)
				{
					if (A_0 != null)
					{
						this.h = A_0.h;
						this.a = A_0.a;
						this.f = A_0.f;
						this.g = A_0.g;
						this.b = A_0.b;
						this.c = A_0.c;
						this.d = A_0.d;
						this.e = A_0.e;
					}
				}

				// Token: 0x0400024D RID: 589
				public BackgroundWorker a;

				// Token: 0x0400024E RID: 590
				public int b;

				// Token: 0x0400024F RID: 591
				public int c;

				// Token: 0x04000250 RID: 592
				public int d;

				// Token: 0x04000251 RID: 593
				public ArrayList e;

				// Token: 0x04000252 RID: 594
				public string f;

				// Token: 0x04000253 RID: 595
				public string g;

				// Token: 0x04000254 RID: 596
				public ArrayList h;

				// Token: 0x02000093 RID: 147
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600019B RID: 411 RVA: 0x00022A6A File Offset: 0x00020C6A
					public a(BW2_two.c.a.a A_0)
					{
						if (A_0 != null)
						{
							this.d = A_0.d;
							this.b = A_0.b;
							this.a = A_0.a;
							this.c = A_0.c;
						}
					}

					// Token: 0x0600019C RID: 412 RVA: 0x00022AA8 File Offset: 0x00020CA8
					[CompilerGenerated]
					public void g(string A_0, ParallelLoopState A_1)
					{
						BW2_two.c.a.a.a a = new BW2_two.c.a.a.a(a);
						a.b = this;
						a.a = A_0;
						Interlocked.Add(ref x.i, 1);
						if (a.b.f.a.CancellationPending)
						{
							a.b.e.b = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (a.b.f.a.CancellationPending)
							{
								a.b.e.b = true;
								A_1.Stop();
							}
						}
						string text = string.Empty;
						string[] array = BW2_two.b(a.a);
						checked
						{
							if (array != null)
							{
								text = array[1];
								int num = Conversions.ToInteger(array[2]);
								int num2 = Conversions.ToInteger(array[3]);
								int num3 = BW2_two.a(text) / 100 * 100;
								if (num3 < a.b.e.c)
								{
									if (a.b.e.a && (num3 >= a.b.f.d & num3 < a.b.e.c))
									{
										ArrayList h = a.b.f.h;
										bool flag = false;
										try
										{
											BW2_two.c.a.a.a.a a2 = new BW2_two.c.a.a.a.a(a2);
											a2.c = this;
											a2.b = a;
											Monitor.Enter(h, ref flag);
											a2.a = false;
											string[] array2 = new string[a2.c.f.h.Count - 1 + 1];
											a2.c.f.h.CopyTo(array2, 0);
											Parallel.ForEach<string>(array2, new Action<string, ParallelLoopState>(a2.d));
											if (!a2.a)
											{
												a2.c.f.h.Add(a.a);
											}
											goto IL_474;
										}
										finally
										{
											if (flag)
											{
												Monitor.Exit(h);
											}
										}
									}
									string directoryName = Path.GetDirectoryName(a.a);
									string text2 = string.Concat(new string[]
									{
										Path.Combine(directoryName, a.b.f.f),
										"@",
										a.b.f.g,
										text,
										"pos_",
										Conversions.ToString(a.b.f.b),
										"_",
										Conversions.ToString(a.b.f.c)
									});
									string text3;
									if (1 == x.u)
									{
										text3 = text2 + ".bmp";
									}
									else if (2 == x.u)
									{
										text3 = text2 + ".jpg";
									}
									else
									{
										text3 = text2 + ".png";
									}
									if (!File.Exists(text3))
									{
										Bitmap bitmap = x.a(a.a);
										int x = Math.Abs(a.b.f.b - num);
										int y = Math.Abs(a.b.f.c - num2);
										Bitmap bitmap2 = new Bitmap(this.b, this.a, this.c);
										Graphics graphics = Graphics.FromImage(bitmap2);
										graphics.Clear(Color.Transparent);
										MemoryStream obj = this.d;
										lock (obj)
										{
											graphics.DrawImage(Image.FromStream(this.d), 0, 0, this.b, this.a);
										}
										graphics.DrawImage(bitmap, x, y, bitmap.Width, bitmap.Height);
										graphics.Dispose();
										x.a(text2, ref bitmap2, true);
										Interlocked.Add(ref x.k, 1);
										ArrayList obj2 = a.b.f.e;
										lock (obj2)
										{
											a.b.f.e.Add(text3);
										}
										bitmap2.Dispose();
										bitmap.Dispose();
										ArrayList obj3 = x.f;
										lock (obj3)
										{
											x.f.Add(a.a);
										}
										a.b.f.a.ReportProgress(x.i);
									}
								}
							}
							IL_474:
							Thread.Sleep(x.c);
						}
					}

					// Token: 0x04000255 RID: 597
					public int a;

					// Token: 0x04000256 RID: 598
					public int b;

					// Token: 0x04000257 RID: 599
					public PixelFormat c;

					// Token: 0x04000258 RID: 600
					public MemoryStream d;

					// Token: 0x04000259 RID: 601
					public BW2_two.c e;

					// Token: 0x0400025A RID: 602
					public BW2_two.c.a f;

					// Token: 0x02000094 RID: 148
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x0600019D RID: 413 RVA: 0x00022F68 File Offset: 0x00021168
						public a(BW2_two.c.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.b = A_0.b;
								this.a = A_0.a;
							}
						}

						// Token: 0x0400025B RID: 603
						public string a;

						// Token: 0x0400025C RID: 604
						public BW2_two.c.a.a b;

						// Token: 0x02000095 RID: 149
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x0600019E RID: 414 RVA: 0x00022F8B File Offset: 0x0002118B
							public a(BW2_two.c.a.a.a.a A_0)
							{
								if (A_0 != null)
								{
									this.c = A_0.c;
									this.a = A_0.a;
								}
							}

							// Token: 0x0600019F RID: 415 RVA: 0x00022FAE File Offset: 0x000211AE
							[CompilerGenerated]
							public void d(string A_0, ParallelLoopState A_1)
							{
								if (0 == string.Compare(this.b.a, A_0, StringComparison.Ordinal))
								{
									this.a = true;
									A_1.Stop();
								}
							}

							// Token: 0x0400025D RID: 605
							public bool a;

							// Token: 0x0400025E RID: 606
							public BW2_two.c.a.a.a b;

							// Token: 0x0400025F RID: 607
							public BW2_two.c.a.a c;
						}
					}
				}
			}
		}
	}
}
