using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x0200004C RID: 76
	public class BW2_three
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x0001025C File Offset: 0x0000E45C
		public BW2_three()
		{
			this.a = new ArrayList();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00010270 File Offset: 0x0000E470
		public static bool asd_png__a(ref Form1 myForm1)
		{
			BW2_three.n n = new BW2_three.n();
			n.b = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			n.c = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=\\%x[ ]+sy=0[ ]+sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
			n.f = new Regex("\\=[0-9]{0,3}", RegexOptions.IgnoreCase);
			n.e = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=[0-9]{0,3}[ ]+sy=\\%y sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
			n.d = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=[0-9]{0,3}[ ]+sy=0[ ]+sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
			ParallelOptions parallelOptions = global::x.a();
			n.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(n.g));
			global::x.z = string.Empty;
			return n.b;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00010348 File Offset: 0x0000E548
		public static bool asd__a__a_m(ref Form1 myForm1)
		{
			BW2_three.m m = new BW2_three.m(m);
			m.b = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			m.d = new Regex("\\[eval exp=\\042.*\\042\\]", RegexOptions.IgnoreCase);
			m.e = new Regex("\\042.*\\042", RegexOptions.IgnoreCase);
			ParallelOptions parallelOptions = global::x.a();
			m.a = myForm1.BackgroundWorker2;
			m.c = new Dictionary<string, string>();
			ArrayList arrayList = new ArrayList(10);
			if (0 < global::x.y.Count)
			{
				string z = global::x.z;
				global::x.z = "ks";
				try
				{
					foreach (object value in global::x.y)
					{
						string a_ = Conversions.ToString(value);
						global::x.b(a_, ref arrayList);
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
				global::x.z = z;
				if (0 < arrayList.Count)
				{
					try
					{
						foreach (object value2 in arrayList)
						{
							string path = Conversions.ToString(value2);
							using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
							{
								using (StreamReader streamReader = new StreamReader(fileStream, global::x.o))
								{
									while (!streamReader.EndOfStream)
									{
										string text = streamReader.ReadLine().Trim();
										if (!string.IsNullOrWhiteSpace(text))
										{
											if (Strings.InStr(1, text, "[eval exp=", CompareMethod.Binary) > 0)
											{
												string[] array2 = text.Split(new char[]
												{
													'"'
												});
												string input = array2[1];
												array2 = global::x.an.Split(input);
												if (Versioned.IsNumeric(array2.Last<string>().Trim()) && !m.c.ContainsKey(array2.First<string>().Trim()))
												{
													m.c.Add(array2.First<string>().Trim(), array2.Last<string>().Trim());
												}
											}
										}
									}
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
				}
			}
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(m.f));
			global::x.z = string.Empty;
			return m.b;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00010620 File Offset: 0x0000E820
		public static bool cgm_asd(ref Form1 myForm1)
		{
			bool result = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref global::x.i, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
				}
				string directoryName = Path.GetDirectoryName(text);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				ArrayList arrayList = kirikiri2_fun.readCgmToArr(text);
				if (0 < arrayList.Count)
				{
					Interlocked.Add(ref global::x.i, 1);
					global::x.f.Add(text);
					backgroundWorker.ReportProgress(global::x.i);
					try
					{
						foreach (object obj in arrayList)
						{
							kirikiri2_fun.CgmData cgmData2;
							kirikiri2_fun.CgmData cgmData = (obj != null) ? ((kirikiri2_fun.CgmData)obj) : cgmData2;
							string text2 = Path.Combine(directoryName, cgmData.baseName + "_");
							try
							{
								foreach (object obj2 in cgmData.faceList)
								{
									string[] array3 = (string[])obj2;
									string text3 = text2 + array3[0] + ".asd";
									if (File.Exists(text3))
									{
										Interlocked.Add(ref global::x.i, 1);
										int num = array3.Count<string>();
										if (2 == num)
										{
											if (BW2_three.b(text2, text3, array3, ref myForm1))
											{
												result = true;
											}
										}
										else if (3 == num)
										{
											if (BW2_three.a(text2, text3, array3, ref myForm1))
											{
												result = true;
											}
										}
										else if (3 < num)
										{
											global::x.c("数组多过3个，未支持: " + cgmData.baseName);
										}
									}
								}
							}
							finally
							{
								IEnumerator enumerator2;
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
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
				}
			}
			global::x.z = string.Empty;
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00010880 File Offset: 0x0000EA80
		private static bool b(string A_0, string A_1, string[] A_2, ref Form1 A_3)
		{
			BW2_three.o o = new BW2_three.o();
			o.e = A_0;
			o.b = A_2;
			o.c = false;
			o.d = global::x.a();
			o.a = A_3.BackgroundWorker2;
			ArrayList arrayList = kirikiri2_fun.readCgmAsdToArr(A_1, o.b[1]);
			checked
			{
				if (0 < arrayList.Count)
				{
					string text = global::x.a(Path.Combine(Path.GetDirectoryName(A_1), Path.GetFileNameWithoutExtension(A_1)), "");
					if (File.Exists(text))
					{
						BW2_three.o.a a = new BW2_three.o.a();
						a.a = new MemoryStream();
						a.c = 0;
						a.b = 0;
						using (Bitmap bitmap = global::x.a(text))
						{
							a.c = bitmap.Width;
							a.b = bitmap.Height;
							bitmap.Save(a.a, ImageFormat.Png);
						}
						int count = arrayList.Count;
						if (2 == count)
						{
							BW2_three.o.a.a a2 = new BW2_three.o.a.a();
							a2.d = a;
							a2.c = o;
							a2.a = new ArrayList();
							a2.b = new ArrayList();
							string value = string.Empty;
							try
							{
								foreach (object obj in arrayList)
								{
									kirikiri2_fun.asdData asdData2;
									kirikiri2_fun.asdData asdData = (obj != null) ? ((kirikiri2_fun.asdData)obj) : asdData2;
									string storage = asdData.storage;
									if (string.IsNullOrEmpty(storage))
									{
										if (!string.IsNullOrEmpty(asdData.forktarget) & !string.IsNullOrEmpty(asdData.forktarget_storage))
										{
											string text2 = global::x.a(o.e + asdData.forktarget_storage, "");
											if (File.Exists(text2))
											{
												global::x.f.Add(text2);
												Interlocked.Add(ref global::x.i, 1);
												Bitmap bitmap2 = global::x.a(text2);
												Bitmap bitmap3 = new Bitmap(a.c, a.b, PixelFormat.Format32bppArgb);
												Graphics graphics = Graphics.FromImage(bitmap3);
												graphics.Clear(Color.Transparent);
												graphics.DrawImage(bitmap3, asdData.forktarget_x, asdData.forktarget_y, bitmap3.Width, bitmap3.Height);
												graphics.Dispose();
												MemoryStream memoryStream = new MemoryStream();
												bitmap3.Save(memoryStream, ImageFormat.Png);
												bitmap3.Dispose();
												a2.a.Add(memoryStream);
												bitmap2.Dispose();
											}
										}
									}
									else
									{
										string text3 = global::x.a(o.e + storage, "");
										if (File.Exists(text3))
										{
											global::x.f.Add(text3);
											Interlocked.Add(ref global::x.i, 1);
											if (string.IsNullOrEmpty(value))
											{
												value = storage;
											}
											Bitmap bitmap4 = global::x.a(text3);
											int width = bitmap4.Width;
											int height = bitmap4.Height;
											int num = asdData.width;
											if (0 == num)
											{
												num = width;
											}
											int num2 = (int)Math.Round((double)width / (double)num);
											int num3 = asdData.height;
											if (num3 > height | 0 == num3)
											{
												num3 = height;
											}
											int num4 = 0;
											int num5 = num2 - 1;
											for (int i = num4; i <= num5; i++)
											{
												Bitmap bitmap5 = new Bitmap(a.c, a.b, PixelFormat.Format32bppArgb);
												Graphics graphics2 = Graphics.FromImage(bitmap5);
												graphics2.Clear(Color.Transparent);
												Rectangle rect = new Rectangle(i * num, asdData.top, num, num3);
												BitmapData bitmapData = bitmap4.LockBits(rect, ImageLockMode.ReadOnly, bitmap4.PixelFormat);
												Bitmap bitmap6 = new Bitmap(num, num3, bitmapData.Stride, bitmap4.PixelFormat, bitmapData.Scan0);
												bitmap4.UnlockBits(bitmapData);
												graphics2.DrawImage(bitmap6, asdData.x, asdData.y, bitmap6.Width, bitmap6.Height);
												bitmap6.Dispose();
												if (!string.IsNullOrEmpty(asdData.forktarget_storage))
												{
													string text4 = global::x.a(o.e + asdData.forktarget_storage, "");
													if (File.Exists(text4))
													{
														bitmap6 = global::x.a(text4);
														graphics2.DrawImage(bitmap6, asdData.forktarget_x, asdData.forktarget_y, bitmap6.Width, bitmap6.Height);
														bitmap6.Dispose();
														global::x.f.Add(text4);
													}
												}
												graphics2.Dispose();
												MemoryStream memoryStream2 = new MemoryStream();
												bitmap5.Save(memoryStream2, ImageFormat.Png);
												bitmap5.Dispose();
												if (Strings.InStr(1, storage, "口", CompareMethod.Binary) > 0)
												{
													a2.b.Add(memoryStream2);
												}
												else
												{
													a2.a.Add(memoryStream2);
												}
												o.a.ReportProgress(global::x.i);
											}
											bitmap4.Dispose();
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
							if (0 == a2.a.Count & 0 < a2.b.Count)
							{
								Parallel.For(0, a2.b.Count, o.d, new Action<int, ParallelLoopState>(a2.e));
							}
							else
							{
								Parallel.For(0, a2.a.Count, o.d, new Action<int, ParallelLoopState>(a2.f));
							}
							Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.x));
							a2.a.Clear();
							Parallel.ForEach<object>(a2.b.ToArray(), new Action<object>(BW2_three.w));
							a2.b.Clear();
						}
						a.a.Dispose();
					}
					global::x.f.Add(text);
					global::x.f.Add(A_1);
				}
				return o.c;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00010E88 File Offset: 0x0000F088
		private static void a(ref Form1 A_0, ref ArrayList A_1, ref ArrayList A_2, string A_3, string A_4, string A_5, ref int A_6, ref int A_7)
		{
			BackgroundWorker backgroundWorker = A_0.BackgroundWorker2;
			ArrayList arrayList = kirikiri2_fun.readCgmAsdToArr(A_3, A_4);
			checked
			{
				if (0 < arrayList.Count)
				{
					string text = Path.ChangeExtension(A_3, "png");
					if (File.Exists(text))
					{
						MemoryStream memoryStream = new MemoryStream();
						using (Bitmap bitmap = global::x.a(text))
						{
							A_6 = bitmap.Width;
							A_7 = bitmap.Height;
							bitmap.Save(memoryStream, ImageFormat.Png);
						}
						int count = arrayList.Count;
						if (2 == count)
						{
							string value = string.Empty;
							try
							{
								foreach (object obj in arrayList)
								{
									kirikiri2_fun.asdData asdData2;
									kirikiri2_fun.asdData asdData = (obj != null) ? ((kirikiri2_fun.asdData)obj) : asdData2;
									string storage = asdData.storage;
									if (string.IsNullOrEmpty(storage))
									{
										if (!string.IsNullOrEmpty(asdData.forktarget) & !string.IsNullOrEmpty(asdData.forktarget_storage))
										{
											string text2 = global::x.a(A_5 + asdData.forktarget_storage, "");
											if (File.Exists(text2))
											{
												global::x.f.Add(text2);
												Interlocked.Add(ref global::x.i, 1);
												Bitmap bitmap2 = global::x.a(text2);
												Bitmap bitmap3 = new Bitmap(A_6, A_7, PixelFormat.Format32bppArgb);
												Graphics graphics = Graphics.FromImage(bitmap3);
												graphics.Clear(Color.Transparent);
												graphics.DrawImage(bitmap3, asdData.forktarget_x, asdData.forktarget_y, bitmap3.Width, bitmap3.Height);
												graphics.Dispose();
												MemoryStream memoryStream2 = new MemoryStream();
												bitmap3.Save(memoryStream2, ImageFormat.Png);
												bitmap3.Dispose();
												A_1.Add(memoryStream2);
												bitmap2.Dispose();
											}
										}
									}
									else
									{
										string text3 = global::x.a(A_5 + storage, "");
										if (File.Exists(text3))
										{
											global::x.f.Add(text3);
											Interlocked.Add(ref global::x.i, 1);
											if (string.IsNullOrEmpty(value))
											{
												value = storage;
											}
											Bitmap bitmap4 = global::x.a(text3);
											int width = bitmap4.Width;
											int height = bitmap4.Height;
											int num = asdData.width;
											if (0 == num)
											{
												num = width;
											}
											int num2 = (int)Math.Round((double)width / (double)num);
											int num3 = asdData.height;
											if (num3 > height | 0 == num3)
											{
												num3 = height;
											}
											int num4 = 0;
											int num5 = num2 - 1;
											for (int i = num4; i <= num5; i++)
											{
												Bitmap bitmap5 = new Bitmap(A_6, A_7, PixelFormat.Format32bppArgb);
												Graphics graphics2 = Graphics.FromImage(bitmap5);
												graphics2.Clear(Color.Transparent);
												Rectangle rect = new Rectangle(i * num, asdData.top, num, num3);
												BitmapData bitmapData = bitmap4.LockBits(rect, ImageLockMode.ReadOnly, bitmap4.PixelFormat);
												Bitmap bitmap6 = new Bitmap(num, num3, bitmapData.Stride, bitmap4.PixelFormat, bitmapData.Scan0);
												bitmap4.UnlockBits(bitmapData);
												graphics2.DrawImage(bitmap6, asdData.x, asdData.y, bitmap6.Width, bitmap6.Height);
												bitmap6.Dispose();
												graphics2.Dispose();
												MemoryStream memoryStream3 = new MemoryStream();
												bitmap5.Save(memoryStream3, ImageFormat.Png);
												bitmap5.Dispose();
												if (Strings.InStr(1, storage, "口", CompareMethod.Binary) > 0)
												{
													A_2.Add(memoryStream3);
												}
												else
												{
													A_1.Add(memoryStream3);
												}
												backgroundWorker.ReportProgress(global::x.i);
											}
											bitmap4.Dispose();
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
						}
						memoryStream.Dispose();
					}
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00011268 File Offset: 0x0000F468
		private static void a(ref Form1 A_0, ref ArrayList A_1, ref ArrayList A_2, ref ArrayList A_3, ref int A_4, ref int A_5)
		{
			BackgroundWorker backgroundWorker = A_0.BackgroundWorker2;
			checked
			{
				if (0 == A_1.Count & 0 < A_2.Count)
				{
					int num = 0;
					int num2 = A_2.Count - 1;
					for (int i = num; i <= num2; i++)
					{
						Bitmap bitmap = new Bitmap(A_4, A_5, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap);
						Bitmap bitmap2 = (Bitmap)Image.FromStream((MemoryStream)A_2[i]);
						graphics.DrawImage(bitmap2, 0, 0, A_4, A_5);
						bitmap2.Dispose();
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Png);
						A_3.Add(memoryStream);
						bitmap.Dispose();
						backgroundWorker.ReportProgress(global::x.i);
					}
				}
				else
				{
					int num3 = 0;
					int num4 = A_1.Count - 1;
					for (int j = num3; j <= num4; j++)
					{
						int num5 = 0;
						int num6 = A_2.Count - 1;
						for (int k = num5; k <= num6; k++)
						{
							Bitmap bitmap3 = new Bitmap(A_4, A_5, PixelFormat.Format32bppArgb);
							Graphics graphics2 = Graphics.FromImage(bitmap3);
							Bitmap bitmap4 = (Bitmap)Image.FromStream((MemoryStream)A_1[j]);
							graphics2.DrawImage(bitmap4, 0, 0, A_4, A_5);
							bitmap4 = (Bitmap)Image.FromStream((MemoryStream)A_2[k]);
							graphics2.DrawImage(bitmap4, 0, 0, A_4, A_5);
							bitmap4.Dispose();
							MemoryStream memoryStream2 = new MemoryStream();
							bitmap3.Save(memoryStream2, ImageFormat.Png);
							A_3.Add(memoryStream2);
							bitmap3.Dispose();
							backgroundWorker.ReportProgress(global::x.i);
						}
					}
				}
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00011418 File Offset: 0x0000F618
		private static bool a(string A_0, string A_1, string[] A_2, ref Form1 A_3)
		{
			BW2_three.p p = new BW2_three.p();
			p.j = A_0;
			p.e = A_2;
			p.f = false;
			p.i = global::x.a();
			p.c = A_3.BackgroundWorker2;
			p.h = 0;
			p.g = 0;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			BW2_three.a(ref A_3, ref arrayList, ref arrayList2, A_1, p.e[1], p.j, ref p.h, ref p.g);
			ArrayList arrayList3 = new ArrayList();
			ArrayList arrayList4 = new ArrayList();
			BW2_three.a(ref A_3, ref arrayList3, ref arrayList4, A_1, p.e[2], p.j, ref p.h, ref p.g);
			p.a = new ArrayList();
			BW2_three.a(ref A_3, ref arrayList, ref arrayList2, ref p.a, ref p.h, ref p.g);
			p.b = new ArrayList();
			BW2_three.a(ref A_3, ref arrayList3, ref arrayList4, ref p.b, ref p.h, ref p.g);
			p.d = new MemoryStream();
			string text = Path.ChangeExtension(A_1, "png");
			using (Bitmap bitmap = global::x.a(text))
			{
				bitmap.Save(p.d, ImageFormat.Png);
			}
			Parallel.For(0, p.a.Count, p.i, new Action<int, ParallelLoopState>(p.k));
			global::x.f.Add(text);
			global::x.f.Add(A_1);
			p.d.Dispose();
			Parallel.ForEach<object>(arrayList.ToArray(), new Action<object>(BW2_three.v));
			arrayList.Clear();
			Parallel.ForEach<object>(arrayList2.ToArray(), new Action<object>(BW2_three.u));
			arrayList2.Clear();
			Parallel.ForEach<object>(arrayList3.ToArray(), new Action<object>(BW2_three.t));
			arrayList3.Clear();
			Parallel.ForEach<object>(arrayList4.ToArray(), new Action<object>(BW2_three.s));
			arrayList4.Clear();
			Parallel.ForEach<object>(p.a.ToArray(), new Action<object>(BW2_three.r));
			p.a.Clear();
			Parallel.ForEach<object>(p.b.ToArray(), new Action<object>(BW2_three.q));
			p.b.Clear();
			return p.f;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00011698 File Offset: 0x0000F898
		public static bool merge_ks_tjs_txt(ref Form1 myForm1)
		{
			bool result = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			if (0 == string.Compare(global::x.aa, "triagain", StringComparison.Ordinal))
			{
				BW2_three.triagain = true;
			}
			else if (0 == string.Compare(global::x.aa, "祝祭の歌姫", StringComparison.Ordinal))
			{
				BW2_three.utahime = true;
			}
			ArrayList arrayList = new ArrayList();
			foreach (string sPath in array)
			{
				Interlocked.Add(ref global::x.i, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
				}
				kirikiri2_fun.readKsToArr(sPath, ref arrayList);
			}
			if (0 >= arrayList.Count)
			{
				return result;
			}
			string directoryName = Path.GetDirectoryName(Path.GetDirectoryName(array[0]));
			if (BW2_three.triagain)
			{
				string text = Path.Combine(directoryName, "fgimage");
				if (Directory.Exists(text))
				{
					global::x.z = "txt";
					ArrayList arrayList2 = new ArrayList();
					global::x.b(text, ref arrayList2);
					result = BW2_three.b(ref myForm1, ref arrayList2, ref arrayList);
				}
			}
			string text2 = Path.Combine(directoryName, "evimage");
			if (Directory.Exists(text2))
			{
				global::x.z = "tjs";
				ArrayList arrayList3 = new ArrayList();
				global::x.b(text2, ref arrayList3);
				result = BW2_three.a(ref myForm1, ref arrayList3, ref arrayList);
			}
			global::x.aa = string.Empty;
			global::x.z = string.Empty;
			BW2_three.triagain = false;
			BW2_three.utahime = false;
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0001183C File Offset: 0x0000FA3C
		private static bool b(ref Form1 A_0, ref ArrayList A_1, ref ArrayList A_2)
		{
			BW2_three.e e = new BW2_three.e();
			e.d = false;
			ParallelOptions parallelOptions = global::x.a();
			e.a = A_0.BackgroundWorker2;
			checked
			{
				try
				{
					IEnumerator enumerator = A_1.GetEnumerator();
					while (enumerator.MoveNext())
					{
						BW2_three.e.a a = new BW2_three.e.a(a);
						string text = Conversions.ToString(enumerator.Current);
						a.b = e;
						Interlocked.Add(ref global::x.i, 1);
						if (e.a.CancellationPending)
						{
							return true;
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (e.a.CancellationPending)
							{
								return true;
							}
						}
						e.c = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, e.c, "_info", CompareMethod.Binary) > 0)
						{
							e.b = text;
							a.a = new ArrayList(10);
							if (File.Exists(e.b))
							{
								global::x.f.Add(e.b);
								Parallel.ForEach<object>(A_1.ToArray(), new Action<object>(a.c));
								if (0 < a.a.Count)
								{
									try
									{
										IEnumerator enumerator2 = a.a.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											BW2_three.e.a.a a2 = new BW2_three.e.a.a(a2);
											string text2 = Conversions.ToString(enumerator2.Current);
											a2.l = e;
											Interlocked.Add(ref global::x.i, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.k, ref a2.j))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(e.b, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												ArrayList arrayList6 = new ArrayList();
												string text3 = string.Empty;
												a2.i = 0;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array = (string[])obj;
														if (0 == string.Compare(array[0], "facegroup", StringComparison.Ordinal))
														{
															a2.i++;
														}
														else if (0 == string.Compare(array[0], "dress", StringComparison.Ordinal))
														{
															if (0 == string.Compare(array[2], "base", StringComparison.Ordinal))
															{
																string[] array2 = new string[7];
																array2[0] = array[1];
																text3 = array[3];
																array2[1] = text3;
																bool flag = false;
																try
																{
																	foreach (object obj2 in arrayList3)
																	{
																		string[] array3 = (string[])obj2;
																		if (0 == string.Compare(array3[0], array2[0], StringComparison.Ordinal) && 0 == string.Compare(array3[1], array2[1], StringComparison.Ordinal))
																		{
																			flag = true;
																			break;
																		}
																	}
																}
																finally
																{
																	IEnumerator enumerator4;
																	if (enumerator4 is IDisposable)
																	{
																		(enumerator4 as IDisposable).Dispose();
																	}
																}
																if (!flag)
																{
																	string str = text3;
																	bool bFollowUp = false;
																	ArrayList arrayList7 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList7);
																	array2[2] = layerArr.layer_id;
																	array2[3] = layerArr.left;
																	array2[4] = layerArr.top;
																	array2[5] = layerArr.width;
																	array2[6] = layerArr.height;
																	arrayList3.Add(array2);
																}
															}
															else if (0 == string.Compare(array[2], "diff", StringComparison.Ordinal))
															{
																string[] array4 = new string[8];
																array4[0] = array[1];
																array4[1] = array[3];
																text3 = array[4];
																array4[7] = text3;
																string str2 = text3;
																bool bFollowUp2 = false;
																ArrayList arrayList7 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList7);
																array4[2] = layerArr2.layer_id;
																array4[3] = layerArr2.left;
																array4[4] = layerArr2.top;
																array4[5] = layerArr2.width;
																array4[6] = layerArr2.height;
																if (Strings.InStr(1, text3, "/", CompareMethod.Binary) > 0)
																{
																}
																arrayList4.Add(array4);
															}
															else
															{
																global::x.c("dress 出现未知数据!");
															}
														}
														else if (0 == string.Compare(array[0], "fgname", StringComparison.Ordinal))
														{
															string[] array5 = new string[7];
															if (3 > array.Length)
															{
																array5[0] = array[1];
																array5[1] = "-1";
															}
															else
															{
																array5[0] = array[1];
																text3 = array[2];
																array5[6] = text3;
																string str3 = text3;
																bool bFollowUp3 = false;
																ArrayList arrayList7 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(str3, ref arrayList, bFollowUp3, ref arrayList7);
																array5[1] = layerArr3.layer_id;
																array5[2] = layerArr3.left;
																array5[3] = layerArr3.top;
																array5[4] = layerArr3.width;
																array5[5] = layerArr3.height;
															}
															arrayList5.Add(array5);
														}
													}
												}
												finally
												{
													IEnumerator enumerator3;
													if (enumerator3 is IDisposable)
													{
														(enumerator3 as IDisposable).Dispose();
													}
												}
												a2.c = Path.GetDirectoryName(text2).Split(new char[]
												{
													Path.DirectorySeparatorChar
												}).Last<string>();
												a2.h = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												e.a.ReportProgress(0);
												a2.f = new ArrayList();
												a2.g = new ArrayList();
												try
												{
													foreach (object obj3 in arrayList5)
													{
														string[] array6 = (string[])obj3;
														if (e.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (e.a.CancellationPending)
															{
																return true;
															}
														}
														Bitmap bitmap = new Bitmap(a2.k, a2.j, PixelFormat.Format32bppArgb);
														Graphics graphics = Graphics.FromImage(bitmap);
														graphics.Clear(Color.Transparent);
														Interlocked.Add(ref global::x.i, 1);
														if (0 != string.Compare(array6[1], "-1", StringComparison.Ordinal))
														{
															string text4 = global::x.a(a2.h, "_" + array6[1]);
															if (File.Exists(text4))
															{
																global::x.f.Add(text4);
																Bitmap bitmap2 = global::x.a(text4);
																graphics.DrawImage(bitmap2, Conversions.ToInteger(array6[2]), Conversions.ToInteger(array6[3]), bitmap2.Width, bitmap2.Height);
																bitmap2.Dispose();
															}
														}
														graphics.Dispose();
														MemoryStream memoryStream = new MemoryStream();
														bitmap.Save(memoryStream, ImageFormat.Png);
														a2.f.Add(memoryStream);
														a2.g.Add(array6[0]);
														bitmap.Dispose();
														e.a.ReportProgress(global::x.i);
													}
												}
												finally
												{
													IEnumerator enumerator5;
													if (enumerator5 is IDisposable)
													{
														(enumerator5 as IDisposable).Dispose();
													}
												}
												global::x.j += a2.f.Count;
												a2.a = new ArrayList();
												a2.b = new ArrayList();
												try
												{
													foreach (object obj4 in arrayList4)
													{
														string[] array7 = (string[])obj4;
														if (e.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (e.a.CancellationPending)
															{
																return true;
															}
														}
														Bitmap bitmap3 = new Bitmap(a2.k, a2.j, PixelFormat.Format32bppArgb);
														Graphics graphics2 = Graphics.FromImage(bitmap3);
														graphics2.Clear(Color.Transparent);
														Interlocked.Add(ref global::x.i, 1);
														string text5 = global::x.a(a2.h, "_" + array7[2]);
														if (File.Exists(text5))
														{
															global::x.f.Add(text5);
															Bitmap bitmap4 = global::x.a(text5);
															graphics2.DrawImage(bitmap4, Conversions.ToInteger(array7[3]), Conversions.ToInteger(array7[4]), bitmap4.Width, bitmap4.Height);
															bitmap4.Dispose();
														}
														graphics2.Dispose();
														MemoryStream memoryStream2 = new MemoryStream();
														bitmap3.Save(memoryStream2, ImageFormat.Png);
														a2.a.Add(memoryStream2);
														text3 = array7[0] + "_" + array7[1];
														a2.b.Add(text3);
														bitmap3.Dispose();
														e.a.ReportProgress(global::x.i);
													}
												}
												finally
												{
													IEnumerator enumerator6;
													if (enumerator6 is IDisposable)
													{
														(enumerator6 as IDisposable).Dispose();
													}
												}
												global::x.j += a2.a.Count;
												a2.d = new ArrayList();
												a2.e = new ArrayList();
												string strB = string.Empty;
												try
												{
													foreach (object obj5 in arrayList3)
													{
														string[] array8 = (string[])obj5;
														if (e.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (e.a.CancellationPending)
															{
																return true;
															}
														}
														string text6 = array8[0];
														int x = Conversions.ToInteger(array8[3]);
														int y = Conversions.ToInteger(array8[4]);
														if (0 != string.Compare(text6, strB, StringComparison.Ordinal))
														{
															Bitmap bitmap5 = new Bitmap(a2.k, a2.j, PixelFormat.Format32bppArgb);
															Graphics graphics3 = Graphics.FromImage(bitmap5);
															graphics3.Clear(Color.Transparent);
															Interlocked.Add(ref global::x.i, 1);
															string text7 = global::x.a(a2.h, "_" + array8[2]);
															if (File.Exists(text7))
															{
																global::x.f.Add(text7);
																using (Bitmap bitmap6 = global::x.a(text7))
																{
																	graphics3.DrawImage(bitmap6, x, y, bitmap6.Width, bitmap6.Height);
																}
															}
															try
															{
																foreach (object obj6 in arrayList3)
																{
																	string[] array9 = (string[])obj6;
																	if (0 != string.Compare(array8[2], array9[2], StringComparison.Ordinal) && 0 == string.Compare(text6, array9[0], StringComparison.Ordinal))
																	{
																		strB = text6;
																		text7 = global::x.a(a2.h, "_" + array9[2]);
																		Interlocked.Add(ref global::x.i, 1);
																		if (File.Exists(text7))
																		{
																			global::x.f.Add(text7);
																			using (Bitmap bitmap7 = global::x.a(text7))
																			{
																				graphics3.DrawImage(bitmap7, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitmap7.Width, bitmap7.Height);
																				break;
																			}
																		}
																	}
																}
															}
															finally
															{
																IEnumerator enumerator8;
																if (enumerator8 is IDisposable)
																{
																	(enumerator8 as IDisposable).Dispose();
																}
															}
															graphics3.Dispose();
															MemoryStream memoryStream3 = new MemoryStream();
															bitmap5.Save(memoryStream3, ImageFormat.Png);
															a2.d.Add(memoryStream3);
															a2.e.Add(text6);
															bitmap5.Dispose();
															e.a.ReportProgress(global::x.i);
														}
													}
												}
												finally
												{
													IEnumerator enumerator7;
													if (enumerator7 is IDisposable)
													{
														(enumerator7 as IDisposable).Dispose();
													}
												}
												Parallel.ForEach<object>(A_2.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.m));
												Parallel.ForEach<object>(a2.f.ToArray(), new Action<object>(BW2_three.p));
												a2.f.Clear();
												a2.g.Clear();
												Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.o));
												a2.a.Clear();
												a2.b.Clear();
												Parallel.ForEach<object>(a2.d.ToArray(), new Action<object>(BW2_three.n));
												a2.d.Clear();
												a2.e.Clear();
											}
										}
									}
									finally
									{
										IEnumerator enumerator2;
										if (enumerator2 is IDisposable)
										{
											(enumerator2 as IDisposable).Dispose();
										}
									}
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
				return e.d;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00012520 File Offset: 0x00010720
		private static bool a(ref Form1 A_0, ref ArrayList A_1, ref ArrayList A_2)
		{
			bool result = false;
			ParallelOptions parallelOptions = global::x.a();
			BackgroundWorker backgroundWorker = A_0.BackgroundWorker2;
			checked
			{
				try
				{
					foreach (object value in A_1)
					{
						string text = Conversions.ToString(value);
						Interlocked.Add(ref global::x.i, 1);
						if (backgroundWorker.CancellationPending)
						{
							return true;
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (backgroundWorker.CancellationPending)
							{
								return true;
							}
						}
						ArrayList arrayList = kirikiri2_fun.readTjsToArr_2(text);
						if (1 <= arrayList.Count)
						{
							string directoryName = Path.GetDirectoryName(text);
							object obj = arrayList[0];
							kirikiri2_fun.kirikiri2TjsData2 kirikiri2TjsData2;
							kirikiri2_fun.kirikiri2TjsData2 kirikiri2TjsData = (obj != null) ? ((kirikiri2_fun.kirikiri2TjsData2)obj) : kirikiri2TjsData2;
							string baseImage = kirikiri2TjsData.baseImage;
							int iDiffCommands = kirikiri2TjsData.iDiffCommands;
							string text2 = global::x.a(Path.Combine(directoryName, baseImage), "");
							if (File.Exists(text2))
							{
								global::x.f.Add(text2);
								try
								{
									foreach (object value2 in A_2)
									{
										string text3 = Conversions.ToString(value2);
										if (backgroundWorker.CancellationPending)
										{
											return true;
										}
										while (global::x.a)
										{
											Thread.Sleep(500);
											if (backgroundWorker.CancellationPending)
											{
												return true;
											}
										}
										string text4 = text3.Substring(1);
										string[] array = global::x.ap.Split(text4);
										string text5 = array.First<string>();
										if (BW2_three.utahime && Operators.CompareString(Conversions.ToString(baseImage.Last<char>()), "大", false) == 0)
										{
											text5 += "大";
										}
										string text6 = Path.Combine(directoryName, baseImage + "_");
										if (0 == string.Compare(text5, baseImage, StringComparison.Ordinal))
										{
											Interlocked.Add(ref global::x.i, 1);
											Bitmap bitmap = global::x.a(text2);
											Graphics graphics = Graphics.FromImage(bitmap);
											int num = 1;
											int num2 = array.Count<string>() - 1;
											for (int i = num; i <= num2; i++)
											{
												text4 = array[i];
												text6 += text4;
												if (i >= iDiffCommands)
												{
													break;
												}
												text6 += "_";
											}
											text4 = global::x.a(text6, "");
											if (!File.Exists(text4))
											{
												for (int j = array.Count<string>() - 1; j >= 1; j += -1)
												{
													text4 = array[j];
													try
													{
														foreach (object obj2 in arrayList)
														{
															kirikiri2_fun.kirikiri2TjsData2 kirikiri2TjsData3 = (obj2 != null) ? ((kirikiri2_fun.kirikiri2TjsData2)obj2) : kirikiri2TjsData2;
															text5 = kirikiri2TjsData3.diffs1 + kirikiri2TjsData3.diffs2;
															if (0 == string.Compare(text5, text4, StringComparison.Ordinal))
															{
																text4 = global::x.a(Path.Combine(directoryName, string.Concat(new string[]
																{
																	baseImage,
																	"_",
																	kirikiri2TjsData3.diffs1,
																	"_",
																	kirikiri2TjsData3.diffs2
																})), "");
																if (File.Exists(text4))
																{
																	using (Bitmap bitmap2 = global::x.a(text4))
																	{
																		graphics.DrawImage(bitmap2, Conversions.ToInteger(kirikiri2TjsData3.x), Conversions.ToInteger(kirikiri2TjsData3.y), Conversions.ToInteger(kirikiri2TjsData3.width), Conversions.ToInteger(kirikiri2TjsData3.height));
																		global::x.f.Add(text4);
																		Interlocked.Add(ref global::x.i, 1);
																	}
																	break;
																}
																break;
															}
														}
													}
													finally
													{
														IEnumerator enumerator3;
														if (enumerator3 is IDisposable)
														{
															(enumerator3 as IDisposable).Dispose();
														}
													}
												}
												graphics.Dispose();
												text6 = Path.Combine(directoryName, baseImage + "_");
												int num3 = 1;
												int num4 = array.Count<string>() - 1;
												for (int k = num3; k <= num4; k++)
												{
													text4 = array[k];
													text6 += text4;
													if (k >= iDiffCommands)
													{
														break;
													}
													text6 += "_";
												}
												text4 = global::x.a(text6, ref bitmap, false);
												if (!string.IsNullOrEmpty(text4))
												{
													Interlocked.Add(ref global::x.k, 1);
												}
												bitmap.Dispose();
												backgroundWorker.ReportProgress(global::x.i);
												Thread.Sleep(global::x.c);
											}
										}
									}
								}
								finally
								{
									IEnumerator enumerator2;
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
								global::x.f.Add(text);
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
				return result;
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000129F8 File Offset: 0x00010BF8
		public static bool merge_ks_cg_mode_first(ref Form1 myForm1)
		{
			bool result = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				string strA = string.Empty;
				string a_ = string.Empty;
				ParallelOptions parallelOptions = global::x.a();
				BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
				ArrayList arrayList = new ArrayList();
				string text = global::x.z;
				foreach (string text2 in array)
				{
					Interlocked.Add(ref global::x.i, 1);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (backgroundWorker.CancellationPending)
						{
							return true;
						}
					}
					strA = Path.GetFileNameWithoutExtension(text2);
					if (0 == string.Compare(strA, "CGモード", StringComparison.Ordinal) | 0 == string.Compare(strA, "first", StringComparison.Ordinal))
					{
						a_ = Path.GetDirectoryName(text2);
						arrayList.Clear();
						global::x.z = "*";
						global::x.b(a_, ref arrayList);
						if (1 > arrayList.Count)
						{
							return result;
						}
						backgroundWorker.ReportProgress(global::x.i);
						global::x.f.Add(text2);
						using (FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, global::x.o))
							{
								string text3 = string.Empty;
								string text4 = string.Empty;
								string text5 = string.Empty;
								bool flag = true;
								bool flag2 = false;
								bool flag3 = false;
								ArrayList arrayList2 = new ArrayList();
								ArrayList arrayList3 = new ArrayList();
								while (!streamReader.EndOfStream)
								{
									if (backgroundWorker.CancellationPending)
									{
										return true;
									}
									while (global::x.a)
									{
										Thread.Sleep(500);
										if (backgroundWorker.CancellationPending)
										{
											return true;
										}
									}
									text3 = streamReader.ReadLine().Trim();
									if (Strings.InStr(1, text3, "[endif", CompareMethod.Binary) > 0 | Strings.InStr(1, text3, "[if", CompareMethod.Binary) > 0)
									{
										text5 = string.Empty;
										flag = false;
										flag2 = false;
										flag3 = false;
										arrayList2.Clear();
										arrayList3.Clear();
										arrayList2 = new ArrayList();
										arrayList3 = new ArrayList();
									}
									else if (Strings.InStr(1, text3, "[image", CompareMethod.Binary) > 0)
									{
										string[] array3 = global::x.ap.Split(text3);
										string[] array4 = new string[]
										{
											null,
											null,
											null,
											"true",
											"0",
											"-1"
										};
										bool flag4 = false;
										int num = 0;
										int num2 = array3.Count<string>() - 1;
										for (int j = num; j <= num2; j++)
										{
											string text6 = array3[j];
											if (Strings.InStr(1, text6, "top=", CompareMethod.Binary) > 0)
											{
												text = global::x.an.Split(text6).Last<string>();
												array4[0] = text;
											}
											else if (Strings.InStr(1, text6, "left=", CompareMethod.Binary) > 0)
											{
												text = global::x.an.Split(text6).Last<string>();
												array4[1] = text;
											}
											else if (Strings.InStr(1, text6, "storage=", CompareMethod.Binary) > 0)
											{
												text4 = global::x.an.Split(text6).Last<string>().Replace("\"", string.Empty);
												array4[2] = text4;
												if (Strings.InStr(1, text4, "立ち絵", CompareMethod.Binary) > 0)
												{
													flag3 = true;
													if (Strings.InStr(1, text4, "体", CompareMethod.Binary) > 0)
													{
														flag4 = true;
													}
												}
											}
											else if (Strings.InStr(1, text6, "visible=", CompareMethod.Binary) > 0)
											{
												text = global::x.an.Split(text6).Last<string>();
												array4[3] = text;
											}
											else if (Strings.InStr(1, text6, "cond=", CompareMethod.Binary) > 0)
											{
												text = array3[j + 1];
												if (Strings.InStr(1, text, "=", CompareMethod.Binary) > 0)
												{
													text = text6 + text + array3[j + 2];
												}
												text = text.Split(new char[]
												{
													'"'
												})[1];
												array4[4] = text;
												j += 2;
											}
											else if (Strings.InStr(1, text6, "layer=", CompareMethod.Binary) > 0)
											{
												text = global::x.an.Split(text6).Last<string>();
												array4[5] = text;
											}
										}
										if (flag4 && flag3)
										{
											arrayList2.Add(array4);
										}
										else
										{
											arrayList3.Insert(0, array4);
										}
										if (flag)
										{
											flag = false;
										}
									}
									else if (Strings.InStr(1, text3, "[ichenge2", CompareMethod.Binary) > 0)
									{
										if (!flag)
										{
											flag2 = true;
											if (!flag3)
											{
												string[] array3 = global::x.ap.Split(text3);
												string[] array5 = new string[]
												{
													"0",
													"0",
													null,
													"true",
													"0",
													"-1"
												};
												int num3 = 0;
												int num4 = array3.Count<string>() - 1;
												for (int k = num3; k <= num4; k++)
												{
													string text7 = array3[k];
													if (Strings.InStr(1, text7, "storage=", CompareMethod.Binary) > 0)
													{
														text4 = global::x.an.Split(text7).Last<string>().Replace("\"", string.Empty);
														array5[2] = text4;
													}
													else if (Strings.InStr(1, text7, "cond=", CompareMethod.Binary) > 0)
													{
														text = array3[k + 1];
														if (Strings.InStr(1, text, "=", CompareMethod.Binary) > 0)
														{
															text = text7 + text + array3[k + 2];
														}
														text = text.Split(new char[]
														{
															'"'
														})[1];
														array5[4] = text;
														k += 2;
													}
												}
												arrayList2.Add(array5);
											}
										}
									}
									else if (flag2)
									{
										text = string.Empty;
										string text8 = string.Empty;
										int num5 = 0;
										int num6 = arrayList3.Count - 1;
										for (int l = num5; l <= num6; l++)
										{
											string[] array6 = (string[])arrayList3[l];
											if (0 == string.Compare(text8, array6[5], StringComparison.Ordinal))
											{
												break;
											}
											text8 = array6[5];
										}
										ArrayList arrayList4 = new ArrayList();
										if (!string.IsNullOrWhiteSpace(text8))
										{
											for (;;)
											{
												IL_5C9:
												int num7 = 0;
												int num8 = arrayList3.Count - 1;
												for (int m = num7; m <= num8; m++)
												{
													string[] array7 = (string[])arrayList3[m];
													if (0 == string.Compare(text8, array7[5], StringComparison.Ordinal))
													{
														arrayList3.RemoveAt(m);
														arrayList4.Add(array7);
														goto IL_5C9;
													}
												}
												break;
											}
										}
										ArrayList arrayList5 = new ArrayList();
										ArrayList arrayList6 = new ArrayList();
										ArrayList arrayList7 = new ArrayList();
										int width;
										int height;
										try
										{
											foreach (object obj in arrayList2)
											{
												string[] array8 = (string[])obj;
												text5 = string.Empty;
												string text9 = array8[2];
												string text10 = global::x.a(ref arrayList, text9);
												if (!string.IsNullOrWhiteSpace(text10))
												{
													Interlocked.Add(ref global::x.i, 1);
													Bitmap bitmap = global::x.a(text10);
													width = bitmap.Width;
													height = bitmap.Height;
													Graphics graphics = Graphics.FromImage(bitmap);
													try
													{
														foreach (object obj2 in arrayList3)
														{
															string[] array9 = (string[])obj2;
															if (!flag3 && 0 != string.Compare("0", array9[4], StringComparison.Ordinal))
															{
																if (0 == string.Compare("true", array9[3], StringComparison.OrdinalIgnoreCase))
																{
																	if (0 != string.Compare(array8[4], array9[4], StringComparison.Ordinal))
																	{
																		continue;
																	}
																}
																else if (0 == string.Compare("false", array9[3], StringComparison.OrdinalIgnoreCase))
																{
																	continue;
																}
															}
															string text11 = array9[2];
															text = global::x.a(ref arrayList, text11);
															if (!string.IsNullOrWhiteSpace(text))
															{
																global::x.f.Add(text);
																Interlocked.Add(ref global::x.i, 1);
																int x = Conversions.ToInteger(array9[0]);
																int y = Conversions.ToInteger(array9[1]);
																using (Bitmap bitmap2 = global::x.a(text))
																{
																	if (flag3)
																	{
																		graphics.DrawImage(bitmap2, 0, 0, width, height);
																	}
																	else
																	{
																		graphics.DrawImage(bitmap2, x, y, width, height);
																	}
																}
																text5 = text5 + text11 + "_";
															}
															backgroundWorker.ReportProgress(global::x.i);
														}
													}
													finally
													{
														IEnumerator enumerator2;
														if (enumerator2 is IDisposable)
														{
															(enumerator2 as IDisposable).Dispose();
														}
													}
													graphics.Dispose();
													MemoryStream memoryStream = new MemoryStream();
													if (!string.IsNullOrWhiteSpace(text5))
													{
														global::x.f.Add(text10);
														string value = Path.Combine(Path.GetDirectoryName(text10), text9 + "_" + text5.Substring(0, text5.Length - 1));
														arrayList6.Add(value);
														bitmap.Save(memoryStream, ImageFormat.Png);
														arrayList5.Add(memoryStream);
														arrayList7.Add(array8[4]);
													}
													bitmap.Dispose();
												}
												backgroundWorker.ReportProgress(global::x.i);
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
										int num9 = 0;
										int num10 = arrayList5.Count - 1;
										int n = num9;
										while (n <= num10)
										{
											MemoryStream stream = (MemoryStream)arrayList5[n];
											if (0 < arrayList4.Count)
											{
												try
												{
													foreach (object obj3 in arrayList4)
													{
														string[] array10 = (string[])obj3;
														text5 = string.Empty;
														bool flag5 = true;
														if (!flag3 && 0 != string.Compare("0", array10[4], StringComparison.Ordinal))
														{
															if (0 != string.Compare(Conversions.ToString(arrayList7[n]), array10[4], StringComparison.Ordinal))
															{
																continue;
															}
															flag5 = (0 == string.Compare("true", array10[3], StringComparison.OrdinalIgnoreCase));
														}
														Bitmap bitmap3 = (Bitmap)Image.FromStream(stream);
														if (flag5)
														{
															Graphics graphics2 = Graphics.FromImage(bitmap3);
															string text12 = array10[2];
															text = global::x.a(ref arrayList, text12);
															if (!string.IsNullOrWhiteSpace(text))
															{
																global::x.f.Add(text);
																Interlocked.Add(ref global::x.i, 1);
																int x = Conversions.ToInteger(array10[0]);
																int y = Conversions.ToInteger(array10[1]);
																using (Bitmap bitmap4 = global::x.a(text))
																{
																	if (flag3)
																	{
																		graphics2.DrawImage(bitmap4, 0, 0, width, height);
																	}
																	else
																	{
																		graphics2.DrawImage(bitmap4, x, y, width, height);
																	}
																}
																text5 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(arrayList6[n], "_"), text12));
															}
															graphics2.Dispose();
														}
														else
														{
															text5 = Conversions.ToString(arrayList6[n]);
														}
														text = global::x.a(text5, ref bitmap3, false);
														if (!string.IsNullOrWhiteSpace(text))
														{
															Interlocked.Add(ref global::x.k, 1);
														}
														bitmap3.Dispose();
													}
													goto IL_A93;
												}
												finally
												{
													IEnumerator enumerator3;
													if (enumerator3 is IDisposable)
													{
														(enumerator3 as IDisposable).Dispose();
													}
												}
												goto IL_A58;
											}
											goto IL_A58;
											IL_A93:
											n++;
											continue;
											IL_A58:
											string a_2 = Conversions.ToString(arrayList6[n]);
											Bitmap bitmap5 = (Bitmap)Image.FromStream(stream);
											text = global::x.a(a_2, ref bitmap5, false);
											if (!string.IsNullOrWhiteSpace(text))
											{
												Interlocked.Add(ref global::x.k, 1);
												goto IL_A93;
											}
											goto IL_A93;
										}
										text5 = string.Empty;
										width = 0;
										height = 0;
										flag = false;
										flag2 = false;
										flag3 = false;
										arrayList2.Clear();
										arrayList3.Clear();
										arrayList2 = new ArrayList();
										arrayList3 = new ArrayList();
									}
								}
							}
						}
					}
				}
				global::x.aa = string.Empty;
				global::x.z = string.Empty;
				return result;
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000135D8 File Offset: 0x000117D8
		public static bool merge_ks_width_gamename(ref Form1 myForm1)
		{
			BW2_three.g g = new BW2_three.g();
			g.b = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			if (0 == string.Compare(global::x.aa, "逆王道", StringComparison.Ordinal))
			{
				BW2_three.gyakuoudou = true;
			}
			if (!BW2_three.gyakuoudou)
			{
				return g.b;
			}
			string text = string.Empty;
			ParallelOptions parallelOptions = global::x.a();
			g.a = myForm1.BackgroundWorker2;
			ArrayList arrayList = new ArrayList(100);
			foreach (string text2 in array)
			{
				Interlocked.Add(ref global::x.i, 1);
				if (g.a.CancellationPending)
				{
					return true;
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (g.a.CancellationPending)
					{
						return true;
					}
				}
				if (BW2_three.gyakuoudou)
				{
					kirikiri2_fun.readKsToArr2(text2, ref arrayList, "#");
				}
				else
				{
					kirikiri2_fun.readKsToArr2(text2, ref arrayList, "");
				}
				text = Directory.GetParent(Path.GetDirectoryName(text2)).FullName;
			}
			if (0 >= arrayList.Count)
			{
				return g.b;
			}
			if (Directory.Exists(text))
			{
				BW2_three.g.a a = new BW2_three.g.a();
				a.b = g;
				global::x.z = string.Empty;
				a.a = new ArrayList(100);
				global::x.b(text, ref a.a);
				if (0 >= a.a.Count)
				{
					return g.b;
				}
				Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a.c));
			}
			BW2_three.gyakuoudou = false;
			global::x.aa = string.Empty;
			global::x.z = string.Empty;
			return g.b;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000137AC File Offset: 0x000119AC
		public static bool pos_anm_asd_1(ref Form1 myForm1)
		{
			BW2_three.f f = new BW2_three.f();
			f.c = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = global::x.a();
				f.a = myForm1.BackgroundWorker2;
				f.a.ReportProgress(0);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.f.a a = new BW2_three.f.a(a);
					string text = array2[i];
					Interlocked.Add(ref global::x.i, 1);
					if (f.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (f.a.CancellationPending)
						{
							return true;
						}
					}
					string text2 = Path.ChangeExtension(text, "pos");
					a.a = false;
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					f.b = Path.GetDirectoryName(text);
					string text3 = string.Empty;
					if (File.Exists(text2))
					{
						global::x.f.Add(text2);
						Interlocked.Add(ref global::x.i, 1);
						string[] array3 = kirikiri2_fun.readAnmToArr(text2);
						string text4 = global::x.a(Path.Combine(f.b, array3[0]), "");
						if (File.Exists(text4))
						{
							Image image = global::x.a(text);
							Image image2 = global::x.a(text4);
							Graphics graphics = Graphics.FromImage(image2);
							graphics.DrawImage(image, Conversions.ToInteger(array3[2]), Conversions.ToInteger(array3[1]), image.Width, image.Height);
							graphics.Dispose();
							image.Dispose();
							string text5 = text2;
							string a_ = text5;
							Bitmap bitmap = (Bitmap)image2;
							string text6 = global::x.a(a_, ref bitmap, true);
							image2 = bitmap;
							text3 = text6;
							a.a = true;
							Interlocked.Add(ref global::x.k, 1);
							image2.Dispose();
							f.a.ReportProgress(global::x.i);
						}
					}
					string text7 = Path.ChangeExtension(text, "anm");
					if (File.Exists(text7))
					{
						BW2_three.f.a.a a2 = new BW2_three.f.a.a();
						a2.a = kirikiri2_fun.readAnmToArr(text7);
						a2.b = Path.Combine(f.b, fileNameWithoutExtension + "_anm.asd");
						if (File.Exists(a2.b))
						{
							BW2_three.f.a.a.a a3 = new BW2_three.f.a.a.a();
							a3.f = a2;
							a3.e = a;
							a3.d = f;
							global::x.f.Add(text7);
							Interlocked.Add(ref global::x.i, 1);
							global::x.f.Add(a2.b);
							Interlocked.Add(ref global::x.i, 1);
							a3.c = kirikiri2_fun.readAsdToArr(a2.b);
							string text8 = global::x.a(Path.Combine(Path.GetDirectoryName(a2.b), Path.GetFileNameWithoutExtension(a2.b)), "");
							global::x.f.Add(text8);
							Interlocked.Add(ref global::x.i, 1);
							Image image3;
							if (a.a)
							{
								if (File.Exists(text3))
								{
									global::x.f.Add(text3);
									image3 = global::x.a(text3);
								}
								else
								{
									image3 = global::x.a(text);
								}
							}
							else
							{
								image3 = global::x.a(text);
							}
							a3.a = new MemoryStream();
							a3.b = new MemoryStream();
							image3.Save(a3.a, ImageFormat.Png);
							image3.Dispose();
							image3 = global::x.a(text8);
							image3.Save(a3.b, ImageFormat.Png);
							image3.Dispose();
							Parallel.For(0, a3.c.Count, parallelOptions, new Action<int, ParallelLoopState>(a3.g));
							a3.b.Dispose();
							a3.a.Dispose();
						}
					}
					f.a.ReportProgress(global::x.i);
					Thread.Sleep(global::x.c);
					if (a.a)
					{
						global::x.f.Add(text);
					}
				}
				global::x.z = string.Empty;
				return f.c;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00013BC4 File Offset: 0x00011DC4
		public static bool pos_anm_asd_2(ref Form1 myForm1)
		{
			BW2_three.i i = new BW2_three.i();
			i.c = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			if (0 == string.Compare(global::x.aa, "rebirth_colony", StringComparison.OrdinalIgnoreCase))
			{
			}
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = global::x.a();
				i.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				int j = 0;
				while (j < array2.Length)
				{
					BW2_three.i.a a = new BW2_three.i.a(a);
					string text = array2[j];
					a.q = i;
					Interlocked.Add(ref global::x.i, 1);
					if (i.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (i.a.CancellationPending)
						{
							return true;
						}
					}
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					i.b = Path.GetDirectoryName(text);
					string text2;
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, global::x.o))
						{
							text2 = streamReader.ReadLine().Trim();
							if (!Versioned.IsNumeric(text2))
							{
								goto IL_496;
							}
							a.k = Conversions.ToInteger(text2);
							text2 = streamReader.ReadLine().Trim();
							if (!Versioned.IsNumeric(text2))
							{
								goto IL_496;
							}
							a.l = Conversions.ToInteger(text2);
						}
					}
					goto IL_178;
					IL_496:
					j++;
					continue;
					IL_178:
					a.p = Path.Combine(i.b, fileNameWithoutExtension + "_");
					ArrayList arrayList = new ArrayList();
					a.o = new ArrayList();
					a.a = new ArrayList();
					a.f = new ArrayList();
					a.g = new ArrayList();
					a.h = new ArrayList();
					a.m = new ArrayList();
					text2 = global::x.z;
					global::x.z = string.Empty;
					global::x.b(i.b, ref arrayList);
					global::x.z = text2;
					Parallel.ForEach<object>(arrayList.ToArray(), new Action<object>(a.r));
					if (0 >= a.a.Count)
					{
						goto IL_496;
					}
					using (Bitmap bitmap = global::x.a(Conversions.ToString(a.a[0])))
					{
						a.c = bitmap.Width;
						a.b = bitmap.Height;
						a.n = bitmap.PixelFormat;
					}
					if (0 >= a.c & 0 >= a.b)
					{
						goto IL_496;
					}
					a.d = new ArrayList();
					a.e = new ArrayList();
					Parallel.ForEach<object>(a.h.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a.r));
					a.i = new ArrayList();
					a.j = new ArrayList();
					Parallel.For(0, a.d.Count, parallelOptions, new Action<int, ParallelLoopState>(a.r));
					Parallel.ForEach<object>(a.d.ToArray(), new Action<object>(BW2_three.m));
					a.e.Clear();
					int num = 0;
					int num2 = a.a.Count - 1;
					for (int k = num; k <= num2; k++)
					{
						BW2_three.i.a.a a2 = new BW2_three.i.a.a(a2);
						if (i.a.CancellationPending)
						{
							return true;
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (i.a.CancellationPending)
							{
								return true;
							}
						}
						Interlocked.Add(ref global::x.i, 1);
						a2.c = Conversions.ToString(a.a[k]);
						BW2_three.i.a.a.a a3 = new BW2_three.i.a.a.a();
						a3.d = a2;
						a3.c = a;
						a3.b = i;
						a3.a = global::x.a(a2.c);
						try
						{
							a2.b = a3.a.Width;
							a2.a = a3.a.Height;
							Parallel.For(0, a.i.Count, parallelOptions, new Action<int, ParallelLoopState>(a3.e));
						}
						finally
						{
							if (a3.a != null)
							{
								((IDisposable)a3.a).Dispose();
							}
						}
					}
					global::x.f.Add(text);
					Parallel.ForEach<object>(a.i.ToArray(), new Action<object>(BW2_three.l));
					a.j.Clear();
					goto IL_496;
				}
				global::x.z = string.Empty;
				global::x.aa = string.Empty;
				return i.c;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000140C8 File Offset: 0x000122C8
		public static bool merge_imageObject_tjs(ref Form1 myForm1)
		{
			bool flag = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			if (0 == string.Compare(global::x.aa, "suigetsu_2", StringComparison.OrdinalIgnoreCase))
			{
			}
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref global::x.i, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
				}
				string directoryName = Path.GetDirectoryName(text);
				ArrayList arrayList = kirikiri2_fun.readTjsToArr(text);
				if (0 < arrayList.Count)
				{
					string[] directories = Directory.GetDirectories(directoryName);
					foreach (string text2 in directories)
					{
						string text3 = text2.Split(new char[]
						{
							Path.DirectorySeparatorChar
						}).Last<string>();
						if (Strings.InStr(1, text3, "_", CompareMethod.Binary) > 0)
						{
							string[] array4 = global::x.ak.Split(text3);
							string strB = array4[0].ToLower();
							ArrayList arrayList2 = new ArrayList();
							try
							{
								foreach (object obj in arrayList)
								{
									kirikiri2_fun.Tjs_lms_SY tjs_lms_SY2;
									kirikiri2_fun.Tjs_lms_SY tjs_lms_SY = (obj != null) ? ((kirikiri2_fun.Tjs_lms_SY)obj) : tjs_lms_SY2;
									if (0 == string.Compare(tjs_lms_SY.CharaID, strB, StringComparison.Ordinal))
									{
										arrayList2.Add(tjs_lms_SY);
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
							if (0 < arrayList2.Count)
							{
								flag = BW2_three.a(ref myForm1, text2, ref arrayList2, "l");
								flag = BW2_three.a(ref myForm1, text2, ref arrayList2, "m");
								flag = BW2_three.a(ref myForm1, text2, ref arrayList2, "s");
								if (!flag)
								{
									string path = Path.Combine(directoryName, "0_YouCanDel");
									path = Path.Combine(path, text3);
									global::x.g.Add(new string[]
									{
										Path.Combine(text2, "素体"),
										Path.Combine(path, "素体")
									});
									global::x.g.Add(new string[]
									{
										Path.Combine(text2, "目パチ"),
										Path.Combine(path, "目パチ")
									});
									global::x.g.Add(new string[]
									{
										Path.Combine(text2, "口パク"),
										Path.Combine(path, "口パク")
									});
									global::x.g.Add(new string[]
									{
										Path.Combine(text2, "表情"),
										Path.Combine(path, "表情")
									});
								}
							}
						}
					}
				}
			}
			global::x.z = string.Empty;
			global::x.aa = string.Empty;
			return flag;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000143E8 File Offset: 0x000125E8
		private static bool a(ref Form1 A_0, string A_1, ref ArrayList A_2, string A_3)
		{
			BW2_three.k k = new BW2_three.k(k);
			k.b = false;
			ParallelOptions parallelOptions = global::x.a();
			k.a = A_0.BackgroundWorker2;
			if (k.a.CancellationPending)
			{
				return true;
			}
			string[] tjsFiles = kirikiri2_fun.getTjsFiles(A_1, "素体", A_3);
			string[] tjsFiles2 = kirikiri2_fun.getTjsFiles(A_1, "表情", A_3);
			string[] tjsFiles3 = kirikiri2_fun.getTjsFiles(A_1, "目パチ", A_3);
			string[] tjsFiles4 = kirikiri2_fun.getTjsFiles(A_1, "口パク", A_3);
			string[] array = tjsFiles;
			checked
			{
				for (int i = 0; i < array.Length; i++)
				{
					BW2_three.k.a a = new BW2_three.k.a(a);
					a.j = array[i];
					a.k = k;
					if (!string.IsNullOrWhiteSpace(a.j))
					{
						string text = Path.GetFileNameWithoutExtension(a.j).Substring(2, 3);
						a.d = new MemoryStream();
						using (Bitmap bitmap = global::x.a(a.j))
						{
							a.f = bitmap.Width;
							a.e = bitmap.Height;
							a.i = bitmap.PixelFormat;
							bitmap.Save(a.d, ImageFormat.Png);
						}
						a.g = new ArrayList();
						a.h = new ArrayList();
						int num = 0;
						int num2 = 0;
						kirikiri2_fun.Tjs_lms_SY tjs_lms_SY2;
						try
						{
							foreach (object obj in A_2)
							{
								kirikiri2_fun.Tjs_lms_SY tjs_lms_SY = (obj != null) ? ((kirikiri2_fun.Tjs_lms_SY)obj) : tjs_lms_SY2;
								if (0 == string.Compare(tjs_lms_SY.PosEorM, "目パチ", StringComparison.Ordinal) && 0 == string.Compare(tjs_lms_SY.PosID, text.Substring(1), StringComparison.Ordinal))
								{
									if (Operators.CompareString(A_3, "l", false) == 0)
									{
										num = tjs_lms_SY.Pos_l_x;
										num2 = tjs_lms_SY.Pos_l_y;
										break;
									}
									if (Operators.CompareString(A_3, "m", false) == 0)
									{
										num = tjs_lms_SY.Pos_m_x;
										num2 = tjs_lms_SY.Pos_m_y;
										break;
									}
									if (Operators.CompareString(A_3, "s", false) == 0)
									{
										num = tjs_lms_SY.Pos_s_x;
										num2 = tjs_lms_SY.Pos_s_y;
										break;
									}
									num = 0;
									num2 = 0;
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
						if (!(0 == num & 0 == num2))
						{
							foreach (string text2 in tjsFiles2)
							{
								if (k.a.CancellationPending)
								{
									return true;
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (k.a.CancellationPending)
									{
										return true;
									}
								}
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
									string strB = fileNameWithoutExtension.Substring(1, 3);
									Interlocked.Add(ref global::x.i, 1);
									if (0 == string.Compare(text, strB, StringComparison.Ordinal))
									{
										bool flag = false;
										foreach (string text3 in tjsFiles3)
										{
											if (k.a.CancellationPending)
											{
												return true;
											}
											while (global::x.a)
											{
												Thread.Sleep(500);
												if (k.a.CancellationPending)
												{
													return true;
												}
											}
											if (!string.IsNullOrWhiteSpace(text3))
											{
												string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(text3);
												string strB2 = fileNameWithoutExtension2.Substring(1, 3);
												if (0 == string.Compare(text, strB2, StringComparison.Ordinal) && Strings.InStr(1, fileNameWithoutExtension2, fileNameWithoutExtension, CompareMethod.Binary) > 0)
												{
													Interlocked.Add(ref global::x.i, 1);
													flag = true;
													Bitmap bitmap2 = global::x.a(text3);
													int num3 = bitmap2.Width / 4;
													int height = bitmap2.Height;
													Bitmap bitmap3 = new Bitmap(a.f, a.e, a.i);
													Graphics graphics = Graphics.FromImage(bitmap3);
													graphics.Clear(Color.Transparent);
													using (Bitmap bitmap4 = global::x.a(text2))
													{
														graphics.DrawImage(bitmap4, 0, 0, bitmap4.Width, bitmap4.Height);
													}
													graphics.Dispose();
													int num4 = num;
													int num5 = num3 + num - 1;
													for (int m = num4; m <= num5; m++)
													{
														int num6 = num2;
														int num7 = height + num2 - 1;
														for (int n = num6; n <= num7; n++)
														{
															bitmap3.SetPixel(m, n, Color.Transparent);
														}
													}
													MemoryStream memoryStream = new MemoryStream();
													bitmap3.Save(memoryStream, ImageFormat.Png);
													bitmap3.Dispose();
													int num8 = 0;
													do
													{
														Rectangle rect = new Rectangle(num3 * num8, 0, num3, height);
														BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
														Bitmap bitmap5 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
														bitmap2.UnlockBits(bitmapData);
														Bitmap bitmap6 = new Bitmap(a.f, a.e, a.i);
														graphics = Graphics.FromImage(bitmap6);
														graphics.DrawImage(Image.FromStream(memoryStream), 0, 0, a.f, a.e);
														graphics.DrawImage(bitmap5, num, num2, bitmap5.Width, bitmap5.Height);
														graphics.Dispose();
														bitmap5.Dispose();
														MemoryStream memoryStream2 = new MemoryStream();
														bitmap6.Save(memoryStream2, ImageFormat.Png);
														a.g.Add(memoryStream2);
														string value = Path.GetFileNameWithoutExtension(text2) + "_" + num8.ToString("D3");
														a.h.Add(value);
														bitmap6.Dispose();
														k.a.ReportProgress(global::x.i);
														num8++;
													}
													while (num8 <= 3);
													bitmap2.Dispose();
													memoryStream.Dispose();
												}
											}
										}
										if (!flag)
										{
											Bitmap bitmap7 = new Bitmap(a.f, a.e, a.i);
											Graphics graphics2 = Graphics.FromImage(bitmap7);
											graphics2.Clear(Color.Transparent);
											using (Bitmap bitmap8 = global::x.a(text2))
											{
												graphics2.DrawImage(bitmap8, 0, 0, bitmap8.Width, bitmap8.Height);
											}
											graphics2.Dispose();
											MemoryStream memoryStream3 = new MemoryStream();
											bitmap7.Save(memoryStream3, ImageFormat.Png);
											bitmap7.Dispose();
											a.g.Add(memoryStream3);
											string value = Path.GetFileNameWithoutExtension(text2);
											a.h.Add(value);
										}
										k.a.ReportProgress(global::x.i);
									}
								}
							}
						}
						if (0 >= a.g.Count)
						{
							foreach (string text4 in tjsFiles2)
							{
								if (k.a.CancellationPending)
								{
									return true;
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (k.a.CancellationPending)
									{
										return true;
									}
								}
								if (!string.IsNullOrWhiteSpace(text4))
								{
									Interlocked.Add(ref global::x.i, 1);
									Bitmap bitmap9 = new Bitmap(a.f, a.e, a.i);
									Graphics graphics3 = Graphics.FromImage(bitmap9);
									graphics3.Clear(Color.Transparent);
									using (Bitmap bitmap10 = global::x.a(text4))
									{
										graphics3.DrawImage(bitmap10, 0, 0, bitmap10.Width, bitmap10.Height);
									}
									graphics3.Dispose();
									MemoryStream memoryStream4 = new MemoryStream();
									bitmap9.Save(memoryStream4, ImageFormat.Png);
									bitmap9.Dispose();
									a.g.Add(memoryStream4);
									string value = Path.GetFileNameWithoutExtension(text4);
									a.h.Add(value);
									k.a.ReportProgress(global::x.i);
								}
							}
						}
						int num10 = 0;
						int num11 = 0;
						try
						{
							foreach (object obj2 in A_2)
							{
								kirikiri2_fun.Tjs_lms_SY tjs_lms_SY3 = (obj2 != null) ? ((kirikiri2_fun.Tjs_lms_SY)obj2) : tjs_lms_SY2;
								if (0 == string.Compare(tjs_lms_SY3.PosEorM, "口パク", StringComparison.Ordinal) && 0 == string.Compare(tjs_lms_SY3.PosID, text.Substring(1), StringComparison.Ordinal))
								{
									if (Operators.CompareString(A_3, "l", false) == 0)
									{
										num10 = tjs_lms_SY3.Pos_l_x;
										num11 = tjs_lms_SY3.Pos_l_y;
										break;
									}
									if (Operators.CompareString(A_3, "m", false) == 0)
									{
										num10 = tjs_lms_SY3.Pos_m_x;
										num11 = tjs_lms_SY3.Pos_m_y;
										break;
									}
									if (Operators.CompareString(A_3, "s", false) == 0)
									{
										num10 = tjs_lms_SY3.Pos_s_x;
										num11 = tjs_lms_SY3.Pos_s_y;
										break;
									}
									num10 = 0;
									num11 = 0;
									break;
								}
							}
						}
						finally
						{
							IEnumerator enumerator2;
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						if (!(0 == num10 & 0 == num11))
						{
							a.a = new ArrayList();
							a.b = new ArrayList();
							foreach (string text5 in tjsFiles4)
							{
								if (k.a.CancellationPending)
								{
									return true;
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (k.a.CancellationPending)
									{
										return true;
									}
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									string fileNameWithoutExtension3 = Path.GetFileNameWithoutExtension(text5);
									string strB3 = fileNameWithoutExtension3.Substring(1, 3);
									if (0 == string.Compare(text, strB3, StringComparison.Ordinal))
									{
										Interlocked.Add(ref global::x.i, 1);
										Bitmap bitmap11 = global::x.a(text5);
										int num13 = bitmap11.Width / 4;
										int height2 = bitmap11.Height;
										int num14 = 0;
										do
										{
											Rectangle rect2 = new Rectangle(num13 * num14, 0, num13, height2);
											BitmapData bitmapData2 = bitmap11.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
											Bitmap bitmap12 = new Bitmap(num13, height2, bitmapData2.Stride, PixelFormat.Format32bppArgb, bitmapData2.Scan0);
											bitmap11.UnlockBits(bitmapData2);
											Bitmap bitmap13 = new Bitmap(a.f, a.e, a.i);
											Graphics graphics4 = Graphics.FromImage(bitmap13);
											graphics4.Clear(Color.Transparent);
											graphics4.DrawImage(bitmap12, num10, num11, bitmap12.Width, bitmap12.Height);
											graphics4.Dispose();
											bitmap12.Dispose();
											MemoryStream memoryStream5 = new MemoryStream();
											bitmap13.Save(memoryStream5, ImageFormat.Png);
											a.a.Add(memoryStream5);
											string value = Path.GetFileNameWithoutExtension(text5) + "_" + num14.ToString("D3");
											a.b.Add(value);
											bitmap13.Dispose();
											k.a.ReportProgress(global::x.i);
											num14++;
										}
										while (num14 <= 3);
									}
								}
							}
							a.c = Path.Combine(A_1, A_3);
							if (!Directory.Exists(a.c))
							{
								Directory.CreateDirectory(a.c);
							}
							Parallel.For(0, a.g.Count, parallelOptions, new Action<int, ParallelLoopState>(a.l));
							a.d.Dispose();
							Parallel.ForEach<object>(a.g.ToArray(), new Action<object>(BW2_three.k));
							a.h.Clear();
							Parallel.ForEach<object>(a.a.ToArray(), new Action<object>(BW2_three.j));
							a.b.Clear();
						}
					}
				}
				return k.b;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00014F88 File Offset: 0x00013188
		public static bool X_info_X_X_info_V1(ref Form1 myForm1, bool bAutoWH = false)
		{
			BW2_three.j j = new BW2_three.j();
			j.d = bAutoWH;
			j.e = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				j.f = global::x.a();
				j.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.j.a a = new BW2_three.j.a(a);
					string text = array2[i];
					a.b = j;
					Interlocked.Add(ref global::x.i, 1);
					if (j.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (j.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						string[] array3 = global::x.ak.Split(Path.GetFileNameWithoutExtension(text));
						j.b = array3[0];
						j.c = Path.Combine(Path.GetDirectoryName(text), j.b) + "_info.txt";
						a.a = new ArrayList(10);
						if (File.Exists(j.c))
						{
							global::x.f.Add(j.c);
							Parallel.ForEach<string>(array, new Action<string>(a.c));
							if (0 < a.a.Count)
							{
								try
								{
									IEnumerator enumerator = a.a.GetEnumerator();
									while (enumerator.MoveNext())
									{
										BW2_three.j.a.a a2 = new BW2_three.j.a.a(a2);
										string text2 = Conversions.ToString(enumerator.Current);
										a2.k = j;
										Interlocked.Add(ref global::x.i, 1);
										ArrayList arrayList = new ArrayList();
										if (Strings.InStr(1, text2, "_info", CompareMethod.Binary) > 0)
										{
											global::x.f.Add(text2);
										}
										else
										{
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											string text3 = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension) + "_info.txt";
											if (File.Exists(text3))
											{
												global::x.f.Add(text3);
												if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.j, ref a2.i))
												{
													ArrayList arrayList2 = new ArrayList();
													kirikiri2_fun.readBaseInfoToArr(j.c, ref arrayList2);
													ArrayList arrayList3 = new ArrayList();
													a2.b = new ArrayList();
													ArrayList arrayList4 = new ArrayList();
													a2.e = new ArrayList();
													a2.a = new ArrayList();
													string text4 = string.Empty;
													try
													{
														foreach (object obj in arrayList2)
														{
															string[] array4 = (string[])obj;
															if (array4.GetUpperBound(0) >= 2)
															{
																if (0 == string.Compare(array4[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array4[2], "base", StringComparison.Ordinal))
																{
																	string[] array5 = new string[7];
																	array5[0] = array4[1];
																	text4 = array4[3];
																	array5[1] = text4;
																	string str = text4;
																	bool bFollowUp = false;
																	ArrayList arrayList5 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList5);
																	array5[2] = layerArr.layer_id;
																	array5[3] = layerArr.left;
																	array5[4] = layerArr.top;
																	array5[5] = layerArr.width;
																	array5[6] = layerArr.height;
																	arrayList3.Add(array5);
																}
																else if (0 == string.Compare(array4[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array4[2], "diff", StringComparison.Ordinal))
																{
																	string[] array6 = new string[8];
																	array6[0] = array4[1];
																	array6[1] = array4[3];
																	text4 = array4[4];
																	array6[7] = text4;
																	string str2 = text4;
																	bool bFollowUp2 = false;
																	ArrayList arrayList5 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList5);
																	array6[2] = layerArr2.layer_id;
																	array6[3] = layerArr2.left;
																	array6[4] = layerArr2.top;
																	array6[5] = layerArr2.width;
																	array6[6] = layerArr2.height;
																	a2.b.Add(array6);
																}
																else if (0 == string.Compare(array4[0], "face", StringComparison.Ordinal))
																{
																	string[] array7 = new string[7];
																	array7[0] = array4[1];
																	text4 = array4[3];
																	array7[6] = text4;
																	string str3 = text4;
																	bool bFollowUp3 = false;
																	ArrayList arrayList5 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(str3, ref arrayList, bFollowUp3, ref arrayList5);
																	array7[1] = layerArr3.layer_id;
																	array7[2] = layerArr3.left;
																	array7[3] = layerArr3.top;
																	array7[4] = layerArr3.width;
																	array7[5] = layerArr3.height;
																	bool flag = false;
																	if (Strings.InStr(1, text4, "/", CompareMethod.Binary) > 0)
																	{
																		string[] array8 = text4.Split(new char[]
																		{
																			'/'
																		});
																		text4 = array8[1];
																		if (0 == string.Compare("表情", array8[0], StringComparison.Ordinal))
																		{
																			flag = true;
																		}
																	}
																	if (flag)
																	{
																		arrayList4.Add(array7);
																	}
																	else
																	{
																		a2.e.Add(array7);
																	}
																}
																else if (0 == string.Compare(array4[0], "add", StringComparison.Ordinal))
																{
																	string[] array9 = new string[7];
																	array9[0] = array4[1];
																	text4 = array4[2];
																	array9[6] = text4;
																	string str4 = text4;
																	bool bFollowUp4 = false;
																	ArrayList arrayList5 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr4 = kirikiri2_fun.getLayerArr(str4, ref arrayList, bFollowUp4, ref arrayList5);
																	array9[1] = layerArr4.layer_id;
																	array9[2] = layerArr4.left;
																	array9[3] = layerArr4.top;
																	array9[4] = layerArr4.width;
																	array9[5] = layerArr4.height;
																	a2.a.Add(array9);
																}
															}
														}
													}
													finally
													{
														IEnumerator enumerator2;
														if (enumerator2 is IDisposable)
														{
															(enumerator2 as IDisposable).Dispose();
														}
													}
													a2.h = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
													j.a.ReportProgress(0);
													a2.c = new ArrayList();
													a2.d = new ArrayList();
													Parallel.ForEach<object>(arrayList4.ToArray(), j.f, new Action<object, ParallelLoopState>(a2.l));
													j.a.ReportProgress(global::x.i);
													a2.f = new ArrayList();
													a2.g = new ArrayList();
													Parallel.For(0, a2.c.Count, j.f, new Action<int, ParallelLoopState>(a2.l));
													Parallel.ForEach<object>(a2.c.ToArray(), new Action<object>(BW2_three.i));
													a2.c.Clear();
													a2.d.Clear();
													global::x.j = arrayList3.Count + a2.f.Count;
													j.a.ReportProgress(global::x.i);
													try
													{
														IEnumerator enumerator3 = arrayList3.GetEnumerator();
														while (enumerator3.MoveNext())
														{
															BW2_three.j.a.a.a a3 = new BW2_three.j.a.a.a(a3);
															a3.a = (string[])enumerator3.Current;
															Interlocked.Add(ref global::x.i, 1);
															if (j.a.CancellationPending)
															{
																return true;
															}
															while (global::x.a)
															{
																Thread.Sleep(500);
																if (j.a.CancellationPending)
																{
																	return true;
																}
															}
															if (!string.IsNullOrWhiteSpace(a3.a[0]))
															{
																string text5 = global::x.a(a2.h, "_" + a3.a[2]);
																if (File.Exists(text5))
																{
																	BW2_three.j.a.a.a.a a4 = new BW2_three.j.a.a.a.a();
																	a4.i = a3;
																	a4.h = a2;
																	a4.g = j;
																	global::x.f.Add(text5);
																	a4.f = new MemoryStream();
																	using (Bitmap bitmap = global::x.a(text5))
																	{
																		bitmap.Save(a4.f, ImageFormat.Png);
																	}
																	a4.e = a3.a[0];
																	a4.c = Conversions.ToInteger(a3.a[3]);
																	a4.d = Conversions.ToInteger(a3.a[4]);
																	a4.b = Conversions.ToInteger(a3.a[5]);
																	a4.a = Conversions.ToInteger(a3.a[6]);
																	Parallel.For(0, a2.f.Count, j.f, new Action<int, ParallelLoopState>(a4.j));
																	a4.f.Dispose();
																}
															}
														}
													}
													finally
													{
														IEnumerator enumerator3;
														if (enumerator3 is IDisposable)
														{
															(enumerator3 as IDisposable).Dispose();
														}
													}
													Parallel.ForEach<object>(a2.f.ToArray(), new Action<object>(BW2_three.h));
													a2.f.Clear();
													a2.g.Clear();
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
							}
						}
					}
				}
				global::x.z = string.Empty;
				return j.e;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000158CC File Offset: 0x00013ACC
		public static bool X_info_X_X_stand(ref Form1 myForm1)
		{
			BW2_three.c c = new BW2_three.c();
			c.d = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				c.e = global::x.a();
				c.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.c.a a = new BW2_three.c.a(a);
					string text = array2[i];
					a.b = c;
					Interlocked.Add(ref global::x.i, 1);
					if (c.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (c.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						string[] array3 = global::x.ak.Split(Path.GetFileNameWithoutExtension(text));
						c.b = array3[0];
						c.c = Path.Combine(Path.GetDirectoryName(text), c.b) + "_info.txt";
						a.a = new ArrayList(10);
						if (File.Exists(c.c))
						{
							global::x.f.Add(c.c);
							Parallel.ForEach<string>(array, new Action<string>(a.c));
							if (0 < a.a.Count)
							{
								try
								{
									IEnumerator enumerator = a.a.GetEnumerator();
									while (enumerator.MoveNext())
									{
										BW2_three.c.a.a a2 = new BW2_three.c.a.a(a2);
										string text2 = Conversions.ToString(enumerator.Current);
										a2.g = c;
										Interlocked.Add(ref global::x.i, 1);
										ArrayList arrayList = new ArrayList();
										if (Strings.InStr(1, text2, "_info", CompareMethod.Binary) > 0)
										{
											global::x.f.Add(text2);
										}
										else
										{
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											string text3 = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension) + "_info.txt";
											if (File.Exists(text3))
											{
												global::x.f.Add(text3);
												if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.f, ref a2.e))
												{
													ArrayList arrayList2 = new ArrayList();
													kirikiri2_fun.readBaseInfoToArr(c.c, ref arrayList2);
													ArrayList arrayList3 = new ArrayList();
													ArrayList arrayList4 = new ArrayList();
													a2.c = new ArrayList();
													ArrayList arrayList5 = new ArrayList();
													string text4 = string.Empty;
													try
													{
														foreach (object obj in arrayList2)
														{
															string[] array4 = (string[])obj;
															if (array4.GetUpperBound(0) >= 2 && 0 != string.Compare(array4[0], "facegroup", StringComparison.Ordinal))
															{
																if (0 == string.Compare(array4[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array4[2], "base", StringComparison.Ordinal))
																{
																	string[] array5 = new string[7];
																	array5[0] = array4[1];
																	text4 = array4[3];
																	array5[1] = text4;
																	string str = text4;
																	bool bFollowUp = false;
																	ArrayList arrayList6 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList6);
																	array5[2] = layerArr.layer_id;
																	array5[3] = layerArr.left;
																	array5[4] = layerArr.top;
																	array5[5] = layerArr.width;
																	array5[6] = layerArr.height;
																	arrayList3.Add(array5);
																}
																else if (0 == string.Compare(array4[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array4[2], "diff", StringComparison.Ordinal))
																{
																	string[] array6 = new string[8];
																	array6[0] = array4[1];
																	array6[1] = array4[3];
																	text4 = array4[4];
																	array6[7] = text4;
																	string str2 = text4;
																	bool bFollowUp2 = false;
																	ArrayList arrayList6 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList6);
																	array6[2] = layerArr2.layer_id;
																	array6[3] = layerArr2.left;
																	array6[4] = layerArr2.top;
																	array6[5] = layerArr2.width;
																	array6[6] = layerArr2.height;
																	arrayList4.Add(array6);
																}
																else if (0 == string.Compare(array4[0], "fgname", StringComparison.Ordinal))
																{
																	string[] array7 = new string[7];
																	array7[0] = array4[1];
																	text4 = array4[2];
																	array7[6] = text4;
																	string str3 = text4;
																	bool bFollowUp3 = false;
																	ArrayList arrayList6 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(str3, ref arrayList, bFollowUp3, ref arrayList6);
																	array7[1] = layerArr3.layer_id;
																	array7[2] = layerArr3.left;
																	array7[3] = layerArr3.top;
																	array7[4] = layerArr3.width;
																	array7[5] = layerArr3.height;
																	a2.c.Add(array7);
																}
																else if (0 == string.Compare(array4[0], "fgalias", StringComparison.Ordinal))
																{
																	arrayList5.Add(array4);
																}
															}
														}
													}
													finally
													{
														IEnumerator enumerator2;
														if (enumerator2 is IDisposable)
														{
															(enumerator2 as IDisposable).Dispose();
														}
													}
													a2.d = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
													c.a.ReportProgress(0);
													a2.a = new ArrayList();
													a2.b = new ArrayList();
													Parallel.ForEach<object>(arrayList5.ToArray(), c.e, new Action<object, ParallelLoopState>(a2.h));
													global::x.j = arrayList3.Count + arrayList4.Count;
													c.a.ReportProgress(global::x.i);
													try
													{
														IEnumerator enumerator3 = arrayList3.GetEnumerator();
														while (enumerator3.MoveNext())
														{
															BW2_three.c.a.a.a a3 = new BW2_three.c.a.a.a(a3);
															a3.a = (string[])enumerator3.Current;
															Interlocked.Add(ref global::x.i, 1);
															if (c.a.CancellationPending)
															{
																return true;
															}
															while (global::x.a)
															{
																Thread.Sleep(500);
																if (c.a.CancellationPending)
																{
																	return true;
																}
															}
															if (!string.IsNullOrWhiteSpace(a3.a[0]))
															{
																string text5 = global::x.a(a2.d, "_" + a3.a[2]);
																if (File.Exists(text5))
																{
																	BW2_three.c.a.a.a.a a4 = new BW2_three.c.a.a.a.a();
																	a4.g = a3;
																	a4.f = a2;
																	a4.e = c;
																	global::x.f.Add(text5);
																	a4.d = new MemoryStream();
																	using (Bitmap bitmap = global::x.a(text5))
																	{
																		bitmap.Save(a4.d, ImageFormat.Png);
																	}
																	a4.c = a3.a[0];
																	a4.a = Conversions.ToInteger(a3.a[3]);
																	a4.b = Conversions.ToInteger(a3.a[4]);
																	int num = Conversions.ToInteger(a3.a[5]);
																	int num2 = Conversions.ToInteger(a3.a[6]);
																	Parallel.ForEach<object>(arrayList4.ToArray(), c.e, new Action<object, ParallelLoopState>(a4.h));
																	a4.d.Dispose();
																}
															}
														}
													}
													finally
													{
														IEnumerator enumerator3;
														if (enumerator3 is IDisposable)
														{
															(enumerator3 as IDisposable).Dispose();
														}
													}
													Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.g));
													a2.a.Clear();
													a2.b.Clear();
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
							}
						}
					}
				}
				global::x.z = string.Empty;
				return c.d;
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000160A4 File Offset: 0x000142A4
		public static bool X_info_X_txt_ddfff(ref Form1 myForm1, bool bNoBase = false)
		{
			BW2_three.d d = new BW2_three.d();
			d.d = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				d.e = global::x.a();
				d.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.d.a a = new BW2_three.d.a(a);
					string text = array2[i];
					a.b = d;
					Interlocked.Add(ref global::x.i, 1);
					if (d.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (d.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						d.b = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, d.b, "_info", CompareMethod.Binary) > 0)
						{
							d.c = text;
							a.a = new ArrayList(10);
							if (File.Exists(d.c))
							{
								global::x.f.Add(d.c);
								Parallel.ForEach<string>(array, new Action<string>(a.c));
								if (0 < a.a.Count)
								{
									try
									{
										IEnumerator enumerator = a.a.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three.d.a.a a2 = new BW2_three.d.a.a(a2);
											string text2 = Conversions.ToString(enumerator.Current);
											a2.g = d;
											Interlocked.Add(ref global::x.i, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.f, ref a2.e))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(d.c, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												a2.c = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												string text3 = string.Empty;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array3 = (string[])obj;
														if (array3.GetUpperBound(0) >= 2 && 0 != string.Compare(array3[0], "facegroup", StringComparison.Ordinal) && 0 != string.Compare(array3[0], "addgroup", StringComparison.Ordinal) && 0 != string.Compare(array3[0], "add", StringComparison.Ordinal))
														{
															if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "base", StringComparison.Ordinal))
															{
																string[] array4 = new string[7];
																array4[0] = array3[1];
																text3 = array3[3];
																array4[1] = text3;
																bool flag = false;
																try
																{
																	foreach (object obj2 in arrayList3)
																	{
																		string[] array5 = (string[])obj2;
																		if (0 == string.Compare(array5[0], array4[0], StringComparison.Ordinal) && 0 == string.Compare(array5[1], array4[1], StringComparison.Ordinal))
																		{
																			flag = true;
																			break;
																		}
																	}
																}
																finally
																{
																	IEnumerator enumerator3;
																	if (enumerator3 is IDisposable)
																	{
																		(enumerator3 as IDisposable).Dispose();
																	}
																}
																if (!flag)
																{
																	string str = text3;
																	bool bFollowUp = false;
																	ArrayList arrayList6 = null;
																	kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList6);
																	array4[2] = layerArr.layer_id;
																	array4[3] = layerArr.left;
																	array4[4] = layerArr.top;
																	array4[5] = layerArr.width;
																	array4[6] = layerArr.height;
																	arrayList3.Add(array4);
																}
															}
															else if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "diff", StringComparison.Ordinal))
															{
																string[] array6 = new string[8];
																array6[0] = array3[1];
																array6[1] = array3[3];
																text3 = array3[4];
																array6[7] = text3;
																bool flag2 = false;
																string str2 = text3;
																bool bFollowUp2 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList6);
																array6[2] = layerArr2.layer_id;
																array6[3] = layerArr2.left;
																array6[4] = layerArr2.top;
																array6[5] = layerArr2.width;
																array6[6] = layerArr2.height;
																if (Strings.InStr(1, text3, "/", CompareMethod.Binary) > 0)
																{
																	flag2 = true;
																}
																if (bNoBase && flag2)
																{
																	arrayList3.Add(array6);
																}
																else
																{
																	arrayList4.Add(array6);
																}
															}
															else if (0 == string.Compare(array3[0], "fgname", StringComparison.Ordinal))
															{
																string[] array7 = new string[7];
																array7[0] = array3[1];
																text3 = array3[2];
																array7[6] = text3;
																string str3 = text3;
																bool bFollowUp3 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(str3, ref arrayList, bFollowUp3, ref arrayList6);
																array7[1] = layerArr3.layer_id;
																array7[2] = layerArr3.left;
																array7[3] = layerArr3.top;
																array7[4] = layerArr3.width;
																array7[5] = layerArr3.height;
																a2.c.Add(array7);
															}
															else if (0 == string.Compare(array3[0], "fgalias", StringComparison.Ordinal))
															{
																arrayList5.Add(array3);
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator2;
													if (enumerator2 is IDisposable)
													{
														(enumerator2 as IDisposable).Dispose();
													}
												}
												a2.d = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												d.a.ReportProgress(0);
												a2.a = new ArrayList();
												a2.b = new ArrayList();
												Parallel.ForEach<object>(arrayList5.ToArray(), d.e, new Action<object, ParallelLoopState>(a2.h));
												global::x.j = arrayList3.Count + arrayList4.Count;
												d.a.ReportProgress(global::x.i);
												if (bNoBase && (0 == arrayList3.Count & 0 < arrayList4.Count))
												{
													try
													{
														foreach (object obj3 in arrayList4)
														{
															string[] value = (string[])obj3;
															arrayList3.Add(value);
														}
													}
													finally
													{
														IEnumerator enumerator4;
														if (enumerator4 is IDisposable)
														{
															(enumerator4 as IDisposable).Dispose();
														}
													}
													arrayList4.Clear();
												}
												try
												{
													IEnumerator enumerator5 = arrayList3.GetEnumerator();
													while (enumerator5.MoveNext())
													{
														BW2_three.d.a.a.a a3 = new BW2_three.d.a.a.a(a3);
														a3.a = (string[])enumerator5.Current;
														Interlocked.Add(ref global::x.i, 1);
														if (d.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (d.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(a3.a[0]))
														{
															string text4 = global::x.a(a2.d, "_" + a3.a[2]);
															if (File.Exists(text4))
															{
																BW2_three.d.a.a.a.a a4 = new BW2_three.d.a.a.a.a();
																a4.h = a3;
																a4.g = a2;
																a4.f = d;
																global::x.f.Add(text4);
																a4.e = new MemoryStream();
																using (Bitmap bitmap = global::x.a(text4))
																{
																	bitmap.Save(a4.e, ImageFormat.Png);
																}
																a4.d = a3.a[0];
																a4.a = Conversions.ToInteger(a3.a[3]);
																a4.b = Conversions.ToInteger(a3.a[4]);
																int num = Conversions.ToInteger(a3.a[5]);
																int num2 = Conversions.ToInteger(a3.a[6]);
																a4.c = 0;
																Parallel.ForEach<object>(arrayList4.ToArray(), d.e, new Action<object, ParallelLoopState>(a4.i));
																if (0 == a4.c)
																{
																	Parallel.For(0, a2.a.Count, d.e, new Action<int, ParallelLoopState>(a4.i));
																}
																a4.e.Dispose();
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator5;
													if (enumerator5 is IDisposable)
													{
														(enumerator5 as IDisposable).Dispose();
													}
												}
												Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.f));
												a2.a.Clear();
												a2.b.Clear();
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
								}
							}
						}
					}
				}
				global::x.z = string.Empty;
				return d.d;
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000169A4 File Offset: 0x00014BA4
		public static bool X_info_X_txt_ddfa(ref Form1 myForm1)
		{
			BW2_three.h h = new BW2_three.h();
			h.d = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				h.e = global::x.a();
				h.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.h.a a = new BW2_three.h.a(a);
					string text = array2[i];
					a.b = h;
					Interlocked.Add(ref global::x.i, 1);
					if (h.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (h.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						h.b = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, h.b, "_info", CompareMethod.Binary) > 0)
						{
							h.c = text;
							a.a = new ArrayList(10);
							if (File.Exists(h.c))
							{
								global::x.f.Add(h.c);
								Parallel.ForEach<string>(array, new Action<string>(a.c));
								if (0 < a.a.Count)
								{
									try
									{
										IEnumerator enumerator = a.a.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three.h.a.a a2 = new BW2_three.h.a.a(a2);
											string text2 = Conversions.ToString(enumerator.Current);
											a2.h = h;
											Interlocked.Add(ref global::x.i, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.f, ref a2.e))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(h.c, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												a2.c = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												a2.g = string.Empty;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array3 = (string[])obj;
														if (array3.GetUpperBound(0) >= 2)
														{
															if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "base", StringComparison.Ordinal))
															{
																string[] array4 = new string[7];
																array4[0] = array3[1];
																a2.g = array3[3];
																array4[1] = a2.g;
																string g = a2.g;
																bool bFollowUp = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(g, ref arrayList, bFollowUp, ref arrayList6);
																array4[2] = layerArr.layer_id;
																array4[3] = layerArr.left;
																array4[4] = layerArr.top;
																array4[5] = layerArr.width;
																array4[6] = layerArr.height;
																arrayList3.Add(array4);
															}
															else if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "diff", StringComparison.Ordinal))
															{
																string[] array5 = new string[9];
																array5[0] = array3[1];
																array5[1] = array3[3];
																a2.g = array3[4];
																array5[7] = a2.g;
																string g2 = a2.g;
																bool bFollowUp2 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(g2, ref arrayList, bFollowUp2, ref arrayList6);
																array5[2] = layerArr2.layer_id;
																array5[3] = layerArr2.left;
																array5[4] = layerArr2.top;
																array5[5] = layerArr2.width;
																array5[6] = layerArr2.height;
																array5[8] = layerArr2.group_layer_id;
																arrayList4.Add(array5);
															}
															else if (0 == string.Compare(array3[0], "face", StringComparison.Ordinal))
															{
																string[] array6 = new string[7];
																array6[0] = array3[1];
																a2.g = array3[3];
																array6[6] = a2.g;
																string g3 = a2.g;
																bool bFollowUp3 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(g3, ref arrayList, bFollowUp3, ref arrayList6);
																array6[1] = layerArr3.layer_id;
																array6[2] = layerArr3.left;
																array6[3] = layerArr3.top;
																array6[4] = layerArr3.width;
																array6[5] = layerArr3.height;
																a2.c.Add(array6);
															}
															else if (0 == string.Compare(array3[0], "add", StringComparison.Ordinal))
															{
																string[] array7 = new string[7];
																array7[0] = array3[1];
																a2.g = array3[2];
																array7[6] = a2.g;
																string g4 = a2.g;
																bool bFollowUp4 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr4 = kirikiri2_fun.getLayerArr(g4, ref arrayList, bFollowUp4, ref arrayList6);
																array7[1] = layerArr4.layer_id;
																array7[2] = layerArr4.left;
																array7[3] = layerArr4.top;
																array7[4] = layerArr4.width;
																array7[5] = layerArr4.height;
																arrayList5.Add(array7);
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator2;
													if (enumerator2 is IDisposable)
													{
														(enumerator2 as IDisposable).Dispose();
													}
												}
												a2.d = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												h.a.ReportProgress(0);
												a2.a = new ArrayList();
												a2.b = new ArrayList();
												ArrayList arrayList7 = new ArrayList();
												string text3 = string.Empty;
												kirikiri2_compare_group_layer_id_v1 comparer = new kirikiri2_compare_group_layer_id_v1();
												arrayList4.Sort(comparer);
												try
												{
													foreach (object obj2 in arrayList4)
													{
														string[] array8 = (string[])obj2;
														Interlocked.Add(ref global::x.i, 1);
														if (h.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (h.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array8[0]))
														{
															if (0 != string.Compare(array8[0] + array8[1], text3, StringComparison.Ordinal) && Strings.InStr(1, array8[7], "$", CompareMethod.Binary) <= 0)
															{
																text3 = array8[0] + array8[1];
																if (!global::x.b(ref arrayList7, text3))
																{
																	arrayList7.Add(text3);
																	Bitmap bitmap = new Bitmap(a2.f, a2.e, PixelFormat.Format32bppArgb);
																	Graphics graphics = Graphics.FromImage(bitmap);
																	graphics.Clear(Color.Transparent);
																	bool flag = true;
																	string text4 = global::x.a(a2.d, "_" + array8[2]);
																	if (File.Exists(text4))
																	{
																		global::x.f.Add(text4);
																		Bitmap bitmap2 = global::x.a(text4);
																		graphics.DrawImage(bitmap2, Conversions.ToInteger(array8[3]), Conversions.ToInteger(array8[4]), bitmap2.Width, bitmap2.Height);
																		ArrayList arrayList8 = new ArrayList();
																		try
																		{
																			foreach (object obj3 in arrayList4)
																			{
																				string[] array9 = (string[])obj3;
																				Interlocked.Add(ref global::x.i, 1);
																				if (h.a.CancellationPending)
																				{
																					return true;
																				}
																				while (global::x.a)
																				{
																					Thread.Sleep(500);
																					if (h.a.CancellationPending)
																					{
																						return true;
																					}
																				}
																				if (!string.IsNullOrWhiteSpace(array9[0]))
																				{
																					if (0 == string.Compare(array8[0], array9[0], StringComparison.Ordinal) && 0 == string.Compare(array8[1], array9[1], StringComparison.Ordinal) && 0 != string.Compare(array8[7], array9[7], StringComparison.Ordinal))
																					{
																						if (Strings.InStr(1, array9[7], "$", CompareMethod.Binary) > 0)
																						{
																							string text5 = Conversions.ToString(array9[7].Last<char>());
																							flag = false;
																							if (Versioned.IsNumeric(text5))
																							{
																								if (!global::x.b(ref arrayList8, text5))
																								{
																									arrayList8.Add(text5);
																								}
																							}
																						}
																						else
																						{
																							string text6 = global::x.a(a2.d, "_" + array9[2]);
																							if (File.Exists(text6))
																							{
																								arrayList7.Add(array9[0] + array9[1]);
																								global::x.f.Add(text6);
																								Bitmap bitmap3 = global::x.a(text6);
																								graphics.DrawImage(bitmap3, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitmap3.Width, bitmap3.Height);
																								bitmap3.Dispose();
																							}
																						}
																					}
																				}
																			}
																		}
																		finally
																		{
																			IEnumerator enumerator4;
																			if (enumerator4 is IDisposable)
																			{
																				(enumerator4 as IDisposable).Dispose();
																			}
																		}
																		if (!flag)
																		{
																			MemoryStream memoryStream = new MemoryStream();
																			bitmap.Save(memoryStream, ImageFormat.Png);
																			try
																			{
																				foreach (object value in arrayList8)
																				{
																					string strA = Conversions.ToString(value);
																					Bitmap bitmap4 = (Bitmap)Image.FromStream(memoryStream);
																					Graphics graphics2 = Graphics.FromImage(bitmap4);
																					string text7 = string.Format("{0}_{1}", array8[0], array8[1]);
																					try
																					{
																						foreach (object obj4 in arrayList4)
																						{
																							string[] array10 = (string[])obj4;
																							if (0 == string.Compare(array8[0], array10[0], StringComparison.Ordinal) && 0 == string.Compare(array8[1], array10[1], StringComparison.Ordinal) && Strings.InStr(1, array10[7], "$", CompareMethod.Binary) > 0)
																							{
																								string text8 = Conversions.ToString(array10[7].Last<char>());
																								if (Versioned.IsNumeric(text8) && 0 == string.Compare(strA, text8, StringComparison.Ordinal))
																								{
																									string[] array11 = array10[7].Split(new char[]
																									{
																										'$'
																									});
																									a2.g = array11[0];
																									if (Strings.InStr(1, a2.g, "/", CompareMethod.Binary) > 0)
																									{
																										array11 = a2.g.Split(new char[]
																										{
																											'/'
																										});
																										a2.g = array11.Last<string>();
																									}
																									text7 = string.Format("{0}_{1}_{2}", array10[0], array10[1], a2.g);
																									string text9 = global::x.a(a2.d, "_" + array10[2]);
																									if (File.Exists(text9))
																									{
																										global::x.f.Add(text9);
																										Bitmap bitmap5 = global::x.a(text9);
																										graphics2.DrawImage(bitmap5, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitmap5.Width, bitmap5.Height);
																										bitmap5.Dispose();
																									}
																								}
																							}
																						}
																					}
																					finally
																					{
																						IEnumerator enumerator6;
																						if (enumerator6 is IDisposable)
																						{
																							(enumerator6 as IDisposable).Dispose();
																						}
																					}
																					graphics2.Dispose();
																					MemoryStream memoryStream2 = new MemoryStream();
																					bitmap4.Save(memoryStream2, ImageFormat.Png);
																					a2.a.Add(memoryStream2);
																					string[] value2 = new string[]
																					{
																						array8[0],
																						text7
																					};
																					a2.b.Add(value2);
																					bitmap4.Dispose();
																				}
																			}
																			finally
																			{
																				IEnumerator enumerator5;
																				if (enumerator5 is IDisposable)
																				{
																					(enumerator5 as IDisposable).Dispose();
																				}
																			}
																			memoryStream.Dispose();
																		}
																		bitmap2.Dispose();
																	}
																	graphics.Dispose();
																	if (flag)
																	{
																		MemoryStream memoryStream3 = new MemoryStream();
																		bitmap.Save(memoryStream3, ImageFormat.Png);
																		a2.a.Add(memoryStream3);
																		string[] value3 = new string[]
																		{
																			array8[0],
																			string.Format("{0}_{1}", array8[0], array8[1])
																		};
																		a2.b.Add(value3);
																	}
																	bitmap.Dispose();
																	h.a.ReportProgress(global::x.i);
																	Thread.Sleep(global::x.c);
																}
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator3;
													if (enumerator3 is IDisposable)
													{
														(enumerator3 as IDisposable).Dispose();
													}
												}
												arrayList7.Clear();
												ArrayList arrayList9 = new ArrayList();
												ArrayList arrayList10 = new ArrayList();
												try
												{
													foreach (object obj5 in arrayList3)
													{
														string[] array12 = (string[])obj5;
														Interlocked.Add(ref global::x.i, 1);
														if (h.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (h.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array12[0]))
														{
															if (Strings.InStr(1, array12[1], "$", CompareMethod.Binary) <= 0 && 0 != string.Compare(array12[0] + array12[1], text3, StringComparison.Ordinal))
															{
																text3 = array12[0] + array12[1];
																if (!global::x.b(ref arrayList7, text3))
																{
																	arrayList7.Add(text3);
																	Bitmap bitmap6 = new Bitmap(a2.f, a2.e, PixelFormat.Format32bppArgb);
																	Graphics graphics3 = Graphics.FromImage(bitmap6);
																	graphics3.Clear(Color.Transparent);
																	string text10 = global::x.a(a2.d, "_" + array12[2]);
																	if (File.Exists(text10))
																	{
																		global::x.f.Add(text10);
																		using (Bitmap bitmap7 = global::x.a(text10))
																		{
																			graphics3.DrawImage(bitmap7, Conversions.ToInteger(array12[3]), Conversions.ToInteger(array12[4]), bitmap7.Width, bitmap7.Height);
																		}
																		try
																		{
																			foreach (object obj6 in arrayList3)
																			{
																				string[] array13 = (string[])obj6;
																				Interlocked.Add(ref global::x.i, 1);
																				if (h.a.CancellationPending)
																				{
																					return true;
																				}
																				while (global::x.a)
																				{
																					Thread.Sleep(500);
																					if (h.a.CancellationPending)
																					{
																						return true;
																					}
																				}
																				if (!string.IsNullOrWhiteSpace(array13[0]))
																				{
																					if (Strings.InStr(1, array13[1], "$", CompareMethod.Binary) <= 0 && 0 == string.Compare(array12[0], array13[0], StringComparison.Ordinal) && 0 != string.Compare(array12[1], array13[1], StringComparison.Ordinal))
																					{
																						arrayList7.Add(array13[0] + array13[1]);
																						string text11 = global::x.a(a2.d, "_" + array13[2]);
																						if (File.Exists(text11))
																						{
																							global::x.f.Add(text11);
																							using (Bitmap bitmap8 = global::x.a(text11))
																							{
																								graphics3.DrawImage(bitmap8, Conversions.ToInteger(array13[3]), Conversions.ToInteger(array13[4]), bitmap8.Width, bitmap8.Height);
																							}
																						}
																					}
																				}
																			}
																		}
																		finally
																		{
																			IEnumerator enumerator8;
																			if (enumerator8 is IDisposable)
																			{
																				(enumerator8 as IDisposable).Dispose();
																			}
																		}
																	}
																	graphics3.Dispose();
																	MemoryStream memoryStream4 = new MemoryStream();
																	bitmap6.Save(memoryStream4, ImageFormat.Png);
																	arrayList9.Add(memoryStream4);
																	arrayList10.Add(array12[0]);
																	bitmap6.Dispose();
																	h.a.ReportProgress(global::x.i);
																	Thread.Sleep(global::x.c);
																}
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator7;
													if (enumerator7 is IDisposable)
													{
														(enumerator7 as IDisposable).Dispose();
													}
												}
												int num = 0;
												int num2 = arrayList9.Count - 1;
												for (int j = num; j <= num2; j++)
												{
													BW2_three.h.a.a.a a3 = new BW2_three.h.a.a.a(a3);
													a3.d = a2;
													a3.c = h;
													Interlocked.Add(ref global::x.i, 1);
													if (h.a.CancellationPending)
													{
														return true;
													}
													while (global::x.a)
													{
														Thread.Sleep(500);
														if (h.a.CancellationPending)
														{
															return true;
														}
													}
													a3.b = (MemoryStream)arrayList9[j];
													a3.a = Conversions.ToString(arrayList10[j]);
													Parallel.For(0, a2.a.Count, h.e, new Action<int, ParallelLoopState>(a3.e));
													a3.b.Dispose();
												}
												Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.e));
												a2.a.Clear();
												a2.b.Clear();
												Parallel.ForEach<object>(arrayList9.ToArray(), new Action<object>(BW2_three.d));
												arrayList10.Clear();
												arrayList10.Clear();
												Parallel.ForEach<object>(arrayList3.ToArray(), h.e, new Action<object, ParallelLoopState>(a2.j));
												Parallel.ForEach<object>(arrayList5.ToArray(), h.e, new Action<object, ParallelLoopState>(a2.i));
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
								}
							}
						}
					}
				}
				global::x.z = string.Empty;
				return h.d;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00017B34 File Offset: 0x00015D34
		public static bool X_info_X_txt_df(ref Form1 myForm1)
		{
			BW2_three.b b = new BW2_three.b();
			b.d = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = global::x.a();
				b.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.b.a a = new BW2_three.b.a(a);
					string text = array2[i];
					a.b = b;
					Interlocked.Add(ref global::x.i, 1);
					if (b.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (b.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						b.b = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, b.b, "_info", CompareMethod.Binary) > 0)
						{
							b.c = text;
							a.a = new ArrayList(10);
							if (File.Exists(b.c))
							{
								global::x.f.Add(b.c);
								Parallel.ForEach<string>(array, new Action<string>(a.c));
								if (0 < a.a.Count)
								{
									try
									{
										IEnumerator enumerator = a.a.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three.b.a.a a2 = new BW2_three.b.a.a(a2);
											string text2 = Conversions.ToString(enumerator.Current);
											a2.f = b;
											Interlocked.Add(ref global::x.i, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref a2.e, ref a2.d))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(b.c, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												string text3 = string.Empty;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array3 = (string[])obj;
														if (array3.GetUpperBound(0) >= 2)
														{
															if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "diff", StringComparison.Ordinal))
															{
																string[] array4 = new string[9];
																array4[0] = array3[1];
																array4[1] = array3[3];
																text3 = array3[4];
																array4[7] = text3;
																string str = text3;
																bool bFollowUp = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList6);
																array4[2] = layerArr.layer_id;
																array4[3] = layerArr.left;
																array4[4] = layerArr.top;
																array4[5] = layerArr.width;
																array4[6] = layerArr.height;
																array4[8] = layerArr.group_layer_id;
																arrayList3.Add(array4);
															}
															else if (0 == string.Compare(array3[0], "face", StringComparison.Ordinal))
															{
																string[] array5 = new string[7];
																array5[0] = array3[1];
																text3 = array3[3];
																array5[6] = text3;
																string str2 = text3;
																bool bFollowUp2 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList6);
																array5[1] = layerArr2.layer_id;
																array5[2] = layerArr2.left;
																array5[3] = layerArr2.top;
																array5[4] = layerArr2.width;
																array5[5] = layerArr2.height;
																arrayList4.Add(array5);
															}
															else if (0 == string.Compare(array3[0], "add", StringComparison.Ordinal))
															{
																string[] array6 = new string[7];
																array6[0] = array3[1];
																text3 = array3[2];
																array6[6] = text3;
																string str3 = text3;
																bool bFollowUp3 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(str3, ref arrayList, bFollowUp3, ref arrayList6);
																array6[1] = layerArr3.layer_id;
																array6[2] = layerArr3.left;
																array6[3] = layerArr3.top;
																array6[4] = layerArr3.width;
																array6[5] = layerArr3.height;
																arrayList5.Add(array6);
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator2;
													if (enumerator2 is IDisposable)
													{
														(enumerator2 as IDisposable).Dispose();
													}
												}
												a2.c = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												b.a.ReportProgress(0);
												a2.a = new ArrayList();
												a2.b = new ArrayList();
												string text4 = string.Empty;
												try
												{
													foreach (object obj2 in arrayList4)
													{
														string[] array7 = (string[])obj2;
														Interlocked.Add(ref global::x.i, 1);
														if (b.a.CancellationPending)
														{
															b.d = true;
															break;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (b.a.CancellationPending)
															{
																b.d = true;
																goto IL_74C;
															}
														}
														if (!string.IsNullOrWhiteSpace(array7[0]))
														{
															if (0 != string.Compare(array7[0], text4, StringComparison.Ordinal))
															{
																Bitmap bitmap = new Bitmap(a2.e, a2.d, PixelFormat.Format32bppArgb);
																Graphics graphics = Graphics.FromImage(bitmap);
																graphics.Clear(Color.Transparent);
																string text5 = global::x.a(a2.c, "_" + array7[1]);
																if (File.Exists(text5))
																{
																	ArrayList f = global::x.f;
																	lock (f)
																	{
																		global::x.f.Add(text5);
																	}
																	Bitmap bitmap2 = global::x.a(text5);
																	graphics.DrawImage(bitmap2, Conversions.ToInteger(array7[2]), Conversions.ToInteger(array7[3]), bitmap2.Width, bitmap2.Height);
																	try
																	{
																		foreach (object obj3 in arrayList4)
																		{
																			string[] array8 = (string[])obj3;
																			if (0 == string.Compare(array7[0], array8[0], StringComparison.Ordinal) && 0 != string.Compare(array7[6], array8[6], StringComparison.Ordinal))
																			{
																				text4 = array8[0];
																				Interlocked.Add(ref global::x.i, 1);
																				string text6 = global::x.a(a2.c, "_" + array8[1]);
																				if (File.Exists(text6))
																				{
																					ArrayList f2 = global::x.f;
																					lock (f2)
																					{
																						global::x.f.Add(text6);
																					}
																					Bitmap bitmap3 = global::x.a(text6);
																					graphics.DrawImage(bitmap3, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitmap3.Width, bitmap3.Height);
																					bitmap3.Dispose();
																				}
																			}
																		}
																	}
																	finally
																	{
																		IEnumerator enumerator4;
																		if (enumerator4 is IDisposable)
																		{
																			(enumerator4 as IDisposable).Dispose();
																		}
																	}
																	bitmap2.Dispose();
																	graphics.Dispose();
																	MemoryStream memoryStream = new MemoryStream();
																	bitmap.Save(memoryStream, ImageFormat.Png);
																	ArrayList obj4 = a2.a;
																	lock (obj4)
																	{
																		a2.a.Add(memoryStream);
																	}
																	ArrayList b2 = a2.b;
																	lock (b2)
																	{
																		a2.b.Add(array7[0]);
																	}
																	bitmap.Dispose();
																}
																b.a.ReportProgress(global::x.i);
																Thread.Sleep(global::x.c);
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator3;
													if (enumerator3 is IDisposable)
													{
														(enumerator3 as IDisposable).Dispose();
													}
												}
												IL_74C:
												ArrayList arrayList7 = new ArrayList();
												ArrayList arrayList8 = new ArrayList();
												ArrayList arrayList9 = new ArrayList();
												text4 = string.Empty;
												kirikiri2_compare_group_layer_id_v1 comparer = new kirikiri2_compare_group_layer_id_v1();
												arrayList3.Sort(comparer);
												try
												{
													foreach (object obj5 in arrayList3)
													{
														string[] array9 = (string[])obj5;
														Interlocked.Add(ref global::x.i, 1);
														if (b.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (b.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array9[0]))
														{
															if (0 != string.Compare(array9[0] + array9[1], text4, StringComparison.Ordinal) && Strings.InStr(1, array9[7], "$", CompareMethod.Binary) <= 0)
															{
																text4 = array9[0] + array9[1];
																if (!global::x.b(ref arrayList9, text4))
																{
																	arrayList9.Add(text4);
																	Bitmap bitmap4 = new Bitmap(a2.e, a2.d, PixelFormat.Format32bppArgb);
																	Graphics graphics2 = Graphics.FromImage(bitmap4);
																	graphics2.Clear(Color.Transparent);
																	bool flag5 = true;
																	string text7 = global::x.a(a2.c, "_" + array9[2]);
																	if (File.Exists(text7))
																	{
																		global::x.f.Add(text7);
																		Bitmap bitmap5 = global::x.a(text7);
																		graphics2.DrawImage(bitmap5, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitmap5.Width, bitmap5.Height);
																		ArrayList arrayList10 = new ArrayList();
																		try
																		{
																			foreach (object obj6 in arrayList3)
																			{
																				string[] array10 = (string[])obj6;
																				Interlocked.Add(ref global::x.i, 1);
																				if (b.a.CancellationPending)
																				{
																					return true;
																				}
																				while (global::x.a)
																				{
																					Thread.Sleep(500);
																					if (b.a.CancellationPending)
																					{
																						return true;
																					}
																				}
																				if (!string.IsNullOrWhiteSpace(array10[0]))
																				{
																					if (0 == string.Compare(array9[0], array10[0], StringComparison.Ordinal) && 0 == string.Compare(array9[1], array10[1], StringComparison.Ordinal) && 0 != string.Compare(array9[7], array10[7], StringComparison.Ordinal))
																					{
																						if (Strings.InStr(1, array10[7], "$", CompareMethod.Binary) > 0)
																						{
																							string text8 = Conversions.ToString(array10[7].Last<char>());
																							flag5 = false;
																							if (Versioned.IsNumeric(text8))
																							{
																								if (!global::x.b(ref arrayList10, text8))
																								{
																									arrayList10.Add(text8);
																								}
																							}
																						}
																						else
																						{
																							string text9 = global::x.a(a2.c, "_" + array10[2]);
																							if (File.Exists(text9))
																							{
																								arrayList9.Add(array10[0] + array10[1]);
																								global::x.f.Add(text9);
																								Bitmap bitmap6 = global::x.a(text9);
																								graphics2.DrawImage(bitmap6, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitmap6.Width, bitmap6.Height);
																								bitmap6.Dispose();
																							}
																						}
																					}
																				}
																			}
																		}
																		finally
																		{
																			IEnumerator enumerator6;
																			if (enumerator6 is IDisposable)
																			{
																				(enumerator6 as IDisposable).Dispose();
																			}
																		}
																		if (!flag5)
																		{
																			MemoryStream memoryStream2 = new MemoryStream();
																			bitmap4.Save(memoryStream2, ImageFormat.Png);
																			try
																			{
																				foreach (object value in arrayList10)
																				{
																					string strA = Conversions.ToString(value);
																					Bitmap bitmap7 = (Bitmap)Image.FromStream(memoryStream2);
																					Graphics graphics3 = Graphics.FromImage(bitmap7);
																					string text10 = string.Format("{0}_{1}", array9[0], array9[1]);
																					try
																					{
																						foreach (object obj7 in arrayList3)
																						{
																							string[] array11 = (string[])obj7;
																							if (0 == string.Compare(array9[0], array11[0], StringComparison.Ordinal) && 0 == string.Compare(array9[1], array11[1], StringComparison.Ordinal) && Strings.InStr(1, array11[7], "$", CompareMethod.Binary) > 0)
																							{
																								string text11 = Conversions.ToString(array11[7].Last<char>());
																								if (Versioned.IsNumeric(text11) && 0 == string.Compare(strA, text11, StringComparison.Ordinal))
																								{
																									string[] array12 = array11[7].Split(new char[]
																									{
																										'$'
																									});
																									text3 = array12[0];
																									if (Strings.InStr(1, text3, "/", CompareMethod.Binary) > 0)
																									{
																										array12 = text3.Split(new char[]
																										{
																											'/'
																										});
																										text3 = array12.Last<string>();
																									}
																									text10 = string.Format("{0}_{1}_{2}", array11[0], array11[1], text3);
																									string text12 = global::x.a(a2.c, "_" + array11[2]);
																									if (File.Exists(text12))
																									{
																										global::x.f.Add(text12);
																										Bitmap bitmap8 = global::x.a(text12);
																										graphics3.DrawImage(bitmap8, Conversions.ToInteger(array11[3]), Conversions.ToInteger(array11[4]), bitmap8.Width, bitmap8.Height);
																										bitmap8.Dispose();
																									}
																								}
																							}
																						}
																					}
																					finally
																					{
																						IEnumerator enumerator8;
																						if (enumerator8 is IDisposable)
																						{
																							(enumerator8 as IDisposable).Dispose();
																						}
																					}
																					graphics3.Dispose();
																					MemoryStream memoryStream3 = new MemoryStream();
																					bitmap7.Save(memoryStream3, ImageFormat.Png);
																					arrayList7.Add(memoryStream3);
																					arrayList8.Add(new string[]
																					{
																						array9[0],
																						text10
																					});
																					bitmap7.Dispose();
																				}
																			}
																			finally
																			{
																				IEnumerator enumerator7;
																				if (enumerator7 is IDisposable)
																				{
																					(enumerator7 as IDisposable).Dispose();
																				}
																			}
																			memoryStream2.Dispose();
																		}
																		bitmap5.Dispose();
																	}
																	graphics2.Dispose();
																	if (flag5)
																	{
																		MemoryStream memoryStream4 = new MemoryStream();
																		bitmap4.Save(memoryStream4, ImageFormat.Png);
																		arrayList7.Add(memoryStream4);
																		arrayList8.Add(new string[]
																		{
																			array9[0],
																			string.Format("{0}_{1}", array9[0], array9[1])
																		});
																	}
																	bitmap4.Dispose();
																	b.a.ReportProgress(global::x.i);
																	Thread.Sleep(global::x.c);
																}
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator5;
													if (enumerator5 is IDisposable)
													{
														(enumerator5 as IDisposable).Dispose();
													}
												}
												global::x.j = arrayList7.Count + a2.a.Count;
												b.a.ReportProgress(global::x.i);
												int num = 0;
												int num2 = arrayList7.Count - 1;
												for (int j = num; j <= num2; j++)
												{
													BW2_three.b.a.a.a a3 = new BW2_three.b.a.a.a(a3);
													a3.d = a2;
													a3.c = b;
													Interlocked.Add(ref global::x.i, 1);
													if (b.a.CancellationPending)
													{
														return true;
													}
													while (global::x.a)
													{
														Thread.Sleep(500);
														if (b.a.CancellationPending)
														{
															return true;
														}
													}
													a3.a = (string[])arrayList8[j];
													a3.b = (MemoryStream)arrayList7[j];
													Parallel.For(0, a2.a.Count, parallelOptions, new Action<int, ParallelLoopState>(a3.e));
													a3.b.Dispose();
												}
												Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.c));
												a2.a.Clear();
												a2.b.Clear();
												Parallel.ForEach<object>(arrayList7.ToArray(), new Action<object>(BW2_three.b));
												arrayList7.Clear();
												arrayList8.Clear();
												Parallel.ForEach<object>(arrayList5.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.g));
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
								}
							}
						}
					}
				}
				global::x.z = string.Empty;
				return b.d;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00018BAC File Offset: 0x00016DAC
		public static bool ChangeImageByTxt(ref Form1 myForm1)
		{
			BW2_three.a a = new BW2_three.a();
			a.b = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			string[] array = new string[checked(global::x.h - 1 + 1)];
			global::x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = global::x.a();
			a.a = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref global::x.i, 1);
				if (a.a.CancellationPending)
				{
					return true;
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (a.a.CancellationPending)
					{
						return true;
					}
				}
				a.a.ReportProgress(0);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				if (Strings.InStr(1, fileNameWithoutExtension, "_info", CompareMethod.Binary) <= 0)
				{
					string text2 = text;
					if (File.Exists(text2))
					{
						BW2_three.a.a a2 = new BW2_three.a.a();
						a2.e = a;
						global::x.f.Add(text2);
						a2.a = new ArrayList();
						if (kirikiri2_fun.readTxtToArr(text2, ref a2.a, ref a2.d, ref a2.c))
						{
							a2.b = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
							Parallel.ForEach<object>(a2.a.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.f));
						}
					}
				}
			}
			global::x.z = string.Empty;
			return a.b;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00018D38 File Offset: 0x00016F38
		public static bool X_info_X_txt_ddfr(ref Form1 myForm1)
		{
			BW2_three.l l = new BW2_three.l();
			l.d = false;
			global::x.h = global::x.e.Count;
			global::x.j = global::x.h;
			global::x.i = 0;
			global::x.k = 0;
			checked
			{
				string[] array = new string[global::x.h - 1 + 1];
				global::x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = global::x.a();
				l.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three.l.a a = new BW2_three.l.a(a);
					string text = array2[i];
					a.b = l;
					Interlocked.Add(ref global::x.i, 1);
					if (l.a.CancellationPending)
					{
						return true;
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (l.a.CancellationPending)
						{
							return true;
						}
					}
					if (!global::x.b(ref global::x.f, text))
					{
						l.b = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, l.b, "_info", CompareMethod.Binary) > 0)
						{
							l.c = text;
							a.a = new ArrayList(10);
							if (File.Exists(l.c))
							{
								global::x.f.Add(l.c);
								Parallel.ForEach<string>(array, new Action<string>(a.c));
								if (0 < a.a.Count)
								{
									try
									{
										IEnumerator enumerator = a.a.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three.l.a.a a2 = new BW2_three.l.a.a(a2);
											string text2 = Conversions.ToString(enumerator.Current);
											Interlocked.Add(ref global::x.i, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											int width;
											int height;
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref width, ref height))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(l.c, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												ArrayList arrayList6 = new ArrayList();
												string text3 = string.Empty;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array3 = (string[])obj;
														if (array3.GetUpperBound(0) >= 2)
														{
															if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "base", StringComparison.Ordinal))
															{
																string[] array4 = new string[7];
																array4[0] = array3[1];
																text3 = array3[3];
																array4[1] = text3;
																string str = text3;
																bool bFollowUp = false;
																ArrayList arrayList7 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr(str, ref arrayList, bFollowUp, ref arrayList7);
																array4[2] = layerArr.layer_id;
																array4[3] = layerArr.left;
																array4[4] = layerArr.top;
																array4[5] = layerArr.width;
																array4[6] = layerArr.height;
																arrayList3.Add(array4);
															}
															else if (0 == string.Compare(array3[0], "dress", StringComparison.Ordinal) & 0 == string.Compare(array3[2], "diff", StringComparison.Ordinal))
															{
																string[] array5 = new string[9];
																array5[0] = array3[1];
																array5[1] = array3[3];
																text3 = array3[4];
																array5[7] = text3;
																string str2 = text3;
																bool bFollowUp2 = false;
																ArrayList arrayList7 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr(str2, ref arrayList, bFollowUp2, ref arrayList7);
																array5[2] = layerArr2.layer_id;
																array5[3] = layerArr2.left;
																array5[4] = layerArr2.top;
																array5[5] = layerArr2.width;
																array5[6] = layerArr2.height;
																array5[8] = layerArr2.group_layer_id;
																arrayList4.Add(array5);
															}
															else if (0 == string.Compare(array3[0], "face", StringComparison.Ordinal))
															{
																text3 = array3[3];
																ArrayList arrayList8 = new ArrayList();
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr(text3, ref arrayList, true, ref arrayList8);
																if (string.IsNullOrWhiteSpace(layerArr3.layer_id) & 0 < arrayList8.Count)
																{
																	kirikiri2_compare_group_layer_id_v2 comparer = new kirikiri2_compare_group_layer_id_v2();
																	arrayList8.Sort(comparer);
																	try
																	{
																		foreach (object obj2 in arrayList8)
																		{
																			kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt2;
																			kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt = (obj2 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)obj2) : kirikiri2DefTxt2;
																			arrayList5.Add(new string[]
																			{
																				array3[1],
																				kirikiri2DefTxt.layer_id,
																				kirikiri2DefTxt.left,
																				kirikiri2DefTxt.top,
																				kirikiri2DefTxt.width,
																				kirikiri2DefTxt.height,
																				kirikiri2DefTxt.name
																			});
																		}
																		continue;
																	}
																	finally
																	{
																		IEnumerator enumerator3;
																		if (enumerator3 is IDisposable)
																		{
																			(enumerator3 as IDisposable).Dispose();
																		}
																	}
																}
																string[] array6 = new string[]
																{
																	array3[1],
																	null,
																	null,
																	null,
																	null,
																	null,
																	array3[3]
																};
																array6[1] = layerArr3.layer_id;
																array6[2] = layerArr3.left;
																array6[3] = layerArr3.top;
																array6[4] = layerArr3.width;
																array6[5] = layerArr3.height;
																arrayList5.Add(array6);
															}
															else if (0 == string.Compare(array3[0], "rename", StringComparison.Ordinal))
															{
																arrayList6.Add(new string[]
																{
																	array3[1],
																	array3[2],
																	array3[3]
																});
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator2;
													if (enumerator2 is IDisposable)
													{
														(enumerator2 as IDisposable).Dispose();
													}
												}
												a2.c = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												l.a.ReportProgress(0);
												a2.a = new ArrayList();
												a2.b = new ArrayList();
												ArrayList arrayList9 = new ArrayList();
												try
												{
													IEnumerator enumerator4 = arrayList5.GetEnumerator();
													while (enumerator4.MoveNext())
													{
														BW2_three.l.a.a.a a3 = new BW2_three.l.a.a.a(a3);
														string[] array7 = (string[])enumerator4.Current;
														a3.b = a2;
														Interlocked.Add(ref global::x.i, 1);
														if (l.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (l.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array7[0]))
														{
															a2.d = array7[0];
															if (!global::x.b(ref arrayList9, a2.d))
															{
																arrayList9.Add(a2.d);
																Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
																Graphics graphics = Graphics.FromImage(bitmap);
																graphics.Clear(Color.Transparent);
																try
																{
																	foreach (object obj3 in arrayList5)
																	{
																		string[] array8 = (string[])obj3;
																		Interlocked.Add(ref global::x.i, 1);
																		if (l.a.CancellationPending)
																		{
																			return true;
																		}
																		while (global::x.a)
																		{
																			Thread.Sleep(500);
																			if (l.a.CancellationPending)
																			{
																				return true;
																			}
																		}
																		if (!string.IsNullOrWhiteSpace(array8[0]))
																		{
																			if (0 == string.Compare(a2.d, array8[0], StringComparison.Ordinal))
																			{
																				string text4 = global::x.a(a2.c, "_" + array8[1]);
																				if (File.Exists(text4))
																				{
																					global::x.f.Add(text4);
																					bool flag = true;
																					try
																					{
																						string strA = array8[0].Substring(0, 4);
																						if (0 == string.Compare(strA, "face", StringComparison.Ordinal) && 0 == string.Compare(array8[6], "頬", StringComparison.Ordinal))
																						{
																							flag = false;
																						}
																					}
																					catch (Exception ex)
																					{
																						global::x.c(ex.Message);
																					}
																					if (!flag)
																					{
																						continue;
																					}
																					Bitmap bitmap2 = global::x.a(text4);
																					graphics.DrawImage(bitmap2, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitmap2.Width, bitmap2.Height);
																					bitmap2.Dispose();
																				}
																			}
																			l.a.ReportProgress(global::x.i);
																		}
																	}
																}
																finally
																{
																	IEnumerator enumerator5;
																	if (enumerator5 is IDisposable)
																	{
																		(enumerator5 as IDisposable).Dispose();
																	}
																}
																graphics.Dispose();
																MemoryStream memoryStream = new MemoryStream();
																bitmap.Save(memoryStream, ImageFormat.Png);
																a2.a.Add(memoryStream);
																a3.a = a2.d;
																Parallel.ForEach<object>(arrayList6.ToArray(), new Action<object, ParallelLoopState>(a3.c));
																a2.b.Add(a3.a);
																bitmap.Dispose();
																l.a.ReportProgress(global::x.i);
															}
														}
													}
												}
												finally
												{
													IEnumerator enumerator4;
													if (enumerator4 is IDisposable)
													{
														(enumerator4 as IDisposable).Dispose();
													}
												}
												try
												{
													IEnumerator enumerator6 = arrayList3.GetEnumerator();
													while (enumerator6.MoveNext())
													{
														BW2_three.l.a.a.b b = new BW2_three.l.a.a.b(b);
														string[] array9 = (string[])enumerator6.Current;
														Interlocked.Add(ref global::x.i, 1);
														if (l.a.CancellationPending)
														{
															return true;
														}
														while (global::x.a)
														{
															Thread.Sleep(500);
															if (l.a.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array9[0]))
														{
															MemoryStream memoryStream2 = new MemoryStream();
															Bitmap bitmap3 = new Bitmap(width, height, PixelFormat.Format32bppArgb);
															b.a = array9[0];
															Parallel.ForEach<object>(arrayList6.ToArray(), new Action<object, ParallelLoopState>(b.b));
															if (string.IsNullOrWhiteSpace(array9[2]))
															{
																bitmap3.Save(memoryStream2, ImageFormat.Png);
															}
															else
															{
																string text5 = global::x.a(a2.c, "_" + array9[2]);
																if (File.Exists(text5))
																{
																	global::x.f.Add(text5);
																	Interlocked.Add(ref global::x.i, 1);
																	Graphics graphics2 = Graphics.FromImage(bitmap3);
																	graphics2.Clear(Color.Transparent);
																	using (Bitmap bitmap4 = global::x.a(text5))
																	{
																		graphics2.DrawImage(bitmap4, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitmap4.Width, bitmap4.Height);
																	}
																	graphics2.Dispose();
																	bitmap3.Save(memoryStream2, ImageFormat.Png);
																	l.a.ReportProgress(global::x.i);
																}
																else
																{
																	bitmap3.Save(memoryStream2, ImageFormat.Png);
																}
															}
															bitmap3.Dispose();
															try
															{
																foreach (object obj4 in arrayList4)
																{
																	string[] array10 = (string[])obj4;
																	Interlocked.Add(ref global::x.i, 1);
																	if (l.a.CancellationPending)
																	{
																		return true;
																	}
																	while (global::x.a)
																	{
																		Thread.Sleep(500);
																		if (l.a.CancellationPending)
																		{
																			return true;
																		}
																	}
																	if (!string.IsNullOrWhiteSpace(array10[0]))
																	{
																		if (0 == string.Compare(array9[0], array10[0], StringComparison.Ordinal))
																		{
																			BW2_three.l.a.a.b.a a4 = new BW2_three.l.a.a.b.a();
																			a4.e = b;
																			a4.d = a2;
																			a4.c = l;
																			a4.b = new MemoryStream();
																			Bitmap bitmap5 = (Bitmap)Image.FromStream(memoryStream2);
																			a4.a = array10[1];
																			Parallel.ForEach<object>(arrayList6.ToArray(), new Action<object, ParallelLoopState>(a4.f));
																			string text6 = global::x.a(a2.c, "_" + array10[2]);
																			if (File.Exists(text6))
																			{
																				global::x.f.Add(text6);
																				Interlocked.Add(ref global::x.i, 1);
																				Graphics graphics3 = Graphics.FromImage(bitmap5);
																				graphics3.Clear(Color.Transparent);
																				using (Bitmap bitmap6 = global::x.a(text6))
																				{
																					graphics3.DrawImage(bitmap6, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitmap6.Width, bitmap6.Height);
																				}
																				graphics3.Dispose();
																				bitmap5.Save(a4.b, ImageFormat.Png);
																				l.a.ReportProgress(global::x.i);
																			}
																			else
																			{
																				bitmap5.Save(a4.b, ImageFormat.Png);
																			}
																			bitmap5.Dispose();
																			Parallel.For(0, a2.a.Count, parallelOptions, new Action<int, ParallelLoopState>(a4.f));
																			a4.b.Dispose();
																		}
																	}
																}
															}
															finally
															{
																IEnumerator enumerator7;
																if (enumerator7 is IDisposable)
																{
																	(enumerator7 as IDisposable).Dispose();
																}
															}
															memoryStream2.Dispose();
														}
													}
												}
												finally
												{
													IEnumerator enumerator6;
													if (enumerator6 is IDisposable)
													{
														(enumerator6 as IDisposable).Dispose();
													}
												}
												Parallel.ForEach<object>(a2.a.ToArray(), new Action<object>(BW2_three.a));
												a2.a.Clear();
												a2.b.Clear();
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
								}
							}
						}
					}
				}
				global::x.z = string.Empty;
				return l.d;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00019AF4 File Offset: 0x00017CF4
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void x(object A_0)
		{
			new ad<MemoryStream>(BW2_three.x)((MemoryStream)A_0);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00019B0D File Offset: 0x00017D0D
		[CompilerGenerated]
		private static void x(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00019B15 File Offset: 0x00017D15
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void w(object A_0)
		{
			new ad<MemoryStream>(BW2_three.w)((MemoryStream)A_0);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00019B2E File Offset: 0x00017D2E
		[CompilerGenerated]
		private static void w(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00019B36 File Offset: 0x00017D36
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void v(object A_0)
		{
			new ad<MemoryStream>(BW2_three.v)((MemoryStream)A_0);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00019B4F File Offset: 0x00017D4F
		[CompilerGenerated]
		private static void v(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00019B57 File Offset: 0x00017D57
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void u(object A_0)
		{
			new ad<MemoryStream>(BW2_three.u)((MemoryStream)A_0);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00019B70 File Offset: 0x00017D70
		[CompilerGenerated]
		private static void u(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00019B78 File Offset: 0x00017D78
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void t(object A_0)
		{
			new ad<MemoryStream>(BW2_three.t)((MemoryStream)A_0);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00019B91 File Offset: 0x00017D91
		[CompilerGenerated]
		private static void t(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00019B99 File Offset: 0x00017D99
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void s(object A_0)
		{
			new ad<MemoryStream>(BW2_three.s)((MemoryStream)A_0);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00019BB2 File Offset: 0x00017DB2
		[CompilerGenerated]
		private static void s(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00019BBA File Offset: 0x00017DBA
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void r(object A_0)
		{
			new ad<MemoryStream>(BW2_three.r)((MemoryStream)A_0);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00019BD3 File Offset: 0x00017DD3
		[CompilerGenerated]
		private static void r(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00019BDB File Offset: 0x00017DDB
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void q(object A_0)
		{
			new ad<MemoryStream>(BW2_three.q)((MemoryStream)A_0);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00019BF4 File Offset: 0x00017DF4
		[CompilerGenerated]
		private static void q(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00019BFC File Offset: 0x00017DFC
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void p(object A_0)
		{
			new ad<MemoryStream>(BW2_three.p)((MemoryStream)A_0);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00019C15 File Offset: 0x00017E15
		[CompilerGenerated]
		private static void p(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00019C1D File Offset: 0x00017E1D
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void o(object A_0)
		{
			new ad<MemoryStream>(BW2_three.o)((MemoryStream)A_0);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00019C36 File Offset: 0x00017E36
		[CompilerGenerated]
		private static void o(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00019C3E File Offset: 0x00017E3E
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void n(object A_0)
		{
			new ad<MemoryStream>(BW2_three.n)((MemoryStream)A_0);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00019C57 File Offset: 0x00017E57
		[CompilerGenerated]
		private static void n(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00019C5F File Offset: 0x00017E5F
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void m(object A_0)
		{
			new ad<MemoryStream>(BW2_three.m)((MemoryStream)A_0);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00019C78 File Offset: 0x00017E78
		[CompilerGenerated]
		private static void m(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00019C80 File Offset: 0x00017E80
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void l(object A_0)
		{
			new ad<MemoryStream>(BW2_three.l)((MemoryStream)A_0);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00019C99 File Offset: 0x00017E99
		[CompilerGenerated]
		private static void l(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00019CA1 File Offset: 0x00017EA1
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void k(object A_0)
		{
			new ad<MemoryStream>(BW2_three.k)((MemoryStream)A_0);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00019CBA File Offset: 0x00017EBA
		[CompilerGenerated]
		private static void k(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00019CC2 File Offset: 0x00017EC2
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void j(object A_0)
		{
			new ad<MemoryStream>(BW2_three.j)((MemoryStream)A_0);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00019CDB File Offset: 0x00017EDB
		[CompilerGenerated]
		private static void j(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00019CE3 File Offset: 0x00017EE3
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void i(object A_0)
		{
			new ad<MemoryStream>(BW2_three.i)((MemoryStream)A_0);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00019CFC File Offset: 0x00017EFC
		[CompilerGenerated]
		private static void i(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00019D04 File Offset: 0x00017F04
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void h(object A_0)
		{
			new ad<MemoryStream>(BW2_three.h)((MemoryStream)A_0);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00019D1D File Offset: 0x00017F1D
		[CompilerGenerated]
		private static void h(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00019D25 File Offset: 0x00017F25
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void g(object A_0)
		{
			new ad<MemoryStream>(BW2_three.g)((MemoryStream)A_0);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00019D3E File Offset: 0x00017F3E
		[CompilerGenerated]
		private static void g(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00019D46 File Offset: 0x00017F46
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void f(object A_0)
		{
			new ad<MemoryStream>(BW2_three.f)((MemoryStream)A_0);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00019D5F File Offset: 0x00017F5F
		[CompilerGenerated]
		private static void f(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00019D67 File Offset: 0x00017F67
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void e(object A_0)
		{
			new ad<MemoryStream>(BW2_three.e)((MemoryStream)A_0);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00019D80 File Offset: 0x00017F80
		[CompilerGenerated]
		private static void e(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00019D88 File Offset: 0x00017F88
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void d(object A_0)
		{
			new ad<MemoryStream>(BW2_three.d)((MemoryStream)A_0);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00019DA1 File Offset: 0x00017FA1
		[CompilerGenerated]
		private static void d(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00019DA9 File Offset: 0x00017FA9
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void c(object A_0)
		{
			new ad<MemoryStream>(BW2_three.c)((MemoryStream)A_0);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00019DC2 File Offset: 0x00017FC2
		[CompilerGenerated]
		private static void c(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00019DCA File Offset: 0x00017FCA
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void b(object A_0)
		{
			new ad<MemoryStream>(BW2_three.b)((MemoryStream)A_0);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00019DE3 File Offset: 0x00017FE3
		[CompilerGenerated]
		private static void b(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00019DEB File Offset: 0x00017FEB
		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void a(object A_0)
		{
			new ad<MemoryStream>(BW2_three.a)((MemoryStream)A_0);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00019E04 File Offset: 0x00018004
		[CompilerGenerated]
		private static void a(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x0400011F RID: 287
		private ArrayList a;

		// Token: 0x04000120 RID: 288
		public static bool triagain = false;

		// Token: 0x04000121 RID: 289
		public static bool utahime = false;

		// Token: 0x04000122 RID: 290
		public static bool gyakuoudou = false;

		// Token: 0x0200004D RID: 77
		[CompilerGenerated]
		internal class n
		{
			// Token: 0x0600010B RID: 267 RVA: 0x00019E14 File Offset: 0x00018014
			[CompilerGenerated]
			public void g(string A_0, ParallelLoopState A_1)
			{
				BW2_three.n.a a = new BW2_three.n.a();
				Interlocked.Add(ref global::x.i, 1);
				if (this.a.CancellationPending)
				{
					this.b = true;
					A_1.Stop();
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.b = true;
						A_1.Stop();
					}
				}
				checked
				{
					int num = Path.GetFullPath(A_0).Length - Path.GetExtension(A_0).Length;
					a.b = Path.GetFullPath(A_0).Substring(0, num);
					a.c = Path.GetFullPath(A_0).Substring(0, num) + "_a";
					a.d = string.Empty;
					a.a = string.Empty;
					string[] files = Directory.GetFiles(Path.GetDirectoryName(A_0));
					if (files.Length > 0)
					{
						Parallel.ForEach<string>(files, new Action<string>(a.e));
					}
					else
					{
						A_1.Stop();
					}
					if (string.IsNullOrEmpty(a.d) | string.IsNullOrEmpty(a.a))
					{
						return;
					}
					bool flag = false;
					bool flag2 = false;
					int num2;
					int num3;
					int num4;
					int y;
					int num5;
					int num6;
					int x;
					int y2;
					int x2;
					int num7;
					int width;
					int num8;
					using (FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream))
						{
							while (!streamReader.EndOfStream)
							{
								string input = streamReader.ReadLine();
								if (this.c.IsMatch(input))
								{
									if (!flag)
									{
										MatchCollection matchCollection = this.f.Matches(input);
										if (matchCollection.Count > 0)
										{
											num2 = Conversions.ToInteger(matchCollection[0].Value.Substring(1));
											num3 = Conversions.ToInteger(matchCollection[1].Value.Substring(1));
											num4 = 0;
											y = Conversions.ToInteger(matchCollection[3].Value.Substring(1));
											num5 = Conversions.ToInteger(matchCollection[4].Value.Substring(1));
											num6 = Conversions.ToInteger(matchCollection[5].Value.Substring(1));
											flag = true;
										}
									}
								}
								else if (this.e.IsMatch(input) && !flag2)
								{
									MatchCollection matchCollection = this.f.Matches(input);
									if (matchCollection.Count > 0)
									{
										x = Conversions.ToInteger(matchCollection[0].Value.Substring(1));
										y2 = Conversions.ToInteger(matchCollection[1].Value.Substring(1));
										x2 = Conversions.ToInteger(matchCollection[2].Value.Substring(1));
										num7 = 0;
										width = Conversions.ToInteger(matchCollection[4].Value.Substring(1));
										num8 = Conversions.ToInteger(matchCollection[5].Value.Substring(1));
										flag2 = true;
									}
								}
							}
						}
					}
					if (0 == num2 & 0 == num3 & 0 == num5 & 0 == num6)
					{
						using (FileStream fileStream2 = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader2 = new StreamReader(fileStream2))
							{
								while (!streamReader2.EndOfStream)
								{
									string input = streamReader2.ReadLine();
									if (this.d.IsMatch(input) && !flag)
									{
										MatchCollection matchCollection = this.f.Matches(input);
										if (matchCollection.Count > 0)
										{
											num2 = Conversions.ToInteger(matchCollection[0].Value.Substring(1));
											num3 = Conversions.ToInteger(matchCollection[1].Value.Substring(1));
											num4 = 0;
											y = Conversions.ToInteger(matchCollection[3].Value.Substring(1));
											num5 = Conversions.ToInteger(matchCollection[4].Value.Substring(1));
											num6 = Conversions.ToInteger(matchCollection[5].Value.Substring(1));
											flag = true;
										}
									}
								}
							}
						}
					}
					if (0 == num2 & 0 == num3 & 0 == num5 & 0 == num6)
					{
						return;
					}
					MemoryStream memoryStream = new MemoryStream();
					int width2;
					int height;
					PixelFormat pixelFormat;
					using (Bitmap bitmap = global::x.a(a.d))
					{
						width2 = bitmap.Width;
						height = bitmap.Height;
						pixelFormat = bitmap.PixelFormat;
						bitmap.Save(memoryStream, ImageFormat.Png);
					}
					using (Bitmap bitmap2 = global::x.a(a.a))
					{
						Bitmap bitmap3 = new Bitmap(width2, height, pixelFormat);
						Graphics graphics = Graphics.FromImage(bitmap3);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(Image.FromStream(memoryStream), 0, 0, width2, height);
						num = bitmap2.Width / num5;
						string str = Path.Combine(Path.GetDirectoryName(a.a), Path.GetFileNameWithoutExtension(a.a));
						int num9 = 1;
						int num10 = num;
						for (int i = num9; i <= num10; i++)
						{
							Rectangle rect = new Rectangle(num4, y, num5, num6);
							BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
							Bitmap bitmap4 = new Bitmap(num5, num6, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
							bitmap2.UnlockBits(bitmapData);
							graphics.DrawImage(bitmap4, num2, num3, num5, num6);
							global::x.a(str + "_sw" + i.ToString("D3"), ref bitmap3, true);
							bitmap4.Dispose();
							num4 += num5;
							Interlocked.Add(ref global::x.k, 1);
						}
						graphics.Dispose();
						bitmap3.Dispose();
						if (flag2)
						{
							bitmap3 = new Bitmap(width2, height, PixelFormat.Format32bppArgb);
							graphics = Graphics.FromImage(bitmap3);
							graphics.Clear(Color.Transparent);
							num = bitmap2.Height / num8;
							int num11 = 1;
							int num12 = num;
							for (int j = num11; j <= num12; j++)
							{
								Rectangle rect = new Rectangle(x2, num7, width, num8);
								BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
								Bitmap bitmap4 = new Bitmap(width, num8, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
								bitmap2.UnlockBits(bitmapData);
								graphics.DrawImage(bitmap4, x, y2, width, num8);
								global::x.a(str + "_sy" + j.ToString("D3"), ref bitmap3, true);
								bitmap4.Dispose();
								num7 += num8;
								Interlocked.Add(ref global::x.k, 1);
							}
							graphics.Dispose();
							bitmap3.Dispose();
						}
					}
					memoryStream.Dispose();
					ArrayList obj = global::x.f;
					lock (obj)
					{
						global::x.f.Add(A_0);
						global::x.f.Add(a.d);
						global::x.f.Add(a.a);
					}
					this.a.ReportProgress(global::x.i);
					Thread.Sleep(global::x.c);
				}
			}

			// Token: 0x04000123 RID: 291
			public BackgroundWorker a;

			// Token: 0x04000124 RID: 292
			public bool b;

			// Token: 0x04000125 RID: 293
			public Regex c;

			// Token: 0x04000126 RID: 294
			public Regex d;

			// Token: 0x04000127 RID: 295
			public Regex e;

			// Token: 0x04000128 RID: 296
			public Regex f;

			// Token: 0x0200004E RID: 78
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600010D RID: 269 RVA: 0x0001A5C8 File Offset: 0x000187C8
				[CompilerGenerated]
				public void e(string A_0)
				{
					string strB = Path.GetFullPath(A_0).Substring(0, checked(Path.GetFullPath(A_0).Length - Path.GetExtension(A_0).Length));
					if (0 == string.Compare(this.b, strB, StringComparison.Ordinal))
					{
						this.d = global::x.a(this.b, "");
						Interlocked.Add(ref global::x.i, 1);
					}
					else if (0 == string.Compare(this.c, strB, StringComparison.Ordinal))
					{
						this.a = global::x.a(this.c, "");
						Interlocked.Add(ref global::x.i, 1);
					}
				}

				// Token: 0x04000129 RID: 297
				public string a;

				// Token: 0x0400012A RID: 298
				public string b;

				// Token: 0x0400012B RID: 299
				public string c;

				// Token: 0x0400012C RID: 300
				public string d;
			}
		}

		// Token: 0x0200004F RID: 79
		[CompilerGenerated]
		internal class m
		{
			// Token: 0x0600010E RID: 270 RVA: 0x0001A660 File Offset: 0x00018860
			public m(BW2_three.m A_0)
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

			// Token: 0x0600010F RID: 271 RVA: 0x0001A6B4 File Offset: 0x000188B4
			[CompilerGenerated]
			public void f(string A_0, ParallelLoopState A_1)
			{
				BW2_three.m.a a = new BW2_three.m.a(a);
				Interlocked.Add(ref global::x.i, 1);
				if (this.a.CancellationPending)
				{
					this.b = true;
					A_1.Stop();
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (this.a.CancellationPending)
					{
						this.b = true;
						A_1.Stop();
					}
				}
				int num = 0;
				checked
				{
					num = Path.GetFullPath(A_0).Length - Path.GetExtension(A_0).Length;
					a.b = Path.GetFullPath(A_0).Substring(0, num) + "_a";
					a.c = Path.GetFullPath(A_0).Substring(0, num) + "_a_m";
					a.d = string.Empty;
					a.a = string.Empty;
					string[] files = Directory.GetFiles(Path.GetDirectoryName(A_0));
					if (files.Length > 0)
					{
						Parallel.ForEach<string>(files, new Action<string>(a.e));
					}
					else
					{
						A_1.Stop();
					}
					if (string.IsNullOrEmpty(a.d) | string.IsNullOrEmpty(a.a))
					{
						return;
					}
					this.a.ReportProgress(global::x.i);
					string text = "";
					string text2 = "";
					int num2;
					int num3;
					int num4;
					int num5;
					int num6;
					int num7;
					using (FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream))
						{
							while (!streamReader.EndOfStream)
							{
								text = streamReader.ReadLine();
								if (this.d.IsMatch(text))
								{
									MatchCollection matchCollection = this.e.Matches(text);
									if (matchCollection.Count > 0)
									{
										string text3 = matchCollection[0].Value.Replace("\"", "");
										string[] array = global::x.an.Split(text3);
										text3 = array[0].Trim();
										if (Strings.InStr(1, text3, "_b_w", CompareMethod.Binary) > 0)
										{
											num2 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_b_h", CompareMethod.Binary) > 0)
										{
											num3 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_f_x", CompareMethod.Binary) > 0)
										{
											num4 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_f_y", CompareMethod.Binary) > 0)
										{
											num5 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_f_w", CompareMethod.Binary) > 0)
										{
											num6 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_f_h", CompareMethod.Binary) > 0)
										{
											num7 = Conversions.ToInteger(array[1].Trim());
										}
										else if (Strings.InStr(1, text3, "_sx1", CompareMethod.Binary) > 0)
										{
											text2 = global::x.ak.Split(text3).First<string>();
											break;
										}
									}
								}
							}
						}
					}
					this.a.ReportProgress(global::x.i);
					if ((0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7) && !string.IsNullOrEmpty(text2) && 0 < this.c.Count)
					{
						this.c.TryGetValue(text2 + "_b_w", out text);
						if (Versioned.IsNumeric(text))
						{
							num2 = Conversions.ToInteger(text);
						}
						this.c.TryGetValue(text2 + "_b_h", out text);
						if (Versioned.IsNumeric(text))
						{
							num3 = Conversions.ToInteger(text);
						}
						this.c.TryGetValue(text2 + "_f_x", out text);
						if (Versioned.IsNumeric(text))
						{
							num4 = Conversions.ToInteger(text);
						}
						this.c.TryGetValue(text2 + "_f_y", out text);
						if (Versioned.IsNumeric(text))
						{
							num5 = Conversions.ToInteger(text);
						}
						this.c.TryGetValue(text2 + "_f_w", out text);
						if (Versioned.IsNumeric(text))
						{
							num6 = Conversions.ToInteger(text);
						}
						this.c.TryGetValue(text2 + "_f_h", out text);
						if (Versioned.IsNumeric(text))
						{
							num7 = Conversions.ToInteger(text);
						}
					}
					int num8 = 1;
					int num9 = 0;
					if (0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7)
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						string text4 = global::x.a(Path.Combine(Path.GetDirectoryName(A_0), fileNameWithoutExtension), "");
						if (File.Exists(text4))
						{
							using (Bitmap bitmap = global::x.a(text4))
							{
								num2 = bitmap.Width;
								num3 = bitmap.Height;
							}
							using (Bitmap bitmap2 = global::x.a(a.d))
							{
								num9 = bitmap2.Width;
								int height = bitmap2.Height;
								if (num9 > num2)
								{
									num8 = 2;
								}
								else
								{
									using (Bitmap bitmap3 = global::x.a(a.a))
									{
										FastBitmap fastBitmap = new FastBitmap(bitmap3);
										int iHeight = fastBitmap.iHeight;
										int iWidth = fastBitmap.iWidth;
										int num10 = 1;
										int num11 = iHeight - 1;
										for (int i = num10; i <= num11; i++)
										{
											int num12 = 1;
											int num13 = iWidth - 1;
											for (int j = num12; j <= num13; j++)
											{
												if (!(num4 == 0 & num5 == 0))
												{
													goto IL_5B5;
												}
												Color pixel = fastBitmap.GetPixel(j, i);
												if (global::x.b(ref pixel))
												{
													pixel = fastBitmap.GetPixel(j + 1, i);
													if (global::x.a(ref pixel))
													{
														pixel = fastBitmap.GetPixel(j + 1, i - 1);
														if (global::x.b(ref pixel))
														{
															num4 = j;
															num5 = i;
														}
													}
												}
											}
										}
										IL_5B5:
										int num14 = num5;
										int num15 = iHeight - 2;
										for (int k = num14; k <= num15; k++)
										{
											int num16 = num4;
											int num17 = iWidth - 2;
											for (int l = num16; l <= num17; l++)
											{
												if (num6 == 0)
												{
													Color pixel = fastBitmap.GetPixel(l, k);
													if (global::x.a(ref pixel))
													{
														pixel = fastBitmap.GetPixel(l, k - 1);
														if (global::x.b(ref pixel))
														{
															pixel = fastBitmap.GetPixel(l + 1, k);
															if (global::x.b(ref pixel))
															{
																num6 = l - num4;
															}
														}
													}
												}
												if (num7 == 0)
												{
													Color pixel = fastBitmap.GetPixel(l, k);
													if (global::x.a(ref pixel))
													{
														pixel = fastBitmap.GetPixel(l, k + 1);
														if (global::x.b(ref pixel))
														{
															num7 = k - num5 + 1;
														}
													}
												}
												if (num6 > 0 & num7 > 0)
												{
													num4++;
													goto IL_6C7;
												}
												if (l >= iWidth - 1 & k >= iWidth - 1)
												{
													num4 = 0;
													num5 = 0;
													num6 = 0;
													num7 = 0;
												}
											}
										}
									}
									IL_6C7:;
								}
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(text4);
							}
						}
					}
					if (num8 == 1)
					{
						if (0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7)
						{
							global::x.c(string.Concat(new string[]
							{
								Conversions.ToString(num2),
								Conversions.ToString(num3),
								Conversions.ToString(num4),
								Conversions.ToString(num5),
								Conversions.ToString(num6),
								Conversions.ToString(num7),
								" iCopyMode",
								Conversions.ToString(num8)
							}));
							return;
						}
					}
					else if (num8 == 2 && (0 >= num2 | 0 >= num3))
					{
						global::x.c(Conversions.ToString(num2) + Conversions.ToString(num3) + " iCopyMode" + Conversions.ToString(num8));
						return;
					}
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					using (Bitmap bitmap4 = global::x.a(a.d))
					{
						FastBitmap fastBitmap2 = new FastBitmap(bitmap4);
						using (Bitmap bitmap5 = global::x.a(a.a))
						{
							FastBitmap fastBitmap3 = new FastBitmap(bitmap5);
							int width = bitmap4.Width;
							Bitmap bitmap6 = new Bitmap(width, num3, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap4 = new FastBitmap(bitmap6);
							int num18 = 0;
							int num19 = width - 1;
							for (int m = num18; m <= num19; m++)
							{
								int num20 = 0;
								int num21 = num3 - 1;
								for (int n = num20; n <= num21; n++)
								{
									Color pixel2 = fastBitmap2.GetPixel(m, n);
									Color pixel3 = fastBitmap3.GetPixel(m, n);
									int alpha = global::x.c(ref pixel3);
									fastBitmap4.SetPixel(m, n, Color.FromArgb(alpha, pixel2));
								}
							}
							fastBitmap4.Save(ref memoryStream, ImageFormat.Png);
							fastBitmap4.Dispose();
							bitmap6.Dispose();
							if (num8 == 1)
							{
								bitmap6 = new Bitmap(fastBitmap2.iWidth, fastBitmap2.iHeight - num3, PixelFormat.Format32bppArgb);
								fastBitmap4 = new FastBitmap(bitmap6);
								int num22 = 0;
								int num23 = fastBitmap2.iWidth - 1;
								for (int num24 = num22; num24 <= num23; num24++)
								{
									int num25 = 0;
									int num26 = fastBitmap2.iHeight - num3 - 1;
									for (int num27 = num25; num27 <= num26; num27++)
									{
										Color pixel2 = fastBitmap2.GetPixel(num24, num27 + num3);
										Color pixel3 = fastBitmap3.GetPixel(num24, num27 + num3);
										int alpha;
										if (pixel3.R == pixel3.G & pixel3.R == pixel3.B)
										{
											alpha = (int)pixel3.R;
										}
										else
										{
											alpha = (int)Math.Round(unchecked(0.212671 * (double)pixel3.R + 0.71516 * (double)pixel3.G + 0.072169 * (double)pixel3.B));
										}
										fastBitmap4.SetPixel(num24, num27, Color.FromArgb(alpha, pixel2));
									}
								}
								fastBitmap4.Save(ref memoryStream2, ImageFormat.Png);
								fastBitmap4.Dispose();
								bitmap6.Dispose();
							}
						}
						fastBitmap2.Dispose();
					}
					if (num8 == 1)
					{
						int num28 = 0;
						int num29 = 0;
						Bitmap bitmap7 = (Bitmap)Image.FromStream(memoryStream2);
						bool flag2 = true;
						num = 0;
						bool flag3 = false;
						while (flag2)
						{
							if (this.a.CancellationPending)
							{
								this.b = true;
								break;
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (this.a.CancellationPending)
								{
									this.b = true;
									break;
								}
							}
							flag3 = false;
							Rectangle rect = new Rectangle(num28, num29, num6, num7);
							BitmapData bitmapData = bitmap7.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
							Bitmap bitmap8 = new Bitmap(num6, num7, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
							bitmap7.UnlockBits(bitmapData);
							using (MemoryStream memoryStream3 = new MemoryStream())
							{
								bitmap8.Save(memoryStream3, ImageFormat.Png);
								FastBitmap fastBitmap5 = new FastBitmap((Bitmap)Image.FromStream(memoryStream3));
								int num30 = 0;
								int num31 = fastBitmap5.iWidth - 1;
								for (int num32 = num30; num32 <= num31; num32++)
								{
									if (flag3)
									{
										break;
									}
									int num33 = 0;
									int num34 = fastBitmap5.iHeight - 1;
									for (int num35 = num33; num35 <= num34; num35++)
									{
										if (255 == fastBitmap5.GetPixel(num32, num35).A)
										{
											flag3 = true;
											break;
										}
									}
								}
							}
							if (flag3)
							{
								FastBitmap fastBitmap6 = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
								int num36 = 0;
								int num37 = num6 - 1;
								for (int num38 = num36; num38 <= num37; num38++)
								{
									int num39 = 0;
									int num40 = num7 - 1;
									for (int num41 = num39; num41 <= num40; num41++)
									{
										Color pixel2 = bitmap8.GetPixel(num38, num41);
										fastBitmap6.SetPixel(num38 + num4, num41 + num5, Color.FromArgb((int)pixel2.A, pixel2));
									}
								}
								string a_ = a.d.Substring(0, a.d.Length - Path.GetExtension(a.d).Length) + "_" + num.ToString("D3");
								global::x.a(a_, ref fastBitmap6);
								fastBitmap6.Dispose();
								num++;
								Interlocked.Add(ref global::x.k, 1);
							}
							this.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
							num28 += num6;
							if (num28 + num6 > bitmap7.Width)
							{
								num28 = 0;
								num29 += num7;
							}
							if (num29 + num7 > bitmap7.Height)
							{
								flag2 = false;
							}
							bitmap8.Dispose();
						}
						bitmap7.Dispose();
					}
					else if (num8 == 2)
					{
						int num42 = (int)Math.Round((double)num9 / (double)num2);
						double num43 = (double)num9 / (double)num2;
						if (num43 > (double)num42)
						{
							num42++;
						}
						Bitmap bitmap9 = (Bitmap)Image.FromStream(memoryStream);
						int num44 = 0;
						int num45 = num42 - 1;
						for (int num46 = num44; num46 <= num45; num46++)
						{
							Rectangle rect2 = new Rectangle(num46 * num2, 0, num2, num3);
							BitmapData bitmapData2 = bitmap9.LockBits(rect2, ImageLockMode.ReadOnly, bitmap9.PixelFormat);
							Bitmap bitmap10 = new Bitmap(num2, num3, bitmapData2.Stride, bitmap9.PixelFormat, bitmapData2.Scan0);
							bitmap9.UnlockBits(bitmapData2);
							string a_2 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0) + "_" + num46.ToString("D3"));
							global::x.a(a_2, ref bitmap10, true);
							bitmap10.Dispose();
							Interlocked.Add(ref global::x.k, 1);
							this.a.ReportProgress(global::x.i);
						}
						bitmap9.Dispose();
						Thread.Sleep(global::x.c);
					}
					memoryStream2.Dispose();
					memoryStream.Dispose();
					ArrayList f2 = global::x.f;
					lock (f2)
					{
						global::x.f.Add(A_0);
						global::x.f.Add(a.d);
						global::x.f.Add(a.a);
					}
				}
			}

			// Token: 0x0400012D RID: 301
			public BackgroundWorker a;

			// Token: 0x0400012E RID: 302
			public bool b;

			// Token: 0x0400012F RID: 303
			public Dictionary<string, string> c;

			// Token: 0x04000130 RID: 304
			public Regex d;

			// Token: 0x04000131 RID: 305
			public Regex e;

			// Token: 0x02000050 RID: 80
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000110 RID: 272 RVA: 0x0001B5B0 File Offset: 0x000197B0
				public a(BW2_three.m.a A_0)
				{
					if (A_0 != null)
					{
						this.b = A_0.b;
						this.d = A_0.d;
						this.c = A_0.c;
						this.a = A_0.a;
					}
				}

				// Token: 0x06000111 RID: 273 RVA: 0x0001B5EC File Offset: 0x000197EC
				[CompilerGenerated]
				public void e(string A_0)
				{
					string strB = Path.GetFullPath(A_0).Substring(0, checked(Path.GetFullPath(A_0).Length - Path.GetExtension(A_0).Length));
					if (0 == string.Compare(this.b, strB, StringComparison.Ordinal))
					{
						this.d = global::x.a(this.b, "");
						Interlocked.Add(ref global::x.i, 1);
					}
					else if (0 == string.Compare(this.c, strB, StringComparison.Ordinal))
					{
						this.a = global::x.a(this.c, "");
						Interlocked.Add(ref global::x.i, 1);
					}
				}

				// Token: 0x04000132 RID: 306
				public string a;

				// Token: 0x04000133 RID: 307
				public string b;

				// Token: 0x04000134 RID: 308
				public string c;

				// Token: 0x04000135 RID: 309
				public string d;
			}
		}

		// Token: 0x02000051 RID: 81
		[CompilerGenerated]
		internal class o
		{
			// Token: 0x04000136 RID: 310
			public BackgroundWorker a;

			// Token: 0x04000137 RID: 311
			public string[] b;

			// Token: 0x04000138 RID: 312
			public bool c;

			// Token: 0x04000139 RID: 313
			public ParallelOptions d;

			// Token: 0x0400013A RID: 314
			public string e;

			// Token: 0x02000052 RID: 82
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0400013B RID: 315
				public MemoryStream a;

				// Token: 0x0400013C RID: 316
				public int b;

				// Token: 0x0400013D RID: 317
				public int c;

				// Token: 0x02000053 RID: 83
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000115 RID: 277 RVA: 0x0001B69C File Offset: 0x0001989C
					[CompilerGenerated]
					public void e(int A_0, ParallelLoopState A_1)
					{
						if (this.c.a.CancellationPending)
						{
							this.c.c = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.c.a.CancellationPending)
							{
								this.c.c = true;
								A_1.Stop();
							}
						}
						MemoryStream obj = this.d.a;
						Bitmap bitmap;
						lock (obj)
						{
							bitmap = (Bitmap)Image.FromStream(this.d.a);
						}
						Graphics graphics = Graphics.FromImage(bitmap);
						ArrayList obj2 = this.b;
						Bitmap bitmap2;
						lock (obj2)
						{
							bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.b[A_0]);
						}
						graphics.DrawImage(bitmap2, 0, 0, this.d.c, this.d.b);
						bitmap2.Dispose();
						string a_ = string.Concat(new string[]
						{
							this.c.e,
							this.c.b[0],
							"_",
							this.c.b[1].Replace("*", string.Empty),
							"_",
							Conversions.ToString(A_0)
						});
						global::x.a(a_, ref bitmap, true);
						bitmap.Dispose();
						Interlocked.Add(ref global::x.k, 1);
						this.c.a.ReportProgress(global::x.i);
						Thread.Sleep(global::x.c);
					}

					// Token: 0x06000116 RID: 278 RVA: 0x0001B870 File Offset: 0x00019A70
					[CompilerGenerated]
					public void f(int A_0, ParallelLoopState A_1)
					{
						BW2_three.o.a.a.a a = new BW2_three.o.a.a.a();
						a.b = this;
						a.a = A_0;
						if (a.b.c.a.CancellationPending)
						{
							a.b.c.c = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (a.b.c.a.CancellationPending)
							{
								a.b.c.c = true;
								A_1.Stop();
							}
						}
						if (0 < this.b.Count)
						{
							Parallel.For(0, this.b.Count, a.b.c.d, new Action<int, ParallelLoopState>(a.c));
						}
						else
						{
							MemoryStream obj = a.b.d.a;
							Bitmap bitmap;
							lock (obj)
							{
								bitmap = (Bitmap)Image.FromStream(a.b.d.a);
							}
							Graphics graphics = Graphics.FromImage(bitmap);
							ArrayList obj2 = this.a;
							Bitmap image;
							lock (obj2)
							{
								image = (Bitmap)Image.FromStream((MemoryStream)this.a[a.a]);
							}
							graphics.DrawImage(image, 0, 0, a.b.d.c, a.b.d.b);
							string a_ = a.b.c.e + a.b.c.b[0] + "_" + a.b.c.b[1].Replace("*", string.Empty);
							global::x.a(a_, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref global::x.k, 1);
							a.b.c.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
						}
					}

					// Token: 0x0400013E RID: 318
					public ArrayList a;

					// Token: 0x0400013F RID: 319
					public ArrayList b;

					// Token: 0x04000140 RID: 320
					public BW2_three.o c;

					// Token: 0x04000141 RID: 321
					public BW2_three.o.a d;

					// Token: 0x02000054 RID: 84
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000118 RID: 280 RVA: 0x0001BAB0 File Offset: 0x00019CB0
						[CompilerGenerated]
						public void c(int A_0, ParallelLoopState A_1)
						{
							if (this.b.c.a.CancellationPending)
							{
								this.b.c.c = true;
								A_1.Stop();
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (this.b.c.a.CancellationPending)
								{
									this.b.c.c = true;
									A_1.Stop();
								}
							}
							MemoryStream obj = this.b.d.a;
							Bitmap bitmap;
							lock (obj)
							{
								bitmap = (Bitmap)Image.FromStream(this.b.d.a);
							}
							Graphics graphics = Graphics.FromImage(bitmap);
							ArrayList obj2 = this.b.a;
							Bitmap bitmap2;
							lock (obj2)
							{
								bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.b.a[this.a]);
							}
							graphics.DrawImage(bitmap2, 0, 0, this.b.d.c, this.b.d.b);
							ArrayList obj3 = this.b.b;
							lock (obj3)
							{
								bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.b.b[A_0]);
							}
							graphics.DrawImage(bitmap2, 0, 0, this.b.d.c, this.b.d.b);
							bitmap2.Dispose();
							string a_ = string.Concat(new string[]
							{
								this.b.c.e,
								this.b.c.b[0],
								"_",
								this.b.c.b[1].Replace("*", string.Empty),
								"_",
								Conversions.ToString(this.a),
								"_",
								Conversions.ToString(A_0)
							});
							global::x.a(a_, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref global::x.k, 1);
							this.b.c.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
						}

						// Token: 0x04000142 RID: 322
						public int a;

						// Token: 0x04000143 RID: 323
						public BW2_three.o.a.a b;
					}
				}
			}
		}

		// Token: 0x02000055 RID: 85
		[CompilerGenerated]
		internal class p
		{
			// Token: 0x0600011A RID: 282 RVA: 0x0001BD6C File Offset: 0x00019F6C
			[CompilerGenerated]
			public void k(int A_0, ParallelLoopState A_1)
			{
				BW2_three.p.a a = new BW2_three.p.a();
				a.a = A_0;
				a.b = this;
				if (this.c.CancellationPending)
				{
					this.f = true;
					A_1.Stop();
				}
				while (global::x.a)
				{
					Thread.Sleep(500);
					if (this.c.CancellationPending)
					{
						this.f = true;
						A_1.Stop();
					}
				}
				Parallel.For(0, this.b.Count, this.i, new Action<int, ParallelLoopState>(a.c));
			}

			// Token: 0x04000144 RID: 324
			public ArrayList a;

			// Token: 0x04000145 RID: 325
			public ArrayList b;

			// Token: 0x04000146 RID: 326
			public BackgroundWorker c;

			// Token: 0x04000147 RID: 327
			public MemoryStream d;

			// Token: 0x04000148 RID: 328
			public string[] e;

			// Token: 0x04000149 RID: 329
			public bool f;

			// Token: 0x0400014A RID: 330
			public int g;

			// Token: 0x0400014B RID: 331
			public int h;

			// Token: 0x0400014C RID: 332
			public ParallelOptions i;

			// Token: 0x0400014D RID: 333
			public string j;

			// Token: 0x02000056 RID: 86
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600011C RID: 284 RVA: 0x0001BE04 File Offset: 0x0001A004
				[CompilerGenerated]
				public void c(int A_0, ParallelLoopState A_1)
				{
					if (this.b.c.CancellationPending)
					{
						this.b.f = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.b.c.CancellationPending)
						{
							this.b.f = true;
							A_1.Stop();
						}
					}
					MemoryStream d = this.b.d;
					Bitmap bitmap;
					lock (d)
					{
						bitmap = (Bitmap)Image.FromStream(this.b.d);
					}
					Graphics graphics = Graphics.FromImage(bitmap);
					ArrayList obj = this.b.a;
					Bitmap bitmap2;
					lock (obj)
					{
						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.b.a[this.a]);
					}
					graphics.DrawImage(bitmap2, 0, 0, this.b.h, this.b.g);
					ArrayList obj2 = this.b.b;
					lock (obj2)
					{
						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.b.b[A_0]);
					}
					graphics.DrawImage(bitmap2, 0, 0, this.b.h, this.b.g);
					bitmap2.Dispose();
					string a_ = string.Concat(new string[]
					{
						this.b.j,
						this.b.e[0],
						"_",
						this.b.e[1].Replace("*", string.Empty),
						"_",
						this.b.e[2].Replace("*", string.Empty),
						"_",
						Conversions.ToString(this.a),
						"_",
						Conversions.ToString(A_0)
					});
					global::x.a(a_, ref bitmap, true);
					bitmap.Dispose();
					Interlocked.Add(ref global::x.k, 1);
					this.b.c.ReportProgress(global::x.i);
					Thread.Sleep(global::x.c);
				}

				// Token: 0x0400014E RID: 334
				public int a;

				// Token: 0x0400014F RID: 335
				public BW2_three.p b;
			}
		}

		// Token: 0x02000057 RID: 87
		[CompilerGenerated]
		internal class e
		{
			// Token: 0x04000150 RID: 336
			public BackgroundWorker a;

			// Token: 0x04000151 RID: 337
			public string b;

			// Token: 0x04000152 RID: 338
			public string c;

			// Token: 0x04000153 RID: 339
			public bool d;

			// Token: 0x02000058 RID: 88
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600011E RID: 286 RVA: 0x0001C0A4 File Offset: 0x0001A2A4
				public a(BW2_three.e.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x0600011F RID: 287 RVA: 0x0001C0BB File Offset: 0x0001A2BB
				[DebuggerStepThrough]
				[CompilerGenerated]
				public void c(object A_0)
				{
					new global::k<string>(this.c)(Conversions.ToString(A_0));
				}

				// Token: 0x06000120 RID: 288 RVA: 0x0001C0D8 File Offset: 0x0001A2D8
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.b, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.c.Replace("_info", ""), CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x04000154 RID: 340
				public ArrayList a;

				// Token: 0x04000155 RID: 341
				public BW2_three.e b;

				// Token: 0x02000059 RID: 89
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000121 RID: 289 RVA: 0x0001C19C File Offset: 0x0001A39C
					public a(BW2_three.e.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.e = A_0.e;
							this.c = A_0.c;
							this.i = A_0.i;
							this.h = A_0.h;
							this.f = A_0.f;
							this.a = A_0.a;
							this.d = A_0.d;
							this.k = A_0.k;
							this.j = A_0.j;
							this.g = A_0.g;
						}
					}

					// Token: 0x06000122 RID: 290 RVA: 0x0001C239 File Offset: 0x0001A439
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void m(object A_0, ParallelLoopState A_1)
					{
						new global::o<string, ParallelLoopState>(this.m)(Conversions.ToString(A_0), A_1);
					}

					// Token: 0x06000123 RID: 291 RVA: 0x0001C254 File Offset: 0x0001A454
					[CompilerGenerated]
					public void m(string A_0, ParallelLoopState A_1)
					{
						if (this.l.a.CancellationPending)
						{
							this.l.d = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.l.a.CancellationPending)
							{
								this.l.d = true;
								A_1.Stop();
							}
						}
						string text = A_0.Substring(1);
						string[] array = global::x.ap.Split(text);
						string strA = array.First<string>();
						checked
						{
							if (0 == string.Compare(strA, this.c, StringComparison.Ordinal))
							{
								Bitmap bitmap = new Bitmap(this.k, this.j, PixelFormat.Format32bppArgb);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								string text2 = this.h + "_";
								int num = 0;
								int num2 = 1;
								int num3 = array.Count<string>() - 1;
								for (int i = num2; i <= num3; i++)
								{
									text = array[i];
									if (Strings.InStr(1, text, "ポーズ", CompareMethod.Binary) <= 0)
									{
										text2 += text;
										num++;
										if (num > this.i + 1)
										{
											break;
										}
										text2 += "_";
									}
								}
								text = global::x.a(text2, "");
								if (File.Exists(text))
								{
									return;
								}
								text2 = this.h + "_";
								num = 0;
								int num4 = 1;
								int num5 = array.Count<string>() - 1;
								for (int j = num4; j <= num5; j++)
								{
									text = array[j];
									if (Strings.InStr(1, text, "ポーズ", CompareMethod.Binary) <= 0)
									{
										if (0 == num)
										{
											int num6 = 0;
											int num7 = this.e.Count - 1;
											for (int k = num6; k <= num7; k++)
											{
												if (0 == string.Compare(Conversions.ToString(this.e[k]), text, StringComparison.Ordinal))
												{
													ArrayList obj = this.d;
													lock (obj)
													{
														using (Bitmap bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.d[k]))
														{
															graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
															break;
														}
													}
												}
											}
										}
										else if (1 == num)
										{
											int num8 = 0;
											int num9 = this.b.Count - 1;
											for (int l = num8; l <= num9; l++)
											{
												string[] array2 = global::x.ak.Split(text2);
												string strB = array2[array2.Length - 2] + "_" + text;
												if (0 == string.Compare(Conversions.ToString(this.b[l]), strB, StringComparison.Ordinal))
												{
													ArrayList obj2 = this.a;
													lock (obj2)
													{
														using (Bitmap bitmap3 = (Bitmap)Image.FromStream((MemoryStream)this.a[l]))
														{
															graphics.DrawImage(bitmap3, 0, 0, bitmap3.Width, bitmap3.Height);
															break;
														}
													}
												}
											}
										}
										else
										{
											int num10 = 0;
											int num11 = this.g.Count - 1;
											for (int m = num10; m <= num11; m++)
											{
												if (0 == string.Compare(Conversions.ToString(this.g[m]), text, StringComparison.Ordinal))
												{
													ArrayList obj3 = this.f;
													lock (obj3)
													{
														using (Bitmap bitmap4 = (Bitmap)Image.FromStream((MemoryStream)this.f[m]))
														{
															graphics.DrawImage(bitmap4, 0, 0, bitmap4.Width, bitmap4.Height);
															break;
														}
													}
												}
											}
										}
										text2 += text;
										num++;
										if (num > this.i + 1)
										{
											break;
										}
										text2 += "_";
									}
								}
								text = global::x.a(text2, ref bitmap, false);
								if (!string.IsNullOrEmpty(text))
								{
									Interlocked.Add(ref global::x.k, 1);
								}
								bitmap.Dispose();
								this.l.a.ReportProgress(global::x.i);
								Thread.Sleep(global::x.c);
							}
						}
					}

					// Token: 0x04000156 RID: 342
					public ArrayList a;

					// Token: 0x04000157 RID: 343
					public ArrayList b;

					// Token: 0x04000158 RID: 344
					public string c;

					// Token: 0x04000159 RID: 345
					public ArrayList d;

					// Token: 0x0400015A RID: 346
					public ArrayList e;

					// Token: 0x0400015B RID: 347
					public ArrayList f;

					// Token: 0x0400015C RID: 348
					public ArrayList g;

					// Token: 0x0400015D RID: 349
					public string h;

					// Token: 0x0400015E RID: 350
					public int i;

					// Token: 0x0400015F RID: 351
					public int j;

					// Token: 0x04000160 RID: 352
					public int k;

					// Token: 0x04000161 RID: 353
					public BW2_three.e l;
				}
			}
		}

		// Token: 0x0200005A RID: 90
		[CompilerGenerated]
		internal class g
		{
			// Token: 0x04000162 RID: 354
			public BackgroundWorker a;

			// Token: 0x04000163 RID: 355
			public bool b;

			// Token: 0x0200005B RID: 91
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000126 RID: 294 RVA: 0x0001C704 File Offset: 0x0001A904
				[DebuggerStepThrough]
				[CompilerGenerated]
				public void c(object A_0, ParallelLoopState A_1)
				{
					new global::p<string, ParallelLoopState>(this.c)(Conversions.ToString(A_0), A_1);
				}

				// Token: 0x06000127 RID: 295 RVA: 0x0001C720 File Offset: 0x0001A920
				[CompilerGenerated]
				public void c(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref global::x.i, 1);
					if (this.b.a.CancellationPending)
					{
						this.b.b = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.b.a.CancellationPending)
						{
							this.b.b = true;
							A_1.Stop();
						}
					}
					checked
					{
						if (string.IsNullOrEmpty(global::x.a(A_0, "")))
						{
							string[] array = global::x.ak.Split(A_0);
							string str = array[0] + "_" + array[1] + "_";
							string text = array.Last<string>();
							string path = "";
							Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
							char[] array2 = Conversions.ToCharArrayRankOne("#######");
							int num = 0;
							int num2 = text.Length - 1;
							for (int i = num; i <= num2; i++)
							{
								if (this.b.a.CancellationPending)
								{
									this.b.b = true;
									A_1.Stop();
									return;
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (this.b.a.CancellationPending)
									{
										this.b.b = true;
										A_1.Stop();
										return;
									}
								}
								if (i < 3)
								{
									array2[i] = text[i];
								}
								else if (i == 3)
								{
									string a_ = str + new string(array2);
									ArrayList obj = this.a;
									string text2;
									lock (obj)
									{
										text2 = global::x.a(ref this.a, a_);
									}
									if (File.Exists(text2))
									{
										bitmap.Dispose();
										path = Path.GetDirectoryName(text2);
										Bitmap bitmap2 = global::x.a(text2);
										bitmap = new Bitmap(bitmap2.Width, bitmap2.Height, global::x.a(bitmap2.PixelFormat));
										Graphics graphics = Graphics.FromImage(bitmap);
										graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
										graphics.Dispose();
										bitmap2.Dispose();
										ArrayList f = global::x.f;
										lock (f)
										{
											global::x.f.Add(text2);
										}
									}
									array2[0] = '#';
									array2[1] = '#';
									array2[2] = 'Y';
									array2[i] = text[i];
									a_ = str + new string(array2);
									ArrayList obj2 = this.a;
									lock (obj2)
									{
										text2 = global::x.a(ref this.a, a_);
									}
									if (File.Exists(text2))
									{
										Bitmap bitmap3 = global::x.a(text2);
										Graphics graphics2 = Graphics.FromImage(bitmap);
										graphics2.DrawImage(bitmap3, 0, 0, bitmap3.Width, bitmap3.Height);
										graphics2.Dispose();
										bitmap3.Dispose();
										ArrayList f2 = global::x.f;
										lock (f2)
										{
											global::x.f.Add(text2);
										}
									}
								}
								else if (i > 3)
								{
									array2[i - 1] = '#';
									array2[i] = text[i];
									string a_ = str + new string(array2);
									ArrayList obj3 = this.a;
									string text2;
									lock (obj3)
									{
										text2 = global::x.a(ref this.a, a_);
									}
									if (File.Exists(text2))
									{
										Bitmap bitmap4 = global::x.a(text2);
										Graphics graphics3 = Graphics.FromImage(bitmap);
										graphics3.DrawImage(bitmap4, 0, 0, bitmap4.Width, bitmap4.Height);
										graphics3.Dispose();
										bitmap4.Dispose();
										ArrayList f3 = global::x.f;
										lock (f3)
										{
											global::x.f.Add(text2);
										}
									}
								}
							}
							global::x.a(Path.Combine(path, A_0), ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref global::x.k, 1);
							this.b.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
						}
					}
				}

				// Token: 0x04000164 RID: 356
				public ArrayList a;

				// Token: 0x04000165 RID: 357
				public BW2_three.g b;
			}
		}

		// Token: 0x0200005C RID: 92
		[CompilerGenerated]
		internal class f
		{
			// Token: 0x04000166 RID: 358
			public BackgroundWorker a;

			// Token: 0x04000167 RID: 359
			public string b;

			// Token: 0x04000168 RID: 360
			public bool c;

			// Token: 0x0200005D RID: 93
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000129 RID: 297 RVA: 0x0001CBA8 File Offset: 0x0001ADA8
				public a(BW2_three.f.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x04000169 RID: 361
				public bool a;

				// Token: 0x0200005E RID: 94
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0400016A RID: 362
					public string[] a;

					// Token: 0x0400016B RID: 363
					public string b;

					// Token: 0x0200005F RID: 95
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x0600012C RID: 300 RVA: 0x0001CBD0 File Offset: 0x0001ADD0
						[CompilerGenerated]
						public void g(int A_0, ParallelLoopState A_1)
						{
							Interlocked.Add(ref global::x.i, 1);
							if (this.d.a.CancellationPending)
							{
								this.d.c = true;
								A_1.Stop();
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (this.d.a.CancellationPending)
								{
									this.d.c = true;
									A_1.Stop();
								}
							}
							MemoryStream obj = this.a;
							Bitmap bitmap;
							lock (obj)
							{
								bitmap = (Bitmap)Image.FromStream(this.a);
							}
							MemoryStream obj2 = this.b;
							Bitmap bitmap2;
							lock (obj2)
							{
								bitmap2 = (Bitmap)Image.FromStream(this.b);
							}
							Graphics graphics = Graphics.FromImage(bitmap);
							int width = Conversions.ToInteger(this.f.a[3]);
							int height = Conversions.ToInteger(this.f.a[4]);
							Rectangle rect = new Rectangle(Conversions.ToInteger(this.c[A_0]), 0, width, height);
							BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
							Bitmap bitmap3 = new Bitmap(width, height, bitmapData.Stride, bitmap2.PixelFormat, bitmapData.Scan0);
							bitmap2.UnlockBits(bitmapData);
							graphics.DrawImage(bitmap3, Conversions.ToInteger(this.f.a[1]), Conversions.ToInteger(this.f.a[2]), bitmap3.Width, bitmap3.Height);
							graphics.Dispose();
							bitmap3.Dispose();
							bitmap2.Dispose();
							string a_ = Path.Combine(this.d.b, Path.GetFileNameWithoutExtension(this.f.b) + "_" + Conversions.ToString(A_0));
							global::x.a(a_, ref bitmap, true);
							this.e.a = true;
							Interlocked.Add(ref global::x.k, 1);
							bitmap.Dispose();
							this.d.a.ReportProgress(global::x.i);
						}

						// Token: 0x0400016C RID: 364
						public MemoryStream a;

						// Token: 0x0400016D RID: 365
						public MemoryStream b;

						// Token: 0x0400016E RID: 366
						public ArrayList c;

						// Token: 0x0400016F RID: 367
						public BW2_three.f d;

						// Token: 0x04000170 RID: 368
						public BW2_three.f.a e;

						// Token: 0x04000171 RID: 369
						public BW2_three.f.a.a f;
					}
				}
			}
		}

		// Token: 0x02000060 RID: 96
		[CompilerGenerated]
		internal class i
		{
			// Token: 0x04000172 RID: 370
			public BackgroundWorker a;

			// Token: 0x04000173 RID: 371
			public string b;

			// Token: 0x04000174 RID: 372
			public bool c;

			// Token: 0x02000061 RID: 97
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600012E RID: 302 RVA: 0x0001CE10 File Offset: 0x0001B010
				public a(BW2_three.i.a A_0)
				{
					if (A_0 != null)
					{
						this.i = A_0.i;
						this.f = A_0.f;
						this.n = A_0.n;
						this.c = A_0.c;
						this.k = A_0.k;
						this.p = A_0.p;
						this.e = A_0.e;
						this.a = A_0.a;
						this.m = A_0.m;
						this.d = A_0.d;
						this.o = A_0.o;
						this.h = A_0.h;
						this.b = A_0.b;
						this.l = A_0.l;
						this.j = A_0.j;
						this.g = A_0.g;
					}
				}

				// Token: 0x0600012F RID: 303 RVA: 0x0001CEE9 File Offset: 0x0001B0E9
				[DebuggerStepThrough]
				[CompilerGenerated]
				public void r(object A_0)
				{
					new u<string>(this.r)(Conversions.ToString(A_0));
				}

				// Token: 0x06000130 RID: 304 RVA: 0x0001CF04 File Offset: 0x0001B104
				[CompilerGenerated]
				public void r(string A_0)
				{
					if (Strings.InStr(1, A_0, this.p + "body_", CompareMethod.Binary) > 0)
					{
						ArrayList obj = this.a;
						lock (obj)
						{
							this.a.Add(A_0);
						}
						ArrayList obj2 = global::x.f;
						lock (obj2)
						{
							global::x.f.Add(A_0);
							return;
						}
					}
					if (Strings.InStr(1, A_0, this.p + "brow_", CompareMethod.Binary) > 0)
					{
						ArrayList obj3 = this.f;
						lock (obj3)
						{
							this.f.Add(A_0);
						}
						ArrayList obj4 = global::x.f;
						lock (obj4)
						{
							global::x.f.Add(A_0);
							return;
						}
					}
					if (Strings.InStr(1, A_0, this.p + "cheek_", CompareMethod.Binary) > 0)
					{
						ArrayList obj5 = this.g;
						lock (obj5)
						{
							this.g.Add(A_0);
						}
						ArrayList obj6 = global::x.f;
						lock (obj6)
						{
							global::x.f.Add(A_0);
							return;
						}
					}
					if (Strings.InStr(1, A_0, this.p + "eye_", CompareMethod.Binary) > 0)
					{
						ArrayList obj7 = this.h;
						lock (obj7)
						{
							this.h.Add(A_0);
						}
						ArrayList obj8 = global::x.f;
						lock (obj8)
						{
							global::x.f.Add(A_0);
							return;
						}
					}
					if (Strings.InStr(1, A_0, this.p + "mouth_", CompareMethod.Binary) > 0)
					{
						ArrayList obj9 = this.m;
						lock (obj9)
						{
							this.m.Add(A_0);
						}
						ArrayList obj10 = global::x.f;
						lock (obj10)
						{
							global::x.f.Add(A_0);
							return;
						}
					}
					if (Strings.InStr(1, A_0, this.p, CompareMethod.Binary) > 0)
					{
						ArrayList obj11 = this.o;
						lock (obj11)
						{
							this.o.Add(A_0);
						}
					}
				}

				// Token: 0x06000131 RID: 305 RVA: 0x0001D244 File Offset: 0x0001B444
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void r(object A_0, ParallelLoopState A_1)
				{
					new w<string, ParallelLoopState>(this.r)(Conversions.ToString(A_0), A_1);
				}

				// Token: 0x06000132 RID: 306 RVA: 0x0001D260 File Offset: 0x0001B460
				[CompilerGenerated]
				public void r(string A_0, ParallelLoopState A_1)
				{
					if (this.q.a.CancellationPending)
					{
						this.q.c = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.q.a.CancellationPending)
						{
							this.q.c = true;
							A_1.Stop();
						}
					}
					string text = Path.ChangeExtension(A_0, "anm");
					string text2 = Path.ChangeExtension(A_0, "asd");
					checked
					{
						if (File.Exists(text) & File.Exists(text2))
						{
							Interlocked.Add(ref global::x.i, 2);
							ArrayList obj = global::x.f;
							lock (obj)
							{
								global::x.f.Add(text);
								global::x.f.Add(text2);
							}
							string[] array = kirikiri2_fun.readAnmToArr(text);
							int x = Conversions.ToInteger(array[1]);
							int y = Conversions.ToInteger(array[2]);
							int num = Conversions.ToInteger(array[3]);
							int height = Conversions.ToInteger(array[4]);
							ArrayList arrayList = kirikiri2_fun.readAsdToArr(text2);
							string text3 = Path.GetFileNameWithoutExtension(A_0);
							string[] source = global::x.ak.Split(text3);
							string str = source.Last<string>();
							text3 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_brow_"));
							string a_ = text3 + Path.GetExtension(A_0);
							text3 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_sp1_"));
							string text4 = text3 + Path.GetExtension(A_0);
							text3 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_sp2_"));
							string text5 = text3 + Path.GetExtension(A_0);
							text3 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_tear_"));
							string text6 = text3 + Path.GetExtension(A_0);
							bool flag2 = false;
							bool flag3 = false;
							bool flag4 = false;
							MemoryStream memoryStream = new MemoryStream();
							MemoryStream memoryStream2 = new MemoryStream();
							MemoryStream memoryStream3 = new MemoryStream();
							MemoryStream memoryStream4 = new MemoryStream();
							MemoryStream memoryStream5 = new MemoryStream();
							Bitmap bitmap = global::x.a(A_0);
							bitmap.Save(memoryStream, ImageFormat.Png);
							bitmap.Dispose();
							bitmap = global::x.a(a_);
							bitmap.Save(memoryStream2, ImageFormat.Png);
							bitmap.Dispose();
							if (File.Exists(text4))
							{
								bitmap = global::x.a(text4);
								bitmap.Save(memoryStream3, ImageFormat.Png);
								bitmap.Dispose();
								flag2 = true;
								ArrayList obj2 = global::x.f;
								lock (obj2)
								{
									global::x.f.Add(text4);
								}
							}
							if (File.Exists(text5))
							{
								bitmap = global::x.a(text5);
								bitmap.Save(memoryStream5, ImageFormat.Png);
								bitmap.Dispose();
								flag4 = true;
								ArrayList obj3 = global::x.f;
								lock (obj3)
								{
									global::x.f.Add(text5);
								}
							}
							if (File.Exists(text6))
							{
								bitmap = global::x.a(text6);
								bitmap.Save(memoryStream4, ImageFormat.Png);
								bitmap.Dispose();
								flag3 = true;
								ArrayList obj4 = global::x.f;
								lock (obj4)
								{
									global::x.f.Add(text6);
								}
							}
							int num2 = arrayList.Count - 1;
							int num3 = 0;
							int num4 = num2;
							for (int i = num3; i <= num4; i++)
							{
								Bitmap bitmap2 = new Bitmap(this.c, this.b, this.n);
								Graphics graphics = Graphics.FromImage(bitmap2);
								graphics.Clear(Color.Transparent);
								Bitmap bitmap3 = (Bitmap)Image.FromStream(memoryStream);
								int num5 = num * i;
								if (num5 >= bitmap3.Width)
								{
									num5 = bitmap3.Width - num5;
									if (0 > num5)
									{
										num5 = 0;
									}
								}
								Rectangle rect = new Rectangle(num5, 0, num, height);
								BitmapData bitmapData = bitmap3.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								Bitmap bitmap4 = new Bitmap(num, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
								bitmap3.UnlockBits(bitmapData);
								graphics.DrawImage(bitmap4, x, y, num, height);
								bitmap4.Dispose();
								bitmap3.Dispose();
								Bitmap bitmap5 = (Bitmap)Image.FromStream(memoryStream2);
								num5 = num * i;
								if (num5 >= bitmap5.Width)
								{
									num5 = bitmap5.Width - num5;
									if (0 > num5)
									{
										num5 = 0;
									}
								}
								rect = new Rectangle(num5, 0, num, height);
								bitmapData = bitmap5.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								bitmap4 = new Bitmap(num, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
								bitmap5.UnlockBits(bitmapData);
								graphics.DrawImage(bitmap4, x, y, num, height);
								bitmap4.Dispose();
								bitmap5.Dispose();
								if (flag2)
								{
									Bitmap bitmap6 = (Bitmap)Image.FromStream(memoryStream3);
									if (num == bitmap6.Width)
									{
										graphics.DrawImage(bitmap6, this.k, this.l, num, height);
									}
									else
									{
										rect = new Rectangle(num * i, 0, num, height);
										bitmapData = bitmap6.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
										bitmap4 = new Bitmap(num, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
										bitmap6.UnlockBits(bitmapData);
										graphics.DrawImage(bitmap4, x, y, num, height);
										bitmap4.Dispose();
									}
									bitmap6.Dispose();
								}
								if (flag3)
								{
									Bitmap bitmap7 = (Bitmap)Image.FromStream(memoryStream4);
									if (num == bitmap7.Width)
									{
										graphics.DrawImage(bitmap7, this.k, this.l, num, height);
									}
									else
									{
										rect = new Rectangle(num * i, 0, num, height);
										bitmapData = bitmap7.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
										bitmap4 = new Bitmap(num, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
										bitmap7.UnlockBits(bitmapData);
										graphics.DrawImage(bitmap4, x, y, num, height);
										bitmap4.Dispose();
									}
									bitmap7.Dispose();
								}
								if (flag4)
								{
									Bitmap bitmap8 = (Bitmap)Image.FromStream(memoryStream5);
									if (num == bitmap8.Width)
									{
										graphics.DrawImage(bitmap8, this.k, this.l, num, height);
									}
									else
									{
										rect = new Rectangle(num * i, 0, num, height);
										bitmapData = bitmap8.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
										bitmap4 = new Bitmap(num, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
										bitmap8.UnlockBits(bitmapData);
										graphics.DrawImage(bitmap4, x, y, num, height);
										bitmap4.Dispose();
									}
									bitmap8.Dispose();
								}
								MemoryStream memoryStream6 = new MemoryStream();
								bitmap2.Save(memoryStream6, ImageFormat.Png);
								ArrayList obj5 = this.d;
								lock (obj5)
								{
									this.d.Add(memoryStream6);
									this.e.Add(str + "_" + i.ToString("D3"));
								}
								bitmap2.Dispose();
							}
							this.q.a.ReportProgress(global::x.i);
							memoryStream.Dispose();
							memoryStream2.Dispose();
							memoryStream3.Dispose();
							memoryStream4.Dispose();
							memoryStream5.Dispose();
						}
						else
						{
							Interlocked.Add(ref global::x.i, 2);
							string text7 = Path.GetFileNameWithoutExtension(A_0);
							string[] source2 = global::x.ak.Split(text7);
							string text8 = source2.Last<string>();
							Bitmap bitmap9 = new Bitmap(this.c, this.b, this.n);
							Graphics graphics2 = Graphics.FromImage(bitmap9);
							graphics2.Clear(Color.Transparent);
							Bitmap bitmap10 = global::x.a(A_0);
							graphics2.DrawImage(bitmap10, this.k, this.l, bitmap10.Width, bitmap10.Height);
							bitmap10.Dispose();
							try
							{
								foreach (object value in this.f)
								{
									string text9 = Conversions.ToString(value);
									text7 = Path.GetFileNameWithoutExtension(text9);
									source2 = global::x.ak.Split(text7);
									string strA = source2.Last<string>();
									if (0 == string.Compare(strA, text8, StringComparison.Ordinal))
									{
										bitmap10 = global::x.a(text9);
										graphics2.DrawImage(bitmap10, this.k, this.l, bitmap10.Width, bitmap10.Height);
										bitmap10.Dispose();
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
							text7 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_sp1_"));
							string text10 = text7 + Path.GetExtension(A_0);
							text7 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_tear_"));
							string text11 = text7 + Path.GetExtension(A_0);
							text7 = Path.Combine(Path.GetDirectoryName(A_0), Path.GetFileNameWithoutExtension(A_0).Replace("_eye_", "_sp2_"));
							string text12 = text7 + Path.GetExtension(A_0);
							if (File.Exists(text10))
							{
								bitmap10 = global::x.a(text10);
								graphics2.DrawImage(bitmap10, this.k, this.l, bitmap10.Width, bitmap10.Height);
								bitmap10.Dispose();
								ArrayList obj6 = global::x.f;
								lock (obj6)
								{
									global::x.f.Add(text10);
								}
							}
							if (File.Exists(text11))
							{
								bitmap10 = global::x.a(text11);
								graphics2.DrawImage(bitmap10, this.k, this.l, bitmap10.Width, bitmap10.Height);
								bitmap10.Dispose();
								ArrayList obj7 = global::x.f;
								lock (obj7)
								{
									global::x.f.Add(text11);
								}
							}
							if (File.Exists(text12))
							{
								bitmap10 = global::x.a(text12);
								graphics2.DrawImage(bitmap10, this.k, this.l, bitmap10.Width, bitmap10.Height);
								bitmap10.Dispose();
								ArrayList obj8 = global::x.f;
								lock (obj8)
								{
									global::x.f.Add(text12);
								}
							}
							MemoryStream memoryStream7 = new MemoryStream();
							bitmap9.Save(memoryStream7, ImageFormat.Png);
							ArrayList obj9 = this.d;
							lock (obj9)
							{
								this.d.Add(memoryStream7);
								this.e.Add(text8);
							}
							bitmap9.Dispose();
							this.q.a.ReportProgress(global::x.i);
						}
					}
				}

				// Token: 0x06000133 RID: 307 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
				[CompilerGenerated]
				public void r(int A_0, ParallelLoopState A_1)
				{
					if (this.q.a.CancellationPending)
					{
						this.q.c = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.q.a.CancellationPending)
						{
							this.q.c = true;
							A_1.Stop();
						}
					}
					Bitmap bitmap = new Bitmap(this.c, this.b, this.n);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.Clear(Color.Transparent);
					string[] source = global::x.ak.Split(Conversions.ToString(this.e[A_0]));
					string strB = source.First<string>();
					Bitmap bitmap2;
					try
					{
						foreach (object value in this.g)
						{
							string text = Conversions.ToString(value);
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
							source = global::x.ak.Split(fileNameWithoutExtension);
							string strA = source.Last<string>();
							if (0 == string.Compare(strA, strB, StringComparison.Ordinal))
							{
								bitmap2 = global::x.a(text);
								graphics.DrawImage(bitmap2, this.k, this.l, bitmap2.Width, bitmap2.Height);
								bitmap2.Dispose();
								Interlocked.Add(ref global::x.i, 1);
								this.q.a.ReportProgress(global::x.i);
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
					try
					{
						foreach (object value2 in this.m)
						{
							string text2 = Conversions.ToString(value2);
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
							source = global::x.ak.Split(fileNameWithoutExtension);
							string strA2 = source.Last<string>();
							if (0 == string.Compare(strA2, strB, StringComparison.Ordinal))
							{
								bitmap2 = global::x.a(text2);
								graphics.DrawImage(bitmap2, this.k, this.l, bitmap2.Width, bitmap2.Height);
								bitmap2.Dispose();
								Interlocked.Add(ref global::x.i, 1);
								this.q.a.ReportProgress(global::x.i);
								break;
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.d[A_0]);
					graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
					bitmap2.Dispose();
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Png);
					ArrayList obj = this.i;
					lock (obj)
					{
						this.i.Add(memoryStream);
						this.j.Add(RuntimeHelpers.GetObjectValue(this.e[A_0]));
					}
					bitmap.Dispose();
				}

				// Token: 0x04000175 RID: 373
				public ArrayList a;

				// Token: 0x04000176 RID: 374
				public int b;

				// Token: 0x04000177 RID: 375
				public int c;

				// Token: 0x04000178 RID: 376
				public ArrayList d;

				// Token: 0x04000179 RID: 377
				public ArrayList e;

				// Token: 0x0400017A RID: 378
				public ArrayList f;

				// Token: 0x0400017B RID: 379
				public ArrayList g;

				// Token: 0x0400017C RID: 380
				public ArrayList h;

				// Token: 0x0400017D RID: 381
				public ArrayList i;

				// Token: 0x0400017E RID: 382
				public ArrayList j;

				// Token: 0x0400017F RID: 383
				public int k;

				// Token: 0x04000180 RID: 384
				public int l;

				// Token: 0x04000181 RID: 385
				public ArrayList m;

				// Token: 0x04000182 RID: 386
				public PixelFormat n;

				// Token: 0x04000183 RID: 387
				public ArrayList o;

				// Token: 0x04000184 RID: 388
				public string p;

				// Token: 0x04000185 RID: 389
				public BW2_three.i q;

				// Token: 0x02000062 RID: 98
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000134 RID: 308 RVA: 0x0001E0C8 File Offset: 0x0001C2C8
					public a(BW2_three.i.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.a = A_0.a;
							this.c = A_0.c;
						}
					}

					// Token: 0x04000186 RID: 390
					public int a;

					// Token: 0x04000187 RID: 391
					public int b;

					// Token: 0x04000188 RID: 392
					public string c;

					// Token: 0x02000063 RID: 99
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000136 RID: 310 RVA: 0x0001E100 File Offset: 0x0001C300
						[CompilerGenerated]
						public void e(int A_0, ParallelLoopState A_1)
						{
							if (this.b.a.CancellationPending)
							{
								this.b.c = true;
								A_1.Stop();
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (this.b.a.CancellationPending)
								{
									this.b.c = true;
									A_1.Stop();
								}
							}
							Bitmap bitmap = new Bitmap(this.d.b, this.d.a, this.c.n);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							Bitmap obj = this.a;
							lock (obj)
							{
								graphics.DrawImage(this.a, 0, 0, this.d.b, this.d.a);
							}
							graphics.DrawImage(Image.FromStream((MemoryStream)this.c.i[A_0]), 0, 0, this.c.c, this.c.b);
							graphics.Dispose();
							string a_ = Conversions.ToString(Operators.ConcatenateObject(Path.Combine(this.b.b, Path.GetFileNameWithoutExtension(this.d.c)) + "_", this.c.j[A_0]));
							global::x.a(a_, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref global::x.k, 1);
							this.b.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
						}

						// Token: 0x04000189 RID: 393
						public Bitmap a;

						// Token: 0x0400018A RID: 394
						public BW2_three.i b;

						// Token: 0x0400018B RID: 395
						public BW2_three.i.a c;

						// Token: 0x0400018C RID: 396
						public BW2_three.i.a.a d;
					}
				}
			}
		}

		// Token: 0x02000064 RID: 100
		[CompilerGenerated]
		internal class k
		{
			// Token: 0x06000137 RID: 311 RVA: 0x0001E2B4 File Offset: 0x0001C4B4
			public k(BW2_three.k A_0)
			{
				if (A_0 != null)
				{
					this.a = A_0.a;
					this.b = A_0.b;
					this.c = A_0.c;
				}
			}

			// Token: 0x0400018D RID: 397
			public BackgroundWorker a;

			// Token: 0x0400018E RID: 398
			public bool b;

			// Token: 0x0400018F RID: 399
			public string[] c;

			// Token: 0x02000065 RID: 101
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000138 RID: 312 RVA: 0x0001E2E4 File Offset: 0x0001C4E4
				public a(BW2_three.k.a A_0)
				{
					if (A_0 != null)
					{
						this.d = A_0.d;
						this.a = A_0.a;
						this.c = A_0.c;
						this.g = A_0.g;
						this.b = A_0.b;
						this.f = A_0.f;
						this.e = A_0.e;
						this.i = A_0.i;
						this.j = A_0.j;
						this.h = A_0.h;
					}
				}

				// Token: 0x06000139 RID: 313 RVA: 0x0001E374 File Offset: 0x0001C574
				[CompilerGenerated]
				public void l(int A_0, ParallelLoopState A_1)
				{
					if (this.k.a.CancellationPending)
					{
						this.k.b = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.k.a.CancellationPending)
						{
							this.k.b = true;
							A_1.Stop();
						}
					}
					Bitmap bitmap = new Bitmap(this.f, this.e, this.i);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.Clear(Color.Transparent);
					MemoryStream obj = this.d;
					lock (obj)
					{
						graphics.DrawImage(Image.FromStream(this.d), 0, 0, this.f, this.e);
					}
					Bitmap bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.g[A_0]);
					graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
					bitmap2.Dispose();
					graphics.Dispose();
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Png);
					bitmap.Dispose();
					this.k.c = global::x.ak.Split(Conversions.ToString(this.h[A_0]));
					string @string = this.k.c[0] + "_" + this.k.c[1];
					int num = 0;
					checked
					{
						int num2 = this.b.Count - 1;
						for (int i = num; i <= num2; i++)
						{
							string text = Conversions.ToString(this.b[i]);
							if (Strings.InStr(1, text, @string, CompareMethod.Binary) > 0)
							{
								bitmap = new Bitmap(this.f, this.e, this.i);
								graphics = Graphics.FromImage(bitmap);
								graphics.DrawImage(Image.FromStream(memoryStream), 0, 0, this.f, this.e);
								graphics.DrawImage(Image.FromStream((MemoryStream)this.a[i]), 0, 0, this.f, this.e);
								graphics.Dispose();
								string a_ = Path.Combine(this.c, Conversions.ToString(Operators.ConcatenateObject(Path.GetFileNameWithoutExtension(this.j) + "_", this.h[A_0]))) + "_" + text;
								global::x.a(a_, ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref global::x.k, 1);
							}
						}
						memoryStream.Dispose();
						this.k.a.ReportProgress(global::x.i);
						Thread.Sleep(global::x.c);
					}
				}

				// Token: 0x04000190 RID: 400
				public ArrayList a;

				// Token: 0x04000191 RID: 401
				public ArrayList b;

				// Token: 0x04000192 RID: 402
				public string c;

				// Token: 0x04000193 RID: 403
				public MemoryStream d;

				// Token: 0x04000194 RID: 404
				public int e;

				// Token: 0x04000195 RID: 405
				public int f;

				// Token: 0x04000196 RID: 406
				public ArrayList g;

				// Token: 0x04000197 RID: 407
				public ArrayList h;

				// Token: 0x04000198 RID: 408
				public PixelFormat i;

				// Token: 0x04000199 RID: 409
				public string j;

				// Token: 0x0400019A RID: 410
				public BW2_three.k k;
			}
		}

		// Token: 0x02000066 RID: 102
		[CompilerGenerated]
		internal class j
		{
			// Token: 0x0400019B RID: 411
			public BackgroundWorker a;

			// Token: 0x0400019C RID: 412
			public string b;

			// Token: 0x0400019D RID: 413
			public string c;

			// Token: 0x0400019E RID: 414
			public bool d;

			// Token: 0x0400019F RID: 415
			public bool e;

			// Token: 0x040001A0 RID: 416
			public ParallelOptions f;

			// Token: 0x02000067 RID: 103
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600013B RID: 315 RVA: 0x0001E640 File Offset: 0x0001C840
				public a(BW2_three.j.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x0600013C RID: 316 RVA: 0x0001E658 File Offset: 0x0001C858
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.b, CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x040001A1 RID: 417
				public ArrayList a;

				// Token: 0x040001A2 RID: 418
				public BW2_three.j b;

				// Token: 0x02000068 RID: 104
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600013D RID: 317 RVA: 0x0001E708 File Offset: 0x0001C908
					public a(BW2_three.j.a.a A_0)
					{
						if (A_0 != null)
						{
							this.g = A_0.g;
							this.a = A_0.a;
							this.d = A_0.d;
							this.j = A_0.j;
							this.i = A_0.i;
							this.f = A_0.f;
							this.e = A_0.e;
							this.b = A_0.b;
							this.h = A_0.h;
							this.c = A_0.c;
						}
					}

					// Token: 0x0600013E RID: 318 RVA: 0x0001E796 File Offset: 0x0001C996
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void l(object A_0, ParallelLoopState A_1)
					{
						new global::n<string[], ParallelLoopState>(this.l)((string[])A_0, A_1);
					}

					// Token: 0x0600013F RID: 319 RVA: 0x0001E7B4 File Offset: 0x0001C9B4
					[CompilerGenerated]
					public void l(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref global::x.i, 1);
						if (this.k.a.CancellationPending)
						{
							this.k.e = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.k.a.CancellationPending)
							{
								this.k.e = true;
								A_1.Stop();
							}
						}
						if (string.IsNullOrWhiteSpace(A_0[0]))
						{
							return;
						}
						string text = global::x.a(this.h, "_" + A_0[1]);
						if (File.Exists(text))
						{
							global::x.f.Add(text);
							MemoryStream memoryStream = new MemoryStream();
							using (Bitmap bitmap = global::x.a(text))
							{
								bitmap.Save(memoryStream, ImageFormat.Png);
							}
							string text2 = A_0[0];
							try
							{
								foreach (object obj in this.a)
								{
									string[] array = (string[])obj;
									Interlocked.Add(ref global::x.i, 1);
									string text3 = array[0];
									if (!string.IsNullOrWhiteSpace(text3))
									{
										string text4 = global::x.a(this.h, "_" + array[1]);
										if (File.Exists(text4))
										{
											global::x.f.Add(text4);
											Bitmap bitmap2 = new Bitmap(this.j, this.i, PixelFormat.Format32bppArgb);
											Graphics graphics = Graphics.FromImage(bitmap2);
											graphics.Clear(Color.Transparent);
											Bitmap bitmap3 = (Bitmap)Image.FromStream(memoryStream);
											graphics.DrawImage(bitmap3, Conversions.ToInteger(A_0[2]), Conversions.ToInteger(A_0[3]), bitmap3.Width, bitmap3.Height);
											bitmap3 = global::x.a(text4);
											graphics.DrawImage(bitmap3, Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3]), bitmap3.Width, bitmap3.Height);
											graphics.Dispose();
											MemoryStream memoryStream2 = new MemoryStream();
											bitmap2.Save(memoryStream2, ImageFormat.Png);
											ArrayList obj2 = this.c;
											lock (obj2)
											{
												this.c.Add(memoryStream2);
											}
											ArrayList obj3 = this.d;
											lock (obj3)
											{
												this.d.Add(new string[]
												{
													text2,
													array[6],
													text2 + "_" + text3
												});
											}
											bitmap3.Dispose();
											bitmap2.Dispose();
											Thread.Sleep(global::x.c);
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
							memoryStream.Dispose();
						}
					}

					// Token: 0x06000140 RID: 320 RVA: 0x0001EADC File Offset: 0x0001CCDC
					[CompilerGenerated]
					public void l(int A_0, ParallelLoopState A_1)
					{
						if (this.k.a.CancellationPending)
						{
							this.k.e = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.k.a.CancellationPending)
							{
								this.k.e = true;
								A_1.Stop();
							}
						}
						string[] array = (string[])this.d[A_0];
						Bitmap bitmap = (Bitmap)Image.FromStream((MemoryStream)this.c[A_0]);
						Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Width, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
						try
						{
							foreach (object obj in this.e)
							{
								string[] array2 = (string[])obj;
								if (0 == string.Compare(array2[0], array[0], StringComparison.Ordinal))
								{
									string text = array2[6];
									string text2 = array[1];
									if (Strings.InStr(1, text, "/", CompareMethod.Binary) > 0)
									{
										string[] array3 = array2[6].Split(new char[]
										{
											'/'
										});
										text = array3[0];
									}
									if (Strings.InStr(1, text2, "/", CompareMethod.Binary) > 0)
									{
										string[] array4 = array[1].Split(new char[]
										{
											'/'
										});
										text2 = array4[0];
									}
									if (0 != string.Compare(text, text2, StringComparison.Ordinal))
									{
										string text3 = global::x.a(this.h, "_" + array2[1]);
										if (File.Exists(text3))
										{
											global::x.f.Add(text3);
											bitmap = global::x.a(text3);
											graphics.DrawImage(bitmap, Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3]), bitmap.Width, bitmap.Height);
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
						graphics.Dispose();
						MemoryStream memoryStream = new MemoryStream();
						bitmap2.Save(memoryStream, ImageFormat.Png);
						ArrayList obj2 = this.f;
						lock (obj2)
						{
							this.f.Add(memoryStream);
						}
						ArrayList obj3 = this.g;
						lock (obj3)
						{
							this.g.Add(array[2]);
						}
						bitmap2.Dispose();
						bitmap.Dispose();
						Thread.Sleep(global::x.c);
					}

					// Token: 0x040001A3 RID: 419
					public ArrayList a;

					// Token: 0x040001A4 RID: 420
					public ArrayList b;

					// Token: 0x040001A5 RID: 421
					public ArrayList c;

					// Token: 0x040001A6 RID: 422
					public ArrayList d;

					// Token: 0x040001A7 RID: 423
					public ArrayList e;

					// Token: 0x040001A8 RID: 424
					public ArrayList f;

					// Token: 0x040001A9 RID: 425
					public ArrayList g;

					// Token: 0x040001AA RID: 426
					public string h;

					// Token: 0x040001AB RID: 427
					public int i;

					// Token: 0x040001AC RID: 428
					public int j;

					// Token: 0x040001AD RID: 429
					public BW2_three.j k;

					// Token: 0x02000069 RID: 105
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000141 RID: 321 RVA: 0x0001EDBC File Offset: 0x0001CFBC
						public a(BW2_three.j.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
							}
						}

						// Token: 0x040001AE RID: 430
						public string[] a;

						// Token: 0x0200006A RID: 106
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x06000143 RID: 323 RVA: 0x0001EDDC File Offset: 0x0001CFDC
							[CompilerGenerated]
							public void j(int A_0, ParallelLoopState A_1)
							{
								BW2_three.j.a.a.a.a.a a = new BW2_three.j.a.a.a.a.a();
								a.a = A_0;
								BW2_three.j.a.a.a.a.a.a a2 = new BW2_three.j.a.a.a.a.a.a();
								a2.c = this;
								a2.b = a;
								if (a2.c.g.a.CancellationPending)
								{
									a2.c.g.e = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (a2.c.g.a.CancellationPending)
									{
										a2.c.g.e = true;
										A_1.Stop();
									}
								}
								a2.a = Conversions.ToString(a2.c.h.g[a.a]);
								Parallel.ForEach<object>(a2.c.h.b.ToArray(), a2.c.g.f, new Action<object, ParallelLoopState>(a2.d));
							}

							// Token: 0x040001AF RID: 431
							public int a;

							// Token: 0x040001B0 RID: 432
							public int b;

							// Token: 0x040001B1 RID: 433
							public int c;

							// Token: 0x040001B2 RID: 434
							public int d;

							// Token: 0x040001B3 RID: 435
							public string e;

							// Token: 0x040001B4 RID: 436
							public MemoryStream f;

							// Token: 0x040001B5 RID: 437
							public BW2_three.j g;

							// Token: 0x040001B6 RID: 438
							public BW2_three.j.a.a h;

							// Token: 0x040001B7 RID: 439
							public BW2_three.j.a.a.a i;

							// Token: 0x0200006B RID: 107
							[CompilerGenerated]
							internal class a
							{
								// Token: 0x040001B8 RID: 440
								public int a;

								// Token: 0x0200006C RID: 108
								[CompilerGenerated]
								internal class a
								{
									// Token: 0x06000146 RID: 326 RVA: 0x0001EEE7 File Offset: 0x0001D0E7
									[CompilerGenerated]
									[DebuggerStepThrough]
									public void d(object A_0, ParallelLoopState A_1)
									{
										new q<string[], ParallelLoopState>(this.d)((string[])A_0, A_1);
									}

									// Token: 0x06000147 RID: 327 RVA: 0x0001EF04 File Offset: 0x0001D104
									[CompilerGenerated]
									public void d(string[] A_0, ParallelLoopState A_1)
									{
										Interlocked.Add(ref global::x.i, 1);
										if (this.c.g.a.CancellationPending)
										{
											this.c.g.e = true;
											A_1.Stop();
										}
										while (global::x.a)
										{
											Thread.Sleep(500);
											if (this.c.g.a.CancellationPending)
											{
												this.c.g.e = true;
												A_1.Stop();
											}
										}
										if (string.IsNullOrWhiteSpace(A_0[0]))
										{
											return;
										}
										checked
										{
											if (0 == string.Compare(this.c.e, A_0[0], StringComparison.Ordinal))
											{
												string text = global::x.a(this.c.h.h, "_" + A_0[2]);
												if (File.Exists(text))
												{
													global::x.f.Add(text);
													int num = this.c.c;
													int num2 = this.c.d;
													int num3 = this.c.b;
													int num4 = this.c.a;
													int width = this.c.h.j;
													int height = this.c.h.i;
													int num5 = Conversions.ToInteger(A_0[3]);
													int num6 = Conversions.ToInteger(A_0[4]);
													int num7 = Conversions.ToInteger(A_0[5]);
													int num8 = 0;
													int num9 = 0;
													if (this.c.g.d)
													{
														if (0 > num2)
														{
															num9 = Math.Abs(num2);
															num2 = 0;
															num6 += num9;
														}
														if (num4 - this.c.h.i > 0)
														{
															height = num4 + Math.Abs(num2);
														}
														else
														{
															height = this.c.h.i + num2;
														}
														if (0 > num)
														{
															num8 = Math.Abs(num);
															num = 0;
															num5 += num8;
															if (num3 - this.c.h.j > 0)
															{
																width = num3 + num8;
															}
														}
													}
													Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
													Graphics graphics = Graphics.FromImage(bitmap);
													graphics.Clear(Color.Transparent);
													MemoryStream f = this.c.f;
													Bitmap bitmap2;
													lock (f)
													{
														bitmap2 = (Bitmap)Image.FromStream(this.c.f);
														graphics.DrawImage(bitmap2, num, num2, bitmap2.Width, bitmap2.Height);
													}
													bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.c.h.f[this.b.a]);
													graphics.DrawImage(bitmap2, num8, num9, bitmap2.Width, bitmap2.Height);
													if (0 != string.Compare(this.c.e, A_0[7], StringComparison.Ordinal))
													{
														bitmap2 = global::x.a(text);
														graphics.DrawImage(bitmap2, num5, num6, bitmap2.Width, bitmap2.Height);
													}
													bitmap2.Dispose();
													graphics.Dispose();
													string a_ = string.Concat(new string[]
													{
														this.c.h.h,
														"_",
														this.c.i.a[1],
														"_",
														A_0[1],
														"_",
														this.a
													});
													global::x.a(a_, ref bitmap, true);
													Interlocked.Add(ref global::x.k, 1);
													bitmap.Dispose();
													this.c.g.a.ReportProgress(global::x.i);
													Thread.Sleep(global::x.c);
												}
											}
										}
									}

									// Token: 0x040001B9 RID: 441
									public string a;

									// Token: 0x040001BA RID: 442
									public BW2_three.j.a.a.a.a.a b;

									// Token: 0x040001BB RID: 443
									public BW2_three.j.a.a.a.a c;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0200006D RID: 109
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x040001BC RID: 444
			public BackgroundWorker a;

			// Token: 0x040001BD RID: 445
			public string b;

			// Token: 0x040001BE RID: 446
			public string c;

			// Token: 0x040001BF RID: 447
			public bool d;

			// Token: 0x040001C0 RID: 448
			public ParallelOptions e;

			// Token: 0x0200006E RID: 110
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000149 RID: 329 RVA: 0x0001F2C8 File Offset: 0x0001D4C8
				public a(BW2_three.c.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x0600014A RID: 330 RVA: 0x0001F2E0 File Offset: 0x0001D4E0
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.b, CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x040001C1 RID: 449
				public ArrayList a;

				// Token: 0x040001C2 RID: 450
				public BW2_three.c b;

				// Token: 0x0200006F RID: 111
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600014B RID: 331 RVA: 0x0001F390 File Offset: 0x0001D590
					public a(BW2_three.c.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.c = A_0.c;
							this.d = A_0.d;
							this.a = A_0.a;
							this.f = A_0.f;
							this.e = A_0.e;
						}
					}

					// Token: 0x0600014C RID: 332 RVA: 0x0001F3EE File Offset: 0x0001D5EE
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void h(object A_0, ParallelLoopState A_1)
					{
						new global::n<string[], ParallelLoopState>(this.h)((string[])A_0, A_1);
					}

					// Token: 0x0600014D RID: 333 RVA: 0x0001F40C File Offset: 0x0001D60C
					[CompilerGenerated]
					public void h(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref global::x.i, 1);
						if (this.g.a.CancellationPending)
						{
							this.g.d = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.g.a.CancellationPending)
							{
								this.g.d = true;
								A_1.Stop();
							}
						}
						if (string.IsNullOrWhiteSpace(A_0[0]))
						{
							return;
						}
						Bitmap bitmap = new Bitmap(this.f, this.e, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						int num = 0;
						checked
						{
							int num2 = A_0.Count<string>() - 1;
							for (int i = num; i <= num2; i++)
							{
								if (i >= 2)
								{
									string strA = A_0[i];
									try
									{
										foreach (object obj in this.c)
										{
											string[] array = (string[])obj;
											if (0 == string.Compare(strA, array[0], StringComparison.Ordinal))
											{
												Interlocked.Add(ref global::x.i, 1);
												string text = global::x.a(this.d, "_" + array[1]);
												if (File.Exists(text))
												{
													global::x.f.Add(text);
													Bitmap bitmap2 = global::x.a(text);
													graphics.DrawImage(bitmap2, Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3]), bitmap2.Width, bitmap2.Height);
													bitmap2.Dispose();
													break;
												}
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
								}
							}
							graphics.Dispose();
							MemoryStream memoryStream = new MemoryStream();
							bitmap.Save(memoryStream, ImageFormat.Png);
							ArrayList obj2 = this.a;
							lock (obj2)
							{
								this.a.Add(memoryStream);
							}
							ArrayList obj3 = this.b;
							lock (obj3)
							{
								this.b.Add(A_0[1]);
							}
							bitmap.Dispose();
							Thread.Sleep(global::x.c);
						}
					}

					// Token: 0x040001C3 RID: 451
					public ArrayList a;

					// Token: 0x040001C4 RID: 452
					public ArrayList b;

					// Token: 0x040001C5 RID: 453
					public ArrayList c;

					// Token: 0x040001C6 RID: 454
					public string d;

					// Token: 0x040001C7 RID: 455
					public int e;

					// Token: 0x040001C8 RID: 456
					public int f;

					// Token: 0x040001C9 RID: 457
					public BW2_three.c g;

					// Token: 0x02000070 RID: 112
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x0600014E RID: 334 RVA: 0x0001F658 File Offset: 0x0001D858
						public a(BW2_three.c.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
							}
						}

						// Token: 0x040001CA RID: 458
						public string[] a;

						// Token: 0x02000071 RID: 113
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x06000150 RID: 336 RVA: 0x0001F677 File Offset: 0x0001D877
							[DebuggerStepThrough]
							[CompilerGenerated]
							public void h(object A_0, ParallelLoopState A_1)
							{
								new q<string[], ParallelLoopState>(this.h)((string[])A_0, A_1);
							}

							// Token: 0x06000151 RID: 337 RVA: 0x0001F694 File Offset: 0x0001D894
							[CompilerGenerated]
							public void h(string[] A_0, ParallelLoopState A_1)
							{
								BW2_three.c.a.a.a.a.a a = new BW2_three.c.a.a.a.a.a();
								a.b = this;
								a.a = A_0;
								if (a.b.e.a.CancellationPending)
								{
									a.b.e.d = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (a.b.e.a.CancellationPending)
									{
										a.b.e.d = true;
										A_1.Stop();
									}
								}
								if (string.IsNullOrWhiteSpace(a.a[0]))
								{
									return;
								}
								if (0 == string.Compare(this.c, a.a[0], StringComparison.Ordinal))
								{
									Interlocked.Add(ref global::x.i, 1);
									string text = global::x.a(a.b.f.d, "_" + a.a[2]);
									if (File.Exists(text))
									{
										BW2_three.c.a.a.a.a.a.a a2 = new BW2_three.c.a.a.a.a.a.a();
										a2.e = this;
										a2.d = a;
										global::x.f.Add(text);
										a2.c = new MemoryStream();
										using (Bitmap bitmap = global::x.a(text))
										{
											bitmap.Save(a2.c, ImageFormat.Png);
										}
										a2.a = Conversions.ToInteger(a.a[3]);
										a2.b = Conversions.ToInteger(a.a[4]);
										Parallel.For(0, a2.e.f.a.Count, a2.e.e.e, new Action<int, ParallelLoopState>(a2.f));
										a2.c.Dispose();
									}
								}
							}

							// Token: 0x040001CB RID: 459
							public int a;

							// Token: 0x040001CC RID: 460
							public int b;

							// Token: 0x040001CD RID: 461
							public string c;

							// Token: 0x040001CE RID: 462
							public MemoryStream d;

							// Token: 0x040001CF RID: 463
							public BW2_three.c e;

							// Token: 0x040001D0 RID: 464
							public BW2_three.c.a.a f;

							// Token: 0x040001D1 RID: 465
							public BW2_three.c.a.a.a g;

							// Token: 0x02000072 RID: 114
							[CompilerGenerated]
							internal class a
							{
								// Token: 0x040001D2 RID: 466
								public string[] a;

								// Token: 0x040001D3 RID: 467
								public BW2_three.c.a.a.a.a b;

								// Token: 0x02000073 RID: 115
								[CompilerGenerated]
								internal class a
								{
									// Token: 0x06000154 RID: 340 RVA: 0x0001F868 File Offset: 0x0001DA68
									[CompilerGenerated]
									public void f(int A_0, ParallelLoopState A_1)
									{
										if (this.e.e.a.CancellationPending)
										{
											this.e.e.d = true;
											A_1.Stop();
										}
										while (global::x.a)
										{
											Thread.Sleep(500);
											if (this.e.e.a.CancellationPending)
											{
												this.e.e.d = true;
												A_1.Stop();
											}
										}
										string text = Conversions.ToString(this.e.f.b[A_0]);
										Bitmap bitmap = new Bitmap(this.e.f.f, this.e.f.e, PixelFormat.Format32bppArgb);
										Graphics graphics = Graphics.FromImage(bitmap);
										graphics.Clear(Color.Transparent);
										MemoryStream obj = this.e.d;
										Bitmap bitmap2;
										lock (obj)
										{
											bitmap2 = (Bitmap)Image.FromStream(this.e.d);
											graphics.DrawImage(bitmap2, this.e.a, this.e.b, bitmap2.Width, bitmap2.Height);
										}
										MemoryStream obj2 = this.c;
										lock (obj2)
										{
											bitmap2 = (Bitmap)Image.FromStream(this.c);
											graphics.DrawImage(bitmap2, this.a, this.b, bitmap2.Width, bitmap2.Height);
										}
										bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.e.f.a[A_0]);
										graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
										graphics.Dispose();
										string a_ = string.Concat(new string[]
										{
											this.e.f.d,
											"_",
											this.e.g.a[0],
											"_",
											this.d.a[1],
											"_",
											text
										});
										global::x.a(a_, ref bitmap, true);
										Interlocked.Add(ref global::x.k, 1);
										bitmap2.Dispose();
										bitmap.Dispose();
										this.e.e.a.ReportProgress(global::x.i);
										Thread.Sleep(global::x.c);
									}

									// Token: 0x040001D4 RID: 468
									public int a;

									// Token: 0x040001D5 RID: 469
									public int b;

									// Token: 0x040001D6 RID: 470
									public MemoryStream c;

									// Token: 0x040001D7 RID: 471
									public BW2_three.c.a.a.a.a.a d;

									// Token: 0x040001D8 RID: 472
									public BW2_three.c.a.a.a.a e;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x02000074 RID: 116
		[CompilerGenerated]
		internal class d
		{
			// Token: 0x040001D9 RID: 473
			public BackgroundWorker a;

			// Token: 0x040001DA RID: 474
			public string b;

			// Token: 0x040001DB RID: 475
			public string c;

			// Token: 0x040001DC RID: 476
			public bool d;

			// Token: 0x040001DD RID: 477
			public ParallelOptions e;

			// Token: 0x02000075 RID: 117
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000156 RID: 342 RVA: 0x0001FB18 File Offset: 0x0001DD18
				public a(BW2_three.d.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x06000157 RID: 343 RVA: 0x0001FB30 File Offset: 0x0001DD30
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.b.Replace("_info", ""), CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x040001DE RID: 478
				public ArrayList a;

				// Token: 0x040001DF RID: 479
				public BW2_three.d b;

				// Token: 0x02000076 RID: 118
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000158 RID: 344 RVA: 0x0001FBF4 File Offset: 0x0001DDF4
					public a(BW2_three.d.a.a A_0)
					{
						if (A_0 != null)
						{
							this.f = A_0.f;
							this.e = A_0.e;
							this.b = A_0.b;
							this.c = A_0.c;
							this.d = A_0.d;
							this.a = A_0.a;
						}
					}

					// Token: 0x06000159 RID: 345 RVA: 0x0001FC52 File Offset: 0x0001DE52
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void h(object A_0, ParallelLoopState A_1)
					{
						new global::n<string[], ParallelLoopState>(this.h)((string[])A_0, A_1);
					}

					// Token: 0x0600015A RID: 346 RVA: 0x0001FC70 File Offset: 0x0001DE70
					[CompilerGenerated]
					public void h(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref global::x.i, 1);
						if (this.g.a.CancellationPending)
						{
							this.g.d = true;
							A_1.Stop();
						}
						while (global::x.a)
						{
							Thread.Sleep(500);
							if (this.g.a.CancellationPending)
							{
								this.g.d = true;
								A_1.Stop();
							}
						}
						if (string.IsNullOrWhiteSpace(A_0[0]))
						{
							return;
						}
						Bitmap bitmap = new Bitmap(this.f, this.e, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						int num = 0;
						checked
						{
							int num2 = A_0.Count<string>() - 1;
							for (int i = num; i <= num2; i++)
							{
								if (i >= 2)
								{
									string strA = A_0[i];
									try
									{
										foreach (object obj in this.c)
										{
											string[] array = (string[])obj;
											if (0 == string.Compare(strA, array[0], StringComparison.Ordinal))
											{
												Interlocked.Add(ref global::x.i, 1);
												string text = global::x.a(this.d, "_" + array[1]);
												if (File.Exists(text))
												{
													ArrayList obj2 = global::x.f;
													lock (obj2)
													{
														global::x.f.Add(text);
													}
													Bitmap bitmap2 = global::x.a(text);
													graphics.DrawImage(bitmap2, Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3]), bitmap2.Width, bitmap2.Height);
													bitmap2.Dispose();
													break;
												}
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
								}
							}
							graphics.Dispose();
							MemoryStream memoryStream = new MemoryStream();
							bitmap.Save(memoryStream, ImageFormat.Png);
							ArrayList obj3 = this.a;
							lock (obj3)
							{
								this.a.Add(memoryStream);
							}
							ArrayList obj4 = this.b;
							lock (obj4)
							{
								this.b.Add(A_0[1]);
							}
							bitmap.Dispose();
							Thread.Sleep(global::x.c);
						}
					}

					// Token: 0x040001E0 RID: 480
					public ArrayList a;

					// Token: 0x040001E1 RID: 481
					public ArrayList b;

					// Token: 0x040001E2 RID: 482
					public ArrayList c;

					// Token: 0x040001E3 RID: 483
					public string d;

					// Token: 0x040001E4 RID: 484
					public int e;

					// Token: 0x040001E5 RID: 485
					public int f;

					// Token: 0x040001E6 RID: 486
					public BW2_three.d g;

					// Token: 0x02000077 RID: 119
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x0600015B RID: 347 RVA: 0x0001FEEC File Offset: 0x0001E0EC
						public a(BW2_three.d.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
							}
						}

						// Token: 0x040001E7 RID: 487
						public string[] a;

						// Token: 0x02000078 RID: 120
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x0600015D RID: 349 RVA: 0x0001FF0B File Offset: 0x0001E10B
							[DebuggerStepThrough]
							[CompilerGenerated]
							public void i(object A_0, ParallelLoopState A_1)
							{
								new q<string[], ParallelLoopState>(this.i)((string[])A_0, A_1);
							}

							// Token: 0x0600015E RID: 350 RVA: 0x0001FF28 File Offset: 0x0001E128
							[CompilerGenerated]
							public void i(string[] A_0, ParallelLoopState A_1)
							{
								BW2_three.d.a.a.a.a.a a = new BW2_three.d.a.a.a.a.a();
								a.b = this;
								a.a = A_0;
								if (a.b.f.a.CancellationPending)
								{
									a.b.f.d = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (a.b.f.a.CancellationPending)
									{
										a.b.f.d = true;
										A_1.Stop();
									}
								}
								if (string.IsNullOrWhiteSpace(a.a[0]))
								{
									return;
								}
								if (0 == string.Compare(this.d, a.a[0], StringComparison.Ordinal))
								{
									Interlocked.Add(ref global::x.i, 1);
									string text = global::x.a(a.b.g.d, "_" + a.a[2]);
									if (File.Exists(text))
									{
										BW2_three.d.a.a.a.a.a.a a2 = new BW2_three.d.a.a.a.a.a.a();
										a2.e = this;
										a2.d = a;
										Interlocked.Add(ref this.c, 1);
										ArrayList obj = global::x.f;
										lock (obj)
										{
											global::x.f.Add(text);
										}
										a2.c = new MemoryStream();
										using (Bitmap bitmap = global::x.a(text))
										{
											bitmap.Save(a2.c, ImageFormat.Png);
										}
										a2.a = Conversions.ToInteger(a.a[3]);
										a2.b = Conversions.ToInteger(a.a[4]);
										Parallel.For(0, a2.e.g.a.Count, a2.e.f.e, new Action<int, ParallelLoopState>(a2.f));
										a2.c.Dispose();
									}
								}
							}

							// Token: 0x0600015F RID: 351 RVA: 0x00020124 File Offset: 0x0001E324
							[CompilerGenerated]
							public void i(int A_0, ParallelLoopState A_1)
							{
								if (this.f.a.CancellationPending)
								{
									this.f.d = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (this.f.a.CancellationPending)
									{
										this.f.d = true;
										A_1.Stop();
									}
								}
								string text = Conversions.ToString(this.g.b[A_0]);
								Bitmap bitmap = new Bitmap(this.g.f, this.g.e, PixelFormat.Format32bppArgb);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								MemoryStream obj = this.e;
								Bitmap bitmap2;
								lock (obj)
								{
									bitmap2 = (Bitmap)Image.FromStream(this.e);
									graphics.DrawImage(bitmap2, this.a, this.b, bitmap2.Width, bitmap2.Height);
								}
								bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.g.a[A_0]);
								graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
								graphics.Dispose();
								string a_ = string.Concat(new string[]
								{
									this.g.d,
									"_",
									this.h.a[0],
									"_",
									text
								});
								if (7 < this.h.a.GetLength(0) && Strings.InStr(1, this.h.a[7], "/", CompareMethod.Binary) > 0)
								{
									a_ = string.Concat(new string[]
									{
										this.g.d,
										"_",
										this.h.a[0],
										"_",
										this.h.a[7].Replace("/", "_"),
										"_",
										text
									});
								}
								global::x.a(a_, ref bitmap, true);
								Interlocked.Add(ref global::x.k, 1);
								bitmap2.Dispose();
								bitmap.Dispose();
								this.f.a.ReportProgress(global::x.i);
								Thread.Sleep(global::x.c);
							}

							// Token: 0x040001E8 RID: 488
							public int a;

							// Token: 0x040001E9 RID: 489
							public int b;

							// Token: 0x040001EA RID: 490
							public int c;

							// Token: 0x040001EB RID: 491
							public string d;

							// Token: 0x040001EC RID: 492
							public MemoryStream e;

							// Token: 0x040001ED RID: 493
							public BW2_three.d f;

							// Token: 0x040001EE RID: 494
							public BW2_three.d.a.a g;

							// Token: 0x040001EF RID: 495
							public BW2_three.d.a.a.a h;

							// Token: 0x02000079 RID: 121
							[CompilerGenerated]
							internal class a
							{
								// Token: 0x040001F0 RID: 496
								public string[] a;

								// Token: 0x040001F1 RID: 497
								public BW2_three.d.a.a.a.a b;

								// Token: 0x0200007A RID: 122
								[CompilerGenerated]
								internal class a
								{
									// Token: 0x06000162 RID: 354 RVA: 0x000203B8 File Offset: 0x0001E5B8
									[CompilerGenerated]
									public void f(int A_0, ParallelLoopState A_1)
									{
										if (this.e.f.a.CancellationPending)
										{
											this.e.f.d = true;
											A_1.Stop();
										}
										while (global::x.a)
										{
											Thread.Sleep(500);
											if (this.e.f.a.CancellationPending)
											{
												this.e.f.d = true;
												A_1.Stop();
											}
										}
										string text = Conversions.ToString(this.e.g.b[A_0]);
										Bitmap bitmap = new Bitmap(this.e.g.f, this.e.g.e, PixelFormat.Format32bppArgb);
										Graphics graphics = Graphics.FromImage(bitmap);
										graphics.Clear(Color.Transparent);
										MemoryStream obj = this.e.e;
										Bitmap bitmap2;
										lock (obj)
										{
											bitmap2 = (Bitmap)Image.FromStream(this.e.e);
											graphics.DrawImage(bitmap2, this.e.a, this.e.b, bitmap2.Width, bitmap2.Height);
										}
										bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.e.g.a[A_0]);
										graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
										MemoryStream obj2 = this.c;
										lock (obj2)
										{
											bitmap2 = (Bitmap)Image.FromStream(this.c);
											graphics.DrawImage(bitmap2, this.a, this.b, bitmap2.Width, bitmap2.Height);
										}
										graphics.Dispose();
										string a_ = string.Concat(new string[]
										{
											this.e.g.d,
											"_",
											this.e.h.a[0],
											"_",
											this.d.a[1],
											"_",
											text
										});
										global::x.a(a_, ref bitmap, true);
										Interlocked.Add(ref global::x.k, 1);
										bitmap2.Dispose();
										bitmap.Dispose();
										this.e.f.a.ReportProgress(global::x.i);
										Thread.Sleep(global::x.c);
									}

									// Token: 0x040001F2 RID: 498
									public int a;

									// Token: 0x040001F3 RID: 499
									public int b;

									// Token: 0x040001F4 RID: 500
									public MemoryStream c;

									// Token: 0x040001F5 RID: 501
									public BW2_three.d.a.a.a.a.a d;

									// Token: 0x040001F6 RID: 502
									public BW2_three.d.a.a.a.a e;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0200007B RID: 123
		[CompilerGenerated]
		internal class h
		{
			// Token: 0x040001F7 RID: 503
			public BackgroundWorker a;

			// Token: 0x040001F8 RID: 504
			public string b;

			// Token: 0x040001F9 RID: 505
			public string c;

			// Token: 0x040001FA RID: 506
			public bool d;

			// Token: 0x040001FB RID: 507
			public ParallelOptions e;

			// Token: 0x0200007C RID: 124
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000164 RID: 356 RVA: 0x00020668 File Offset: 0x0001E868
				public a(BW2_three.h.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x06000165 RID: 357 RVA: 0x00020680 File Offset: 0x0001E880
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.b.Replace("_info", ""), CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x040001FC RID: 508
				public ArrayList a;

				// Token: 0x040001FD RID: 509
				public BW2_three.h b;

				// Token: 0x0200007D RID: 125
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000166 RID: 358 RVA: 0x00020744 File Offset: 0x0001E944
					public a(BW2_three.h.a.a A_0)
					{
						if (A_0 != null)
						{
							this.f = A_0.f;
							this.e = A_0.e;
							this.b = A_0.b;
							this.c = A_0.c;
							this.d = A_0.d;
							this.g = A_0.g;
							this.a = A_0.a;
						}
					}

					// Token: 0x06000167 RID: 359 RVA: 0x000207AE File Offset: 0x0001E9AE
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void j(object A_0, ParallelLoopState A_1)
					{
						new r<string[], ParallelLoopState>(this.j)((string[])A_0, A_1);
					}

					// Token: 0x06000168 RID: 360 RVA: 0x000207CC File Offset: 0x0001E9CC
					[CompilerGenerated]
					public void j(string[] A_0, ParallelLoopState A_1)
					{
						if (Strings.InStr(1, A_0[1], "$", CompareMethod.Binary) > 0)
						{
							string[] array = A_0[1].Split(new char[]
							{
								'$'
							});
							this.g = array[0];
							if (Strings.InStr(1, this.g, "/", CompareMethod.Binary) > 0)
							{
								array = this.g.Split(new char[]
								{
									'/'
								});
								this.g = array.Last<string>();
							}
							string text = global::x.a(this.d, "_" + A_0[2]);
							if (File.Exists(text))
							{
								global::x.f.Add(text);
								Bitmap bitmap = new Bitmap(this.f, this.e, PixelFormat.Format32bppArgb);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								using (Bitmap bitmap2 = global::x.a(text))
								{
									graphics.DrawImage(bitmap2, Conversions.ToInteger(A_0[3]), Conversions.ToInteger(A_0[4]), bitmap2.Width, bitmap2.Height);
								}
								graphics.Dispose();
								string a_ = string.Concat(new string[]
								{
									this.d,
									"_",
									A_0[0],
									"_",
									this.g
								});
								global::x.a(a_, ref bitmap, true);
								Interlocked.Add(ref global::x.k, 1);
								bitmap.Dispose();
							}
						}
						this.h.a.ReportProgress(global::x.i);
						Thread.Sleep(global::x.c);
					}

					// Token: 0x06000169 RID: 361 RVA: 0x00020974 File Offset: 0x0001EB74
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void i(object A_0, ParallelLoopState A_1)
					{
						new z<string[], ParallelLoopState>(this.i)((string[])A_0, A_1);
					}

					// Token: 0x0600016A RID: 362 RVA: 0x00020990 File Offset: 0x0001EB90
					[CompilerGenerated]
					public void i(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref global::x.i, 1);
						string text = global::x.a(this.d, "_" + A_0[1]);
						if (File.Exists(text))
						{
							global::x.f.Add(text);
							Bitmap bitmap = new Bitmap(this.f, this.e, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							using (Bitmap bitmap2 = global::x.a(text))
							{
								graphics.DrawImage(bitmap2, Conversions.ToInteger(A_0[2]), Conversions.ToInteger(A_0[3]), bitmap2.Width, bitmap2.Height);
							}
							graphics.Dispose();
							string a_ = this.d + "_" + A_0[0];
							global::x.a(a_, ref bitmap, true);
							Interlocked.Add(ref global::x.k, 1);
							bitmap.Dispose();
						}
						this.h.a.ReportProgress(global::x.i);
						Thread.Sleep(global::x.c);
					}

					// Token: 0x040001FE RID: 510
					public ArrayList a;

					// Token: 0x040001FF RID: 511
					public ArrayList b;

					// Token: 0x04000200 RID: 512
					public ArrayList c;

					// Token: 0x04000201 RID: 513
					public string d;

					// Token: 0x04000202 RID: 514
					public int e;

					// Token: 0x04000203 RID: 515
					public int f;

					// Token: 0x04000204 RID: 516
					public string g;

					// Token: 0x04000205 RID: 517
					public BW2_three.h h;

					// Token: 0x0200007E RID: 126
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x0600016B RID: 363 RVA: 0x00020AA4 File Offset: 0x0001ECA4
						public a(BW2_three.h.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
								this.b = A_0.b;
							}
						}

						// Token: 0x0600016C RID: 364 RVA: 0x00020AC8 File Offset: 0x0001ECC8
						[CompilerGenerated]
						public void e(int A_0, ParallelLoopState A_1)
						{
							BW2_three.h.a.a.a.a a = new BW2_three.h.a.a.a.a();
							a.c = this;
							if (a.c.c.a.CancellationPending)
							{
								a.c.c.d = true;
								A_1.Stop();
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (a.c.c.a.CancellationPending)
								{
									a.c.c.d = true;
									A_1.Stop();
								}
							}
							a.b = (string[])a.c.d.b[A_0];
							a.a = (Bitmap)Image.FromStream((MemoryStream)a.c.d.a[A_0]);
							if (0 == string.Compare(this.a, a.b[0], StringComparison.Ordinal))
							{
								Parallel.ForEach<object>(a.c.d.c.ToArray(), a.c.c.e, new Action<object, ParallelLoopState>(a.d));
							}
							a.a.Dispose();
						}

						// Token: 0x04000206 RID: 518
						public string a;

						// Token: 0x04000207 RID: 519
						public MemoryStream b;

						// Token: 0x04000208 RID: 520
						public BW2_three.h c;

						// Token: 0x04000209 RID: 521
						public BW2_three.h.a.a d;

						// Token: 0x0200007F RID: 127
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x0600016E RID: 366 RVA: 0x00020BFF File Offset: 0x0001EDFF
							[CompilerGenerated]
							[DebuggerStepThrough]
							public void d(object A_0, ParallelLoopState A_1)
							{
								new global::n<string[], ParallelLoopState>(this.d)((string[])A_0, A_1);
							}

							// Token: 0x0600016F RID: 367 RVA: 0x00020C1C File Offset: 0x0001EE1C
							[CompilerGenerated]
							public void d(string[] A_0, ParallelLoopState A_1)
							{
								Interlocked.Add(ref global::x.i, 1);
								if (this.c.c.a.CancellationPending)
								{
									this.c.c.d = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (this.c.c.a.CancellationPending)
									{
										this.c.c.d = true;
										A_1.Stop();
									}
								}
								if (string.IsNullOrWhiteSpace(A_0[0]))
								{
									return;
								}
								string text = global::x.a(this.c.d.d, "_" + A_0[1]);
								if (File.Exists(text))
								{
									global::x.f.Add(text);
									int x = Conversions.ToInteger(A_0[2]);
									int y = Conversions.ToInteger(A_0[3]);
									Bitmap bitmap = new Bitmap(this.c.d.f, this.c.d.e, PixelFormat.Format32bppArgb);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									MemoryStream obj = this.c.b;
									Bitmap bitmap2;
									lock (obj)
									{
										bitmap2 = (Bitmap)Image.FromStream(this.c.b);
										graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
									}
									bitmap2 = global::x.a(text);
									graphics.DrawImage(bitmap2, x, y, bitmap2.Width, bitmap2.Height);
									bitmap2.Dispose();
									Bitmap obj2 = this.a;
									lock (obj2)
									{
										graphics.DrawImage(this.a, 0, 0, this.a.Width, this.a.Height);
									}
									graphics.Dispose();
									string text2 = A_0[0];
									if (Strings.InStr(1, A_0[6], "/", CompareMethod.Binary) > 0)
									{
										text2 = A_0[6].Split(new char[]
										{
											'/'
										})[0] + "_" + A_0[0];
									}
									string a_ = string.Concat(new string[]
									{
										this.c.d.d,
										"_",
										this.b[1],
										"_",
										text2
									});
									global::x.a(a_, ref bitmap, true);
									Interlocked.Add(ref global::x.k, 1);
									bitmap2.Dispose();
									bitmap.Dispose();
									this.c.c.a.ReportProgress(global::x.i);
									Thread.Sleep(global::x.c);
								}
							}

							// Token: 0x0400020A RID: 522
							public Bitmap a;

							// Token: 0x0400020B RID: 523
							public string[] b;

							// Token: 0x0400020C RID: 524
							public BW2_three.h.a.a.a c;
						}
					}
				}
			}
		}

		// Token: 0x02000080 RID: 128
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x0400020D RID: 525
			public BackgroundWorker a;

			// Token: 0x0400020E RID: 526
			public string b;

			// Token: 0x0400020F RID: 527
			public string c;

			// Token: 0x04000210 RID: 528
			public bool d;

			// Token: 0x02000081 RID: 129
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000171 RID: 369 RVA: 0x00020EFC File Offset: 0x0001F0FC
				public a(BW2_three.b.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x06000172 RID: 370 RVA: 0x00020F14 File Offset: 0x0001F114
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b.b.Replace("_info", ""), CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x04000211 RID: 529
				public ArrayList a;

				// Token: 0x04000212 RID: 530
				public BW2_three.b b;

				// Token: 0x02000082 RID: 130
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000173 RID: 371 RVA: 0x00020FD8 File Offset: 0x0001F1D8
					public a(BW2_three.b.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.e = A_0.e;
							this.d = A_0.d;
							this.a = A_0.a;
							this.c = A_0.c;
						}
					}

					// Token: 0x06000174 RID: 372 RVA: 0x0002102A File Offset: 0x0001F22A
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void g(object A_0, ParallelLoopState A_1)
					{
						new z<string[], ParallelLoopState>(this.g)((string[])A_0, A_1);
					}

					// Token: 0x06000175 RID: 373 RVA: 0x00021048 File Offset: 0x0001F248
					[CompilerGenerated]
					public void g(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref global::x.i, 1);
						string text = global::x.a(this.c, "_" + A_0[1]);
						if (File.Exists(text))
						{
							global::x.f.Add(text);
							Bitmap bitmap = new Bitmap(this.e, this.d, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							using (Bitmap bitmap2 = global::x.a(text))
							{
								graphics.DrawImage(bitmap2, Conversions.ToInteger(A_0[2]), Conversions.ToInteger(A_0[3]), bitmap2.Width, bitmap2.Height);
							}
							graphics.Dispose();
							string a_ = this.c + "_" + A_0[0];
							global::x.a(a_, ref bitmap, true);
							Interlocked.Add(ref global::x.k, 1);
							bitmap.Dispose();
						}
						this.f.a.ReportProgress(global::x.i);
						Thread.Sleep(global::x.c);
					}

					// Token: 0x04000213 RID: 531
					public ArrayList a;

					// Token: 0x04000214 RID: 532
					public ArrayList b;

					// Token: 0x04000215 RID: 533
					public string c;

					// Token: 0x04000216 RID: 534
					public int d;

					// Token: 0x04000217 RID: 535
					public int e;

					// Token: 0x04000218 RID: 536
					public BW2_three.b f;

					// Token: 0x02000083 RID: 131
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000176 RID: 374 RVA: 0x0002115C File Offset: 0x0001F35C
						public a(BW2_three.b.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.b = A_0.b;
								this.a = A_0.a;
							}
						}

						// Token: 0x06000177 RID: 375 RVA: 0x00021180 File Offset: 0x0001F380
						[CompilerGenerated]
						public void e(int A_0, ParallelLoopState A_1)
						{
							Interlocked.Add(ref global::x.i, 1);
							if (this.c.a.CancellationPending)
							{
								this.c.d = true;
								A_1.Stop();
							}
							while (global::x.a)
							{
								Thread.Sleep(500);
								if (this.c.a.CancellationPending)
								{
									this.c.d = true;
									A_1.Stop();
								}
							}
							string text = Conversions.ToString(this.d.b[A_0]);
							Bitmap bitmap = new Bitmap(this.d.e, this.d.d, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							MemoryStream obj = this.b;
							Bitmap bitmap2;
							lock (obj)
							{
								bitmap2 = (Bitmap)Image.FromStream(this.b);
								graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
							}
							bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.d.a[A_0]);
							graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
							graphics.Dispose();
							string a_ = string.Concat(new string[]
							{
								this.d.c,
								"_",
								this.a[1],
								"_",
								text
							});
							global::x.a(a_, ref bitmap, true);
							Interlocked.Add(ref global::x.k, 1);
							bitmap2.Dispose();
							bitmap.Dispose();
							this.c.a.ReportProgress(global::x.i);
							Thread.Sleep(global::x.c);
						}

						// Token: 0x04000219 RID: 537
						public string[] a;

						// Token: 0x0400021A RID: 538
						public MemoryStream b;

						// Token: 0x0400021B RID: 539
						public BW2_three.b c;

						// Token: 0x0400021C RID: 540
						public BW2_three.b.a.a d;
					}
				}
			}
		}

		// Token: 0x02000084 RID: 132
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x0400021D RID: 541
			public BackgroundWorker a;

			// Token: 0x0400021E RID: 542
			public bool b;

			// Token: 0x02000085 RID: 133
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600017A RID: 378 RVA: 0x00021370 File Offset: 0x0001F570
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void f(object A_0, ParallelLoopState A_1)
				{
					kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt;
					new s<kirikiri2_fun.kirikiri2DefTxt, ParallelLoopState>(this.f)((A_0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)A_0) : kirikiri2DefTxt, A_1);
				}

				// Token: 0x0600017B RID: 379 RVA: 0x000213A4 File Offset: 0x0001F5A4
				[CompilerGenerated]
				public void f(kirikiri2_fun.kirikiri2DefTxt A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref global::x.i, 1);
					if (this.e.a.CancellationPending)
					{
						this.e.b = true;
						A_1.Stop();
					}
					while (global::x.a)
					{
						Thread.Sleep(500);
						if (this.e.a.CancellationPending)
						{
							this.e.b = true;
							A_1.Stop();
						}
					}
					if (string.IsNullOrWhiteSpace(A_0.layer_type))
					{
						return;
					}
					if (Operators.CompareString("2", A_0.layer_type, false) == 0)
					{
						return;
					}
					if (string.IsNullOrWhiteSpace(A_0.group_layer_id))
					{
						string text = global::x.a(this.b, "_" + A_0.layer_id);
						if (File.Exists(text))
						{
							global::x.f.Add(text);
							Bitmap bitmap = new Bitmap(this.d, this.c, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							using (Bitmap bitmap2 = global::x.a(text))
							{
								graphics.DrawImage(bitmap2, Conversions.ToInteger(A_0.left), Conversions.ToInteger(A_0.top), bitmap2.Width, bitmap2.Height);
							}
							graphics.Dispose();
							string a_ = this.b + "_" + A_0.name;
							global::x.a(a_, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref global::x.k, 1);
						}
					}
					else
					{
						string text2 = global::x.a(this.b, "_" + A_0.layer_id);
						if (File.Exists(text2))
						{
							BW2_three.a.a.a a = new BW2_three.a.a.a();
							global::x.f.Add(text2);
							a.b = new StringBuilder();
							a.a = A_0.group_layer_id;
							while (!string.IsNullOrEmpty(a.a))
							{
								Parallel.ForEach<object>(this.a.ToArray(), new Action<object, ParallelLoopState>(a.c));
							}
							Bitmap bitmap3 = new Bitmap(this.d, this.c, PixelFormat.Format32bppArgb);
							Graphics graphics2 = Graphics.FromImage(bitmap3);
							graphics2.Clear(Color.Transparent);
							using (Bitmap bitmap4 = global::x.a(text2))
							{
								graphics2.DrawImage(bitmap4, Conversions.ToInteger(A_0.left), Conversions.ToInteger(A_0.top), bitmap4.Width, bitmap4.Height);
							}
							graphics2.Dispose();
							string a_2 = this.b + "_" + a.b.ToString() + A_0.name;
							global::x.a(a_2, ref bitmap3, true);
							bitmap3.Dispose();
							Interlocked.Add(ref global::x.k, 1);
						}
					}
					this.e.a.ReportProgress(global::x.i);
					Thread.Sleep(global::x.c);
				}

				// Token: 0x0400021F RID: 543
				public ArrayList a;

				// Token: 0x04000220 RID: 544
				public string b;

				// Token: 0x04000221 RID: 545
				public int c;

				// Token: 0x04000222 RID: 546
				public int d;

				// Token: 0x04000223 RID: 547
				public BW2_three.a e;

				// Token: 0x02000086 RID: 134
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600017D RID: 381 RVA: 0x000216B8 File Offset: 0x0001F8B8
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void c(object A_0, ParallelLoopState A_1)
					{
						kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt;
						new ab<kirikiri2_fun.kirikiri2DefTxt, ParallelLoopState>(this.c)((A_0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)A_0) : kirikiri2DefTxt, A_1);
					}

					// Token: 0x0600017E RID: 382 RVA: 0x000216EC File Offset: 0x0001F8EC
					[CompilerGenerated]
					public void c(kirikiri2_fun.kirikiri2DefTxt A_0, ParallelLoopState A_1)
					{
						if (0 == string.Compare(A_0.layer_id, this.a, StringComparison.Ordinal))
						{
							A_1.Break();
							StringBuilder obj = this.b;
							lock (obj)
							{
								this.b.Insert(0, A_0.name + "_");
							}
							if (string.IsNullOrWhiteSpace(A_0.group_layer_id))
							{
								this.a = string.Empty;
							}
							else
							{
								this.a = A_0.group_layer_id;
							}
						}
					}

					// Token: 0x04000224 RID: 548
					public string a;

					// Token: 0x04000225 RID: 549
					public StringBuilder b;
				}
			}
		}

		// Token: 0x02000087 RID: 135
		[CompilerGenerated]
		internal class l
		{
			// Token: 0x04000226 RID: 550
			public BackgroundWorker a;

			// Token: 0x04000227 RID: 551
			public string b;

			// Token: 0x04000228 RID: 552
			public string c;

			// Token: 0x04000229 RID: 553
			public bool d;

			// Token: 0x02000088 RID: 136
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000180 RID: 384 RVA: 0x00021790 File Offset: 0x0001F990
				public a(BW2_three.l.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x06000181 RID: 385 RVA: 0x000217A8 File Offset: 0x0001F9A8
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (0 != string.Compare(this.b.c, A_0, StringComparison.Ordinal))
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension.ToLower(), this.b.b.Replace("_info", "").ToLower(), CompareMethod.Binary) > 0)
						{
							ArrayList obj = this.a;
							lock (obj)
							{
								this.a.Add(A_0);
							}
							ArrayList f = global::x.f;
							lock (f)
							{
								global::x.f.Add(A_0);
								return;
							}
						}
						if (Strings.InStr(1, fileNameWithoutExtension.ToLower(), this.b.b.Replace("info", "").ToLower(), CompareMethod.Binary) > 0)
						{
							ArrayList obj2 = this.a;
							lock (obj2)
							{
								this.a.Add(A_0);
							}
							ArrayList f2 = global::x.f;
							lock (f2)
							{
								global::x.f.Add(A_0);
							}
						}
					}
				}

				// Token: 0x0400022A RID: 554
				public ArrayList a;

				// Token: 0x0400022B RID: 555
				public BW2_three.l b;

				// Token: 0x02000089 RID: 137
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000182 RID: 386 RVA: 0x00021920 File Offset: 0x0001FB20
					public a(BW2_three.l.a.a A_0)
					{
						if (A_0 != null)
						{
							this.b = A_0.b;
							this.d = A_0.d;
							this.a = A_0.a;
							this.c = A_0.c;
						}
					}

					// Token: 0x0400022C RID: 556
					public ArrayList a;

					// Token: 0x0400022D RID: 557
					public ArrayList b;

					// Token: 0x0400022E RID: 558
					public string c;

					// Token: 0x0400022F RID: 559
					public string d;

					// Token: 0x0200008A RID: 138
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000183 RID: 387 RVA: 0x0002195B File Offset: 0x0001FB5B
						public a(BW2_three.l.a.a.a A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
							}
						}

						// Token: 0x06000184 RID: 388 RVA: 0x00021972 File Offset: 0x0001FB72
						[CompilerGenerated]
						[DebuggerStepThrough]
						public void c(object A_0, ParallelLoopState A_1)
						{
							new aa<string[], ParallelLoopState>(this.c)((string[])A_0, A_1);
						}

						// Token: 0x06000185 RID: 389 RVA: 0x00021990 File Offset: 0x0001FB90
						[CompilerGenerated]
						public void c(string[] A_0, ParallelLoopState A_1)
						{
							if (0 == string.Compare(A_0[0], "face", StringComparison.Ordinal))
							{
								string text = this.b.d;
								if (Strings.InStr(1, text, "@", CompareMethod.Binary) > 0)
								{
									text = text.Split(new char[]
									{
										'@'
									}).First<string>();
									if (0 == string.Compare(A_0[2], text, StringComparison.Ordinal))
									{
										A_1.Break();
										this.a = this.b.d.Replace(text, A_0[1]);
									}
								}
								else if (0 == string.Compare(A_0[2], text, StringComparison.Ordinal))
								{
									A_1.Break();
									this.a = A_0[1];
								}
							}
						}

						// Token: 0x04000230 RID: 560
						public string a;

						// Token: 0x04000231 RID: 561
						public BW2_three.l.a.a b;
					}

					// Token: 0x0200008B RID: 139
					[CompilerGenerated]
					internal class b
					{
						// Token: 0x06000186 RID: 390 RVA: 0x00021A31 File Offset: 0x0001FC31
						public b(BW2_three.l.a.a.b A_0)
						{
							if (A_0 != null)
							{
								this.a = A_0.a;
							}
						}

						// Token: 0x06000187 RID: 391 RVA: 0x00021A48 File Offset: 0x0001FC48
						[DebuggerStepThrough]
						[CompilerGenerated]
						public void b(object A_0, ParallelLoopState A_1)
						{
							new aa<string[], ParallelLoopState>(this.b)((string[])A_0, A_1);
						}

						// Token: 0x06000188 RID: 392 RVA: 0x00021A64 File Offset: 0x0001FC64
						[CompilerGenerated]
						public void b(string[] A_0, ParallelLoopState A_1)
						{
							if (0 == string.Compare(A_0[0], "dress", StringComparison.Ordinal))
							{
								string strB = this.a;
								if (0 == string.Compare(A_0[2], strB, StringComparison.Ordinal))
								{
									A_1.Break();
									this.a = A_0[1];
								}
							}
						}

						// Token: 0x04000232 RID: 562
						public string a;

						// Token: 0x0200008C RID: 140
						[CompilerGenerated]
						internal class a
						{
							// Token: 0x0600018A RID: 394 RVA: 0x00021AAD File Offset: 0x0001FCAD
							[DebuggerStepThrough]
							[CompilerGenerated]
							public void f(object A_0, ParallelLoopState A_1)
							{
								new aa<string[], ParallelLoopState>(this.f)((string[])A_0, A_1);
							}

							// Token: 0x0600018B RID: 395 RVA: 0x00021AC8 File Offset: 0x0001FCC8
							[CompilerGenerated]
							public void f(string[] A_0, ParallelLoopState A_1)
							{
								if (0 == string.Compare(A_0[0], "diff", StringComparison.Ordinal))
								{
									string strB = this.a;
									if (0 == string.Compare(A_0[2], strB, StringComparison.Ordinal))
									{
										A_1.Break();
										this.a = A_0[1];
									}
								}
							}

							// Token: 0x0600018C RID: 396 RVA: 0x00021B0C File Offset: 0x0001FD0C
							[CompilerGenerated]
							public void f(int A_0, ParallelLoopState A_1)
							{
								if (this.c.a.CancellationPending)
								{
									this.c.d = true;
									A_1.Stop();
								}
								while (global::x.a)
								{
									Thread.Sleep(500);
									if (this.c.a.CancellationPending)
									{
										this.c.d = true;
										A_1.Stop();
									}
								}
								MemoryStream obj = this.b;
								Bitmap bitmap;
								lock (obj)
								{
									bitmap = (Bitmap)Image.FromStream(this.b);
								}
								Graphics graphics = Graphics.FromImage(bitmap);
								Bitmap bitmap2 = (Bitmap)Image.FromStream((MemoryStream)this.d.a[A_0]);
								graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
								bitmap2.Dispose();
								graphics.Dispose();
								string a_ = Conversions.ToString(Operators.ConcatenateObject(this.d.c + "_" + this.e.a + "_" + this.a + "_", this.d.b[A_0]));
								global::x.a(a_, ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref global::x.k, 1);
								this.c.a.ReportProgress(global::x.i);
								Thread.Sleep(global::x.c);
							}

							// Token: 0x04000233 RID: 563
							public string a;

							// Token: 0x04000234 RID: 564
							public MemoryStream b;

							// Token: 0x04000235 RID: 565
							public BW2_three.l c;

							// Token: 0x04000236 RID: 566
							public BW2_three.l.a.a d;

							// Token: 0x04000237 RID: 567
							public BW2_three.l.a.a.b e;
						}
					}
				}
			}
		}
	}
}
