using System.Net.NetworkInformation;
using Game.View.Hero;
using UnityEngine;

namespace Game.View.Power
{
    public class PowerEntity: DisplayPoolObject,IViewBindNode
    {
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
            this.timer += deltaTime;
            if (timer > duration)
            {
                ForceDestroy();
            }
            else
            {
                target.SetPosition(target.GetPosition() + normal * deltaTime * speed);
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
            this.beDestroyed = true;
        }

        public bool beDestroyed { get; set; }

        public Vector3 normal;
        public float duration;
        public float timer;
        public ViewHero target;
        public float speed = 1;
        public void Init(Vector3 normal, float duration,float speed, ViewHero target)
        {
            this.beDestroyed = false;
            this.normal = normal;
            this.duration = duration;
            this.target = target;
        }

        public void StartProjector()
        {
            this.timer = 0;
        }
    }
}