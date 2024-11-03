using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using GalPhotoAuto.My;

namespace GalPhotoAuto
{
	// Token: 0x020000BD RID: 189
	public class MultipleLanguages
	{
		// Token: 0x06000240 RID: 576 RVA: 0x00025485 File Offset: 0x00023685
		public MultipleLanguages(string xmlpath = "")
		{
			this.bChsLang = true;
			this.CHSLang = new Dictionary<string, string>();
			this.CurrLang = new Dictionary<string, string>();
			this.makeChs();
			this.setMultiLingual(xmlpath);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000254B8 File Offset: 0x000236B8
		private void makeChs()
		{
			this.CHSLang.Add("GUI_Form1_Text", "GAL图片自动处理器");
			this.CHSLang.Add("GUI_TabPage1_Text", "（1）添加处理图片");
			this.CHSLang.Add("GUI_Button1_Text", "清 空");
			this.CHSLang.Add("GUI_TabPage2_Text", "（1）选择处理方式");
			this.CHSLang.Add("GUI_RadioButton1_Text", "无");
			this.CHSLang.Add("GUI_RadioButton2_Text", "将某种颜色设为透明");
			this.CHSLang.Add("GUI_RadioButton9_Text", "紫色");
			this.CHSLang.Add("GUI_RadioButton10_Text", "绿色");
			this.CHSLang.Add("GUI_RadioButton11_Text", "自定");
			this.CHSLang.Add("GUI_RadioButton12_Text", "截屏");
			this.CHSLang.Add("GUI_RadioButton3_Text", "截取图片");
			this.CHSLang.Add("GUI_Label1_Text", "起点X:");
			this.CHSLang.Add("GUI_Label2_Text", "起点Y:");
			this.CHSLang.Add("GUI_Label3_Text", "截取宽度:");
			this.CHSLang.Add("GUI_Label4_Text", "截取高度:");
			this.CHSLang.Add("GUI_RadioButton4_Text", "扫描32位图片的ALPHA是否全黑或全白，是就转为24位图片");
			this.CHSLang.Add("GUI_RadioButton13_Text", "格式转换  将");
			this.CHSLang.Add("GUI_Label6_Text", "转为");
			this.CHSLang.Add("GUI_RadioButton14_Text", "扫描32位图片，根据图片ALPHA的黑色值，计算并取出图片有用范围");
			this.CHSLang.Add("GUI_Button2_Text", "执 行");
			this.CHSLang.Add("GUI_GroupBox1_Text", "处理方式");
			this.CHSLang.Add("GUI_ComboBox1_Text", "全 部");
			this.CHSLang.Add("GUI_ComboBox2_Text", "选择格式");
			this.CHSLang.Add("GUI_ComboBox3_Text", "选择格式");
			this.CHSLang.Add("CaptureForms_Label_Text_1", "鼠标左键取色");
			this.CHSLang.Add("CaptureForms_Label_Text_2", "按任意键取消");
			this.CHSLang.Add("GUI_RadioButton15_Text", "横向剪裁");
			this.CHSLang.Add("GUI_RadioButton18_Text", "定义宽度");
			this.CHSLang.Add("GUI_RadioButton19_Text", "定义数量");
			this.CHSLang.Add("GUI_Label7_Text", "，保存为");
			this.CHSLang.Add("GUI_RadioButton20_Text", "竖向剪裁");
			this.CHSLang.Add("GUI_RadioButton21_Text", "定义高度");
			this.CHSLang.Add("GUI_RadioButton22_Text", "定义数量");
			this.CHSLang.Add("GUI_Label8_Text", "，保存为");
			this.CHSLang.Add("GUI_CheckBox5_Text", "删除源图");
			this.CHSLang.Add("GUI_TabPage5_Text", "（2）添加处理图片");
			this.CHSLang.Add("GUI_GroupBox2_Text", "模式一（分别手动添加文件，左底 右面）");
			this.CHSLang.Add("GUI_CheckBox3_Text", "左边一次性");
			this.CHSLang.Add("GUI_Button5_Text", "左边清空");
			this.CHSLang.Add("GUI_Button4_Text", "全部清空");
			this.CHSLang.Add("GUI_Button6_Text", "右边清空");
			this.CHSLang.Add("GUI_CheckBox4_Text", "右边一次性");
			this.CHSLang.Add("GUI_GroupBox3_Text", "模式二（添加文件夹）");
			this.CHSLang.Add("GUI_TabPage4_Text", "（2）选择合成规则");
			this.CHSLang.Add("GUI_Label5_Text", "保存格式：");
			this.CHSLang.Add("GUI_CheckBox2_Text", "不移入0_YouCanDel");
			this.CHSLang.Add("GUI_Button3_Text", "执 行");
			this.CHSLang.Add("GUI_Button7_Text", "特别设定");
			this.CHSLang.Add("GUI_TabPage3_Text", " 日 志 ");
			this.CHSLang.Add("GUI_CheckBox6_Text", "ALPHA黑白反色");
			this.CHSLang.Add("GUI_RadioButton7_Text", "缩放图片");
			this.CHSLang.Add("GUI_RadioButton8_Text", "宽度为准");
			this.CHSLang.Add("GUI_RadioButton25_Text", "高度为准");
			this.CHSLang.Add("GUI_RadioButton26_Text", "百份比");
			this.CHSLang.Add("GUI_Label9_Text", "保存为");
			this.CHSLang.Add("MENU_CpuProcessor_Text", "使用CPU核心数");
			this.CHSLang.Add("MENU_About_Text", "关于");
			this.CHSLang.Add("MENU_ToolStripMenuItem1_Text", "关闭程序");
			this.CHSLang.Add("MENU_ToolStripMenuItem2_Text", "返回程序");
			this.CHSLang.Add("Form1_Thread_Canel_Msg_1", "是否要取消当前转换操作？");
			this.CHSLang.Add("Form1_Thread_Canel_Msg_2", "按 是 取消执行，按 否 继续操作。");
			this.CHSLang.Add("Form1_Thread_Canel_Msg_3", "取消继续操作？");
			this.CHSLang.Add("Form1_Thread_Run_Msg", "准备中");
			this.CHSLang.Add("Form1_Thread_End_Msg_1", "张图片处理完毕。");
			this.CHSLang.Add("Form1_Thread_End_Msg_2", "执行完毕");
			this.CHSLang.Add("Form1_Thread_Mkdir_Msg", "建立文件夹：");
			this.CHSLang.Add("Form1_ListBox_23_Not_Conform_Msg", "（2）合成: 模式一：左右都没有符合的图片！");
			this.CHSLang.Add("Form1_ListBox_4_Not_Conform_Msg", "（2）合成: 模式二：没有符合的图片！");
			this.CHSLang.Add("Form1_Check_Close_Msg_1", "发现有工作线程正在运行，真的要关闭程序？");
			this.CHSLang.Add("Form1_Check_Close_Msg_2", "关闭程序？");
			this.CHSLang.Add("Form3_GUI_GroupBox1_Text", "定义起点 X，Y 坐标 / X，Y 偏移量");
			this.CHSLang.Add("Form3_GUI_Label4_Text", "起点 X，Y：");
			this.CHSLang.Add("Form3_GUI_Label5_Text", "偏移 X，Y：");
			this.CHSLang.Add("Form3_GUI_GroupBox2_Text", "针对个别游戏");
			this.CHSLang.Add("Form3_GUI_Label3_Text", "游戏exe名：");
			this.CHSLang.Add("Form3_GUI_Button1_Text", "验 证");
			this.CHSLang.Add("Form3_GUI_GroupBox3_Text", "其它");
			this.CHSLang.Add("Form3_GUI_CheckBox1_Text", "创建文件时排除相同Hash文件");
			this.CHSLang.Add("BW1_cutImage_errmsg", "截取图片出错: ");
			this.CHSLang.Add("BW1_scan32BitImage_errmsg", "扫描32位图片出错: ");
			this.CHSLang.Add("BW1_TransparentImage_errmsg", "设透明出错: ");
			this.CHSLang.Add("BW1_ConvertImageFormat_errmsg_1", "转换格式出错：未选择格式或者两种格式相同。");
			this.CHSLang.Add("BW1_ConvertImageFormat_errmsg_2", "转换格式出错: ");
			this.CHSLang.Add("BW1_checkBlackAlphaCutImage_errmsg", "取出图片有用范围出错: ");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one", "常规合成规则");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_100", "模式一：手动添加底面，面图片位于左上角，可用于两张图直接合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_101", "模式一：手动添加底面，面图片位于左下角");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_102", "模式一：手动添加底面，面图片位于右上角");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_103", "模式一：手动添加底面，面图片位于右下角");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_112", "模式一：手动添加底面，面图片的起点 X，Y 在\"特别设定\"里设定");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_120", "模式一：手动添加底面，两张图直接合成，仅复制面图片ALPHA为白色值的颜色到底图片");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_xy_offset", "方位与坐标");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_117", "模式一：手动添加底面，底（左边）放ALPHA，面（右边）放源图");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_118", "模式一：手动添加底面，底（左边）放ALPHA（黑白反色），面（右边）放源图");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_104", "模式二：添加文件夹，自动合成，以\"_m\"结尾的合成，xxx.bmp是源图，xxx_m.bmp是作为ALPHA");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_121", "模式二：添加文件夹，自动合成，以\"_m\"结尾的合成，xxx.bmp是源图，xxx_m.bmp是作为ALPHA，黑白反色");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_106", "模式二：添加文件夹，自动合成，以\"m\"开头的合成，xxx.bmp是源图，mxxx.bmp是作为ALPHA");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_111", "模式二：添加文件夹，自动合成，文件名中间带\"M\"和后面带xy坐标，ABC12Dx100y50.bmp是源图，ABC12DMx40y30.bmp是作为ALPHA");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_119", "模式二：添加文件夹，自动合成，以\"_MS\"或者\"_M\"为结尾的合成，ABC_XY.bmp是源图，ABC_MS.bmp是作为ALPHA，黑白反色");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_name_with_m", "源图与ALPHA分开为两张图");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_105", "模式二：添加文件夹，自动合成，图片宽度可平分，左边是源图，右边是ALPHA，黑白反色");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_107", "模式二：添加文件夹，自动合成，图片宽度可平分，左边是源图，右边是ALPHA");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_109", "模式一：手动添加底面，两张图直接合成，非白色的ALPHA一律视为黑色的ALPHA");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_108", "模式一：手动添加底面，扫描底图片（面部）留空区域的ALPHA是否能和面图片（表情）的ALPHA适配合成（严格）");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_110", "模式一：手动添加底面，扫描底图片（面部）留空区域的ALPHA是否能和面图片（表情）的ALPHA适配合成（仅检查宽度）");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_113", "模式一：手动添加底面，根据面图片的X轴第一行（最上）的RGB，扫描底图片找出完全相同位置适配合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_114", "模式一：手动添加底面，根据面图片的X轴最后一行（最下）的RGB，扫描底图片找出完全相同位置适配合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_115", "模式一：手动添加底面，根据面图片的Y轴第一列（最左）的RGB，扫描底图片找出完全相同位置适配合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_116", "模式一：手动添加底面，根据面图片的Y轴最后一列（最右）的RGB，扫描底图片找出完全相同位置适配合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_scan_b_scan_f", "根据面图片的RGB适配合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_one_122", "模式二：添加文件夹，自动合成 ABC_01.bmp + ABC_XY.bmp");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two", "RioShiina（ZeaS版）解包的立绘合成。如：XXXXXX@0000_pos_数字_数字.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two_200", "模式一：手动添加底面");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two_201", "模式一：手动添加底面，底图片高度根据面图片自动增加");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two_202", "模式一：手动添加底面，底图片宽度根据面图片自动增加");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two_203", "模式二：添加文件夹，自动合成，00XX是完整的身体，01XX是表情，02XX和以后的不合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_two_204", "模式二：添加文件夹，自动合成，00XX+01XX合成完整的身体，02XX/03XX/04XX是表情，05XX和以后的不合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three", "kirikiri2 解包的的立绘合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_asd_sc", "asd 脚本系列");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_300", "模式二：添加文件夹，自动合成，xxx.asd + xxx.png + xxx_a.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_301", "模式二：添加文件夹，自动合成，xxx.asd + xxx_a.png + xxx_a_m.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_313", "模式二：添加文件夹，自动合成，*.cgm + *.asd");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_txtinfo", "xxx_info.txt + xxx.txt 系列");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_302", "模式二：添加文件夹，自动合成，xxxyy_info.txt + xxxyy_z.txt + xxxyy_z_info.txt");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_303", "模式二：添加文件夹，自动合成，xxxyy_info.txt + xxxyy_z.txt + xxxyy_z_info.txt，宽高度自动增加");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_304", "模式二：添加文件夹，自动合成，xxx_info.txt + xxx.txt + xxx.stand");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_305", "模式二：添加文件夹，自动合成，fgimage\\xxx_info.txt + fgimage\\***\\xxx_y.txt，info 结构为 dress:diff, facegroup, fgname, fgalias");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_306", "模式二：添加文件夹，自动合成，fgimage\\xxx_info.txt + fgimage\\***\\xxx_y.txt，info 结构为 dress:base, dress:diff, facegroup, fgname, fgalias");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_307", "模式二：添加文件夹，自动合成，fgimage\\xxx_info.txt + fgimage\\***\\xxx_y.txt，info 结构为 dress:base, dress:diff, face, add可有可无");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_308", "模式二：添加文件夹，自动合成，fgimage\\xxx_info.txt + fgimage\\***\\xxx_y.txt，info 结构为 dress:diff, face, add可有可无");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_309", "模式二：添加文件夹，自动转换，根据 xxx.txt 的属性定义将图片转换成可用于直接手动合成统一尺寸的图片");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_312", "模式二：添加文件夹，自动合成，fgimage\\xxx_info.txt + fgimage\\***\\xxx_y.txt，info 结构为 dress:base, dress:diff, face, rename");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_pos", "pos + anm + asd 系列");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_310", "模式二：添加文件夹，自动合成，xxxyy.anm + xxxyy_anm.asd + xxxyy.pos");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_311", "模式二：添加文件夹，自动合成，xxx.pos + xxx_yy_zz.anm + xxx_yy_zz.asd");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_tjs_sc", "tjs 脚本系列");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_314", "模式二：添加文件夹，自动合成，ImageObject.tjs");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_ks_sc", "ks 脚本系列");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_315", "模式二：添加文件夹，自动合成，以 *.ks 为主索引，合成 *.tjs 或者 xxx_info.txt + xxx_y.txt");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_316", "模式二：添加文件夹，自动合成，CGモード.ks 或者 first.ks");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_three_317", "模式二：添加文件夹，自动合成，*.ks");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four", "asmodean 的工具解包后的合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_400", "模式一：手动添加底面，exl6ren，合成文件名带xy坐标的文件，如：XXXXX+x295y34.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_401", "模式二：添加文件夹，自动合成，exszs + tig2png 后的 *.dat + *.png，如：ougenki_A.dat + ougenki_A.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_402", "模式二：添加文件夹，自动合成，exef2paz，合成文件名带xy坐标的文件，如：XXXXX+YYY+ZZZ+x172y164.png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_403", "模式二：添加文件夹，自动合成，exchpac，*.spm 或者 visual.dat");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_404", "模式二：添加文件夹，自动合成，exdieslib，*.dzi");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_405", "模式二：添加文件夹，自动转换，exoozoarc，根据 *.txt 的属性定义将图片转换成可用于直接手动合成统一尺寸的图片");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_406", "模式二：添加文件夹，自动合成，exyatpkg，scriptSettings.lua + *.evt");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_407", "模式二：添加文件夹，自动导出，exsteldat，*.mng");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_408", "模式二：添加文件夹，自动合成，exmed，_BGSET 或者 _SPRSET");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_409", "模式二：添加文件夹，自动合成，exanepak，chaNX00(u).png + chaNXYZ(uh).png");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_410", "模式二：添加文件夹，自动合成，exescarc，*.lsf");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_411", "模式二：添加文件夹，自动合成，expimg，*.txt");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_four_412", "模式二：添加文件夹，自动合成，exl6ren，自动合成cg");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_five", "crass 的工具解包后的合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_five_500", "模式二：添加文件夹，自动合成，PJADV，*.bin（graphic.bin）");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_five_501", "模式二：添加文件夹，自动转换，NScripter，nscript.txt");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_five_502", "模式二：添加文件夹，自动合成，PJADV，*.anm");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_five_503", "模式二：添加文件夹，自动合成，DDSystem，sh_aXYZ\\000000.tga");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_six", "westside 的工具解包后的合成");
			this.CHSLang.Add("BW2_DBTV1_TreeNode_six_600", "模式二：添加文件夹，自动合成，ippaiscv，*.txt");
			this.CurrLang = this.CHSLang;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0002621C File Offset: 0x0002441C
		public string getMultiLingual(string skey)
		{
			string empty = string.Empty;
			if (this.bChsLang)
			{
				if (this.CHSLang.TryGetValue(skey, out empty))
				{
					return empty;
				}
				return skey;
			}
			else
			{
				if (this.CurrLang.TryGetValue(skey, out empty))
				{
					return empty;
				}
				return skey;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00026260 File Offset: 0x00024460
		public void setMultiLingual(string xmlpath = "")
		{
			if (string.IsNullOrWhiteSpace(xmlpath))
			{
				this.bChsLang = true;
			}
			else if (File.Exists(xmlpath))
			{
				this.bChsLang = false;
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(xmlpath);
					XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("text");
					try
					{
						foreach (object obj in xmlNode.ChildNodes)
						{
							XmlNode xmlNode2 = (XmlNode)obj;
							if (xmlNode2.NodeType != XmlNodeType.Comment)
							{
								string innerText = xmlNode2.InnerText;
								if (!string.IsNullOrWhiteSpace(innerText))
								{
									this.CurrLang[xmlNode2.Name] = innerText;
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				catch (Exception ex)
				{
					PublicModule.addLog(xmlpath + " : " + ex.Message);
					MyProject.get_Forms().get_Form1().ShowText1Msg();
				}
			}
		}

		// Token: 0x04000291 RID: 657
		public bool bChsLang;

		// Token: 0x04000292 RID: 658
		private readonly Dictionary<string, string> CHSLang;

		// Token: 0x04000293 RID: 659
		private Dictionary<string, string> CurrLang;
	}
}
