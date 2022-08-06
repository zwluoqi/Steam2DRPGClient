using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XZXD.UI;
using UnityEngine.UI;

public struct NormalAttributeData
{
	/// <summary>
	/// 物理伤害
	/// </summary>
	public double phy_attack;
	/// <summary>
	/// 法术提升
	/// </summary>
	public double mag_attack;

	/// <summary>
	/// 攻击速度
	/// </summary>
	public double attack_speed;
	/// <summary>
	/// 物理防御
	/// </summary>
	public double pyh_def;
	/// <summary>
	/// 法术防御
	/// </summary>
	public double mag_def;
	/// <summary>
	/// 生命上限
	/// </summary>
	public double add_maxhp;
	/// <summary>
	/// 法力上限
	/// </summary>
	public double add_maxmp;
	/// <summary>
	/// 移动速度
	/// </summary>
	public double move_speed;
	/// <summary>
	/// 内力
	/// </summary>
	public double neili;
	/// <summary>
	/// 筋骨
	/// </summary>
	public double jinggu;
	/// <summary>
	/// 身法
	/// </summary>
	public double shenfa;

	/// <summary>
	/// 武器系数
	/// </summary>
	public double weaponFactor;


    /// <summary>
    /// 吸血因子
    /// </summary>
    public double xixue_factor_radio;
    /// <summary>
    /// 命中
    /// </summary>
    public double hit_radio;
    /// <summary>
    /// 闪避
    /// </summary>
    public double miss_radio;
    /// <summary>
    /// 穿透
    /// </summary>
    public double pofang_radio;
    /// <summary>
    /// 暴击
    /// </summary>
    public double crit_radio;
    /// <summary>
    /// 暴击伤害
    /// </summary>
    public double crit_dmg_percent;
    /// <summary>
    /// 眩晕抗性
    /// </summary>
    public double unxuanyun;
    /// <summary>
    /// 禁锢抗性
    /// </summary>
    public double unjinggu;
    /// <summary>
    /// 昏睡抗性
    /// </summary>
    public double unhunshui;
    /// <summary>
    /// 封印抗性
    /// </summary>
    public double unfengyin;
    /// <summary>
    /// 禁法抗性
    /// </summary>
    public double unjinfa;
    /// <summary>
    /// 魅惑抗性
    /// </summary>
    public double unmeihuo;
	/// <summary>
	/// 虚弱抗性
	/// </summary>
	public double unxuruo;

	/// <summary>
	/// 武器攻击属性mask
	/// </summary>
	public int weaponAtkMask;

	public double dmg_add_per;

	public double dmg_des_per;

	public double dmg_fantan_radio;
	public double fantan_factor;

	public double kang_crit_radio;

	public double kang_crit_dmg_radio;

	/// <summary>
	/// 治疗比例
	/// </summary>
	public double treat_hp_per;

	/// <summary>
	/// 抗吸血率
	/// </summary>
	public double kang_xixue_radio;
	/// <summary>
	/// 双刀流
	/// </summary>
	public int shuangdaoliu;
	/// <summary>
	/// 增加行动数
	/// </summary>
	public int actionRound;
	/// <summary>
	/// 双手持
	/// </summary>
	public int shuangshouchi;

	/// <summary>
	/// 忽视闪避
	/// </summary>
	public double attack_no_miss_radio;

	/// <summary>
	/// 被击忽视命中
	/// </summary>
	public double behit_no_mingzhong_radio;

	/// <summary>
	/// 武器学习
	/// </summary>
	public int weapon_xuexi_mask ;


