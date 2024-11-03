using System;
using System.Runtime.InteropServices;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x0200000B RID: 11
	[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface ITaskbarList3
	{
		// Token: 0x06000013 RID: 19
		[PreserveSig]
		void HrInit();

		// Token: 0x06000014 RID: 20
		[PreserveSig]
		void AddTab(IntPtr hwnd);

		// Token: 0x06000015 RID: 21
		[PreserveSig]
		void DeleteTab(IntPtr hwnd);

		// Token: 0x06000016 RID: 22
		[PreserveSig]
		void ActivateTab(IntPtr hwnd);

		// Token: 0x06000017 RID: 23
		[PreserveSig]
		void SetActiveAlt(IntPtr hwnd);

		// Token: 0x06000018 RID: 24
		[PreserveSig]
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// Token: 0x06000019 RID: 25
		void SetProgressValue([In] IntPtr hwnd, [In] ulong ullCompleted, [In] ulong ullTotal);

		// Token: 0x0600001A RID: 26
		void SetProgressState([In] IntPtr hwnd, [In] TBPFLAG tbpFlags);

		// Token: 0x0600001B RID: 27
		void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

		// Token: 0x0600001C RID: 28
		void UnregisterTab(IntPtr hwndTab);

		// Token: 0x0600001D RID: 29
		void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

		// Token: 0x0600001E RID: 30
		void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, TBATFLAG tbatFlags);

		// Token: 0x0600001F RID: 31
		void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

		// Token: 0x06000020 RID: 32
		void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);

		// Token: 0x06000021 RID: 33
		void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

		// Token: 0x06000022 RID: 34
		void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		// Token: 0x06000023 RID: 35
		void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

		// Token: 0x06000024 RID: 36
		void SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);
	}
}
