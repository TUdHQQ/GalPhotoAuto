using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto.My
{
	// Token: 0x020000DB RID: 219
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x06000453 RID: 1107 RVA: 0x00038D74 File Offset: 0x00036F74
		[DebuggerHidden]
		internal static MyComputer get_Computer()
		{
			return MyProject.m_ComputerObjectProvider.get_GetInstance();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00038D8C File Offset: 0x00036F8C
		[DebuggerHidden]
		internal static MyApplication get_Application()
		{
			return MyProject.m_AppObjectProvider.get_GetInstance();
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00038DA4 File Offset: 0x00036FA4
		[DebuggerHidden]
		internal static User get_User()
		{
			return MyProject.m_UserObjectProvider.get_GetInstance();
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00038DBC File Offset: 0x00036FBC
		[DebuggerHidden]
		internal static MyProject.MyForms get_Forms()
		{
			return MyProject.m_MyFormsObjectProvider.get_GetInstance();
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00038DD4 File Offset: 0x00036FD4
		[DebuggerHidden]
		internal static MyProject.MyWebServices get_WebServices()
		{
			return MyProject.m_MyWebServicesObjectProvider.get_GetInstance();
		}

		// Token: 0x04000440 RID: 1088
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000441 RID: 1089
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000442 RID: 1090
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x04000443 RID: 1091
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000444 RID: 1092
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x020000DC RID: 220
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class MyForms
		{
			// Token: 0x06000458 RID: 1112 RVA: 0x00038DEC File Offset: 0x00036FEC
			public AboutBox1 get_AboutBox1()
			{
				this.m_AboutBox1 = MyProject.MyForms.Create__Instance__<AboutBox1>(this.m_AboutBox1);
				return this.m_AboutBox1;
			}

			// Token: 0x06000459 RID: 1113 RVA: 0x00038E10 File Offset: 0x00037010
			public CaptureForms get_CaptureForms()
			{
				this.m_CaptureForms = MyProject.MyForms.Create__Instance__<CaptureForms>(this.m_CaptureForms);
				return this.m_CaptureForms;
			}

			// Token: 0x0600045A RID: 1114 RVA: 0x00038E34 File Offset: 0x00037034
			public Form1 get_Form1()
			{
				this.m_Form1 = MyProject.MyForms.Create__Instance__<Form1>(this.m_Form1);
				return this.m_Form1;
			}

			// Token: 0x0600045B RID: 1115 RVA: 0x00038E58 File Offset: 0x00037058
			public Form2 get_Form2()
			{
				this.m_Form2 = MyProject.MyForms.Create__Instance__<Form2>(this.m_Form2);
				return this.m_Form2;
			}

			// Token: 0x0600045C RID: 1116 RVA: 0x00038E7C File Offset: 0x0003707C
			public Form3 get_Form3()
			{
				this.m_Form3 = MyProject.MyForms.Create__Instance__<Form3>(this.m_Form3);
				return this.m_Form3;
			}

			// Token: 0x0600045D RID: 1117 RVA: 0x00038EA0 File Offset: 0x000370A0
			public void set_AboutBox1(AboutBox1 Value)
			{
				if (Value == this.m_AboutBox1)
				{
					return;
				}
				if (Value != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				this.Dispose__Instance__<AboutBox1>(ref this.m_AboutBox1);
			}

			// Token: 0x0600045E RID: 1118 RVA: 0x00038EC6 File Offset: 0x000370C6
			public void set_CaptureForms(CaptureForms Value)
			{
				if (Value == this.m_CaptureForms)
				{
					return;
				}
				if (Value != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				this.Dispose__Instance__<CaptureForms>(ref this.m_CaptureForms);
			}

			// Token: 0x0600045F RID: 1119 RVA: 0x00038EEC File Offset: 0x000370EC
			public void set_Form1(Form1 Value)
			{
				if (Value == this.m_Form1)
				{
					return;
				}
				if (Value != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				this.Dispose__Instance__<Form1>(ref this.m_Form1);
			}

			// Token: 0x06000460 RID: 1120 RVA: 0x00038F12 File Offset: 0x00037112
			public void set_Form2(Form2 Value)
			{
				if (Value == this.m_Form2)
				{
					return;
				}
				if (Value != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				this.Dispose__Instance__<Form2>(ref this.m_Form2);
			}

			// Token: 0x06000461 RID: 1121 RVA: 0x00038F38 File Offset: 0x00037138
			public void set_Form3(Form3 Value)
			{
				if (Value == this.m_Form3)
				{
					return;
				}
				if (Value != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				this.Dispose__Instance__<Form3>(ref this.m_Form3);
			}

			// Token: 0x06000462 RID: 1122 RVA: 0x00038F60 File Offset: 0x00037160
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				if (Instance == null || Instance.IsDisposed)
				{
					if (MyProject.MyForms.m_FormBeingCreated != null)
					{
						if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return Activator.CreateInstance<T>();
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
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
					return Instance;
				}
				return Instance;
			}

			// Token: 0x06000463 RID: 1123 RVA: 0x0003906C File Offset: 0x0003726C
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x06000464 RID: 1124 RVA: 0x00039094 File Offset: 0x00037294
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			// Token: 0x06000465 RID: 1125 RVA: 0x0003909C File Offset: 0x0003729C
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x06000466 RID: 1126 RVA: 0x000390B8 File Offset: 0x000372B8
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000467 RID: 1127 RVA: 0x000390CC File Offset: 0x000372CC
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x06000468 RID: 1128 RVA: 0x000390E4 File Offset: 0x000372E4
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x04000445 RID: 1093
			public AboutBox1 m_AboutBox1;

			// Token: 0x04000446 RID: 1094
			public CaptureForms m_CaptureForms;

			// Token: 0x04000447 RID: 1095
			public Form1 m_Form1;

			// Token: 0x04000448 RID: 1096
			public Form2 m_Form2;

			// Token: 0x04000449 RID: 1097
			public Form3 m_Form3;

			// Token: 0x0400044A RID: 1098
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;
		}

		// Token: 0x020000DD RID: 221
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class MyWebServices
		{
			// Token: 0x06000469 RID: 1129 RVA: 0x000390F8 File Offset: 0x000372F8
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x0600046A RID: 1130 RVA: 0x00039114 File Offset: 0x00037314
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0600046B RID: 1131 RVA: 0x00039128 File Offset: 0x00037328
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x0600046C RID: 1132 RVA: 0x00039140 File Offset: 0x00037340
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x0600046D RID: 1133 RVA: 0x00039154 File Offset: 0x00037354
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				if (instance == null)
				{
					return Activator.CreateInstance<T>();
				}
				return instance;
			}

			// Token: 0x0600046E RID: 1134 RVA: 0x00039170 File Offset: 0x00037370
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x0600046F RID: 1135 RVA: 0x0003918C File Offset: 0x0003738C
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x020000DE RID: 222
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x06000470 RID: 1136 RVA: 0x00039194 File Offset: 0x00037394
			[DebuggerHidden]
			internal T get_GetInstance()
			{
				if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
				{
					MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
				}
				return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
			}

			// Token: 0x06000471 RID: 1137 RVA: 0x000391BC File Offset: 0x000373BC
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x0400044B RID: 1099
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