	public NormalAttributeData (DictAbility.Model model)
	{
		phy_attack = model.phy_attack;
		mag_attack = model.mag_attack;

		attack_speed = model.attack_speed;
		pyh_def = model.pyh_def;
		mag_def = model.mag_def;
		add_maxhp = model.add_maxhp;
		add_maxmp = model.add_maxmp;
		move_speed = model.move_speed;
		neili = model.neili;
		jinggu = model.jinggu;
		shenfa = model.shenfa;
		weaponFactor = 0;

        xixue_factor_radio = model.xixue_factor;
        hit_radio = model.hit_radio;
        miss_radio = model.miss_radio;
        pofang_radio = model.pofang_radio;
        crit_radio = model.crit_radio;
        crit_dmg_percent = model.crit_dmg_percent;
        unxuanyun = model.unxuanyun;
        unjinggu = model.unjinggu;
        unhunshui = model.unhunshui;
        unfengyin = model.unfengyin;
        unjinfa = model.unjinfa;
        unmeihuo = model.unmeihuo;
		unxuruo = model.unxuruo;

		weaponAtkMask = model.weaponAtkMask;

		dmg_add_per = model.dmg_add_per;
		dmg_des_per = model.dmg_des_per;
		dmg_fantan_radio = model.dmg_fantan;
		fantan_factor = model.fantan_factor;
		kang_crit_radio = model.kang_crit_radio;
		kang_crit_dmg_radio = model.kang_crit_dmg_radio;
		treat_hp_per = model.treat_hp_percent;

		kang_xixue_radio = 0;
		shuangdaoliu = model.shuangdaoliu;
		actionRound = model.action_round;
		shuangshouchi = 0;

		attack_no_miss_radio = model.attack_no_miss;
		behit_no_mingzhong_radio = model.behit_no_mingzhong;
		weapon_xuexi_mask = model.weapon_xuexi_mask;
	}

	public void Add (DictAbility.Model model)
	{

		this.phy_attack += model.phy_attack;
		this.mag_attack += model.mag_attack;

		this.attack_speed += model.attack_speed;
		this.pyh_def += model.pyh_def;
		this.mag_def += model.mag_def;
		this.add_maxhp += model.add_maxhp;
		this.add_maxmp += model.add_maxmp;
		this.move_speed += model.move_speed;
		this.neili += model.neili;
		this.jinggu += model.jinggu;
		this.shenfa += model.shenfa;
		this.weaponFactor += 0;

        this.xixue_factor_radio += model.xixue_factor;
        this.hit_radio += model.hit_radio;
        this.miss_radio += model.miss_radio;
        this.pofang_radio += model.pofang_radio;
        this.crit_radio += model.crit_radio;
        this.crit_dmg_percent += model.crit_dmg_percent;
        this.unxuanyun += model.unxuanyun;
        this.unjinggu += model.unjinggu;
        this.unhunshui += model.unhunshui;
        this.unfengyin += model.unfengyin;
        this.unjinfa += model.unjinfa;
        this.unmeihuo += model.unmeihuo;
		this.unxuruo += model.unxuruo;

		weaponAtkMask |= model.weaponAtkMask;

		dmg_add_per += model.dmg_add_per;
		dmg_des_per += model.dmg_des_per;
		dmg_fantan_radio += model.dmg_fantan;
		kang_crit_radio += model.kang_crit_radio;
		kang_crit_dmg_radio += model.kang_crit_dmg_radio;
		treat_hp_per += model.treat_hp_percent;

		kang_xixue_radio += 0;
		shuangdaoliu += model.shuangdaoliu;
		actionRound += model.action_round;
//		shuangshouchi += model.shuangshouchi;

		attack_no_miss_radio += model.attack_no_miss;
		behit_no_mingzhong_radio += model.behit_no_mingzhong;
		weapon_xuexi_mask |= model.weapon_xuexi_mask;
	}

