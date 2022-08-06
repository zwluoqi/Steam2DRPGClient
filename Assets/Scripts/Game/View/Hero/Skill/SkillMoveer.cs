using UnityEngine;

namespace Game.View.Hero.Skill
{
    public class SkillMoveer
    {
        private SkillEntity _skill;
        private float _timer;
        private bool running;
        private ViewHero _target;
        private SkillMoveConfig _skillMoveConfig;
        private TimeEventHandler _startHandler;
        private TimeEventHandler _endHandler;

        private Vector3 moveDir;
        private float curSpeed = 0;

        public void Init(SkillEntity skill, SkillMoveConfig skillMoveConfig)
        {

            this._skill = skill;
            this._skillMoveConfig = skillMoveConfig;
            curSpeed = this._skillMoveConfig.moveSpeed;
        }
        
        
        public void StartMove(ViewHero target)
        {
            //TODO
            this.running = false;
            this._target = target;
            this._timer = 0;
            
            if (_skillMoveConfig.moveTime > 0)
            {
                _startHandler = _skill.hero.viewManager.timeEventManager.CreateEvent(OnStartMove,
                    _skillMoveConfig.moveTime);
            }
            else
            {
                OnStartMove();
            }

            _endHandler = _skill.hero.viewManager.timeEventManager.CreateEvent(OnTimeOver,
                _skillMoveConfig.moveTime + _skillMoveConfig.duration);
        }
        
        public void StopMove()
        {
            Interrupt();
        }

        private void OnTimeOver()
        {
            Interrupt();
        }

        private void Interrupt()
        {
            if (!this.running)
            {
              return;
            }
            this.running = false;
            if (this._skillMoveConfig.traversal)
            {
                this._skill.hero.DesSkillMoving();
            }
        }

        private void OnStartMove()
        {
            if (running)
            {
                return;
            }
            this.running = true;
            this.moveDir = _skill.hero.heroInputUtil.lastStayMoveDir;
            if (this._skillMoveConfig.traversal)
            {
                this._skill.hero.AddSkillMoving();
            }
        }

        Vector3 lastPos;
        private float timer = 0;
        
        public void OrderedUpdate(float deltaTime)
        {
            if (!running)
            {
                return;
            }

            timer += deltaTime;
            
            // this.moveDir = Vector3.RotateTowards(this.moveDir, targetDir,
            //     deltaTime * Mathf.Deg2Rad * projectorMoveConfig.rotationAngleSpeed, 0.0f);
            //
            
            

            if (timer > _skillMoveConfig.accSpeedPerTime)
            {
                curSpeed = _skillMoveConfig.moveSpeed + _skillMoveConfig.accSpeedPerSecond * _skillMoveConfig.accSpeedPerTime;    
            }
            else
            {
                curSpeed = _skillMoveConfig.moveSpeed + _skillMoveConfig.accSpeedPerSecond * timer;
            }

            if (_skillMoveConfig.avtiveMove)
            {
                if (_skillMoveConfig.rotationAngleSpeed > 0)
                {
                    this.moveDir = Vector3.RotateTowards(this.moveDir, this._skill.hero.heroInputUtil._moveDir,
                        deltaTime * Mathf.Deg2Rad * _skillMoveConfig.rotationAngleSpeed, 0.0f);
                }
                else
                {
                    this.moveDir = this._skill.hero.heroInputUtil._moveDir;
                }

                this._skill.hero.SetPosition(this._skill.hero.GetPosition() + this.moveDir * deltaTime * curSpeed);
            }
            else
            {
                this._skill.hero.SetPosition(this._skill.hero.GetPosition() + this.moveDir * deltaTime * curSpeed);
            }
        }

       
    }
}