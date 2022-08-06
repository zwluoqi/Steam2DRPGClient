using System;
using System.Collections.Generic;
using Game.View.Manager;
using UnityEngine;
using UnityEngine.UI;
using XZXD;
using Object = UnityEngine.Object;

namespace Game.View.Hero.Skill
{
    public class SkillProjector : DisplayPoolObject,IViewBindNode
    {
        public IViewBindRoot root { get; set; }
        public bool beDestroyed { get; set; }
        
        private SkillProjectorConfig _skillProjectorConfig;
        private SkillEntity _skill;
        private ViewHero _followTarget;

        private TimeEventHandler _startHandler;
        private TimeEventHandler _endHandler;

        private GameObject _gameObject;
        private string collideUri;
        private float collideDuration;
        private UnityProjectorTrigger _rigibody;
        private Vector3 _initCenter;
        /// <summary>
        /// 初始方向
        /// </summary>
        private Vector3 _initForward;
        /// <summary>
        /// 初始轴向
        /// </summary>
        private Vector3 _initYForward;
        /// <summary>
        /// 当前方向
        /// </summary>
        private Vector3 _curForward;
        /// <summary>
        /// 初始轴向
        /// </summary>
        private Vector3 _curYForward;

        private Vector3 targetPos
        {
            get
            {
                if (_followTarget == null || _followTarget.isDead)
                {
                    return _skill.hero.GetPosition() +
                           _skill.hero.heroInputUtil.lastStayMoveDir * _skill.skillconfig.searchRadius;
                }
                else
                {
                    return _followTarget.GetPosition();
                }
            }
        }
        
        /// <summary>
        /// 上一次计算的位置
        /// </summary>
        private Vector3 _lastPos;
        private float _timer;
        private bool running = false;
        private bool timeOver = false;
        private bool stopMove = false;
        private float initOffsetLengthOrRadius;
        
        /// <summary>
        /// 累计运动距离
        /// </summary>
        private Vector3[] _accMove;
        /// <summary>
        /// 当前运动的运动方向
        /// </summary>
        private Vector3[] _dirMove;
        
        private float[] _randomMoveTimer;
        public Action<SkillProjector,ViewHero> onCollide;
            //private List<ViewHero> collideTargets = new List<ViewHero>();
        private Dictionary<long, SkillProjectorCollideTarget> collideTargets =
            new Dictionary<long, SkillProjectorCollideTarget>();
        private bool collided = false;
        public void Init(SkillEntity skill, SkillProjectorConfig skillProjectorConfig, ViewHero target)
        {
            this.beDestroyed = false;
            this._timer = 0;
            this.running = false;
            this.timeOver = false;
            this.collided = false;
            this.stopMove = false;
            this._followTarget = target;
            this._skill = skill;
            this._skillProjectorConfig = skillProjectorConfig;
            this._accMove = new Vector3[this._skillProjectorConfig.projectorMoveConfigs.Length]; 
            this._dirMove = new Vector3[this._skillProjectorConfig.projectorMoveConfigs.Length];
            this._randomMoveTimer = new float[this._skillProjectorConfig.projectorMoveConfigs.Length];
            collideUri = "projector/skill_projector_collide";
            if (!string.IsNullOrEmpty(_skillProjectorConfig.collideEffectConfig.uri))
            {
                collideUri = _skillProjectorConfig.collideEffectConfig.uri;
            }

            collideDuration = Mathf.Max(0.1f, _skillProjectorConfig.collideEffectConfig.duration);
            if (_skillProjectorConfig.initOffsetLengthOrRadius == 0)
            {
                initOffsetLengthOrRadius = 0;
            }
            else
            {
                initOffsetLengthOrRadius = _skillProjectorConfig.initOffsetLengthOrRadius;
            }
        }


        public void StartProjector()
        {
            //TODO
            this.running = false;
            this.timeOver = false;
            if (_skillProjectorConfig.projectorTime > 0)
            {
                _startHandler = _skill.hero.viewManager.timeEventManager.CreateEvent(OnStartProjector,
                    _skillProjectorConfig.projectorTime);
            }
            else
            {
                OnStartProjector();
            }

            _endHandler = _skill.hero.viewManager.timeEventManager.CreateEvent(OnTimeOver,
                _skillProjectorConfig.projectorTime + _skillProjectorConfig.projectorDuration);
        }

