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

public partial class DictMenpaiMenpaiCheckData
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// id
        /// </summary>
        public XorInt id_xor;
     /// <summary>
        /// id
        /// </summary>
        public int id{
            get{
                return id_xor.val;
            }
        }
     /// <summary>
        /// type
        /// </summary>
        public string type;
     /// <summary>
        /// 检测门派ID
        /// </summary>
        public List<int> idArray;
     /// <summary>
        /// 对比检测数组
        /// </summary>
        public List<int> checkArray;
     /// <summary>
        /// 挂机过滤概率
        /// </summary>
        public XorDouble radio_xor;
     /// <summary>
        /// 挂机过滤概率
        /// </summary>
        public double radio{
            get{
                return radio_xor.val;
            }
        }
     /// <summary>
        /// desc
        /// </summary>
        public string desc;

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
            Debug.LogError("DictMenpaiMenpaiCheckData m_dict Is Null");
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
        return "dict_menpai_menpai_check_data.txt";
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
            model.type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["type"]]);
            model.idArray = DictTypeConvert.ParseArrayInt(str[fileReader.typeName2Index["idArray"]]);
            model.checkArray = DictTypeConvert.ParseArrayInt(str[fileReader.typeName2Index["checkArray"]]);
            model.radio_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["radio"]]),fileReader.randomUtil);
            model.desc = DictTypeConvert.ParseString(str[fileReader.typeName2Index["desc"]]);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictMenpaiMenpaiCheckData Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
