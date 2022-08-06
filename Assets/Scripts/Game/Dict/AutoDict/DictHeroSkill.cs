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

public partial class DictHeroSkill
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 技能id
        /// </summary>
        public string id;
     /// <summary>
        /// 名字
        /// </summary>
        public string name;
     /// <summary>
        /// 英雄ID
        /// </summary>
        public string hero_id;
     /// <summary>
        /// 解锁星级
        /// </summary>
        public XorInt hero_star_xor;
     /// <summary>
        /// 解锁星级
        /// </summary>
        public int hero_star{
            get{
                return hero_star_xor.val;
            }
        }
     /// <summary>
        /// 小怪释放顺序
        /// </summary>
        public XorInt weigth_xor;
     /// <summary>
        /// 小怪释放顺序
        /// </summary>
        public int weigth{
            get{
                return weigth_xor.val;
            }
        }
     /// <summary>
        /// 顺序
        /// </summary>
        public XorInt order_xor;
     /// <summary>
        /// 顺序
        /// </summary>
        public int order{
            get{
                return order_xor.val;
            }
        }
     /// <summary>
        /// 伤害参数
        /// </summary>
        public XorDouble dmg_factor_xor;
     /// <summary>
        /// 伤害参数
        /// </summary>
        public double dmg_factor{
            get{
                return dmg_factor_xor.val;
            }
        }
     /// <summary>
        /// 伤害成长
        /// </summary>
        public XorDouble dmg_factor_lev_xor;
     /// <summary>
        /// 伤害成长
        /// </summary>
        public double dmg_factor_lev{
            get{
                return dmg_factor_lev_xor.val;
            }
        }
     /// <summary>
        /// 冷却回合
        /// </summary>
        public XorInt cd_xor;
     /// <summary>
        /// 冷却回合
        /// </summary>
        public int cd{
            get{
                return cd_xor.val;
            }
        }
     /// <summary>
        /// 前移时间
        /// </summary>
        public XorDouble before_time_xor;
     /// <summary>
        /// 前移时间
        /// </summary>
        public double before_time{
            get{
                return before_time_xor.val;
            }
        }
     /// <summary>
        /// 技能时间
        /// </summary>
        public XorDouble skill_time_xor;
     /// <summary>
        /// 技能时间
        /// </summary>
        public double skill_time{
            get{
                return skill_time_xor.val;
            }
        }
     /// <summary>
        /// 武器系数(真实伤害武器系数*英雄装备武器系数)
        /// </summary>
        public XorDouble weapon_factor_xor;
     /// <summary>
        /// 武器系数(真实伤害武器系数*英雄装备武器系数)
        /// </summary>
        public double weapon_factor{
            get{
                return weapon_factor_xor.val;
            }
        }
     /// <summary>
        /// 技能触发条件
        /// </summary>
        public string skill_trigger;
     /// <summary>
        /// 技能施法类型
        /// </summary>
        public string skill_type;
     /// <summary>
        /// 技能释放效果 
        /// </summary>
        public string release_effect;
     /// <summary>
        /// 技能投掷效果（战力攻击有效）
        /// </summary>
        public string project_effect;
     /// <summary>
        /// 命中prefab
        /// </summary>
        public string hit_prefab;
     /// <summary>
        /// 技能命中特效(只对敌人有效)
        /// </summary>
        public string hit_effect;
     /// <summary>
        /// 技能图标
        /// </summary>
        public string skill_icon;
     /// <summary>
        /// 技能文字效果
        /// </summary>
        public string effect_text;
     /// <summary>
        /// 技能描述
        /// </summary>
        public string detail;
     /// <summary>
        /// 公式
        /// </summary>
        public string skill_calculate;
     /// <summary>
        /// 目标选择策略
        /// </summary>
        public XorInt SelectStrategy_xor;
     /// <summary>
        /// 目标选择策略
        /// </summary>
        public int SelectStrategy{
            get{
                return SelectStrategy_xor.val;
            }
        }
     /// <summary>
        /// 目标对象(0敌方，1友方，2自己)
        /// </summary>
        public XorInt target_xor;
     /// <summary>
        /// 目标对象(0敌方，1友方，2自己)
        /// </summary>
        public int target{
            get{
                return target_xor.val;
            }
        }
     /// <summary>
        /// 技能类型（物理，法术）
        /// </summary>
        public XorInt fashu_xor;
     /// <summary>
        /// 技能类型（物理，法术）
        /// </summary>
        public int fashu{
            get{
                return fashu_xor.val;
            }
        }
     /// <summary>
        /// 属性参数
        /// </summary>
        public string abilityid;
     /// <summary>
        /// 属性成长参数
        /// </summary>
        public string abilityid_lev;
     /// <summary>
        /// buff目标对象(0选择目标，1.自身)
        /// </summary>
        public XorDouble buff_target_xor;
     /// <summary>
        /// buff目标对象(0选择目标，1.自身)
        /// </summary>
        public double buff_target{
            get{
                return buff_target_xor.val;
            }
        }
     /// <summary>
        /// buff叠加几率
        /// </summary>
        public XorDouble buff_radio_xor;
     /// <summary>
        /// buff叠加几率
        /// </summary>
        public double buff_radio{
            get{
                return buff_radio_xor.val;
            }
        }
     /// <summary>
        /// buff叠加
        /// </summary>
        public string buff_id;
     /// <summary>
        /// buff叠加几率公式
        /// </summary>
        public string buff_radio_gongshi;

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
            Debug.LogError("DictHeroSkill m_dict Is Null");
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
        return "dict_hero_skill.txt";
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
            model.hero_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["hero_id"]]);
            model.hero_star_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["hero_star"]]),fileReader.randomUtil);
            model.weigth_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["weigth"]]),fileReader.randomUtil);
            model.order_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["order"]]),fileReader.randomUtil);
            model.dmg_factor_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["dmg_factor"]]),fileReader.randomUtil);
            model.dmg_factor_lev_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["dmg_factor_lev"]]),fileReader.randomUtil);
            model.cd_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["cd"]]),fileReader.randomUtil);
            model.before_time_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["before_time"]]),fileReader.randomUtil);
            model.skill_time_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["skill_time"]]),fileReader.randomUtil);
            model.weapon_factor_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["weapon_factor"]]),fileReader.randomUtil);
            model.skill_trigger = DictTypeConvert.ParseString(str[fileReader.typeName2Index["skill_trigger"]]);
            model.skill_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["skill_type"]]);
            model.release_effect = DictTypeConvert.ParseString(str[fileReader.typeName2Index["release_effect"]]);
            model.project_effect = DictTypeConvert.ParseString(str[fileReader.typeName2Index["project_effect"]]);
            model.hit_prefab = DictTypeConvert.ParseString(str[fileReader.typeName2Index["hit_prefab"]]);
            model.hit_effect = DictTypeConvert.ParseString(str[fileReader.typeName2Index["hit_effect"]]);
            model.skill_icon = DictTypeConvert.ParseString(str[fileReader.typeName2Index["skill_icon"]]);
            model.effect_text = DictTypeConvert.ParseString(str[fileReader.typeName2Index["effect_text"]]);
            model.detail = DictTypeConvert.ParseString(str[fileReader.typeName2Index["detail"]]);
            model.skill_calculate = DictTypeConvert.ParseString(str[fileReader.typeName2Index["skill_calculate"]]);
            model.SelectStrategy_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["SelectStrategy"]]),fileReader.randomUtil);
            model.target_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["target"]]),fileReader.randomUtil);
            model.fashu_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["fashu"]]),fileReader.randomUtil);
            model.abilityid = DictTypeConvert.ParseString(str[fileReader.typeName2Index["abilityid"]]);
            model.abilityid_lev = DictTypeConvert.ParseString(str[fileReader.typeName2Index["abilityid_lev"]]);
            model.buff_target_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["buff_target"]]),fileReader.randomUtil);
            model.buff_radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["buff_radio"]]),fileReader.randomUtil);
            model.buff_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["buff_id"]]);
            model.buff_radio_gongshi = DictTypeConvert.ParseString(str[fileReader.typeName2Index["buff_radio_gongshi"]]);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictHeroSkill Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
