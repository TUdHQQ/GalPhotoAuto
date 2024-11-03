using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GalPhotoAuto;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x02000098 RID: 152
[HideModuleName]
[StandardModule]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class t
{
	// Token: 0x060001A4 RID: 420 RVA: 0x000233C8 File Offset: 0x000215C8
	[DebuggerHidden]
	internal static global::a e()
	{
		return t.a.a();
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x000233E0 File Offset: 0x000215E0
	[DebuggerHidden]
	internal static e d()
	{
		return t.b.a();
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x000233F8 File Offset: 0x000215F8
	[DebuggerHidden]
	internal static User c()
	{
		return t.c.a();
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00023410 File Offset: 0x00021610
	[DebuggerHidden]
	internal static t.c b()
	{
		return t.d.a();
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00023428 File Offset: 0x00021628
	[DebuggerHidden]
	internal static t.a a()
	{
		return t.e.a();
	}

	// Token: 0x04000260 RID: 608
	private static readonly t<global::a>.b a = new t<global::a>.b();

	// Token: 0x04000261 RID: 609
	private static readonly t<e>.b b = new t<e>.b();

	// Token: 0x04000262 RID: 610
	private static readonly t<User>.b c = new t<User>.b();

	// Token: 0x04000263 RID: 611
	private static t<t.c>.b d = new t<t.c>.b();

	// Token: 0x04000264 RID: 612
	private static readonly t<t.a>.b e = new t<t.a>.b();

	// Token: 0x02000099 RID: 153
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class c
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x00023440 File Offset: 0x00021640
		public AboutBox1 p()
		{
			this.a = t.c.k<AboutBox1>(this.a);
			return this.a;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00023464 File Offset: 0x00021664
		public CaptureForms o()
		{
			this.b = t.c.k<CaptureForms>(this.b);
			return this.b;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00023488 File Offset: 0x00021688
		public Form1 n()
		{
			this.c = t.c.k<Form1>(this.c);
			return this.c;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000234AC File Offset: 0x000216AC
		public Form2 k()
		{
			this.d = t.c.k<Form2>(this.d);
			return this.d;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000234D0 File Offset: 0x000216D0
		public Form3 l()
		{
			this.e = t.c.k<Form3>(this.e);
			return this.e;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000234F4 File Offset: 0x000216F4
		public void k(AboutBox1 A_0)
		{
			if (A_0 == this.a)
			{
				return;
			}
			if (A_0 != null)
			{
				throw new ArgumentException("Property can only be set to Nothing");
			}
			this.k<AboutBox1>(ref this.a);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0002351A File Offset: 0x0002171A
		public void k(CaptureForms A_0)
		{
			if (A_0 == this.b)
			{
				return;
			}
			if (A_0 != null)
			{
				throw new ArgumentException("Property can only be set to Nothing");
			}
			this.k<CaptureForms>(ref this.b);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00023540 File Offset: 0x00021740
		public void k(Form1 A_0)
		{
			if (A_0 == this.c)
			{
				return;
			}
			if (A_0 != null)
			{
				throw new ArgumentException("Property can only be set to Nothing");
			}
			this.k<Form1>(ref this.c);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00023566 File Offset: 0x00021766
		public void k(Form2 A_0)
		{
			if (A_0 == this.d)
			{
				return;
			}
			if (A_0 != null)
			{
				throw new ArgumentException("Property can only be set to Nothing");
			}
			this.k<Form2>(ref this.d);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0002358C File Offset: 0x0002178C
		public void k(Form3 A_0)
		{
			if (A_0 == this.e)
			{
				return;
			}
			if (A_0 != null)
			{
				throw new ArgumentException("Property can only be set to Nothing");
			}
			this.k<Form3>(ref this.e);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000235B4 File Offset: 0x000217B4
		[DebuggerHidden]
		private static a k<a>(a A_0) where a : Form, new()
		{
			if (A_0 == null || A_0.IsDisposed)
			{
				if (t.c.f != null)
				{
					if (t.c.f.ContainsKey(typeof(a)))
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
				}
				else
				{
					t.c.f = new Hashtable();
				}
				t.c.f.Add(typeof(a), null);
				try
				{
					return Activator.CreateInstance<a>();
				}
				catch (TargetInvocationException ex) when (ex.InnerException != null)
				{
					string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[]
					{
						ex.InnerException.Message
					});
					throw new InvalidOperationException(resourceString, ex.InnerException);
				}
				finally
				{
					t.c.f.Remove(typeof(a));
				}
				return A_0;
			}
			return A_0;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000236C0 File Offset: 0x000218C0
		[DebuggerHidden]
		private void k<a>(ref a A_0) where a : Form
		{
			A_0.Dispose();
			A_0 = default(a);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000236E8 File Offset: 0x000218E8
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public c()
		{
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000236F0 File Offset: 0x000218F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0002370C File Offset: 0x0002190C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00023720 File Offset: 0x00021920
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type m()
		{
			return typeof(t.c);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00023738 File Offset: 0x00021938
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		// Token: 0x04000265 RID: 613
		public AboutBox1 a;

		// Token: 0x04000266 RID: 614
		public CaptureForms b;

		// Token: 0x04000267 RID: 615
		public Form1 c;

		// Token: 0x04000268 RID: 616
		public Form2 d;

		// Token: 0x04000269 RID: 617
		public Form3 e;

		// Token: 0x0400026A RID: 618
		[ThreadStatic]
		private static Hashtable f;
	}

	// Token: 0x0200009A RID: 154
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class a
	{
		// Token: 0x060001BA RID: 442 RVA: 0x0002374C File Offset: 0x0002194C
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00023768 File Offset: 0x00021968
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0002377C File Offset: 0x0002197C
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type a()
		{
			return typeof(t.a);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00023794 File Offset: 0x00021994
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000237A8 File Offset: 0x000219A8
		[DebuggerHidden]
		private static a a<a>(a A_0) where a : new()
		{
			if (A_0 == null)
			{
				return Activator.CreateInstance<a>();
			}
			return A_0;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000237C4 File Offset: 0x000219C4
		[DebuggerHidden]
		private void a<a>(ref a A_0)
		{
			A_0 = default(a);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000237E0 File Offset: 0x000219E0
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public a()
		{
		}
	}

	// Token: 0x0200009B RID: 155
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class b<a> where a : new()
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x000237E8 File Offset: 0x000219E8
		[DebuggerHidden]
		internal a a()
		{
			if (t<a>.b.a == null)
			{
				t<a>.b.a = Activator.CreateInstance<a>();
			}
			return t<a>.b.a;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00023810 File Offset: 0x00021A10
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public b()
		{
		}

		// Token: 0x0400026B RID: 619
		[CompilerGenerated]
		[ThreadStatic]
		private static a a;
	}
}