    public void Add(DictEquipEquip.Model model){
        this.phy_attack += model.phy_attack;
        this.mag_attack += model.mag_attack;
        this.attack_speed += model.attack_speed;
        this.pyh_def += model.pyh_def;
        this.mag_def += model.mag_def;
        this.add_maxhp += model.add_maxhp;
        this.add_maxmp += model.add_maxmp;
        this.move_speed += model.move_speed;
        this.neili += model.neili;
        this.jinggu += model.jinggu;
        this.shenfa += model.shenfa;
        this.weaponFactor += model.weapon_facor;

        this.xixue_factor_radio += model.xixue_factor;
        this.hit_radio += model.hit_radio;
        this.miss_radio += model.miss_radio;
        this.pofang_radio += model.pofang_radio;
        this.crit_radio += model.crit_radio;
        this.crit_dmg_percent += model.crit_dmg_percent;
        this.unxuanyun += model.unxuanyun;
        this.unjinggu += model.unjinggu;
        this.unhunshui += model.unhunshui;
        this.unfengyin += model.unfengyin;
        this.unjinfa += model.unjinfa;
        this.unmeihuo += model.unmeihuo;
		this.unxuruo += model.unxuruo;

        weaponAtkMask |= model.weaponAtkMask;

		dmg_add_per += model.dmg_add_per;
		dmg_des_per += model.dmg_des_per;
		dmg_fantan_radio += model.dmg_fantan;
		kang_crit_radio += model.kang_crit_radio;
		kang_crit_dmg_radio += model.kang_crit_dmg_radio;
		treat_hp_per += model.treat_hp_per;

		kang_xixue_radio += 0;
		shuangdaoliu += model.shuangdaoliu;
		actionRound += model.action_round;
		shuangshouchi += model.shuangshouchi;

		attack_no_miss_radio += 0;
		behit_no_mingzhong_radio += 0;
//		weapon_xuexi_mask |= model.weapon_xuexi_mask;
    }

            


	public void Add (NormalAttributeData model)
	{

		this.phy_attack += model.phy_attack;
		this.mag_attack += model.mag_attack;

		this.attack_speed += model.attack_speed;
		this.pyh_def += model.pyh_def;
		this.mag_def += model.mag_def;
		this.add_maxhp += model.add_maxhp;
		this.add_maxmp += model.add_maxmp;
		this.move_speed += model.move_speed;
		this.neili += model.neili;
		this.jinggu += model.jinggu;
		this.shenfa += model.shenfa;
		this.weaponFactor += model.weaponFactor;

        this.xixue_factor_radio += model.xixue_factor_radio;
        this.hit_radio += model.hit_radio;
        this.miss_radio += model.miss_radio;
        this.pofang_radio += model.pofang_radio;
        this.crit_radio += model.crit_radio;
        this.crit_dmg_percent += model.crit_dmg_percent;
        this.unxuanyun += model.unxuanyun;
        this.unjinggu += model.unjinggu;
        this.unhunshui += model.unhunshui;
        this.unfengyin += model.unfengyin;
        this.unjinfa += model.unjinfa;
        this.unmeihuo += model.unmeihuo;
		this.unxuruo += model.unxuruo;

		weaponAtkMask |= model.weaponAtkMask;

		dmg_add_per += model.dmg_add_per;
		dmg_des_per += model.dmg_des_per;
		dmg_fantan_radio += model.dmg_fantan_radio;
		kang_crit_radio += model.kang_crit_radio;
		kang_crit_dmg_radio += model.kang_crit_dmg_radio;
		treat_hp_per += model.treat_hp_per;

		kang_xixue_radio += model.kang_xixue_radio;
		shuangdaoliu += model.shuangdaoliu;
		actionRound += model.actionRound;
		shuangshouchi += model.shuangshouchi;

		attack_no_miss_radio += model.attack_no_miss_radio;
		behit_no_mingzhong_radio += model.behit_no_mingzhong_radio;
		weapon_xuexi_mask |= model.weapon_xuexi_mask;
	}

