namespace Game.View.Hero
{
    public class HB_MoveToInit:HeroBehaviour
    {
        public override bool Interruptable
        {
            get
            {
                return false;
            }
            protected set
            {
                
            }
        }

        public override bool Check()
        {
            var sqrtDistanceNoZ = MathUtil2D.SqrtDistanceNoZ(owner.GetPosition(), owner.initPos);
            
            if (modelData.moveBackConfig.moveBackRange*modelData.moveBackConfig.moveBackRange < sqrtDistanceNoZ)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected override void OnStart()
        {
            owner.heroInputUtil.AutoSetMoveTarget(owner.initPos);
            owner.MoveLogic();
        }

        public override void OrderUpdate()
        {
            owner.heroInputUtil.AutoSetMoveTarget(owner.initPos);
            owner.MoveLogic();
            var sqrtDistanceNoZ = MathUtil2D.SqrtDistanceNoZ(owner.GetPosition(), owner.initPos);
            if (sqrtDistanceNoZ < 1)
            {
                WillFinish = true;
            }
        }
    }
}