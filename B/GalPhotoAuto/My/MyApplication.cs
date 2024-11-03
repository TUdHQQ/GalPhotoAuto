using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

namespace GalPhotoAuto.My
{
	// Token: 0x02000003 RID: 3
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal class MyApplication : WindowsFormsApplicationBase
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
		[DebuggerHidden]
		[STAThread]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		internal static void Main(string[] Args)
		{
			try
			{
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
			}
			finally
			{
			}
			MyProject.get_Application().Run(Args);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D4 File Offset: 0x000002D4
		private void MyApplication_Startup(object sender, StartupEventArgs e)
		{
			AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GalPhotoAuto.exe.Config"));
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (1 < commandLineArgs.Length && 0 == string.Compare(commandLineArgs[1], "/showcurr", StringComparison.Ordinal))
			{
				Interaction.MsgBox(CultureInfo.CurrentCulture.ToString(), MsgBoxStyle.OkOnly, null);
				Environment.Exit(-1);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000213C File Offset: 0x0000033C
		private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(e.Exception.Message + "\r\n\r\n是 继续运行程序，否 马上关闭程序。", MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "意外情况？Ctrl + C 可以复制该信息！");
			if (msgBoxResult == MsgBoxResult.No)
			{
				MyProject.get_Forms().get_Form1().Close();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002180 File Offset: 0x00000380
		[DebuggerStepThrough]
		public MyApplication() : base(AuthenticationMode.Windows)
		{
			base.Startup += this.MyApplication_Startup;
			base.UnhandledException += this.MyApplication_UnhandledException;
			this.IsSingleInstance = true;
			this.EnableVisualStyles = true;
			this.SaveMySettingsOnExit = true;
			this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021D6 File Offset: 0x000003D6
		[DebuggerStepThrough]
		protected override void OnCreateMainForm()
		{
			this.MainForm = MyProject.get_Forms().get_Form1();
		}
	}
}
