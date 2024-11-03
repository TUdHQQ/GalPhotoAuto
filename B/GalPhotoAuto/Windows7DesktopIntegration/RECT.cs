using System;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x02000005 RID: 5
	public struct RECT
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002361 File Offset: 0x00000561
		public RECT(int left, int top, int right, int bottom)
		{
			this = default(RECT);
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		// Token: 0x04000005 RID: 5
		public int left;

		// Token: 0x04000006 RID: 6
		public int top;

		// Token: 0x04000007 RID: 7
		public int right;

		// Token: 0x04000008 RID: 8
		public int bottom;
	}
}
