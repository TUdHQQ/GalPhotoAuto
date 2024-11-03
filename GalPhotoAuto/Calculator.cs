using System;
using System.Collections.Specialized;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000BB RID: 187
	public class Calculator
	{
		// Token: 0x06000253 RID: 595 RVA: 0x00024944 File Offset: 0x00022B44
		// Note: this type is marked as 'beforefieldinit'.
		static Calculator()
		{
			object[,] array = new object[33, 2];
			array[0, 0] = ",";
			array[0, 1] = 0;
			array[1, 0] = "=";
			array[1, 1] = 1;
			array[2, 0] = ">=";
			array[2, 1] = 1;
			array[3, 0] = "<=";
			array[3, 1] = 1;
			array[4, 0] = "<>";
			array[4, 1] = 1;
			array[5, 0] = ">";
			array[5, 1] = 1;
			array[6, 0] = "<";
			array[6, 1] = 1;
			array[7, 0] = "+";
			array[7, 1] = 2;
			array[8, 0] = "-";
			array[8, 1] = 2;
			array[9, 0] = "*";
			array[9, 1] = 3;
			array[10, 0] = "/";
			array[10, 1] = 3;
			array[11, 0] = "%";
			array[11, 1] = 3;
			array[12, 0] = "NEG";
			array[12, 1] = 4;
			array[13, 0] = "^";
			array[13, 1] = 5;
			array[14, 0] = "(";
			array[14, 1] = 99;
			array[15, 0] = "ROUND(";
			array[15, 1] = 99;
			array[16, 0] = "TRUNC(";
			array[16, 1] = 99;
			array[17, 0] = "MAX(";
			array[17, 1] = 99;
			array[18, 0] = "MIN(";
			array[18, 1] = 99;
			array[19, 0] = "ABS(";
			array[19, 1] = 99;
			array[20, 0] = "SUM(";
			array[20, 1] = 99;
			array[21, 0] = "AVERAGE(";
			array[21, 1] = 99;
			array[22, 0] = "SQRT(";
			array[22, 1] = 99;
			array[23, 0] = "EXP(";
			array[23, 1] = 99;
			array[24, 0] = "LOG(";
			array[24, 1] = 99;
			array[25, 0] = "LOG10(";
			array[25, 1] = 99;
			array[26, 0] = "SIN(";
			array[26, 1] = 99;
			array[27, 0] = "COS(";
			array[27, 1] = 99;
			array[28, 0] = "TAN(";
			array[28, 1] = 99;
			array[29, 0] = "IF(";
			array[29, 1] = 99;
			array[30, 0] = "NOT(";
			array[30, 1] = 99;
			array[31, 0] = "AND(";
			array[31, 1] = 99;
			array[32, 0] = "OR(";
			array[32, 1] = 99;
			Calculator.f = array;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00024D20 File Offset: 0x00022F20
		public static decimal[] Eval(string expression, NameValueCollection dataProvider)
		{
			Calculator calculator = new Calculator(expression, dataProvider);
			return calculator.Calculate();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00024D40 File Offset: 0x00022F40
		public Calculator(string expression, NameValueCollection dataProvider)
		{
			this.c = expression;
			this.a = dataProvider;
			this.e = expression.ToUpper();
			if (this.a(this.e) != -1)
			{
				throw new Exception("表达式\"" + this.c + "\"缺少\"(\"");
			}
			this.c();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00024DA0 File Offset: 0x00022FA0
		private void c()
		{
			string empty = string.Empty;
			this.a(this.e, ref this.d, ref this.b, ref empty);
			this.e = empty;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00024DD4 File Offset: 0x00022FD4
		private static int c(string A_0)
		{
			int num = 0;
			checked
			{
				int num2 = Calculator.f.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (Operators.CompareString(Conversions.ToString(Calculator.f[i, 0]), A_0, false) == 0)
					{
						return Conversions.ToInteger(Calculator.f[i, 1]);
					}
				}
				return -1;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00024E2C File Offset: 0x0002302C
		private static string b(string A_0)
		{
			int num = 0;
			checked
			{
				int num2 = Calculator.f.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (A_0.StartsWith(Conversions.ToString(Calculator.f[i, 0])))
					{
						return Conversions.ToString(Calculator.f[i, 0]);
					}
				}
				return null;
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00024E80 File Offset: 0x00023080
		private void a(string A_0, ref string A_1, ref string A_2, ref string A_3)
		{
			A_3 = A_0;
			A_1 = string.Empty;
			A_2 = null;
			checked
			{
				while (Operators.CompareString(A_3, string.Empty, false) != 0)
				{
					A_2 = Calculator.b(A_3);
					if (Operators.CompareString(A_2, null, false) != 0)
					{
						A_3 = A_3.Substring(A_2.Length, A_3.Length - A_2.Length);
						break;
					}
					A_1 += Conversions.ToString(A_3[0]);
					A_3 = A_3.Substring(1, A_3.Length - 1);
				}
				A_1 = A_1.Trim();
				A_3 = A_3.Trim();
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00024F2C File Offset: 0x0002312C
		public decimal[] Calculate()
		{
			if (Operators.CompareString(this.b, null, false) == 0)
			{
				decimal num = 0m;
				try
				{
					num = decimal.Parse(this.d);
				}
				catch (Exception ex)
				{
					try
					{
						num = decimal.Parse(this.a[this.d]);
					}
					catch (Exception ex2)
					{
						throw new Exception("表达式\"" + this.c + "\"中含有错误的格式:" + this.d);
					}
				}
				return new decimal[]
				{
					num
				};
			}
			if (Calculator.c(this.b) != 99)
			{
				if (Operators.CompareString(this.b, "-", false) != 0 & Operators.CompareString(this.d, string.Empty, false) == 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this.c,
						"\"中\"",
						this.b,
						"\" 运算符的左边需要值或表达式"
					}));
				}
				if (Operators.CompareString(this.b, "-", false) == 0 & Operators.CompareString(this.d, string.Empty, false) == 0)
				{
					this.b = "NEG";
				}
				if (Operators.CompareString(this.e, string.Empty, false) == 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this.c,
						"\"中\"",
						this.b,
						"\" 运算符的右边需要值或表达式"
					}));
				}
				return this.a();
			}
			else
			{
				if (Operators.CompareString(this.d, string.Empty, false) != 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this.c,
						"\"中\"",
						this.b,
						"\" 运算符的左边不需要值或表达式"
					}));
				}
				return this.b();
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00025140 File Offset: 0x00023340
		private decimal[] b()
		{
			int num = this.a(this.e);
			if (num == -1)
			{
				throw new Exception("表达式\"" + this.c + "\"缺少\")\"");
			}
			string a_ = this.e.Substring(0, num);
			checked
			{
				if (num == this.e.Length - 1)
				{
					return this.a(this.b, a_);
				}
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				this.e = this.e.Substring(num + 1, this.e.Length - num - 1);
				this.a(this.e, ref empty, ref empty3, ref empty2);
				decimal[] array = this.a(this.b, a_);
				this.d = array[array.Length - 1].ToString();
				if (Operators.CompareString(empty3, null, false) == 0)
				{
					throw new Exception("表达式\"" + this.c + "\"中\")\"运算符的右边需要运算符");
				}
				this.b = empty3;
				this.e = empty2;
				return this.Calculate();
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00025254 File Offset: 0x00023454
		private int a(string A_0)
		{
			int num = 0;
			int num2 = 0;
			checked
			{
				int num3 = A_0.Length - 1;
				for (int i = num2; i <= num3; i++)
				{
					if (A_0[i] == ')')
					{
						if (num == 0)
						{
							return i;
						}
						num--;
					}
					if (A_0[i] == '(')
					{
						num++;
					}
				}
				return -1;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000252A0 File Offset: 0x000234A0
		private decimal[] a()
		{
			string empty = string.Empty;
			string text = string.Empty;
			string empty2 = string.Empty;
			this.a(this.e, ref empty, ref empty2, ref text);
			checked
			{
				decimal[] array;
				if (Operators.CompareString(empty2, null, false) == 0 | Calculator.c(this.b) >= Calculator.c(empty2))
				{
					array = this.a(this.b, this.d, empty);
				}
				else
				{
					string text2 = empty;
					while (Calculator.c(this.b) < Calculator.c(empty2) & Operators.CompareString(text, string.Empty, false) != 0)
					{
						text2 += empty2;
						if (Calculator.c(empty2) == 99)
						{
							int num = this.a(text);
							text2 += text.Substring(0, num + 1);
							text = text.Substring(num + 1);
						}
						this.a(text, ref empty, ref empty2, ref text);
						text2 += empty;
					}
					Calculator calculator = new Calculator(text2, this.a);
					decimal[] array2 = calculator.Calculate();
					array = this.a(this.b, this.d, array2[array2.Length - 1].ToString());
				}
				this.d = array[array.Length - 1].ToString();
				this.b = empty2;
				this.e = text;
				decimal[] array3 = this.Calculate();
				decimal[] array4 = new decimal[array.Length - 1 + array3.Length - 1 + 1];
				int num2 = 0;
				int num3 = array.Length - 2;
				for (int i = num2; i <= num3; i++)
				{
					array4[i] = array[i];
				}
				int num4 = 0;
				int num5 = array3.Length - 1;
				for (int i = num4; i <= num5; i++)
				{
					array4[array.Length - 1 + i] = array3[i];
				}
				return array4;
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00025484 File Offset: 0x00023684
		private decimal[] a(string A_0, string A_1)
		{
			Calculator calculator = new Calculator(A_1, this.a);
			decimal[] array = calculator.Calculate();
			checked
			{
				decimal num = array[array.Length - 1];
				decimal num2 = 0m;
				string left = this.b;
				if (Operators.CompareString(left, "(", false) == 0)
				{
					num2 = num;
				}
				else if (Operators.CompareString(left, "ROUND(", false) == 0)
				{
					if (array.Length > 2)
					{
						throw new Exception("表达式\"" + this.c + "\"中Round函数需要一个或两个参数!");
					}
					if (array.Length == 1)
					{
						num2 = decimal.Round(num, 0);
					}
					else
					{
						num2 = decimal.Round(array[0], Convert.ToInt32(array[1]));
					}
				}
				else if (Operators.CompareString(left, "TRUNC(", false) == 0)
				{
					if (array.Length > 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Trunc函数只需要一个参数!");
					}
					num2 = decimal.Truncate(num);
				}
				else if (Operators.CompareString(left, "MAX(", false) == 0)
				{
					if (array.Length < 2)
					{
						throw new Exception("表达式\"" + this.c + "\"中Max函数至少需要两个参数!");
					}
					num2 = array[0];
					int num3 = 1;
					int num4 = array.Length - 1;
					for (int i = num3; i <= num4; i++)
					{
						if (decimal.Compare(array[i], num2) > 0)
						{
							num2 = array[i];
						}
					}
				}
				else if (Operators.CompareString(left, "MIN(", false) == 0)
				{
					if (array.Length < 2)
					{
						throw new Exception("表达式\"" + this.c + "\"中Min函数至少需要两个参数!");
					}
					num2 = array[0];
					int num5 = 1;
					int num6 = array.Length - 1;
					for (int j = num5; j <= num6; j++)
					{
						if (decimal.Compare(array[j], num2) < 0)
						{
							num2 = array[j];
						}
					}
				}
				else if (Operators.CompareString(left, "ABS", false) == 0)
				{
					if (array.Length > 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Abs函数只需要一个参数!");
					}
					num2 = Math.Abs(num);
				}
				else if (Operators.CompareString(left, "SUM(", false) == 0)
				{
					foreach (decimal d in array)
					{
						num2 = decimal.Add(num2, d);
					}
				}
				else if (Operators.CompareString(left, "AVERAGE(", false) == 0)
				{
					foreach (decimal d2 in array)
					{
						num2 = decimal.Add(num2, d2);
					}
					num2 = decimal.Divide(num2, new decimal(array.Length));
				}
				else if (Operators.CompareString(left, "IF(", false) == 0)
				{
					if (array.Length != 3)
					{
						throw new Exception("表达式\"" + this.c + "\"中IF函数需要三个参数!");
					}
					if (this.a(array[0]))
					{
						num2 = array[1];
					}
					else
					{
						num2 = array[2];
					}
				}
				else if (Operators.CompareString(left, "NOT(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中NOT函数需要一个参数!");
					}
					if (this.a(array[0]))
					{
						num2 = 0m;
					}
					else
					{
						num2 = 1m;
					}
				}
				else if (Operators.CompareString(left, "OR(", false) == 0)
				{
					if (array.Length < 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中OR函数至少需要两个参数!");
					}
					foreach (decimal a_ in array)
					{
						if (this.a(a_))
						{
							return new decimal[]
							{
								1m
							};
						}
					}
				}
				else if (Operators.CompareString(left, "AND(", false) == 0)
				{
					if (array.Length < 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中AND函数至少需要两个参数!");
					}
					foreach (decimal a_2 in array)
					{
						if (!this.a(a_2))
						{
							return new decimal[]
							{
								0m
							};
						}
					}
					num2 = 1m;
				}
				else if (Operators.CompareString(left, "SQRT(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中SQRT函数需要一个参数!");
					}
					num2 = new decimal(Math.Sqrt(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(left, "SIN(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Sin函数需要一个参数!");
					}
					num2 = new decimal(Math.Sin(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(left, "COS(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Cos函数需要一个参数!");
					}
					num2 = new decimal(Math.Cos(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(left, "TAN(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Tan函数需要一个参数!");
					}
					num2 = new decimal(Math.Tan(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(left, "EXP(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Exp函数需要一个参数!");
					}
					num2 = new decimal(Math.Exp(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(left, "LOG(", false) == 0)
				{
					if (array.Length > 2)
					{
						throw new Exception("表达式\"" + this.c + "\"中Log函数需要一个或两个参数!");
					}
					if (array.Length == 1)
					{
						num2 = new decimal(Math.Log(Convert.ToDouble(num)));
					}
					else
					{
						num2 = new decimal(Math.Log(Convert.ToDouble(array[0]), Convert.ToDouble(array[1])));
					}
				}
				else if (Operators.CompareString(left, "LOG10(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this.c + "\"中Log10函数需要一个参数!");
					}
					num2 = new decimal(Math.Log10(Convert.ToDouble(num)));
				}
				return new decimal[]
				{
					num2
				};
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00025B8C File Offset: 0x00023D8C
		private bool a(decimal A_0)
		{
			return Convert.ToInt32(A_0) == 1;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00025BA4 File Offset: 0x00023DA4
		private decimal[] a(string A_0, string A_1, string A_2)
		{
			decimal num = 0m;
			decimal num2 = 0m;
			try
			{
				num2 = decimal.Parse(A_1);
			}
			catch (Exception ex)
			{
				if (Operators.CompareString(A_0, "NEG", false) != 0)
				{
					try
					{
						num2 = decimal.Parse(this.a[A_1]);
					}
					catch (Exception ex2)
					{
						throw new Exception("表达式\"" + this.c + "\"中含有错误的格式:" + A_1);
					}
				}
			}
			decimal num3;
			try
			{
				num3 = decimal.Parse(A_2);
			}
			catch (Exception ex3)
			{
				try
				{
					num3 = decimal.Parse(this.a[A_2]);
				}
				catch (Exception ex4)
				{
					throw new Exception("表达式\"" + this.c + "\"中含有错误的格式:" + A_1);
				}
			}
			string left = this.b;
			if (Operators.CompareString(left, "NEG", false) == 0)
			{
				num = decimal.Negate(num3);
			}
			else if (Operators.CompareString(left, "+", false) == 0)
			{
				num = decimal.Add(num2, num3);
			}
			else if (Operators.CompareString(left, "-", false) == 0)
			{
				num = decimal.Subtract(num2, num3);
			}
			else if (Operators.CompareString(left, "*", false) == 0)
			{
				num = decimal.Multiply(num2, num3);
			}
			else if (Operators.CompareString(left, "/", false) == 0)
			{
				num = decimal.Divide(num2, num3);
			}
			else if (Operators.CompareString(left, "%", false) == 0)
			{
				num = decimal.Remainder(num2, num3);
			}
			else if (Operators.CompareString(left, "^", false) == 0)
			{
				num = new decimal(Math.Pow(Convert.ToDouble(num2), Convert.ToDouble(num3)));
			}
			else
			{
				if (Operators.CompareString(left, ",", false) == 0)
				{
					return new decimal[]
					{
						num2,
						num3
					};
				}
				if (Operators.CompareString(left, "=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) == 0, 1, 0));
				}
				else if (Operators.CompareString(left, "<>", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) != 0, 1, 0));
				}
				else if (Operators.CompareString(left, "<", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) < 0, 1, 0));
				}
				else if (Operators.CompareString(left, ">", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) > 0, 1, 0));
				}
				else if (Operators.CompareString(left, ">=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) >= 0, 1, 0));
				}
				else if (Operators.CompareString(left, "<=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) <= 0, 1, 0));
				}
			}
			return new decimal[]
			{
				num
			};
		}

		// Token: 0x040002BB RID: 699
		protected const int MAX_LEVEL = 99;

		// Token: 0x040002BC RID: 700
		private NameValueCollection a;

		// Token: 0x040002BD RID: 701
		private string b;

		// Token: 0x040002BE RID: 702
		private string c;

		// Token: 0x040002BF RID: 703
		private string d;

		// Token: 0x040002C0 RID: 704
		private string e;

		// Token: 0x040002C1 RID: 705
		private static object[,] f;
	}
}
