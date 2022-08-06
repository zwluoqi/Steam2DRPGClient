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

public partial class DictHeroZhaomuDropHero
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 主键ID
        /// </summary>
        public string id;
     /// <summary>
        /// 招募英雄ID
        /// </summary>
        public string hero_id;
     /// <summary>
        /// 得到概率
        /// </summary>
        public XorDouble drop_radiu_xor;
     /// <summary>
        /// 得到概率
        /// </summary>
        public double drop_radiu{
            get{
                return drop_radiu_xor.val;
            }
        }
     /// <summary>
        /// 十连抽必须得对象
        /// </summary>
        public XorInt ten_must_xor;
     /// <summary>
        /// 十连抽必须得对象
        /// </summary>
        public int ten_must{
            get{
                return ten_must_xor.val;
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
            Debug.LogError("DictHeroZhaomuDropHero m_dict Is Null");
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
        return "dict_hero_zhaomu_drop_hero.txt";
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
            model.hero_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["hero_id"]]);
            model.drop_radiu_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["drop_radiu"]]),fileReader.randomUtil);
            model.ten_must_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["ten_must"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictHeroZhaomuDropHero Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