        private void OnTimeOver()
        {
            this.timeOver = true;
            if (_skillProjectorConfig.timeOverType == TimeOverType.Destroy)
            {
                EndProjector();
            }
            else
            {
                ReturnProjector2Source();
            }
        }



        private void OnStartProjector()
        {
            this.running = true;
            this.timeOver = false;
            
            _gameObject = GameObjectPoolManager.Instance.GetGameObjectDirect(_skillProjectorConfig.projectorEffectConfig.uri);
            UnityTools.SetParent(_gameObject.transform,_skill.hero.viewManager.effectRoot);
            var collider = _gameObject.GetComponentInChildren<Collider2D>();
            _rigibody = collider.gameObject.AddMissingComponent<UnityProjectorTrigger>();
            _rigibody.guid = -1;
            this._rigibody.OnTriggerEnter2DEvent = OnTriggerEnter2DEvent;
            this._rigibody.OnTriggerExit2DEvent = OnTriggerExit2DEvent;

            ResetRotation();
            
            OrderedUpdate0(0);
        }

        private void OnTriggerExit2DEvent(UnityCollide2D other)
        {
            if (other.collideType == UnityCollide2DType.Hero)
            {
                if (other.guid >= 0)
                {
                    ViewHero target = null;
                    if (_skill.hero.viewManager.heroDict.TryGetValue(other.guid, out target))
                    {
                        UnCollide(target);
                    }
                }
            }else if (other.collideType == UnityCollide2DType.Wall)
            {
                //TODO
                Debug.LogError("撞墙TODO EXIT");
            }
        }

        private void OnTriggerEnter2DEvent(UnityCollide2D other)
        {
            if (other.collideType == UnityCollide2DType.Hero)
            {
                if (other.guid >= 0)
                {
                    ViewHero target = null;
                    if (_skill.hero.viewManager.heroDict.TryGetValue(other.guid, out target))
                    {
                        Collide(target);
                    }
                }
            }
            else if (other.collideType == UnityCollide2DType.Wall)
            {
                //TODO
                Debug.LogError("撞墙TODO Enter");
            }
        }

        public void ResetRotation()
        {
            //偏移方向
            if (_skillProjectorConfig.initOffsetBaseSource)
            {
                _initForward = MathUtil2D.Rotation(_skill.hero.heroInputUtil.lastStayMoveDir, _skillProjectorConfig.initOffsetAngle)
                    .normalized;
            }
            else
            {
                _initForward = MathUtil2D.Rotation(Vector2.right, _skillProjectorConfig.initOffsetAngle)
                    .normalized;
            }

            _curForward = _initForward;
            SetDirMove(_curForward);

            //轴向偏移方向
            _initYForward = MathUtil2D.Rotation(_initForward, 90).normalized;
            _curYForward = _initYForward;
            var initAngle = MathUtil2D.AngleBettwenVector(Vector3.right, _initForward, Vector3.forward);
            _gameObject.transform.localRotation =
                Quaternion.AngleAxis(initAngle, Vector3.forward);
            
            //位置重置
            if (_skillProjectorConfig.initOffsetBaseSource)
            {
                _initCenter = _skill.hero.GetPosition() +
                              _initForward * this.initOffsetLengthOrRadius;
            }
            else
            {
                _initCenter = targetPos +
                              _initForward * this.initOffsetLengthOrRadius; 
            }

            _lastPos = _initCenter;
            _gameObject.transform.localPosition = _initCenter;

            //缩放
            // _gameObject.transform.localScale = new Vector3(_skillProjectorConfig.uriXYScale.x,_skillProjectorConfig.uriXYScale.y, 1);

        }

