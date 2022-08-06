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

public partial class DictEquipEquipAdvance
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
        /// 目标装备ID
        /// </summary>
        public string target_equip_id;
     /// <summary>
        /// 原始装备ID
        /// </summary>
        public string source_equip_id;

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
            Debug.LogError("DictEquipEquipAdvance m_dict Is Null");
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
        return "dict_equip_equip_advance.txt";
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
            model.target_equip_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["target_equip_id"]]);
            model.source_equip_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["source_equip_id"]]);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictEquipEquipAdvance Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
