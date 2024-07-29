using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    /// <summary>
    /// 스테이지 안에서 충돌 및 물리 상호작용이 일어날 수 있는 모든 객체
    /// </summary>
    public interface IStageObject
    {
        public HitBox Hitbox{ get; }
        public void Hit(Attack attack);
    }

    /// <summary>
    /// 체력을 가지고 피해를 받으며 죽을 수 있는 객체
    /// </summary>
    public interface IKillable
    {
        public int CurrentHp { get; }
        public int MaxHp { get; }
    }

    /// <summary>
    /// 무기
    /// </summary>
    public class Weapon: MonoBehaviour
    {
        public Character Owner;

        public Action<Character> OnLeftDown = (owner) => {};
        public Action<Character> OnLeftHold = (owner) => {};
        public Action<Character> OnLeftUp = (owner) => {};

        public Action<Character> OnRightDown = (owner) => {};
        public Action<Character> OnRightHold = (owner) => {};
        public Action<Character> OnRightUp = (owner) => {};
    };

    /// <summary>
    /// 공격 객체
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Attack: MonoBehaviour
    {
        //
        public Character Attacker;

        //
        public Action<Collision2D> attackEnter = (other) => {};
        public Action<Collision2D> attackStay = (other) => {};
        public Action<Collision2D> attackExit = (other) => {};

        protected virtual void OnCollisionEnter2D(Collision2D other){ attackEnter(other); }
        protected virtual void OnCollisionStay2D(Collision2D other) { attackStay(other);}
        protected virtual void OnCollisionExit2D(Collision2D other) { attackExit(other); }
    }
}