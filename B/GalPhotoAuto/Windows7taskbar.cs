using System;
using System.Runtime.CompilerServices;
using GalPhotoAuto.Windows7DesktopIntegration;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C4 RID: 196
	public class Windows7taskbar
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00027580 File Offset: 0x00025780
		public static void Initialization()
		{
			if (!Windows7taskbar.bInitialize && Environment.OSVersion.Version >= new Version(6, 1))
			{
				try
				{
					if (Windows7taskbar.w7tb == null)
					{
						object obj = Windows7taskbar.syncLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(obj);
						lock (obj)
						{
							Windows7taskbar.w7tb = (ITaskbarList3)new CTaskbarList();
						}
						Windows7taskbar.bInitialize = true;
					}
				}
				catch (Exception ex)
				{
					Windows7taskbar.bInitialize = false;
					PublicModule.addLog(ex.Message);
				}
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00027628 File Offset: 0x00025828
		public static void SetWindows7Progress(IntPtr hwnd, int iNow, int iMax)
		{
			checked
			{
				if (Windows7taskbar.bInitialize)
				{
					Windows7taskbar.w7tb.SetProgressValue(hwnd, (ulong)iNow, (ulong)iMax);
				}
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00027640 File Offset: 0x00025840
		public static void ResetWindows7Progress(IntPtr hwnd)
		{
			if (Windows7taskbar.bInitialize)
			{
				Windows7taskbar.w7tb.SetProgressState(hwnd, TBPFLAG.TBPF_NOPROGRESS);
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00027655 File Offset: 0x00025855
		public static void SetWindows7ProgressState(IntPtr hwnd, Windows7taskbar.Windows7TaskbarState state)
		{
			if (Windows7taskbar.bInitialize)
			{
				Windows7taskbar.w7tb.SetProgressState(hwnd, (TBPFLAG)state);
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0002766A File Offset: 0x0002586A
		public static void AddWindows7ThumbBarButtons(IntPtr hwnd, int itbL, THUMBBUTTON[] tb)
		{
			if (Windows7taskbar.bInitialize)
			{
				Windows7taskbar.w7tb.ThumbBarAddButtons(hwnd, checked((uint)itbL), tb);
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00027681 File Offset: 0x00025881
		public static void UpdateWindows7ThumbBarButtons(IntPtr hwnd, int itbL, THUMBBUTTON[] tb)
		{
			if (Windows7taskbar.bInitialize)
			{
				Windows7taskbar.w7tb.ThumbBarUpdateButtons(hwnd, checked((uint)itbL), tb);
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00027698 File Offset: 0x00025898
		public static void SetWindows7OverlayIcon(IntPtr hwnd, IntPtr icon, string sText)
		{
			if (Windows7taskbar.bInitialize)
			{
				Windows7taskbar.w7tb.SetOverlayIcon(hwnd, icon, sText);
			}
		}

		// Token: 0x040002E5 RID: 741
		private static readonly object syncLock = RuntimeHelpers.GetObjectValue(new object());

		// Token: 0x040002E6 RID: 742
		private static ITaskbarList3 w7tb;

		// Token: 0x040002E7 RID: 743
		private static bool bInitialize = false;

		// Token: 0x020000C5 RID: 197
		public enum Windows7TaskbarState
		{
			// Token: 0x040002E9 RID: 745
			NOPROGRESS,
			// Token: 0x040002EA RID: 746
			INDETERMINATE,
			// Token: 0x040002EB RID: 747
			NORMAL,
			// Token: 0x040002EC RID: 748
			ERROR = 4,
			// Token: 0x040002ED RID: 749
			PAUSED = 8
		}
	}
}
