using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x02000005 RID: 5
	public class BW2_four
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002348 File Offset: 0x00000548
		public static bool merge_ad_exl6ren_xy(ref Form1 myForm1)
		{
			BW2_four.a a = new BW2_four.a();
			a.d = false;
			checked
			{
				x.h = x.m.Count * x.n.Count;
				x.j = x.h;
				x.i = 0;
				x.k = 0;
				a.b = myForm1.CheckBox3.Checked;
				a.c = myForm1.CheckBox4.Checked;
				string[] array = new string[x.m.Count - 1 + 1];
				x.m.CopyTo(array, 0);
				a.f = new string[x.n.Count - 1 + 1];
				x.n.CopyTo(a.f, 0);
				a.e = x.a();
				a.a = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, a.e, new Action<string, ParallelLoopState>(a.g));
				return a.d;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002438 File Offset: 0x00000638
		public static bool merge_ad_exszs_tig2png_dat(ref Form1 myForm1)
		{
			BW2_four.e e = new BW2_four.e();
			e.d = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			e.a = myForm1.BackgroundWorker2;
			e.a.ReportProgress(0);
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			foreach (string text in array)
			{
				Interlocked.Add(ref x.i, 1);
				if (e.a.CancellationPending)
				{
					return true;
				}
				while (x.a)
				{
					Thread.Sleep(500);
					if (e.a.CancellationPending)
					{
						return true;
					}
				}
				e.b = Path.GetFileNameWithoutExtension(text);
				e.c = Path.GetDirectoryName(text);
				if (File.Exists(text))
				{
					BW2_four.e.a a = new BW2_four.e.a();
					x.f.Add(text);
					a.a = new ArrayList();
					int[] array3 = asmodean_fun.get_ad_dat_date(text, ref a.a);
					int height = array3[0];
					a.d = array3[1];
					a.e = array3[2];
					a.c = array3[3];
					a.b = array3[4];
					if (0 < a.a.Count)
					{
						string text2 = Path.ChangeExtension(text, "png");
						if (File.Exists(text2))
						{
							BW2_four.e.a.a a2 = new BW2_four.e.a.a();
							a2.d = a;
							a2.c = e;
							x.f.Add(text2);
							Interlocked.Add(ref x.i, 1);
							a2.a = new MemoryStream();
							a2.b = new MemoryStream();
							using (Bitmap bitmap = x.a(text2))
							{
								int width = bitmap.Width;
								int height2 = bitmap.Height;
								Rectangle rect = new Rectangle(0, 0, width, height);
								BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
								bitmap.UnlockBits(bitmapData);
								bitmap2.Save(a2.a, ImageFormat.Png);
								bitmap2.Dispose();
								bitmap.Save(a2.b, ImageFormat.Png);
							}
							Parallel.For(0, a.a.Count, parallelOptions, new Action<int, ParallelLoopState>(a2.e));
							a2.b.Dispose();
							a2.a.Dispose();
						}
					}
				}
			}
			x.z = string.Empty;
			return e.d;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002704 File Offset: 0x00000904
		public static bool merge_ad_exef2paz_xy(ref Form1 myForm1)
		{
			BW2_four.f f = new BW2_four.f();
			f.d = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			f.a = myForm1.BackgroundWorker2;
			f.a.ReportProgress(0);
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				f.e = false;
				if (0 == string.Compare(x.aa, "perseus", StringComparison.OrdinalIgnoreCase))
				{
					f.e = true;
				}
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four.f.a a = new BW2_four.f.a(a);
					string text = array2[i];
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
					f.c = Path.GetFileNameWithoutExtension(text);
					f.b = Path.GetDirectoryName(text);
					if (!x.b(ref x.f, text))
					{
						a.b = Path.Combine(f.b, f.c + "+");
						a.a = new ArrayList();
						Parallel.ForEach<string>(array, new Action<string>(a.c));
						if (0 < a.a.Count)
						{
							BW2_four.f.a.a a2 = new BW2_four.f.a.a();
							a2.f = a;
							a2.e = f;
							a2.d = new MemoryStream();
							using (Bitmap bitmap = x.a(text))
							{
								a2.b = bitmap.Width;
								a2.a = bitmap.Height;
								a2.c = bitmap.PixelFormat;
								bitmap.Save(a2.d, ImageFormat.Png);
							}
							Parallel.For(0, a.a.Count, parallelOptions, new Action<int, ParallelLoopState>(a2.g));
							if (f.e)
							{
								BW2_four.f.a.a.a a3 = new BW2_four.f.a.a.a();
								a3.c = a2;
								a3.b = f;
								ArrayList arrayList = new ArrayList();
								a3.a = new ArrayList();
								try
								{
									foreach (object value in a.a)
									{
										string text2 = Conversions.ToString(value);
										string text3 = Path.GetFileNameWithoutExtension(text2);
										string[] array3 = text3.Split(new char[]
										{
											'+'
										});
										string text4 = array3[2];
										text3 = text4.Substring(text4.Length - 1);
										if (0 == string.Compare(text3, "口", StringComparison.Ordinal))
										{
											arrayList.Add(text2);
										}
										else if (0 == string.Compare(text3, "目", StringComparison.Ordinal))
										{
											a3.a.Add(text2);
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
								Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a3.d));
							}
							a2.d.Dispose();
						}
					}
				}
				x.aa = string.Empty;
				return f.d;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A68 File Offset: 0x00000C68
		public static bool merge_ad_exchpac_spm_visual(ref Form1 myForm1)
		{
			bool result = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			backgroundWorker.ReportProgress(0);
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				string path = string.Empty;
				ParallelOptions parallelOptions = x.a();
				bool flag = false;
				if (0 == string.Compare(x.aa, "MaterialBraveIgnition", StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
				}
				string text = string.Empty;
				foreach (string text2 in array)
				{
					string text3 = Path.GetFileName(text2).ToLower();
					if (0 == string.Compare(text3, "visual.dat", StringComparison.Ordinal))
					{
						text = text2;
						path = Path.GetDirectoryName(text2);
						break;
					}
				}
				if (File.Exists(text))
				{
					ArrayList arrayList = asmodean_fun.read_visualdat_to_arr(text);
					try
					{
						foreach (object obj in arrayList)
						{
							string[] array3 = (string[])obj;
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
							string text4 = Path.Combine(path, array3[0]);
							string text5 = Path.Combine(path, array3[1]);
							if (File.Exists(text4) & File.Exists(text5))
							{
								Interlocked.Add(ref x.i, 2);
								x.f.Add(text5);
								int x = Conversions.ToInteger(array3[2]);
								int y = Conversions.ToInteger(array3[3]);
								Bitmap bitmap = x.a(text4);
								Graphics graphics = Graphics.FromImage(bitmap);
								using (Bitmap bitmap2 = x.a(text5))
								{
									if (flag)
									{
										bitmap2.MakeTransparent(Color.Black);
									}
									graphics.DrawImage(bitmap2, x, y, bitmap2.Width, bitmap2.Height);
								}
								graphics.Dispose();
								string text6 = Path.Combine(path, Path.GetFileNameWithoutExtension(array3[0]).ToLower());
								text6 = text6 + "_" + x.a(Path.GetFileNameWithoutExtension(array3[0]), Path.GetFileNameWithoutExtension(array3[1]), 0).ToLower();
								x.a(text6, ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref x.k, 1);
								backgroundWorker.ReportProgress(x.i);
								Thread.Sleep(x.c);
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
					x.f.Add(text);
				}
				foreach (string text7 in array)
				{
					Interlocked.Add(ref x.i, 1);
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
					string text3 = Path.GetExtension(text7).ToLower().Substring(1);
					if (0 == string.Compare(text3, "spm", StringComparison.Ordinal))
					{
						ArrayList arrayList2 = new ArrayList();
						ArrayList arrayList3 = new ArrayList();
						asmodean_fun.read_spm_to_arr(text7, ref arrayList2, ref arrayList3);
						if (!(0 == arrayList2.Count | 0 == arrayList3.Count))
						{
							path = Path.GetDirectoryName(text7);
							int num = 0;
							int num2 = arrayList2.Count - 1;
							for (int k = num; k <= num2; k++)
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
								object obj2 = arrayList2[k];
								asmodean_fun.spmFileDataCount spmFileDataCount2;
								asmodean_fun.spmFileDataCount spmFileDataCount = (obj2 != null) ? ((asmodean_fun.spmFileDataCount)obj2) : spmFileDataCount2;
								if (1 >= spmFileDataCount.iThisCount)
								{
									k++;
								}
								else
								{
									int num3 = 0;
									Bitmap bitmap3 = new Bitmap(spmFileDataCount.iWidth, spmFileDataCount.iHeight, PixelFormat.Format32bppArgb);
									Graphics graphics2 = Graphics.FromImage(bitmap3);
									graphics2.Clear(Color.Transparent);
									text3 = Path.GetFileNameWithoutExtension(text7).ToLower();
									string text8 = Path.Combine(path, text3);
									int num4 = 0;
									int num5 = spmFileDataCount.iThisCount - 1;
									for (int l = num4; l <= num5; l++)
									{
										k++;
										object obj3 = arrayList2[k];
										asmodean_fun.spmFileDataFace spmFileDataFace2;
										asmodean_fun.spmFileDataFace spmFileDataFace = (obj3 != null) ? ((asmodean_fun.spmFileDataFace)obj3) : spmFileDataFace2;
										if (!(0 == spmFileDataFace.iIndex & 0 == spmFileDataFace.iDX & 0 == spmFileDataFace.iDY & 0 == spmFileDataFace.iEndH & 0 == spmFileDataFace.iEndW & 0 == spmFileDataFace.iStarX & 0 == spmFileDataFace.iStarY & 0 == spmFileDataFace.iSX & 0 == spmFileDataFace.iSY & 0 == spmFileDataFace.iX & 0 == spmFileDataFace.iY))
										{
											string text9 = Path.Combine(path, Conversions.ToString(arrayList3[spmFileDataFace.iIndex]));
											if (File.Exists(text9))
											{
												Interlocked.Add(ref x.i, 1);
												int x2 = Math.Abs(spmFileDataCount.iX - spmFileDataFace.iX);
												int y2 = Math.Abs(spmFileDataCount.iY - spmFileDataFace.iY);
												using (Bitmap bitmap4 = x.a(text9))
												{
													graphics2.DrawImage(bitmap4, x2, y2, bitmap4.Width, bitmap4.Height);
												}
												text8 = text8 + "_" + x.a(text3, Path.GetFileNameWithoutExtension(text9.ToLower()), 0);
												num3++;
												if (0 < spmFileDataFace.iIndex)
												{
													x.f.Add(text9);
												}
											}
										}
									}
									graphics2.Dispose();
									if (1 >= num3)
									{
										bitmap3.Dispose();
									}
									else
									{
										x.a(text8, ref bitmap3, true);
										bitmap3.Dispose();
										Interlocked.Add(ref x.k, 1);
										backgroundWorker.ReportProgress(x.i);
										Thread.Sleep(x.c);
									}
								}
							}
							x.f.Add(text7);
						}
					}
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return result;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000030C0 File Offset: 0x000012C0
		public static bool merge_ad_exdieslib_dzi_svg(ref Form1 myForm1)
		{
			bool result = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
				foreach (string text in array)
				{
					Interlocked.Add(ref x.i, 1);
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
					string directoryName = Path.GetDirectoryName(text);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, x.o))
						{
							string text2 = streamReader.ReadLine().Trim();
							text2 = streamReader.ReadLine().Trim();
							string[] array3 = text2.Split(new char[]
							{
								','
							});
							int num = Conversions.ToInteger(array3[0]);
							int num2 = Conversions.ToInteger(array3[1]);
							text2 = streamReader.ReadLine().Trim();
							int j = Conversions.ToInteger(text2);
							while (j > 0)
							{
								text2 = streamReader.ReadLine().Trim();
								array3 = text2.Split(new char[]
								{
									','
								});
								if (2 == array3.Count<string>())
								{
									int num3 = Conversions.ToInteger(array3[1]);
									int width = Conversions.ToInteger(array3[0]) * 256;
									int height = num3 * 256;
									j--;
									Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									int num4 = 0;
									int num5 = num3 - 1;
									for (int k = num4; k <= num5; k++)
									{
										text2 = streamReader.ReadLine().Trim();
										array3 = text2.Split(new char[]
										{
											','
										});
										int num6 = 0;
										int num7 = array3.Count<string>() - 1;
										for (int l = num6; l <= num7; l++)
										{
											string text3 = array3[l];
											if (!string.IsNullOrWhiteSpace(text3))
											{
												string text4 = x.a(Path.Combine(directoryName, "tex" + Conversions.ToString(Path.DirectorySeparatorChar) + text3), "");
												if (File.Exists(text4))
												{
													Interlocked.Add(ref x.i, 1);
													using (Bitmap bitmap2 = x.a(text4))
													{
														graphics.DrawImage(bitmap2, l * 256, k * 256, 256, 256);
													}
												}
											}
										}
									}
									graphics.Dispose();
									string a_ = Path.Combine(directoryName, fileNameWithoutExtension + "_" + j.ToString("D2"));
									x.a(a_, ref bitmap, true);
									bitmap.Dispose();
									Interlocked.Add(ref x.k, 1);
									backgroundWorker.ReportProgress(x.i);
									Thread.Sleep(x.c);
								}
							}
						}
					}
					x.f.Add(text);
					x.f.Add(Path.ChangeExtension(text, "svg"));
					string path = Path.Combine(directoryName, "0_YouCanDel");
					x.g.Add(new string[]
					{
						Path.Combine(directoryName, "tex"),
						Path.Combine(path, "tex")
					});
					x.g.Add(new string[]
					{
						Path.Combine(directoryName, "thumbnl"),
						Path.Combine(path, "thumbnl")
					});
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return result;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000034F0 File Offset: 0x000016F0
		public static bool merge_ad_exoozoarc_txt(ref Form1 myForm1)
		{
			BW2_four.g g = new BW2_four.g();
			g.d = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				g.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four.g.a a = new BW2_four.g.a(a);
					string text = array2[i];
					a.c = g;
					Interlocked.Add(ref x.i, 1);
					if (g.a.CancellationPending)
					{
						return true;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (g.a.CancellationPending)
						{
							return true;
						}
					}
					g.b = Path.GetFileNameWithoutExtension(text).Split(new char[]
					{
						'+'
					}).First<string>();
					g.c = Path.GetDirectoryName(text);
					a.b = 0;
					a.a = 0;
					ArrayList arrayList = new ArrayList();
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
						{
							string text2 = streamReader.ReadLine().Trim();
							string[] array3 = x.ap.Split(text2);
							a.b = Conversions.ToInteger(array3[0]);
							a.a = Conversions.ToInteger(array3[1]);
							while (!streamReader.EndOfStream)
							{
								string[] array4 = new string[6];
								text2 = streamReader.ReadLine().Trim();
								if (!string.IsNullOrWhiteSpace(text2))
								{
									array3 = x.ao.Split(text2);
									array4[0] = array3[0].Trim();
									array4[1] = array3[1].Trim();
									array4[2] = array3[2].Trim();
									array4[3] = array3[3].Trim();
									array4[4] = array3[4].Trim();
									array4[5] = array3[5].Trim();
									arrayList.Add(array4);
								}
							}
						}
					}
					if (1 <= arrayList.Count)
					{
						x.f.Add(text);
						Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a.d));
					}
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return g.d;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000378C File Offset: 0x0000198C
		public static bool merge_ad_exyatpkg_lua_evt(ref Form1 myForm1)
		{
			BW2_four.i i = new BW2_four.i();
			i.d = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				if (0 >= array.Count<string>())
				{
					x.aa = string.Empty;
					x.z = string.Empty;
					return i.d;
				}
				string text = string.Empty;
				i.b = string.Empty;
				ParallelOptions parallelOptions = x.a();
				i.a = myForm1.BackgroundWorker2;
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				foreach (string text2 in array)
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
					if (string.IsNullOrEmpty(i.b))
					{
						i.b = Path.GetDirectoryName(text2);
					}
					using (FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, x.o))
						{
							IL_512:
							while (!streamReader.EndOfStream)
							{
								string text3 = streamReader.ReadLine().Trim().Replace("]", string.Empty);
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (0 != string.Compare(Conversions.ToString(text3.First<char>()), ";", StringComparison.Ordinal))
									{
										if (Strings.InStr(1, text3, "@[SimpleStandChara", CompareMethod.Binary) > 0)
										{
											BW2_four.i.a a = new BW2_four.i.a();
											string[] array3 = x.ap.Split(text3);
											a.b = new string[2];
											foreach (string text4 in array3)
											{
												if (Strings.InStr(1, text4, "file=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text4);
													a.b[0] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text4, "diff=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text4);
													a.b[1] = source.Last<string>().Replace("\"", string.Empty);
												}
											}
											a.a = false;
											Parallel.ForEach<object>(arrayList.ToArray(), new Action<object, ParallelLoopState>(a.c));
											if (!a.a)
											{
												arrayList.Add(a.b);
											}
										}
										else if (Strings.InStr(1, text3, "@[SimpleEvent", CompareMethod.Binary) > 0)
										{
											BW2_four.i.b b = new BW2_four.i.b();
											string[] array3 = x.ap.Split(text3);
											b.b = new string[6];
											foreach (string text5 in array3)
											{
												if (Strings.InStr(1, text5, "file=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[0] = source.Last<string>().Replace("\"", string.Empty);
													if (Strings.InStr(1, b.b[0], "&", CompareMethod.Binary) > 0)
													{
														goto IL_512;
													}
												}
												else if (Strings.InStr(1, text5, "df1=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[1] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df2=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[2] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df3=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[3] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df4=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[4] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df5=", CompareMethod.Binary) > 0)
												{
													string[] source = x.an.Split(text5);
													b.b[5] = source.Last<string>().Replace("\"", string.Empty);
												}
											}
											if (!(string.IsNullOrEmpty(b.b[1]) & string.IsNullOrEmpty(b.b[2]) & string.IsNullOrEmpty(b.b[3]) & string.IsNullOrEmpty(b.b[4]) & string.IsNullOrEmpty(b.b[5])))
											{
												b.a = false;
												Parallel.ForEach<object>(arrayList2.ToArray(), new Action<object, ParallelLoopState>(b.c));
												if (!b.a)
												{
													arrayList2.Add(b.b);
												}
											}
										}
									}
								}
							}
						}
					}
					x.f.Add(text2);
				}
				string text6 = Path.Combine(i.b, "scriptSettings.lua");
				i.c = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				i.e = new ArrayList();
				if (File.Exists(text6))
				{
					using (FileStream fileStream2 = new FileStream(text6, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader2 = new StreamReader(fileStream2, x.o))
						{
							while (!streamReader2.EndOfStream)
							{
								string text7 = streamReader2.ReadLine().Trim();
								if (!string.IsNullOrWhiteSpace(text7))
								{
									if (0 != string.Compare(Conversions.ToString(text7.First<char>()), "-", StringComparison.Ordinal))
									{
										if (Strings.InStr(1, text7, "g_CharaDiffPosChara", CompareMethod.Binary) > 0)
										{
											string text8 = x.an.Split(text7).First<string>().Trim();
											text = text8.Substring(text8.Length - 4);
											int num = 0;
											for (;;)
											{
												text7 = streamReader2.ReadLine().Trim();
												if (Strings.InStr(1, text7, "}", CompareMethod.Binary) > 0)
												{
													break;
												}
												if (!string.IsNullOrWhiteSpace(text7))
												{
													string[] array6 = text7.Split(new char[]
													{
														','
													});
													string[] array7 = new string[]
													{
														text,
														Conversions.ToString(num),
														array6[0].Trim(),
														array6[1].Trim()
													};
													if (Strings.InStr(1, array7[2], "+", CompareMethod.Binary) > 0 | Strings.InStr(1, array7[2], "-", CompareMethod.Binary) > 0)
													{
														decimal[] array8 = Calculator.Eval(array7[2], null);
														array7[2] = Conversions.ToString(array8[0]);
													}
													if (Strings.InStr(1, array7[3], "+", CompareMethod.Binary) > 0 | Strings.InStr(1, array7[3], "-", CompareMethod.Binary) > 0)
													{
														decimal[] array9 = Calculator.Eval(array7[3], null);
														array7[3] = Conversions.ToString(array9[0]);
													}
													num++;
													i.c.Add(array7);
												}
											}
										}
										else if (Strings.InStr(1, text7, "g_CharaAddPartsChara", CompareMethod.Binary) > 0)
										{
											string text8 = x.an.Split(text7).First<string>().Trim();
											for (;;)
											{
												text7 = streamReader2.ReadLine().Trim();
												if (Strings.InStr(1, text7, "}", CompareMethod.Binary) > 0)
												{
													break;
												}
												if (!string.IsNullOrWhiteSpace(text7))
												{
													string[] array6 = text7.Split(new char[]
													{
														','
													});
													arrayList3.Add(new string[]
													{
														array6[0].Trim().Replace("\"", string.Empty),
														array6[1].Trim(),
														array6[2].Trim()
													});
												}
											}
										}
										else if (Strings.InStr(1, text7, "g_ECGdiffList", CompareMethod.Binary) > 0)
										{
											for (;;)
											{
												text7 = streamReader2.ReadLine().Trim().Replace("\"", string.Empty);
												if (Strings.InStr(1, text7, "}", CompareMethod.Binary) > 0)
												{
													break;
												}
												if (!string.IsNullOrWhiteSpace(text7))
												{
													string[] array10 = new string[3];
													string[] source = text7.Split(new char[]
													{
														':'
													});
													array10[0] = source.First<string>();
													string[] array6 = source.Last<string>().Split(new char[]
													{
														','
													});
													array10[1] = array6[0].Trim();
													array10[2] = array6[1].Trim();
													i.e.Add(array10);
												}
											}
										}
									}
								}
							}
						}
					}
					x.f.Add(text6);
				}
				if (0 < arrayList.Count & 0 < i.c.Count)
				{
					Parallel.ForEach<object>(arrayList.ToArray(), new Action<object, ParallelLoopState>(i.g));
				}
				if (0 < arrayList3.Count)
				{
					Parallel.ForEach<object>(arrayList3.ToArray(), new Action<object>(i.f));
				}
				if (0 < i.e.Count & 0 < arrayList2.Count)
				{
					Parallel.ForEach<object>(arrayList2.ToArray(), new Action<object, ParallelLoopState>(i.f));
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return i.d;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000041B0 File Offset: 0x000023B0
		public static bool extract_ad_exsteldat_mng(ref Form1 myForm1)
		{
			BW2_four.d d = new BW2_four.d();
			d.d = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			d.a = myForm1.BackgroundWorker2;
			d.c = new string[]
			{
				"89",
				"50",
				"4E",
				"47",
				"0D",
				"0A",
				"1A",
				"0A",
				"00",
				"00",
				"00",
				"0D",
				"49",
				"48",
				"44",
				"52"
			};
			d.b = new string[]
			{
				"44",
				"AE",
				"42",
				"60",
				"82"
			};
			Parallel.ForEach<string>(array, new Action<string, ParallelLoopState>(d.e));
			x.aa = string.Empty;
			x.z = string.Empty;
			return d.d;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004330 File Offset: 0x00002530
		public static bool merge_ad_exmed_bgset_sprset(ref Form1 myForm1)
		{
			BW2_four.c c = new BW2_four.c(c);
			c.b = false;
			string a_ = "_SPRSET";
			Form1 form = myForm1;
			ListBox listBox = form.ListBox4;
			string text = x.a(a_, ref listBox, 1);
			form.ListBox4 = listBox;
			string text2 = text;
			string a_2 = "_BGSET";
			form = myForm1;
			listBox = form.ListBox4;
			string text3 = x.a(a_2, ref listBox, 1);
			form.ListBox4 = listBox;
			string text4 = text3;
			string a_3 = ".exe";
			form = myForm1;
			listBox = form.ListBox4;
			string text5 = x.a(a_3, ref listBox, 2);
			form.ListBox4 = listBox;
			string text6 = text5;
			if (string.IsNullOrWhiteSpace(text2) & string.IsNullOrWhiteSpace(text4))
			{
				return c.b;
			}
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				c.a = myForm1.BackgroundWorker2;
				int num = 0;
				int num2 = 0;
				string customkey = string.Empty;
				for (;;)
				{
					if (File.Exists(text6))
					{
						customkey = asmodean_fun.getunobfuscatekeyfromexe(ref text6, num2);
					}
					int num3 = 1;
					string path = text2;
					for (;;)
					{
						if (File.Exists(path))
						{
							byte[] array2;
							using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
							{
								BinaryReader binaryReader = new BinaryReader(fileStream);
								num = binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								int num4 = binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								array2 = new byte[num + 1];
								int num5 = 0;
								int num6 = num - 1;
								for (int i = num5; i <= num6; i++)
								{
									array2[i] = binaryReader.ReadByte();
								}
								binaryReader.Dispose();
							}
							bool flag = false;
							int num7 = 0;
							unchecked
							{
								if (asmodean_fun.unobfuscate(ref array2, (long)num, customkey))
								{
									flag = true;
									num7 = 1;
								}
								else if (asmodean_fun.unobfuscate2(ref array2, (long)num, customkey))
								{
									flag = true;
									num7 = 2;
								}
								if (!flag & num2 == 0)
								{
									break;
								}
							}
							if (!flag & num2 > 0)
							{
								x.c("not support, tell me.");
							}
							else
							{
								BW2_four.c.a a = new BW2_four.c.a(a);
								StringBuilder stringBuilder = new StringBuilder();
								foreach (byte b in array2)
								{
									if (b == 0)
									{
										stringBuilder.Append("\r\n");
									}
									else
									{
										stringBuilder.Append(Convert.ToChar(b));
									}
								}
								a.a = string.Empty;
								ArrayList arrayList = new ArrayList();
								ArrayList arrayList2 = new ArrayList();
								using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(stringBuilder.ToString())))
								{
									using (StreamReader streamReader = new StreamReader(memoryStream, Encoding.Default))
									{
										bool flag2 = false;
										bool flag3 = false;
										while (!streamReader.EndOfStream)
										{
											string text7 = streamReader.ReadLine().Trim();
											if (!string.IsNullOrWhiteSpace(text7))
											{
												if (Operators.CompareString(Conversions.ToString(text7.First<char>()), "#", false) != 0)
												{
													if (0 == string.Compare(text7, "{", StringComparison.Ordinal))
													{
														flag2 = true;
													}
													else
													{
														if (flag2)
														{
															if (0 == string.Compare(text7, "}", StringComparison.Ordinal))
															{
																flag2 = false;
																flag3 = true;
															}
															string[] array4 = text7.Split(new char[]
															{
																':'
															});
															if (0 == string.Compare(array4.First<string>(), "PREFIX", StringComparison.Ordinal))
															{
																string[] array5 = array4.Last<string>().Split(new char[]
																{
																	','
																});
																a.a = array5.First<string>();
																if (num7 == 2)
																{
																	a.a = array5.Last<string>();
																}
															}
															else if (0 == string.Compare(array4.First<string>(), "BODY", StringComparison.Ordinal))
															{
																string[] array5 = array4.Last<string>().Split(new char[]
																{
																	','
																});
																string[] array6 = new string[]
																{
																	"none",
																	array5[0],
																	array5[1]
																};
																if (num7 == 2)
																{
																	array6[1] = array5[1];
																}
																arrayList.Add(array6);
															}
															else if (0 == string.Compare(array4.First<string>(), "FACE", StringComparison.Ordinal))
															{
																string[] array5 = array4.Last<string>().Split(new char[]
																{
																	','
																});
																if (array5.Count<string>() > 1)
																{
																	string[] value = new string[]
																	{
																		"none",
																		array5[1],
																		array5[1],
																		array5[2],
																		array5[3]
																	};
																	arrayList2.Add(value);
																}
															}
															else if (0 == string.Compare(array4.First<string>(), "PARTS", StringComparison.Ordinal))
															{
																string[] array5 = array4.Last<string>().Split(new char[]
																{
																	','
																});
																if (array5.Count<string>() > 1)
																{
																	string[] value2 = new string[]
																	{
																		"none",
																		array5[0],
																		array5[1],
																		array5[2],
																		array5[3]
																	};
																	arrayList2.Add(value2);
																}
															}
														}
														if (flag3)
														{
															int num8 = 0;
															int num9 = arrayList.Count - 1;
															for (int k = num8; k <= num9; k++)
															{
																string[] array4 = (string[])arrayList[k];
																string text8 = x.a(ref x.e, a.a + array4[2]);
																if (!string.IsNullOrWhiteSpace(text8))
																{
																	array4[0] = text8;
																	arrayList[k] = array4;
																}
															}
															int num10 = 0;
															int num11 = arrayList2.Count - 1;
															for (int l = num10; l <= num11; l++)
															{
																string[] array4 = (string[])arrayList2[l];
																string text8 = x.a(ref x.e, a.a + array4[2]);
																if (!string.IsNullOrWhiteSpace(text8))
																{
																	array4[0] = text8;
																	arrayList2[l] = array4;
																}
															}
															try
															{
																IEnumerator enumerator = arrayList.GetEnumerator();
																while (enumerator.MoveNext())
																{
																	BW2_four.c.a.a a2 = new BW2_four.c.a.a(a2);
																	a2.f = (string[])enumerator.Current;
																	a2.h = a;
																	a2.g = c;
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
																	if (File.Exists(a2.f[0]))
																	{
																		a2.b = new MemoryStream();
																		a2.d = 0;
																		a2.c = 0;
																		a2.e = PixelFormat.Format32bppArgb;
																		using (Bitmap bitmap = x.a(a2.f[0]))
																		{
																			a2.d = bitmap.Width;
																			a2.c = bitmap.Height;
																			a2.e = bitmap.PixelFormat;
																			Rectangle rect = new Rectangle(0, 0, a2.d, a2.c);
																			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, a2.e);
																			Bitmap bitmap2 = new Bitmap(a2.d, a2.c, bitmapData.Stride, x.a(a2.e), bitmapData.Scan0);
																			bitmap.UnlockBits(bitmapData);
																			bitmap2.Save(a2.b, ImageFormat.Png);
																			bitmap2.Dispose();
																		}
																		a2.a = Path.GetDirectoryName(a2.f[0]);
																		Parallel.ForEach<object>(arrayList2.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.i));
																		a2.b.Dispose();
																		ArrayList f = x.f;
																		lock (f)
																		{
																			x.f.Add(a2.f[0]);
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
															a.a = string.Empty;
															arrayList.Clear();
															arrayList2.Clear();
															flag3 = false;
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (num3 != 1)
						{
							goto IL_823;
						}
						num3 = 2;
						path = text4;
					}
					num2++;
				}
				IL_823:
				if (0 < x.k)
				{
					x.f.Add(text2);
					x.f.Add(text4);
					x.f.Add(text6);
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return c.b;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004C40 File Offset: 0x00002E40
		public static bool merge_ad_exanepak_chaNX00_chaNXYZ(ref Form1 myForm1)
		{
			BW2_four.h h = new BW2_four.h(h);
			h.e = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				string[] source = array;
				ParallelOptions parallelOptions = x.a();
				h.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four.h.a a = new BW2_four.h.a(a);
					a.a = array2[i];
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
					if (!x.b(ref x.f, a.a))
					{
						h.b = Path.GetFileNameWithoutExtension(a.a);
						if (7 <= h.b.Length && (Operators.CompareString(Conversions.ToString(h.b[0]), "c", false) == 0 & Operators.CompareString(Conversions.ToString(h.b[1]), "h", false) == 0))
						{
							string text = h.b.Substring(4);
							if (Versioned.IsNumeric(text))
							{
								if (Conversions.ToInteger(text) % 100 == 0)
								{
									BW2_four.h.a.a a2 = new BW2_four.h.a.a(a2);
									a2.h = a;
									a2.g = h;
									h.d = Path.GetDirectoryName(a.a);
									h.c = h.b.Substring(0, 5);
									a2.f = new MemoryStream();
									using (Bitmap bitmap = x.a(a.a))
									{
										a2.b = bitmap.Width;
										a2.a = bitmap.Height;
										a2.e = bitmap.PixelFormat;
										bitmap.Save(a2.f, ImageFormat.Png);
									}
									a2.c = -1;
									a2.d = -1;
									FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(a2.f));
									int num = fastBitmap.iWidth / 2 - 1;
									int num2 = fastBitmap.iHeight / 2;
									int num3 = fastBitmap.iHeight - 1;
									for (int j = num2; j <= num3; j++)
									{
										int a3 = (int)fastBitmap.GetPixel(num, j).A;
										if (255 == a3)
										{
											a2.c = num + 1;
											a2.d = j;
											break;
										}
									}
									fastBitmap.Dispose();
									if (!(-1 == a2.c | -1 == a2.d))
									{
										Parallel.ForEach<string>(source, parallelOptions, new Action<string, ParallelLoopState>(a2.i));
										a2.f.Dispose();
										x.f.Add(a.a);
									}
								}
							}
							else if (Operators.CompareString(Conversions.ToString(h.b.Last<char>()), "u", false) == 0)
							{
								text = text.Substring(0, text.Length - 1);
								if (Conversions.ToInteger(text) % 100 == 0)
								{
									BW2_four.h.a.b b = new BW2_four.h.a.b(b);
									b.h = a;
									b.g = h;
									h.d = Path.GetDirectoryName(a.a);
									h.c = h.b.Substring(0, 5);
									b.f = new MemoryStream();
									using (Bitmap bitmap2 = x.a(a.a))
									{
										b.b = bitmap2.Width;
										b.a = bitmap2.Height;
										b.e = bitmap2.PixelFormat;
										bitmap2.Save(b.f, ImageFormat.Png);
									}
									b.c = -1;
									b.d = -1;
									FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(b.f));
									int num4 = fastBitmap2.iWidth / 2 - 1;
									int num5 = fastBitmap2.iHeight / 2;
									int num6 = fastBitmap2.iHeight - 1;
									for (int k = num5; k <= num6; k++)
									{
										int a4 = (int)fastBitmap2.GetPixel(num4, k).A;
										if (255 == a4)
										{
											b.c = num4 + 1;
											b.d = k;
											break;
										}
									}
									fastBitmap2.Dispose();
									if (!(-1 == b.c | -1 == b.d))
									{
										Parallel.ForEach<string>(source, parallelOptions, new Action<string, ParallelLoopState>(b.i));
										b.f.Dispose();
										x.f.Add(a.a);
									}
								}
							}
							else if (Operators.CompareString(Conversions.ToString(h.b.Last<char>()), "h", false) == 0)
							{
							}
						}
					}
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return h.e;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000517C File Offset: 0x0000337C
		public static bool merge_ad_exescarc_lsf(ref Form1 myForm1)
		{
			BW2_four.k k = new BW2_four.k();
			k.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			ParallelOptions parallelOptions = x.a();
			k.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, parallelOptions, new Action<string, ParallelLoopState>(k.c));
			x.aa = string.Empty;
			x.z = string.Empty;
			return k.b;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00005218 File Offset: 0x00003418
		public static void merge_lsf_layer_Bitmap(ref Bitmap basebmp, int ibmpW, int ibmpH, PixelFormat PF, ref ArrayList arrright, ref ArrayList arrrightlayer, int iTurn, string paths, string arrleftname, ref ArrayList arrrightname, ref ArrayList arrrightpath, ref BackgroundWorker BW)
		{
			if (98 < iTurn)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			checked
			{
				int num2 = arrright.Count - 1;
				for (int i = num; i <= num2; i++)
				{
					Interlocked.Add(ref x.i, 1);
					if (BW.CancellationPending)
					{
						return;
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (BW.CancellationPending)
						{
							return;
						}
					}
					int num3 = Conversions.ToInteger(arrrightlayer[i]);
					if (iTurn == num3)
					{
						flag = true;
						Bitmap bitmap = (Bitmap)Image.FromStream((MemoryStream)arrright[i]);
						Bitmap bitmap2 = new Bitmap(ibmpW, ibmpH, PF);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(basebmp, 0, 0, basebmp.Width, basebmp.Height);
						graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
						graphics.Dispose();
						string text = Path.Combine(paths, arrleftname);
						string text2 = Conversions.ToString(arrrightname[i]);
						text = text + "_" + text2.Split(new char[]
						{
							'_'
						}).Last<string>();
						x.a(text, ref bitmap2, true);
						BW2_four.merge_lsf_layer_Bitmap(ref bitmap2, ibmpW, ibmpH, PF, ref arrright, ref arrrightlayer, iTurn + 1, paths, Path.GetFileNameWithoutExtension(text), ref arrrightname, ref arrrightpath, ref BW);
						bitmap2.Dispose();
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(RuntimeHelpers.GetObjectValue(arrrightpath[i]));
						}
						Interlocked.Add(ref x.k, 1);
						BW.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}
				if (!flag)
				{
					BW2_four.merge_lsf_layer_Bitmap(ref basebmp, ibmpW, ibmpH, PF, ref arrright, ref arrrightlayer, iTurn + 1, paths, arrleftname, ref arrrightname, ref arrrightpath, ref BW);
				}
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000540C File Offset: 0x0000360C
		public static bool merge_ad_expimg_txt(ref Form1 myForm1)
		{
			BW2_four.b b = new BW2_four.b();
			b.c = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			checked
			{
				string[] array = new string[x.h - 1 + 1];
				x.e.CopyTo(array, 0);
				ParallelOptions parallelOptions = x.a();
				b.a = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four.b.a a = new BW2_four.b.a(a);
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
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					b.b = Path.GetDirectoryName(text);
					a.e = "AA";
					a.d = 0;
					a.c = 0;
					a.b = 0;
					ArrayList arrayList = new ArrayList(10);
					string[] array3 = new string[10];
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream))
						{
							while (!streamReader.EndOfStream)
							{
								string text2 = streamReader.ReadLine();
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string[] array4 = text2.Split(new char[]
									{
										':'
									});
									string text3 = array4.First<string>();
									string text4 = array4.Last<string>().Trim();
									if (0 == a.d && 0 == string.Compare(text3, "image_width", StringComparison.Ordinal))
									{
										a.d = Conversions.ToInteger(text4);
									}
									else if (0 == a.c && 0 == string.Compare(text3, "image_height", StringComparison.Ordinal))
									{
										a.c = Conversions.ToInteger(text4);
									}
									else if (0 == string.Compare(text3, "name", StringComparison.Ordinal))
									{
										array3[0] = text4;
										a.e = text4;
									}
									else if (0 == string.Compare(text3, "layer_id", StringComparison.Ordinal))
									{
										array3[1] = text4;
										a.b = Conversions.ToInteger(text4);
									}
									else if (0 == string.Compare(text3, "width", StringComparison.Ordinal))
									{
										array3[2] = text4;
									}
									else if (0 == string.Compare(text3, "height", StringComparison.Ordinal))
									{
										array3[3] = text4;
									}
									else if (0 == string.Compare(text3, "left", StringComparison.Ordinal))
									{
										array3[4] = text4;
									}
									else if (0 == string.Compare(text3, "top", StringComparison.Ordinal))
									{
										array3[5] = text4;
									}
									else if (0 == string.Compare(text3, "opacity", StringComparison.Ordinal))
									{
										array3[6] = text4;
									}
									else if (0 == string.Compare(text3, "layer_type", StringComparison.Ordinal))
									{
										array3[7] = text4;
									}
									else if (0 == string.Compare(text3, "type", StringComparison.Ordinal))
									{
										array3[8] = text4;
									}
									else if (0 == string.Compare(text3, "visible", StringComparison.Ordinal))
									{
										array3[9] = text4;
										arrayList.Add(array3);
										array3 = new string[10];
									}
								}
							}
						}
					}
					if (0 < arrayList.Count)
					{
						if (!(0 == a.d | 0 == a.c))
						{
							string[] array4 = fileNameWithoutExtension.Split(new char[]
							{
								'+'
							});
							string text3 = string.Concat(new string[]
							{
								array4[0],
								"+",
								array4[1],
								"+",
								Conversions.ToString(a.b)
							});
							string text4 = Path.Combine(b.b, text3);
							a.a = Path.Combine(b.b, array4[0] + "+" + array4[1] + "+");
							text3 = x.a(text4, "");
							if (!string.IsNullOrEmpty(text3))
							{
								BW2_four.b.a.a a2 = new BW2_four.b.a.a();
								a2.d = a;
								a2.c = b;
								a2.a = new MemoryStream();
								Bitmap bitmap = x.a(text3);
								a2.b = bitmap.PixelFormat;
								int width = bitmap.Width;
								int height = bitmap.Height;
								Rectangle rect = new Rectangle(0, 0, width, height);
								BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, a2.b);
								Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, x.a(a2.b), bitmapData.Scan0);
								bitmap.UnlockBits(bitmapData);
								bitmap2.Save(a2.a, ImageFormat.Png);
								bitmap2.Dispose();
								bitmap.Dispose();
								Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, new Action<object, ParallelLoopState>(a2.e));
								a2.a.Dispose();
								x.f.Add(text3);
								x.f.Add(text);
							}
						}
					}
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return b.c;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000595C File Offset: 0x00003B5C
		public static bool merge_ad_exl6ren_automcg(ref Form1 myForm1)
		{
			BW2_four.j j = new BW2_four.j();
			j.b = false;
			x.h = x.e.Count;
			x.j = x.h;
			x.i = 0;
			x.k = 0;
			string[] array = new string[checked(x.h - 1 + 1)];
			x.e.CopyTo(array, 0);
			j.c = x.a();
			j.a = myForm1.BackgroundWorker2;
			Parallel.ForEach<string>(array, j.c, new Action<string, ParallelLoopState>(j.d));
			return j.b;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000059EE File Offset: 0x00003BEE
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void b(object A_0)
		{
			new ad<MemoryStream>(BW2_four.b)((MemoryStream)A_0);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005A07 File Offset: 0x00003C07
		[CompilerGenerated]
		private static void b(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00005A0F File Offset: 0x00003C0F
		[CompilerGenerated]
		[DebuggerStepThrough]
		private static void a(object A_0)
		{
			new ad<MemoryStream>(BW2_four.a)((MemoryStream)A_0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00005A28 File Offset: 0x00003C28
		[CompilerGenerated]
		private static void a(MemoryStream A_0)
		{
			A_0.Dispose();
		}

		// Token: 0x02000006 RID: 6
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x06000026 RID: 38 RVA: 0x00005A38 File Offset: 0x00003C38
			[CompilerGenerated]
			public void g(string A_0, ParallelLoopState A_1)
			{
				BW2_four.a.a a = new BW2_four.a.a();
				a.f = this;
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
				a.e = new MemoryStream();
				a.d = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(A_0));
				using (Bitmap bitmap = x.a(A_0))
				{
					a.b = bitmap.Width;
					a.a = bitmap.Height;
					a.c = bitmap.PixelFormat;
					Rectangle rect = new Rectangle(0, 0, a.b, a.a);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, a.c);
					Bitmap bitmap2 = new Bitmap(a.b, a.a, bitmapData.Stride, x.a(a.c), bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					bitmap2.Save(a.e, ImageFormat.Png);
					bitmap2.Dispose();
				}
				Parallel.ForEach<string>(this.f, this.e, new Action<string, ParallelLoopState>(a.g));
				a.e.Dispose();
				if (this.b)
				{
					ArrayList obj = x.f;
					lock (obj)
					{
						x.f.Add(A_0);
					}
				}
			}

			// Token: 0x04000005 RID: 5
			public BackgroundWorker a;

			// Token: 0x04000006 RID: 6
			public bool b;

			// Token: 0x04000007 RID: 7
			public bool c;

			// Token: 0x04000008 RID: 8
			public bool d;

			// Token: 0x04000009 RID: 9
			public ParallelOptions e;

			// Token: 0x0400000A RID: 10
			public string[] f;

			// Token: 0x02000007 RID: 7
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000028 RID: 40 RVA: 0x00005BEC File Offset: 0x00003DEC
				[CompilerGenerated]
				public void g(string A_0, ParallelLoopState A_1)
				{
					Interlocked.Add(ref x.i, 1);
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
					Bitmap bitmap = x.a(A_0);
					int width = bitmap.Width;
					int height = bitmap.Height;
					PixelFormat pixelFormat = bitmap.PixelFormat;
					Rectangle rect = new Rectangle(0, 0, width, height);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
					Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, x.a(pixelFormat), bitmapData.Scan0);
					bitmap.UnlockBits(bitmapData);
					string[] array = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(A_0));
					Bitmap bitmap3 = new Bitmap(this.b, this.a, x.a(this.c));
					Graphics graphics = Graphics.FromImage(bitmap3);
					graphics.Clear(Color.Transparent);
					MemoryStream obj = this.e;
					lock (obj)
					{
						graphics.DrawImage(Image.FromStream(this.e), 0, 0, this.b, this.a);
					}
					checked
					{
						graphics.DrawImage(bitmap2, Conversions.ToInteger(array[1]) - Conversions.ToInteger(this.d[1]), Conversions.ToInteger(array[2]) - Conversions.ToInteger(this.d[2]), width, height);
						graphics.Dispose();
						string a_ = string.Concat(new string[]
						{
							Path.Combine(Path.GetDirectoryName(A_0), this.d[0]),
							"_",
							array[0],
							"+x",
							this.d[1],
							"y",
							this.d[2]
						});
						x.a(a_, ref bitmap3, true);
						Interlocked.Add(ref x.k, 1);
						bitmap2.Dispose();
						bitmap3.Dispose();
						bitmap.Dispose();
						if (this.f.c)
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

				// Token: 0x0400000B RID: 11
				public int a;

				// Token: 0x0400000C RID: 12
				public int b;

				// Token: 0x0400000D RID: 13
				public PixelFormat c;

				// Token: 0x0400000E RID: 14
				public string[] d;

				// Token: 0x0400000F RID: 15
				public MemoryStream e;

				// Token: 0x04000010 RID: 16
				public BW2_four.a f;
			}
		}

		// Token: 0x02000008 RID: 8
		[CompilerGenerated]
		internal class e
		{
			// Token: 0x04000011 RID: 17
			public BackgroundWorker a;

			// Token: 0x04000012 RID: 18
			public string b;

			// Token: 0x04000013 RID: 19
			public string c;

			// Token: 0x04000014 RID: 20
			public bool d;

			// Token: 0x02000009 RID: 9
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x04000015 RID: 21
				public ArrayList a;

				// Token: 0x04000016 RID: 22
				public int b;

				// Token: 0x04000017 RID: 23
				public int c;

				// Token: 0x04000018 RID: 24
				public int d;

				// Token: 0x04000019 RID: 25
				public int e;

				// Token: 0x0200000A RID: 10
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600002C RID: 44 RVA: 0x00005E9C File Offset: 0x0000409C
					[CompilerGenerated]
					public void e(int A_0, ParallelLoopState A_1)
					{
						if (this.c.a.CancellationPending)
						{
							this.c.d = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.c.a.CancellationPending)
							{
								this.c.d = true;
								A_1.Stop();
							}
						}
						int[] array = (int[])this.d.a[A_0];
						MemoryStream obj = this.b;
						Bitmap bitmap;
						lock (obj)
						{
							bitmap = (Bitmap)Image.FromStream(this.b);
						}
						Rectangle rect = new Rectangle(array[0], array[1], this.d.c, this.d.b);
						BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
						Bitmap bitmap2 = new Bitmap(this.d.c, this.d.b, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
						bitmap.UnlockBits(bitmapData);
						MemoryStream obj2 = this.a;
						Bitmap bitmap3;
						lock (obj2)
						{
							bitmap3 = (Bitmap)Image.FromStream(this.a);
						}
						Graphics graphics = Graphics.FromImage(bitmap3);
						graphics.DrawImage(bitmap2, this.d.d, this.d.e, this.d.c, this.d.b);
						graphics.Dispose();
						bitmap2.Dispose();
						string a_ = Path.Combine(this.c.c, this.c.b) + "_" + Conversions.ToString(A_0);
						x.a(a_, ref bitmap3, true);
						Interlocked.Add(ref x.k, 1);
						bitmap.Dispose();
						bitmap3.Dispose();
						this.c.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}

					// Token: 0x0400001A RID: 26
					public MemoryStream a;

					// Token: 0x0400001B RID: 27
					public MemoryStream b;

					// Token: 0x0400001C RID: 28
					public BW2_four.e c;

					// Token: 0x0400001D RID: 29
					public BW2_four.e.a d;
				}
			}
		}

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		internal class f
		{
			// Token: 0x0400001E RID: 30
			public BackgroundWorker a;

			// Token: 0x0400001F RID: 31
			public string b;

			// Token: 0x04000020 RID: 32
			public string c;

			// Token: 0x04000021 RID: 33
			public bool d;

			// Token: 0x04000022 RID: 34
			public bool e;

			// Token: 0x0200000C RID: 12
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600002E RID: 46 RVA: 0x000060CC File Offset: 0x000042CC
				public a(BW2_four.f.a A_0)
				{
					if (A_0 != null)
					{
						this.b = A_0.b;
						this.a = A_0.a;
					}
				}

				// Token: 0x0600002F RID: 47 RVA: 0x000060F0 File Offset: 0x000042F0
				[CompilerGenerated]
				public void c(string A_0)
				{
					if (Strings.InStr(1, A_0, this.b, CompareMethod.Binary) > 0)
					{
						ArrayList obj = this.a;
						lock (obj)
						{
							this.a.Add(A_0);
							x.f.Add(A_0);
						}
					}
				}

				// Token: 0x04000023 RID: 35
				public ArrayList a;

				// Token: 0x04000024 RID: 36
				public string b;

				// Token: 0x0200000D RID: 13
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000031 RID: 49 RVA: 0x0000615C File Offset: 0x0000435C
					[CompilerGenerated]
					public void g(int A_0, ParallelLoopState A_1)
					{
						if (this.e.a.CancellationPending)
						{
							this.e.d = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.e.a.CancellationPending)
							{
								this.e.d = true;
								A_1.Stop();
							}
						}
						Interlocked.Add(ref x.i, 1);
						string text = Conversions.ToString(this.f.a[A_0]);
						Bitmap bitmap = new Bitmap(this.b, this.a, this.c);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						MemoryStream obj = this.d;
						lock (obj)
						{
							graphics.DrawImage(Image.FromStream(this.d), 0, 0, this.b, this.a);
						}
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
						string[] array = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
						int x = Conversions.ToInteger(array[1]);
						int y = Conversions.ToInteger(array[2]);
						Bitmap bitmap2 = x.a(text);
						graphics.DrawImage(bitmap2, x, y, bitmap2.Width, bitmap2.Height);
						bitmap2.Dispose();
						graphics.Dispose();
						string str = A_0.ToString("D3");
						if (this.e.e)
						{
							array = fileNameWithoutExtension.Split(new char[]
							{
								'+'
							});
							str = array[2];
						}
						string a_ = Path.Combine(this.e.b, this.e.c) + "_" + str;
						x.a(a_, ref bitmap, true);
						bitmap.Dispose();
						Interlocked.Add(ref x.k, 1);
						this.e.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}

					// Token: 0x04000025 RID: 37
					public int a;

					// Token: 0x04000026 RID: 38
					public int b;

					// Token: 0x04000027 RID: 39
					public PixelFormat c;

					// Token: 0x04000028 RID: 40
					public MemoryStream d;

					// Token: 0x04000029 RID: 41
					public BW2_four.f e;

					// Token: 0x0400002A RID: 42
					public BW2_four.f.a f;

					// Token: 0x0200000E RID: 14
					[CompilerGenerated]
					internal class a
					{
						// Token: 0x06000033 RID: 51 RVA: 0x00006360 File Offset: 0x00004560
						[CompilerGenerated]
						[DebuggerStepThrough]
						public void d(object A_0, ParallelLoopState A_1)
						{
							new global::b<string, ParallelLoopState>(this.d)(Conversions.ToString(A_0), A_1);
						}

						// Token: 0x06000034 RID: 52 RVA: 0x0000637C File Offset: 0x0000457C
						[CompilerGenerated]
						public void d(string A_0, ParallelLoopState A_1)
						{
							if (this.b.a.CancellationPending)
							{
								this.b.d = true;
								A_1.Stop();
							}
							while (x.a)
							{
								Thread.Sleep(500);
								if (this.b.a.CancellationPending)
								{
									this.b.d = true;
									A_1.Stop();
								}
							}
							Bitmap bitmap = new Bitmap(this.c.b, this.c.a, this.c.c);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							MemoryStream d = this.c.d;
							lock (d)
							{
								graphics.DrawImage(Image.FromStream(this.c.d), 0, 0, this.c.b, this.c.a);
							}
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
							string[] array = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
							int x = Conversions.ToInteger(array[1]);
							int y = Conversions.ToInteger(array[2]);
							Bitmap bitmap2 = x.a(A_0);
							graphics.DrawImage(bitmap2, x, y, bitmap2.Width, bitmap2.Height);
							bitmap2.Dispose();
							graphics.Dispose();
							MemoryStream memoryStream = new MemoryStream();
							bitmap.Save(memoryStream, ImageFormat.Png);
							bitmap.Dispose();
							try
							{
								foreach (object value in this.a)
								{
									string text = Conversions.ToString(value);
									fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
									array = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
									x = Conversions.ToInteger(array[1]);
									y = Conversions.ToInteger(array[2]);
									Bitmap bitmap3 = (Bitmap)Image.FromStream(memoryStream);
									Graphics graphics2 = Graphics.FromImage(bitmap3);
									Bitmap bitmap4 = x.a(text);
									graphics2.DrawImage(bitmap4, x, y, bitmap4.Width, bitmap4.Height);
									bitmap4.Dispose();
									array = fileNameWithoutExtension.Split(new char[]
									{
										'+'
									});
									string str = array[2];
									fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
									array = fileNameWithoutExtension.Split(new char[]
									{
										'+'
									});
									str = array[2] + "_" + str;
									string a_ = Path.Combine(this.b.b, this.b.c) + "_" + str;
									x.a(a_, ref bitmap3, true);
									bitmap3.Dispose();
									Interlocked.Add(ref x.k, 1);
									this.b.a.ReportProgress(x.i);
									Thread.Sleep(x.c);
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

						// Token: 0x0400002B RID: 43
						public ArrayList a;

						// Token: 0x0400002C RID: 44
						public BW2_four.f b;

						// Token: 0x0400002D RID: 45
						public BW2_four.f.a.a c;
					}
				}
			}
		}

		// Token: 0x0200000F RID: 15
		[CompilerGenerated]
		internal class g
		{
			// Token: 0x0400002E RID: 46
			public BackgroundWorker a;

			// Token: 0x0400002F RID: 47
			public string b;

			// Token: 0x04000030 RID: 48
			public string c;

			// Token: 0x04000031 RID: 49
			public bool d;

			// Token: 0x02000010 RID: 16
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000036 RID: 54 RVA: 0x00006684 File Offset: 0x00004884
				public a(BW2_four.g.a A_0)
				{
					if (A_0 != null)
					{
						this.b = A_0.b;
						this.a = A_0.a;
					}
				}

				// Token: 0x06000037 RID: 55 RVA: 0x000066A7 File Offset: 0x000048A7
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void d(object A_0, ParallelLoopState A_1)
				{
					new y<string[], ParallelLoopState>(this.d)((string[])A_0, A_1);
				}

				// Token: 0x06000038 RID: 56 RVA: 0x000066C4 File Offset: 0x000048C4
				[CompilerGenerated]
				public void d(string[] A_0, ParallelLoopState A_1)
				{
					if (this.c.a.CancellationPending)
					{
						this.c.d = true;
						A_1.Stop();
					}
					while (x.a)
					{
						Thread.Sleep(500);
						if (this.c.a.CancellationPending)
						{
							this.c.d = true;
							A_1.Stop();
						}
					}
					string text = Path.Combine(this.c.c, A_0[5]);
					if (File.Exists(text))
					{
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(text);
						}
						Interlocked.Add(ref x.i, 1);
						int x = Conversions.ToInteger(A_0[1]);
						int y = Conversions.ToInteger(A_0[2]);
						int width = Conversions.ToInteger(A_0[3]);
						int height = Conversions.ToInteger(A_0[4]);
						Bitmap bitmap = new Bitmap(this.b, this.a, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						using (Bitmap bitmap2 = x.a(text))
						{
							graphics.DrawImage(bitmap2, x, y, width, height);
						}
						graphics.Dispose();
						string a_ = Path.Combine(this.c.c, this.c.b + "_" + A_0[0]);
						x.a(a_, ref bitmap, true);
						Interlocked.Add(ref x.k, 1);
						bitmap.Dispose();
						this.c.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}

				// Token: 0x04000032 RID: 50
				public int a;

				// Token: 0x04000033 RID: 51
				public int b;

				// Token: 0x04000034 RID: 52
				public BW2_four.g c;
			}
		}

		// Token: 0x02000011 RID: 17
		[CompilerGenerated]
		internal class i
		{
			// Token: 0x0600003A RID: 58 RVA: 0x0000688C File Offset: 0x00004A8C
			[DebuggerStepThrough]
			[CompilerGenerated]
			public void g(object A_0, ParallelLoopState A_1)
			{
				new l<string[], ParallelLoopState>(this.f)((string[])A_0, A_1);
			}

			// Token: 0x0600003B RID: 59 RVA: 0x000068A8 File Offset: 0x00004AA8
			[CompilerGenerated]
			public void f(string[] A_0, ParallelLoopState A_1)
			{
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
				if (string.IsNullOrEmpty(A_0[0]) | string.IsNullOrEmpty(A_0[1]))
				{
					return;
				}
				string text = Path.Combine(this.b, Path.ChangeExtension(A_0[0], "png"));
				string text2 = Path.Combine(this.b, A_0[1]);
				if (File.Exists(text) & File.Exists(text2))
				{
					Interlocked.Add(ref x.i, 2);
					x.f.Add(text);
					x.f.Add(text2);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0[1]);
					string[] array = x.ak.Split(fileNameWithoutExtension);
					string text3 = array.First<string>().Substring(2);
					string strA = Conversions.ToString(array[2].First<char>());
					string strA2 = Conversions.ToString(array[2].Last<char>());
					if (0 == string.Compare(strA, "3", StringComparison.Ordinal))
					{
						text3 += "_3";
					}
					else
					{
						text3 += "_0";
					}
					int num = -1;
					int num2 = -1;
					try
					{
						foreach (object obj in this.c)
						{
							string[] array2 = (string[])obj;
							if (0 == string.Compare(text3, array2[0], StringComparison.Ordinal) & 0 == string.Compare(strA2, array2[1], StringComparison.Ordinal))
							{
								num = Conversions.ToInteger(array2[2]);
								num2 = Conversions.ToInteger(array2[3]);
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
					if (-1 == num & -1 == num2)
					{
						x.c(text3 + " : is false. ");
						return;
					}
					Bitmap bitmap = x.a(text);
					Graphics graphics = Graphics.FromImage(bitmap);
					Bitmap bitmap2 = x.a(text2);
					graphics.DrawImage(bitmap2, num, num2, bitmap2.Width, bitmap2.Height);
					graphics.Dispose();
					bitmap2.Dispose();
					string a_ = Path.Combine(this.b, Path.GetFileNameWithoutExtension(A_0[0]) + "_" + Path.GetFileNameWithoutExtension(A_0[1]));
					x.a(a_, ref bitmap, true);
					bitmap.Dispose();
					Interlocked.Add(ref x.k, 1);
					this.a.ReportProgress(x.i);
					Thread.Sleep(x.c);
				}
			}

			// Token: 0x0600003C RID: 60 RVA: 0x00006B2C File Offset: 0x00004D2C
			[CompilerGenerated]
			[DebuggerStepThrough]
			public void f(object A_0)
			{
				new global::h<string[]>(this.f)((string[])A_0);
			}

			// Token: 0x0600003D RID: 61 RVA: 0x00006B48 File Offset: 0x00004D48
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			public void f(string[] A_0)
			{
				string text = Path.Combine(this.b, A_0[0]);
				if (File.Exists(text))
				{
					string newPath = string.Concat(new string[]
					{
						Path.Combine(this.b, Path.GetFileNameWithoutExtension(A_0[0])),
						"_",
						A_0[1],
						"_",
						A_0[2],
						Path.GetExtension(A_0[0])
					});
					try
					{
						FileSystem.Rename(text, newPath);
					}
					catch (Exception ex)
					{
						x.c(text + " : " + ex.Message);
					}
				}
			}

			// Token: 0x0600003E RID: 62 RVA: 0x00006BF4 File Offset: 0x00004DF4
			[DebuggerStepThrough]
			[CompilerGenerated]
			public void f(object A_0, ParallelLoopState A_1)
			{
				new l<string[], ParallelLoopState>(this.g)((string[])A_0, A_1);
			}

			// Token: 0x0600003F RID: 63 RVA: 0x00006C10 File Offset: 0x00004E10
			[CompilerGenerated]
			public void g(string[] A_0, ParallelLoopState A_1)
			{
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
				string text = Path.Combine(this.b, Path.ChangeExtension(A_0[0], "png"));
				checked
				{
					if (File.Exists(text))
					{
						Interlocked.Add(ref x.i, 1);
						string text2 = string.Empty;
						Bitmap bitmap = x.a(text);
						int num = 1;
						int num2 = A_0.Count<string>() - 1;
						for (int i = num; i <= num2; i++)
						{
							if (!string.IsNullOrEmpty(A_0[i]))
							{
								if (A_0[i].Length >= 3)
								{
									string text3 = Path.Combine(this.b, A_0[i]);
									if (File.Exists(text3))
									{
										Interlocked.Add(ref x.i, 1);
										x.f.Add(text3);
										int num3 = -1;
										int num4 = -1;
										string text4 = A_0[i];
										try
										{
											foreach (object obj in this.e)
											{
												string[] array = (string[])obj;
												if (0 == string.Compare(text4, array[0], StringComparison.Ordinal))
												{
													num3 = Conversions.ToInteger(array[1]);
													num4 = Conversions.ToInteger(array[2]);
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
										if (-1 == num3 & -1 == num4)
										{
											x.c(text4 + " : is false. ");
										}
										else
										{
											Graphics graphics = Graphics.FromImage(bitmap);
											using (Bitmap bitmap2 = x.a(text3))
											{
												graphics.DrawImage(bitmap2, num3, num4, bitmap2.Width, bitmap2.Height);
											}
											graphics.Dispose();
											if (1 == i)
											{
												text2 = Path.GetFileNameWithoutExtension(A_0[i]);
											}
											else
											{
												text2 = text2 + "_" + Path.GetFileNameWithoutExtension(A_0[i]);
											}
										}
									}
								}
							}
						}
						string a_ = Path.Combine(this.b, Path.GetFileNameWithoutExtension(A_0[0]) + "_" + text2);
						x.a(a_, ref bitmap, true);
						Interlocked.Add(ref x.k, 1);
						bitmap.Dispose();
						this.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}
			}

			// Token: 0x04000035 RID: 53
			public BackgroundWorker a;

			// Token: 0x04000036 RID: 54
			public string b;

			// Token: 0x04000037 RID: 55
			public ArrayList c;

			// Token: 0x04000038 RID: 56
			public bool d;

			// Token: 0x04000039 RID: 57
			public ArrayList e;

			// Token: 0x02000012 RID: 18
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000041 RID: 65 RVA: 0x00006E94 File Offset: 0x00005094
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void c(object A_0, ParallelLoopState A_1)
				{
					new l<string[], ParallelLoopState>(this.c)((string[])A_0, A_1);
				}

				// Token: 0x06000042 RID: 66 RVA: 0x00006EAF File Offset: 0x000050AF
				[CompilerGenerated]
				public void c(string[] A_0, ParallelLoopState A_1)
				{
					if (0 == string.Compare(this.b[0], A_0[0], StringComparison.Ordinal) & 0 == string.Compare(this.b[1], A_0[1], StringComparison.Ordinal))
					{
						this.a = true;
						A_1.Stop();
					}
				}

				// Token: 0x0400003A RID: 58
				public bool a;

				// Token: 0x0400003B RID: 59
				public string[] b;
			}

			// Token: 0x02000013 RID: 19
			[CompilerGenerated]
			internal class b
			{
				// Token: 0x06000044 RID: 68 RVA: 0x00006EF1 File Offset: 0x000050F1
				[DebuggerStepThrough]
				[CompilerGenerated]
				public void c(object A_0, ParallelLoopState A_1)
				{
					new l<string[], ParallelLoopState>(this.c)((string[])A_0, A_1);
				}

				// Token: 0x06000045 RID: 69 RVA: 0x00006F0C File Offset: 0x0000510C
				[CompilerGenerated]
				public void c(string[] A_0, ParallelLoopState A_1)
				{
					if (0 == string.Compare(this.b[0], A_0[0], StringComparison.Ordinal) & 0 == string.Compare(this.b[1], A_0[1], StringComparison.Ordinal) & 0 == string.Compare(this.b[2], A_0[2], StringComparison.Ordinal) & 0 == string.Compare(this.b[3], A_0[3], StringComparison.Ordinal) & 0 == string.Compare(this.b[4], A_0[4], StringComparison.Ordinal) & 0 == string.Compare(this.b[5], A_0[5], StringComparison.Ordinal))
					{
						this.a = true;
						A_1.Stop();
					}
				}

				// Token: 0x0400003C RID: 60
				public bool a;

				// Token: 0x0400003D RID: 61
				public string[] b;
			}
		}

		// Token: 0x02000014 RID: 20
		[CompilerGenerated]
		internal class d
		{
			// Token: 0x06000047 RID: 71 RVA: 0x00006FB0 File Offset: 0x000051B0
			[CompilerGenerated]
			public void e(string A_0, ParallelLoopState A_1)
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
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				string directoryName = Path.GetDirectoryName(A_0);
				checked
				{
					using (FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						BinaryReader binaryReader = new BinaryReader(fileStream);
						int num = binaryReader.ReadInt32();
						if (1196313994 == num)
						{
							binaryReader.ReadChars(24);
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							int num7 = 0;
							int num8 = 0;
							int num9 = 0;
							int num10 = 0;
							bool flag = false;
							bool flag2 = false;
							string path = Path.Combine(directoryName, fileNameWithoutExtension) + "_" + num2.ToString("D3") + ".png";
							FileStream fileStream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
							BinaryWriter binaryWriter = new BinaryWriter(fileStream2, Encoding.Default);
							binaryWriter.Dispose();
							fileStream2.Dispose();
							while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
							{
								byte value = binaryReader.ReadByte();
								string right = Convert.ToString(value);
								if (!flag)
								{
									if (Operators.CompareString("73", right, false) == 0)
									{
										num3 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("72", right, false) == 0)
									{
										num4 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("68", right, false) == 0)
									{
										num5 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("82", right, false) == 0)
									{
										num6 = (int)binaryReader.BaseStream.Position;
									}
									unchecked
									{
										if (0 < num3 & 0 < num4 & 0 < num5 & 0 < num6)
										{
											long num11 = (long)(checked(num4 - num3));
											if (1L == num11)
											{
												num11 = (long)(checked(num5 - num4));
												if (1L == num11)
												{
													num11 = (long)(checked(num6 - num5));
													if (1L == num11)
													{
														flag = true;
														path = Path.Combine(directoryName, fileNameWithoutExtension) + "_" + num2.ToString("D3") + ".png";
														fileStream2 = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
														binaryWriter = new BinaryWriter(fileStream2);
														foreach (string value2 in this.c)
														{
															byte value3 = Convert.ToByte(value2, 16);
															binaryWriter.Write(value3);
														}
														continue;
													}
												}
											}
										}
									}
								}
								if (flag)
								{
									if (Operators.CompareString("73", right, false) == 0)
									{
										num7 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("69", right, false) == 0)
									{
										num8 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("78", right, false) == 0)
									{
										num9 = (int)binaryReader.BaseStream.Position;
									}
									else if (Operators.CompareString("68", right, false) == 0)
									{
										num10 = (int)binaryReader.BaseStream.Position;
									}
									unchecked
									{
										if (0 < num7 & 0 < num8 & 0 < num9 & 0 < num10)
										{
											long num11 = (long)(checked(num8 - num7));
											if (1L == num11)
											{
												num11 = (long)(checked(num9 - num8));
												if (1L == num11)
												{
													num11 = (long)(checked(num10 - num9));
													if (1L == num11)
													{
														flag = false;
														num3 = 0;
														num4 = 0;
														num5 = 0;
														num6 = 0;
														flag2 = true;
														continue;
													}
												}
											}
										}
										binaryWriter.Write(value);
									}
								}
								if (flag2)
								{
									foreach (string value4 in this.b)
									{
										byte value3 = Convert.ToByte(value4, 16);
										binaryWriter.Write(value3);
									}
									binaryWriter.Dispose();
									fileStream2.Dispose();
									num7 = 0;
									num8 = 0;
									num9 = 0;
									num10 = 0;
									flag2 = false;
									num2++;
									Interlocked.Add(ref x.k, 1);
									this.a.ReportProgress(x.i);
								}
							}
							if (0 < num2)
							{
								x.f.Add(A_0);
							}
						}
						binaryReader.Dispose();
					}
				}
			}

			// Token: 0x0400003E RID: 62
			public BackgroundWorker a;

			// Token: 0x0400003F RID: 63
			public string[] b;

			// Token: 0x04000040 RID: 64
			public string[] c;

			// Token: 0x04000041 RID: 65
			public bool d;
		}

		// Token: 0x02000015 RID: 21
		[CompilerGenerated]
		internal class c
		{
			// Token: 0x06000048 RID: 72 RVA: 0x000073D8 File Offset: 0x000055D8
			public c(BW2_four.c A_0)
			{
				if (A_0 != null)
				{
					this.a = A_0.a;
					this.b = A_0.b;
				}
			}

			// Token: 0x04000042 RID: 66
			public BackgroundWorker a;

			// Token: 0x04000043 RID: 67
			public bool b;

			// Token: 0x02000016 RID: 22
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000049 RID: 73 RVA: 0x000073FB File Offset: 0x000055FB
				public a(BW2_four.c.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x04000044 RID: 68
				public string a;

				// Token: 0x02000017 RID: 23
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600004A RID: 74 RVA: 0x00007414 File Offset: 0x00005614
					public a(BW2_four.c.a.a A_0)
					{
						if (A_0 != null)
						{
							this.d = A_0.d;
							this.c = A_0.c;
							this.e = A_0.e;
							this.b = A_0.b;
							this.a = A_0.a;
							this.f = A_0.f;
						}
					}

					// Token: 0x0600004B RID: 75 RVA: 0x00007472 File Offset: 0x00005672
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void i(object A_0, ParallelLoopState A_1)
					{
						new global::d<string[], ParallelLoopState>(this.i)((string[])A_0, A_1);
					}

					// Token: 0x0600004C RID: 76 RVA: 0x00007490 File Offset: 0x00005690
					[CompilerGenerated]
					public void i(string[] A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref x.i, 1);
						if (this.g.a.CancellationPending)
						{
							this.g.b = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.g.a.CancellationPending)
							{
								this.g.b = true;
								A_1.Stop();
							}
						}
						if (!File.Exists(A_0[0]))
						{
							return;
						}
						Bitmap bitmap = new Bitmap(this.d, this.c, x.a(this.e));
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						MemoryStream obj = this.b;
						lock (obj)
						{
							graphics.DrawImage(Image.FromStream(this.b), 0, 0, this.d, this.c);
						}
						using (Bitmap bitmap2 = x.a(A_0[0]))
						{
							Rectangle rect = new Rectangle(0, 0, bitmap2.Width, bitmap2.Height);
							BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, bitmap2.PixelFormat);
							Bitmap bitmap3 = new Bitmap(bitmap2.Width, bitmap2.Height, bitmapData.Stride, x.a(bitmap2.PixelFormat), bitmapData.Scan0);
							bitmap2.UnlockBits(bitmapData);
							graphics.DrawImage(bitmap3, Conversions.ToInteger(A_0[3]), Conversions.ToInteger(A_0[4]), bitmap2.Width, bitmap2.Height);
							bitmap3.Dispose();
						}
						graphics.Dispose();
						string a_ = Path.Combine(this.a, this.h.a + this.f[1] + A_0[1]);
						x.a(a_, ref bitmap, true);
						bitmap.Dispose();
						ArrayList obj2 = x.f;
						lock (obj2)
						{
							x.f.Add(A_0[0]);
						}
						Interlocked.Add(ref x.k, 1);
						this.g.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}

					// Token: 0x04000045 RID: 69
					public string a;

					// Token: 0x04000046 RID: 70
					public MemoryStream b;

					// Token: 0x04000047 RID: 71
					public int c;

					// Token: 0x04000048 RID: 72
					public int d;

					// Token: 0x04000049 RID: 73
					public PixelFormat e;

					// Token: 0x0400004A RID: 74
					public string[] f;

					// Token: 0x0400004B RID: 75
					public BW2_four.c g;

					// Token: 0x0400004C RID: 76
					public BW2_four.c.a h;
				}
			}
		}

		// Token: 0x02000018 RID: 24
		[CompilerGenerated]
		internal class h
		{
			// Token: 0x0600004D RID: 77 RVA: 0x000076D8 File Offset: 0x000058D8
			public h(BW2_four.h A_0)
			{
				if (A_0 != null)
				{
					this.c = A_0.c;
					this.b = A_0.b;
					this.d = A_0.d;
					this.a = A_0.a;
					this.e = A_0.e;
				}
			}

			// Token: 0x0400004D RID: 77
			public BackgroundWorker a;

			// Token: 0x0400004E RID: 78
			public string b;

			// Token: 0x0400004F RID: 79
			public string c;

			// Token: 0x04000050 RID: 80
			public string d;

			// Token: 0x04000051 RID: 81
			public bool e;

			// Token: 0x02000019 RID: 25
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600004E RID: 78 RVA: 0x0000772A File Offset: 0x0000592A
				public a(BW2_four.h.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
					}
				}

				// Token: 0x04000052 RID: 82
				public string a;

				// Token: 0x0200001A RID: 26
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x0600004F RID: 79 RVA: 0x00007744 File Offset: 0x00005944
					public a(BW2_four.h.a.a A_0)
					{
						if (A_0 != null)
						{
							this.f = A_0.f;
							this.b = A_0.b;
							this.a = A_0.a;
							this.e = A_0.e;
							this.c = A_0.c;
							this.d = A_0.d;
						}
					}

					// Token: 0x06000050 RID: 80 RVA: 0x000077A4 File Offset: 0x000059A4
					[CompilerGenerated]
					public void i(string A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref x.i, 1);
						if (this.g.a.CancellationPending)
						{
							this.g.e = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.g.a.CancellationPending)
							{
								this.g.e = true;
								A_1.Stop();
							}
						}
						ArrayList obj = x.f;
						lock (obj)
						{
							if (x.b(ref x.f, A_0))
							{
								return;
							}
						}
						if (0 == string.Compare(this.h.a, A_0, StringComparison.Ordinal))
						{
							return;
						}
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (7 > fileNameWithoutExtension.Length)
						{
							return;
						}
						checked
						{
							if (Operators.CompareString(Conversions.ToString(fileNameWithoutExtension.Last<char>()), "u", false) == 0 | Operators.CompareString(Conversions.ToString(fileNameWithoutExtension[fileNameWithoutExtension.Length - 2]), "u", false) == 0)
							{
								return;
							}
							string strB = fileNameWithoutExtension.Substring(0, 5);
							if (0 == string.Compare(this.g.c, strB, StringComparison.Ordinal))
							{
								Bitmap bitmap = new Bitmap(this.b, this.a, this.e);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								MemoryStream obj2 = this.f;
								lock (obj2)
								{
									graphics.DrawImage(Image.FromStream(this.f), 0, 0, this.b, this.a);
								}
								MemoryStream memoryStream = new MemoryStream();
								int width;
								int height;
								using (Bitmap bitmap2 = x.a(A_0))
								{
									width = bitmap2.Width;
									height = bitmap2.Height;
									bitmap2.Save(memoryStream, ImageFormat.Png);
								}
								graphics.DrawImage(Image.FromStream(memoryStream), this.c - width / 2, this.d - height, width, height);
								graphics.Dispose();
								string str = x.a(this.g.b, fileNameWithoutExtension, 0);
								string a_ = Path.Combine(this.g.d, this.g.b + "_" + str);
								x.a(a_, ref bitmap, true);
								Interlocked.Add(ref x.k, 1);
								bitmap.Dispose();
								memoryStream.Dispose();
								ArrayList obj3 = x.f;
								lock (obj3)
								{
									x.f.Add(A_0);
								}
								this.g.a.ReportProgress(x.i);
								Thread.Sleep(x.c);
							}
						}
					}

					// Token: 0x04000053 RID: 83
					public int a;

					// Token: 0x04000054 RID: 84
					public int b;

					// Token: 0x04000055 RID: 85
					public int c;

					// Token: 0x04000056 RID: 86
					public int d;

					// Token: 0x04000057 RID: 87
					public PixelFormat e;

					// Token: 0x04000058 RID: 88
					public MemoryStream f;

					// Token: 0x04000059 RID: 89
					public BW2_four.h g;

					// Token: 0x0400005A RID: 90
					public BW2_four.h.a h;
				}

				// Token: 0x0200001B RID: 27
				[CompilerGenerated]
				internal class b
				{
					// Token: 0x06000051 RID: 81 RVA: 0x00007A88 File Offset: 0x00005C88
					public b(BW2_four.h.a.b A_0)
					{
						if (A_0 != null)
						{
							this.f = A_0.f;
							this.b = A_0.b;
							this.a = A_0.a;
							this.e = A_0.e;
							this.c = A_0.c;
							this.d = A_0.d;
						}
					}

					// Token: 0x06000052 RID: 82 RVA: 0x00007AE8 File Offset: 0x00005CE8
					[CompilerGenerated]
					public void i(string A_0, ParallelLoopState A_1)
					{
						Interlocked.Add(ref x.i, 1);
						if (this.g.a.CancellationPending)
						{
							this.g.e = true;
							A_1.Stop();
						}
						while (x.a)
						{
							Thread.Sleep(500);
							if (this.g.a.CancellationPending)
							{
								this.g.e = true;
								A_1.Stop();
							}
						}
						ArrayList obj = x.f;
						lock (obj)
						{
							if (x.b(ref x.f, A_0))
							{
								return;
							}
						}
						if (0 == string.Compare(this.h.a, A_0, StringComparison.Ordinal))
						{
							return;
						}
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (7 > fileNameWithoutExtension.Length)
						{
							return;
						}
						checked
						{
							if (Operators.CompareString(Conversions.ToString(fileNameWithoutExtension.Last<char>()), "u", false) == 0 | Operators.CompareString(Conversions.ToString(fileNameWithoutExtension[fileNameWithoutExtension.Length - 2]), "u", false) == 0)
							{
								string strB = fileNameWithoutExtension.Substring(0, 5);
								if (0 == string.Compare(this.g.c, strB, StringComparison.Ordinal))
								{
									Bitmap bitmap = new Bitmap(this.b, this.a, this.e);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									MemoryStream obj2 = this.f;
									lock (obj2)
									{
										graphics.DrawImage(Image.FromStream(this.f), 0, 0, this.b, this.a);
									}
									MemoryStream memoryStream = new MemoryStream();
									int width;
									int height;
									using (Bitmap bitmap2 = x.a(A_0))
									{
										width = bitmap2.Width;
										height = bitmap2.Height;
										bitmap2.Save(memoryStream, ImageFormat.Png);
									}
									graphics.DrawImage(Image.FromStream(memoryStream), this.c - width / 2, this.d - height, width, height);
									graphics.Dispose();
									string str = x.a(this.g.b, fileNameWithoutExtension, 0);
									string a_ = Path.Combine(this.g.d, this.g.b + "_" + str);
									x.a(a_, ref bitmap, true);
									Interlocked.Add(ref x.k, 1);
									bitmap.Dispose();
									memoryStream.Dispose();
									ArrayList obj3 = x.f;
									lock (obj3)
									{
										x.f.Add(A_0);
									}
									this.g.a.ReportProgress(x.i);
									Thread.Sleep(x.c);
								}
							}
						}
					}

					// Token: 0x0400005B RID: 91
					public int a;

					// Token: 0x0400005C RID: 92
					public int b;

					// Token: 0x0400005D RID: 93
					public int c;

					// Token: 0x0400005E RID: 94
					public int d;

					// Token: 0x0400005F RID: 95
					public PixelFormat e;

					// Token: 0x04000060 RID: 96
					public MemoryStream f;

					// Token: 0x04000061 RID: 97
					public BW2_four.h g;

					// Token: 0x04000062 RID: 98
					public BW2_four.h.a h;
				}
			}
		}

		// Token: 0x0200001C RID: 28
		[CompilerGenerated]
		internal class k
		{
			// Token: 0x06000054 RID: 84 RVA: 0x00007DD8 File Offset: 0x00005FD8
			[CompilerGenerated]
			public void c(string A_0, ParallelLoopState A_1)
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
				Interlocked.Add(ref x.i, 1);
				string directoryName = Path.GetDirectoryName(A_0);
				ArrayList arrayList = new ArrayList();
				if (!asmodean_fun.readLsfToArrayList(ref arrayList, A_0))
				{
					return;
				}
				if (2 >= arrayList.Count)
				{
					return;
				}
				ArrayList arrayList2 = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				ArrayList arrayList4 = new ArrayList();
				ArrayList arrayList5 = new ArrayList();
				ArrayList arrayList6 = new ArrayList();
				ArrayList arrayList7 = new ArrayList();
				ArrayList arrayList8 = new ArrayList();
				string[] array = (string[])arrayList[0];
				int ibmpW = Conversions.ToInteger(array[3]);
				int ibmpH = Conversions.ToInteger(array[4]);
				int num = 1;
				checked
				{
					int num2 = arrayList.Count - 1;
					for (int i = num; i <= num2; i++)
					{
						string[] array2 = (string[])arrayList[i];
						Interlocked.Add(ref x.i, 1);
						string text = x.a(Path.Combine(directoryName, array2[0]), "");
						if (File.Exists(text))
						{
							Bitmap bitmap = x.a(text);
							PixelFormat pixelFormat = bitmap.PixelFormat;
							int width = bitmap.Width;
							int height = bitmap.Height;
							Rectangle rect = new Rectangle(0, 0, width, height);
							BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
							Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, x.a(pixelFormat), bitmapData.Scan0);
							bitmap.UnlockBits(bitmapData);
							Bitmap bitmap3 = new Bitmap(Conversions.ToInteger(array2[3]), Conversions.ToInteger(array2[4]), x.a(pixelFormat));
							Graphics graphics = Graphics.FromImage(bitmap3);
							graphics.Clear(Color.Transparent);
							graphics.DrawImage(bitmap2, Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), width, height);
							graphics.Dispose();
							MemoryStream memoryStream = new MemoryStream();
							bitmap3.Save(memoryStream, ImageFormat.Png);
							int num3 = Conversions.ToInteger(array2[8]);
							if (0 == num3)
							{
								arrayList2.Add(memoryStream);
								arrayList4.Add(array2[0]);
								arrayList6.Add(text);
							}
							else
							{
								if (255 == num3)
								{
									ArrayList f = x.f;
									lock (f)
									{
										x.f.Add(text);
										goto IL_295;
									}
								}
								if (0 < num3 & 99 > num3)
								{
									arrayList3.Add(memoryStream);
									arrayList5.Add(array2[0]);
									arrayList7.Add(text);
									arrayList8.Add(num3);
								}
							}
							IL_295:
							bitmap3.Dispose();
							bitmap2.Dispose();
							bitmap.Dispose();
						}
					}
					if (0 >= arrayList2.Count | 0 >= arrayList3.Count)
					{
						return;
					}
					int num4 = 0;
					int num5 = arrayList2.Count - 1;
					for (int j = num4; j <= num5; j++)
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
						int index = j;
						Bitmap bitmap4 = (Bitmap)Image.FromStream((MemoryStream)arrayList2[index]);
						PixelFormat pixelFormat2 = bitmap4.PixelFormat;
						ArrayList f2 = x.f;
						lock (f2)
						{
							x.f.Add(RuntimeHelpers.GetObjectValue(arrayList6[index]));
						}
						BW2_four.merge_lsf_layer_Bitmap(ref bitmap4, ibmpW, ibmpH, pixelFormat2, ref arrayList3, ref arrayList8, 1, directoryName, Conversions.ToString(arrayList4[index]), ref arrayList5, ref arrayList7, ref this.a);
					}
					ArrayList f3 = x.f;
					lock (f3)
					{
						x.f.Add(A_0);
					}
					Parallel.ForEach<object>(arrayList2.ToArray(), new Action<object>(BW2_four.b));
					arrayList2.Clear();
					Parallel.ForEach<object>(arrayList3.ToArray(), new Action<object>(BW2_four.a));
					arrayList3.Clear();
				}
			}

			// Token: 0x04000063 RID: 99
			public BackgroundWorker a;

			// Token: 0x04000064 RID: 100
			public bool b;
		}

		// Token: 0x0200001D RID: 29
		[CompilerGenerated]
		internal class b
		{
			// Token: 0x04000065 RID: 101
			public BackgroundWorker a;

			// Token: 0x04000066 RID: 102
			public string b;

			// Token: 0x04000067 RID: 103
			public bool c;

			// Token: 0x0200001E RID: 30
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x06000056 RID: 86 RVA: 0x00008254 File Offset: 0x00006454
				public a(BW2_four.b.a A_0)
				{
					if (A_0 != null)
					{
						this.a = A_0.a;
						this.d = A_0.d;
						this.c = A_0.c;
						this.b = A_0.b;
						this.e = A_0.e;
					}
				}

				// Token: 0x04000068 RID: 104
				public string a;

				// Token: 0x04000069 RID: 105
				public int b;

				// Token: 0x0400006A RID: 106
				public int c;

				// Token: 0x0400006B RID: 107
				public int d;

				// Token: 0x0400006C RID: 108
				public string e;

				// Token: 0x0200001F RID: 31
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000058 RID: 88 RVA: 0x000082AE File Offset: 0x000064AE
					[DebuggerStepThrough]
					[CompilerGenerated]
					public void e(object A_0, ParallelLoopState A_1)
					{
						new global::f<string[], ParallelLoopState>(this.e)((string[])A_0, A_1);
					}

					// Token: 0x06000059 RID: 89 RVA: 0x000082CC File Offset: 0x000064CC
					[CompilerGenerated]
					public void e(string[] A_0, ParallelLoopState A_1)
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
						string text = x.a(this.d.a + A_0[1], "");
						if (!string.IsNullOrEmpty(text))
						{
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
							string[] source = fileNameWithoutExtension.Split(new char[]
							{
								'+'
							});
							string text2 = source.First<string>() + "+";
							Bitmap bitmap = new Bitmap(this.d.d, this.d.c, this.b);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							MemoryStream obj = this.a;
							lock (obj)
							{
								using (Bitmap bitmap2 = (Bitmap)Image.FromStream(this.a))
								{
									graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
								}
							}
							text2 += this.d.e;
							if (this.d.b != Conversions.ToInteger(A_0[1]))
							{
								using (Bitmap bitmap3 = x.a(text))
								{
									int width = bitmap3.Width;
									int height = bitmap3.Height;
									Rectangle rect = new Rectangle(0, 0, width, height);
									BitmapData bitmapData = bitmap3.LockBits(rect, ImageLockMode.ReadOnly, bitmap3.PixelFormat);
									Bitmap bitmap4 = new Bitmap(width, height, bitmapData.Stride, x.a(bitmap3.PixelFormat), bitmapData.Scan0);
									bitmap3.UnlockBits(bitmapData);
									graphics.DrawImage(bitmap4, Conversions.ToInteger(A_0[4]), Conversions.ToInteger(A_0[5]), bitmap4.Width, bitmap4.Height);
									bitmap4.Dispose();
								}
								text2 = text2 + "+" + A_0[0];
							}
							graphics.Dispose();
							x.a(Path.Combine(this.c.b, text2), ref bitmap, true);
							bitmap.Dispose();
							ArrayList f = x.f;
							lock (f)
							{
								x.f.Add(text);
							}
							Interlocked.Add(ref x.k, 1);
							this.c.a.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}

					// Token: 0x0400006D RID: 109
					public MemoryStream a;

					// Token: 0x0400006E RID: 110
					public PixelFormat b;

					// Token: 0x0400006F RID: 111
					public BW2_four.b c;

					// Token: 0x04000070 RID: 112
					public BW2_four.b.a d;
				}
			}
		}

		// Token: 0x02000020 RID: 32
		[CompilerGenerated]
		internal class j
		{
			// Token: 0x0600005B RID: 91 RVA: 0x000085C4 File Offset: 0x000067C4
			[CompilerGenerated]
			public void d(string A_0, ParallelLoopState A_1)
			{
				BW2_four.j.a a = new BW2_four.j.a();
				Interlocked.Add(ref x.i, 1);
				if (Strings.InStr(1, A_0, "+", CompareMethod.Binary) > 0)
				{
					return;
				}
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
				a.b = new string[2];
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
				string directoryName = Path.GetDirectoryName(A_0);
				int num = 0;
				checked
				{
					while (Versioned.IsNumeric(fileNameWithoutExtension[fileNameWithoutExtension.Length - (num + 1)]))
					{
						num++;
					}
					if (0 == num)
					{
						return;
					}
					a.b[0] = fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - num);
					a.b[1] = fileNameWithoutExtension.Substring(fileNameWithoutExtension.Length - num);
					a.a = "";
					Parallel.ForEach<object>(x.e.ToArray(), this.c, new Action<object, ParallelLoopState>(a.c));
					if (string.IsNullOrWhiteSpace(a.a))
					{
						a.a = x.a(ref x.e, a.b[0] + "モ" + a.b[1] + "甲");
					}
					if (File.Exists(a.a))
					{
						Interlocked.Add(ref x.i, 1);
						string[] array = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(a.a));
						Bitmap bitmap = x.a(A_0);
						PixelFormat pixelFormat = bitmap.PixelFormat;
						int width = bitmap.Width;
						int height = bitmap.Height;
						Rectangle rect = new Rectangle(0, 0, width, height);
						BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
						Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, x.a(pixelFormat), bitmapData.Scan0);
						bitmap.UnlockBits(bitmapData);
						Bitmap bitmap3 = x.a(a.a);
						PixelFormat pixelFormat2 = bitmap3.PixelFormat;
						int width2 = bitmap3.Width;
						int height2 = bitmap3.Height;
						rect = new Rectangle(0, 0, width2, height2);
						bitmapData = bitmap3.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat2);
						Bitmap bitmap4 = new Bitmap(width2, height2, bitmapData.Stride, x.a(pixelFormat2), bitmapData.Scan0);
						bitmap3.UnlockBits(bitmapData);
						Bitmap bitmap5 = new Bitmap(width, height, x.a(pixelFormat));
						Graphics graphics = Graphics.FromImage(bitmap5);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(bitmap2, 0, 0, width, height);
						graphics.DrawImage(bitmap4, Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), width2, height2);
						graphics.Dispose();
						bitmap2.Dispose();
						bitmap.Dispose();
						bitmap4.Dispose();
						bitmap3.Dispose();
						string a_ = Path.Combine(directoryName, string.Concat(new string[]
						{
							fileNameWithoutExtension,
							"+x",
							array[1],
							"y",
							array[2]
						}));
						x.a(a_, ref bitmap5, true);
						bitmap5.Dispose();
						Interlocked.Add(ref x.k, 1);
						ArrayList f = x.f;
						lock (f)
						{
							x.f.Add(A_0);
							x.f.Add(a.a);
						}
						this.a.ReportProgress(x.i);
						Thread.Sleep(x.c);
					}
				}
			}

			// Token: 0x04000071 RID: 113
			public BackgroundWorker a;

			// Token: 0x04000072 RID: 114
			public bool b;

			// Token: 0x04000073 RID: 115
			public ParallelOptions c;

			// Token: 0x02000021 RID: 33
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x0600005D RID: 93 RVA: 0x0000895C File Offset: 0x00006B5C
				[CompilerGenerated]
				[DebuggerStepThrough]
				public void c(object A_0, ParallelLoopState A_1)
				{
					new ac<string, ParallelLoopState>(this.c)(Conversions.ToString(A_0), A_1);
				}

				// Token: 0x0600005E RID: 94 RVA: 0x00008978 File Offset: 0x00006B78
				[CompilerGenerated]
				public void c(string A_0, ParallelLoopState A_1)
				{
					if (Strings.InStr(1, A_0, "+", CompareMethod.Binary) > 0)
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(A_0);
						if (Strings.InStr(1, fileNameWithoutExtension, this.b[0] + "モ" + this.b[1] + "甲", CompareMethod.Binary) > 0)
						{
							this.a = A_0;
							A_1.Stop();
							return;
						}
					}
				}

				// Token: 0x04000074 RID: 116
				public string a;

				// Token: 0x04000075 RID: 117
				public string[] b;
			}
		}
	}
}
