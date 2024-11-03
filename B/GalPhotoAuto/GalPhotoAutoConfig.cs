using System;
using System.Configuration;

namespace GalPhotoAuto
{
	// Token: 0x020000BC RID: 188
	public class GalPhotoAutoConfig
	{
		// Token: 0x06000239 RID: 569 RVA: 0x00025378 File Offset: 0x00023578
		public GalPhotoAutoConfig()
		{
			this.conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0002538C File Offset: 0x0002358C
		public void Save()
		{
			this.conf.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000253A4 File Offset: 0x000235A4
		public string getValue(string sKey)
		{
			if (this.checkKey(sKey))
			{
				return this.conf.AppSettings.Settings[sKey].Value;
			}
			return string.Empty;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000253DB File Offset: 0x000235DB
		public void Add(string sKey, string sValue)
		{
			this.conf.AppSettings.Settings.Add(sKey, sValue);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000253F4 File Offset: 0x000235F4
		public void Remove(string sKey)
		{
			this.conf.AppSettings.Settings.Remove(sKey);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0002540C File Offset: 0x0002360C
		public void Update(string sKey, string sValue)
		{
			if (this.checkKey(sKey))
			{
				this.conf.AppSettings.Settings[sKey].Value = sValue;
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00025434 File Offset: 0x00023634
		public bool checkKey(string sKey)
		{
			bool result = false;
			string[] allKeys = this.conf.AppSettings.Settings.AllKeys;
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

		// Token: 0x04000290 RID: 656
		private Configuration conf;
	}
}
