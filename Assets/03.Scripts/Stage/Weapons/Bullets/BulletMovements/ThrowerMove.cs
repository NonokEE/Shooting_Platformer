using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public class ThrowerMove : BulletMoveType
    {
        /// Bullet의 PierceGround와 PierceEnemy가 Thrower에서는 다르게 적용됨
        /// PierceEnemy  -> EnemyBounce: 적에게만 적용되는 튕기기 횟수
        /// PierceGround -> TotalBounce: 콜라이더에 튕길 수 있는 총 횟수
        public int Force;

        [Tooltip("음수라면 적 충돌 여부와 관계없이 사라지기 전까지 남아있음.")]
        public int EnemyBounce = 0;

        [Tooltip("음수라면 지형 충돌 여부와 관계없이 사라지기 전까지 남아있음.")]
        public int TotalBounce = 0;
        public Action OnDestroyCallback = () => {};

        private Rigidbody2D rig;

        //Movement
        private void Start() 
        {
            Vector2 mousePosition = StageTools.MousePosition2D();
            Vector2 targetVector = new(mousePosition.x - StartPosition.x, mousePosition.y - StartPosition.y);

            //초기값 설정
            //TODO ThrowerMove : 무작위 회전한 상태에서 시작
            transform.SetPositionAndRotation(StartPosition, StageTools.GetQuatBy2D(targetVector));

            //이동 설정
            rig = GetComponent<Rigidbody2D>();
            rig.bodyType = RigidbodyType2D.Dynamic;
            rig.drag = 0;
            
            //이동 시작
            rig.velocity = targetVector.normalized * Force;
        }

        private void FixedUpdate() 
        {
            transform.rotation = StageTools.GetQuatBy2D(rig.velocity.y, rig.velocity.x);
        }

        //
        private void OnDestroy() 
        {
            OnDestroyCallback();
        }

        protected override void InitAction()
        {
            OnEnterGround = EnterGround;
            OnEnterEnemy = EnterEnemy;
        }
        private void EnterGround()
        {
            if(TotalBounce == -1) return;
            if(TotalBounce == 0) Destroy(gameObject);
            TotalBounce -= 1;
        }

        private void EnterEnemy()
        {
            if(EnemyBounce == -1) return;
            if(EnemyBounce == 0) Destroy(gameObject);
            EnemyBounce -= 1;
        }
    }
}
