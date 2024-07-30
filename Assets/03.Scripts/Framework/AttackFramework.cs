using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    /// <summary>
    /// 공격 객체
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Attack: MonoBehaviour
    {
        public Character Attacker;

        public IAttackEnter attackEnter;
        public IAttackStay  attackStay;
        public IAttackExit  attackExit;

        protected void Awake() 
        {
            Initiate();
            attackEnter ??= new NoAttackEnter();
            attackStay  ??= new NoAttackStay();
            attackExit  ??= new NoAttackExit();
        }
        protected abstract void Initiate();

        protected virtual void OnCollisionEnter2D(Collision2D other){ attackEnter.Invoke(); }
        protected virtual void OnCollisionStay2D(Collision2D other) { attackStay.Invoke();}
        protected virtual void OnCollisionExit2D(Collision2D other) { attackExit.Invoke(); }
    }

    public interface IAttackEnter{ public void Invoke(); }
    public interface IAttackStay { public void Invoke(); }
    public interface IAttackExit { public void Invoke(); }

    public class NoAttackEnter: IAttackEnter { public void Invoke(){} }
    public class NoAttackStay : IAttackStay { public void Invoke(){} }
    public class NoAttackExit : IAttackExit { public void Invoke(){} }
}