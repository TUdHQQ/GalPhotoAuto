﻿using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace GalPhotoAuto
{
	// Token: 0x020000D5 RID: 213
	public class kirikiri2_compare_group_layer_id_v2 : IComparer
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x000369CC File Offset: 0x00034BCC
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