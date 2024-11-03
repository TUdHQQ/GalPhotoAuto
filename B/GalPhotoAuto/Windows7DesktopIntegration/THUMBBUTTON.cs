using System;
using System.Runtime.InteropServices;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x0200000A RID: 10
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct THUMBBUTTON
	{
		// Token: 0x0400001D RID: 29
		[MarshalAs(UnmanagedType.U4)]
		public THBMASK dwMask;

		// Token: 0x0400001E RID: 30
		public uint iId;

		// Token: 0x0400001F RID: 31
		public uint iBitmap;

		// Token: 0x04000020 RID: 32
		public IntPtr hIcon;

		// Token: 0x04000021 RID: 33
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szTip;

		// Token: 0x04000022 RID: 34
		[MarshalAs(UnmanagedType.U4)]
		public THBFLAGS dwFlags;
	}
}
