using System;
using System.Runtime.InteropServices;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x020000DE RID: 222
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
	[ComImport]
	public interface ITaskbarList3
	{
		// Token: 0x06000460 RID: 1120
		[PreserveSig]
		void HrInit();

		// Token: 0x06000461 RID: 1121
		[PreserveSig]
		void AddTab(IntPtr hwnd);

		// Token: 0x06000462 RID: 1122
		[PreserveSig]
		void DeleteTab(IntPtr hwnd);

		// Token: 0x06000463 RID: 1123
		[PreserveSig]
		void ActivateTab(IntPtr hwnd);

		// Token: 0x06000464 RID: 1124
		[PreserveSig]
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x06000465 RID: 1125
		[PreserveSig]
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// Token: 0x06000466 RID: 1126
		void SetProgressValue([In] IntPtr hwnd, [In] ulong ullCompleted, [In] ulong ullTotal);

		// Token: 0x06000467 RID: 1127
		void SetProgressState([In] IntPtr hwnd, [In] TBPFLAG tbpFlags);

		// Token: 0x06000468 RID: 1128
		void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

		// Token: 0x06000469 RID: 1129
		void UnregisterTab(IntPtr hwndTab);

		// Token: 0x0600046A RID: 1130
		void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

		// Token: 0x0600046B RID: 1131
		void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, TBATFLAG tbatFlags);

		// Token: 0x0600046C RID: 1132
		void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

		// Token: 0x0600046D RID: 1133
		void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

		// Token: 0x0600046E RID: 1134
		void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

		// Token: 0x0600046F RID: 1135
		void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		// Token: 0x06000470 RID: 1136
		void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

		// Token: 0x06000471 RID: 1137
		void SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);
	}
}
