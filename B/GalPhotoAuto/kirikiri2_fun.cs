using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GalPhotoAuto.merge_function;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000CB RID: 203
	public class kirikiri2_fun
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00034950 File Offset: 0x00032B50
		public static kirikiri2_fun.kirikiri2DefTxt getLayerArr(string str, ref ArrayList defineTxt, bool bFollowUp = false, ref ArrayList tempArrlist = null)
		{
			kirikiri2_fun._Closure$__135 CS$<>8__locals1 = new kirikiri2_fun._Closure$__135();
			CS$<>8__locals1.$VB$Local_strTemp = str;
			CS$<>8__locals1.$VB$Local_tempArr = default(kirikiri2_fun.kirikiri2DefTxt);
			if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_strTemp, "$", CompareMethod.Binary) > 0)
			{
				string[] array = CS$<>8__locals1.$VB$Local_strTemp.Split(new char[]
				{
					'$'
				});
				CS$<>8__locals1.$VB$Local_strTemp = array[0];
			}
			checked
			{
				if (Strings.InStr(1, CS$<>8__locals1.$VB$Local_strTemp, "/", CompareMethod.Binary) > 0)
				{
					kirikiri2_fun._Closure$__135._Closure$__136 CS$<>8__locals2 = new kirikiri2_fun._Closure$__135._Closure$__136();
					string[] array2 = CS$<>8__locals1.$VB$Local_strTemp.Split(new char[]
					{
						'/'
					});
					CS$<>8__locals2.$VB$Local_group_layer_id = 0;
					CS$<>8__locals2.$VB$Local_bAddDone = false;
					string[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						kirikiri2_fun._Closure$__135._Closure$__136._Closure$__137 CS$<>8__locals3 = new kirikiri2_fun._Closure$__135._Closure$__136._Closure$__137(CS$<>8__locals3);
						CS$<>8__locals3.$VB$Local_s = array3[i];
						CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88 = CS$<>8__locals2;
						CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_87 = CS$<>8__locals1;
						Parallel.ForEach<object>(defineTxt.ToArray(), delegate(object a0, ParallelLoopState a1)
						{
							kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt3;
							delegate(kirikiri2_fun.kirikiri2DefTxt dft, ParallelLoopState loopstate)
							{
								if (0 == string.Compare(dft.name, CS$<>8__locals3.$VB$Local_s, StringComparison.Ordinal) & 0 == CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id)
								{
									if (Operators.CompareString(dft.layer_type, "2", false) == 0)
									{
										loopstate.Break();
										if (string.IsNullOrWhiteSpace(dft.group_layer_id))
										{
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id = Conversions.ToInteger(dft.layer_id);
										}
										else
										{
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id = 0;
										}
									}
								}
								else if (0 == string.Compare(dft.name, CS$<>8__locals3.$VB$Local_s, StringComparison.Ordinal) & 0 < CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id)
								{
									if (string.IsNullOrWhiteSpace(dft.group_layer_id))
									{
										return;
									}
									if (CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id == Conversions.ToInteger(dft.group_layer_id))
									{
										loopstate.Break();
										if (Operators.CompareString(dft.layer_type, "2", false) == 0)
										{
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_group_layer_id = Conversions.ToInteger(dft.layer_id);
										}
										else if (Operators.CompareString(dft.layer_type, "0", false) == 0)
										{
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_87.$VB$Local_tempArr = dft;
											CS$<>8__locals3.$VB$NonLocal_$VB$Closure_ClosureVariable_88.$VB$Local_bAddDone = true;
										}
									}
								}
							}((a0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)a0) : kirikiri2DefTxt3, a1);
						});
					}
					if (!CS$<>8__locals2.$VB$Local_bAddDone)
					{
						if (bFollowUp && string.IsNullOrEmpty(CS$<>8__locals1.$VB$Local_tempArr.layer_type))
						{
							try
							{
								foreach (object obj in defineTxt)
								{
									kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt2;
									kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt = (obj != null) ? ((kirikiri2_fun.kirikiri2DefTxt)obj) : kirikiri2DefTxt2;
									if (!string.IsNullOrWhiteSpace(kirikiri2DefTxt.group_layer_id))
									{
										if (CS$<>8__locals2.$VB$Local_group_layer_id == Conversions.ToInteger(kirikiri2DefTxt.group_layer_id))
										{
											tempArrlist.Add(kirikiri2DefTxt);
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
						}
					}
				}
				else
				{
					Parallel.ForEach<object>(defineTxt.ToArray(), delegate(object a0, ParallelLoopState a1)
					{
						kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt3;
						delegate(kirikiri2_fun.kirikiri2DefTxt dft, ParallelLoopState loopstate)
						{
							if (0 == string.Compare(dft.name, CS$<>8__locals1.$VB$Local_strTemp, StringComparison.Ordinal) & Operators.CompareString(dft.layer_type, "0", false) == 0)
							{
								loopstate.Break();
								CS$<>8__locals1.$VB$Local_tempArr = dft;
							}
						}((a0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)a0) : kirikiri2DefTxt3, a1);
					});
				}
				return CS$<>8__locals1.$VB$Local_tempArr;
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00034B20 File Offset: 0x00032D20
		public static void readBaseInfoToArr(string base_info_path, ref ArrayList baseinfotxt)
		{
			using (FileStream fileStream = new FileStream(base_info_path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					while (!streamReader.EndOfStream)
					{
						string input = streamReader.ReadLine();
						string[] array = PublicModule.regBigSpace.Split(input);
						if (!(Strings.InStr(1, array[0], "#", CompareMethod.Binary) > 0 | string.IsNullOrEmpty(array[0])))
						{
							baseinfotxt.Add(array);
						}
					}
				}
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00034BBC File Offset: 0x00032DBC
		public static bool readTxtToArr(string txtF, ref ArrayList defineTxt, ref int iW, ref int iH)
		{
			bool result = false;
			using (FileStream fileStream = new FileStream(txtF, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					while (!streamReader.EndOfStream)
					{
						string input = streamReader.ReadLine();
						string[] array = PublicModule.regBigSpace.Split(input);
						if (2 <= array.Count<string>() && Strings.InStr(1, array[0], "#", CompareMethod.Binary) <= 0)
						{
							if (string.IsNullOrEmpty(array[0]))
							{
								if (!(string.IsNullOrEmpty(array[4]) | string.IsNullOrEmpty(array[5])))
								{
									iW = Conversions.ToInteger(array[4]);
									iH = Conversions.ToInteger(array[5]);
								}
							}
							else
							{
								kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt = default(kirikiri2_fun.kirikiri2DefTxt);
								Array array2 = array;
								kirikiri2DefTxt.fromArray(ref array2);
								array = (string[])array2;
								defineTxt.Add(kirikiri2DefTxt);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00034CC8 File Offset: 0x00032EC8
		public static string[] readAnmToArr(string sPath)
		{
			string[] array = new string[5];
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
					{
						StringBuilder stringBuilder = new StringBuilder();
						while (!streamReader.EndOfStream)
						{
							string value = streamReader.ReadLine();
							stringBuilder.Append(value);
						}
						string text = stringBuilder.ToString();
						text = text.Replace("[", string.Empty).Replace("]", string.Empty);
						string[] array2 = text.Split(new char[]
						{
							','
						});
						int num = 0;
						array = new string[array2.Count<string>() - 1 + 1];
						foreach (string input in array2)
						{
							string[] source = PublicModule.regSmallSpace.Split(input);
							text = source.Last<string>();
							if (Strings.InStr(1, text, "//", CompareMethod.Binary) > 0)
							{
								source = text.Split(new char[]
								{
									'/'
								});
								text = source.Last<string>();
							}
							array[num] = text.Replace("\"", string.Empty);
							num++;
						}
					}
				}
				return array;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00034E3C File Offset: 0x0003303C
		public static ArrayList readAsdToArr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine();
						if (Strings.InStr(1, text, "@clip left", CompareMethod.Binary) > 0 | string.IsNullOrWhiteSpace(text))
						{
							string[] source = PublicModule.regEqual.Split(text);
							string text2 = source.Last<string>();
							if (Versioned.IsNumeric(text2) && !PublicModule.canFindSameInArrayList(ref arrayList, text2))
							{
								arrayList.Add(text2);
							}
						}
					}
				}
			}
			return arrayList;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00034EFC File Offset: 0x000330FC
		public static ArrayList readCgmToArr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
					{
						string baseName = string.Empty;
						while (!streamReader.EndOfStream)
						{
							string text = streamReader.ReadLine().Trim();
							if (0 == string.Compare(text, "/*", StringComparison.Ordinal))
							{
								flag = true;
							}
							else if (0 == string.Compare(text, "*/", StringComparison.Ordinal))
							{
								flag = false;
								continue;
							}
							if (!flag)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (0 == string.Compare(text, "%[", StringComparison.Ordinal))
									{
										flag2 = true;
										kirikiri2_fun.CgmData cgmData = default(kirikiri2_fun.CgmData);
										arrayList = new ArrayList();
									}
									else if ((flag2 & !flag3) && 0 == string.Compare(text, "],", StringComparison.Ordinal))
									{
										flag2 = false;
										kirikiri2_fun.CgmData cgmData;
										cgmData.baseName = baseName;
										cgmData.faceList = arrayList;
										arrayList2.Add(cgmData);
									}
									if (flag2)
									{
										if (Strings.InStr(1, text, "id :", CompareMethod.Binary) > 0)
										{
											string str = text.Split(new char[]
											{
												','
											}).First<string>();
											baseName = kirikiri2_fun.SplitCgm(str);
										}
										if (Strings.InStr(1, text, "cg :", CompareMethod.Binary) > 0)
										{
											flag3 = true;
										}
										else if (flag3 && 0 == string.Compare(text, "],", StringComparison.Ordinal))
										{
											flag3 = false;
										}
										else if (flag3)
										{
											string[] array = text.Split(new char[]
											{
												','
											});
											int num = array.Count<string>();
											if (string.IsNullOrWhiteSpace(array.Last<string>()))
											{
												num--;
											}
											if (num < 0)
											{
												num = 0;
											}
											string[] array2 = new string[num - 1 + 1];
											int num2 = 0;
											int num3 = num - 1;
											for (int i = num2; i <= num3; i++)
											{
												string str = array[i];
												array2[i] = kirikiri2_fun.SplitCgm(str);
											}
											arrayList.Add(array2);
										}
									}
								}
							}
						}
					}
				}
				return arrayList2;
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0003513C File Offset: 0x0003333C
		private static string SplitCgm(string str)
		{
			string[] array = str.Split(new char[]
			{
				':'
			});
			string text = array.Last<string>();
			array = text.Split(new char[]
			{
				'"'
			});
			if (1 < array.Count<string>())
			{
				text = array[1];
			}
			else
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00035190 File Offset: 0x00033390
		private static bool findCgmNameInAsd(string sSouceName, string sFindName)
		{
			string[] array = new string[]
			{
				"目",
				"口"
			};
			foreach (string str in array)
			{
				if (0 == string.Compare(sSouceName, sFindName + str, StringComparison.Ordinal))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000351E8 File Offset: 0x000333E8
		public static ArrayList readCgmAsdToArr(string sPath, string sName)
		{
			string strA = "";
			ArrayList arrayList = new ArrayList();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			Regex regex = new Regex("\\=[0-9]{0,3}", RegexOptions.IgnoreCase);
			string s;
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					s = streamReader.ReadToEnd();
				}
			}
			Regex regex2 = new Regex("^\\@clip x=[0-9]{0,3} y=[0-9]{0,3}$", RegexOptions.IgnoreCase);
			MemoryStream memoryStream = new MemoryStream(PublicModule.JpEncode.GetBytes(s));
			using (StreamReader streamReader2 = new StreamReader(memoryStream, PublicModule.JpEncode))
			{
				kirikiri2_fun.asdData asdData = default(kirikiri2_fun.asdData);
				IL_687:
				while (!streamReader2.EndOfStream)
				{
					string text = streamReader2.ReadLine().Trim();
					if (Strings.InStr(1, text, ";", CompareMethod.Binary) <= 0)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							while (flag || !kirikiri2_fun.findCgmNameInAsd(text, sName))
							{
								if (!flag)
								{
									goto IL_687;
								}
								if (Strings.InStr(1, text, "@cell storage", CompareMethod.Binary) > 0)
								{
									string text2 = PublicModule.regEqual.Split(text).Last<string>();
									if (0 == string.Compare(strA, text2, StringComparison.Ordinal))
									{
										flag = false;
										goto IL_687;
									}
									asdData.storage = text2;
									strA = text2;
									flag3 = true;
									goto IL_687;
								}
								else
								{
									MatchCollection matchCollection = regex2.Matches(text);
									if (matchCollection.Count > 0)
									{
										string[] array = PublicModule.regSmallSpace.Split(text);
										asdData.x = Conversions.ToInteger(PublicModule.regEqual.Split(array[1]).Last<string>());
										asdData.y = Conversions.ToInteger(PublicModule.regEqual.Split(array[2]).Last<string>());
										asdData.top = 0;
										asdData.left = 0;
										asdData.width = 0;
										asdData.height = 0;
										flag3 = true;
										goto IL_687;
									}
									if (Strings.InStr(1, text, "@fork target", CompareMethod.Binary) > 0)
									{
										asdData.forktarget = PublicModule.regEqual.Split(text).Last<string>();
										using (MemoryStream memoryStream2 = new MemoryStream(PublicModule.JpEncode.GetBytes(s)))
										{
											using (StreamReader streamReader3 = new StreamReader(memoryStream2, PublicModule.JpEncode))
											{
												while (!streamReader3.EndOfStream)
												{
													string text2 = streamReader3.ReadLine().Trim();
													if (Strings.InStr(1, text2, ";", CompareMethod.Binary) <= 0)
													{
														if (!string.IsNullOrWhiteSpace(text2))
														{
															if (0 == string.Compare(text2, asdData.forktarget, StringComparison.Ordinal))
															{
																text2 = streamReader3.ReadLine().Trim();
																if (Strings.InStr(1, text2, "@cell storage", CompareMethod.Binary) > 0)
																{
																	asdData.forktarget_storage = PublicModule.regEqual.Split(text2).Last<string>();
																	text2 = streamReader3.ReadLine().Trim();
																	if (Strings.InStr(1, text2, "@clip", CompareMethod.Binary) > 0)
																	{
																		string[] array2 = PublicModule.regSmallSpace.Split(text2);
																		asdData.forktarget_x = Conversions.ToInteger(PublicModule.regEqual.Split(array2[1]).Last<string>());
																		asdData.forktarget_y = Conversions.ToInteger(PublicModule.regEqual.Split(array2[2]).Last<string>());
																		flag3 = true;
																		break;
																	}
																	break;
																}
																else if (Strings.InStr(1, text2, "@invisible", CompareMethod.Binary) > 0)
																{
																	asdData.forktarget_storage = string.Empty;
																	asdData.forktarget_x = 0;
																	asdData.forktarget_y = 0;
																	flag3 = true;
																	break;
																}
															}
														}
													}
												}
											}
											goto IL_687;
										}
									}
									if (Strings.InStr(1, text, "@jump target", CompareMethod.Binary) > 0)
									{
										asdData.jumptarget = PublicModule.regEqual.Split(text).Last<string>();
										using (MemoryStream memoryStream3 = new MemoryStream(PublicModule.JpEncode.GetBytes(s)))
										{
											using (StreamReader streamReader4 = new StreamReader(memoryStream3, PublicModule.JpEncode))
											{
												while (!streamReader4.EndOfStream)
												{
													string text2 = streamReader4.ReadLine().Trim();
													if (Strings.InStr(1, text2, ";", CompareMethod.Binary) <= 0)
													{
														if (!string.IsNullOrWhiteSpace(text2))
														{
															if (!flag2 && 0 == string.Compare(text2, asdData.jumptarget, StringComparison.Ordinal))
															{
																flag2 = true;
															}
															if (flag2)
															{
																if (Strings.InStr(1, text2, "@clip", CompareMethod.Binary) > 0)
																{
																	MatchCollection matchCollection2 = regex.Matches(text2);
																	if (matchCollection2.Count > 0)
																	{
																		asdData.x = Conversions.ToInteger(matchCollection2[0].Value.Substring(1));
																		asdData.y = Conversions.ToInteger(matchCollection2[1].Value.Substring(1));
																		asdData.left = 0;
																		asdData.top = Conversions.ToInteger(matchCollection2[3].Value.Substring(1));
																		asdData.width = Conversions.ToInteger(matchCollection2[4].Value.Substring(1));
																		asdData.height = Conversions.ToInteger(matchCollection2[5].Value.Substring(1));
																		flag2 = false;
																	}
																}
																text2 = streamReader4.ReadLine().Trim();
																if (Strings.InStr(1, text2, ";", CompareMethod.Binary) <= 0)
																{
																	if (Strings.InStr(1, text2, "@clip", CompareMethod.Binary) > 0)
																	{
																		MatchCollection matchCollection3 = regex.Matches(text2);
																		if (matchCollection3.Count > 0)
																		{
																			asdData.x = Conversions.ToInteger(matchCollection3[0].Value.Substring(1));
																			asdData.y = Conversions.ToInteger(matchCollection3[1].Value.Substring(1));
																			asdData.left = 0;
																			asdData.top = Conversions.ToInteger(matchCollection3[3].Value.Substring(1));
																			asdData.width = Conversions.ToInteger(matchCollection3[4].Value.Substring(1));
																			asdData.height = Conversions.ToInteger(matchCollection3[5].Value.Substring(1));
																			flag2 = false;
																		}
																	}
																	if (flag2)
																	{
																		continue;
																	}
																}
																flag3 = true;
																break;
															}
														}
													}
												}
											}
											goto IL_687;
										}
									}
									if (0 == string.Compare(text, "@s", StringComparison.Ordinal))
									{
										flag = false;
										arrayList.Add(asdData);
										flag3 = false;
										goto IL_687;
									}
									if (string.IsNullOrWhiteSpace(text))
									{
										flag = false;
										arrayList.Add(asdData);
										flag3 = false;
										goto IL_687;
									}
									if (Strings.InStr(1, text, "*", CompareMethod.Binary) <= 0 || !flag3)
									{
										goto IL_687;
									}
									flag = false;
									flag3 = false;
									arrayList.Add(asdData);
								}
							}
							flag = true;
							asdData = default(kirikiri2_fun.asdData);
							asdData.baseName = sName;
							asdData.x = 0;
							asdData.y = 0;
						}
					}
				}
			}
			memoryStream.Dispose();
			return arrayList;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0003594C File Offset: 0x00033B4C
		private static void isFind_tjs_lms_sy(string sFileLine, string sclass, ref kirikiri2_fun.Tjs_lms_SY data)
		{
			if (Strings.InStr(1, sFileLine, "=", CompareMethod.Binary) > 0)
			{
				string[] source = sFileLine.Split(new char[]
				{
					'='
				});
				string text = source.First<string>().Trim();
				if (0 == string.Compare(text, "ex", StringComparison.Ordinal) | 0 == string.Compare(text, "mx", StringComparison.Ordinal))
				{
					text = source.Last<string>().Trim();
					if (Operators.CompareString(sclass, "s", false) == 0)
					{
						data.Pos_s_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(sclass, "m", false) == 0)
					{
						data.Pos_m_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(sclass, "l", false) == 0)
					{
						data.Pos_l_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
				}
				else if (0 == string.Compare(text, "ey", StringComparison.Ordinal) | 0 == string.Compare(text, "my", StringComparison.Ordinal))
				{
					text = source.Last<string>().Trim();
					if (Operators.CompareString(sclass, "s", false) == 0)
					{
						data.Pos_s_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(sclass, "m", false) == 0)
					{
						data.Pos_m_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(sclass, "l", false) == 0)
					{
						data.Pos_l_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
				}
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00035B08 File Offset: 0x00033D08
		public static ArrayList readTjsToArr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
					{
						string posEorM = string.Empty;
						string charaID = string.Empty;
						bool flag = false;
						int num = 0;
						kirikiri2_fun.Tjs_lms_SY tjs_lms_SY = default(kirikiri2_fun.Tjs_lms_SY);
						while (!streamReader.EndOfStream)
						{
							string text = streamReader.ReadLine().Trim();
							if (Strings.InStr(1, text, "/", CompareMethod.Binary) <= 0)
							{
								if (!string.IsNullOrWhiteSpace(text))
								{
									if (!flag)
									{
										if (Strings.InStr(1, text, "ResourceCheck(EyeAnimeFile)", CompareMethod.Binary) > 0)
										{
											posEorM = "目パチ";
											flag = true;
											continue;
										}
										if (Strings.InStr(1, text, "ResourceCheck(MouthAnimeFile)", CompareMethod.Binary) > 0)
										{
											posEorM = "口パク";
											flag = true;
											continue;
										}
									}
									if (flag)
									{
										if (0 == num && Strings.InStr(1, text, "case", CompareMethod.Binary) > 0)
										{
											string[] array = text.Split(new char[]
											{
												'"'
											});
											charaID = array[1];
											num++;
										}
										else if (1 == num && Strings.InStr(1, text, "case", CompareMethod.Binary) > 0)
										{
											string[] array = text.Split(new char[]
											{
												'"'
											});
											tjs_lms_SY.PosID = array[1];
											num++;
										}
										else
										{
											if (2 == num && Strings.InStr(1, text, "case", CompareMethod.Binary) > 0)
											{
												string[] array = text.Split(new char[]
												{
													'"'
												});
												string text2 = array[1].ToLower();
												string left = text2;
												if (Operators.CompareString(left, "s", false) == 0)
												{
													do
													{
														text = streamReader.ReadLine().Trim();
														kirikiri2_fun.isFind_tjs_lms_sy(text, text2, ref tjs_lms_SY);
													}
													while (!(0 < tjs_lms_SY.Pos_s_x & 0 < tjs_lms_SY.Pos_s_y));
													num++;
												}
												else if (Operators.CompareString(left, "m", false) == 0)
												{
													do
													{
														text = streamReader.ReadLine().Trim();
														kirikiri2_fun.isFind_tjs_lms_sy(text, text2, ref tjs_lms_SY);
													}
													while (!(0 < tjs_lms_SY.Pos_m_x & 0 < tjs_lms_SY.Pos_m_y));
													num++;
												}
												else if (Operators.CompareString(left, "l", false) == 0)
												{
													do
													{
														text = streamReader.ReadLine().Trim();
														kirikiri2_fun.isFind_tjs_lms_sy(text, text2, ref tjs_lms_SY);
													}
													while (!(0 < tjs_lms_SY.Pos_l_x & 0 < tjs_lms_SY.Pos_l_y));
													num++;
												}
											}
											if (Strings.InStr(1, text, "break;", CompareMethod.Binary) > 0)
											{
												num--;
												if (1 == num)
												{
													tjs_lms_SY.CharaID = charaID;
													tjs_lms_SY.PosEorM = posEorM;
													arrayList.Add(tjs_lms_SY);
													tjs_lms_SY = default(kirikiri2_fun.Tjs_lms_SY);
												}
												else if (0 >= num)
												{
													tjs_lms_SY = default(kirikiri2_fun.Tjs_lms_SY);
												}
											}
											else if (Strings.InStr(1, text, "EyeAnimeObj[index]", CompareMethod.Binary) > 0)
											{
												flag = false;
												num = 0;
											}
											else if (Strings.InStr(1, text, "MouthAnimeObj[index]", CompareMethod.Binary) > 0)
											{
												break;
											}
										}
									}
								}
							}
						}
					}
				}
				return arrayList;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00035E50 File Offset: 0x00034050
		public static string[] getTjsFiles(string sBasePath, string sClass, string sMergeSize)
		{
			string[] result = new string[1];
			string path = Path.Combine(sBasePath, sClass + Conversions.ToString(Path.DirectorySeparatorChar) + sMergeSize);
			if (Directory.Exists(path))
			{
				result = Directory.GetFiles(path);
			}
			return result;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00035E8C File Offset: 0x0003408C
		public static void readKsToArr(string sPath, ref ArrayList aeTempArr)
		{
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine().Trim();
						if (!string.IsNullOrWhiteSpace(text))
						{
							if (text.StartsWith("@"))
							{
								if (!PublicModule.canFindSameInArrayList(ref aeTempArr, text))
								{
									string[] array = PublicModule.regSmallSpace.Split(text);
									if (1 != array.Count<string>())
									{
										string text2 = array[1];
										if (!string.IsNullOrWhiteSpace(text2))
										{
											if (Strings.InStr(1, text2, "=", CompareMethod.Binary) <= 0 && Strings.InStr(1, text2, "@", CompareMethod.Binary) <= 0 && 0 != string.Compare(text2, "消", StringComparison.Ordinal) && 0 != string.Compare(text2, "vo", StringComparison.Ordinal))
											{
												bool flag = false;
												text2 = array.First<string>();
												if (Strings.InStr(1, text2, "@ev", CompareMethod.Binary) > 0)
												{
													flag = true;
												}
												if (BW2_three.triagain)
												{
													if (0 == string.Compare(text2, "@深冬", StringComparison.Ordinal))
													{
														flag = true;
													}
													else if (0 == string.Compare(text2, "@美羽", StringComparison.Ordinal))
													{
														flag = true;
													}
													else if (0 == string.Compare(text2, "@静音", StringComparison.Ordinal))
													{
														flag = true;
													}
												}
												if (flag)
												{
													aeTempArr.Add(text);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00036020 File Offset: 0x00034220
		public static ArrayList readTjsToArr_2(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
					{
						string text = string.Empty;
						int num = 0;
						int num2 = 0;
						bool flag = false;
						kirikiri2_fun.kirikiri2TjsData2 kirikiri2TjsData = default(kirikiri2_fun.kirikiri2TjsData2);
						while (!streamReader.EndOfStream)
						{
							string text2 = streamReader.ReadLine().Trim();
							if (!string.IsNullOrWhiteSpace(text2))
							{
								if (Strings.InStr(1, text2, "[", CompareMethod.Binary) > 0)
								{
									num++;
								}
								else if (Strings.InStr(1, text2, "]", CompareMethod.Binary) > 0)
								{
									num--;
								}
								if (string.IsNullOrWhiteSpace(text) && Strings.InStr(1, text2, "baseImage", CompareMethod.Binary) > 0)
								{
									string[] array = text2.Split(new char[]
									{
										'"'
									});
									text = array[3];
								}
								else if (Strings.InStr(1, text2, "diffCommands", CompareMethod.Binary) > 0)
								{
									flag = true;
								}
								else
								{
									if (flag)
									{
										if (2 == num)
										{
											num2++;
										}
										else
										{
											flag = false;
										}
									}
									if (3 == num)
									{
										if (Strings.InStr(1, text2, "=>", CompareMethod.Binary) > 0)
										{
											kirikiri2TjsData = default(kirikiri2_fun.kirikiri2TjsData2);
											kirikiri2TjsData.baseImage = text;
											kirikiri2TjsData.iDiffCommands = num2;
											string[] array = text2.Split(new char[]
											{
												'"'
											});
											string diffs = array[1];
											kirikiri2TjsData.diffs1 = diffs;
										}
										else if (Strings.InStr(1, text2, "]", CompareMethod.Binary) > 0)
										{
											arrayList.Add(kirikiri2TjsData);
										}
									}
									else if (4 == num)
									{
										string[] array = text2.Split(new char[]
										{
											'"'
										});
										string text3 = array.Last<string>();
										if (Strings.InStr(1, text3, "(const)", CompareMethod.Binary) > 0)
										{
											kirikiri2TjsData.diffs2 = array[1];
										}
										else
										{
											text3 = array[1];
											if (0 == string.Compare(text3, "opacity", StringComparison.Ordinal))
											{
												kirikiri2TjsData.opacity = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "width", StringComparison.Ordinal))
											{
												kirikiri2TjsData.width = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "y", StringComparison.Ordinal))
											{
												kirikiri2TjsData.y = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "type", StringComparison.Ordinal))
											{
												kirikiri2TjsData.type = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "x", StringComparison.Ordinal))
											{
												kirikiri2TjsData.x = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "height", StringComparison.Ordinal))
											{
												kirikiri2TjsData.height = kirikiri2_fun.strCleanSomeDummy(array.Last<string>());
											}
										}
									}
								}
							}
						}
					}
				}
				return arrayList;
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0003632C File Offset: 0x0003452C
		private static string strCleanSomeDummy(string source)
		{
			string text = source.Replace("=", string.Empty);
			text = text.Replace(">", string.Empty);
			text = text.Replace(",", string.Empty);
			return text.Trim();
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00036378 File Offset: 0x00034578
		public static void readKsToArr2(string sPath, ref ArrayList aeTempArr, string sSPCstr = "")
		{
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, PublicModule.JpEncode))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine().Trim();
						if (!string.IsNullOrWhiteSpace(text))
						{
							if (text.StartsWith("["))
							{
								if (!PublicModule.canFindSameInArrayList(ref aeTempArr, text))
								{
									string[] array = PublicModule.regSmallSpace.Split(text);
									if (1 != array.Count<string>())
									{
										bool flag = false;
										string text2 = array.First<string>();
										if (Strings.InStr(1, text2, "[limage", CompareMethod.Binary) > 0)
										{
											foreach (string text3 in array)
											{
												if (Strings.InStr(1, text3, "storage=", CompareMethod.Binary) > 0)
												{
													if (string.IsNullOrEmpty(sSPCstr))
													{
														text2 = text3.Substring("storage=".Length);
														if (!PublicModule.canFindSameInArrayList(ref aeTempArr, text2))
														{
															flag = true;
														}
													}
													else if (Strings.InStr(1, text3, sSPCstr, CompareMethod.Binary) > 0)
													{
														text2 = text3.Substring("storage=".Length);
														if (!PublicModule.canFindSameInArrayList(ref aeTempArr, text2))
														{
															flag = true;
														}
													}
												}
											}
										}
										if (flag)
										{
											aeTempArr.Add(text2);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x020000CC RID: 204
		public struct kirikiri2DefTxt
		{
			// Token: 0x060003F5 RID: 1013 RVA: 0x000364F8 File Offset: 0x000346F8
			public void fromArray(ref Array a)
			{
				this.layer_type = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					0
				}, null));
				this.name = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					1
				}, null));
				this.left = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					2
				}, null));
				this.top = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					3
				}, null));
				this.width = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					4
				}, null));
				this.height = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					5
				}, null));
				this.type = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					6
				}, null));
				this.opacity = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					7
				}, null));
				this.visible = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					8
				}, null));
				this.layer_id = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					9
				}, null));
				this.group_layer_id = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
				{
					10
				}, null));
				if (a.Length > 12)
				{
					this.@base = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
					{
						11
					}, null));
					this.images = Conversions.ToString(NewLateBinding.LateIndexGet(a, new object[]
					{
						12
					}, null));
				}
			}

			// Token: 0x040003D1 RID: 977
			public string layer_type;

			// Token: 0x040003D2 RID: 978
			public string name;

			// Token: 0x040003D3 RID: 979
			public string left;

			// Token: 0x040003D4 RID: 980
			public string top;

			// Token: 0x040003D5 RID: 981
			public string width;

			// Token: 0x040003D6 RID: 982
			public string height;

			// Token: 0x040003D7 RID: 983
			public string type;

			// Token: 0x040003D8 RID: 984
			public string opacity;

			// Token: 0x040003D9 RID: 985
			public string visible;

			// Token: 0x040003DA RID: 986
			public string layer_id;

			// Token: 0x040003DB RID: 987
			public string group_layer_id;

			// Token: 0x040003DC RID: 988
			public string @base;

			// Token: 0x040003DD RID: 989
			public string images;
		}

		// Token: 0x020000CD RID: 205
		public struct CgmData
		{
			// Token: 0x040003DE RID: 990
			public string baseName;

			// Token: 0x040003DF RID: 991
			public ArrayList faceList;
		}

		// Token: 0x020000CE RID: 206
		public struct asdData
		{
			// Token: 0x040003E0 RID: 992
			public string baseName;

			// Token: 0x040003E1 RID: 993
			public string storage;

			// Token: 0x040003E2 RID: 994
			public string jumptarget;

			// Token: 0x040003E3 RID: 995
			public string forktarget;

			// Token: 0x040003E4 RID: 996
			public string forktarget_storage;

			// Token: 0x040003E5 RID: 997
			public int forktarget_x;

			// Token: 0x040003E6 RID: 998
			public int forktarget_y;

			// Token: 0x040003E7 RID: 999
			public int x;

			// Token: 0x040003E8 RID: 1000
			public int y;

			// Token: 0x040003E9 RID: 1001
			public int left;

			// Token: 0x040003EA RID: 1002
			public int top;

			// Token: 0x040003EB RID: 1003
			public int width;

			// Token: 0x040003EC RID: 1004
			public int height;
		}

		// Token: 0x020000CF RID: 207
		public struct Tjs_lms_SY
		{
			// Token: 0x040003ED RID: 1005
			public string CharaID;

			// Token: 0x040003EE RID: 1006
			public string PosID;

			// Token: 0x040003EF RID: 1007
			public string PosEorM;

			// Token: 0x040003F0 RID: 1008
			public int Pos_l_x;

			// Token: 0x040003F1 RID: 1009
			public int Pos_l_y;

			// Token: 0x040003F2 RID: 1010
			public int Pos_m_x;

			// Token: 0x040003F3 RID: 1011
			public int Pos_m_y;

			// Token: 0x040003F4 RID: 1012
			public int Pos_s_x;

			// Token: 0x040003F5 RID: 1013
			public int Pos_s_y;
		}

		// Token: 0x020000D0 RID: 208
		public struct kirikiri2TjsData2
		{
			// Token: 0x040003F6 RID: 1014
			public string baseImage;

			// Token: 0x040003F7 RID: 1015
			public int iDiffCommands;

			// Token: 0x040003F8 RID: 1016
			public string diffs1;

			// Token: 0x040003F9 RID: 1017
			public string diffs2;

			// Token: 0x040003FA RID: 1018
			public string opacity;

			// Token: 0x040003FB RID: 1019
			public string width;

			// Token: 0x040003FC RID: 1020
			public string y;

			// Token: 0x040003FD RID: 1021
			public string type;

			// Token: 0x040003FE RID: 1022
			public string x;

			// Token: 0x040003FF RID: 1023
			public string height;
		}
	}
}
