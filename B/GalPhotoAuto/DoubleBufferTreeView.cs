using System;
using System.Windows.Forms;

namespace GalPhotoAuto
{
	// Token: 0x020000BA RID: 186
	public class DoubleBufferTreeView : TreeView
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00024DA9 File Offset: 0x00022FA9
		public DoubleBufferTreeView()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
		}
	}
}
