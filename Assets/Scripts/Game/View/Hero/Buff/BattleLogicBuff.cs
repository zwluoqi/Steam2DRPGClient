// /*
//                #########
//               ############
//               #############
//              ##  ###########
//             ###  ###### #####
//             ### #######   ####
//            ###  ########## ####
//           ####  ########### ####
//          ####   ###########  #####
//         #####   ### ########   #####
//        #####   ###   ########   ######
//       ######   ###  ###########   ######
//      ######   #### ##############  ######
//     #######  #####################  ######
//     #######  ######################  ######
//    #######  ###### #################  ######
//    #######  ###### ###### #########   ######
//    #######    ##  ######   ######     ######
//    #######        ######    #####     #####
//     ######        #####     #####     ####
//      #####        ####      #####     ###
//       #####       ###        ###      #
//         ###       ###        ###
//          ##       ###        ###
// __________#_______####_______####______________
//
//                 我们的未来没有BUG
// * ==============================================================================
// * Filename:BattleLogicBuff.cs
// * Created:2017/12/1
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using Battle.Logic;
using Game.View.Hero;

namespace Game.View.Buff
{
	public class BattleLogicBuff
	{
		public enum BuffLogicType
		{
			Normal,
			ClearBuff,
		}
		public enum BuffInflunceType
		{
			Add,
			Des,
			Normal,
		}
		public ViewHero buffSource;
		public ViewHero buffTarget;

		public List<BattleLogicBuffProp> props;

		public DictHeroBuff.Model modelData {
			get {
				return DictDataManager.Instance.dictHeroBuff.GetModel (buffId);
			}
		}

		public string buffId;
		public int buffLev;


		public void Init (int level,string buff_id)
		{
			this.buffId = buff_id;	
			this.buffLev = Math.Min (100, level);
		}

		public long guid;

		public void LoadBuff (ViewHero source, ViewHero target, ref BattleLogicOneSkillExport data)
		{
			this.guid = DisplayPool.GET_GUID;
			this.buffSource = source;
			this.buffTarget = target;

			this.props = new List<BattleLogicBuffProp> ();

			if (modelData.buff_props_per.Count > 1) {
				double[] startRadios = new double[modelData.buff_props_per.Count];
				double[] endRadios = new double[modelData.buff_props_per.Count];
				double startRadio = 0;
				string valPropId ="";
				double val = source.viewManager.randomUtil.value;
				for (int i=0;i< modelData.buff_props_per.Count;i++) {
					if (val > startRadio && val <= startRadio + modelData.buff_props_per [i]) {
						valPropId = modelData.buff_props [i];
						AddProps (valPropId);
						break;
					}
					startRadio += modelData.buff_props_per [i];
				}
			} else {
				foreach (var propId in modelData.buff_props) {
					AddProps (propId);
				}
			}

			BattleLogicExportBuff exbuff = new BattleLogicExportBuff ();
			exbuff.sourceGUID = source.guid;
			exbuff.targetGUID = target.guid;
			exbuff.buffId = buffId;
			exbuff.buffGUID = guid;
			data.loadBuffs.Add (exbuff);

			ViewManager viewManager = this.buffSource.viewManager;

			BeginEffect (ref data);
			if (this.modelData.round > 0) {
				this.buffSource.viewManager.timeEventManager.CreateEvent (OnRoundDone, this.modelData.round);
			} else {
				UnLoadBuff (ref data);
			}
		}

		void BeginEffect (ref  BattleLogicOneSkillExport data)
		{
			EffectOnce (ref data);
			if (this.modelData.space_round > 0) {
				this.buffSource.viewManager.timeEventManager.CreateEvent (OnRound, this.modelData.space_round);
			}
		}

		void OnRound ()
		{
			BattleLogicOneSkillExport data = new BattleLogicOneSkillExport ();
			data.attackGUID = this.buffSource.guid;
			data.timer = this.buffSource.viewManager.timer;
			data.buff = this;

			ViewManager viewManager = this.buffSource.viewManager;
			EffectOnce (ref data);
			this.buffSource.viewManager.timeEventManager.CreateEvent (OnRound, this.modelData.space_round);

			viewManager.AddSkillExport (data);
		}

		void OnRoundDone ()
		{
			BattleLogicOneSkillExport data = new BattleLogicOneSkillExport ();
			data.attackGUID = this.buffSource.guid;
			data.timer = this.buffSource.viewManager.timer;
			data.buff = this;
			ViewManager viewManager = this.buffSource.viewManager;

			UnLoadBuff (ref data);
			viewManager.AddSkillExport (data);
		}



