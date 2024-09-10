using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public abstract class CharacterObject : MonoBehaviour, IKillable, IStageObject
    {
            [Header("Character Info")]
        [SerializeField] protected int maxHp;
        [SerializeField] protected int currentHp;
        [SerializeField] protected HitBox hitBox;

        public abstract int MaxHp{ get; }
        public abstract int CurrentHp{ get; }
        public abstract HitBox HitBox{ get; }

        private CharacterInfo characterInfo;

        protected virtual void Awake()
        {
            characterInfo = new CharacterInfo
            {
                MaxHp = maxHp,
                CurrentHp = currentHp,
                HitBox = hitBox
            };
        }

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

    public class CharacterInfo
    {
        protected int maxHp;
        public int MaxHp { get => maxHp; set => maxHp = value; }

        protected int currentHp;
        public int CurrentHp { get => currentHp; set => currentHp = value; }

        protected HitBox hitBox;
        public HitBox HitBox { get => hitBox; set => hitBox = value; }
    }
}