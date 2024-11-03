using System;

namespace GalPhotoAuto.Windows7DesktopIntegration
{
	// Token: 0x020000D8 RID: 216
	public struct RECT
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x000391DF File Offset: 0x000373DF
		public RECT(int left, int top, int right, int bottom)
		{
			this = default(RECT);
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		// Token: 0x0400042F RID: 1071
		public int left;

		// Token: 0x04000430 RID: 1072
		public int top;

		// Token: 0x04000431 RID: 1073
		public int right;

		// Token: 0x04000432 RID: 1074
		public int bottom;
	}
}