		void EffectOnce (ref  BattleLogicOneSkillExport data)
		{
			data.buffTriggers.Add (this.guid);
			foreach (var buffProp in props) {
				BattleLogicExportProp exProp = new BattleLogicExportProp ();
				exProp.attackGUID = this.buffSource.guid;
				exProp.defenceGUID = this.buffTarget.guid;
				exProp.sourceBuff = this;
                exProp.dictBuffPropId = buffProp.dictBuffPropId;

				bool skip = false;
				switch ((DictHeroExportPropEnum)buffProp.propId) {
				case DictHeroExportPropEnum.hp:
					if (buffTarget.heroBattleDataUtil.GetPropVal(DictHeroExportPropEnum.Fengyin) > 0) {
						skip = true;
					} else {
						double value = 0;
						if (buffProp.percent) {
							value = buffProp.val * this.buffTarget.heroBattleDataUtil.maxHpVal;
						} else {
							value = buffProp.val;
						}
						if (buffProp.val > 0) {
							this.buffTarget.OnBeTreat (this.buffSource, value, ref exProp);
						} else {
							this.buffTarget.OnBeDMG (this.buffSource, -value, ref exProp);
						}
					}
					break;
				case DictHeroExportPropEnum.DEF:
					if (buffProp.percent) {
						this.buffTarget.heroBattleDataUtil.defence.AddCurrentRadio (buffProp.val);
					} else {
						this.buffTarget.heroBattleDataUtil.defence.AddNormalVal (buffProp.val);
					}
					buffProp.totalVal += buffProp.val;
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.ATK:
					if (buffProp.percent) {
						this.buffTarget.heroBattleDataUtil.attack.AddCurrentRadio (buffProp.val);
					} else {
						this.buffTarget.heroBattleDataUtil.attack.AddNormalVal (buffProp.val);
					}
					buffProp.totalVal += buffProp.val;
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;

				// case DictHeroExportPropEnum.shenfa:
				// 	this.buffTarget.heroBattleDataUtil.shenfa.AddNormalVal (buffProp.val);
				// 	buffProp.totalVal += buffProp.val;
				// 	exProp.value = buffProp.val;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				// case DictHeroExportPropEnum.neili:
				// 	this.buffTarget.heroBattleDataUtil.neili.AddNormalVal (buffProp.val);
				// 	buffProp.totalVal += buffProp.val;
				// 	exProp.value = buffProp.val;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				// case DictHeroExportPropEnum.jingu:
				// 	this.buffTarget.heroBattleDataUtil.jingu.AddNormalVal (buffProp.val);
				// 	buffProp.totalVal += buffProp.val;
				// 	exProp.value = buffProp.val;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				case DictHeroExportPropEnum.Meihuo:
					this.buffTarget.heroBattleDataUtil.AddMeihuo ();
					buffProp.totalVal += buffProp.val;
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.hp_max:
					this.buffTarget.heroBattleDataUtil.maxHP.AddNormalVal (buffProp.val);
					buffProp.totalVal += buffProp.val;
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.hp_max_percent:
					this.buffTarget.heroBattleDataUtil.maxHP.AddCurrentRadio (buffProp.val);
					buffProp.totalVal += buffProp.val;
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;

				case DictHeroExportPropEnum.atk_shuxing:
					this.buffTarget.heroBattleDataUtil.atkTypeMask |= buffProp.intVal; 
					exProp.value = buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.ATK_SPEED:
					AddVal (buffProp, exProp);
					// buffSource.viewManager.RequestOrder ();
					break;
				case DictHeroExportPropEnum.chaofeng:
					AddVal (buffProp, exProp);
					this.buffTarget.heroBattleDataUtil.mustAtkTarget = this.buffSource;
					break;
				case DictHeroExportPropEnum.shanbi:
				case DictHeroExportPropEnum.jingzhi:
				case DictHeroExportPropEnum.Xuanyun:
				case DictHeroExportPropEnum.HunShui:
				case DictHeroExportPropEnum.Fengyin:
				case DictHeroExportPropEnum.JinFa:
				case DictHeroExportPropEnum.XuRuo:
				case DictHeroExportPropEnum.CLOAKING:
				case DictHeroExportPropEnum.RENSHUBIAOJI:
				case DictHeroExportPropEnum.crit_radio:
				case DictHeroExportPropEnum.crit_damage_percent:
				case DictHeroExportPropEnum.unjingu:
				case DictHeroExportPropEnum.unXuanyun:
				case DictHeroExportPropEnum.unHunshui:
				case DictHeroExportPropEnum.unXuruo:
				case DictHeroExportPropEnum.unMeihuo:
				case DictHeroExportPropEnum.unJinfa:
				case DictHeroExportPropEnum.unFengyin:
				case DictHeroExportPropEnum.XIXUE_Factor:

				case DictHeroExportPropEnum.dmg_add_per:
				case DictHeroExportPropEnum.dmg_des_per:
				case DictHeroExportPropEnum.dmg_fantan:

//				case DictHeroExportPropEnum.chaofeng:
				case DictHeroExportPropEnum.dui_qianpai_yinshen:
				case DictHeroExportPropEnum.dui_houpai_yinshen:
				case DictHeroExportPropEnum.treat_per:
				case DictHeroExportPropEnum.kang_crit_per:
				case DictHeroExportPropEnum.kang_crit_dmg_per:
				case DictHeroExportPropEnum.mianyi_buff:
				case DictHeroExportPropEnum.mianyi_dead:
					AddVal (buffProp,exProp);
					break;
				default:
					UnityEngine.Debug.LogError ("不支持buff prop:" + buffProp.propId);
//					skip = true;
					AddVal (buffProp,exProp);
					break;
				}
				if (skip) {
                    
				} else {
					data.props.Add (exProp);
					// this.buffTarget.FreshAttribute ();
				}
			}
		}

