using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000C3 RID: 195
	[DesignerGenerated]
	public class SplitterLabel : UserControl
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0002741A File Offset: 0x0002561A
		public SplitterLabel()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00027428 File Offset: 0x00025628
		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00027468 File Offset: 0x00025668
		[DebuggerStepThrough]
		private void InitializeComponent()
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
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00027544 File Offset: 0x00025744
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00027557 File Offset: 0x00025757
		internal virtual Label Label1
		{
			get
			{
				return this._Label1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		// Token: 0x040002E3 RID: 739
		private IContainer components;

		// Token: 0x040002E4 RID: 740
		[AccessedThroughProperty("Label1")]
		private Label _Label1;
	}
}
