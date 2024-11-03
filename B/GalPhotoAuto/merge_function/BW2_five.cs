using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x0200004D RID: 77
	public class BW2_five
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x0000EC78 File Offset: 0x0000CE78
		public static bool crass_PJADV(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			bool flag = false;
			if (0 == string.Compare(PublicModule.sGameExe, "ikedukuri", StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
			}
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
			string[] array2 = array;
			int i = 0;
			string base_path;
			while (i < array2.Length)
			{
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
				base_path = Path.GetDirectoryName(text);
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
					PublicModule.addLog(Conversions.ToString(arrayList.Count));
					if (0 < arrayList.Count)
					{
						PublicModule.iMaxToBW = arrayList.Count;
						Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
						{
							delegate(string[] sData, ParallelLoopState loopstate)
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
								string text4 = Path.Combine(base_path, Path.ChangeExtension(sData[1], "png"));
								if (File.Exists(text4))
								{
									string text5 = Path.Combine(base_path, Path.ChangeExtension(sData[2], "png"));
									if (File.Exists(text5))
									{
										ArrayList files = PublicModule.files2;
										lock (files)
										{
											PublicModule.files2.Add(text5);
										}
										Bitmap bitmap;
										Graphics graphics;
										using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text4))
										{
											bitmap = new Bitmap(bitMapFromFile.Width, bitMapFromFile.Height, bitMapFromFile.PixelFormat);
											graphics = Graphics.FromImage(bitmap);
											graphics.DrawImage(bitMapFromFile, 0, 0, bitMapFromFile.Width, bitMapFromFile.Height);
										}
										using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text5))
										{
											graphics.DrawImage(bitMapFromFile2, Conversions.ToInteger(sData[3]), Conversions.ToInteger(sData[4]), Conversions.ToInteger(sData[5]), Conversions.ToInteger(sData[6]));
										}
										graphics.Dispose();
										string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sData[1]);
										string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(sData[2]);
										string sSavePath = Path.Combine(base_path, fileNameWithoutExtension + "_" + fileNameWithoutExtension2);
										PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
										Interlocked.Add(ref PublicModule.iBuild, 1);
										bitmap.Dispose();
									}
								}
								BackgroundWorker2.ReportProgress(PublicModule.iNow);
								Thread.Sleep(PublicModule.iThreadWaitTime);
							}((string[])a0, a1);
						});
						PublicModule.files2.Add(text);
						goto IL_336;
					}
					goto IL_336;
				}
			}
			PublicModule.sSpecialExt = string.Empty;
			return eCancel;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000EFF8 File Offset: 0x0000D1F8
		public static bool crass_NScripter(ref Form1 myForm1)
		{
			BW2_five._Closure$__66 CS$<>8__locals1 = new BW2_five._Closure$__66();
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
					BW2_five._Closure$__66._Closure$__67 CS$<>8__locals2 = new BW2_five._Closure$__66._Closure$__67(CS$<>8__locals2);
					string path = array2[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42 = CS$<>8__locals1;
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
					if (0 == string.Compare(Path.GetFileName(path), "nscript.txt", StringComparison.Ordinal))
					{
						string directoryName = Path.GetDirectoryName(path);
						CS$<>8__locals2.$VB$Local_iWidth = 0;
						CS$<>8__locals2.$VB$Local_iHeight = 0;
						ArrayList arrayList = new ArrayList();
						CS$<>8__locals2.$VB$Local_imgArr = new ArrayList();
						using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
							{
								while (!streamReader.EndOfStream)
								{
									string text = streamReader.ReadLine();
									if (0 == CS$<>8__locals2.$VB$Local_iWidth)
									{
										string[] array3 = PublicModule.regSmallSpace.Split(text);
										if (0 == string.Compare(array3[0], "setwindow", StringComparison.Ordinal))
										{
											string[] array4 = array3[1].Split(new char[]
											{
												','
											});
											CS$<>8__locals2.$VB$Local_iHeight = Conversions.ToInteger(array4.Last<string>());
											CS$<>8__locals2.$VB$Local_iWidth = Conversions.ToInteger(array4[array4.Count<string>() - 2]);
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
						if (0 != CS$<>8__locals2.$VB$Local_iWidth)
						{
							try
							{
								IEnumerator enumerator = arrayList.GetEnumerator();
								while (enumerator.MoveNext())
								{
									BW2_five._Closure$__66._Closure$__67._Closure$__68 CS$<>8__locals3 = new BW2_five._Closure$__66._Closure$__67._Closure$__68(CS$<>8__locals3);
									string text2 = Conversions.ToString(enumerator.Current);
									CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_43 = CS$<>8__locals2;
									CS$<>8__locals3.$VB$Local_subs = text2.Split(new char[]
									{
										','
									});
									CS$<>8__locals3.$VB$Local_subs2 = CS$<>8__locals3.$VB$Local_subs[0].Split(new char[]
									{
										'/'
									});
									if (3 <= CS$<>8__locals3.$VB$Local_subs2.Count<string>())
									{
										if (Strings.InStr(1, CS$<>8__locals3.$VB$Local_subs[0], "$", CompareMethod.Binary) > 0)
										{
											CS$<>8__locals3.$VB$Local_subs2 = CS$<>8__locals3.$VB$Local_subs[0].Replace("/", "\\").Split(new char[]
											{
												'"'
											});
											string path2 = Path.Combine(directoryName, Path.GetDirectoryName(CS$<>8__locals3.$VB$Local_subs2[0]));
											if (Directory.Exists(path2))
											{
												string[] files = Directory.GetFiles(path2);
												Parallel.ForEach<string>(files, parallelOptions, delegate(string sfile)
												{
													if (Strings.InStr(1, sfile, CS$<>8__locals3.$VB$Local_subs2[0], CompareMethod.Binary) > 0)
													{
														string[] value3 = new string[]
														{
															sfile,
															CS$<>8__locals3.$VB$Local_subs[1],
															CS$<>8__locals3.$VB$Local_subs[2]
														};
														ArrayList $VB$Local_imgArr = CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_43.$VB$Local_imgArr;
														lock ($VB$Local_imgArr)
														{
															CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_43.$VB$Local_imgArr.Add(value3);
														}
													}
												});
											}
										}
										else
										{
											string[] value2 = new string[]
											{
												Path.Combine(directoryName, CS$<>8__locals3.$VB$Local_subs[0].Replace("\"", string.Empty)).Replace("/", "\\"),
												CS$<>8__locals3.$VB$Local_subs[1],
												CS$<>8__locals3.$VB$Local_subs[2]
											};
											CS$<>8__locals2.$VB$Local_imgArr.Add(value2);
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
							Parallel.ForEach<object>(CS$<>8__locals2.$VB$Local_imgArr.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
							{
								delegate(string[] fileArr, ParallelLoopState loopstate)
								{
									Interlocked.Add(ref PublicModule.iNow, 1);
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
									while (PublicModule.bWaitCancelAsync)
									{
										Thread.Sleep(500);
										if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42.$VB$Local_BackgroundWorker2.CancellationPending)
										{
											CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42.$VB$Local_eCancel = true;
											loopstate.Stop();
										}
									}
									if (File.Exists(fileArr[0]))
									{
										Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, PixelFormat.Format32bppArgb);
										Graphics graphics = Graphics.FromImage(bitmap);
										graphics.Clear(Color.Transparent);
										Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(fileArr[0]);
										int width = bitMapFromFile.Width;
										int height = bitMapFromFile.Height;
										if (CS$<>8__locals2.$VB$Local_iWidth == width & CS$<>8__locals2.$VB$Local_iHeight == height)
										{
											return;
										}
										Color pixel = bitMapFromFile.GetPixel(0, 0);
										int x = Conversions.ToInteger(fileArr[1]);
										int y = Conversions.ToInteger(fileArr[2]);
										if (width > CS$<>8__locals2.$VB$Local_iWidth & (pixel.R == 255 & pixel.G == 255 & pixel.B == 255))
										{
											graphics.Clear(Color.White);
											int num = width / 2;
											Rectangle rect = new Rectangle(num, 0, num, height);
											BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile.PixelFormat);
											Bitmap bitmap2 = new Bitmap(num, height, bitmapData.Stride, bitMapFromFile.PixelFormat, bitmapData.Scan0);
											bitMapFromFile.UnlockBits(bitmapData);
											graphics.DrawImage(bitmap2, x, y, num, height);
											bitmap2.Dispose();
										}
										else
										{
											int num2 = width / 2;
											Rectangle rect2 = new Rectangle(num2, 0, num2, height);
											BitmapData bitmapData2 = bitMapFromFile.LockBits(rect2, ImageLockMode.ReadOnly, bitMapFromFile.PixelFormat);
											Bitmap bitmap3 = new Bitmap(num2, height, bitmapData2.Stride, bitMapFromFile.PixelFormat, bitmapData2.Scan0);
											bitMapFromFile.UnlockBits(bitmapData2);
											int num3 = 0;
											int num4 = 0;
											int num5 = 0;
											int num6 = 0;
											int num7 = num2 - 1;
											for (int j = num6; j <= num7; j++)
											{
												int num8 = 0;
												int num9 = height - 1;
												for (int k = num8; k <= num9; k++)
												{
													Color pixel2 = bitmap3.GetPixel(j, k);
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
												Bitmap bitmap4 = new Bitmap(num2, height, PixelFormat.Format32bppArgb);
												int num10 = 0;
												int num11 = num2 - 1;
												for (int l = num10; l <= num11; l++)
												{
													int num12 = 0;
													int num13 = height - 1;
													for (int m = num12; m <= num13; m++)
													{
														Color pixel2 = bitMapFromFile.GetPixel(l, m);
														Color pixel3 = bitmap3.GetPixel(l, m);
														int alpha = 255 - PublicModule.getiAlphaFromColor(ref pixel3);
														bitmap4.SetPixel(l, m, Color.FromArgb(alpha, pixel2));
													}
												}
												graphics.DrawImage(bitmap4, x, y, num2, height);
												bitmap4.Dispose();
											}
											else
											{
												graphics.DrawImage(bitMapFromFile, x, y, width, height);
											}
											bitmap3.Dispose();
										}
										bitMapFromFile.Dispose();
										graphics.Dispose();
										PublicModule.saveBitmapFile(fileArr[0], ref bitmap, true);
										bitmap.Dispose();
										Interlocked.Add(ref PublicModule.iBuild, 1);
										ArrayList files2 = PublicModule.files2;
										lock (files2)
										{
											PublicModule.files2.Add(fileArr[0]);
										}
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_42.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
										Thread.Sleep(PublicModule.iThreadWaitTime);
									}
								}((string[])a0, a1);
							});
						}
					}
				}
				PublicModule.sSpecialExt = string.Empty;
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000F44C File Offset: 0x0000D64C
		public static bool crass_PJADV_anm(ref Form1 myForm1)
		{
			bool eCancel = false;
			PublicModule.iCount = PublicModule.files1.Count;
			checked
			{
				PublicModule.iMaxToBW = PublicModule.iCount * 3;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker2 = myForm1.BackgroundWorker2;
				Parallel.ForEach<string>(array, parallelOptions, delegate(string anmpath, ParallelLoopState loopstate)
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
					string directoryName = Path.GetDirectoryName(anmpath);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(anmpath);
					string text = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, fileNameWithoutExtension), "");
					if (File.Exists(text))
					{
						int num = 3;
						if (Strings.InStr(1, fileNameWithoutExtension, "Seye", CompareMethod.Binary) > 0)
						{
							num = 4;
						}
						string text2 = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - num)), "");
						if (File.Exists(text2))
						{
							int num3;
							int num4;
							int num5;
							int num6;
							using (FileStream fileStream = new FileStream(anmpath, FileMode.Open, FileAccess.Read, FileShare.Read))
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
							Interlocked.Add(ref PublicModule.iNow, 2);
							PublicModule.files2.Add(text2);
							PublicModule.files2.Add(text);
							Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text2);
							Graphics graphics = Graphics.FromImage(bitMapFromFile);
							using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text))
							{
								int num7 = bitMapFromFile2.Height / num6;
								int num8 = 0;
								int num9 = num7 - 1;
								for (int i = num8; i <= num9; i++)
								{
									Rectangle rect = new Rectangle(0, i * num6, num5, num6);
									BitmapData bitmapData = bitMapFromFile2.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
									Bitmap bitmap = new Bitmap(num5, num6, bitmapData.Stride, bitMapFromFile2.PixelFormat, bitmapData.Scan0);
									bitMapFromFile2.UnlockBits(bitmapData);
									graphics.DrawImage(bitmap, num3, num4, num5, num6);
									bitmap.Dispose();
									string text3 = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(text2));
									if (4 == num)
									{
										text3 = text3 + "S_" + i.ToString("D3");
									}
									else
									{
										text3 = text3 + "_" + i.ToString("D3");
									}
									PublicModule.saveBitmapFile(text3, ref bitMapFromFile, true);
									Interlocked.Add(ref PublicModule.iBuild, 1);
									BackgroundWorker2.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								}
							}
							bitMapFromFile.Dispose();
							PublicModule.files2.Add(anmpath);
						}
					}
				});
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		public static bool crass_DDSystem_tga(ref Form1 myForm1)
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
				ArrayList zeroimg = new ArrayList(10);
				Parallel.ForEach<string>(array, parallelOptions, delegate(string imgpath, ParallelLoopState loopstate)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imgpath);
					if (Versioned.IsNumeric(fileNameWithoutExtension) && Conversions.ToInteger(fileNameWithoutExtension) == 0)
					{
						ArrayList $VB$Local_zeroimg = zeroimg;
						lock ($VB$Local_zeroimg)
						{
							zeroimg.Add(imgpath);
						}
					}
				});
				Parallel.ForEach<object>(zeroimg.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
				{
					delegate(string zeroimgpath, ParallelLoopState loopstate)
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
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(zeroimgpath);
						string directoryName = Path.GetDirectoryName(zeroimgpath);
						int length = fileNameWithoutExtension.Length;
						Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(zeroimgpath);
						if (PublicModule.isNeedDevIL(zeroimgpath))
						{
							PublicModule.saveBitmapFile(Path.Combine(directoryName, fileNameWithoutExtension), ref bitMapFromFile, true);
							Interlocked.Add(ref PublicModule.iBuild, 1);
							Interlocked.Add(ref PublicModule.iNow, 1);
							ArrayList files = PublicModule.files2;
							lock (files)
							{
								PublicModule.files2.Add(zeroimgpath);
							}
						}
						Graphics graphics = Graphics.FromImage(bitMapFromFile);
						int num = 0;
						for (;;)
						{
							num++;
							string text = PublicModule.searchBitmapWithExt(Path.Combine(directoryName, num.ToString("D6")), "");
							if (string.IsNullOrEmpty(text))
							{
								break;
							}
							using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text))
							{
								graphics.DrawImage(bitMapFromFile2, 0, 0, bitMapFromFile2.Width, bitMapFromFile2.Height);
							}
							string sSavePath = Path.Combine(directoryName, fileNameWithoutExtension + "_" + num.ToString("D6"));
							PublicModule.saveBitmapFile(sSavePath, ref bitMapFromFile, true);
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(text);
							}
							Interlocked.Add(ref PublicModule.iBuild, 1);
							Interlocked.Add(ref PublicModule.iNow, 1);
							BackgroundWorker2.ReportProgress(PublicModule.iNow);
							Thread.Sleep(PublicModule.iThreadWaitTime);
						}
						graphics.Dispose();
						bitMapFromFile.Dispose();
					}(Conversions.ToString(a0), a1);
				});
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return eCancel;
			}
		}
	}
}
