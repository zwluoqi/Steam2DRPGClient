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

public partial class DictHeroSkillLev
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
        /// 消耗技能点
        /// </summary>
        public XorInt cost_point_xor;
     /// <summary>
        /// 消耗技能点
        /// </summary>
        public int cost_point{
            get{
                return cost_point_xor.val;
            }
        }
     /// <summary>
        /// 消耗金币
        /// </summary>
        public XorInt cost_coin_xor;
     /// <summary>
        /// 消耗金币
        /// </summary>
        public int cost_coin{
            get{
                return cost_coin_xor.val;
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
            Debug.LogError("DictHeroSkillLev m_dict Is Null");
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
        return "dict_hero_skill_lev.txt";
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
            model.level_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["level"]]),fileReader.randomUtil);
            model.cost_point_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["cost_point"]]),fileReader.randomUtil);
            model.cost_coin_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["cost_coin"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictHeroSkillLev Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
