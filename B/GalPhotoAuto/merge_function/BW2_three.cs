using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
	// Token: 0x02000054 RID: 84
	public class BW2_three
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00010264 File Offset: 0x0000E464
		public BW2_three()
		{
			this.asdFile = new ArrayList();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00010278 File Offset: 0x0000E478
		public static bool asd_png__a(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				Regex regFindValueSX = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=\\%x[ ]+sy=0[ ]+sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
				Regex rgx = new Regex("\\=[0-9]{0,3}", RegexOptions.IgnoreCase);
				Regex regFindValueSY = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=[0-9]{0,3}[ ]+sy=\\%y sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
				Regex regFindValueSX2 = new Regex("\\@copy[ ]+dx=[0-9]{0,3}[ ]+dy=[0-9]{0,3}[ ]+sx=[0-9]{0,3}[ ]+sy=0[ ]+sw=[0-9]{0,3}[ ]+sh=[0-9]{0,3}", RegexOptions.IgnoreCase);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker2.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker2.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					int num = Path.GetFullPath(thispath).Length - Path.GetExtension(thispath).Length;
					string baseF1 = Path.GetFullPath(thispath).Substring(0, num);
					string baseF2 = Path.GetFullPath(thispath).Substring(0, num) + "_a";
					string masterfile = string.Empty;
					string arfile = string.Empty;
					string[] files = Directory.GetFiles(Path.GetDirectoryName(thispath));
					if (files.Length > 0)
					{
						Parallel.ForEach<string>(files, delegate(string path1)
						{
							string strB = Path.GetFullPath(path1).Substring(0, Path.GetFullPath(path1).Length - Path.GetExtension(path1).Length);
							if (0 == string.Compare(baseF1, strB, StringComparison.Ordinal))
							{
								masterfile = PublicModule.searchBitmapWithExt(baseF1, "");
								Interlocked.Add(ref PublicModule.iNow, 1);
							}
							else if (0 == string.Compare(baseF2, strB, StringComparison.Ordinal))
							{
								arfile = PublicModule.searchBitmapWithExt(baseF2, "");
								Interlocked.Add(ref PublicModule.iNow, 1);
							}
						});
					}
					else
					{
						loopstate.Stop();
					}
					if (string.IsNullOrEmpty(masterfile) | string.IsNullOrEmpty(arfile))
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
					using (FileStream fileStream = new FileStream(thispath, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream))
						{
							while (!streamReader.EndOfStream)
							{
								string input = streamReader.ReadLine();
								if (regFindValueSX.IsMatch(input))
								{
									if (!flag)
									{
										MatchCollection matchCollection = rgx.Matches(input);
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
								else if (regFindValueSY.IsMatch(input) && !flag2)
								{
									MatchCollection matchCollection = rgx.Matches(input);
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
						using (FileStream fileStream2 = new FileStream(thispath, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader2 = new StreamReader(fileStream2))
							{
								while (!streamReader2.EndOfStream)
								{
									string input = streamReader2.ReadLine();
									if (regFindValueSX2.IsMatch(input) && !flag)
									{
										MatchCollection matchCollection = rgx.Matches(input);
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
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(masterfile))
					{
						width2 = bitMapFromFile.Width;
						height = bitMapFromFile.Height;
						pixelFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(memoryStream, ImageFormat.Png);
					}
					using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(arfile))
					{
						Bitmap bitmap = new Bitmap(width2, height, pixelFormat);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(Image.FromStream(memoryStream), 0, 0, width2, height);
						num = bitMapFromFile2.Width / num5;
						string str = Path.Combine(Path.GetDirectoryName(arfile), Path.GetFileNameWithoutExtension(arfile));
						int num9 = 1;
						int num10 = num;
						for (int i = num9; i <= num10; i++)
						{
							Rectangle rect = new Rectangle(num4, y, num5, num6);
							BitmapData bitmapData = bitMapFromFile2.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
							Bitmap bitmap2 = new Bitmap(num5, num6, bitmapData.Stride, bitMapFromFile2.PixelFormat, bitmapData.Scan0);
							bitMapFromFile2.UnlockBits(bitmapData);
							graphics.DrawImage(bitmap2, num2, num3, num5, num6);
							PublicModule.saveBitmapFile(str + "_sw" + i.ToString("D3"), ref bitmap, true);
							bitmap2.Dispose();
							num4 += num5;
							Interlocked.Add(ref PublicModule.iBuild, 1);
						}
						graphics.Dispose();
						bitmap.Dispose();
						if (flag2)
						{
							bitmap = new Bitmap(width2, height, PixelFormat.Format32bppArgb);
							graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							num = bitMapFromFile2.Height / num8;
							int num11 = 1;
							int num12 = num;
							for (int j = num11; j <= num12; j++)
							{
								Rectangle rect = new Rectangle(x2, num7, width, num8);
								BitmapData bitmapData = bitMapFromFile2.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
								Bitmap bitmap2 = new Bitmap(width, num8, bitmapData.Stride, bitMapFromFile2.PixelFormat, bitmapData.Scan0);
								bitMapFromFile2.UnlockBits(bitmapData);
								graphics.DrawImage(bitmap2, x, y2, width, num8);
								PublicModule.saveBitmapFile(str + "_sy" + j.ToString("D3"), ref bitmap, true);
								bitmap2.Dispose();
								num7 += num8;
								Interlocked.Add(ref PublicModule.iBuild, 1);
							}
							graphics.Dispose();
							bitmap.Dispose();
						}
					}
					memoryStream.Dispose();
					ArrayList files2 = PublicModule.files2;
					lock (files2)
					{
						PublicModule.files2.Add(thispath);
						PublicModule.files2.Add(masterfile);
						PublicModule.files2.Add(arfile);
					}
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00010350 File Offset: 0x0000E550
		public static bool asd__a__a_m(ref Form1 myForm1)
		{
			BW2_three._Closure$__73 CS$<>8__locals1 = new BW2_three._Closure$__73(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				CS$<>8__locals1.$VB$Local_regFindValue = new Regex("\\[eval exp=\\042.*\\042\\]", RegexOptions.IgnoreCase);
				CS$<>8__locals1.$VB$Local_rgx = new Regex("\\042.*\\042", RegexOptions.IgnoreCase);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				CS$<>8__locals1.$VB$Local_ksarrkey = new Dictionary<string, string>();
				ArrayList arrayList = new ArrayList(10);
				if (0 < PublicModule.form1box4directorylist.Count)
				{
					string sSpecialExt = PublicModule.sSpecialExt;
					PublicModule.sSpecialExt = "ks";
					try
					{
						foreach (object value in PublicModule.form1box4directorylist)
						{
							string folder_path = Conversions.ToString(value);
							PublicModule.RecursionFolder(folder_path, ref arrayList);
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
					PublicModule.sSpecialExt = sSpecialExt;
					if (0 < arrayList.Count)
					{
						try
						{
							foreach (object value2 in arrayList)
							{
								string path = Conversions.ToString(value2);
								using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
								{
									using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
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
													array2 = PublicModule.regEqual.Split(input);
													if (Versioned.IsNumeric(array2.Last<string>().Trim()) && !CS$<>8__locals1.$VB$Local_ksarrkey.ContainsKey(array2.First<string>().Trim()))
													{
														CS$<>8__locals1.$VB$Local_ksarrkey.Add(array2.First<string>().Trim(), array2.Last<string>().Trim());
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
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					BW2_three._Closure$__73._Closure$__74 CS$<>8__locals2 = new BW2_three._Closure$__73._Closure$__74(CS$<>8__locals2);
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						CS$<>8__locals1.$VB$Local_eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals1.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
					}
					int num = 0;
					num = Path.GetFullPath(thispath).Length - Path.GetExtension(thispath).Length;
					CS$<>8__locals2.$VB$Local_baseF1 = Path.GetFullPath(thispath).Substring(0, num) + "_a";
					CS$<>8__locals2.$VB$Local_baseF2 = Path.GetFullPath(thispath).Substring(0, num) + "_a_m";
					CS$<>8__locals2.$VB$Local_masterfile = string.Empty;
					CS$<>8__locals2.$VB$Local_arfile = string.Empty;
					string[] files = Directory.GetFiles(Path.GetDirectoryName(thispath));
					if (files.Length > 0)
					{
						Parallel.ForEach<string>(files, delegate(string path1)
						{
							string strB = Path.GetFullPath(path1).Substring(0, Path.GetFullPath(path1).Length - Path.GetExtension(path1).Length);
							if (0 == string.Compare(CS$<>8__locals2.$VB$Local_baseF1, strB, StringComparison.Ordinal))
							{
								CS$<>8__locals2.$VB$Local_masterfile = PublicModule.searchBitmapWithExt(CS$<>8__locals2.$VB$Local_baseF1, "");
								Interlocked.Add(ref PublicModule.iNow, 1);
							}
							else if (0 == string.Compare(CS$<>8__locals2.$VB$Local_baseF2, strB, StringComparison.Ordinal))
							{
								CS$<>8__locals2.$VB$Local_arfile = PublicModule.searchBitmapWithExt(CS$<>8__locals2.$VB$Local_baseF2, "");
								Interlocked.Add(ref PublicModule.iNow, 1);
							}
						});
					}
					else
					{
						loopstate.Stop();
					}
					if (string.IsNullOrEmpty(CS$<>8__locals2.$VB$Local_masterfile) | string.IsNullOrEmpty(CS$<>8__locals2.$VB$Local_arfile))
					{
						return;
					}
					CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
					string text2 = "";
					string text3 = "";
					int num2;
					int num3;
					int num4;
					int num5;
					int num6;
					int num7;
					using (FileStream fileStream2 = new FileStream(thispath, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader2 = new StreamReader(fileStream2))
						{
							while (!streamReader2.EndOfStream)
							{
								text2 = streamReader2.ReadLine();
								if (CS$<>8__locals1.$VB$Local_regFindValue.IsMatch(text2))
								{
									MatchCollection matchCollection = CS$<>8__locals1.$VB$Local_rgx.Matches(text2);
									if (matchCollection.Count > 0)
									{
										string text4 = matchCollection[0].Value.Replace("\"", "");
										string[] array3 = PublicModule.regEqual.Split(text4);
										text4 = array3[0].Trim();
										if (Strings.InStr(1, text4, "_b_w", CompareMethod.Binary) > 0)
										{
											num2 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_b_h", CompareMethod.Binary) > 0)
										{
											num3 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_f_x", CompareMethod.Binary) > 0)
										{
											num4 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_f_y", CompareMethod.Binary) > 0)
										{
											num5 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_f_w", CompareMethod.Binary) > 0)
										{
											num6 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_f_h", CompareMethod.Binary) > 0)
										{
											num7 = Conversions.ToInteger(array3[1].Trim());
										}
										else if (Strings.InStr(1, text4, "_sx1", CompareMethod.Binary) > 0)
										{
											text3 = PublicModule.regXIA.Split(text4).First<string>();
											break;
										}
									}
								}
							}
						}
					}
					CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
					if ((0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7) && !string.IsNullOrEmpty(text3) && 0 < CS$<>8__locals1.$VB$Local_ksarrkey.Count)
					{
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_b_w", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num2 = Conversions.ToInteger(text2);
						}
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_b_h", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num3 = Conversions.ToInteger(text2);
						}
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_f_x", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num4 = Conversions.ToInteger(text2);
						}
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_f_y", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num5 = Conversions.ToInteger(text2);
						}
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_f_w", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num6 = Conversions.ToInteger(text2);
						}
						CS$<>8__locals1.$VB$Local_ksarrkey.TryGetValue(text3 + "_f_h", out text2);
						if (Versioned.IsNumeric(text2))
						{
							num7 = Conversions.ToInteger(text2);
						}
					}
					int num8 = 1;
					int num9 = 0;
					if (0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7)
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(thispath);
						string text5 = PublicModule.searchBitmapWithExt(Path.Combine(Path.GetDirectoryName(thispath), fileNameWithoutExtension), "");
						if (File.Exists(text5))
						{
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text5))
							{
								num2 = bitMapFromFile.Width;
								num3 = bitMapFromFile.Height;
							}
							using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_masterfile))
							{
								num9 = bitMapFromFile2.Width;
								int height = bitMapFromFile2.Height;
								if (num9 > num2)
								{
									num8 = 2;
								}
								else
								{
									using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_arfile))
									{
										FastBitmap fastBitmap = new FastBitmap(bitMapFromFile3);
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
												if (PublicModule.isColorWhile(ref pixel))
												{
													pixel = fastBitmap.GetPixel(j + 1, i);
													if (PublicModule.isColorBlack(ref pixel))
													{
														pixel = fastBitmap.GetPixel(j + 1, i - 1);
														if (PublicModule.isColorWhile(ref pixel))
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
													if (PublicModule.isColorBlack(ref pixel))
													{
														pixel = fastBitmap.GetPixel(l, k - 1);
														if (PublicModule.isColorWhile(ref pixel))
														{
															pixel = fastBitmap.GetPixel(l + 1, k);
															if (PublicModule.isColorWhile(ref pixel))
															{
																num6 = l - num4;
															}
														}
													}
												}
												if (num7 == 0)
												{
													Color pixel = fastBitmap.GetPixel(l, k);
													if (PublicModule.isColorBlack(ref pixel))
													{
														pixel = fastBitmap.GetPixel(l, k + 1);
														if (PublicModule.isColorWhile(ref pixel))
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
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(text5);
							}
						}
					}
					if (num8 == 1)
					{
						if (0 >= num2 | 0 >= num3 | 0 >= num4 | 0 >= num5 | 0 >= num6 | 0 >= num7)
						{
							PublicModule.addLog(string.Concat(new string[]
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
						PublicModule.addLog(Conversions.ToString(num2) + Conversions.ToString(num3) + " iCopyMode" + Conversions.ToString(num8));
						return;
					}
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					using (Bitmap bitMapFromFile4 = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_masterfile))
					{
						FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile4);
						using (Bitmap bitMapFromFile5 = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_arfile))
						{
							FastBitmap fastBitmap3 = new FastBitmap(bitMapFromFile5);
							int width = bitMapFromFile4.Width;
							Bitmap bitmap = new Bitmap(width, num3, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap4 = new FastBitmap(bitmap);
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
									int alpha = PublicModule.getiAlphaFromColor(ref pixel3);
									fastBitmap4.SetPixel(m, n, Color.FromArgb(alpha, pixel2));
								}
							}
							fastBitmap4.Save(ref memoryStream, ImageFormat.Png);
							fastBitmap4.Dispose();
							bitmap.Dispose();
							if (num8 == 1)
							{
								bitmap = new Bitmap(fastBitmap2.iWidth, fastBitmap2.iHeight - num3, PixelFormat.Format32bppArgb);
								fastBitmap4 = new FastBitmap(bitmap);
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
								bitmap.Dispose();
							}
						}
						fastBitmap2.Dispose();
					}
					if (num8 == 1)
					{
						int num28 = 0;
						int num29 = 0;
						Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream2);
						bool flag2 = true;
						num = 0;
						bool flag3 = false;
						while (flag2)
						{
							if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals1.$VB$Local_eCancel = true;
								break;
							}
							while (PublicModule.bWaitCancelAsync)
							{
								Thread.Sleep(500);
								if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals1.$VB$Local_eCancel = true;
									break;
								}
							}
							flag3 = false;
							Rectangle rect = new Rectangle(num28, num29, num6, num7);
							BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
							Bitmap bitmap3 = new Bitmap(num6, num7, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
							bitmap2.UnlockBits(bitmapData);
							using (MemoryStream memoryStream3 = new MemoryStream())
							{
								bitmap3.Save(memoryStream3, ImageFormat.Png);
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
										Color pixel2 = bitmap3.GetPixel(num38, num41);
										fastBitmap6.SetPixel(num38 + num4, num41 + num5, Color.FromArgb((int)pixel2.A, pixel2));
									}
								}
								string sSavePath = CS$<>8__locals2.$VB$Local_masterfile.Substring(0, CS$<>8__locals2.$VB$Local_masterfile.Length - Path.GetExtension(CS$<>8__locals2.$VB$Local_masterfile).Length) + "_" + num.ToString("D3");
								PublicModule.saveBitmapFile(sSavePath, ref fastBitmap6);
								fastBitmap6.Dispose();
								num++;
								Interlocked.Add(ref PublicModule.iBuild, 1);
							}
							CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
							Thread.Sleep(PublicModule.iThreadWaitTime);
							num28 += num6;
							if (num28 + num6 > bitmap2.Width)
							{
								num28 = 0;
								num29 += num7;
							}
							if (num29 + num7 > bitmap2.Height)
							{
								flag2 = false;
							}
							bitmap3.Dispose();
						}
						bitmap2.Dispose();
					}
					else if (num8 == 2)
					{
						int num42 = (int)Math.Round((double)num9 / (double)num2);
						double num43 = (double)num9 / (double)num2;
						if (num43 > (double)num42)
						{
							num42++;
						}
						Bitmap bitmap4 = (Bitmap)Image.FromStream(memoryStream);
						int num44 = 0;
						int num45 = num42 - 1;
						for (int num46 = num44; num46 <= num45; num46++)
						{
							Rectangle rect2 = new Rectangle(num46 * num2, 0, num2, num3);
							BitmapData bitmapData2 = bitmap4.LockBits(rect2, ImageLockMode.ReadOnly, bitmap4.PixelFormat);
							Bitmap bitmap5 = new Bitmap(num2, num3, bitmapData2.Stride, bitmap4.PixelFormat, bitmapData2.Scan0);
							bitmap4.UnlockBits(bitmapData2);
							string sSavePath2 = Path.Combine(Path.GetDirectoryName(thispath), Path.GetFileNameWithoutExtension(thispath) + "_" + num46.ToString("D3"));
							PublicModule.saveBitmapFile(sSavePath2, ref bitmap5, true);
							bitmap5.Dispose();
							Interlocked.Add(ref PublicModule.iBuild, 1);
							CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						}
						bitmap4.Dispose();
						Thread.Sleep(PublicModule.iThreadWaitTime);
					}
					memoryStream2.Dispose();
					memoryStream.Dispose();
					ArrayList files3 = PublicModule.files2;
					lock (files3)
					{
						PublicModule.files2.Add(thispath);
						PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_masterfile);
						PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_arfile);
					}
				});
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00010628 File Offset: 0x0000E828
		public static bool cgm_asd(ref Form1 myForm1)
		{
			bool result = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref PublicModule.iNow, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (PublicModule.bWaitCancelAsync)
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
					Interlocked.Add(ref PublicModule.iNow, 1);
					PublicModule.files2.Add(text);
					backgroundWorker.ReportProgress(PublicModule.iNow);
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
										Interlocked.Add(ref PublicModule.iNow, 1);
										int num = array3.Count<string>();
										if (2 == num)
										{
											if (BW2_three.cgm_asd_ev_2(text2, text3, array3, ref myForm1))
											{
												result = true;
											}
										}
										else if (3 == num)
										{
											if (BW2_three.cgm_asd_ev_3(text2, text3, array3, ref myForm1))
											{
												result = true;
											}
										}
										else if (3 < num)
										{
											PublicModule.addLog("数组多过3个，未支持: " + cgmData.baseName);
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
			PublicModule.sSpecialExt = string.Empty;
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00010888 File Offset: 0x0000EA88
		private static bool cgm_asd_ev_2(string sCgmBaseName, string asdfile, string[] cgArr, ref Form1 myForm1)
		{
			bool eCancel = false;
			ParallelOptions po = PublicModule.PublicParallelOptions();
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			ArrayList arrayList = kirikiri2_fun.readCgmAsdToArr(asdfile, cgArr[1]);
			checked
			{
				if (0 < arrayList.Count)
				{
					string text = PublicModule.searchBitmapWithExt(Path.Combine(Path.GetDirectoryName(asdfile), Path.GetFileNameWithoutExtension(asdfile)), "");
					if (File.Exists(text))
					{
						MemoryStream bmpStream = new MemoryStream();
						int iW = 0;
						int iH = 0;
						using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
						{
							iW = bitMapFromFile.Width;
							iH = bitMapFromFile.Height;
							bitMapFromFile.Save(bmpStream, ImageFormat.Png);
						}
						int count = arrayList.Count;
						if (2 == count)
						{
							ArrayList arr1 = new ArrayList();
							ArrayList arr2 = new ArrayList();
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
											string text2 = PublicModule.searchBitmapWithExt(sCgmBaseName + asdData.forktarget_storage, "");
											if (File.Exists(text2))
											{
												PublicModule.files2.Add(text2);
												Interlocked.Add(ref PublicModule.iNow, 1);
												Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text2);
												Bitmap bitmap = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
												Graphics graphics = Graphics.FromImage(bitmap);
												graphics.Clear(Color.Transparent);
												graphics.DrawImage(bitmap, asdData.forktarget_x, asdData.forktarget_y, bitmap.Width, bitmap.Height);
												graphics.Dispose();
												MemoryStream memoryStream = new MemoryStream();
												bitmap.Save(memoryStream, ImageFormat.Png);
												bitmap.Dispose();
												arr1.Add(memoryStream);
												bitMapFromFile2.Dispose();
											}
										}
									}
									else
									{
										string text3 = PublicModule.searchBitmapWithExt(sCgmBaseName + storage, "");
										if (File.Exists(text3))
										{
											PublicModule.files2.Add(text3);
											Interlocked.Add(ref PublicModule.iNow, 1);
											if (string.IsNullOrEmpty(value))
											{
												value = storage;
											}
											Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text3);
											int width = bitMapFromFile3.Width;
											int height = bitMapFromFile3.Height;
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
												Bitmap bitmap2 = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
												Graphics graphics2 = Graphics.FromImage(bitmap2);
												graphics2.Clear(Color.Transparent);
												Rectangle rect = new Rectangle(i * num, asdData.top, num, num3);
												BitmapData bitmapData = bitMapFromFile3.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile3.PixelFormat);
												Bitmap bitmap3 = new Bitmap(num, num3, bitmapData.Stride, bitMapFromFile3.PixelFormat, bitmapData.Scan0);
												bitMapFromFile3.UnlockBits(bitmapData);
												graphics2.DrawImage(bitmap3, asdData.x, asdData.y, bitmap3.Width, bitmap3.Height);
												bitmap3.Dispose();
												if (!string.IsNullOrEmpty(asdData.forktarget_storage))
												{
													string text4 = PublicModule.searchBitmapWithExt(sCgmBaseName + asdData.forktarget_storage, "");
													if (File.Exists(text4))
													{
														bitmap3 = PublicModule.getBitMapFromFile(text4);
														graphics2.DrawImage(bitmap3, asdData.forktarget_x, asdData.forktarget_y, bitmap3.Width, bitmap3.Height);
														bitmap3.Dispose();
														PublicModule.files2.Add(text4);
													}
												}
												graphics2.Dispose();
												MemoryStream memoryStream2 = new MemoryStream();
												bitmap2.Save(memoryStream2, ImageFormat.Png);
												bitmap2.Dispose();
												if (Strings.InStr(1, storage, "口", CompareMethod.Binary) > 0)
												{
													arr2.Add(memoryStream2);
												}
												else
												{
													arr1.Add(memoryStream2);
												}
												BackgroundWorker2.ReportProgress(PublicModule.iNow);
											}
											bitMapFromFile3.Dispose();
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
							if (0 == arr1.Count & 0 < arr2.Count)
							{
								Parallel.For(0, arr2.Count, po, delegate(int iB, ParallelLoopState loopstate2)
								{
									if (BackgroundWorker2.CancellationPending)
									{
										eCancel = true;
										loopstate2.Stop();
									}
									while (PublicModule.bWaitCancelAsync)
									{
										Thread.Sleep(500);
										if (BackgroundWorker2.CancellationPending)
										{
											eCancel = true;
											loopstate2.Stop();
										}
									}
									MemoryStream $VB$Local_bmpStream = bmpStream;
									Bitmap bitmap4;
									lock ($VB$Local_bmpStream)
									{
										bitmap4 = (Bitmap)Image.FromStream(bmpStream);
									}
									Graphics graphics3 = Graphics.FromImage(bitmap4);
									ArrayList $VB$Local_arr = arr2;
									Bitmap bitmap5;
									lock ($VB$Local_arr)
									{
										bitmap5 = (Bitmap)Image.FromStream((MemoryStream)arr2[iB]);
									}
									graphics3.DrawImage(bitmap5, 0, 0, iW, iH);
									bitmap5.Dispose();
									string sSavePath = string.Concat(new string[]
									{
										sCgmBaseName,
										cgArr[0],
										"_",
										cgArr[1].Replace("*", string.Empty),
										"_",
										Conversions.ToString(iB)
									});
									PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
									bitmap4.Dispose();
									Interlocked.Add(ref PublicModule.iBuild, 1);
									BackgroundWorker2.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								});
							}
							else
							{
								Parallel.For(0, arr1.Count, po, delegate(int iA, ParallelLoopState loopstate1)
								{
									if (BackgroundWorker2.CancellationPending)
									{
										eCancel = true;
										loopstate1.Stop();
									}
									while (PublicModule.bWaitCancelAsync)
									{
										Thread.Sleep(500);
										if (BackgroundWorker2.CancellationPending)
										{
											eCancel = true;
											loopstate1.Stop();
										}
									}
									if (0 < arr2.Count)
									{
										Parallel.For(0, arr2.Count, po, delegate(int iB, ParallelLoopState loopstate2)
										{
											if (BackgroundWorker2.CancellationPending)
											{
												eCancel = true;
												loopstate2.Stop();
											}
											while (PublicModule.bWaitCancelAsync)
											{
												Thread.Sleep(500);
												if (BackgroundWorker2.CancellationPending)
												{
													eCancel = true;
													loopstate2.Stop();
												}
											}
											MemoryStream $VB$Local_bmpStream2 = bmpStream;
											Bitmap bitmap5;
											lock ($VB$Local_bmpStream2)
											{
												bitmap5 = (Bitmap)Image.FromStream(bmpStream);
											}
											Graphics graphics4 = Graphics.FromImage(bitmap5);
											ArrayList $VB$Local_arr2 = arr1;
											Bitmap bitmap6;
											lock ($VB$Local_arr2)
											{
												bitmap6 = (Bitmap)Image.FromStream((MemoryStream)arr1[iA]);
											}
											graphics4.DrawImage(bitmap6, 0, 0, iW, iH);
											ArrayList $VB$Local_arr3 = arr2;
											lock ($VB$Local_arr3)
											{
												bitmap6 = (Bitmap)Image.FromStream((MemoryStream)arr2[iB]);
											}
											graphics4.DrawImage(bitmap6, 0, 0, iW, iH);
											bitmap6.Dispose();
											string sSavePath2 = string.Concat(new string[]
											{
												sCgmBaseName,
												cgArr[0],
												"_",
												cgArr[1].Replace("*", string.Empty),
												"_",
												Conversions.ToString(iA),
												"_",
												Conversions.ToString(iB)
											});
											PublicModule.saveBitmapFile(sSavePath2, ref bitmap5, true);
											bitmap5.Dispose();
											Interlocked.Add(ref PublicModule.iBuild, 1);
											BackgroundWorker2.ReportProgress(PublicModule.iNow);
											Thread.Sleep(PublicModule.iThreadWaitTime);
										});
									}
									else
									{
										MemoryStream $VB$Local_bmpStream = bmpStream;
										Bitmap bitmap4;
										lock ($VB$Local_bmpStream)
										{
											bitmap4 = (Bitmap)Image.FromStream(bmpStream);
										}
										Graphics graphics3 = Graphics.FromImage(bitmap4);
										ArrayList $VB$Local_arr = arr1;
										Bitmap image;
										lock ($VB$Local_arr)
										{
											image = (Bitmap)Image.FromStream((MemoryStream)arr1[iA]);
										}
										graphics3.DrawImage(image, 0, 0, iW, iH);
										string sSavePath = sCgmBaseName + cgArr[0] + "_" + cgArr[1].Replace("*", string.Empty);
										PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
										bitmap4.Dispose();
										Interlocked.Add(ref PublicModule.iBuild, 1);
										BackgroundWorker2.ReportProgress(PublicModule.iNow);
										Thread.Sleep(PublicModule.iThreadWaitTime);
									}
								});
							}
							Parallel.ForEach<object>(arr1.ToArray(), delegate(object a0)
							{
								delegate(MemoryStream ms)
								{
									ms.Dispose();
								}((MemoryStream)a0);
							});
							arr1.Clear();
							Parallel.ForEach<object>(arr2.ToArray(), delegate(object a0)
							{
								delegate(MemoryStream ms)
								{
									ms.Dispose();
								}((MemoryStream)a0);
							});
							arr2.Clear();
						}
						bmpStream.Dispose();
					}
					PublicModule.files2.Add(text);
					PublicModule.files2.Add(asdfile);
				}
				return eCancel;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00010E90 File Offset: 0x0000F090
		private static void cgm_asd_ev_make_arr1(ref Form1 myForm1, ref ArrayList arr1, ref ArrayList arr2, string asdFile, string cgName, string sCgmBaseName, ref int iW, ref int iH)
		{
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			ArrayList arrayList = kirikiri2_fun.readCgmAsdToArr(asdFile, cgName);
			checked
			{
				if (0 < arrayList.Count)
				{
					string text = Path.ChangeExtension(asdFile, "png");
					if (File.Exists(text))
					{
						MemoryStream memoryStream = new MemoryStream();
						using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
						{
							iW = bitMapFromFile.Width;
							iH = bitMapFromFile.Height;
							bitMapFromFile.Save(memoryStream, ImageFormat.Png);
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
											string text2 = PublicModule.searchBitmapWithExt(sCgmBaseName + asdData.forktarget_storage, "");
											if (File.Exists(text2))
											{
												PublicModule.files2.Add(text2);
												Interlocked.Add(ref PublicModule.iNow, 1);
												Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text2);
												Bitmap bitmap = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
												Graphics graphics = Graphics.FromImage(bitmap);
												graphics.Clear(Color.Transparent);
												graphics.DrawImage(bitmap, asdData.forktarget_x, asdData.forktarget_y, bitmap.Width, bitmap.Height);
												graphics.Dispose();
												MemoryStream memoryStream2 = new MemoryStream();
												bitmap.Save(memoryStream2, ImageFormat.Png);
												bitmap.Dispose();
												arr1.Add(memoryStream2);
												bitMapFromFile2.Dispose();
											}
										}
									}
									else
									{
										string text3 = PublicModule.searchBitmapWithExt(sCgmBaseName + storage, "");
										if (File.Exists(text3))
										{
											PublicModule.files2.Add(text3);
											Interlocked.Add(ref PublicModule.iNow, 1);
											if (string.IsNullOrEmpty(value))
											{
												value = storage;
											}
											Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text3);
											int width = bitMapFromFile3.Width;
											int height = bitMapFromFile3.Height;
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
												Bitmap bitmap2 = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
												Graphics graphics2 = Graphics.FromImage(bitmap2);
												graphics2.Clear(Color.Transparent);
												Rectangle rect = new Rectangle(i * num, asdData.top, num, num3);
												BitmapData bitmapData = bitMapFromFile3.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile3.PixelFormat);
												Bitmap bitmap3 = new Bitmap(num, num3, bitmapData.Stride, bitMapFromFile3.PixelFormat, bitmapData.Scan0);
												bitMapFromFile3.UnlockBits(bitmapData);
												graphics2.DrawImage(bitmap3, asdData.x, asdData.y, bitmap3.Width, bitmap3.Height);
												bitmap3.Dispose();
												graphics2.Dispose();
												MemoryStream memoryStream3 = new MemoryStream();
												bitmap2.Save(memoryStream3, ImageFormat.Png);
												bitmap2.Dispose();
												if (Strings.InStr(1, storage, "口", CompareMethod.Binary) > 0)
												{
													arr2.Add(memoryStream3);
												}
												else
												{
													arr1.Add(memoryStream3);
												}
												backgroundWorker.ReportProgress(PublicModule.iNow);
											}
											bitMapFromFile3.Dispose();
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

		// Token: 0x060000DB RID: 219 RVA: 0x00011270 File Offset: 0x0000F470
		private static void cgm_asd_ev_make_arr2(ref Form1 myForm1, ref ArrayList arr1, ref ArrayList arr2, ref ArrayList arr3, ref int iW, ref int iH)
		{
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			checked
			{
				if (0 == arr1.Count & 0 < arr2.Count)
				{
					int num = 0;
					int num2 = arr2.Count - 1;
					for (int i = num; i <= num2; i++)
					{
						Bitmap bitmap = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
						Graphics graphics = Graphics.FromImage(bitmap);
						Bitmap bitmap2 = (Bitmap)Image.FromStream((MemoryStream)arr2[i]);
						graphics.DrawImage(bitmap2, 0, 0, iW, iH);
						bitmap2.Dispose();
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Png);
						arr3.Add(memoryStream);
						bitmap.Dispose();
						backgroundWorker.ReportProgress(PublicModule.iNow);
					}
				}
				else
				{
					int num3 = 0;
					int num4 = arr1.Count - 1;
					for (int j = num3; j <= num4; j++)
					{
						int num5 = 0;
						int num6 = arr2.Count - 1;
						for (int k = num5; k <= num6; k++)
						{
							Bitmap bitmap3 = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
							Graphics graphics2 = Graphics.FromImage(bitmap3);
							Bitmap bitmap4 = (Bitmap)Image.FromStream((MemoryStream)arr1[j]);
							graphics2.DrawImage(bitmap4, 0, 0, iW, iH);
							bitmap4 = (Bitmap)Image.FromStream((MemoryStream)arr2[k]);
							graphics2.DrawImage(bitmap4, 0, 0, iW, iH);
							bitmap4.Dispose();
							MemoryStream memoryStream2 = new MemoryStream();
							bitmap3.Save(memoryStream2, ImageFormat.Png);
							arr3.Add(memoryStream2);
							bitmap3.Dispose();
							backgroundWorker.ReportProgress(PublicModule.iNow);
						}
					}
				}
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00011420 File Offset: 0x0000F620
		private static bool cgm_asd_ev_3(string sCgmBaseName, string asdfile, string[] cgArr, ref Form1 myForm1)
		{
			bool eCancel = false;
			ParallelOptions po = PublicModule.PublicParallelOptions();
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			int iW = 0;
			int iH = 0;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			BW2_three.cgm_asd_ev_make_arr1(ref myForm1, ref arrayList, ref arrayList2, asdfile, cgArr[1], sCgmBaseName, ref iW, ref iH);
			ArrayList arrayList3 = new ArrayList();
			ArrayList arrayList4 = new ArrayList();
			BW2_three.cgm_asd_ev_make_arr1(ref myForm1, ref arrayList3, ref arrayList4, asdfile, cgArr[2], sCgmBaseName, ref iW, ref iH);
			ArrayList arr5 = new ArrayList();
			BW2_three.cgm_asd_ev_make_arr2(ref myForm1, ref arrayList, ref arrayList2, ref arr5, ref iW, ref iH);
			ArrayList arr6 = new ArrayList();
			BW2_three.cgm_asd_ev_make_arr2(ref myForm1, ref arrayList3, ref arrayList4, ref arr6, ref iW, ref iH);
			MemoryStream bmpStream1 = new MemoryStream();
			string text = Path.ChangeExtension(asdfile, "png");
			using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
			{
				bitMapFromFile.Save(bmpStream1, ImageFormat.Png);
			}
			Parallel.For(0, arr5.Count, po, delegate(int iA, ParallelLoopState loopstate1)
			{
				if (BackgroundWorker2.CancellationPending)
				{
					eCancel = true;
					loopstate1.Stop();
				}
				while (PublicModule.bWaitCancelAsync)
				{
					Thread.Sleep(500);
					if (BackgroundWorker2.CancellationPending)
					{
						eCancel = true;
						loopstate1.Stop();
					}
				}
				Parallel.For(0, arr6.Count, po, delegate(int iB, ParallelLoopState loopstate2)
				{
					if (BackgroundWorker2.CancellationPending)
					{
						eCancel = true;
						loopstate2.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker2.CancellationPending)
						{
							eCancel = true;
							loopstate2.Stop();
						}
					}
					MemoryStream $VB$Local_bmpStream = bmpStream1;
					Bitmap bitmap;
					lock ($VB$Local_bmpStream)
					{
						bitmap = (Bitmap)Image.FromStream(bmpStream1);
					}
					Graphics graphics = Graphics.FromImage(bitmap);
					ArrayList $VB$Local_arr = arr5;
					Bitmap bitmap2;
					lock ($VB$Local_arr)
					{
						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)arr5[iA]);
					}
					graphics.DrawImage(bitmap2, 0, 0, iW, iH);
					ArrayList $VB$Local_arr2 = arr6;
					lock ($VB$Local_arr2)
					{
						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)arr6[iB]);
					}
					graphics.DrawImage(bitmap2, 0, 0, iW, iH);
					bitmap2.Dispose();
					string sSavePath = string.Concat(new string[]
					{
						sCgmBaseName,
						cgArr[0],
						"_",
						cgArr[1].Replace("*", string.Empty),
						"_",
						cgArr[2].Replace("*", string.Empty),
						"_",
						Conversions.ToString(iA),
						"_",
						Conversions.ToString(iB)
					});
					PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
					bitmap.Dispose();
					Interlocked.Add(ref PublicModule.iBuild, 1);
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
			});
			PublicModule.files2.Add(text);
			PublicModule.files2.Add(asdfile);
			bmpStream1.Dispose();
			Parallel.ForEach<object>(arrayList.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arrayList.Clear();
			Parallel.ForEach<object>(arrayList2.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arrayList2.Clear();
			Parallel.ForEach<object>(arrayList3.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arrayList3.Clear();
			Parallel.ForEach<object>(arrayList4.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arrayList4.Clear();
			Parallel.ForEach<object>(arr5.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arr5.Clear();
			Parallel.ForEach<object>(arr6.ToArray(), delegate(object a0)
			{
				delegate(MemoryStream ms)
				{
					ms.Dispose();
				}((MemoryStream)a0);
			});
			arr6.Clear();
			return eCancel;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000116A0 File Offset: 0x0000F8A0
		public static bool merge_ks_tjs_txt(ref Form1 myForm1)
		{
			bool result = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			if (0 == string.Compare(PublicModule.sGameExe, "triagain", StringComparison.Ordinal))
			{
				BW2_three.triagain = true;
			}
			else if (0 == string.Compare(PublicModule.sGameExe, "祝祭の歌姫", StringComparison.Ordinal))
			{
				BW2_three.utahime = true;
			}
			ArrayList arrayList = new ArrayList();
			foreach (string sPath in array)
			{
				Interlocked.Add(ref PublicModule.iNow, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (PublicModule.bWaitCancelAsync)
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
					PublicModule.sSpecialExt = "txt";
					ArrayList arrayList2 = new ArrayList();
					PublicModule.RecursionFolder(text, ref arrayList2);
					result = BW2_three.merge_ks_tjs_txt_fgimage(ref myForm1, ref arrayList2, ref arrayList);
				}
			}
			string text2 = Path.Combine(directoryName, "evimage");
			if (Directory.Exists(text2))
			{
				PublicModule.sSpecialExt = "tjs";
				ArrayList arrayList3 = new ArrayList();
				PublicModule.RecursionFolder(text2, ref arrayList3);
				result = BW2_three.merge_ks_tjs_txt_evimage(ref myForm1, ref arrayList3, ref arrayList);
			}
			PublicModule.sGameExe = string.Empty;
			PublicModule.sSpecialExt = string.Empty;
			BW2_three.triagain = false;
			BW2_three.utahime = false;
			return result;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00011844 File Offset: 0x0000FA44
		private static bool merge_ks_tjs_txt_fgimage(ref Form1 myForm1, ref ArrayList baseTxtArr, ref ArrayList baseKsArr)
		{
			BW2_three._Closure$__81 CS$<>8__locals1 = new BW2_three._Closure$__81();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
			checked
			{
				try
				{
					IEnumerator enumerator = baseTxtArr.GetEnumerator();
					while (enumerator.MoveNext())
					{
						BW2_three._Closure$__81._Closure$__82 CS$<>8__locals2 = new BW2_three._Closure$__81._Closure$__82(CS$<>8__locals2);
						string text = Conversions.ToString(enumerator.Current);
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_51 = CS$<>8__locals1;
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								return true;
							}
						}
						CS$<>8__locals1.$VB$Local_base_name = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_base_name, "_info", CompareMethod.Binary) > 0)
						{
							CS$<>8__locals1.$VB$Local_base_info_path = text;
							CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
							if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
							{
								PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
								Parallel.ForEach<object>(baseTxtArr.ToArray(), delegate(object a0)
								{
									delegate(string path1)
									{
										if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
										{
											string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
											if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_base_name.Replace("_info", ""), CompareMethod.Binary) > 0)
											{
												ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
												lock ($VB$Local_sameTxtArr)
												{
													CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
												}
												ArrayList files = PublicModule.files2;
												lock (files)
												{
													PublicModule.files2.Add(path1);
												}
											}
										}
									}(Conversions.ToString(a0));
								});
								if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
								{
									try
									{
										IEnumerator enumerator2 = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											BW2_three._Closure$__81._Closure$__82._Closure$__83 CS$<>8__locals3 = new BW2_three._Closure$__81._Closure$__82._Closure$__83(CS$<>8__locals3);
											string text2 = Conversions.ToString(enumerator2.Current);
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51 = CS$<>8__locals1;
											Interlocked.Add(ref PublicModule.iNow, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												ArrayList arrayList6 = new ArrayList();
												string text3 = string.Empty;
												CS$<>8__locals3.$VB$Local_ifacegroup = 0;
												try
												{
													foreach (object obj in arrayList2)
													{
														string[] array = (string[])obj;
														if (0 == string.Compare(array[0], "facegroup", StringComparison.Ordinal))
														{
															CS$<>8__locals3.$VB$Local_ifacegroup++;
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
																PublicModule.addLog("dress 出现未知数据!");
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
												CS$<>8__locals3.$VB$Local_dirBaseName = Path.GetDirectoryName(text2).Split(new char[]
												{
													Path.DirectorySeparatorChar
												}).Last<string>();
												CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
												CS$<>8__locals3.$VB$Local_fgnameBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_fgnameName = new ArrayList();
												try
												{
													foreach (object obj3 in arrayList5)
													{
														string[] array6 = (string[])obj3;
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
														Graphics graphics = Graphics.FromImage(bitmap);
														graphics.Clear(Color.Transparent);
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (0 != string.Compare(array6[1], "-1", StringComparison.Ordinal))
														{
															string text4 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array6[1]);
															if (File.Exists(text4))
															{
																PublicModule.files2.Add(text4);
																Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4);
																graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(array6[2]), Conversions.ToInteger(array6[3]), bitMapFromFile.Width, bitMapFromFile.Height);
																bitMapFromFile.Dispose();
															}
														}
														graphics.Dispose();
														MemoryStream memoryStream = new MemoryStream();
														bitmap.Save(memoryStream, ImageFormat.Png);
														CS$<>8__locals3.$VB$Local_fgnameBitmap.Add(memoryStream);
														CS$<>8__locals3.$VB$Local_fgnameName.Add(array6[0]);
														bitmap.Dispose();
														CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
												PublicModule.iMaxToBW += CS$<>8__locals3.$VB$Local_fgnameBitmap.Count;
												CS$<>8__locals3.$VB$Local_diffBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_diffName = new ArrayList();
												try
												{
													foreach (object obj4 in arrayList4)
													{
														string[] array7 = (string[])obj4;
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														Bitmap bitmap2 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
														Graphics graphics2 = Graphics.FromImage(bitmap2);
														graphics2.Clear(Color.Transparent);
														Interlocked.Add(ref PublicModule.iNow, 1);
														string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array7[2]);
														if (File.Exists(text5))
														{
															PublicModule.files2.Add(text5);
															Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5);
															graphics2.DrawImage(bitMapFromFile2, Conversions.ToInteger(array7[3]), Conversions.ToInteger(array7[4]), bitMapFromFile2.Width, bitMapFromFile2.Height);
															bitMapFromFile2.Dispose();
														}
														graphics2.Dispose();
														MemoryStream memoryStream2 = new MemoryStream();
														bitmap2.Save(memoryStream2, ImageFormat.Png);
														CS$<>8__locals3.$VB$Local_diffBitmap.Add(memoryStream2);
														text3 = array7[0] + "_" + array7[1];
														CS$<>8__locals3.$VB$Local_diffName.Add(text3);
														bitmap2.Dispose();
														CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
												PublicModule.iMaxToBW += CS$<>8__locals3.$VB$Local_diffBitmap.Count;
												CS$<>8__locals3.$VB$Local_dressBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_dressName = new ArrayList();
												string strB = string.Empty;
												try
												{
													foreach (object obj5 in arrayList3)
													{
														string[] array8 = (string[])obj5;
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														string text6 = array8[0];
														int x = Conversions.ToInteger(array8[3]);
														int y = Conversions.ToInteger(array8[4]);
														if (0 != string.Compare(text6, strB, StringComparison.Ordinal))
														{
															Bitmap bitmap3 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
															Graphics graphics3 = Graphics.FromImage(bitmap3);
															graphics3.Clear(Color.Transparent);
															Interlocked.Add(ref PublicModule.iNow, 1);
															string text7 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[2]);
															if (File.Exists(text7))
															{
																PublicModule.files2.Add(text7);
																using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text7))
																{
																	graphics3.DrawImage(bitMapFromFile3, x, y, bitMapFromFile3.Width, bitMapFromFile3.Height);
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
																		text7 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array9[2]);
																		Interlocked.Add(ref PublicModule.iNow, 1);
																		if (File.Exists(text7))
																		{
																			PublicModule.files2.Add(text7);
																			using (Bitmap bitMapFromFile4 = PublicModule.getBitMapFromFile(text7))
																			{
																				graphics3.DrawImage(bitMapFromFile4, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitMapFromFile4.Width, bitMapFromFile4.Height);
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
															bitmap3.Save(memoryStream3, ImageFormat.Png);
															CS$<>8__locals3.$VB$Local_dressBitmap.Add(memoryStream3);
															CS$<>8__locals3.$VB$Local_dressName.Add(text6);
															bitmap3.Dispose();
															CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
												Parallel.ForEach<object>(baseKsArr.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
												{
													delegate(string ksdata, ParallelLoopState loopstate)
													{
														if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_eCancel = true;
															loopstate.Stop();
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_eCancel = true;
																loopstate.Stop();
															}
														}
														string text8 = ksdata.Substring(1);
														string[] array10 = PublicModule.regSmallSpace.Split(text8);
														string strA = array10.First<string>();
														if (0 == string.Compare(strA, CS$<>8__locals3.$VB$Local_dirBaseName, StringComparison.Ordinal))
														{
															Bitmap bitmap4 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
															Graphics graphics4 = Graphics.FromImage(bitmap4);
															graphics4.Clear(Color.Transparent);
															string text9 = CS$<>8__locals3.$VB$Local_fullBasepath + "_";
															int num = 0;
															int num2 = 1;
															int num3 = array10.Count<string>() - 1;
															for (int i = num2; i <= num3; i++)
															{
																text8 = array10[i];
																if (Strings.InStr(1, text8, "ポーズ", CompareMethod.Binary) <= 0)
																{
																	text9 += text8;
																	num++;
																	if (num > CS$<>8__locals3.$VB$Local_ifacegroup + 1)
																	{
																		break;
																	}
																	text9 += "_";
																}
															}
															text8 = PublicModule.searchBitmapWithExt(text9, "");
															if (File.Exists(text8))
															{
																return;
															}
															text9 = CS$<>8__locals3.$VB$Local_fullBasepath + "_";
															num = 0;
															int num4 = 1;
															int num5 = array10.Count<string>() - 1;
															for (int j = num4; j <= num5; j++)
															{
																text8 = array10[j];
																if (Strings.InStr(1, text8, "ポーズ", CompareMethod.Binary) <= 0)
																{
																	if (0 == num)
																	{
																		int num6 = 0;
																		int num7 = CS$<>8__locals3.$VB$Local_dressName.Count - 1;
																		for (int k = num6; k <= num7; k++)
																		{
																			if (0 == string.Compare(Conversions.ToString(CS$<>8__locals3.$VB$Local_dressName[k]), text8, StringComparison.Ordinal))
																			{
																				ArrayList $VB$Local_dressBitmap = CS$<>8__locals3.$VB$Local_dressBitmap;
																				lock ($VB$Local_dressBitmap)
																				{
																					using (Bitmap bitmap5 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_dressBitmap[k]))
																					{
																						graphics4.DrawImage(bitmap5, 0, 0, bitmap5.Width, bitmap5.Height);
																						break;
																					}
																				}
																			}
																		}
																	}
																	else if (1 == num)
																	{
																		int num8 = 0;
																		int num9 = CS$<>8__locals3.$VB$Local_diffName.Count - 1;
																		for (int l = num8; l <= num9; l++)
																		{
																			string[] array11 = PublicModule.regXIA.Split(text9);
																			string strB2 = array11[array11.Length - 2] + "_" + text8;
																			if (0 == string.Compare(Conversions.ToString(CS$<>8__locals3.$VB$Local_diffName[l]), strB2, StringComparison.Ordinal))
																			{
																				ArrayList $VB$Local_diffBitmap = CS$<>8__locals3.$VB$Local_diffBitmap;
																				lock ($VB$Local_diffBitmap)
																				{
																					using (Bitmap bitmap6 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_diffBitmap[l]))
																					{
																						graphics4.DrawImage(bitmap6, 0, 0, bitmap6.Width, bitmap6.Height);
																						break;
																					}
																				}
																			}
																		}
																	}
																	else
																	{
																		int num10 = 0;
																		int num11 = CS$<>8__locals3.$VB$Local_fgnameName.Count - 1;
																		for (int m = num10; m <= num11; m++)
																		{
																			if (0 == string.Compare(Conversions.ToString(CS$<>8__locals3.$VB$Local_fgnameName[m]), text8, StringComparison.Ordinal))
																			{
																				ArrayList $VB$Local_fgnameBitmap = CS$<>8__locals3.$VB$Local_fgnameBitmap;
																				lock ($VB$Local_fgnameBitmap)
																				{
																					using (Bitmap bitmap7 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_fgnameBitmap[m]))
																					{
																						graphics4.DrawImage(bitmap7, 0, 0, bitmap7.Width, bitmap7.Height);
																						break;
																					}
																				}
																			}
																		}
																	}
																	text9 += text8;
																	num++;
																	if (num > CS$<>8__locals3.$VB$Local_ifacegroup + 1)
																	{
																		break;
																	}
																	text9 += "_";
																}
															}
															text8 = PublicModule.saveBitmapFile(text9, ref bitmap4, false);
															if (!string.IsNullOrEmpty(text8))
															{
																Interlocked.Add(ref PublicModule.iBuild, 1);
															}
															bitmap4.Dispose();
															CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_51.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
															Thread.Sleep(PublicModule.iThreadWaitTime);
														}
													}(Conversions.ToString(a0), a1);
												});
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_fgnameBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_fgnameBitmap.Clear();
												CS$<>8__locals3.$VB$Local_fgnameName.Clear();
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_diffBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_diffBitmap.Clear();
												CS$<>8__locals3.$VB$Local_diffName.Clear();
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_dressBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_dressBitmap.Clear();
												CS$<>8__locals3.$VB$Local_dressName.Clear();
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
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00012528 File Offset: 0x00010728
		private static bool merge_ks_tjs_txt_evimage(ref Form1 myForm1, ref ArrayList baseTjsArr, ref ArrayList baseKsArr)
		{
			bool result = false;
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			checked
			{
				try
				{
					foreach (object value in baseTjsArr)
					{
						string text = Conversions.ToString(value);
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (backgroundWorker.CancellationPending)
						{
							return true;
						}
						while (PublicModule.bWaitCancelAsync)
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
							string text2 = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, baseImage), "");
							if (File.Exists(text2))
							{
								PublicModule.files2.Add(text2);
								try
								{
									foreach (object value2 in baseKsArr)
									{
										string text3 = Conversions.ToString(value2);
										if (backgroundWorker.CancellationPending)
										{
											return true;
										}
										while (PublicModule.bWaitCancelAsync)
										{
											Thread.Sleep(500);
											if (backgroundWorker.CancellationPending)
											{
												return true;
											}
										}
										string text4 = text3.Substring(1);
										string[] array = PublicModule.regSmallSpace.Split(text4);
										string text5 = array.First<string>();
										if (BW2_three.utahime && Operators.CompareString(Conversions.ToString(baseImage.Last<char>()), "大", false) == 0)
										{
											text5 += "大";
										}
										string text6 = Path.Combine(directoryName, baseImage + "_");
										if (0 == string.Compare(text5, baseImage, StringComparison.Ordinal))
										{
											Interlocked.Add(ref PublicModule.iNow, 1);
											Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text2);
											Graphics graphics = Graphics.FromImage(bitMapFromFile);
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
											text4 = PublicModule.searchBitmapWithExt(text6, "");
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
																text4 = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, string.Concat(new string[]
																{
																	baseImage,
																	"_",
																	kirikiri2TjsData3.diffs1,
																	"_",
																	kirikiri2TjsData3.diffs2
																})), "");
																if (File.Exists(text4))
																{
																	using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text4))
																	{
																		graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(kirikiri2TjsData3.x), Conversions.ToInteger(kirikiri2TjsData3.y), Conversions.ToInteger(kirikiri2TjsData3.width), Conversions.ToInteger(kirikiri2TjsData3.height));
																		PublicModule.files2.Add(text4);
																		Interlocked.Add(ref PublicModule.iNow, 1);
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
												text4 = PublicModule.saveBitmapFile(text6, ref bitMapFromFile, false);
												if (!string.IsNullOrEmpty(text4))
												{
													Interlocked.Add(ref PublicModule.iBuild, 1);
												}
												bitMapFromFile.Dispose();
												backgroundWorker.ReportProgress(PublicModule.iNow);
												Thread.Sleep(PublicModule.iThreadWaitTime);
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
								PublicModule.files2.Add(text);
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

		// Token: 0x060000E1 RID: 225 RVA: 0x00012A00 File Offset: 0x00010C00
		public static bool merge_ks_cg_mode_first(ref Form1 myForm1)
		{
			bool result = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				string strA = string.Empty;
				string folder_path = string.Empty;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
				ArrayList arrayList = new ArrayList();
				string text = PublicModule.sSpecialExt;
				foreach (string text2 in array)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (backgroundWorker.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
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
						folder_path = Path.GetDirectoryName(text2);
						arrayList.Clear();
						PublicModule.sSpecialExt = "*";
						PublicModule.RecursionFolder(folder_path, ref arrayList);
						if (1 > arrayList.Count)
						{
							return result;
						}
						backgroundWorker.ReportProgress(PublicModule.iNow);
						PublicModule.files2.Add(text2);
						using (FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
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
									while (PublicModule.bWaitCancelAsync)
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
										string[] array3 = PublicModule.regSmallSpace.Split(text3);
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
												text = PublicModule.regEqual.Split(text6).Last<string>();
												array4[0] = text;
											}
											else if (Strings.InStr(1, text6, "left=", CompareMethod.Binary) > 0)
											{
												text = PublicModule.regEqual.Split(text6).Last<string>();
												array4[1] = text;
											}
											else if (Strings.InStr(1, text6, "storage=", CompareMethod.Binary) > 0)
											{
												text4 = PublicModule.regEqual.Split(text6).Last<string>().Replace("\"", string.Empty);
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
												text = PublicModule.regEqual.Split(text6).Last<string>();
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
												text = PublicModule.regEqual.Split(text6).Last<string>();
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
												string[] array3 = PublicModule.regSmallSpace.Split(text3);
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
														text4 = PublicModule.regEqual.Split(text7).Last<string>().Replace("\"", string.Empty);
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
												string text10 = PublicModule.sFindNameInArrayList(ref arrayList, text9);
												if (!string.IsNullOrWhiteSpace(text10))
												{
													Interlocked.Add(ref PublicModule.iNow, 1);
													Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text10);
													width = bitMapFromFile.Width;
													height = bitMapFromFile.Height;
													Graphics graphics = Graphics.FromImage(bitMapFromFile);
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
															text = PublicModule.sFindNameInArrayList(ref arrayList, text11);
															if (!string.IsNullOrWhiteSpace(text))
															{
																PublicModule.files2.Add(text);
																Interlocked.Add(ref PublicModule.iNow, 1);
																int x = Conversions.ToInteger(array9[0]);
																int y = Conversions.ToInteger(array9[1]);
																using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text))
																{
																	if (flag3)
																	{
																		graphics.DrawImage(bitMapFromFile2, 0, 0, width, height);
																	}
																	else
																	{
																		graphics.DrawImage(bitMapFromFile2, x, y, width, height);
																	}
																}
																text5 = text5 + text11 + "_";
															}
															backgroundWorker.ReportProgress(PublicModule.iNow);
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
														PublicModule.files2.Add(text10);
														string value = Path.Combine(Path.GetDirectoryName(text10), text9 + "_" + text5.Substring(0, text5.Length - 1));
														arrayList6.Add(value);
														bitMapFromFile.Save(memoryStream, ImageFormat.Png);
														arrayList5.Add(memoryStream);
														arrayList7.Add(array8[4]);
													}
													bitMapFromFile.Dispose();
												}
												backgroundWorker.ReportProgress(PublicModule.iNow);
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
														Bitmap bitmap = (Bitmap)Image.FromStream(stream);
														if (flag5)
														{
															Graphics graphics2 = Graphics.FromImage(bitmap);
															string text12 = array10[2];
															text = PublicModule.sFindNameInArrayList(ref arrayList, text12);
															if (!string.IsNullOrWhiteSpace(text))
															{
																PublicModule.files2.Add(text);
																Interlocked.Add(ref PublicModule.iNow, 1);
																int x = Conversions.ToInteger(array10[0]);
																int y = Conversions.ToInteger(array10[1]);
																using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text))
																{
																	if (flag3)
																	{
																		graphics2.DrawImage(bitMapFromFile3, 0, 0, width, height);
																	}
																	else
																	{
																		graphics2.DrawImage(bitMapFromFile3, x, y, width, height);
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
														text = PublicModule.saveBitmapFile(text5, ref bitmap, false);
														if (!string.IsNullOrWhiteSpace(text))
														{
															Interlocked.Add(ref PublicModule.iBuild, 1);
														}
														bitmap.Dispose();
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
											string sSavePath = Conversions.ToString(arrayList6[n]);
											Bitmap bitmap2 = (Bitmap)Image.FromStream(stream);
											text = PublicModule.saveBitmapFile(sSavePath, ref bitmap2, false);
											if (!string.IsNullOrWhiteSpace(text))
											{
												Interlocked.Add(ref PublicModule.iBuild, 1);
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
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return result;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000135E0 File Offset: 0x000117E0
		public static bool merge_ks_width_gamename(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				if (0 == string.Compare(PublicModule.sGameExe, "逆王道", StringComparison.Ordinal))
				{
					BW2_three.gyakuoudou = true;
				}
				if (!BW2_three.gyakuoudou)
				{
					return eCancel;
				}
				string text = string.Empty;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				ArrayList arrayList = new ArrayList(100);
				foreach (string text2 in array)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker2.CancellationPending)
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
					return eCancel;
				}
				if (Directory.Exists(text))
				{
					PublicModule.sSpecialExt = string.Empty;
					ArrayList pngimageArr = new ArrayList(100);
					PublicModule.RecursionFolder(text, ref pngimageArr);
					if (0 >= pngimageArr.Count)
					{
						return eCancel;
					}
					Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
					{
						delegate(string sfinalname, ParallelLoopState loopstate)
						{
							Interlocked.Add(ref PublicModule.iNow, 1);
							if (BackgroundWorker2.CancellationPending)
							{
								eCancel = true;
								loopstate.Stop();
							}
							while (PublicModule.bWaitCancelAsync)
							{
								Thread.Sleep(500);
								if (BackgroundWorker2.CancellationPending)
								{
									eCancel = true;
									loopstate.Stop();
								}
							}
							if (string.IsNullOrEmpty(PublicModule.searchBitmapWithExt(sfinalname, "")))
							{
								string[] array3 = PublicModule.regXIA.Split(sfinalname);
								string str = array3[0] + "_" + array3[1] + "_";
								string text3 = array3.Last<string>();
								string path = "";
								Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
								char[] array4 = Conversions.ToCharArrayRankOne("#######");
								int num = 0;
								int num2 = text3.Length - 1;
								for (int j = num; j <= num2; j++)
								{
									if (BackgroundWorker2.CancellationPending)
									{
										eCancel = true;
										loopstate.Stop();
										return;
									}
									while (PublicModule.bWaitCancelAsync)
									{
										Thread.Sleep(500);
										if (BackgroundWorker2.CancellationPending)
										{
											eCancel = true;
											loopstate.Stop();
											return;
										}
									}
									if (j < 3)
									{
										array4[j] = text3[j];
									}
									else if (j == 3)
									{
										string strFind = str + new string(array4);
										ArrayList $VB$Local_pngimageArr = pngimageArr;
										string text4;
										lock ($VB$Local_pngimageArr)
										{
											text4 = PublicModule.sFindNameInArrayList(ref pngimageArr, strFind);
										}
										if (File.Exists(text4))
										{
											bitmap.Dispose();
											path = Path.GetDirectoryName(text4);
											Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4);
											bitmap = new Bitmap(bitMapFromFile.Width, bitMapFromFile.Height, PublicModule.checkPixelFormat(bitMapFromFile.PixelFormat));
											Graphics graphics = Graphics.FromImage(bitmap);
											graphics.DrawImage(bitMapFromFile, 0, 0, bitMapFromFile.Width, bitMapFromFile.Height);
											graphics.Dispose();
											bitMapFromFile.Dispose();
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(text4);
											}
										}
										array4[0] = '#';
										array4[1] = '#';
										array4[2] = 'Y';
										array4[j] = text3[j];
										strFind = str + new string(array4);
										ArrayList $VB$Local_pngimageArr2 = pngimageArr;
										lock ($VB$Local_pngimageArr2)
										{
											text4 = PublicModule.sFindNameInArrayList(ref pngimageArr, strFind);
										}
										if (File.Exists(text4))
										{
											Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text4);
											Graphics graphics2 = Graphics.FromImage(bitmap);
											graphics2.DrawImage(bitMapFromFile2, 0, 0, bitMapFromFile2.Width, bitMapFromFile2.Height);
											graphics2.Dispose();
											bitMapFromFile2.Dispose();
											ArrayList files2 = PublicModule.files2;
											lock (files2)
											{
												PublicModule.files2.Add(text4);
											}
										}
									}
									else if (j > 3)
									{
										array4[j - 1] = '#';
										array4[j] = text3[j];
										string strFind = str + new string(array4);
										ArrayList $VB$Local_pngimageArr3 = pngimageArr;
										string text4;
										lock ($VB$Local_pngimageArr3)
										{
											text4 = PublicModule.sFindNameInArrayList(ref pngimageArr, strFind);
										}
										if (File.Exists(text4))
										{
											Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text4);
											Graphics graphics3 = Graphics.FromImage(bitmap);
											graphics3.DrawImage(bitMapFromFile3, 0, 0, bitMapFromFile3.Width, bitMapFromFile3.Height);
											graphics3.Dispose();
											bitMapFromFile3.Dispose();
											ArrayList files3 = PublicModule.files2;
											lock (files3)
											{
												PublicModule.files2.Add(text4);
											}
										}
									}
								}
								PublicModule.saveBitmapFile(Path.Combine(path, sfinalname), ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref PublicModule.iBuild, 1);
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							}
						}(Conversions.ToString(a0), a1);
					});
				}
				BW2_three.gyakuoudou = false;
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000137B4 File Offset: 0x000119B4
		public static bool pos_anm_asd_1(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				BackgroundWorker2.ReportProgress(0);
				string[] array2 = array;
				string base_info_path;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__86._Closure$__87 CS$<>8__locals2 = new BW2_three._Closure$__86._Closure$__87(CS$<>8__locals2);
					string text = array2[i];
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					string text2 = Path.ChangeExtension(text, "pos");
					CS$<>8__locals2.$VB$Local_bDoSomeThing = false;
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					base_info_path = Path.GetDirectoryName(text);
					string text3 = string.Empty;
					if (File.Exists(text2))
					{
						PublicModule.files2.Add(text2);
						Interlocked.Add(ref PublicModule.iNow, 1);
						string[] array3 = kirikiri2_fun.readAnmToArr(text2);
						string text4 = PublicModule.searchBitmapWithExt(Path.Combine(base_info_path, array3[0]), "");
						if (File.Exists(text4))
						{
							Image bitMapFromFile = PublicModule.getBitMapFromFile(text);
							Image image = PublicModule.getBitMapFromFile(text4);
							Graphics graphics = Graphics.FromImage(image);
							graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(array3[2]), Conversions.ToInteger(array3[1]), bitMapFromFile.Width, bitMapFromFile.Height);
							graphics.Dispose();
							bitMapFromFile.Dispose();
							string text5 = text2;
							string sSavePath = text5;
							Bitmap bitmap = (Bitmap)image;
							string text6 = PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
							image = bitmap;
							text3 = text6;
							CS$<>8__locals2.$VB$Local_bDoSomeThing = true;
							Interlocked.Add(ref PublicModule.iBuild, 1);
							image.Dispose();
							BackgroundWorker2.ReportProgress(PublicModule.iNow);
						}
					}
					string text7 = Path.ChangeExtension(text, "anm");
					if (File.Exists(text7))
					{
						string[] anmArr = kirikiri2_fun.readAnmToArr(text7);
						string asdfile = Path.Combine(base_info_path, fileNameWithoutExtension + "_anm.asd");
						if (File.Exists(asdfile))
						{
							PublicModule.files2.Add(text7);
							Interlocked.Add(ref PublicModule.iNow, 1);
							PublicModule.files2.Add(asdfile);
							Interlocked.Add(ref PublicModule.iNow, 1);
							ArrayList pAsd = kirikiri2_fun.readAsdToArr(asdfile);
							string text8 = PublicModule.searchBitmapWithExt(Path.Combine(Path.GetDirectoryName(asdfile), Path.GetFileNameWithoutExtension(asdfile)), "");
							PublicModule.files2.Add(text8);
							Interlocked.Add(ref PublicModule.iNow, 1);
							Image bitMapFromFile2;
							if (CS$<>8__locals2.$VB$Local_bDoSomeThing)
							{
								if (File.Exists(text3))
								{
									PublicModule.files2.Add(text3);
									bitMapFromFile2 = PublicModule.getBitMapFromFile(text3);
								}
								else
								{
									bitMapFromFile2 = PublicModule.getBitMapFromFile(text);
								}
							}
							else
							{
								bitMapFromFile2 = PublicModule.getBitMapFromFile(text);
							}
							MemoryStream ms1 = new MemoryStream();
							MemoryStream ms2 = new MemoryStream();
							bitMapFromFile2.Save(ms1, ImageFormat.Png);
							bitMapFromFile2.Dispose();
							bitMapFromFile2 = PublicModule.getBitMapFromFile(text8);
							bitMapFromFile2.Save(ms2, ImageFormat.Png);
							bitMapFromFile2.Dispose();
							Parallel.For(0, pAsd.Count, parallelOptions, delegate(int iI, ParallelLoopState loopstate)
							{
								Interlocked.Add(ref PublicModule.iNow, 1);
								if (BackgroundWorker2.CancellationPending)
								{
									eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (BackgroundWorker2.CancellationPending)
									{
										eCancel = true;
										loopstate.Stop();
									}
								}
								MemoryStream $VB$Local_ms = ms1;
								Bitmap bitmap2;
								lock ($VB$Local_ms)
								{
									bitmap2 = (Bitmap)Image.FromStream(ms1);
								}
								MemoryStream $VB$Local_ms2 = ms2;
								Bitmap bitmap3;
								lock ($VB$Local_ms2)
								{
									bitmap3 = (Bitmap)Image.FromStream(ms2);
								}
								Graphics graphics2 = Graphics.FromImage(bitmap2);
								int width = Conversions.ToInteger(anmArr[3]);
								int height = Conversions.ToInteger(anmArr[4]);
								Rectangle rect = new Rectangle(Conversions.ToInteger(pAsd[iI]), 0, width, height);
								BitmapData bitmapData = bitmap3.LockBits(rect, ImageLockMode.ReadOnly, bitmap3.PixelFormat);
								Bitmap bitmap4 = new Bitmap(width, height, bitmapData.Stride, bitmap3.PixelFormat, bitmapData.Scan0);
								bitmap3.UnlockBits(bitmapData);
								graphics2.DrawImage(bitmap4, Conversions.ToInteger(anmArr[1]), Conversions.ToInteger(anmArr[2]), bitmap4.Width, bitmap4.Height);
								graphics2.Dispose();
								bitmap4.Dispose();
								bitmap3.Dispose();
								string sSavePath2 = Path.Combine(base_info_path, Path.GetFileNameWithoutExtension(asdfile) + "_" + Conversions.ToString(iI));
								PublicModule.saveBitmapFile(sSavePath2, ref bitmap2, true);
								CS$<>8__locals2.$VB$Local_bDoSomeThing = true;
								Interlocked.Add(ref PublicModule.iBuild, 1);
								bitmap2.Dispose();
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
							});
							ms2.Dispose();
							ms1.Dispose();
						}
					}
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
					if (CS$<>8__locals2.$VB$Local_bDoSomeThing)
					{
						PublicModule.files2.Add(text);
					}
				}
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00013BCC File Offset: 0x00011DCC
		public static bool pos_anm_asd_2(ref Form1 myForm1)
		{
			BW2_three._Closure$__90 CS$<>8__locals1 = new BW2_three._Closure$__90();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			if (0 == string.Compare(PublicModule.sGameExe, "rebirth_colony", StringComparison.OrdinalIgnoreCase))
			{
			}
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				int i = 0;
				while (i < array2.Length)
				{
					BW2_three._Closure$__90._Closure$__91 CS$<>8__locals2 = new BW2_three._Closure$__90._Closure$__91(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					CS$<>8__locals1.$VB$Local_base_path = Path.GetDirectoryName(text);
					string text2;
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
						{
							text2 = streamReader.ReadLine().Trim();
							if (!Versioned.IsNumeric(text2))
							{
								goto IL_496;
							}
							CS$<>8__locals2.$VB$Local_iX = Conversions.ToInteger(text2);
							text2 = streamReader.ReadLine().Trim();
							if (!Versioned.IsNumeric(text2))
							{
								goto IL_496;
							}
							CS$<>8__locals2.$VB$Local_iY = Conversions.ToInteger(text2);
						}
					}
					goto IL_178;
					IL_496:
					i++;
					continue;
					IL_178:
					CS$<>8__locals2.$VB$Local_samePngBase = Path.Combine(CS$<>8__locals1.$VB$Local_base_path, fileNameWithoutExtension + "_");
					ArrayList arrayList = new ArrayList();
					CS$<>8__locals2.$VB$Local_samePngArr = new ArrayList();
					CS$<>8__locals2.$VB$Local_bodyArr = new ArrayList();
					CS$<>8__locals2.$VB$Local_browArr = new ArrayList();
					CS$<>8__locals2.$VB$Local_cheekArr = new ArrayList();
					CS$<>8__locals2.$VB$Local_eyeArr = new ArrayList();
					CS$<>8__locals2.$VB$Local_mouthArr = new ArrayList();
					text2 = PublicModule.sSpecialExt;
					PublicModule.sSpecialExt = string.Empty;
					PublicModule.RecursionFolder(CS$<>8__locals1.$VB$Local_base_path, ref arrayList);
					PublicModule.sSpecialExt = text2;
					Parallel.ForEach<object>(arrayList.ToArray(), delegate(object a0)
					{
						delegate(string thispngfile)
						{
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase + "body_", CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_bodyArr = CS$<>8__locals2.$VB$Local_bodyArr;
								lock ($VB$Local_bodyArr)
								{
									CS$<>8__locals2.$VB$Local_bodyArr.Add(thispngfile);
								}
								ArrayList files = PublicModule.files2;
								lock (files)
								{
									PublicModule.files2.Add(thispngfile);
									return;
								}
							}
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase + "brow_", CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_browArr = CS$<>8__locals2.$VB$Local_browArr;
								lock ($VB$Local_browArr)
								{
									CS$<>8__locals2.$VB$Local_browArr.Add(thispngfile);
								}
								ArrayList files2 = PublicModule.files2;
								lock (files2)
								{
									PublicModule.files2.Add(thispngfile);
									return;
								}
							}
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase + "cheek_", CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_cheekArr = CS$<>8__locals2.$VB$Local_cheekArr;
								lock ($VB$Local_cheekArr)
								{
									CS$<>8__locals2.$VB$Local_cheekArr.Add(thispngfile);
								}
								ArrayList files3 = PublicModule.files2;
								lock (files3)
								{
									PublicModule.files2.Add(thispngfile);
									return;
								}
							}
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase + "eye_", CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_eyeArr = CS$<>8__locals2.$VB$Local_eyeArr;
								lock ($VB$Local_eyeArr)
								{
									CS$<>8__locals2.$VB$Local_eyeArr.Add(thispngfile);
								}
								ArrayList files4 = PublicModule.files2;
								lock (files4)
								{
									PublicModule.files2.Add(thispngfile);
									return;
								}
							}
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase + "mouth_", CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_mouthArr = CS$<>8__locals2.$VB$Local_mouthArr;
								lock ($VB$Local_mouthArr)
								{
									CS$<>8__locals2.$VB$Local_mouthArr.Add(thispngfile);
								}
								ArrayList files5 = PublicModule.files2;
								lock (files5)
								{
									PublicModule.files2.Add(thispngfile);
									return;
								}
							}
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase, CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_samePngArr = CS$<>8__locals2.$VB$Local_samePngArr;
								lock ($VB$Local_samePngArr)
								{
									CS$<>8__locals2.$VB$Local_samePngArr.Add(thispngfile);
								}
							}
						}(Conversions.ToString(a0));
					});
					if (0 >= CS$<>8__locals2.$VB$Local_bodyArr.Count)
					{
						goto IL_496;
					}
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(Conversions.ToString(CS$<>8__locals2.$VB$Local_bodyArr[0])))
					{
						CS$<>8__locals2.$VB$Local_bodyW = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_bodyH = bitMapFromFile.Height;
						CS$<>8__locals2.$VB$Local_pf = bitMapFromFile.PixelFormat;
					}
					if (0 >= CS$<>8__locals2.$VB$Local_bodyW & 0 >= CS$<>8__locals2.$VB$Local_bodyH)
					{
						goto IL_496;
					}
					CS$<>8__locals2.$VB$Local_browAndeye = new ArrayList();
					CS$<>8__locals2.$VB$Local_browAndeyeName = new ArrayList();
					Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_eyeArr.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
					{
						delegate(string eyePath, ParallelLoopState loopstate)
						{
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
							while (PublicModule.bWaitCancelAsync)
							{
								Thread.Sleep(500);
								if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
							}
							string text3 = Path.ChangeExtension(eyePath, "anm");
							string text4 = Path.ChangeExtension(eyePath, "asd");
							if (File.Exists(text3) & File.Exists(text4))
							{
								Interlocked.Add(ref PublicModule.iNow, 2);
								ArrayList files = PublicModule.files2;
								lock (files)
								{
									PublicModule.files2.Add(text3);
									PublicModule.files2.Add(text4);
								}
								string[] array3 = kirikiri2_fun.readAnmToArr(text3);
								int x = Conversions.ToInteger(array3[1]);
								int y = Conversions.ToInteger(array3[2]);
								int num3 = Conversions.ToInteger(array3[3]);
								int height = Conversions.ToInteger(array3[4]);
								ArrayList arrayList2 = kirikiri2_fun.readAsdToArr(text4);
								string text5 = Path.GetFileNameWithoutExtension(eyePath);
								string[] source = PublicModule.regXIA.Split(text5);
								string str = source.Last<string>();
								text5 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_brow_"));
								string sPath = text5 + Path.GetExtension(eyePath);
								text5 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_sp1_"));
								string text6 = text5 + Path.GetExtension(eyePath);
								text5 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_sp2_"));
								string text7 = text5 + Path.GetExtension(eyePath);
								text5 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_tear_"));
								string text8 = text5 + Path.GetExtension(eyePath);
								bool flag2 = false;
								bool flag3 = false;
								bool flag4 = false;
								MemoryStream memoryStream = new MemoryStream();
								MemoryStream memoryStream2 = new MemoryStream();
								MemoryStream memoryStream3 = new MemoryStream();
								MemoryStream memoryStream4 = new MemoryStream();
								MemoryStream memoryStream5 = new MemoryStream();
								Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(eyePath);
								bitMapFromFile2.Save(memoryStream, ImageFormat.Png);
								bitMapFromFile2.Dispose();
								bitMapFromFile2 = PublicModule.getBitMapFromFile(sPath);
								bitMapFromFile2.Save(memoryStream2, ImageFormat.Png);
								bitMapFromFile2.Dispose();
								if (File.Exists(text6))
								{
									bitMapFromFile2 = PublicModule.getBitMapFromFile(text6);
									bitMapFromFile2.Save(memoryStream3, ImageFormat.Png);
									bitMapFromFile2.Dispose();
									flag2 = true;
									ArrayList files2 = PublicModule.files2;
									lock (files2)
									{
										PublicModule.files2.Add(text6);
									}
								}
								if (File.Exists(text7))
								{
									bitMapFromFile2 = PublicModule.getBitMapFromFile(text7);
									bitMapFromFile2.Save(memoryStream5, ImageFormat.Png);
									bitMapFromFile2.Dispose();
									flag4 = true;
									ArrayList files3 = PublicModule.files2;
									lock (files3)
									{
										PublicModule.files2.Add(text7);
									}
								}
								if (File.Exists(text8))
								{
									bitMapFromFile2 = PublicModule.getBitMapFromFile(text8);
									bitMapFromFile2.Save(memoryStream4, ImageFormat.Png);
									bitMapFromFile2.Dispose();
									flag3 = true;
									ArrayList files4 = PublicModule.files2;
									lock (files4)
									{
										PublicModule.files2.Add(text8);
									}
								}
								int num4 = arrayList2.Count - 1;
								int num5 = 0;
								int num6 = num4;
								for (int k = num5; k <= num6; k++)
								{
									Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_bodyW, CS$<>8__locals2.$VB$Local_bodyH, CS$<>8__locals2.$VB$Local_pf);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
									int num7 = num3 * k;
									if (num7 >= bitmap2.Width)
									{
										num7 = bitmap2.Width - num7;
										if (0 > num7)
										{
											num7 = 0;
										}
									}
									Rectangle rect = new Rectangle(num7, 0, num3, height);
									BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
									Bitmap bitmap3 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
									bitmap2.UnlockBits(bitmapData);
									graphics.DrawImage(bitmap3, x, y, num3, height);
									bitmap3.Dispose();
									bitmap2.Dispose();
									Bitmap bitmap4 = (Bitmap)Image.FromStream(memoryStream2);
									num7 = num3 * k;
									if (num7 >= bitmap4.Width)
									{
										num7 = bitmap4.Width - num7;
										if (0 > num7)
										{
											num7 = 0;
										}
									}
									rect = new Rectangle(num7, 0, num3, height);
									bitmapData = bitmap4.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
									bitmap3 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
									bitmap4.UnlockBits(bitmapData);
									graphics.DrawImage(bitmap3, x, y, num3, height);
									bitmap3.Dispose();
									bitmap4.Dispose();
									if (flag2)
									{
										Bitmap bitmap5 = (Bitmap)Image.FromStream(memoryStream3);
										if (num3 == bitmap5.Width)
										{
											graphics.DrawImage(bitmap5, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, num3, height);
										}
										else
										{
											rect = new Rectangle(num3 * k, 0, num3, height);
											bitmapData = bitmap5.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
											bitmap3 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
											bitmap5.UnlockBits(bitmapData);
											graphics.DrawImage(bitmap3, x, y, num3, height);
											bitmap3.Dispose();
										}
										bitmap5.Dispose();
									}
									if (flag3)
									{
										Bitmap bitmap6 = (Bitmap)Image.FromStream(memoryStream4);
										if (num3 == bitmap6.Width)
										{
											graphics.DrawImage(bitmap6, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, num3, height);
										}
										else
										{
											rect = new Rectangle(num3 * k, 0, num3, height);
											bitmapData = bitmap6.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
											bitmap3 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
											bitmap6.UnlockBits(bitmapData);
											graphics.DrawImage(bitmap3, x, y, num3, height);
											bitmap3.Dispose();
										}
										bitmap6.Dispose();
									}
									if (flag4)
									{
										Bitmap bitmap7 = (Bitmap)Image.FromStream(memoryStream5);
										if (num3 == bitmap7.Width)
										{
											graphics.DrawImage(bitmap7, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, num3, height);
										}
										else
										{
											rect = new Rectangle(num3 * k, 0, num3, height);
											bitmapData = bitmap7.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
											bitmap3 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
											bitmap7.UnlockBits(bitmapData);
											graphics.DrawImage(bitmap3, x, y, num3, height);
											bitmap3.Dispose();
										}
										bitmap7.Dispose();
									}
									MemoryStream memoryStream6 = new MemoryStream();
									bitmap.Save(memoryStream6, ImageFormat.Png);
									ArrayList $VB$Local_browAndeye = CS$<>8__locals2.$VB$Local_browAndeye;
									lock ($VB$Local_browAndeye)
									{
										CS$<>8__locals2.$VB$Local_browAndeye.Add(memoryStream6);
										CS$<>8__locals2.$VB$Local_browAndeyeName.Add(str + "_" + k.ToString("D3"));
									}
									bitmap.Dispose();
								}
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
								memoryStream.Dispose();
								memoryStream2.Dispose();
								memoryStream3.Dispose();
								memoryStream4.Dispose();
								memoryStream5.Dispose();
							}
							else
							{
								Interlocked.Add(ref PublicModule.iNow, 2);
								string text9 = Path.GetFileNameWithoutExtension(eyePath);
								string[] source2 = PublicModule.regXIA.Split(text9);
								string text10 = source2.Last<string>();
								Bitmap bitmap8 = new Bitmap(CS$<>8__locals2.$VB$Local_bodyW, CS$<>8__locals2.$VB$Local_bodyH, CS$<>8__locals2.$VB$Local_pf);
								Graphics graphics2 = Graphics.FromImage(bitmap8);
								graphics2.Clear(Color.Transparent);
								Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(eyePath);
								graphics2.DrawImage(bitMapFromFile3, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitMapFromFile3.Width, bitMapFromFile3.Height);
								bitMapFromFile3.Dispose();
								try
								{
									foreach (object value in CS$<>8__locals2.$VB$Local_browArr)
									{
										string text11 = Conversions.ToString(value);
										text9 = Path.GetFileNameWithoutExtension(text11);
										source2 = PublicModule.regXIA.Split(text9);
										string strA = source2.Last<string>();
										if (0 == string.Compare(strA, text10, StringComparison.Ordinal))
										{
											bitMapFromFile3 = PublicModule.getBitMapFromFile(text11);
											graphics2.DrawImage(bitMapFromFile3, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitMapFromFile3.Width, bitMapFromFile3.Height);
											bitMapFromFile3.Dispose();
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
								text9 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_sp1_"));
								string text12 = text9 + Path.GetExtension(eyePath);
								text9 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_tear_"));
								string text13 = text9 + Path.GetExtension(eyePath);
								text9 = Path.Combine(Path.GetDirectoryName(eyePath), Path.GetFileNameWithoutExtension(eyePath).Replace("_eye_", "_sp2_"));
								string text14 = text9 + Path.GetExtension(eyePath);
								if (File.Exists(text12))
								{
									bitMapFromFile3 = PublicModule.getBitMapFromFile(text12);
									graphics2.DrawImage(bitMapFromFile3, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitMapFromFile3.Width, bitMapFromFile3.Height);
									bitMapFromFile3.Dispose();
									ArrayList files5 = PublicModule.files2;
									lock (files5)
									{
										PublicModule.files2.Add(text12);
									}
								}
								if (File.Exists(text13))
								{
									bitMapFromFile3 = PublicModule.getBitMapFromFile(text13);
									graphics2.DrawImage(bitMapFromFile3, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitMapFromFile3.Width, bitMapFromFile3.Height);
									bitMapFromFile3.Dispose();
									ArrayList files6 = PublicModule.files2;
									lock (files6)
									{
										PublicModule.files2.Add(text13);
									}
								}
								if (File.Exists(text14))
								{
									bitMapFromFile3 = PublicModule.getBitMapFromFile(text14);
									graphics2.DrawImage(bitMapFromFile3, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitMapFromFile3.Width, bitMapFromFile3.Height);
									bitMapFromFile3.Dispose();
									ArrayList files7 = PublicModule.files2;
									lock (files7)
									{
										PublicModule.files2.Add(text14);
									}
								}
								MemoryStream memoryStream7 = new MemoryStream();
								bitmap8.Save(memoryStream7, ImageFormat.Png);
								ArrayList $VB$Local_browAndeye2 = CS$<>8__locals2.$VB$Local_browAndeye;
								lock ($VB$Local_browAndeye2)
								{
									CS$<>8__locals2.$VB$Local_browAndeye.Add(memoryStream7);
									CS$<>8__locals2.$VB$Local_browAndeyeName.Add(text10);
								}
								bitmap8.Dispose();
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
							}
						}(Conversions.ToString(a0), a1);
					});
					CS$<>8__locals2.$VB$Local_fullface = new ArrayList();
					CS$<>8__locals2.$VB$Local_fullfaceName = new ArrayList();
					Parallel.For(0, CS$<>8__locals2.$VB$Local_browAndeye.Count, parallelOptions, delegate(int IBE, ParallelLoopState loopstate)
					{
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_bodyW, CS$<>8__locals2.$VB$Local_bodyH, CS$<>8__locals2.$VB$Local_pf);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						string[] source = PublicModule.regXIA.Split(Conversions.ToString(CS$<>8__locals2.$VB$Local_browAndeyeName[IBE]));
						string strB = source.First<string>();
						Bitmap bitmap2;
						try
						{
							foreach (object value in CS$<>8__locals2.$VB$Local_cheekArr)
							{
								string text3 = Conversions.ToString(value);
								string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(text3);
								source = PublicModule.regXIA.Split(fileNameWithoutExtension2);
								string strA = source.Last<string>();
								if (0 == string.Compare(strA, strB, StringComparison.Ordinal))
								{
									bitmap2 = PublicModule.getBitMapFromFile(text3);
									graphics.DrawImage(bitmap2, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitmap2.Width, bitmap2.Height);
									bitmap2.Dispose();
									Interlocked.Add(ref PublicModule.iNow, 1);
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
							foreach (object value2 in CS$<>8__locals2.$VB$Local_mouthArr)
							{
								string text4 = Conversions.ToString(value2);
								string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(text4);
								source = PublicModule.regXIA.Split(fileNameWithoutExtension2);
								string strA2 = source.Last<string>();
								if (0 == string.Compare(strA2, strB, StringComparison.Ordinal))
								{
									bitmap2 = PublicModule.getBitMapFromFile(text4);
									graphics.DrawImage(bitmap2, CS$<>8__locals2.$VB$Local_iX, CS$<>8__locals2.$VB$Local_iY, bitmap2.Width, bitmap2.Height);
									bitmap2.Dispose();
									Interlocked.Add(ref PublicModule.iNow, 1);
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals2.$VB$Local_browAndeye[IBE]);
						graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
						bitmap2.Dispose();
						MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Png);
						ArrayList $VB$Local_fullface = CS$<>8__locals2.$VB$Local_fullface;
						lock ($VB$Local_fullface)
						{
							CS$<>8__locals2.$VB$Local_fullface.Add(memoryStream);
							CS$<>8__locals2.$VB$Local_fullfaceName.Add(RuntimeHelpers.GetObjectValue(CS$<>8__locals2.$VB$Local_browAndeyeName[IBE]));
						}
						bitmap.Dispose();
					});
					Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_browAndeye.ToArray(), delegate(object a0)
					{
						delegate(MemoryStream ms)
						{
							ms.Dispose();
						}((MemoryStream)a0);
					});
					CS$<>8__locals2.$VB$Local_browAndeyeName.Clear();
					int num = 0;
					int num2 = CS$<>8__locals2.$VB$Local_bodyArr.Count - 1;
					for (int j = num; j <= num2; j++)
					{
						BW2_three._Closure$__90._Closure$__91._Closure$__92 CS$<>8__locals3 = new BW2_three._Closure$__90._Closure$__91._Closure$__92(CS$<>8__locals3);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								return true;
							}
						}
						Interlocked.Add(ref PublicModule.iNow, 1);
						CS$<>8__locals3.$VB$Local_sBodyPath1 = Conversions.ToString(CS$<>8__locals2.$VB$Local_bodyArr[j]);
						using (Bitmap tempBitmap = PublicModule.getBitMapFromFile(CS$<>8__locals3.$VB$Local_sBodyPath1))
						{
							CS$<>8__locals3.$VB$Local_iWidth = tempBitmap.Width;
							CS$<>8__locals3.$VB$Local_iHeight = tempBitmap.Height;
							Parallel.For(0, CS$<>8__locals2.$VB$Local_fullface.Count, parallelOptions, delegate(int iFF, ParallelLoopState loopstate)
							{
								if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals1.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals1.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
								}
								Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pf);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								Bitmap $VB$Local_tempBitmap = tempBitmap;
								lock ($VB$Local_tempBitmap)
								{
									graphics.DrawImage(tempBitmap, 0, 0, CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight);
								}
								graphics.DrawImage(Image.FromStream((MemoryStream)CS$<>8__locals2.$VB$Local_fullface[iFF]), 0, 0, CS$<>8__locals2.$VB$Local_bodyW, CS$<>8__locals2.$VB$Local_bodyH);
								graphics.Dispose();
								string sSavePath = Conversions.ToString(Operators.ConcatenateObject(Path.Combine(CS$<>8__locals1.$VB$Local_base_path, Path.GetFileNameWithoutExtension(CS$<>8__locals3.$VB$Local_sBodyPath1)) + "_", CS$<>8__locals2.$VB$Local_fullfaceName[iFF]));
								PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref PublicModule.iBuild, 1);
								CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							});
						}
					}
					PublicModule.files2.Add(text);
					Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_fullface.ToArray(), delegate(object a0)
					{
						delegate(MemoryStream ms)
						{
							ms.Dispose();
						}((MemoryStream)a0);
					});
					CS$<>8__locals2.$VB$Local_fullfaceName.Clear();
					goto IL_496;
				}
				PublicModule.sSpecialExt = string.Empty;
				PublicModule.sGameExe = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000140D0 File Offset: 0x000122D0
		public static bool merge_imageObject_tjs(ref Form1 myForm1)
		{
			bool flag = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			if (0 == string.Compare(PublicModule.sGameExe, "suigetsu_2", StringComparison.OrdinalIgnoreCase))
			{
			}
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref PublicModule.iNow, 1);
				if (backgroundWorker.CancellationPending)
				{
					return true;
				}
				while (PublicModule.bWaitCancelAsync)
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
							string[] array4 = PublicModule.regXIA.Split(text3);
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
								flag = BW2_three.merge_imageObject_tjs_lms(ref myForm1, text2, ref arrayList2, "l");
								flag = BW2_three.merge_imageObject_tjs_lms(ref myForm1, text2, ref arrayList2, "m");
								flag = BW2_three.merge_imageObject_tjs_lms(ref myForm1, text2, ref arrayList2, "s");
								if (!flag)
								{
									string path = Path.Combine(directoryName, "0_YouCanDel");
									path = Path.Combine(path, text3);
									PublicModule.files3.Add(new string[]
									{
										Path.Combine(text2, "素体"),
										Path.Combine(path, "素体")
									});
									PublicModule.files3.Add(new string[]
									{
										Path.Combine(text2, "目パチ"),
										Path.Combine(path, "目パチ")
									});
									PublicModule.files3.Add(new string[]
									{
										Path.Combine(text2, "口パク"),
										Path.Combine(path, "口パク")
									});
									PublicModule.files3.Add(new string[]
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
			PublicModule.sSpecialExt = string.Empty;
			PublicModule.sGameExe = string.Empty;
			return flag;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000143F0 File Offset: 0x000125F0
		private static bool merge_imageObject_tjs_lms(ref Form1 myForm1, string thisfolder, ref ArrayList thisArr, string sMSize)
		{
			BW2_three._Closure$__94 CS$<>8__locals1 = new BW2_three._Closure$__94(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_eCancel = false;
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
			{
				return true;
			}
			string[] tjsFiles = kirikiri2_fun.getTjsFiles(thisfolder, "素体", sMSize);
			string[] tjsFiles2 = kirikiri2_fun.getTjsFiles(thisfolder, "表情", sMSize);
			string[] tjsFiles3 = kirikiri2_fun.getTjsFiles(thisfolder, "目パチ", sMSize);
			string[] tjsFiles4 = kirikiri2_fun.getTjsFiles(thisfolder, "口パク", sMSize);
			string[] array = tjsFiles;
			checked
			{
				for (int i = 0; i < array.Length; i++)
				{
					BW2_three._Closure$__94._Closure$__95 CS$<>8__locals2 = new BW2_three._Closure$__94._Closure$__95(CS$<>8__locals2);
					CS$<>8__locals2.$VB$Local_thisbody = array[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E = CS$<>8__locals1;
					if (!string.IsNullOrWhiteSpace(CS$<>8__locals2.$VB$Local_thisbody))
					{
						string text = Path.GetFileNameWithoutExtension(CS$<>8__locals2.$VB$Local_thisbody).Substring(2, 3);
						CS$<>8__locals2.$VB$Local_BodyStream = new MemoryStream();
						using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_thisbody))
						{
							CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
							CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
							CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
							bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_BodyStream, ImageFormat.Png);
						}
						CS$<>8__locals2.$VB$Local_mFaceEyeArr = new ArrayList();
						CS$<>8__locals2.$VB$Local_mFaceEyeName = new ArrayList();
						int num = 0;
						int num2 = 0;
						kirikiri2_fun.Tjs_lms_SY tjs_lms_SY2;
						try
						{
							foreach (object obj in thisArr)
							{
								kirikiri2_fun.Tjs_lms_SY tjs_lms_SY = (obj != null) ? ((kirikiri2_fun.Tjs_lms_SY)obj) : tjs_lms_SY2;
								if (0 == string.Compare(tjs_lms_SY.PosEorM, "目パチ", StringComparison.Ordinal) && 0 == string.Compare(tjs_lms_SY.PosID, text.Substring(1), StringComparison.Ordinal))
								{
									if (Operators.CompareString(sMSize, "l", false) == 0)
									{
										num = tjs_lms_SY.Pos_l_x;
										num2 = tjs_lms_SY.Pos_l_y;
										break;
									}
									if (Operators.CompareString(sMSize, "m", false) == 0)
									{
										num = tjs_lms_SY.Pos_m_x;
										num2 = tjs_lms_SY.Pos_m_y;
										break;
									}
									if (Operators.CompareString(sMSize, "s", false) == 0)
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
								if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									return true;
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										return true;
									}
								}
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
									string strB = fileNameWithoutExtension.Substring(1, 3);
									Interlocked.Add(ref PublicModule.iNow, 1);
									if (0 == string.Compare(text, strB, StringComparison.Ordinal))
									{
										bool flag = false;
										foreach (string text3 in tjsFiles3)
										{
											if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
											{
												return true;
											}
											while (PublicModule.bWaitCancelAsync)
											{
												Thread.Sleep(500);
												if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
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
													Interlocked.Add(ref PublicModule.iNow, 1);
													flag = true;
													Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text3);
													int num3 = bitMapFromFile2.Width / 4;
													int height = bitMapFromFile2.Height;
													Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
													Graphics graphics = Graphics.FromImage(bitmap);
													graphics.Clear(Color.Transparent);
													using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text2))
													{
														graphics.DrawImage(bitMapFromFile3, 0, 0, bitMapFromFile3.Width, bitMapFromFile3.Height);
													}
													graphics.Dispose();
													int num4 = num;
													int num5 = num3 + num - 1;
													for (int l = num4; l <= num5; l++)
													{
														int num6 = num2;
														int num7 = height + num2 - 1;
														for (int m = num6; m <= num7; m++)
														{
															bitmap.SetPixel(l, m, Color.Transparent);
														}
													}
													MemoryStream memoryStream = new MemoryStream();
													bitmap.Save(memoryStream, ImageFormat.Png);
													bitmap.Dispose();
													int num8 = 0;
													do
													{
														Rectangle rect = new Rectangle(num3 * num8, 0, num3, height);
														BitmapData bitmapData = bitMapFromFile2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
														Bitmap bitmap2 = new Bitmap(num3, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
														bitMapFromFile2.UnlockBits(bitmapData);
														Bitmap bitmap3 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
														graphics = Graphics.FromImage(bitmap3);
														graphics.DrawImage(Image.FromStream(memoryStream), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
														graphics.DrawImage(bitmap2, num, num2, bitmap2.Width, bitmap2.Height);
														graphics.Dispose();
														bitmap2.Dispose();
														MemoryStream memoryStream2 = new MemoryStream();
														bitmap3.Save(memoryStream2, ImageFormat.Png);
														CS$<>8__locals2.$VB$Local_mFaceEyeArr.Add(memoryStream2);
														string value = Path.GetFileNameWithoutExtension(text2) + "_" + num8.ToString("D3");
														CS$<>8__locals2.$VB$Local_mFaceEyeName.Add(value);
														bitmap3.Dispose();
														CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
														num8++;
													}
													while (num8 <= 3);
													bitMapFromFile2.Dispose();
													memoryStream.Dispose();
												}
											}
										}
										if (!flag)
										{
											Bitmap bitmap4 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
											Graphics graphics2 = Graphics.FromImage(bitmap4);
											graphics2.Clear(Color.Transparent);
											using (Bitmap bitMapFromFile4 = PublicModule.getBitMapFromFile(text2))
											{
												graphics2.DrawImage(bitMapFromFile4, 0, 0, bitMapFromFile4.Width, bitMapFromFile4.Height);
											}
											graphics2.Dispose();
											MemoryStream memoryStream3 = new MemoryStream();
											bitmap4.Save(memoryStream3, ImageFormat.Png);
											bitmap4.Dispose();
											CS$<>8__locals2.$VB$Local_mFaceEyeArr.Add(memoryStream3);
											string value = Path.GetFileNameWithoutExtension(text2);
											CS$<>8__locals2.$VB$Local_mFaceEyeName.Add(value);
										}
										CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
									}
								}
							}
						}
						if (0 >= CS$<>8__locals2.$VB$Local_mFaceEyeArr.Count)
						{
							foreach (string text4 in tjsFiles2)
							{
								if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									return true;
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										return true;
									}
								}
								if (!string.IsNullOrWhiteSpace(text4))
								{
									Interlocked.Add(ref PublicModule.iNow, 1);
									Bitmap bitmap5 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
									Graphics graphics3 = Graphics.FromImage(bitmap5);
									graphics3.Clear(Color.Transparent);
									using (Bitmap bitMapFromFile5 = PublicModule.getBitMapFromFile(text4))
									{
										graphics3.DrawImage(bitMapFromFile5, 0, 0, bitMapFromFile5.Width, bitMapFromFile5.Height);
									}
									graphics3.Dispose();
									MemoryStream memoryStream4 = new MemoryStream();
									bitmap5.Save(memoryStream4, ImageFormat.Png);
									bitmap5.Dispose();
									CS$<>8__locals2.$VB$Local_mFaceEyeArr.Add(memoryStream4);
									string value = Path.GetFileNameWithoutExtension(text4);
									CS$<>8__locals2.$VB$Local_mFaceEyeName.Add(value);
									CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
								}
							}
						}
						int num9 = 0;
						int num10 = 0;
						try
						{
							foreach (object obj2 in thisArr)
							{
								kirikiri2_fun.Tjs_lms_SY tjs_lms_SY3 = (obj2 != null) ? ((kirikiri2_fun.Tjs_lms_SY)obj2) : tjs_lms_SY2;
								if (0 == string.Compare(tjs_lms_SY3.PosEorM, "口パク", StringComparison.Ordinal) && 0 == string.Compare(tjs_lms_SY3.PosID, text.Substring(1), StringComparison.Ordinal))
								{
									if (Operators.CompareString(sMSize, "l", false) == 0)
									{
										num9 = tjs_lms_SY3.Pos_l_x;
										num10 = tjs_lms_SY3.Pos_l_y;
										break;
									}
									if (Operators.CompareString(sMSize, "m", false) == 0)
									{
										num9 = tjs_lms_SY3.Pos_m_x;
										num10 = tjs_lms_SY3.Pos_m_y;
										break;
									}
									if (Operators.CompareString(sMSize, "s", false) == 0)
									{
										num9 = tjs_lms_SY3.Pos_s_x;
										num10 = tjs_lms_SY3.Pos_s_y;
										break;
									}
									num9 = 0;
									num10 = 0;
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
						if (!(0 == num9 & 0 == num10))
						{
							CS$<>8__locals2.$VB$Local_aeMouthArr = new ArrayList();
							CS$<>8__locals2.$VB$Local_aeMouthName = new ArrayList();
							foreach (string text5 in tjsFiles4)
							{
								if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									return true;
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
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
										Interlocked.Add(ref PublicModule.iNow, 1);
										Bitmap bitMapFromFile6 = PublicModule.getBitMapFromFile(text5);
										int num12 = bitMapFromFile6.Width / 4;
										int height2 = bitMapFromFile6.Height;
										int num13 = 0;
										do
										{
											Rectangle rect2 = new Rectangle(num12 * num13, 0, num12, height2);
											BitmapData bitmapData2 = bitMapFromFile6.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
											Bitmap bitmap6 = new Bitmap(num12, height2, bitmapData2.Stride, PixelFormat.Format32bppArgb, bitmapData2.Scan0);
											bitMapFromFile6.UnlockBits(bitmapData2);
											Bitmap bitmap7 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
											Graphics graphics4 = Graphics.FromImage(bitmap7);
											graphics4.Clear(Color.Transparent);
											graphics4.DrawImage(bitmap6, num9, num10, bitmap6.Width, bitmap6.Height);
											graphics4.Dispose();
											bitmap6.Dispose();
											MemoryStream memoryStream5 = new MemoryStream();
											bitmap7.Save(memoryStream5, ImageFormat.Png);
											CS$<>8__locals2.$VB$Local_aeMouthArr.Add(memoryStream5);
											string value = Path.GetFileNameWithoutExtension(text5) + "_" + num13.ToString("D3");
											CS$<>8__locals2.$VB$Local_aeMouthName.Add(value);
											bitmap7.Dispose();
											CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
											num13++;
										}
										while (num13 <= 3);
									}
								}
							}
							CS$<>8__locals2.$VB$Local_basedir = Path.Combine(thisfolder, sMSize);
							if (!Directory.Exists(CS$<>8__locals2.$VB$Local_basedir))
							{
								Directory.CreateDirectory(CS$<>8__locals2.$VB$Local_basedir);
							}
							Parallel.For(0, CS$<>8__locals2.$VB$Local_mFaceEyeArr.Count, parallelOptions, delegate(int iI, ParallelLoopState loopstate)
							{
								if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
								}
								Bitmap bitmap8 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
								Graphics graphics5 = Graphics.FromImage(bitmap8);
								graphics5.Clear(Color.Transparent);
								MemoryStream $VB$Local_BodyStream = CS$<>8__locals2.$VB$Local_BodyStream;
								lock ($VB$Local_BodyStream)
								{
									graphics5.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_BodyStream), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
								}
								Bitmap bitmap9 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals2.$VB$Local_mFaceEyeArr[iI]);
								graphics5.DrawImage(bitmap9, 0, 0, bitmap9.Width, bitmap9.Height);
								bitmap9.Dispose();
								graphics5.Dispose();
								MemoryStream memoryStream6 = new MemoryStream();
								bitmap8.Save(memoryStream6, ImageFormat.Png);
								bitmap8.Dispose();
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_substrings = PublicModule.regXIA.Split(Conversions.ToString(CS$<>8__locals2.$VB$Local_mFaceEyeName[iI]));
								string @string = CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_substrings[0] + "_" + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_substrings[1];
								int num14 = 0;
								int num15 = CS$<>8__locals2.$VB$Local_aeMouthName.Count - 1;
								for (int num16 = num14; num16 <= num15; num16++)
								{
									string text6 = Conversions.ToString(CS$<>8__locals2.$VB$Local_aeMouthName[num16]);
									if (Strings.InStr(1, text6, @string, CompareMethod.Binary) > 0)
									{
										bitmap8 = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
										graphics5 = Graphics.FromImage(bitmap8);
										graphics5.DrawImage(Image.FromStream(memoryStream6), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
										graphics5.DrawImage(Image.FromStream((MemoryStream)CS$<>8__locals2.$VB$Local_aeMouthArr[num16]), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
										graphics5.Dispose();
										string sSavePath = Path.Combine(CS$<>8__locals2.$VB$Local_basedir, Conversions.ToString(Operators.ConcatenateObject(Path.GetFileNameWithoutExtension(CS$<>8__locals2.$VB$Local_thisbody) + "_", CS$<>8__locals2.$VB$Local_mFaceEyeName[iI]))) + "_" + text6;
										PublicModule.saveBitmapFile(sSavePath, ref bitmap8, true);
										bitmap8.Dispose();
										Interlocked.Add(ref PublicModule.iBuild, 1);
									}
								}
								memoryStream6.Dispose();
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_5E.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							});
							CS$<>8__locals2.$VB$Local_BodyStream.Dispose();
							Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_mFaceEyeArr.ToArray(), delegate(object a0)
							{
								delegate(MemoryStream ms)
								{
									ms.Dispose();
								}((MemoryStream)a0);
							});
							CS$<>8__locals2.$VB$Local_mFaceEyeName.Clear();
							Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_aeMouthArr.ToArray(), delegate(object a0)
							{
								delegate(MemoryStream ms)
								{
									ms.Dispose();
								}((MemoryStream)a0);
							});
							CS$<>8__locals2.$VB$Local_aeMouthName.Clear();
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00014F90 File Offset: 0x00013190
		public static bool X_info_X_X_info_V1(ref Form1 myForm1, bool bAutoWH = false)
		{
			BW2_three._Closure$__96 CS$<>8__locals1 = new BW2_three._Closure$__96();
			CS$<>8__locals1.$VB$Local_bAutoWH = bAutoWH;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				CS$<>8__locals1.$VB$Local_po = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__96._Closure$__97 CS$<>8__locals2 = new BW2_three._Closure$__96._Closure$__97(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_60 = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						string[] array3 = PublicModule.regXIA.Split(Path.GetFileNameWithoutExtension(text));
						CS$<>8__locals1.$VB$Local_bas_name = array3[0];
						CS$<>8__locals1.$VB$Local_base_info_path = Path.Combine(Path.GetDirectoryName(text), CS$<>8__locals1.$VB$Local_bas_name) + "_info.txt";
						CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
						if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
						{
							PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
							Parallel.ForEach<string>(array, delegate(string path1)
							{
								if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
								{
									string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
									if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_bas_name, CompareMethod.Binary) > 0)
									{
										ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
										lock ($VB$Local_sameTxtArr)
										{
											CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
										}
										ArrayList files = PublicModule.files2;
										lock (files)
										{
											PublicModule.files2.Add(path1);
										}
									}
								}
							});
							if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
							{
								try
								{
									IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
									while (enumerator.MoveNext())
									{
										BW2_three._Closure$__96._Closure$__97._Closure$__98 CS$<>8__locals3 = new BW2_three._Closure$__96._Closure$__97._Closure$__98(CS$<>8__locals3);
										string text2 = Conversions.ToString(enumerator.Current);
										CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60 = CS$<>8__locals1;
										Interlocked.Add(ref PublicModule.iNow, 1);
										ArrayList arrayList = new ArrayList();
										if (Strings.InStr(1, text2, "_info", CompareMethod.Binary) > 0)
										{
											PublicModule.files2.Add(text2);
										}
										else
										{
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											string text3 = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension) + "_info.txt";
											if (File.Exists(text3))
											{
												PublicModule.files2.Add(text3);
												if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
												{
													ArrayList arrayList2 = new ArrayList();
													kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
													ArrayList arrayList3 = new ArrayList();
													CS$<>8__locals3.$VB$Local_diffArr = new ArrayList();
													ArrayList arrayList4 = new ArrayList();
													CS$<>8__locals3.$VB$Local_faceMergeArr = new ArrayList();
													CS$<>8__locals3.$VB$Local_addArr = new ArrayList();
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
																	CS$<>8__locals3.$VB$Local_diffArr.Add(array6);
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
																		CS$<>8__locals3.$VB$Local_faceMergeArr.Add(array7);
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
																	CS$<>8__locals3.$VB$Local_addArr.Add(array9);
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
													CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
													CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
													CS$<>8__locals3.$VB$Local_faceAndaddBitmap = new ArrayList();
													CS$<>8__locals3.$VB$Local_faceAndaddName = new ArrayList();
													Parallel.ForEach<object>(arrayList4.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
													{
														delegate(string[] fa, ParallelLoopState loopstate2)
														{
															Interlocked.Add(ref PublicModule.iNow, 1);
															if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_eCancel = true;
																loopstate2.Stop();
															}
															while (PublicModule.bWaitCancelAsync)
															{
																Thread.Sleep(500);
																if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_BackgroundWorker2.CancellationPending)
																{
																	CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_eCancel = true;
																	loopstate2.Stop();
																}
															}
															if (string.IsNullOrWhiteSpace(fa[0]))
															{
																return;
															}
															string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + fa[1]);
															if (File.Exists(text6))
															{
																PublicModule.files2.Add(text6);
																MemoryStream memoryStream = new MemoryStream();
																using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text6))
																{
																	bitMapFromFile2.Save(memoryStream, ImageFormat.Png);
																}
																string text7 = fa[0];
																try
																{
																	foreach (object obj2 in CS$<>8__locals3.$VB$Local_addArr)
																	{
																		string[] array10 = (string[])obj2;
																		Interlocked.Add(ref PublicModule.iNow, 1);
																		string text8 = array10[0];
																		if (!string.IsNullOrWhiteSpace(text8))
																		{
																			string text9 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array10[1]);
																			if (File.Exists(text9))
																			{
																				PublicModule.files2.Add(text9);
																				Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																				Graphics graphics = Graphics.FromImage(bitmap);
																				graphics.Clear(Color.Transparent);
																				Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
																				graphics.DrawImage(bitmap2, Conversions.ToInteger(fa[2]), Conversions.ToInteger(fa[3]), bitmap2.Width, bitmap2.Height);
																				bitmap2 = PublicModule.getBitMapFromFile(text9);
																				graphics.DrawImage(bitmap2, Conversions.ToInteger(array10[2]), Conversions.ToInteger(array10[3]), bitmap2.Width, bitmap2.Height);
																				graphics.Dispose();
																				MemoryStream memoryStream2 = new MemoryStream();
																				bitmap.Save(memoryStream2, ImageFormat.Png);
																				ArrayList $VB$Local_faceAndaddBitmap = CS$<>8__locals3.$VB$Local_faceAndaddBitmap;
																				lock ($VB$Local_faceAndaddBitmap)
																				{
																					CS$<>8__locals3.$VB$Local_faceAndaddBitmap.Add(memoryStream2);
																				}
																				ArrayList $VB$Local_faceAndaddName = CS$<>8__locals3.$VB$Local_faceAndaddName;
																				lock ($VB$Local_faceAndaddName)
																				{
																					CS$<>8__locals3.$VB$Local_faceAndaddName.Add(new string[]
																					{
																						text7,
																						array10[6],
																						text7 + "_" + text8
																					});
																				}
																				bitmap2.Dispose();
																				bitmap.Dispose();
																				Thread.Sleep(PublicModule.iThreadWaitTime);
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
																memoryStream.Dispose();
															}
														}((string[])a0, a1);
													});
													CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
													CS$<>8__locals3.$VB$Local_faceMergeBitmap = new ArrayList();
													CS$<>8__locals3.$VB$Local_faceMergeName = new ArrayList();
													Parallel.For(0, CS$<>8__locals3.$VB$Local_faceAndaddBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
													{
														if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_eCancel = true;
															loopstate.Stop();
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_60.$VB$Local_eCancel = true;
																loopstate.Stop();
															}
														}
														string[] array10 = (string[])CS$<>8__locals3.$VB$Local_faceAndaddName[ims];
														Bitmap bitmap = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_faceAndaddBitmap[ims]);
														Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Width, PixelFormat.Format32bppArgb);
														Graphics graphics = Graphics.FromImage(bitmap2);
														graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
														try
														{
															foreach (object obj2 in CS$<>8__locals3.$VB$Local_faceMergeArr)
															{
																string[] array11 = (string[])obj2;
																if (0 == string.Compare(array11[0], array10[0], StringComparison.Ordinal))
																{
																	string text6 = array11[6];
																	string text7 = array10[1];
																	if (Strings.InStr(1, text6, "/", CompareMethod.Binary) > 0)
																	{
																		string[] array12 = array11[6].Split(new char[]
																		{
																			'/'
																		});
																		text6 = array12[0];
																	}
																	if (Strings.InStr(1, text7, "/", CompareMethod.Binary) > 0)
																	{
																		string[] array13 = array10[1].Split(new char[]
																		{
																			'/'
																		});
																		text7 = array13[0];
																	}
																	if (0 != string.Compare(text6, text7, StringComparison.Ordinal))
																	{
																		string text8 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array11[1]);
																		if (File.Exists(text8))
																		{
																			PublicModule.files2.Add(text8);
																			bitmap = PublicModule.getBitMapFromFile(text8);
																			graphics.DrawImage(bitmap, Conversions.ToInteger(array11[2]), Conversions.ToInteger(array11[3]), bitmap.Width, bitmap.Height);
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
														graphics.Dispose();
														MemoryStream memoryStream = new MemoryStream();
														bitmap2.Save(memoryStream, ImageFormat.Png);
														ArrayList $VB$Local_faceMergeBitmap = CS$<>8__locals3.$VB$Local_faceMergeBitmap;
														lock ($VB$Local_faceMergeBitmap)
														{
															CS$<>8__locals3.$VB$Local_faceMergeBitmap.Add(memoryStream);
														}
														ArrayList $VB$Local_faceMergeName = CS$<>8__locals3.$VB$Local_faceMergeName;
														lock ($VB$Local_faceMergeName)
														{
															CS$<>8__locals3.$VB$Local_faceMergeName.Add(array10[2]);
														}
														bitmap2.Dispose();
														bitmap.Dispose();
														Thread.Sleep(PublicModule.iThreadWaitTime);
													});
													Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_faceAndaddBitmap.ToArray(), delegate(object a0)
													{
														delegate(MemoryStream ms)
														{
															ms.Dispose();
														}((MemoryStream)a0);
													});
													CS$<>8__locals3.$VB$Local_faceAndaddBitmap.Clear();
													CS$<>8__locals3.$VB$Local_faceAndaddName.Clear();
													PublicModule.iMaxToBW = arrayList3.Count + CS$<>8__locals3.$VB$Local_faceMergeBitmap.Count;
													CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
													try
													{
														IEnumerator enumerator3 = arrayList3.GetEnumerator();
														while (enumerator3.MoveNext())
														{
															BW2_three._Closure$__96._Closure$__97._Closure$__98._Closure$__99 CS$<>8__locals4 = new BW2_three._Closure$__96._Closure$__97._Closure$__98._Closure$__99(CS$<>8__locals4);
															CS$<>8__locals4.$VB$Local_da = (string[])enumerator3.Current;
															Interlocked.Add(ref PublicModule.iNow, 1);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
															while (PublicModule.bWaitCancelAsync)
															{
																Thread.Sleep(500);
																if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																{
																	return true;
																}
															}
															if (!string.IsNullOrWhiteSpace(CS$<>8__locals4.$VB$Local_da[0]))
															{
																string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + CS$<>8__locals4.$VB$Local_da[2]);
																if (File.Exists(text5))
																{
																	PublicModule.files2.Add(text5);
																	MemoryStream stream1 = new MemoryStream();
																	using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text5))
																	{
																		bitMapFromFile.Save(stream1, ImageFormat.Png);
																	}
																	string sCloth = CS$<>8__locals4.$VB$Local_da[0];
																	int iDaX = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[3]);
																	int iDaY = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[4]);
																	int iDaW = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[5]);
																	int iDaH = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[6]);
																	Parallel.For(0, CS$<>8__locals3.$VB$Local_faceMergeBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
																	{
																		BW2_three._Closure$__96._Closure$__97._Closure$__98._Closure$__99._Closure$__100._Closure$__101 CS$<>8__locals6 = new BW2_three._Closure$__96._Closure$__97._Closure$__98._Closure$__99._Closure$__100._Closure$__101();
																		CS$<>8__locals6.$VB$Local_ims = ims;
																		if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			CS$<>8__locals1.$VB$Local_eCancel = true;
																			loopstate.Stop();
																		}
																		while (PublicModule.bWaitCancelAsync)
																		{
																			Thread.Sleep(500);
																			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																			{
																				CS$<>8__locals1.$VB$Local_eCancel = true;
																				loopstate.Stop();
																			}
																		}
																		string fMName = Conversions.ToString(CS$<>8__locals3.$VB$Local_faceMergeName[CS$<>8__locals6.$VB$Local_ims]);
																		Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_diffArr.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
																		{
																			delegate(string[] dia, ParallelLoopState loopstate2)
																			{
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					CS$<>8__locals1.$VB$Local_eCancel = true;
																					loopstate2.Stop();
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																					{
																						CS$<>8__locals1.$VB$Local_eCancel = true;
																						loopstate2.Stop();
																					}
																				}
																				if (string.IsNullOrWhiteSpace(dia[0]))
																				{
																					return;
																				}
																				if (0 == string.Compare(sCloth, dia[0], StringComparison.Ordinal))
																				{
																					string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + dia[2]);
																					if (File.Exists(text6))
																					{
																						PublicModule.files2.Add(text6);
																						int num = iDaX;
																						int num2 = iDaY;
																						int $VB$Local_iDaW = iDaW;
																						int $VB$Local_iDaH = iDaH;
																						int width = CS$<>8__locals3.$VB$Local_iW;
																						int height = CS$<>8__locals3.$VB$Local_iH;
																						int num3 = Conversions.ToInteger(dia[3]);
																						int num4 = Conversions.ToInteger(dia[4]);
																						int num5 = Conversions.ToInteger(dia[5]);
																						int num6 = 0;
																						int num7 = 0;
																						if (CS$<>8__locals1.$VB$Local_bAutoWH)
																						{
																							if (0 > num2)
																							{
																								num7 = Math.Abs(num2);
																								num2 = 0;
																								num4 += num7;
																							}
																							if ($VB$Local_iDaH - CS$<>8__locals3.$VB$Local_iH > 0)
																							{
																								height = $VB$Local_iDaH + Math.Abs(num2);
																							}
																							else
																							{
																								height = CS$<>8__locals3.$VB$Local_iH + num2;
																							}
																							if (0 > num)
																							{
																								num6 = Math.Abs(num);
																								num = 0;
																								num3 += num6;
																								if ($VB$Local_iDaW - CS$<>8__locals3.$VB$Local_iW > 0)
																								{
																									width = $VB$Local_iDaW + num6;
																								}
																							}
																						}
																						Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
																						Graphics graphics = Graphics.FromImage(bitmap);
																						graphics.Clear(Color.Transparent);
																						MemoryStream $VB$Local_stream = stream1;
																						Bitmap bitmap2;
																						lock ($VB$Local_stream)
																						{
																							bitmap2 = (Bitmap)Image.FromStream(stream1);
																							graphics.DrawImage(bitmap2, num, num2, bitmap2.Width, bitmap2.Height);
																						}
																						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_faceMergeBitmap[CS$<>8__locals6.$VB$Local_ims]);
																						graphics.DrawImage(bitmap2, num6, num7, bitmap2.Width, bitmap2.Height);
																						if (0 != string.Compare(sCloth, dia[7], StringComparison.Ordinal))
																						{
																							bitmap2 = PublicModule.getBitMapFromFile(text6);
																							graphics.DrawImage(bitmap2, num3, num4, bitmap2.Width, bitmap2.Height);
																						}
																						bitmap2.Dispose();
																						graphics.Dispose();
																						string sSavePath = string.Concat(new string[]
																						{
																							CS$<>8__locals3.$VB$Local_fullBasepath,
																							"_",
																							CS$<>8__locals4.$VB$Local_da[1],
																							"_",
																							dia[1],
																							"_",
																							fMName
																						});
																						PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
																						Interlocked.Add(ref PublicModule.iBuild, 1);
																						bitmap.Dispose();
																						CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																						Thread.Sleep(PublicModule.iThreadWaitTime);
																					}
																				}
																			}((string[])a0, a1);
																		});
																	});
																	stream1.Dispose();
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
													Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_faceMergeBitmap.ToArray(), delegate(object a0)
													{
														delegate(MemoryStream ms)
														{
															ms.Dispose();
														}((MemoryStream)a0);
													});
													CS$<>8__locals3.$VB$Local_faceMergeBitmap.Clear();
													CS$<>8__locals3.$VB$Local_faceMergeName.Clear();
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000158D4 File Offset: 0x00013AD4
		public static bool X_info_X_X_stand(ref Form1 myForm1)
		{
			BW2_three._Closure$__103 CS$<>8__locals1 = new BW2_three._Closure$__103();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				CS$<>8__locals1.$VB$Local_po = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__103._Closure$__104 CS$<>8__locals2 = new BW2_three._Closure$__103._Closure$__104(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_67 = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						string[] array3 = PublicModule.regXIA.Split(Path.GetFileNameWithoutExtension(text));
						CS$<>8__locals1.$VB$Local_bas_name = array3[0];
						CS$<>8__locals1.$VB$Local_base_info_path = Path.Combine(Path.GetDirectoryName(text), CS$<>8__locals1.$VB$Local_bas_name) + "_info.txt";
						CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
						if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
						{
							PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
							Parallel.ForEach<string>(array, delegate(string path1)
							{
								if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
								{
									string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
									if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_bas_name, CompareMethod.Binary) > 0)
									{
										ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
										lock ($VB$Local_sameTxtArr)
										{
											CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
										}
										ArrayList files = PublicModule.files2;
										lock (files)
										{
											PublicModule.files2.Add(path1);
										}
									}
								}
							});
							if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
							{
								try
								{
									IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
									while (enumerator.MoveNext())
									{
										BW2_three._Closure$__103._Closure$__104._Closure$__105 CS$<>8__locals3 = new BW2_three._Closure$__103._Closure$__104._Closure$__105(CS$<>8__locals3);
										string text2 = Conversions.ToString(enumerator.Current);
										CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_67 = CS$<>8__locals1;
										Interlocked.Add(ref PublicModule.iNow, 1);
										ArrayList arrayList = new ArrayList();
										if (Strings.InStr(1, text2, "_info", CompareMethod.Binary) > 0)
										{
											PublicModule.files2.Add(text2);
										}
										else
										{
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											string text3 = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension) + "_info.txt";
											if (File.Exists(text3))
											{
												PublicModule.files2.Add(text3);
												if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
												{
													ArrayList arrayList2 = new ArrayList();
													kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
													ArrayList arrayList3 = new ArrayList();
													ArrayList arrayList4 = new ArrayList();
													CS$<>8__locals3.$VB$Local_fgnameArr = new ArrayList();
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
																	CS$<>8__locals3.$VB$Local_fgnameArr.Add(array7);
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
													CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
													CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
													CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap = new ArrayList();
													CS$<>8__locals3.$VB$Local_fgaliasName = new ArrayList();
													Parallel.ForEach<object>(arrayList5.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
													{
														delegate(string[] fa, ParallelLoopState loopstate2)
														{
															Interlocked.Add(ref PublicModule.iNow, 1);
															if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_eCancel = true;
																loopstate2.Stop();
															}
															while (PublicModule.bWaitCancelAsync)
															{
																Thread.Sleep(500);
																if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_BackgroundWorker2.CancellationPending)
																{
																	CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_67.$VB$Local_eCancel = true;
																	loopstate2.Stop();
																}
															}
															if (string.IsNullOrWhiteSpace(fa[0]))
															{
																return;
															}
															Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
															Graphics graphics = Graphics.FromImage(bitmap);
															graphics.Clear(Color.Transparent);
															int num3 = 0;
															int num4 = fa.Count<string>() - 1;
															for (int j = num3; j <= num4; j++)
															{
																if (j >= 2)
																{
																	string strA = fa[j];
																	try
																	{
																		foreach (object obj2 in CS$<>8__locals3.$VB$Local_fgnameArr)
																		{
																			string[] array8 = (string[])obj2;
																			if (0 == string.Compare(strA, array8[0], StringComparison.Ordinal))
																			{
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[1]);
																				if (File.Exists(text6))
																				{
																					PublicModule.files2.Add(text6);
																					Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text6);
																					graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																					bitMapFromFile2.Dispose();
																					break;
																				}
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
																}
															}
															graphics.Dispose();
															MemoryStream memoryStream = new MemoryStream();
															bitmap.Save(memoryStream, ImageFormat.Png);
															ArrayList $VB$Local_fgaliasAndfgnameBitmap = CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap;
															lock ($VB$Local_fgaliasAndfgnameBitmap)
															{
																CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Add(memoryStream);
															}
															ArrayList $VB$Local_fgaliasName = CS$<>8__locals3.$VB$Local_fgaliasName;
															lock ($VB$Local_fgaliasName)
															{
																CS$<>8__locals3.$VB$Local_fgaliasName.Add(fa[1]);
															}
															bitmap.Dispose();
															Thread.Sleep(PublicModule.iThreadWaitTime);
														}((string[])a0, a1);
													});
													PublicModule.iMaxToBW = arrayList3.Count + arrayList4.Count;
													CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
													try
													{
														IEnumerator enumerator3 = arrayList3.GetEnumerator();
														while (enumerator3.MoveNext())
														{
															BW2_three._Closure$__103._Closure$__104._Closure$__105._Closure$__106 CS$<>8__locals4 = new BW2_three._Closure$__103._Closure$__104._Closure$__105._Closure$__106(CS$<>8__locals4);
															CS$<>8__locals4.$VB$Local_da = (string[])enumerator3.Current;
															Interlocked.Add(ref PublicModule.iNow, 1);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
															while (PublicModule.bWaitCancelAsync)
															{
																Thread.Sleep(500);
																if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																{
																	return true;
																}
															}
															if (!string.IsNullOrWhiteSpace(CS$<>8__locals4.$VB$Local_da[0]))
															{
																string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + CS$<>8__locals4.$VB$Local_da[2]);
																if (File.Exists(text5))
																{
																	PublicModule.files2.Add(text5);
																	MemoryStream stream1 = new MemoryStream();
																	using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text5))
																	{
																		bitMapFromFile.Save(stream1, ImageFormat.Png);
																	}
																	string sCloth = CS$<>8__locals4.$VB$Local_da[0];
																	int iDaX = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[3]);
																	int iDaY = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[4]);
																	int num = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[5]);
																	int num2 = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[6]);
																	Parallel.ForEach<object>(arrayList4.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
																	{
																		delegate(string[] dia, ParallelLoopState loopstate2)
																		{
																			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																			{
																				CS$<>8__locals1.$VB$Local_eCancel = true;
																				loopstate2.Stop();
																			}
																			while (PublicModule.bWaitCancelAsync)
																			{
																				Thread.Sleep(500);
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					CS$<>8__locals1.$VB$Local_eCancel = true;
																					loopstate2.Stop();
																				}
																			}
																			if (string.IsNullOrWhiteSpace(dia[0]))
																			{
																				return;
																			}
																			if (0 == string.Compare(sCloth, dia[0], StringComparison.Ordinal))
																			{
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + dia[2]);
																				if (File.Exists(text6))
																				{
																					PublicModule.files2.Add(text6);
																					MemoryStream stream2 = new MemoryStream();
																					using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text6))
																					{
																						bitMapFromFile2.Save(stream2, ImageFormat.Png);
																					}
																					int iDiaX = Conversions.ToInteger(dia[3]);
																					int iDiaY = Conversions.ToInteger(dia[4]);
																					Parallel.For(0, CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
																					{
																						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																						{
																							CS$<>8__locals1.$VB$Local_eCancel = true;
																							loopstate.Stop();
																						}
																						while (PublicModule.bWaitCancelAsync)
																						{
																							Thread.Sleep(500);
																							if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																							{
																								CS$<>8__locals1.$VB$Local_eCancel = true;
																								loopstate.Stop();
																							}
																						}
																						string text7 = Conversions.ToString(CS$<>8__locals3.$VB$Local_fgaliasName[ims]);
																						Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																						Graphics graphics = Graphics.FromImage(bitmap);
																						graphics.Clear(Color.Transparent);
																						MemoryStream $VB$Local_stream = stream1;
																						Bitmap bitmap2;
																						lock ($VB$Local_stream)
																						{
																							bitmap2 = (Bitmap)Image.FromStream(stream1);
																							graphics.DrawImage(bitmap2, iDaX, iDaY, bitmap2.Width, bitmap2.Height);
																						}
																						MemoryStream $VB$Local_stream2 = stream2;
																						lock ($VB$Local_stream2)
																						{
																							bitmap2 = (Bitmap)Image.FromStream(stream2);
																							graphics.DrawImage(bitmap2, iDiaX, iDiaY, bitmap2.Width, bitmap2.Height);
																						}
																						bitmap2 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap[ims]);
																						graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
																						graphics.Dispose();
																						string sSavePath = string.Concat(new string[]
																						{
																							CS$<>8__locals3.$VB$Local_fullBasepath,
																							"_",
																							CS$<>8__locals4.$VB$Local_da[0],
																							"_",
																							dia[1],
																							"_",
																							text7
																						});
																						PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
																						Interlocked.Add(ref PublicModule.iBuild, 1);
																						bitmap2.Dispose();
																						bitmap.Dispose();
																						CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																						Thread.Sleep(PublicModule.iThreadWaitTime);
																					});
																					stream2.Dispose();
																				}
																			}
																		}((string[])a0, a1);
																	});
																	stream1.Dispose();
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
													Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.ToArray(), delegate(object a0)
													{
														delegate(MemoryStream ms)
														{
															ms.Dispose();
														}((MemoryStream)a0);
													});
													CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Clear();
													CS$<>8__locals3.$VB$Local_fgaliasName.Clear();
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000160AC File Offset: 0x000142AC
		public static bool X_info_X_txt_ddfff(ref Form1 myForm1, bool bNoBase = false)
		{
			BW2_three._Closure$__110 CS$<>8__locals1 = new BW2_three._Closure$__110();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				CS$<>8__locals1.$VB$Local_po = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__110._Closure$__111 CS$<>8__locals2 = new BW2_three._Closure$__110._Closure$__111(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_6E = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						CS$<>8__locals1.$VB$Local_bas_name = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_bas_name, "_info", CompareMethod.Binary) > 0)
						{
							CS$<>8__locals1.$VB$Local_base_info_path = text;
							CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
							if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
							{
								PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
								Parallel.ForEach<string>(array, delegate(string path1)
								{
									if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
									{
										string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
										if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_bas_name.Replace("_info", ""), CompareMethod.Binary) > 0)
										{
											ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
											lock ($VB$Local_sameTxtArr)
											{
												CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
											}
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(path1);
											}
										}
									}
								});
								if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
								{
									try
									{
										IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three._Closure$__110._Closure$__111._Closure$__112 CS$<>8__locals3 = new BW2_three._Closure$__110._Closure$__111._Closure$__112(CS$<>8__locals3);
											string text2 = Conversions.ToString(enumerator.Current);
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_6E = CS$<>8__locals1;
											Interlocked.Add(ref PublicModule.iNow, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												CS$<>8__locals3.$VB$Local_fgnameArr = new ArrayList();
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
																CS$<>8__locals3.$VB$Local_fgnameArr.Add(array7);
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
												CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
												CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_fgaliasName = new ArrayList();
												Parallel.ForEach<object>(arrayList5.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
												{
													delegate(string[] fa, ParallelLoopState loopstate2)
													{
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_eCancel = true;
															loopstate2.Stop();
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_6E.$VB$Local_eCancel = true;
																loopstate2.Stop();
															}
														}
														if (string.IsNullOrWhiteSpace(fa[0]))
														{
															return;
														}
														Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
														Graphics graphics = Graphics.FromImage(bitmap);
														graphics.Clear(Color.Transparent);
														int num3 = 0;
														int num4 = fa.Count<string>() - 1;
														for (int j = num3; j <= num4; j++)
														{
															if (j >= 2)
															{
																string strA = fa[j];
																try
																{
																	foreach (object obj4 in CS$<>8__locals3.$VB$Local_fgnameArr)
																	{
																		string[] array8 = (string[])obj4;
																		if (0 == string.Compare(strA, array8[0], StringComparison.Ordinal))
																		{
																			Interlocked.Add(ref PublicModule.iNow, 1);
																			string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[1]);
																			if (File.Exists(text5))
																			{
																				ArrayList files = PublicModule.files2;
																				lock (files)
																				{
																					PublicModule.files2.Add(text5);
																				}
																				Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5);
																				graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																				bitMapFromFile2.Dispose();
																				break;
																			}
																			break;
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
															}
														}
														graphics.Dispose();
														MemoryStream memoryStream = new MemoryStream();
														bitmap.Save(memoryStream, ImageFormat.Png);
														ArrayList $VB$Local_fgaliasAndfgnameBitmap = CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap;
														lock ($VB$Local_fgaliasAndfgnameBitmap)
														{
															CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Add(memoryStream);
														}
														ArrayList $VB$Local_fgaliasName = CS$<>8__locals3.$VB$Local_fgaliasName;
														lock ($VB$Local_fgaliasName)
														{
															CS$<>8__locals3.$VB$Local_fgaliasName.Add(fa[1]);
														}
														bitmap.Dispose();
														Thread.Sleep(PublicModule.iThreadWaitTime);
													}((string[])a0, a1);
												});
												PublicModule.iMaxToBW = arrayList3.Count + arrayList4.Count;
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
														BW2_three._Closure$__110._Closure$__111._Closure$__112._Closure$__113 CS$<>8__locals4 = new BW2_three._Closure$__110._Closure$__111._Closure$__112._Closure$__113(CS$<>8__locals4);
														CS$<>8__locals4.$VB$Local_da = (string[])enumerator5.Current;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(CS$<>8__locals4.$VB$Local_da[0]))
														{
															string text4 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + CS$<>8__locals4.$VB$Local_da[2]);
															if (File.Exists(text4))
															{
																PublicModule.files2.Add(text4);
																MemoryStream stream1 = new MemoryStream();
																using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4))
																{
																	bitMapFromFile.Save(stream1, ImageFormat.Png);
																}
																string sCloth = CS$<>8__locals4.$VB$Local_da[0];
																int iDaX = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[3]);
																int iDaY = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[4]);
																int num = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[5]);
																int num2 = Conversions.ToInteger(CS$<>8__locals4.$VB$Local_da[6]);
																int iFind = 0;
																Parallel.ForEach<object>(arrayList4.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
																{
																	delegate(string[] dia, ParallelLoopState loopstate2)
																	{
																		if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			CS$<>8__locals1.$VB$Local_eCancel = true;
																			loopstate2.Stop();
																		}
																		while (PublicModule.bWaitCancelAsync)
																		{
																			Thread.Sleep(500);
																			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																			{
																				CS$<>8__locals1.$VB$Local_eCancel = true;
																				loopstate2.Stop();
																			}
																		}
																		if (string.IsNullOrWhiteSpace(dia[0]))
																		{
																			return;
																		}
																		if (0 == string.Compare(sCloth, dia[0], StringComparison.Ordinal))
																		{
																			Interlocked.Add(ref PublicModule.iNow, 1);
																			string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + dia[2]);
																			if (File.Exists(text5))
																			{
																				Interlocked.Add(ref iFind, 1);
																				ArrayList files = PublicModule.files2;
																				lock (files)
																				{
																					PublicModule.files2.Add(text5);
																				}
																				MemoryStream stream2 = new MemoryStream();
																				using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5))
																				{
																					bitMapFromFile2.Save(stream2, ImageFormat.Png);
																				}
																				int iDiaX = Conversions.ToInteger(dia[3]);
																				int iDiaY = Conversions.ToInteger(dia[4]);
																				Parallel.For(0, CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
																				{
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																					{
																						CS$<>8__locals1.$VB$Local_eCancel = true;
																						loopstate.Stop();
																					}
																					while (PublicModule.bWaitCancelAsync)
																					{
																						Thread.Sleep(500);
																						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																						{
																							CS$<>8__locals1.$VB$Local_eCancel = true;
																							loopstate.Stop();
																						}
																					}
																					string text6 = Conversions.ToString(CS$<>8__locals3.$VB$Local_fgaliasName[ims]);
																					Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																					Graphics graphics = Graphics.FromImage(bitmap);
																					graphics.Clear(Color.Transparent);
																					MemoryStream $VB$Local_stream = stream1;
																					Bitmap bitmap2;
																					lock ($VB$Local_stream)
																					{
																						bitmap2 = (Bitmap)Image.FromStream(stream1);
																						graphics.DrawImage(bitmap2, iDaX, iDaY, bitmap2.Width, bitmap2.Height);
																					}
																					bitmap2 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap[ims]);
																					graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
																					MemoryStream $VB$Local_stream2 = stream2;
																					lock ($VB$Local_stream2)
																					{
																						bitmap2 = (Bitmap)Image.FromStream(stream2);
																						graphics.DrawImage(bitmap2, iDiaX, iDiaY, bitmap2.Width, bitmap2.Height);
																					}
																					graphics.Dispose();
																					string sSavePath = string.Concat(new string[]
																					{
																						CS$<>8__locals3.$VB$Local_fullBasepath,
																						"_",
																						CS$<>8__locals4.$VB$Local_da[0],
																						"_",
																						dia[1],
																						"_",
																						text6
																					});
																					PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
																					Interlocked.Add(ref PublicModule.iBuild, 1);
																					bitmap2.Dispose();
																					bitmap.Dispose();
																					CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																					Thread.Sleep(PublicModule.iThreadWaitTime);
																				});
																				stream2.Dispose();
																			}
																		}
																	}((string[])a0, a1);
																});
																if (0 == iFind)
																{
																	Parallel.For(0, CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
																	{
																		if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			CS$<>8__locals1.$VB$Local_eCancel = true;
																			loopstate.Stop();
																		}
																		while (PublicModule.bWaitCancelAsync)
																		{
																			Thread.Sleep(500);
																			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																			{
																				CS$<>8__locals1.$VB$Local_eCancel = true;
																				loopstate.Stop();
																			}
																		}
																		string text5 = Conversions.ToString(CS$<>8__locals3.$VB$Local_fgaliasName[ims]);
																		Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																		Graphics graphics = Graphics.FromImage(bitmap);
																		graphics.Clear(Color.Transparent);
																		MemoryStream $VB$Local_stream = stream1;
																		Bitmap bitmap2;
																		lock ($VB$Local_stream)
																		{
																			bitmap2 = (Bitmap)Image.FromStream(stream1);
																			graphics.DrawImage(bitmap2, iDaX, iDaY, bitmap2.Width, bitmap2.Height);
																		}
																		bitmap2 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap[ims]);
																		graphics.DrawImage(bitmap2, 0, 0, bitmap2.Width, bitmap2.Height);
																		graphics.Dispose();
																		string sSavePath = string.Concat(new string[]
																		{
																			CS$<>8__locals3.$VB$Local_fullBasepath,
																			"_",
																			CS$<>8__locals4.$VB$Local_da[0],
																			"_",
																			text5
																		});
																		if (7 < CS$<>8__locals4.$VB$Local_da.GetLength(0) && Strings.InStr(1, CS$<>8__locals4.$VB$Local_da[7], "/", CompareMethod.Binary) > 0)
																		{
																			sSavePath = string.Concat(new string[]
																			{
																				CS$<>8__locals3.$VB$Local_fullBasepath,
																				"_",
																				CS$<>8__locals4.$VB$Local_da[0],
																				"_",
																				CS$<>8__locals4.$VB$Local_da[7].Replace("/", "_"),
																				"_",
																				text5
																			});
																		}
																		PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
																		Interlocked.Add(ref PublicModule.iBuild, 1);
																		bitmap2.Dispose();
																		bitmap.Dispose();
																		CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																		Thread.Sleep(PublicModule.iThreadWaitTime);
																	});
																}
																stream1.Dispose();
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
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_fgaliasAndfgnameBitmap.Clear();
												CS$<>8__locals3.$VB$Local_fgaliasName.Clear();
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000169AC File Offset: 0x00014BAC
		public static bool X_info_X_txt_ddfa(ref Form1 myForm1)
		{
			BW2_three._Closure$__117 CS$<>8__locals1 = new BW2_three._Closure$__117();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				CS$<>8__locals1.$VB$Local_po = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__117._Closure$__118 CS$<>8__locals2 = new BW2_three._Closure$__117._Closure$__118(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_75 = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						CS$<>8__locals1.$VB$Local_bas_name = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_bas_name, "_info", CompareMethod.Binary) > 0)
						{
							CS$<>8__locals1.$VB$Local_base_info_path = text;
							CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
							if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
							{
								PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
								Parallel.ForEach<string>(array, delegate(string path1)
								{
									if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
									{
										string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
										if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_bas_name.Replace("_info", ""), CompareMethod.Binary) > 0)
										{
											ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
											lock ($VB$Local_sameTxtArr)
											{
												CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
											}
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(path1);
											}
										}
									}
								});
								if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
								{
									try
									{
										IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three._Closure$__117._Closure$__118._Closure$__119 CS$<>8__locals3 = new BW2_three._Closure$__117._Closure$__118._Closure$__119(CS$<>8__locals3);
											string text2 = Conversions.ToString(enumerator.Current);
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_75 = CS$<>8__locals1;
											Interlocked.Add(ref PublicModule.iNow, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
												ArrayList arrayList3 = new ArrayList();
												ArrayList arrayList4 = new ArrayList();
												CS$<>8__locals3.$VB$Local_faceArr = new ArrayList();
												ArrayList arrayList5 = new ArrayList();
												CS$<>8__locals3.$VB$Local_strTemp = string.Empty;
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
																CS$<>8__locals3.$VB$Local_strTemp = array3[3];
																array4[1] = CS$<>8__locals3.$VB$Local_strTemp;
																string $VB$Local_strTemp = CS$<>8__locals3.$VB$Local_strTemp;
																bool bFollowUp = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr = kirikiri2_fun.getLayerArr($VB$Local_strTemp, ref arrayList, bFollowUp, ref arrayList6);
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
																CS$<>8__locals3.$VB$Local_strTemp = array3[4];
																array5[7] = CS$<>8__locals3.$VB$Local_strTemp;
																string $VB$Local_strTemp2 = CS$<>8__locals3.$VB$Local_strTemp;
																bool bFollowUp2 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr2 = kirikiri2_fun.getLayerArr($VB$Local_strTemp2, ref arrayList, bFollowUp2, ref arrayList6);
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
																CS$<>8__locals3.$VB$Local_strTemp = array3[3];
																array6[6] = CS$<>8__locals3.$VB$Local_strTemp;
																string $VB$Local_strTemp3 = CS$<>8__locals3.$VB$Local_strTemp;
																bool bFollowUp3 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr3 = kirikiri2_fun.getLayerArr($VB$Local_strTemp3, ref arrayList, bFollowUp3, ref arrayList6);
																array6[1] = layerArr3.layer_id;
																array6[2] = layerArr3.left;
																array6[3] = layerArr3.top;
																array6[4] = layerArr3.width;
																array6[5] = layerArr3.height;
																CS$<>8__locals3.$VB$Local_faceArr.Add(array6);
															}
															else if (0 == string.Compare(array3[0], "add", StringComparison.Ordinal))
															{
																string[] array7 = new string[7];
																array7[0] = array3[1];
																CS$<>8__locals3.$VB$Local_strTemp = array3[2];
																array7[6] = CS$<>8__locals3.$VB$Local_strTemp;
																string $VB$Local_strTemp4 = CS$<>8__locals3.$VB$Local_strTemp;
																bool bFollowUp4 = false;
																ArrayList arrayList6 = null;
																kirikiri2_fun.kirikiri2DefTxt layerArr4 = kirikiri2_fun.getLayerArr($VB$Local_strTemp4, ref arrayList, bFollowUp4, ref arrayList6);
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
												CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
												CS$<>8__locals3.$VB$Local_diffArrBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_diffArrName = new ArrayList();
												ArrayList arrayList7 = new ArrayList();
												string text3 = string.Empty;
												kirikiri2_compare_group_layer_id_v1 comparer = new kirikiri2_compare_group_layer_id_v1();
												arrayList4.Sort(comparer);
												try
												{
													foreach (object obj2 in arrayList4)
													{
														string[] array8 = (string[])obj2;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array8[0]))
														{
															if (0 != string.Compare(array8[0] + array8[1], text3, StringComparison.Ordinal) && Strings.InStr(1, array8[7], "$", CompareMethod.Binary) <= 0)
															{
																text3 = array8[0] + array8[1];
																if (!PublicModule.canFindSameInArrayList(ref arrayList7, text3))
																{
																	arrayList7.Add(text3);
																	Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																	Graphics graphics = Graphics.FromImage(bitmap);
																	graphics.Clear(Color.Transparent);
																	bool flag = true;
																	string text4 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[2]);
																	if (File.Exists(text4))
																	{
																		PublicModule.files2.Add(text4);
																		Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4);
																		graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(array8[3]), Conversions.ToInteger(array8[4]), bitMapFromFile.Width, bitMapFromFile.Height);
																		ArrayList arrayList8 = new ArrayList();
																		try
																		{
																			foreach (object obj3 in arrayList4)
																			{
																				string[] array9 = (string[])obj3;
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					return true;
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
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
																								if (!PublicModule.canFindSameInArrayList(ref arrayList8, text5))
																								{
																									arrayList8.Add(text5);
																								}
																							}
																						}
																						else
																						{
																							string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array9[2]);
																							if (File.Exists(text6))
																							{
																								arrayList7.Add(array9[0] + array9[1]);
																								PublicModule.files2.Add(text6);
																								Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text6);
																								graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																								bitMapFromFile2.Dispose();
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
																					Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
																					Graphics graphics2 = Graphics.FromImage(bitmap2);
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
																									CS$<>8__locals3.$VB$Local_strTemp = array11[0];
																									if (Strings.InStr(1, CS$<>8__locals3.$VB$Local_strTemp, "/", CompareMethod.Binary) > 0)
																									{
																										array11 = CS$<>8__locals3.$VB$Local_strTemp.Split(new char[]
																										{
																											'/'
																										});
																										CS$<>8__locals3.$VB$Local_strTemp = array11.Last<string>();
																									}
																									text7 = string.Format("{0}_{1}_{2}", array10[0], array10[1], CS$<>8__locals3.$VB$Local_strTemp);
																									string text9 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array10[2]);
																									if (File.Exists(text9))
																									{
																										PublicModule.files2.Add(text9);
																										Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text9);
																										graphics2.DrawImage(bitMapFromFile3, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitMapFromFile3.Width, bitMapFromFile3.Height);
																										bitMapFromFile3.Dispose();
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
																					bitmap2.Save(memoryStream2, ImageFormat.Png);
																					CS$<>8__locals3.$VB$Local_diffArrBitmap.Add(memoryStream2);
																					string[] value2 = new string[]
																					{
																						array8[0],
																						text7
																					};
																					CS$<>8__locals3.$VB$Local_diffArrName.Add(value2);
																					bitmap2.Dispose();
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
																		bitMapFromFile.Dispose();
																	}
																	graphics.Dispose();
																	if (flag)
																	{
																		MemoryStream memoryStream3 = new MemoryStream();
																		bitmap.Save(memoryStream3, ImageFormat.Png);
																		CS$<>8__locals3.$VB$Local_diffArrBitmap.Add(memoryStream3);
																		string[] value3 = new string[]
																		{
																			array8[0],
																			string.Format("{0}_{1}", array8[0], array8[1])
																		};
																		CS$<>8__locals3.$VB$Local_diffArrName.Add(value3);
																	}
																	bitmap.Dispose();
																	CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																	Thread.Sleep(PublicModule.iThreadWaitTime);
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
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array12[0]))
														{
															if (Strings.InStr(1, array12[1], "$", CompareMethod.Binary) <= 0 && 0 != string.Compare(array12[0] + array12[1], text3, StringComparison.Ordinal))
															{
																text3 = array12[0] + array12[1];
																if (!PublicModule.canFindSameInArrayList(ref arrayList7, text3))
																{
																	arrayList7.Add(text3);
																	Bitmap bitmap3 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																	Graphics graphics3 = Graphics.FromImage(bitmap3);
																	graphics3.Clear(Color.Transparent);
																	string text10 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array12[2]);
																	if (File.Exists(text10))
																	{
																		PublicModule.files2.Add(text10);
																		using (Bitmap bitMapFromFile4 = PublicModule.getBitMapFromFile(text10))
																		{
																			graphics3.DrawImage(bitMapFromFile4, Conversions.ToInteger(array12[3]), Conversions.ToInteger(array12[4]), bitMapFromFile4.Width, bitMapFromFile4.Height);
																		}
																		try
																		{
																			foreach (object obj6 in arrayList3)
																			{
																				string[] array13 = (string[])obj6;
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					return true;
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																					{
																						return true;
																					}
																				}
																				if (!string.IsNullOrWhiteSpace(array13[0]))
																				{
																					if (Strings.InStr(1, array13[1], "$", CompareMethod.Binary) <= 0 && 0 == string.Compare(array12[0], array13[0], StringComparison.Ordinal) && 0 != string.Compare(array12[1], array13[1], StringComparison.Ordinal))
																					{
																						arrayList7.Add(array13[0] + array13[1]);
																						string text11 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array13[2]);
																						if (File.Exists(text11))
																						{
																							PublicModule.files2.Add(text11);
																							using (Bitmap bitMapFromFile5 = PublicModule.getBitMapFromFile(text11))
																							{
																								graphics3.DrawImage(bitMapFromFile5, Conversions.ToInteger(array13[3]), Conversions.ToInteger(array13[4]), bitMapFromFile5.Width, bitMapFromFile5.Height);
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
																	bitmap3.Save(memoryStream4, ImageFormat.Png);
																	arrayList9.Add(memoryStream4);
																	arrayList10.Add(array12[0]);
																	bitmap3.Dispose();
																	CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																	Thread.Sleep(PublicModule.iThreadWaitTime);
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
													BW2_three._Closure$__117._Closure$__118._Closure$__119._Closure$__120 CS$<>8__locals4 = new BW2_three._Closure$__117._Closure$__118._Closure$__119._Closure$__120(CS$<>8__locals4);
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77 = CS$<>8__locals3;
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75 = CS$<>8__locals1;
													Interlocked.Add(ref PublicModule.iNow, 1);
													if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
													{
														return true;
													}
													while (PublicModule.bWaitCancelAsync)
													{
														Thread.Sleep(500);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
													}
													CS$<>8__locals4.$VB$Local_stream1 = (MemoryStream)arrayList9[j];
													CS$<>8__locals4.$VB$Local_sCloth = Conversions.ToString(arrayList10[j]);
													Parallel.For(0, CS$<>8__locals3.$VB$Local_diffArrBitmap.Count, CS$<>8__locals1.$VB$Local_po, delegate(int ims, ParallelLoopState loopstate)
													{
														if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_eCancel = true;
															loopstate.Stop();
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_eCancel = true;
																loopstate.Stop();
															}
														}
														string[] fMName = (string[])CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_diffArrName[ims];
														Bitmap daBitmap = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_diffArrBitmap[ims]);
														if (0 == string.Compare(CS$<>8__locals4.$VB$Local_sCloth, fMName[0], StringComparison.Ordinal))
														{
															Parallel.ForEach<object>(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_faceArr.ToArray(), CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
															{
																delegate(string[] fa, ParallelLoopState loopstate2)
																{
																	Interlocked.Add(ref PublicModule.iNow, 1);
																	if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.CancellationPending)
																	{
																		CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_eCancel = true;
																		loopstate2.Stop();
																	}
																	while (PublicModule.bWaitCancelAsync)
																	{
																		Thread.Sleep(500);
																		if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_eCancel = true;
																			loopstate2.Stop();
																		}
																	}
																	if (string.IsNullOrWhiteSpace(fa[0]))
																	{
																		return;
																	}
																	string text12 = PublicModule.searchBitmapWithExt(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_fullBasepath, "_" + fa[1]);
																	if (File.Exists(text12))
																	{
																		PublicModule.files2.Add(text12);
																		int x = Conversions.ToInteger(fa[2]);
																		int y = Conversions.ToInteger(fa[3]);
																		Bitmap bitmap4 = new Bitmap(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_iW, CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_iH, PixelFormat.Format32bppArgb);
																		Graphics graphics4 = Graphics.FromImage(bitmap4);
																		graphics4.Clear(Color.Transparent);
																		MemoryStream $VB$Local_stream = CS$<>8__locals4.$VB$Local_stream1;
																		Bitmap bitmap5;
																		lock ($VB$Local_stream)
																		{
																			bitmap5 = (Bitmap)Image.FromStream(CS$<>8__locals4.$VB$Local_stream1);
																			graphics4.DrawImage(bitmap5, 0, 0, bitmap5.Width, bitmap5.Height);
																		}
																		bitmap5 = PublicModule.getBitMapFromFile(text12);
																		graphics4.DrawImage(bitmap5, x, y, bitmap5.Width, bitmap5.Height);
																		bitmap5.Dispose();
																		Bitmap $VB$Local_daBitmap = daBitmap;
																		lock ($VB$Local_daBitmap)
																		{
																			graphics4.DrawImage(daBitmap, 0, 0, daBitmap.Width, daBitmap.Height);
																		}
																		graphics4.Dispose();
																		string text13 = fa[0];
																		if (Strings.InStr(1, fa[6], "/", CompareMethod.Binary) > 0)
																		{
																			text13 = fa[6].Split(new char[]
																			{
																				'/'
																			})[0] + "_" + fa[0];
																		}
																		string sSavePath = string.Concat(new string[]
																		{
																			CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_77.$VB$Local_fullBasepath,
																			"_",
																			fMName[1],
																			"_",
																			text13
																		});
																		PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
																		Interlocked.Add(ref PublicModule.iBuild, 1);
																		bitmap5.Dispose();
																		bitmap4.Dispose();
																		CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																		Thread.Sleep(PublicModule.iThreadWaitTime);
																	}
																}((string[])a0, a1);
															});
														}
														daBitmap.Dispose();
													});
													CS$<>8__locals4.$VB$Local_stream1.Dispose();
												}
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_diffArrBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_diffArrBitmap.Clear();
												CS$<>8__locals3.$VB$Local_diffArrName.Clear();
												Parallel.ForEach<object>(arrayList9.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												arrayList10.Clear();
												arrayList10.Clear();
												Parallel.ForEach<object>(arrayList3.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
												{
													delegate(string[] da, ParallelLoopState loopstate)
													{
														if (Strings.InStr(1, da[1], "$", CompareMethod.Binary) > 0)
														{
															string[] array14 = da[1].Split(new char[]
															{
																'$'
															});
															CS$<>8__locals3.$VB$Local_strTemp = array14[0];
															if (Strings.InStr(1, CS$<>8__locals3.$VB$Local_strTemp, "/", CompareMethod.Binary) > 0)
															{
																array14 = CS$<>8__locals3.$VB$Local_strTemp.Split(new char[]
																{
																	'/'
																});
																CS$<>8__locals3.$VB$Local_strTemp = array14.Last<string>();
															}
															string text12 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + da[2]);
															if (File.Exists(text12))
															{
																PublicModule.files2.Add(text12);
																Bitmap bitmap4 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																Graphics graphics4 = Graphics.FromImage(bitmap4);
																graphics4.Clear(Color.Transparent);
																using (Bitmap bitMapFromFile6 = PublicModule.getBitMapFromFile(text12))
																{
																	graphics4.DrawImage(bitMapFromFile6, Conversions.ToInteger(da[3]), Conversions.ToInteger(da[4]), bitMapFromFile6.Width, bitMapFromFile6.Height);
																}
																graphics4.Dispose();
																string sSavePath = string.Concat(new string[]
																{
																	CS$<>8__locals3.$VB$Local_fullBasepath,
																	"_",
																	da[0],
																	"_",
																	CS$<>8__locals3.$VB$Local_strTemp
																});
																PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
																Interlocked.Add(ref PublicModule.iBuild, 1);
																bitmap4.Dispose();
															}
														}
														CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
														Thread.Sleep(PublicModule.iThreadWaitTime);
													}((string[])a0, a1);
												});
												Parallel.ForEach<object>(arrayList5.ToArray(), CS$<>8__locals1.$VB$Local_po, delegate(object a0, ParallelLoopState a1)
												{
													delegate(string[] aA, ParallelLoopState loopstate)
													{
														Interlocked.Add(ref PublicModule.iNow, 1);
														string text12 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + aA[1]);
														if (File.Exists(text12))
														{
															PublicModule.files2.Add(text12);
															Bitmap bitmap4 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
															Graphics graphics4 = Graphics.FromImage(bitmap4);
															graphics4.Clear(Color.Transparent);
															using (Bitmap bitMapFromFile6 = PublicModule.getBitMapFromFile(text12))
															{
																graphics4.DrawImage(bitMapFromFile6, Conversions.ToInteger(aA[2]), Conversions.ToInteger(aA[3]), bitMapFromFile6.Width, bitMapFromFile6.Height);
															}
															graphics4.Dispose();
															string sSavePath = CS$<>8__locals3.$VB$Local_fullBasepath + "_" + aA[0];
															PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
															Interlocked.Add(ref PublicModule.iBuild, 1);
															bitmap4.Dispose();
														}
														CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_75.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
														Thread.Sleep(PublicModule.iThreadWaitTime);
													}((string[])a0, a1);
												});
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00017B3C File Offset: 0x00015D3C
		public static bool X_info_X_txt_df(ref Form1 myForm1)
		{
			BW2_three._Closure$__122 CS$<>8__locals1 = new BW2_three._Closure$__122();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__122._Closure$__123 CS$<>8__locals2 = new BW2_three._Closure$__122._Closure$__123(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_7A = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						CS$<>8__locals1.$VB$Local_bas_name = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_bas_name, "_info", CompareMethod.Binary) > 0)
						{
							CS$<>8__locals1.$VB$Local_base_info_path = text;
							CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
							if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
							{
								PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
								Parallel.ForEach<string>(array, delegate(string path1)
								{
									if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
									{
										string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
										if (Strings.InStr(1, fileNameWithoutExtension2, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_bas_name.Replace("_info", ""), CompareMethod.Binary) > 0)
										{
											ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
											lock ($VB$Local_sameTxtArr)
											{
												CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
											}
											ArrayList files3 = PublicModule.files2;
											lock (files3)
											{
												PublicModule.files2.Add(path1);
											}
										}
									}
								});
								if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
								{
									try
									{
										IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three._Closure$__122._Closure$__123._Closure$__124 CS$<>8__locals3 = new BW2_three._Closure$__122._Closure$__123._Closure$__124(CS$<>8__locals3);
											string text2 = Conversions.ToString(enumerator.Current);
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_7A = CS$<>8__locals1;
											Interlocked.Add(ref PublicModule.iNow, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref CS$<>8__locals3.$VB$Local_iW, ref CS$<>8__locals3.$VB$Local_iH))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
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
												CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
												CS$<>8__locals3.$VB$Local_faceBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_faceName = new ArrayList();
												string text4 = string.Empty;
												try
												{
													foreach (object obj2 in arrayList4)
													{
														string[] array7 = (string[])obj2;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals1.$VB$Local_eCancel = true;
															break;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals1.$VB$Local_eCancel = true;
																goto IL_74C;
															}
														}
														if (!string.IsNullOrWhiteSpace(array7[0]))
														{
															if (0 != string.Compare(array7[0], text4, StringComparison.Ordinal))
															{
																Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																Graphics graphics = Graphics.FromImage(bitmap);
																graphics.Clear(Color.Transparent);
																string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array7[1]);
																if (File.Exists(text5))
																{
																	ArrayList files = PublicModule.files2;
																	lock (files)
																	{
																		PublicModule.files2.Add(text5);
																	}
																	Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text5);
																	graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(array7[2]), Conversions.ToInteger(array7[3]), bitMapFromFile.Width, bitMapFromFile.Height);
																	try
																	{
																		foreach (object obj3 in arrayList4)
																		{
																			string[] array8 = (string[])obj3;
																			if (0 == string.Compare(array7[0], array8[0], StringComparison.Ordinal) && 0 != string.Compare(array7[6], array8[6], StringComparison.Ordinal))
																			{
																				text4 = array8[0];
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[1]);
																				if (File.Exists(text6))
																				{
																					ArrayList files2 = PublicModule.files2;
																					lock (files2)
																					{
																						PublicModule.files2.Add(text6);
																					}
																					Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text6);
																					graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																					bitMapFromFile2.Dispose();
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
																	bitMapFromFile.Dispose();
																	graphics.Dispose();
																	MemoryStream memoryStream = new MemoryStream();
																	bitmap.Save(memoryStream, ImageFormat.Png);
																	ArrayList $VB$Local_faceBitmap = CS$<>8__locals3.$VB$Local_faceBitmap;
																	lock ($VB$Local_faceBitmap)
																	{
																		CS$<>8__locals3.$VB$Local_faceBitmap.Add(memoryStream);
																	}
																	ArrayList $VB$Local_faceName = CS$<>8__locals3.$VB$Local_faceName;
																	lock ($VB$Local_faceName)
																	{
																		CS$<>8__locals3.$VB$Local_faceName.Add(array7[0]);
																	}
																	bitmap.Dispose();
																}
																CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																Thread.Sleep(PublicModule.iThreadWaitTime);
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
													foreach (object obj4 in arrayList3)
													{
														string[] array9 = (string[])obj4;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array9[0]))
														{
															if (0 != string.Compare(array9[0] + array9[1], text4, StringComparison.Ordinal) && Strings.InStr(1, array9[7], "$", CompareMethod.Binary) <= 0)
															{
																text4 = array9[0] + array9[1];
																if (!PublicModule.canFindSameInArrayList(ref arrayList9, text4))
																{
																	arrayList9.Add(text4);
																	Bitmap bitmap2 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
																	Graphics graphics2 = Graphics.FromImage(bitmap2);
																	graphics2.Clear(Color.Transparent);
																	bool flag5 = true;
																	string text7 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array9[2]);
																	if (File.Exists(text7))
																	{
																		PublicModule.files2.Add(text7);
																		Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text7);
																		graphics2.DrawImage(bitMapFromFile3, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitMapFromFile3.Width, bitMapFromFile3.Height);
																		ArrayList arrayList10 = new ArrayList();
																		try
																		{
																			foreach (object obj5 in arrayList3)
																			{
																				string[] array10 = (string[])obj5;
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					return true;
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
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
																								if (!PublicModule.canFindSameInArrayList(ref arrayList10, text8))
																								{
																									arrayList10.Add(text8);
																								}
																							}
																						}
																						else
																						{
																							string text9 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array10[2]);
																							if (File.Exists(text9))
																							{
																								arrayList9.Add(array10[0] + array10[1]);
																								PublicModule.files2.Add(text9);
																								Bitmap bitMapFromFile4 = PublicModule.getBitMapFromFile(text9);
																								graphics2.DrawImage(bitMapFromFile4, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitMapFromFile4.Width, bitMapFromFile4.Height);
																								bitMapFromFile4.Dispose();
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
																			bitmap2.Save(memoryStream2, ImageFormat.Png);
																			try
																			{
																				foreach (object value in arrayList10)
																				{
																					string strA = Conversions.ToString(value);
																					Bitmap bitmap3 = (Bitmap)Image.FromStream(memoryStream2);
																					Graphics graphics3 = Graphics.FromImage(bitmap3);
																					string text10 = string.Format("{0}_{1}", array9[0], array9[1]);
																					try
																					{
																						foreach (object obj6 in arrayList3)
																						{
																							string[] array11 = (string[])obj6;
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
																									string text12 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array11[2]);
																									if (File.Exists(text12))
																									{
																										PublicModule.files2.Add(text12);
																										Bitmap bitMapFromFile5 = PublicModule.getBitMapFromFile(text12);
																										graphics3.DrawImage(bitMapFromFile5, Conversions.ToInteger(array11[3]), Conversions.ToInteger(array11[4]), bitMapFromFile5.Width, bitMapFromFile5.Height);
																										bitMapFromFile5.Dispose();
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
																					bitmap3.Save(memoryStream3, ImageFormat.Png);
																					arrayList7.Add(memoryStream3);
																					arrayList8.Add(new string[]
																					{
																						array9[0],
																						text10
																					});
																					bitmap3.Dispose();
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
																		bitMapFromFile3.Dispose();
																	}
																	graphics2.Dispose();
																	if (flag5)
																	{
																		MemoryStream memoryStream4 = new MemoryStream();
																		bitmap2.Save(memoryStream4, ImageFormat.Png);
																		arrayList7.Add(memoryStream4);
																		arrayList8.Add(new string[]
																		{
																			array9[0],
																			string.Format("{0}_{1}", array9[0], array9[1])
																		});
																	}
																	bitmap2.Dispose();
																	CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																	Thread.Sleep(PublicModule.iThreadWaitTime);
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
												PublicModule.iMaxToBW = arrayList7.Count + CS$<>8__locals3.$VB$Local_faceBitmap.Count;
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
												int num = 0;
												int num2 = arrayList7.Count - 1;
												for (int j = num; j <= num2; j++)
												{
													BW2_three._Closure$__122._Closure$__123._Closure$__124._Closure$__125 CS$<>8__locals4 = new BW2_three._Closure$__122._Closure$__123._Closure$__124._Closure$__125(CS$<>8__locals4);
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C = CS$<>8__locals3;
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A = CS$<>8__locals1;
													Interlocked.Add(ref PublicModule.iNow, 1);
													if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
													{
														return true;
													}
													while (PublicModule.bWaitCancelAsync)
													{
														Thread.Sleep(500);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
													}
													CS$<>8__locals4.$VB$Local_fMName = (string[])arrayList8[j];
													CS$<>8__locals4.$VB$Local_stream1 = (MemoryStream)arrayList7[j];
													Parallel.For(0, CS$<>8__locals3.$VB$Local_faceBitmap.Count, parallelOptions, delegate(int ifb, ParallelLoopState loopstate)
													{
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_eCancel = true;
															loopstate.Stop();
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_eCancel = true;
																loopstate.Stop();
															}
														}
														string text13 = Conversions.ToString(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C.$VB$Local_faceName[ifb]);
														Bitmap bitmap4 = new Bitmap(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C.$VB$Local_iW, CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C.$VB$Local_iH, PixelFormat.Format32bppArgb);
														Graphics graphics4 = Graphics.FromImage(bitmap4);
														graphics4.Clear(Color.Transparent);
														MemoryStream $VB$Local_stream = CS$<>8__locals4.$VB$Local_stream1;
														Bitmap bitmap5;
														lock ($VB$Local_stream)
														{
															bitmap5 = (Bitmap)Image.FromStream(CS$<>8__locals4.$VB$Local_stream1);
															graphics4.DrawImage(bitmap5, 0, 0, bitmap5.Width, bitmap5.Height);
														}
														bitmap5 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C.$VB$Local_faceBitmap[ifb]);
														graphics4.DrawImage(bitmap5, 0, 0, bitmap5.Width, bitmap5.Height);
														graphics4.Dispose();
														string sSavePath = string.Concat(new string[]
														{
															CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7C.$VB$Local_fullBasepath,
															"_",
															CS$<>8__locals4.$VB$Local_fMName[1],
															"_",
															text13
														});
														PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
														Interlocked.Add(ref PublicModule.iBuild, 1);
														bitmap5.Dispose();
														bitmap4.Dispose();
														CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
														Thread.Sleep(PublicModule.iThreadWaitTime);
													});
													CS$<>8__locals4.$VB$Local_stream1.Dispose();
												}
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_faceBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_faceBitmap.Clear();
												CS$<>8__locals3.$VB$Local_faceName.Clear();
												Parallel.ForEach<object>(arrayList7.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												arrayList7.Clear();
												arrayList8.Clear();
												Parallel.ForEach<object>(arrayList5.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
												{
													delegate(string[] aA, ParallelLoopState loopstate)
													{
														Interlocked.Add(ref PublicModule.iNow, 1);
														string text13 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + aA[1]);
														if (File.Exists(text13))
														{
															PublicModule.files2.Add(text13);
															Bitmap bitmap4 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PixelFormat.Format32bppArgb);
															Graphics graphics4 = Graphics.FromImage(bitmap4);
															graphics4.Clear(Color.Transparent);
															using (Bitmap bitMapFromFile6 = PublicModule.getBitMapFromFile(text13))
															{
																graphics4.DrawImage(bitMapFromFile6, Conversions.ToInteger(aA[2]), Conversions.ToInteger(aA[3]), bitMapFromFile6.Width, bitMapFromFile6.Height);
															}
															graphics4.Dispose();
															string sSavePath = CS$<>8__locals3.$VB$Local_fullBasepath + "_" + aA[0];
															PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
															Interlocked.Add(ref PublicModule.iBuild, 1);
															bitmap4.Dispose();
														}
														CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_7A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
														Thread.Sleep(PublicModule.iThreadWaitTime);
													}((string[])a0, a1);
												});
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00018BB4 File Offset: 0x00016DB4
		public static bool ChangeImageByTxt(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			foreach (string text in array)
			{
				Interlocked.Add(ref PublicModule.iNow, 1);
				if (BackgroundWorker2.CancellationPending)
				{
					return true;
				}
				while (PublicModule.bWaitCancelAsync)
				{
					Thread.Sleep(500);
					if (BackgroundWorker2.CancellationPending)
					{
						return true;
					}
				}
				BackgroundWorker2.ReportProgress(0);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				if (Strings.InStr(1, fileNameWithoutExtension, "_info", CompareMethod.Binary) <= 0)
				{
					string text2 = text;
					if (File.Exists(text2))
					{
						PublicModule.files2.Add(text2);
						ArrayList defineTxt = new ArrayList();
						int iH;
						int iW;
						if (kirikiri2_fun.readTxtToArr(text2, ref defineTxt, ref iW, ref iH))
						{
							string fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
							Parallel.ForEach<object>(defineTxt.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
							{
								kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt;
								delegate(kirikiri2_fun.kirikiri2DefTxt kr2deftxt, ParallelLoopState loopstate)
								{
									Interlocked.Add(ref PublicModule.iNow, 1);
									if (BackgroundWorker2.CancellationPending)
									{
										eCancel = true;
										loopstate.Stop();
									}
									while (PublicModule.bWaitCancelAsync)
									{
										Thread.Sleep(500);
										if (BackgroundWorker2.CancellationPending)
										{
											eCancel = true;
											loopstate.Stop();
										}
									}
									if (string.IsNullOrWhiteSpace(kr2deftxt.layer_type))
									{
										return;
									}
									if (Operators.CompareString("2", kr2deftxt.layer_type, false) == 0)
									{
										return;
									}
									if (string.IsNullOrWhiteSpace(kr2deftxt.group_layer_id))
									{
										string text3 = PublicModule.searchBitmapWithExt(fullBasepath, "_" + kr2deftxt.layer_id);
										if (File.Exists(text3))
										{
											PublicModule.files2.Add(text3);
											Bitmap bitmap = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
											Graphics graphics = Graphics.FromImage(bitmap);
											graphics.Clear(Color.Transparent);
											using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text3))
											{
												graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(kr2deftxt.left), Conversions.ToInteger(kr2deftxt.top), bitMapFromFile.Width, bitMapFromFile.Height);
											}
											graphics.Dispose();
											string sSavePath = fullBasepath + "_" + kr2deftxt.name;
											PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
											bitmap.Dispose();
											Interlocked.Add(ref PublicModule.iBuild, 1);
										}
									}
									else
									{
										string text4 = PublicModule.searchBitmapWithExt(fullBasepath, "_" + kr2deftxt.layer_id);
										if (File.Exists(text4))
										{
											PublicModule.files2.Add(text4);
											StringBuilder tempName = new StringBuilder();
											string glid = kr2deftxt.group_layer_id;
											while (!string.IsNullOrEmpty(glid))
											{
												Parallel.ForEach<object>(defineTxt.ToArray(), delegate(object a0, ParallelLoopState a1)
												{
													kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt2;
													delegate(kirikiri2_fun.kirikiri2DefTxt kr2deftxt2, ParallelLoopState loopstate2)
													{
														if (0 == string.Compare(kr2deftxt2.layer_id, glid, StringComparison.Ordinal))
														{
															loopstate2.Break();
															StringBuilder $VB$Local_tempName = tempName;
															lock ($VB$Local_tempName)
															{
																tempName.Insert(0, kr2deftxt2.name + "_");
															}
															if (string.IsNullOrWhiteSpace(kr2deftxt2.group_layer_id))
															{
																glid = string.Empty;
															}
															else
															{
																glid = kr2deftxt2.group_layer_id;
															}
														}
													}((a0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)a0) : kirikiri2DefTxt2, a1);
												});
											}
											Bitmap bitmap2 = new Bitmap(iW, iH, PixelFormat.Format32bppArgb);
											Graphics graphics2 = Graphics.FromImage(bitmap2);
											graphics2.Clear(Color.Transparent);
											using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text4))
											{
												graphics2.DrawImage(bitMapFromFile2, Conversions.ToInteger(kr2deftxt.left), Conversions.ToInteger(kr2deftxt.top), bitMapFromFile2.Width, bitMapFromFile2.Height);
											}
											graphics2.Dispose();
											string sSavePath2 = fullBasepath + "_" + tempName.ToString() + kr2deftxt.name;
											PublicModule.saveBitmapFile(sSavePath2, ref bitmap2, true);
											bitmap2.Dispose();
											Interlocked.Add(ref PublicModule.iBuild, 1);
										}
									}
									BackgroundWorker2.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								}((a0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)a0) : kirikiri2DefTxt, a1);
							});
						}
					}
				}
			}
			PublicModule.sSpecialExt = string.Empty;
			return eCancel;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00018D40 File Offset: 0x00016F40
		public static bool X_info_X_txt_ddfr(ref Form1 myForm1)
		{
			BW2_three._Closure$__129 CS$<>8__locals1 = new BW2_three._Closure$__129();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_three._Closure$__129._Closure$__130 CS$<>8__locals2 = new BW2_three._Closure$__129._Closure$__130(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_81 = CS$<>8__locals1;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
					{
						return true;
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
					}
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						CS$<>8__locals1.$VB$Local_bas_name = Path.GetFileNameWithoutExtension(text);
						if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_bas_name, "_info", CompareMethod.Binary) > 0)
						{
							CS$<>8__locals1.$VB$Local_base_info_path = text;
							CS$<>8__locals2.$VB$Local_sameTxtArr = new ArrayList(10);
							if (File.Exists(CS$<>8__locals1.$VB$Local_base_info_path))
							{
								PublicModule.files2.Add(CS$<>8__locals1.$VB$Local_base_info_path);
								Parallel.ForEach<string>(array, delegate(string path1)
								{
									if (0 != string.Compare(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_81.$VB$Local_base_info_path, path1, StringComparison.Ordinal))
									{
										string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(path1);
										if (Strings.InStr(1, fileNameWithoutExtension2.ToLower(), CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_81.$VB$Local_bas_name.Replace("_info", "").ToLower(), CompareMethod.Binary) > 0)
										{
											ArrayList $VB$Local_sameTxtArr = CS$<>8__locals2.$VB$Local_sameTxtArr;
											lock ($VB$Local_sameTxtArr)
											{
												CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
											}
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(path1);
												return;
											}
										}
										if (Strings.InStr(1, fileNameWithoutExtension2.ToLower(), CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_81.$VB$Local_bas_name.Replace("info", "").ToLower(), CompareMethod.Binary) > 0)
										{
											ArrayList $VB$Local_sameTxtArr2 = CS$<>8__locals2.$VB$Local_sameTxtArr;
											lock ($VB$Local_sameTxtArr2)
											{
												CS$<>8__locals2.$VB$Local_sameTxtArr.Add(path1);
											}
											ArrayList files2 = PublicModule.files2;
											lock (files2)
											{
												PublicModule.files2.Add(path1);
											}
										}
									}
								});
								if (0 < CS$<>8__locals2.$VB$Local_sameTxtArr.Count)
								{
									try
									{
										IEnumerator enumerator = CS$<>8__locals2.$VB$Local_sameTxtArr.GetEnumerator();
										while (enumerator.MoveNext())
										{
											BW2_three._Closure$__129._Closure$__130._Closure$__131 CS$<>8__locals3 = new BW2_three._Closure$__129._Closure$__130._Closure$__131(CS$<>8__locals3);
											string text2 = Conversions.ToString(enumerator.Current);
											Interlocked.Add(ref PublicModule.iNow, 1);
											ArrayList arrayList = new ArrayList();
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text2);
											int width;
											int height;
											if (kirikiri2_fun.readTxtToArr(text2, ref arrayList, ref width, ref height))
											{
												ArrayList arrayList2 = new ArrayList();
												kirikiri2_fun.readBaseInfoToArr(CS$<>8__locals1.$VB$Local_base_info_path, ref arrayList2);
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
												CS$<>8__locals3.$VB$Local_fullBasepath = Path.Combine(Path.GetDirectoryName(text2), fileNameWithoutExtension);
												CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(0);
												CS$<>8__locals3.$VB$Local_faceArrBitmap = new ArrayList();
												CS$<>8__locals3.$VB$Local_faceArrName = new ArrayList();
												ArrayList arrayList9 = new ArrayList();
												try
												{
													IEnumerator enumerator4 = arrayList5.GetEnumerator();
													while (enumerator4.MoveNext())
													{
														BW2_three._Closure$__129._Closure$__130._Closure$__131._Closure$__132 CS$<>8__locals4 = new BW2_three._Closure$__129._Closure$__130._Closure$__131._Closure$__132(CS$<>8__locals4);
														string[] array7 = (string[])enumerator4.Current;
														CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_83 = CS$<>8__locals3;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array7[0]))
														{
															CS$<>8__locals3.$VB$Local_strLastName = array7[0];
															if (!PublicModule.canFindSameInArrayList(ref arrayList9, CS$<>8__locals3.$VB$Local_strLastName))
															{
																arrayList9.Add(CS$<>8__locals3.$VB$Local_strLastName);
																Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
																Graphics graphics = Graphics.FromImage(bitmap);
																graphics.Clear(Color.Transparent);
																try
																{
																	foreach (object obj3 in arrayList5)
																	{
																		string[] array8 = (string[])obj3;
																		Interlocked.Add(ref PublicModule.iNow, 1);
																		if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			return true;
																		}
																		while (PublicModule.bWaitCancelAsync)
																		{
																			Thread.Sleep(500);
																			if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																			{
																				return true;
																			}
																		}
																		if (!string.IsNullOrWhiteSpace(array8[0]))
																		{
																			if (0 == string.Compare(CS$<>8__locals3.$VB$Local_strLastName, array8[0], StringComparison.Ordinal))
																			{
																				string text4 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array8[1]);
																				if (File.Exists(text4))
																				{
																					PublicModule.files2.Add(text4);
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
																						PublicModule.addLog(ex.Message);
																					}
																					if (!flag)
																					{
																						continue;
																					}
																					Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4);
																					graphics.DrawImage(bitMapFromFile, Conversions.ToInteger(array8[2]), Conversions.ToInteger(array8[3]), bitMapFromFile.Width, bitMapFromFile.Height);
																					bitMapFromFile.Dispose();
																				}
																			}
																			CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
																CS$<>8__locals3.$VB$Local_faceArrBitmap.Add(memoryStream);
																CS$<>8__locals4.$VB$Local_sTemp = CS$<>8__locals3.$VB$Local_strLastName;
																Parallel.ForEach<object>(arrayList6.ToArray(), delegate(object a0, ParallelLoopState a1)
																{
																	delegate(string[] sArr, ParallelLoopState loopstate)
																	{
																		if (0 == string.Compare(sArr[0], "face", StringComparison.Ordinal))
																		{
																			string text7 = CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_83.$VB$Local_strLastName;
																			if (Strings.InStr(1, text7, "@", CompareMethod.Binary) > 0)
																			{
																				text7 = text7.Split(new char[]
																				{
																					'@'
																				}).First<string>();
																				if (0 == string.Compare(sArr[2], text7, StringComparison.Ordinal))
																				{
																					loopstate.Break();
																					CS$<>8__locals4.$VB$Local_sTemp = CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_83.$VB$Local_strLastName.Replace(text7, sArr[1]);
																				}
																			}
																			else if (0 == string.Compare(sArr[2], text7, StringComparison.Ordinal))
																			{
																				loopstate.Break();
																				CS$<>8__locals4.$VB$Local_sTemp = sArr[1];
																			}
																		}
																	}((string[])a0, a1);
																});
																CS$<>8__locals3.$VB$Local_faceArrName.Add(CS$<>8__locals4.$VB$Local_sTemp);
																bitmap.Dispose();
																CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
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
														BW2_three._Closure$__129._Closure$__130._Closure$__131._Closure$__133 CS$<>8__locals5 = new BW2_three._Closure$__129._Closure$__130._Closure$__131._Closure$__133(CS$<>8__locals5);
														string[] array9 = (string[])enumerator6.Current;
														Interlocked.Add(ref PublicModule.iNow, 1);
														if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
														{
															return true;
														}
														while (PublicModule.bWaitCancelAsync)
														{
															Thread.Sleep(500);
															if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
															{
																return true;
															}
														}
														if (!string.IsNullOrWhiteSpace(array9[0]))
														{
															MemoryStream memoryStream2 = new MemoryStream();
															Bitmap bitmap2 = new Bitmap(width, height, PixelFormat.Format32bppArgb);
															CS$<>8__locals5.$VB$Local_dressName = array9[0];
															Parallel.ForEach<object>(arrayList6.ToArray(), delegate(object a0, ParallelLoopState a1)
															{
																delegate(string[] sArr, ParallelLoopState loopstate)
																{
																	if (0 == string.Compare(sArr[0], "dress", StringComparison.Ordinal))
																	{
																		string $VB$Local_dressName = CS$<>8__locals5.$VB$Local_dressName;
																		if (0 == string.Compare(sArr[2], $VB$Local_dressName, StringComparison.Ordinal))
																		{
																			loopstate.Break();
																			CS$<>8__locals5.$VB$Local_dressName = sArr[1];
																		}
																	}
																}((string[])a0, a1);
															});
															if (string.IsNullOrWhiteSpace(array9[2]))
															{
																bitmap2.Save(memoryStream2, ImageFormat.Png);
															}
															else
															{
																string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array9[2]);
																if (File.Exists(text5))
																{
																	PublicModule.files2.Add(text5);
																	Interlocked.Add(ref PublicModule.iNow, 1);
																	Graphics graphics2 = Graphics.FromImage(bitmap2);
																	graphics2.Clear(Color.Transparent);
																	using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5))
																	{
																		graphics2.DrawImage(bitMapFromFile2, Conversions.ToInteger(array9[3]), Conversions.ToInteger(array9[4]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																	}
																	graphics2.Dispose();
																	bitmap2.Save(memoryStream2, ImageFormat.Png);
																	CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																}
																else
																{
																	bitmap2.Save(memoryStream2, ImageFormat.Png);
																}
															}
															bitmap2.Dispose();
															try
															{
																foreach (object obj4 in arrayList4)
																{
																	string[] array10 = (string[])obj4;
																	Interlocked.Add(ref PublicModule.iNow, 1);
																	if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																	{
																		return true;
																	}
																	while (PublicModule.bWaitCancelAsync)
																	{
																		Thread.Sleep(500);
																		if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																		{
																			return true;
																		}
																	}
																	if (!string.IsNullOrWhiteSpace(array10[0]))
																	{
																		if (0 == string.Compare(array9[0], array10[0], StringComparison.Ordinal))
																		{
																			MemoryStream stream2 = new MemoryStream();
																			Bitmap bitmap3 = (Bitmap)Image.FromStream(memoryStream2);
																			string diffName = array10[1];
																			Parallel.ForEach<object>(arrayList6.ToArray(), delegate(object a0, ParallelLoopState a1)
																			{
																				delegate(string[] sArr, ParallelLoopState loopstate)
																				{
																					if (0 == string.Compare(sArr[0], "diff", StringComparison.Ordinal))
																					{
																						string $VB$Local_diffName = diffName;
																						if (0 == string.Compare(sArr[2], $VB$Local_diffName, StringComparison.Ordinal))
																						{
																							loopstate.Break();
																							diffName = sArr[1];
																						}
																					}
																				}((string[])a0, a1);
																			});
																			string text6 = PublicModule.searchBitmapWithExt(CS$<>8__locals3.$VB$Local_fullBasepath, "_" + array10[2]);
																			if (File.Exists(text6))
																			{
																				PublicModule.files2.Add(text6);
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				Graphics graphics3 = Graphics.FromImage(bitmap3);
																				graphics3.Clear(Color.Transparent);
																				using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text6))
																				{
																					graphics3.DrawImage(bitMapFromFile3, Conversions.ToInteger(array10[3]), Conversions.ToInteger(array10[4]), bitMapFromFile3.Width, bitMapFromFile3.Height);
																				}
																				graphics3.Dispose();
																				bitmap3.Save(stream2, ImageFormat.Png);
																				CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																			}
																			else
																			{
																				bitmap3.Save(stream2, ImageFormat.Png);
																			}
																			bitmap3.Dispose();
																			Parallel.For(0, CS$<>8__locals3.$VB$Local_faceArrBitmap.Count, parallelOptions, delegate(int iI, ParallelLoopState loopstate)
																			{
																				if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					CS$<>8__locals1.$VB$Local_eCancel = true;
																					loopstate.Stop();
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals1.$VB$Local_BackgroundWorker2.CancellationPending)
																					{
																						CS$<>8__locals1.$VB$Local_eCancel = true;
																						loopstate.Stop();
																					}
																				}
																				MemoryStream $VB$Local_stream = stream2;
																				Bitmap bitmap4;
																				lock ($VB$Local_stream)
																				{
																					bitmap4 = (Bitmap)Image.FromStream(stream2);
																				}
																				Graphics graphics4 = Graphics.FromImage(bitmap4);
																				Bitmap bitmap5 = (Bitmap)Image.FromStream((MemoryStream)CS$<>8__locals3.$VB$Local_faceArrBitmap[iI]);
																				graphics4.DrawImage(bitmap5, 0, 0, bitmap5.Width, bitmap5.Height);
																				bitmap5.Dispose();
																				graphics4.Dispose();
																				string sSavePath = Conversions.ToString(Operators.ConcatenateObject(CS$<>8__locals3.$VB$Local_fullBasepath + "_" + CS$<>8__locals5.$VB$Local_dressName + "_" + diffName + "_", CS$<>8__locals3.$VB$Local_faceArrName[iI]));
																				PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
																				bitmap4.Dispose();
																				Interlocked.Add(ref PublicModule.iBuild, 1);
																				CS$<>8__locals1.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																				Thread.Sleep(PublicModule.iThreadWaitTime);
																			});
																			stream2.Dispose();
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
												Parallel.ForEach<object>(CS$<>8__locals3.$VB$Local_faceArrBitmap.ToArray(), delegate(object a0)
												{
													delegate(MemoryStream ms)
													{
														ms.Dispose();
													}((MemoryStream)a0);
												});
												CS$<>8__locals3.$VB$Local_faceArrBitmap.Clear();
												CS$<>8__locals3.$VB$Local_faceArrName.Clear();
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
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x0400013C RID: 316
		private ArrayList asdFile;

		// Token: 0x0400013D RID: 317
		public static bool triagain = false;

		// Token: 0x0400013E RID: 318
		public static bool utahime = false;

		// Token: 0x0400013F RID: 319
		public static bool gyakuoudou = false;
	}
}
