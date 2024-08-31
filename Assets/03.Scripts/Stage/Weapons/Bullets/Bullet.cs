using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Stage
{
    [RequireComponent(typeof(SpriteRenderer))]
    /// <summary> 투사체 타입 Attack </summary>
    public abstract class Bullet : Attack
    {
        [Header("Attack Properties")]
        public Sprite Sprite;
        public IBulletMoveType BulletMoveType;
        private SpriteRenderer spriteRenderer;

        [Header("Bullet Properties")]
        public int Damage;
        public int Pierce;
        public int Speed;

        protected override void Awake() 
        {
            base.Awake();
            SetMoveType();
            BulletMoveType ??= new NoMovement();

            spriteRenderer = GetComponent<SpriteRenderer>();
            SetSprite(Sprite);
        }

        protected abstract void SetMoveType();
        public void SetSprite(Sprite sprite) => spriteRenderer.sprite = sprite;
    }
}