        /// <summary>
        /// 设定所有运动的运动方向
        /// </summary>
        /// <param name="curForward"></param>
        private void SetDirMove(Vector3 curForward)
        {
            for (int i = 0; i < _dirMove.Length; i++)
            {
                _dirMove[i] = curForward;
            }
        }
        
        
        /// <summary>
        /// 平均运动方向
        /// </summary>
        /// <returns></returns>
        private void LerpForward()
        {
            if (_dirMove.Length > 1)
            {
                _curForward = Vector3.zero;
                ;
                for (int i = 0; i < _dirMove.Length; i++)
                {
                    _curForward += _dirMove[i];
                }

                _curForward /= _dirMove.Length;
                _curYForward = MathUtil2D.Rotation(_curForward, 90).normalized;
            }
            else if(_dirMove.Length >0)
            {
                _curForward = _dirMove[0];
                _curYForward = MathUtil2D.Rotation(_curForward, 90).normalized;
            }
            else
            {
                
            }
        }


        public void EndProjector()
        {
            ForceDestroy();
        }


        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Continue()
        {
            throw new System.NotImplementedException();
        }

        public void OrderedUpdate(float deltaTime)
        {
            if (_skillProjectorConfig.followHeroRotation)
            {
                
                ResetRotation();
            
                OrderedUpdate0(deltaTime);
            }
            else
            {
                OrderedUpdate0(deltaTime);
            }
        }
        
        public void OrderedUpdate0(float deltaTime)
        {
            if (!this.running)
            {
                return;
            }
            
            if (stopMove)
            {
                return;
            }

            _lastPos = _gameObject.transform.localPosition;
            if (timeOver)
            {
                if (_skillProjectorConfig.timeOverType == TimeOverType.ReturnSource)
                {
                    Return2SourceUpdate(deltaTime);
                }
                else
                {
                    EndProjector();
                }
            }
            else
            {
                NormalOrderUpdate(deltaTime);
            }

            OrderedCollideTarget(deltaTime);
        }

        private void OrderedCollideTarget(float deltaTime)
        {
            if (_skill.skillconfig.spaceHitTimer > 0)
            {
                foreach (var kv in collideTargets)
                {
                    
                    var item = kv.Value;
                    if (item.isInValid)
                    {
                        continue;
                    }
                    item.timer += deltaTime;
                    if (item.timer >= _skill.skillconfig.spaceHitTimer)
                    {
                        LogicHitOnce(item);
                    }
                }
            }
        }

        /// <summary>
        /// 回旋运动
        /// </summary>
        /// <param name="deltaTime"></param>
        private void Return2SourceUpdate(float deltaTime)
        {
            var projectorMoveConfig = _skillProjectorConfig.projectorMoveConfigs[0];
            var targetDir = _skill.hero.GetPosition() - _gameObject.transform.localPosition;
            targetDir = targetDir.normalized;
            _curForward = Vector3.RotateTowards(_curForward, targetDir,
                deltaTime * Mathf.Deg2Rad * projectorMoveConfig.rotationAngleSpeed, 0.0f);
            var curDelta = deltaTime * _curForward * projectorMoveConfig.moveSpeedOrAngle;
            _gameObject.transform.localPosition += curDelta;
        }

        /// <summary>
        /// 正常模式运动
        /// </summary>
        /// <param name="deltaTime"></param>
        private void NormalOrderUpdate(float deltaTime)
        {
            _timer += deltaTime;
            Vector3 moveAcc = Vector3.zero;
            for (int i = 0; i < _skillProjectorConfig.projectorMoveConfigs.Length; i++)
            {

                ProjectorMove(i, deltaTime);

                Vector3 moveDelta = _accMove[i];
                moveAcc += moveDelta;
            }

            LerpForward();

            if (_skillProjectorConfig.followHero)
            {
                var _correctCenter = _initCenter;
                if (_skillProjectorConfig.initOffsetBaseSource)
                {
                    _correctCenter = _skill.hero.GetPosition() +
                                     _initForward * this.initOffsetLengthOrRadius;
                }
                else
                {
                    _correctCenter = targetPos +
                                     _initForward * this.initOffsetLengthOrRadius;
                }

                _gameObject.transform.localPosition = _correctCenter + moveAcc;
            }
            else
            {
                _gameObject.transform.localPosition = _initCenter + moveAcc;
            }
        }

