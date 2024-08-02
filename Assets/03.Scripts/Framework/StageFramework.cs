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
}