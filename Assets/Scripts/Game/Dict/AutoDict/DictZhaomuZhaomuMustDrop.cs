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

public partial class DictZhaomuZhaomuMustDrop
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 主键ID
        /// </summary>
        public XorInt id_xor;
     /// <summary>
        /// 主键ID
        /// </summary>
        public int id{
            get{
                return id_xor.val;
            }
        }
     /// <summary>
        /// 必掉物品ID
        /// </summary>
        public string class_id;
     /// <summary>
        /// 必掉物品ID
        /// </summary>
        public string prop_id;
     /// <summary>
        /// 必掉物品ID
        /// </summary>
        public string obj_id;
     /// <summary>
        /// 数量
        /// </summary>
        public XorInt drop_num_xor;
     /// <summary>
        /// 数量
        /// </summary>
        public int drop_num{
            get{
                return drop_num_xor.val;
            }
        }
     /// <summary>
        /// 招募公告池子类型
        /// </summary>
        public XorInt zhaomu_types_xor;
     /// <summary>
        /// 招募公告池子类型
        /// </summary>
        public int zhaomu_types{
            get{
                return zhaomu_types_xor.val;
            }
        }
     /// <summary>
        /// 抽卡次数
        /// </summary>
        public XorInt zhaomu_num_xor;
     /// <summary>
        /// 抽卡次数
        /// </summary>
        public int zhaomu_num{
            get{
                return zhaomu_num_xor.val;
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
            Debug.LogError("DictZhaomuZhaomuMustDrop m_dict Is Null");
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
        return "dict_zhaomu_zhaomu_must_drop.txt";
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
            model.class_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["class_id"]]);
            model.prop_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["prop_id"]]);
            model.obj_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["obj_id"]]);
            model.drop_num_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["drop_num"]]),fileReader.randomUtil);
            model.zhaomu_types_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["zhaomu_types"]]),fileReader.randomUtil);
            model.zhaomu_num_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["zhaomu_num"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictZhaomuZhaomuMustDrop Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
