using System;
using System.Collections.Specialized;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000B8 RID: 184
	public class Calculator
	{
		// Token: 0x0600021A RID: 538 RVA: 0x00023394 File Offset: 0x00021594
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
			Calculator.Level = array;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00023770 File Offset: 0x00021970
		public static decimal[] Eval(string expression, NameValueCollection dataProvider)
		{
			Calculator calculator = new Calculator(expression, dataProvider);
			return calculator.Calculate();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00023790 File Offset: 0x00021990
		public Calculator(string expression, NameValueCollection dataProvider)
		{
			this._expression = expression;
			this._data = dataProvider;
			this._rightValue = expression.ToUpper();
			if (this.GetIndex(this._rightValue) != -1)
			{
				throw new Exception("表达式\"" + this._expression + "\"缺少\"(\"");
			}
			this.Initialize();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000237F0 File Offset: 0x000219F0
		private void Initialize()
		{
			string empty = string.Empty;
			this.GetNext(this._rightValue, ref this._leftValue, ref this._opt, ref empty);
			this._rightValue = empty;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00023824 File Offset: 0x00021A24
		private static int GetOperatorLevel(string strOperator)
		{
			int num = 0;
			checked
			{
				int num2 = Calculator.Level.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (Operators.CompareString(Conversions.ToString(Calculator.Level[i, 0]), strOperator, false) == 0)
					{
						return Conversions.ToInteger(Calculator.Level[i, 1]);
					}
				}
				return -1;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0002387C File Offset: 0x00021A7C
		private static string GetOperator(string str)
		{
			int num = 0;
			checked
			{
				int num2 = Calculator.Level.GetLength(0) - 1;
				for (int i = num; i <= num2; i++)
				{
					if (str.StartsWith(Conversions.ToString(Calculator.Level[i, 0])))
					{
						return Conversions.ToString(Calculator.Level[i, 0]);
					}
				}
				return null;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000238D0 File Offset: 0x00021AD0
		private void GetNext(string expression, ref string left, ref string opt, ref string right)
		{
			right = expression;
			left = string.Empty;
			opt = null;
			checked
			{
				while (Operators.CompareString(right, string.Empty, false) != 0)
				{
					opt = Calculator.GetOperator(right);
					if (Operators.CompareString(opt, null, false) != 0)
					{
						right = right.Substring(opt.Length, right.Length - opt.Length);
						break;
					}
					left += Conversions.ToString(right[0]);
					right = right.Substring(1, right.Length - 1);
				}
				left = left.Trim();
				right = right.Trim();
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0002397C File Offset: 0x00021B7C
		public decimal[] Calculate()
		{
			if (Operators.CompareString(this._opt, null, false) == 0)
			{
				decimal num = 0m;
				try
				{
					num = decimal.Parse(this._leftValue);
				}
				catch (Exception ex)
				{
					try
					{
						num = decimal.Parse(this._data[this._leftValue]);
					}
					catch (Exception ex2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中含有错误的格式:" + this._leftValue);
					}
				}
				return new decimal[]
				{
					num
				};
			}
			if (Calculator.GetOperatorLevel(this._opt) != 99)
			{
				if (Operators.CompareString(this._opt, "-", false) != 0 & Operators.CompareString(this._leftValue, string.Empty, false) == 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this._expression,
						"\"中\"",
						this._opt,
						"\" 运算符的左边需要值或表达式"
					}));
				}
				if (Operators.CompareString(this._opt, "-", false) == 0 & Operators.CompareString(this._leftValue, string.Empty, false) == 0)
				{
					this._opt = "NEG";
				}
				if (Operators.CompareString(this._rightValue, string.Empty, false) == 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this._expression,
						"\"中\"",
						this._opt,
						"\" 运算符的右边需要值或表达式"
					}));
				}
				return this.CalculateTwoParms();
			}
			else
			{
				if (Operators.CompareString(this._leftValue, string.Empty, false) != 0)
				{
					throw new Exception(string.Concat(new string[]
					{
						"表达式\"",
						this._expression,
						"\"中\"",
						this._opt,
						"\" 运算符的左边不需要值或表达式"
					}));
				}
				return this.CalculateFunction();
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00023B90 File Offset: 0x00021D90
		private decimal[] CalculateFunction()
		{
			int index = this.GetIndex(this._rightValue);
			if (index == -1)
			{
				throw new Exception("表达式\"" + this._expression + "\"缺少\")\"");
			}
			string expression = this._rightValue.Substring(0, index);
			checked
			{
				if (index == this._rightValue.Length - 1)
				{
					return this.Calc(this._opt, expression);
				}
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				this._rightValue = this._rightValue.Substring(index + 1, this._rightValue.Length - index - 1);
				this.GetNext(this._rightValue, ref empty, ref empty3, ref empty2);
				decimal[] array = this.Calc(this._opt, expression);
				this._leftValue = array[array.Length - 1].ToString();
				if (Operators.CompareString(empty3, null, false) == 0)
				{
					throw new Exception("表达式\"" + this._expression + "\"中\")\"运算符的右边需要运算符");
				}
				this._opt = empty3;
				this._rightValue = empty2;
				return this.Calculate();
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00023CA4 File Offset: 0x00021EA4
		private int GetIndex(string expression)
		{
			int num = 0;
			int num2 = 0;
			checked
			{
				int num3 = expression.Length - 1;
				for (int i = num2; i <= num3; i++)
				{
					if (expression[i] == ')')
					{
						if (num == 0)
						{
							return i;
						}
						num--;
					}
					if (expression[i] == '(')
					{
						num++;
					}
				}
				return -1;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00023CF0 File Offset: 0x00021EF0
		private decimal[] CalculateTwoParms()
		{
			string empty = string.Empty;
			string text = string.Empty;
			string empty2 = string.Empty;
			this.GetNext(this._rightValue, ref empty, ref empty2, ref text);
			checked
			{
				decimal[] array;
				if (Operators.CompareString(empty2, null, false) == 0 | Calculator.GetOperatorLevel(this._opt) >= Calculator.GetOperatorLevel(empty2))
				{
					array = this.Calc(this._opt, this._leftValue, empty);
				}
				else
				{
					string text2 = empty;
					while (Calculator.GetOperatorLevel(this._opt) < Calculator.GetOperatorLevel(empty2) & Operators.CompareString(text, string.Empty, false) != 0)
					{
						text2 += empty2;
						if (Calculator.GetOperatorLevel(empty2) == 99)
						{
							int index = this.GetIndex(text);
							text2 += text.Substring(0, index + 1);
							text = text.Substring(index + 1);
						}
						this.GetNext(text, ref empty, ref empty2, ref text);
						text2 += empty;
					}
					Calculator calculator = new Calculator(text2, this._data);
					decimal[] array2 = calculator.Calculate();
					array = this.Calc(this._opt, this._leftValue, array2[array2.Length - 1].ToString());
				}
				this._leftValue = array[array.Length - 1].ToString();
				this._opt = empty2;
				this._rightValue = text;
				decimal[] array3 = this.Calculate();
				decimal[] array4 = new decimal[array.Length - 1 + array3.Length - 1 + 1];
				int num = 0;
				int num2 = array.Length - 2;
				for (int i = num; i <= num2; i++)
				{
					array4[i] = array[i];
				}
				int num3 = 0;
				int num4 = array3.Length - 1;
				for (int i = num3; i <= num4; i++)
				{
					array4[array.Length - 1 + i] = array3[i];
				}
				return array4;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00023ED4 File Offset: 0x000220D4
		private decimal[] Calc(string opt, string expression)
		{
			Calculator calculator = new Calculator(expression, this._data);
			decimal[] array = calculator.Calculate();
			checked
			{
				decimal num = array[array.Length - 1];
				decimal num2 = 0m;
				string opt2 = this._opt;
				if (Operators.CompareString(opt2, "(", false) == 0)
				{
					num2 = num;
				}
				else if (Operators.CompareString(opt2, "ROUND(", false) == 0)
				{
					if (array.Length > 2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Round函数需要一个或两个参数!");
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
				else if (Operators.CompareString(opt2, "TRUNC(", false) == 0)
				{
					if (array.Length > 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Trunc函数只需要一个参数!");
					}
					num2 = decimal.Truncate(num);
				}
				else if (Operators.CompareString(opt2, "MAX(", false) == 0)
				{
					if (array.Length < 2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Max函数至少需要两个参数!");
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
				else if (Operators.CompareString(opt2, "MIN(", false) == 0)
				{
					if (array.Length < 2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Min函数至少需要两个参数!");
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
				else if (Operators.CompareString(opt2, "ABS", false) == 0)
				{
					if (array.Length > 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Abs函数只需要一个参数!");
					}
					num2 = Math.Abs(num);
				}
				else if (Operators.CompareString(opt2, "SUM(", false) == 0)
				{
					foreach (decimal d in array)
					{
						num2 = decimal.Add(num2, d);
					}
				}
				else if (Operators.CompareString(opt2, "AVERAGE(", false) == 0)
				{
					foreach (decimal d2 in array)
					{
						num2 = decimal.Add(num2, d2);
					}
					num2 = decimal.Divide(num2, new decimal(array.Length));
				}
				else if (Operators.CompareString(opt2, "IF(", false) == 0)
				{
					if (array.Length != 3)
					{
						throw new Exception("表达式\"" + this._expression + "\"中IF函数需要三个参数!");
					}
					if (this.GetBoolean(array[0]))
					{
						num2 = array[1];
					}
					else
					{
						num2 = array[2];
					}
				}
				else if (Operators.CompareString(opt2, "NOT(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中NOT函数需要一个参数!");
					}
					if (this.GetBoolean(array[0]))
					{
						num2 = 0m;
					}
					else
					{
						num2 = 1m;
					}
				}
				else if (Operators.CompareString(opt2, "OR(", false) == 0)
				{
					if (array.Length < 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中OR函数至少需要两个参数!");
					}
					foreach (decimal d3 in array)
					{
						if (this.GetBoolean(d3))
						{
							return new decimal[]
							{
								1m
							};
						}
					}
				}
				else if (Operators.CompareString(opt2, "AND(", false) == 0)
				{
					if (array.Length < 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中AND函数至少需要两个参数!");
					}
					foreach (decimal d4 in array)
					{
						if (!this.GetBoolean(d4))
						{
							return new decimal[]
							{
								0m
							};
						}
					}
					num2 = 1m;
				}
				else if (Operators.CompareString(opt2, "SQRT(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中SQRT函数需要一个参数!");
					}
					num2 = new decimal(Math.Sqrt(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(opt2, "SIN(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Sin函数需要一个参数!");
					}
					num2 = new decimal(Math.Sin(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(opt2, "COS(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Cos函数需要一个参数!");
					}
					num2 = new decimal(Math.Cos(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(opt2, "TAN(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Tan函数需要一个参数!");
					}
					num2 = new decimal(Math.Tan(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(opt2, "EXP(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Exp函数需要一个参数!");
					}
					num2 = new decimal(Math.Exp(Convert.ToDouble(num)));
				}
				else if (Operators.CompareString(opt2, "LOG(", false) == 0)
				{
					if (array.Length > 2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Log函数需要一个或两个参数!");
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
				else if (Operators.CompareString(opt2, "LOG10(", false) == 0)
				{
					if (array.Length != 1)
					{
						throw new Exception("表达式\"" + this._expression + "\"中Log10函数需要一个参数!");
					}
					num2 = new decimal(Math.Log10(Convert.ToDouble(num)));
				}
				return new decimal[]
				{
					num2
				};
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000245DC File Offset: 0x000227DC
		private bool GetBoolean(decimal d)
		{
			return Convert.ToInt32(d) == 1;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000245F4 File Offset: 0x000227F4
		private decimal[] Calc(string opt, string leftEx, string rightEx)
		{
			decimal num = 0m;
			decimal num2 = 0m;
			try
			{
				num2 = decimal.Parse(leftEx);
			}
			catch (Exception ex)
			{
				if (Operators.CompareString(opt, "NEG", false) != 0)
				{
					try
					{
						num2 = decimal.Parse(this._data[leftEx]);
					}
					catch (Exception ex2)
					{
						throw new Exception("表达式\"" + this._expression + "\"中含有错误的格式:" + leftEx);
					}
				}
			}
			decimal num3;
			try
			{
				num3 = decimal.Parse(rightEx);
			}
			catch (Exception ex3)
			{
				try
				{
					num3 = decimal.Parse(this._data[rightEx]);
				}
				catch (Exception ex4)
				{
					throw new Exception("表达式\"" + this._expression + "\"中含有错误的格式:" + leftEx);
				}
			}
			string opt2 = this._opt;
			if (Operators.CompareString(opt2, "NEG", false) == 0)
			{
				num = decimal.Negate(num3);
			}
			else if (Operators.CompareString(opt2, "+", false) == 0)
			{
				num = decimal.Add(num2, num3);
			}
			else if (Operators.CompareString(opt2, "-", false) == 0)
			{
				num = decimal.Subtract(num2, num3);
			}
			else if (Operators.CompareString(opt2, "*", false) == 0)
			{
				num = decimal.Multiply(num2, num3);
			}
			else if (Operators.CompareString(opt2, "/", false) == 0)
			{
				num = decimal.Divide(num2, num3);
			}
			else if (Operators.CompareString(opt2, "%", false) == 0)
			{
				num = decimal.Remainder(num2, num3);
			}
			else if (Operators.CompareString(opt2, "^", false) == 0)
			{
				num = new decimal(Math.Pow(Convert.ToDouble(num2), Convert.ToDouble(num3)));
			}
			else
			{
				if (Operators.CompareString(opt2, ",", false) == 0)
				{
					return new decimal[]
					{
						num2,
						num3
					};
				}
				if (Operators.CompareString(opt2, "=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) == 0, 1, 0));
				}
				else if (Operators.CompareString(opt2, "<>", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) != 0, 1, 0));
				}
				else if (Operators.CompareString(opt2, "<", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) < 0, 1, 0));
				}
				else if (Operators.CompareString(opt2, ">", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) > 0, 1, 0));
				}
				else if (Operators.CompareString(opt2, ">=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) >= 0, 1, 0));
				}
				else if (Operators.CompareString(opt2, "<=", false) == 0)
				{
					num = Conversions.ToDecimal(Interaction.IIf(decimal.Compare(num2, num3) <= 0, 1, 0));
				}
			}
			return new decimal[]
			{
				num
			};
		}

		// Token: 0x0400027D RID: 637
		protected const int MAX_LEVEL = 99;

		// Token: 0x0400027E RID: 638
		private NameValueCollection _data;

		// Token: 0x0400027F RID: 639
		private string _opt;

		// Token: 0x04000280 RID: 640
		private string _expression;

		// Token: 0x04000281 RID: 641
		private string _leftValue;

		// Token: 0x04000282 RID: 642
		private string _rightValue;

		// Token: 0x04000283 RID: 643
		private static object[,] Level;
	}
}
