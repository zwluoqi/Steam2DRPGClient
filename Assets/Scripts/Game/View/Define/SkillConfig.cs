using UnityEngine;

namespace Game.View
{


    
    [CreateAssetMenu(fileName = "skill_config_", menuName = "ScriptableObjects/SkillConfig", order = 1)]
    public class SkillConfig:ScriptableObject
    {
        public string animName = "attack";
        public EffectConfig skillEffectConfig;
        public SkillType skillType;
        
        [Header("释放时长")]
        public float duration;
        [Header("开始可插入时机")]
        public float insertStartTime;
        [Header("禁止可插入时机")]
        public float insertEndTime;
        [Header("技能释放过程中可以移动")]
        public bool couldMove;
        [Header("技能抛射物体")]
        public SkillProjectorConfig[] skillProjectorConfigs;
        [Header("释放技能过程中移动")]
        public SkillMoveConfig[] skillMoveConfigs;
        [Header("索敌范围")]
        public float searchRadius = 6;
        [Header("冷却时间")]
        public float coolDown = 0;
        [Header("连招重置时间")]
        public float skillGroupResetDuration = 1.0f;
        [Header("碰撞区域内多长时间受击一次")]
        public float spaceHitTimer = 0;
        [Header("技能描述")]
        public string desc;
        [Header("施法消耗属性")]
        public HeroAttribute[] costAttribute = new HeroAttribute[0];
        [Header("施法过程中每秒消耗属性")]
        public HeroAttribute[] costAttributePerSecond= new HeroAttribute[0];
        [Header("触发被动技能")]
        public SkillGroupConfig triggerPassiveSkill;
    }

    [System.Serializable]
    public class SkillMoveConfig
    {
        public float moveTime = 0;
        public float duration = 0.2f;
        [Header("移动速度")] public float moveSpeed = 15;
        [Header("加速度")] public float accSpeedPerSecond = 0;
        [Header("加速时间")] public float accSpeedPerTime = 0;
        [Header("角速度")] public float rotationAngleSpeed = 0;
        
        [Header("被动移动,0当前没有方向控制也能移动,1当前有方向控制才能进行移动")]
        public bool avtiveMove = false;

        [Header("移动具有穿透性")]
        public bool traversal = false;
    }

    [System.Serializable]
    public class EffectConfig
    {
        /// <summary>
        /// 特效持续时长
        /// </summary>
        public float duration;
        /// <summary>
        /// 特效uri
        /// </summary>
        public string uri;
    }

    [System.Serializable]
    public class SkillProjectorConfig
    {
        /// <summary>
        /// 释放时间
        /// </summary>
        [Header("释放时间")]
        public float projectorTime = 0;
        /// <summary>
        /// 释放持续时间
        /// </summary>
        [Header("持续时间")]
        public float projectorDuration = 2;

        /// <summary>
        /// 特效配置
        /// </summary>
        public EffectConfig projectorEffectConfig;
        
        /// <summary>
        /// 碰撞特效
        /// </summary>
        public EffectConfig collideEffectConfig;

        [Header("初始偏移是相对发射方")]
        public bool initOffsetBaseSource = true;
        /// <summary>
        /// 初始点偏移距离
        /// </summary>
        [Header("初始点偏移距离")]
        public float initOffsetLengthOrRadius = 0;
        /// <summary>
        /// 初始点偏移角度
        /// </summary>
        [Header("初始点偏移角度")]
        public int initOffsetAngle = 0;

        [Header("运动轨迹")]
        public ProjectorMoveConfig[] projectorMoveConfigs;
        
        /// <summary>
        /// 运动过程中跟随主角
        /// </summary>
        [Header("运动过程中跟随主角位置")]
        public bool followHero;

        [Header("运动过程中跟随主角旋转")]
        public bool followHeroRotation;

        [Header("碰撞结果")] 
        public CollideType collideType = CollideType.Destroy;
        
        [Header("到时间点结果")] 
        public TimeOverType timeOverType = TimeOverType.Destroy;
        
        [Header("撞击移动效果")]
        public SkillMoveConfig[] skillMoveConfigs;
    }

    public enum CollideType
    {
        Destroy,//销毁
        Traversal,//穿透
        Return,//反弹
        Stay,//悬停
    }

    public enum TimeOverType
    {
        Destroy,//销毁
        ReturnSource,//回旋
    }

    // [System.Serializable]
    // public class ProjectorCollideConfig
    // {
    //     public CollideType collideType;
    //     
    //     [Header("圆形的碰撞半斤")]
    //     public float radius = 0.3f;
    //
    //     [Header("矩形的长宽")]
    //     public Vector2 rect = new Vector2(0.3f,0.3f);
    // }

    // public enum CollideType
    // {
    //     Circle,
    //     Rect,
    // }

    [System.Serializable]
    public class ProjectorMoveConfig
    {
        /// <summary>
        /// 运动轨迹
        /// </summary>
        [Header("运动轨迹")]
        public ProjectorMoveType projectorMoveType;
        /// <summary>
        /// 运动速度或角速度
        /// </summary>
        [Header("运动速度或角速度")]
        public float moveSpeedOrAngle = 2;

        /// <summary>
        /// Line轴向偏移标准值
        /// </summary>
        [Header("Line轴向偏移标准值")]
        public float YAsixOffset = 0;
        /// <summary>
        /// Line轴向偏移
        /// </summary>
        [Header("Line轴向偏移")]
        public AnimationCurve animationCurve;

        /// <summary>
        /// Source2Target跟踪转向角速度
        /// </summary>
        [Header("Source2Target跟踪转向最大角速度")]
        public float rotationAngleSpeed = 240;

        [Header("无限跟踪弹道，敌人死亡后继续跟踪下一位")]
        public bool loopSource2Target = true;
        
        /// <summary>
        /// Circle旋转半径
        /// </summary>
        [Header("Circle旋转半径")]
        public float circleRadius = 2;
    }

    public enum ProjectorMoveType
    {
        /// <summary>
        /// 直线运动轨迹
        /// </summary>
        Line,
        /// <summary>
        /// 跟踪
        /// </summary>
        Source2Target,
        /// <summary>
        /// 围绕圆心运动
        /// </summary>
        Circle,
        /// <summary>
        /// 随机布朗运动
        /// </summary>
        RandomMove,
    }


    public enum SkillType
    {
        Normal,
        Shanbi,
        Feixing,
    }
}