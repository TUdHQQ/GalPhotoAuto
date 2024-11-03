using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GalPhotoAuto.merge_function;
using GalPhotoAuto.My;
using GalPhotoAuto.My.Resources;
using GalPhotoAuto.Windows7DesktopIntegration;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C9 RID: 201
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		// Token: 0x06000287 RID: 647 RVA: 0x00028304 File Offset: 0x00026504
		public Form1()
		{
			base.HandleCreated += this.Form1_HandleCreated;
			base.FormClosing += this.Form1_FormClosing;
			base.Shown += this.Form1_Shown;
			base.Load += this.Form1_Load;
			this.pSubMenu = 0;
			this.pLangSubMenu = 0;
			this.iMaxLangFile = 0;
			this.InitializeComponent();
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00028380 File Offset: 0x00026580
		private void BWendWithLog()
		{
			string text = string.Format("{0} {1}({2:d2}:{3:d2}:{4:d2})", new object[]
			{
				PublicModule.iBuild,
				PublicModule.thisLang.getMultiLingual("Form1_Thread_End_Msg_1"),
				PublicModule.iUseTimeHour,
				PublicModule.iUseTimeMinute,
				PublicModule.iUseTimeSecond
			});
			PublicModule.addLog(text);
			this.NotifyIcon1.BalloonTipTitle = PublicModule.thisLang.getMultiLingual("Form1_Thread_End_Msg_2");
			this.NotifyIcon1.BalloonTipText = text;
			this.NotifyIcon1.ShowBalloonTip(2000);
			if (0 < PublicModule.strLog.Length)
			{
				text = this.TextBox1.Text;
				this.TextBox1.Text = string.Format("{0}{1}", PublicModule.strLog.ToString(), text);
			}
			Windows7taskbar.ResetWindows7Progress(this.Handle);
			IntPtr icon;
			Windows7taskbar.SetWindows7OverlayIcon(this.Handle, icon, "");
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00028478 File Offset: 0x00026678
		private void files2Move()
		{
			if (0 < PublicModule.files2.Count & 0 < PublicModule.iBuild)
			{
				try
				{
					foreach (object value in PublicModule.files2)
					{
						string text = Conversions.ToString(value);
						string text2 = text;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string text3 = Path.Combine(Path.GetDirectoryName(text2), "0_YouCanDel");
							if (!Directory.Exists(text3))
							{
								Directory.CreateDirectory(text3);
								PublicModule.addLog(PublicModule.thisLang.getMultiLingual("Form1_Thread_Mkdir_Msg") + text3);
							}
							text3 = Path.Combine(Path.GetDirectoryName(text2), "0_YouCanDel") + Conversions.ToString(Path.DirectorySeparatorChar) + Path.GetFileName(text2);
							try
							{
								if (File.Exists(text2))
								{
									File.Move(text2, text3);
								}
							}
							catch (Exception ex)
							{
								PublicModule.addLog(ex.Message);
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

		// Token: 0x0600028A RID: 650 RVA: 0x00028598 File Offset: 0x00026798
		private void files3MoveDirectory()
		{
			checked
			{
				if (0 < PublicModule.files3.Count & 0 < PublicModule.iBuild)
				{
					try
					{
						foreach (object obj in PublicModule.files3)
						{
							string[] array = (string[])obj;
							string text = array[0];
							string text2 = array[1];
							string[] array2 = text2.Split(new char[]
							{
								Path.DirectorySeparatorChar
							});
							string text3 = array2[0];
							int num = 1;
							int num2 = array2.Count<string>() - 2;
							for (int i = num; i <= num2; i++)
							{
								text3 = Path.Combine(text3, array2[i]);
								if (!Directory.Exists(text3))
								{
									Directory.CreateDirectory(text3);
									PublicModule.addLog(PublicModule.thisLang.getMultiLingual("Form1_Thread_Mkdir_Msg") + text3);
								}
							}
							try
							{
								if (Directory.Exists(text))
								{
									Directory.Move(text, text2);
								}
							}
							catch (Exception ex)
							{
								PublicModule.addLog(ex.Message);
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

		// Token: 0x0600028B RID: 651 RVA: 0x000286C4 File Offset: 0x000268C4
		private void ALL_END()
		{
			PublicModule.pLeft.Clear();
			PublicModule.pRight.Clear();
			PublicModule.files1.Clear();
			PublicModule.files2.Clear();
			PublicModule.files3.Clear();
			PublicModule.strLog.Clear();
			PublicModule.iCount = 0;
			PublicModule.iMaxToBW = 0;
			PublicModule.iNow = 0;
			PublicModule.iBuild = 0;
			PublicModule.iUseTime = 0;
			PublicModule.iUseTimeSecond = 0;
			PublicModule.iUseTimeMinute = 0;
			PublicModule.iUseTimeHour = 0;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00028740 File Offset: 0x00026940
		public void ShowText1Msg()
		{
			string text = this.TextBox1.Text;
			this.TextBox1.Text = string.Format("{0}{1}", PublicModule.strLog.ToString(), text);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0002877C File Offset: 0x0002697C
		private bool BW2Check2Mode1()
		{
			if (0 < this.ListBox2.Items.Count & 0 < this.ListBox3.Items.Count)
			{
				ListBox listBox = this.ListBox2;
				PublicModule.makeFileList(ref listBox, ref PublicModule.pLeft);
				this.ListBox2 = listBox;
				listBox = this.ListBox3;
				PublicModule.makeFileList(ref listBox, ref PublicModule.pRight);
				this.ListBox3 = listBox;
			}
			if (0 < PublicModule.pLeft.Count & 0 < PublicModule.pRight.Count)
			{
				return true;
			}
			PublicModule.addLog(PublicModule.thisLang.getMultiLingual("Form1_ListBox_23_Not_Conform_Msg"));
			return false;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0002881C File Offset: 0x00026A1C
		private bool BW2Check2Mode2(string sSpeT = "")
		{
			if (0 < this.ListBox4.Items.Count)
			{
				if (!string.IsNullOrWhiteSpace(sSpeT))
				{
					PublicModule.sSpecialExt = sSpeT;
					this.ToolStripStatusLabel1.Text = sSpeT;
				}
				ListBox listBox = this.ListBox4;
				PublicModule.makeFileList(ref listBox, ref PublicModule.files1);
				this.ListBox4 = listBox;
			}
			if (0 < PublicModule.files1.Count)
			{
				return true;
			}
			PublicModule.addLog(PublicModule.thisLang.getMultiLingual("Form1_ListBox_4_Not_Conform_Msg"));
			return false;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00028894 File Offset: 0x00026A94
		private void addMenuToSysMenu()
		{
			int systemMenu = PublicModule.GetSystemMenu(this.Handle, 0);
			this.pSubMenu = PublicModule.CreatePopupMenu();
			int hMenu = systemMenu;
			int nPosition = 0;
			int wFlags = 3072;
			int wIDNewItem = 0;
			string text = null;
			PublicModule.InsertMenu(hMenu, nPosition, wFlags, wIDNewItem, ref text);
			int hMenu2 = systemMenu;
			int nPosition2 = 0;
			int wFlags2 = 1040;
			int wIDNewItem2 = this.pSubMenu;
			text = PublicModule.thisLang.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(PublicModule.iCpuProcessor) + ")";
			PublicModule.InsertMenu(hMenu2, nPosition2, wFlags2, wIDNewItem2, ref text);
			int hMenu3 = systemMenu;
			int flagsw = 1024;
			int idnewItem = 0;
			text = null;
			PublicModule.AppendMenu(hMenu3, flagsw, idnewItem, ref text);
			int hMenu4 = systemMenu;
			int flagsw2 = 1024;
			int idnewItem2 = 5999;
			text = PublicModule.thisLang.getMultiLingual("MENU_About_Text") + "(&A)";
			PublicModule.AppendMenu(hMenu4, flagsw2, idnewItem2, ref text);
			int num = 1;
			int iMaxCpuProcessor = PublicModule.iMaxCpuProcessor;
			checked
			{
				for (int i = num; i <= iMaxCpuProcessor; i++)
				{
					int hMenu5 = this.pSubMenu;
					int flagsw3 = 16;
					int idnewItem3 = 6000 + i;
					text = Conversions.ToString(i);
					PublicModule.AppendMenu(hMenu5, flagsw3, idnewItem3, ref text);
					if (i == PublicModule.iCpuProcessor)
					{
						PublicModule.CheckMenuItem(this.pSubMenu, 6000 + i, 8);
					}
				}
				int hMenu6 = systemMenu;
				int flagsw4 = 1024;
				int idnewItem4 = 0;
				text = null;
				PublicModule.AppendMenu(hMenu6, flagsw4, idnewItem4, ref text);
				this.pLangSubMenu = PublicModule.CreatePopupMenu();
				int hMenu7 = systemMenu;
				int flagsw5 = 1040;
				int idnewItem5 = this.pLangSubMenu;
				text = "Language";
				PublicModule.AppendMenu(hMenu7, flagsw5, idnewItem5, ref text);
				string sysCurrentCulture = PublicModule.getSysCurrentCulture();
				bool flag = false;
				if (Directory.Exists("lang"))
				{
					this.lang_xml_files = Directory.GetFiles("lang");
					this.iMaxLangFile = this.lang_xml_files.Length;
					if (this.iMaxLangFile > 0)
					{
						int num2 = Information.LBound(this.lang_xml_files, 1);
						int num3 = Information.UBound(this.lang_xml_files, 1);
						for (int j = num2; j <= num3; j++)
						{
							using (DataSet dataSet = new DataSet())
							{
								dataSet.ReadXml(this.lang_xml_files[j]);
								string text2 = dataSet.Tables["lang"].Rows[0]["name"].ToString();
								PublicModule.AppendMenu(this.pLangSubMenu, 16, 6500 + j, ref text2);
								if (!flag && 0 == string.Compare(sysCurrentCulture, Path.GetFileNameWithoutExtension(this.lang_xml_files[j]), StringComparison.Ordinal))
								{
									PublicModule.CheckMenuItem(this.pLangSubMenu, 6500 + j, 8);
									flag = true;
								}
							}
						}
					}
				}
				else
				{
					int hMenu8 = this.pLangSubMenu;
					int flagsw6 = 16;
					int idnewItem6 = -1;
					text = "None";
					PublicModule.AppendMenu(hMenu8, flagsw6, idnewItem6, ref text);
				}
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00028B0C File Offset: 0x00026D0C
		protected override void WndProc(ref Message m)
		{
			checked
			{
				if (m.Msg == 274)
				{
					int num = m.WParam.ToInt32();
					int num2 = num;
					if (num2 == 5999)
					{
						MyProject.get_Forms().get_AboutBox1().ShowDialog();
					}
					else if (num2 >= 6001 && num2 <= 6000 + PublicModule.iMaxCpuProcessor)
					{
						PublicModule.iCpuProcessor = num - 6000;
						int num3 = 6001;
						int num4 = 6000 + PublicModule.iMaxCpuProcessor;
						for (int i = num3; i <= num4; i++)
						{
							PublicModule.CheckMenuItem(this.pSubMenu, i, 0);
						}
						PublicModule.CheckMenuItem(this.pSubMenu, num, 8);
						int systemMenu = PublicModule.GetSystemMenu(this.Handle, 0);
						int nPosition = 0;
						int wFlags = 1040;
						int wIDNewItem = this.pSubMenu;
						string text = PublicModule.thisLang.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(PublicModule.iCpuProcessor) + ")";
						PublicModule.ModifyMenu(systemMenu, nPosition, wFlags, wIDNewItem, ref text);
						PublicModule.galConfig.Update("iUseCpuCore", Conversions.ToString(PublicModule.iCpuProcessor));
						PublicModule.galConfig.Save();
					}
					else if (num2 >= 6500 && num2 <= 6500 + this.iMaxLangFile)
					{
						this.Hide();
						bool flag = false;
						if (MyProject.get_Forms().get_Form3().Visible)
						{
							MyProject.get_Forms().get_Form3().Hide();
							flag = true;
						}
						int num5 = 6500;
						int num6 = 6500 + this.iMaxLangFile;
						for (int j = num5; j <= num6; j++)
						{
							PublicModule.CheckMenuItem(this.pLangSubMenu, j, 0);
						}
						PublicModule.CheckMenuItem(this.pLangSubMenu, num, 8);
						PublicModule.strCultureLangName = Path.GetFileNameWithoutExtension(this.lang_xml_files[num - 6500]);
						PublicModule.thisLang.setMultiLingual(this.lang_xml_files[num - 6500]);
						this.setMultiLingualGui();
						PublicModule.galConfig.Update("sLastLanguage", PublicModule.strCultureLangName);
						PublicModule.galConfig.Save();
						if (flag)
						{
							MyProject.get_Forms().get_Form3().Show();
						}
						this.Show();
					}
				}
				else if (m.Msg == 273)
				{
					ulong num7 = (ulong)m.WParam.ToInt64();
					uint num8 = (uint)(num7 & unchecked((ulong)-1));
					if (unchecked((ulong)(num8 >> 16)) == 6144UL)
					{
						switch ((uint)(unchecked((ulong)num8) & 65535UL))
						{
						case 500U:
							this.ThumbButtonId500();
							break;
						case 501U:
							this.ThumbButtonId501();
							break;
						case 502U:
							this.ThumbButtonId502();
							break;
						}
					}
				}
				base.WndProc(ref m);
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00028DA0 File Offset: 0x00026FA0
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				PublicModule.bWaitCancelAsync = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				if (Interaction.MsgBox(PublicModule.thisLang.getMultiLingual("Form1_Check_Close_Msg_1"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, PublicModule.thisLang.getMultiLingual("Form1_Check_Close_Msg_2")) == MsgBoxResult.Yes)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
					this.BackgroundWorker1.CancelAsync();
					this.BackgroundWorker2.CancelAsync();
				}
				else
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					e.Cancel = true;
					PublicModule.bWaitCancelAsync = false;
				}
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00028E85 File Offset: 0x00027085
		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(1))
			{
				((TextBox)sender).SelectAll();
				e.Handled = true;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00028EA8 File Offset: 0x000270A8
		private void ListBox1_DragEnter(object sender, DragEventArgs e)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(e.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00028ED8 File Offset: 0x000270D8
		private void ListBox2_DragEnter(object sender, DragEventArgs e)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(e.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00028F08 File Offset: 0x00027108
		private void ListBox3_DragEnter(object sender, DragEventArgs e)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(e.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00028F38 File Offset: 0x00027138
		private void ListBox4_DragEnter(object sender, DragEventArgs e)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(e.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00028F68 File Offset: 0x00027168
		private void ListBox1_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			int num = Information.LBound(array, 1);
			int num2 = Information.UBound(array, 1);
			checked
			{
				for (int i = num; i <= num2; i++)
				{
					string text = array[i];
					if (Directory.Exists(text))
					{
						this.ListBox1.Items.Add(text);
					}
					else if (File.Exists(text))
					{
						this.ListBox1.Items.Add(text);
					}
				}
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00028FE0 File Offset: 0x000271E0
		private void ListBox2_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			int num = Information.LBound(array, 1);
			int num2 = Information.UBound(array, 1);
			checked
			{
				for (int i = num; i <= num2; i++)
				{
					string text = array[i];
					if (File.Exists(text))
					{
						this.ListBox2.Items.Add(text);
					}
				}
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0002903C File Offset: 0x0002723C
		private void ListBox3_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			int num = Information.LBound(array, 1);
			int num2 = Information.UBound(array, 1);
			checked
			{
				for (int i = num; i <= num2; i++)
				{
					string text = array[i];
					if (File.Exists(text))
					{
						this.ListBox3.Items.Add(text);
					}
				}
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00029098 File Offset: 0x00027298
		private void ListBox4_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			int num = Information.LBound(array, 1);
			int num2 = Information.UBound(array, 1);
			checked
			{
				for (int i = num; i <= num2; i++)
				{
					string text = array[i];
					if (Directory.Exists(text))
					{
						this.ListBox4.Items.Add(text);
					}
				}
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000290F3 File Offset: 0x000272F3
		private void ListBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.ListBox1.SelectedIndex > -1)
			{
				this.ListBox1.Items.RemoveAt(this.ListBox1.SelectedIndex);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0002912B File Offset: 0x0002732B
		private void ListBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.ListBox2.SelectedIndex > -1)
			{
				this.ListBox2.Items.RemoveAt(this.ListBox2.SelectedIndex);
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00029163 File Offset: 0x00027363
		private void ListBox3_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.ListBox3.SelectedIndex > -1)
			{
				this.ListBox3.Items.RemoveAt(this.ListBox3.SelectedIndex);
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0002919B File Offset: 0x0002739B
		private void ListBox4_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.ListBox4.SelectedIndex > -1)
			{
				this.ListBox4.Items.RemoveAt(this.ListBox4.SelectedIndex);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000291D3 File Offset: 0x000273D3
		private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.BackgroundWorker1.IsBusy)
			{
				this.TabControl1.SelectedTab = this.TabPage2;
			}
			else if (this.BackgroundWorker2.IsBusy)
			{
				this.TabControl1.SelectedTab = this.TabPage4;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00029214 File Offset: 0x00027414
		private void RadioButton11_MouseClick(object sender, EventArgs e)
		{
			if (this.ColorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				this.Panel6.BackColor = this.ColorDialog1.Color;
				this.ToolTip1.SetToolTip(this.Panel6, this.Panel6.BackColor.ToString());
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00029270 File Offset: 0x00027470
		private void RadioButton12_MouseClick(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.Hide();
			Screen primaryScreen = Screen.PrimaryScreen;
			Rectangle bounds = primaryScreen.Bounds;
			int width = bounds.Width;
			int height = bounds.Height;
			Image image = new Bitmap(width, height);
			Graphics graphics = Graphics.FromImage(image);
			Graphics graphics2 = graphics;
			Point point = new Point(0, 0);
			Point upperLeftSource = point;
			Point point2 = new Point(0, 0);
			Point upperLeftDestination = point2;
			Size blockRegionSize = new Size(width, height);
			graphics2.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
			this.Show();
			this.WindowState = FormWindowState.Normal;
			MyProject.get_Forms().get_Form2().WindowState = FormWindowState.Minimized;
			MyProject.get_Forms().get_Form2().Hide();
			MyProject.get_Forms().get_Form2().BackgroundImage = image;
			MyProject.get_Forms().get_Form2().Show();
			MyProject.get_Forms().get_Form2().WindowState = FormWindowState.Maximized;
			graphics.Dispose();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00029341 File Offset: 0x00027541
		private void Panel4_MouseClick(object sender, EventArgs e)
		{
			this.RadioButton9.Checked = true;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0002934F File Offset: 0x0002754F
		private void Panel5_MouseClick(object sender, EventArgs e)
		{
			this.RadioButton10.Checked = true;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0002935D File Offset: 0x0002755D
		private void Panel6_MouseClick(object sender, EventArgs e)
		{
			this.RadioButton11_MouseClick(RuntimeHelpers.GetObjectValue(sender), e);
			this.RadioButton11.Checked = true;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00029378 File Offset: 0x00027578
		private void Panel7_MouseClick(object sender, EventArgs e)
		{
			this.RadioButton12_MouseClick(RuntimeHelpers.GetObjectValue(sender), e);
			this.RadioButton12.Checked = true;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00029393 File Offset: 0x00027593
		private void NumericUpDown5_MouseClick(object sender, EventArgs e)
		{
			this.RadioButton6.Checked = true;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000293A4 File Offset: 0x000275A4
		private void setToolTip1()
		{
			this.ToolTip1.SetToolTip(this.Panel4, this.Panel4.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel5, this.Panel5.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel6, this.Panel6.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel7, this.Panel7.BackColor.ToString());
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0002945C File Offset: 0x0002765C
		private void Form1_Shown(object sender, EventArgs e)
		{
			THUMBBUTTON[] array = new THUMBBUTTON[3];
			array[0].dwMask = (THBMASK)14;
			array[0].iId = 500U;
			array[0].hIcon = Resources.play.Handle;
			array[0].szTip = "Go";
			array[0].dwFlags = THBFLAGS.THBF_ENABLED;
			array[1].dwMask = (THBMASK)14;
			array[1].iId = 501U;
			array[1].hIcon = Resources.pause.Handle;
			array[1].szTip = "Pause";
			array[1].dwFlags = THBFLAGS.THBF_ENABLED;
			array[2].dwMask = (THBMASK)14;
			array[2].iId = 502U;
			array[2].hIcon = Resources._stop.Handle;
			array[2].szTip = "Stop";
			array[2].dwFlags = THBFLAGS.THBF_ENABLED;
			Windows7taskbar.AddWindows7ThumbBarButtons(this.Handle, array.Length, array);
			PublicModule.addChangeWindowMessageFilter();
			if (!File.Exists(this.myLocalLanguage))
			{
				this.TextBox1.Text = Conversions.ToString(DateTime.Now) + " : " + this.myLocalLanguage + " file not found.\r\n";
			}
			checked
			{
				this.ComboBox2.Items.RemoveAt(this.ComboBox2.Items.Count - 1);
				this.ComboBox2.Items.RemoveAt(this.ComboBox2.Items.Count - 1);
				base.Text += " B.Ver";
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00029610 File Offset: 0x00027810
		private void ThumbButtonId500()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				PublicModule.bWaitCancelAsync = false;
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00029664 File Offset: 0x00027864
		private void ThumbButtonId501()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				PublicModule.bWaitCancelAsync = true;
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000296B8 File Offset: 0x000278B8
		private void ThumbButtonId502()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				this.BackgroundWorker1.CancelAsync();
				this.BackgroundWorker2.CancelAsync();
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
				PublicModule.bWaitCancelAsync = false;
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00029720 File Offset: 0x00027920
		private void DoubleBufferTreeView1_MouseLeave(object sender, EventArgs e)
		{
			if (this.DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectNotEqual(this.DoubleBufferTreeView1.SelectedNode.Tag, Form1.MergeOptionType.none, false))
			{
				this.DoubleBufferTreeView1.SelectedNode.ForeColor = SystemColors.HighlightText;
				this.DoubleBufferTreeView1.SelectedNode.BackColor = SystemColors.HotTrack;
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00029784 File Offset: 0x00027984
		private void DoubleBufferTreeView1_MouseClick(object sender, EventArgs e)
		{
			if (this.DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectNotEqual(this.DoubleBufferTreeView1.SelectedNode.Tag, Form1.MergeOptionType.none, false))
			{
				this.DoubleBufferTreeView1.SelectedNode.ForeColor = this.DoubleBufferTreeView1.ForeColor;
				this.DoubleBufferTreeView1.SelectedNode.BackColor = this.DoubleBufferTreeView1.BackColor;
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000297F4 File Offset: 0x000279F4
		private void Form1_HandleCreated(object sender, EventArgs e)
		{
			Windows7taskbar.Initialization();
			this.GetOrAddConfig();
			string text = PublicModule.strCultureLangName;
			this.myLocalLanguage = Path.Combine("lang", text + ".xml");
			if (!File.Exists(this.myLocalLanguage))
			{
				text = PublicModule.getSysCurrentCulture();
				this.myLocalLanguage = Path.Combine("lang", text + ".xml");
			}
			if (File.Exists(this.myLocalLanguage))
			{
				PublicModule.strCultureLangName = text;
				PublicModule.thisLang = new MultipleLanguages(this.myLocalLanguage);
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(PublicModule.strCultureLangName);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false);
			}
			else
			{
				PublicModule.thisLang = new MultipleLanguages("");
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000298C4 File Offset: 0x00027AC4
		private void setMultiLingualGui()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(PublicModule.strCultureLangName);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false);
			this.Text = PublicModule.thisLang.getMultiLingual("GUI_Form1_Text");
			this.TabPage1.Text = PublicModule.thisLang.getMultiLingual("GUI_TabPage1_Text");
			this.Button1.Text = PublicModule.thisLang.getMultiLingual("GUI_Button1_Text");
			this.TabPage2.Text = PublicModule.thisLang.getMultiLingual("GUI_TabPage2_Text");
			this.RadioButton1.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton1_Text");
			this.RadioButton2.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton2_Text");
			this.RadioButton9.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton9_Text");
			this.RadioButton10.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton10_Text");
			this.RadioButton11.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton11_Text");
			this.RadioButton12.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton12_Text");
			this.RadioButton3.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton3_Text");
			this.Label1.Text = PublicModule.thisLang.getMultiLingual("GUI_Label1_Text");
			this.Label2.Text = PublicModule.thisLang.getMultiLingual("GUI_Label2_Text");
			this.Label3.Text = PublicModule.thisLang.getMultiLingual("GUI_Label3_Text");
			this.Label4.Text = PublicModule.thisLang.getMultiLingual("GUI_Label4_Text");
			this.RadioButton4.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton4_Text");
			this.RadioButton13.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton13_Text");
			this.Label6.Text = PublicModule.thisLang.getMultiLingual("GUI_Label6_Text");
			this.RadioButton14.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton14_Text");
			this.Button2.Text = PublicModule.thisLang.getMultiLingual("GUI_Button2_Text");
			this.GroupBox1.Text = PublicModule.thisLang.getMultiLingual("GUI_GroupBox1_Text");
			this.ComboBox1.Items[0] = PublicModule.thisLang.getMultiLingual("GUI_ComboBox1_Text");
			this.ComboBox2.Items[0] = PublicModule.thisLang.getMultiLingual("GUI_ComboBox2_Text");
			this.ComboBox3.Items[0] = PublicModule.thisLang.getMultiLingual("GUI_ComboBox3_Text");
			this.RadioButton15.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton15_Text");
			this.RadioButton18.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton18_Text");
			this.RadioButton19.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton19_Text");
			this.Label7.Text = PublicModule.thisLang.getMultiLingual("GUI_Label7_Text");
			this.RadioButton20.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton20_Text");
			this.RadioButton21.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton21_Text");
			this.RadioButton22.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton22_Text");
			this.Label8.Text = PublicModule.thisLang.getMultiLingual("GUI_Label8_Text");
			this.CheckBox5.Text = PublicModule.thisLang.getMultiLingual("GUI_CheckBox5_Text");
			MyProject.get_Forms().get_Form2().updateLabelText();
			this.TabPage5.Text = PublicModule.thisLang.getMultiLingual("GUI_TabPage5_Text");
			this.GroupBox2.Text = PublicModule.thisLang.getMultiLingual("GUI_GroupBox2_Text");
			this.CheckBox3.Text = PublicModule.thisLang.getMultiLingual("GUI_CheckBox3_Text");
			this.Button5.Text = PublicModule.thisLang.getMultiLingual("GUI_Button5_Text");
			this.Button4.Text = PublicModule.thisLang.getMultiLingual("GUI_Button4_Text");
			this.Button6.Text = PublicModule.thisLang.getMultiLingual("GUI_Button6_Text");
			this.CheckBox4.Text = PublicModule.thisLang.getMultiLingual("GUI_CheckBox4_Text");
			this.GroupBox3.Text = PublicModule.thisLang.getMultiLingual("GUI_GroupBox3_Text");
			this.TabPage4.Text = PublicModule.thisLang.getMultiLingual("GUI_TabPage4_Text");
			this.Label5.Text = PublicModule.thisLang.getMultiLingual("GUI_Label5_Text");
			this.CheckBox2.Text = PublicModule.thisLang.getMultiLingual("GUI_CheckBox2_Text");
			this.Button3.Text = PublicModule.thisLang.getMultiLingual("GUI_Button3_Text");
			this.TabPage3.Text = PublicModule.thisLang.getMultiLingual("GUI_TabPage3_Text");
			this.Button7.Text = PublicModule.thisLang.getMultiLingual("GUI_Button7_Text");
			int systemMenu = PublicModule.GetSystemMenu(this.Handle, 0);
			int hMenu = systemMenu;
			int nPosition = 0;
			int wFlags = 1040;
			int wIDNewItem = this.pSubMenu;
			string text = PublicModule.thisLang.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(PublicModule.iCpuProcessor) + ")";
			PublicModule.ModifyMenu(hMenu, nPosition, wFlags, wIDNewItem, ref text);
			int hMenu2 = systemMenu;
			int nPosition2 = 10;
			int wFlags2 = 1024;
			int wIDNewItem2 = 5999;
			text = PublicModule.thisLang.getMultiLingual("MENU_About_Text") + "(&A)";
			PublicModule.ModifyMenu(hMenu2, nPosition2, wFlags2, wIDNewItem2, ref text);
			this.ToolStripMenuItem1.Text = PublicModule.thisLang.getMultiLingual("MENU_ToolStripMenuItem1_Text");
			this.ToolStripMenuItem2.Text = PublicModule.thisLang.getMultiLingual("MENU_ToolStripMenuItem2_Text");
			this.NotifyIcon1.Text = PublicModule.thisLang.getMultiLingual("GUI_Form1_Text");
			this.CheckBox6.Text = PublicModule.thisLang.getMultiLingual("GUI_CheckBox6_Text");
			this.RadioButton7.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton7_Text");
			this.RadioButton8.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton8_Text");
			this.RadioButton25.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton25_Text");
			this.RadioButton26.Text = PublicModule.thisLang.getMultiLingual("GUI_RadioButton26_Text");
			this.Label9.Text = PublicModule.thisLang.getMultiLingual("GUI_Label9_Text");
			this.CheckTreeView1AddNodes();
			int num = 10;
			Point location = this.FlowLayoutPanel1.Location;
			checked
			{
				location.X = num + this.RadioButton2.Location.X + this.RadioButton2.Width;
				this.FlowLayoutPanel1.Location = location;
				location = this.FlowLayoutPanel2.Location;
				location.X = num + this.RadioButton3.Location.X + this.RadioButton3.Width;
				this.FlowLayoutPanel2.Location = location;
				location = this.Panel2.Location;
				location.X = num + this.RadioButton4.Location.X + this.RadioButton4.Width;
				this.Panel2.Location = location;
				location = this.FlowLayoutPanel3.Location;
				location.X = this.RadioButton13.Location.X + this.RadioButton13.Width;
				this.FlowLayoutPanel3.Location = location;
				location = this.FlowLayoutPanel5.Location;
				location.X = this.RadioButton15.Location.X + this.RadioButton15.Width;
				this.FlowLayoutPanel5.Location = location;
				location = this.FlowLayoutPanel7.Location;
				location.X = this.RadioButton20.Location.X + this.RadioButton20.Width;
				this.FlowLayoutPanel7.Location = location;
				location = this.FlowLayoutPanel9.Location;
				location.X = this.RadioButton7.Location.X + this.RadioButton7.Width;
				this.FlowLayoutPanel9.Location = location;
				location = this.Panel10.Location;
				location.X = this.Label9.Location.X + this.Label9.Width;
				this.Panel10.Location = location;
				ComboBox comboBox = this.ComboBox2;
				PublicModule.ResetComboBoxWidth(ref comboBox);
				this.ComboBox2 = comboBox;
				comboBox = this.ComboBox3;
				PublicModule.ResetComboBoxWidth(ref comboBox);
				this.ComboBox3 = comboBox;
				num = this.Panel8.PreferredSize.Width - 15;
				this.SplitterLabel1.Width = num;
				this.SplitterLabel2.Width = num;
				this.SplitterLabel3.Width = num;
				this.SplitterLabel4.Width = num;
				this.SplitterLabel5.Width = num;
				this.SplitterLabel6.Width = num;
				this.SplitterLabel7.Width = num;
				this.SplitterLabel8.Width = num;
				MyProject.get_Forms().get_Form3().initLanguage();
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0002A208 File Offset: 0x00028408
		private void GetOrAddConfig()
		{
			bool flag = false;
			string text = PublicModule.galConfig.getValue("iThreadWaitingTime");
			if (Versioned.IsNumeric(text))
			{
				PublicModule.iThreadWaitTime = Conversions.ToInteger(text);
			}
			else
			{
				PublicModule.galConfig.Remove("iThreadWaitingTime");
				PublicModule.galConfig.Add("iThreadWaitingTime", "100");
				PublicModule.iThreadWaitTime = 100;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iUseCpuCore");
			if (Versioned.IsNumeric(text))
			{
				PublicModule.iCpuProcessor = Conversions.ToInteger(text);
			}
			else
			{
				PublicModule.galConfig.Remove("iUseCpuCore");
				PublicModule.galConfig.Add("iUseCpuCore", Conversions.ToString(PublicModule.iMaxCpuProcessor));
				PublicModule.iCpuProcessor = PublicModule.iMaxCpuProcessor;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("sLastLanguage");
			if (string.IsNullOrEmpty(text))
			{
				PublicModule.galConfig.Remove("sLastLanguage");
				text = PublicModule.getSysCurrentCulture();
				PublicModule.galConfig.Add("sLastLanguage", text);
				PublicModule.strCultureLangName = text;
				flag = true;
			}
			else
			{
				PublicModule.strCultureLangName = text;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown5");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown5.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown5");
				PublicModule.galConfig.Add("iNumUpDown5", "100");
				this.NumericUpDown5.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown6");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown6.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown6");
				PublicModule.galConfig.Add("iNumUpDown6", "100");
				this.NumericUpDown6.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("p2SaveBitmapFormat");
			if (Versioned.IsNumeric(text))
			{
				this.ComboBox4.SelectedIndex = Conversions.ToInteger(text);
			}
			else
			{
				PublicModule.galConfig.Remove("p2SaveBitmapFormat");
				PublicModule.galConfig.Add("p2SaveBitmapFormat", "0");
				flag = true;
				this.ComboBox4.SelectedIndex = 0;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown13");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown13.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown13");
				PublicModule.galConfig.Add("iNumUpDown13", "100");
				this.NumericUpDown13.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown8");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown8.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown8");
				PublicModule.galConfig.Add("iNumUpDown8", "100");
				this.NumericUpDown8.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown12");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown12.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown12");
				PublicModule.galConfig.Add("iNumUpDown12", "100");
				this.NumericUpDown12.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("i2CheckHash");
			if (Versioned.IsNumeric(text))
			{
				PublicModule.i2CheckHash = Conversions.ToInteger(Conversion.Int(text));
			}
			else
			{
				PublicModule.galConfig.Remove("i2CheckHash");
				PublicModule.galConfig.Add("i2CheckHash", "0");
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown16");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown16.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown16");
				PublicModule.galConfig.Add("iNumUpDown16", "100");
				this.NumericUpDown16.Value = 100m;
				flag = true;
			}
			text = PublicModule.galConfig.getValue("iNumUpDown17");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown17.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				PublicModule.galConfig.Remove("iNumUpDown17");
				PublicModule.galConfig.Add("iNumUpDown17", "100");
				this.NumericUpDown17.Value = 100m;
				flag = true;
			}
			if (flag)
			{
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0002A6A0 File Offset: 0x000288A0
		private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			this.ALL_END();
			if (this.BackgroundWorker1.CancellationPending)
			{
				e.Cancel = true;
			}
			else if (this.RadioButton2.Checked)
			{
				Form1 form = this;
				if (BW1.TransparentImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton3.Checked)
			{
				Form1 form = this;
				if (BW1.cutImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton4.Checked)
			{
				Form1 form = this;
				if (BW1.scan32BitImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton13.Checked)
			{
				Form1 form = this;
				ArrayList arrayList = (ArrayList)e.Argument;
				if (BW1.ConvertImageFormatToX(ref form, ref arrayList))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton14.Checked)
			{
				Form1 form = this;
				if (BW1.checkBlackAlphaCutImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton15.Checked)
			{
				Form1 form = this;
				if (BW1.defineWidthCutImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton20.Checked)
			{
				Form1 form = this;
				if (BW1.defineHeightCutImage(ref form))
				{
					e.Cancel = true;
				}
			}
			else if (this.RadioButton7.Checked)
			{
				Form1 form = this;
				if (BW1.reSizeImage(ref form))
				{
					e.Cancel = true;
				}
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0002A7F8 File Offset: 0x000289F8
		private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Button2.Text = Conversions.ToString(PublicModule.iBuild);
			checked
			{
				if (PublicModule.iNow > PublicModule.iMaxToBW)
				{
					PublicModule.iMaxToBW += PublicModule.iNow / 2;
				}
				if (0 == e.ProgressPercentage)
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.INDETERMINATE);
				}
				else
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					Windows7taskbar.SetWindows7Progress(this.Handle, PublicModule.iNow, PublicModule.iMaxToBW);
				}
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0002A870 File Offset: 0x00028A70
		private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			PublicModule.sSpecialExt = string.Empty;
			PublicModule.sGameExe = string.Empty;
			this.ToolStripStatusLabel1.Text = string.Empty;
			this.ToolStripStatusLabel2.Text = string.Empty;
			if (!e.Cancelled)
			{
				if (this.CheckBox5.Checked)
				{
					try
					{
						foreach (object value in PublicModule.files2)
						{
							string text = Conversions.ToString(value);
							try
							{
								if (File.Exists(text))
								{
									File.Delete(text);
								}
							}
							catch (Exception ex)
							{
								PublicModule.addLog(ex.Message + " : " + text);
							}
						}
						goto IL_BF;
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
				this.files2Move();
			}
			IL_BF:
			this.Button2.Text = PublicModule.thisLang.getMultiLingual("GUI_Button2_Text");
			this.GroupBox1.Enabled = true;
			this.CheckBox5.Enabled = true;
			this.Timer1.Stop();
			this.BWendWithLog();
			this.ToolStripStatusLabel5.Text = "00:00:00";
			PublicModule.form1box4directorylist.Clear();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0002A9B8 File Offset: 0x00028BB8
		private void CheckTreeView1AddNodes()
		{
			Color backColor = Color.FromArgb(246, 246, 246);
			string text = string.Empty;
			if (this.DoubleBufferTreeView1.SelectedNode != null)
			{
				text = this.DoubleBufferTreeView1.SelectedNode.Name;
			}
			this.DoubleBufferTreeView1.BeginUpdate();
			this.DoubleBufferTreeView1.Nodes.Clear();
			TreeNode treeNode = new TreeNode("常规合成规则", new TreeNode[]
			{
				new TreeNode("one_xy_offset", new TreeNode[]
				{
					new TreeNode
					{
						Name = "one_100",
						Tag = Form1.MergeOptionType.one_100,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_100")
					},
					new TreeNode
					{
						Name = "one_101",
						Tag = Form1.MergeOptionType.one_101,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_101")
					},
					new TreeNode
					{
						Name = "one_102",
						Tag = Form1.MergeOptionType.one_102,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_102")
					},
					new TreeNode
					{
						Name = "one_103",
						Tag = Form1.MergeOptionType.one_103,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_103")
					},
					new TreeNode
					{
						Name = "one_112",
						Tag = Form1.MergeOptionType.one_112,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_112")
					},
					new TreeNode
					{
						Name = "one_109",
						Tag = Form1.MergeOptionType.one_109,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_109")
					},
					new TreeNode
					{
						Name = "one_120",
						Tag = Form1.MergeOptionType.one_120,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_120")
					}
				})
				{
					Name = "one_xy_offset",
					Tag = Form1.MergeOptionType.none,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_xy_offset"),
					BackColor = backColor
				},
				new TreeNode("one_name_with_m", new TreeNode[]
				{
					new TreeNode
					{
						Name = "one_117",
						Tag = Form1.MergeOptionType.one_117,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_117")
					},
					new TreeNode
					{
						Name = "one_118",
						Tag = Form1.MergeOptionType.one_118,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_118")
					},
					new TreeNode
					{
						Name = "one_104",
						Tag = Form1.MergeOptionType.one_104,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_104")
					},
					new TreeNode
					{
						Name = "one_121",
						Tag = Form1.MergeOptionType.one_121,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_121")
					},
					new TreeNode
					{
						Name = "one_106",
						Tag = Form1.MergeOptionType.one_106,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_106")
					},
					new TreeNode
					{
						Name = "one_111",
						Tag = Form1.MergeOptionType.one_111,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_111")
					},
					new TreeNode
					{
						Name = "one_119",
						Tag = Form1.MergeOptionType.one_119,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_119")
					}
				})
				{
					Name = "one_name_with_m",
					Tag = Form1.MergeOptionType.none,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_name_with_m"),
					BackColor = backColor
				},
				new TreeNode
				{
					Name = "one_105",
					Tag = Form1.MergeOptionType.one_105,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_105")
				},
				new TreeNode
				{
					Name = "one_107",
					Tag = Form1.MergeOptionType.one_107,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_107")
				},
				new TreeNode
				{
					Name = "one_108",
					Tag = Form1.MergeOptionType.one_108,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_108")
				},
				new TreeNode
				{
					Name = "one_110",
					Tag = Form1.MergeOptionType.one_110,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_110")
				},
				new TreeNode("one_scan_b_scan_f", new TreeNode[]
				{
					new TreeNode
					{
						Name = "one_113",
						Tag = Form1.MergeOptionType.one_113,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_113")
					},
					new TreeNode
					{
						Name = "one_114",
						Tag = Form1.MergeOptionType.one_114,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_114")
					},
					new TreeNode
					{
						Name = "one_115",
						Tag = Form1.MergeOptionType.one_115,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_115")
					},
					new TreeNode
					{
						Name = "one_116",
						Tag = Form1.MergeOptionType.one_116,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_116")
					}
				})
				{
					Name = "one_scan_b_scan_f",
					Tag = Form1.MergeOptionType.none,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_scan_b_scan_f"),
					BackColor = backColor
				},
				new TreeNode
				{
					Name = "one_122",
					Tag = Form1.MergeOptionType.one_122,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one_122")
				}
			});
			treeNode.Name = "one";
			treeNode.Tag = Form1.MergeOptionType.none;
			treeNode.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_one");
			treeNode.BackColor = backColor;
			TreeNode treeNode2 = new TreeNode("RioShiina（ZeaS版）解包的的立绘合成。如：XXXXXX@0000_pos_数字_数字.bmp", new TreeNode[]
			{
				new TreeNode
				{
					Name = "two_200",
					Tag = Form1.MergeOptionType.two_200,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two_200")
				},
				new TreeNode
				{
					Name = "two_201",
					Tag = Form1.MergeOptionType.two_201,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two_201")
				},
				new TreeNode
				{
					Name = "two_202",
					Tag = Form1.MergeOptionType.two_202,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two_202")
				},
				new TreeNode
				{
					Name = "two_203",
					Tag = Form1.MergeOptionType.two_203,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two_203")
				},
				new TreeNode
				{
					Name = "two_204",
					Tag = Form1.MergeOptionType.two_204,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two_204")
				}
			});
			treeNode2.Name = "two";
			treeNode2.Tag = Form1.MergeOptionType.none;
			treeNode2.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_two");
			treeNode2.BackColor = backColor;
			TreeNode treeNode3 = new TreeNode("asd 脚本系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_300",
					Tag = Form1.MergeOptionType.three_300,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_300")
				},
				new TreeNode
				{
					Name = "three_301",
					Tag = Form1.MergeOptionType.three_301,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_301")
				},
				new TreeNode
				{
					Name = "three_313",
					Tag = Form1.MergeOptionType.three_313,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_313")
				}
			});
			treeNode3.Name = "three_asd_sc";
			treeNode3.Tag = Form1.MergeOptionType.none;
			treeNode3.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_asd_sc");
			treeNode3.BackColor = backColor;
			TreeNode treeNode4 = new TreeNode();
			treeNode4.Name = "three_302";
			treeNode4.Tag = Form1.MergeOptionType.three_302;
			treeNode4.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_302");
			TreeNode treeNode5 = new TreeNode();
			treeNode5.Name = "three_303";
			treeNode5.Tag = Form1.MergeOptionType.three_303;
			treeNode5.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_303");
			TreeNode treeNode6 = new TreeNode();
			treeNode6.Name = "three_304";
			treeNode6.Tag = Form1.MergeOptionType.three_304;
			treeNode6.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_304");
			TreeNode treeNode7 = new TreeNode();
			treeNode7.Name = "three_305";
			treeNode7.Tag = Form1.MergeOptionType.three_305;
			treeNode7.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_305");
			TreeNode treeNode8 = new TreeNode();
			treeNode8.Name = "three_306";
			treeNode8.Tag = Form1.MergeOptionType.three_306;
			treeNode8.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_306");
			TreeNode treeNode9 = new TreeNode();
			treeNode9.Name = "three_307";
			treeNode9.Tag = Form1.MergeOptionType.three_307;
			treeNode9.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_307");
			TreeNode treeNode10 = new TreeNode();
			treeNode10.Name = "three_308";
			treeNode10.Tag = Form1.MergeOptionType.three_308;
			treeNode10.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_308");
			TreeNode treeNode11 = new TreeNode("xxx_info.txt + xxx.txt 系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_309",
					Tag = Form1.MergeOptionType.three_309,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_309")
				},
				treeNode4,
				treeNode5,
				treeNode6,
				treeNode7,
				treeNode8,
				treeNode9,
				treeNode10,
				new TreeNode
				{
					Name = "three_312",
					Tag = Form1.MergeOptionType.three_312,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_312")
				}
			});
			treeNode11.Name = "three_txtinfo";
			treeNode11.Tag = Form1.MergeOptionType.none;
			treeNode11.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_txtinfo");
			treeNode11.BackColor = backColor;
			TreeNode treeNode12 = new TreeNode("pos + anm + asd 系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_310",
					Tag = Form1.MergeOptionType.three_310,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_310")
				},
				new TreeNode
				{
					Name = "three_311",
					Tag = Form1.MergeOptionType.three_311,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_311")
				}
			});
			treeNode12.Name = "three_pos";
			treeNode12.Tag = Form1.MergeOptionType.none;
			treeNode12.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_pos");
			treeNode12.BackColor = backColor;
			TreeNode treeNode13 = new TreeNode("kirikiri2 解包的的立绘合成", new TreeNode[]
			{
				treeNode3,
				new TreeNode("tjs 脚本系列", new TreeNode[]
				{
					new TreeNode
					{
						Name = "three_314",
						Tag = Form1.MergeOptionType.three_314,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_314")
					}
				})
				{
					Name = "three_asd_sc",
					Tag = Form1.MergeOptionType.none,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_tjs_sc"),
					BackColor = backColor
				},
				new TreeNode("ks 脚本系列", new TreeNode[]
				{
					new TreeNode
					{
						Name = "three_315",
						Tag = Form1.MergeOptionType.three_315,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_315")
					},
					new TreeNode
					{
						Name = "three_316",
						Tag = Form1.MergeOptionType.three_316,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_316")
					},
					new TreeNode
					{
						Name = "three_317",
						Tag = Form1.MergeOptionType.three_317,
						Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_317")
					}
				})
				{
					Name = "three_asd_sc",
					Tag = Form1.MergeOptionType.none,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three_ks_sc"),
					BackColor = backColor
				},
				treeNode11,
				treeNode12
			});
			treeNode13.Name = "three";
			treeNode13.Tag = Form1.MergeOptionType.none;
			treeNode13.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_three");
			treeNode13.BackColor = backColor;
			TreeNode treeNode14 = new TreeNode();
			treeNode14.Name = "four_400";
			treeNode14.Tag = Form1.MergeOptionType.four_400;
			treeNode14.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_400");
			TreeNode treeNode15 = new TreeNode();
			treeNode15.Name = "four_401";
			treeNode15.Tag = Form1.MergeOptionType.four_401;
			treeNode15.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_401");
			TreeNode treeNode16 = new TreeNode();
			treeNode16.Name = "four_402";
			treeNode16.Tag = Form1.MergeOptionType.four_402;
			treeNode16.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_402");
			TreeNode treeNode17 = new TreeNode();
			treeNode17.Name = "four_403";
			treeNode17.Tag = Form1.MergeOptionType.four_403;
			treeNode17.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_403");
			TreeNode treeNode18 = new TreeNode();
			treeNode18.Name = "four_404";
			treeNode18.Tag = Form1.MergeOptionType.four_404;
			treeNode18.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_404");
			TreeNode treeNode19 = new TreeNode();
			treeNode19.Name = "four_405";
			treeNode19.Tag = Form1.MergeOptionType.four_405;
			treeNode19.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_405");
			TreeNode treeNode20 = new TreeNode();
			treeNode20.Name = "four_406";
			treeNode20.Tag = Form1.MergeOptionType.four_406;
			treeNode20.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_406");
			TreeNode treeNode21 = new TreeNode();
			treeNode21.Name = "four_407";
			treeNode21.Tag = Form1.MergeOptionType.four_407;
			treeNode21.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_407");
			TreeNode treeNode22 = new TreeNode();
			treeNode22.Name = "four_408";
			treeNode22.Tag = Form1.MergeOptionType.four_408;
			treeNode22.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_408");
			TreeNode treeNode23 = new TreeNode();
			treeNode23.Name = "four_409";
			treeNode23.Tag = Form1.MergeOptionType.four_409;
			treeNode23.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_409");
			TreeNode treeNode24 = new TreeNode();
			treeNode24.Name = "four_410";
			treeNode24.Tag = Form1.MergeOptionType.four_410;
			treeNode24.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_410");
			TreeNode treeNode25 = new TreeNode();
			treeNode25.Name = "four_411";
			treeNode25.Tag = Form1.MergeOptionType.four_411;
			treeNode25.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_411");
			TreeNode treeNode26 = new TreeNode("asmodean 的工具解包后的合成", new TreeNode[]
			{
				treeNode14,
				new TreeNode
				{
					Name = "four_412",
					Tag = Form1.MergeOptionType.four_412,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four_412")
				},
				treeNode15,
				treeNode16,
				treeNode17,
				treeNode18,
				treeNode19,
				treeNode20,
				treeNode21,
				treeNode22,
				treeNode23,
				treeNode24,
				treeNode25
			});
			treeNode26.Name = "four";
			treeNode26.Tag = Form1.MergeOptionType.none;
			treeNode26.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_four");
			treeNode26.BackColor = backColor;
			TreeNode treeNode27 = new TreeNode();
			treeNode27.Name = "five_500";
			treeNode27.Tag = Form1.MergeOptionType.five_500;
			treeNode27.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_five_500");
			TreeNode treeNode28 = new TreeNode();
			treeNode28.Name = "five_501";
			treeNode28.Tag = Form1.MergeOptionType.five_501;
			treeNode28.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_five_501");
			TreeNode treeNode29 = new TreeNode("crass 的工具解包后的合成", new TreeNode[]
			{
				treeNode27,
				new TreeNode
				{
					Name = "five_502",
					Tag = Form1.MergeOptionType.five_502,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_five_502")
				},
				treeNode28,
				new TreeNode
				{
					Name = "five_503",
					Tag = Form1.MergeOptionType.five_503,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_five_503")
				}
			});
			treeNode29.Name = "five";
			treeNode29.Tag = Form1.MergeOptionType.none;
			treeNode29.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_five");
			treeNode29.BackColor = backColor;
			TreeNode treeNode30 = new TreeNode("westside 的工具解包后的合成", new TreeNode[]
			{
				new TreeNode
				{
					Name = "six_600",
					Tag = Form1.MergeOptionType.six_600,
					Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_six_600")
				}
			});
			treeNode30.Name = "six";
			treeNode30.Tag = Form1.MergeOptionType.none;
			treeNode30.Text = PublicModule.thisLang.getMultiLingual("BW2_DBTV1_TreeNode_six");
			treeNode30.BackColor = backColor;
			this.DoubleBufferTreeView1.Nodes.AddRange(new TreeNode[]
			{
				treeNode,
				treeNode2,
				treeNode13,
				treeNode26,
				treeNode29,
				treeNode30
			});
			if (!string.IsNullOrEmpty(text))
			{
				string sName = text;
				TreeNodeCollection nodes = this.DoubleBufferTreeView1.Nodes;
				this.DoubleBufferTreeView1SelectedNode(sName, ref nodes);
			}
			this.DoubleBufferTreeView1.EndUpdate();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0002BE9C File Offset: 0x0002A09C
		public void DoubleBufferTreeView1SelectedNode(string sName, ref TreeNodeCollection TreeViewNodes)
		{
			try
			{
				foreach (object obj in TreeViewNodes)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (0 == string.Compare(sName, treeNode.Name, StringComparison.Ordinal))
					{
						this.DoubleBufferTreeView1.SelectedNode = treeNode;
						break;
					}
					if (0 < treeNode.Nodes.Count)
					{
						TreeNodeCollection nodes = treeNode.Nodes;
						this.DoubleBufferTreeView1SelectedNode(sName, ref nodes);
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

		// Token: 0x060002B6 RID: 694 RVA: 0x0002BF2C File Offset: 0x0002A12C
		private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
			PublicModule.MD5HashArr.Clear();
			int num = Conversions.ToInteger(e.Argument);
			if (0 >= num)
			{
				return;
			}
			this.ALL_END();
			if (this.BackgroundWorker2.CancellationPending)
			{
				e.Cancel = true;
			}
			else
			{
				try
				{
					int num2 = num;
					if (num2 != -1)
					{
						if (num2 == 100)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 1))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 101)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 2))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 102)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 3))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 103)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 4))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 104)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_m(ref form, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 121)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_m(ref form, true))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 107)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_sou_plus_alpha(ref form, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 105)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_sou_plus_alpha(ref form, true))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 106)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_xxx_mxxx(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 108)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_image_find_area_merge(ref form, 0))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 109)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_noWhitelookBlack(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 110)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_image_find_area_merge(ref form, 1))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 111)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_image_M_and_xy(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 112)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 5))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 113)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 1))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 114)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 2))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 115)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 3))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 116)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 4))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 117)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_L_alpha_R_image(ref form, 0))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 118)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_L_alpha_R_image(ref form, 1))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 119)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_MS_M(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 120)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_one.merge_image_white_alpha_to_tran(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 122)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_one.merge_image_abc_01_abc_xy(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 200)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, false, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 201)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, false, true))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 202)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, true, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 >= 203 && num2 <= 204)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode2(ref form, num))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 300)
						{
							if (this.BW2Check2Mode2("asd"))
							{
								Form1 form = this;
								if (BW2_three.asd_png__a(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 301)
						{
							if (this.BW2Check2Mode2("asd"))
							{
								Form1 form = this;
								if (BW2_three.asd__a__a_m(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 302)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_info_V1(ref form, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 303)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_info_V1(ref form, true))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 304)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_stand(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 305)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfff(ref form, true))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 306)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfff(ref form, false))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 307)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfa(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 308)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_df(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 309)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.ChangeImageByTxt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 310)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_three.pos_anm_asd_1(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 311)
						{
							if (this.BW2Check2Mode2("pos"))
							{
								Form1 form = this;
								if (BW2_three.pos_anm_asd_2(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 312)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfr(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 313)
						{
							if (this.BW2Check2Mode2("cgm"))
							{
								Form1 form = this;
								if (BW2_three.cgm_asd(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 314)
						{
							if (this.BW2Check2Mode2("tjs"))
							{
								Form1 form = this;
								if (BW2_three.merge_imageObject_tjs(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 315)
						{
							if (this.BW2Check2Mode2("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_tjs_txt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 316)
						{
							if (this.BW2Check2Mode2("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_cg_mode_first(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 317)
						{
							if (this.BW2Check2Mode2("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_width_gamename(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 400)
						{
							if (this.BW2Check2Mode1())
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exl6ren_xy(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 401)
						{
							if (this.BW2Check2Mode2("dat"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exszs_tig2png_dat(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 402)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exef2paz_xy(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 403)
						{
							if (this.BW2Check2Mode2("*"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exchpac_spm_visual(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 404)
						{
							if (this.BW2Check2Mode2("dzi"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exdieslib_dzi_svg(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 405)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exoozoarc_txt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 406)
						{
							if (this.BW2Check2Mode2("evt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exyatpkg_lua_evt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 407)
						{
							if (this.BW2Check2Mode2("mng"))
							{
								Form1 form = this;
								if (BW2_four.extract_ad_exsteldat_mng(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 408)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exmed_bgset_sprset(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 409)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exanepak_chaNX00_chaNXYZ(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 410)
						{
							if (this.BW2Check2Mode2("lsf"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exescarc_lsf(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 411)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_expimg_txt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 412)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exl6ren_automcg(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 500)
						{
							if (this.BW2Check2Mode2("bin"))
							{
								Form1 form = this;
								if (BW2_five.crass_PJADV(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 501)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_five.crass_NScripter(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 502)
						{
							if (this.BW2Check2Mode2("anm"))
							{
								Form1 form = this;
								if (BW2_five.crass_PJADV_anm(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 503)
						{
							if (this.BW2Check2Mode2(""))
							{
								Form1 form = this;
								if (BW2_five.crass_DDSystem_tga(ref form))
								{
									e.Cancel = true;
								}
							}
						}
						else if (num2 == 600)
						{
							if (this.BW2Check2Mode2("txt"))
							{
								Form1 form = this;
								if (BW2_six.merge_ws_ippaiscv_txt(ref form))
								{
									e.Cancel = true;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					PublicModule.addLog(ex.Message);
					throw new Exception(ex.Message);
				}
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0002CABC File Offset: 0x0002ACBC
		private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Button3.Text = Conversions.ToString(PublicModule.iBuild);
			checked
			{
				if (PublicModule.iNow > PublicModule.iMaxToBW)
				{
					PublicModule.iMaxToBW += PublicModule.iNow / 2;
				}
				if (0 == e.ProgressPercentage)
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.INDETERMINATE);
				}
				else
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					Windows7taskbar.SetWindows7Progress(this.Handle, PublicModule.iNow, PublicModule.iMaxToBW);
				}
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0002CB34 File Offset: 0x0002AD34
		private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			PublicModule.sSpecialExt = string.Empty;
			PublicModule.sGameExe = string.Empty;
			this.ToolStripStatusLabel1.Text = string.Empty;
			this.ToolStripStatusLabel2.Text = string.Empty;
			if (!this.CheckBox2.Checked && !e.Cancelled)
			{
				this.files2Move();
				this.files3MoveDirectory();
			}
			if (this.CheckBox3.Checked)
			{
				this.ListBox2.Items.Clear();
				PublicModule.pLeft.Clear();
			}
			if (this.CheckBox4.Checked)
			{
				this.ListBox3.Items.Clear();
				PublicModule.pRight.Clear();
			}
			this.Button3.Text = PublicModule.thisLang.getMultiLingual("GUI_Button2_Text");
			this.DoubleBufferTreeView1.Enabled = true;
			this.Panel1.Enabled = true;
			this.Timer1.Stop();
			this.BWendWithLog();
			this.ToolStripStatusLabel5.Text = "00:00:00";
			PublicModule.MD5HashArr.Clear();
			PublicModule.form1box4directorylist.Clear();
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0003265C File Offset: 0x0003085C
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00032670 File Offset: 0x00030870
		internal virtual TabControl TabControl1
		{
			get
			{
				return this._TabControl1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TabControl1_SelectedIndexChanged);
				if (this._TabControl1 != null)
				{
					this._TabControl1.SelectedIndexChanged -= value2;
				}
				this._TabControl1 = value;
				if (this._TabControl1 != null)
				{
					this._TabControl1.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000326BC File Offset: 0x000308BC
		// (set) Token: 0x060002BE RID: 702 RVA: 0x000326CF File Offset: 0x000308CF
		internal virtual TabPage TabPage1
		{
			get
			{
				return this._TabPage1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage1 = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000326D8 File Offset: 0x000308D8
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x000326EB File Offset: 0x000308EB
		internal virtual TabPage TabPage2
		{
			get
			{
				return this._TabPage2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage2 = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x000326F4 File Offset: 0x000308F4
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x00032707 File Offset: 0x00030907
		internal virtual TabPage TabPage3
		{
			get
			{
				return this._TabPage3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage3 = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00032710 File Offset: 0x00030910
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x00032723 File Offset: 0x00030923
		internal virtual TabPage TabPage4
		{
			get
			{
				return this._TabPage4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage4 = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0003272C File Offset: 0x0003092C
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0003273F File Offset: 0x0003093F
		internal virtual TabPage TabPage5
		{
			get
			{
				return this._TabPage5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage5 = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00032748 File Offset: 0x00030948
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0003275C File Offset: 0x0003095C
		internal virtual ListBox ListBox1
		{
			get
			{
				return this._ListBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DragEventHandler value2 = new DragEventHandler(this.ListBox1_DragEnter);
				MouseEventHandler value3 = new MouseEventHandler(this.ListBox1_MouseClick);
				DragEventHandler value4 = new DragEventHandler(this.ListBox1_DragDrop);
				if (this._ListBox1 != null)
				{
					this._ListBox1.DragEnter -= value2;
					this._ListBox1.MouseDown -= value3;
					this._ListBox1.DragDrop -= value4;
				}
				this._ListBox1 = value;
				if (this._ListBox1 != null)
				{
					this._ListBox1.DragEnter += value2;
					this._ListBox1.MouseDown += value3;
					this._ListBox1.DragDrop += value4;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x000327F4 File Offset: 0x000309F4
		// (set) Token: 0x060002CA RID: 714 RVA: 0x00032807 File Offset: 0x00030A07
		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this._GroupBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00032810 File Offset: 0x00030A10
		// (set) Token: 0x060002CC RID: 716 RVA: 0x00032824 File Offset: 0x00030A24
		internal virtual Button Button2
		{
			get
			{
				return this._Button2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button2_Click);
				if (this._Button2 != null)
				{
					this._Button2.Click -= value2;
				}
				this._Button2 = value;
				if (this._Button2 != null)
				{
					this._Button2.Click += value2;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00032870 File Offset: 0x00030A70
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00032884 File Offset: 0x00030A84
		internal virtual Button Button1
		{
			get
			{
				return this._Button1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click_1);
				if (this._Button1 != null)
				{
					this._Button1.Click -= value2;
				}
				this._Button1 = value;
				if (this._Button1 != null)
				{
					this._Button1.Click += value2;
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000328D0 File Offset: 0x00030AD0
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000328E4 File Offset: 0x00030AE4
		internal virtual BackgroundWorker BackgroundWorker1
		{
			get
			{
				return this._BackgroundWorker1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ProgressChangedEventHandler value2 = new ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
				DoWorkEventHandler value3 = new DoWorkEventHandler(this.BackgroundWorker1_DoWork);
				RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
				if (this._BackgroundWorker1 != null)
				{
					this._BackgroundWorker1.ProgressChanged -= value2;
					this._BackgroundWorker1.DoWork -= value3;
					this._BackgroundWorker1.RunWorkerCompleted -= value4;
				}
				this._BackgroundWorker1 = value;
				if (this._BackgroundWorker1 != null)
				{
					this._BackgroundWorker1.ProgressChanged += value2;
					this._BackgroundWorker1.DoWork += value3;
					this._BackgroundWorker1.RunWorkerCompleted += value4;
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0003297C File Offset: 0x00030B7C
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x0003298F File Offset: 0x00030B8F
		internal virtual RadioButton RadioButton1
		{
			get
			{
				return this._RadioButton1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton1 = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x00032998 File Offset: 0x00030B98
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000329AB File Offset: 0x00030BAB
		internal virtual RadioButton RadioButton2
		{
			get
			{
				return this._RadioButton2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton2 = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000329B4 File Offset: 0x00030BB4
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000329C7 File Offset: 0x00030BC7
		internal virtual NumericUpDown NumericUpDown1
		{
			get
			{
				return this._NumericUpDown1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown1 = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x000329D0 File Offset: 0x00030BD0
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x000329E3 File Offset: 0x00030BE3
		internal virtual Label Label4
		{
			get
			{
				return this._Label4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x000329EC File Offset: 0x00030BEC
		// (set) Token: 0x060002DA RID: 730 RVA: 0x000329FF File Offset: 0x00030BFF
		internal virtual Label Label3
		{
			get
			{
				return this._Label3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060002DB RID: 731 RVA: 0x00032A08 File Offset: 0x00030C08
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00032A1B File Offset: 0x00030C1B
		internal virtual Label Label2
		{
			get
			{
				return this._Label2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00032A24 File Offset: 0x00030C24
		// (set) Token: 0x060002DE RID: 734 RVA: 0x00032A37 File Offset: 0x00030C37
		internal virtual Label Label1
		{
			get
			{
				return this._Label1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00032A40 File Offset: 0x00030C40
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x00032A53 File Offset: 0x00030C53
		internal virtual RadioButton RadioButton3
		{
			get
			{
				return this._RadioButton3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton3 = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00032A5C File Offset: 0x00030C5C
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x00032A6F File Offset: 0x00030C6F
		internal virtual NumericUpDown NumericUpDown2
		{
			get
			{
				return this._NumericUpDown2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown2 = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00032A78 File Offset: 0x00030C78
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x00032A8B File Offset: 0x00030C8B
		internal virtual NumericUpDown NumericUpDown4
		{
			get
			{
				return this._NumericUpDown4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown4 = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00032A94 File Offset: 0x00030C94
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00032AA7 File Offset: 0x00030CA7
		internal virtual NumericUpDown NumericUpDown3
		{
			get
			{
				return this._NumericUpDown3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown3 = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00032AB0 File Offset: 0x00030CB0
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x00032AC4 File Offset: 0x00030CC4
		internal virtual TextBox TextBox1
		{
			get
			{
				return this._TextBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox1_KeyPress);
				if (this._TextBox1 != null)
				{
					this._TextBox1.KeyPress -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.KeyPress += value2;
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00032B10 File Offset: 0x00030D10
		// (set) Token: 0x060002EA RID: 746 RVA: 0x00032B23 File Offset: 0x00030D23
		internal virtual SplitterLabel SplitterLabel2
		{
			get
			{
				return this._SplitterLabel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel2 = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00032B2C File Offset: 0x00030D2C
		// (set) Token: 0x060002EC RID: 748 RVA: 0x00032B3F File Offset: 0x00030D3F
		internal virtual SplitterLabel SplitterLabel3
		{
			get
			{
				return this._SplitterLabel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel3 = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00032B48 File Offset: 0x00030D48
		// (set) Token: 0x060002EE RID: 750 RVA: 0x00032B5B File Offset: 0x00030D5B
		internal virtual RadioButton RadioButton4
		{
			get
			{
				return this._RadioButton4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton4 = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00032B64 File Offset: 0x00030D64
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x00032B78 File Offset: 0x00030D78
		internal virtual NumericUpDown NumericUpDown5
		{
			get
			{
				return this._NumericUpDown5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown5_ValueChanged);
				MouseEventHandler value3 = new MouseEventHandler(this.NumericUpDown5_MouseClick);
				if (this._NumericUpDown5 != null)
				{
					this._NumericUpDown5.ValueChanged -= value2;
					this._NumericUpDown5.MouseClick -= value3;
				}
				this._NumericUpDown5 = value;
				if (this._NumericUpDown5 != null)
				{
					this._NumericUpDown5.ValueChanged += value2;
					this._NumericUpDown5.MouseClick += value3;
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00032BE8 File Offset: 0x00030DE8
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x00032BFB File Offset: 0x00030DFB
		internal virtual RadioButton RadioButton6
		{
			get
			{
				return this._RadioButton6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton6 = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x00032C04 File Offset: 0x00030E04
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x00032C17 File Offset: 0x00030E17
		internal virtual RadioButton RadioButton5
		{
			get
			{
				return this._RadioButton5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton5 = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00032C20 File Offset: 0x00030E20
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00032C33 File Offset: 0x00030E33
		internal virtual SplitterLabel SplitterLabel4
		{
			get
			{
				return this._SplitterLabel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel4 = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00032C3C File Offset: 0x00030E3C
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00032C4F File Offset: 0x00030E4F
		internal virtual CheckBox CheckBox1
		{
			get
			{
				return this._CheckBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox1 = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00032C58 File Offset: 0x00030E58
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00032C6C File Offset: 0x00030E6C
		internal virtual Button Button3
		{
			get
			{
				return this._Button3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button3_Click);
				if (this._Button3 != null)
				{
					this._Button3.Click -= value2;
				}
				this._Button3 = value;
				if (this._Button3 != null)
				{
					this._Button3.Click += value2;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00032CB8 File Offset: 0x00030EB8
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00032CCC File Offset: 0x00030ECC
		internal virtual BackgroundWorker BackgroundWorker2
		{
			get
			{
				return this._BackgroundWorker2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ProgressChangedEventHandler value2 = new ProgressChangedEventHandler(this.BackgroundWorker2_ProgressChanged);
				DoWorkEventHandler value3 = new DoWorkEventHandler(this.BackgroundWorker2_DoWork);
				RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);
				if (this._BackgroundWorker2 != null)
				{
					this._BackgroundWorker2.ProgressChanged -= value2;
					this._BackgroundWorker2.DoWork -= value3;
					this._BackgroundWorker2.RunWorkerCompleted -= value4;
				}
				this._BackgroundWorker2 = value;
				if (this._BackgroundWorker2 != null)
				{
					this._BackgroundWorker2.ProgressChanged += value2;
					this._BackgroundWorker2.DoWork += value3;
					this._BackgroundWorker2.RunWorkerCompleted += value4;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00032D64 File Offset: 0x00030F64
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00032D77 File Offset: 0x00030F77
		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			get
			{
				return this._TableLayoutPanel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00032D80 File Offset: 0x00030F80
		// (set) Token: 0x06000300 RID: 768 RVA: 0x00032D93 File Offset: 0x00030F93
		internal virtual TableLayoutPanel TableLayoutPanel2
		{
			get
			{
				return this._TableLayoutPanel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel2 = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00032D9C File Offset: 0x00030F9C
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00032DAF File Offset: 0x00030FAF
		internal virtual TableLayoutPanel TableLayoutPanel3
		{
			get
			{
				return this._TableLayoutPanel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel3 = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00032DB8 File Offset: 0x00030FB8
		// (set) Token: 0x06000304 RID: 772 RVA: 0x00032DCB File Offset: 0x00030FCB
		internal virtual GroupBox GroupBox2
		{
			get
			{
				return this._GroupBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox2 = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00032DD4 File Offset: 0x00030FD4
		// (set) Token: 0x06000306 RID: 774 RVA: 0x00032DE7 File Offset: 0x00030FE7
		internal virtual GroupBox GroupBox3
		{
			get
			{
				return this._GroupBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox3 = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00032DF0 File Offset: 0x00030FF0
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00032E03 File Offset: 0x00031003
		internal virtual TableLayoutPanel TableLayoutPanel4
		{
			get
			{
				return this._TableLayoutPanel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel4 = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00032E0C File Offset: 0x0003100C
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00032E20 File Offset: 0x00031020
		internal virtual ListBox ListBox2
		{
			get
			{
				return this._ListBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ListBox2_MouseClick);
				DragEventHandler value3 = new DragEventHandler(this.ListBox2_DragDrop);
				DragEventHandler value4 = new DragEventHandler(this.ListBox2_DragEnter);
				if (this._ListBox2 != null)
				{
					this._ListBox2.MouseDown -= value2;
					this._ListBox2.DragDrop -= value3;
					this._ListBox2.DragEnter -= value4;
				}
				this._ListBox2 = value;
				if (this._ListBox2 != null)
				{
					this._ListBox2.MouseDown += value2;
					this._ListBox2.DragDrop += value3;
					this._ListBox2.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00032EB8 File Offset: 0x000310B8
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00032ECC File Offset: 0x000310CC
		internal virtual ListBox ListBox3
		{
			get
			{
				return this._ListBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ListBox3_MouseClick);
				DragEventHandler value3 = new DragEventHandler(this.ListBox3_DragDrop);
				DragEventHandler value4 = new DragEventHandler(this.ListBox3_DragEnter);
				if (this._ListBox3 != null)
				{
					this._ListBox3.MouseDown -= value2;
					this._ListBox3.DragDrop -= value3;
					this._ListBox3.DragEnter -= value4;
				}
				this._ListBox3 = value;
				if (this._ListBox3 != null)
				{
					this._ListBox3.MouseDown += value2;
					this._ListBox3.DragDrop += value3;
					this._ListBox3.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00032F64 File Offset: 0x00031164
		// (set) Token: 0x0600030E RID: 782 RVA: 0x00032F77 File Offset: 0x00031177
		internal virtual SplitterLabel SplitterLabel1
		{
			get
			{
				return this._SplitterLabel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel1 = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600030F RID: 783 RVA: 0x00032F80 File Offset: 0x00031180
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00032F94 File Offset: 0x00031194
		internal virtual ListBox ListBox4
		{
			get
			{
				return this._ListBox4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ListBox4_MouseClick);
				DragEventHandler value3 = new DragEventHandler(this.ListBox4_DragDrop);
				DragEventHandler value4 = new DragEventHandler(this.ListBox4_DragEnter);
				if (this._ListBox4 != null)
				{
					this._ListBox4.MouseDown -= value2;
					this._ListBox4.DragDrop -= value3;
					this._ListBox4.DragEnter -= value4;
				}
				this._ListBox4 = value;
				if (this._ListBox4 != null)
				{
					this._ListBox4.MouseDown += value2;
					this._ListBox4.DragDrop += value3;
					this._ListBox4.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0003302C File Offset: 0x0003122C
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0003303F File Offset: 0x0003123F
		internal virtual TableLayoutPanel TableLayoutPanel5
		{
			get
			{
				return this._TableLayoutPanel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel5 = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00033048 File Offset: 0x00031248
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0003305B File Offset: 0x0003125B
		internal virtual Label Label5
		{
			get
			{
				return this._Label5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00033064 File Offset: 0x00031264
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00033077 File Offset: 0x00031277
		internal virtual CheckBox CheckBox2
		{
			get
			{
				return this._CheckBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox2 = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00033080 File Offset: 0x00031280
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00033093 File Offset: 0x00031293
		internal virtual TableLayoutPanel TableLayoutPanel7
		{
			get
			{
				return this._TableLayoutPanel7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel7 = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000319 RID: 793 RVA: 0x0003309C File Offset: 0x0003129C
		// (set) Token: 0x0600031A RID: 794 RVA: 0x000330B0 File Offset: 0x000312B0
		internal virtual Button Button4
		{
			get
			{
				return this._Button4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button4_Click);
				if (this._Button4 != null)
				{
					this._Button4.Click -= value2;
				}
				this._Button4 = value;
				if (this._Button4 != null)
				{
					this._Button4.Click += value2;
				}
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600031B RID: 795 RVA: 0x000330FC File Offset: 0x000312FC
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00033110 File Offset: 0x00031310
		internal virtual Button Button5
		{
			get
			{
				return this._Button5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button5_Click);
				if (this._Button5 != null)
				{
					this._Button5.Click -= value2;
				}
				this._Button5 = value;
				if (this._Button5 != null)
				{
					this._Button5.Click += value2;
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0003315C File Offset: 0x0003135C
		// (set) Token: 0x0600031E RID: 798 RVA: 0x00033170 File Offset: 0x00031370
		internal virtual Button Button6
		{
			get
			{
				return this._Button6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button6_Click);
				if (this._Button6 != null)
				{
					this._Button6.Click -= value2;
				}
				this._Button6 = value;
				if (this._Button6 != null)
				{
					this._Button6.Click += value2;
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600031F RID: 799 RVA: 0x000331BC File Offset: 0x000313BC
		// (set) Token: 0x06000320 RID: 800 RVA: 0x000331CF File Offset: 0x000313CF
		internal virtual ColorDialog ColorDialog1
		{
			get
			{
				return this._ColorDialog1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColorDialog1 = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000321 RID: 801 RVA: 0x000331D8 File Offset: 0x000313D8
		// (set) Token: 0x06000322 RID: 802 RVA: 0x000331EB File Offset: 0x000313EB
		internal virtual RadioButton RadioButton9
		{
			get
			{
				return this._RadioButton9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton9 = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000323 RID: 803 RVA: 0x000331F4 File Offset: 0x000313F4
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00033208 File Offset: 0x00031408
		internal virtual Panel Panel4
		{
			get
			{
				return this._Panel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.Panel4_MouseClick);
				if (this._Panel4 != null)
				{
					this._Panel4.MouseClick -= value2;
				}
				this._Panel4 = value;
				if (this._Panel4 != null)
				{
					this._Panel4.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00033254 File Offset: 0x00031454
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00033267 File Offset: 0x00031467
		internal virtual RadioButton RadioButton10
		{
			get
			{
				return this._RadioButton10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton10 = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00033270 File Offset: 0x00031470
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00033284 File Offset: 0x00031484
		internal virtual Panel Panel5
		{
			get
			{
				return this._Panel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.Panel5_MouseClick);
				if (this._Panel5 != null)
				{
					this._Panel5.MouseClick -= value2;
				}
				this._Panel5 = value;
				if (this._Panel5 != null)
				{
					this._Panel5.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000329 RID: 809 RVA: 0x000332D0 File Offset: 0x000314D0
		// (set) Token: 0x0600032A RID: 810 RVA: 0x000332E4 File Offset: 0x000314E4
		internal virtual RadioButton RadioButton11
		{
			get
			{
				return this._RadioButton11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.RadioButton11_MouseClick);
				if (this._RadioButton11 != null)
				{
					this._RadioButton11.MouseClick -= value2;
				}
				this._RadioButton11 = value;
				if (this._RadioButton11 != null)
				{
					this._RadioButton11.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00033330 File Offset: 0x00031530
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00033344 File Offset: 0x00031544
		internal virtual RadioButton RadioButton12
		{
			get
			{
				return this._RadioButton12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.RadioButton12_MouseClick);
				if (this._RadioButton12 != null)
				{
					this._RadioButton12.MouseClick -= value2;
				}
				this._RadioButton12 = value;
				if (this._RadioButton12 != null)
				{
					this._RadioButton12.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00033390 File Offset: 0x00031590
		// (set) Token: 0x0600032E RID: 814 RVA: 0x000333A4 File Offset: 0x000315A4
		internal virtual Panel Panel6
		{
			get
			{
				return this._Panel6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.Panel6_MouseClick);
				if (this._Panel6 != null)
				{
					this._Panel6.MouseClick -= value2;
				}
				this._Panel6 = value;
				if (this._Panel6 != null)
				{
					this._Panel6.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600032F RID: 815 RVA: 0x000333F0 File Offset: 0x000315F0
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00033404 File Offset: 0x00031604
		internal virtual Panel Panel7
		{
			get
			{
				return this._Panel7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.Panel7_MouseClick);
				if (this._Panel7 != null)
				{
					this._Panel7.MouseClick -= value2;
				}
				this._Panel7 = value;
				if (this._Panel7 != null)
				{
					this._Panel7.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00033450 File Offset: 0x00031650
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00033463 File Offset: 0x00031663
		internal virtual ToolTip ToolTip1
		{
			get
			{
				return this._ToolTip1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolTip1 = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0003346C File Offset: 0x0003166C
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00033480 File Offset: 0x00031680
		internal virtual NotifyIcon NotifyIcon1
		{
			get
			{
				return this._NotifyIcon1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
				if (this._NotifyIcon1 != null)
				{
					this._NotifyIcon1.MouseDoubleClick -= value2;
				}
				this._NotifyIcon1 = value;
				if (this._NotifyIcon1 != null)
				{
					this._NotifyIcon1.MouseDoubleClick += value2;
				}
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000334CC File Offset: 0x000316CC
		// (set) Token: 0x06000336 RID: 822 RVA: 0x000334DF File Offset: 0x000316DF
		internal virtual ContextMenuStrip ContextMenuStrip1
		{
			get
			{
				return this._ContextMenuStrip1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ContextMenuStrip1 = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000337 RID: 823 RVA: 0x000334E8 File Offset: 0x000316E8
		// (set) Token: 0x06000338 RID: 824 RVA: 0x000334FB File Offset: 0x000316FB
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get
			{
				return this._ToolStripSeparator1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripSeparator1 = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00033504 File Offset: 0x00031704
		// (set) Token: 0x0600033A RID: 826 RVA: 0x00033518 File Offset: 0x00031718
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			get
			{
				return this._ToolStripMenuItem1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ToolStripMenuItem1_Click);
				if (this._ToolStripMenuItem1 != null)
				{
					this._ToolStripMenuItem1.Click -= value2;
				}
				this._ToolStripMenuItem1 = value;
				if (this._ToolStripMenuItem1 != null)
				{
					this._ToolStripMenuItem1.Click += value2;
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00033564 File Offset: 0x00031764
		// (set) Token: 0x0600033C RID: 828 RVA: 0x00033578 File Offset: 0x00031778
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			get
			{
				return this._ToolStripMenuItem2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ToolStripMenuItem2_Click);
				if (this._ToolStripMenuItem2 != null)
				{
					this._ToolStripMenuItem2.Click -= value2;
				}
				this._ToolStripMenuItem2 = value;
				if (this._ToolStripMenuItem2 != null)
				{
					this._ToolStripMenuItem2.Click += value2;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000335C4 File Offset: 0x000317C4
		// (set) Token: 0x0600033E RID: 830 RVA: 0x000335D7 File Offset: 0x000317D7
		internal virtual ComboBox ComboBox1
		{
			get
			{
				return this._ComboBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox1 = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600033F RID: 831 RVA: 0x000335E0 File Offset: 0x000317E0
		// (set) Token: 0x06000340 RID: 832 RVA: 0x000335F3 File Offset: 0x000317F3
		internal virtual SplitterLabel SplitterLabel5
		{
			get
			{
				return this._SplitterLabel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel5 = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000341 RID: 833 RVA: 0x000335FC File Offset: 0x000317FC
		// (set) Token: 0x06000342 RID: 834 RVA: 0x0003360F File Offset: 0x0003180F
		internal virtual RadioButton RadioButton13
		{
			get
			{
				return this._RadioButton13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton13 = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00033618 File Offset: 0x00031818
		// (set) Token: 0x06000344 RID: 836 RVA: 0x0003362B File Offset: 0x0003182B
		internal virtual ComboBox ComboBox2
		{
			get
			{
				return this._ComboBox2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox2 = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00033634 File Offset: 0x00031834
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00033648 File Offset: 0x00031848
		internal virtual ComboBox ComboBox3
		{
			get
			{
				return this._ComboBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox3_SelectedIndexChanged);
				if (this._ComboBox3 != null)
				{
					this._ComboBox3.SelectedIndexChanged -= value2;
				}
				this._ComboBox3 = value;
				if (this._ComboBox3 != null)
				{
					this._ComboBox3.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00033694 File Offset: 0x00031894
		// (set) Token: 0x06000348 RID: 840 RVA: 0x000336A7 File Offset: 0x000318A7
		internal virtual Label Label6
		{
			get
			{
				return this._Label6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000349 RID: 841 RVA: 0x000336B0 File Offset: 0x000318B0
		// (set) Token: 0x0600034A RID: 842 RVA: 0x000336C4 File Offset: 0x000318C4
		internal virtual NumericUpDown NumericUpDown6
		{
			get
			{
				return this._NumericUpDown6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown6_ValueChanged);
				if (this._NumericUpDown6 != null)
				{
					this._NumericUpDown6.ValueChanged -= value2;
				}
				this._NumericUpDown6 = value;
				if (this._NumericUpDown6 != null)
				{
					this._NumericUpDown6.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00033710 File Offset: 0x00031910
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00033723 File Offset: 0x00031923
		internal virtual Panel Panel8
		{
			get
			{
				return this._Panel8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel8 = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0003372C File Offset: 0x0003192C
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0003373F File Offset: 0x0003193F
		internal virtual SplitterLabel SplitterLabel6
		{
			get
			{
				return this._SplitterLabel6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel6 = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00033748 File Offset: 0x00031948
		// (set) Token: 0x06000350 RID: 848 RVA: 0x0003375B File Offset: 0x0003195B
		internal virtual RadioButton RadioButton14
		{
			get
			{
				return this._RadioButton14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton14 = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00033764 File Offset: 0x00031964
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00033777 File Offset: 0x00031977
		internal virtual CheckBox CheckBox3
		{
			get
			{
				return this._CheckBox3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox3 = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00033780 File Offset: 0x00031980
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00033793 File Offset: 0x00031993
		internal virtual CheckBox CheckBox4
		{
			get
			{
				return this._CheckBox4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox4 = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0003379C File Offset: 0x0003199C
		// (set) Token: 0x06000356 RID: 854 RVA: 0x000337AF File Offset: 0x000319AF
		internal virtual FlowLayoutPanel FlowLayoutPanel1
		{
			get
			{
				return this._FlowLayoutPanel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel1 = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000357 RID: 855 RVA: 0x000337B8 File Offset: 0x000319B8
		// (set) Token: 0x06000358 RID: 856 RVA: 0x000337CB File Offset: 0x000319CB
		internal virtual FlowLayoutPanel FlowLayoutPanel2
		{
			get
			{
				return this._FlowLayoutPanel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel2 = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000359 RID: 857 RVA: 0x000337D4 File Offset: 0x000319D4
		// (set) Token: 0x0600035A RID: 858 RVA: 0x000337E7 File Offset: 0x000319E7
		internal virtual Panel Panel2
		{
			get
			{
				return this._Panel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600035B RID: 859 RVA: 0x000337F0 File Offset: 0x000319F0
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00033803 File Offset: 0x00031A03
		internal virtual FlowLayoutPanel FlowLayoutPanel3
		{
			get
			{
				return this._FlowLayoutPanel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel3 = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600035D RID: 861 RVA: 0x0003380C File Offset: 0x00031A0C
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00033820 File Offset: 0x00031A20
		internal virtual DoubleBufferTreeView DoubleBufferTreeView1
		{
			get
			{
				return this._DoubleBufferTreeView1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.DoubleBufferTreeView1_MouseClick);
				EventHandler value3 = new EventHandler(this.DoubleBufferTreeView1_MouseLeave);
				if (this._DoubleBufferTreeView1 != null)
				{
					this._DoubleBufferTreeView1.MouseClick -= value2;
					this._DoubleBufferTreeView1.MouseLeave -= value3;
				}
				this._DoubleBufferTreeView1 = value;
				if (this._DoubleBufferTreeView1 != null)
				{
					this._DoubleBufferTreeView1.MouseClick += value2;
					this._DoubleBufferTreeView1.MouseLeave += value3;
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00033890 File Offset: 0x00031A90
		// (set) Token: 0x06000360 RID: 864 RVA: 0x000338A3 File Offset: 0x00031AA3
		internal virtual FlowLayoutPanel FlowLayoutPanel4
		{
			get
			{
				return this._FlowLayoutPanel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel4 = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000361 RID: 865 RVA: 0x000338AC File Offset: 0x00031AAC
		// (set) Token: 0x06000362 RID: 866 RVA: 0x000338BF File Offset: 0x00031ABF
		internal virtual FlowLayoutPanel FlowLayoutPanel5
		{
			get
			{
				return this._FlowLayoutPanel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel5 = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000363 RID: 867 RVA: 0x000338C8 File Offset: 0x00031AC8
		// (set) Token: 0x06000364 RID: 868 RVA: 0x000338DB File Offset: 0x00031ADB
		internal virtual NumericUpDown NumericUpDown7
		{
			get
			{
				return this._NumericUpDown7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown7 = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000365 RID: 869 RVA: 0x000338E4 File Offset: 0x00031AE4
		// (set) Token: 0x06000366 RID: 870 RVA: 0x000338F7 File Offset: 0x00031AF7
		internal virtual RadioButton RadioButton15
		{
			get
			{
				return this._RadioButton15;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton15 = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00033900 File Offset: 0x00031B00
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00033913 File Offset: 0x00031B13
		internal virtual Label Label7
		{
			get
			{
				return this._Label7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0003391C File Offset: 0x00031B1C
		// (set) Token: 0x0600036A RID: 874 RVA: 0x0003392F File Offset: 0x00031B2F
		internal virtual SplitterLabel SplitterLabel7
		{
			get
			{
				return this._SplitterLabel7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel7 = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00033938 File Offset: 0x00031B38
		// (set) Token: 0x0600036C RID: 876 RVA: 0x0003394B File Offset: 0x00031B4B
		internal virtual Panel Panel1
		{
			get
			{
				return this._Panel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00033954 File Offset: 0x00031B54
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00033967 File Offset: 0x00031B67
		internal virtual Panel Panel3
		{
			get
			{
				return this._Panel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel3 = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00033970 File Offset: 0x00031B70
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00033984 File Offset: 0x00031B84
		internal virtual NumericUpDown NumericUpDown8
		{
			get
			{
				return this._NumericUpDown8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown8_ValueChanged);
				if (this._NumericUpDown8 != null)
				{
					this._NumericUpDown8.ValueChanged -= value2;
				}
				this._NumericUpDown8 = value;
				if (this._NumericUpDown8 != null)
				{
					this._NumericUpDown8.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000371 RID: 881 RVA: 0x000339D0 File Offset: 0x00031BD0
		// (set) Token: 0x06000372 RID: 882 RVA: 0x000339E3 File Offset: 0x00031BE3
		internal virtual RadioButton RadioButton16
		{
			get
			{
				return this._RadioButton16;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton16 = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000373 RID: 883 RVA: 0x000339EC File Offset: 0x00031BEC
		// (set) Token: 0x06000374 RID: 884 RVA: 0x000339FF File Offset: 0x00031BFF
		internal virtual RadioButton RadioButton17
		{
			get
			{
				return this._RadioButton17;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton17 = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00033A08 File Offset: 0x00031C08
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00033A1C File Offset: 0x00031C1C
		internal virtual System.Windows.Forms.Timer Timer1
		{
			get
			{
				return this._Timer1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer1_Tick);
				if (this._Timer1 != null)
				{
					this._Timer1.Tick -= value2;
				}
				this._Timer1 = value;
				if (this._Timer1 != null)
				{
					this._Timer1.Tick += value2;
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00033A68 File Offset: 0x00031C68
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00033A7C File Offset: 0x00031C7C
		internal virtual Button Button7
		{
			get
			{
				return this._Button7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button7_Click);
				if (this._Button7 != null)
				{
					this._Button7.Click -= value2;
				}
				this._Button7 = value;
				if (this._Button7 != null)
				{
					this._Button7.Click += value2;
				}
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00033AC8 File Offset: 0x00031CC8
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00033ADB File Offset: 0x00031CDB
		internal virtual StatusStrip StatusStrip1
		{
			get
			{
				return this._StatusStrip1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._StatusStrip1 = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00033AE4 File Offset: 0x00031CE4
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00033AF7 File Offset: 0x00031CF7
		internal virtual TableLayoutPanel TableLayoutPanel6
		{
			get
			{
				return this._TableLayoutPanel6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel6 = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00033B00 File Offset: 0x00031D00
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00033B13 File Offset: 0x00031D13
		internal virtual ToolStripStatusLabel ToolStripStatusLabel1
		{
			get
			{
				return this._ToolStripStatusLabel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripStatusLabel1 = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00033B1C File Offset: 0x00031D1C
		// (set) Token: 0x06000380 RID: 896 RVA: 0x00033B2F File Offset: 0x00031D2F
		internal virtual ToolStripStatusLabel ToolStripStatusLabel2
		{
			get
			{
				return this._ToolStripStatusLabel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripStatusLabel2 = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00033B38 File Offset: 0x00031D38
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00033B4B File Offset: 0x00031D4B
		internal virtual ToolStripStatusLabel ToolStripStatusLabel3
		{
			get
			{
				return this._ToolStripStatusLabel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripStatusLabel3 = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00033B54 File Offset: 0x00031D54
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00033B67 File Offset: 0x00031D67
		internal virtual ToolStripStatusLabel ToolStripStatusLabel4
		{
			get
			{
				return this._ToolStripStatusLabel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripStatusLabel4 = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00033B70 File Offset: 0x00031D70
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00033B83 File Offset: 0x00031D83
		internal virtual ToolStripStatusLabel ToolStripStatusLabel5
		{
			get
			{
				return this._ToolStripStatusLabel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolStripStatusLabel5 = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00033B8C File Offset: 0x00031D8C
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00033B9F File Offset: 0x00031D9F
		internal virtual CheckBox CheckBox5
		{
			get
			{
				return this._CheckBox5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox5 = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00033BA8 File Offset: 0x00031DA8
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00033BBB File Offset: 0x00031DBB
		internal virtual FlowLayoutPanel FlowLayoutPanel6
		{
			get
			{
				return this._FlowLayoutPanel6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel6 = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00033BC4 File Offset: 0x00031DC4
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00033BD7 File Offset: 0x00031DD7
		internal virtual RadioButton RadioButton18
		{
			get
			{
				return this._RadioButton18;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton18 = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00033BE0 File Offset: 0x00031DE0
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00033BF3 File Offset: 0x00031DF3
		internal virtual RadioButton RadioButton19
		{
			get
			{
				return this._RadioButton19;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton19 = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00033BFC File Offset: 0x00031DFC
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00033C0F File Offset: 0x00031E0F
		internal virtual NumericUpDown NumericUpDown9
		{
			get
			{
				return this._NumericUpDown9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown9 = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00033C18 File Offset: 0x00031E18
		// (set) Token: 0x06000392 RID: 914 RVA: 0x00033C2B File Offset: 0x00031E2B
		internal virtual RadioButton RadioButton20
		{
			get
			{
				return this._RadioButton20;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton20 = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00033C34 File Offset: 0x00031E34
		// (set) Token: 0x06000394 RID: 916 RVA: 0x00033C47 File Offset: 0x00031E47
		internal virtual SplitterLabel SplitterLabel8
		{
			get
			{
				return this._SplitterLabel8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel8 = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00033C50 File Offset: 0x00031E50
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00033C63 File Offset: 0x00031E63
		internal virtual FlowLayoutPanel FlowLayoutPanel7
		{
			get
			{
				return this._FlowLayoutPanel7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel7 = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00033C6C File Offset: 0x00031E6C
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00033C7F File Offset: 0x00031E7F
		internal virtual FlowLayoutPanel FlowLayoutPanel8
		{
			get
			{
				return this._FlowLayoutPanel8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel8 = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00033C88 File Offset: 0x00031E88
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00033C9B File Offset: 0x00031E9B
		internal virtual RadioButton RadioButton21
		{
			get
			{
				return this._RadioButton21;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton21 = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00033CA4 File Offset: 0x00031EA4
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00033CB7 File Offset: 0x00031EB7
		internal virtual NumericUpDown NumericUpDown10
		{
			get
			{
				return this._NumericUpDown10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown10 = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00033CC0 File Offset: 0x00031EC0
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00033CD3 File Offset: 0x00031ED3
		internal virtual RadioButton RadioButton22
		{
			get
			{
				return this._RadioButton22;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton22 = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00033CDC File Offset: 0x00031EDC
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00033CEF File Offset: 0x00031EEF
		internal virtual NumericUpDown NumericUpDown11
		{
			get
			{
				return this._NumericUpDown11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown11 = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00033CF8 File Offset: 0x00031EF8
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00033D0B File Offset: 0x00031F0B
		internal virtual Label Label8
		{
			get
			{
				return this._Label8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00033D14 File Offset: 0x00031F14
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00033D27 File Offset: 0x00031F27
		internal virtual Panel Panel9
		{
			get
			{
				return this._Panel9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel9 = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00033D30 File Offset: 0x00031F30
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00033D44 File Offset: 0x00031F44
		internal virtual NumericUpDown NumericUpDown12
		{
			get
			{
				return this._NumericUpDown12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown12_ValueChanged);
				if (this._NumericUpDown12 != null)
				{
					this._NumericUpDown12.ValueChanged -= value2;
				}
				this._NumericUpDown12 = value;
				if (this._NumericUpDown12 != null)
				{
					this._NumericUpDown12.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00033D90 File Offset: 0x00031F90
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00033DA3 File Offset: 0x00031FA3
		internal virtual RadioButton RadioButton23
		{
			get
			{
				return this._RadioButton23;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton23 = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00033DAC File Offset: 0x00031FAC
		// (set) Token: 0x060003AA RID: 938 RVA: 0x00033DBF File Offset: 0x00031FBF
		internal virtual RadioButton RadioButton24
		{
			get
			{
				return this._RadioButton24;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton24 = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00033DC8 File Offset: 0x00031FC8
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00033DDC File Offset: 0x00031FDC
		internal virtual ComboBox ComboBox4
		{
			get
			{
				return this._ComboBox4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox4_SelectedIndexChanged);
				if (this._ComboBox4 != null)
				{
					this._ComboBox4.SelectedIndexChanged -= value2;
				}
				this._ComboBox4 = value;
				if (this._ComboBox4 != null)
				{
					this._ComboBox4.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060003AD RID: 941 RVA: 0x00033E28 File Offset: 0x00032028
		// (set) Token: 0x060003AE RID: 942 RVA: 0x00033E3C File Offset: 0x0003203C
		internal virtual NumericUpDown NumericUpDown13
		{
			get
			{
				return this._NumericUpDown13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown13_ValueChanged);
				if (this._NumericUpDown13 != null)
				{
					this._NumericUpDown13.ValueChanged -= value2;
				}
				this._NumericUpDown13 = value;
				if (this._NumericUpDown13 != null)
				{
					this._NumericUpDown13.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003AF RID: 943 RVA: 0x00033E88 File Offset: 0x00032088
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x00033E9B File Offset: 0x0003209B
		internal virtual RadioButton RadioButton7
		{
			get
			{
				return this._RadioButton7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton7 = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00033EA4 File Offset: 0x000320A4
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x00033EB7 File Offset: 0x000320B7
		internal virtual SplitterLabel SplitterLabel9
		{
			get
			{
				return this._SplitterLabel9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitterLabel9 = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x00033EC0 File Offset: 0x000320C0
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x00033ED3 File Offset: 0x000320D3
		internal virtual CheckBox CheckBox6
		{
			get
			{
				return this._CheckBox6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox6 = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00033EDC File Offset: 0x000320DC
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x00033EEF File Offset: 0x000320EF
		internal virtual FlowLayoutPanel FlowLayoutPanel9
		{
			get
			{
				return this._FlowLayoutPanel9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._FlowLayoutPanel9 = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00033EF8 File Offset: 0x000320F8
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00033F0B File Offset: 0x0003210B
		internal virtual RadioButton RadioButton8
		{
			get
			{
				return this._RadioButton8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton8 = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00033F14 File Offset: 0x00032114
		// (set) Token: 0x060003BA RID: 954 RVA: 0x00033F27 File Offset: 0x00032127
		internal virtual NumericUpDown NumericUpDown14
		{
			get
			{
				return this._NumericUpDown14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown14 = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00033F30 File Offset: 0x00032130
		// (set) Token: 0x060003BC RID: 956 RVA: 0x00033F43 File Offset: 0x00032143
		internal virtual RadioButton RadioButton25
		{
			get
			{
				return this._RadioButton25;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton25 = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00033F4C File Offset: 0x0003214C
		// (set) Token: 0x060003BE RID: 958 RVA: 0x00033F5F File Offset: 0x0003215F
		internal virtual NumericUpDown NumericUpDown15
		{
			get
			{
				return this._NumericUpDown15;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown15 = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00033F68 File Offset: 0x00032168
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x00033F7B File Offset: 0x0003217B
		internal virtual RadioButton RadioButton26
		{
			get
			{
				return this._RadioButton26;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton26 = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00033F84 File Offset: 0x00032184
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x00033F98 File Offset: 0x00032198
		internal virtual NumericUpDown NumericUpDown16
		{
			get
			{
				return this._NumericUpDown16;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown16_ValueChanged);
				if (this._NumericUpDown16 != null)
				{
					this._NumericUpDown16.ValueChanged -= value2;
				}
				this._NumericUpDown16 = value;
				if (this._NumericUpDown16 != null)
				{
					this._NumericUpDown16.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00033FE4 File Offset: 0x000321E4
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00033FF7 File Offset: 0x000321F7
		internal virtual Panel Panel10
		{
			get
			{
				return this._Panel10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel10 = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x00034000 File Offset: 0x00032200
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x00034014 File Offset: 0x00032214
		internal virtual NumericUpDown NumericUpDown17
		{
			get
			{
				return this._NumericUpDown17;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown17_ValueChanged);
				if (this._NumericUpDown17 != null)
				{
					this._NumericUpDown17.ValueChanged -= value2;
				}
				this._NumericUpDown17 = value;
				if (this._NumericUpDown17 != null)
				{
					this._NumericUpDown17.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00034060 File Offset: 0x00032260
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x00034073 File Offset: 0x00032273
		internal virtual RadioButton RadioButton27
		{
			get
			{
				return this._RadioButton27;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton27 = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0003407C File Offset: 0x0003227C
		// (set) Token: 0x060003CA RID: 970 RVA: 0x0003408F File Offset: 0x0003228F
		internal virtual RadioButton RadioButton28
		{
			get
			{
				return this._RadioButton28;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton28 = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00034098 File Offset: 0x00032298
		// (set) Token: 0x060003CC RID: 972 RVA: 0x000340AB File Offset: 0x000322AB
		internal virtual Label Label9
		{
			get
			{
				return this._Label9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label9 = value;
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000340B4 File Offset: 0x000322B4
		private void Form1_Load(object sender, EventArgs e)
		{
			this.addMenuToSysMenu();
			this.CheckTreeView1AddNodes();
			this.setToolTip1();
			this.ComboBox1.SelectedIndex = 0;
			this.ComboBox2.SelectedIndex = 0;
			this.ComboBox3.SelectedIndex = 0;
			if (Directory.Exists("lang") && 0 != string.Compare(PublicModule.strCultureLangName, "zh-CN", StringComparison.Ordinal))
			{
				this.setMultiLingualGui();
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0003411C File Offset: 0x0003231C
		private void Button1_Click_1(object sender, EventArgs e)
		{
			this.ListBox1.Items.Clear();
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00034130 File Offset: 0x00032330
		private void Button2_Click(object sender, EventArgs e)
		{
			if (this.BackgroundWorker1.IsBusy)
			{
				PublicModule.bWaitCancelAsync = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				MsgBoxResult msgBoxResult = Interaction.MsgBox(PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_1") + "\r\n" + PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_2"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_3"));
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
					this.BackgroundWorker1.CancelAsync();
				}
				else if (msgBoxResult == MsgBoxResult.No)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
				}
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				PublicModule.bWaitCancelAsync = false;
			}
			else if (!this.RadioButton1.Checked && 0 <= this.ListBox1.Items.Count)
			{
				this.GroupBox1.Enabled = false;
				this.CheckBox5.Enabled = false;
				this.Button2.Text = PublicModule.thisLang.getMultiLingual("Form1_Thread_Run_Msg");
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
				this.Timer1.Start();
				if (this.RadioButton13.Checked)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.Add(this.ComboBox1.SelectedIndex);
					arrayList.Add(this.ComboBox2.SelectedIndex);
					arrayList.Add(this.ComboBox3.SelectedIndex);
					arrayList.Add(this.ComboBox2.SelectedItem.ToString().ToLower());
					arrayList.Add(this.CheckBox6.Checked);
					this.BackgroundWorker1.RunWorkerAsync(arrayList);
				}
				else
				{
					this.BackgroundWorker1.RunWorkerAsync();
				}
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00034340 File Offset: 0x00032540
		private void Button3_Click(object sender, EventArgs e)
		{
			if (this.BackgroundWorker2.IsBusy)
			{
				PublicModule.bWaitCancelAsync = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				MsgBoxResult msgBoxResult = Interaction.MsgBox(PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_1") + "\r\n" + PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_2"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, PublicModule.thisLang.getMultiLingual("Form1_Thread_Canel_Msg_3"));
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
					this.BackgroundWorker2.CancelAsync();
				}
				else if (msgBoxResult == MsgBoxResult.No)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
				}
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				PublicModule.bWaitCancelAsync = false;
			}
			else if (this.DoubleBufferTreeView1.SelectedNode != null && 0 < this.DoubleBufferTreeView1.SelectedNode.Level && Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(this.DoubleBufferTreeView1.SelectedNode.Tag)))
			{
				int num = Conversions.ToInteger(this.DoubleBufferTreeView1.SelectedNode.Tag);
				if (0 < num && ((0 < this.ListBox2.Items.Count & 0 < this.ListBox3.Items.Count) | 0 < this.ListBox4.Items.Count))
				{
					this.DoubleBufferTreeView1.Enabled = false;
					this.Panel1.Enabled = false;
					this.Button3.Text = PublicModule.thisLang.getMultiLingual("Form1_Thread_Run_Msg");
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
					this.Timer1.Start();
					this.BackgroundWorker2.RunWorkerAsync(num);
				}
			}
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00034532 File Offset: 0x00032732
		private void Button4_Click(object sender, EventArgs e)
		{
			this.ListBox2.Items.Clear();
			this.ListBox3.Items.Clear();
			this.ListBox4.Items.Clear();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00034564 File Offset: 0x00032764
		private void Button5_Click(object sender, EventArgs e)
		{
			this.ListBox2.Items.Clear();
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00034576 File Offset: 0x00032776
		private void Button6_Click(object sender, EventArgs e)
		{
			this.ListBox3.Items.Clear();
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00034588 File Offset: 0x00032788
		private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			this.RadioButton6.Checked = true;
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown5", Conversions.ToString(this.NumericUpDown5.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000345C7 File Offset: 0x000327C7
		private void NumericUpDown6_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown6", Conversions.ToString(this.NumericUpDown6.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000345FA File Offset: 0x000327FA
		private void NumericUpDown8_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown8", Conversions.ToString(this.NumericUpDown8.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0003462D File Offset: 0x0003282D
		private void NumericUpDown12_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown12", Conversions.ToString(this.NumericUpDown12.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00034660 File Offset: 0x00032860
		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00034668 File Offset: 0x00032868
		private void ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
			PublicModule.SetForegroundWindow(this.Handle);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00034688 File Offset: 0x00032888
		private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.ComboBox3.SelectedIndex;
			if (3 == selectedIndex)
			{
				this.NumericUpDown6.Enabled = true;
			}
			else
			{
				this.NumericUpDown6.Enabled = false;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000346BF File Offset: 0x000328BF
		private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.WindowState == FormWindowState.Minimized)
				{
					this.WindowState = FormWindowState.Normal;
					PublicModule.SetForegroundWindow(this.Handle);
				}
				else if (this.WindowState == FormWindowState.Normal)
				{
					this.WindowState = FormWindowState.Minimized;
				}
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000346FC File Offset: 0x000328FC
		private void RadioButton7_CheckedChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("p2SaveBitmapFormat", "7");
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00034724 File Offset: 0x00032924
		private void RadioButton8_CheckedChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("p2SaveBitmapFormat", "8");
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0003474C File Offset: 0x0003294C
		private void Timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				PublicModule.iUseTime++;
				PublicModule.iUseTimeSecond = PublicModule.iUseTime % 60;
				PublicModule.iUseTimeMinute = (int)Math.Round(Conversion.Fix((double)(PublicModule.iUseTime % 3600) / 60.0));
				PublicModule.iUseTimeHour = (int)Math.Round(Conversion.Fix((double)(PublicModule.iUseTime % 86400) / 3600.0));
				this.ToolStripStatusLabel5.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", PublicModule.iUseTimeHour, PublicModule.iUseTimeMinute, PublicModule.iUseTimeSecond);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000347F1 File Offset: 0x000329F1
		private void Button7_Click(object sender, EventArgs e)
		{
			MyProject.get_Forms().get_Form3().Show();
			MyProject.get_Forms().get_Form3().WindowState = FormWindowState.Normal;
			PublicModule.SetForegroundWindow(MyProject.get_Forms().get_Form3().Handle);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00034828 File Offset: 0x00032A28
		private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.ComboBox4.SelectedIndex;
			PublicModule.i2SaveBitmapFormat = selectedIndex;
			if (2 == selectedIndex)
			{
				this.NumericUpDown13.Enabled = true;
			}
			else
			{
				this.NumericUpDown13.Enabled = false;
			}
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("p2SaveBitmapFormat", Conversions.ToString(selectedIndex));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0003488C File Offset: 0x00032A8C
		private void NumericUpDown13_ValueChanged(object sender, EventArgs e)
		{
			PublicModule.i2SaveBitmapFormatJpg = Convert.ToInt32(this.NumericUpDown13.Value);
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown13", Conversions.ToString(this.NumericUpDown13.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000348DF File Offset: 0x00032ADF
		private void NumericUpDown16_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown16", Conversions.ToString(this.NumericUpDown16.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00034912 File Offset: 0x00032B12
		private void NumericUpDown17_ValueChanged(object sender, EventArgs e)
		{
			if (this.IsHandleCreated)
			{
				PublicModule.galConfig.Update("iNumUpDown17", Conversions.ToString(this.NumericUpDown17.Value));
				PublicModule.galConfig.Save();
			}
		}

		// Token: 0x04000300 RID: 768
		private int pSubMenu;

		// Token: 0x04000301 RID: 769
		private int pLangSubMenu;

		// Token: 0x04000302 RID: 770
		private int iMaxLangFile;

		// Token: 0x04000303 RID: 771
		private string[] lang_xml_files;

		// Token: 0x04000304 RID: 772
		private string myLocalLanguage;

		// Token: 0x04000306 RID: 774
		[AccessedThroughProperty("TabControl1")]
		private TabControl _TabControl1;

		// Token: 0x04000307 RID: 775
		[AccessedThroughProperty("TabPage1")]
		private TabPage _TabPage1;

		// Token: 0x04000308 RID: 776
		[AccessedThroughProperty("TabPage2")]
		private TabPage _TabPage2;

		// Token: 0x04000309 RID: 777
		[AccessedThroughProperty("TabPage3")]
		private TabPage _TabPage3;

		// Token: 0x0400030A RID: 778
		[AccessedThroughProperty("TabPage4")]
		private TabPage _TabPage4;

		// Token: 0x0400030B RID: 779
		[AccessedThroughProperty("TabPage5")]
		private TabPage _TabPage5;

		// Token: 0x0400030C RID: 780
		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		// Token: 0x0400030D RID: 781
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		// Token: 0x0400030E RID: 782
		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		// Token: 0x0400030F RID: 783
		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		// Token: 0x04000310 RID: 784
		[AccessedThroughProperty("BackgroundWorker1")]
		private BackgroundWorker _BackgroundWorker1;

		// Token: 0x04000311 RID: 785
		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		// Token: 0x04000312 RID: 786
		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		// Token: 0x04000313 RID: 787
		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown _NumericUpDown1;

		// Token: 0x04000314 RID: 788
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x04000315 RID: 789
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x04000316 RID: 790
		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		// Token: 0x04000317 RID: 791
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x04000318 RID: 792
		[AccessedThroughProperty("RadioButton3")]
		private RadioButton _RadioButton3;

		// Token: 0x04000319 RID: 793
		[AccessedThroughProperty("NumericUpDown2")]
		private NumericUpDown _NumericUpDown2;

		// Token: 0x0400031A RID: 794
		[AccessedThroughProperty("NumericUpDown4")]
		private NumericUpDown _NumericUpDown4;

		// Token: 0x0400031B RID: 795
		[AccessedThroughProperty("NumericUpDown3")]
		private NumericUpDown _NumericUpDown3;

		// Token: 0x0400031C RID: 796
		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		// Token: 0x0400031D RID: 797
		[AccessedThroughProperty("SplitterLabel2")]
		private SplitterLabel _SplitterLabel2;

		// Token: 0x0400031E RID: 798
		[AccessedThroughProperty("SplitterLabel3")]
		private SplitterLabel _SplitterLabel3;

		// Token: 0x0400031F RID: 799
		[AccessedThroughProperty("RadioButton4")]
		private RadioButton _RadioButton4;

		// Token: 0x04000320 RID: 800
		[AccessedThroughProperty("NumericUpDown5")]
		private NumericUpDown _NumericUpDown5;

		// Token: 0x04000321 RID: 801
		[AccessedThroughProperty("RadioButton6")]
		private RadioButton _RadioButton6;

		// Token: 0x04000322 RID: 802
		[AccessedThroughProperty("RadioButton5")]
		private RadioButton _RadioButton5;

		// Token: 0x04000323 RID: 803
		[AccessedThroughProperty("SplitterLabel4")]
		private SplitterLabel _SplitterLabel4;

		// Token: 0x04000324 RID: 804
		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		// Token: 0x04000325 RID: 805
		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		// Token: 0x04000326 RID: 806
		[AccessedThroughProperty("BackgroundWorker2")]
		private BackgroundWorker _BackgroundWorker2;

		// Token: 0x04000327 RID: 807
		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		// Token: 0x04000328 RID: 808
		[AccessedThroughProperty("TableLayoutPanel2")]
		private TableLayoutPanel _TableLayoutPanel2;

		// Token: 0x04000329 RID: 809
		[AccessedThroughProperty("TableLayoutPanel3")]
		private TableLayoutPanel _TableLayoutPanel3;

		// Token: 0x0400032A RID: 810
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		// Token: 0x0400032B RID: 811
		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		// Token: 0x0400032C RID: 812
		[AccessedThroughProperty("TableLayoutPanel4")]
		private TableLayoutPanel _TableLayoutPanel4;

		// Token: 0x0400032D RID: 813
		[AccessedThroughProperty("ListBox2")]
		private ListBox _ListBox2;

		// Token: 0x0400032E RID: 814
		[AccessedThroughProperty("ListBox3")]
		private ListBox _ListBox3;

		// Token: 0x0400032F RID: 815
		[AccessedThroughProperty("SplitterLabel1")]
		private SplitterLabel _SplitterLabel1;

		// Token: 0x04000330 RID: 816
		[AccessedThroughProperty("ListBox4")]
		private ListBox _ListBox4;

		// Token: 0x04000331 RID: 817
		[AccessedThroughProperty("TableLayoutPanel5")]
		private TableLayoutPanel _TableLayoutPanel5;

		// Token: 0x04000332 RID: 818
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x04000333 RID: 819
		[AccessedThroughProperty("CheckBox2")]
		private CheckBox _CheckBox2;

		// Token: 0x04000334 RID: 820
		[AccessedThroughProperty("TableLayoutPanel7")]
		private TableLayoutPanel _TableLayoutPanel7;

		// Token: 0x04000335 RID: 821
		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		// Token: 0x04000336 RID: 822
		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		// Token: 0x04000337 RID: 823
		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		// Token: 0x04000338 RID: 824
		[AccessedThroughProperty("ColorDialog1")]
		private ColorDialog _ColorDialog1;

		// Token: 0x04000339 RID: 825
		[AccessedThroughProperty("RadioButton9")]
		private RadioButton _RadioButton9;

		// Token: 0x0400033A RID: 826
		[AccessedThroughProperty("Panel4")]
		private Panel _Panel4;

		// Token: 0x0400033B RID: 827
		[AccessedThroughProperty("RadioButton10")]
		private RadioButton _RadioButton10;

		// Token: 0x0400033C RID: 828
		[AccessedThroughProperty("Panel5")]
		private Panel _Panel5;

		// Token: 0x0400033D RID: 829
		[AccessedThroughProperty("RadioButton11")]
		private RadioButton _RadioButton11;

		// Token: 0x0400033E RID: 830
		[AccessedThroughProperty("RadioButton12")]
		private RadioButton _RadioButton12;

		// Token: 0x0400033F RID: 831
		[AccessedThroughProperty("Panel6")]
		private Panel _Panel6;

		// Token: 0x04000340 RID: 832
		[AccessedThroughProperty("Panel7")]
		private Panel _Panel7;

		// Token: 0x04000341 RID: 833
		[AccessedThroughProperty("ToolTip1")]
		private ToolTip _ToolTip1;

		// Token: 0x04000342 RID: 834
		[AccessedThroughProperty("NotifyIcon1")]
		private NotifyIcon _NotifyIcon1;

		// Token: 0x04000343 RID: 835
		[AccessedThroughProperty("ContextMenuStrip1")]
		private ContextMenuStrip _ContextMenuStrip1;

		// Token: 0x04000344 RID: 836
		[AccessedThroughProperty("ToolStripSeparator1")]
		private ToolStripSeparator _ToolStripSeparator1;

		// Token: 0x04000345 RID: 837
		[AccessedThroughProperty("ToolStripMenuItem1")]
		private ToolStripMenuItem _ToolStripMenuItem1;

		// Token: 0x04000346 RID: 838
		[AccessedThroughProperty("ToolStripMenuItem2")]
		private ToolStripMenuItem _ToolStripMenuItem2;

		// Token: 0x04000347 RID: 839
		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		// Token: 0x04000348 RID: 840
		[AccessedThroughProperty("SplitterLabel5")]
		private SplitterLabel _SplitterLabel5;

		// Token: 0x04000349 RID: 841
		[AccessedThroughProperty("RadioButton13")]
		private RadioButton _RadioButton13;

		// Token: 0x0400034A RID: 842
		[AccessedThroughProperty("ComboBox2")]
		private ComboBox _ComboBox2;

		// Token: 0x0400034B RID: 843
		[AccessedThroughProperty("ComboBox3")]
		private ComboBox _ComboBox3;

		// Token: 0x0400034C RID: 844
		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		// Token: 0x0400034D RID: 845
		[AccessedThroughProperty("NumericUpDown6")]
		private NumericUpDown _NumericUpDown6;

		// Token: 0x0400034E RID: 846
		[AccessedThroughProperty("Panel8")]
		private Panel _Panel8;

		// Token: 0x0400034F RID: 847
		[AccessedThroughProperty("SplitterLabel6")]
		private SplitterLabel _SplitterLabel6;

		// Token: 0x04000350 RID: 848
		[AccessedThroughProperty("RadioButton14")]
		private RadioButton _RadioButton14;

		// Token: 0x04000351 RID: 849
		[AccessedThroughProperty("CheckBox3")]
		private CheckBox _CheckBox3;

		// Token: 0x04000352 RID: 850
		[AccessedThroughProperty("CheckBox4")]
		private CheckBox _CheckBox4;

		// Token: 0x04000353 RID: 851
		[AccessedThroughProperty("FlowLayoutPanel1")]
		private FlowLayoutPanel _FlowLayoutPanel1;

		// Token: 0x04000354 RID: 852
		[AccessedThroughProperty("FlowLayoutPanel2")]
		private FlowLayoutPanel _FlowLayoutPanel2;

		// Token: 0x04000355 RID: 853
		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		// Token: 0x04000356 RID: 854
		[AccessedThroughProperty("FlowLayoutPanel3")]
		private FlowLayoutPanel _FlowLayoutPanel3;

		// Token: 0x04000357 RID: 855
		[AccessedThroughProperty("DoubleBufferTreeView1")]
		private DoubleBufferTreeView _DoubleBufferTreeView1;

		// Token: 0x04000358 RID: 856
		[AccessedThroughProperty("FlowLayoutPanel4")]
		private FlowLayoutPanel _FlowLayoutPanel4;

		// Token: 0x04000359 RID: 857
		[AccessedThroughProperty("FlowLayoutPanel5")]
		private FlowLayoutPanel _FlowLayoutPanel5;

		// Token: 0x0400035A RID: 858
		[AccessedThroughProperty("NumericUpDown7")]
		private NumericUpDown _NumericUpDown7;

		// Token: 0x0400035B RID: 859
		[AccessedThroughProperty("RadioButton15")]
		private RadioButton _RadioButton15;

		// Token: 0x0400035C RID: 860
		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		// Token: 0x0400035D RID: 861
		[AccessedThroughProperty("SplitterLabel7")]
		private SplitterLabel _SplitterLabel7;

		// Token: 0x0400035E RID: 862
		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		// Token: 0x0400035F RID: 863
		[AccessedThroughProperty("Panel3")]
		private Panel _Panel3;

		// Token: 0x04000360 RID: 864
		[AccessedThroughProperty("NumericUpDown8")]
		private NumericUpDown _NumericUpDown8;

		// Token: 0x04000361 RID: 865
		[AccessedThroughProperty("RadioButton16")]
		private RadioButton _RadioButton16;

		// Token: 0x04000362 RID: 866
		[AccessedThroughProperty("RadioButton17")]
		private RadioButton _RadioButton17;

		// Token: 0x04000363 RID: 867
		[AccessedThroughProperty("Timer1")]
		private System.Windows.Forms.Timer _Timer1;

		// Token: 0x04000364 RID: 868
		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		// Token: 0x04000365 RID: 869
		[AccessedThroughProperty("StatusStrip1")]
		private StatusStrip _StatusStrip1;

		// Token: 0x04000366 RID: 870
		[AccessedThroughProperty("TableLayoutPanel6")]
		private TableLayoutPanel _TableLayoutPanel6;

		// Token: 0x04000367 RID: 871
		[AccessedThroughProperty("ToolStripStatusLabel1")]
		private ToolStripStatusLabel _ToolStripStatusLabel1;

		// Token: 0x04000368 RID: 872
		[AccessedThroughProperty("ToolStripStatusLabel2")]
		private ToolStripStatusLabel _ToolStripStatusLabel2;

		// Token: 0x04000369 RID: 873
		[AccessedThroughProperty("ToolStripStatusLabel3")]
		private ToolStripStatusLabel _ToolStripStatusLabel3;

		// Token: 0x0400036A RID: 874
		[AccessedThroughProperty("ToolStripStatusLabel4")]
		private ToolStripStatusLabel _ToolStripStatusLabel4;

		// Token: 0x0400036B RID: 875
		[AccessedThroughProperty("ToolStripStatusLabel5")]
		private ToolStripStatusLabel _ToolStripStatusLabel5;

		// Token: 0x0400036C RID: 876
		[AccessedThroughProperty("CheckBox5")]
		private CheckBox _CheckBox5;

		// Token: 0x0400036D RID: 877
		[AccessedThroughProperty("FlowLayoutPanel6")]
		private FlowLayoutPanel _FlowLayoutPanel6;

		// Token: 0x0400036E RID: 878
		[AccessedThroughProperty("RadioButton18")]
		private RadioButton _RadioButton18;

		// Token: 0x0400036F RID: 879
		[AccessedThroughProperty("RadioButton19")]
		private RadioButton _RadioButton19;

		// Token: 0x04000370 RID: 880
		[AccessedThroughProperty("NumericUpDown9")]
		private NumericUpDown _NumericUpDown9;

		// Token: 0x04000371 RID: 881
		[AccessedThroughProperty("RadioButton20")]
		private RadioButton _RadioButton20;

		// Token: 0x04000372 RID: 882
		[AccessedThroughProperty("SplitterLabel8")]
		private SplitterLabel _SplitterLabel8;

		// Token: 0x04000373 RID: 883
		[AccessedThroughProperty("FlowLayoutPanel7")]
		private FlowLayoutPanel _FlowLayoutPanel7;

		// Token: 0x04000374 RID: 884
		[AccessedThroughProperty("FlowLayoutPanel8")]
		private FlowLayoutPanel _FlowLayoutPanel8;

		// Token: 0x04000375 RID: 885
		[AccessedThroughProperty("RadioButton21")]
		private RadioButton _RadioButton21;

		// Token: 0x04000376 RID: 886
		[AccessedThroughProperty("NumericUpDown10")]
		private NumericUpDown _NumericUpDown10;

		// Token: 0x04000377 RID: 887
		[AccessedThroughProperty("RadioButton22")]
		private RadioButton _RadioButton22;

		// Token: 0x04000378 RID: 888
		[AccessedThroughProperty("NumericUpDown11")]
		private NumericUpDown _NumericUpDown11;

		// Token: 0x04000379 RID: 889
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x0400037A RID: 890
		[AccessedThroughProperty("Panel9")]
		private Panel _Panel9;

		// Token: 0x0400037B RID: 891
		[AccessedThroughProperty("NumericUpDown12")]
		private NumericUpDown _NumericUpDown12;

		// Token: 0x0400037C RID: 892
		[AccessedThroughProperty("RadioButton23")]
		private RadioButton _RadioButton23;

		// Token: 0x0400037D RID: 893
		[AccessedThroughProperty("RadioButton24")]
		private RadioButton _RadioButton24;

		// Token: 0x0400037E RID: 894
		[AccessedThroughProperty("ComboBox4")]
		private ComboBox _ComboBox4;

		// Token: 0x0400037F RID: 895
		[AccessedThroughProperty("NumericUpDown13")]
		private NumericUpDown _NumericUpDown13;

		// Token: 0x04000380 RID: 896
		[AccessedThroughProperty("RadioButton7")]
		private RadioButton _RadioButton7;

		// Token: 0x04000381 RID: 897
		[AccessedThroughProperty("SplitterLabel9")]
		private SplitterLabel _SplitterLabel9;

		// Token: 0x04000382 RID: 898
		[AccessedThroughProperty("CheckBox6")]
		private CheckBox _CheckBox6;

		// Token: 0x04000383 RID: 899
		[AccessedThroughProperty("FlowLayoutPanel9")]
		private FlowLayoutPanel _FlowLayoutPanel9;

		// Token: 0x04000384 RID: 900
		[AccessedThroughProperty("RadioButton8")]
		private RadioButton _RadioButton8;

		// Token: 0x04000385 RID: 901
		[AccessedThroughProperty("NumericUpDown14")]
		private NumericUpDown _NumericUpDown14;

		// Token: 0x04000386 RID: 902
		[AccessedThroughProperty("RadioButton25")]
		private RadioButton _RadioButton25;

		// Token: 0x04000387 RID: 903
		[AccessedThroughProperty("NumericUpDown15")]
		private NumericUpDown _NumericUpDown15;

		// Token: 0x04000388 RID: 904
		[AccessedThroughProperty("RadioButton26")]
		private RadioButton _RadioButton26;

		// Token: 0x04000389 RID: 905
		[AccessedThroughProperty("NumericUpDown16")]
		private NumericUpDown _NumericUpDown16;

		// Token: 0x0400038A RID: 906
		[AccessedThroughProperty("Panel10")]
		private Panel _Panel10;

		// Token: 0x0400038B RID: 907
		[AccessedThroughProperty("NumericUpDown17")]
		private NumericUpDown _NumericUpDown17;

		// Token: 0x0400038C RID: 908
		[AccessedThroughProperty("RadioButton27")]
		private RadioButton _RadioButton27;

		// Token: 0x0400038D RID: 909
		[AccessedThroughProperty("RadioButton28")]
		private RadioButton _RadioButton28;

		// Token: 0x0400038E RID: 910
		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		// Token: 0x020000CA RID: 202
		public enum MergeOptionType
		{
			// Token: 0x04000390 RID: 912
			none = -1,
			// Token: 0x04000391 RID: 913
			one_100 = 100,
			// Token: 0x04000392 RID: 914
			one_101,
			// Token: 0x04000393 RID: 915
			one_102,
			// Token: 0x04000394 RID: 916
			one_103,
			// Token: 0x04000395 RID: 917
			one_104,
			// Token: 0x04000396 RID: 918
			one_105,
			// Token: 0x04000397 RID: 919
			one_106,
			// Token: 0x04000398 RID: 920
			one_107,
			// Token: 0x04000399 RID: 921
			one_108,
			// Token: 0x0400039A RID: 922
			one_109,
			// Token: 0x0400039B RID: 923
			one_110,
			// Token: 0x0400039C RID: 924
			one_111,
			// Token: 0x0400039D RID: 925
			one_112,
			// Token: 0x0400039E RID: 926
			one_113,
			// Token: 0x0400039F RID: 927
			one_114,
			// Token: 0x040003A0 RID: 928
			one_115,
			// Token: 0x040003A1 RID: 929
			one_116,
			// Token: 0x040003A2 RID: 930
			one_117,
			// Token: 0x040003A3 RID: 931
			one_118,
			// Token: 0x040003A4 RID: 932
			one_119,
			// Token: 0x040003A5 RID: 933
			one_120,
			// Token: 0x040003A6 RID: 934
			one_121,
			// Token: 0x040003A7 RID: 935
			one_122,
			// Token: 0x040003A8 RID: 936
			two_200 = 200,
			// Token: 0x040003A9 RID: 937
			two_201,
			// Token: 0x040003AA RID: 938
			two_202,
			// Token: 0x040003AB RID: 939
			two_203,
			// Token: 0x040003AC RID: 940
			two_204,
			// Token: 0x040003AD RID: 941
			three_300 = 300,
			// Token: 0x040003AE RID: 942
			three_301,
			// Token: 0x040003AF RID: 943
			three_302,
			// Token: 0x040003B0 RID: 944
			three_303,
			// Token: 0x040003B1 RID: 945
			three_304,
			// Token: 0x040003B2 RID: 946
			three_305,
			// Token: 0x040003B3 RID: 947
			three_306,
			// Token: 0x040003B4 RID: 948
			three_307,
			// Token: 0x040003B5 RID: 949
			three_308,
			// Token: 0x040003B6 RID: 950
			three_309,
			// Token: 0x040003B7 RID: 951
			three_310,
			// Token: 0x040003B8 RID: 952
			three_311,
			// Token: 0x040003B9 RID: 953
			three_312,
			// Token: 0x040003BA RID: 954
			three_313,
			// Token: 0x040003BB RID: 955
			three_314,
			// Token: 0x040003BC RID: 956
			three_315,
			// Token: 0x040003BD RID: 957
			three_316,
			// Token: 0x040003BE RID: 958
			three_317,
			// Token: 0x040003BF RID: 959
			four_400 = 400,
			// Token: 0x040003C0 RID: 960
			four_401,
			// Token: 0x040003C1 RID: 961
			four_402,
			// Token: 0x040003C2 RID: 962
			four_403,
			// Token: 0x040003C3 RID: 963
			four_404,
			// Token: 0x040003C4 RID: 964
			four_405,
			// Token: 0x040003C5 RID: 965
			four_406,
			// Token: 0x040003C6 RID: 966
			four_407,
			// Token: 0x040003C7 RID: 967
			four_408,
			// Token: 0x040003C8 RID: 968
			four_409,
			// Token: 0x040003C9 RID: 969
			four_410,
			// Token: 0x040003CA RID: 970
			four_411,
			// Token: 0x040003CB RID: 971
			four_412,
			// Token: 0x040003CC RID: 972
			five_500 = 500,
			// Token: 0x040003CD RID: 973
			five_501,
			// Token: 0x040003CE RID: 974
			five_502,
			// Token: 0x040003CF RID: 975
			five_503,
			// Token: 0x040003D0 RID: 976
			six_600 = 600
		}
	}
}
