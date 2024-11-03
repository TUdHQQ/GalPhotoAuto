using System;
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
	// Token: 0x0200009E RID: 158
	public class BW2_six
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x00022FE4 File Offset: 0x000211E4
		public static bool merge_ws_ippaiscv_txt(ref Form1 myForm1)
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
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
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
					while (Strings.InStr(1, fileNameWithoutExtension, ".", CompareMethod.Binary) > 0)
					{
						fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileNameWithoutExtension);
					}
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
						{
							string text2 = streamReader.ReadLine().Trim();
							string[] array3 = text2.Split(new char[]
							{
								','
							});
							int width = Conversions.ToInteger(array3[0].Trim());
							int num = Conversions.ToInteger(array3[1].Trim());
							int num2 = Conversions.ToInteger(array3[2].Trim());
							Bitmap bitmap = new Bitmap(width, num, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.Clear(Color.Transparent);
							int num3 = num / num2;
							while (!streamReader.EndOfStream)
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
								if (!string.IsNullOrWhiteSpace(text2))
								{
									text2 = streamReader.ReadLine().Trim();
									array3 = PublicModule.regAT.Split(text2);
									string text3 = Path.GetFileNameWithoutExtension(array3.Last<string>());
									array3 = text3.Split(new char[]
									{
										','
									});
									int y = (num3 - Conversions.ToInteger(array3[0])) * num2;
									int x = Conversions.ToInteger(array3[1]) * num2;
									text3 = Path.Combine(directoryName, text2);
									using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text3))
									{
										PixelFormat pixelFormat = bitMapFromFile.PixelFormat;
										Rectangle rect = new Rectangle(0, 0, num2, num2);
										BitmapData bitmapData = bitMapFromFile.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
										Bitmap bitmap2 = new Bitmap(num2, num2, bitmapData.Stride, PublicModule.checkPixelFormat(pixelFormat), bitmapData.Scan0);
										bitMapFromFile.UnlockBits(bitmapData);
										graphics.DrawImage(bitmap2, x, y, num2, num2);
										bitmap2.Dispose();
									}
									PublicModule.files2.Add(text3);
									backgroundWorker.ReportProgress(PublicModule.iNow);
								}
							}
							graphics.Dispose();
							string sSavePath = Path.Combine(directoryName, fileNameWithoutExtension);
							PublicModule.saveBitmapFile(sSavePath, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref PublicModule.iBuild, 1);
							backgroundWorker.ReportProgress(PublicModule.iNow);
							Thread.Sleep(PublicModule.iThreadWaitTime);
						}
					}
					PublicModule.files2.Add(text);
				}
				PublicModule.sGameExe = string.Empty;
				PublicModule.sSpecialExt = string.Empty;
				return result;
			}
		}
	}
}
