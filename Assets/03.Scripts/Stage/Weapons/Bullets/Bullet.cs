using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

namespace Stage
{
    [RequireComponent(typeof(SpriteRenderer))]
    /// <summary> 투사체 타입 Attack </summary>
    public abstract class Bullet : Attack
    {
        [Header("Attack Properties")]
        private SpriteRenderer spriteRenderer;

        [Header("Bullet Properties")]
        public int Damage;
        public int Speed;
        public int PierceEnemy;
        public int PierceGround;
        public float MaxDuration = 5.0f;

        //

        public Vector2 StartPosition{ get => startPosition; set => startPosition = value; }
        protected Vector2 startPosition;

        public Vector2 TargetPosition{ get => targetPosition; set => targetPosition = value; }
        protected Vector2 targetPosition;

        //
        protected Tween maxDurationTween;
        [HideInInspector] public BulletMoveType BulletMoveType;
        //
        protected override void Awake() 
        {
            base.Awake();
            SetMoveType();
            BulletMoveType = BulletMoveType != null ? BulletMoveType : gameObject.AddComponent<NoMovement>();

            maxDurationTween = DOTween.To(() => MaxDuration, x => MaxDuration = x, 0, MaxDuration).OnComplete(() => Destroy(gameObject));
        }

        protected abstract void SetMoveType();
        public void SetSprite(Sprite sprite) => spriteRenderer.sprite = sprite;

        //TODO 피아 식별 리워크 필요
        protected override void OnTriggerEnter2D(Collider2D other)
        { 
            if(other.gameObject.CompareTag("Enemy")) 
            {
                OnAttackEnter.Invoke(other);
                BulletMoveType.OnEnterEnemy();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) BulletMoveType.OnEnterGround();
        }
        protected override void OnTriggerStay2D(Collider2D other) 
        { 
            if(other.gameObject.CompareTag("Enemy")) 
            {
                OnAttackStay.Invoke(other);
                BulletMoveType.OnStayEnemy();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) BulletMoveType.OnStayGround();
        }
        protected override void OnTriggerExit2D(Collider2D other) 
        { 
            if(other.gameObject.CompareTag("Enemy")) 
            {
                OnAttackExit.Invoke(other);
                BulletMoveType.OnExitEnemy();
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) BulletMoveType.OnExitGround();
        }

    }
}
