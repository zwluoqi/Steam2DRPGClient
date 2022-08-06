
using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


[ExecuteInEditMode]
public class Custom3DGrid:MonoBehaviour
{
        [Header("自动适配机制")]
        public bool adaptChild = false;
        public Vector2 cellSize = Vector2.one;
        public Vector2 spaceSize = new Vector2(0.1f,0.1f);
        public int rowCount = 6;


        /// <summary>
        /// Helper method used to set a given property if it has changed.
        /// </summary>
        /// <param name="currentValue">A reference to the member value.</param>
        /// <param name="newValue">The new value.</param>
        protected void SetProperty<T>(ref T currentValue, T newValue)
        {
            if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
                return;
            currentValue = newValue;
            SetDirty();
        }


        /// <summary>
        /// Mark the LayoutGroup as dirty.
        /// </summary>
        protected void SetDirty()
        {
            if (!IsActive())
                return;
            //TODO
            SimpleUpdatePos();
        }

        private void SimpleUpdatePos()
        {
            var currentx = 0;
            var currenty = 0;

            for (int i = 0; i < this.transform.childCount; i++)
            {
                var child = this.transform.GetChild(i);
                if (this.adaptChild)
                {

                    //TODO  不好确定以什么味单位，或者在所有子对象上挂特定脚本，感觉也不是很合适？
                }
                else
                {
                    child.localPosition = new Vector3(
                        (this.cellSize.x + this.spaceSize.x) * (i % this.rowCount),
                        -(this.cellSize.y + this.spaceSize.y) * (i / this.rowCount), 0);

                }
            }
        }

        private void OnEnable()
        {
            SetDirty();
        }

        private void OnTransformChildrenChanged()
        {
            StartCoroutine(DelaySetDirty());
        }

        private IEnumerator DelaySetDirty()
        {
            yield return null;
            SetDirty();
        }

        public virtual bool IsActive()
        {
            return isActiveAndEnabled;
        }

}
