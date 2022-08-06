namespace Game.View.Hero
{
    [System.Serializable]
    public class HeroBattleDataUtil
    {
        public DataAttribute attack = new DataAttribute ();
        public DataAttribute defence = new DataAttribute ();
        

        public DataAttribute maxHP = new DataAttribute ();
        public DataAttribute maxMp = new DataAttribute ();
        public DataAttribute maxAngle = new DataAttribute ();
        public DataAttribute maxNaili = new DataAttribute ();

        
        
        public int hp;
        public int mp = 0;
        public int angle = 0;
        public int naili = 0;
        
        public double hpPercent {
            get {
                return hp / maxHpVal;
            }
        }
        public double attackVal {
            get {
                return attack.value ;	
            }
        }

        public double defenceVal {
            get {
                return defence.value;
            }
        }

        public double maxHpVal {
            get {
                return maxHP.value ;
            }
        }

        public double maxMpVal {
            get {
                return maxMp.value ;
            }
        }


        public float moveSpeed
        {
            get
            {
                return (float) propVals[(int) DictHeroExportPropEnum.move_speed];
            }
        }


        double[] propVals = new double[128];
        /// <summary>
        /// 攻击类型加持
        /// </summary>
        public int atkTypeMask;


        /// <summary>
        /// 强迫攻击目标
        /// </summary>
        public ViewHero mustAtkTarget { get; set; }


        public void Init(ViewHero viewHero)
        {
            var config = viewHero.heroConfig.heroAttributeConfig;
            propVals[(int) DictHeroExportPropEnum.move_speed] = config.curSpeed;
            maxHP.ResetBaseVal(config.maxHP);
            maxMp.ResetBaseVal(config.maxMp);
            maxAngle.ResetBaseVal(config.maxAngle);
            maxNaili.ResetBaseVal(config.maxNaili);
            hp = (int)maxHP.value;
            mp = (int)maxMp.value;
            angle = (int)maxAngle.value;
            naili = (int)maxNaili.value;
            for (int i = 0; i < config.attributes.Length; i++)
            {
                propVals[(int)config.attributes[i].prop] = config.attributes[i].val;
            }
        }
        
        public void AddMeihuo ()
        {
//			this.meihuo++;
            propVals[(int)DictHeroExportPropEnum.Meihuo]+=1;
            // enemyIsPlayer = this.isPlayer;
        }

        public void DesMeihuo()
        {
            propVals[(int)DictHeroExportPropEnum.Meihuo]-=1;
        }

        public void ResumeVal(DictHeroExportPropEnum propId, double buffPropTotalVal)
        {
            if (propId ==  DictHeroExportPropEnum.hp)
            {
                hp-= (int)buffPropTotalVal;
            }else if (propId == DictHeroExportPropEnum.mp)
            {
                mp-= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.angle)
            {
                angle-= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.naili)
            {
                naili-= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.ATK)
            {
                // return attackVal;
            }
            else if (propId == DictHeroExportPropEnum.DEF)
            {
                // return defenceVal;
            }
            else
            {
                this.propVals[(int)propId] -= buffPropTotalVal;
            }
        }

        public void AddVal(DictHeroExportPropEnum propId, double buffPropTotalVal)
        {
            if (propId ==  DictHeroExportPropEnum.hp)
            {
                hp+= (int)buffPropTotalVal;
            }else if (propId == DictHeroExportPropEnum.mp)
            {
                mp+= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.angle)
            {
                angle+= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.naili)
            {
                naili+= (int)buffPropTotalVal;
            }
            else if (propId == DictHeroExportPropEnum.ATK)
            {
                // return attackVal;
            }
            else if (propId == DictHeroExportPropEnum.DEF)
            {
                // return defenceVal;
            }
            else
            {
                this.propVals[(int)propId] += buffPropTotalVal;
            }
        }
        public double GetPropVal(DictHeroExportPropEnum propId){
            if (propId ==  DictHeroExportPropEnum.hp)
            {
                return hp;
            }else if (propId == DictHeroExportPropEnum.mp)
            {
                return mp;
            }
            else if (propId == DictHeroExportPropEnum.angle)
            {
                return angle;
            }
            else if (propId == DictHeroExportPropEnum.naili)
            {
                return naili;
            }
            else if (propId == DictHeroExportPropEnum.ATK)
            {
                return attackVal;
            }
            else if (propId == DictHeroExportPropEnum.DEF)
            {
                return defenceVal;
            }
            return propVals [(int)propId];
        }
    }
}