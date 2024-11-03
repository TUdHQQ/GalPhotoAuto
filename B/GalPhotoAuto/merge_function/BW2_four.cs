using System;
using System.Collections;
using System.ComponentModel;
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
	// Token: 0x0200000D RID: 13
	public class BW2_four
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002390 File Offset: 0x00000590
		public static bool merge_ad_exl6ren_xy(ref Form1 myForm1)
		{
			bool eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool bLDisposable = myForm1.CheckBox3.Checked;
				bool bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] sRight = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(sRight, 0);
				ParallelOptions po = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, po, delegate(string sPathL, ParallelLoopState loopstate)
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
					MemoryStream stream = new MemoryStream();
					string[] strA1 = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(sPathL));
					int iHeight;
					int iWidth;
					PixelFormat pFormat;
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(sPathL))
					{
						iWidth = bitMapFromFile.Width;
						iHeight = bitMapFromFile.Height;
						pFormat = bitMapFromFile.PixelFormat;
						Rectangle rect = new Rectangle(0, 0, iWidth, iHeight);
						BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pFormat);
						Bitmap bitmap = new Bitmap(iWidth, iHeight, bitmapData.Stride, PublicModule.checkPixelFormat(pFormat), bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						bitmap.Save(stream, ImageFormat.Png);
						bitmap.Dispose();
					}
					Parallel.ForEach<string>(sRight, po, delegate(string sr, ParallelLoopState loopstate2)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
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
						Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr);
						int width = bitMapFromFile2.Width;
						int height = bitMapFromFile2.Height;
						PixelFormat pixelFormat = bitMapFromFile2.PixelFormat;
						Rectangle rect2 = new Rectangle(0, 0, width, height);
						BitmapData bitmapData2 = bitMapFromFile2.LockBits(rect2, ImageLockMode.ReadOnly, pixelFormat);
						Bitmap bitmap2 = new Bitmap(width, height, bitmapData2.Stride, PublicModule.checkPixelFormat(pixelFormat), bitmapData2.Scan0);
						bitMapFromFile2.UnlockBits(bitmapData2);
						string[] array2 = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(sr));
						Bitmap bitmap3 = new Bitmap(iWidth, iHeight, PublicModule.checkPixelFormat(pFormat));
						Graphics graphics = Graphics.FromImage(bitmap3);
						graphics.Clear(Color.Transparent);
						MemoryStream $VB$Local_stream = stream;
						lock ($VB$Local_stream)
						{
							graphics.DrawImage(Image.FromStream(stream), 0, 0, iWidth, iHeight);
						}
						graphics.DrawImage(bitmap2, Conversions.ToInteger(array2[1]) - Conversions.ToInteger(strA1[1]), Conversions.ToInteger(array2[2]) - Conversions.ToInteger(strA1[2]), width, height);
						graphics.Dispose();
						string sSavePath = string.Concat(new string[]
						{
							Path.Combine(Path.GetDirectoryName(sr), strA1[0]),
							"_",
							array2[0],
							"+x",
							strA1[1],
							"y",
							strA1[2]
						});
						PublicModule.saveBitmapFile(sSavePath, ref bitmap3, true);
						Interlocked.Add(ref PublicModule.iBuild, 1);
						bitmap2.Dispose();
						bitmap3.Dispose();
						bitMapFromFile2.Dispose();
						if (bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					stream.Dispose();
					if (bLDisposable)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(sPathL);
						}
					}
				});
				return eCancel;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002480 File Offset: 0x00000680
		public static bool merge_ad_exszs_tig2png_dat(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			BackgroundWorker2.ReportProgress(0);
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			string base_dat_name;
			string base_path;
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
				base_dat_name = Path.GetFileNameWithoutExtension(text);
				base_path = Path.GetDirectoryName(text);
				if (File.Exists(text))
				{
					PublicModule.files2.Add(text);
					ArrayList charArr = new ArrayList();
					int[] array3 = asmodean_fun.get_ad_dat_date(text, ref charArr);
					int height = array3[0];
					int iX = array3[1];
					int iY = array3[2];
					int isw = array3[3];
					int ish = array3[4];
					if (0 < charArr.Count)
					{
						string text2 = Path.ChangeExtension(text, "png");
						if (File.Exists(text2))
						{
							PublicModule.files2.Add(text2);
							Interlocked.Add(ref PublicModule.iNow, 1);
							MemoryStream stream1 = new MemoryStream();
							MemoryStream stream2 = new MemoryStream();
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text2))
							{
								int width = bitMapFromFile.Width;
								int height2 = bitMapFromFile.Height;
								Rectangle rect = new Rectangle(0, 0, width, height);
								BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								Bitmap bitmap = new Bitmap(width, height, bitmapData.Stride, PixelFormat.Format32bppArgb, bitmapData.Scan0);
								bitMapFromFile.UnlockBits(bitmapData);
								bitmap.Save(stream1, ImageFormat.Png);
								bitmap.Dispose();
								bitMapFromFile.Save(stream2, ImageFormat.Png);
							}
							Parallel.For(0, charArr.Count, parallelOptions, delegate(int iC, ParallelLoopState loopstate)
							{
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
								int[] array4 = (int[])charArr[iC];
								MemoryStream $VB$Local_stream = stream2;
								Bitmap bitmap2;
								lock ($VB$Local_stream)
								{
									bitmap2 = (Bitmap)Image.FromStream(stream2);
								}
								Rectangle rect2 = new Rectangle(array4[0], array4[1], isw, ish);
								BitmapData bitmapData2 = bitmap2.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
								Bitmap bitmap3 = new Bitmap(isw, ish, bitmapData2.Stride, PixelFormat.Format32bppArgb, bitmapData2.Scan0);
								bitmap2.UnlockBits(bitmapData2);
								MemoryStream $VB$Local_stream2 = stream1;
								Bitmap bitmap4;
								lock ($VB$Local_stream2)
								{
									bitmap4 = (Bitmap)Image.FromStream(stream1);
								}
								Graphics graphics = Graphics.FromImage(bitmap4);
								graphics.DrawImage(bitmap3, iX, iY, isw, ish);
								graphics.Dispose();
								bitmap3.Dispose();
								string sSavePath = Path.Combine(base_path, base_dat_name) + "_" + Conversions.ToString(iC);
								PublicModule.saveBitmapFile(sSavePath, ref bitmap4, true);
								Interlocked.Add(ref PublicModule.iBuild, 1);
								bitmap2.Dispose();
								bitmap4.Dispose();
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							});
							stream2.Dispose();
							stream1.Dispose();
						}
					}
				}
			}
			PublicModule.sSpecialExt = string.Empty;
			return eCancel;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000274C File Offset: 0x0000094C
		public static bool merge_ad_exef2paz_xy(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			BackgroundWorker2.ReportProgress(0);
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				bool perseus = false;
				if (0 == string.Compare(PublicModule.sGameExe, "perseus", StringComparison.OrdinalIgnoreCase))
				{
					perseus = true;
				}
				string[] array2 = array;
				string base_path;
				string base_png_name;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four._Closure$__9._Closure$__10 CS$<>8__locals2 = new BW2_four._Closure$__9._Closure$__10(CS$<>8__locals2);
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
					base_png_name = Path.GetFileNameWithoutExtension(text);
					base_path = Path.GetDirectoryName(text);
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
					{
						CS$<>8__locals2.$VB$Local_samePngBase = Path.Combine(base_path, base_png_name + "+");
						CS$<>8__locals2.$VB$Local_samePngArr = new ArrayList();
						Parallel.ForEach<string>(array, delegate(string thispngfile)
						{
							if (Strings.InStr(1, thispngfile, CS$<>8__locals2.$VB$Local_samePngBase, CompareMethod.Binary) > 0)
							{
								ArrayList $VB$Local_samePngArr = CS$<>8__locals2.$VB$Local_samePngArr;
								lock ($VB$Local_samePngArr)
								{
									CS$<>8__locals2.$VB$Local_samePngArr.Add(thispngfile);
									PublicModule.files2.Add(thispngfile);
								}
							}
						});
						if (0 < CS$<>8__locals2.$VB$Local_samePngArr.Count)
						{
							MemoryStream stream1 = new MemoryStream();
							int iHeight;
							int iWidth;
							PixelFormat pFormat;
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
							{
								iWidth = bitMapFromFile.Width;
								iHeight = bitMapFromFile.Height;
								pFormat = bitMapFromFile.PixelFormat;
								bitMapFromFile.Save(stream1, ImageFormat.Png);
							}
							Parallel.For(0, CS$<>8__locals2.$VB$Local_samePngArr.Count, parallelOptions, delegate(int iC, ParallelLoopState loopstate)
							{
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
								Interlocked.Add(ref PublicModule.iNow, 1);
								string text5 = Conversions.ToString(CS$<>8__locals2.$VB$Local_samePngArr[iC]);
								Bitmap bitmap = new Bitmap(iWidth, iHeight, pFormat);
								Graphics graphics = Graphics.FromImage(bitmap);
								graphics.Clear(Color.Transparent);
								MemoryStream $VB$Local_stream = stream1;
								lock ($VB$Local_stream)
								{
									graphics.DrawImage(Image.FromStream(stream1), 0, 0, iWidth, iHeight);
								}
								string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text5);
								string[] array4 = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
								int x = Conversions.ToInteger(array4[1]);
								int y = Conversions.ToInteger(array4[2]);
								Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5);
								graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
								bitMapFromFile2.Dispose();
								graphics.Dispose();
								string str = iC.ToString("D3");
								if (perseus)
								{
									array4 = fileNameWithoutExtension.Split(new char[]
									{
										'+'
									});
									str = array4[2];
								}
								string sSavePath = Path.Combine(base_path, base_png_name) + "_" + str;
								PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
								bitmap.Dispose();
								Interlocked.Add(ref PublicModule.iBuild, 1);
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							});
							if (perseus)
							{
								ArrayList arrayList = new ArrayList();
								ArrayList arr2 = new ArrayList();
								try
								{
									foreach (object value in CS$<>8__locals2.$VB$Local_samePngArr)
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
											arr2.Add(text2);
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
								Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
								{
									delegate(string spath1, ParallelLoopState loopstate1)
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
										Bitmap bitmap = new Bitmap(iWidth, iHeight, pFormat);
										Graphics graphics = Graphics.FromImage(bitmap);
										graphics.Clear(Color.Transparent);
										MemoryStream $VB$Local_stream = stream1;
										lock ($VB$Local_stream)
										{
											graphics.DrawImage(Image.FromStream(stream1), 0, 0, iWidth, iHeight);
										}
										string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(spath1);
										string[] array4 = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
										int x = Conversions.ToInteger(array4[1]);
										int y = Conversions.ToInteger(array4[2]);
										Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(spath1);
										graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
										bitMapFromFile2.Dispose();
										graphics.Dispose();
										MemoryStream memoryStream = new MemoryStream();
										bitmap.Save(memoryStream, ImageFormat.Png);
										bitmap.Dispose();
										try
										{
											foreach (object value2 in arr2)
											{
												string text5 = Conversions.ToString(value2);
												fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text5);
												array4 = asmodean_fun.get_ad_xy(fileNameWithoutExtension);
												x = Conversions.ToInteger(array4[1]);
												y = Conversions.ToInteger(array4[2]);
												Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream);
												Graphics graphics2 = Graphics.FromImage(bitmap2);
												Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text5);
												graphics2.DrawImage(bitMapFromFile3, x, y, bitMapFromFile3.Width, bitMapFromFile3.Height);
												bitMapFromFile3.Dispose();
												array4 = fileNameWithoutExtension.Split(new char[]
												{
													'+'
												});
												string str = array4[2];
												fileNameWithoutExtension = Path.GetFileNameWithoutExtension(spath1);
												array4 = fileNameWithoutExtension.Split(new char[]
												{
													'+'
												});
												str = array4[2] + "_" + str;
												string sSavePath = Path.Combine(base_path, base_png_name) + "_" + str;
												PublicModule.saveBitmapFile(sSavePath, ref bitmap2, true);
												bitmap2.Dispose();
												Interlocked.Add(ref PublicModule.iBuild, 1);
												BackgroundWorker2.ReportProgress(PublicModule.iNow);
												Thread.Sleep(PublicModule.iThreadWaitTime);
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
										memoryStream.Dispose();
									}(Conversions.ToString(a0), a1);
								});
							}
							stream1.Dispose();
						}
					}
				}
				PublicModule.sGameExe = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public static bool merge_ad_exchpac_spm_visual(ref Form1 myForm1)
		{
			bool result = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			backgroundWorker.ReportProgress(0);
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				string path = string.Empty;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				bool flag = false;
				if (0 == string.Compare(PublicModule.sGameExe, "MaterialBraveIgnition", StringComparison.OrdinalIgnoreCase))
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
							while (PublicModule.bWaitCancelAsync)
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
								Interlocked.Add(ref PublicModule.iNow, 2);
								PublicModule.files2.Add(text5);
								int x = Conversions.ToInteger(array3[2]);
								int y = Conversions.ToInteger(array3[3]);
								Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4);
								Graphics graphics = Graphics.FromImage(bitMapFromFile);
								using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5))
								{
									if (flag)
									{
										bitMapFromFile2.MakeTransparent(Color.Black);
									}
									graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
								}
								graphics.Dispose();
								string text6 = Path.Combine(path, Path.GetFileNameWithoutExtension(array3[0]).ToLower());
								text6 = text6 + "_" + PublicModule.getSameNameFromTheLeft(Path.GetFileNameWithoutExtension(array3[0]), Path.GetFileNameWithoutExtension(array3[1]), 0).ToLower();
								PublicModule.saveBitmapFile(text6, ref bitMapFromFile, true);
								bitMapFromFile.Dispose();
								Interlocked.Add(ref PublicModule.iBuild, 1);
								backgroundWorker.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
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
					PublicModule.files2.Add(text);
				}
				foreach (string text7 in array)
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
								while (PublicModule.bWaitCancelAsync)
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
									Bitmap bitmap = new Bitmap(spmFileDataCount.iWidth, spmFileDataCount.iHeight, PixelFormat.Format32bppArgb);
									Graphics graphics2 = Graphics.FromImage(bitmap);
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
												Interlocked.Add(ref PublicModule.iNow, 1);
												int x2 = Math.Abs(spmFileDataCount.iX - spmFileDataFace.iX);
												int y2 = Math.Abs(spmFileDataCount.iY - spmFileDataFace.iY);
												using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(text9))
												{
													graphics2.DrawImage(bitMapFromFile3, x2, y2, bitMapFromFile3.Width, bitMapFromFile3.Height);
												}
												text8 = text8 + "_" + PublicModule.getSameNameFromTheLeft(text3, Path.GetFileNameWithoutExtension(text9.ToLower()), 0);
												num3++;
												if (0 < spmFileDataFace.iIndex)
												{
													PublicModule.files2.Add(text9);
												}
											}
										}
									}
									graphics2.Dispose();
									if (1 >= num3)
									{
										bitmap.Dispose();
									}
									else
									{
										PublicModule.saveBitmapFile(text8, ref bitmap, true);
										bitmap.Dispose();
										Interlocked.Add(ref PublicModule.iBuild, 1);
										backgroundWorker.ReportProgress(PublicModule.iNow);
										Thread.Sleep(PublicModule.iThreadWaitTime);
									}
								}
							}
							PublicModule.files2.Add(text7);
						}
					}
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return result;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003108 File Offset: 0x00001308
		public static bool merge_ad_exdieslib_dzi_svg(ref Form1 myForm1)
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
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
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
												string text4 = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, "tex" + Conversions.ToString(Path.DirectorySeparatorChar) + text3), "");
												if (File.Exists(text4))
												{
													Interlocked.Add(ref PublicModule.iNow, 1);
													using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4))
													{
														graphics.DrawImage(bitMapFromFile, l * 256, k * 256, 256, 256);
													}
												}
											}
										}
									}
									graphics.Dispose();
									string sSavePath = Path.Combine(directoryName, fileNameWithoutExtension + "_" + j.ToString("D2"));
									PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
									bitmap.Dispose();
									Interlocked.Add(ref PublicModule.iBuild, 1);
									backgroundWorker.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								}
							}
						}
					}
					PublicModule.files2.Add(text);
					PublicModule.files2.Add(Path.ChangeExtension(text, "svg"));
					string path = Path.Combine(directoryName, "0_YouCanDel");
					PublicModule.files3.Add(new string[]
					{
						Path.Combine(directoryName, "tex"),
						Path.Combine(path, "tex")
					});
					PublicModule.files3.Add(new string[]
					{
						Path.Combine(directoryName, "thumbnl"),
						Path.Combine(path, "thumbnl")
					});
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return result;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003538 File Offset: 0x00001738
		public static bool merge_ad_exoozoarc_txt(ref Form1 myForm1)
		{
			BW2_four._Closure$__13 CS$<>8__locals1 = new BW2_four._Closure$__13();
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
					BW2_four._Closure$__13._Closure$__14 CS$<>8__locals2 = new BW2_four._Closure$__13._Closure$__14(CS$<>8__locals2);
					string text = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D = CS$<>8__locals1;
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
					CS$<>8__locals1.$VB$Local_base_name = Path.GetFileNameWithoutExtension(text).Split(new char[]
					{
						'+'
					}).First<string>();
					CS$<>8__locals1.$VB$Local_base_path = Path.GetDirectoryName(text);
					CS$<>8__locals2.$VB$Local_iW = 0;
					CS$<>8__locals2.$VB$Local_iH = 0;
					ArrayList arrayList = new ArrayList();
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
						{
							string text2 = streamReader.ReadLine().Trim();
							string[] array3 = PublicModule.regSmallSpace.Split(text2);
							CS$<>8__locals2.$VB$Local_iW = Conversions.ToInteger(array3[0]);
							CS$<>8__locals2.$VB$Local_iH = Conversions.ToInteger(array3[1]);
							while (!streamReader.EndOfStream)
							{
								string[] array4 = new string[6];
								text2 = streamReader.ReadLine().Trim();
								if (!string.IsNullOrWhiteSpace(text2))
								{
									array3 = PublicModule.regBigSpace.Split(text2);
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
						PublicModule.files2.Add(text);
						Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
						{
							delegate(string[] txtData, ParallelLoopState loopstate)
							{
								if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
								}
								string text3 = Path.Combine(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_base_path, txtData[5]);
								if (File.Exists(text3))
								{
									ArrayList files = PublicModule.files2;
									lock (files)
									{
										PublicModule.files2.Add(text3);
									}
									Interlocked.Add(ref PublicModule.iNow, 1);
									int x = Conversions.ToInteger(txtData[1]);
									int y = Conversions.ToInteger(txtData[2]);
									int width = Conversions.ToInteger(txtData[3]);
									int height = Conversions.ToInteger(txtData[4]);
									Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iW, CS$<>8__locals2.$VB$Local_iH, PixelFormat.Format32bppArgb);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text3))
									{
										graphics.DrawImage(bitMapFromFile, x, y, width, height);
									}
									graphics.Dispose();
									string sSavePath = Path.Combine(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_base_path, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_base_name + "_" + txtData[0]);
									PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
									Interlocked.Add(ref PublicModule.iBuild, 1);
									bitmap.Dispose();
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_D.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								}
							}((string[])a0, a1);
						});
					}
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000037D4 File Offset: 0x000019D4
		public static bool merge_ad_exyatpkg_lua_evt(ref Form1 myForm1)
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
				if (0 >= array.Count<string>())
				{
					PublicModule.sGameExe = string.Empty;
					PublicModule.sSpecialExt = string.Empty;
					return eCancel;
				}
				string text = string.Empty;
				string base_path = string.Empty;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
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
					if (string.IsNullOrEmpty(base_path))
					{
						base_path = Path.GetDirectoryName(text2);
					}
					using (FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
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
											string[] array3 = PublicModule.regSmallSpace.Split(text3);
											string[] chara = new string[2];
											foreach (string text4 in array3)
											{
												if (Strings.InStr(1, text4, "file=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text4);
													chara[0] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text4, "diff=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text4);
													chara[1] = source.Last<string>().Replace("\"", string.Empty);
												}
											}
											bool bfind = false;
											Parallel.ForEach<object>(arrayList.ToArray(), delegate(object a0, ParallelLoopState a1)
											{
												delegate(string[] thisdatas, ParallelLoopState loopstate)
												{
													if (0 == string.Compare(chara[0], thisdatas[0], StringComparison.Ordinal) & 0 == string.Compare(chara[1], thisdatas[1], StringComparison.Ordinal))
													{
														bfind = true;
														loopstate.Stop();
													}
												}((string[])a0, a1);
											});
											if (!bfind)
											{
												arrayList.Add(chara);
											}
										}
										else if (Strings.InStr(1, text3, "@[SimpleEvent", CompareMethod.Binary) > 0)
										{
											string[] array3 = PublicModule.regSmallSpace.Split(text3);
											string[] events = new string[6];
											foreach (string text5 in array3)
											{
												if (Strings.InStr(1, text5, "file=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[0] = source.Last<string>().Replace("\"", string.Empty);
													if (Strings.InStr(1, events[0], "&", CompareMethod.Binary) > 0)
													{
														goto IL_512;
													}
												}
												else if (Strings.InStr(1, text5, "df1=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[1] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df2=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[2] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df3=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[3] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df4=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[4] = source.Last<string>().Replace("\"", string.Empty);
												}
												else if (Strings.InStr(1, text5, "df5=", CompareMethod.Binary) > 0)
												{
													string[] source = PublicModule.regEqual.Split(text5);
													events[5] = source.Last<string>().Replace("\"", string.Empty);
												}
											}
											if (!(string.IsNullOrEmpty(events[1]) & string.IsNullOrEmpty(events[2]) & string.IsNullOrEmpty(events[3]) & string.IsNullOrEmpty(events[4]) & string.IsNullOrEmpty(events[5])))
											{
												bool bfind = false;
												Parallel.ForEach<object>(arrayList2.ToArray(), delegate(object a0, ParallelLoopState a1)
												{
													delegate(string[] thisdatas, ParallelLoopState loopstate)
													{
														if (0 == string.Compare(events[0], thisdatas[0], StringComparison.Ordinal) & 0 == string.Compare(events[1], thisdatas[1], StringComparison.Ordinal) & 0 == string.Compare(events[2], thisdatas[2], StringComparison.Ordinal) & 0 == string.Compare(events[3], thisdatas[3], StringComparison.Ordinal) & 0 == string.Compare(events[4], thisdatas[4], StringComparison.Ordinal) & 0 == string.Compare(events[5], thisdatas[5], StringComparison.Ordinal))
														{
															bfind = true;
															loopstate.Stop();
														}
													}((string[])a0, a1);
												});
												if (!bfind)
												{
													arrayList2.Add(events);
												}
											}
										}
									}
								}
							}
						}
					}
					PublicModule.files2.Add(text2);
				}
				string text6 = Path.Combine(base_path, "scriptSettings.lua");
				ArrayList CharaDiffPosArr = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				ArrayList ECGdiffArr = new ArrayList();
				if (File.Exists(text6))
				{
					using (FileStream fileStream2 = new FileStream(text6, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader2 = new StreamReader(fileStream2, PublicModule.JpEncode))
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
											string text8 = PublicModule.regEqual.Split(text7).First<string>().Trim();
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
													CharaDiffPosArr.Add(array7);
												}
											}
										}
										else if (Strings.InStr(1, text7, "g_CharaAddPartsChara", CompareMethod.Binary) > 0)
										{
											string text8 = PublicModule.regEqual.Split(text7).First<string>().Trim();
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
													ECGdiffArr.Add(array10);
												}
											}
										}
									}
								}
							}
						}
					}
					PublicModule.files2.Add(text6);
				}
				if (0 < arrayList.Count & 0 < CharaDiffPosArr.Count)
				{
					Parallel.ForEach<object>(arrayList.ToArray(), delegate(object a0, ParallelLoopState a1)
					{
						delegate(string[] thisdatas, ParallelLoopState loopstate)
						{
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
							if (string.IsNullOrEmpty(thisdatas[0]) | string.IsNullOrEmpty(thisdatas[1]))
							{
								return;
							}
							string text9 = Path.Combine(base_path, Path.ChangeExtension(thisdatas[0], "png"));
							string text10 = Path.Combine(base_path, thisdatas[1]);
							if (File.Exists(text9) & File.Exists(text10))
							{
								Interlocked.Add(ref PublicModule.iNow, 2);
								PublicModule.files2.Add(text9);
								PublicModule.files2.Add(text10);
								string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(thisdatas[1]);
								string[] array11 = PublicModule.regXIA.Split(fileNameWithoutExtension);
								string text11 = array11.First<string>().Substring(2);
								string strA = Conversions.ToString(array11[2].First<char>());
								string strA2 = Conversions.ToString(array11[2].Last<char>());
								if (0 == string.Compare(strA, "3", StringComparison.Ordinal))
								{
									text11 += "_3";
								}
								else
								{
									text11 += "_0";
								}
								int num2 = -1;
								int num3 = -1;
								try
								{
									foreach (object obj in CharaDiffPosArr)
									{
										string[] array12 = (string[])obj;
										if (0 == string.Compare(text11, array12[0], StringComparison.Ordinal) & 0 == string.Compare(strA2, array12[1], StringComparison.Ordinal))
										{
											num2 = Conversions.ToInteger(array12[2]);
											num3 = Conversions.ToInteger(array12[3]);
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
								if (-1 == num2 & -1 == num3)
								{
									PublicModule.addLog(text11 + " : is false. ");
									return;
								}
								Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text9);
								Graphics graphics = Graphics.FromImage(bitMapFromFile);
								Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text10);
								graphics.DrawImage(bitMapFromFile2, num2, num3, bitMapFromFile2.Width, bitMapFromFile2.Height);
								graphics.Dispose();
								bitMapFromFile2.Dispose();
								string sSavePath = Path.Combine(base_path, Path.GetFileNameWithoutExtension(thisdatas[0]) + "_" + Path.GetFileNameWithoutExtension(thisdatas[1]));
								PublicModule.saveBitmapFile(sSavePath, ref bitMapFromFile, true);
								bitMapFromFile.Dispose();
								Interlocked.Add(ref PublicModule.iBuild, 1);
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							}
						}((string[])a0, a1);
					});
				}
				if (0 < arrayList3.Count)
				{
					Parallel.ForEach<object>(arrayList3.ToArray(), delegate(object a0)
					{
						delegate(string[] thisdatas)
						{
							string text9 = Path.Combine(base_path, thisdatas[0]);
							if (File.Exists(text9))
							{
								string newPath = string.Concat(new string[]
								{
									Path.Combine(base_path, Path.GetFileNameWithoutExtension(thisdatas[0])),
									"_",
									thisdatas[1],
									"_",
									thisdatas[2],
									Path.GetExtension(thisdatas[0])
								});
								try
								{
									FileSystem.Rename(text9, newPath);
								}
								catch (Exception ex)
								{
									PublicModule.addLog(text9 + " : " + ex.Message);
								}
							}
						}((string[])a0);
					});
				}
				if (0 < ECGdiffArr.Count & 0 < arrayList2.Count)
				{
					Parallel.ForEach<object>(arrayList2.ToArray(), delegate(object a0, ParallelLoopState a1)
					{
						delegate(string[] thisdatas, ParallelLoopState loopstate)
						{
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
							string text9 = Path.Combine(base_path, Path.ChangeExtension(thisdatas[0], "png"));
							if (File.Exists(text9))
							{
								Interlocked.Add(ref PublicModule.iNow, 1);
								string text10 = string.Empty;
								Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text9);
								int num2 = 1;
								int num3 = thisdatas.Count<string>() - 1;
								for (int l = num2; l <= num3; l++)
								{
									if (!string.IsNullOrEmpty(thisdatas[l]))
									{
										if (thisdatas[l].Length >= 3)
										{
											string text11 = Path.Combine(base_path, thisdatas[l]);
											if (File.Exists(text11))
											{
												Interlocked.Add(ref PublicModule.iNow, 1);
												PublicModule.files2.Add(text11);
												int num4 = -1;
												int num5 = -1;
												string text12 = thisdatas[l];
												try
												{
													foreach (object obj in ECGdiffArr)
													{
														string[] array11 = (string[])obj;
														if (0 == string.Compare(text12, array11[0], StringComparison.Ordinal))
														{
															num4 = Conversions.ToInteger(array11[1]);
															num5 = Conversions.ToInteger(array11[2]);
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
												if (-1 == num4 & -1 == num5)
												{
													PublicModule.addLog(text12 + " : is false. ");
												}
												else
												{
													Graphics graphics = Graphics.FromImage(bitMapFromFile);
													using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text11))
													{
														graphics.DrawImage(bitMapFromFile2, num4, num5, bitMapFromFile2.Width, bitMapFromFile2.Height);
													}
													graphics.Dispose();
													if (1 == l)
													{
														text10 = Path.GetFileNameWithoutExtension(thisdatas[l]);
													}
													else
													{
														text10 = text10 + "_" + Path.GetFileNameWithoutExtension(thisdatas[l]);
													}
												}
											}
										}
									}
								}
								string sSavePath = Path.Combine(base_path, Path.GetFileNameWithoutExtension(thisdatas[0]) + "_" + text10);
								PublicModule.saveBitmapFile(sSavePath, ref bitMapFromFile, true);
								Interlocked.Add(ref PublicModule.iBuild, 1);
								bitMapFromFile.Dispose();
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							}
						}((string[])a0, a1);
					});
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000041F8 File Offset: 0x000023F8
		public static bool extract_ad_exsteldat_mng(ref Form1 myForm1)
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
				string[] bytePngHead = new string[]
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
				string[] bytePngEng = new string[]
				{
					"44",
					"AE",
					"42",
					"60",
					"82"
				};
				Parallel.ForEach<string>(array, delegate(string mngpath, ParallelLoopState loopstate)
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
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(mngpath);
					string directoryName = Path.GetDirectoryName(mngpath);
					using (FileStream fileStream = new FileStream(mngpath, FileMode.Open, FileAccess.Read, FileShare.Read))
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
														foreach (string value2 in bytePngHead)
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
									foreach (string value4 in bytePngEng)
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
									Interlocked.Add(ref PublicModule.iBuild, 1);
									BackgroundWorker2.ReportProgress(PublicModule.iNow);
								}
							}
							if (0 < num2)
							{
								PublicModule.files2.Add(mngpath);
							}
						}
						binaryReader.Dispose();
					}
				});
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004378 File Offset: 0x00002578
		public static bool merge_ad_exmed_bgset_sprset(ref Form1 myForm1)
		{
			BW2_four._Closure$__19 CS$<>8__locals1 = new BW2_four._Closure$__19(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_eCancel = false;
			string sfind = "_SPRSET";
			Form1 form = myForm1;
			ListBox listBox = form.ListBox4;
			string text = PublicModule.sFindInListBox(sfind, ref listBox, 1);
			form.ListBox4 = listBox;
			string text2 = text;
			string sfind2 = "_BGSET";
			form = myForm1;
			listBox = form.ListBox4;
			string text3 = PublicModule.sFindInListBox(sfind2, ref listBox, 1);
			form.ListBox4 = listBox;
			string text4 = text3;
			string sfind3 = ".exe";
			form = myForm1;
			listBox = form.ListBox4;
			string text5 = PublicModule.sFindInListBox(sfind3, ref listBox, 2);
			form.ListBox4 = listBox;
			string text6 = text5;
			if (string.IsNullOrWhiteSpace(text2) & string.IsNullOrWhiteSpace(text4))
			{
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
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
								PublicModule.addLog("not support, tell me.");
							}
							else
							{
								BW2_four._Closure$__19._Closure$__20 CS$<>8__locals2 = new BW2_four._Closure$__19._Closure$__20(CS$<>8__locals2);
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
								CS$<>8__locals2.$VB$Local_PREFIX = string.Empty;
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
																CS$<>8__locals2.$VB$Local_PREFIX = array5.First<string>();
																if (num7 == 2)
																{
																	CS$<>8__locals2.$VB$Local_PREFIX = array5.Last<string>();
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
																string text8 = PublicModule.sFindNameInArrayList(ref PublicModule.files1, CS$<>8__locals2.$VB$Local_PREFIX + array4[2]);
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
																string text8 = PublicModule.sFindNameInArrayList(ref PublicModule.files1, CS$<>8__locals2.$VB$Local_PREFIX + array4[2]);
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
																	BW2_four._Closure$__19._Closure$__20._Closure$__21 CS$<>8__locals3 = new BW2_four._Closure$__19._Closure$__20._Closure$__21(CS$<>8__locals3);
																	CS$<>8__locals3.$VB$Local_sBodyArr = (string[])enumerator.Current;
																	CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_14 = CS$<>8__locals2;
																	CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13 = CS$<>8__locals1;
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
																	if (File.Exists(CS$<>8__locals3.$VB$Local_sBodyArr[0]))
																	{
																		CS$<>8__locals3.$VB$Local_BodyStream = new MemoryStream();
																		CS$<>8__locals3.$VB$Local_iW = 0;
																		CS$<>8__locals3.$VB$Local_iH = 0;
																		CS$<>8__locals3.$VB$Local_pf = PixelFormat.Format32bppArgb;
																		using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(CS$<>8__locals3.$VB$Local_sBodyArr[0]))
																		{
																			CS$<>8__locals3.$VB$Local_iW = bitMapFromFile.Width;
																			CS$<>8__locals3.$VB$Local_iH = bitMapFromFile.Height;
																			CS$<>8__locals3.$VB$Local_pf = bitMapFromFile.PixelFormat;
																			Rectangle rect = new Rectangle(0, 0, CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH);
																			BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, CS$<>8__locals3.$VB$Local_pf);
																			Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, bitmapData.Stride, PublicModule.checkPixelFormat(CS$<>8__locals3.$VB$Local_pf), bitmapData.Scan0);
																			bitMapFromFile.UnlockBits(bitmapData);
																			bitmap.Save(CS$<>8__locals3.$VB$Local_BodyStream, ImageFormat.Png);
																			bitmap.Dispose();
																		}
																		CS$<>8__locals3.$VB$Local_base_path = Path.GetDirectoryName(CS$<>8__locals3.$VB$Local_sBodyArr[0]);
																		Parallel.ForEach<object>(arrayList2.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
																		{
																			delegate(string[] sPartsArr, ParallelLoopState loopstate)
																			{
																				Interlocked.Add(ref PublicModule.iNow, 1);
																				if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13.$VB$Local_BackgroundWorker2.CancellationPending)
																				{
																					CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13.$VB$Local_eCancel = true;
																					loopstate.Stop();
																				}
																				while (PublicModule.bWaitCancelAsync)
																				{
																					Thread.Sleep(500);
																					if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13.$VB$Local_BackgroundWorker2.CancellationPending)
																					{
																						CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13.$VB$Local_eCancel = true;
																						loopstate.Stop();
																					}
																				}
																				if (!File.Exists(sPartsArr[0]))
																				{
																					return;
																				}
																				Bitmap bitmap2 = new Bitmap(CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH, PublicModule.checkPixelFormat(CS$<>8__locals3.$VB$Local_pf));
																				Graphics graphics = Graphics.FromImage(bitmap2);
																				graphics.Clear(Color.Transparent);
																				MemoryStream $VB$Local_BodyStream = CS$<>8__locals3.$VB$Local_BodyStream;
																				lock ($VB$Local_BodyStream)
																				{
																					graphics.DrawImage(Image.FromStream(CS$<>8__locals3.$VB$Local_BodyStream), 0, 0, CS$<>8__locals3.$VB$Local_iW, CS$<>8__locals3.$VB$Local_iH);
																				}
																				using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sPartsArr[0]))
																				{
																					Rectangle rect2 = new Rectangle(0, 0, bitMapFromFile2.Width, bitMapFromFile2.Height);
																					BitmapData bitmapData2 = bitMapFromFile2.LockBits(rect2, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
																					Bitmap bitmap3 = new Bitmap(bitMapFromFile2.Width, bitMapFromFile2.Height, bitmapData2.Stride, PublicModule.checkPixelFormat(bitMapFromFile2.PixelFormat), bitmapData2.Scan0);
																					bitMapFromFile2.UnlockBits(bitmapData2);
																					graphics.DrawImage(bitmap3, Conversions.ToInteger(sPartsArr[3]), Conversions.ToInteger(sPartsArr[4]), bitMapFromFile2.Width, bitMapFromFile2.Height);
																					bitmap3.Dispose();
																				}
																				graphics.Dispose();
																				string sSavePath = Path.Combine(CS$<>8__locals3.$VB$Local_base_path, CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_14.$VB$Local_PREFIX + CS$<>8__locals3.$VB$Local_sBodyArr[1] + sPartsArr[1]);
																				PublicModule.saveBitmapFile(sSavePath, ref bitmap2, true);
																				bitmap2.Dispose();
																				ArrayList files2 = PublicModule.files2;
																				lock (files2)
																				{
																					PublicModule.files2.Add(sPartsArr[0]);
																				}
																				Interlocked.Add(ref PublicModule.iBuild, 1);
																				CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_13.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
																				Thread.Sleep(PublicModule.iThreadWaitTime);
																			}((string[])a0, a1);
																		});
																		CS$<>8__locals3.$VB$Local_BodyStream.Dispose();
																		ArrayList files = PublicModule.files2;
																		lock (files)
																		{
																			PublicModule.files2.Add(CS$<>8__locals3.$VB$Local_sBodyArr[0]);
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
															CS$<>8__locals2.$VB$Local_PREFIX = string.Empty;
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
				if (0 < PublicModule.iBuild)
				{
					PublicModule.files2.Add(text2);
					PublicModule.files2.Add(text4);
					PublicModule.files2.Add(text6);
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004C88 File Offset: 0x00002E88
		public static bool merge_ad_exanepak_chaNX00_chaNXYZ(ref Form1 myForm1)
		{
			BW2_four._Closure$__22 CS$<>8__locals1 = new BW2_four._Closure$__22(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				string[] source = array;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four._Closure$__22._Closure$__23 CS$<>8__locals2 = new BW2_four._Closure$__22._Closure$__23(CS$<>8__locals2);
					CS$<>8__locals2.$VB$Local_imgpath = array2[i];
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
					if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, CS$<>8__locals2.$VB$Local_imgpath))
					{
						CS$<>8__locals1.$VB$Local_base_name = Path.GetFileNameWithoutExtension(CS$<>8__locals2.$VB$Local_imgpath);
						if (7 <= CS$<>8__locals1.$VB$Local_base_name.Length && (Operators.CompareString(Conversions.ToString(CS$<>8__locals1.$VB$Local_base_name[0]), "c", false) == 0 & Operators.CompareString(Conversions.ToString(CS$<>8__locals1.$VB$Local_base_name[1]), "h", false) == 0))
						{
							string text = CS$<>8__locals1.$VB$Local_base_name.Substring(4);
							if (Versioned.IsNumeric(text))
							{
								if (Conversions.ToInteger(text) % 100 == 0)
								{
									BW2_four._Closure$__22._Closure$__23._Closure$__24 CS$<>8__locals3 = new BW2_four._Closure$__22._Closure$__23._Closure$__24(CS$<>8__locals3);
									CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_17 = CS$<>8__locals2;
									CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16 = CS$<>8__locals1;
									CS$<>8__locals1.$VB$Local_base_path = Path.GetDirectoryName(CS$<>8__locals2.$VB$Local_imgpath);
									CS$<>8__locals1.$VB$Local_base_name2 = CS$<>8__locals1.$VB$Local_base_name.Substring(0, 5);
									CS$<>8__locals3.$VB$Local_streamL = new MemoryStream();
									using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_imgpath))
									{
										CS$<>8__locals3.$VB$Local_iWidth = bitMapFromFile.Width;
										CS$<>8__locals3.$VB$Local_iHeight = bitMapFromFile.Height;
										CS$<>8__locals3.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
										bitMapFromFile.Save(CS$<>8__locals3.$VB$Local_streamL, ImageFormat.Png);
									}
									CS$<>8__locals3.$VB$Local_ix = -1;
									CS$<>8__locals3.$VB$Local_iy = -1;
									FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals3.$VB$Local_streamL));
									int num = fastBitmap.iWidth / 2 - 1;
									int num2 = fastBitmap.iHeight / 2;
									int num3 = fastBitmap.iHeight - 1;
									for (int j = num2; j <= num3; j++)
									{
										int a = (int)fastBitmap.GetPixel(num, j).A;
										if (255 == a)
										{
											CS$<>8__locals3.$VB$Local_ix = num + 1;
											CS$<>8__locals3.$VB$Local_iy = j;
											break;
										}
									}
									fastBitmap.Dispose();
									if (!(-1 == CS$<>8__locals3.$VB$Local_ix | -1 == CS$<>8__locals3.$VB$Local_iy))
									{
										Parallel.ForEach<string>(source, parallelOptions, delegate(string facepath, ParallelLoopState loopstate)
										{
											Interlocked.Add(ref PublicModule.iNow, 1);
											if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.CancellationPending)
											{
												CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_eCancel = true;
												loopstate.Stop();
											}
											while (PublicModule.bWaitCancelAsync)
											{
												Thread.Sleep(500);
												if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.CancellationPending)
												{
													CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_eCancel = true;
													loopstate.Stop();
												}
											}
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												if (PublicModule.canFindSameInArrayList(ref PublicModule.files2, facepath))
												{
													return;
												}
											}
											if (0 == string.Compare(CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_17.$VB$Local_imgpath, facepath, StringComparison.Ordinal))
											{
												return;
											}
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(facepath);
											if (7 > fileNameWithoutExtension.Length)
											{
												return;
											}
											if (Operators.CompareString(Conversions.ToString(fileNameWithoutExtension.Last<char>()), "u", false) == 0 | Operators.CompareString(Conversions.ToString(fileNameWithoutExtension[fileNameWithoutExtension.Length - 2]), "u", false) == 0)
											{
												return;
											}
											string strB = fileNameWithoutExtension.Substring(0, 5);
											if (0 == string.Compare(CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name2, strB, StringComparison.Ordinal))
											{
												Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight, CS$<>8__locals3.$VB$Local_pFormat);
												Graphics graphics = Graphics.FromImage(bitmap);
												graphics.Clear(Color.Transparent);
												MemoryStream $VB$Local_streamL = CS$<>8__locals3.$VB$Local_streamL;
												lock ($VB$Local_streamL)
												{
													graphics.DrawImage(Image.FromStream(CS$<>8__locals3.$VB$Local_streamL), 0, 0, CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight);
												}
												MemoryStream memoryStream = new MemoryStream();
												int width;
												int height;
												using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(facepath))
												{
													width = bitMapFromFile3.Width;
													height = bitMapFromFile3.Height;
													bitMapFromFile3.Save(memoryStream, ImageFormat.Png);
												}
												graphics.DrawImage(Image.FromStream(memoryStream), CS$<>8__locals3.$VB$Local_ix - width / 2, CS$<>8__locals3.$VB$Local_iy - height, width, height);
												graphics.Dispose();
												string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name, fileNameWithoutExtension, 0);
												string sSavePath = Path.Combine(CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_path, CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name + "_" + sameNameFromTheLeft);
												PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
												Interlocked.Add(ref PublicModule.iBuild, 1);
												bitmap.Dispose();
												memoryStream.Dispose();
												ArrayList files2 = PublicModule.files2;
												lock (files2)
												{
													PublicModule.files2.Add(facepath);
												}
												CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
												Thread.Sleep(PublicModule.iThreadWaitTime);
											}
										});
										CS$<>8__locals3.$VB$Local_streamL.Dispose();
										PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_imgpath);
									}
								}
							}
							else if (Operators.CompareString(Conversions.ToString(CS$<>8__locals1.$VB$Local_base_name.Last<char>()), "u", false) == 0)
							{
								text = text.Substring(0, text.Length - 1);
								if (Conversions.ToInteger(text) % 100 == 0)
								{
									BW2_four._Closure$__22._Closure$__23._Closure$__25 CS$<>8__locals4 = new BW2_four._Closure$__22._Closure$__23._Closure$__25(CS$<>8__locals4);
									CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_17 = CS$<>8__locals2;
									CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16 = CS$<>8__locals1;
									CS$<>8__locals1.$VB$Local_base_path = Path.GetDirectoryName(CS$<>8__locals2.$VB$Local_imgpath);
									CS$<>8__locals1.$VB$Local_base_name2 = CS$<>8__locals1.$VB$Local_base_name.Substring(0, 5);
									CS$<>8__locals4.$VB$Local_streamL = new MemoryStream();
									using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_imgpath))
									{
										CS$<>8__locals4.$VB$Local_iWidth = bitMapFromFile2.Width;
										CS$<>8__locals4.$VB$Local_iHeight = bitMapFromFile2.Height;
										CS$<>8__locals4.$VB$Local_pFormat = bitMapFromFile2.PixelFormat;
										bitMapFromFile2.Save(CS$<>8__locals4.$VB$Local_streamL, ImageFormat.Png);
									}
									CS$<>8__locals4.$VB$Local_ix = -1;
									CS$<>8__locals4.$VB$Local_iy = -1;
									FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals4.$VB$Local_streamL));
									int num4 = fastBitmap2.iWidth / 2 - 1;
									int num5 = fastBitmap2.iHeight / 2;
									int num6 = fastBitmap2.iHeight - 1;
									for (int k = num5; k <= num6; k++)
									{
										int a2 = (int)fastBitmap2.GetPixel(num4, k).A;
										if (255 == a2)
										{
											CS$<>8__locals4.$VB$Local_ix = num4 + 1;
											CS$<>8__locals4.$VB$Local_iy = k;
											break;
										}
									}
									fastBitmap2.Dispose();
									if (!(-1 == CS$<>8__locals4.$VB$Local_ix | -1 == CS$<>8__locals4.$VB$Local_iy))
									{
										Parallel.ForEach<string>(source, parallelOptions, delegate(string facepath, ParallelLoopState loopstate)
										{
											Interlocked.Add(ref PublicModule.iNow, 1);
											if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.CancellationPending)
											{
												CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_eCancel = true;
												loopstate.Stop();
											}
											while (PublicModule.bWaitCancelAsync)
											{
												Thread.Sleep(500);
												if (CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.CancellationPending)
												{
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_eCancel = true;
													loopstate.Stop();
												}
											}
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												if (PublicModule.canFindSameInArrayList(ref PublicModule.files2, facepath))
												{
													return;
												}
											}
											if (0 == string.Compare(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_17.$VB$Local_imgpath, facepath, StringComparison.Ordinal))
											{
												return;
											}
											string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(facepath);
											if (7 > fileNameWithoutExtension.Length)
											{
												return;
											}
											if (Operators.CompareString(Conversions.ToString(fileNameWithoutExtension.Last<char>()), "u", false) == 0 | Operators.CompareString(Conversions.ToString(fileNameWithoutExtension[fileNameWithoutExtension.Length - 2]), "u", false) == 0)
											{
												string strB = fileNameWithoutExtension.Substring(0, 5);
												if (0 == string.Compare(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name2, strB, StringComparison.Ordinal))
												{
													Bitmap bitmap = new Bitmap(CS$<>8__locals4.$VB$Local_iWidth, CS$<>8__locals4.$VB$Local_iHeight, CS$<>8__locals4.$VB$Local_pFormat);
													Graphics graphics = Graphics.FromImage(bitmap);
													graphics.Clear(Color.Transparent);
													MemoryStream $VB$Local_streamL = CS$<>8__locals4.$VB$Local_streamL;
													lock ($VB$Local_streamL)
													{
														graphics.DrawImage(Image.FromStream(CS$<>8__locals4.$VB$Local_streamL), 0, 0, CS$<>8__locals4.$VB$Local_iWidth, CS$<>8__locals4.$VB$Local_iHeight);
													}
													MemoryStream memoryStream = new MemoryStream();
													int width;
													int height;
													using (Bitmap bitMapFromFile3 = PublicModule.getBitMapFromFile(facepath))
													{
														width = bitMapFromFile3.Width;
														height = bitMapFromFile3.Height;
														bitMapFromFile3.Save(memoryStream, ImageFormat.Png);
													}
													graphics.DrawImage(Image.FromStream(memoryStream), CS$<>8__locals4.$VB$Local_ix - width / 2, CS$<>8__locals4.$VB$Local_iy - height, width, height);
													graphics.Dispose();
													string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name, fileNameWithoutExtension, 0);
													string sSavePath = Path.Combine(CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_path, CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_base_name + "_" + sameNameFromTheLeft);
													PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
													Interlocked.Add(ref PublicModule.iBuild, 1);
													bitmap.Dispose();
													memoryStream.Dispose();
													ArrayList files2 = PublicModule.files2;
													lock (files2)
													{
														PublicModule.files2.Add(facepath);
													}
													CS$<>8__locals4.$VB$NonLocal_$VB$Closure_ClosureVariable_16.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
													Thread.Sleep(PublicModule.iThreadWaitTime);
												}
											}
										});
										CS$<>8__locals4.$VB$Local_streamL.Dispose();
										PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_imgpath);
									}
								}
							}
							else if (Operators.CompareString(Conversions.ToString(CS$<>8__locals1.$VB$Local_base_name.Last<char>()), "h", false) == 0)
							{
							}
						}
					}
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000051C4 File Offset: 0x000033C4
		public static bool merge_ad_exescarc_lsf(ref Form1 myForm1)
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
				Parallel.ForEach<string>(array, parallelOptions, delegate(string lsfpath, ParallelLoopState loopstate)
				{
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
					Interlocked.Add(ref PublicModule.iNow, 1);
					string directoryName = Path.GetDirectoryName(lsfpath);
					ArrayList arrayList = new ArrayList();
					if (!asmodean_fun.readLsfToArrayList(ref arrayList, lsfpath))
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
					string[] array2 = (string[])arrayList[0];
					int ibmpW = Conversions.ToInteger(array2[3]);
					int ibmpH = Conversions.ToInteger(array2[4]);
					int num = 1;
					int num2 = arrayList.Count - 1;
					for (int i = num; i <= num2; i++)
					{
						string[] array3 = (string[])arrayList[i];
						Interlocked.Add(ref PublicModule.iNow, 1);
						string text = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, array3[0]), "");
						if (File.Exists(text))
						{
							Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text);
							PixelFormat pixelFormat = bitMapFromFile.PixelFormat;
							int width = bitMapFromFile.Width;
							int height = bitMapFromFile.Height;
							Rectangle rect = new Rectangle(0, 0, width, height);
							BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
							Bitmap bitmap = new Bitmap(width, height, bitmapData.Stride, PublicModule.checkPixelFormat(pixelFormat), bitmapData.Scan0);
							bitMapFromFile.UnlockBits(bitmapData);
							Bitmap bitmap2 = new Bitmap(Conversions.ToInteger(array3[3]), Conversions.ToInteger(array3[4]), PublicModule.checkPixelFormat(pixelFormat));
							Graphics graphics = Graphics.FromImage(bitmap2);
							graphics.Clear(Color.Transparent);
							graphics.DrawImage(bitmap, Conversions.ToInteger(array3[1]), Conversions.ToInteger(array3[2]), width, height);
							graphics.Dispose();
							MemoryStream memoryStream = new MemoryStream();
							bitmap2.Save(memoryStream, ImageFormat.Png);
							int num3 = Conversions.ToInteger(array3[8]);
							if (0 == num3)
							{
								arrayList2.Add(memoryStream);
								arrayList4.Add(array3[0]);
								arrayList6.Add(text);
							}
							else
							{
								if (255 == num3)
								{
									ArrayList files = PublicModule.files2;
									lock (files)
									{
										PublicModule.files2.Add(text);
										goto IL_295;
									}
								}
								if (0 < num3 & 99 > num3)
								{
									arrayList3.Add(memoryStream);
									arrayList5.Add(array3[0]);
									arrayList7.Add(text);
									arrayList8.Add(num3);
								}
							}
							IL_295:
							bitmap2.Dispose();
							bitmap.Dispose();
							bitMapFromFile.Dispose();
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
						int index = j;
						Bitmap bitmap3 = (Bitmap)Image.FromStream((MemoryStream)arrayList2[index]);
						PixelFormat pixelFormat2 = bitmap3.PixelFormat;
						ArrayList files2 = PublicModule.files2;
						lock (files2)
						{
							PublicModule.files2.Add(RuntimeHelpers.GetObjectValue(arrayList6[index]));
						}
						BW2_four.merge_lsf_layer_Bitmap(ref bitmap3, ibmpW, ibmpH, pixelFormat2, ref arrayList3, ref arrayList8, 1, directoryName, Conversions.ToString(arrayList4[index]), ref arrayList5, ref arrayList7, ref BackgroundWorker2);
					}
					ArrayList files3 = PublicModule.files2;
					lock (files3)
					{
						PublicModule.files2.Add(lsfpath);
					}
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
				});
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005260 File Offset: 0x00003460
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
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BW.CancellationPending)
					{
						return;
					}
					while (PublicModule.bWaitCancelAsync)
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
						PublicModule.saveBitmapFile(text, ref bitmap2, true);
						BW2_four.merge_lsf_layer_Bitmap(ref bitmap2, ibmpW, ibmpH, PF, ref arrright, ref arrrightlayer, iTurn + 1, paths, Path.GetFileNameWithoutExtension(text), ref arrrightname, ref arrrightpath, ref BW);
						bitmap2.Dispose();
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(RuntimeHelpers.GetObjectValue(arrrightpath[i]));
						}
						Interlocked.Add(ref PublicModule.iBuild, 1);
						BW.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					}
				}
				if (!flag)
				{
					BW2_four.merge_lsf_layer_Bitmap(ref basebmp, ibmpW, ibmpH, PF, ref arrright, ref arrrightlayer, iTurn + 1, paths, arrleftname, ref arrrightname, ref arrrightpath, ref BW);
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005454 File Offset: 0x00003654
		public static bool merge_ad_expimg_txt(ref Form1 myForm1)
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
				string[] array2 = array;
				string base_path;
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_four._Closure$__27._Closure$__28 CS$<>8__locals2 = new BW2_four._Closure$__27._Closure$__28(CS$<>8__locals2);
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
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					base_path = Path.GetDirectoryName(text);
					CS$<>8__locals2.$VB$Local_sLastName = "AA";
					CS$<>8__locals2.$VB$Local_image_width = 0;
					CS$<>8__locals2.$VB$Local_image_height = 0;
					CS$<>8__locals2.$VB$Local_iLastID = 0;
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
									if (0 == CS$<>8__locals2.$VB$Local_image_width && 0 == string.Compare(text3, "image_width", StringComparison.Ordinal))
									{
										CS$<>8__locals2.$VB$Local_image_width = Conversions.ToInteger(text4);
									}
									else if (0 == CS$<>8__locals2.$VB$Local_image_height && 0 == string.Compare(text3, "image_height", StringComparison.Ordinal))
									{
										CS$<>8__locals2.$VB$Local_image_height = Conversions.ToInteger(text4);
									}
									else if (0 == string.Compare(text3, "name", StringComparison.Ordinal))
									{
										array3[0] = text4;
										CS$<>8__locals2.$VB$Local_sLastName = text4;
									}
									else if (0 == string.Compare(text3, "layer_id", StringComparison.Ordinal))
									{
										array3[1] = text4;
										CS$<>8__locals2.$VB$Local_iLastID = Conversions.ToInteger(text4);
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
						if (!(0 == CS$<>8__locals2.$VB$Local_image_width | 0 == CS$<>8__locals2.$VB$Local_image_height))
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
								Conversions.ToString(CS$<>8__locals2.$VB$Local_iLastID)
							});
							string text4 = Path.Combine(base_path, text3);
							CS$<>8__locals2.$VB$Local_basepathnoid = Path.Combine(base_path, array4[0] + "+" + array4[1] + "+");
							text3 = PublicModule.searchBitmapWithExt(text4, "");
							if (!string.IsNullOrEmpty(text3))
							{
								MemoryStream membmp7 = new MemoryStream();
								Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text3);
								PixelFormat pf = bitMapFromFile.PixelFormat;
								int width = bitMapFromFile.Width;
								int height = bitMapFromFile.Height;
								Rectangle rect = new Rectangle(0, 0, width, height);
								BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pf);
								Bitmap bitmap = new Bitmap(width, height, bitmapData.Stride, PublicModule.checkPixelFormat(pf), bitmapData.Scan0);
								bitMapFromFile.UnlockBits(bitmapData);
								bitmap.Save(membmp7, ImageFormat.Png);
								bitmap.Dispose();
								bitMapFromFile.Dispose();
								Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
								{
									delegate(string[] strArr, ParallelLoopState loopstate)
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
										string text5 = PublicModule.searchBitmapWithExt(CS$<>8__locals2.$VB$Local_basepathnoid + strArr[1], "");
										if (!string.IsNullOrEmpty(text5))
										{
											string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(text5);
											string[] source = fileNameWithoutExtension2.Split(new char[]
											{
												'+'
											});
											string text6 = source.First<string>() + "+";
											Bitmap bitmap2 = new Bitmap(CS$<>8__locals2.$VB$Local_image_width, CS$<>8__locals2.$VB$Local_image_height, pf);
											Graphics graphics = Graphics.FromImage(bitmap2);
											graphics.Clear(Color.Transparent);
											MemoryStream $VB$Local_membmp = membmp7;
											lock ($VB$Local_membmp)
											{
												using (Bitmap bitmap3 = (Bitmap)Image.FromStream(membmp7))
												{
													graphics.DrawImage(bitmap3, 0, 0, bitmap3.Width, bitmap3.Height);
												}
											}
											text6 += CS$<>8__locals2.$VB$Local_sLastName;
											if (CS$<>8__locals2.$VB$Local_iLastID != Conversions.ToInteger(strArr[1]))
											{
												using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5))
												{
													int width2 = bitMapFromFile2.Width;
													int height2 = bitMapFromFile2.Height;
													Rectangle rect2 = new Rectangle(0, 0, width2, height2);
													BitmapData bitmapData2 = bitMapFromFile2.LockBits(rect2, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
													Bitmap bitmap4 = new Bitmap(width2, height2, bitmapData2.Stride, PublicModule.checkPixelFormat(bitMapFromFile2.PixelFormat), bitmapData2.Scan0);
													bitMapFromFile2.UnlockBits(bitmapData2);
													graphics.DrawImage(bitmap4, Conversions.ToInteger(strArr[4]), Conversions.ToInteger(strArr[5]), bitmap4.Width, bitmap4.Height);
													bitmap4.Dispose();
												}
												text6 = text6 + "+" + strArr[0];
											}
											graphics.Dispose();
											PublicModule.saveBitmapFile(Path.Combine(base_path, text6), ref bitmap2, true);
											bitmap2.Dispose();
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(text5);
											}
											Interlocked.Add(ref PublicModule.iBuild, 1);
											BackgroundWorker2.ReportProgress(PublicModule.iNow);
											Thread.Sleep(PublicModule.iThreadWaitTime);
										}
									}((string[])a0, a1);
								});
								membmp7.Dispose();
								PublicModule.files2.Add(text3);
								PublicModule.files2.Add(text);
							}
						}
					}
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000059A4 File Offset: 0x00003BA4
		public static bool merge_ad_exl6ren_automcg(ref Form1 myForm1)
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
				ParallelOptions po = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, po, delegate(string sPath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (Strings.InStr(1, sPath, "+", CompareMethod.Binary) > 0)
					{
						return;
					}
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
					string[] substrings = new string[2];
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sPath);
					string directoryName = Path.GetDirectoryName(sPath);
					int num = 0;
					while (Versioned.IsNumeric(fileNameWithoutExtension[fileNameWithoutExtension.Length - (num + 1)]))
					{
						num++;
					}
					if (0 == num)
					{
						return;
					}
					substrings[0] = fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - num);
					substrings[1] = fileNameWithoutExtension.Substring(fileNameWithoutExtension.Length - num);
					string sMergeFiles = "";
					Parallel.ForEach<object>(PublicModule.files1.ToArray(), po, delegate(object a0, ParallelLoopState a1)
					{
						delegate(string sr, ParallelLoopState loopstate2)
						{
							if (Strings.InStr(1, sr, "+", CompareMethod.Binary) > 0)
							{
								string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(sr);
								if (Strings.InStr(1, fileNameWithoutExtension2, substrings[0] + "モ" + substrings[1] + "甲", CompareMethod.Binary) > 0)
								{
									sMergeFiles = sr;
									loopstate2.Stop();
									return;
								}
							}
						}(Conversions.ToString(a0), a1);
					});
					if (string.IsNullOrWhiteSpace(sMergeFiles))
					{
						sMergeFiles = PublicModule.sFindNameInArrayList(ref PublicModule.files1, substrings[0] + "モ" + substrings[1] + "甲");
					}
					if (File.Exists(sMergeFiles))
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						string[] array2 = asmodean_fun.get_ad_xy(Path.GetFileNameWithoutExtension(sMergeFiles));
						Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(sPath);
						PixelFormat pixelFormat = bitMapFromFile.PixelFormat;
						int width = bitMapFromFile.Width;
						int height = bitMapFromFile.Height;
						Rectangle rect = new Rectangle(0, 0, width, height);
						BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
						Bitmap bitmap = new Bitmap(width, height, bitmapData.Stride, PublicModule.checkPixelFormat(pixelFormat), bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sMergeFiles);
						PixelFormat pixelFormat2 = bitMapFromFile2.PixelFormat;
						int width2 = bitMapFromFile2.Width;
						int height2 = bitMapFromFile2.Height;
						rect = new Rectangle(0, 0, width2, height2);
						bitmapData = bitMapFromFile2.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat2);
						Bitmap bitmap2 = new Bitmap(width2, height2, bitmapData.Stride, PublicModule.checkPixelFormat(pixelFormat2), bitmapData.Scan0);
						bitMapFromFile2.UnlockBits(bitmapData);
						Bitmap bitmap3 = new Bitmap(width, height, PublicModule.checkPixelFormat(pixelFormat));
						Graphics graphics = Graphics.FromImage(bitmap3);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(bitmap, 0, 0, width, height);
						graphics.DrawImage(bitmap2, Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), width2, height2);
						graphics.Dispose();
						bitmap.Dispose();
						bitMapFromFile.Dispose();
						bitmap2.Dispose();
						bitMapFromFile2.Dispose();
						string sSavePath = Path.Combine(directoryName, string.Concat(new string[]
						{
							fileNameWithoutExtension,
							"+x",
							array2[1],
							"y",
							array2[2]
						}));
						PublicModule.saveBitmapFile(sSavePath, ref bitmap3, true);
						bitmap3.Dispose();
						Interlocked.Add(ref PublicModule.iBuild, 1);
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(sPath);
							PublicModule.files2.Add(sMergeFiles);
						}
						BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					}
				});
				return eCancel;
			}
		}
	}
}
