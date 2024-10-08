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
        public HitBox HitBox{ get; }
    }

    /// <summary>
    /// 체력을 가지고 피해를 받으며 죽을 수 있는 객체
    /// </summary>
    public interface IKillable
    {
        public int CurrentHp { get; }
        public int MaxHp { get; }

        //TODO InputSystem에 맞춰서 리워크한거 기준으로 HitFeedback 부분 리워크 필요. 일단은 그냥 구현.
        public HitFeedback HitFeedback { get; }
        public void Hit(Attack attack, int damage);
    }
}