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

public partial class DictRewardTask
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// id
        /// </summary>
        public string id;
     /// <summary>
        /// 活跃度
        /// </summary>
        public XorInt activity_xor;
     /// <summary>
        /// 活跃度
        /// </summary>
        public int activity{
            get{
                return activity_xor.val;
            }
        }
     /// <summary>
        /// 任务激活机制
        /// </summary>
        public XorInt trigger_enum_xor;
     /// <summary>
        /// 任务激活机制
        /// </summary>
        public int trigger_enum{
            get{
                return trigger_enum_xor.val;
            }
        }
     /// <summary>
        /// 任务类型
        /// </summary>
        public string task_type;
     /// <summary>
        /// 任务目标类型
        /// </summary>
        public string target_class;
     /// <summary>
        /// 消耗物品
        /// </summary>
        public XorInt cost_target_xor;
     /// <summary>
        /// 消耗物品
        /// </summary>
        public int cost_target{
            get{
                return cost_target_xor.val;
            }
        }
     /// <summary>
        /// 任务目标class
        /// </summary>
        public string class_id;
     /// <summary>
        /// 任务目标prop
        /// </summary>
        public string prop_id;
     /// <summary>
        /// 任务目标obj
        /// </summary>
        public string obj_id;
     /// <summary>
        /// 任务目标objnum
        /// </summary>
        public XorInt obj_num_xor;
     /// <summary>
        /// 任务目标objnum
        /// </summary>
        public int obj_num{
            get{
                return obj_num_xor.val;
            }
        }
     /// <summary>
        /// 顺序
        /// </summary>
        public XorInt order_xor;
     /// <summary>
        /// 顺序
        /// </summary>
        public int order{
            get{
                return order_xor.val;
            }
        }
     /// <summary>
        /// 任务标题
        /// </summary>
        public string title;
     /// <summary>
        /// 任务描述
        /// </summary>
        public string detail;
     /// <summary>
        /// 奖励数组
        /// </summary>
        public List<string> rewards;
     /// <summary>
        /// 任务group
        /// </summary>
        public string group;
     /// <summary>
        /// 事件类型
        /// </summary>
        public string action_type;
     /// <summary>
        /// 事件参数
        /// </summary>
        public List<string> action_params;
     /// <summary>
        /// 任务显示toggle
        /// </summary>
        public string show_toggle;
     /// <summary>
        /// 任务显示sub_toggle
        /// </summary>
        public string sub_show_toggle;
     /// <summary>
        /// 任务显示等级
        /// </summary>
        public XorInt show_lev_xor;
     /// <summary>
        /// 任务显示等级
        /// </summary>
        public int show_lev{
            get{
                return show_lev_xor.val;
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
            Debug.LogError("DictRewardTask m_dict Is Null");
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
        return "dict_reward_task.txt";
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
            model.activity_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["activity"]]),fileReader.randomUtil);
            model.trigger_enum_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["trigger_enum"]]),fileReader.randomUtil);
            model.task_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["task_type"]]);
            model.target_class = DictTypeConvert.ParseString(str[fileReader.typeName2Index["target_class"]]);
            model.cost_target_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["cost_target"]]),fileReader.randomUtil);
            model.class_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["class_id"]]);
            model.prop_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["prop_id"]]);
            model.obj_id = DictTypeConvert.ParseString(str[fileReader.typeName2Index["obj_id"]]);
            model.obj_num_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["obj_num"]]),fileReader.randomUtil);
            model.order_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["order"]]),fileReader.randomUtil);
            model.title = DictTypeConvert.ParseString(str[fileReader.typeName2Index["title"]]);
            model.detail = DictTypeConvert.ParseString(str[fileReader.typeName2Index["detail"]]);
            model.rewards = DictTypeConvert.ParseArrayString(str[fileReader.typeName2Index["rewards"]]);
            model.group = DictTypeConvert.ParseString(str[fileReader.typeName2Index["group"]]);
            model.action_type = DictTypeConvert.ParseString(str[fileReader.typeName2Index["action_type"]]);
            model.action_params = DictTypeConvert.ParseArrayString(str[fileReader.typeName2Index["action_params"]]);
            model.show_toggle = DictTypeConvert.ParseString(str[fileReader.typeName2Index["show_toggle"]]);
            model.sub_show_toggle = DictTypeConvert.ParseString(str[fileReader.typeName2Index["sub_show_toggle"]]);
            model.show_lev_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["show_lev"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictRewardTask Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
