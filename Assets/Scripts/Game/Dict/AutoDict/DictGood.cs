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

public partial class DictGood
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 物品ID
        /// </summary>
        public string id;
     /// <summary>
        /// 名字
        /// </summary>
        public string good_name;
     /// <summary>
        /// 类型
        /// </summary>
        public string good_type;
     /// <summary>
        /// 图标
        /// </summary>
        public string good_icon;
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
        /// 星级
        /// </summary>
        public XorInt start_xor;
     /// <summary>
        /// 星级
        /// </summary>
        public int start{
            get{
                return start_xor.val;
            }
        }
     /// <summary>
        /// 产出
        /// </summary>
        public string good_produce;
     /// <summary>
        /// 故事
        /// </summary>
        public string story;
     /// <summary>
        /// 加经验数值
        /// </summary>
        public XorInt add_exp_xor;
     /// <summary>
        /// 加经验数值
        /// </summary>
        public int add_exp{
            get{
                return add_exp_xor.val;
            }
        }
     /// <summary>
        /// 碎片英雄ID
        /// </summary>
        public string suit_hero_id;
     /// <summary>
        /// 增加属性
        /// </summary>
        public string abilityId;
     /// <summary>
        /// 图标来源
        /// </summary>
        public string icon_from;
     /// <summary>
        /// 图标外框带碎片表示
        /// </summary>
        public XorInt has_suipian_frame_xor;
     /// <summary>
        /// 图标外框带碎片表示
        /// </summary>
        public int has_suipian_frame{
            get{
                return has_suipian_frame_xor.val;
            }
        }
     /// <summary>
        /// 获取
        /// </summary>
        public List<string> fromIds;
     /// <summary>
        /// 基准ID
        /// </summary>
        public string baseGoodId;
     /// <summary>
        /// 宝箱使用期限
        /// </summary>
        public string baoxiangendTime;

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
            Debug.LogError("DictGood m_dict Is Null");
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
        return "dict_good.txt";
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
            model.good_name = DictTypeConvert.ParseString(str[fileReader.typeName2Index["good_name"]]);
            model.good_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["good_type"]]);
            model.good_icon = DictTypeConvert.ParseString(str[fileReader.typeName2Index["good_icon"]]);
            model.qulity_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["qulity"]]),fileReader.randomUtil);
            model.start_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["start"]]),fileReader.randomUtil);
            model.good_produce = DictTypeConvert.ParseString(str[fileReader.typeName2Index["good_produce"]]);
            model.story = DictTypeConvert.ParseString(str[fileReader.typeName2Index["story"]]);
            model.add_exp_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["add_exp"]]),fileReader.randomUtil);
            model.suit_hero_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["suit_hero_id"]]);
            model.abilityId = DictTypeConvert.ParseString(str[fileReader.typeName2Index["abilityId"]]);
            model.icon_from = DictTypeConvert.ParseString(str[fileReader.typeName2Index["icon_from"]]);
            model.has_suipian_frame_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["has_suipian_frame"]]),fileReader.randomUtil);
            model.fromIds = DictTypeConvert.ParseArrayString(str[fileReader.typeName2Index["fromIds"]]);
            model.baseGoodId = DictTypeConvert.ParseString(str[fileReader.typeName2Index["baseGoodId"]]);
            model.baoxiangendTime = DictTypeConvert.ParseString(str[fileReader.typeName2Index["baoxiangendTime"]]);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictGood Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
