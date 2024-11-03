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
using GalPhotoAuto.My.Resources;
using GalPhotoAuto.Windows7DesktopIntegration;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C7 RID: 199
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		// Token: 0x06000295 RID: 661 RVA: 0x00028808 File Offset: 0x00026A08
		public Form1()
		{
			base.HandleCreated += this.w;
			base.FormClosing += this.a;
			base.Shown += this.z;
			base.Load += this.v;
			this.a = 0;
			this.b = 0;
			this.c = 0;
			this.a();
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00028884 File Offset: 0x00026A84
		private void n()
		{
			string text = string.Format("{0} {1}({2:d2}:{3:d2}:{4:d2})", new object[]
			{
				global::x.k,
				global::x.ad.getMultiLingual("Form1_Thread_End_Msg_1"),
				global::x.s,
				global::x.r,
				global::x.q
			});
			global::x.c(text);
			this.NotifyIcon1.BalloonTipTitle = global::x.ad.getMultiLingual("Form1_Thread_End_Msg_2");
			this.NotifyIcon1.BalloonTipText = text;
			this.NotifyIcon1.ShowBalloonTip(2000);
			if (0 < global::x.l.Length)
			{
				text = this.TextBox1.Text;
				this.TextBox1.Text = string.Format("{0}{1}", global::x.l.ToString(), text);
			}
			Windows7taskbar.ResetWindows7Progress(this.Handle);
			IntPtr icon;
			Windows7taskbar.SetWindows7OverlayIcon(this.Handle, icon, "");
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0002897C File Offset: 0x00026B7C
		private void m()
		{
			if (0 < global::x.f.Count & 0 < global::x.k)
			{
				try
				{
					foreach (object value in global::x.f)
					{
						string text = Conversions.ToString(value);
						string text2 = text;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string text3 = Path.Combine(Path.GetDirectoryName(text2), "0_YouCanDel");
							if (!Directory.Exists(text3))
							{
								Directory.CreateDirectory(text3);
								global::x.c(global::x.ad.getMultiLingual("Form1_Thread_Mkdir_Msg") + text3);
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
								global::x.c(ex.Message);
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

		// Token: 0x06000298 RID: 664 RVA: 0x00028A9C File Offset: 0x00026C9C
		private void l()
		{
			checked
			{
				if (0 < global::x.g.Count & 0 < global::x.k)
				{
					try
					{
						foreach (object obj in global::x.g)
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
									global::x.c(global::x.ad.getMultiLingual("Form1_Thread_Mkdir_Msg") + text3);
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
								global::x.c(ex.Message);
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

		// Token: 0x06000299 RID: 665 RVA: 0x00028BC8 File Offset: 0x00026DC8
		private void k()
		{
			global::x.m.Clear();
			global::x.n.Clear();
			global::x.e.Clear();
			global::x.f.Clear();
			global::x.g.Clear();
			global::x.l.Clear();
			global::x.h = 0;
			global::x.j = 0;
			global::x.i = 0;
			global::x.k = 0;
			global::x.p = 0;
			global::x.q = 0;
			global::x.r = 0;
			global::x.s = 0;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00028C44 File Offset: 0x00026E44
		public void ShowText1Msg()
		{
			string text = this.TextBox1.Text;
			this.TextBox1.Text = string.Format("{0}{1}", global::x.l.ToString(), text);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00028C80 File Offset: 0x00026E80
		private bool j()
		{
			if (0 < this.ListBox2.Items.Count & 0 < this.ListBox3.Items.Count)
			{
				ListBox listBox = this.ListBox2;
				global::x.a(ref listBox, ref global::x.m);
				this.ListBox2 = listBox;
				listBox = this.ListBox3;
				global::x.a(ref listBox, ref global::x.n);
				this.ListBox3 = listBox;
			}
			if (0 < global::x.m.Count & 0 < global::x.n.Count)
			{
				return true;
			}
			global::x.c(global::x.ad.getMultiLingual("Form1_ListBox_23_Not_Conform_Msg"));
			return false;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00028D20 File Offset: 0x00026F20
		private bool a(string A_0 = "")
		{
			if (0 < this.ListBox4.Items.Count)
			{
				if (!string.IsNullOrWhiteSpace(A_0))
				{
					global::x.z = A_0;
					this.ToolStripStatusLabel1.Text = A_0;
				}
				ListBox listBox = this.ListBox4;
				global::x.a(ref listBox, ref global::x.e);
				this.ListBox4 = listBox;
			}
			if (0 < global::x.e.Count)
			{
				return true;
			}
			global::x.c(global::x.ad.getMultiLingual("Form1_ListBox_4_Not_Conform_Msg"));
			return false;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00028D98 File Offset: 0x00026F98
		private void i()
		{
			int systemMenu = global::x.GetSystemMenu(this.Handle, 0);
			this.a = global::x.CreatePopupMenu();
			int a_ = systemMenu;
			int a_2 = 0;
			int a_3 = 3072;
			int a_4 = 0;
			string text = null;
			global::x.InsertMenu(a_, a_2, a_3, a_4, ref text);
			int a_5 = systemMenu;
			int a_6 = 0;
			int a_7 = 1040;
			int a_8 = this.a;
			text = global::x.ad.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(global::x.d) + ")";
			global::x.InsertMenu(a_5, a_6, a_7, a_8, ref text);
			int a_9 = systemMenu;
			int a_10 = 1024;
			int a_11 = 0;
			text = null;
			global::x.AppendMenu(a_9, a_10, a_11, ref text);
			int a_12 = systemMenu;
			int a_13 = 1024;
			int a_14 = 5999;
			text = global::x.ad.getMultiLingual("MENU_About_Text") + "(&A)";
			global::x.AppendMenu(a_12, a_13, a_14, ref text);
			int num = 1;
			int num2 = global::x.b;
			checked
			{
				for (int i = num; i <= num2; i++)
				{
					int a_15 = this.a;
					int a_16 = 16;
					int a_17 = 6000 + i;
					text = Conversions.ToString(i);
					global::x.AppendMenu(a_15, a_16, a_17, ref text);
					if (i == global::x.d)
					{
						global::x.CheckMenuItem(this.a, 6000 + i, 8);
					}
				}
				int a_18 = systemMenu;
				int a_19 = 1024;
				int a_20 = 0;
				text = null;
				global::x.AppendMenu(a_18, a_19, a_20, ref text);
				this.b = global::x.CreatePopupMenu();
				int a_21 = systemMenu;
				int a_22 = 1040;
				int a_23 = this.b;
				text = "Language";
				global::x.AppendMenu(a_21, a_22, a_23, ref text);
				string strA = global::x.b();
				bool flag = false;
				if (Directory.Exists("lang"))
				{
					this.d = Directory.GetFiles("lang");
					this.c = this.d.Length;
					if (this.c > 0)
					{
						int num3 = Information.LBound(this.d, 1);
						int num4 = Information.UBound(this.d, 1);
						for (int j = num3; j <= num4; j++)
						{
							using (DataSet dataSet = new DataSet())
							{
								dataSet.ReadXml(this.d[j]);
								string text2 = dataSet.Tables["lang"].Rows[0]["name"].ToString();
								global::x.AppendMenu(this.b, 16, 6500 + j, ref text2);
								if (!flag && 0 == string.Compare(strA, Path.GetFileNameWithoutExtension(this.d[j]), StringComparison.Ordinal))
								{
									global::x.CheckMenuItem(this.b, 6500 + j, 8);
									flag = true;
								}
							}
						}
					}
				}
				else
				{
					int a_24 = this.b;
					int a_25 = 16;
					int a_26 = -1;
					text = "None";
					global::x.AppendMenu(a_24, a_25, a_26, ref text);
				}
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00029010 File Offset: 0x00027210
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
						global::t.b().p().ShowDialog();
					}
					else if (num2 >= 6001 && num2 <= 6000 + global::x.b)
					{
						global::x.d = num - 6000;
						int num3 = 6001;
						int num4 = 6000 + global::x.b;
						for (int i = num3; i <= num4; i++)
						{
							global::x.CheckMenuItem(this.a, i, 0);
						}
						global::x.CheckMenuItem(this.a, num, 8);
						int systemMenu = global::x.GetSystemMenu(this.Handle, 0);
						int a_ = 0;
						int a_2 = 1040;
						int a_3 = this.a;
						string text = global::x.ad.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(global::x.d) + ")";
						global::x.ModifyMenu(systemMenu, a_, a_2, a_3, ref text);
						global::x.ag.Update("iUseCpuCore", Conversions.ToString(global::x.d));
						global::x.ag.Save();
					}
					else if (num2 >= 6500 && num2 <= 6500 + this.c)
					{
						this.Hide();
						bool flag = false;
						if (global::t.b().l().Visible)
						{
							global::t.b().l().Hide();
							flag = true;
						}
						int num5 = 6500;
						int num6 = 6500 + this.c;
						for (int j = num5; j <= num6; j++)
						{
							global::x.CheckMenuItem(this.b, j, 0);
						}
						global::x.CheckMenuItem(this.b, num, 8);
						global::x.ae = Path.GetFileNameWithoutExtension(this.d[num - 6500]);
						global::x.ad.setMultiLingual(this.d[num - 6500]);
						this.d();
						global::x.ag.Update("sLastLanguage", global::x.ae);
						global::x.ag.Save();
						if (flag)
						{
							global::t.b().l().Show();
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
							this.g();
							break;
						case 501U:
							this.f();
							break;
						case 502U:
							this.e();
							break;
						}
					}
				}
				base.WndProc(ref m);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000292A4 File Offset: 0x000274A4
		private void a(object A_0, FormClosingEventArgs A_1)
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				global::x.a = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				if (Interaction.MsgBox(global::x.ad.getMultiLingual("Form1_Check_Close_Msg_1"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, global::x.ad.getMultiLingual("Form1_Check_Close_Msg_2")) == MsgBoxResult.Yes)
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
					this.BackgroundWorker1.CancelAsync();
					this.BackgroundWorker2.CancelAsync();
				}
				else
				{
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					A_1.Cancel = true;
					global::x.a = false;
				}
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00029389 File Offset: 0x00027589
		private void a(object A_0, KeyPressEventArgs A_1)
		{
			if (A_1.KeyChar == Convert.ToChar(1))
			{
				((TextBox)A_0).SelectAll();
				A_1.Handled = true;
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x000293AC File Offset: 0x000275AC
		private void h(object A_0, DragEventArgs A_1)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(A_1.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				A_1.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x000293DC File Offset: 0x000275DC
		private void g(object A_0, DragEventArgs A_1)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(A_1.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				A_1.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0002940C File Offset: 0x0002760C
		private void f(object A_0, DragEventArgs A_1)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(A_1.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				A_1.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0002943C File Offset: 0x0002763C
		private void e(object A_0, DragEventArgs A_1)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(A_1.Data.GetData(DataFormats.FileDrop));
			if (objectValue != null)
			{
				A_1.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0002946C File Offset: 0x0002766C
		private void d(object A_0, DragEventArgs A_1)
		{
			string[] array = (string[])A_1.Data.GetData(DataFormats.FileDrop);
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

		// Token: 0x060002A6 RID: 678 RVA: 0x000294E4 File Offset: 0x000276E4
		private void c(object A_0, DragEventArgs A_1)
		{
			string[] array = (string[])A_1.Data.GetData(DataFormats.FileDrop);
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

		// Token: 0x060002A7 RID: 679 RVA: 0x00029540 File Offset: 0x00027740
		private void b(object A_0, DragEventArgs A_1)
		{
			string[] array = (string[])A_1.Data.GetData(DataFormats.FileDrop);
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

		// Token: 0x060002A8 RID: 680 RVA: 0x0002959C File Offset: 0x0002779C
		private void a(object A_0, DragEventArgs A_1)
		{
			string[] array = (string[])A_1.Data.GetData(DataFormats.FileDrop);
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

		// Token: 0x060002A9 RID: 681 RVA: 0x000295F7 File Offset: 0x000277F7
		private void e(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Right && this.ListBox1.SelectedIndex > -1)
			{
				this.ListBox1.Items.RemoveAt(this.ListBox1.SelectedIndex);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0002962F File Offset: 0x0002782F
		private void d(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Right && this.ListBox2.SelectedIndex > -1)
			{
				this.ListBox2.Items.RemoveAt(this.ListBox2.SelectedIndex);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00029667 File Offset: 0x00027867
		private void c(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Right && this.ListBox3.SelectedIndex > -1)
			{
				this.ListBox3.Items.RemoveAt(this.ListBox3.SelectedIndex);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0002969F File Offset: 0x0002789F
		private void b(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Right && this.ListBox4.SelectedIndex > -1)
			{
				this.ListBox4.Items.RemoveAt(this.ListBox4.SelectedIndex);
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000296D7 File Offset: 0x000278D7
		private void ah(object A_0, EventArgs A_1)
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

		// Token: 0x060002AE RID: 686 RVA: 0x00029718 File Offset: 0x00027918
		private void ag(object A_0, EventArgs A_1)
		{
			if (this.ColorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				this.Panel6.BackColor = this.ColorDialog1.Color;
				this.ToolTip1.SetToolTip(this.Panel6, this.Panel6.BackColor.ToString());
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00029774 File Offset: 0x00027974
		private void af(object A_0, EventArgs A_1)
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
			global::t.b().k().WindowState = FormWindowState.Minimized;
			global::t.b().k().Hide();
			global::t.b().k().BackgroundImage = image;
			global::t.b().k().Show();
			global::t.b().k().WindowState = FormWindowState.Maximized;
			graphics.Dispose();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00029845 File Offset: 0x00027A45
		private void ae(object A_0, EventArgs A_1)
		{
			this.RadioButton9.Checked = true;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00029853 File Offset: 0x00027A53
		private void ad(object A_0, EventArgs A_1)
		{
			this.RadioButton10.Checked = true;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00029861 File Offset: 0x00027A61
		private void ac(object A_0, EventArgs A_1)
		{
			this.ag(RuntimeHelpers.GetObjectValue(A_0), A_1);
			this.RadioButton11.Checked = true;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0002987C File Offset: 0x00027A7C
		private void ab(object A_0, EventArgs A_1)
		{
			this.af(RuntimeHelpers.GetObjectValue(A_0), A_1);
			this.RadioButton12.Checked = true;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00029897 File Offset: 0x00027A97
		private void aa(object A_0, EventArgs A_1)
		{
			this.RadioButton6.Checked = true;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000298A8 File Offset: 0x00027AA8
		private void h()
		{
			this.ToolTip1.SetToolTip(this.Panel4, this.Panel4.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel5, this.Panel5.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel6, this.Panel6.BackColor.ToString());
			this.ToolTip1.SetToolTip(this.Panel7, this.Panel7.BackColor.ToString());
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00029960 File Offset: 0x00027B60
		private void z(object A_0, EventArgs A_1)
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
			global::x.c();
			if (!File.Exists(this.e))
			{
				this.TextBox1.Text = Conversions.ToString(DateTime.Now) + " : " + this.e + " file not found.\r\n";
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00029AB8 File Offset: 0x00027CB8
		private void g()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				global::x.a = false;
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00029B0C File Offset: 0x00027D0C
		private void f()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				global::x.a = true;
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00029B60 File Offset: 0x00027D60
		private void e()
		{
			if (this.BackgroundWorker1.IsBusy | this.BackgroundWorker2.IsBusy)
			{
				this.BackgroundWorker1.CancelAsync();
				this.BackgroundWorker2.CancelAsync();
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources._stop2.Handle, "Stop");
				global::x.a = false;
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00029BC8 File Offset: 0x00027DC8
		private void y(object A_0, EventArgs A_1)
		{
			if (this.DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectNotEqual(this.DoubleBufferTreeView1.SelectedNode.Tag, Form1.MergeOptionType.none, false))
			{
				this.DoubleBufferTreeView1.SelectedNode.ForeColor = SystemColors.HighlightText;
				this.DoubleBufferTreeView1.SelectedNode.BackColor = SystemColors.HotTrack;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00029C2C File Offset: 0x00027E2C
		private void x(object A_0, EventArgs A_1)
		{
			if (this.DoubleBufferTreeView1.SelectedNode != null && Operators.ConditionalCompareObjectNotEqual(this.DoubleBufferTreeView1.SelectedNode.Tag, Form1.MergeOptionType.none, false))
			{
				this.DoubleBufferTreeView1.SelectedNode.ForeColor = this.DoubleBufferTreeView1.ForeColor;
				this.DoubleBufferTreeView1.SelectedNode.BackColor = this.DoubleBufferTreeView1.BackColor;
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00029C9C File Offset: 0x00027E9C
		private void w(object A_0, EventArgs A_1)
		{
			Windows7taskbar.Initialization();
			this.c();
			string str = global::x.ae;
			this.e = Path.Combine("lang", str + ".xml");
			if (!File.Exists(this.e))
			{
				str = global::x.b();
				this.e = Path.Combine("lang", str + ".xml");
			}
			if (File.Exists(this.e))
			{
				global::x.ae = str;
				global::x.ad = new MultipleLanguages(this.e);
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(global::x.ae);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false);
			}
			else
			{
				global::x.ad = new MultipleLanguages("");
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00029D6C File Offset: 0x00027F6C
		private void d()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(global::x.ae);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false);
			this.Text = global::x.ad.getMultiLingual("GUI_Form1_Text");
			this.TabPage1.Text = global::x.ad.getMultiLingual("GUI_TabPage1_Text");
			this.Button1.Text = global::x.ad.getMultiLingual("GUI_Button1_Text");
			this.TabPage2.Text = global::x.ad.getMultiLingual("GUI_TabPage2_Text");
			this.RadioButton1.Text = global::x.ad.getMultiLingual("GUI_RadioButton1_Text");
			this.RadioButton2.Text = global::x.ad.getMultiLingual("GUI_RadioButton2_Text");
			this.RadioButton9.Text = global::x.ad.getMultiLingual("GUI_RadioButton9_Text");
			this.RadioButton10.Text = global::x.ad.getMultiLingual("GUI_RadioButton10_Text");
			this.RadioButton11.Text = global::x.ad.getMultiLingual("GUI_RadioButton11_Text");
			this.RadioButton12.Text = global::x.ad.getMultiLingual("GUI_RadioButton12_Text");
			this.RadioButton3.Text = global::x.ad.getMultiLingual("GUI_RadioButton3_Text");
			this.Label1.Text = global::x.ad.getMultiLingual("GUI_Label1_Text");
			this.Label2.Text = global::x.ad.getMultiLingual("GUI_Label2_Text");
			this.Label3.Text = global::x.ad.getMultiLingual("GUI_Label3_Text");
			this.Label4.Text = global::x.ad.getMultiLingual("GUI_Label4_Text");
			this.RadioButton4.Text = global::x.ad.getMultiLingual("GUI_RadioButton4_Text");
			this.RadioButton13.Text = global::x.ad.getMultiLingual("GUI_RadioButton13_Text");
			this.Label6.Text = global::x.ad.getMultiLingual("GUI_Label6_Text");
			this.RadioButton14.Text = global::x.ad.getMultiLingual("GUI_RadioButton14_Text");
			this.Button2.Text = global::x.ad.getMultiLingual("GUI_Button2_Text");
			this.GroupBox1.Text = global::x.ad.getMultiLingual("GUI_GroupBox1_Text");
			this.ComboBox1.Items[0] = global::x.ad.getMultiLingual("GUI_ComboBox1_Text");
			this.ComboBox2.Items[0] = global::x.ad.getMultiLingual("GUI_ComboBox2_Text");
			this.ComboBox3.Items[0] = global::x.ad.getMultiLingual("GUI_ComboBox3_Text");
			this.RadioButton15.Text = global::x.ad.getMultiLingual("GUI_RadioButton15_Text");
			this.RadioButton18.Text = global::x.ad.getMultiLingual("GUI_RadioButton18_Text");
			this.RadioButton19.Text = global::x.ad.getMultiLingual("GUI_RadioButton19_Text");
			this.Label7.Text = global::x.ad.getMultiLingual("GUI_Label7_Text");
			this.RadioButton20.Text = global::x.ad.getMultiLingual("GUI_RadioButton20_Text");
			this.RadioButton21.Text = global::x.ad.getMultiLingual("GUI_RadioButton21_Text");
			this.RadioButton22.Text = global::x.ad.getMultiLingual("GUI_RadioButton22_Text");
			this.Label8.Text = global::x.ad.getMultiLingual("GUI_Label8_Text");
			this.CheckBox5.Text = global::x.ad.getMultiLingual("GUI_CheckBox5_Text");
			global::t.b().k().updateLabelText();
			this.TabPage5.Text = global::x.ad.getMultiLingual("GUI_TabPage5_Text");
			this.GroupBox2.Text = global::x.ad.getMultiLingual("GUI_GroupBox2_Text");
			this.CheckBox3.Text = global::x.ad.getMultiLingual("GUI_CheckBox3_Text");
			this.Button5.Text = global::x.ad.getMultiLingual("GUI_Button5_Text");
			this.Button4.Text = global::x.ad.getMultiLingual("GUI_Button4_Text");
			this.Button6.Text = global::x.ad.getMultiLingual("GUI_Button6_Text");
			this.CheckBox4.Text = global::x.ad.getMultiLingual("GUI_CheckBox4_Text");
			this.GroupBox3.Text = global::x.ad.getMultiLingual("GUI_GroupBox3_Text");
			this.TabPage4.Text = global::x.ad.getMultiLingual("GUI_TabPage4_Text");
			this.Label5.Text = global::x.ad.getMultiLingual("GUI_Label5_Text");
			this.CheckBox2.Text = global::x.ad.getMultiLingual("GUI_CheckBox2_Text");
			this.Button3.Text = global::x.ad.getMultiLingual("GUI_Button3_Text");
			this.TabPage3.Text = global::x.ad.getMultiLingual("GUI_TabPage3_Text");
			this.Button7.Text = global::x.ad.getMultiLingual("GUI_Button7_Text");
			int systemMenu = global::x.GetSystemMenu(this.Handle, 0);
			int a_ = systemMenu;
			int a_2 = 0;
			int a_3 = 1040;
			int a_4 = this.a;
			string text = global::x.ad.getMultiLingual("MENU_CpuProcessor_Text") + " (" + Conversions.ToString(global::x.d) + ")";
			global::x.ModifyMenu(a_, a_2, a_3, a_4, ref text);
			int a_5 = systemMenu;
			int a_6 = 10;
			int a_7 = 1024;
			int a_8 = 5999;
			text = global::x.ad.getMultiLingual("MENU_About_Text") + "(&A)";
			global::x.ModifyMenu(a_5, a_6, a_7, a_8, ref text);
			this.ToolStripMenuItem1.Text = global::x.ad.getMultiLingual("MENU_ToolStripMenuItem1_Text");
			this.ToolStripMenuItem2.Text = global::x.ad.getMultiLingual("MENU_ToolStripMenuItem2_Text");
			this.NotifyIcon1.Text = global::x.ad.getMultiLingual("GUI_Form1_Text");
			this.CheckBox6.Text = global::x.ad.getMultiLingual("GUI_CheckBox6_Text");
			this.RadioButton7.Text = global::x.ad.getMultiLingual("GUI_RadioButton7_Text");
			this.RadioButton8.Text = global::x.ad.getMultiLingual("GUI_RadioButton8_Text");
			this.RadioButton25.Text = global::x.ad.getMultiLingual("GUI_RadioButton25_Text");
			this.RadioButton26.Text = global::x.ad.getMultiLingual("GUI_RadioButton26_Text");
			this.Label9.Text = global::x.ad.getMultiLingual("GUI_Label9_Text");
			this.b();
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
				global::x.a(ref comboBox);
				this.ComboBox2 = comboBox;
				comboBox = this.ComboBox3;
				global::x.a(ref comboBox);
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
				global::t.b().l().initLanguage();
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0002A6B0 File Offset: 0x000288B0
		private void c()
		{
			bool flag = false;
			string text = global::x.ag.getValue("iThreadWaitingTime");
			if (Versioned.IsNumeric(text))
			{
				global::x.c = Conversions.ToInteger(text);
			}
			else
			{
				global::x.ag.Remove("iThreadWaitingTime");
				global::x.ag.Add("iThreadWaitingTime", "100");
				global::x.c = 100;
				flag = true;
			}
			text = global::x.ag.getValue("iUseCpuCore");
			if (Versioned.IsNumeric(text))
			{
				global::x.d = Conversions.ToInteger(text);
			}
			else
			{
				global::x.ag.Remove("iUseCpuCore");
				global::x.ag.Add("iUseCpuCore", Conversions.ToString(global::x.b));
				global::x.d = global::x.b;
				flag = true;
			}
			text = global::x.ag.getValue("sLastLanguage");
			if (string.IsNullOrEmpty(text))
			{
				global::x.ag.Remove("sLastLanguage");
				text = global::x.b();
				global::x.ag.Add("sLastLanguage", text);
				global::x.ae = text;
				flag = true;
			}
			else
			{
				global::x.ae = text;
			}
			text = global::x.ag.getValue("iNumUpDown5");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown5.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown5");
				global::x.ag.Add("iNumUpDown5", "100");
				this.NumericUpDown5.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("iNumUpDown6");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown6.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown6");
				global::x.ag.Add("iNumUpDown6", "100");
				this.NumericUpDown6.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("p2SaveBitmapFormat");
			if (Versioned.IsNumeric(text))
			{
				this.ComboBox4.SelectedIndex = Conversions.ToInteger(text);
			}
			else
			{
				global::x.ag.Remove("p2SaveBitmapFormat");
				global::x.ag.Add("p2SaveBitmapFormat", "0");
				flag = true;
				this.ComboBox4.SelectedIndex = 0;
			}
			text = global::x.ag.getValue("iNumUpDown13");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown13.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown13");
				global::x.ag.Add("iNumUpDown13", "100");
				this.NumericUpDown13.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("iNumUpDown8");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown8.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown8");
				global::x.ag.Add("iNumUpDown8", "100");
				this.NumericUpDown8.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("iNumUpDown12");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown12.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown12");
				global::x.ag.Add("iNumUpDown12", "100");
				this.NumericUpDown12.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("i2CheckHash");
			if (Versioned.IsNumeric(text))
			{
				global::x.x = Conversions.ToInteger(Conversion.Int(text));
			}
			else
			{
				global::x.ag.Remove("i2CheckHash");
				global::x.ag.Add("i2CheckHash", "0");
				flag = true;
			}
			text = global::x.ag.getValue("iNumUpDown16");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown16.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown16");
				global::x.ag.Add("iNumUpDown16", "100");
				this.NumericUpDown16.Value = 100m;
				flag = true;
			}
			text = global::x.ag.getValue("iNumUpDown17");
			if (Versioned.IsNumeric(text))
			{
				this.NumericUpDown17.Value = new decimal(Conversions.ToInteger(text));
			}
			else
			{
				global::x.ag.Remove("iNumUpDown17");
				global::x.ag.Add("iNumUpDown17", "100");
				this.NumericUpDown17.Value = 100m;
				flag = true;
			}
			if (flag)
			{
				global::x.ag.Save();
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0002AB48 File Offset: 0x00028D48
		private void b(object A_0, DoWorkEventArgs A_1)
		{
			this.k();
			if (this.BackgroundWorker1.CancellationPending)
			{
				A_1.Cancel = true;
			}
			else if (this.RadioButton2.Checked)
			{
				Form1 form = this;
				if (BW1.TransparentImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton3.Checked)
			{
				Form1 form = this;
				if (BW1.cutImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton4.Checked)
			{
				Form1 form = this;
				if (BW1.scan32BitImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton13.Checked)
			{
				Form1 form = this;
				ArrayList arrayList = (ArrayList)A_1.Argument;
				if (BW1.ConvertImageFormatToX(ref form, ref arrayList))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton14.Checked)
			{
				Form1 form = this;
				if (BW1.checkBlackAlphaCutImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton15.Checked)
			{
				Form1 form = this;
				if (BW1.defineWidthCutImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton20.Checked)
			{
				Form1 form = this;
				if (BW1.defineHeightCutImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
			else if (this.RadioButton7.Checked)
			{
				Form1 form = this;
				if (BW1.reSizeImage(ref form))
				{
					A_1.Cancel = true;
				}
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0002ACA0 File Offset: 0x00028EA0
		private void b(object A_0, ProgressChangedEventArgs A_1)
		{
			this.Button2.Text = Conversions.ToString(global::x.k);
			checked
			{
				if (global::x.i > global::x.j)
				{
					global::x.j += global::x.i / 2;
				}
				if (0 == A_1.ProgressPercentage)
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.INDETERMINATE);
				}
				else
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					Windows7taskbar.SetWindows7Progress(this.Handle, global::x.i, global::x.j);
				}
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0002AD18 File Offset: 0x00028F18
		private void b(object A_0, RunWorkerCompletedEventArgs A_1)
		{
			global::x.z = string.Empty;
			global::x.aa = string.Empty;
			this.ToolStripStatusLabel1.Text = string.Empty;
			this.ToolStripStatusLabel2.Text = string.Empty;
			if (!A_1.Cancelled)
			{
				if (this.CheckBox5.Checked)
				{
					try
					{
						foreach (object value in global::x.f)
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
								global::x.c(ex.Message + " : " + text);
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
				this.m();
			}
			IL_BF:
			this.Button2.Text = global::x.ad.getMultiLingual("GUI_Button2_Text");
			this.GroupBox1.Enabled = true;
			this.CheckBox5.Enabled = true;
			this.Timer1.Stop();
			this.n();
			this.ToolStripStatusLabel5.Text = "00:00:00";
			global::x.y.Clear();
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0002AE60 File Offset: 0x00029060
		private void b()
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
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_100")
					},
					new TreeNode
					{
						Name = "one_101",
						Tag = Form1.MergeOptionType.one_101,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_101")
					},
					new TreeNode
					{
						Name = "one_102",
						Tag = Form1.MergeOptionType.one_102,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_102")
					},
					new TreeNode
					{
						Name = "one_103",
						Tag = Form1.MergeOptionType.one_103,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_103")
					},
					new TreeNode
					{
						Name = "one_112",
						Tag = Form1.MergeOptionType.one_112,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_112")
					},
					new TreeNode
					{
						Name = "one_109",
						Tag = Form1.MergeOptionType.one_109,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_109")
					},
					new TreeNode
					{
						Name = "one_120",
						Tag = Form1.MergeOptionType.one_120,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_120")
					}
				})
				{
					Name = "one_xy_offset",
					Tag = Form1.MergeOptionType.none,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_xy_offset"),
					BackColor = backColor
				},
				new TreeNode("one_name_with_m", new TreeNode[]
				{
					new TreeNode
					{
						Name = "one_117",
						Tag = Form1.MergeOptionType.one_117,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_117")
					},
					new TreeNode
					{
						Name = "one_118",
						Tag = Form1.MergeOptionType.one_118,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_118")
					},
					new TreeNode
					{
						Name = "one_104",
						Tag = Form1.MergeOptionType.one_104,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_104")
					},
					new TreeNode
					{
						Name = "one_121",
						Tag = Form1.MergeOptionType.one_121,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_121")
					},
					new TreeNode
					{
						Name = "one_106",
						Tag = Form1.MergeOptionType.one_106,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_106")
					},
					new TreeNode
					{
						Name = "one_111",
						Tag = Form1.MergeOptionType.one_111,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_111")
					},
					new TreeNode
					{
						Name = "one_119",
						Tag = Form1.MergeOptionType.one_119,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_119")
					}
				})
				{
					Name = "one_name_with_m",
					Tag = Form1.MergeOptionType.none,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_name_with_m"),
					BackColor = backColor
				},
				new TreeNode
				{
					Name = "one_105",
					Tag = Form1.MergeOptionType.one_105,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_105")
				},
				new TreeNode
				{
					Name = "one_107",
					Tag = Form1.MergeOptionType.one_107,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_107")
				},
				new TreeNode
				{
					Name = "one_108",
					Tag = Form1.MergeOptionType.one_108,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_108")
				},
				new TreeNode
				{
					Name = "one_110",
					Tag = Form1.MergeOptionType.one_110,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_110")
				},
				new TreeNode("one_scan_b_scan_f", new TreeNode[]
				{
					new TreeNode
					{
						Name = "one_113",
						Tag = Form1.MergeOptionType.one_113,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_113")
					},
					new TreeNode
					{
						Name = "one_114",
						Tag = Form1.MergeOptionType.one_114,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_114")
					},
					new TreeNode
					{
						Name = "one_115",
						Tag = Form1.MergeOptionType.one_115,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_115")
					},
					new TreeNode
					{
						Name = "one_116",
						Tag = Form1.MergeOptionType.one_116,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_116")
					}
				})
				{
					Name = "one_scan_b_scan_f",
					Tag = Form1.MergeOptionType.none,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_scan_b_scan_f"),
					BackColor = backColor
				},
				new TreeNode
				{
					Name = "one_122",
					Tag = Form1.MergeOptionType.one_122,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one_122")
				}
			});
			treeNode.Name = "one";
			treeNode.Tag = Form1.MergeOptionType.none;
			treeNode.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_one");
			treeNode.BackColor = backColor;
			TreeNode treeNode2 = new TreeNode("RioShiina（ZeaS版）解包的的立绘合成。如：XXXXXX@0000_pos_数字_数字.bmp", new TreeNode[]
			{
				new TreeNode
				{
					Name = "two_200",
					Tag = Form1.MergeOptionType.two_200,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two_200")
				},
				new TreeNode
				{
					Name = "two_201",
					Tag = Form1.MergeOptionType.two_201,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two_201")
				},
				new TreeNode
				{
					Name = "two_202",
					Tag = Form1.MergeOptionType.two_202,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two_202")
				},
				new TreeNode
				{
					Name = "two_203",
					Tag = Form1.MergeOptionType.two_203,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two_203")
				},
				new TreeNode
				{
					Name = "two_204",
					Tag = Form1.MergeOptionType.two_204,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two_204")
				}
			});
			treeNode2.Name = "two";
			treeNode2.Tag = Form1.MergeOptionType.none;
			treeNode2.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_two");
			treeNode2.BackColor = backColor;
			TreeNode treeNode3 = new TreeNode("asd 脚本系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_300",
					Tag = Form1.MergeOptionType.three_300,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_300")
				},
				new TreeNode
				{
					Name = "three_301",
					Tag = Form1.MergeOptionType.three_301,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_301")
				},
				new TreeNode
				{
					Name = "three_313",
					Tag = Form1.MergeOptionType.three_313,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_313")
				}
			});
			treeNode3.Name = "three_asd_sc";
			treeNode3.Tag = Form1.MergeOptionType.none;
			treeNode3.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_asd_sc");
			treeNode3.BackColor = backColor;
			TreeNode treeNode4 = new TreeNode();
			treeNode4.Name = "three_302";
			treeNode4.Tag = Form1.MergeOptionType.three_302;
			treeNode4.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_302");
			TreeNode treeNode5 = new TreeNode();
			treeNode5.Name = "three_303";
			treeNode5.Tag = Form1.MergeOptionType.three_303;
			treeNode5.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_303");
			TreeNode treeNode6 = new TreeNode();
			treeNode6.Name = "three_304";
			treeNode6.Tag = Form1.MergeOptionType.three_304;
			treeNode6.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_304");
			TreeNode treeNode7 = new TreeNode();
			treeNode7.Name = "three_305";
			treeNode7.Tag = Form1.MergeOptionType.three_305;
			treeNode7.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_305");
			TreeNode treeNode8 = new TreeNode();
			treeNode8.Name = "three_306";
			treeNode8.Tag = Form1.MergeOptionType.three_306;
			treeNode8.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_306");
			TreeNode treeNode9 = new TreeNode();
			treeNode9.Name = "three_307";
			treeNode9.Tag = Form1.MergeOptionType.three_307;
			treeNode9.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_307");
			TreeNode treeNode10 = new TreeNode();
			treeNode10.Name = "three_308";
			treeNode10.Tag = Form1.MergeOptionType.three_308;
			treeNode10.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_308");
			TreeNode treeNode11 = new TreeNode("xxx_info.txt + xxx.txt 系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_309",
					Tag = Form1.MergeOptionType.three_309,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_309")
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
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_312")
				}
			});
			treeNode11.Name = "three_txtinfo";
			treeNode11.Tag = Form1.MergeOptionType.none;
			treeNode11.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_txtinfo");
			treeNode11.BackColor = backColor;
			TreeNode treeNode12 = new TreeNode("pos + anm + asd 系列", new TreeNode[]
			{
				new TreeNode
				{
					Name = "three_310",
					Tag = Form1.MergeOptionType.three_310,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_310")
				},
				new TreeNode
				{
					Name = "three_311",
					Tag = Form1.MergeOptionType.three_311,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_311")
				}
			});
			treeNode12.Name = "three_pos";
			treeNode12.Tag = Form1.MergeOptionType.none;
			treeNode12.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_pos");
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
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_314")
					}
				})
				{
					Name = "three_asd_sc",
					Tag = Form1.MergeOptionType.none,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_tjs_sc"),
					BackColor = backColor
				},
				new TreeNode("ks 脚本系列", new TreeNode[]
				{
					new TreeNode
					{
						Name = "three_315",
						Tag = Form1.MergeOptionType.three_315,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_315")
					},
					new TreeNode
					{
						Name = "three_316",
						Tag = Form1.MergeOptionType.three_316,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_316")
					},
					new TreeNode
					{
						Name = "three_317",
						Tag = Form1.MergeOptionType.three_317,
						Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_317")
					}
				})
				{
					Name = "three_asd_sc",
					Tag = Form1.MergeOptionType.none,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three_ks_sc"),
					BackColor = backColor
				},
				treeNode11,
				treeNode12
			});
			treeNode13.Name = "three";
			treeNode13.Tag = Form1.MergeOptionType.none;
			treeNode13.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_three");
			treeNode13.BackColor = backColor;
			TreeNode treeNode14 = new TreeNode();
			treeNode14.Name = "four_400";
			treeNode14.Tag = Form1.MergeOptionType.four_400;
			treeNode14.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_400");
			TreeNode treeNode15 = new TreeNode();
			treeNode15.Name = "four_401";
			treeNode15.Tag = Form1.MergeOptionType.four_401;
			treeNode15.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_401");
			TreeNode treeNode16 = new TreeNode();
			treeNode16.Name = "four_402";
			treeNode16.Tag = Form1.MergeOptionType.four_402;
			treeNode16.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_402");
			TreeNode treeNode17 = new TreeNode();
			treeNode17.Name = "four_403";
			treeNode17.Tag = Form1.MergeOptionType.four_403;
			treeNode17.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_403");
			TreeNode treeNode18 = new TreeNode();
			treeNode18.Name = "four_404";
			treeNode18.Tag = Form1.MergeOptionType.four_404;
			treeNode18.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_404");
			TreeNode treeNode19 = new TreeNode();
			treeNode19.Name = "four_405";
			treeNode19.Tag = Form1.MergeOptionType.four_405;
			treeNode19.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_405");
			TreeNode treeNode20 = new TreeNode();
			treeNode20.Name = "four_406";
			treeNode20.Tag = Form1.MergeOptionType.four_406;
			treeNode20.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_406");
			TreeNode treeNode21 = new TreeNode();
			treeNode21.Name = "four_407";
			treeNode21.Tag = Form1.MergeOptionType.four_407;
			treeNode21.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_407");
			TreeNode treeNode22 = new TreeNode();
			treeNode22.Name = "four_408";
			treeNode22.Tag = Form1.MergeOptionType.four_408;
			treeNode22.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_408");
			TreeNode treeNode23 = new TreeNode();
			treeNode23.Name = "four_409";
			treeNode23.Tag = Form1.MergeOptionType.four_409;
			treeNode23.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_409");
			TreeNode treeNode24 = new TreeNode();
			treeNode24.Name = "four_410";
			treeNode24.Tag = Form1.MergeOptionType.four_410;
			treeNode24.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_410");
			TreeNode treeNode25 = new TreeNode();
			treeNode25.Name = "four_411";
			treeNode25.Tag = Form1.MergeOptionType.four_411;
			treeNode25.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_411");
			TreeNode treeNode26 = new TreeNode("asmodean 的工具解包后的合成", new TreeNode[]
			{
				treeNode14,
				new TreeNode
				{
					Name = "four_412",
					Tag = Form1.MergeOptionType.four_412,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four_412")
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
			treeNode26.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_four");
			treeNode26.BackColor = backColor;
			TreeNode treeNode27 = new TreeNode();
			treeNode27.Name = "five_500";
			treeNode27.Tag = Form1.MergeOptionType.five_500;
			treeNode27.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_five_500");
			TreeNode treeNode28 = new TreeNode();
			treeNode28.Name = "five_501";
			treeNode28.Tag = Form1.MergeOptionType.five_501;
			treeNode28.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_five_501");
			TreeNode treeNode29 = new TreeNode("crass 的工具解包后的合成", new TreeNode[]
			{
				treeNode27,
				new TreeNode
				{
					Name = "five_502",
					Tag = Form1.MergeOptionType.five_502,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_five_502")
				},
				treeNode28,
				new TreeNode
				{
					Name = "five_503",
					Tag = Form1.MergeOptionType.five_503,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_five_503")
				}
			});
			treeNode29.Name = "five";
			treeNode29.Tag = Form1.MergeOptionType.none;
			treeNode29.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_five");
			treeNode29.BackColor = backColor;
			TreeNode treeNode30 = new TreeNode("westside 的工具解包后的合成", new TreeNode[]
			{
				new TreeNode
				{
					Name = "six_600",
					Tag = Form1.MergeOptionType.six_600,
					Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_six_600")
				}
			});
			treeNode30.Name = "six";
			treeNode30.Tag = Form1.MergeOptionType.none;
			treeNode30.Text = global::x.ad.getMultiLingual("BW2_DBTV1_TreeNode_six");
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

		// Token: 0x060002C3 RID: 707 RVA: 0x0002C344 File Offset: 0x0002A544
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

		// Token: 0x060002C4 RID: 708 RVA: 0x0002C3D4 File Offset: 0x0002A5D4
		private void a(object A_0, DoWorkEventArgs A_1)
		{
			global::x.w.Clear();
			int num = Conversions.ToInteger(A_1.Argument);
			if (0 >= num)
			{
				return;
			}
			this.k();
			if (this.BackgroundWorker2.CancellationPending)
			{
				A_1.Cancel = true;
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
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 1))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 101)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 2))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 102)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 3))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 103)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 4))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 104)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_m(ref form, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 121)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_m(ref form, true))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 107)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_sou_plus_alpha(ref form, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 105)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_sou_plus_alpha(ref form, true))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 106)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_xxx_mxxx(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 108)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_image_find_area_merge(ref form, 0))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 109)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_noWhitelookBlack(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 110)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_image_find_area_merge(ref form, 1))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 111)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_image_M_and_xy(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 112)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_in(ref form, 5))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 113)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 1))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 114)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 2))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 115)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 3))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 116)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.scan_b_scan_f_find_line_merge(ref form, 4))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 117)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_L_alpha_R_image(ref form, 0))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 118)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_L_alpha_R_image(ref form, 1))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 119)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_MS_M(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 120)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_one.merge_image_white_alpha_to_tran(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 122)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_one.merge_image_abc_01_abc_xy(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 200)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, false, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 201)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, false, true))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 202)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode1(ref form, true, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 >= 203 && num2 <= 204)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_two.RioShiina_ZeaS_mode2(ref form, num))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 300)
						{
							if (this.a("asd"))
							{
								Form1 form = this;
								if (BW2_three.asd_png__a(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 301)
						{
							if (this.a("asd"))
							{
								Form1 form = this;
								if (BW2_three.asd__a__a_m(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 302)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_info_V1(ref form, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 303)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_info_V1(ref form, true))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 304)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_X_stand(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 305)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfff(ref form, true))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 306)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfff(ref form, false))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 307)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfa(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 308)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_df(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 309)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.ChangeImageByTxt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 310)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_three.pos_anm_asd_1(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 311)
						{
							if (this.a("pos"))
							{
								Form1 form = this;
								if (BW2_three.pos_anm_asd_2(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 312)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_three.X_info_X_txt_ddfr(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 313)
						{
							if (this.a("cgm"))
							{
								Form1 form = this;
								if (BW2_three.cgm_asd(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 314)
						{
							if (this.a("tjs"))
							{
								Form1 form = this;
								if (BW2_three.merge_imageObject_tjs(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 315)
						{
							if (this.a("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_tjs_txt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 316)
						{
							if (this.a("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_cg_mode_first(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 317)
						{
							if (this.a("ks"))
							{
								Form1 form = this;
								if (BW2_three.merge_ks_width_gamename(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 400)
						{
							if (this.j())
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exl6ren_xy(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 401)
						{
							if (this.a("dat"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exszs_tig2png_dat(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 402)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exef2paz_xy(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 403)
						{
							if (this.a("*"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exchpac_spm_visual(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 404)
						{
							if (this.a("dzi"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exdieslib_dzi_svg(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 405)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exoozoarc_txt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 406)
						{
							if (this.a("evt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exyatpkg_lua_evt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 407)
						{
							if (this.a("mng"))
							{
								Form1 form = this;
								if (BW2_four.extract_ad_exsteldat_mng(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 408)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exmed_bgset_sprset(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 409)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exanepak_chaNX00_chaNXYZ(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 410)
						{
							if (this.a("lsf"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exescarc_lsf(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 411)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_expimg_txt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 412)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_four.merge_ad_exl6ren_automcg(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 500)
						{
							if (this.a("bin"))
							{
								Form1 form = this;
								if (BW2_five.crass_PJADV(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 501)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_five.crass_NScripter(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 502)
						{
							if (this.a("anm"))
							{
								Form1 form = this;
								if (BW2_five.crass_PJADV_anm(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 503)
						{
							if (this.a(""))
							{
								Form1 form = this;
								if (BW2_five.crass_DDSystem_tga(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
						else if (num2 == 600)
						{
							if (this.a("txt"))
							{
								Form1 form = this;
								if (BW2_six.merge_ws_ippaiscv_txt(ref form))
								{
									A_1.Cancel = true;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					global::x.c(ex.Message);
					throw new Exception(ex.Message);
				}
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0002CF64 File Offset: 0x0002B164
		private void a(object A_0, ProgressChangedEventArgs A_1)
		{
			this.Button3.Text = Conversions.ToString(global::x.k);
			checked
			{
				if (global::x.i > global::x.j)
				{
					global::x.j += global::x.i / 2;
				}
				if (0 == A_1.ProgressPercentage)
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.INDETERMINATE);
				}
				else
				{
					Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.NORMAL);
					Windows7taskbar.SetWindows7Progress(this.Handle, global::x.i, global::x.j);
				}
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0002CFDC File Offset: 0x0002B1DC
		private void a(object A_0, RunWorkerCompletedEventArgs A_1)
		{
			global::x.z = string.Empty;
			global::x.aa = string.Empty;
			this.ToolStripStatusLabel1.Text = string.Empty;
			this.ToolStripStatusLabel2.Text = string.Empty;
			if (!this.CheckBox2.Checked && !A_1.Cancelled)
			{
				this.m();
				this.l();
			}
			if (this.CheckBox3.Checked)
			{
				this.ListBox2.Items.Clear();
				global::x.m.Clear();
			}
			if (this.CheckBox4.Checked)
			{
				this.ListBox3.Items.Clear();
				global::x.n.Clear();
			}
			this.Button3.Text = global::x.ad.getMultiLingual("GUI_Button2_Text");
			this.DoubleBufferTreeView1.Enabled = true;
			this.Panel1.Enabled = true;
			this.Timer1.Stop();
			this.n();
			this.ToolStripStatusLabel5.Text = "00:00:00";
			global::x.w.Clear();
			global::x.y.Clear();
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0002D134 File Offset: 0x0002B334
		[DebuggerStepThrough]
		private void a()
		{
			this.f = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.TabControl1 = new TabControl();
			this.TabPage1 = new TabPage();
			this.TableLayoutPanel1 = new TableLayoutPanel();
			this.ListBox1 = new ListBox();
			this.Button1 = new Button();
			this.TabPage2 = new TabPage();
			this.TableLayoutPanel2 = new TableLayoutPanel();
			this.GroupBox1 = new GroupBox();
			this.Panel8 = new Panel();
			this.Panel10 = new Panel();
			this.NumericUpDown17 = new NumericUpDown();
			this.RadioButton27 = new RadioButton();
			this.RadioButton28 = new RadioButton();
			this.Label9 = new Label();
			this.FlowLayoutPanel9 = new FlowLayoutPanel();
			this.RadioButton8 = new RadioButton();
			this.NumericUpDown14 = new NumericUpDown();
			this.RadioButton25 = new RadioButton();
			this.NumericUpDown15 = new NumericUpDown();
			this.RadioButton26 = new RadioButton();
			this.NumericUpDown16 = new NumericUpDown();
			this.RadioButton7 = new RadioButton();
			this.FlowLayoutPanel7 = new FlowLayoutPanel();
			this.FlowLayoutPanel8 = new FlowLayoutPanel();
			this.RadioButton21 = new RadioButton();
			this.NumericUpDown10 = new NumericUpDown();
			this.RadioButton22 = new RadioButton();
			this.NumericUpDown11 = new NumericUpDown();
			this.Label8 = new Label();
			this.Panel9 = new Panel();
			this.NumericUpDown12 = new NumericUpDown();
			this.RadioButton23 = new RadioButton();
			this.RadioButton24 = new RadioButton();
			this.RadioButton20 = new RadioButton();
			this.RadioButton15 = new RadioButton();
			this.FlowLayoutPanel3 = new FlowLayoutPanel();
			this.ComboBox1 = new ComboBox();
			this.ComboBox2 = new ComboBox();
			this.Label6 = new Label();
			this.ComboBox3 = new ComboBox();
			this.NumericUpDown6 = new NumericUpDown();
			this.CheckBox6 = new CheckBox();
			this.FlowLayoutPanel2 = new FlowLayoutPanel();
			this.Label1 = new Label();
			this.NumericUpDown1 = new NumericUpDown();
			this.Label2 = new Label();
			this.NumericUpDown2 = new NumericUpDown();
			this.Label3 = new Label();
			this.NumericUpDown3 = new NumericUpDown();
			this.Label4 = new Label();
			this.NumericUpDown4 = new NumericUpDown();
			this.FlowLayoutPanel1 = new FlowLayoutPanel();
			this.RadioButton9 = new RadioButton();
			this.Panel4 = new Panel();
			this.RadioButton10 = new RadioButton();
			this.Panel5 = new Panel();
			this.RadioButton11 = new RadioButton();
			this.Panel6 = new Panel();
			this.RadioButton12 = new RadioButton();
			this.Panel7 = new Panel();
			this.RadioButton14 = new RadioButton();
			this.RadioButton1 = new RadioButton();
			this.Panel2 = new Panel();
			this.CheckBox1 = new CheckBox();
			this.NumericUpDown5 = new NumericUpDown();
			this.RadioButton6 = new RadioButton();
			this.RadioButton5 = new RadioButton();
			this.RadioButton2 = new RadioButton();
			this.RadioButton3 = new RadioButton();
			this.RadioButton13 = new RadioButton();
			this.RadioButton4 = new RadioButton();
			this.FlowLayoutPanel5 = new FlowLayoutPanel();
			this.FlowLayoutPanel6 = new FlowLayoutPanel();
			this.RadioButton18 = new RadioButton();
			this.NumericUpDown7 = new NumericUpDown();
			this.RadioButton19 = new RadioButton();
			this.NumericUpDown9 = new NumericUpDown();
			this.Label7 = new Label();
			this.Panel3 = new Panel();
			this.NumericUpDown8 = new NumericUpDown();
			this.RadioButton16 = new RadioButton();
			this.RadioButton17 = new RadioButton();
			this.Button2 = new Button();
			this.CheckBox5 = new CheckBox();
			this.TabPage5 = new TabPage();
			this.TableLayoutPanel3 = new TableLayoutPanel();
			this.GroupBox2 = new GroupBox();
			this.TableLayoutPanel4 = new TableLayoutPanel();
			this.ListBox2 = new ListBox();
			this.ListBox3 = new ListBox();
			this.GroupBox3 = new GroupBox();
			this.ListBox4 = new ListBox();
			this.TableLayoutPanel7 = new TableLayoutPanel();
			this.Button4 = new Button();
			this.Button5 = new Button();
			this.Button6 = new Button();
			this.CheckBox3 = new CheckBox();
			this.CheckBox4 = new CheckBox();
			this.TabPage4 = new TabPage();
			this.TableLayoutPanel5 = new TableLayoutPanel();
			this.Button3 = new Button();
			this.Panel1 = new Panel();
			this.CheckBox2 = new CheckBox();
			this.FlowLayoutPanel4 = new FlowLayoutPanel();
			this.Label5 = new Label();
			this.ComboBox4 = new ComboBox();
			this.NumericUpDown13 = new NumericUpDown();
			this.Button7 = new Button();
			this.TabPage3 = new TabPage();
			this.TextBox1 = new TextBox();
			this.BackgroundWorker1 = new BackgroundWorker();
			this.BackgroundWorker2 = new BackgroundWorker();
			this.ColorDialog1 = new ColorDialog();
			this.ToolTip1 = new ToolTip(this.f);
			this.NotifyIcon1 = new NotifyIcon(this.f);
			this.ContextMenuStrip1 = new ContextMenuStrip(this.f);
			this.ToolStripMenuItem1 = new ToolStripMenuItem();
			this.ToolStripSeparator1 = new ToolStripSeparator();
			this.ToolStripMenuItem2 = new ToolStripMenuItem();
			this.Timer1 = new System.Windows.Forms.Timer(this.f);
			this.StatusStrip1 = new StatusStrip();
			this.ToolStripStatusLabel1 = new ToolStripStatusLabel();
			this.ToolStripStatusLabel2 = new ToolStripStatusLabel();
			this.ToolStripStatusLabel3 = new ToolStripStatusLabel();
			this.ToolStripStatusLabel4 = new ToolStripStatusLabel();
			this.ToolStripStatusLabel5 = new ToolStripStatusLabel();
			this.TableLayoutPanel6 = new TableLayoutPanel();
			this.SplitterLabel9 = new SplitterLabel();
			this.SplitterLabel8 = new SplitterLabel();
			this.SplitterLabel7 = new SplitterLabel();
			this.SplitterLabel6 = new SplitterLabel();
			this.SplitterLabel2 = new SplitterLabel();
			this.SplitterLabel1 = new SplitterLabel();
			this.SplitterLabel5 = new SplitterLabel();
			this.SplitterLabel4 = new SplitterLabel();
			this.SplitterLabel3 = new SplitterLabel();
			this.DoubleBufferTreeView1 = new DoubleBufferTreeView();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TableLayoutPanel1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TableLayoutPanel2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.Panel8.SuspendLayout();
			this.Panel10.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown17).BeginInit();
			this.FlowLayoutPanel9.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown14).BeginInit();
			((ISupportInitialize)this.NumericUpDown15).BeginInit();
			((ISupportInitialize)this.NumericUpDown16).BeginInit();
			this.FlowLayoutPanel7.SuspendLayout();
			this.FlowLayoutPanel8.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown10).BeginInit();
			((ISupportInitialize)this.NumericUpDown11).BeginInit();
			this.Panel9.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown12).BeginInit();
			this.FlowLayoutPanel3.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown6).BeginInit();
			this.FlowLayoutPanel2.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown1).BeginInit();
			((ISupportInitialize)this.NumericUpDown2).BeginInit();
			((ISupportInitialize)this.NumericUpDown3).BeginInit();
			((ISupportInitialize)this.NumericUpDown4).BeginInit();
			this.FlowLayoutPanel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown5).BeginInit();
			this.FlowLayoutPanel5.SuspendLayout();
			this.FlowLayoutPanel6.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown7).BeginInit();
			((ISupportInitialize)this.NumericUpDown9).BeginInit();
			this.Panel3.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown8).BeginInit();
			this.TabPage5.SuspendLayout();
			this.TableLayoutPanel3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.TableLayoutPanel4.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.TableLayoutPanel7.SuspendLayout();
			this.TabPage4.SuspendLayout();
			this.TableLayoutPanel5.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.FlowLayoutPanel4.SuspendLayout();
			((ISupportInitialize)this.NumericUpDown13).BeginInit();
			this.TabPage3.SuspendLayout();
			this.ContextMenuStrip1.SuspendLayout();
			this.StatusStrip1.SuspendLayout();
			this.TableLayoutPanel6.SuspendLayout();
			this.SuspendLayout();
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Controls.Add(this.TabPage5);
			this.TabControl1.Controls.Add(this.TabPage4);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Dock = DockStyle.Fill;
			Control tabControl = this.TabControl1;
			Point location = new Point(3, 3);
			tabControl.Location = location;
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			Control tabControl2 = this.TabControl1;
			Size size = new Size(620, 436);
			tabControl2.Size = size;
			this.TabControl1.TabIndex = 0;
			this.TabPage1.BackColor = Color.Transparent;
			this.TabPage1.Controls.Add(this.TableLayoutPanel1);
			TabPage tabPage = this.TabPage1;
			location = new Point(4, 22);
			tabPage.Location = location;
			this.TabPage1.Name = "TabPage1";
			Control tabPage2 = this.TabPage1;
			Padding padding = new Padding(3);
			tabPage2.Padding = padding;
			Control tabPage3 = this.TabPage1;
			size = new Size(612, 410);
			tabPage3.Size = size;
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "（1）添加处理图片";
			this.TableLayoutPanel1.ColumnCount = 1;
			this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel1.Controls.Add(this.ListBox1, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Button1, 0, 1);
			this.TableLayoutPanel1.Dock = DockStyle.Fill;
			Control tableLayoutPanel = this.TableLayoutPanel1;
			location = new Point(3, 3);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 2;
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
			Control tableLayoutPanel2 = this.TableLayoutPanel1;
			size = new Size(606, 404);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 2;
			this.ListBox1.AllowDrop = true;
			this.ListBox1.Dock = DockStyle.Fill;
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.HorizontalScrollbar = true;
			this.ListBox1.ItemHeight = 12;
			Control listBox = this.ListBox1;
			location = new Point(3, 3);
			listBox.Location = location;
			this.ListBox1.Name = "ListBox1";
			Control listBox2 = this.ListBox1;
			size = new Size(600, 358);
			listBox2.Size = size;
			this.ListBox1.TabIndex = 0;
			this.Button1.Anchor = AnchorStyles.Bottom;
			Control button = this.Button1;
			location = new Point(253, 371);
			button.Location = location;
			this.Button1.Name = "Button1";
			Control button2 = this.Button1;
			size = new Size(100, 30);
			button2.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "清 空";
			this.Button1.UseVisualStyleBackColor = true;
			this.TabPage2.BackColor = Color.Transparent;
			this.TabPage2.Controls.Add(this.TableLayoutPanel2);
			TabPage tabPage4 = this.TabPage2;
			location = new Point(4, 22);
			tabPage4.Location = location;
			this.TabPage2.Name = "TabPage2";
			Control tabPage5 = this.TabPage2;
			padding = new Padding(3);
			tabPage5.Padding = padding;
			Control tabPage6 = this.TabPage2;
			size = new Size(612, 410);
			tabPage6.Size = size;
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "（1）选择处理方式";
			this.TableLayoutPanel2.ColumnCount = 2;
			this.TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
			this.TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
			this.TableLayoutPanel2.Controls.Add(this.GroupBox1, 0, 0);
			this.TableLayoutPanel2.Controls.Add(this.Button2, 1, 1);
			this.TableLayoutPanel2.Controls.Add(this.CheckBox5, 0, 1);
			this.TableLayoutPanel2.Dock = DockStyle.Fill;
			Control tableLayoutPanel3 = this.TableLayoutPanel2;
			location = new Point(3, 3);
			tableLayoutPanel3.Location = location;
			this.TableLayoutPanel2.Name = "TableLayoutPanel2";
			this.TableLayoutPanel2.RowCount = 2;
			this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
			Control tableLayoutPanel4 = this.TableLayoutPanel2;
			size = new Size(606, 404);
			tableLayoutPanel4.Size = size;
			this.TableLayoutPanel2.TabIndex = 2;
			this.TableLayoutPanel2.SetColumnSpan(this.GroupBox1, 2);
			this.GroupBox1.Controls.Add(this.Panel8);
			this.GroupBox1.Dock = DockStyle.Fill;
			Control groupBox = this.GroupBox1;
			location = new Point(3, 3);
			groupBox.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			Control groupBox2 = this.GroupBox1;
			size = new Size(600, 358);
			groupBox2.Size = size;
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "处理方式";
			this.Panel8.AutoScroll = true;
			this.Panel8.Controls.Add(this.Panel10);
			this.Panel8.Controls.Add(this.Label9);
			this.Panel8.Controls.Add(this.FlowLayoutPanel9);
			this.Panel8.Controls.Add(this.RadioButton7);
			this.Panel8.Controls.Add(this.SplitterLabel9);
			this.Panel8.Controls.Add(this.SplitterLabel8);
			this.Panel8.Controls.Add(this.FlowLayoutPanel7);
			this.Panel8.Controls.Add(this.RadioButton20);
			this.Panel8.Controls.Add(this.SplitterLabel7);
			this.Panel8.Controls.Add(this.RadioButton15);
			this.Panel8.Controls.Add(this.FlowLayoutPanel3);
			this.Panel8.Controls.Add(this.FlowLayoutPanel2);
			this.Panel8.Controls.Add(this.FlowLayoutPanel1);
			this.Panel8.Controls.Add(this.SplitterLabel6);
			this.Panel8.Controls.Add(this.RadioButton14);
			this.Panel8.Controls.Add(this.RadioButton1);
			this.Panel8.Controls.Add(this.Panel2);
			this.Panel8.Controls.Add(this.SplitterLabel2);
			this.Panel8.Controls.Add(this.SplitterLabel1);
			this.Panel8.Controls.Add(this.RadioButton2);
			this.Panel8.Controls.Add(this.RadioButton3);
			this.Panel8.Controls.Add(this.SplitterLabel5);
			this.Panel8.Controls.Add(this.RadioButton13);
			this.Panel8.Controls.Add(this.SplitterLabel4);
			this.Panel8.Controls.Add(this.SplitterLabel3);
			this.Panel8.Controls.Add(this.RadioButton4);
			this.Panel8.Controls.Add(this.FlowLayoutPanel5);
			this.Panel8.Dock = DockStyle.Fill;
			Control panel = this.Panel8;
			location = new Point(3, 17);
			panel.Location = location;
			this.Panel8.Name = "Panel8";
			Control panel2 = this.Panel8;
			size = new Size(594, 338);
			panel2.Size = size;
			this.Panel8.TabIndex = 26;
			this.Panel10.AutoSize = true;
			this.Panel10.Controls.Add(this.NumericUpDown17);
			this.Panel10.Controls.Add(this.RadioButton27);
			this.Panel10.Controls.Add(this.RadioButton28);
			Control panel3 = this.Panel10;
			location = new Point(139, 283);
			panel3.Location = location;
			Control panel4 = this.Panel10;
			padding = new Padding(3, 1, 3, 3);
			panel4.Margin = padding;
			this.Panel10.Name = "Panel10";
			Control panel5 = this.Panel10;
			size = new Size(145, 26);
			panel5.Size = size;
			this.Panel10.TabIndex = 42;
			Control numericUpDown = this.NumericUpDown17;
			location = new Point(99, 2);
			numericUpDown.Location = location;
			this.NumericUpDown17.Name = "NumericUpDown17";
			Control numericUpDown2 = this.NumericUpDown17;
			size = new Size(43, 21);
			numericUpDown2.Size = size;
			this.NumericUpDown17.TabIndex = 2;
			NumericUpDown numericUpDown3 = this.NumericUpDown17;
			decimal num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown3.Value = num;
			this.RadioButton27.AutoSize = true;
			Control radioButton = this.RadioButton27;
			location = new Point(52, 4);
			radioButton.Location = location;
			this.RadioButton27.Name = "RadioButton27";
			Control radioButton2 = this.RadioButton27;
			size = new Size(41, 16);
			radioButton2.Size = size;
			this.RadioButton27.TabIndex = 1;
			this.RadioButton27.Text = "JPG";
			this.RadioButton27.UseVisualStyleBackColor = true;
			this.RadioButton28.AutoSize = true;
			this.RadioButton28.Checked = true;
			Control radioButton3 = this.RadioButton28;
			location = new Point(4, 4);
			radioButton3.Location = location;
			this.RadioButton28.Name = "RadioButton28";
			Control radioButton4 = this.RadioButton28;
			size = new Size(41, 16);
			radioButton4.Size = size;
			this.RadioButton28.TabIndex = 0;
			this.RadioButton28.TabStop = true;
			this.RadioButton28.Text = "BMP";
			this.RadioButton28.UseVisualStyleBackColor = true;
			this.Label9.AutoSize = true;
			Control label = this.Label9;
			location = new Point(92, 289);
			label.Location = location;
			Control label2 = this.Label9;
			padding = new Padding(3, 7, 3, 3);
			label2.Margin = padding;
			this.Label9.Name = "Label9";
			Control label3 = this.Label9;
			size = new Size(41, 12);
			label3.Size = size;
			this.Label9.TabIndex = 41;
			this.Label9.Text = "保存为";
			this.FlowLayoutPanel9.AutoSize = true;
			this.FlowLayoutPanel9.Controls.Add(this.RadioButton8);
			this.FlowLayoutPanel9.Controls.Add(this.NumericUpDown14);
			this.FlowLayoutPanel9.Controls.Add(this.RadioButton25);
			this.FlowLayoutPanel9.Controls.Add(this.NumericUpDown15);
			this.FlowLayoutPanel9.Controls.Add(this.RadioButton26);
			this.FlowLayoutPanel9.Controls.Add(this.NumericUpDown16);
			Control flowLayoutPanel = this.FlowLayoutPanel9;
			location = new Point(91, 252);
			flowLayoutPanel.Location = location;
			Control flowLayoutPanel2 = this.FlowLayoutPanel9;
			padding = new Padding(3, 1, 3, 3);
			flowLayoutPanel2.Margin = padding;
			this.FlowLayoutPanel9.Name = "FlowLayoutPanel9";
			Control flowLayoutPanel3 = this.FlowLayoutPanel9;
			size = new Size(373, 27);
			flowLayoutPanel3.Size = size;
			this.FlowLayoutPanel9.TabIndex = 40;
			this.RadioButton8.AutoSize = true;
			this.RadioButton8.Checked = true;
			Control radioButton5 = this.RadioButton8;
			location = new Point(3, 4);
			radioButton5.Location = location;
			Control radioButton6 = this.RadioButton8;
			padding = new Padding(3, 4, 3, 3);
			radioButton6.Margin = padding;
			this.RadioButton8.Name = "RadioButton8";
			Control radioButton7 = this.RadioButton8;
			size = new Size(71, 16);
			radioButton7.Size = size;
			this.RadioButton8.TabIndex = 0;
			this.RadioButton8.TabStop = true;
			this.RadioButton8.Text = "宽度为准";
			this.RadioButton8.UseVisualStyleBackColor = true;
			Control numericUpDown4 = this.NumericUpDown14;
			location = new Point(80, 3);
			numericUpDown4.Location = location;
			NumericUpDown numericUpDown5 = this.NumericUpDown14;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown5.Maximum = num;
			this.NumericUpDown14.Name = "NumericUpDown14";
			Control numericUpDown6 = this.NumericUpDown14;
			size = new Size(50, 21);
			numericUpDown6.Size = size;
			this.NumericUpDown14.TabIndex = 0;
			this.RadioButton25.AutoSize = true;
			Control radioButton8 = this.RadioButton25;
			location = new Point(136, 4);
			radioButton8.Location = location;
			Control radioButton9 = this.RadioButton25;
			padding = new Padding(3, 4, 3, 3);
			radioButton9.Margin = padding;
			this.RadioButton25.Name = "RadioButton25";
			Control radioButton10 = this.RadioButton25;
			size = new Size(71, 16);
			radioButton10.Size = size;
			this.RadioButton25.TabIndex = 1;
			this.RadioButton25.Text = "高度为准";
			this.RadioButton25.UseVisualStyleBackColor = true;
			Control numericUpDown7 = this.NumericUpDown15;
			location = new Point(213, 3);
			numericUpDown7.Location = location;
			NumericUpDown numericUpDown8 = this.NumericUpDown15;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown8.Maximum = num;
			this.NumericUpDown15.Name = "NumericUpDown15";
			Control numericUpDown9 = this.NumericUpDown15;
			size = new Size(43, 21);
			numericUpDown9.Size = size;
			this.NumericUpDown15.TabIndex = 2;
			this.RadioButton26.AutoSize = true;
			Control radioButton11 = this.RadioButton26;
			location = new Point(262, 4);
			radioButton11.Location = location;
			Control radioButton12 = this.RadioButton26;
			padding = new Padding(3, 4, 3, 3);
			radioButton12.Margin = padding;
			this.RadioButton26.Name = "RadioButton26";
			Control radioButton13 = this.RadioButton26;
			size = new Size(59, 16);
			radioButton13.Size = size;
			this.RadioButton26.TabIndex = 3;
			this.RadioButton26.Text = "百份比";
			this.RadioButton26.UseVisualStyleBackColor = true;
			Control numericUpDown10 = this.NumericUpDown16;
			location = new Point(327, 3);
			numericUpDown10.Location = location;
			NumericUpDown numericUpDown11 = this.NumericUpDown16;
			num = new decimal(new int[]
			{
				999,
				0,
				0,
				0
			});
			numericUpDown11.Maximum = num;
			NumericUpDown numericUpDown12 = this.NumericUpDown16;
			num = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			numericUpDown12.Minimum = num;
			this.NumericUpDown16.Name = "NumericUpDown16";
			Control numericUpDown13 = this.NumericUpDown16;
			size = new Size(43, 21);
			numericUpDown13.Size = size;
			this.NumericUpDown16.TabIndex = 4;
			NumericUpDown numericUpDown14 = this.NumericUpDown16;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown14.Value = num;
			this.RadioButton7.AutoSize = true;
			Control radioButton14 = this.RadioButton7;
			location = new Point(16, 257);
			radioButton14.Location = location;
			this.RadioButton7.Name = "RadioButton7";
			Control radioButton15 = this.RadioButton7;
			size = new Size(71, 16);
			radioButton15.Size = size;
			this.RadioButton7.TabIndex = 39;
			this.RadioButton7.TabStop = true;
			this.RadioButton7.Text = "缩放图片";
			this.RadioButton7.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel7.AutoSize = true;
			this.FlowLayoutPanel7.Controls.Add(this.FlowLayoutPanel8);
			this.FlowLayoutPanel7.Controls.Add(this.Label8);
			this.FlowLayoutPanel7.Controls.Add(this.Panel9);
			Control flowLayoutPanel4 = this.FlowLayoutPanel7;
			location = new Point(88, 219);
			flowLayoutPanel4.Location = location;
			this.FlowLayoutPanel7.Name = "FlowLayoutPanel7";
			Control flowLayoutPanel5 = this.FlowLayoutPanel7;
			size = new Size(475, 31);
			flowLayoutPanel5.Size = size;
			this.FlowLayoutPanel7.TabIndex = 36;
			this.FlowLayoutPanel8.AutoSize = true;
			this.FlowLayoutPanel8.Controls.Add(this.RadioButton21);
			this.FlowLayoutPanel8.Controls.Add(this.NumericUpDown10);
			this.FlowLayoutPanel8.Controls.Add(this.RadioButton22);
			this.FlowLayoutPanel8.Controls.Add(this.NumericUpDown11);
			Control flowLayoutPanel6 = this.FlowLayoutPanel8;
			location = new Point(3, 1);
			flowLayoutPanel6.Location = location;
			Control flowLayoutPanel7 = this.FlowLayoutPanel8;
			padding = new Padding(3, 1, 3, 3);
			flowLayoutPanel7.Margin = padding;
			this.FlowLayoutPanel8.Name = "FlowLayoutPanel8";
			Control flowLayoutPanel8 = this.FlowLayoutPanel8;
			size = new Size(259, 27);
			flowLayoutPanel8.Size = size;
			this.FlowLayoutPanel8.TabIndex = 35;
			this.RadioButton21.AutoSize = true;
			this.RadioButton21.Checked = true;
			Control radioButton16 = this.RadioButton21;
			location = new Point(3, 4);
			radioButton16.Location = location;
			Control radioButton17 = this.RadioButton21;
			padding = new Padding(3, 4, 3, 3);
			radioButton17.Margin = padding;
			this.RadioButton21.Name = "RadioButton21";
			Control radioButton18 = this.RadioButton21;
			size = new Size(71, 16);
			radioButton18.Size = size;
			this.RadioButton21.TabIndex = 0;
			this.RadioButton21.TabStop = true;
			this.RadioButton21.Text = "定义高度";
			this.RadioButton21.UseVisualStyleBackColor = true;
			Control numericUpDown15 = this.NumericUpDown10;
			location = new Point(80, 3);
			numericUpDown15.Location = location;
			NumericUpDown numericUpDown16 = this.NumericUpDown10;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown16.Maximum = num;
			this.NumericUpDown10.Name = "NumericUpDown10";
			Control numericUpDown17 = this.NumericUpDown10;
			size = new Size(50, 21);
			numericUpDown17.Size = size;
			this.NumericUpDown10.TabIndex = 0;
			this.RadioButton22.AutoSize = true;
			Control radioButton19 = this.RadioButton22;
			location = new Point(136, 4);
			radioButton19.Location = location;
			Control radioButton20 = this.RadioButton22;
			padding = new Padding(3, 4, 3, 3);
			radioButton20.Margin = padding;
			this.RadioButton22.Name = "RadioButton22";
			Control radioButton21 = this.RadioButton22;
			size = new Size(71, 16);
			radioButton21.Size = size;
			this.RadioButton22.TabIndex = 1;
			this.RadioButton22.Text = "定义数量";
			this.RadioButton22.UseVisualStyleBackColor = true;
			Control numericUpDown18 = this.NumericUpDown11;
			location = new Point(213, 3);
			numericUpDown18.Location = location;
			NumericUpDown numericUpDown19 = this.NumericUpDown11;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown19.Maximum = num;
			this.NumericUpDown11.Name = "NumericUpDown11";
			Control numericUpDown20 = this.NumericUpDown11;
			size = new Size(43, 21);
			numericUpDown20.Size = size;
			this.NumericUpDown11.TabIndex = 2;
			this.Label8.AutoSize = true;
			Control label4 = this.Label8;
			location = new Point(268, 7);
			label4.Location = location;
			Control label5 = this.Label8;
			padding = new Padding(3, 7, 3, 3);
			label5.Margin = padding;
			this.Label8.Name = "Label8";
			Control label6 = this.Label8;
			size = new Size(53, 12);
			label6.Size = size;
			this.Label8.TabIndex = 1;
			this.Label8.Text = "，保存为";
			this.Panel9.AutoSize = true;
			this.Panel9.Controls.Add(this.NumericUpDown12);
			this.Panel9.Controls.Add(this.RadioButton23);
			this.Panel9.Controls.Add(this.RadioButton24);
			Control panel6 = this.Panel9;
			location = new Point(327, 1);
			panel6.Location = location;
			Control panel7 = this.Panel9;
			padding = new Padding(3, 1, 3, 3);
			panel7.Margin = padding;
			this.Panel9.Name = "Panel9";
			Control panel8 = this.Panel9;
			size = new Size(145, 26);
			panel8.Size = size;
			this.Panel9.TabIndex = 20;
			Control numericUpDown21 = this.NumericUpDown12;
			location = new Point(99, 2);
			numericUpDown21.Location = location;
			this.NumericUpDown12.Name = "NumericUpDown12";
			Control numericUpDown22 = this.NumericUpDown12;
			size = new Size(43, 21);
			numericUpDown22.Size = size;
			this.NumericUpDown12.TabIndex = 2;
			NumericUpDown numericUpDown23 = this.NumericUpDown12;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown23.Value = num;
			this.RadioButton23.AutoSize = true;
			Control radioButton22 = this.RadioButton23;
			location = new Point(52, 4);
			radioButton22.Location = location;
			this.RadioButton23.Name = "RadioButton23";
			Control radioButton23 = this.RadioButton23;
			size = new Size(41, 16);
			radioButton23.Size = size;
			this.RadioButton23.TabIndex = 1;
			this.RadioButton23.Text = "JPG";
			this.RadioButton23.UseVisualStyleBackColor = true;
			this.RadioButton24.AutoSize = true;
			this.RadioButton24.Checked = true;
			Control radioButton24 = this.RadioButton24;
			location = new Point(4, 4);
			radioButton24.Location = location;
			this.RadioButton24.Name = "RadioButton24";
			Control radioButton25 = this.RadioButton24;
			size = new Size(41, 16);
			radioButton25.Size = size;
			this.RadioButton24.TabIndex = 0;
			this.RadioButton24.TabStop = true;
			this.RadioButton24.Text = "BMP";
			this.RadioButton24.UseVisualStyleBackColor = true;
			this.RadioButton20.AutoSize = true;
			Control radioButton26 = this.RadioButton20;
			location = new Point(16, 224);
			radioButton26.Location = location;
			this.RadioButton20.Name = "RadioButton20";
			Control radioButton27 = this.RadioButton20;
			size = new Size(71, 16);
			radioButton27.Size = size;
			this.RadioButton20.TabIndex = 34;
			this.RadioButton20.TabStop = true;
			this.RadioButton20.Text = "竖向剪裁";
			this.RadioButton20.UseVisualStyleBackColor = true;
			this.RadioButton15.AutoSize = true;
			Control radioButton28 = this.RadioButton15;
			location = new Point(16, 192);
			radioButton28.Location = location;
			this.RadioButton15.Name = "RadioButton15";
			Control radioButton29 = this.RadioButton15;
			size = new Size(71, 16);
			radioButton29.Size = size;
			this.RadioButton15.TabIndex = 31;
			this.RadioButton15.TabStop = true;
			this.RadioButton15.Text = "横向剪裁";
			this.RadioButton15.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel3.AutoSize = true;
			this.FlowLayoutPanel3.Controls.Add(this.ComboBox1);
			this.FlowLayoutPanel3.Controls.Add(this.ComboBox2);
			this.FlowLayoutPanel3.Controls.Add(this.Label6);
			this.FlowLayoutPanel3.Controls.Add(this.ComboBox3);
			this.FlowLayoutPanel3.Controls.Add(this.NumericUpDown6);
			this.FlowLayoutPanel3.Controls.Add(this.CheckBox6);
			Control flowLayoutPanel9 = this.FlowLayoutPanel3;
			location = new Point(113, 126);
			flowLayoutPanel9.Location = location;
			this.FlowLayoutPanel3.Name = "FlowLayoutPanel3";
			Control flowLayoutPanel10 = this.FlowLayoutPanel3;
			size = new Size(435, 27);
			flowLayoutPanel10.Size = size;
			this.FlowLayoutPanel3.TabIndex = 30;
			this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Items.AddRange(new object[]
			{
				"全 部",
				"32Bit",
				"24Bit"
			});
			Control comboBox = this.ComboBox1;
			location = new Point(3, 3);
			comboBox.Location = location;
			this.ComboBox1.Name = "ComboBox1";
			Control comboBox2 = this.ComboBox1;
			size = new Size(75, 20);
			comboBox2.Size = size;
			this.ComboBox1.TabIndex = 22;
			this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ComboBox2.FormattingEnabled = true;
			this.ComboBox2.Items.AddRange(new object[]
			{
				"选择格式",
				"BMP",
				"PNG",
				"JPG",
				"GIF",
				"TGA",
				"DDS"
			});
			Control comboBox3 = this.ComboBox2;
			location = new Point(84, 3);
			comboBox3.Location = location;
			this.ComboBox2.Name = "ComboBox2";
			Control comboBox4 = this.ComboBox2;
			size = new Size(75, 20);
			comboBox4.Size = size;
			this.ComboBox2.TabIndex = 23;
			this.Label6.AutoSize = true;
			Control label7 = this.Label6;
			location = new Point(165, 7);
			label7.Location = location;
			Control label8 = this.Label6;
			padding = new Padding(3, 7, 3, 0);
			label8.Margin = padding;
			this.Label6.Name = "Label6";
			Control label9 = this.Label6;
			size = new Size(29, 12);
			label9.Size = size;
			this.Label6.TabIndex = 24;
			this.Label6.Text = "转为";
			this.ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ComboBox3.FormattingEnabled = true;
			this.ComboBox3.Items.AddRange(new object[]
			{
				"选择格式",
				"BMP",
				"PNG",
				"JPG"
			});
			Control comboBox5 = this.ComboBox3;
			location = new Point(200, 3);
			comboBox5.Location = location;
			this.ComboBox3.Name = "ComboBox3";
			Control comboBox6 = this.ComboBox3;
			size = new Size(75, 20);
			comboBox6.Size = size;
			this.ComboBox3.TabIndex = 25;
			this.NumericUpDown6.Enabled = false;
			Control numericUpDown24 = this.NumericUpDown6;
			location = new Point(281, 3);
			numericUpDown24.Location = location;
			this.NumericUpDown6.Name = "NumericUpDown6";
			Control numericUpDown25 = this.NumericUpDown6;
			size = new Size(43, 21);
			numericUpDown25.Size = size;
			this.NumericUpDown6.TabIndex = 20;
			NumericUpDown numericUpDown26 = this.NumericUpDown6;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown26.Value = num;
			this.CheckBox6.AutoSize = true;
			Control checkBox = this.CheckBox6;
			location = new Point(330, 3);
			checkBox.Location = location;
			this.CheckBox6.Name = "CheckBox6";
			Control checkBox2 = this.CheckBox6;
			size = new Size(102, 16);
			checkBox2.Size = size;
			this.CheckBox6.TabIndex = 40;
			this.CheckBox6.Text = "ALPHA黑白反色";
			this.CheckBox6.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel2.AutoSize = true;
			this.FlowLayoutPanel2.Controls.Add(this.Label1);
			this.FlowLayoutPanel2.Controls.Add(this.NumericUpDown1);
			this.FlowLayoutPanel2.Controls.Add(this.Label2);
			this.FlowLayoutPanel2.Controls.Add(this.NumericUpDown2);
			this.FlowLayoutPanel2.Controls.Add(this.Label3);
			this.FlowLayoutPanel2.Controls.Add(this.NumericUpDown3);
			this.FlowLayoutPanel2.Controls.Add(this.Label4);
			this.FlowLayoutPanel2.Controls.Add(this.NumericUpDown4);
			Control flowLayoutPanel11 = this.FlowLayoutPanel2;
			location = new Point(92, 64);
			flowLayoutPanel11.Location = location;
			this.FlowLayoutPanel2.Name = "FlowLayoutPanel2";
			Control flowLayoutPanel12 = this.FlowLayoutPanel2;
			size = new Size(453, 27);
			flowLayoutPanel12.Size = size;
			this.FlowLayoutPanel2.TabIndex = 29;
			this.Label1.AutoSize = true;
			Control label10 = this.Label1;
			location = new Point(3, 7);
			label10.Location = location;
			Control label11 = this.Label1;
			padding = new Padding(3, 7, 3, 0);
			label11.Margin = padding;
			this.Label1.Name = "Label1";
			Control label12 = this.Label1;
			size = new Size(41, 12);
			label12.Size = size;
			this.Label1.TabIndex = 4;
			this.Label1.Text = "起点X:";
			Control numericUpDown27 = this.NumericUpDown1;
			location = new Point(50, 3);
			numericUpDown27.Location = location;
			NumericUpDown numericUpDown28 = this.NumericUpDown1;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown28.Maximum = num;
			this.NumericUpDown1.Name = "NumericUpDown1";
			Control numericUpDown29 = this.NumericUpDown1;
			size = new Size(50, 21);
			numericUpDown29.Size = size;
			this.NumericUpDown1.TabIndex = 9;
			this.Label2.AutoSize = true;
			Control label13 = this.Label2;
			location = new Point(106, 7);
			label13.Location = location;
			Control label14 = this.Label2;
			padding = new Padding(3, 7, 3, 0);
			label14.Margin = padding;
			this.Label2.Name = "Label2";
			Control label15 = this.Label2;
			size = new Size(41, 12);
			label15.Size = size;
			this.Label2.TabIndex = 5;
			this.Label2.Text = "起点Y:";
			Control numericUpDown30 = this.NumericUpDown2;
			location = new Point(153, 3);
			numericUpDown30.Location = location;
			NumericUpDown numericUpDown31 = this.NumericUpDown2;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown31.Maximum = num;
			this.NumericUpDown2.Name = "NumericUpDown2";
			Control numericUpDown32 = this.NumericUpDown2;
			size = new Size(50, 21);
			numericUpDown32.Size = size;
			this.NumericUpDown2.TabIndex = 10;
			this.Label3.AutoSize = true;
			Control label16 = this.Label3;
			location = new Point(209, 7);
			label16.Location = location;
			Control label17 = this.Label3;
			padding = new Padding(3, 7, 3, 0);
			label17.Margin = padding;
			this.Label3.Name = "Label3";
			Control label18 = this.Label3;
			size = new Size(59, 12);
			label18.Size = size;
			this.Label3.TabIndex = 6;
			this.Label3.Text = "截取宽度:";
			Control numericUpDown33 = this.NumericUpDown3;
			location = new Point(274, 3);
			numericUpDown33.Location = location;
			NumericUpDown numericUpDown34 = this.NumericUpDown3;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown34.Maximum = num;
			this.NumericUpDown3.Name = "NumericUpDown3";
			Control numericUpDown35 = this.NumericUpDown3;
			size = new Size(50, 21);
			numericUpDown35.Size = size;
			this.NumericUpDown3.TabIndex = 11;
			this.Label4.AutoSize = true;
			Control label19 = this.Label4;
			location = new Point(330, 7);
			label19.Location = location;
			Control label20 = this.Label4;
			padding = new Padding(3, 7, 3, 0);
			label20.Margin = padding;
			this.Label4.Name = "Label4";
			Control label21 = this.Label4;
			size = new Size(59, 12);
			label21.Size = size;
			this.Label4.TabIndex = 7;
			this.Label4.Text = "截取高度:";
			Control numericUpDown36 = this.NumericUpDown4;
			location = new Point(395, 3);
			numericUpDown36.Location = location;
			NumericUpDown numericUpDown37 = this.NumericUpDown4;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown37.Maximum = num;
			this.NumericUpDown4.Name = "NumericUpDown4";
			Control numericUpDown38 = this.NumericUpDown4;
			size = new Size(50, 21);
			numericUpDown38.Size = size;
			this.NumericUpDown4.TabIndex = 12;
			this.FlowLayoutPanel1.AutoSize = true;
			this.FlowLayoutPanel1.Controls.Add(this.RadioButton9);
			this.FlowLayoutPanel1.Controls.Add(this.Panel4);
			this.FlowLayoutPanel1.Controls.Add(this.RadioButton10);
			this.FlowLayoutPanel1.Controls.Add(this.Panel5);
			this.FlowLayoutPanel1.Controls.Add(this.RadioButton11);
			this.FlowLayoutPanel1.Controls.Add(this.Panel6);
			this.FlowLayoutPanel1.Controls.Add(this.RadioButton12);
			this.FlowLayoutPanel1.Controls.Add(this.Panel7);
			Control flowLayoutPanel13 = this.FlowLayoutPanel1;
			location = new Point(153, 32);
			flowLayoutPanel13.Location = location;
			this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
			Control flowLayoutPanel14 = this.FlowLayoutPanel1;
			size = new Size(340, 26);
			flowLayoutPanel14.Size = size;
			this.FlowLayoutPanel1.TabIndex = 28;
			this.RadioButton9.AutoSize = true;
			this.RadioButton9.Checked = true;
			Control radioButton30 = this.RadioButton9;
			location = new Point(3, 3);
			radioButton30.Location = location;
			this.RadioButton9.Name = "RadioButton9";
			Control radioButton31 = this.RadioButton9;
			padding = new Padding(1);
			radioButton31.Padding = padding;
			Control radioButton32 = this.RadioButton9;
			size = new Size(49, 18);
			radioButton32.Size = size;
			this.RadioButton9.TabIndex = 0;
			this.RadioButton9.TabStop = true;
			this.RadioButton9.Text = "紫色";
			this.RadioButton9.UseVisualStyleBackColor = true;
			this.Panel4.BackColor = Color.Fuchsia;
			this.Panel4.BorderStyle = BorderStyle.FixedSingle;
			Control panel9 = this.Panel4;
			location = new Point(58, 3);
			panel9.Location = location;
			this.Panel4.Name = "Panel4";
			Control panel10 = this.Panel4;
			padding = new Padding(2);
			panel10.Padding = padding;
			Control panel11 = this.Panel4;
			size = new Size(20, 20);
			panel11.Size = size;
			this.Panel4.TabIndex = 1;
			this.RadioButton10.AutoSize = true;
			Control radioButton33 = this.RadioButton10;
			location = new Point(84, 3);
			radioButton33.Location = location;
			this.RadioButton10.Name = "RadioButton10";
			Control radioButton34 = this.RadioButton10;
			padding = new Padding(1);
			radioButton34.Padding = padding;
			Control radioButton35 = this.RadioButton10;
			size = new Size(49, 18);
			radioButton35.Size = size;
			this.RadioButton10.TabIndex = 2;
			this.RadioButton10.TabStop = true;
			this.RadioButton10.Text = "绿色";
			this.RadioButton10.UseVisualStyleBackColor = true;
			this.Panel5.BackColor = Color.Lime;
			this.Panel5.BorderStyle = BorderStyle.FixedSingle;
			Control panel12 = this.Panel5;
			location = new Point(139, 3);
			panel12.Location = location;
			this.Panel5.Name = "Panel5";
			Control panel13 = this.Panel5;
			padding = new Padding(2);
			panel13.Padding = padding;
			Control panel14 = this.Panel5;
			size = new Size(20, 20);
			panel14.Size = size;
			this.Panel5.TabIndex = 3;
			this.RadioButton11.AutoSize = true;
			Control radioButton36 = this.RadioButton11;
			location = new Point(165, 3);
			radioButton36.Location = location;
			this.RadioButton11.Name = "RadioButton11";
			Control radioButton37 = this.RadioButton11;
			padding = new Padding(1);
			radioButton37.Padding = padding;
			Control radioButton38 = this.RadioButton11;
			size = new Size(49, 18);
			radioButton38.Size = size;
			this.RadioButton11.TabIndex = 22;
			this.RadioButton11.TabStop = true;
			this.RadioButton11.Text = "自定";
			this.RadioButton11.UseVisualStyleBackColor = true;
			this.Panel6.BackColor = Color.Transparent;
			this.Panel6.BorderStyle = BorderStyle.FixedSingle;
			Control panel15 = this.Panel6;
			location = new Point(220, 3);
			panel15.Location = location;
			this.Panel6.Name = "Panel6";
			Control panel16 = this.Panel6;
			size = new Size(20, 20);
			panel16.Size = size;
			this.Panel6.TabIndex = 21;
			this.RadioButton12.AutoSize = true;
			Control radioButton39 = this.RadioButton12;
			location = new Point(246, 3);
			radioButton39.Location = location;
			this.RadioButton12.Name = "RadioButton12";
			Control radioButton40 = this.RadioButton12;
			padding = new Padding(1);
			radioButton40.Padding = padding;
			Control radioButton41 = this.RadioButton12;
			size = new Size(49, 18);
			radioButton41.Size = size;
			this.RadioButton12.TabIndex = 23;
			this.RadioButton12.TabStop = true;
			this.RadioButton12.Text = "截屏";
			this.RadioButton12.UseVisualStyleBackColor = true;
			this.Panel7.BackColor = Color.Transparent;
			this.Panel7.BorderStyle = BorderStyle.FixedSingle;
			Control panel17 = this.Panel7;
			location = new Point(301, 3);
			panel17.Location = location;
			this.Panel7.Name = "Panel7";
			Control panel18 = this.Panel7;
			size = new Size(20, 20);
			panel18.Size = size;
			this.Panel7.TabIndex = 22;
			this.RadioButton14.AutoSize = true;
			Control radioButton42 = this.RadioButton14;
			location = new Point(16, 162);
			radioButton42.Location = location;
			this.RadioButton14.Name = "RadioButton14";
			Control radioButton43 = this.RadioButton14;
			size = new Size(377, 16);
			radioButton43.Size = size;
			this.RadioButton14.TabIndex = 26;
			this.RadioButton14.TabStop = true;
			this.RadioButton14.Text = "扫描32位图片，根据图片ALPHA的黑色值，计算并取出图片有用范围";
			this.RadioButton14.UseVisualStyleBackColor = true;
			this.RadioButton1.AutoSize = true;
			this.RadioButton1.Checked = true;
			Control radioButton44 = this.RadioButton1;
			location = new Point(16, 7);
			radioButton44.Location = location;
			this.RadioButton1.Name = "RadioButton1";
			Control radioButton45 = this.RadioButton1;
			size = new Size(35, 16);
			radioButton45.Size = size;
			this.RadioButton1.TabIndex = 1;
			this.RadioButton1.TabStop = true;
			this.RadioButton1.Text = "无";
			this.RadioButton1.UseVisualStyleBackColor = true;
			this.Panel2.Controls.Add(this.CheckBox1);
			this.Panel2.Controls.Add(this.NumericUpDown5);
			this.Panel2.Controls.Add(this.RadioButton6);
			this.Panel2.Controls.Add(this.RadioButton5);
			Control panel19 = this.Panel2;
			location = new Point(351, 95);
			panel19.Location = location;
			this.Panel2.Name = "Panel2";
			Control panel20 = this.Panel2;
			size = new Size(185, 26);
			panel20.Size = size;
			this.Panel2.TabIndex = 17;
			this.CheckBox1.AutoSize = true;
			Control checkBox3 = this.CheckBox1;
			location = new Point(153, 5);
			checkBox3.Location = location;
			this.CheckBox1.Name = "CheckBox1";
			Control checkBox4 = this.CheckBox1;
			size = new Size(30, 16);
			checkBox4.Size = size;
			this.CheckBox1.TabIndex = 19;
			this.CheckBox1.Text = "F";
			this.CheckBox1.UseVisualStyleBackColor = true;
			Control numericUpDown39 = this.NumericUpDown5;
			location = new Point(99, 2);
			numericUpDown39.Location = location;
			this.NumericUpDown5.Name = "NumericUpDown5";
			Control numericUpDown40 = this.NumericUpDown5;
			size = new Size(43, 21);
			numericUpDown40.Size = size;
			this.NumericUpDown5.TabIndex = 2;
			NumericUpDown numericUpDown41 = this.NumericUpDown5;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown41.Value = num;
			this.RadioButton6.AutoSize = true;
			Control radioButton46 = this.RadioButton6;
			location = new Point(52, 4);
			radioButton46.Location = location;
			this.RadioButton6.Name = "RadioButton6";
			Control radioButton47 = this.RadioButton6;
			size = new Size(41, 16);
			radioButton47.Size = size;
			this.RadioButton6.TabIndex = 1;
			this.RadioButton6.Text = "JPG";
			this.RadioButton6.UseVisualStyleBackColor = true;
			this.RadioButton5.AutoSize = true;
			this.RadioButton5.Checked = true;
			Control radioButton48 = this.RadioButton5;
			location = new Point(4, 4);
			radioButton48.Location = location;
			this.RadioButton5.Name = "RadioButton5";
			Control radioButton49 = this.RadioButton5;
			size = new Size(41, 16);
			radioButton49.Size = size;
			this.RadioButton5.TabIndex = 0;
			this.RadioButton5.TabStop = true;
			this.RadioButton5.Text = "BMP";
			this.RadioButton5.UseVisualStyleBackColor = true;
			this.RadioButton2.AutoSize = true;
			Control radioButton50 = this.RadioButton2;
			location = new Point(16, 37);
			radioButton50.Location = location;
			this.RadioButton2.Name = "RadioButton2";
			Control radioButton51 = this.RadioButton2;
			size = new Size(131, 16);
			radioButton51.Size = size;
			this.RadioButton2.TabIndex = 2;
			this.RadioButton2.Text = "将某种颜色设为透明";
			this.RadioButton2.UseVisualStyleBackColor = true;
			this.RadioButton3.AutoSize = true;
			Control radioButton52 = this.RadioButton3;
			location = new Point(16, 67);
			radioButton52.Location = location;
			this.RadioButton3.Name = "RadioButton3";
			Control radioButton53 = this.RadioButton3;
			size = new Size(71, 16);
			radioButton53.Size = size;
			this.RadioButton3.TabIndex = 3;
			this.RadioButton3.TabStop = true;
			this.RadioButton3.Text = "截取图片";
			this.RadioButton3.UseVisualStyleBackColor = true;
			this.RadioButton13.AutoSize = true;
			Control radioButton54 = this.RadioButton13;
			location = new Point(16, 130);
			radioButton54.Location = location;
			this.RadioButton13.Name = "RadioButton13";
			Control radioButton55 = this.RadioButton13;
			size = new Size(95, 16);
			radioButton55.Size = size;
			this.RadioButton13.TabIndex = 20;
			this.RadioButton13.TabStop = true;
			this.RadioButton13.Text = "格式转换  将";
			this.RadioButton13.UseVisualStyleBackColor = true;
			this.RadioButton4.AutoSize = true;
			Control radioButton56 = this.RadioButton4;
			location = new Point(16, 100);
			radioButton56.Location = location;
			this.RadioButton4.Name = "RadioButton4";
			Control radioButton57 = this.RadioButton4;
			size = new Size(329, 16);
			radioButton57.Size = size;
			this.RadioButton4.TabIndex = 16;
			this.RadioButton4.TabStop = true;
			this.RadioButton4.Text = "扫描32位图片的ALPHA是否全黑或全白，是就转为24位图片";
			this.RadioButton4.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel5.AutoSize = true;
			this.FlowLayoutPanel5.Controls.Add(this.FlowLayoutPanel6);
			this.FlowLayoutPanel5.Controls.Add(this.Label7);
			this.FlowLayoutPanel5.Controls.Add(this.Panel3);
			Control flowLayoutPanel15 = this.FlowLayoutPanel5;
			location = new Point(88, 187);
			flowLayoutPanel15.Location = location;
			this.FlowLayoutPanel5.Name = "FlowLayoutPanel5";
			Control flowLayoutPanel16 = this.FlowLayoutPanel5;
			size = new Size(475, 31);
			flowLayoutPanel16.Size = size;
			this.FlowLayoutPanel5.TabIndex = 32;
			this.FlowLayoutPanel6.AutoSize = true;
			this.FlowLayoutPanel6.Controls.Add(this.RadioButton18);
			this.FlowLayoutPanel6.Controls.Add(this.NumericUpDown7);
			this.FlowLayoutPanel6.Controls.Add(this.RadioButton19);
			this.FlowLayoutPanel6.Controls.Add(this.NumericUpDown9);
			Control flowLayoutPanel17 = this.FlowLayoutPanel6;
			location = new Point(3, 1);
			flowLayoutPanel17.Location = location;
			Control flowLayoutPanel18 = this.FlowLayoutPanel6;
			padding = new Padding(3, 1, 3, 3);
			flowLayoutPanel18.Margin = padding;
			this.FlowLayoutPanel6.Name = "FlowLayoutPanel6";
			Control flowLayoutPanel19 = this.FlowLayoutPanel6;
			size = new Size(259, 27);
			flowLayoutPanel19.Size = size;
			this.FlowLayoutPanel6.TabIndex = 35;
			this.RadioButton18.AutoSize = true;
			this.RadioButton18.Checked = true;
			Control radioButton58 = this.RadioButton18;
			location = new Point(3, 4);
			radioButton58.Location = location;
			Control radioButton59 = this.RadioButton18;
			padding = new Padding(3, 4, 3, 3);
			radioButton59.Margin = padding;
			this.RadioButton18.Name = "RadioButton18";
			Control radioButton60 = this.RadioButton18;
			size = new Size(71, 16);
			radioButton60.Size = size;
			this.RadioButton18.TabIndex = 0;
			this.RadioButton18.TabStop = true;
			this.RadioButton18.Text = "定义宽度";
			this.RadioButton18.UseVisualStyleBackColor = true;
			Control numericUpDown42 = this.NumericUpDown7;
			location = new Point(80, 3);
			numericUpDown42.Location = location;
			NumericUpDown numericUpDown43 = this.NumericUpDown7;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown43.Maximum = num;
			this.NumericUpDown7.Name = "NumericUpDown7";
			Control numericUpDown44 = this.NumericUpDown7;
			size = new Size(50, 21);
			numericUpDown44.Size = size;
			this.NumericUpDown7.TabIndex = 0;
			this.RadioButton19.AutoSize = true;
			Control radioButton61 = this.RadioButton19;
			location = new Point(136, 4);
			radioButton61.Location = location;
			Control radioButton62 = this.RadioButton19;
			padding = new Padding(3, 4, 3, 3);
			radioButton62.Margin = padding;
			this.RadioButton19.Name = "RadioButton19";
			Control radioButton63 = this.RadioButton19;
			size = new Size(71, 16);
			radioButton63.Size = size;
			this.RadioButton19.TabIndex = 1;
			this.RadioButton19.Text = "定义数量";
			this.RadioButton19.UseVisualStyleBackColor = true;
			Control numericUpDown45 = this.NumericUpDown9;
			location = new Point(213, 3);
			numericUpDown45.Location = location;
			NumericUpDown numericUpDown46 = this.NumericUpDown9;
			num = new decimal(new int[]
			{
				9999,
				0,
				0,
				0
			});
			numericUpDown46.Maximum = num;
			this.NumericUpDown9.Name = "NumericUpDown9";
			Control numericUpDown47 = this.NumericUpDown9;
			size = new Size(43, 21);
			numericUpDown47.Size = size;
			this.NumericUpDown9.TabIndex = 2;
			this.Label7.AutoSize = true;
			Control label22 = this.Label7;
			location = new Point(268, 7);
			label22.Location = location;
			Control label23 = this.Label7;
			padding = new Padding(3, 7, 3, 3);
			label23.Margin = padding;
			this.Label7.Name = "Label7";
			Control label24 = this.Label7;
			size = new Size(53, 12);
			label24.Size = size;
			this.Label7.TabIndex = 1;
			this.Label7.Text = "，保存为";
			this.Panel3.AutoSize = true;
			this.Panel3.Controls.Add(this.NumericUpDown8);
			this.Panel3.Controls.Add(this.RadioButton16);
			this.Panel3.Controls.Add(this.RadioButton17);
			Control panel21 = this.Panel3;
			location = new Point(327, 1);
			panel21.Location = location;
			Control panel22 = this.Panel3;
			padding = new Padding(3, 1, 3, 3);
			panel22.Margin = padding;
			this.Panel3.Name = "Panel3";
			Control panel23 = this.Panel3;
			size = new Size(145, 26);
			panel23.Size = size;
			this.Panel3.TabIndex = 20;
			Control numericUpDown48 = this.NumericUpDown8;
			location = new Point(99, 2);
			numericUpDown48.Location = location;
			this.NumericUpDown8.Name = "NumericUpDown8";
			Control numericUpDown49 = this.NumericUpDown8;
			size = new Size(43, 21);
			numericUpDown49.Size = size;
			this.NumericUpDown8.TabIndex = 2;
			NumericUpDown numericUpDown50 = this.NumericUpDown8;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown50.Value = num;
			this.RadioButton16.AutoSize = true;
			Control radioButton64 = this.RadioButton16;
			location = new Point(52, 4);
			radioButton64.Location = location;
			this.RadioButton16.Name = "RadioButton16";
			Control radioButton65 = this.RadioButton16;
			size = new Size(41, 16);
			radioButton65.Size = size;
			this.RadioButton16.TabIndex = 1;
			this.RadioButton16.Text = "JPG";
			this.RadioButton16.UseVisualStyleBackColor = true;
			this.RadioButton17.AutoSize = true;
			this.RadioButton17.Checked = true;
			Control radioButton66 = this.RadioButton17;
			location = new Point(4, 4);
			radioButton66.Location = location;
			this.RadioButton17.Name = "RadioButton17";
			Control radioButton67 = this.RadioButton17;
			size = new Size(41, 16);
			radioButton67.Size = size;
			this.RadioButton17.TabIndex = 0;
			this.RadioButton17.TabStop = true;
			this.RadioButton17.Text = "BMP";
			this.RadioButton17.UseVisualStyleBackColor = true;
			this.Button2.Anchor = AnchorStyles.None;
			Control button3 = this.Button2;
			location = new Point(343, 369);
			button3.Location = location;
			this.Button2.Name = "Button2";
			Control button4 = this.Button2;
			size = new Size(100, 30);
			button4.Size = size;
			this.Button2.TabIndex = 1;
			this.Button2.Text = "执 行";
			this.Button2.UseVisualStyleBackColor = true;
			this.CheckBox5.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.CheckBox5.AutoSize = true;
			Control checkBox5 = this.CheckBox5;
			location = new Point(106, 367);
			checkBox5.Location = location;
			this.CheckBox5.Name = "CheckBox5";
			Control checkBox6 = this.CheckBox5;
			size = new Size(72, 16);
			checkBox6.Size = size;
			this.CheckBox5.TabIndex = 2;
			this.CheckBox5.Text = "删除源图";
			this.CheckBox5.UseVisualStyleBackColor = true;
			this.TabPage5.BackColor = Color.Transparent;
			this.TabPage5.Controls.Add(this.TableLayoutPanel3);
			TabPage tabPage7 = this.TabPage5;
			location = new Point(4, 22);
			tabPage7.Location = location;
			this.TabPage5.Name = "TabPage5";
			Control tabPage8 = this.TabPage5;
			padding = new Padding(3);
			tabPage8.Padding = padding;
			Control tabPage9 = this.TabPage5;
			size = new Size(612, 410);
			tabPage9.Size = size;
			this.TabPage5.TabIndex = 4;
			this.TabPage5.Text = "（2）添加处理图片";
			this.TableLayoutPanel3.ColumnCount = 1;
			this.TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel3.Controls.Add(this.GroupBox2, 0, 0);
			this.TableLayoutPanel3.Controls.Add(this.GroupBox3, 0, 2);
			this.TableLayoutPanel3.Controls.Add(this.TableLayoutPanel7, 0, 1);
			this.TableLayoutPanel3.Dock = DockStyle.Fill;
			Control tableLayoutPanel5 = this.TableLayoutPanel3;
			location = new Point(3, 3);
			tableLayoutPanel5.Location = location;
			this.TableLayoutPanel3.Name = "TableLayoutPanel3";
			this.TableLayoutPanel3.RowCount = 3;
			this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 75f));
			this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
			Control tableLayoutPanel6 = this.TableLayoutPanel3;
			size = new Size(606, 404);
			tableLayoutPanel6.Size = size;
			this.TableLayoutPanel3.TabIndex = 0;
			this.GroupBox2.Controls.Add(this.TableLayoutPanel4);
			this.GroupBox2.Dock = DockStyle.Fill;
			Control groupBox3 = this.GroupBox2;
			location = new Point(3, 3);
			groupBox3.Location = location;
			this.GroupBox2.Name = "GroupBox2";
			Control groupBox4 = this.GroupBox2;
			size = new Size(600, 274);
			groupBox4.Size = size;
			this.GroupBox2.TabIndex = 0;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "模式一（分另手动添加文件，左底 右面）";
			this.TableLayoutPanel4.ColumnCount = 3;
			this.TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4f));
			this.TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.TableLayoutPanel4.Controls.Add(this.ListBox2, 0, 0);
			this.TableLayoutPanel4.Controls.Add(this.ListBox3, 2, 0);
			this.TableLayoutPanel4.Dock = DockStyle.Fill;
			Control tableLayoutPanel7 = this.TableLayoutPanel4;
			location = new Point(3, 17);
			tableLayoutPanel7.Location = location;
			this.TableLayoutPanel4.Name = "TableLayoutPanel4";
			this.TableLayoutPanel4.RowCount = 1;
			this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 254f));
			Control tableLayoutPanel8 = this.TableLayoutPanel4;
			size = new Size(594, 254);
			tableLayoutPanel8.Size = size;
			this.TableLayoutPanel4.TabIndex = 0;
			this.ListBox2.AllowDrop = true;
			this.ListBox2.Dock = DockStyle.Fill;
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.HorizontalScrollbar = true;
			this.ListBox2.ItemHeight = 12;
			Control listBox3 = this.ListBox2;
			location = new Point(3, 3);
			listBox3.Location = location;
			this.ListBox2.Name = "ListBox2";
			Control listBox4 = this.ListBox2;
			size = new Size(289, 248);
			listBox4.Size = size;
			this.ListBox2.TabIndex = 0;
			this.ListBox3.AllowDrop = true;
			this.ListBox3.Dock = DockStyle.Fill;
			this.ListBox3.FormattingEnabled = true;
			this.ListBox3.HorizontalScrollbar = true;
			this.ListBox3.ItemHeight = 12;
			Control listBox5 = this.ListBox3;
			location = new Point(302, 3);
			listBox5.Location = location;
			this.ListBox3.Name = "ListBox3";
			Control listBox6 = this.ListBox3;
			size = new Size(289, 248);
			listBox6.Size = size;
			this.ListBox3.TabIndex = 1;
			this.GroupBox3.Controls.Add(this.ListBox4);
			this.GroupBox3.Dock = DockStyle.Fill;
			Control groupBox5 = this.GroupBox3;
			location = new Point(3, 313);
			groupBox5.Location = location;
			this.GroupBox3.Name = "GroupBox3";
			Control groupBox6 = this.GroupBox3;
			size = new Size(600, 88);
			groupBox6.Size = size;
			this.GroupBox3.TabIndex = 1;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "模式二（添加文件夹）";
			this.ListBox4.AllowDrop = true;
			this.ListBox4.Dock = DockStyle.Fill;
			this.ListBox4.FormattingEnabled = true;
			this.ListBox4.HorizontalScrollbar = true;
			this.ListBox4.ItemHeight = 12;
			Control listBox7 = this.ListBox4;
			location = new Point(3, 17);
			listBox7.Location = location;
			this.ListBox4.Name = "ListBox4";
			Control listBox8 = this.ListBox4;
			size = new Size(594, 68);
			listBox8.Size = size;
			this.ListBox4.TabIndex = 0;
			this.TableLayoutPanel7.ColumnCount = 5;
			this.TableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
			this.TableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
			this.TableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
			this.TableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
			this.TableLayoutPanel7.Controls.Add(this.Button4, 2, 0);
			this.TableLayoutPanel7.Controls.Add(this.Button5, 1, 0);
			this.TableLayoutPanel7.Controls.Add(this.Button6, 3, 0);
			this.TableLayoutPanel7.Controls.Add(this.CheckBox3, 0, 0);
			this.TableLayoutPanel7.Controls.Add(this.CheckBox4, 4, 0);
			this.TableLayoutPanel7.Dock = DockStyle.Fill;
			Control tableLayoutPanel9 = this.TableLayoutPanel7;
			location = new Point(3, 283);
			tableLayoutPanel9.Location = location;
			this.TableLayoutPanel7.Name = "TableLayoutPanel7";
			this.TableLayoutPanel7.RowCount = 1;
			this.TableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			Control tableLayoutPanel10 = this.TableLayoutPanel7;
			size = new Size(600, 24);
			tableLayoutPanel10.Size = size;
			this.TableLayoutPanel7.TabIndex = 2;
			this.Button4.Anchor = AnchorStyles.Bottom;
			Control button5 = this.Button4;
			location = new Point(250, 0);
			button5.Location = location;
			Control button6 = this.Button4;
			padding = new Padding(0);
			button6.Margin = padding;
			this.Button4.Name = "Button4";
			Control button7 = this.Button4;
			size = new Size(100, 24);
			button7.Size = size;
			this.Button4.TabIndex = 3;
			this.Button4.Text = "全部清空";
			this.Button4.UseVisualStyleBackColor = true;
			this.Button5.Dock = DockStyle.Right;
			Control button8 = this.Button5;
			location = new Point(100, 0);
			button8.Location = location;
			Control button9 = this.Button5;
			padding = new Padding(0);
			button9.Margin = padding;
			this.Button5.Name = "Button5";
			Control button10 = this.Button5;
			size = new Size(100, 24);
			button10.Size = size;
			this.Button5.TabIndex = 4;
			this.Button5.Text = "左边清空";
			this.Button5.UseVisualStyleBackColor = true;
			this.Button6.Dock = DockStyle.Left;
			Control button11 = this.Button6;
			location = new Point(400, 0);
			button11.Location = location;
			Control button12 = this.Button6;
			padding = new Padding(0);
			button12.Margin = padding;
			this.Button6.Name = "Button6";
			Control button13 = this.Button6;
			size = new Size(100, 24);
			button13.Size = size;
			this.Button6.TabIndex = 5;
			this.Button6.Text = "右边清空";
			this.Button6.UseVisualStyleBackColor = true;
			this.CheckBox3.AutoSize = true;
			this.CheckBox3.Checked = true;
			this.CheckBox3.CheckState = CheckState.Checked;
			this.CheckBox3.Dock = DockStyle.Left;
			Control checkBox7 = this.CheckBox3;
			location = new Point(3, 3);
			checkBox7.Location = location;
			this.CheckBox3.Name = "CheckBox3";
			Control checkBox8 = this.CheckBox3;
			size = new Size(84, 18);
			checkBox8.Size = size;
			this.CheckBox3.TabIndex = 6;
			this.CheckBox3.Text = "左边一次性";
			this.CheckBox3.UseVisualStyleBackColor = true;
			this.CheckBox4.AutoSize = true;
			this.CheckBox4.Checked = true;
			this.CheckBox4.CheckState = CheckState.Checked;
			this.CheckBox4.Dock = DockStyle.Right;
			Control checkBox9 = this.CheckBox4;
			location = new Point(513, 3);
			checkBox9.Location = location;
			this.CheckBox4.Name = "CheckBox4";
			Control checkBox10 = this.CheckBox4;
			size = new Size(84, 18);
			checkBox10.Size = size;
			this.CheckBox4.TabIndex = 7;
			this.CheckBox4.Text = "右边一次性";
			this.CheckBox4.UseVisualStyleBackColor = true;
			this.TabPage4.BackColor = Color.Transparent;
			this.TabPage4.Controls.Add(this.TableLayoutPanel5);
			this.TabPage4.ImeMode = ImeMode.Off;
			TabPage tabPage10 = this.TabPage4;
			location = new Point(4, 22);
			tabPage10.Location = location;
			this.TabPage4.Name = "TabPage4";
			Control tabPage11 = this.TabPage4;
			padding = new Padding(3);
			tabPage11.Padding = padding;
			Control tabPage12 = this.TabPage4;
			size = new Size(612, 410);
			tabPage12.Size = size;
			this.TabPage4.TabIndex = 3;
			this.TabPage4.Text = "（2）选择合成规则";
			this.TableLayoutPanel5.ColumnCount = 3;
			this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
			this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
			this.TableLayoutPanel5.Controls.Add(this.Button3, 1, 1);
			this.TableLayoutPanel5.Controls.Add(this.DoubleBufferTreeView1, 0, 0);
			this.TableLayoutPanel5.Controls.Add(this.Panel1, 0, 1);
			this.TableLayoutPanel5.Controls.Add(this.Button7, 2, 1);
			this.TableLayoutPanel5.Dock = DockStyle.Fill;
			Control tableLayoutPanel11 = this.TableLayoutPanel5;
			location = new Point(3, 3);
			tableLayoutPanel11.Location = location;
			this.TableLayoutPanel5.Name = "TableLayoutPanel5";
			this.TableLayoutPanel5.RowCount = 2;
			this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
			Control tableLayoutPanel12 = this.TableLayoutPanel5;
			size = new Size(606, 404);
			tableLayoutPanel12.Size = size;
			this.TableLayoutPanel5.TabIndex = 2;
			this.Button3.Anchor = AnchorStyles.Left;
			Control button14 = this.Button3;
			location = new Point(389, 369);
			button14.Location = location;
			this.Button3.Name = "Button3";
			Control button15 = this.Button3;
			size = new Size(100, 30);
			button15.Size = size;
			this.Button3.TabIndex = 1;
			this.Button3.Text = "执 行";
			this.Button3.UseVisualStyleBackColor = true;
			this.Panel1.Anchor = AnchorStyles.Left;
			this.Panel1.AutoSize = true;
			this.Panel1.Controls.Add(this.CheckBox2);
			this.Panel1.Controls.Add(this.FlowLayoutPanel4);
			Control panel24 = this.Panel1;
			location = new Point(3, 367);
			panel24.Location = location;
			this.Panel1.Name = "Panel1";
			Control panel25 = this.Panel1;
			size = new Size(341, 34);
			panel25.Size = size;
			this.Panel1.TabIndex = 2;
			this.CheckBox2.AutoSize = true;
			Control checkBox11 = this.CheckBox2;
			location = new Point(212, 7);
			checkBox11.Location = location;
			this.CheckBox2.Name = "CheckBox2";
			Control checkBox12 = this.CheckBox2;
			size = new Size(126, 16);
			checkBox12.Size = size;
			this.CheckBox2.TabIndex = 6;
			this.CheckBox2.Text = "不移入0_YouCanDel";
			this.CheckBox2.UseVisualStyleBackColor = true;
			this.FlowLayoutPanel4.AutoSize = true;
			this.FlowLayoutPanel4.Controls.Add(this.Label5);
			this.FlowLayoutPanel4.Controls.Add(this.ComboBox4);
			this.FlowLayoutPanel4.Controls.Add(this.NumericUpDown13);
			Control flowLayoutPanel20 = this.FlowLayoutPanel4;
			location = new Point(3, 4);
			flowLayoutPanel20.Location = location;
			this.FlowLayoutPanel4.Name = "FlowLayoutPanel4";
			Control flowLayoutPanel21 = this.FlowLayoutPanel4;
			size = new Size(203, 27);
			flowLayoutPanel21.Size = size;
			this.FlowLayoutPanel4.TabIndex = 7;
			this.Label5.AutoSize = true;
			Control label25 = this.Label5;
			location = new Point(3, 5);
			label25.Location = location;
			Control label26 = this.Label5;
			padding = new Padding(3, 5, 3, 0);
			label26.Margin = padding;
			this.Label5.Name = "Label5";
			Control label27 = this.Label5;
			size = new Size(65, 12);
			label27.Size = size;
			this.Label5.TabIndex = 3;
			this.Label5.Text = "保存格式：";
			this.ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ComboBox4.FormattingEnabled = true;
			this.ComboBox4.Items.AddRange(new object[]
			{
				"PNG",
				"BMP",
				"JPG"
			});
			Control comboBox7 = this.ComboBox4;
			location = new Point(74, 3);
			comboBox7.Location = location;
			this.ComboBox4.Name = "ComboBox4";
			Control comboBox8 = this.ComboBox4;
			size = new Size(65, 20);
			comboBox8.Size = size;
			this.ComboBox4.TabIndex = 4;
			Control numericUpDown51 = this.NumericUpDown13;
			location = new Point(145, 3);
			numericUpDown51.Location = location;
			this.NumericUpDown13.Name = "NumericUpDown13";
			Control numericUpDown52 = this.NumericUpDown13;
			size = new Size(45, 21);
			numericUpDown52.Size = size;
			this.NumericUpDown13.TabIndex = 5;
			NumericUpDown numericUpDown53 = this.NumericUpDown13;
			num = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			numericUpDown53.Value = num;
			this.Button7.Anchor = AnchorStyles.Right;
			Control button16 = this.Button7;
			location = new Point(503, 369);
			button16.Location = location;
			this.Button7.Name = "Button7";
			Control button17 = this.Button7;
			size = new Size(100, 30);
			button17.Size = size;
			this.Button7.TabIndex = 3;
			this.Button7.Text = "特别设定";
			this.Button7.UseVisualStyleBackColor = true;
			this.TabPage3.BackColor = Color.Transparent;
			this.TabPage3.Controls.Add(this.TextBox1);
			TabPage tabPage13 = this.TabPage3;
			location = new Point(4, 22);
			tabPage13.Location = location;
			this.TabPage3.Name = "TabPage3";
			Control tabPage14 = this.TabPage3;
			padding = new Padding(3);
			tabPage14.Padding = padding;
			Control tabPage15 = this.TabPage3;
			size = new Size(612, 410);
			tabPage15.Size = size;
			this.TabPage3.TabIndex = 2;
			this.TabPage3.Text = " 日 志 ";
			this.TextBox1.AcceptsReturn = true;
			this.TextBox1.BackColor = Color.White;
			this.TextBox1.Dock = DockStyle.Fill;
			this.TextBox1.ImeMode = ImeMode.Off;
			Control textBox = this.TextBox1;
			location = new Point(3, 3);
			textBox.Location = location;
			this.TextBox1.MaxLength = 65536;
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.ScrollBars = ScrollBars.Both;
			Control textBox2 = this.TextBox1;
			size = new Size(606, 404);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 0;
			this.BackgroundWorker1.WorkerReportsProgress = true;
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker2.WorkerReportsProgress = true;
			this.BackgroundWorker2.WorkerSupportsCancellation = true;
			this.ToolTip1.AutoPopDelay = 5000;
			this.ToolTip1.InitialDelay = 100;
			this.ToolTip1.ReshowDelay = 100;
			this.ToolTip1.UseAnimation = false;
			this.ToolTip1.UseFading = false;
			this.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
			this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
			this.NotifyIcon1.Icon = (Icon)componentResourceManager.GetObject("NotifyIcon1.Icon");
			this.NotifyIcon1.Text = "GAL图片自动处理器";
			this.NotifyIcon1.Visible = true;
			this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.ToolStripMenuItem1,
				this.ToolStripSeparator1,
				this.ToolStripMenuItem2
			});
			this.ContextMenuStrip1.Name = "ContextMenuStrip1";
			Control contextMenuStrip = this.ContextMenuStrip1;
			size = new Size(125, 54);
			contextMenuStrip.Size = size;
			this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
			ToolStripItem toolStripMenuItem = this.ToolStripMenuItem1;
			size = new Size(124, 22);
			toolStripMenuItem.Size = size;
			this.ToolStripMenuItem1.Text = "关闭程序";
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			ToolStripItem toolStripSeparator = this.ToolStripSeparator1;
			size = new Size(121, 6);
			toolStripSeparator.Size = size;
			this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
			ToolStripItem toolStripMenuItem2 = this.ToolStripMenuItem2;
			size = new Size(124, 22);
			toolStripMenuItem2.Size = size;
			this.ToolStripMenuItem2.Text = "返回程序";
			this.Timer1.Interval = 1001;
			this.StatusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.ToolStripStatusLabel1,
				this.ToolStripStatusLabel2,
				this.ToolStripStatusLabel3,
				this.ToolStripStatusLabel4,
				this.ToolStripStatusLabel5
			});
			Control statusStrip = this.StatusStrip1;
			location = new Point(0, 442);
			statusStrip.Location = location;
			this.StatusStrip1.Name = "StatusStrip1";
			Control statusStrip2 = this.StatusStrip1;
			size = new Size(626, 22);
			statusStrip2.Size = size;
			this.StatusStrip1.TabIndex = 1;
			this.StatusStrip1.Text = "StatusStrip1";
			this.ToolStripStatusLabel1.AutoSize = false;
			this.ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
			ToolStripItem toolStripStatusLabel = this.ToolStripStatusLabel1;
			padding = new Padding(0, 3, 0, 3);
			toolStripStatusLabel.Margin = padding;
			this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
			ToolStripItem toolStripStatusLabel2 = this.ToolStripStatusLabel1;
			size = new Size(50, 16);
			toolStripStatusLabel2.Size = size;
			this.ToolStripStatusLabel2.AutoSize = false;
			this.ToolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;
			ToolStripItem toolStripStatusLabel3 = this.ToolStripStatusLabel2;
			padding = new Padding(0, 3, 0, 3);
			toolStripStatusLabel3.Margin = padding;
			this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
			ToolStripItem toolStripStatusLabel4 = this.ToolStripStatusLabel2;
			size = new Size(150, 16);
			toolStripStatusLabel4.Size = size;
			this.ToolStripStatusLabel3.AutoSize = false;
			this.ToolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;
			ToolStripItem toolStripStatusLabel5 = this.ToolStripStatusLabel3;
			padding = new Padding(0, 3, 0, 3);
			toolStripStatusLabel5.Margin = padding;
			this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
			ToolStripItem toolStripStatusLabel6 = this.ToolStripStatusLabel3;
			size = new Size(100, 16);
			toolStripStatusLabel6.Size = size;
			this.ToolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Right;
			ToolStripItem toolStripStatusLabel7 = this.ToolStripStatusLabel4;
			padding = new Padding(0, 3, 0, 3);
			toolStripStatusLabel7.Margin = padding;
			this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
			ToolStripItem toolStripStatusLabel8 = this.ToolStripStatusLabel4;
			size = new Size(211, 16);
			toolStripStatusLabel8.Size = size;
			this.ToolStripStatusLabel4.Spring = true;
			this.ToolStripStatusLabel5.AutoSize = false;
			ToolStripItem toolStripStatusLabel9 = this.ToolStripStatusLabel5;
			padding = new Padding(0, 3, 0, 3);
			toolStripStatusLabel9.Margin = padding;
			this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
			ToolStripItem toolStripStatusLabel10 = this.ToolStripStatusLabel5;
			size = new Size(100, 16);
			toolStripStatusLabel10.Size = size;
			this.ToolStripStatusLabel5.Text = "00:00:00";
			this.TableLayoutPanel6.ColumnCount = 1;
			this.TableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel6.Controls.Add(this.TabControl1, 0, 0);
			this.TableLayoutPanel6.Dock = DockStyle.Fill;
			Control tableLayoutPanel13 = this.TableLayoutPanel6;
			location = new Point(0, 0);
			tableLayoutPanel13.Location = location;
			this.TableLayoutPanel6.Name = "TableLayoutPanel6";
			this.TableLayoutPanel6.RowCount = 2;
			this.TableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.TableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			Control tableLayoutPanel14 = this.TableLayoutPanel6;
			size = new Size(626, 464);
			tableLayoutPanel14.Size = size;
			this.TableLayoutPanel6.TabIndex = 2;
			this.SplitterLabel9.ImeMode = ImeMode.Off;
			Control splitterLabel = this.SplitterLabel9;
			location = new Point(9, 311);
			splitterLabel.Location = location;
			this.SplitterLabel9.Name = "SplitterLabel9";
			Control splitterLabel2 = this.SplitterLabel9;
			size = new Size(580, 2);
			splitterLabel2.Size = size;
			this.SplitterLabel9.TabIndex = 38;
			this.SplitterLabel8.ImeMode = ImeMode.Off;
			Control splitterLabel3 = this.SplitterLabel8;
			location = new Point(9, 248);
			splitterLabel3.Location = location;
			this.SplitterLabel8.Name = "SplitterLabel8";
			Control splitterLabel4 = this.SplitterLabel8;
			size = new Size(580, 2);
			splitterLabel4.Size = size;
			this.SplitterLabel8.TabIndex = 37;
			this.SplitterLabel7.ImeMode = ImeMode.Off;
			Control splitterLabel5 = this.SplitterLabel7;
			location = new Point(9, 216);
			splitterLabel5.Location = location;
			this.SplitterLabel7.Name = "SplitterLabel7";
			Control splitterLabel6 = this.SplitterLabel7;
			size = new Size(580, 2);
			splitterLabel6.Size = size;
			this.SplitterLabel7.TabIndex = 33;
			this.SplitterLabel6.ImeMode = ImeMode.Off;
			Control splitterLabel7 = this.SplitterLabel6;
			location = new Point(9, 184);
			splitterLabel7.Location = location;
			this.SplitterLabel6.Name = "SplitterLabel6";
			Control splitterLabel8 = this.SplitterLabel6;
			size = new Size(580, 2);
			splitterLabel8.Size = size;
			this.SplitterLabel6.TabIndex = 27;
			this.SplitterLabel2.ImeMode = ImeMode.Off;
			Control splitterLabel9 = this.SplitterLabel2;
			location = new Point(9, 59);
			splitterLabel9.Location = location;
			this.SplitterLabel2.Name = "SplitterLabel2";
			Control splitterLabel10 = this.SplitterLabel2;
			size = new Size(580, 2);
			splitterLabel10.Size = size;
			this.SplitterLabel2.TabIndex = 14;
			this.SplitterLabel1.ImeMode = ImeMode.Off;
			Control splitterLabel11 = this.SplitterLabel1;
			location = new Point(9, 29);
			splitterLabel11.Location = location;
			this.SplitterLabel1.Name = "SplitterLabel1";
			Control splitterLabel12 = this.SplitterLabel1;
			size = new Size(580, 2);
			splitterLabel12.Size = size;
			this.SplitterLabel1.TabIndex = 13;
			this.SplitterLabel5.ImeMode = ImeMode.Off;
			Control splitterLabel13 = this.SplitterLabel5;
			location = new Point(9, 154);
			splitterLabel13.Location = location;
			this.SplitterLabel5.Name = "SplitterLabel5";
			Control splitterLabel14 = this.SplitterLabel5;
			size = new Size(580, 2);
			splitterLabel14.Size = size;
			this.SplitterLabel5.TabIndex = 21;
			this.SplitterLabel4.ImeMode = ImeMode.Off;
			Control splitterLabel15 = this.SplitterLabel4;
			location = new Point(9, 122);
			splitterLabel15.Location = location;
			this.SplitterLabel4.Name = "SplitterLabel4";
			Control splitterLabel16 = this.SplitterLabel4;
			size = new Size(580, 2);
			splitterLabel16.Size = size;
			this.SplitterLabel4.TabIndex = 18;
			this.SplitterLabel3.ImeMode = ImeMode.Off;
			Control splitterLabel17 = this.SplitterLabel3;
			location = new Point(9, 92);
			splitterLabel17.Location = location;
			this.SplitterLabel3.Name = "SplitterLabel3";
			Control splitterLabel18 = this.SplitterLabel3;
			size = new Size(580, 2);
			splitterLabel18.Size = size;
			this.SplitterLabel3.TabIndex = 15;
			this.TableLayoutPanel5.SetColumnSpan(this.DoubleBufferTreeView1, 3);
			this.DoubleBufferTreeView1.Dock = DockStyle.Fill;
			this.DoubleBufferTreeView1.ItemHeight = 18;
			Control doubleBufferTreeView = this.DoubleBufferTreeView1;
			location = new Point(3, 3);
			doubleBufferTreeView.Location = location;
			this.DoubleBufferTreeView1.Name = "DoubleBufferTreeView1";
			Control doubleBufferTreeView2 = this.DoubleBufferTreeView1;
			size = new Size(600, 358);
			doubleBufferTreeView2.Size = size;
			this.DoubleBufferTreeView1.TabIndex = 2;
			SizeF autoScaleDimensions = new SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(626, 464);
			this.ClientSize = size;
			this.Controls.Add(this.StatusStrip1);
			this.Controls.Add(this.TableLayoutPanel6);
			this.DoubleBuffered = true;
			this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			size = new Size(642, 502);
			this.MinimumSize = size;
			this.Name = "Form1";
			this.Text = "GAL图片自动处理器";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TableLayoutPanel2.ResumeLayout(false);
			this.TableLayoutPanel2.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.Panel8.ResumeLayout(false);
			this.Panel8.PerformLayout();
			this.Panel10.ResumeLayout(false);
			this.Panel10.PerformLayout();
			((ISupportInitialize)this.NumericUpDown17).EndInit();
			this.FlowLayoutPanel9.ResumeLayout(false);
			this.FlowLayoutPanel9.PerformLayout();
			((ISupportInitialize)this.NumericUpDown14).EndInit();
			((ISupportInitialize)this.NumericUpDown15).EndInit();
			((ISupportInitialize)this.NumericUpDown16).EndInit();
			this.FlowLayoutPanel7.ResumeLayout(false);
			this.FlowLayoutPanel7.PerformLayout();
			this.FlowLayoutPanel8.ResumeLayout(false);
			this.FlowLayoutPanel8.PerformLayout();
			((ISupportInitialize)this.NumericUpDown10).EndInit();
			((ISupportInitialize)this.NumericUpDown11).EndInit();
			this.Panel9.ResumeLayout(false);
			this.Panel9.PerformLayout();
			((ISupportInitialize)this.NumericUpDown12).EndInit();
			this.FlowLayoutPanel3.ResumeLayout(false);
			this.FlowLayoutPanel3.PerformLayout();
			((ISupportInitialize)this.NumericUpDown6).EndInit();
			this.FlowLayoutPanel2.ResumeLayout(false);
			this.FlowLayoutPanel2.PerformLayout();
			((ISupportInitialize)this.NumericUpDown1).EndInit();
			((ISupportInitialize)this.NumericUpDown2).EndInit();
			((ISupportInitialize)this.NumericUpDown3).EndInit();
			((ISupportInitialize)this.NumericUpDown4).EndInit();
			this.FlowLayoutPanel1.ResumeLayout(false);
			this.FlowLayoutPanel1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			this.Panel2.PerformLayout();
			((ISupportInitialize)this.NumericUpDown5).EndInit();
			this.FlowLayoutPanel5.ResumeLayout(false);
			this.FlowLayoutPanel5.PerformLayout();
			this.FlowLayoutPanel6.ResumeLayout(false);
			this.FlowLayoutPanel6.PerformLayout();
			((ISupportInitialize)this.NumericUpDown7).EndInit();
			((ISupportInitialize)this.NumericUpDown9).EndInit();
			this.Panel3.ResumeLayout(false);
			this.Panel3.PerformLayout();
			((ISupportInitialize)this.NumericUpDown8).EndInit();
			this.TabPage5.ResumeLayout(false);
			this.TableLayoutPanel3.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.TableLayoutPanel4.ResumeLayout(false);
			this.GroupBox3.ResumeLayout(false);
			this.TableLayoutPanel7.ResumeLayout(false);
			this.TableLayoutPanel7.PerformLayout();
			this.TabPage4.ResumeLayout(false);
			this.TableLayoutPanel5.ResumeLayout(false);
			this.TableLayoutPanel5.PerformLayout();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.FlowLayoutPanel4.ResumeLayout(false);
			this.FlowLayoutPanel4.PerformLayout();
			((ISupportInitialize)this.NumericUpDown13).EndInit();
			this.TabPage3.ResumeLayout(false);
			this.TabPage3.PerformLayout();
			this.ContextMenuStrip1.ResumeLayout(false);
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			this.TableLayoutPanel6.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00032B04 File Offset: 0x00030D04
		// (set) Token: 0x060002CA RID: 714 RVA: 0x00032B18 File Offset: 0x00030D18
		internal virtual TabControl TabControl1
		{
			get
			{
				return this.g;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ah);
				if (this.g != null)
				{
					this.g.SelectedIndexChanged -= value2;
				}
				this.g = value;
				if (this.g != null)
				{
					this.g.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00032B64 File Offset: 0x00030D64
		// (set) Token: 0x060002CC RID: 716 RVA: 0x00032B77 File Offset: 0x00030D77
		internal virtual TabPage TabPage1
		{
			get
			{
				return this.h;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.h = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00032B80 File Offset: 0x00030D80
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00032B93 File Offset: 0x00030D93
		internal virtual TabPage TabPage2
		{
			get
			{
				return this.i;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00032B9C File Offset: 0x00030D9C
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00032BAF File Offset: 0x00030DAF
		internal virtual TabPage TabPage3
		{
			get
			{
				return this.j;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x00032BB8 File Offset: 0x00030DB8
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00032BCB File Offset: 0x00030DCB
		internal virtual TabPage TabPage4
		{
			get
			{
				return this.k;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x00032BD4 File Offset: 0x00030DD4
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x00032BE7 File Offset: 0x00030DE7
		internal virtual TabPage TabPage5
		{
			get
			{
				return this.l;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x00032BF0 File Offset: 0x00030DF0
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x00032C04 File Offset: 0x00030E04
		internal virtual ListBox ListBox1
		{
			get
			{
				return this.m;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DragEventHandler value2 = new DragEventHandler(this.h);
				MouseEventHandler value3 = new MouseEventHandler(this.e);
				DragEventHandler value4 = new DragEventHandler(this.d);
				if (this.m != null)
				{
					this.m.DragEnter -= value2;
					this.m.MouseDown -= value3;
					this.m.DragDrop -= value4;
				}
				this.m = value;
				if (this.m != null)
				{
					this.m.DragEnter += value2;
					this.m.MouseDown += value3;
					this.m.DragDrop += value4;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x00032C9C File Offset: 0x00030E9C
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x00032CAF File Offset: 0x00030EAF
		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this.n;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00032CB8 File Offset: 0x00030EB8
		// (set) Token: 0x060002DA RID: 730 RVA: 0x00032CCC File Offset: 0x00030ECC
		internal virtual Button Button2
		{
			get
			{
				return this.o;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.t);
				if (this.o != null)
				{
					this.o.Click -= value2;
				}
				this.o = value;
				if (this.o != null)
				{
					this.o.Click += value2;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060002DB RID: 731 RVA: 0x00032D18 File Offset: 0x00030F18
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00032D2C File Offset: 0x00030F2C
		internal virtual Button Button1
		{
			get
			{
				return this.p;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.u);
				if (this.p != null)
				{
					this.p.Click -= value2;
				}
				this.p = value;
				if (this.p != null)
				{
					this.p.Click += value2;
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00032D78 File Offset: 0x00030F78
		// (set) Token: 0x060002DE RID: 734 RVA: 0x00032D8C File Offset: 0x00030F8C
		internal virtual BackgroundWorker BackgroundWorker1
		{
			get
			{
				return this.q;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ProgressChangedEventHandler value2 = new ProgressChangedEventHandler(this.b);
				DoWorkEventHandler value3 = new DoWorkEventHandler(this.b);
				RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.b);
				if (this.q != null)
				{
					this.q.ProgressChanged -= value2;
					this.q.DoWork -= value3;
					this.q.RunWorkerCompleted -= value4;
				}
				this.q = value;
				if (this.q != null)
				{
					this.q.ProgressChanged += value2;
					this.q.DoWork += value3;
					this.q.RunWorkerCompleted += value4;
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00032E24 File Offset: 0x00031024
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x00032E37 File Offset: 0x00031037
		internal virtual RadioButton RadioButton1
		{
			get
			{
				return this.r;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.r = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00032E40 File Offset: 0x00031040
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x00032E53 File Offset: 0x00031053
		internal virtual RadioButton RadioButton2
		{
			get
			{
				return this.s;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.s = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00032E5C File Offset: 0x0003105C
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x00032E6F File Offset: 0x0003106F
		internal virtual NumericUpDown NumericUpDown1
		{
			get
			{
				return this.t;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.t = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00032E78 File Offset: 0x00031078
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00032E8B File Offset: 0x0003108B
		internal virtual Label Label4
		{
			get
			{
				return this.u;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.u = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00032E94 File Offset: 0x00031094
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x00032EA7 File Offset: 0x000310A7
		internal virtual Label Label3
		{
			get
			{
				return this.v;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.v = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00032EB0 File Offset: 0x000310B0
		// (set) Token: 0x060002EA RID: 746 RVA: 0x00032EC3 File Offset: 0x000310C3
		internal virtual Label Label2
		{
			get
			{
				return this.w;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.w = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00032ECC File Offset: 0x000310CC
		// (set) Token: 0x060002EC RID: 748 RVA: 0x00032EDF File Offset: 0x000310DF
		internal virtual Label Label1
		{
			get
			{
				return this.x;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.x = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00032EE8 File Offset: 0x000310E8
		// (set) Token: 0x060002EE RID: 750 RVA: 0x00032EFB File Offset: 0x000310FB
		internal virtual RadioButton RadioButton3
		{
			get
			{
				return this.y;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00032F04 File Offset: 0x00031104
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x00032F17 File Offset: 0x00031117
		internal virtual NumericUpDown NumericUpDown2
		{
			get
			{
				return this.z;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.z = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00032F20 File Offset: 0x00031120
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x00032F33 File Offset: 0x00031133
		internal virtual NumericUpDown NumericUpDown4
		{
			get
			{
				return this.aa;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.aa = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x00032F3C File Offset: 0x0003113C
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x00032F4F File Offset: 0x0003114F
		internal virtual NumericUpDown NumericUpDown3
		{
			get
			{
				return this.ab;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ab = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00032F58 File Offset: 0x00031158
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00032F6C File Offset: 0x0003116C
		internal virtual TextBox TextBox1
		{
			get
			{
				return this.ac;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.a);
				if (this.ac != null)
				{
					this.ac.KeyPress -= value2;
				}
				this.ac = value;
				if (this.ac != null)
				{
					this.ac.KeyPress += value2;
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00032FB8 File Offset: 0x000311B8
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00032FCB File Offset: 0x000311CB
		internal virtual SplitterLabel SplitterLabel2
		{
			get
			{
				return this.ad;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ad = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00032FD4 File Offset: 0x000311D4
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00032FE7 File Offset: 0x000311E7
		internal virtual SplitterLabel SplitterLabel3
		{
			get
			{
				return this.ae;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ae = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00032FF0 File Offset: 0x000311F0
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00033003 File Offset: 0x00031203
		internal virtual RadioButton RadioButton4
		{
			get
			{
				return this.af;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.af = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0003300C File Offset: 0x0003120C
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00033020 File Offset: 0x00031220
		internal virtual NumericUpDown NumericUpDown5
		{
			get
			{
				return this.ag;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.o);
				MouseEventHandler value3 = new MouseEventHandler(this.aa);
				if (this.ag != null)
				{
					this.ag.ValueChanged -= value2;
					this.ag.MouseClick -= value3;
				}
				this.ag = value;
				if (this.ag != null)
				{
					this.ag.ValueChanged += value2;
					this.ag.MouseClick += value3;
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00033090 File Offset: 0x00031290
		// (set) Token: 0x06000300 RID: 768 RVA: 0x000330A3 File Offset: 0x000312A3
		internal virtual RadioButton RadioButton6
		{
			get
			{
				return this.ah;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ah = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000301 RID: 769 RVA: 0x000330AC File Offset: 0x000312AC
		// (set) Token: 0x06000302 RID: 770 RVA: 0x000330BF File Offset: 0x000312BF
		internal virtual RadioButton RadioButton5
		{
			get
			{
				return this.ai;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ai = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000303 RID: 771 RVA: 0x000330C8 File Offset: 0x000312C8
		// (set) Token: 0x06000304 RID: 772 RVA: 0x000330DB File Offset: 0x000312DB
		internal virtual SplitterLabel SplitterLabel4
		{
			get
			{
				return this.aj;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.aj = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000305 RID: 773 RVA: 0x000330E4 File Offset: 0x000312E4
		// (set) Token: 0x06000306 RID: 774 RVA: 0x000330F7 File Offset: 0x000312F7
		internal virtual CheckBox CheckBox1
		{
			get
			{
				return this.ak;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ak = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00033100 File Offset: 0x00031300
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00033114 File Offset: 0x00031314
		internal virtual Button Button3
		{
			get
			{
				return this.al;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.s);
				if (this.al != null)
				{
					this.al.Click -= value2;
				}
				this.al = value;
				if (this.al != null)
				{
					this.al.Click += value2;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00033160 File Offset: 0x00031360
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00033174 File Offset: 0x00031374
		internal virtual BackgroundWorker BackgroundWorker2
		{
			get
			{
				return this.am;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ProgressChangedEventHandler value2 = new ProgressChangedEventHandler(this.a);
				DoWorkEventHandler value3 = new DoWorkEventHandler(this.a);
				RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.a);
				if (this.am != null)
				{
					this.am.ProgressChanged -= value2;
					this.am.DoWork -= value3;
					this.am.RunWorkerCompleted -= value4;
				}
				this.am = value;
				if (this.am != null)
				{
					this.am.ProgressChanged += value2;
					this.am.DoWork += value3;
					this.am.RunWorkerCompleted += value4;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0003320C File Offset: 0x0003140C
		// (set) Token: 0x0600030C RID: 780 RVA: 0x0003321F File Offset: 0x0003141F
		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			get
			{
				return this.an;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.an = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00033228 File Offset: 0x00031428
		// (set) Token: 0x0600030E RID: 782 RVA: 0x0003323B File Offset: 0x0003143B
		internal virtual TableLayoutPanel TableLayoutPanel2
		{
			get
			{
				return this.ao;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ao = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600030F RID: 783 RVA: 0x00033244 File Offset: 0x00031444
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00033257 File Offset: 0x00031457
		internal virtual TableLayoutPanel TableLayoutPanel3
		{
			get
			{
				return this.ap;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ap = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000311 RID: 785 RVA: 0x00033260 File Offset: 0x00031460
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00033273 File Offset: 0x00031473
		internal virtual GroupBox GroupBox2
		{
			get
			{
				return this.aq;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.aq = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0003327C File Offset: 0x0003147C
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0003328F File Offset: 0x0003148F
		internal virtual GroupBox GroupBox3
		{
			get
			{
				return this.ar;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ar = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00033298 File Offset: 0x00031498
		// (set) Token: 0x06000316 RID: 790 RVA: 0x000332AB File Offset: 0x000314AB
		internal virtual TableLayoutPanel TableLayoutPanel4
		{
			get
			{
				return this.@as;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.@as = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000332B4 File Offset: 0x000314B4
		// (set) Token: 0x06000318 RID: 792 RVA: 0x000332C8 File Offset: 0x000314C8
		internal virtual ListBox ListBox2
		{
			get
			{
				return this.at;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.d);
				DragEventHandler value3 = new DragEventHandler(this.c);
				DragEventHandler value4 = new DragEventHandler(this.g);
				if (this.at != null)
				{
					this.at.MouseDown -= value2;
					this.at.DragDrop -= value3;
					this.at.DragEnter -= value4;
				}
				this.at = value;
				if (this.at != null)
				{
					this.at.MouseDown += value2;
					this.at.DragDrop += value3;
					this.at.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00033360 File Offset: 0x00031560
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00033374 File Offset: 0x00031574
		internal virtual ListBox ListBox3
		{
			get
			{
				return this.au;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.c);
				DragEventHandler value3 = new DragEventHandler(this.b);
				DragEventHandler value4 = new DragEventHandler(this.f);
				if (this.au != null)
				{
					this.au.MouseDown -= value2;
					this.au.DragDrop -= value3;
					this.au.DragEnter -= value4;
				}
				this.au = value;
				if (this.au != null)
				{
					this.au.MouseDown += value2;
					this.au.DragDrop += value3;
					this.au.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0003340C File Offset: 0x0003160C
		// (set) Token: 0x0600031C RID: 796 RVA: 0x0003341F File Offset: 0x0003161F
		internal virtual SplitterLabel SplitterLabel1
		{
			get
			{
				return this.av;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.av = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00033428 File Offset: 0x00031628
		// (set) Token: 0x0600031E RID: 798 RVA: 0x0003343C File Offset: 0x0003163C
		internal virtual ListBox ListBox4
		{
			get
			{
				return this.aw;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.b);
				DragEventHandler value3 = new DragEventHandler(this.a);
				DragEventHandler value4 = new DragEventHandler(this.e);
				if (this.aw != null)
				{
					this.aw.MouseDown -= value2;
					this.aw.DragDrop -= value3;
					this.aw.DragEnter -= value4;
				}
				this.aw = value;
				if (this.aw != null)
				{
					this.aw.MouseDown += value2;
					this.aw.DragDrop += value3;
					this.aw.DragEnter += value4;
				}
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600031F RID: 799 RVA: 0x000334D4 File Offset: 0x000316D4
		// (set) Token: 0x06000320 RID: 800 RVA: 0x000334E7 File Offset: 0x000316E7
		internal virtual TableLayoutPanel TableLayoutPanel5
		{
			get
			{
				return this.ax;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ax = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000321 RID: 801 RVA: 0x000334F0 File Offset: 0x000316F0
		// (set) Token: 0x06000322 RID: 802 RVA: 0x00033503 File Offset: 0x00031703
		internal virtual Label Label5
		{
			get
			{
				return this.ay;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ay = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0003350C File Offset: 0x0003170C
		// (set) Token: 0x06000324 RID: 804 RVA: 0x0003351F File Offset: 0x0003171F
		internal virtual CheckBox CheckBox2
		{
			get
			{
				return this.az;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.az = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00033528 File Offset: 0x00031728
		// (set) Token: 0x06000326 RID: 806 RVA: 0x0003353B File Offset: 0x0003173B
		internal virtual TableLayoutPanel TableLayoutPanel7
		{
			get
			{
				return this.a0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.a0 = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00033544 File Offset: 0x00031744
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00033558 File Offset: 0x00031758
		internal virtual Button Button4
		{
			get
			{
				return this.a1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.r);
				if (this.a1 != null)
				{
					this.a1.Click -= value2;
				}
				this.a1 = value;
				if (this.a1 != null)
				{
					this.a1.Click += value2;
				}
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000329 RID: 809 RVA: 0x000335A4 File Offset: 0x000317A4
		// (set) Token: 0x0600032A RID: 810 RVA: 0x000335B8 File Offset: 0x000317B8
		internal virtual Button Button5
		{
			get
			{
				return this.a2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.q);
				if (this.a2 != null)
				{
					this.a2.Click -= value2;
				}
				this.a2 = value;
				if (this.a2 != null)
				{
					this.a2.Click += value2;
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00033604 File Offset: 0x00031804
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00033618 File Offset: 0x00031818
		internal virtual Button Button6
		{
			get
			{
				return this.a3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.p);
				if (this.a3 != null)
				{
					this.a3.Click -= value2;
				}
				this.a3 = value;
				if (this.a3 != null)
				{
					this.a3.Click += value2;
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00033664 File Offset: 0x00031864
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00033677 File Offset: 0x00031877
		internal virtual ColorDialog ColorDialog1
		{
			get
			{
				return this.a4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.a4 = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00033680 File Offset: 0x00031880
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00033693 File Offset: 0x00031893
		internal virtual RadioButton RadioButton9
		{
			get
			{
				return this.a5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.a5 = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0003369C File Offset: 0x0003189C
		// (set) Token: 0x06000332 RID: 818 RVA: 0x000336B0 File Offset: 0x000318B0
		internal virtual Panel Panel4
		{
			get
			{
				return this.a6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ae);
				if (this.a6 != null)
				{
					this.a6.MouseClick -= value2;
				}
				this.a6 = value;
				if (this.a6 != null)
				{
					this.a6.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000333 RID: 819 RVA: 0x000336FC File Offset: 0x000318FC
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0003370F File Offset: 0x0003190F
		internal virtual RadioButton RadioButton10
		{
			get
			{
				return this.a7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.a7 = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00033718 File Offset: 0x00031918
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0003372C File Offset: 0x0003192C
		internal virtual Panel Panel5
		{
			get
			{
				return this.a8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ad);
				if (this.a8 != null)
				{
					this.a8.MouseClick -= value2;
				}
				this.a8 = value;
				if (this.a8 != null)
				{
					this.a8.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00033778 File Offset: 0x00031978
		// (set) Token: 0x06000338 RID: 824 RVA: 0x0003378C File Offset: 0x0003198C
		internal virtual RadioButton RadioButton11
		{
			get
			{
				return this.a9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ag);
				if (this.a9 != null)
				{
					this.a9.MouseClick -= value2;
				}
				this.a9 = value;
				if (this.a9 != null)
				{
					this.a9.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000339 RID: 825 RVA: 0x000337D8 File Offset: 0x000319D8
		// (set) Token: 0x0600033A RID: 826 RVA: 0x000337EC File Offset: 0x000319EC
		internal virtual RadioButton RadioButton12
		{
			get
			{
				return this.ba;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.af);
				if (this.ba != null)
				{
					this.ba.MouseClick -= value2;
				}
				this.ba = value;
				if (this.ba != null)
				{
					this.ba.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00033838 File Offset: 0x00031A38
		// (set) Token: 0x0600033C RID: 828 RVA: 0x0003384C File Offset: 0x00031A4C
		internal virtual Panel Panel6
		{
			get
			{
				return this.bb;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ac);
				if (this.bb != null)
				{
					this.bb.MouseClick -= value2;
				}
				this.bb = value;
				if (this.bb != null)
				{
					this.bb.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00033898 File Offset: 0x00031A98
		// (set) Token: 0x0600033E RID: 830 RVA: 0x000338AC File Offset: 0x00031AAC
		internal virtual Panel Panel7
		{
			get
			{
				return this.bc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.ab);
				if (this.bc != null)
				{
					this.bc.MouseClick -= value2;
				}
				this.bc = value;
				if (this.bc != null)
				{
					this.bc.MouseClick += value2;
				}
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600033F RID: 831 RVA: 0x000338F8 File Offset: 0x00031AF8
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0003390B File Offset: 0x00031B0B
		internal virtual ToolTip ToolTip1
		{
			get
			{
				return this.bd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bd = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00033914 File Offset: 0x00031B14
		// (set) Token: 0x06000342 RID: 834 RVA: 0x00033928 File Offset: 0x00031B28
		internal virtual NotifyIcon NotifyIcon1
		{
			get
			{
				return this.be;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.a);
				if (this.be != null)
				{
					this.be.MouseDoubleClick -= value2;
				}
				this.be = value;
				if (this.be != null)
				{
					this.be.MouseDoubleClick += value2;
				}
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00033974 File Offset: 0x00031B74
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00033987 File Offset: 0x00031B87
		internal virtual ContextMenuStrip ContextMenuStrip1
		{
			get
			{
				return this.bf;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bf = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00033990 File Offset: 0x00031B90
		// (set) Token: 0x06000346 RID: 838 RVA: 0x000339A3 File Offset: 0x00031BA3
		internal virtual ToolStripSeparator ToolStripSeparator1
		{
			get
			{
				return this.bg;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bg = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000347 RID: 839 RVA: 0x000339AC File Offset: 0x00031BAC
		// (set) Token: 0x06000348 RID: 840 RVA: 0x000339C0 File Offset: 0x00031BC0
		internal virtual ToolStripMenuItem ToolStripMenuItem1
		{
			get
			{
				return this.bh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.k);
				if (this.bh != null)
				{
					this.bh.Click -= value2;
				}
				this.bh = value;
				if (this.bh != null)
				{
					this.bh.Click += value2;
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00033A0C File Offset: 0x00031C0C
		// (set) Token: 0x0600034A RID: 842 RVA: 0x00033A20 File Offset: 0x00031C20
		internal virtual ToolStripMenuItem ToolStripMenuItem2
		{
			get
			{
				return this.bi;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.j);
				if (this.bi != null)
				{
					this.bi.Click -= value2;
				}
				this.bi = value;
				if (this.bi != null)
				{
					this.bi.Click += value2;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00033A6C File Offset: 0x00031C6C
		// (set) Token: 0x0600034C RID: 844 RVA: 0x00033A7F File Offset: 0x00031C7F
		internal virtual ComboBox ComboBox1
		{
			get
			{
				return this.bj;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bj = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00033A88 File Offset: 0x00031C88
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00033A9B File Offset: 0x00031C9B
		internal virtual SplitterLabel SplitterLabel5
		{
			get
			{
				return this.bk;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bk = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00033AA4 File Offset: 0x00031CA4
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00033AB7 File Offset: 0x00031CB7
		internal virtual RadioButton RadioButton13
		{
			get
			{
				return this.bl;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bl = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00033AC0 File Offset: 0x00031CC0
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00033AD3 File Offset: 0x00031CD3
		internal virtual ComboBox ComboBox2
		{
			get
			{
				return this.bm;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bm = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00033ADC File Offset: 0x00031CDC
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00033AF0 File Offset: 0x00031CF0
		internal virtual ComboBox ComboBox3
		{
			get
			{
				return this.bn;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.i);
				if (this.bn != null)
				{
					this.bn.SelectedIndexChanged -= value2;
				}
				this.bn = value;
				if (this.bn != null)
				{
					this.bn.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00033B3C File Offset: 0x00031D3C
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00033B4F File Offset: 0x00031D4F
		internal virtual Label Label6
		{
			get
			{
				return this.bo;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bo = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00033B58 File Offset: 0x00031D58
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00033B6C File Offset: 0x00031D6C
		internal virtual NumericUpDown NumericUpDown6
		{
			get
			{
				return this.bp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.n);
				if (this.bp != null)
				{
					this.bp.ValueChanged -= value2;
				}
				this.bp = value;
				if (this.bp != null)
				{
					this.bp.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00033BB8 File Offset: 0x00031DB8
		// (set) Token: 0x0600035A RID: 858 RVA: 0x00033BCB File Offset: 0x00031DCB
		internal virtual Panel Panel8
		{
			get
			{
				return this.bq;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bq = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00033BD4 File Offset: 0x00031DD4
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00033BE7 File Offset: 0x00031DE7
		internal virtual SplitterLabel SplitterLabel6
		{
			get
			{
				return this.br;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.br = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00033BF0 File Offset: 0x00031DF0
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00033C03 File Offset: 0x00031E03
		internal virtual RadioButton RadioButton14
		{
			get
			{
				return this.bs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bs = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00033C0C File Offset: 0x00031E0C
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00033C1F File Offset: 0x00031E1F
		internal virtual CheckBox CheckBox3
		{
			get
			{
				return this.bt;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bt = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00033C28 File Offset: 0x00031E28
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00033C3B File Offset: 0x00031E3B
		internal virtual CheckBox CheckBox4
		{
			get
			{
				return this.bu;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bu = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00033C44 File Offset: 0x00031E44
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00033C57 File Offset: 0x00031E57
		internal virtual FlowLayoutPanel FlowLayoutPanel1
		{
			get
			{
				return this.bv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bv = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00033C60 File Offset: 0x00031E60
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00033C73 File Offset: 0x00031E73
		internal virtual FlowLayoutPanel FlowLayoutPanel2
		{
			get
			{
				return this.bw;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bw = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00033C7C File Offset: 0x00031E7C
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00033C8F File Offset: 0x00031E8F
		internal virtual Panel Panel2
		{
			get
			{
				return this.bx;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.bx = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00033C98 File Offset: 0x00031E98
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00033CAB File Offset: 0x00031EAB
		internal virtual FlowLayoutPanel FlowLayoutPanel3
		{
			get
			{
				return this.by;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.by = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00033CB4 File Offset: 0x00031EB4
		// (set) Token: 0x0600036C RID: 876 RVA: 0x00033CC8 File Offset: 0x00031EC8
		internal virtual DoubleBufferTreeView DoubleBufferTreeView1
		{
			get
			{
				return this.bz;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.x);
				EventHandler value3 = new EventHandler(this.y);
				if (this.bz != null)
				{
					this.bz.MouseClick -= value2;
					this.bz.MouseLeave -= value3;
				}
				this.bz = value;
				if (this.bz != null)
				{
					this.bz.MouseClick += value2;
					this.bz.MouseLeave += value3;
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600036D RID: 877 RVA: 0x00033D38 File Offset: 0x00031F38
		// (set) Token: 0x0600036E RID: 878 RVA: 0x00033D4B File Offset: 0x00031F4B
		internal virtual FlowLayoutPanel FlowLayoutPanel4
		{
			get
			{
				return this.b0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b0 = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600036F RID: 879 RVA: 0x00033D54 File Offset: 0x00031F54
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00033D67 File Offset: 0x00031F67
		internal virtual FlowLayoutPanel FlowLayoutPanel5
		{
			get
			{
				return this.b1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b1 = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000371 RID: 881 RVA: 0x00033D70 File Offset: 0x00031F70
		// (set) Token: 0x06000372 RID: 882 RVA: 0x00033D83 File Offset: 0x00031F83
		internal virtual NumericUpDown NumericUpDown7
		{
			get
			{
				return this.b2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b2 = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00033D8C File Offset: 0x00031F8C
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00033D9F File Offset: 0x00031F9F
		internal virtual RadioButton RadioButton15
		{
			get
			{
				return this.b3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b3 = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000375 RID: 885 RVA: 0x00033DA8 File Offset: 0x00031FA8
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00033DBB File Offset: 0x00031FBB
		internal virtual Label Label7
		{
			get
			{
				return this.b4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b4 = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000377 RID: 887 RVA: 0x00033DC4 File Offset: 0x00031FC4
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00033DD7 File Offset: 0x00031FD7
		internal virtual SplitterLabel SplitterLabel7
		{
			get
			{
				return this.b5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b5 = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00033DE0 File Offset: 0x00031FE0
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00033DF3 File Offset: 0x00031FF3
		internal virtual Panel Panel1
		{
			get
			{
				return this.b6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b6 = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00033DFC File Offset: 0x00031FFC
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00033E0F File Offset: 0x0003200F
		internal virtual Panel Panel3
		{
			get
			{
				return this.b7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b7 = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00033E18 File Offset: 0x00032018
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00033E2C File Offset: 0x0003202C
		internal virtual NumericUpDown NumericUpDown8
		{
			get
			{
				return this.b8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.m);
				if (this.b8 != null)
				{
					this.b8.ValueChanged -= value2;
				}
				this.b8 = value;
				if (this.b8 != null)
				{
					this.b8.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00033E78 File Offset: 0x00032078
		// (set) Token: 0x06000380 RID: 896 RVA: 0x00033E8B File Offset: 0x0003208B
		internal virtual RadioButton RadioButton16
		{
			get
			{
				return this.b9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b9 = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00033E94 File Offset: 0x00032094
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00033EA7 File Offset: 0x000320A7
		internal virtual RadioButton RadioButton17
		{
			get
			{
				return this.ca;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ca = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00033EB0 File Offset: 0x000320B0
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00033EC4 File Offset: 0x000320C4
		internal virtual System.Windows.Forms.Timer Timer1
		{
			get
			{
				return this.cb;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.f);
				if (this.cb != null)
				{
					this.cb.Tick -= value2;
				}
				this.cb = value;
				if (this.cb != null)
				{
					this.cb.Tick += value2;
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00033F10 File Offset: 0x00032110
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00033F24 File Offset: 0x00032124
		internal virtual Button Button7
		{
			get
			{
				return this.cc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.e);
				if (this.cc != null)
				{
					this.cc.Click -= value2;
				}
				this.cc = value;
				if (this.cc != null)
				{
					this.cc.Click += value2;
				}
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00033F70 File Offset: 0x00032170
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00033F83 File Offset: 0x00032183
		internal virtual StatusStrip StatusStrip1
		{
			get
			{
				return this.cd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cd = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00033F8C File Offset: 0x0003218C
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00033F9F File Offset: 0x0003219F
		internal virtual TableLayoutPanel TableLayoutPanel6
		{
			get
			{
				return this.ce;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ce = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00033FA8 File Offset: 0x000321A8
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00033FBB File Offset: 0x000321BB
		internal virtual ToolStripStatusLabel ToolStripStatusLabel1
		{
			get
			{
				return this.cf;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cf = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00033FC4 File Offset: 0x000321C4
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00033FD7 File Offset: 0x000321D7
		internal virtual ToolStripStatusLabel ToolStripStatusLabel2
		{
			get
			{
				return this.cg;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cg = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00033FE0 File Offset: 0x000321E0
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00033FF3 File Offset: 0x000321F3
		internal virtual ToolStripStatusLabel ToolStripStatusLabel3
		{
			get
			{
				return this.ch;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ch = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00033FFC File Offset: 0x000321FC
		// (set) Token: 0x06000392 RID: 914 RVA: 0x0003400F File Offset: 0x0003220F
		internal virtual ToolStripStatusLabel ToolStripStatusLabel4
		{
			get
			{
				return this.ci;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ci = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00034018 File Offset: 0x00032218
		// (set) Token: 0x06000394 RID: 916 RVA: 0x0003402B File Offset: 0x0003222B
		internal virtual ToolStripStatusLabel ToolStripStatusLabel5
		{
			get
			{
				return this.cj;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cj = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00034034 File Offset: 0x00032234
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00034047 File Offset: 0x00032247
		internal virtual CheckBox CheckBox5
		{
			get
			{
				return this.ck;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ck = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00034050 File Offset: 0x00032250
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00034063 File Offset: 0x00032263
		internal virtual FlowLayoutPanel FlowLayoutPanel6
		{
			get
			{
				return this.cl;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cl = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000399 RID: 921 RVA: 0x0003406C File Offset: 0x0003226C
		// (set) Token: 0x0600039A RID: 922 RVA: 0x0003407F File Offset: 0x0003227F
		internal virtual RadioButton RadioButton18
		{
			get
			{
				return this.cm;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cm = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00034088 File Offset: 0x00032288
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0003409B File Offset: 0x0003229B
		internal virtual RadioButton RadioButton19
		{
			get
			{
				return this.cn;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cn = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600039D RID: 925 RVA: 0x000340A4 File Offset: 0x000322A4
		// (set) Token: 0x0600039E RID: 926 RVA: 0x000340B7 File Offset: 0x000322B7
		internal virtual NumericUpDown NumericUpDown9
		{
			get
			{
				return this.co;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.co = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600039F RID: 927 RVA: 0x000340C0 File Offset: 0x000322C0
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x000340D3 File Offset: 0x000322D3
		internal virtual RadioButton RadioButton20
		{
			get
			{
				return this.cp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cp = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x000340DC File Offset: 0x000322DC
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x000340EF File Offset: 0x000322EF
		internal virtual SplitterLabel SplitterLabel8
		{
			get
			{
				return this.cq;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cq = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x000340F8 File Offset: 0x000322F8
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x0003410B File Offset: 0x0003230B
		internal virtual FlowLayoutPanel FlowLayoutPanel7
		{
			get
			{
				return this.cr;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cr = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00034114 File Offset: 0x00032314
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00034127 File Offset: 0x00032327
		internal virtual FlowLayoutPanel FlowLayoutPanel8
		{
			get
			{
				return this.cs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cs = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00034130 File Offset: 0x00032330
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x00034143 File Offset: 0x00032343
		internal virtual RadioButton RadioButton21
		{
			get
			{
				return this.ct;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ct = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0003414C File Offset: 0x0003234C
		// (set) Token: 0x060003AA RID: 938 RVA: 0x0003415F File Offset: 0x0003235F
		internal virtual NumericUpDown NumericUpDown10
		{
			get
			{
				return this.cu;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cu = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00034168 File Offset: 0x00032368
		// (set) Token: 0x060003AC RID: 940 RVA: 0x0003417B File Offset: 0x0003237B
		internal virtual RadioButton RadioButton22
		{
			get
			{
				return this.cv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cv = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060003AD RID: 941 RVA: 0x00034184 File Offset: 0x00032384
		// (set) Token: 0x060003AE RID: 942 RVA: 0x00034197 File Offset: 0x00032397
		internal virtual NumericUpDown NumericUpDown11
		{
			get
			{
				return this.cw;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cw = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000341A0 File Offset: 0x000323A0
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x000341B3 File Offset: 0x000323B3
		internal virtual Label Label8
		{
			get
			{
				return this.cx;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cx = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000341BC File Offset: 0x000323BC
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x000341CF File Offset: 0x000323CF
		internal virtual Panel Panel9
		{
			get
			{
				return this.cy;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.cy = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x000341D8 File Offset: 0x000323D8
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x000341EC File Offset: 0x000323EC
		internal virtual NumericUpDown NumericUpDown12
		{
			get
			{
				return this.cz;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.l);
				if (this.cz != null)
				{
					this.cz.ValueChanged -= value2;
				}
				this.cz = value;
				if (this.cz != null)
				{
					this.cz.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00034238 File Offset: 0x00032438
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x0003424B File Offset: 0x0003244B
		internal virtual RadioButton RadioButton23
		{
			get
			{
				return this.c0;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c0 = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00034254 File Offset: 0x00032454
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00034267 File Offset: 0x00032467
		internal virtual RadioButton RadioButton24
		{
			get
			{
				return this.c1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c1 = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00034270 File Offset: 0x00032470
		// (set) Token: 0x060003BA RID: 954 RVA: 0x00034284 File Offset: 0x00032484
		internal virtual ComboBox ComboBox4
		{
			get
			{
				return this.c2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.d);
				if (this.c2 != null)
				{
					this.c2.SelectedIndexChanged -= value2;
				}
				this.c2 = value;
				if (this.c2 != null)
				{
					this.c2.SelectedIndexChanged += value2;
				}
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060003BB RID: 955 RVA: 0x000342D0 File Offset: 0x000324D0
		// (set) Token: 0x060003BC RID: 956 RVA: 0x000342E4 File Offset: 0x000324E4
		internal virtual NumericUpDown NumericUpDown13
		{
			get
			{
				return this.c3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.c);
				if (this.c3 != null)
				{
					this.c3.ValueChanged -= value2;
				}
				this.c3 = value;
				if (this.c3 != null)
				{
					this.c3.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00034330 File Offset: 0x00032530
		// (set) Token: 0x060003BE RID: 958 RVA: 0x00034343 File Offset: 0x00032543
		internal virtual RadioButton RadioButton7
		{
			get
			{
				return this.c4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c4 = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0003434C File Offset: 0x0003254C
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0003435F File Offset: 0x0003255F
		internal virtual SplitterLabel SplitterLabel9
		{
			get
			{
				return this.c5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c5 = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00034368 File Offset: 0x00032568
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0003437B File Offset: 0x0003257B
		internal virtual CheckBox CheckBox6
		{
			get
			{
				return this.c6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c6 = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00034384 File Offset: 0x00032584
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00034397 File Offset: 0x00032597
		internal virtual FlowLayoutPanel FlowLayoutPanel9
		{
			get
			{
				return this.c7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c7 = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x000343A0 File Offset: 0x000325A0
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x000343B3 File Offset: 0x000325B3
		internal virtual RadioButton RadioButton8
		{
			get
			{
				return this.c8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c8 = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x000343BC File Offset: 0x000325BC
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x000343CF File Offset: 0x000325CF
		internal virtual NumericUpDown NumericUpDown14
		{
			get
			{
				return this.c9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.c9 = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000343D8 File Offset: 0x000325D8
		// (set) Token: 0x060003CA RID: 970 RVA: 0x000343EB File Offset: 0x000325EB
		internal virtual RadioButton RadioButton25
		{
			get
			{
				return this.da;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.da = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003CB RID: 971 RVA: 0x000343F4 File Offset: 0x000325F4
		// (set) Token: 0x060003CC RID: 972 RVA: 0x00034407 File Offset: 0x00032607
		internal virtual NumericUpDown NumericUpDown15
		{
			get
			{
				return this.db;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.db = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00034410 File Offset: 0x00032610
		// (set) Token: 0x060003CE RID: 974 RVA: 0x00034423 File Offset: 0x00032623
		internal virtual RadioButton RadioButton26
		{
			get
			{
				return this.dc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dc = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003CF RID: 975 RVA: 0x0003442C File Offset: 0x0003262C
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00034440 File Offset: 0x00032640
		internal virtual NumericUpDown NumericUpDown16
		{
			get
			{
				return this.dd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.b);
				if (this.dd != null)
				{
					this.dd.ValueChanged -= value2;
				}
				this.dd = value;
				if (this.dd != null)
				{
					this.dd.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0003448C File Offset: 0x0003268C
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x0003449F File Offset: 0x0003269F
		internal virtual Panel Panel10
		{
			get
			{
				return this.de;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.de = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x000344A8 File Offset: 0x000326A8
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x000344BC File Offset: 0x000326BC
		internal virtual NumericUpDown NumericUpDown17
		{
			get
			{
				return this.df;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.a);
				if (this.df != null)
				{
					this.df.ValueChanged -= value2;
				}
				this.df = value;
				if (this.df != null)
				{
					this.df.ValueChanged += value2;
				}
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00034508 File Offset: 0x00032708
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0003451B File Offset: 0x0003271B
		internal virtual RadioButton RadioButton27
		{
			get
			{
				return this.dg;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dg = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00034524 File Offset: 0x00032724
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00034537 File Offset: 0x00032737
		internal virtual RadioButton RadioButton28
		{
			get
			{
				return this.dh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dh = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00034540 File Offset: 0x00032740
		// (set) Token: 0x060003DA RID: 986 RVA: 0x00034553 File Offset: 0x00032753
		internal virtual Label Label9
		{
			get
			{
				return this.di;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.di = value;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0003455C File Offset: 0x0003275C
		private void v(object A_0, EventArgs A_1)
		{
			this.i();
			this.b();
			this.h();
			this.ComboBox1.SelectedIndex = 0;
			this.ComboBox2.SelectedIndex = 0;
			this.ComboBox3.SelectedIndex = 0;
			if (Directory.Exists("lang") && 0 != string.Compare(global::x.ae, "zh-CN", StringComparison.Ordinal))
			{
				this.d();
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000345C4 File Offset: 0x000327C4
		private void u(object A_0, EventArgs A_1)
		{
			this.ListBox1.Items.Clear();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000345D8 File Offset: 0x000327D8
		private void t(object A_0, EventArgs A_1)
		{
			if (this.BackgroundWorker1.IsBusy)
			{
				global::x.a = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				MsgBoxResult msgBoxResult = Interaction.MsgBox(global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_1") + "\r\n" + global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_2"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_3"));
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
				global::x.a = false;
			}
			else if (!this.RadioButton1.Checked && 0 <= this.ListBox1.Items.Count)
			{
				this.GroupBox1.Enabled = false;
				this.CheckBox5.Enabled = false;
				this.Button2.Text = global::x.ad.getMultiLingual("Form1_Thread_Run_Msg");
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

		// Token: 0x060003DE RID: 990 RVA: 0x000347E8 File Offset: 0x000329E8
		private void s(object A_0, EventArgs A_1)
		{
			if (this.BackgroundWorker2.IsBusy)
			{
				global::x.a = true;
				Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.pause2.Handle, "Pause");
				Windows7taskbar.SetWindows7ProgressState(this.Handle, Windows7taskbar.Windows7TaskbarState.PAUSED);
				MsgBoxResult msgBoxResult = Interaction.MsgBox(global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_1") + "\r\n" + global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_2"), MsgBoxStyle.YesNo | MsgBoxStyle.Critical | MsgBoxStyle.Question | MsgBoxStyle.DefaultButton2, global::x.ad.getMultiLingual("Form1_Thread_Canel_Msg_3"));
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
				global::x.a = false;
			}
			else if (this.DoubleBufferTreeView1.SelectedNode != null && 0 < this.DoubleBufferTreeView1.SelectedNode.Level && Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(this.DoubleBufferTreeView1.SelectedNode.Tag)))
			{
				int num = Conversions.ToInteger(this.DoubleBufferTreeView1.SelectedNode.Tag);
				if (0 < num && ((0 < this.ListBox2.Items.Count & 0 < this.ListBox3.Items.Count) | 0 < this.ListBox4.Items.Count))
				{
					this.DoubleBufferTreeView1.Enabled = false;
					this.Panel1.Enabled = false;
					this.Button3.Text = global::x.ad.getMultiLingual("Form1_Thread_Run_Msg");
					Windows7taskbar.SetWindows7OverlayIcon(this.Handle, Resources.play2.Handle, "Go");
					this.Timer1.Start();
					this.BackgroundWorker2.RunWorkerAsync(num);
				}
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000349DA File Offset: 0x00032BDA
		private void r(object A_0, EventArgs A_1)
		{
			this.ListBox2.Items.Clear();
			this.ListBox3.Items.Clear();
			this.ListBox4.Items.Clear();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00034A0C File Offset: 0x00032C0C
		private void q(object A_0, EventArgs A_1)
		{
			this.ListBox2.Items.Clear();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00034A1E File Offset: 0x00032C1E
		private void p(object A_0, EventArgs A_1)
		{
			this.ListBox3.Items.Clear();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00034A30 File Offset: 0x00032C30
		private void o(object A_0, EventArgs A_1)
		{
			this.RadioButton6.Checked = true;
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown5", Conversions.ToString(this.NumericUpDown5.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00034A6F File Offset: 0x00032C6F
		private void n(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown6", Conversions.ToString(this.NumericUpDown6.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00034AA2 File Offset: 0x00032CA2
		private void m(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown8", Conversions.ToString(this.NumericUpDown8.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00034AD5 File Offset: 0x00032CD5
		private void l(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown12", Conversions.ToString(this.NumericUpDown12.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00034B08 File Offset: 0x00032D08
		private void k(object A_0, EventArgs A_1)
		{
			this.Close();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00034B10 File Offset: 0x00032D10
		private void j(object A_0, EventArgs A_1)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
			global::x.SetForegroundWindow(this.Handle);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00034B30 File Offset: 0x00032D30
		private void i(object A_0, EventArgs A_1)
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

		// Token: 0x060003E9 RID: 1001 RVA: 0x00034B67 File Offset: 0x00032D67
		private void a(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Left)
			{
				if (this.WindowState == FormWindowState.Minimized)
				{
					this.WindowState = FormWindowState.Normal;
					global::x.SetForegroundWindow(this.Handle);
				}
				else if (this.WindowState == FormWindowState.Normal)
				{
					this.WindowState = FormWindowState.Minimized;
				}
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00034BA4 File Offset: 0x00032DA4
		private void h(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("p2SaveBitmapFormat", "7");
				global::x.ag.Save();
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00034BCC File Offset: 0x00032DCC
		private void g(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("p2SaveBitmapFormat", "8");
				global::x.ag.Save();
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00034BF4 File Offset: 0x00032DF4
		private void f(object A_0, EventArgs A_1)
		{
			checked
			{
				global::x.p++;
				global::x.q = global::x.p % 60;
				global::x.r = (int)Math.Round(Conversion.Fix((double)(global::x.p % 3600) / 60.0));
				global::x.s = (int)Math.Round(Conversion.Fix((double)(global::x.p % 86400) / 3600.0));
				this.ToolStripStatusLabel5.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", global::x.s, global::x.r, global::x.q);
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00034C99 File Offset: 0x00032E99
		private void e(object A_0, EventArgs A_1)
		{
			global::t.b().l().Show();
			global::t.b().l().WindowState = FormWindowState.Normal;
			global::x.SetForegroundWindow(global::t.b().l().Handle);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00034CD0 File Offset: 0x00032ED0
		private void d(object A_0, EventArgs A_1)
		{
			int selectedIndex = this.ComboBox4.SelectedIndex;
			global::x.u = selectedIndex;
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
				global::x.ag.Update("p2SaveBitmapFormat", Conversions.ToString(selectedIndex));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00034D34 File Offset: 0x00032F34
		private void c(object A_0, EventArgs A_1)
		{
			global::x.v = Convert.ToInt32(this.NumericUpDown13.Value);
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown13", Conversions.ToString(this.NumericUpDown13.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00034D87 File Offset: 0x00032F87
		private void b(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown16", Conversions.ToString(this.NumericUpDown16.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00034DBA File Offset: 0x00032FBA
		private void a(object A_0, EventArgs A_1)
		{
			if (this.IsHandleCreated)
			{
				global::x.ag.Update("iNumUpDown17", Conversions.ToString(this.NumericUpDown17.Value));
				global::x.ag.Save();
			}
		}

		// Token: 0x040002EF RID: 751
		private int a;

		// Token: 0x040002F0 RID: 752
		private int b;

		// Token: 0x040002F1 RID: 753
		private int c;

		// Token: 0x040002F2 RID: 754
		private string[] d;

		// Token: 0x040002F3 RID: 755
		private string e;

		// Token: 0x040002F5 RID: 757
		[AccessedThroughProperty("TabControl1")]
		private TabControl g;

		// Token: 0x040002F6 RID: 758
		[AccessedThroughProperty("TabPage1")]
		private TabPage h;

		// Token: 0x040002F7 RID: 759
		[AccessedThroughProperty("TabPage2")]
		private TabPage i;

		// Token: 0x040002F8 RID: 760
		[AccessedThroughProperty("TabPage3")]
		private TabPage j;

		// Token: 0x040002F9 RID: 761
		[AccessedThroughProperty("TabPage4")]
		private TabPage k;

		// Token: 0x040002FA RID: 762
		[AccessedThroughProperty("TabPage5")]
		private TabPage l;

		// Token: 0x040002FB RID: 763
		[AccessedThroughProperty("ListBox1")]
		private ListBox m;

		// Token: 0x040002FC RID: 764
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox n;

		// Token: 0x040002FD RID: 765
		[AccessedThroughProperty("Button2")]
		private Button o;

		// Token: 0x040002FE RID: 766
		[AccessedThroughProperty("Button1")]
		private Button p;

		// Token: 0x040002FF RID: 767
		[AccessedThroughProperty("BackgroundWorker1")]
		private BackgroundWorker q;

		// Token: 0x04000300 RID: 768
		[AccessedThroughProperty("RadioButton1")]
		private RadioButton r;

		// Token: 0x04000301 RID: 769
		[AccessedThroughProperty("RadioButton2")]
		private RadioButton s;

		// Token: 0x04000302 RID: 770
		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown t;

		// Token: 0x04000303 RID: 771
		[AccessedThroughProperty("Label4")]
		private Label u;

		// Token: 0x04000304 RID: 772
		[AccessedThroughProperty("Label3")]
		private Label v;

		// Token: 0x04000305 RID: 773
		[AccessedThroughProperty("Label2")]
		private Label w;

		// Token: 0x04000306 RID: 774
		[AccessedThroughProperty("Label1")]
		private Label x;

		// Token: 0x04000307 RID: 775
		[AccessedThroughProperty("RadioButton3")]
		private RadioButton y;

		// Token: 0x04000308 RID: 776
		[AccessedThroughProperty("NumericUpDown2")]
		private NumericUpDown z;

		// Token: 0x04000309 RID: 777
		[AccessedThroughProperty("NumericUpDown4")]
		private NumericUpDown aa;

		// Token: 0x0400030A RID: 778
		[AccessedThroughProperty("NumericUpDown3")]
		private NumericUpDown ab;

		// Token: 0x0400030B RID: 779
		[AccessedThroughProperty("TextBox1")]
		private TextBox ac;

		// Token: 0x0400030C RID: 780
		[AccessedThroughProperty("SplitterLabel2")]
		private SplitterLabel ad;

		// Token: 0x0400030D RID: 781
		[AccessedThroughProperty("SplitterLabel3")]
		private SplitterLabel ae;

		// Token: 0x0400030E RID: 782
		[AccessedThroughProperty("RadioButton4")]
		private RadioButton af;

		// Token: 0x0400030F RID: 783
		[AccessedThroughProperty("NumericUpDown5")]
		private NumericUpDown ag;

		// Token: 0x04000310 RID: 784
		[AccessedThroughProperty("RadioButton6")]
		private RadioButton ah;

		// Token: 0x04000311 RID: 785
		[AccessedThroughProperty("RadioButton5")]
		private RadioButton ai;

		// Token: 0x04000312 RID: 786
		[AccessedThroughProperty("SplitterLabel4")]
		private SplitterLabel aj;

		// Token: 0x04000313 RID: 787
		[AccessedThroughProperty("CheckBox1")]
		private CheckBox ak;

		// Token: 0x04000314 RID: 788
		[AccessedThroughProperty("Button3")]
		private Button al;

		// Token: 0x04000315 RID: 789
		[AccessedThroughProperty("BackgroundWorker2")]
		private BackgroundWorker am;

		// Token: 0x04000316 RID: 790
		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel an;

		// Token: 0x04000317 RID: 791
		[AccessedThroughProperty("TableLayoutPanel2")]
		private TableLayoutPanel ao;

		// Token: 0x04000318 RID: 792
		[AccessedThroughProperty("TableLayoutPanel3")]
		private TableLayoutPanel ap;

		// Token: 0x04000319 RID: 793
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox aq;

		// Token: 0x0400031A RID: 794
		[AccessedThroughProperty("GroupBox3")]
		private GroupBox ar;

		// Token: 0x0400031B RID: 795
		[AccessedThroughProperty("TableLayoutPanel4")]
		private TableLayoutPanel @as;

		// Token: 0x0400031C RID: 796
		[AccessedThroughProperty("ListBox2")]
		private ListBox at;

		// Token: 0x0400031D RID: 797
		[AccessedThroughProperty("ListBox3")]
		private ListBox au;

		// Token: 0x0400031E RID: 798
		[AccessedThroughProperty("SplitterLabel1")]
		private SplitterLabel av;

		// Token: 0x0400031F RID: 799
		[AccessedThroughProperty("ListBox4")]
		private ListBox aw;

		// Token: 0x04000320 RID: 800
		[AccessedThroughProperty("TableLayoutPanel5")]
		private TableLayoutPanel ax;

		// Token: 0x04000321 RID: 801
		[AccessedThroughProperty("Label5")]
		private Label ay;

		// Token: 0x04000322 RID: 802
		[AccessedThroughProperty("CheckBox2")]
		private CheckBox az;

		// Token: 0x04000323 RID: 803
		[AccessedThroughProperty("TableLayoutPanel7")]
		private TableLayoutPanel a0;

		// Token: 0x04000324 RID: 804
		[AccessedThroughProperty("Button4")]
		private Button a1;

		// Token: 0x04000325 RID: 805
		[AccessedThroughProperty("Button5")]
		private Button a2;

		// Token: 0x04000326 RID: 806
		[AccessedThroughProperty("Button6")]
		private Button a3;

		// Token: 0x04000327 RID: 807
		[AccessedThroughProperty("ColorDialog1")]
		private ColorDialog a4;

		// Token: 0x04000328 RID: 808
		[AccessedThroughProperty("RadioButton9")]
		private RadioButton a5;

		// Token: 0x04000329 RID: 809
		[AccessedThroughProperty("Panel4")]
		private Panel a6;

		// Token: 0x0400032A RID: 810
		[AccessedThroughProperty("RadioButton10")]
		private RadioButton a7;

		// Token: 0x0400032B RID: 811
		[AccessedThroughProperty("Panel5")]
		private Panel a8;

		// Token: 0x0400032C RID: 812
		[AccessedThroughProperty("RadioButton11")]
		private RadioButton a9;

		// Token: 0x0400032D RID: 813
		[AccessedThroughProperty("RadioButton12")]
		private RadioButton ba;

		// Token: 0x0400032E RID: 814
		[AccessedThroughProperty("Panel6")]
		private Panel bb;

		// Token: 0x0400032F RID: 815
		[AccessedThroughProperty("Panel7")]
		private Panel bc;

		// Token: 0x04000330 RID: 816
		[AccessedThroughProperty("ToolTip1")]
		private ToolTip bd;

		// Token: 0x04000331 RID: 817
		[AccessedThroughProperty("NotifyIcon1")]
		private NotifyIcon be;

		// Token: 0x04000332 RID: 818
		[AccessedThroughProperty("ContextMenuStrip1")]
		private ContextMenuStrip bf;

		// Token: 0x04000333 RID: 819
		[AccessedThroughProperty("ToolStripSeparator1")]
		private ToolStripSeparator bg;

		// Token: 0x04000334 RID: 820
		[AccessedThroughProperty("ToolStripMenuItem1")]
		private ToolStripMenuItem bh;

		// Token: 0x04000335 RID: 821
		[AccessedThroughProperty("ToolStripMenuItem2")]
		private ToolStripMenuItem bi;

		// Token: 0x04000336 RID: 822
		[AccessedThroughProperty("ComboBox1")]
		private ComboBox bj;

		// Token: 0x04000337 RID: 823
		[AccessedThroughProperty("SplitterLabel5")]
		private SplitterLabel bk;

		// Token: 0x04000338 RID: 824
		[AccessedThroughProperty("RadioButton13")]
		private RadioButton bl;

		// Token: 0x04000339 RID: 825
		[AccessedThroughProperty("ComboBox2")]
		private ComboBox bm;

		// Token: 0x0400033A RID: 826
		[AccessedThroughProperty("ComboBox3")]
		private ComboBox bn;

		// Token: 0x0400033B RID: 827
		[AccessedThroughProperty("Label6")]
		private Label bo;

		// Token: 0x0400033C RID: 828
		[AccessedThroughProperty("NumericUpDown6")]
		private NumericUpDown bp;

		// Token: 0x0400033D RID: 829
		[AccessedThroughProperty("Panel8")]
		private Panel bq;

		// Token: 0x0400033E RID: 830
		[AccessedThroughProperty("SplitterLabel6")]
		private SplitterLabel br;

		// Token: 0x0400033F RID: 831
		[AccessedThroughProperty("RadioButton14")]
		private RadioButton bs;

		// Token: 0x04000340 RID: 832
		[AccessedThroughProperty("CheckBox3")]
		private CheckBox bt;

		// Token: 0x04000341 RID: 833
		[AccessedThroughProperty("CheckBox4")]
		private CheckBox bu;

		// Token: 0x04000342 RID: 834
		[AccessedThroughProperty("FlowLayoutPanel1")]
		private FlowLayoutPanel bv;

		// Token: 0x04000343 RID: 835
		[AccessedThroughProperty("FlowLayoutPanel2")]
		private FlowLayoutPanel bw;

		// Token: 0x04000344 RID: 836
		[AccessedThroughProperty("Panel2")]
		private Panel bx;

		// Token: 0x04000345 RID: 837
		[AccessedThroughProperty("FlowLayoutPanel3")]
		private FlowLayoutPanel by;

		// Token: 0x04000346 RID: 838
		[AccessedThroughProperty("DoubleBufferTreeView1")]
		private DoubleBufferTreeView bz;

		// Token: 0x04000347 RID: 839
		[AccessedThroughProperty("FlowLayoutPanel4")]
		private FlowLayoutPanel b0;

		// Token: 0x04000348 RID: 840
		[AccessedThroughProperty("FlowLayoutPanel5")]
		private FlowLayoutPanel b1;

		// Token: 0x04000349 RID: 841
		[AccessedThroughProperty("NumericUpDown7")]
		private NumericUpDown b2;

		// Token: 0x0400034A RID: 842
		[AccessedThroughProperty("RadioButton15")]
		private RadioButton b3;

		// Token: 0x0400034B RID: 843
		[AccessedThroughProperty("Label7")]
		private Label b4;

		// Token: 0x0400034C RID: 844
		[AccessedThroughProperty("SplitterLabel7")]
		private SplitterLabel b5;

		// Token: 0x0400034D RID: 845
		[AccessedThroughProperty("Panel1")]
		private Panel b6;

		// Token: 0x0400034E RID: 846
		[AccessedThroughProperty("Panel3")]
		private Panel b7;

		// Token: 0x0400034F RID: 847
		[AccessedThroughProperty("NumericUpDown8")]
		private NumericUpDown b8;

		// Token: 0x04000350 RID: 848
		[AccessedThroughProperty("RadioButton16")]
		private RadioButton b9;

		// Token: 0x04000351 RID: 849
		[AccessedThroughProperty("RadioButton17")]
		private RadioButton ca;

		// Token: 0x04000352 RID: 850
		[AccessedThroughProperty("Timer1")]
		private System.Windows.Forms.Timer cb;

		// Token: 0x04000353 RID: 851
		[AccessedThroughProperty("Button7")]
		private Button cc;

		// Token: 0x04000354 RID: 852
		[AccessedThroughProperty("StatusStrip1")]
		private StatusStrip cd;

		// Token: 0x04000355 RID: 853
		[AccessedThroughProperty("TableLayoutPanel6")]
		private TableLayoutPanel ce;

		// Token: 0x04000356 RID: 854
		[AccessedThroughProperty("ToolStripStatusLabel1")]
		private ToolStripStatusLabel cf;

		// Token: 0x04000357 RID: 855
		[AccessedThroughProperty("ToolStripStatusLabel2")]
		private ToolStripStatusLabel cg;

		// Token: 0x04000358 RID: 856
		[AccessedThroughProperty("ToolStripStatusLabel3")]
		private ToolStripStatusLabel ch;

		// Token: 0x04000359 RID: 857
		[AccessedThroughProperty("ToolStripStatusLabel4")]
		private ToolStripStatusLabel ci;

		// Token: 0x0400035A RID: 858
		[AccessedThroughProperty("ToolStripStatusLabel5")]
		private ToolStripStatusLabel cj;

		// Token: 0x0400035B RID: 859
		[AccessedThroughProperty("CheckBox5")]
		private CheckBox ck;

		// Token: 0x0400035C RID: 860
		[AccessedThroughProperty("FlowLayoutPanel6")]
		private FlowLayoutPanel cl;

		// Token: 0x0400035D RID: 861
		[AccessedThroughProperty("RadioButton18")]
		private RadioButton cm;

		// Token: 0x0400035E RID: 862
		[AccessedThroughProperty("RadioButton19")]
		private RadioButton cn;

		// Token: 0x0400035F RID: 863
		[AccessedThroughProperty("NumericUpDown9")]
		private NumericUpDown co;

		// Token: 0x04000360 RID: 864
		[AccessedThroughProperty("RadioButton20")]
		private RadioButton cp;

		// Token: 0x04000361 RID: 865
		[AccessedThroughProperty("SplitterLabel8")]
		private SplitterLabel cq;

		// Token: 0x04000362 RID: 866
		[AccessedThroughProperty("FlowLayoutPanel7")]
		private FlowLayoutPanel cr;

		// Token: 0x04000363 RID: 867
		[AccessedThroughProperty("FlowLayoutPanel8")]
		private FlowLayoutPanel cs;

		// Token: 0x04000364 RID: 868
		[AccessedThroughProperty("RadioButton21")]
		private RadioButton ct;

		// Token: 0x04000365 RID: 869
		[AccessedThroughProperty("NumericUpDown10")]
		private NumericUpDown cu;

		// Token: 0x04000366 RID: 870
		[AccessedThroughProperty("RadioButton22")]
		private RadioButton cv;

		// Token: 0x04000367 RID: 871
		[AccessedThroughProperty("NumericUpDown11")]
		private NumericUpDown cw;

		// Token: 0x04000368 RID: 872
		[AccessedThroughProperty("Label8")]
		private Label cx;

		// Token: 0x04000369 RID: 873
		[AccessedThroughProperty("Panel9")]
		private Panel cy;

		// Token: 0x0400036A RID: 874
		[AccessedThroughProperty("NumericUpDown12")]
		private NumericUpDown cz;

		// Token: 0x0400036B RID: 875
		[AccessedThroughProperty("RadioButton23")]
		private RadioButton c0;

		// Token: 0x0400036C RID: 876
		[AccessedThroughProperty("RadioButton24")]
		private RadioButton c1;

		// Token: 0x0400036D RID: 877
		[AccessedThroughProperty("ComboBox4")]
		private ComboBox c2;

		// Token: 0x0400036E RID: 878
		[AccessedThroughProperty("NumericUpDown13")]
		private NumericUpDown c3;

		// Token: 0x0400036F RID: 879
		[AccessedThroughProperty("RadioButton7")]
		private RadioButton c4;

		// Token: 0x04000370 RID: 880
		[AccessedThroughProperty("SplitterLabel9")]
		private SplitterLabel c5;

		// Token: 0x04000371 RID: 881
		[AccessedThroughProperty("CheckBox6")]
		private CheckBox c6;

		// Token: 0x04000372 RID: 882
		[AccessedThroughProperty("FlowLayoutPanel9")]
		private FlowLayoutPanel c7;

		// Token: 0x04000373 RID: 883
		[AccessedThroughProperty("RadioButton8")]
		private RadioButton c8;

		// Token: 0x04000374 RID: 884
		[AccessedThroughProperty("NumericUpDown14")]
		private NumericUpDown c9;

		// Token: 0x04000375 RID: 885
		[AccessedThroughProperty("RadioButton25")]
		private RadioButton da;

		// Token: 0x04000376 RID: 886
		[AccessedThroughProperty("NumericUpDown15")]
		private NumericUpDown db;

		// Token: 0x04000377 RID: 887
		[AccessedThroughProperty("RadioButton26")]
		private RadioButton dc;

		// Token: 0x04000378 RID: 888
		[AccessedThroughProperty("NumericUpDown16")]
		private NumericUpDown dd;

		// Token: 0x04000379 RID: 889
		[AccessedThroughProperty("Panel10")]
		private Panel de;

		// Token: 0x0400037A RID: 890
		[AccessedThroughProperty("NumericUpDown17")]
		private NumericUpDown df;

		// Token: 0x0400037B RID: 891
		[AccessedThroughProperty("RadioButton27")]
		private RadioButton dg;

		// Token: 0x0400037C RID: 892
		[AccessedThroughProperty("RadioButton28")]
		private RadioButton dh;

		// Token: 0x0400037D RID: 893
		[AccessedThroughProperty("Label9")]
		private Label di;

		// Token: 0x020000C8 RID: 200
		public enum MergeOptionType
		{
			// Token: 0x0400037F RID: 895
			none = -1,
			// Token: 0x04000380 RID: 896
			one_100 = 100,
			// Token: 0x04000381 RID: 897
			one_101,
			// Token: 0x04000382 RID: 898
			one_102,
			// Token: 0x04000383 RID: 899
			one_103,
			// Token: 0x04000384 RID: 900
			one_104,
			// Token: 0x04000385 RID: 901
			one_105,
			// Token: 0x04000386 RID: 902
			one_106,
			// Token: 0x04000387 RID: 903
			one_107,
			// Token: 0x04000388 RID: 904
			one_108,
			// Token: 0x04000389 RID: 905
			one_109,
			// Token: 0x0400038A RID: 906
			one_110,
			// Token: 0x0400038B RID: 907
			one_111,
			// Token: 0x0400038C RID: 908
			one_112,
			// Token: 0x0400038D RID: 909
			one_113,
			// Token: 0x0400038E RID: 910
			one_114,
			// Token: 0x0400038F RID: 911
			one_115,
			// Token: 0x04000390 RID: 912
			one_116,
			// Token: 0x04000391 RID: 913
			one_117,
			// Token: 0x04000392 RID: 914
			one_118,
			// Token: 0x04000393 RID: 915
			one_119,
			// Token: 0x04000394 RID: 916
			one_120,
			// Token: 0x04000395 RID: 917
			one_121,
			// Token: 0x04000396 RID: 918
			one_122,
			// Token: 0x04000397 RID: 919
			two_200 = 200,
			// Token: 0x04000398 RID: 920
			two_201,
			// Token: 0x04000399 RID: 921
			two_202,
			// Token: 0x0400039A RID: 922
			two_203,
			// Token: 0x0400039B RID: 923
			two_204,
			// Token: 0x0400039C RID: 924
			three_300 = 300,
			// Token: 0x0400039D RID: 925
			three_301,
			// Token: 0x0400039E RID: 926
			three_302,
			// Token: 0x0400039F RID: 927
			three_303,
			// Token: 0x040003A0 RID: 928
			three_304,
			// Token: 0x040003A1 RID: 929
			three_305,
			// Token: 0x040003A2 RID: 930
			three_306,
			// Token: 0x040003A3 RID: 931
			three_307,
			// Token: 0x040003A4 RID: 932
			three_308,
			// Token: 0x040003A5 RID: 933
			three_309,
			// Token: 0x040003A6 RID: 934
			three_310,
			// Token: 0x040003A7 RID: 935
			three_311,
			// Token: 0x040003A8 RID: 936
			three_312,
			// Token: 0x040003A9 RID: 937
			three_313,
			// Token: 0x040003AA RID: 938
			three_314,
			// Token: 0x040003AB RID: 939
			three_315,
			// Token: 0x040003AC RID: 940
			three_316,
			// Token: 0x040003AD RID: 941
			three_317,
			// Token: 0x040003AE RID: 942
			four_400 = 400,
			// Token: 0x040003AF RID: 943
			four_401,
			// Token: 0x040003B0 RID: 944
			four_402,
			// Token: 0x040003B1 RID: 945
			four_403,
			// Token: 0x040003B2 RID: 946
			four_404,
			// Token: 0x040003B3 RID: 947
			four_405,
			// Token: 0x040003B4 RID: 948
			four_406,
			// Token: 0x040003B5 RID: 949
			four_407,
			// Token: 0x040003B6 RID: 950
			four_408,
			// Token: 0x040003B7 RID: 951
			four_409,
			// Token: 0x040003B8 RID: 952
			four_410,
			// Token: 0x040003B9 RID: 953
			four_411,
			// Token: 0x040003BA RID: 954
			four_412,
			// Token: 0x040003BB RID: 955
			five_500 = 500,
			// Token: 0x040003BC RID: 956
			five_501,
			// Token: 0x040003BD RID: 957
			five_502,
			// Token: 0x040003BE RID: 958
			five_503,
			// Token: 0x040003BF RID: 959
			six_600 = 600
		}
	}
}
