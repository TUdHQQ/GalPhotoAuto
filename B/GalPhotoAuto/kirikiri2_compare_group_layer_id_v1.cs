using System;
using System.Collections;
using Microsoft.VisualBasic;

namespace GalPhotoAuto
{
	// Token: 0x020000D4 RID: 212
	public class kirikiri2_compare_group_layer_id_v1 : IComparer
	{
		// Token: 0x060003FE RID: 1022 RVA: 0x000368FC File Offset: 0x00034AFC
		public int Compare(object x, object y)
		{
			string[] array = (string[])x;
			string[] array2 = (string[])y;
			if (string.IsNullOrWhiteSpace(array[8]) & !string.IsNullOrWhiteSpace(array2[8]))
			{
				return 1;
			}
			if (!string.IsNullOrWhiteSpace(array[8]) & string.IsNullOrWhiteSpace(array2[8]))
			{
				return -1;
			}
			if (Strings.InStr(1, array[7], "$", CompareMethod.Binary) > 1 & Strings.InStr(1, array2[7], "$", CompareMethod.Binary) > 1)
			{
				return 0;
			}
			if (Strings.InStr(1, array[7], "$", CompareMethod.Binary) > 1 & Strings.InStr(1, array2[7], "$", CompareMethod.Binary) < 1)
			{
				return 2;
			}
			if (Strings.InStr(1, array[7], "$", CompareMethod.Binary) < 1 & Strings.InStr(1, array2[7], "$", CompareMethod.Binary) > 1)
			{
				return -2;
			}
			return 0;
		}
	}
}
