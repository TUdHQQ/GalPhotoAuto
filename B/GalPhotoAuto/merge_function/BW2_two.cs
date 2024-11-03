using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.merge_function
{
	// Token: 0x02000095 RID: 149
	public class BW2_two
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00021CAC File Offset: 0x0001FEAC
		public static bool RioShiina_ZeaS_mode1(ref Form1 myForm1, bool bNegativeX = false, bool bNegativeY = false)
		{
			BW2_two._Closure$__138 CS$<>8__locals1 = new BW2_two._Closure$__138(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_bNegativeX = bNegativeX;
			CS$<>8__locals1.$VB$Local_bNegativeY = bNegativeY;
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
				CS$<>8__locals1.$VB$Local_strSn1 = string.Empty;
				CS$<>8__locals1.$VB$Local_baseX = 0;
				CS$<>8__locals1.$VB$Local_baseY = 0;
				ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
				CS$<>8__locals1.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
				string[] array3 = array;
				for (int i = 0; i < array3.Length; i++)
				{
					BW2_two._Closure$__138._Closure$__139 CS$<>8__locals2 = new BW2_two._Closure$__138._Closure$__139(CS$<>8__locals2);
					string text = array3[i];
					CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A = CS$<>8__locals1;
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
					string[] rioShiinaZeaSFileData = BW2_two.getRioShiinaZeaSFileData(text);
					if (rioShiinaZeaSFileData != null)
					{
						CS$<>8__locals1.$VB$Local_strMaster = rioShiinaZeaSFileData[0];
						CS$<>8__locals1.$VB$Local_strSn1 = rioShiinaZeaSFileData[1];
						CS$<>8__locals1.$VB$Local_baseX = Conversions.ToInteger(rioShiinaZeaSFileData[2]);
						CS$<>8__locals1.$VB$Local_baseY = Conversions.ToInteger(rioShiinaZeaSFileData[3]);
						if (!(0 == CS$<>8__locals1.$VB$Local_baseX & 0 == CS$<>8__locals1.$VB$Local_baseY))
						{
							CS$<>8__locals2.$VB$Local_stream = new MemoryStream();
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(text))
							{
								CS$<>8__locals2.$VB$Local_iWidth = bitMapFromFile.Width;
								CS$<>8__locals2.$VB$Local_iHeight = bitMapFromFile.Height;
								CS$<>8__locals2.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
								bitMapFromFile.Save(CS$<>8__locals2.$VB$Local_stream, ImageFormat.Png);
							}
							Parallel.ForEach<string>(array2, parallelOptions, delegate(string avatar, ParallelLoopState loopstate)
							{
								Interlocked.Add(ref PublicModule.iNow, 1);
								if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
								}
								string text2 = string.Empty;
								string[] rioShiinaZeaSFileData2 = BW2_two.getRioShiinaZeaSFileData(avatar);
								if (rioShiinaZeaSFileData2 != null)
								{
									text2 = rioShiinaZeaSFileData2[1];
									int num = Conversions.ToInteger(rioShiinaZeaSFileData2[2]);
									int num2 = Conversions.ToInteger(rioShiinaZeaSFileData2[3]);
									Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(avatar);
									int num3 = Math.Abs(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseX - num);
									int num4 = Math.Abs(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseY - num2);
									int width = CS$<>8__locals2.$VB$Local_iWidth;
									int height = CS$<>8__locals2.$VB$Local_iHeight;
									int x = num3;
									int y = num4;
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeX)
									{
										width = CS$<>8__locals2.$VB$Local_iWidth + num3;
										x = 0;
									}
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeY)
									{
										if (bitMapFromFile2.Width + num3 > CS$<>8__locals2.$VB$Local_iWidth)
										{
											width = bitMapFromFile2.Width + num3;
										}
										height = CS$<>8__locals2.$VB$Local_iHeight + num4;
										y = 0;
									}
									Bitmap bitmap = new Bitmap(width, height, CS$<>8__locals2.$VB$Local_pFormat);
									Graphics graphics = Graphics.FromImage(bitmap);
									graphics.Clear(Color.Transparent);
									MemoryStream $VB$Local_stream = CS$<>8__locals2.$VB$Local_stream;
									lock ($VB$Local_stream)
									{
										if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeY)
										{
											graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_stream), 0, num4, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
										}
										else if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeX)
										{
											graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_stream), num3, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
										}
										else
										{
											graphics.DrawImage(Image.FromStream(CS$<>8__locals2.$VB$Local_stream), 0, 0, CS$<>8__locals2.$VB$Local_iWidth, CS$<>8__locals2.$VB$Local_iHeight);
										}
									}
									graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
									graphics.Dispose();
									string directoryName = Path.GetDirectoryName(avatar);
									string text3 = string.Concat(new string[]
									{
										Path.Combine(directoryName, CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_strMaster),
										"@",
										CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_strSn1,
										text2,
										"pos_"
									});
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeX)
									{
										text3 += Conversions.ToString(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseX - num3);
									}
									else
									{
										text3 += Conversions.ToString(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseX);
									}
									text3 += "_";
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bNegativeY)
									{
										text3 += Conversions.ToString(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseY - num4);
									}
									else
									{
										text3 += Conversions.ToString(CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_baseY);
									}
									PublicModule.saveBitmapFile(text3, ref bitmap, true);
									Interlocked.Add(ref PublicModule.iBuild, 1);
									bitmap.Dispose();
									bitMapFromFile2.Dispose();
									if (CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_bRDisposable)
									{
										ArrayList files2 = PublicModule.files2;
										lock (files2)
										{
											PublicModule.files2.Add(avatar);
										}
									}
									CS$<>8__locals2.$VB$NonLocal_$VB$Closure_ClosureVariable_8A.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
								}
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
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00021F38 File Offset: 0x00020138
		public static bool RioShiina_ZeaS_mode2(ref Form1 myForm1, int iMode)
		{
			bool result = false;
			PublicModule.iCount = PublicModule.files1.Count;
			PublicModule.iMaxToBW = PublicModule.iCount;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			int iLong;
			switch (iMode)
			{
			case 203:
				iLong = 200;
				break;
			case 204:
				iLong = 500;
				break;
			default:
				return false;
			}
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			BackgroundWorker backgroundWorker = myForm1.BackgroundWorker2;
			foreach (string text in array)
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
				if (!PublicModule.canFindSameInArrayList(ref PublicModule.files2, text))
				{
					if (BW2_two.RioShiina_ZeaS_mode2sub1(ref myForm1, text, iLong))
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0002201C File Offset: 0x0002021C
		private static bool RioShiina_ZeaS_mode2sub1(ref Form1 myForm1, string thispath, int iLong)
		{
			bool result = false;
			string[] rioShiinaZeaSFileData = BW2_two.getRioShiinaZeaSFileData(thispath);
			if (rioShiinaZeaSFileData == null)
			{
				return false;
			}
			string strMaster = rioShiinaZeaSFileData[0];
			string text = rioShiinaZeaSFileData[1];
			int num = Conversions.ToInteger(rioShiinaZeaSFileData[2]);
			int num2 = Conversions.ToInteger(rioShiinaZeaSFileData[3]);
			if (0 == num & 0 == num2)
			{
				return false;
			}
			ArrayList masterArr = new ArrayList(100);
			ArrayList tempArr = new ArrayList(100);
			string[] array = new string[checked(PublicModule.iCount - 1 + 1)];
			PublicModule.files1.CopyTo(array, 0);
			Parallel.ForEach<string>(array, delegate(string sameFile)
			{
				string[] rioShiinaZeaSFileData2 = BW2_two.getRioShiinaZeaSFileData(sameFile);
				string text2 = rioShiinaZeaSFileData2[0];
				if (Operators.CompareString(strMaster, text2, false) == 0)
				{
					text2 = rioShiinaZeaSFileData2[1];
					int snLast = BW2_two.getSnLast(text2);
					if (snLast < 100)
					{
						ArrayList $VB$Local_masterArr = masterArr;
						lock ($VB$Local_masterArr)
						{
							masterArr.Add(sameFile);
							goto IL_8B;
						}
					}
					ArrayList $VB$Local_tempArr = tempArr;
					lock ($VB$Local_tempArr)
					{
						tempArr.Add(sameFile);
					}
					IL_8B:
					if (snLast < iLong)
					{
						ArrayList files = PublicModule.files2;
						lock (files)
						{
							PublicModule.files2.Add(sameFile);
						}
					}
				}
			});
			if (0 >= tempArr.Count)
			{
				return false;
			}
			if (BW2_two.RioShiina_ZeaS_mode2sub2(ref myForm1, masterArr, tempArr, iLong, true))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000220F8 File Offset: 0x000202F8
		private static bool RioShiina_ZeaS_mode2sub2(ref Form1 myForm1, ArrayList arr1, ArrayList arr2, int iLong, bool bCheck = true)
		{
			BW2_two._Closure$__141 CS$<>8__locals1 = new BW2_two._Closure$__141(CS$<>8__locals1);
			CS$<>8__locals1.$VB$Local_iLong = iLong;
			CS$<>8__locals1.$VB$Local_bCheck = bCheck;
			CS$<>8__locals1.$VB$Local_eCancel = false;
			if (0 >= arr1.Count | 0 >= arr2.Count)
			{
				return false;
			}
			checked
			{
				if (0 < arr1.Count & 0 < arr2.Count)
				{
					BW2_two._Closure$__141._Closure$__142 CS$<>8__locals2 = new BW2_two._Closure$__141._Closure$__142(CS$<>8__locals2);
					string[] array = new string[arr1.Count - 1 + 1];
					arr1.CopyTo(array, 0);
					string[] array2 = new string[arr2.Count - 1 + 1];
					arr2.CopyTo(array2, 0);
					CS$<>8__locals2.$VB$Local_baseX = 0;
					CS$<>8__locals2.$VB$Local_baseY = 0;
					CS$<>8__locals2.$VB$Local_iMin = 0;
					CS$<>8__locals2.$VB$Local_masterArr = new ArrayList(100);
					CS$<>8__locals2.$VB$Local_tempArr = new ArrayList(100);
					ParallelOptions parallelOptions = PublicModule.PublicParallelOptions();
					CS$<>8__locals2.$VB$Local_BackgroundWorker2 = myForm1.BackgroundWorker2;
					string[] array3 = array;
					for (int i = 0; i < array3.Length; i++)
					{
						BW2_two._Closure$__141._Closure$__142._Closure$__143 CS$<>8__locals3 = new BW2_two._Closure$__141._Closure$__142._Closure$__143(CS$<>8__locals3);
						string sPath = array3[i];
						CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_8E = CS$<>8__locals2;
						CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_8D = CS$<>8__locals1;
						Interlocked.Add(ref PublicModule.iNow, 1);
						if (CS$<>8__locals2.$VB$Local_BackgroundWorker2.CancellationPending)
						{
							return true;
						}
						while (PublicModule.bWaitCancelAsync)
						{
							Thread.Sleep(500);
							if (CS$<>8__locals2.$VB$Local_BackgroundWorker2.CancellationPending)
							{
								return true;
							}
						}
						string[] rioShiinaZeaSFileData = BW2_two.getRioShiinaZeaSFileData(sPath);
						if (rioShiinaZeaSFileData != null)
						{
							CS$<>8__locals2.$VB$Local_strMaster = rioShiinaZeaSFileData[0];
							CS$<>8__locals2.$VB$Local_strSn1 = rioShiinaZeaSFileData[1];
							CS$<>8__locals2.$VB$Local_baseX = Conversions.ToInteger(rioShiinaZeaSFileData[2]);
							CS$<>8__locals2.$VB$Local_baseY = Conversions.ToInteger(rioShiinaZeaSFileData[3]);
							CS$<>8__locals2.$VB$Local_iMin = (BW2_two.getSnLast(CS$<>8__locals2.$VB$Local_strSn1) / 100 + 1) * 100 + 99;
							CS$<>8__locals3.$VB$Local_stream = new MemoryStream();
							using (Bitmap bitMapFromFile = PublicModule.getBitMapFromFile(sPath))
							{
								CS$<>8__locals3.$VB$Local_iWidth = bitMapFromFile.Width;
								CS$<>8__locals3.$VB$Local_iHeight = bitMapFromFile.Height;
								CS$<>8__locals3.$VB$Local_pFormat = bitMapFromFile.PixelFormat;
								bitMapFromFile.Save(CS$<>8__locals3.$VB$Local_stream, ImageFormat.Png);
							}
							Parallel.ForEach<string>(array2, parallelOptions, delegate(string avatar, ParallelLoopState loopstate)
							{
								BW2_two._Closure$__141._Closure$__142._Closure$__143._Closure$__144 CS$<>8__locals4 = new BW2_two._Closure$__141._Closure$__142._Closure$__143._Closure$__144(CS$<>8__locals4);
								CS$<>8__locals4.$VB$Local_avatar = avatar;
								CS$<>8__locals4.$VB$NonLocal__Closure$__143 = CS$<>8__locals3;
								Interlocked.Add(ref PublicModule.iNow, 1);
								if (CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_BackgroundWorker2.CancellationPending)
								{
									CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8D.$VB$Local_eCancel = true;
									loopstate.Stop();
								}
								while (PublicModule.bWaitCancelAsync)
								{
									Thread.Sleep(500);
									if (CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_BackgroundWorker2.CancellationPending)
									{
										CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8D.$VB$Local_eCancel = true;
										loopstate.Stop();
									}
								}
								string text = string.Empty;
								string[] rioShiinaZeaSFileData2 = BW2_two.getRioShiinaZeaSFileData(CS$<>8__locals4.$VB$Local_avatar);
								if (rioShiinaZeaSFileData2 != null)
								{
									text = rioShiinaZeaSFileData2[1];
									int num = Conversions.ToInteger(rioShiinaZeaSFileData2[2]);
									int num2 = Conversions.ToInteger(rioShiinaZeaSFileData2[3]);
									int num3 = BW2_two.getSnLast(text) / 100 * 100;
									if (num3 < CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8D.$VB$Local_iLong)
									{
										if (CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8D.$VB$Local_bCheck && (num3 >= CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_iMin & num3 < CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8D.$VB$Local_iLong))
										{
											ArrayList $VB$Local_tempArr = CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_tempArr;
											bool flag = false;
											try
											{
												BW2_two._Closure$__141._Closure$__142._Closure$__143._Closure$__144._Closure$__145 CS$<>8__locals5 = new BW2_two._Closure$__141._Closure$__142._Closure$__143._Closure$__144._Closure$__145(CS$<>8__locals5);
												CS$<>8__locals5.$VB$NonLocal__Closure$__143 = CS$<>8__locals3;
												CS$<>8__locals5.$VB$NonLocal_$VB$Closure_ClosureVariable_90 = CS$<>8__locals4;
												Monitor.Enter($VB$Local_tempArr, ref flag);
												CS$<>8__locals5.$VB$Local_bHave = false;
												string[] array4 = new string[CS$<>8__locals5.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_tempArr.Count - 1 + 1];
												CS$<>8__locals5.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_tempArr.CopyTo(array4, 0);
												Parallel.ForEach<string>(array4, delegate(string thisfile, ParallelLoopState loopstate1)
												{
													if (0 == string.Compare(CS$<>8__locals5.$VB$NonLocal_$VB$Closure_ClosureVariable_90.$VB$Local_avatar, thisfile, StringComparison.Ordinal))
													{
														CS$<>8__locals5.$VB$Local_bHave = true;
														loopstate1.Stop();
													}
												});
												if (!CS$<>8__locals5.$VB$Local_bHave)
												{
													CS$<>8__locals5.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_tempArr.Add(CS$<>8__locals4.$VB$Local_avatar);
												}
												goto IL_474;
											}
											finally
											{
												if (flag)
												{
													Monitor.Exit($VB$Local_tempArr);
												}
											}
										}
										string directoryName = Path.GetDirectoryName(CS$<>8__locals4.$VB$Local_avatar);
										string text2 = string.Concat(new string[]
										{
											Path.Combine(directoryName, CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_strMaster),
											"@",
											CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_strSn1,
											text,
											"pos_",
											Conversions.ToString(CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_baseX),
											"_",
											Conversions.ToString(CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_baseY)
										});
										string text3;
										if (1 == PublicModule.i2SaveBitmapFormat)
										{
											text3 = text2 + ".bmp";
										}
										else if (2 == PublicModule.i2SaveBitmapFormat)
										{
											text3 = text2 + ".jpg";
										}
										else
										{
											text3 = text2 + ".png";
										}
										if (!File.Exists(text3))
										{
											Bitmap bitMapFromFile2 = PublicModule.getBitMapFromFile(CS$<>8__locals4.$VB$Local_avatar);
											int x = Math.Abs(CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_baseX - num);
											int y = Math.Abs(CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_baseY - num2);
											Bitmap bitmap = new Bitmap(CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight, CS$<>8__locals3.$VB$Local_pFormat);
											Graphics graphics = Graphics.FromImage(bitmap);
											graphics.Clear(Color.Transparent);
											MemoryStream $VB$Local_stream = CS$<>8__locals3.$VB$Local_stream;
											lock ($VB$Local_stream)
											{
												graphics.DrawImage(Image.FromStream(CS$<>8__locals3.$VB$Local_stream), 0, 0, CS$<>8__locals3.$VB$Local_iWidth, CS$<>8__locals3.$VB$Local_iHeight);
											}
											graphics.DrawImage(bitMapFromFile2, x, y, bitMapFromFile2.Width, bitMapFromFile2.Height);
											graphics.Dispose();
											PublicModule.saveBitmapFile(text2, ref bitmap, true);
											Interlocked.Add(ref PublicModule.iBuild, 1);
											ArrayList $VB$Local_masterArr = CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_masterArr;
											lock ($VB$Local_masterArr)
											{
												CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_masterArr.Add(text3);
											}
											bitmap.Dispose();
											bitMapFromFile2.Dispose();
											ArrayList files = PublicModule.files2;
											lock (files)
											{
												PublicModule.files2.Add(CS$<>8__locals4.$VB$Local_avatar);
											}
											CS$<>8__locals4.$VB$NonLocal__Closure$__143.$VB$NonLocal_$VB$Closure_ClosureVariable_8E.$VB$Local_BackgroundWorker2.ReportProgress(PublicModule.iNow);
										}
									}
								}
								IL_474:
								Thread.Sleep(PublicModule.iThreadWaitTime);
							});
							CS$<>8__locals3.$VB$Local_stream.Dispose();
						}
					}
					if (CS$<>8__locals1.$VB$Local_eCancel)
					{
						return true;
					}
					if (BW2_two.RioShiina_ZeaS_mode2sub2(ref myForm1, CS$<>8__locals2.$VB$Local_masterArr, CS$<>8__locals2.$VB$Local_tempArr, CS$<>8__locals1.$VB$Local_iLong, false))
					{
						CS$<>8__locals1.$VB$Local_eCancel = true;
					}
				}
				return CS$<>8__locals1.$VB$Local_eCancel;
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00022374 File Offset: 0x00020574
		private static string[] getRioShiinaZeaSFileData(string sPath)
		{
			string text = Path.GetFileNameWithoutExtension(sPath);
			string[] array;
			if (Strings.InStr(1, text, ".", CompareMethod.Binary) > 0)
			{
				array = PublicModule.regDOT.Split(text);
				text = array[0];
			}
			array = PublicModule.regAT.Split(text);
			if (array.Length != 2)
			{
				return null;
			}
			string text2 = array[0];
			string input = array[1];
			array = PublicModule.regPOS.Split(input);
			string text3 = array[0];
			input = array[1];
			array = PublicModule.regXIA.Split(input);
			int value = Conversions.ToInteger(array[1]);
			int value2 = Conversions.ToInteger(array[2]);
			return new string[]
			{
				text2,
				text3,
				Conversions.ToString(value),
				Conversions.ToString(value2)
			};
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00022438 File Offset: 0x00020638
		private static int getSnLast(string sn)
		{
			string[] array = PublicModule.regXIA.Split(sn);
			string value = array[checked(array.Length - 2)];
			return Conversions.ToInteger(value);
		}
	}
}
