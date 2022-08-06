using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scene;
using Game.View;
using Game.View.Define;
using Game.View.Hero;
using Game.View.Manager;
using Game.View.Trigger;
using Game.View.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Battle.Logic
{
    public class ViewManager
    {
        public InputSystem inputSystem = new InputSystem();
        public TimeEventManager timeEventManager = new TimeEventManager();
        public RandomUtil randomUtil = new RandomUtil();
        public ProjectorManager projectorManager;
        public EffectManager effectManager;
        public PowerManager powerManager;
        public TargetUtil targetUtil;
        public Transform root;
        public Transform effectRoot;
        public Transform heroRoot;
        public Transform dynamicRoot;
        public Tilemap[] tilemaps;
        public Vector3 bornPos;


        public ViewHero mainHero;
        public List<ViewHero> heroList = new List<ViewHero>();
        public List<ViewHero> attacks = new List<ViewHero>();
        public List<ViewHero> defences = new List<ViewHero>();
        public List<ViewHero> npcCamp = new List<ViewHero>();
        public List<ViewHero> hunluanCamp = new List<ViewHero>();
        
        public Dictionary<long,ViewHero> heroDict = new Dictionary<long, ViewHero>();
        public Dictionary<int,ViewHero> levelHeroDict = new Dictionary<int, ViewHero>();
        public Dictionary<int,ViewHeroGroup> viewHeroGroups = new Dictionary<int, ViewHeroGroup>();
        public Dictionary<int, List<ViewTrigger>> viewTriggers = new Dictionary<int, List<ViewTrigger>>();
        
        public List<TilemapCollider2D> airCollider2Ds = new List<TilemapCollider2D>();
        public List<TilemapCollider2D> wallCollider2Ds = new List<TilemapCollider2D>();
        
        public NotificationCenter notification = NotificationCenter.GetNew();
        public Camera mainCamera;
        public float timer = 0;
        public float deltaTime;
        public void Tick()
        {
            deltaTime = Time.deltaTime;
            timer += Time.deltaTime;
            inputSystem.UpdateInput();
            
            timeEventManager.OrderUpdate(Time.deltaTime);
            projectorManager.OrderUpdate(Time.deltaTime);
            effectManager.OrderUpdate(Time.deltaTime);
            powerManager.OrderUpdate(Time.deltaTime);
            OrderUpdateHero();
        }

        private void OrderUpdateHero()
        {
            for (int i=0;i<heroList.Count;)
            {
                var hero = heroList[i];
                if (hero.isInValid)
                {
                    RemoveHero(hero);
                }
                else
                {
                    hero.Tick();
                    i++;
                }
            }
        }


        public void LateTick()
        {
            if (mainCamera == null && mainHero != null)
            {
                mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    var cameraFollow = mainCamera.gameObject.AddComponent<BasicCameraFollow>();
                    cameraFollow.followTarget = mainHero.GetTrans();
                    cameraFollow.moveSpeed = 5;
                }
            }
        }


        public void ChangeScene(string sceneName)
        {
            ClearScene();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            RunCoroutine.Run(InitSceneItems());
        }

        void ClearScene()
        {
            ClearManagerObjects();
            ClearSceneTriggers();
            ClearSceneHeros();
            ClearViewHeroGroups();
        }

        private void ClearViewHeroGroups()
        {
            viewHeroGroups.Clear();
        }

        private void ClearManagerObjects()
        {
            projectorManager.Clear();
            effectManager.Clear();
            powerManager.Clear();
        }

        private void ClearSceneHeros()
        {
            List<ViewHero> tmps = new List<ViewHero>();
            tmps.AddRange(heroList);
            foreach (var hero in tmps)
            {
                if (!hero.isMainHero)
                {
                    RemoveHero(hero);
                }
            }
        }

        private void ClearSceneTriggers()
        {
            foreach (var kv in viewTriggers)
            {
                foreach (var VARIABLE in kv.Value)
                {
                    VARIABLE.Destroy();
                }
                
            }
            viewTriggers.Clear();
        }

        private IEnumerator InitSceneItems()
        {
            yield return null;
            tilemaps = GameObject.FindObjectsOfType<Tilemap>();
            var sceneItems =  GameObject.FindObjectsOfType<SceneTriggerItem>();
            foreach (var sceneItem in sceneItems)
            {
                AddSceneTriggerItem(sceneItem);
            }

            var airObjects = GameObject.FindObjectsOfType<TilemapCollider2D>();
            foreach (var airCollider in airObjects)
            {
                if (airCollider.gameObject.layer == (int)UnityLayer.AirAreaCollide)
                {
                    airCollider2Ds.Add(airCollider);
                }

                else if(airCollider.gameObject.layer == (int)UnityLayer.WallCollide)
                {
                     wallCollider2Ds.Add(airCollider);
                }
            }
        }


        private void InitPlayer()
        {
            int randomVal = 20;
            mainHero = AddHero(true, HeroCamp.Player, Vector3.zero, 
                -1,-1,Resources.Load<HeroConfig>("hero_config/hero_config_player"));
        }

        private void AddSceneTriggerItem(SceneTriggerItem sceneItem)
        {
            ViewTrigger viewTrigger = ViewTriggerFactory.GetTrigger(sceneItem.levelTriggerConfig.sceneTriggerType);
            viewTrigger.Init(this,sceneItem);
            viewTrigger.Start();
            List<ViewTrigger> list;
            if (!viewTriggers.TryGetValue(sceneItem.levelTriggerConfig.triggerId,out list))
            {
                list = new List<ViewTrigger>();
                viewTriggers.Add(sceneItem.levelTriggerConfig.triggerId,list );
            }
            list.Add(viewTrigger);
        }

        public void TriggerSceneItem(SceneItem sceneItem)
        {
            if (sceneItem.sceneItemType == SceneItem.SceneItemType.Hero)
            {
                var sceneHero = (sceneItem as SceneHeroItem);
                AddHero(false, sceneHero.heroCamp, sceneHero.transform.localPosition,
                    sceneHero.levelGroupHeroId,
                    sceneHero.levelHeroId,
                    sceneHero.heroConfig);
            }else if (sceneItem.sceneItemType == SceneItem.SceneItemType.HeroCollection)
            {
                var sceneHero = (sceneItem as SceneRandomHeroItem);
                for(int i=0;i<sceneHero.counter;i++)
                {
                    var posx = this.randomUtil.Range(-10, 10);
                    var posy = this.randomUtil.Range(-10, 10);
                    
                    AddHero(false, sceneHero.heroCamp,new Vector3(posx,posy,0) ,sceneHero.levelGroupHeroId,
                        sceneHero.levelHeroId,
                        sceneHero.heroConfig);
                }
            }
            else if(sceneItem.sceneItemType == SceneItem.SceneItemType.PlayerBornCollide)
            {
                bornPos = sceneItem.transform.localPosition;
                mainHero.SetPosition(sceneItem.transform.localPosition);
            }else if (sceneItem.sceneItemType == SceneItem.SceneItemType.PlayerNextCollide)
            {
                
            }
        }

        
        private ViewHero AddHero(HeroInstanceData instanceData,Vector3 pos,HeroConfig heroConfig)
        {
            var obj = Resources.Load<GameObject>(heroConfig.heroUri);
            var go = GameObject.Instantiate(obj);
            go.GetComponentInChildren<SpriteRenderer>().color = heroConfig.color;
            UnityTools.SetParent(go.transform, heroRoot);
            var hero = new ViewHero();
            // var  instanceData = new HeroInstanceData();
            // instanceData.isMain = isMain;
            // instanceData.heroCamp = heroCamp;
            hero.Init(this,go,instanceData,pos,heroConfig);
            
            heroList.Add(hero);
            heroDict.Add(hero.guid,hero);
            levelHeroDict.Add(hero.levelHeroId,hero);
            var list = GetHerosByCamp(instanceData.heroCamp);
            list.Add(hero);
            ViewHeroGroup viewHeroGroup;
            if (!viewHeroGroups.TryGetValue(hero.levelGroupHeroId,out viewHeroGroup))
            {
                viewHeroGroup = new ViewHeroGroup();
                viewHeroGroup.groupHeroId = hero.levelGroupHeroId;
                viewHeroGroups.Add(hero.levelGroupHeroId,viewHeroGroup);
            }
            viewHeroGroup.viewHeroes.Add(hero);
            return hero;
        }
        
        private ViewHero AddHero(bool isMain,HeroCamp heroCamp,Vector3 pos,int levelGroupHeroId,int levelHeroId,HeroConfig heroConfig)
        {
            HeroInstanceData instanceData = new HeroInstanceData();
            instanceData.heroCamp = heroCamp;
            instanceData.mainHero = isMain;
            instanceData.levelGroupHeroId = levelGroupHeroId;
            instanceData.levelHeroId = levelHeroId;
            
            // LevelHeroConfig levelHeroConfig = ScriptableObject.CreateInstance<LevelHeroConfig>();
            // levelHeroConfig.heroConfig = heroConfig;
            // levelHeroConfig.levelHeroId = -1;
            // levelHeroConfig.levelGroupHeroId = -1;
            return AddHero(instanceData, pos, heroConfig);
        }
        
        
        private void RemoveHero(ViewHero hero)
        {
            ViewHeroGroup viewHeroGroup;
            if (viewHeroGroups.TryGetValue(hero.levelGroupHeroId, out viewHeroGroup))
            {
                viewHeroGroup.viewHeroes.Remove(hero);
            }
            heroList.Remove(hero);
            heroDict.Remove(hero.guid);
            levelHeroDict.Remove(hero.levelHeroId);
            var list = GetHerosByCamp(hero.heroCamp);
            list.Remove(hero);
            hero.Destroy();
           

            GameObject.Destroy(hero.gameObject);
        }

        public void Start()
        {
            InitSystem();
            InitPlayer();
            ChangeScene("level0");
        }

        private void InitSystem()
        {
            randomUtil.SetSeed(System.DateTime.Now.Ticks);
            root = new GameObject("root").transform;
            GameObject.DontDestroyOnLoad(root);
            heroRoot = new GameObject("hero").transform;
            effectRoot = new GameObject("effect").transform;
            dynamicRoot = new GameObject("dynamic").transform;
            UnityTools.SetParent(heroRoot,root);
            UnityTools.SetParent(effectRoot,root);
            UnityTools.SetParent(dynamicRoot,root);
            
            this.timeEventManager = new TimeEventManager();
            this.timeEventManager.Start();
            
            projectorManager = new ProjectorManager();
            effectManager = new EffectManager();
            powerManager = new PowerManager();
            targetUtil = new TargetUtil();
        }


        public List<ViewHero> GetHerosByCamp(HeroCamp heroCamp)
        {
            if (heroCamp == HeroCamp.Player)
            {
                return attacks;
            }
            else if (heroCamp == HeroCamp.Enemy)
            {
                return defences;
            }
            else if (heroCamp == HeroCamp.Npc)
            {
                return npcCamp;
            }
            else if (heroCamp == HeroCamp.Hunluan)
            {
                return hunluanCamp;
            }
            else
            {
                return null;
            }
        }
        
        public List<ViewHero> GetHerosByCampMask(int heroCampMask)
        {
            List<ViewHero> res = new List<ViewHero>();
            if ((heroCampMask &  1<<(int)HeroCamp.Player ) > 0)
            {
                res.AddRange(attacks);
            }
            if ((heroCampMask &  1<<(int)HeroCamp.Enemy ) > 0)
            {
                res.AddRange(defences);
            }
            if ((heroCampMask &  1<<(int)HeroCamp.Npc ) > 0)
            {
                res.AddRange(npcCamp);
            }
            if ((heroCampMask &  1<<(int)HeroCamp.Hunluan ) > 0)
            {
                res.AddRange(hunluanCamp);
            }

            return res;
        }
        
        public void AddSkillExport(BattleLogicOneSkillExport export){
            // this.roundExport.skillExports.Add (export);
        }

        public void AddRoundExport(){
            // this.roundExport = new BattleLogicOneRoundExport (this.RoundNum);
            // this.export.roundExports.Add (this.roundExport);
        }

        public void OnDead(ViewHero skillHero)
        {
            CheckHeroGroupDead(skillHero.levelGroupHeroId);
        }

        private void CheckHeroGroupDead(int groupHeroId)
        {
            ViewHeroGroup viewHeroGroup;
            if (!viewHeroGroups.TryGetValue(groupHeroId, out viewHeroGroup))
            {
                Debug.LogError("levelGroupHeroId不存在");
            }
            else
            {
                foreach (var hero in viewHeroGroup.viewHeroes)
                {
                    if (!hero.isDead)
                    {
                        return;
                    }
                }
                this.notification.PostNotification((int)ViewCodeEventId.GroupHeroDead,groupHeroId);
            }
        }

        public void ForbideTrigger(int triggerId)
        {
            List<ViewTrigger> viewTrigger;
            if (viewTriggers.TryGetValue(triggerId, out viewTrigger))
            {
                foreach (var VARIABLE in viewTrigger)
                {
                    VARIABLE.Destroy();
                }
            }
            else
            {
                Debug.LogError("无法找到触发器:" + triggerId);
            }
        }

        public void ForbideDeadHero(int levelHeroId)
        {
            ViewHero viewHero;
            if (levelHeroDict.TryGetValue(levelHeroId,out viewHero))
            {
                viewHero.HeroDead(null);
            }
            else
            {
                Debug.LogError("无法找到关卡英雄:" + levelHeroId);
            }
        }

        public void ForbideDeadHeroGroup(int levelGroupHeroId)
        {
            ViewHeroGroup viewHeroGroup;
            if (!viewHeroGroups.TryGetValue(levelGroupHeroId, out viewHeroGroup))
            {
                Debug.LogError("levelGroupHeroId不存在");
            }
            else
            {
                foreach (var hero in viewHeroGroup.viewHeroes)
                {
                    hero.HeroDead(null);
                }
            }
        }

        public bool CheckCurInLayer(Vector3 pos,UnityLayer airAreaCollide)
        {
            var intVec3 = Vector3Int.CeilToInt(pos);
            foreach (var tilemap in tilemaps)
            {
                var sprite = tilemap.GetTile(intVec3);
                if (sprite != null)
                {
                    if ((int)airAreaCollide == tilemap.gameObject.layer)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}