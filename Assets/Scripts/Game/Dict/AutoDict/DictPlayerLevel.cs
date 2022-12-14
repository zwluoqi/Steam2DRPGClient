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

public partial class DictPlayerLevel
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
        /// 下一级所需经验
        /// </summary>
        public XorLong needExp_xor;
     /// <summary>
        /// 下一级所需经验
        /// </summary>
        public long needExp{
            get{
                return needExp_xor.val;
            }
        }
     /// <summary>
        /// 下一级所需境界
        /// </summary>
        public XorInt needJingjieLev_xor;
     /// <summary>
        /// 下一级所需境界
        /// </summary>
        public int needJingjieLev{
            get{
                return needJingjieLev_xor.val;
            }
        }
     /// <summary>
        /// 下一级所需经验
        /// </summary>
        public XorInt exp_xor;
     /// <summary>
        /// 下一级所需经验
        /// </summary>
        public int exp{
            get{
                return exp_xor.val;
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
            Debug.LogError("DictPlayerLevel m_dict Is Null");
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
        return "dict_player_level.txt";
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
            model.quality_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["quality"]]),fileReader.randomUtil);
            model.needExp_xor = new XorLong(DictTypeConvert.ParseLong(str[fileReader.typeName2Index["needExp"]]),fileReader.randomUtil);
            model.needJingjieLev_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["needJingjieLev"]]),fileReader.randomUtil);
            model.exp_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["exp"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictPlayerLevel Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
