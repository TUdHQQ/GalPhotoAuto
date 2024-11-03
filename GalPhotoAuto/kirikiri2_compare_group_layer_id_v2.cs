using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D3 RID: 211
	public class kirikiri2_compare_group_layer_id_v2 : IComparer
	{
		// Token: 0x0600040E RID: 1038 RVA: 0x00036E74 File Offset: 0x00035074
		public int Compare(object x, object y)
		{
			kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt2;
			kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt = (x != null) ? ((kirikiri2_fun.kirikiri2DefTxt)x) : kirikiri2DefTxt2;
			kirikiri2_fun.kirikiri2DefTxt kirikiri2DefTxt3 = (y != null) ? ((kirikiri2_fun.kirikiri2DefTxt)y) : kirikiri2DefTxt2;
			int num = Conversions.ToInteger(kirikiri2DefTxt.layer_id);
			int num2 = Conversions.ToInteger(kirikiri2DefTxt3.layer_id);
			if (num > num2)
			{
				return 1;
			}
			return -1;
		}
	}
}