		void EndEffect (ref  BattleLogicOneSkillExport data)
		{
			foreach (var buffProp in props) {
				BattleLogicExportProp exProp = new BattleLogicExportProp ();
				exProp.attackGUID = this.buffSource.guid;
				exProp.defenceGUID = this.buffTarget.guid;
				exProp.sourceBuff = this;
                exProp.dictBuffPropId = buffProp.dictBuffPropId;

				bool skip = false;
				switch ((DictHeroExportPropEnum)buffProp.propId) {
				case DictHeroExportPropEnum.hp:
					skip = true;
					break;
				case DictHeroExportPropEnum.DEF:
					if (buffProp.percent) {
						this.buffTarget.heroBattleDataUtil.defence.AddCurrentRadio (-buffProp.totalVal);
					} else {
						this.buffTarget.heroBattleDataUtil.defence.AddNormalVal (-buffProp.totalVal);
					}
					exProp.value = -buffProp.totalVal;
					exProp.propID =(DictHeroExportPropEnum) buffProp.propId;
					break;
				case DictHeroExportPropEnum.ATK:
					if (buffProp.percent) {
						this.buffTarget.heroBattleDataUtil.attack.AddCurrentRadio (-buffProp.totalVal);
					} else {
						this.buffTarget.heroBattleDataUtil.attack.AddNormalVal (-buffProp.totalVal);
					}
					exProp.value = -buffProp.totalVal;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				// case DictHeroExportPropEnum.shenfa:
				// 	this.buffTarget.heroBattleDataUtil.shenfa.AddNormalVal (-buffProp.totalVal);
				// 	exProp.value = -buffProp.totalVal;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				// case DictHeroExportPropEnum.neili:
				// 	this.buffTarget.heroBattleDataUtil.neili.AddNormalVal (-buffProp.totalVal);
				// 	exProp.value = -buffProp.totalVal;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				// case DictHeroExportPropEnum.jingu:
				// 	this.buffTarget.heroBattleDataUtil.jingu.AddNormalVal (-buffProp.totalVal);
				// 	exProp.value = -buffProp.totalVal;
				// 	exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
				// 	break;
				case DictHeroExportPropEnum.Meihuo:
					this.buffTarget.heroBattleDataUtil.DesMeihuo ();
					exProp.value = -buffProp.totalVal;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.hp_max:
					this.buffTarget.heroBattleDataUtil.maxHP.AddNormalVal (-buffProp.totalVal);
					exProp.value = -buffProp.totalVal;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.hp_max_percent:
					this.buffTarget.heroBattleDataUtil.maxHP.AddCurrentRadio (-buffProp.totalVal);
					exProp.value = -buffProp.totalVal;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
					break;
				case DictHeroExportPropEnum.atk_shuxing:
                    this.buffTarget.heroBattleDataUtil.atkTypeMask &= ~buffProp.intVal;
                    exProp.value = -buffProp.val;
					exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
                    break;
				case DictHeroExportPropEnum.ATK_SPEED:
					ResumeVal (buffProp, exProp);
					// buffSource.viewManager.RequestOrder ();
					break;
				case DictHeroExportPropEnum.chaofeng:
					ResumeVal (buffProp, exProp);
					this.buffTarget.heroBattleDataUtil.mustAtkTarget = null;
					break;
				case DictHeroExportPropEnum.shanbi:
				case DictHeroExportPropEnum.jingzhi:
				case DictHeroExportPropEnum.Xuanyun:
				case DictHeroExportPropEnum.HunShui:
				case DictHeroExportPropEnum.Fengyin:
				case DictHeroExportPropEnum.JinFa:
				case DictHeroExportPropEnum.XuRuo:
				case DictHeroExportPropEnum.CLOAKING:
				case DictHeroExportPropEnum.RENSHUBIAOJI:
				case DictHeroExportPropEnum.crit_radio:
				case DictHeroExportPropEnum.crit_damage_percent:
				case DictHeroExportPropEnum.unjingu:
				case DictHeroExportPropEnum.unXuanyun:
				case DictHeroExportPropEnum.unHunshui:
				case DictHeroExportPropEnum.unXuruo:
				case DictHeroExportPropEnum.unMeihuo:
				case DictHeroExportPropEnum.unJinfa:
				case DictHeroExportPropEnum.unFengyin:
				case DictHeroExportPropEnum.XIXUE_Factor:


				case DictHeroExportPropEnum.dmg_add_per:
				case DictHeroExportPropEnum.dmg_des_per:
				case DictHeroExportPropEnum.dmg_fantan:
//				case DictHeroExportPropEnum.chaofeng:
				case DictHeroExportPropEnum.dui_qianpai_yinshen:
				case DictHeroExportPropEnum.dui_houpai_yinshen:
				case DictHeroExportPropEnum.treat_per:
				case DictHeroExportPropEnum.kang_crit_per:
				case DictHeroExportPropEnum.kang_crit_dmg_per:
				case DictHeroExportPropEnum.mianyi_buff:
				case DictHeroExportPropEnum.mianyi_dead:
					ResumeVal (buffProp,exProp);
					break;
				default :
                        UnityEngine.Debug.LogError("不支持buff prop:" + buffProp.propId);
//					skip = true;
					ResumeVal (buffProp,exProp);
					break;
					
				}
				if (skip == false) {
					data.props.Add (exProp);
					// this.buffTarget.FreshAttribute ();
				}
			}
		}


