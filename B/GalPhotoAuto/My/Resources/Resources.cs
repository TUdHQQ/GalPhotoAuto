using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.My.Resources
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[HideModuleName]
	[CompilerGenerated]
	[StandardModule]
	[DebuggerNonUserCode]
	internal sealed class Resources
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000021E8 File Offset: 0x000003E8
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("GalPhotoAuto.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002228 File Offset: 0x00000428
		// (set) Token: 0x0600000B RID: 11 RVA: 0x0000223A File Offset: 0x0000043A
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002244 File Offset: 0x00000444
		internal static Icon _stop
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("_stop", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002274 File Offset: 0x00000474
		internal static Icon _stop2
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("_stop2", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000022A4 File Offset: 0x000004A4
		internal static Icon pause
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("pause", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022D4 File Offset: 0x000004D4
		internal static Icon pause2
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("pause2", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002304 File Offset: 0x00000504
		internal static Icon play
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("play", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002334 File Offset: 0x00000534
		internal static Icon play2
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("play2", Resources.resourceCulture));
				return (Icon)objectValue;
			}
		}

		// Token: 0x04000003 RID: 3
		private static ResourceManager resourceMan;

		// Token: 0x04000004 RID: 4
		private static CultureInfo resourceCulture;
	}
}
