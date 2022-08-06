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
using System.Collections.Generic;
using Xor;

public partial class DictChapterEnemy
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 敌人id
        /// </summary>
        public string id;
     /// <summary>
        /// 名字
        /// </summary>
        public string name;
     /// <summary>
        /// 描述
        /// </summary>
        public string desc;
     /// <summary>
        /// 英雄ID
        /// </summary>
        public string hero_id;
     /// <summary>
        /// 等级
        /// </summary>
        public XorInt level_xor;
     /// <summary>
        /// 等级
        /// </summary>
        public int level{
            get{
                return level_xor.val;
            }
        }
     /// <summary>
        /// 技能等级
        /// </summary>
        public XorInt skill_lev_xor;
     /// <summary>
        /// 技能等级
        /// </summary>
        public int skill_lev{
            get{
                return skill_lev_xor.val;
            }
        }
     /// <summary>
        /// 攻击
        /// </summary>
        public XorInt attack_xor;
     /// <summary>
        /// 攻击
        /// </summary>
        public int attack{
            get{
                return attack_xor.val;
            }
        }
     /// <summary>
        /// 防御
        /// </summary>
        public XorInt defence_xor;
     /// <summary>
        /// 防御
        /// </summary>
        public int defence{
            get{
                return defence_xor.val;
            }
        }
     /// <summary>
        /// 血量
        /// </summary>
        public XorLong hp_xor;
     /// <summary>
        /// 血量
        /// </summary>
        public long hp{
            get{
                return hp_xor.val;
            }
        }
     /// <summary>
        /// 魔法
        /// </summary>
        public XorInt mp_xor;
     /// <summary>
        /// 魔法
        /// </summary>
        public int mp{
            get{
                return mp_xor.val;
            }
        }
     /// <summary>
        /// 身法
        /// </summary>
        public XorInt shenfa_xor;
     /// <summary>
        /// 身法
        /// </summary>
        public int shenfa{
            get{
                return shenfa_xor.val;
            }
        }
     /// <summary>
        /// 筋骨
        /// </summary>
        public XorInt jingu_xor;
     /// <summary>
        /// 筋骨
        /// </summary>
        public int jingu{
            get{
                return jingu_xor.val;
            }
        }
     /// <summary>
        /// 内力
        /// </summary>
        public XorInt neili_xor;
     /// <summary>
        /// 内力
        /// </summary>
        public int neili{
            get{
                return neili_xor.val;
            }
        }
     /// <summary>
        /// 武器系数
        /// </summary>
        public XorInt weapon_factor_xor;
     /// <summary>
        /// 武器系数
        /// </summary>
        public int weapon_factor{
            get{
                return weapon_factor_xor.val;
            }
        }
     /// <summary>
        /// 英雄星级
        /// </summary>
        public XorInt star_lev_xor;
     /// <summary>
        /// 英雄星级
        /// </summary>
        public int star_lev{
            get{
                return star_lev_xor.val;
            }
        }
     /// <summary>
        /// 攻击速度
        /// </summary>
        public XorDouble attack_speed_xor;
     /// <summary>
        /// 攻击速度
        /// </summary>
        public double attack_speed{
            get{
                return attack_speed_xor.val;
            }
        }
     /// <summary>
        /// 吸血因子
        /// </summary>
        public XorDouble xixue_factor_xor;
     /// <summary>
        /// 吸血因子
        /// </summary>
        public double xixue_factor{
            get{
                return xixue_factor_xor.val;
            }
        }
     /// <summary>
        /// 命中
        /// </summary>
        public XorDouble hit_radio_xor;
     /// <summary>
        /// 命中
        /// </summary>
        public double hit_radio{
            get{
                return hit_radio_xor.val;
            }
        }
     /// <summary>
        /// 闪避
        /// </summary>
        public XorDouble miss_radio_xor;
     /// <summary>
        /// 闪避
        /// </summary>
        public double miss_radio{
            get{
                return miss_radio_xor.val;
            }
        }
     /// <summary>
        /// 穿透
        /// </summary>
        public XorDouble pofang_radio_xor;
     /// <summary>
        /// 穿透
        /// </summary>
        public double pofang_radio{
            get{
                return pofang_radio_xor.val;
            }
        }
     /// <summary>
        /// 暴击
        /// </summary>
        public XorDouble crit_radio_xor;
     /// <summary>
        /// 暴击
        /// </summary>
        public double crit_radio{
            get{
                return crit_radio_xor.val;
            }
        }
     /// <summary>
        /// 暴击伤害
        /// </summary>
        public XorDouble crit_dmg_percent_xor;
     /// <summary>
        /// 暴击伤害
        /// </summary>
        public double crit_dmg_percent{
            get{
                return crit_dmg_percent_xor.val;
            }
        }
     /// <summary>
        /// 眩晕抗性
        /// </summary>
        public XorDouble unxuanyun_xor;
     /// <summary>
        /// 眩晕抗性
        /// </summary>
        public double unxuanyun{
            get{
                return unxuanyun_xor.val;
            }
        }
     /// <summary>
        /// 禁锢抗性
        /// </summary>
        public XorDouble unjinggu_xor;
     /// <summary>
        /// 禁锢抗性
        /// </summary>
        public double unjinggu{
            get{
                return unjinggu_xor.val;
            }
        }
     /// <summary>
        /// 昏睡抗性
        /// </summary>
        public XorDouble unhunshui_xor;
     /// <summary>
        /// 昏睡抗性
        /// </summary>
        public double unhunshui{
            get{
                return unhunshui_xor.val;
            }
        }
     /// <summary>
        /// 封印抗性
        /// </summary>
        public XorDouble unfengyin_xor;
     /// <summary>
        /// 封印抗性
        /// </summary>
        public double unfengyin{
            get{
                return unfengyin_xor.val;
            }
        }
     /// <summary>
        /// 禁法抗性
        /// </summary>
        public XorDouble unjinfa_xor;
     /// <summary>
        /// 禁法抗性
        /// </summary>
        public double unjinfa{
            get{
                return unjinfa_xor.val;
            }
        }
     /// <summary>
        /// 魅惑抗性
        /// </summary>
        public XorDouble unmeihuo_xor;
     /// <summary>
        /// 魅惑抗性
        /// </summary>
        public double unmeihuo{
            get{
                return unmeihuo_xor.val;
            }
        }
     /// <summary>
        /// 虚弱抗性
        /// </summary>
        public XorDouble unxuruo_xor;
     /// <summary>
        /// 虚弱抗性
        /// </summary>
        public double unxuruo{
            get{
                return unxuruo_xor.val;
            }
        }
     /// <summary>
        /// 攻击属性类型
        /// </summary>
        public XorInt atkShuxingType_xor;
     /// <summary>
        /// 攻击属性类型
        /// </summary>
        public int atkShuxingType{
            get{
                return atkShuxingType_xor.val;
            }
        }
     /// <summary>
        /// 被击属性类型
        /// </summary>
        public XorInt beAtkShuxingType_xor;
     /// <summary>
        /// 被击属性类型
        /// </summary>
        public int beAtkShuxingType{
            get{
                return beAtkShuxingType_xor.val;
            }
        }
     /// <summary>
        /// 增伤
        /// </summary>
        public XorDouble dmg_add_per_xor;
     /// <summary>
        /// 增伤
        /// </summary>
        public double dmg_add_per{
            get{
                return dmg_add_per_xor.val;
            }
        }
     /// <summary>
        /// 减伤
        /// </summary>
        public XorDouble dmg_des_per_xor;
     /// <summary>
        /// 减伤
        /// </summary>
        public double dmg_des_per{
            get{
                return dmg_des_per_xor.val;
            }
        }
     /// <summary>
        /// 伤害反弹
        /// </summary>
        public XorDouble dmg_fantan_xor;
     /// <summary>
        /// 伤害反弹
        /// </summary>
        public double dmg_fantan{
            get{
                return dmg_fantan_xor.val;
            }
        }
     /// <summary>
        /// 抗爆率
        /// </summary>
        public XorDouble kang_crit_radio_xor;
     /// <summary>
        /// 抗爆率
        /// </summary>
        public double kang_crit_radio{
            get{
                return kang_crit_radio_xor.val;
            }
        }
     /// <summary>
        /// 抗爆伤害率
        /// </summary>
        public XorDouble kang_crit_dmg_radio_xor;
     /// <summary>
        /// 抗爆伤害率
        /// </summary>
        public double kang_crit_dmg_radio{
            get{
                return kang_crit_dmg_radio_xor.val;
            }
        }
     /// <summary>
        /// 抗吸血
        /// </summary>
        public XorDouble kang_xixue_xor;
     /// <summary>
        /// 抗吸血
        /// </summary>
        public double kang_xixue{
            get{
                return kang_xixue_xor.val;
            }
        }
     /// <summary>
        /// 每回合行动次数
        /// </summary>
        public XorInt action_count_round_xor;
     /// <summary>
        /// 每回合行动次数
        /// </summary>
        public int action_count_round{
            get{
                return action_count_round_xor.val;
            }
        }

    public virtual Model Clone()
    {
        Model mm = this.MemberwiseClone() as Model;
        return mm;
    }
}

    //
    private Dictionary<string, Model> m_dict;

    // Get The Dictionary
    public Dictionary<string, Model> Dict
    {
        get
        {
            return m_dict;
        }
    }

    private List<Model> m_list;
	public List<Model> getList()
	{
		return m_list;
	}

    // Get The Model By Key
    public Model GetModel(string id)
    {
        if (m_dict == null)
        {
            Debug.LogError("DictChapterEnemy m_dict Is Null");
            return null;
        }
        else
        {
            if (m_dict.ContainsKey(id))
            {
                return m_dict[id];
            }
            else
            {
                Debug.LogError ("error id:"+id);
                return null;
            }
        }
    }

    private DictString_LoadFinishedCallBack m_loadFinishedCallBack;
    // load the json file
    public void Load(string path,DictString_LoadFinishedCallBack callBack)
    {
        m_loadFinishedCallBack = callBack;

        //
        string filePath = path;
        if(!filePath.EndsWith("/"))
        {
            filePath += "/";
        }

        filePath += GetFileName();
        DictFileReader fileReader = new DictFileReader(filePath, DoParse);
    }

    // get file name
    public string GetFileName()
    {
        return "dict_chapter_enemy.txt";
    }

    // parse the json data
    private void DoParse(DictFileReader fileReader)
    {
        m_dict = new Dictionary<string,Model>();
        m_list = new List<Model>();
        //
        do
        {
            string[] str = fileReader.ReadRow();
            if (str == null || str.Length == 0)
            {
                break;
            }

            //
            Model model = new Model();
            model.id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["id"]]);
            model.name = DictTypeConvert.ParseString(str[fileReader.typeName2Index["name"]]);
            model.desc = DictTypeConvert.ParseString(str[fileReader.typeName2Index["desc"]]);
            model.hero_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["hero_id"]]);
            model.level_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["level"]]),fileReader.randomUtil);
            model.skill_lev_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["skill_lev"]]),fileReader.randomUtil);
            model.attack_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["attack"]]),fileReader.randomUtil);
            model.defence_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["defence"]]),fileReader.randomUtil);
            model.hp_xor = new XorLong(DictTypeConvert.ParseLong(str[fileReader.typeName2Index["hp"]]),fileReader.randomUtil);
            model.mp_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["mp"]]),fileReader.randomUtil);
            model.shenfa_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["shenfa"]]),fileReader.randomUtil);
            model.jingu_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["jingu"]]),fileReader.randomUtil);
            model.neili_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["neili"]]),fileReader.randomUtil);
            model.weapon_factor_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["weapon_factor"]]),fileReader.randomUtil);
            model.star_lev_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["star_lev"]]),fileReader.randomUtil);
            model.attack_speed_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["attack_speed"]]),fileReader.randomUtil);
            model.xixue_factor_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["xixue_factor"]]),fileReader.randomUtil);
            model.hit_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["hit_radio"]]),fileReader.randomUtil);
            model.miss_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["miss_radio"]]),fileReader.randomUtil);
            model.pofang_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["pofang_radio"]]),fileReader.randomUtil);
            model.crit_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["crit_radio"]]),fileReader.randomUtil);
            model.crit_dmg_percent_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["crit_dmg_percent"]]),fileReader.randomUtil);
            model.unxuanyun_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unxuanyun"]]),fileReader.randomUtil);
            model.unjinggu_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unjinggu"]]),fileReader.randomUtil);
            model.unhunshui_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unhunshui"]]),fileReader.randomUtil);
            model.unfengyin_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unfengyin"]]),fileReader.randomUtil);
            model.unjinfa_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unjinfa"]]),fileReader.randomUtil);
            model.unmeihuo_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unmeihuo"]]),fileReader.randomUtil);
            model.unxuruo_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["unxuruo"]]),fileReader.randomUtil);
            model.atkShuxingType_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["atkShuxingType"]]),fileReader.randomUtil);
            model.beAtkShuxingType_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["beAtkShuxingType"]]),fileReader.randomUtil);
            model.dmg_add_per_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["dmg_add_per"]]),fileReader.randomUtil);
            model.dmg_des_per_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["dmg_des_per"]]),fileReader.randomUtil);
            model.dmg_fantan_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["dmg_fantan"]]),fileReader.randomUtil);
            model.kang_crit_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["kang_crit_radio"]]),fileReader.randomUtil);
            model.kang_crit_dmg_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["kang_crit_dmg_radio"]]),fileReader.randomUtil);
            model.kang_xixue_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["kang_xixue"]]),fileReader.randomUtil);
            model.action_count_round_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["action_count_round"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictChapterEnemy Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
