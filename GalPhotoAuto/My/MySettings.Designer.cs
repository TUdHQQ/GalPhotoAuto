using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.My
{
	// Token: 0x020000E0 RID: 224
	[CompilerGenerated]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00039232 File Offset: 0x00037432
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DebuggerNonUserCode]
		private static void a(object A_0, EventArgs A_1)
		{
			if (t.d().SaveMySettingsOnExit)
			{
				m.a().Save();
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0003924C File Offset: 0x0003744C
		public static MySettings Default
		{
			get
			{
				if (!MySettings.b)
				{
					object obj = MySettings.c;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						if (!MySettings.b)
						{
							t.d().Shutdown += MySettings.a;
							MySettings.b = true;
						}
					}
				}
				return MySettings.a;
			}
		}

		// Token: 0x0400044D RID: 1101
		private static MySettings a = (MySettings)SettingsBase.Synchronized(new MySettings());

		// Token: 0x0400044E RID: 1102
		private static bool b;

		// Token: 0x0400044F RID: 1103
		private static object c = RuntimeHelpers.GetObjectValue(new object());
	}
}
