using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C1 RID: 193
	[DesignerGenerated]
	public class SplitterLabel : UserControl
	{
		// Token: 0x0600027D RID: 637 RVA: 0x0002791C File Offset: 0x00025B1C
		public SplitterLabel()
		{
			this.a();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0002792C File Offset: 0x00025B2C
		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.a != null)
				{
					this.a.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0002796C File Offset: 0x00025B6C
		[DebuggerStepThrough]
		private void a()
		{
			this.Label1 = new Label();
			this.SuspendLayout();
			this.Label1.BorderStyle = BorderStyle.Fixed3D;
			this.Label1.Dock = DockStyle.Top;
			Control label = this.Label1;
			Point location = new Point(0, 0);
			label.Location = location;
			Control label2 = this.Label1;
			Padding margin = new Padding(0);
			label2.Margin = margin;
			this.Label1.Name = "Label1";
			Control label3 = this.Label1;
			Size size = new Size(528, 2);
			label3.Size = size;
			this.Label1.TabIndex = 0;
			this.Controls.Add(this.Label1);
			this.DoubleBuffered = true;
			this.ImeMode = ImeMode.Off;
			this.Name = "SplitterLabel";
			size = new Size(528, 20);
			this.Size = size;
			this.ResumeLayout(false);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00027A48 File Offset: 0x00025C48
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00027A5B File Offset: 0x00025C5B
		internal virtual Label Label1
		{
			get
			{
				return this.b;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.b = value;
			}
		}

		// Token: 0x040002D2 RID: 722
		private IContainer a;

		// Token: 0x040002D3 RID: 723
		[AccessedThroughProperty("Label1")]
		private Label b;
	}
}
