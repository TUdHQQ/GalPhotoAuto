using System;
using System.Collections;
using System.Diagnostics;
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
using DevIL;
using GalPhotoAuto;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x0200009C RID: 156
[StandardModule]
internal sealed class x
{
	// Token: 0x060001C4 RID: 452
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int SetForegroundWindow(IntPtr A_0);

	// Token: 0x060001C5 RID: 453
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern bool ShowWindowAsync(IntPtr A_0, int A_1);

	// Token: 0x060001C6 RID: 454
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int GetSystemMenu(IntPtr A_0, int A_1);

	// Token: 0x060001C7 RID: 455
	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "InsertMenuA", ExactSpelling = true, SetLastError = true)]
	public static extern int InsertMenu(int A_0, int A_1, int A_2, int A_3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string A_4);

	// Token: 0x060001C8 RID: 456
	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "AppendMenuA", ExactSpelling = true, SetLastError = true)]
	public static extern int AppendMenu(int A_0, int A_1, int A_2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string A_3);

	// Token: 0x060001C9 RID: 457
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int CreatePopupMenu();

	// Token: 0x060001CA RID: 458
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int CheckMenuItem(int A_0, int A_1, int A_2);

	// Token: 0x060001CB RID: 459
	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "ModifyMenuA", ExactSpelling = true, SetLastError = true)]
	public static extern int ModifyMenu(int A_0, int A_1, int A_2, int A_3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string A_4);

	// Token: 0x060001CC RID: 460 RVA: 0x000239DD File Offset: 0x00021BDD
	public static void c(string A_0)
	{
		global::x.l.Insert(0, Conversions.ToString(DateTime.Now) + " : " + A_0 + "\r\n");
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00023A08 File Offset: 0x00021C08
	public static void a(ref ListBox A_0, ref ArrayList A_1)
	{
		A_1.Clear();
		int num = 0;
		checked
		{
			int num2 = A_0.Items.Count - 1;
			for (int i = num; i <= num2; i++)
			{
				string text = A_0.Items[i].ToString();
				if (Directory.Exists(text))
				{
					global::x.y.Add(text);
					global::x.b(text, ref A_1);
				}
				else if (File.Exists(text) && Strings.InStr(1, text, global::x.ai, CompareMethod.Binary) <= 0 && global::x.a(text, false))
				{
					A_1.Add(text);
				}
			}
		}
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00023A94 File Offset: 0x00021C94
	public static void b(string A_0, ref ArrayList A_1)
	{
		string[] files = Directory.GetFiles(A_0);
		checked
		{
			if (files.Length > 0)
			{
				int num = Information.LBound(files, 1);
				int num2 = Information.UBound(files, 1);
				for (int i = num; i <= num2; i++)
				{
					if (global::x.a(files[i], false) && Strings.InStr(1, files[i], global::x.ai, CompareMethod.Binary) <= 0)
					{
						A_1.Add(files[i]);
					}
				}
			}
			string[] directories = Directory.GetDirectories(A_0);
			if (directories.Length > 0)
			{
				int num3 = Information.LBound(directories, 1);
				int num4 = Information.UBound(directories, 1);
				for (int i = num3; i <= num4; i++)
				{
					if (Strings.InStr(1, directories[i], global::x.ai, CompareMethod.Binary) <= 0)
					{
						global::x.b(directories[i], ref A_1);
					}
				}
			}
		}
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00023B34 File Offset: 0x00021D34
	public static void a(string A_0, ref ArrayList A_1)
	{
		string[] files = Directory.GetFiles(A_0);
		checked
		{
			if (files.Length > 0)
			{
				int num = Information.LBound(files, 1);
				int num2 = Information.UBound(files, 1);
				for (int i = num; i <= num2; i++)
				{
					if (Strings.InStr(1, files[i], global::x.ai, CompareMethod.Binary) <= 0)
					{
						A_1.Add(files[i]);
					}
				}
			}
			string[] directories = Directory.GetDirectories(A_0);
			if (directories.Length > 0)
			{
				int num3 = Information.LBound(directories, 1);
				int num4 = Information.UBound(directories, 1);
				for (int i = num3; i <= num4; i++)
				{
					if (Strings.InStr(1, directories[i], global::x.ai, CompareMethod.Binary) <= 0)
					{
						global::x.a(directories[i], ref A_1);
					}
				}
			}
		}
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00023BCC File Offset: 0x00021DCC
	public static bool a(string A_0, bool A_1 = false)
	{
		if (A_1)
		{
			return true;
		}
		string text = Path.GetExtension(A_0).ToLower();
		if (0 >= text.Length)
		{
			return false;
		}
		string strA = text.Substring(1);
		if (!string.IsNullOrWhiteSpace(global::x.z))
		{
			if (0 == string.Compare("*", global::x.z, StringComparison.Ordinal))
			{
				return true;
			}
			if (0 == string.Compare(strA, global::x.z, StringComparison.Ordinal))
			{
				return true;
			}
		}
		else
		{
			foreach (string strB in global::x.t)
			{
				if (0 == string.Compare(strA, strB, StringComparison.Ordinal))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00023C60 File Offset: 0x00021E60
	public static PixelFormat a(PixelFormat A_0)
	{
		if (A_0 == PixelFormat.Format32bppArgb)
		{
			return A_0;
		}
		if (A_0 == PixelFormat.Format32bppRgb)
		{
			return PixelFormat.Format32bppArgb;
		}
		if (A_0 == PixelFormat.Format24bppRgb)
		{
			return A_0;
		}
		if (A_0 == PixelFormat.Undefined)
		{
			return PixelFormat.Format32bppArgb;
		}
		if (A_0 == PixelFormat.Undefined)
		{
			return PixelFormat.Format32bppArgb;
		}
		if (A_0 == PixelFormat.Format16bppArgb1555)
		{
			return PixelFormat.Format32bppArgb;
		}
		if (A_0 == PixelFormat.Format1bppIndexed)
		{
			return PixelFormat.Format24bppRgb;
		}
		if (A_0 == PixelFormat.Format4bppIndexed)
		{
			return PixelFormat.Format24bppRgb;
		}
		if (A_0 == PixelFormat.Format8bppIndexed)
		{
			return PixelFormat.Format24bppRgb;
		}
		if (A_0 <= PixelFormat.Format24bppRgb)
		{
			return A_0;
		}
		if (A_0 >= PixelFormat.Format32bppArgb)
		{
			return A_0;
		}
		return PixelFormat.Format32bppArgb;
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00023CF8 File Offset: 0x00021EF8
	public static ImageCodecInfo a(ImageFormat A_0)
	{
		ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
		foreach (ImageCodecInfo imageCodecInfo in imageDecoders)
		{
			if (imageCodecInfo.FormatID == A_0.Guid)
			{
				return imageCodecInfo;
			}
		}
		return null;
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00023D38 File Offset: 0x00021F38
	public static int c(ref Color A_0)
	{
		int result;
		if (A_0.R == A_0.G & A_0.R == A_0.B)
		{
			result = (int)A_0.R;
		}
		else
		{
			result = checked((int)Math.Round(unchecked(0.212671 * (double)A_0.R + 0.71516 * (double)A_0.G + 0.072169 * (double)A_0.B)));
		}
		return result;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00023DAC File Offset: 0x00021FAC
	public static string a(string A_0, string A_1 = "")
	{
		string result = string.Empty;
		string text = string.Empty;
		int num = 0;
		int upperBound = global::x.t.GetUpperBound(0);
		checked
		{
			for (int i = num; i <= upperBound; i++)
			{
				if (string.IsNullOrEmpty(A_1))
				{
					text = A_0 + "." + global::x.t[i];
				}
				else
				{
					text = A_0 + A_1 + "." + global::x.t[i];
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

	// Token: 0x060001D5 RID: 469 RVA: 0x00023E20 File Offset: 0x00022020
	public static string a(ref Hashtable A_0, string A_1)
	{
		string result = string.Empty;
		Hashtable obj = A_0;
		lock (obj)
		{
			if (0 < A_0.Count)
			{
				foreach (object obj2 in A_0)
				{
					DictionaryEntry dictionaryEntry2;
					DictionaryEntry dictionaryEntry = (obj2 != null) ? ((DictionaryEntry)obj2) : dictionaryEntry2;
					if (0 == string.Compare(A_1, dictionaryEntry.Key.ToString(), StringComparison.Ordinal))
					{
						result = dictionaryEntry.Value.ToString();
						break;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00023EBC File Offset: 0x000220BC
	public static bool b(ref ArrayList A_0, string A_1)
	{
		x.d d = new x.d();
		d.b = A_1;
		d.a = false;
		if (0 < A_0.Count)
		{
			string[] array = new string[checked(A_0.Count - 1 + 1)];
			ArrayList obj = A_0;
			lock (obj)
			{
				A_0.CopyTo(array, 0);
			}
			Parallel.ForEach<string>(array, new Action<string, ParallelLoopState>(d.c));
		}
		return d.a;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00023F48 File Offset: 0x00022148
	public static string a(ref ArrayList A_0, string A_1)
	{
		x.a a = new x.a();
		a.b = A_1;
		a.a = string.Empty;
		if (0 < A_0.Count)
		{
			string[] array = new string[checked(A_0.Count - 1 + 1)];
			ArrayList obj = A_0;
			lock (obj)
			{
				A_0.CopyTo(array, 0);
			}
			Parallel.ForEach<string>(array, new Action<string, ParallelLoopState>(a.c));
		}
		return a.a;
	}

	// Token: 0x060001D8 RID: 472
	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool ChangeWindowMessageFilter(uint A_0, int A_1);

	// Token: 0x060001D9 RID: 473 RVA: 0x00023FD8 File Offset: 0x000221D8
	public static void c()
	{
		global::x.ChangeWindowMessageFilter(563U, 1);
		global::x.ChangeWindowMessageFilter(74U, 1);
		global::x.ChangeWindowMessageFilter(73U, 1);
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00023FF8 File Offset: 0x000221F8
	public static string b()
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

	// Token: 0x060001DB RID: 475 RVA: 0x00024058 File Offset: 0x00022258
	public static void a(ref ComboBox A_0)
	{
		Graphics graphics = A_0.CreateGraphics();
		int selectedIndex = A_0.SelectedIndex;
		int num = 0;
		checked
		{
			int num2 = A_0.Items.Count - 1;
			int num3;
			for (int i = num; i <= num2; i++)
			{
				A_0.SelectedIndex = i;
				SizeF sizeF = graphics.MeasureString(A_0.Text, A_0.Font);
				if ((float)num3 < sizeF.Width)
				{
					num3 = (int)Math.Round((double)sizeF.Width);
				}
			}
			A_0.DropDownWidth = A_0.Width;
			if (A_0.DropDownWidth < num3)
			{
				A_0.DropDownWidth = num3;
				A_0.Width = num3;
			}
			A_0.SelectedIndex = selectedIndex;
		}
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00024100 File Offset: 0x00022300
	public static ParallelOptions a()
	{
		if (1 > global::x.d | global::x.d > global::x.b)
		{
			global::x.d = global::x.b;
		}
		return new ParallelOptions
		{
			MaxDegreeOfParallelism = global::x.d
		};
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00024140 File Offset: 0x00022340
	public static string a(string A_0, string A_1, int A_2 = 0)
	{
		checked
		{
			int num = A_0.Length - 1;
			int num2 = A_1.Length - 1;
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = 0;
			int num4 = num;
			int num5 = num3;
			while (num5 <= num4 && num5 <= num2 && 0 == string.Compare(Conversions.ToString(A_0[num5]), Conversions.ToString(A_1[num5]), StringComparison.Ordinal))
			{
				stringBuilder.Append(A_0[num5]);
				num5++;
			}
			if (0 < stringBuilder.Length)
			{
				string text = stringBuilder.ToString();
				return A_1.Substring(text.Length);
			}
			if (0 == A_2)
			{
				return A_1;
			}
			return A_0;
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x000241E4 File Offset: 0x000223E4
	public static string a(string A_0, ref Bitmap A_1, bool A_2 = true)
	{
		string text;
		ImageFormat imageFormat;
		switch (global::x.u)
		{
		case 0:
			text = A_0 + ".png";
			imageFormat = ImageFormat.Png;
			break;
		case 1:
			text = A_0 + ".bmp";
			imageFormat = ImageFormat.Bmp;
			break;
		case 2:
			text = A_0 + ".jpg";
			imageFormat = ImageFormat.Jpeg;
			break;
		default:
			text = A_0 + ".png";
			imageFormat = ImageFormat.Png;
			break;
		}
		if (1 == global::x.x)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				A_1.Save(memoryStream, ImageFormat.Png);
				MemoryStream memoryStream2 = memoryStream;
				string text2 = global::x.a(ref memoryStream2);
				string text3 = global::x.a(ref global::x.w, text2);
				if (!string.IsNullOrEmpty(text3))
				{
					global::x.c(Path.GetFileName(text) + " <= same with => " + text3);
					return string.Empty;
				}
				global::x.w.Add(text2, Path.GetFileName(text));
			}
		}
		checked
		{
			if (A_2)
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
		if (2 == global::x.u)
		{
			System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
			EncoderParameters encoderParameters = new EncoderParameters(1);
			EncoderParameter encoderParameter = new EncoderParameter(quality, (long)global::x.v);
			encoderParameters.Param[0] = encoderParameter;
			ImageCodecInfo encoder = global::x.a(imageFormat);
			A_1.Save(text, encoder, encoderParameters);
			encoderParameter.Dispose();
			encoderParameters.Dispose();
		}
		else
		{
			A_1.Save(text, imageFormat);
		}
		return text;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00024398 File Offset: 0x00022598
	public static string a(string A_0, ref FastBitmap A_1)
	{
		string text;
		ImageFormat imageFormat;
		switch (global::x.u)
		{
		case 0:
			text = A_0 + ".png";
			imageFormat = ImageFormat.Png;
			break;
		case 1:
			text = A_0 + ".bmp";
			imageFormat = ImageFormat.Bmp;
			break;
		case 2:
			text = A_0 + ".jpg";
			imageFormat = ImageFormat.Jpeg;
			break;
		default:
			text = A_0 + ".png";
			imageFormat = ImageFormat.Png;
			break;
		}
		if (1 == global::x.x)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				FastBitmap fastBitmap = A_1;
				MemoryStream memoryStream2 = memoryStream;
				fastBitmap.Save(ref memoryStream2, ImageFormat.Png);
				memoryStream2 = memoryStream;
				string text2 = global::x.a(ref memoryStream2);
				string text3 = global::x.a(ref global::x.w, text2);
				if (!string.IsNullOrEmpty(text3))
				{
					global::x.c(Path.GetFileName(text) + " <= same with => " + text3);
					return string.Empty;
				}
				global::x.w.Add(text2, Path.GetFileName(text));
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
		if (2 == global::x.u)
		{
			System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
			EncoderParameters encoderParameters = new EncoderParameters(1);
			EncoderParameter encoderParameter = new EncoderParameter(quality, (long)global::x.v);
			encoderParameters.Param[0] = encoderParameter;
			ImageCodecInfo imgci = global::x.a(imageFormat);
			A_1.Save(text, imgci, ref encoderParameters);
			encoderParameter.Dispose();
			encoderParameters.Dispose();
		}
		else
		{
			A_1.Save(text, imageFormat);
		}
		return text;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0002453C File Offset: 0x0002273C
	public static bool b(string A_0)
	{
		string text = Path.GetExtension(A_0).Substring(1).ToLower();
		string left = text;
		return Operators.CompareString(left, "tga", false) == 0 || Operators.CompareString(left, "dds", false) == 0;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00024580 File Offset: 0x00022780
	public static Bitmap a(string A_0)
	{
		if (global::x.b(A_0))
		{
			object obj = global::x.a5;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			lock (obj)
			{
				return DevIL.LoadBitmap(A_0);
			}
		}
		FileInfo fileInfo = new FileInfo(A_0);
		FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
		MemoryStream memoryStream = new MemoryStream();
		fileStream.CopyTo(memoryStream);
		fileStream.Dispose();
		Bitmap bitmap2;
		using (Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream))
		{
			PixelFormat pixelFormat = bitmap.PixelFormat;
			if (PixelFormat.Format1bppIndexed == pixelFormat | PixelFormat.Format4bppIndexed == pixelFormat | PixelFormat.Format8bppIndexed == pixelFormat)
			{
				int width = bitmap.Width;
				int height = bitmap.Height;
				bitmap2 = new Bitmap(width, height, global::x.a(pixelFormat));
				Graphics graphics = Graphics.FromImage(bitmap2);
				graphics.Clear(Color.Transparent);
				graphics.DrawImage(bitmap, 0, 0, width, height);
				graphics.Dispose();
			}
			else
			{
				FastBitmap fastBitmap = new FastBitmap(bitmap);
				bitmap2 = (Bitmap)fastBitmap.getImage().Clone();
				fastBitmap.Dispose();
			}
		}
		memoryStream.Dispose();
		return bitmap2;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x000246CC File Offset: 0x000228CC
	public static string a(string A_0, ref ListBox A_1, int A_2)
	{
		x.b b = new x.b();
		b.b = A_0;
		b.a = A_2;
		b.c = string.Empty;
		ArrayList arrayList = new ArrayList();
		int num = 0;
		checked
		{
			int num2 = A_1.Items.Count - 1;
			for (int i = num; i <= num2; i++)
			{
				string text = A_1.Items[i].ToString();
				if (Directory.Exists(text))
				{
					global::x.a(text, ref arrayList);
				}
				else if (File.Exists(text) && Strings.InStr(1, text, global::x.ai, CompareMethod.Binary) <= 0)
				{
					arrayList.Add(text);
				}
			}
			Parallel.ForEach<object>(arrayList.ToArray(), new Action<object, ParallelLoopState>(b.d));
			return b.c;
		}
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00024784 File Offset: 0x00022984
	private static byte[] a(ref byte[] A_0)
	{
		return new MD5CryptoServiceProvider().ComputeHash(A_0);
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x000247A0 File Offset: 0x000229A0
	private static string a(ref MemoryStream A_0)
	{
		byte[] array = A_0.ToArray();
		return BitConverter.ToString(global::x.a(ref array)).Replace("-", string.Empty);
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x000247D0 File Offset: 0x000229D0
	public static bool b(ref Color A_0)
	{
		return A_0.R == byte.MaxValue & A_0.G == byte.MaxValue & A_0.B == byte.MaxValue;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0002480C File Offset: 0x00022A0C
	public static bool a(ref Color A_0)
	{
		return A_0.R == 0 & A_0.G == 0 & A_0.B == 0;
	}

	// Token: 0x0400026C RID: 620
	public static bool a = false;

	// Token: 0x0400026D RID: 621
	public static readonly int b = Environment.ProcessorCount;

	// Token: 0x0400026E RID: 622
	public static int c = 100;

	// Token: 0x0400026F RID: 623
	public static int d = 1;

	// Token: 0x04000270 RID: 624
	public static ArrayList e = new ArrayList();

	// Token: 0x04000271 RID: 625
	public static ArrayList f = new ArrayList();

	// Token: 0x04000272 RID: 626
	public static ArrayList g = new ArrayList();

	// Token: 0x04000273 RID: 627
	public static int h;

	// Token: 0x04000274 RID: 628
	public static int i;

	// Token: 0x04000275 RID: 629
	public static int j;

	// Token: 0x04000276 RID: 630
	public static int k;

	// Token: 0x04000277 RID: 631
	public static StringBuilder l = new StringBuilder();

	// Token: 0x04000278 RID: 632
	public static ArrayList m = new ArrayList();

	// Token: 0x04000279 RID: 633
	public static ArrayList n = new ArrayList();

	// Token: 0x0400027A RID: 634
	public static readonly Encoding o = Encoding.GetEncoding("shift-jis");

	// Token: 0x0400027B RID: 635
	public static int p = 0;

	// Token: 0x0400027C RID: 636
	public static int q = 0;

	// Token: 0x0400027D RID: 637
	public static int r = 0;

	// Token: 0x0400027E RID: 638
	public static int s = 0;

	// Token: 0x0400027F RID: 639
	public static readonly string[] t = new string[]
	{
		"png",
		"bmp",
		"jpg",
		"jpeg",
		"gif",
		"tga",
		"dds"
	};

	// Token: 0x04000280 RID: 640
	public static int u = 0;

	// Token: 0x04000281 RID: 641
	public static int v = 100;

	// Token: 0x04000282 RID: 642
	public static Hashtable w = new Hashtable(1000);

	// Token: 0x04000283 RID: 643
	public static int x = 0;

	// Token: 0x04000284 RID: 644
	public static ArrayList y = new ArrayList(10);

	// Token: 0x04000285 RID: 645
	public static string z = string.Empty;

	// Token: 0x04000286 RID: 646
	public static string aa = string.Empty;

	// Token: 0x04000287 RID: 647
	public static int ab = 0;

	// Token: 0x04000288 RID: 648
	public static int ac = 0;

	// Token: 0x04000289 RID: 649
	public static MultipleLanguages ad;

	// Token: 0x0400028A RID: 650
	public static string ae = "zh-CN";

	// Token: 0x0400028B RID: 651
	public const string af = "lang";

	// Token: 0x0400028C RID: 652
	public static GalPhotoAutoConfig ag = new GalPhotoAutoConfig();

	// Token: 0x0400028D RID: 653
	public const string ah = "0_YouCanDel";

	// Token: 0x0400028E RID: 654
	public static readonly string ai = Path.Combine(Conversions.ToString(Path.DirectorySeparatorChar), "0_YouCanDel");

	// Token: 0x0400028F RID: 655
	public static Regex aj = new Regex("@");

	// Token: 0x04000290 RID: 656
	public static Regex ak = new Regex("_");

	// Token: 0x04000291 RID: 657
	public static Regex al = new Regex("\\.");

	// Token: 0x04000292 RID: 658
	public static Regex am = new Regex("pos");

	// Token: 0x04000293 RID: 659
	public static Regex an = new Regex("=");

	// Token: 0x04000294 RID: 660
	public static Regex ao = new Regex("\t");

	// Token: 0x04000295 RID: 661
	public static Regex ap = new Regex(" ");

	// Token: 0x04000296 RID: 662
	public const int aq = 273;

	// Token: 0x04000297 RID: 663
	public const int ar = 6144;

	// Token: 0x04000298 RID: 664
	public const int @as = 0;

	// Token: 0x04000299 RID: 665
	public const int at = 1024;

	// Token: 0x0400029A RID: 666
	public const int au = 0;

	// Token: 0x0400029B RID: 667
	public const int av = 2048;

	// Token: 0x0400029C RID: 668
	public const int aw = 274;

	// Token: 0x0400029D RID: 669
	public const int ax = 4096;

	// Token: 0x0400029E RID: 670
	public const int ay = 16;

	// Token: 0x0400029F RID: 671
	public const int az = 8;

	// Token: 0x040002A0 RID: 672
	public const int a0 = 0;

	// Token: 0x040002A1 RID: 673
	private const int a1 = 563;

	// Token: 0x040002A2 RID: 674
	private const int a2 = 74;

	// Token: 0x040002A3 RID: 675
	private const int a3 = 73;

	// Token: 0x040002A4 RID: 676
	private const int a4 = 1;

	// Token: 0x040002A5 RID: 677
	private static object a5 = RuntimeHelpers.GetObjectValue(new object());

	// Token: 0x0200009D RID: 157
	public struct c
	{
		// Token: 0x040002A6 RID: 678
		public const string a = "iThreadWaitingTime";

		// Token: 0x040002A7 RID: 679
		public const string b = "iUseCpuCore";

		// Token: 0x040002A8 RID: 680
		public const string c = "sLastLanguage";

		// Token: 0x040002A9 RID: 681
		public const string d = "iNumUpDown5";

		// Token: 0x040002AA RID: 682
		public const string e = "iNumUpDown6";

		// Token: 0x040002AB RID: 683
		public const string f = "p2SaveBitmapFormat";

		// Token: 0x040002AC RID: 684
		public const string g = "iNumUpDown13";

		// Token: 0x040002AD RID: 685
		public const string h = "iNumUpDown8";

		// Token: 0x040002AE RID: 686
		public const string i = "iNumUpDown12";

		// Token: 0x040002AF RID: 687
		public const string j = "iF3NumUpDown1";

		// Token: 0x040002B0 RID: 688
		public const string k = "iF3NumUpDown2";

		// Token: 0x040002B1 RID: 689
		public const string l = "i2CheckHash";

		// Token: 0x040002B2 RID: 690
		public const string m = "iNumUpDown16";

		// Token: 0x040002B3 RID: 691
		public const string n = "iNumUpDown17";
	}

	// Token: 0x0200009E RID: 158
	[CompilerGenerated]
	internal class d
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00024843 File Offset: 0x00022A43
		[CompilerGenerated]
		public void c(string A_0, ParallelLoopState A_1)
		{
			if (0 == string.Compare(this.b, A_0, StringComparison.Ordinal))
			{
				this.a = true;
				A_1.Stop();
			}
		}

		// Token: 0x040002B4 RID: 692
		public bool a;

		// Token: 0x040002B5 RID: 693
		public string b;
	}

	// Token: 0x0200009F RID: 159
	[CompilerGenerated]
	internal class a
	{
		// Token: 0x060001EA RID: 490 RVA: 0x0002486A File Offset: 0x00022A6A
		[CompilerGenerated]
		public void c(string A_0, ParallelLoopState A_1)
		{
			if (0 == string.Compare(this.b, Path.GetFileNameWithoutExtension(A_0), StringComparison.Ordinal))
			{
				this.a = A_0;
				A_1.Stop();
			}
		}

		// Token: 0x040002B6 RID: 694
		public string a;

		// Token: 0x040002B7 RID: 695
		public string b;
	}

	// Token: 0x020000A0 RID: 160
	[CompilerGenerated]
	internal class b
	{
		// Token: 0x060001EC RID: 492 RVA: 0x00024896 File Offset: 0x00022A96
		[DebuggerStepThrough]
		[CompilerGenerated]
		public void d(object A_0, ParallelLoopState A_1)
		{
			new i<string, ParallelLoopState>(this.d)(Conversions.ToString(A_0), A_1);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000248B4 File Offset: 0x00022AB4
		[CompilerGenerated]
		public void d(string A_0, ParallelLoopState A_1)
		{
			if (1 == this.a)
			{
				if (0 == string.Compare(this.b, A_0.Split(new char[]
				{
					Path.DirectorySeparatorChar
				}).Last<string>(), StringComparison.OrdinalIgnoreCase))
				{
					this.c = A_0;
					A_1.Stop();
				}
			}
			else if (2 == this.a && 0 == string.Compare(this.b, Path.GetExtension(A_0), StringComparison.OrdinalIgnoreCase))
			{
				this.c = A_0;
				A_1.Stop();
			}
		}

		// Token: 0x040002B8 RID: 696
		public int a;

		// Token: 0x040002B9 RID: 697
		public string b;

		// Token: 0x040002BA RID: 698
		public string c;
	}
}
