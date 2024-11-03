using System;
using System.Windows.Forms;

namespace GalPhotoAuto
{
	// Token: 0x020000BD RID: 189
	public class DoubleBufferTreeView : TreeView
	{
		// Token: 0x06000264 RID: 612 RVA: 0x00026359 File Offset: 0x00024559
		public DoubleBufferTreeView()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			this.UpdateStyles();
		}
	}
}
