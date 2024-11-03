using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GalPhotoAuto.merge_function;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C9 RID: 201
	public class kirikiri2_fun
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x00034DF8 File Offset: 0x00032FF8
		public static kirikiri2_fun.kirikiri2DefTxt getLayerArr(string str, ref ArrayList defineTxt, bool bFollowUp = false, ref ArrayList tempArrlist = null)
		{
			kirikiri2_fun.a a = new kirikiri2_fun.a();
			a.a = str;
			a.b = default(kirikiri2_fun.kirikiri2DefTxt);
			if (Strings.InStr(1, a.a, "$", CompareMethod.Binary) > 0)
			{
				string[] array = a.a.Split(new char[]
				{
					'$'
				});
				a.a = array[0];
			}
			checked
			{
				if (Strings.InStr(1, a.a, "/", CompareMethod.Binary) > 0)
				{
					kirikiri2_fun.a.a a2 = new kirikiri2_fun.a.a();
					string[] array2 = a.a.Split(new char[]
					{
						'/'
					});
					a2.b = 0;
					a2.a = false;
					string[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						kirikiri2_fun.a.a.a a3 = new kirikiri2_fun.a.a.a(a3);
						a3.a = array3[i];
						a3.c = a2;
						a3.b = a;
						Parallel.ForEach<object>(defineTxt.ToArray(), new Action<object, ParallelLoopState>(a3.d));
					}
					if (!a2.a)
					{
						if (bFollowUp && string.IsNullOrEmpty(a.b.layer_type))
						{
							try
							{
								foreach (object obj in defineTxt)
								{
									kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt2;
									kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt = (obj != null) ? ((kirikiri2_fun.kirikiri2DefTxt)obj) : kirikiri2DefTxt2;
									if (!string.IsNullOrWhiteSpace(kirikiri2DefTxt.group_layer_id))
									{
										if (a2.b == Conversions.ToInteger(kirikiri2DefTxt.group_layer_id))
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
					Parallel.ForEach<object>(defineTxt.ToArray(), new Action<object, ParallelLoopState>(a.c));
				}
				return a.b;
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00034FC8 File Offset: 0x000331C8
		public static void readBaseInfoToArr(string base_info_path, ref ArrayList baseinfotxt)
		{
			using (FileStream fileStream = new FileStream(base_info_path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					while (!streamReader.EndOfStream)
					{
						string input = streamReader.ReadLine();
						string[] array = x.ao.Split(input);
						if (!(Strings.InStr(1, array[0], "#", CompareMethod.Binary) > 0 | string.IsNullOrEmpty(array[0])))
						{
							baseinfotxt.Add(array);
						}
					}
				}
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00035064 File Offset: 0x00033264
		public static bool readTxtToArr(string txtF, ref ArrayList defineTxt, ref int iW, ref int iH)
		{
			bool result = false;
			using (FileStream fileStream = new FileStream(txtF, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					while (!streamReader.EndOfStream)
					{
						string input = streamReader.ReadLine();
						string[] array = x.ao.Split(input);
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

		// Token: 0x060003F6 RID: 1014 RVA: 0x00035170 File Offset: 0x00033370
		public static string[] readAnmToArr(string sPath)
		{
			string[] array = new string[5];
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, x.o))
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
							string[] source = x.ap.Split(input);
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

		// Token: 0x060003F7 RID: 1015 RVA: 0x000352E4 File Offset: 0x000334E4
		public static ArrayList readAsdToArr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine();
						if (Strings.InStr(1, text, "@clip left", CompareMethod.Binary) > 0 | string.IsNullOrWhiteSpace(text))
						{
							string[] source = x.an.Split(text);
							string text2 = source.Last<string>();
							if (Versioned.IsNumeric(text2) && !x.b(ref arrayList, text2))
							{
								arrayList.Add(text2);
							}
						}
					}
				}
			}
			return arrayList;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000353A4 File Offset: 0x000335A4
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
					using (StreamReader streamReader = new StreamReader(fileStream, x.o))
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
											string a_ = text.Split(new char[]
											{
												','
											}).First<string>();
											baseName = kirikiri2_fun.b(a_);
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
												string a_ = array[i];
												array2[i] = kirikiri2_fun.b(a_);
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

		// Token: 0x060003F9 RID: 1017 RVA: 0x000355E4 File Offset: 0x000337E4
		private static string b(string A_0)
		{
			string[] array = A_0.Split(new char[]
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

		// Token: 0x060003FA RID: 1018 RVA: 0x00035638 File Offset: 0x00033838
		private static bool a(string A_0, string A_1)
		{
			string[] array = new string[]
			{
				"目",
				"口"
			};
			foreach (string str in array)
			{
				if (0 == string.Compare(A_0, A_1 + str, StringComparison.Ordinal))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00035690 File Offset: 0x00033890
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
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					s = streamReader.ReadToEnd();
				}
			}
			Regex regex2 = new Regex("^\\@clip x=[0-9]{0,3} y=[0-9]{0,3}$", RegexOptions.IgnoreCase);
			MemoryStream memoryStream = new MemoryStream(x.o.GetBytes(s));
			using (StreamReader streamReader2 = new StreamReader(memoryStream, x.o))
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
							while (flag || !kirikiri2_fun.a(text, sName))
							{
								if (!flag)
								{
									goto IL_687;
								}
								if (Strings.InStr(1, text, "@cell storage", CompareMethod.Binary) > 0)
								{
									string text2 = x.an.Split(text).Last<string>();
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
										string[] array = x.ap.Split(text);
										asdData.x = Conversions.ToInteger(x.an.Split(array[1]).Last<string>());
										asdData.y = Conversions.ToInteger(x.an.Split(array[2]).Last<string>());
										asdData.top = 0;
										asdData.left = 0;
										asdData.width = 0;
										asdData.height = 0;
										flag3 = true;
										goto IL_687;
									}
									if (Strings.InStr(1, text, "@fork target", CompareMethod.Binary) > 0)
									{
										asdData.forktarget = x.an.Split(text).Last<string>();
										using (MemoryStream memoryStream2 = new MemoryStream(x.o.GetBytes(s)))
										{
											using (StreamReader streamReader3 = new StreamReader(memoryStream2, x.o))
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
																	asdData.forktarget_storage = x.an.Split(text2).Last<string>();
																	text2 = streamReader3.ReadLine().Trim();
																	if (Strings.InStr(1, text2, "@clip", CompareMethod.Binary) > 0)
																	{
																		string[] array2 = x.ap.Split(text2);
																		asdData.forktarget_x = Conversions.ToInteger(x.an.Split(array2[1]).Last<string>());
																		asdData.forktarget_y = Conversions.ToInteger(x.an.Split(array2[2]).Last<string>());
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
										asdData.jumptarget = x.an.Split(text).Last<string>();
										using (MemoryStream memoryStream3 = new MemoryStream(x.o.GetBytes(s)))
										{
											using (StreamReader streamReader4 = new StreamReader(memoryStream3, x.o))
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

		// Token: 0x060003FC RID: 1020 RVA: 0x00035DF4 File Offset: 0x00033FF4
		private static void a(string A_0, string A_1, ref kirikiri2_fun.Tjs_lms_SY A_2)
		{
			if (Strings.InStr(1, A_0, "=", CompareMethod.Binary) > 0)
			{
				string[] source = A_0.Split(new char[]
				{
					'='
				});
				string text = source.First<string>().Trim();
				if (0 == string.Compare(text, "ex", StringComparison.Ordinal) | 0 == string.Compare(text, "mx", StringComparison.Ordinal))
				{
					text = source.Last<string>().Trim();
					if (Operators.CompareString(A_1, "s", false) == 0)
					{
						A_2.Pos_s_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(A_1, "m", false) == 0)
					{
						A_2.Pos_m_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(A_1, "l", false) == 0)
					{
						A_2.Pos_l_x = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
				}
				else if (0 == string.Compare(text, "ey", StringComparison.Ordinal) | 0 == string.Compare(text, "my", StringComparison.Ordinal))
				{
					text = source.Last<string>().Trim();
					if (Operators.CompareString(A_1, "s", false) == 0)
					{
						A_2.Pos_s_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(A_1, "m", false) == 0)
					{
						A_2.Pos_m_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
					else if (Operators.CompareString(A_1, "l", false) == 0)
					{
						A_2.Pos_l_y = Conversions.ToInteger(text.Replace(";", string.Empty));
					}
				}
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00035FB0 File Offset: 0x000341B0
		public static ArrayList readTjsToArr(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, x.o))
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
														kirikiri2_fun.a(text, text2, ref tjs_lms_SY);
													}
													while (!(0 < tjs_lms_SY.Pos_s_x & 0 < tjs_lms_SY.Pos_s_y));
													num++;
												}
												else if (Operators.CompareString(left, "m", false) == 0)
												{
													do
													{
														text = streamReader.ReadLine().Trim();
														kirikiri2_fun.a(text, text2, ref tjs_lms_SY);
													}
													while (!(0 < tjs_lms_SY.Pos_m_x & 0 < tjs_lms_SY.Pos_m_y));
													num++;
												}
												else if (Operators.CompareString(left, "l", false) == 0)
												{
													do
													{
														text = streamReader.ReadLine().Trim();
														kirikiri2_fun.a(text, text2, ref tjs_lms_SY);
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

		// Token: 0x060003FE RID: 1022 RVA: 0x000362F8 File Offset: 0x000344F8
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

		// Token: 0x060003FF RID: 1023 RVA: 0x00036334 File Offset: 0x00034534
		public static void readKsToArr(string sPath, ref ArrayList aeTempArr)
		{
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine().Trim();
						if (!string.IsNullOrWhiteSpace(text))
						{
							if (text.StartsWith("@"))
							{
								if (!x.b(ref aeTempArr, text))
								{
									string[] array = x.ap.Split(text);
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

		// Token: 0x06000400 RID: 1024 RVA: 0x000364C8 File Offset: 0x000346C8
		public static ArrayList readTjsToArr_2(string sPath)
		{
			ArrayList arrayList = new ArrayList();
			checked
			{
				using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader streamReader = new StreamReader(fileStream, x.o))
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
												kirikiri2TjsData.opacity = kirikiri2_fun.a(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "width", StringComparison.Ordinal))
											{
												kirikiri2TjsData.width = kirikiri2_fun.a(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "y", StringComparison.Ordinal))
											{
												kirikiri2TjsData.y = kirikiri2_fun.a(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "type", StringComparison.Ordinal))
											{
												kirikiri2TjsData.type = kirikiri2_fun.a(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "x", StringComparison.Ordinal))
											{
												kirikiri2TjsData.x = kirikiri2_fun.a(array.Last<string>());
											}
											else if (0 == string.Compare(text3, "height", StringComparison.Ordinal))
											{
												kirikiri2TjsData.height = kirikiri2_fun.a(array.Last<string>());
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

		// Token: 0x06000401 RID: 1025 RVA: 0x000367D4 File Offset: 0x000349D4
		private static string a(string A_0)
		{
			string text = A_0.Replace("=", string.Empty);
			text = text.Replace(">", string.Empty);
			text = text.Replace(",", string.Empty);
			return text.Trim();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00036820 File Offset: 0x00034A20
		public static void readKsToArr2(string sPath, ref ArrayList aeTempArr, string sSPCstr = "")
		{
			using (FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream, x.o))
				{
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine().Trim();
						if (!string.IsNullOrWhiteSpace(text))
						{
							if (text.StartsWith("["))
							{
								if (!x.b(ref aeTempArr, text))
								{
									string[] array = x.ap.Split(text);
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
														if (!x.b(ref aeTempArr, text2))
														{
															flag = true;
														}
													}
													else if (Strings.InStr(1, text3, sSPCstr, CompareMethod.Binary) > 0)
													{
														text2 = text3.Substring("storage=".Length);
														if (!x.b(ref aeTempArr, text2))
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

		// Token: 0x020000CA RID: 202
		public struct kirikiri2DefTxt
		{
			// Token: 0x06000403 RID: 1027 RVA: 0x000369A0 File Offset: 0x00034BA0
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

			// Token: 0x040003C0 RID: 960
			public string layer_type;

			// Token: 0x040003C1 RID: 961
			public string name;

			// Token: 0x040003C2 RID: 962
			public string left;

			// Token: 0x040003C3 RID: 963
			public string top;

			// Token: 0x040003C4 RID: 964
			public string width;

			// Token: 0x040003C5 RID: 965
			public string height;

			// Token: 0x040003C6 RID: 966
			public string type;

			// Token: 0x040003C7 RID: 967
			public string opacity;

			// Token: 0x040003C8 RID: 968
			public string visible;

			// Token: 0x040003C9 RID: 969
			public string layer_id;

			// Token: 0x040003CA RID: 970
			public string group_layer_id;

			// Token: 0x040003CB RID: 971
			public string @base;

			// Token: 0x040003CC RID: 972
			public string images;
		}

		// Token: 0x020000CB RID: 203
		public struct CgmData
		{
			// Token: 0x040003CD RID: 973
			public string baseName;

			// Token: 0x040003CE RID: 974
			public ArrayList faceList;
		}

		// Token: 0x020000CC RID: 204
		public struct asdData
		{
			// Token: 0x040003CF RID: 975
			public string baseName;

			// Token: 0x040003D0 RID: 976
			public string storage;

			// Token: 0x040003D1 RID: 977
			public string jumptarget;

			// Token: 0x040003D2 RID: 978
			public string forktarget;

			// Token: 0x040003D3 RID: 979
			public string forktarget_storage;

			// Token: 0x040003D4 RID: 980
			public int forktarget_x;

			// Token: 0x040003D5 RID: 981
			public int forktarget_y;

			// Token: 0x040003D6 RID: 982
			public int x;

			// Token: 0x040003D7 RID: 983
			public int y;

			// Token: 0x040003D8 RID: 984
			public int left;

			// Token: 0x040003D9 RID: 985
			public int top;

			// Token: 0x040003DA RID: 986
			public int width;

			// Token: 0x040003DB RID: 987
			public int height;
		}

		// Token: 0x020000CD RID: 205
		public struct Tjs_lms_SY
		{
			// Token: 0x040003DC RID: 988
			public string CharaID;

			// Token: 0x040003DD RID: 989
			public string PosID;

			// Token: 0x040003DE RID: 990
			public string PosEorM;

			// Token: 0x040003DF RID: 991
			public int Pos_l_x;

			// Token: 0x040003E0 RID: 992
			public int Pos_l_y;

			// Token: 0x040003E1 RID: 993
			public int Pos_m_x;

			// Token: 0x040003E2 RID: 994
			public int Pos_m_y;

			// Token: 0x040003E3 RID: 995
			public int Pos_s_x;

			// Token: 0x040003E4 RID: 996
			public int Pos_s_y;
		}

		// Token: 0x020000CE RID: 206
		public struct kirikiri2TjsData2
		{
			// Token: 0x040003E5 RID: 997
			public string baseImage;

			// Token: 0x040003E6 RID: 998
			public int iDiffCommands;

			// Token: 0x040003E7 RID: 999
			public string diffs1;

			// Token: 0x040003E8 RID: 1000
			public string diffs2;

			// Token: 0x040003E9 RID: 1001
			public string opacity;

			// Token: 0x040003EA RID: 1002
			public string width;

			// Token: 0x040003EB RID: 1003
			public string y;

			// Token: 0x040003EC RID: 1004
			public string type;

			// Token: 0x040003ED RID: 1005
			public string x;

			// Token: 0x040003EE RID: 1006
			public string height;
		}

		// Token: 0x020000CF RID: 207
		[CompilerGenerated]
		internal class a
		{
			// Token: 0x06000405 RID: 1029 RVA: 0x00036B98 File Offset: 0x00034D98
			[DebuggerStepThrough]
			[CompilerGenerated]
			public void c(object A_0, ParallelLoopState A_1)
			{
				kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt;
				new c<kirikiri2_fun.kirikiri2DefTxt, ParallelLoopState>(this.c)((A_0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)A_0) : kirikiri2DefTxt, A_1);
			}

			// Token: 0x06000406 RID: 1030 RVA: 0x00036BCA File Offset: 0x00034DCA
			[CompilerGenerated]
			public void c(kirikiri2_fun.kirikiri2DefTxt A_0, ParallelLoopState A_1)
			{
				if (0 == string.Compare(A_0.name, this.a, StringComparison.Ordinal) & Operators.CompareString(A_0.layer_type, "0", false) == 0)
				{
					A_1.Break();
					this.b = A_0;
				}
			}

			// Token: 0x040003EF RID: 1007
			public string a;

			// Token: 0x040003F0 RID: 1008
			public kirikiri2_fun.kirikiri2DefTxt b;

			// Token: 0x020000D0 RID: 208
			[CompilerGenerated]
			internal class a
			{
				// Token: 0x040003F1 RID: 1009
				public bool a;

				// Token: 0x040003F2 RID: 1010
				public int b;

				// Token: 0x020000D1 RID: 209
				[CompilerGenerated]
				internal class a
				{
					// Token: 0x06000408 RID: 1032 RVA: 0x00036C0F File Offset: 0x00034E0F
					public a(kirikiri2_fun.a.a.a A_0)
					{
						if (A_0 != null)
						{
							this.a = A_0.a;
						}
					}

					// Token: 0x06000409 RID: 1033 RVA: 0x00036C28 File Offset: 0x00034E28
					[CompilerGenerated]
					[DebuggerStepThrough]
					public void d(object A_0, ParallelLoopState A_1)
					{
						kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt;
						new c<kirikiri2_fun.kirikiri2DefTxt, ParallelLoopState>(this.d)((A_0 != null) ? ((kirikiri2_fun.kirikiri2DefTxt)A_0) : kirikiri2DefTxt, A_1);
					}

					// Token: 0x0600040A RID: 1034 RVA: 0x00036C5C File Offset: 0x00034E5C
					[CompilerGenerated]
					public void d(kirikiri2_fun.kirikiri2DefTxt A_0, ParallelLoopState A_1)
					{
						if (0 == string.Compare(A_0.name, this.a, StringComparison.Ordinal) & 0 == this.c.b)
						{
							if (Operators.CompareString(A_0.layer_type, "2", false) == 0)
							{
								A_1.Break();
								if (string.IsNullOrWhiteSpace(A_0.group_layer_id))
								{
									this.c.b = Conversions.ToInteger(A_0.layer_id);
								}
								else
								{
									this.c.b = 0;
								}
							}
						}
						else if (0 == string.Compare(A_0.name, this.a, StringComparison.Ordinal) & 0 < this.c.b)
						{
							if (string.IsNullOrWhiteSpace(A_0.group_layer_id))
							{
								return;
							}
							if (this.c.b == Conversions.ToInteger(A_0.group_layer_id))
							{
								A_1.Break();
								if (Operators.CompareString(A_0.layer_type, "2", false) == 0)
								{
									this.c.b = Conversions.ToInteger(A_0.layer_id);
								}
								else if (Operators.CompareString(A_0.layer_type, "0", false) == 0)
								{
									this.b.b = A_0;
									this.c.a = true;
								}
							}
						}
					}

					// Token: 0x040003F3 RID: 1011
					public string a;

					// Token: 0x040003F4 RID: 1012
					public kirikiri2_fun.a b;

					// Token: 0x040003F5 RID: 1013
					public kirikiri2_fun.a.a c;
				}
			}
		}
	}
}
