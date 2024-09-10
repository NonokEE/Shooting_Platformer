using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    /// <summary>
    /// 탄환의 이동패턴에 대한 정의. 적, 지형을 만났을 때 궤적이 바뀌거나 사라지거나 하는 등의 행동을 정의해야함.
    /// </summary>
    public abstract class BulletMoveType : MonoBehaviour
    {
        protected abstract void InitAction();
        protected virtual void Awake(){ InitAction(); }

        public Bullet Bullet{ get => bullet; set => bullet = value; }
        protected Bullet bullet;
        
        public Action OnEnterEnemy = () => {};
        public Action OnStayEnemy = () => {};
        public Action OnExitEnemy = () => {};

        public Action OnEnterGround = () => {};
        public Action OnStayGround = () => {};
        public Action OnExitGround = () => {};
    }

    public class NoMovement : BulletMoveType{ protected override void InitAction(){} }
}
