using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public abstract class CharacterObject : MonoBehaviour, IKillable, IStageObject
    {
        [Header("Character Config")]
        [SerializeField] private HitBox hitBox;
        public HitBox Hitbox => hitBox;

        [SerializeField] private int maxHp;
        public int MaxHp => maxHp;

        [SerializeField] private int currentHp;
        public int CurrentHp => currentHp;

        //TODO HitFeedback 부분 리팩토링 필요
        public HitFeedback HitFeedback => throw new System.NotImplementedException();
        public virtual void Hit(Attack attack, int damage)
        {
            if(maxHp > 0)
            {
                currentHp -= damage;
                if(currentHp <= 0) Destroy(gameObject);
            }
        }
    }
}