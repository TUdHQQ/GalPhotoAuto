using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000BE RID: 190
	[StandardModule]
	internal sealed class PublicModule
	{
		// Token: 0x06000245 RID: 581
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SetForegroundWindow(IntPtr hwnd);

		// Token: 0x06000246 RID: 582
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

		// Token: 0x06000247 RID: 583
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetSystemMenu(IntPtr hWnd, int bRevert);

		// Token: 0x06000248 RID: 584
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "InsertMenuA", ExactSpelling = true, SetLastError = true)]
		public static extern int InsertMenu(int hMenu, int nPosition, int wFlags, int wIDNewItem, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpNewItem);

		// Token: 0x06000249 RID: 585
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "AppendMenuA", ExactSpelling = true, SetLastError = true)]
		public static extern int AppendMenu(int hMenu, int Flagsw, int IDNewItem, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpNewItem);

		// Token: 0x0600024A RID: 586
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int CreatePopupMenu();

		// Token: 0x0600024B RID: 587
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int CheckMenuItem(int hMenu, int wIDCheckItem, int wCheck);

		// Token: 0x0600024C RID: 588
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "ModifyMenuA", ExactSpelling = true, SetLastError = true)]
		public static extern int ModifyMenu(int hMenu, int nPosition, int wFlags, int wIDNewItem, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString);

		// Token: 0x0600024D RID: 589 RVA: 0x00026531 File Offset: 0x00024731
		public static void addLog(string str)
		{
			PublicModule.strLog.Insert(0, Conversions.ToString(DateTime.Now) + " : " + str + "\r\n");
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0002655C File Offset: 0x0002475C
		public static void makeFileList(ref ListBox listbox, ref ArrayList list)
		{
			list.Clear();
			int num = 0;
			checked
			{
				int num2 = listbox.Items.Count - 1;
				for (int i = num; i <= num2; i++)
				{
					string text = listbox.Items[i].ToString();
					if (Directory.Exists(text))
					{
						PublicModule.form1box4directorylist.Add(text);
						PublicModule.RecursionFolder(text, ref list);
					}
					else if (File.Exists(text) && Strings.InStr(1, text, PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0 && PublicModule.checkFileExtension(text, false))
					{
						list.Add(text);
					}
				}
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000265E8 File Offset: 0x000247E8
		public static void RecursionFolder(string folder_path, ref ArrayList list)
		{
			string[] files = Directory.GetFiles(folder_path);
			checked
			{
				if (files.Length > 0)
				{
					int num = Information.LBound(files, 1);
					int num2 = Information.UBound(files, 1);
					for (int i = num; i <= num2; i++)
					{
						if (PublicModule.checkFileExtension(files[i], false) && Strings.InStr(1, files[i], PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0)
						{
							list.Add(files[i]);
						}
					}
				}
				string[] directories = Directory.GetDirectories(folder_path);
				if (directories.Length > 0)
				{
					int num3 = Information.LBound(directories, 1);
					int num4 = Information.UBound(directories, 1);
					for (int i = num3; i <= num4; i++)
					{
						if (Strings.InStr(1, directories[i], PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0)
						{
							PublicModule.RecursionFolder(directories[i], ref list);
						}
					}
				}
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00026688 File Offset: 0x00024888
		public static void RecursionFolder2(string folder_path, ref ArrayList list)
		{
			string[] files = Directory.GetFiles(folder_path);
			checked
			{
				if (files.Length > 0)
				{
					int num = Information.LBound(files, 1);
					int num2 = Information.UBound(files, 1);
					for (int i = num; i <= num2; i++)
					{
						if (Strings.InStr(1, files[i], PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0)
						{
							list.Add(files[i]);
						}
					}
				}
				string[] directories = Directory.GetDirectories(folder_path);
				if (directories.Length > 0)
				{
					int num3 = Information.LBound(directories, 1);
					int num4 = Information.UBound(directories, 1);
					for (int i = num3; i <= num4; i++)
					{
						if (Strings.InStr(1, directories[i], PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0)
						{
							PublicModule.RecursionFolder2(directories[i], ref list);
						}
					}
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00026720 File Offset: 0x00024920
		public static bool checkFileExtension(string sPath, bool nocheck = false)
		{
			if (nocheck)
			{
				return true;
			}
			string text = Path.GetExtension(sPath).ToLower();
			if (0 >= text.Length)
			{
				return false;
			}
			string strA = text.Substring(1);
			if (!string.IsNullOrWhiteSpace(PublicModule.sSpecialExt))
			{
				if (0 == string.Compare("*", PublicModule.sSpecialExt, StringComparison.Ordinal))
				{
					return true;
				}
				if (0 == string.Compare(strA, PublicModule.sSpecialExt, StringComparison.Ordinal))
				{
					return true;
				}
			}
			else
			{
				foreach (string strB in PublicModule.extArr)
				{
					if (0 == string.Compare(strA, strB, StringComparison.Ordinal))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000267B4 File Offset: 0x000249B4
		public static PixelFormat checkPixelFormat(PixelFormat pf)
		{
			if (pf == PixelFormat.Format32bppArgb)
			{
				return pf;
			}
			if (pf == PixelFormat.Format32bppRgb)
			{
				return PixelFormat.Format32bppArgb;
			}
			if (pf == PixelFormat.Format24bppRgb)
			{
				return pf;
			}
			if (pf == PixelFormat.Undefined)
			{
				return PixelFormat.Format32bppArgb;
			}
			if (pf == PixelFormat.Undefined)
			{
				return PixelFormat.Format32bppArgb;
			}
			if (pf == PixelFormat.Format16bppArgb1555)
			{
				return PixelFormat.Format32bppArgb;
			}
			if (pf == PixelFormat.Format1bppIndexed)
			{
				return PixelFormat.Format24bppRgb;
			}
			if (pf == PixelFormat.Format4bppIndexed)
			{
				return PixelFormat.Format24bppRgb;
			}
			if (pf == PixelFormat.Format8bppIndexed)
			{
				return PixelFormat.Format24bppRgb;
			}
			if (pf <= PixelFormat.Format24bppRgb)
			{
				return pf;
			}
			if (pf >= PixelFormat.Format32bppArgb)
			{
				return pf;
			}
			return PixelFormat.Format32bppArgb;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0002684C File Offset: 0x00024A4C
		public static ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo imageCodecInfo in imageDecoders)
			{
				if (imageCodecInfo.FormatID == format.Guid)
				{
					return imageCodecInfo;
				}
			}
			return null;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0002688C File Offset: 0x00024A8C
		public static int getiAlphaFromColor(ref Color colorA)
		{
			int result;
			if (colorA.R == colorA.G & colorA.R == colorA.B)
			{
				result = (int)colorA.R;
			}
			else
			{
				result = checked((int)Math.Round(unchecked(0.212671 * (double)colorA.R + 0.71516 * (double)colorA.G + 0.072169 * (double)colorA.B)));
			}
			return result;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00026900 File Offset: 0x00024B00
		public static string searchBitmapWithExt(string sFileWithoutExt, string sBeforeExt = "")
		{
			string result = string.Empty;
			string text = string.Empty;
			int num = 0;
			int upperBound = PublicModule.extArr.GetUpperBound(0);
			checked
			{
				for (int i = num; i <= upperBound; i++)
				{
					if (string.IsNullOrEmpty(sBeforeExt))
					{
						text = sFileWithoutExt + "." + PublicModule.extArr[i];
					}
					else
					{
						text = sFileWithoutExt + sBeforeExt + "." + PublicModule.extArr[i];
					}
					if (File.Exists(text))
					{
						result = text;
						break;
					}
				}
				return result;
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00026974 File Offset: 0x00024B74
		public static string canFindInHashtable(ref Hashtable ht, string strFind)
		{
			string result = string.Empty;
			Hashtable obj = ht;
			lock (obj)
			{
				if (0 < ht.Count)
				{
					foreach (object obj2 in ht)
					{
						DictionaryEntry dictionaryEntry2;
						DictionaryEntry dictionaryEntry = (obj2 != null) ? ((DictionaryEntry)obj2) : dictionaryEntry2;
						if (0 == string.Compare(strFind, dictionaryEntry.Key.ToString(), StringComparison.Ordinal))
						{
							result = dictionaryEntry.Value.ToString();
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00026A10 File Offset: 0x00024C10
		public static bool canFindSameInArrayList(ref ArrayList arr, string strFind)
		{
			bool bFind = false;
			if (0 < arr.Count)
			{
				string[] array = new string[checked(arr.Count - 1 + 1)];
				ArrayList obj = arr;
				lock (obj)
				{
					arr.CopyTo(array, 0);
				}
				Parallel.ForEach<string>(array, delegate(string thisid, ParallelLoopState loopstate)
				{
					if (0 == string.Compare(strFind, thisid, StringComparison.Ordinal))
					{
						bFind = true;
						loopstate.Stop();
					}
				});
			}
			return bFind;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00026A9C File Offset: 0x00024C9C
		public static string sFindNameInArrayList(ref ArrayList arr, string strFind)
		{
			string sFind = string.Empty;
			if (0 < arr.Count)
			{
				string[] array = new string[checked(arr.Count - 1 + 1)];
				ArrayList obj = arr;
				lock (obj)
				{
					arr.CopyTo(array, 0);
				}
				Parallel.ForEach<string>(array, delegate(string thisid, ParallelLoopState loopstate)
				{
					if (0 == string.Compare(strFind, Path.GetFileNameWithoutExtension(thisid), StringComparison.Ordinal))
					{
						sFind = thisid;
						loopstate.Stop();
					}
				});
			}
			return sFind;
		}

		// Token: 0x06000259 RID: 601
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool ChangeWindowMessageFilter(uint Message, int dwFlag);

		// Token: 0x0600025A RID: 602 RVA: 0x00026B2C File Offset: 0x00024D2C
		public static void addChangeWindowMessageFilter()
		{
			PublicModule.ChangeWindowMessageFilter(563U, 1);
			PublicModule.ChangeWindowMessageFilter(74U, 1);
			PublicModule.ChangeWindowMessageFilter(73U, 1);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00026B4C File Offset: 0x00024D4C
		public static string getSysCurrentCulture()
		{
			string text = CultureInfo.CurrentCulture.ToString();
			string left = text;
			if (Operators.CompareString(left, "zh-HK", false) == 0)
			{
				text = "zh-TW";
			}
			else if (Operators.CompareString(left, "zh-MO", false) == 0)
			{
				text = "zh-TW";
			}
			else if (Operators.CompareString(left, "zh-SG", false) == 0)
			{
				text = "zh-CN";
			}
			return text;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00026BAC File Offset: 0x00024DAC
		public static void ResetComboBoxWidth(ref ComboBox cb)
		{
			Graphics graphics = cb.CreateGraphics();
			int selectedIndex = cb.SelectedIndex;
			int num = 0;
			checked
			{
				int num2 = cb.Items.Count - 1;
				int num3;
				for (int i = num; i <= num2; i++)
				{
					cb.SelectedIndex = i;
					SizeF sizeF = graphics.MeasureString(cb.Text, cb.Font);
					if ((float)num3 < sizeF.Width)
					{
						num3 = (int)Math.Round((double)sizeF.Width);
					}
				}
				cb.DropDownWidth = cb.Width;
				if (cb.DropDownWidth < num3)
				{
					cb.DropDownWidth = num3;
					cb.Width = num3;
				}
				cb.SelectedIndex = selectedIndex;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00026C54 File Offset: 0x00024E54
		public static ParallelOptions PublicParallelOptions()
		{
			if (1 > PublicModule.iCpuProcessor | PublicModule.iCpuProcessor > PublicModule.iMaxCpuProcessor)
			{
				PublicModule.iCpuProcessor = PublicModule.iMaxCpuProcessor;
			}
			return new ParallelOptions
			{
				MaxDegreeOfParallelism = PublicModule.iCpuProcessor
			};
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00026C94 File Offset: 0x00024E94
		public static string getSameNameFromTheLeft(string str1, string str2, int iReturn = 0)
		{
			checked
			{
				int num = str1.Length - 1;
				int num2 = str2.Length - 1;
				StringBuilder stringBuilder = new StringBuilder();
				int num3 = 0;
				int num4 = num;
				int num5 = num3;
				while (num5 <= num4 && num5 <= num2 && 0 == string.Compare(Conversions.ToString(str1[num5]), Conversions.ToString(str2[num5]), StringComparison.Ordinal))
				{
					stringBuilder.Append(str1[num5]);
					num5++;
				}
				if (0 < stringBuilder.Length)
				{
					string text = stringBuilder.ToString();
					return str2.Substring(text.Length);
				}
				if (0 == iReturn)
				{
					return str2;
				}
				return str1;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00026D38 File Offset: 0x00024F38
		public static string saveBitmapFile(string sSavePath, ref Bitmap bitmap, bool bReNameSame = true)
		{
			string text;
			ImageFormat format;
			switch (PublicModule.i2SaveBitmapFormat)
			{
			case 0:
				text = sSavePath + ".png";
				format = ImageFormat.Png;
				break;
			case 1:
				text = sSavePath + ".bmp";
				format = ImageFormat.Bmp;
				break;
			case 2:
				text = sSavePath + ".jpg";
				format = ImageFormat.Jpeg;
				break;
			default:
				text = sSavePath + ".png";
				format = ImageFormat.Png;
				break;
			}
			if (1 == PublicModule.i2CheckHash)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					bitmap.Save(memoryStream, ImageFormat.Png);
					MemoryStream memoryStream2 = memoryStream;
					string md5Hash = PublicModule.getMD5Hash(ref memoryStream2);
					string text2 = PublicModule.canFindInHashtable(ref PublicModule.MD5HashArr, md5Hash);
					if (!string.IsNullOrEmpty(text2))
					{
						PublicModule.addLog(Path.GetFileName(text) + " <= same with => " + text2);
						return string.Empty;
					}
					PublicModule.MD5HashArr.Add(md5Hash, Path.GetFileName(text));
				}
			}
			checked
			{
				if (bReNameSame)
				{
					int num = 0;
					while (File.Exists(text))
					{
						text = Path.Combine(Path.GetDirectoryName(text), Path.GetFileNameWithoutExtension(text) + "_" + Conversions.ToString(num) + Path.GetExtension(text));
						num++;
					}
				}
				else if (File.Exists(text))
				{
					return string.Empty;
				}
			}
			if (2 == PublicModule.i2SaveBitmapFormat)
			{
				System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
				EncoderParameters encoderParameters = new EncoderParameters(1);
				EncoderParameter encoderParameter = new EncoderParameter(quality, (long)PublicModule.i2SaveBitmapFormatJpg);
				encoderParameters.Param[0] = encoderParameter;
				ImageCodecInfo encoder = PublicModule.GetEncoder(format);
				bitmap.Save(text, encoder, encoderParameters);
				encoderParameter.Dispose();
				encoderParameters.Dispose();
			}
			else
			{
				bitmap.Save(text, format);
			}
			return text;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00026EEC File Offset: 0x000250EC
		public static string saveBitmapFile(string sSavePath, ref FastBitmap fbitmap)
		{
			string text;
			ImageFormat imageFormat;
			switch (PublicModule.i2SaveBitmapFormat)
			{
			case 0:
				text = sSavePath + ".png";
				imageFormat = ImageFormat.Png;
				break;
			case 1:
				text = sSavePath + ".bmp";
				imageFormat = ImageFormat.Bmp;
				break;
			case 2:
				text = sSavePath + ".jpg";
				imageFormat = ImageFormat.Jpeg;
				break;
			default:
				text = sSavePath + ".png";
				imageFormat = ImageFormat.Png;
				break;
			}
			if (1 == PublicModule.i2CheckHash)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					FastBitmap fastBitmap = fbitmap;
					MemoryStream memoryStream2 = memoryStream;
					fastBitmap.Save(ref memoryStream2, ImageFormat.Png);
					memoryStream2 = memoryStream;
					string md5Hash = PublicModule.getMD5Hash(ref memoryStream2);
					string text2 = PublicModule.canFindInHashtable(ref PublicModule.MD5HashArr, md5Hash);
					if (!string.IsNullOrEmpty(text2))
					{
						PublicModule.addLog(Path.GetFileName(text) + " <= same with => " + text2);
						return string.Empty;
					}
					PublicModule.MD5HashArr.Add(md5Hash, Path.GetFileName(text));
				}
			}
			int num = 0;
			checked
			{
				while (File.Exists(text))
				{
					text = Path.Combine(Path.GetDirectoryName(text), Path.GetFileNameWithoutExtension(text) + "_" + Conversions.ToString(num) + Path.GetExtension(text));
					num++;
				}
			}
			if (2 == PublicModule.i2SaveBitmapFormat)
			{
				System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
				EncoderParameters encoderParameters = new EncoderParameters(1);
				EncoderParameter encoderParameter = new EncoderParameter(quality, (long)PublicModule.i2SaveBitmapFormatJpg);
				encoderParameters.Param[0] = encoderParameter;
				ImageCodecInfo encoder = PublicModule.GetEncoder(imageFormat);
				fbitmap.Save(text, encoder, ref encoderParameters);
				encoderParameter.Dispose();
				encoderParameters.Dispose();
			}
			else
			{
				fbitmap.Save(text, imageFormat);
			}
			return text;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00027090 File Offset: 0x00025290
		public static bool isNeedDevIL(string sPath)
		{
			return false;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000270A0 File Offset: 0x000252A0
		public static Bitmap getBitMapFromFile(string sPath)
		{
			Bitmap bitmap;
			if (PublicModule.isNeedDevIL(sPath))
			{
				bitmap = (Bitmap)Image.FromFile(sPath);
			}
			else
			{
				FileInfo fileInfo = new FileInfo(sPath);
				FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
				MemoryStream memoryStream = new MemoryStream();
				fileStream.CopyTo(memoryStream);
				fileStream.Dispose();
				using (Bitmap bitmap2 = (Bitmap)Image.FromStream(memoryStream))
				{
					PixelFormat pixelFormat = bitmap2.PixelFormat;
					if (PixelFormat.Format1bppIndexed == pixelFormat | PixelFormat.Format4bppIndexed == pixelFormat | PixelFormat.Format8bppIndexed == pixelFormat)
					{
						int width = bitmap2.Width;
						int height = bitmap2.Height;
						bitmap = new Bitmap(width, height, PublicModule.checkPixelFormat(pixelFormat));
						Graphics graphics = Graphics.FromImage(bitmap);
						graphics.Clear(Color.Transparent);
						graphics.DrawImage(bitmap2, 0, 0, width, height);
						graphics.Dispose();
					}
					else
					{
						FastBitmap fastBitmap = new FastBitmap(bitmap2);
						bitmap = (Bitmap)fastBitmap.getImage().Clone();
						fastBitmap.Dispose();
					}
				}
				memoryStream.Dispose();
			}
			return bitmap;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000271B8 File Offset: 0x000253B8
		public static string sFindInListBox(string sfind, ref ListBox listbox, int imode)
		{
			string sTemp = string.Empty;
			ArrayList arrayList = new ArrayList();
			int num = 0;
			checked
			{
				int num2 = listbox.Items.Count - 1;
				for (int i = num; i <= num2; i++)
				{
					string text = listbox.Items[i].ToString();
					if (Directory.Exists(text))
					{
						PublicModule.RecursionFolder2(text, ref arrayList);
					}
					else if (File.Exists(text) && Strings.InStr(1, text, PublicModule.strMoveDirNameNoSlashes, CompareMethod.Binary) <= 0)
					{
						arrayList.Add(text);
					}
				}
				Parallel.ForEach<object>(arrayList.ToArray(), delegate(object a0, ParallelLoopState a1)
				{
					delegate(string strthis, ParallelLoopState loopstate)
					{
						if (1 == imode)
						{
							if (0 == string.Compare(sfind, strthis.Split(new char[]
							{
								Path.DirectorySeparatorChar
							}).Last<string>(), StringComparison.OrdinalIgnoreCase))
							{
								sTemp = strthis;
								loopstate.Stop();
							}
						}
						else if (2 == imode && 0 == string.Compare(sfind, Path.GetExtension(strthis), StringComparison.OrdinalIgnoreCase))
						{
							sTemp = strthis;
							loopstate.Stop();
						}
					}(Conversions.ToString(a0), a1);
				});
				return sTemp;
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00027270 File Offset: 0x00025470
		private static byte[] MD5(ref byte[] data)
		{
			return new MD5CryptoServiceProvider().ComputeHash(data);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0002728C File Offset: 0x0002548C
		private static string getMD5Hash(ref MemoryStream ms)
		{
			byte[] array = ms.ToArray();
			return BitConverter.ToString(PublicModule.MD5(ref array)).Replace("-", string.Empty);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000272BC File Offset: 0x000254BC
		public static bool isColorWhile(ref Color c)
		{
			return c.R == byte.MaxValue & c.G == byte.MaxValue & c.B == byte.MaxValue;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000272F8 File Offset: 0x000254F8
		public static bool isColorBlack(ref Color c)
		{
			return c.R == 0 & c.G == 0 & c.B == 0;
		}

		// Token: 0x04000294 RID: 660
		public static bool bWaitCancelAsync = false;

		// Token: 0x04000295 RID: 661
		public static readonly int iMaxCpuProcessor = Environment.ProcessorCount;

		// Token: 0x04000296 RID: 662
		public static int iThreadWaitTime = 100;

		// Token: 0x04000297 RID: 663
		public static int iCpuProcessor = 1;

		// Token: 0x04000298 RID: 664
		public static ArrayList files1 = new ArrayList();

		// Token: 0x04000299 RID: 665
		public static ArrayList files2 = new ArrayList();

		// Token: 0x0400029A RID: 666
		public static ArrayList files3 = new ArrayList();

		// Token: 0x0400029B RID: 667
		public static int iCount;

		// Token: 0x0400029C RID: 668
		public static int iNow;

		// Token: 0x0400029D RID: 669
		public static int iMaxToBW;

		// Token: 0x0400029E RID: 670
		public static int iBuild;

		// Token: 0x0400029F RID: 671
		public static StringBuilder strLog = new StringBuilder();

		// Token: 0x040002A0 RID: 672
		public static ArrayList pLeft = new ArrayList();

		// Token: 0x040002A1 RID: 673
		public static ArrayList pRight = new ArrayList();

		// Token: 0x040002A2 RID: 674
		public static readonly Encoding JpEncode = Encoding.GetEncoding("shift-jis");

		// Token: 0x040002A3 RID: 675
		public static int iUseTime = 0;

		// Token: 0x040002A4 RID: 676
		public static int iUseTimeSecond = 0;

		// Token: 0x040002A5 RID: 677
		public static int iUseTimeMinute = 0;

		// Token: 0x040002A6 RID: 678
		public static int iUseTimeHour = 0;

		// Token: 0x040002A7 RID: 679
		public static readonly string[] extArr = new string[]
		{
			"png",
			"bmp",
			"jpg",
			"jpeg",
			"gif",
			"tga",
			"dds"
		};

		// Token: 0x040002A8 RID: 680
		public static int i2SaveBitmapFormat = 0;

		// Token: 0x040002A9 RID: 681
		public static int i2SaveBitmapFormatJpg = 100;

		// Token: 0x040002AA RID: 682
		public static Hashtable MD5HashArr = new Hashtable(1000);

		// Token: 0x040002AB RID: 683
		public static int i2CheckHash = 0;

		// Token: 0x040002AC RID: 684
		public static ArrayList form1box4directorylist = new ArrayList(10);

		// Token: 0x040002AD RID: 685
		public static string sSpecialExt = string.Empty;

		// Token: 0x040002AE RID: 686
		public static string sGameExe = string.Empty;

		// Token: 0x040002AF RID: 687
		public static int iForm3Tx = 0;

		// Token: 0x040002B0 RID: 688
		public static int iForm3Ty = 0;

		// Token: 0x040002B1 RID: 689
		public static MultipleLanguages thisLang;

		// Token: 0x040002B2 RID: 690
		public static string strCultureLangName = "zh-CN";

		// Token: 0x040002B3 RID: 691
		public const string sLangXmlTextDir = "lang";

		// Token: 0x040002B4 RID: 692
		public static GalPhotoAutoConfig galConfig = new GalPhotoAutoConfig();

		// Token: 0x040002B5 RID: 693
		public const string strMoveDirName = "0_YouCanDel";

		// Token: 0x040002B6 RID: 694
		public static readonly string strMoveDirNameNoSlashes = Path.Combine(Conversions.ToString(Path.DirectorySeparatorChar), "0_YouCanDel");

		// Token: 0x040002B7 RID: 695
		public static Regex regAT = new Regex("@");

		// Token: 0x040002B8 RID: 696
		public static Regex regXIA = new Regex("_");

		// Token: 0x040002B9 RID: 697
		public static Regex regDOT = new Regex("\\.");

		// Token: 0x040002BA RID: 698
		public static Regex regPOS = new Regex("pos");

		// Token: 0x040002BB RID: 699
		public static Regex regEqual = new Regex("=");

		// Token: 0x040002BC RID: 700
		public static Regex regBigSpace = new Regex("\t");

		// Token: 0x040002BD RID: 701
		public static Regex regSmallSpace = new Regex(" ");

		// Token: 0x040002BE RID: 702
		public const int WM_COMMAND = 273;

		// Token: 0x040002BF RID: 703
		public const int THBN_CLICKED = 6144;

		// Token: 0x040002C0 RID: 704
		public const int MF_BYCOMMAND = 0;

		// Token: 0x040002C1 RID: 705
		public const int MF_BYPOSITION = 1024;

		// Token: 0x040002C2 RID: 706
		public const int MF_STRING = 0;

		// Token: 0x040002C3 RID: 707
		public const int MF_SEPARATOR = 2048;

		// Token: 0x040002C4 RID: 708
		public const int WM_SYSCOMMAND = 274;

		// Token: 0x040002C5 RID: 709
		public const int MF_REMOVE = 4096;

		// Token: 0x040002C6 RID: 710
		public const int MF_POPUP = 16;

		// Token: 0x040002C7 RID: 711
		public const int MF_CHECKED = 8;

		// Token: 0x040002C8 RID: 712
		public const int MF_UNCHECKED = 0;

		// Token: 0x040002C9 RID: 713
		private const int WM_DROPFILES = 563;

		// Token: 0x040002CA RID: 714
		private const int WM_COPYDATA = 74;

		// Token: 0x040002CB RID: 715
		private const int WM_COPYGLOBALDATA = 73;

		// Token: 0x040002CC RID: 716
		private const int MSGFLT_ADD = 1;

		// Token: 0x040002CD RID: 717
		private static object objects = RuntimeHelpers.GetObjectValue(new object());

		// Token: 0x020000BF RID: 191
		public struct GalPhotoAutoConfigType
		{
			// Token: 0x040002CE RID: 718
			public const string iThreadWaitingTime = "iThreadWaitingTime";

			// Token: 0x040002CF RID: 719
			public const string iUseCpuCore = "iUseCpuCore";

			// Token: 0x040002D0 RID: 720
			public const string sLastLanguage = "sLastLanguage";

			// Token: 0x040002D1 RID: 721
			public const string iNumUpDown5 = "iNumUpDown5";

			// Token: 0x040002D2 RID: 722
			public const string iNumUpDown6 = "iNumUpDown6";

			// Token: 0x040002D3 RID: 723
			public const string p2SaveBitmapFormat = "p2SaveBitmapFormat";

			// Token: 0x040002D4 RID: 724
			public const string iNumUpDown13 = "iNumUpDown13";

			// Token: 0x040002D5 RID: 725
			public const string iNumUpDown8 = "iNumUpDown8";

			// Token: 0x040002D6 RID: 726
			public const string iNumUpDown12 = "iNumUpDown12";

			// Token: 0x040002D7 RID: 727
			public const string iF3NumUpDown1 = "iF3NumUpDown1";

			// Token: 0x040002D8 RID: 728
			public const string iF3NumUpDown2 = "iF3NumUpDown2";

			// Token: 0x040002D9 RID: 729
			public const string i2CheckHash = "i2CheckHash";

			// Token: 0x040002DA RID: 730
			public const string iNumUpDown16 = "iNumUpDown16";

			// Token: 0x040002DB RID: 731
			public const string iNumUpDown17 = "iNumUpDown17";
		}
	}
}