        private void ProjectorMove(int i,float deltaTime)
        {
            
            var projectorMoveConfig = _skillProjectorConfig.projectorMoveConfigs[i];
            if (projectorMoveConfig.projectorMoveType == ProjectorMoveType.Line)
                {
                    _accMove[i] += _dirMove[i] * deltaTime * projectorMoveConfig.moveSpeedOrAngle;
                    if (projectorMoveConfig.YAsixOffset > 0)
                    {
                        var YAsixOffsetFactorLast = projectorMoveConfig.animationCurve.Evaluate((_timer-deltaTime) / _skillProjectorConfig.projectorDuration);
                        var YAsixOffsetFactor = projectorMoveConfig.animationCurve.Evaluate(_timer / _skillProjectorConfig.projectorDuration);
                        var YAsixOffset = (YAsixOffsetFactor-YAsixOffsetFactorLast) * projectorMoveConfig.YAsixOffset;
                        _accMove[i] += _curYForward * YAsixOffset;
                    }
                }
                else if(projectorMoveConfig.projectorMoveType == ProjectorMoveType.Circle)
                {
                    _dirMove[i] = MathUtil2D.Rotation(_dirMove[i], deltaTime * projectorMoveConfig.moveSpeedOrAngle);
                    var curDelta = projectorMoveConfig.circleRadius * _dirMove[i];
                    _accMove[i] = curDelta;
                }else if (projectorMoveConfig.projectorMoveType == ProjectorMoveType.Source2Target)
                {
                    Vector3 curDelta = Vector3.zero;
                    if (projectorMoveConfig.loopSource2Target)
                    {
                        if (_followTarget == null || _followTarget.isDead)
                        {
                              _skill.hero.GetNearestEnemyInSkillRange(this._gameObject.transform.localPosition,_skill,out _followTarget);
                        }
                    }

                    if (_followTarget == null || _followTarget.isDead || this.collided)
                    {
                        curDelta = deltaTime * _dirMove[i] * projectorMoveConfig.moveSpeedOrAngle;
                    }
                    else
                    {
                        var targetDir = _followTarget.GetPosition() - _gameObject.transform.localPosition;
                        targetDir = targetDir.normalized;
                        _dirMove[i] = Vector3.RotateTowards(_dirMove[i], targetDir,
                            deltaTime * Mathf.Deg2Rad * projectorMoveConfig.rotationAngleSpeed, 0.0f);
                        curDelta = deltaTime * _dirMove[i] * projectorMoveConfig.moveSpeedOrAngle;
                    }
                    
                    _accMove[i] += curDelta;
                }
            else if (projectorMoveConfig.projectorMoveType == ProjectorMoveType.RandomMove)
            {
                this._randomMoveTimer[i] += deltaTime;
                if (this._randomMoveTimer[i] > 0.1f)
                {
                    this._randomMoveTimer[i] = 0;
                    _dirMove[i] = new Vector3(_skill.hero.viewManager.randomUtil.Range(-1, 1),
                        _skill.hero.viewManager.randomUtil.Range(-1, 1), 0);
                }
                _accMove[i] += deltaTime * _dirMove[i] * projectorMoveConfig.moveSpeedOrAngle;
            }
            else
            {
                
            }
            
        }

        private void Collide(ViewHero target)
        {
            Debug.LogWarning("Collide:"+target.gameObject.name);

            if (timeOver)
            {
                if (target == this._skill.hero)
                {
                    Debug.LogWarning("超时撞到自己，直接销毁:" + this._gameObject.name);
                    EndProjector();
                }
                else
                {
                    if (_skill.hero.IsEnemyCamp(target.heroCamp))
                    {
                        CollideTargetEvent(target);
                    }
                }
            }
            else
            {
                if (target == this._skill.hero)
                {
                    // Debug.LogError("撞到自己:" + this._gameObject.name);
                }
                else
                {
                    if (_skill.hero.IsEnemyCamp(target.heroCamp))
                    {

                        CollideTargetEvent(target);
                        if (_skillProjectorConfig.collideType == CollideType.Destroy)
                        {
                            EndProjector();
                        }
                        else if (_skillProjectorConfig.collideType == CollideType.Traversal)
                        {
                            TraversalProjector();
                        }else if (_skillProjectorConfig.collideType == CollideType.Return)
                        {
                            ReturnProjector();
                        }else if (_skillProjectorConfig.collideType == CollideType.Stay)
                        {
                            StayProjector();
                        }
                        else
                        {
                            EndProjector();
                        } 
                    }
                }
            }
        }

