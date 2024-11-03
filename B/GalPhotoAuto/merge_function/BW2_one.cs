using System;
using System.Collections;
using System.ComponentModel;
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
	// Token: 0x02000037 RID: 55
	public class BW2_one
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000AEC0 File Offset: 0x000090C0
		public static bool merge_image_in(ref Form1 myForm1, int iMod = 1)
		{
			BW2_one._Closure$__44 CS$<>8__locals1 = new BW2_one._Closure$__44();
			CS$<>8__locals1.$VB$Local_iMod = iMod;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				CS$<>8__locals1.$VB$Local_iTx = 0;
				CS$<>8__locals1.$VB$Local_iTy = 0;
				if (5 == CS$<>8__locals1.$VB$Local_iMod)
				{
					CS$<>8__locals1.$VB$Local_iTx = PublicModule.iForm3Tx;
					CS$<>8__locals1.$VB$Local_iTy = PublicModule.iForm3Ty;
				}
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__44._Closure$__45 CS$<>8__locals2 = new BW2_one._Closure$__44._Closure$__45(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_stream = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
						CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_stream, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr);
						int x = 0;
						int y = 0;
						switch (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_iMod)
						{
						case 2:
							y = CS$<>8__locals2.$VB$Local_iHeight - bitMapFromFile2.Height;
							break;
						case 3:
							x = CS$<>8__locals2.$VB$Local_iWidth - bitMapFromFile2.Width;
							break;
						case 4:
							x = CS$<>8__locals2.$VB$Local_iWidth - bitMapFromFile2.Width;
							y = CS$<>8__locals2.$VB$Local_iHeight - bitMapFromFile2.Height;
							break;
						case 5:
							x = CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_iTx;
							y = CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_iTy;
							break;
						}
						Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						MemoryStream $VB$Local_stream = CS$<>8__locals2.$VB$Local_stream;
						lock ($VB$Local_stream)
						{
							graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_stream), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
						}
						graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
						graphics.Dispose();
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
						Interlocked.Add(ref PublicModule.iBuild, 1);
						bitmap.Dispose();
						bitMapFromFile2.Dispose();
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_2C.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_stream.Dispose();
					if (@checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000B108 File Offset: 0x00009308
		public static bool merge_m(ref Form1 myForm1, bool bBALpha = false)
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
					bool flag = false;
					string directoryName = Path.GetDirectoryName(thispath);
					string path = Path.GetFileNameWithoutExtension(thispath) + "_m";
					string text = Path.Combine(directoryName, path);
					try
					{
						foreach (object obj in PublicModule.files1)
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
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						bool flag2 = false;
						try
						{
							Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath);
							FastBitmap fastBitmap = new FastBitmap(bitMapFromFile);
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text);
							FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile2);
							Bitmap bitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap3 = new FastBitmap(bitmap);
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
									if (bBALpha)
									{
										alpha = 255 - PublicModule.getiAlphaFromColor(ref pixel2);
									}
									else
									{
										alpha = PublicModule.getiAlphaFromColor(ref pixel2);
									}
									fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
								}
							}
							PublicModule.saveBitmapFile(thispath + ".merge", ref fastBitmap3);
							fastBitmap3.Dispose();
							bitmap.Dispose();
							fastBitmap2.Dispose();
							bitMapFromFile2.Dispose();
							fastBitmap.Dispose();
							bitMapFromFile.Dispose();
							flag2 = true;
						}
						catch (Exception ex)
						{
							flag2 = false;
							PublicModule.addLog("_m合成出错: " + ex.Message);
							throw new Exception(ex.Message);
						}
						if (flag2)
						{
							PublicModule.files2.Add(thispath);
							PublicModule.files2.Add(text);
							Interlocked.Add(ref PublicModule.iBuild, 1);
						}
					}
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000B198 File Offset: 0x00009398
		public static bool merge_sou_plus_alpha(ref Form1 myForm1, bool bReverse = false)
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
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream2 = new MemoryStream();
					int num = 0;
					int num2 = 0;
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath))
					{
						num = bitMapFromFile.Width / 2;
						num2 = bitMapFromFile.Height;
						Rectangle rect = new Rectangle(0, 0, num, num2);
						BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile.PixelFormat);
						Bitmap bitmap = new Bitmap(num, num2, bitmapData.Stride, bitMapFromFile.PixelFormat, bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						bitmap.Save(memoryStream, ImageFormat.Png);
						bitmap.Dispose();
						rect = new Rectangle(num, 0, num, num2);
						bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, bitMapFromFile.PixelFormat);
						Bitmap bitmap2 = new Bitmap(num, num2, bitmapData.Stride, bitMapFromFile.PixelFormat, bitmapData.Scan0);
						bitMapFromFile.UnlockBits(bitmapData);
						bitmap2.Save(memoryStream2, ImageFormat.Png);
						bitmap2.Dispose();
					}
					FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
					FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(memoryStream2));
					Bitmap bitmap3 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
					FastBitmap fastBitmap3 = new FastBitmap(bitmap3);
					int num3 = 0;
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
							if (bReverse)
							{
								alpha = 255 - PublicModule.getiAlphaFromColor(ref pixel2);
							}
							else
							{
								alpha = PublicModule.getiAlphaFromColor(ref pixel2);
							}
							fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
						}
					}
					PublicModule.saveBitmapFile(thispath + ".merge", ref fastBitmap3);
					Interlocked.Add(ref PublicModule.iBuild, 1);
					fastBitmap3.Dispose();
					bitmap3.Dispose();
					fastBitmap2.Dispose();
					fastBitmap.Dispose();
					memoryStream2.Dispose();
					memoryStream.Dispose();
					ArrayList files = PublicModule.files2;
					lock (files)
					{
						PublicModule.files2.Add(thispath);
					}
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000B228 File Offset: 0x00009428
		public static bool merge_xxx_mxxx(ref Form1 myForm1)
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
					bool flag = false;
					string directoryName = Path.GetDirectoryName(thispath);
					string path = "m" + Path.GetFileNameWithoutExtension(thispath);
					string text = Path.Combine(directoryName, path);
					try
					{
						foreach (object obj in PublicModule.files1)
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
					if (flag)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						bool flag2 = false;
						try
						{
							Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(thispath);
							FastBitmap fastBitmap = new FastBitmap(bitMapFromFile);
							int iWidth = fastBitmap.iWidth;
							int iHeight = fastBitmap.iHeight;
							Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text);
							FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile2);
							Bitmap bitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
							FastBitmap fastBitmap3 = new FastBitmap(bitmap);
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
									int alpha = PublicModule.getiAlphaFromColor(ref pixel2);
									fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
								}
							}
							PublicModule.saveBitmapFile(thispath + ".merge", ref fastBitmap3);
							fastBitmap3.Dispose();
							bitmap.Dispose();
							fastBitmap2.Dispose();
							bitMapFromFile2.Dispose();
							fastBitmap.Dispose();
							bitMapFromFile.Dispose();
							flag2 = true;
						}
						catch (Exception ex)
						{
							flag2 = false;
							PublicModule.addLog("mxxx合成出错: " + ex.Message);
							throw new Exception(ex.Message);
						}
						if (flag2)
						{
							PublicModule.files2.Add(thispath);
							PublicModule.files2.Add(text);
							Interlocked.Add(ref PublicModule.iBuild, 1);
						}
					}
					BackgroundWorker2.ReportProgress(PublicModule.iNow);
					Thread.Sleep(PublicModule.iThreadWaitTime);
				});
				return eCancel;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000B2B0 File Offset: 0x000094B0
		public static bool scan_image_find_area_merge(ref Form1 myForm1, int iMode = 0)
		{
			BW2_one._Closure$__49 CS$<>8__locals1 = new BW2_one._Closure$__49(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_iMode = iMode;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__49._Closure$__50 CS$<>8__locals2 = new BW2_one._Closure$__49._Closure$__50(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31 = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_streamL = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
						CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_streamL, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					CS$<>8__locals2.$VB$Local_bThis = false;
					CS$<>8__locals2.$VB$Local_iLx = -1;
					CS$<>8__locals2.$VB$Local_iLy = -1;
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						MemoryStream memoryStream = new MemoryStream();
						int width;
						int height;
						using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr))
						{
							width = bitMapFromFile2.Width;
							height = bitMapFromFile2.Height;
							bitMapFromFile2.Save(memoryStream, ImageFormat.Png);
						}
						if (-1 == CS$<>8__locals2.$VB$Local_iLx | -1 == CS$<>8__locals2.$VB$Local_iLy)
						{
							MemoryStream $VB$Local_streamL = CS$<>8__locals2.$VB$Local_streamL;
							lock ($VB$Local_streamL)
							{
								FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_streamL));
								FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
								if (!(-1 < CS$<>8__locals2.$VB$Local_iLx & -1 < CS$<>8__locals2.$VB$Local_iLy))
								{
									int num = 1;
									int num2 = CS$<>8__locals2.$VB$Local_iWidth - 1;
									for (int j = num; j <= num2; j++)
									{
										int num3 = 1;
										int num4 = CS$<>8__locals2.$VB$Local_iHeight - 1;
										for (int k = num3; k <= num4; k++)
										{
											if (fastBitmap.GetPixel(j, k).A == 0 && fastBitmap.GetPixel(j - 1, k).A == 255 && fastBitmap.GetPixel(j, k - 1).A == 255)
											{
												if (1 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_iMode && fastBitmap.GetPixel(j + width - 1, k).A == 0 && fastBitmap.GetPixel(j + width, k).A > 0 && fastBitmap.GetPixel(j + width - 1, k - 1).A > 0)
												{
													CS$<>8__locals2.$VB$Local_iLx = j;
													CS$<>8__locals2.$VB$Local_iLy = k;
													CS$<>8__locals2.$VB$Local_bThis = true;
													goto IL_2C9;
												}
												int num5 = 0;
												int num6 = 0;
												int num7 = width - 1;
												for (int l = num6; l <= num7; l++)
												{
													int num8 = 0;
													int num9 = height - 1;
													for (int m = num8; m <= num9; m++)
													{
														Color pixel = fastBitmap2.GetPixel(l, m);
														Color pixel2 = fastBitmap.GetPixel(l + j, m + k);
														if (255 - pixel.A == pixel2.A)
														{
															num5++;
														}
													}
												}
												if (num5 == width * height)
												{
													CS$<>8__locals2.$VB$Local_iLx = j;
													CS$<>8__locals2.$VB$Local_iLy = k;
													CS$<>8__locals2.$VB$Local_bThis = true;
												}
											}
											if (-1 < CS$<>8__locals2.$VB$Local_iLx & -1 < CS$<>8__locals2.$VB$Local_iLy)
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
						if (-1 == CS$<>8__locals2.$VB$Local_iLx | -1 == CS$<>8__locals2.$VB$Local_iLy)
						{
							return;
						}
						Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						MemoryStream $VB$Local_streamL2 = CS$<>8__locals2.$VB$Local_streamL;
						lock ($VB$Local_streamL2)
						{
							graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_streamL), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
						}
						graphics.DrawImage(Image.FromStream(memoryStream), CS$<>8__locals2.$VB$Local_iLx, CS$<>8__locals2.$VB$Local_iLy, width, height);
						graphics.Dispose();
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
						Interlocked.Add(ref PublicModule.iBuild, 1);
						bitmap.Dispose();
						memoryStream.Dispose();
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_31.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_streamL.Dispose();
					if (CS$<>8__locals2.$VB$Local_bThis && @checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000B4F0 File Offset: 0x000096F0
		public static bool merge_image_noWhitelookBlack(ref Form1 myForm1)
		{
			BW2_one._Closure$__51 CS$<>8__locals1 = new BW2_one._Closure$__51();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__51._Closure$__52 CS$<>8__locals2 = new BW2_one._Closure$__51._Closure$__52(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33 = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_stream = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
						CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_stream, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
						FastBitmap fastBitmap = new FastBitmap(bitmap);
						MemoryStream $VB$Local_stream = CS$<>8__locals2.$VB$Local_stream;
						FastBitmap fastBitmap2;
						lock ($VB$Local_stream)
						{
							fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_stream));
						}
						FastBitmap fastBitmap3 = new FastBitmap(PublicModule.getBitMapFromFile(sr));
						int num = 0;
						int num2 = CS$<>8__locals2.$VB$Local_iWidth - 1;
						for (int j = num; j <= num2; j++)
						{
							int num3 = 0;
							int num4 = CS$<>8__locals2.$VB$Local_iHeight - 1;
							for (int k = num3; k <= num4; k++)
							{
								Color pixel = fastBitmap2.GetPixel(j, k);
								Color pixel2 = fastBitmap3.GetPixel(j, k);
								if (pixel2.A == 255)
								{
									fastBitmap.SetPixel(j, k, pixel2);
								}
								else
								{
									fastBitmap.SetPixel(j, k, pixel);
								}
							}
						}
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						PublicModule.saveBitmapFile(sSavePath, ref fastBitmap);
						Interlocked.Add(ref PublicModule.iBuild, 1);
						fastBitmap3.Dispose();
						fastBitmap2.Dispose();
						fastBitmap.Dispose();
						bitmap.Dispose();
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_33.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_stream.Dispose();
					if (@checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000B704 File Offset: 0x00009904
		public static bool merge_image_M_and_xy(ref Form1 myForm1)
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
					bool flag = false;
					string directoryName = Path.GetDirectoryName(thispath);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(thispath);
					string[] array2 = null;
					string text = string.Empty;
					if (Strings.InStr(1, fileNameWithoutExtension, "Mx", CompareMethod.Binary) > 0)
					{
						array2 = fileNameWithoutExtension.Split(new char[]
						{
							'M'
						});
						text = array2[0];
						if (string.IsNullOrEmpty(text))
						{
							return;
						}
						string text2 = Path.Combine(directoryName, text);
						string str = text2;
						try
						{
							foreach (object value in PublicModule.files1)
							{
								string text3 = Conversions.ToString(value);
								if (0 != string.Compare(text3, thispath, StringComparison.Ordinal) && Strings.InStr(1, text3, text2, CompareMethod.Binary) > 0)
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
							text = array2[1].Substring(1);
							array2 = text.Split(new char[]
							{
								'y'
							});
							if (!(Versioned.IsNumeric(array2[0]) & Versioned.IsNumeric(array2[1])))
							{
								return;
							}
							int num = Conversions.ToInteger(array2[0]);
							int num2 = Conversions.ToInteger(array2[1]);
							text = Path.GetFileNameWithoutExtension(text2);
							array2 = text.Split(new char[]
							{
								'x'
							});
							text = array2[1];
							array2 = text.Split(new char[]
							{
								'y'
							});
							if (!(Versioned.IsNumeric(array2[0]) & Versioned.IsNumeric(array2[1])))
							{
								return;
							}
							int num3 = Conversions.ToInteger(array2[0]);
							int num4 = Conversions.ToInteger(array2[1]);
							Interlocked.Add(ref PublicModule.iNow, 1);
							bool flag2 = false;
							try
							{
								Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text2);
								FastBitmap fastBitmap = new FastBitmap(bitMapFromFile);
								int iWidth = fastBitmap.iWidth;
								int iHeight = fastBitmap.iHeight;
								Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(thispath);
								FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile2);
								Bitmap bitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
								FastBitmap fastBitmap3 = new FastBitmap(bitmap);
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
										int alpha = PublicModule.getiAlphaFromColor(ref pixel2);
										fastBitmap3.SetPixel(i, j, Color.FromArgb(alpha, pixel));
									}
								}
								PublicModule.saveBitmapFile(str + ".merge", ref fastBitmap3);
								fastBitmap3.Dispose();
								bitmap.Dispose();
								fastBitmap2.Dispose();
								bitMapFromFile2.Dispose();
								fastBitmap.Dispose();
								bitMapFromFile.Dispose();
								flag2 = true;
							}
							catch (Exception ex)
							{
								flag2 = false;
								PublicModule.addLog("文件名中间带M和后面带xy坐标合成出错: " + ex.Message);
								throw new Exception(ex.Message);
							}
							if (flag2)
							{
								PublicModule.files2.Add(thispath);
								PublicModule.files2.Add(text2);
								Interlocked.Add(ref PublicModule.iBuild, 1);
							}
						}
						BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					}
				});
				return eCancel;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000B78C File Offset: 0x0000998C
		public static bool scan_b_scan_f_find_line_merge(ref Form1 myForm1, int iMode = 0)
		{
			BW2_one._Closure$__54 CS$<>8__locals1 = new BW2_one._Closure$__54(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_iMode = iMode;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__54._Closure$__55 CS$<>8__locals2 = new BW2_one._Closure$__54._Closure$__55(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36 = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_streamL = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
						CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_streamL, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_b32Alpha = false;
					PixelFormat $VB$Local_pFormat = CS$<>8__locals2.$VB$Local_pFormat;
					if ($VB$Local_pFormat == PixelFormat.Format24bppRgb)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = false;
					}
					else if ($VB$Local_pFormat == PixelFormat.Format32bppArgb)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					else if ($VB$Local_pFormat == PixelFormat.Format16bppArgb1555)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					else if ($VB$Local_pFormat == PixelFormat.Format32bppPArgb)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					else if ($VB$Local_pFormat == PixelFormat.PAlpha)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					else if ($VB$Local_pFormat == PixelFormat.Format64bppArgb)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					else if ($VB$Local_pFormat == PixelFormat.Format64bppPArgb)
					{
						CS$<>8__locals2.$VB$Local_b32Alpha = true;
					}
					CS$<>8__locals2.$VB$Local_iAlphaAA = new byte[CS$<>8__locals2.$VB$Local_iWidth + 1, CS$<>8__locals2.$VB$Local_iHeight + 1];
					if (CS$<>8__locals2.$VB$Local_b32Alpha)
					{
						FastBitmap fastBitmap = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_streamL));
						int num = 0;
						int num2 = CS$<>8__locals2.$VB$Local_iWidth - 1;
						for (int j = num; j <= num2; j++)
						{
							int num3 = 0;
							int num4 = CS$<>8__locals2.$VB$Local_iHeight - 1;
							for (int k = num3; k <= num4; k++)
							{
								Color pixel = fastBitmap.GetPixel(j, k);
								CS$<>8__locals2.$VB$Local_iAlphaAA[j, k] = pixel.A;
							}
						}
						fastBitmap.Dispose();
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					CS$<>8__locals2.$VB$Local_bThis = false;
					CS$<>8__locals2.$VB$Local_iLx = -1;
					CS$<>8__locals2.$VB$Local_iLy = -1;
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						int num5 = 0;
						Interlocked.Add(ref PublicModule.iNow, 1);
						MemoryStream memoryStream;
						int width;
						int height;
						for (;;)
						{
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
							while (PublicModule.bWaitCancelAsync)
							{
								Thread.Sleep(500);
								if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
							}
							memoryStream = new MemoryStream();
							using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr))
							{
								width = bitMapFromFile2.Width;
								height = bitMapFromFile2.Height;
								bitMapFromFile2.Save(memoryStream, ImageFormat.Png);
							}
							if (-1 == CS$<>8__locals2.$VB$Local_iLx | -1 == CS$<>8__locals2.$VB$Local_iLy)
							{
								MemoryStream $VB$Local_streamL = CS$<>8__locals2.$VB$Local_streamL;
								lock ($VB$Local_streamL)
								{
									if (!(-1 < CS$<>8__locals2.$VB$Local_iLx & -1 < CS$<>8__locals2.$VB$Local_iLy))
									{
										FastBitmap fastBitmap2 = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_streamL));
										FastBitmap fastBitmap3 = new FastBitmap((Bitmap)Image.FromStream(memoryStream));
										Color pixel2;
										if (2 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
										{
											pixel2 = fastBitmap3.GetPixel(0, height - 1);
										}
										else if (4 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
										{
											pixel2 = fastBitmap3.GetPixel(width - 1, 0);
										}
										else
										{
											pixel2 = fastBitmap3.GetPixel(0, 0);
										}
										int num6 = 0;
										int num7 = CS$<>8__locals2.$VB$Local_iWidth - 1;
										for (int l = num6; l <= num7; l++)
										{
											int num8 = 0;
											int num9 = CS$<>8__locals2.$VB$Local_iHeight - 1;
											for (int m = num8; m <= num9; m++)
											{
												Color pixel3 = fastBitmap2.GetPixel(l, m);
												if (pixel3.R == pixel2.R & pixel3.G == pixel2.G & pixel3.B == pixel2.B)
												{
													if (1 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
													{
														int num10 = 0;
														int num11 = width - 1;
														for (int n = num10; n <= num11; n++)
														{
															pixel3 = fastBitmap3.GetPixel(n, 0);
															Color pixel4 = fastBitmap2.GetPixel(n + l, m);
															if (!(pixel3.R == pixel4.R & pixel3.G == pixel4.G & pixel3.B == pixel4.B))
															{
																CS$<>8__locals2.$VB$Local_bThis = false;
																CS$<>8__locals2.$VB$Local_iLx = -1;
																CS$<>8__locals2.$VB$Local_iLy = -1;
																break;
															}
															CS$<>8__locals2.$VB$Local_bThis = true;
															CS$<>8__locals2.$VB$Local_iLx = l;
															CS$<>8__locals2.$VB$Local_iLy = m;
														}
													}
													else if (2 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
													{
														int num12 = 0;
														int num13 = width - 1;
														for (int num14 = num12; num14 <= num13; num14++)
														{
															pixel3 = fastBitmap3.GetPixel(num14, height - 1);
															Color pixel4 = fastBitmap2.GetPixel(num14 + l, m);
															if (!(pixel3.R == pixel4.R & pixel3.G == pixel4.G & pixel3.B == pixel4.B))
															{
																CS$<>8__locals2.$VB$Local_bThis = false;
																CS$<>8__locals2.$VB$Local_iLx = -1;
																CS$<>8__locals2.$VB$Local_iLy = -1;
																break;
															}
															CS$<>8__locals2.$VB$Local_bThis = true;
															CS$<>8__locals2.$VB$Local_iLx = l;
															CS$<>8__locals2.$VB$Local_iLy = m - height + 1;
														}
													}
													else if (3 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
													{
														int num15 = 0;
														int num16 = height - 1;
														for (int num17 = num15; num17 <= num16; num17++)
														{
															pixel3 = fastBitmap3.GetPixel(0, num17);
															Color pixel4 = fastBitmap2.GetPixel(l, num17 + m);
															if (!(pixel3.R == pixel4.R & pixel3.G == pixel4.G & pixel3.B == pixel4.B))
															{
																CS$<>8__locals2.$VB$Local_bThis = false;
																CS$<>8__locals2.$VB$Local_iLx = -1;
																CS$<>8__locals2.$VB$Local_iLy = -1;
																break;
															}
															CS$<>8__locals2.$VB$Local_bThis = true;
															CS$<>8__locals2.$VB$Local_iLx = l;
															CS$<>8__locals2.$VB$Local_iLy = m;
														}
													}
													else if (4 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_iMode)
													{
														int num18 = 0;
														int num19 = height - 1;
														for (int num20 = num18; num20 <= num19; num20++)
														{
															pixel3 = fastBitmap3.GetPixel(width - 1, num20);
															Color pixel4 = fastBitmap2.GetPixel(l, num20 + m);
															if (!(pixel3.R == pixel4.R & pixel3.G == pixel4.G & pixel3.B == pixel4.B))
															{
																CS$<>8__locals2.$VB$Local_bThis = false;
																CS$<>8__locals2.$VB$Local_iLx = -1;
																CS$<>8__locals2.$VB$Local_iLy = -1;
																break;
															}
															CS$<>8__locals2.$VB$Local_bThis = true;
															CS$<>8__locals2.$VB$Local_iLx = l - width + 1;
															CS$<>8__locals2.$VB$Local_iLy = m;
														}
													}
												}
												if (-1 < CS$<>8__locals2.$VB$Local_iLx & -1 < CS$<>8__locals2.$VB$Local_iLy)
												{
													goto IL_4EA;
												}
											}
										}
										fastBitmap3.Dispose();
										fastBitmap2.Dispose();
									}
								}
							}
							IL_4EA:
							if (!(-1 == CS$<>8__locals2.$VB$Local_iLx | -1 == CS$<>8__locals2.$VB$Local_iLy))
							{
								goto IL_50E;
							}
							if (10 <= num5)
							{
								break;
							}
							num5++;
						}
						return;
						IL_50E:
						Bitmap bitmap = new Bitmap(CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight, CS$<>8__locals2.$VB$Local_pFormat);
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						MemoryStream $VB$Local_streamL2 = CS$<>8__locals2.$VB$Local_streamL;
						lock ($VB$Local_streamL2)
						{
							graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_streamL), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
						}
						graphics.DrawImage(Image.FromStream(memoryStream), CS$<>8__locals2.$VB$Local_iLx, CS$<>8__locals2.$VB$Local_iLy, width, height);
						graphics.Dispose();
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						if (CS$<>8__locals2.$VB$Local_b32Alpha)
						{
							FastBitmap fastBitmap4 = new FastBitmap(bitmap);
							int num21 = 0;
							int num22 = CS$<>8__locals2.$VB$Local_iWidth - 1;
							for (int num23 = num21; num23 <= num22; num23++)
							{
								int num24 = 0;
								int num25 = CS$<>8__locals2.$VB$Local_iHeight - 1;
								for (int num26 = num24; num26 <= num25; num26++)
								{
									Color pixel5 = fastBitmap4.GetPixel(num23, num26);
									fastBitmap4.SetPixel(num23, num26, Color.FromArgb((int)CS$<>8__locals2.$VB$Local_iAlphaAA[num23, num26], pixel5));
								}
							}
							PublicModule.saveBitmapFile(sSavePath, ref fastBitmap4);
							fastBitmap4.Dispose();
						}
						else
						{
							PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
						}
						Interlocked.Add(ref PublicModule.iBuild, 1);
						bitmap.Dispose();
						memoryStream.Dispose();
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_36.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_streamL.Dispose();
					if (CS$<>8__locals2.$VB$Local_bThis && @checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000BB00 File Offset: 0x00009D00
		public static bool merge_L_alpha_R_image(ref Form1 myForm1, int iMod = 0)
		{
			BW2_one._Closure$__56 CS$<>8__locals1 = new BW2_one._Closure$__56();
			CS$<>8__locals1.$VB$Local_iMod = iMod;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__56._Closure$__57 CS$<>8__locals2 = new BW2_one._Closure$__56._Closure$__57(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38 = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_stream = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_stream, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						MemoryStream $VB$Local_stream = CS$<>8__locals2.$VB$Local_stream;
						Bitmap bitmap;
						lock ($VB$Local_stream)
						{
							bitmap = (Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_stream);
						}
						FastBitmap fastBitmap = new FastBitmap(bitmap);
						int iWidth = fastBitmap.iWidth;
						int iHeight = fastBitmap.iHeight;
						Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr);
						FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile2);
						Bitmap bitmap2 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
						FastBitmap fastBitmap3 = new FastBitmap(bitmap2);
						int num = 0;
						int num2 = iWidth - 1;
						for (int j = num; j <= num2; j++)
						{
							int num3 = 0;
							int num4 = iHeight - 1;
							for (int k = num3; k <= num4; k++)
							{
								Color pixel = fastBitmap.GetPixel(j, k);
								Color pixel2 = fastBitmap2.GetPixel(j, k);
								int alpha;
								if (1 == CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_iMod)
								{
									alpha = 255 - PublicModule.getiAlphaFromColor(ref pixel);
								}
								else
								{
									alpha = PublicModule.getiAlphaFromColor(ref pixel);
								}
								fastBitmap3.SetPixel(j, k, Color.FromArgb(alpha, pixel2));
							}
						}
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						PublicModule.saveBitmapFile(sSavePath, ref fastBitmap3);
						fastBitmap3.Dispose();
						bitmap2.Dispose();
						fastBitmap2.Dispose();
						bitMapFromFile2.Dispose();
						fastBitmap.Dispose();
						bitmap.Dispose();
						Interlocked.Add(ref PublicModule.iBuild, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_38.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_stream.Dispose();
					if (@checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000BCF4 File Offset: 0x00009EF4
		public static bool merge_MS_M(ref Form1 myForm1)
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
				for (int i = 0; i < array2.Length; i++)
				{
					BW2_one._Closure$__58._Closure$__59 CS$<>8__locals2 = new BW2_one._Closure$__58._Closure$__59(CS$<>8__locals2);
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
					string directoryName = Path.GetDirectoryName(text);
					CS$<>8__locals2.$VB$Local_sOnlyfileName = Path.GetFileNameWithoutExtension(text);
					string text2 = "_" + PublicModule.regXIA.Split(CS$<>8__locals2.$VB$Local_sOnlyfileName).Last<string>();
					if (0 == string.Compare("_MS", text2, StringComparison.Ordinal) | 0 == string.Compare("_M", text2, StringComparison.Ordinal))
					{
						string path = CS$<>8__locals2.$VB$Local_sOnlyfileName.Substring(0, CS$<>8__locals2.$VB$Local_sOnlyfileName.Length - text2.Length);
						string strA = Path.Combine(directoryName, path);
						ArrayList arrayList = new ArrayList();
						try
						{
							foreach (object value in PublicModule.files1)
							{
								string text3 = Conversions.ToString(value);
								if (0 != string.Compare(text3, text, StringComparison.Ordinal))
								{
									string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text3);
									if (Strings.InStr(1, fileNameWithoutExtension, "_", CompareMethod.Binary) > 0)
									{
										text2 = "_" + PublicModule.regXIA.Split(fileNameWithoutExtension).Last<string>();
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
							MemoryStream stream = new MemoryStream();
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
							{
								bitMapFromFile.Save(stream, ImageFormat.Png);
							}
							Parallel.ForEach<object>(arrayList.ToArray(), parallelOptions, delegate(object a0, ParallelLoopState a1)
							{
								delegate(string sr, ParallelLoopState loopstate2)
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
									MemoryStream $VB$Local_stream = stream;
									Bitmap bitmap;
									lock ($VB$Local_stream)
									{
										bitmap = (Bitmap)Image.FromStream(stream);
									}
									FastBitmap fastBitmap = new FastBitmap(bitmap);
									int iWidth = fastBitmap.iWidth;
									int iHeight = fastBitmap.iHeight;
									Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(sr);
									FastBitmap fastBitmap2 = new FastBitmap(bitMapFromFile2);
									Bitmap bitmap2 = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
									FastBitmap fastBitmap3 = new FastBitmap(bitmap2);
									int num = 0;
									int num2 = iWidth - 1;
									for (int j = num; j <= num2; j++)
									{
										int num3 = 0;
										int num4 = iHeight - 1;
										for (int k = num3; k <= num4; k++)
										{
											Color pixel = fastBitmap.GetPixel(j, k);
											Color pixel2 = fastBitmap2.GetPixel(j, k);
											int alpha = 255 - PublicModule.getiAlphaFromColor(ref pixel);
											fastBitmap3.SetPixel(j, k, Color.FromArgb(alpha, pixel2));
										}
									}
									string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_sOnlyfileName, Path.GetFileNameWithoutExtension(sr), 0);
									string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_sOnlyfileName) + "_" + sameNameFromTheLeft;
									PublicModule.saveBitmapFile(sSavePath, ref fastBitmap3);
									fastBitmap3.Dispose();
									bitmap2.Dispose();
									fastBitmap2.Dispose();
									bitMapFromFile2.Dispose();
									fastBitmap.Dispose();
									bitmap.Dispose();
									Interlocked.Add(ref PublicModule.iBuild, 1);
									ArrayList files = PublicModule.files2;
									lock (files)
									{
										PublicModule.files2.Add(sr);
									}
									BackgroundWorker2.ReportProgress(PublicModule.iNow);
									Thread.Sleep(PublicModule.iThreadWaitTime);
								}(Conversions.ToString(a0), a1);
							});
							stream.Dispose();
							PublicModule.files2.Add(text);
						}
					}
				}
				return eCancel;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
		public static bool merge_image_white_alpha_to_tran(ref Form1 myForm1)
		{
			BW2_one._Closure$__61 CS$<>8__locals1 = new BW2_one._Closure$__61();
			CS$<>8__locals1.$VB$Local_eCancel = false;
			checked
			{
				PublicModule.iCount = PublicModule.pLeft.Count * PublicModule.pRight.Count;
				PublicModule.iMaxToBW = PublicModule.iCount;
				PublicModule.iNow = 0;
				PublicModule.iBuild = 0;
				bool @checked = myForm1.CheckBox3.Checked;
				CS$<>8__locals1.$VB$Local_bRDisposable = myForm1.CheckBox4.Checked;
				string[] array = new string[PublicModule.pLeft.Count - 1 + 1];
				PublicModule.pLeft.CopyTo(array, 0);
				string[] array2 = new string[PublicModule.pRight.Count - 1 + 1];
				PublicModule.pRight.CopyTo(array2, 0);
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				CS$<>8__locals1.$VB$Local_iTx = PublicModule.iForm3Tx;
				CS$<>8__locals1.$VB$Local_iTy = PublicModule.iForm3Ty;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_one._Closure$__61._Closure$__62 CS$<>8__locals2 = new BW2_one._Closure$__61._Closure$__62(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D = CS$<>8__locals1;
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
					CS$<>8__locals2.$VB$Local_stream = new MemoryStream();
					using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
					{
						CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
						CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
						PixelFormat pixelFormat = bitMapFromFile.PixelFormat;
						bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_stream, ImageFormat.Png);
					}
					CS$<>8__locals2.$VB$Local_Lname = Path.GetFileNameWithoutExtension(text);
					Parallel.ForEach<string>(array2, parallelOptions, delegate(string sr, ParallelLoopState loopstate)
					{
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_eCancel = true;
							loopstate.Stop();
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_eCancel = true;
								loopstate.Stop();
							}
						}
						MemoryStream $VB$Local_stream = CS$<>8__locals2.$VB$Local_stream;
						FastBitmap fastBitmap;
						lock ($VB$Local_stream)
						{
							fastBitmap = new FastBitmap((Bitmap)Image.FromStream(CS$<>8__locals2.$VB$Local_stream));
						}
						FastBitmap fastBitmap2 = new FastBitmap(PublicModule.getBitMapFromFile(sr));
						int num = fastBitmap2.iWidth - 1;
						int num2 = fastBitmap2.iHeight - 1;
						int num3 = 0;
						int num4 = CS$<>8__locals2.$VB$Local_iWidth - 1;
						int num5 = num3;
						while (num5 <= num4 && num5 <= num)
						{
							int num6 = 0;
							int num7 = CS$<>8__locals2.$VB$Local_iHeight - 1;
							int num8 = num6;
							while (num8 <= num7 && num8 <= num2)
							{
								Color pixel = fastBitmap2.GetPixel(num5, num8);
								int a = (int)pixel.A;
								if (255 == a)
								{
									fastBitmap.SetPixel(num5 + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_iTx, num8 + CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_iTy, Color.FromArgb(a, pixel));
								}
								num8++;
							}
							num5++;
						}
						string sameNameFromTheLeft = PublicModule.getSameNameFromTheLeft(CS$<>8__locals2.$VB$Local_Lname, Path.GetFileNameWithoutExtension(sr), 0);
						string sSavePath = Path.Combine(Path.GetDirectoryName(sr), CS$<>8__locals2.$VB$Local_Lname) + "_" + sameNameFromTheLeft;
						PublicModule.saveBitmapFile(sSavePath, ref fastBitmap);
						Interlocked.Add(ref PublicModule.iBuild, 1);
						fastBitmap2.Dispose();
						fastBitmap.Dispose();
						if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_bRDisposable)
						{
							ArrayList files2 = PublicModule.files2;
							lock (files2)
							{
								PublicModule.files2.Add(sr);
							}
						}
						CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_3D.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					CS$<>8__locals2.$VB$Local_stream.Dispose();
					if (@checked)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text);
						}
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000C1F8 File Offset: 0x0000A3F8
		public static bool merge_image_abc_01_abc_xy(ref Form1 myForm1)
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
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				base_path = Path.GetDirectoryName(text);
				string[] source = PublicModule.regXIA.Split(fileNameWithoutExtension);
				string text2 = source.Last<string>();
				if (Versioned.IsNumeric(text2) && 1 == Conversions.ToInteger(text2))
				{
					string sTemp1 = source.First<string>();
					MemoryStream membmp7 = new MemoryStream();
					Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text);
					PixelFormat pf = bitMapFromFile.PixelFormat;
					int iW = bitMapFromFile.Width;
					int iH = bitMapFromFile.Height;
					Rectangle rect = new Rectangle(0, 0, iW, iH);
					BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pf);
					Bitmap bitmap = new Bitmap(iW, iH, bitmapData.Stride, PublicModule.checkPixelFormat(pf), bitmapData.Scan0);
					bitMapFromFile.UnlockBits(bitmapData);
					bitmap.Save(membmp7, ImageFormat.Png);
					bitmap.Dispose();
					bitMapFromFile.Dispose();
					Parallel.For(2, 100, parallelOptions, delegate(int iD, ParallelLoopState loopstate)
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
						string text3 = iD.ToString("D2");
						string sFileWithoutExt = Path.Combine(base_path, sTemp1 + "_" + text3);
						text3 = PublicModule.searchBitmapWithExt(sFileWithoutExt, "");
						if (string.IsNullOrEmpty(text3))
						{
							return;
						}
						Bitmap bitmap2 = new Bitmap(iW, iH, pf);
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
						using (Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(text3))
						{
							int width = bitMapFromFile2.Width;
							int height = bitMapFromFile2.Height;
							Rectangle rect2 = new Rectangle(0, 0, width, height);
							BitmapData bitmapData2 = bitMapFromFile2.LockBits(rect2, ImageLockMode.ReadOnly, bitMapFromFile2.PixelFormat);
							Bitmap bitmap4 = new Bitmap(width, height, bitmapData2.Stride, PublicModule.checkPixelFormat(bitMapFromFile2.PixelFormat), bitmapData2.Scan0);
							bitMapFromFile2.UnlockBits(bitmapData2);
							graphics.DrawImage(bitmap4, 0, 0, bitmap4.Width, bitmap4.Height);
							bitmap4.Dispose();
						}
						graphics.Dispose();
						string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(text3);
						string[] source2 = PublicModule.regXIA.Split(fileNameWithoutExtension2);
						string sSavePath = Path.Combine(base_path, source2.First<string>() + "_01_" + source2.Last<string>());
						PublicModule.saveBitmapFile(sSavePath, ref bitmap2, true);
						bitmap2.Dispose();
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(text3);
						}
						Interlocked.Add(ref PublicModule.iBuild, 1);
						BackgroundWorker2.ReportProgress(PublicModule.iNow);
						Thread.Sleep(PublicModule.iThreadWaitTime);
					});
					membmp7.Dispose();
				}
			}
			PublicModule.sGameExe = string.Empty;
			PublicModule.sSpecialExt = string.Empty;
			return eCancel;
		}
	}
}
