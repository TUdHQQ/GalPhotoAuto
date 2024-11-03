using System;
using System.Runtime.CompilerServices;
using GalPhotoAuto.Windows7DesktopIntegration;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C2 RID: 194
	public class Windows7taskbar
	{
		// Token: 0x06000284 RID: 644 RVA: 0x00027A84 File Offset: 0x00025C84
		public static void Initialization()
		{
			if (!Windows7taskbar.c && Environment.OSVersion.Version >= new Version(6, 1))
			{
				try
				{
					if (Windows7taskbar.b == null)
					{
						object obj = Windows7taskbar.a;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							Windows7taskbar.b = (ITaskbarList3)new CTaskbarList();
						}
						Windows7taskbar.c = true;
					}
				}
				catch (Exception ex)
				{
					Windows7taskbar.c = false;
					x.c(ex.Message);
				}
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00027B2C File Offset: 0x00025D2C
		public static void SetWindows7Progress(IntPtr hwnd, int iNow, int iMax)
		{
			checked
			{
				if (Windows7taskbar.c)
				{
					Windows7taskbar.b.SetProgressValue(hwnd, (ulong)iNow, (ulong)iMax);
				}
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00027B44 File Offset: 0x00025D44
		public static void ResetWindows7Progress(IntPtr hwnd)
		{
			if (Windows7taskbar.c)
			{
				Windows7taskbar.b.SetProgressState(hwnd, TBPFLAG.TBPF_NOPROGRESS);
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00027B59 File Offset: 0x00025D59
		public static void SetWindows7ProgressState(IntPtr hwnd, Windows7taskbar.Windows7TaskbarState state)
		{
			if (Windows7taskbar.c)
			{
				Windows7taskbar.b.SetProgressState(hwnd, (TBPFLAG)state);
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00027B6E File Offset: 0x00025D6E
		public static void AddWindows7ThumbBarButtons(IntPtr hwnd, int itbL, THUMBBUTTON[] tb)
		{
			if (Windows7taskbar.c)
			{
				Windows7taskbar.b.ThumbBarAddButtons(hwnd, checked((uint)itbL), tb);
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00027B85 File Offset: 0x00025D85
		public static void UpdateWindows7ThumbBarButtons(IntPtr hwnd, int itbL, THUMBBUTTON[] tb)
		{
			if (Windows7taskbar.c)
			{
				Windows7taskbar.b.ThumbBarUpdateButtons(hwnd, checked((uint)itbL), tb);
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00027B9C File Offset: 0x00025D9C
		public static void SetWindows7OverlayIcon(IntPtr hwnd, IntPtr icon, string sText)
		{
			if (Windows7taskbar.c)
			{
				Windows7taskbar.b.SetOverlayIcon(hwnd, icon, sText);
			}
		}

		// Token: 0x040002D4 RID: 724
		private static readonly object a = RuntimeHelpers.GetObjectValue(new object());

		// Token: 0x040002D5 RID: 725
		private static ITaskbarList3 b;

		// Token: 0x040002D6 RID: 726
		private static bool c = false;

		// Token: 0x020000C3 RID: 195
		public enum Windows7TaskbarState
		{
			// Token: 0x040002D8 RID: 728
			NOPROGRESS,
			// Token: 0x040002D9 RID: 729
			INDETERMINATE,
			// Token: 0x040002DA RID: 730
			NORMAL,
			// Token: 0x040002DB RID: 731
			ERROR = 4,
			// Token: 0x040002DC RID: 732
			PAUSED = 8
		}
	}
}
