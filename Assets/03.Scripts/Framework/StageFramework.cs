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
    }

    /// <summary>
    /// 체력을 가지고 피해를 받으며 죽을 수 있는 객체
    /// </summary>
    public interface IKillable
    {
        public int CurrentHp { get; }
        public int MaxHp { get; }

        public HitFeedback HitFeedback { get; }
        public void Hit(Attack attack, int damage);
    }

    public class HitFeedback
    {
        public  Character Sender{ get; private set; }
        //TODO 피격무적 관련 옵션
        //TODO 체력바 관련 옵션
        //~ Invicator ~//
        public IIndicator Indicator;
        public bool showLog = true;

        public HitFeedback(Character character)
        {
            Sender = character;
        }
        public void Invoke(Attack attack, int damage)
        {
            if(showLog) Debug.Log("("+ Sender.name + ") got ("+ damage + ")damage by (" + attack.AttackInfo.Attacker.name + ") with (" + attack.AttackInfo.Weapon.name + ")");
            Indicator.Invoke();
        }
    }

    public interface IIndicator { public void Invoke(); }
    public class NoIndicator : IIndicator { public void Invoke(){} }

    
}