	public void Add (int lev)
	{
		this.phy_attack += lev;
		this.mag_attack += lev;


		this.attack_speed += lev;
		this.pyh_def += lev;
		this.mag_def += lev;
		this.add_maxhp += lev;
		this.add_maxmp += lev;
		this.move_speed += lev;
		this.neili += lev;
		this.jinggu += lev;
		this.shenfa += lev;
		this.weaponFactor += lev;

		this.xixue_factor_radio += lev;
		this.hit_radio += lev;
		this.miss_radio += lev;
		this.pofang_radio += lev;
		this.crit_radio += lev;
		this.crit_dmg_percent += lev;
		this.unxuanyun += lev;
		this.unjinggu += lev;
		this.unhunshui += lev;
		this.unfengyin += lev;
		this.unjinfa += lev;
		this.unmeihuo += lev;
		this.unxuruo += lev;


		dmg_add_per += lev;
		dmg_des_per += lev;
		dmg_fantan_radio += lev;
		kang_crit_radio += lev;
		kang_crit_dmg_radio += lev;
		treat_hp_per += lev;

		kang_xixue_radio += lev;
		shuangdaoliu += lev;
		actionRound += lev;
		shuangshouchi += lev;

		attack_no_miss_radio += lev;
		behit_no_mingzhong_radio += lev;

	}

	public void Des (NormalAttributeData model)
	{
		this.phy_attack -= model.phy_attack;
		this.mag_attack -= model.mag_attack;


		this.attack_speed -= model.attack_speed;
		this.pyh_def -= model.pyh_def;
		this.mag_def -= model.mag_def;
		this.add_maxhp -= model.add_maxhp;
		this.add_maxmp -= model.add_maxmp;
		this.move_speed -= model.move_speed;
		this.neili -= model.neili;
		this.jinggu -= model.jinggu;
		this.shenfa -= model.shenfa;
		this.weaponFactor -= model.weaponFactor;

        this.xixue_factor_radio -= model.xixue_factor_radio;
        this.hit_radio -= model.hit_radio;
        this.miss_radio -= model.miss_radio;
        this.pofang_radio -= model.pofang_radio;
        this.crit_radio -= model.crit_radio;
        this.crit_dmg_percent -= model.crit_dmg_percent;
        this.unxuanyun -= model.unxuanyun;
        this.unjinggu -= model.unjinggu;
        this.unhunshui -= model.unhunshui;
        this.unfengyin -= model.unfengyin;
        this.unjinfa -= model.unjinfa;
        this.unmeihuo -= model.unmeihuo;
		this.unxuruo -= model.unxuruo;

		dmg_add_per -= model.dmg_add_per;
		dmg_des_per -= model.dmg_des_per;
		dmg_fantan_radio -= model.dmg_fantan_radio;
		kang_crit_radio -= model.kang_crit_radio;
		kang_crit_dmg_radio -= model.kang_crit_dmg_radio;
		treat_hp_per -= model.treat_hp_per;

		kang_xixue_radio -= model.kang_xixue_radio;
		shuangdaoliu -= model.shuangdaoliu;
		actionRound -= model.actionRound;
		shuangshouchi -= model.shuangshouchi;

		attack_no_miss_radio -= model.attack_no_miss_radio;
		behit_no_mingzhong_radio -= model.behit_no_mingzhong_radio;

	}


	public void Multiple(float lev){
		this.phy_attack *= lev;
		this.mag_attack *= lev;


		this.attack_speed *= lev;
		this.pyh_def *= lev;
		this.mag_def *= lev;
		this.add_maxhp *= lev;
		this.add_maxmp *= lev;
		this.move_speed *= lev;
		this.neili *= lev;
		this.jinggu *= lev;
		this.shenfa *= lev;
		this.weaponFactor *= lev;

		this.xixue_factor_radio *= lev;
		this.hit_radio *= lev;
		this.miss_radio *= lev;
		this.pofang_radio *= lev;
		this.crit_radio *= lev;
		this.crit_dmg_percent *= lev;
		this.unxuanyun *= lev;
		this.unjinggu *= lev;
		this.unhunshui *= lev;
		this.unfengyin *= lev;
		this.unjinfa *= lev;
		this.unmeihuo *= lev;
		this.unxuruo *= lev;


		dmg_add_per *= lev;
		dmg_des_per *= lev;
		dmg_fantan_radio *= lev;
		kang_crit_radio *= lev;
		kang_crit_dmg_radio *= lev;
		treat_hp_per *= lev;


		kang_xixue_radio *= lev;
		shuangdaoliu = Mathf.RoundToInt(shuangdaoliu*lev);
		actionRound = Mathf.RoundToInt (actionRound * lev);
		shuangshouchi = Mathf.RoundToInt (shuangshouchi * lev);

		attack_no_miss_radio *= lev;
		behit_no_mingzhong_radio *= lev;

	}

