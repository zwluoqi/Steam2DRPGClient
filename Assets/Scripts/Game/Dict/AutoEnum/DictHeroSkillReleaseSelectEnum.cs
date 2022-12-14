//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public enum DictHeroSkillReleaseSelectEnum : int
{
    /// <summary>
    /// 无
    /// </summary>
    NONE = 0,
    /// <summary>
    /// 第一个（默认）
    /// </summary>
    FIRST = 1,
    /// <summary>
    /// 敌方全体
    /// </summary>
    ALL_ENEMY = 2,
    /// <summary>
    /// 前排
    /// </summary>
    FRONT_ROW = 3,
    /// <summary>
    /// 中排
    /// </summary>
    MIDDLE_ROW = 4,
    /// <summary>
    /// 后排
    /// </summary>
    BACK_ROW = 5,
    /// <summary>
    /// 假随机2
    /// </summary>
    RANDOM2_FIRST = 6,
    /// <summary>
    /// 假随机3
    /// </summary>
    RANDOM3_FIRST = 7,
    /// <summary>
    /// 真随机1
    /// </summary>
    RANDOM1 = 8,
    /// <summary>
    /// 真随机2
    /// </summary>
    RANDOM2 = 9,
    /// <summary>
    /// 真随机3
    /// </summary>
    RANDOM3 = 10,
    /// <summary>
    /// 以目标为中心直线单列
    /// </summary>
    LINE_COLLUM = 11,
    /// <summary>
    /// 自己
    /// </summary>
    SELF = 12,
    /// <summary>
    /// 跟上一次选择保持相同
    /// </summary>
    SAME = 13,
    /// <summary>
    /// 跟cast选择保持相同
    /// </summary>
    SAME_AS_CAST = 14,
    /// <summary>
    /// 以目标为中心前两排
    /// </summary>
    Center_FRONT_ROW = 15,
    /// <summary>
    /// 目标中心九宫格前两排
    /// </summary>
    CENTER_SUDOKU_FRONT_ROW = 16,
    /// <summary>
    /// 非目标、真随机
    /// </summary>
    NOT_FIRST_RANDOM = 17,
    /// <summary>
    /// 排除已选、真随机
    /// </summary>
    NOT_SELECT_RANDOM = 18,
    /// <summary>
    /// 我方全体
    /// </summary>
    ALL_FRIEND = 19,
    /// <summary>
    /// 我方血量最少
    /// </summary>
    FRIEND_MIN_HP = 20,
    /// <summary>
    /// 攻击力最低
    /// </summary>
    MIN_ATTACK = 21,
    /// <summary>
    /// 血量百分比最少
    /// </summary>
    MIN_HP_PERCENT = 22,
    /// <summary>
    /// 阵亡人员
    /// </summary>
    Dead_Hero = 23,
    /// <summary>
    /// 全体阵亡人员
    /// </summary>
    All_Dead_Hero = 24,
    /// <summary>
    /// 最大值
    /// </summary>
    MAX_COUNT = 25,

}

public class DictHeroSkillReleaseSelectEnumString
{
    /// <summary>
    /// 无
    /// </summary>
    public const string NONE = "NONE";
    /// <summary>
    /// 第一个（默认）
    /// </summary>
    public const string FIRST = "FIRST";
    /// <summary>
    /// 敌方全体
    /// </summary>
    public const string ALL_ENEMY = "ALL_ENEMY";
    /// <summary>
    /// 前排
    /// </summary>
    public const string FRONT_ROW = "FRONT_ROW";
    /// <summary>
    /// 中排
    /// </summary>
    public const string MIDDLE_ROW = "MIDDLE_ROW";
    /// <summary>
    /// 后排
    /// </summary>
    public const string BACK_ROW = "BACK_ROW";
    /// <summary>
    /// 假随机2
    /// </summary>
    public const string RANDOM2_FIRST = "RANDOM2_FIRST";
    /// <summary>
    /// 假随机3
    /// </summary>
    public const string RANDOM3_FIRST = "RANDOM3_FIRST";
    /// <summary>
    /// 真随机1
    /// </summary>
    public const string RANDOM1 = "RANDOM1";
    /// <summary>
    /// 真随机2
    /// </summary>
    public const string RANDOM2 = "RANDOM2";
    /// <summary>
    /// 真随机3
    /// </summary>
    public const string RANDOM3 = "RANDOM3";
    /// <summary>
    /// 以目标为中心直线单列
    /// </summary>
    public const string LINE_COLLUM = "LINE_COLLUM";
    /// <summary>
    /// 自己
    /// </summary>
    public const string SELF = "SELF";
    /// <summary>
    /// 跟上一次选择保持相同
    /// </summary>
    public const string SAME = "SAME";
    /// <summary>
    /// 跟cast选择保持相同
    /// </summary>
    public const string SAME_AS_CAST = "SAME_AS_CAST";
    /// <summary>
    /// 以目标为中心前两排
    /// </summary>
    public const string Center_FRONT_ROW = "Center_FRONT_ROW";
    /// <summary>
    /// 目标中心九宫格前两排
    /// </summary>
    public const string CENTER_SUDOKU_FRONT_ROW = "CENTER_SUDOKU_FRONT_ROW";
    /// <summary>
    /// 非目标、真随机
    /// </summary>
    public const string NOT_FIRST_RANDOM = "NOT_FIRST_RANDOM";
    /// <summary>
    /// 排除已选、真随机
    /// </summary>
    public const string NOT_SELECT_RANDOM = "NOT_SELECT_RANDOM";
    /// <summary>
    /// 我方全体
    /// </summary>
    public const string ALL_FRIEND = "ALL_FRIEND";
    /// <summary>
    /// 我方血量最少
    /// </summary>
    public const string FRIEND_MIN_HP = "FRIEND_MIN_HP";
    /// <summary>
    /// 攻击力最低
    /// </summary>
    public const string MIN_ATTACK = "MIN_ATTACK";
    /// <summary>
    /// 血量百分比最少
    /// </summary>
    public const string MIN_HP_PERCENT = "MIN_HP_PERCENT";
    /// <summary>
    /// 阵亡人员
    /// </summary>
    public const string Dead_Hero = "Dead_Hero";
    /// <summary>
    /// 全体阵亡人员
    /// </summary>
    public const string All_Dead_Hero = "All_Dead_Hero";

public static string[] vlas = new string[]{
		
"NONE",

"FIRST",

"ALL_ENEMY",

"FRONT_ROW",

"MIDDLE_ROW",

"BACK_ROW",

"RANDOM2_FIRST",

"RANDOM3_FIRST",

"RANDOM1",

"RANDOM2",

"RANDOM3",

"LINE_COLLUM",

"SELF",

"SAME",

"SAME_AS_CAST",

"Center_FRONT_ROW",

"CENTER_SUDOKU_FRONT_ROW",

"NOT_FIRST_RANDOM",

"NOT_SELECT_RANDOM",

"ALL_FRIEND",

"FRIEND_MIN_HP",

"MIN_ATTACK",

"MIN_HP_PERCENT",

"Dead_Hero",

"All_Dead_Hero",
""
	};
}
