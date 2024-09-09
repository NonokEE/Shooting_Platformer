using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public class HowitzerMove : BulletMoveType
    {
        public int Force;
        public int PierceGround = 0;
        public int PierceEnemy = 0;
        public Action OnDestroyCallback = () => {};

        private Rigidbody2D rig;

        //Movement
        private void Start() 
        {
            Vector2 targetVector = new(bullet.TargetPosition.x - bullet.StartPosition.x, bullet.TargetPosition.y - bullet.StartPosition.y);

            //초기값 설정
            transform.SetPositionAndRotation(bullet.StartPosition, StageTools.GetQuatBy2D(targetVector));

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
            if(PierceGround == -1) return;
            if(PierceGround == 0) Destroy(gameObject);
            PierceGround -= 1;
        }

        private void EnterEnemy()
        {
            if(PierceEnemy == -1) return;
            if(PierceEnemy == 0) Destroy(gameObject);
            PierceEnemy -= 1;
        }
    }
}
