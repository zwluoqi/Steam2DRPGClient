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

public partial class DictPlayerProp
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 枚举id
        /// </summary>
        public XorInt classId_xor;
     /// <summary>
        /// 枚举id
        /// </summary>
        public int classId{
            get{
                return classId_xor.val;
            }
        }
     /// <summary>
        /// 静态名称
        /// </summary>
        public string id;
     /// <summary>
        /// 属性名称
        /// </summary>
        public string propName;
     /// <summary>
        /// 图标
        /// </summary>
        public string icon;
     /// <summary>
        /// 出处
        /// </summary>
        public string drop;
     /// <summary>
        /// 描述
        /// </summary>
        public string detail;
     /// <summary>
        /// 品质
        /// </summary>
        public XorInt qulity_xor;
     /// <summary>
        /// 品质
        /// </summary>
        public int qulity{
            get{
                return qulity_xor.val;
            }
        }
     /// <summary>
        /// 基准数值
        /// </summary>
        public XorInt base_val_xor;
     /// <summary>
        /// 基准数值
        /// </summary>
        public int base_val{
            get{
                return base_val_xor.val;
            }
        }
     /// <summary>
        /// 获取
        /// </summary>
        public List<string> fromIds;
     /// <summary>
        /// 服务器进行数据统计
        /// </summary>
        public XorInt server_cal_xor;
     /// <summary>
        /// 服务器进行数据统计
        /// </summary>
        public int server_cal{
            get{
                return server_cal_xor.val;
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
    public Model GetModel(int classId)
    {
        if (m_dict == null)
        {
            Debug.LogError("DictPlayerProp m_dict Is Null");
            return null;
        }
        else
        {
            if (m_dict.ContainsKey(classId))
            {
                return m_dict[classId];
            }
            else
            {
                Debug.LogError ("error id:"+classId);
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
        return "dict_player_prop.txt";
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
            model.classId_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["classId"]]),fileReader.randomUtil);
            model.id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["id"]]);
            model.propName = DictTypeConvert.ParseString(str[fileReader.typeName2Index["propName"]]);
            model.icon = DictTypeConvert.ParseString(str[fileReader.typeName2Index["icon"]]);
            model.drop = DictTypeConvert.ParseString(str[fileReader.typeName2Index["drop"]]);
            model.detail = DictTypeConvert.ParseString(str[fileReader.typeName2Index["detail"]]);
            model.qulity_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["qulity"]]),fileReader.randomUtil);
            model.base_val_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["base_val"]]),fileReader.randomUtil);
            model.fromIds = DictTypeConvert.ParseArrayString(str[fileReader.typeName2Index["fromIds"]]);
            model.server_cal_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["server_cal"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.classId) == false)
            {
                m_dict.Add(model.classId, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictPlayerProp Parse:Same Key = " + model.classId);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}