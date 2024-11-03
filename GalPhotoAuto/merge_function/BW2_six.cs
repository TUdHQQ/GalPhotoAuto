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
	// Token: 0x02000096 RID: 150
	public class BW2_six
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x00022FDC File Offset: 0x000211DC
		public static bool merge_ws_ippaiscv_txt(ref Form1 myForm1)
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
				ParallelOptions parallelOptions = x.a();
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
					while (Strings.InStr(1, fileNameWithoutExtension, ".", CompareMethod.Binary) > 0)
					{
						fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileNameWithoutExtension);
					}
					using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, x.o))
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
								if (!string.IsNullOrWhiteSpace(text2))
								{
									text2 = streamReader.ReadLine().Trim();
									array3 = x.aj.Split(text2);
									string text3 = Path.GetFileNameWithoutExtension(array3.Last<string>());
									array3 = text3.Split(new char[]
									{
										','
									});
									int y = (num3 - Conversions.ToInteger(array3[0])) * num2;
									int x = Conversions.ToInteger(array3[1]) * num2;
									text3 = Path.Combine(directoryName, text2);
									using (Bitmap bitmap2 = x.a(text3))
									{
										PixelFormat pixelFormat = bitmap2.PixelFormat;
										Rectangle rect = new Rectangle(0, 0, num2, num2);
										BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
										Bitmap bitmap3 = new Bitmap(num2, num2, bitmapData.Stride, x.a(pixelFormat), bitmapData.Scan0);
										bitmap2.UnlockBits(bitmapData);
										graphics.DrawImage(bitmap3, x, y, num2, num2);
										bitmap3.Dispose();
									}
									x.f.Add(text3);
									backgroundWorker.ReportProgress(x.i);
								}
							}
							graphics.Dispose();
							string a_ = Path.Combine(directoryName, fileNameWithoutExtension);
							x.a(a_, ref bitmap, true);
							bitmap.Dispose();
							Interlocked.Add(ref x.k, 1);
							backgroundWorker.ReportProgress(x.i);
							Thread.Sleep(x.c);
						}
					}
					x.f.Add(text);
				}
				x.aa = string.Empty;
				x.z = string.Empty;
				return result;
			}
		}
	}
}
