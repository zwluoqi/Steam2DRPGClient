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

public partial class DictHeroHeroStarAddAbility
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 主键
        /// </summary>
        public XorInt id_xor;
     /// <summary>
        /// 主键
        /// </summary>
        public int id{
            get{
                return id_xor.val;
            }
        }
     /// <summary>
        /// 星级
        /// </summary>
        public XorInt star_xor;
     /// <summary>
        /// 星级
        /// </summary>
        public int star{
            get{
                return star_xor.val;
            }
        }
     /// <summary>
        /// 英雄品质
        /// </summary>
        public XorInt quality_xor;
     /// <summary>
        /// 英雄品质
        /// </summary>
        public int quality{
            get{
                return quality_xor.val;
            }
        }
     /// <summary>
        /// 英雄类型
        /// </summary>
        public XorInt hero_type_xor;
     /// <summary>
        /// 英雄类型
        /// </summary>
        public int hero_type{
            get{
                return hero_type_xor.val;
            }
        }
     /// <summary>
        /// 攻击能力提升上线
        /// </summary>
        public XorDouble atk_max_xor;
     /// <summary>
        /// 攻击能力提升上线
        /// </summary>
        public double atk_max{
            get{
                return atk_max_xor.val;
            }
        }
     /// <summary>
        /// 气血能力提升上线
        /// </summary>
        public XorDouble hp_max_xor;
     /// <summary>
        /// 气血能力提升上线
        /// </summary>
        public double hp_max{
            get{
                return hp_max_xor.val;
            }
        }
     /// <summary>
        /// 防御能力提升上线
        /// </summary>
        public XorDouble def_max_xor;
     /// <summary>
        /// 防御能力提升上线
        /// </summary>
        public double def_max{
            get{
                return def_max_xor.val;
            }
        }
     /// <summary>
        /// 真元能力提升上线
        /// </summary>
        public XorDouble mp_max_xor;
     /// <summary>
        /// 真元能力提升上线
        /// </summary>
        public double mp_max{
            get{
                return mp_max_xor.val;
            }
        }
     /// <summary>
        /// 数值提升
        /// </summary>
        public XorInt valadv_xor;
     /// <summary>
        /// 数值提升
        /// </summary>
        public int valadv{
            get{
                return valadv_xor.val;
            }
        }

    public virtual Model Clone()
    {
        Model mm = this.MemberwiseClone() as Model;
        return mm;
    }
}

    //
    private Dictionary<int, Model> m_dict;

    // Get The Dictionary
    public Dictionary<int, Model> Dict
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
    public Model GetModel(int id)
    {
        if (m_dict == null)
        {
            Debug.LogError("DictHeroHeroStarAddAbility m_dict Is Null");
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
        return "dict_hero_hero_star_add_ability.txt";
    }

    // parse the json data
    private void DoParse(DictFileReader fileReader)
    {
        m_dict = new Dictionary<int,Model>();
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
            model.id_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["id"]]),fileReader.randomUtil);
            model.star_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["star"]]),fileReader.randomUtil);
            model.quality_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["quality"]]),fileReader.randomUtil);
            model.hero_type_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["hero_type"]]),fileReader.randomUtil);
            model.atk_max_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["atk_max"]]),fileReader.randomUtil);
            model.hp_max_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["hp_max"]]),fileReader.randomUtil);
            model.def_max_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["def_max"]]),fileReader.randomUtil);
            model.mp_max_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["mp_max"]]),fileReader.randomUtil);
            model.valadv_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["valadv"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictHeroHeroStarAddAbility Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