        private void CollideTargetEvent(ViewHero target)
        {
            this.collided = true;
            SkillProjectorCollideTarget collideTarget;
            if (collideTargets.TryGetValue(target.guid, out collideTarget))
            {
                collideTarget.isInValid = false;
                Debug.LogError("已经触发过碰撞:"+target.gameObject.name);
            }
            else
            {
                
                var moveSpeed = (_gameObject.transform.localPosition - _lastPos).magnitude / Time.deltaTime;
                collideTarget = DisplayPoolUtil.displayPool.Spwan<SkillProjectorCollideTarget>();
                collideTarget.Init(this._rigibody, target,moveSpeed+2);
                collideTargets.Add(target.guid, collideTarget);
            }

            LogicHitOnce(collideTarget);
        }

        private void LogicHitOnce(SkillProjectorCollideTarget collideTarget)
        {
            if (collideTarget.target.isDead)
            {
                return;
            }

            collideTarget.timer = 0;
            collideTarget.hitCount++;

            Vector3 hitNormal;
            hitNormal = (collideTarget.target.GetPosition()- collideTarget.target.GetPosition()).normalized;
            var pos = collideTarget.target.GetPosition();//collideTarget.RayCast(out hitNormal);
            
            var target = collideTarget.target;
            var moveSpeed = collideTarget.collideSpeed;
            
            var effect = _skill.hero.viewManager.effectManager.CreateProjector(
                _skill.hero.viewManager.effectRoot,
                collideUri,collideDuration);
            effect.SetPosition(pos);
            effect.SetForward(hitNormal);
            var powerEntity = _skill.hero.viewManager.powerManager.CreateProjector(-hitNormal, 0.1f, moveSpeed, target);
            target.powerUtil.AddNode(powerEntity);
            if (onCollide != null)
            {
                onCollide(this, target);
            }
        }

        private void StayProjector()
        {
            this.stopMove = true;
        }

        private void TraversalProjector()
        {
            
        }

        /// <summary>
        /// 反弹
        /// </summary>
        private void ReturnProjector()
        {
            for (int i = 0; i < _dirMove.Length; i++)
            {
                _dirMove[i] = -_curForward;
            }
            LerpForward();
        }

        /// <summary>
        /// 回旋
        /// </summary>
        private void ReturnProjector2Source()
        {
            
        }


        private void UnCollide(ViewHero target)
        {
            Debug.LogWarning("UnCollide:"+target.gameObject.name);
            SkillProjectorCollideTarget collideTarget;
            if (this.collideTargets.TryGetValue(target.guid, out collideTarget))
            {
                collideTarget.isInValid = true;
            }
        }


        public void LoadModel()
        {
            throw new System.NotImplementedException();
        }

        public bool IsLoading()
        {
            throw new System.NotImplementedException();
        }

        public void DestroyModel()
        {
            throw new System.NotImplementedException();
        }

        public void SetRoot(IViewBindRoot root)
        {
            
        }


        public void ForceDestroy()
        {
            this.beDestroyed = true;
            this._rigibody.OnTriggerEnter2DEvent = null;
            this._rigibody.OnTriggerExit2DEvent = null;
            this.onCollide = null;
            this.running = false;
            DisplayPoolUtil.displayPool.UnSpwanDict(this.collideTargets);
            //this.collideTargets.Clear();
            GameObjectPoolManager.Instance.Unspawn(ref _gameObject);
            this._rigibody = null;
            TimeEventManager.Delete(ref _startHandler);
            TimeEventManager.Delete(ref _endHandler);
            
        }

        
        public override void OnDeathToPool()
        {
            
        }

        public override void OnActiveFromPool()
        {
            
        }
    }
}