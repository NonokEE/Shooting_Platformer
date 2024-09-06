using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    [RequireComponent(typeof(HitBox))]
    /// <summary>체력을 가지고 피해를 받을 수 있는 개체. </summary>
    public abstract class CharacterLegacy : MonoBehaviour, IKillable, IStageObject
    {
        /******* Character : MonoBehaviour *******/
        //~ Event Func ~//
        protected virtual void Awake() 
        {
            hitBox = GetComponent<HitBox>();

            InitiateKillable();
        }

        protected virtual void Start() 
        {
            currentHp = maxHp;
        }

        private void Update() 
        {
            StageTools.MousePosition2D();
        }

        /******* Killable *******/
        //~ Properties ~//
        [Header("Killable Attributes")]
        [SerializeField] private int currentHp;
        public int CurrentHp { get{ return currentHp; } }

        [Tooltip("Invincible if maxHP < 0")]
        [SerializeField] private int maxHp;
        public int MaxHp { get {return maxHp; } }

        //~ Bindings ~//
        protected HitFeedback hitFeedback;
        public HitFeedback HitFeedback { get{ return hitFeedback; } }
        
        //~ Method ~//
        protected void InitiateKillable()
        {
            hitFeedback = new HitFeedback(this);

            InitiateHitFeedback();
            hitFeedback.Indicator ??= new NoIndicator(this);
            //TODO 히트 피드백 타입별 초기화
        }
        protected abstract void InitiateHitFeedback();

        public virtual void Hit(Attack attack, int damage)
        {
            //~ Feedback ~//
            HitFeedback.Invoke(attack, damage);

            //~ Die ~//
            if(maxHp > 0)
            {
                currentHp -= damage;
                if(currentHp <= 0) Die();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }

        /******* StageObject *******/
        //~ Properties ~//
        private HitBox hitBox;
        public HitBox Hitbox { get {return hitBox; } }
    }
}