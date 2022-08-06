using System;
using Battle.Logic;
using Game.View;
using UnityEngine;

namespace Game
{
    public class GameRoot:MonoBehaviour
    {
        public ViewManager viewManager = new ViewManager();

        public static GameRoot Instance;

        private void Awake()
        {
            Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            viewManager.Start();
        }

        public void Update()
        {
            viewManager.Tick();
        }

        public void LateUpdate()
        {
            viewManager.LateTick();
            UnityEngine.SkeletonBone s;
        }
    }
}