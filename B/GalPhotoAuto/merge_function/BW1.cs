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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x0200002A RID: 42
	public class BW1
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00008A24 File Offset: 0x00006C24
		public static bool cutImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				int iX = Convert.ToInt32(myForm1.NumericUpDown1.Value);
				int iY = Convert.ToInt32(myForm1.NumericUpDown2.Value);
				int iW = Convert.ToInt32(myForm1.NumericUpDown3.Value);
				int iH = Convert.ToInt32(myForm1.NumericUpDown4.Value);
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					bool flag = false;
					try
					{
						Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath);
						if (bitMapFromFile.Width < iW + iX | bitMapFromFile.Height < iH + iY)
						{
							bitMapFromFile.Dispose();
							return;
						}
						Rectangle rect = new Rectangle(iX, iY, iW, iH);
						BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile.PixelFormat);
						Bitmap bitmap = new Bitmap(iW, iH, bitmapData.Stride, bitMapFromFile.PixelFormat, bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						bitmap.Save(thispath + ".cut.bmp", ImageFormat.Bmp);
						bitMapFromFile.Dispose();
						bitmap.Dispose();
						flag = true;
					}
					catch (Exception ex)
					{
						flag = false;
						PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_cutImage_errmsg") + ex.Message + " : " + thispath);
						throw new Exception(ex.Message);
					}
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iBuild, 1);
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(thispath);
						}
					}
					BackgroundWorker1.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00008B2C File Offset: 0x00006D2C
		public static bool scan32BitImage(ref Form1 myForm1)
		{
			BW1._Closure$__33 CS$<>8__locals1 = new BW1._Closure$__33(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_bForce = myForm1.CheckBox1.Checked;
				CS$<>8__locals1.$VB$Local_BackgroundWorker1 = myForm1.BackgroundWorker1;
				CS$<>8__locals1.$VB$Local_iJpgPercent = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown5.Value, 1m));
				CS$<>8__locals1.$VB$Local_RadioButton6 = myForm1.RadioButton6;
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (CS$<>8__locals1.$VB$Local_BackgroundWorker1.CancellationPending)
					{
						CS$<>8__locals1.$VB$Local_eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (CS$<>8__locals1.$VB$Local_BackgroundWorker1.CancellationPending)
						{
							CS$<>8__locals1.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
					}
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					bool flag = false;
					try
					{
						MemoryStream memoryStream = new MemoryStream();
						using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath))
						{
							bitMapFromFile.Save(memoryStream, ImageFormat.Bmp);
						}
						Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
						if (bitmap.PixelFormat == PixelFormat.Format32bppArgb | bitmap.PixelFormat == PixelFormat.Format32bppRgb)
						{
							FastBitmap fastBitmap = new FastBitmap(bitmap);
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							bool flag2;
							if (!CS$<>8__locals1.$VB$Local_bForce)
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
							if (flag2 | CS$<>8__locals1.$VB$Local_bForce)
							{
								if (CS$<>8__locals1.$VB$Local_RadioButton6.Checked)
								{
									Encoder quality = Encoder.Quality;
									EncoderParameters encoderParameters = new EncoderParameters(1);
									EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)CS$<>8__locals1.$VB$Local_iJpgPercent));
									encoderParameters.Param[0] = encoderParameter;
									ImageCodecInfo encoder = PublicModule.GetEncoder(ImageFormat.Jpeg);
									fastBitmap.Image.Save(thispath + ".32to24.jpg", encoder, encoderParameters);
									encoderParameter.Dispose();
									encoderParameters.Dispose();
								}
								else
								{
									Rectangle rect = new Rectangle(0, 0, iWidth, iHeight);
									using (Bitmap bitmap2 = fastBitmap.Image.Clone(rect, PixelFormat.Format24bppRgb))
									{
										bitmap2.Save(thispath + ".32to24.bmp", ImageFormat.Bmp);
									}
								}
								flag = true;
							}
							fastBitmap.Dispose();
						}
						bitmap.Dispose();
						memoryStream.Dispose();
					}
					catch (Exception ex)
					{
						flag = false;
						PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_scan32BitImage_errmsg") + ex.Message + " : " + thispath);
						throw new Exception(ex.Message);
					}
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iBuild, 1);
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(thispath);
						}
					}
					CS$<>8__locals1.$VB$Local_BackgroundWorker1.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00008C18 File Offset: 0x00006E18
		public static bool TransparentImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
			BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
			Color pColor = Color.Transparent;
			if (myForm1.RadioButton9.Checked)
			{
				pColor = myForm1.Panel4.BackColor;
			}
			else if (myForm1.RadioButton10.Checked)
			{
				pColor = myForm1.Panel5.BackColor;
			}
			else if (myForm1.RadioButton11.Checked)
			{
				pColor = myForm1.Panel6.BackColor;
			}
			else if (myForm1.RadioButton12.Checked)
			{
				pColor = myForm1.Panel7.BackColor;
			}
			Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
			{
				Interlocked.Add(ref PublicModule.iNow, 1);
				if (BackgroundWorker1.CancellationPending)
				{
					eCancel = true;
					loopstate.Stop();
				}
				while (PublicModule.bWaitCancelAsync)
				{
					Thread.Sleep(500);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
				}
				bool flag = false;
				try
				{
					Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath);
					bitMapFromFile.MakeTransparent(pColor);
					bitMapFromFile.Save(thispath + ".tran.bmp", ImageFormat.Bmp);
					bitMapFromFile.Dispose();
					flag = true;
				}
				catch (Exception ex)
				{
					flag = false;
					PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_TransparentImage_errmsg") + ex.Message + " : " + thispath);
				}
				if (flag)
				{
					Interlocked.Add(ref PublicModule.iBuild, 1);
					ArrayList files = PublicModule.files2;
					lock (files)
					{
						PublicModule.files2.Add(thispath);
					}
				}
				BackgroundWorker1.ReportProgress(PublicModule.iNow);
				Thread.Sleep(PublicModule.iThreadWaitTime);
			});
			return eCancel;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008D54 File Offset: 0x00006F54
		public static bool ConvertImageFormatToX(ref Form1 myForm1, ref ArrayList arr)
		{
			bool eCancel = false;
			int c1 = Conversions.ToInteger(arr[0]);
			int num = Conversions.ToInteger(arr[1]);
			int c3 = Conversions.ToInteger(arr[2]);
			bool balphabw = Conversions.ToBoolean(arr[4]);
			if (0 == num | 0 == c3 | num == c3)
			{
				PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_ConvertImageFormat_errmsg_1"));
				return eCancel;
			}
			PublicModule.sSpecialExt = Conversions.ToString(arr[3]);
			if (string.IsNullOrWhiteSpace(PublicModule.sSpecialExt))
			{
				return eCancel;
			}
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			int iJpgPercent = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown6.Value, 1m));
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				int iWait = PublicModule.iThreadWaitTime * parallelOptions.MaxDegreeOfParallelism;
				if (100 > iWait)
				{
					iWait = 100;
				}
				object objectValue = RuntimeHelpers.GetObjectValue(new object());
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					bool flag = false;
					try
					{
						Bitmap bitmap;
						if (PublicModule.isNeedDevIL(thispath))
						{
							bitmap = (Bitmap)Image.FromFile(thispath);
						}
						else
						{
							FileInfo fileInfo = new FileInfo(thispath);
							FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
							MemoryStream memoryStream = new MemoryStream();
							fileStream.CopyTo(memoryStream);
							fileStream.Dispose();
							bitmap = (Bitmap)Image.FromStream(memoryStream);
							memoryStream.Dispose();
						}
						PixelFormat pixelFormat = bitmap.PixelFormat;
						bool flag2 = false;
						bool flag3 = false;
						switch (c1)
						{
						case 0:
							flag2 = true;
							if (PixelFormat.Format1bppIndexed == pixelFormat | PixelFormat.Format4bppIndexed == pixelFormat | PixelFormat.Format8bppIndexed == pixelFormat)
							{
								flag3 = true;
							}
							break;
						case 1:
							if (pixelFormat == PixelFormat.Format32bppArgb | pixelFormat == PixelFormat.Format32bppRgb)
							{
								flag2 = true;
							}
							break;
						case 2:
							if (pixelFormat == PixelFormat.Format24bppRgb)
							{
								flag2 = true;
							}
							break;
						}
						if (flag2)
						{
							int width = bitmap.Width;
							int height = bitmap.Height;
							PixelFormat pixelFormat2 = PublicModule.checkPixelFormat(pixelFormat);
							Bitmap bitmap2;
							if (flag3)
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
							if (balphabw && (pixelFormat2 == PixelFormat.Format32bppArgb | pixelFormat2 == PixelFormat.Format32bppRgb))
							{
								int num2 = 0;
								int num3 = width - 1;
								for (int i = num2; i <= num3; i++)
								{
									int num4 = 0;
									int num5 = height - 1;
									for (int j = num4; j <= num5; j++)
									{
										Color pixel = fastBitmap.GetPixel(i, j);
										int alpha = (int)(byte.MaxValue - pixel.A);
										fastBitmap.SetPixel(i, j, Color.FromArgb(alpha, pixel));
									}
								}
							}
							string sPath = string.Empty;
							switch (c3)
							{
							case 1:
								sPath = Path.ChangeExtension(thispath, "bmp");
								fastBitmap.Save(sPath, ImageFormat.Bmp);
								break;
							case 2:
								sPath = Path.ChangeExtension(thispath, "png");
								fastBitmap.Save(sPath, ImageFormat.Png);
								break;
							case 3:
							{
								Encoder quality = Encoder.Quality;
								EncoderParameters encoderParameters = new EncoderParameters(1);
								EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)iJpgPercent));
								encoderParameters.Param[0] = encoderParameter;
								ImageCodecInfo encoder = PublicModule.GetEncoder(ImageFormat.Jpeg);
								sPath = Path.ChangeExtension(thispath, "jpg");
								fastBitmap.Save(sPath, encoder, ref encoderParameters);
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
						PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_ConvertImageFormat_errmsg_2") + ex.Message + " : " + thispath);
					}
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iBuild, 1);
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(thispath);
						}
					}
					BackgroundWorker1.ReportProgress(PublicModule.iNow);
					Thread.Sleep(iWait);
				});
				return eCancel;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00008EF4 File Offset: 0x000070F4
		public static bool checkBlackAlphaCutImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					bool flag = false;
					MemoryStream memoryStream = new MemoryStream();
					try
					{
						PixelFormat pixelFormat;
						using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath))
						{
							pixelFormat = bitMapFromFile.PixelFormat;
							bitMapFromFile.Save(memoryStream, ImageFormat.Png);
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
								Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
								Rectangle rect = new Rectangle(num, num2, width, height);
								BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
								Bitmap bitmap2 = new Bitmap(width, height, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
								bitmap.UnlockBits(bitmapData);
								bitmap2.Save(thispath + ".cut.bmp", ImageFormat.Bmp);
								bitmap2.Dispose();
								bitmap.Dispose();
								flag = true;
							}
						}
					}
					catch (Exception ex)
					{
						flag = false;
						PublicModule.addLog(PublicModule.thisLang.getMultiLingual("BW1_checkBlackAlphaCutImage_errmsg") + ex.Message + " : " + thispath);
					}
					memoryStream.Dispose();
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iBuild, 1);
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(thispath);
						}
					}
					BackgroundWorker1.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00008FA0 File Offset: 0x000071A0
		public static bool defineWidthCutImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions po = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				bool bCutWithW = myForm1.RadioButton18.Checked;
				int iSetWidth = Convert.ToInt32(myForm1.NumericUpDown7.Value);
				int iSetNum = Convert.ToInt32(myForm1.NumericUpDown9.Value);
				if (bCutWithW)
				{
					if (0 >= iSetWidth)
					{
						return eCancel;
					}
				}
				else if (0 >= iSetNum)
				{
					return eCancel;
				}
				bool bSaveBMP = myForm1.RadioButton17.Checked;
				int iJpgPercent = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown8.Value, 1m));
				Parallel.ForEach<string>(array, po, delegate(string thispath, ParallelLoopState loopstate)
				{
					BW1._Closure$__37._Closure$__38 CS$<>8__locals2 = new BW1._Closure$__37._Closure$__38();
					CS$<>8__locals2.$VB$Local_thispath = thispath;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					MemoryStream stream = new MemoryStream();
					int isouH;
					int iTemp;
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_thispath))
					{
						iTemp = bitMapFromFile.Width;
						isouH = bitMapFromFile.Height;
						bitMapFromFile.Save(stream, ImageFormat.Png);
					}
					int iThisWidth = 0;
					int num;
					if (bCutWithW)
					{
						iThisWidth = iSetWidth;
						num = (int)Math.Round((double)iTemp / (double)iThisWidth);
						double num2 = (double)iTemp / (double)iThisWidth;
						if (num2 > (double)num)
						{
							num++;
						}
					}
					else
					{
						iThisWidth = (int)Math.Round((double)iTemp / (double)iSetNum);
						num = iSetNum;
						double num2 = (double)iTemp / (double)iSetNum;
						if (num2 > (double)iThisWidth)
						{
							num++;
						}
					}
					Parallel.For(0, num, po, delegate(int ims, ParallelLoopState loopstate2)
					{
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate2.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (BackgroundWorker1.CancellationPending)
							{
								eCancel = true;
								loopstate2.Stop();
							}
						}
						bool flag = false;
						int width = iThisWidth;
						int num3 = ims * iThisWidth + iThisWidth;
						if (num3 > iTemp)
						{
							width = iThisWidth - (num3 - iTemp);
						}
						try
						{
							MemoryStream $VB$Local_stream = stream;
							Bitmap bitmap;
							lock ($VB$Local_stream)
							{
								bitmap = (Bitmap)Image.FromStream(stream);
							}
							Rectangle rect = new Rectangle(ims * iThisWidth, 0, width, isouH);
							BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
							Bitmap bitmap2 = new Bitmap(width, isouH, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
							bitmap.UnlockBits(bitmapData);
							string str = Path.Combine(Path.GetDirectoryName(CS$<>8__locals2.$VB$Local_thispath), Path.GetFileNameWithoutExtension(CS$<>8__locals2.$VB$Local_thispath) + "_" + ims.ToString("D3"));
							if (bSaveBMP)
							{
								bitmap2.Save(str + ".bmp", ImageFormat.Bmp);
							}
							else
							{
								Encoder quality = Encoder.Quality;
								EncoderParameters encoderParameters = new EncoderParameters(1);
								EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)iJpgPercent));
								encoderParameters.Param[0] = encoderParameter;
								ImageCodecInfo encoder = PublicModule.GetEncoder(ImageFormat.Jpeg);
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
							PublicModule.addLog(ex.Message);
						}
						if (flag)
						{
							Interlocked.Add(ref PublicModule.iBuild, 1);
							ArrayList files = PublicModule.files2;
							lock (files)
							{
								PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_thispath);
							}
						}
						BackgroundWorker1.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					stream.Dispose();
				});
				return eCancel;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000090EC File Offset: 0x000072EC
		public static bool defineHeightCutImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions po = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				bool bCutWithH = myForm1.RadioButton21.Checked;
				int iSetHeight = Convert.ToInt32(myForm1.NumericUpDown10.Value);
				int iSetNum = Convert.ToInt32(myForm1.NumericUpDown11.Value);
				if (bCutWithH)
				{
					if (0 >= iSetHeight)
					{
						return eCancel;
					}
				}
				else if (0 >= iSetNum)
				{
					return eCancel;
				}
				bool bSaveBMP = myForm1.RadioButton24.Checked;
				int iJpgPercent = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown12.Value, 1m));
				Parallel.ForEach<string>(array, po, delegate(string thispath, ParallelLoopState loopstate)
				{
					BW1._Closure$__40._Closure$__41 CS$<>8__locals2 = new BW1._Closure$__40._Closure$__41();
					CS$<>8__locals2.$VB$Local_thispath = thispath;
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					MemoryStream stream = new MemoryStream();
					int isouW;
					int iTemp;
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(CS$<>8__locals2.$VB$Local_thispath))
					{
						isouW = bitMapFromFile.Width;
						iTemp = bitMapFromFile.Height;
						bitMapFromFile.Save(stream, ImageFormat.Png);
					}
					int iThisHeight = 0;
					int num;
					if (bCutWithH)
					{
						iThisHeight = iSetHeight;
						num = (int)Math.Round((double)iTemp / (double)iThisHeight);
						double num2 = (double)iTemp / (double)iThisHeight;
						if (num2 > (double)num)
						{
							num++;
						}
					}
					else
					{
						iThisHeight = (int)Math.Round((double)iTemp / (double)iSetNum);
						num = iSetNum;
						double num2 = (double)iTemp / (double)iSetNum;
						if (num2 > (double)iThisHeight)
						{
							num++;
						}
					}
					Parallel.For(0, num, po, delegate(int ims, ParallelLoopState loopstate2)
					{
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate2.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (BackgroundWorker1.CancellationPending)
							{
								eCancel = true;
								loopstate2.Stop();
							}
						}
						bool flag = false;
						int height = iThisHeight;
						int num3 = ims * iThisHeight + iThisHeight;
						if (num3 > iTemp)
						{
							height = iThisHeight - (num3 - iTemp);
						}
						try
						{
							MemoryStream $VB$Local_stream = stream;
							Bitmap bitmap;
							lock ($VB$Local_stream)
							{
								bitmap = (Bitmap)Image.FromStream(stream);
							}
							Rectangle rect = new Rectangle(0, ims * iThisHeight, isouW, height);
							BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
							Bitmap bitmap2 = new Bitmap(isouW, height, bitmapData.Stride, bitmap.PixelFormat, bitmapData.Scan0);
							bitmap.UnlockBits(bitmapData);
							string str = Path.Combine(Path.GetDirectoryName(CS$<>8__locals2.$VB$Local_thispath), Path.GetFileNameWithoutExtension(CS$<>8__locals2.$VB$Local_thispath) + "_" + ims.ToString("D3"));
							if (bSaveBMP)
							{
								bitmap2.Save(str + ".bmp", ImageFormat.Bmp);
							}
							else
							{
								Encoder quality = Encoder.Quality;
								EncoderParameters encoderParameters = new EncoderParameters(1);
								EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)iJpgPercent));
								encoderParameters.Param[0] = encoderParameter;
								ImageCodecInfo encoder = PublicModule.GetEncoder(ImageFormat.Jpeg);
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
							PublicModule.addLog(ex.Message);
						}
						if (flag)
						{
							Interlocked.Add(ref PublicModule.iBuild, 1);
							ArrayList files = PublicModule.files2;
							lock (files)
							{
								PublicModule.files2.Add(CS$<>8__locals2.$VB$Local_thispath);
							}
						}
						BackgroundWorker1.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					stream.Dispose();
				});
				return eCancel;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00009238 File Offset: 0x00007438
		public static bool reSizeImage(ref Form1 myForm1)
		{
			bool eCancel = false;
			Form1 form = myForm1;
			ListBox listBox = form.ListBox1;
			PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
			form.ListBox1 = listBox;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			checked
			{
				string[] array = new string[PublicModule.iCount - 1 + 1];
				PublicModule.files1.CopyTo(array, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				BackgroundWorker BackgroundWorker1 = myForm1.BackgroundWorker1;
				bool bDel = myForm1.CheckBox5.Checked;
				int iSelects = 0;
				int iSetNum = 0;
				if (myForm1.RadioButton8.Checked)
				{
					iSelects = 1;
					iSetNum = Convert.ToInt32(myForm1.NumericUpDown14.Value);
				}
				else if (myForm1.RadioButton25.Checked)
				{
					iSelects = 2;
					iSetNum = Convert.ToInt32(myForm1.NumericUpDown15.Value);
				}
				else if (myForm1.RadioButton26.Checked)
				{
					iSelects = 3;
					iSetNum = Convert.ToInt32(myForm1.NumericUpDown16.Value);
				}
				if (0 == iSelects | 0 == iSetNum)
				{
					return eCancel;
				}
				bool bSaveBMP = myForm1.RadioButton28.Checked;
				int iJpgPercent = Convert.ToInt32(decimal.Add(myForm1.NumericUpDown17.Value, 1m));
				Parallel.ForEach<string>(array, parallelOptions, delegate(string thispath, ParallelLoopState loopstate)
				{
					Interlocked.Add(ref PublicModule.iNow, 1);
					if (BackgroundWorker1.CancellationPending)
					{
						eCancel = true;
						loopstate.Stop();
					}
					while (PublicModule.bWaitCancelAsync)
					{
						Thread.Sleep(500);
						if (BackgroundWorker1.CancellationPending)
						{
							eCancel = true;
							loopstate.Stop();
						}
					}
					Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath);
					int width = bitMapFromFile.Width;
					int height = bitMapFromFile.Height;
					PixelFormat pixelFormat = bitMapFromFile.PixelFormat;
					PixelFormat format = PublicModule.checkPixelFormat(pixelFormat);
					int num;
					int height2;
					if (iSelects == 1)
					{
						num = iSetNum;
						height2 = (int)Math.Round(unchecked((double)iSetNum / (double)width * (double)height));
					}
					else if (iSelects == 2)
					{
						num = (int)Math.Round(unchecked((double)iSetNum / (double)height * (double)width));
						height2 = iSetNum;
					}
					else if (iSelects == 3)
					{
						num = (int)Math.Round((double)(width * iSetNum) / 100.0);
						height2 = (int)Math.Round((double)(height * iSetNum) / 100.0);
					}
					if (0 == num | 0 == num)
					{
						eCancel = true;
						loopstate.Stop();
					}
					bool flag = false;
					string str = Path.Combine(Path.GetDirectoryName(thispath), Path.GetFileNameWithoutExtension(thispath) + ".gpa");
					try
					{
						Rectangle rect = new Rectangle(0, 0, width, height);
						BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
						Bitmap bitmap = new Bitmap(width, height, bitmapData.Stride, format, bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						Bitmap bitmap2 = new Bitmap(num, height2, format);
						Graphics graphics = Graphics.FromImage(bitmap2);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(bitmap, 0, 0, num, height2);
						graphics.Dispose();
						if (bSaveBMP)
						{
							bitmap2.Save(str + ".bmp", ImageFormat.Bmp);
						}
						else
						{
							Encoder quality = Encoder.Quality;
							EncoderParameters encoderParameters = new EncoderParameters(1);
							EncoderParameter encoderParameter = new EncoderParameter(quality, unchecked((long)iJpgPercent));
							encoderParameters.Param[0] = encoderParameter;
							ImageCodecInfo encoder = PublicModule.GetEncoder(ImageFormat.Jpeg);
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
						PublicModule.addLog(ex.Message);
					}
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iBuild, 1);
						flag = false;
						if (bDel)
						{
							try
							{
								if (File.Exists(thispath))
								{
									File.Delete(thispath);
									flag = true;
								}
								goto IL_35B;
							}
							catch (Exception ex2)
							{
								flag = false;
								PublicModule.addLog(ex2.Message + " : " + thispath);
								goto IL_35B;
							}
						}
						string text = Path.Combine(Path.GetDirectoryName(thispath), "0_YouCanDel");
						try
						{
							if (!Directory.Exists(text))
							{
								Directory.CreateDirectory(text);
								PublicModule.addLog(PublicModule.thisLang.getMultiLingual("Form1_Thread_Mkdir_Msg") + text);
							}
						}
						catch (Exception ex3)
						{
							flag = false;
							PublicModule.addLog(ex3.Message);
						}
						text = Path.Combine(text, Path.GetFileName(thispath));
						try
						{
							if (File.Exists(thispath))
							{
								File.Move(thispath, text);
								flag = true;
							}
						}
						catch (Exception ex4)
						{
							flag = false;
							PublicModule.addLog(ex4.Message);
						}
						IL_35B:
						if (flag)
						{
							if (bSaveBMP)
							{
								FileSystem.Rename(str + ".bmp", Path.Combine(Path.GetDirectoryName(thispath), Path.GetFileNameWithoutExtension(thispath) + ".bmp"));
							}
							else
							{
								FileSystem.Rename(str + ".jpg", Path.Combine(Path.GetDirectoryName(thispath), Path.GetFileNameWithoutExtension(thispath) + ".jpg"));
							}
						}
					}
					bitMapFromFile.Dispose();
					BackgroundWorker1.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}
	}
}
