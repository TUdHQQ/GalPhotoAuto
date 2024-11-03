using System;
using System.Runtime.InteropServices;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x020000DD RID: 221
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct THUMBBUTTON
	{
		// Token: 0x04000447 RID: 1095
		[MarshalAs(UnmanagedType.U4)]
		public THBMASK dwMask;

		// Token: 0x04000448 RID: 1096
		public uint iId;

		// Token: 0x04000449 RID: 1097
		public uint iBitmap;

		// Token: 0x0400044A RID: 1098
		public IntPtr hIcon;

		// Token: 0x0400044B RID: 1099
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szTip;

		// Token: 0x0400044C RID: 1100
		[MarshalAs(UnmanagedType.U4)]
		public THBFLAGS dwFlags;
	}
}
