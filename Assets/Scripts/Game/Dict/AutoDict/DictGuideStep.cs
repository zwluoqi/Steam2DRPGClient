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

public partial class DictGuideStep
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// 引导小步骤
        /// </summary>
        public XorInt guide_step_id_xor;
     /// <summary>
        /// 引导小步骤
        /// </summary>
        public int guide_step_id{
            get{
                return guide_step_id_xor.val;
            }
        }
     /// <summary>
        /// 引导小步骤条件
        /// </summary>
        public List<int> conditions;
     /// <summary>
        /// 行为类型
        /// </summary>
        public string action_type;
     /// <summary>
        /// 行为子类型
        /// </summary>
        public string action_sub_type;
     /// <summary>
        /// 行为参数
        /// </summary>
        public List<string> action_args;
     /// <summary>
        /// 小步骤描述
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
    public Model GetModel(int guide_step_id)
    {
        if (m_dict == null)
        {
            Debug.LogError("DictGuideStep m_dict Is Null");
            return null;
        }
        else
        {
            if (m_dict.ContainsKey(guide_step_id))
            {
                return m_dict[guide_step_id];
            }
            else
            {
                Debug.LogError ("error id:"+guide_step_id);
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
        return "dict_guide_step.txt";
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
            model.guide_step_id_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["guide_step_id"]]),fileReader.randomUtil);
            model.conditions = DictTypeConvert.ParseArrayInt(str[fileReader.typeName2Index["conditions"]]);
            model.action_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["action_type"]]);
            model.action_sub_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["action_sub_type"]]);
            model.action_args = DictTypeConvert.ParseArrayString(str[fileReader.typeName2Index["action_args"]]);
            model.desc = DictTypeConvert.ParseString(str[fileReader.typeName2Index["desc"]]);

            if (m_dict.ContainsKey(model.guide_step_id) == false)
            {
                m_dict.Add(model.guide_step_id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictGuideStep Parse:Same Key = " + model.guide_step_id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
