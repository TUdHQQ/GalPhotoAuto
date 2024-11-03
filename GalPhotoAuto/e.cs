using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

// Token: 0x02000003 RID: 3
[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal class e : WindowsFormsApplicationBase
{
	// Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
	[DebuggerHidden]
	[STAThread]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	internal static void a(string[] A_0)
	{
		try
		{
			Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
		}
		finally
		{
		}
		t.d().Run(A_0);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000020D4 File Offset: 0x000002D4
	private void a(object A_0, StartupEventArgs A_1)
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (1 < commandLineArgs.Length && 0 == string.Compare(commandLineArgs[1], "/showcurr", StringComparison.Ordinal))
		{
			Interaction.MsgBox(CultureInfo.CurrentCulture.ToString(), MsgBoxStyle.OkOnly, null);
			Environment.Exit(-1);
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002118 File Offset: 0x00000318
	private void a(object A_0, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs A_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(A_1.Exception.Message + "\r\n\r\n是 继续运行程序，否 马上关闭程序。", MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "意外情况？Ctrl + C 可以复制该信息！");
		if (msgBoxResult == MsgBoxResult.No)
		{
			t.b().n().Close();
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000215C File Offset: 0x0000035C
	[DebuggerStepThrough]
	public e() : base(AuthenticationMode.Windows)
	{
		base.Startup += this.a;
		base.UnhandledException += this.a;
		this.IsSingleInstance = true;
		this.EnableVisualStyles = true;
		this.SaveMySettingsOnExit = true;
		this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000021B2 File Offset: 0x000003B2
	[DebuggerStepThrough]
	protected override void OnCreateMainForm()
	{
		this.MainForm = t.b().n();
	}
}