	public void Multiple (NormalAttributeData model)
	{

		this.phy_attack *= model.phy_attack;
		this.mag_attack *= model.mag_attack;

		this.attack_speed *= model.attack_speed;
		this.pyh_def *= model.pyh_def;
		this.mag_def *= model.mag_def;
		this.add_maxhp *= model.add_maxhp;
		this.add_maxmp *= model.add_maxmp;
		this.move_speed *= model.move_speed;
		this.neili *= model.neili;
		this.jinggu *= model.jinggu;
		this.shenfa *= model.shenfa;
		this.weaponFactor *= model.weaponFactor;

		this.xixue_factor_radio *= model.xixue_factor_radio;
		this.hit_radio *= model.hit_radio;
		this.miss_radio *= model.miss_radio;
		this.pofang_radio *= model.pofang_radio;
		this.crit_radio *= model.crit_radio;
		this.crit_dmg_percent *= model.crit_dmg_percent;
		this.unxuanyun *= model.unxuanyun;
		this.unjinggu *= model.unjinggu;
		this.unhunshui *= model.unhunshui;
		this.unfengyin *= model.unfengyin;
		this.unjinfa *= model.unjinfa;
		this.unmeihuo *= model.unmeihuo;
		this.unxuruo *= model.unxuruo;

//		weaponAtkMask |= model.weaponAtkMask;

		dmg_add_per *= model.dmg_add_per;
		dmg_des_per *= model.dmg_des_per;
		dmg_fantan_radio *= model.dmg_fantan_radio;
		kang_crit_radio *= model.kang_crit_radio;
		kang_crit_dmg_radio *= model.kang_crit_dmg_radio;
		treat_hp_per *= model.treat_hp_per;

		kang_xixue_radio *= model.kang_xixue_radio;
		shuangdaoliu *= model.shuangdaoliu;
		actionRound *= model.actionRound;
		shuangshouchi *= model.shuangshouchi;

		attack_no_miss_radio *= model.attack_no_miss_radio;
		behit_no_mingzhong_radio *= model.behit_no_mingzhong_radio;
//		weapon_xuexi_mask |= model.weapon_xuexi_mask;
	}

	public void Reset ()
	{
		phy_attack = 0;
		mag_attack = 0;

		attack_speed = 0;
		pyh_def = 0;
		mag_def = 0;
		add_maxhp = 0;
		add_maxmp = 0;
		move_speed = 0;
		neili = 0;
		jinggu = 0;
		shenfa = 0;
		weaponFactor = 0;

        xixue_factor_radio = 0;
        hit_radio = 0;
        miss_radio = 0;
        pofang_radio = 0;
        crit_radio =0;
        crit_dmg_percent =0;
        unxuanyun = 0;
        unjinggu = 0;
        unhunshui = 0;
        unfengyin = 0;
        unjinfa = 0;
        unmeihuo = 0;
		unxuruo = 0;

		weaponAtkMask = 1;

		dmg_add_per = 0;
		dmg_des_per = 0;
		dmg_fantan_radio =  0;
		kang_crit_radio =  0;
		kang_crit_dmg_radio =  0;
		treat_hp_per =  0;

		kang_xixue_radio = 0;
		shuangdaoliu = 0;
		actionRound = 0;
		shuangshouchi = 0;

		attack_no_miss_radio = 0;
		behit_no_mingzhong_radio = 0;

		weapon_xuexi_mask = 0;
	}
}


