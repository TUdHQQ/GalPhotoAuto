using System;
using System.Configuration;

namespace GalPhotoAuto
{
	// Token: 0x020000BF RID: 191
	public class GalPhotoAutoConfig
	{
		// Token: 0x06000272 RID: 626 RVA: 0x00026928 File Offset: 0x00024B28
		public GalPhotoAutoConfig()
		{
			this.a = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0002693C File Offset: 0x00024B3C
		public void Save()
		{
			this.a.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00026954 File Offset: 0x00024B54
		public string getValue(string sKey)
		{
			if (this.checkKey(sKey))
			{
				return this.a.AppSettings.Settings[sKey].Value;
			}
			return string.Empty;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0002698B File Offset: 0x00024B8B
		public void Add(string sKey, string sValue)
		{
			this.a.AppSettings.Settings.Add(sKey, sValue);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000269A4 File Offset: 0x00024BA4
		public void Remove(string sKey)
		{
			this.a.AppSettings.Settings.Remove(sKey);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000269BC File Offset: 0x00024BBC
		public void Update(string sKey, string sValue)
		{
			if (this.checkKey(sKey))
			{
				this.a.AppSettings.Settings[sKey].Value = sValue;
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000269E4 File Offset: 0x00024BE4
		public bool checkKey(string sKey)
		{
			bool result = false;
			string[] allKeys = this.a.AppSettings.Settings.AllKeys;
			foreach (string strA in allKeys)
			{
				if (0 == string.Compare(strA, sKey, StringComparison.Ordinal))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x040002CE RID: 718
		private Configuration a;
	}
}