		public void UnLoadBuff (ref BattleLogicOneSkillExport data)
		{
			EndEffect (ref data);
			data.unloadBuffs.Add (this.guid);
		}

		void AddVal ( BattleLogicBuffProp buffProp,BattleLogicExportProp exProp)
		{
			this.buffTarget.heroBattleDataUtil.AddVal((DictHeroExportPropEnum)buffProp.propId,buffProp.val);
			buffProp.totalVal += buffProp.val;
			exProp.value = buffProp.val;
			exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
		}

		void ResumeVal (BattleLogicBuffProp buffProp,BattleLogicExportProp exProp)
		{
			this.buffTarget.heroBattleDataUtil.ResumeVal((DictHeroExportPropEnum)buffProp.propId, buffProp.totalVal);
			exProp.value = -buffProp.totalVal;
			exProp.propID = (DictHeroExportPropEnum)buffProp.propId;
		}

		void AddProps (string propId)
		{

			var propModel = DictDataManager.Instance.dictHeroBuffProp.GetModel (propId);
			BattleLogicBuffProp propData = new BattleLogicBuffProp ();
			propData.propId = propModel.buff_prop_int;
			propData.val = (propModel.base_val + propModel.lev_add_val * this.buffLev);
			propData.dictBuffPropId = propId;
			propData.export = propModel.show > 0;
			propData.percent = propModel.percent > 0;
			this.props.Add (propData);
		}

	}

	public class BattleLogicBuffProp
	{
        public int intVal{
            get{
                return (int)val;
            }
        }
		public double val = 0;
		public double totalVal = 0;
		public int propId;
        public string dictBuffPropId;
		public bool export = true;
		public bool percent = false;
    }
}
