using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C4 RID: 196
	public class asmodean_fun
	{
		// Token: 0x0600028C RID: 652 RVA: 0x00027BBC File Offset: 0x00025DBC
		public static string[] get_ad_xy(string sname)
		{
			string[] array = new string[]
			{
				sname,
				"0",
				"0"
			};
			string[] array2 = sname.Split(new char[]
			{
				'+'
			});
			if (array2.Count<string>() > 1)
			{
				array[0] = array2.First<string>();
				string text = array2.Last<string>();
				array2 = text.Split(new char[]
				{
					'y'
				});
				array[1] = array2[0].Replace("x", "");
				array[2] = array2[1];
			}
			return array;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00027C48 File Offset: 0x00025E48
		public static int[] get_ad_dat_date(string sdatfile, ref ArrayList charArr)
		{
			int[] array = new int[5];
			checked
			{
				using (FileStream fileStream = new FileStream(sdatfile, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					fileStream.Seek(64L, SeekOrigin.Begin);
					int num = binaryReader.ReadInt32();
					num = binaryReader.ReadInt32();
					array[0] = num;
					bool flag = false;
					int num2 = 0;
					char[] array2 = binaryReader.ReadChars(4);
					if ('\0' == array2[2] & '\0' == array2[3])
					{
						flag = true;
					}
					if (flag)
					{
						fileStream.Seek(-4L, SeekOrigin.Current);
						num2 = binaryReader.ReadInt32();
					}
					else
					{
						fileStream.Seek(-4L, SeekOrigin.Current);
					}
					fileStream.Seek(64L, SeekOrigin.Current);
					num = binaryReader.ReadInt32();
					if (flag)
					{
						array[1] = num2 + num - 640;
					}
					else
					{
						array[1] = num;
					}
					num = binaryReader.ReadInt32();
					if (flag)
					{
						array[2] = array[0] + num - 720;
					}
					else
					{
						array[2] = num;
					}
					num = binaryReader.ReadInt32();
					array[3] = num;
					num = binaryReader.ReadInt32();
					array[4] = num;
					while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
					{
						int[] array3 = new int[2];
						num = binaryReader.ReadInt32();
						array3[0] = num;
						num = binaryReader.ReadInt32();
						array3[1] = num;
						if (0 == array3[0] & 0 == array3[1])
						{
							break;
						}
						charArr.Add(array3);
					}
					binaryReader.Dispose();
				}
				return array;
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00027DC8 File Offset: 0x00025FC8
		public static ArrayList read_visualdat_to_arr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Seek(60L, SeekOrigin.Begin);
				StringBuilder stringBuilder = new StringBuilder();
				string text = string.Empty;
				while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
				{
					string[] array = new string[4];
					long num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					num = (long)binaryReader.ReadInt32();
					text = Conversions.ToString(binaryReader.ReadChar());
					while (Operators.CompareString(text, "\0", false) != 0)
					{
						stringBuilder.Append(text);
						text = Conversions.ToString(binaryReader.ReadChar());
					}
					num = (long)binaryReader.PeekChar();
					if (0L == num)
					{
						stringBuilder = new StringBuilder();
						text = new string(binaryReader.ReadChars(9));
						num = binaryReader.ReadInt64();
					}
					else
					{
						array[0] = stringBuilder.ToString();
						stringBuilder = new StringBuilder();
						text = Conversions.ToString(binaryReader.ReadChar());
						while (Operators.CompareString(text, "\0", false) != 0)
						{
							stringBuilder.Append(text);
							text = Conversions.ToString(binaryReader.ReadChar());
						}
						array[1] = stringBuilder.ToString();
						num = (long)binaryReader.ReadInt32();
						array[2] = Conversions.ToString(num);
						num = (long)binaryReader.ReadInt32();
						array[3] = Conversions.ToString(num);
						num = binaryReader.ReadInt64();
						arrayList.Add(array);
						stringBuilder = new StringBuilder();
					}
				}
				binaryReader.Dispose();
			}
			return arrayList;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00027FA4 File Offset: 0x000261A4
		public static void read_spm_to_arr(string sPath, ref ArrayList spmArr, ref ArrayList fileArr)
		{
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					StringBuilder stringBuilder = new StringBuilder();
					fileStream.Seek(13L, SeekOrigin.Begin);
					int num = binaryReader.ReadInt32();
					int num2 = 0;
					int num3 = num - 1;
					for (int i = num2; i <= num3; i++)
					{
						asmodean_fun.spmFileDataCount spmFileDataCount = default(asmodean_fun.spmFileDataCount);
						spmFileDataCount.iThisCount = binaryReader.ReadInt32();
						spmFileDataCount.iWidth = binaryReader.ReadInt32();
						spmFileDataCount.iHeight = binaryReader.ReadInt32();
						spmFileDataCount.iX = binaryReader.ReadInt32();
						spmFileDataCount.iY = binaryReader.ReadInt32();
						spmFileDataCount.iDX = binaryReader.ReadInt32();
						spmFileDataCount.iDY = binaryReader.ReadInt32();
						binaryReader.ReadChars(16);
						spmArr.Add(spmFileDataCount);
						int num4 = 0;
						int num5 = spmFileDataCount.iThisCount - 1;
						for (int j = num4; j <= num5; j++)
						{
							asmodean_fun.spmFileDataFace spmFileDataFace = default(asmodean_fun.spmFileDataFace);
							spmFileDataFace.iIndex = binaryReader.ReadInt32();
							spmFileDataFace.iX = binaryReader.ReadInt32();
							spmFileDataFace.iY = binaryReader.ReadInt32();
							spmFileDataFace.iDX = binaryReader.ReadInt32();
							spmFileDataFace.iDY = binaryReader.ReadInt32();
							spmFileDataFace.iSX = binaryReader.ReadInt32();
							spmFileDataFace.iSY = binaryReader.ReadInt32();
							spmFileDataFace.iStarX = binaryReader.ReadInt32();
							spmFileDataFace.iStarY = binaryReader.ReadInt32();
							spmFileDataFace.iEndW = binaryReader.ReadInt32();
							spmFileDataFace.iEndH = binaryReader.ReadInt32();
							binaryReader.ReadChars(12);
							spmArr.Add(spmFileDataFace);
						}
					}
					num = binaryReader.ReadInt32();
					StringBuilder stringBuilder2 = new StringBuilder();
					string text = string.Empty;
					int num6 = 0;
					int num7 = num - 1;
					for (int k = num6; k <= num7; k++)
					{
						text = Conversions.ToString(binaryReader.ReadChar());
						while (Operators.CompareString(text, "\0", false) != 0)
						{
							stringBuilder2.Append(text);
							text = Conversions.ToString(binaryReader.ReadChar());
						}
						fileArr.Add(stringBuilder2.ToString());
						stringBuilder2 = new StringBuilder();
					}
					binaryReader.Dispose();
				}
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000281E4 File Offset: 0x000263E4
		public static bool unobfuscate(ref byte[] buff, long len, string customkey = "")
		{
			string[] array = new string[]
			{
				"VISHNU",
				"NANAMI",
				"artemina_daisuki",
				"SHIINAMACHI",
				"SAYAKA",
				"TUKIMI",
				"dltmes",
				"IORI",
				customkey
			};
			checked
			{
				foreach (string text in array)
				{
					int length = text.Length;
					if (0 < length)
					{
						int num = 0;
						int num2 = (int)(len - 1L);
						for (int j = num; j <= num2; j++)
						{
							int num3 = (int)Convert.ToByte(text[(j + 16) % length]);
							int num4 = (int)asmodean_fun.a((int)buff[j] + num3);
							if (0 == j)
							{
								num3 = (int)Convert.ToByte(text[(j + 1 + 16) % length]);
								int num5 = (int)asmodean_fun.a((int)buff[j + 1] + num3);
								num3 = (int)Convert.ToByte(text[(j + 2 + 16) % length]);
								int value = (int)asmodean_fun.a((int)buff[j + 2] + num3);
								num3 = (int)Convert.ToByte(text[(int)((len - 1L + 16L) % unchecked((long)length))]);
								int num6 = (int)asmodean_fun.a((int)buff[(int)(len - 1L)] + num3);
								if (num4 != 0 | num5 != 35 | !char.IsUpper(Convert.ToChar(value)) | num6 != 0)
								{
									break;
								}
							}
							buff[j] = (byte)num4;
						}
					}
				}
				return buff[0] == 0;
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00028380 File Offset: 0x00026580
		public static bool unobfuscate2(ref byte[] buff, long len, string customkey = "")
		{
			string[] array = new string[]
			{
				customkey
			};
			checked
			{
				foreach (string text in array)
				{
					int length = text.Length;
					if (0 < length)
					{
						int num = 0;
						int num2 = (int)(len - 1L);
						for (int j = num; j <= num2; j++)
						{
							int num3 = (int)Convert.ToByte(text[(j + 16) % length]);
							buff[j] = asmodean_fun.a((int)buff[j] + num3);
						}
					}
				}
				return buff[0] == 0;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0002840C File Offset: 0x0002660C
		private static byte a(int A_0)
		{
			checked
			{
				if (A_0 >= 256)
				{
					return (byte)(A_0 - 256);
				}
				return (byte)A_0;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0002842C File Offset: 0x0002662C
		public static string getunobfuscatekeyfromexe(ref string spath, int iMode = 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			FileInfo fileInfo = new FileInfo(spath);
			FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
			MemoryStream memoryStream = new MemoryStream();
			fileStream.CopyTo(memoryStream);
			fileStream.Dispose();
			long position = memoryStream.Position;
			memoryStream.Position = 0L;
			StreamReader streamReader = new StreamReader(memoryStream);
			string text = streamReader.ReadToEnd();
			streamReader.Dispose();
			long num = (long)Strings.InStr(1, text, "md_apnd%d.med", CompareMethod.Binary);
			checked
			{
				if (num > 0L)
				{
					string strA = string.Concat(new string[]
					{
						Conversions.ToString(text[(int)(num - 8L)]),
						Conversions.ToString(text[(int)(num - 7L)]),
						Conversions.ToString(text[(int)(num - 6L)]),
						Conversions.ToString(text[(int)(num - 5L)]),
						Conversions.ToString(text[(int)(num - 4L)])
					});
					while (num > 0L)
					{
						if (0 == string.Compare(strA, "M%02d", StringComparison.OrdinalIgnoreCase))
						{
							if (iMode == 1)
							{
								num -= 4L;
								break;
							}
							break;
						}
						else
						{
							strA = string.Concat(new string[]
							{
								Conversions.ToString(text[(int)(num - 8L)]),
								Conversions.ToString(text[(int)(num - 7L)]),
								Conversions.ToString(text[(int)(num - 6L)]),
								Conversions.ToString(text[(int)(num - 5L)]),
								Conversions.ToString(text[(int)(num - 4L)])
							});
							num -= 1L;
						}
					}
					if (0 == string.Compare(strA, "M%02d", StringComparison.OrdinalIgnoreCase))
					{
						int i = (int)(num - 10L);
						if (iMode == 1)
						{
							i = (int)(num - 5L);
						}
						while (i > 0)
						{
							char c = text[i];
							if (c == '\0')
							{
								break;
							}
							stringBuilder.Insert(0, text[i]);
							i--;
						}
					}
				}
				memoryStream.Dispose();
				return stringBuilder.ToString();
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00028630 File Offset: 0x00026830
		public static bool readLsfToArrayList(ref ArrayList arr, string lsf)
		{
			bool result = false;
			checked
			{
				using (FileStream fileStream = new FileStream(lsf, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					string strA = new string(binaryReader.ReadChars(3));
					if (0 == string.Compare(strA, "LSF", StringComparison.Ordinal))
					{
						result = true;
						binaryReader.ReadChar();
						string[] array = new string[]
						{
							Conversions.ToString(binaryReader.ReadInt32()),
							Conversions.ToString((int)binaryReader.ReadInt16()),
							Conversions.ToString((int)binaryReader.ReadInt16()),
							Conversions.ToString(binaryReader.ReadInt32()),
							Conversions.ToString(binaryReader.ReadInt32()),
							Conversions.ToString(binaryReader.ReadInt32()),
							Conversions.ToString(binaryReader.ReadInt32())
						};
						arr.Add(array);
						int num = 1;
						int num2 = Conversions.ToInteger(array[2]);
						for (int i = num; i <= num2; i++)
						{
							string[] value = new string[]
							{
								x.o.GetString(binaryReader.ReadBytes(64)).TrimEnd(new char[]
								{
									'\0'
								}),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadInt32()),
								Conversions.ToString(binaryReader.ReadByte()),
								Conversions.ToString(binaryReader.ReadByte()),
								Conversions.ToString((int)binaryReader.ReadInt16())
							};
							arr.Add(value);
						}
					}
				}
				return result;
			}
		}

		// Token: 0x020000C5 RID: 197
		public struct spmFileDataCount
		{
			// Token: 0x040002DD RID: 733
			public int iThisCount;

			// Token: 0x040002DE RID: 734
			public int iWidth;

			// Token: 0x040002DF RID: 735
			public int iHeight;

			// Token: 0x040002E0 RID: 736
			public int iX;

			// Token: 0x040002E1 RID: 737
			public int iY;

			// Token: 0x040002E2 RID: 738
			public int iDX;

			// Token: 0x040002E3 RID: 739
			public int iDY;
		}

		// Token: 0x020000C6 RID: 198
		public struct spmFileDataFace
		{
			// Token: 0x040002E4 RID: 740
			public int iIndex;

			// Token: 0x040002E5 RID: 741
			public int iX;

			// Token: 0x040002E6 RID: 742
			public int iY;

			// Token: 0x040002E7 RID: 743
			public int iDX;

			// Token: 0x040002E8 RID: 744
			public int iDY;

			// Token: 0x040002E9 RID: 745
			public int iSX;

			// Token: 0x040002EA RID: 746
			public int iSY;

			// Token: 0x040002EB RID: 747
			public int iStarX;

			// Token: 0x040002EC RID: 748
			public int iStarY;

			// Token: 0x040002ED RID: 749
			public int iEndW;

			// Token: 0x040002EE RID: 750
			public int iEndH;
		}
	}
}
