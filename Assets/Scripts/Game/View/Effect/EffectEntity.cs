using Game.View.Hero.Skill;
using UnityEngine;

namespace Game.View.Effect
{
    public class EffectEntity: DisplayPoolObject,IViewBindNode
    {
        GameObject _gameObject;
        private float timer = 0;
        private float duration = 1;
        public void Init(EffectConfig effectConfig)
        {
            Init(null,effectConfig.uri, effectConfig.duration);
        }
        
        public void Init(Transform parent,string uri,float duration)
        {
            this.beDestroyed = false;
            this._gameObject = GameObjectPoolManager.Instance.GetGameObjectDirect(uri);
            if (parent != null)
            {
                UnityTools.SetParent(this._gameObject.transform, parent);
            }
            this.timer = 0;
            this.duration = duration;
        }

        public override void OnDeathToPool()
        {
            
        }

        public override void OnActiveFromPool()
        {
            
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
            timer += deltaTime;
            if (timer >= duration)
            {
                ForceDestroy();
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

        public IViewBindRoot root { get; set; }
        public void ForceDestroy()
        {
            beDestroyed = true;
            GameObjectPoolManager.Instance.Unspawn(ref _gameObject);
        }

        public bool beDestroyed { get; set; }

        public void SetPosition(Vector3 pos)
        {
            this._gameObject.transform.localPosition = pos;
        }

        public void SetForward(Vector3 normal)
        {
            this._gameObject.transform.localEulerAngles = new Vector3(0,0,MathUtil2D.VectorTEuler(normal));
        }
    }
}