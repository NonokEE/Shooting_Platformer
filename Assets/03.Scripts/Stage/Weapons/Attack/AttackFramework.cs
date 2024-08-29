using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    /// <summary>
    /// 공격 객체. Attack을 상속받는 객체는 1회용 투사체, 히트스캔, 장판 등 공격의 "성질"을 정한다. 데미지, 지속시간, 관통횟수 등의 수치는 Weapon객체에서 초기화한다.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Attack: MonoBehaviour
    {
        [Header("Attack Properties")]
        public AttackInfo AttackInfo;

        //
        protected virtual void Awake() 
        {
            SetStrategies();
            OnAttackEnter ??= new NoAttackEnter();
            OnAttackStay  ??= new NoAttackStay();
            OnAttackExit  ??= new NoAttackExit();
        }
        protected abstract void SetStrategies();
        public abstract void Initiate();

        public IAttackEnter OnAttackEnter;
        public IAttackStay  OnAttackStay;
        public IAttackExit  OnAttackExit;

        protected virtual void OnTriggerEnter2D(Collider2D other){ OnAttackEnter.Invoke(other); }
        protected virtual void OnTriggerStay2D(Collider2D other) { OnAttackStay.Invoke(other); }
        protected virtual void OnTriggerExit2D(Collider2D other) { OnAttackExit.Invoke(other); }
    }

    public interface IAttackEnter{ public void Invoke(Collider2D other); }
    public interface IAttackStay { public void Invoke(Collider2D other); }
    public interface IAttackExit { public void Invoke(Collider2D other); }

    public class NoAttackEnter: IAttackEnter { public void Invoke(Collider2D other){} }
    public class NoAttackStay : IAttackStay { public void Invoke(Collider2D other){} }
    public class NoAttackExit : IAttackExit { public void Invoke(Collider2D other){} }
}