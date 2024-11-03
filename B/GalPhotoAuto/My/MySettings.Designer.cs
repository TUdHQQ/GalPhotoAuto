using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.My
{
	// Token: 0x020000DF RID: 223
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	[CompilerGenerated]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x06000474 RID: 1140 RVA: 0x000391F1 File Offset: 0x000373F1
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		private static void AutoSaveSettings(object sender, EventArgs e)
		{
			if (MyProject.get_Application().SaveMySettingsOnExit)
			{
				MySettingsProperty.get_Settings().Save();
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0003920C File Offset: 0x0003740C
		public static MySettings Default
		{
			get
			{
				if (!MySettings.addedHandler)
				{
					object obj = MySettings.addedHandlerLockObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						if (!MySettings.addedHandler)
						{
							MyProject.get_Application().Shutdown += MySettings.AutoSaveSettings;
							MySettings.addedHandler = true;
						}
					}
				}
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x0400044C RID: 1100
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());

		// Token: 0x0400044D RID: 1101
		private static bool addedHandler;

		// Token: 0x0400044E RID: 1102
		private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());
	}
}
