using System;
using UnityEngine;

namespace Game.View.Hero
{
    public class HeroInputUtil
    {
        
        
        // public MouseType xCurInput = MouseType.None, yCurInput = MouseType.None;
        public Vector3 _moveDir = Vector3.zero;
        public ViewDir _viewDir;

        public Vector3 lastStayMoveDir = Vector3.right;
        public ViewDir lastStayViewDir;
        // public MouseType _xLastStayInput = MouseType.None, _yLastStayInput = MouseType.None;
        
        public bool[] skillBtns = new bool[ViewHero.skillCount];
        public bool[] skillBtnings = new bool[ViewHero.skillCount];

        public ViewHero hero;
        public void Init(ViewHero viewHero)
        {
            this.hero = viewHero;
            this.lastStayViewDir.x = MouseType.Positive;
            this._moveDir = Vector3.zero;
            this.lastStayMoveDir = Vector3.right;
            Array.Clear(skillBtns, 0, skillBtns.Length);
            Array.Clear(skillBtnings,0,skillBtnings.Length);
        }

        public void InputOperaiton()
        {
            
            Array.Copy(hero.viewManager.inputSystem.skillBtns, skillBtns, skillBtns.Length);
            Array.Copy(hero.viewManager.inputSystem.skillBtnings, skillBtnings, skillBtnings.Length);
            
            
            this._viewDir.x = hero.viewManager.inputSystem.xCurInput;
            this._viewDir.y = hero.viewManager.inputSystem.yCurInput;
            this._moveDir.x = (int) this._viewDir.x;
            this._moveDir.y = (int)  this._viewDir.y ;
            this._moveDir = this._moveDir.normalized;
            
            if ( this._viewDir.x != MouseType.None || this._viewDir.y != MouseType.None)
            {
                this.lastStayViewDir = this._viewDir;
                this.lastStayMoveDir = this._moveDir;
            }

        }

        public static ViewDir[] viewDirs = new[]
        {
            new ViewDir(MouseType.Positive, MouseType.None),
            new ViewDir(MouseType.Positive, MouseType.Positive),
            new ViewDir(MouseType.None, MouseType.Positive),
            new ViewDir(MouseType.Nagative, MouseType.Positive),
            new ViewDir(MouseType.Nagative, MouseType.None),
            new ViewDir(MouseType.Nagative, MouseType.Nagative),
            new ViewDir(MouseType.None, MouseType.Nagative),
            new ViewDir(MouseType.Positive, MouseType.Nagative),
        };
        
        
        
        public void ViewTarget(Vector3 targetPos)
        {
            var dir = targetPos - this.hero.GetPosition();
            dir.z = 0;
            var num = Vector3.Magnitude(dir);
            if (num < 0.0001f)
            {
                // this._moveDir = Vector3.zero;
                // this._viewDir.x = MouseType.None;
                // this._viewDir.x = MouseType.None;
            }
            else
            {
                // this._moveDir = dir.normalized;
                this.lastStayMoveDir = dir.normalized;
                var angle = MathUtil2D.AngleBettwenVector(Vector3.right, this.lastStayMoveDir, Vector3.forward);
                if (angle < 0)
                {
                    angle = 360 + angle;
                }
                int viewDirIndex = Mathf.CeilToInt(angle) / 45;
                // this._viewDir = viewDirs[viewDirIndex];
                this.lastStayViewDir = viewDirs[viewDirIndex];
            }
        }
        
        public void AutoSetMoveTarget(Vector3 targetPos)
        {
            var dir = targetPos - this.hero.GetPosition();
            dir.z = 0;
            var num = Vector3.Magnitude(dir);
            if (num < 0.0001f)
            {
                this._moveDir = Vector3.zero;
                this._viewDir.x = MouseType.None;
                this._viewDir.x = MouseType.None;
            }
            else
            {
                this._moveDir = dir.normalized;
                this.lastStayMoveDir = dir.normalized;
                var angle = MathUtil2D.AngleBettwenVector(Vector3.right, this._moveDir, Vector3.forward);
                if (angle < 0)
                {
                    angle = 360 + angle;
                }
                int viewDirIndex = (Mathf.CeilToInt(angle)-1) / 45;
                this._viewDir = viewDirs[viewDirIndex];
                this.lastStayViewDir = _viewDir;
            }
        }
    }
}