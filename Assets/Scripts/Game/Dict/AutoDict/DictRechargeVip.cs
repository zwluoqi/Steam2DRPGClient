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

public partial class DictRechargeVip
{

    // data model
    // [System.Serializable]
    public class Model
    {
     /// <summary>
        /// vip等级
        /// </summary>
        public XorInt id_xor;
     /// <summary>
        /// vip等级
        /// </summary>
        public int id{
            get{
                return id_xor.val;
            }
        }
     /// <summary>
        /// name
        /// </summary>
        public string vip;
     /// <summary>
        /// 升级经验
        /// </summary>
        public XorInt upexp_xor;
     /// <summary>
        /// 升级经验
        /// </summary>
        public int upexp{
            get{
                return upexp_xor.val;
            }
        }
     /// <summary>
        /// 图标
        /// </summary>
        public string spriteName;
     /// <summary>
        /// 加速战斗权限
        /// </summary>
        public XorInt acce_battle_max_xor;
     /// <summary>
        /// 加速战斗权限
        /// </summary>
        public int acce_battle_max{
            get{
                return acce_battle_max_xor.val;
            }
        }
     /// <summary>
        /// 重置试炼挑战次数权限
        /// </summary>
        public XorInt reset_shilian_count_xor;
     /// <summary>
        /// 重置试炼挑战次数权限
        /// </summary>
        public int reset_shilian_count{
            get{
                return reset_shilian_count_xor.val;
            }
        }
     /// <summary>
        /// 购买首领挑战次数权限(废弃)
        /// </summary>
        public XorInt buy_shouling_count_xor;
     /// <summary>
        /// 购买首领挑战次数权限(废弃)
        /// </summary>
        public int buy_shouling_count{
            get{
                return buy_shouling_count_xor.val;
            }
        }
     /// <summary>
        /// 重置普通boss挑战次数权限
        /// </summary>
        public XorInt reset_normal_boss_copy_xor;
     /// <summary>
        /// 重置普通boss挑战次数权限
        /// </summary>
        public int reset_normal_boss_copy{
            get{
                return reset_normal_boss_copy_xor.val;
            }
        }
     /// <summary>
        /// 重置天缘Boss挑战次数权限
        /// </summary>
        public XorInt reset_tianyuan_boss_copy_xor;
     /// <summary>
        /// 重置天缘Boss挑战次数权限
        /// </summary>
        public int reset_tianyuan_boss_copy{
            get{
                return reset_tianyuan_boss_copy_xor.val;
            }
        }
     /// <summary>
        /// 重置天机之争挑战次数权限
        /// </summary>
        public XorInt reset_tainji_boss_count_xor;
     /// <summary>
        /// 重置天机之争挑战次数权限
        /// </summary>
        public int reset_tainji_boss_count{
            get{
                return reset_tainji_boss_count_xor.val;
            }
        }
     /// <summary>
        /// 购买世界boss挑战次数权限
        /// </summary>
        public XorInt buy_world_boss_count_xor;
     /// <summary>
        /// 购买世界boss挑战次数权限
        /// </summary>
        public int buy_world_boss_count{
            get{
                return buy_world_boss_count_xor.val;
            }
        }
     /// <summary>
        /// 重置爬塔挑战次数权限
        /// </summary>
        public XorInt reset_pata_diff_copy_xor;
     /// <summary>
        /// 重置爬塔挑战次数权限
        /// </summary>
        public int reset_pata_diff_copy{
            get{
                return reset_pata_diff_copy_xor.val;
            }
        }
     /// <summary>
        /// 购买pvp挑战次数
        /// </summary>
        public XorInt buy_pvp_battle_count_xor;
     /// <summary>
        /// 购买pvp挑战次数
        /// </summary>
        public int buy_pvp_battle_count{
            get{
                return buy_pvp_battle_count_xor.val;
            }
        }
     /// <summary>
        /// 购买门派boss次数
        /// </summary>
        public XorInt buy_menpai_boss_count_xor;
     /// <summary>
        /// 购买门派boss次数
        /// </summary>
        public int buy_menpai_boss_count{
            get{
                return buy_menpai_boss_count_xor.val;
            }
        }
     /// <summary>
        /// 是否能够跳过战斗动画
        /// </summary>
        public XorInt skip_battle_xor;
     /// <summary>
        /// 是否能够跳过战斗动画
        /// </summary>
        public int skip_battle{
            get{
                return skip_battle_xor.val;
            }
        }
     /// <summary>
        /// 离线收益倍率
        /// </summary>
        public XorDouble offline_shouyi_xor;
     /// <summary>
        /// 离线收益倍率
        /// </summary>
        public double offline_shouyi{
            get{
                return offline_shouyi_xor.val;
            }
        }
     /// <summary>
        /// 每日免费日梦
        /// </summary>
        public XorInt free_rumeng_xor;
     /// <summary>
        /// 每日免费日梦
        /// </summary>
        public int free_rumeng{
            get{
                return free_rumeng_xor.val;
            }
        }
     /// <summary>
        /// 世界boss挂机刺出
        /// </summary>
        public XorInt worldboss_hook_xor;
     /// <summary>
        /// 世界boss挂机刺出
        /// </summary>
        public int worldboss_hook{
            get{
                return worldboss_hook_xor.val;
            }
        }
     /// <summary>
        /// 许愿池CD百分比
        /// </summary>
        public XorDouble vow_cd_des_xor;
     /// <summary>
        /// 许愿池CD百分比
        /// </summary>
        public double vow_cd_des{
            get{
                return vow_cd_des_xor.val;
            }
        }
     /// <summary>
        /// 购买跨服boss次数
        /// </summary>
        public XorInt buy_kuafu_boss_count_xor;
     /// <summary>
        /// 购买跨服boss次数
        /// </summary>
        public int buy_kuafu_boss_count{
            get{
                return buy_kuafu_boss_count_xor.val;
            }
        }
     /// <summary>
        /// 每日完成门派日常次数
        /// </summary>
        public XorInt menpai_richang_count_xor;
     /// <summary>
        /// 每日完成门派日常次数
        /// </summary>
        public int menpai_richang_count{
            get{
                return menpai_richang_count_xor.val;
            }
        }
     /// <summary>
        /// 天机快速作战次数
        /// </summary>
        public XorInt quick_tianyuan_boss_copy_xor;
     /// <summary>
        /// 天机快速作战次数
        /// </summary>
        public int quick_tianyuan_boss_copy{
            get{
                return quick_tianyuan_boss_copy_xor.val;
            }
        }
     /// <summary>
        /// 好友数量
        /// </summary>
        public XorInt friend_count_xor;
     /// <summary>
        /// 好友数量
        /// </summary>
        public int friend_count{
            get{
                return friend_count_xor.val;
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
            Debug.LogError("DictRechargeVip m_dict Is Null");
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
        return "dict_recharge_vip.txt";
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
            model.vip = DictTypeConvert.ParseString(str[fileReader.typeName2Index["vip"]]);
            model.upexp_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["upexp"]]),fileReader.randomUtil);
            model.spriteName = DictTypeConvert.ParseString(str[fileReader.typeName2Index["spriteName"]]);
            model.acce_battle_max_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["acce_battle_max"]]),fileReader.randomUtil);
            model.reset_shilian_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["reset_shilian_count"]]),fileReader.randomUtil);
            model.buy_shouling_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["buy_shouling_count"]]),fileReader.randomUtil);
            model.reset_normal_boss_copy_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["reset_normal_boss_copy"]]),fileReader.randomUtil);
            model.reset_tianyuan_boss_copy_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["reset_tianyuan_boss_copy"]]),fileReader.randomUtil);
            model.reset_tainji_boss_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["reset_tainji_boss_count"]]),fileReader.randomUtil);
            model.buy_world_boss_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["buy_world_boss_count"]]),fileReader.randomUtil);
            model.reset_pata_diff_copy_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["reset_pata_diff_copy"]]),fileReader.randomUtil);
            model.buy_pvp_battle_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["buy_pvp_battle_count"]]),fileReader.randomUtil);
            model.buy_menpai_boss_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["buy_menpai_boss_count"]]),fileReader.randomUtil);
            model.skip_battle_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["skip_battle"]]),fileReader.randomUtil);
            model.offline_shouyi_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["offline_shouyi"]]),fileReader.randomUtil);
            model.free_rumeng_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["free_rumeng"]]),fileReader.randomUtil);
            model.worldboss_hook_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["worldboss_hook"]]),fileReader.randomUtil);
            model.vow_cd_des_xor = new XorDouble(DictTypeConvert.ParseDouble(str[fileReader.typeName2Index["vow_cd_des"]]),fileReader.randomUtil);
            model.buy_kuafu_boss_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["buy_kuafu_boss_count"]]),fileReader.randomUtil);
            model.menpai_richang_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["menpai_richang_count"]]),fileReader.randomUtil);
            model.quick_tianyuan_boss_copy_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["quick_tianyuan_boss_copy"]]),fileReader.randomUtil);
            model.friend_count_xor = new XorInt( DictTypeConvert.ParseInt(str[fileReader.typeName2Index["friend_count"]]),fileReader.randomUtil);

            if (m_dict.ContainsKey(model.id) == false)
            {
                m_dict.Add(model.id, model);
                m_list.Add(model);
            }
            else
            {
                Debug.LogError("DictRechargeVip Parse:Same Key = " + model.id);
            }

        } while (true);

        if(m_loadFinishedCallBack != null)
        {
            m_loadFinishedCallBack(GetFileName());
        }
    }

}
