using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

namespace Stage
{
    public class StraightMove : BulletMoveType
    {
        public int BulletSpeed;
        public int PierceGround;
        public int PierceEnemy;
        public Action OnDestroyCallback = () => {};

        private Tween moveTween;

        //Movement
        private void Start() 
        {
            transform.position = StartPosition;
            var mousePosition = StageTools.MousePosition2D();

            Vector2 newPos = mousePosition - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
            moveTween = transform.DOMove(mousePosition, BulletSpeed).SetEase(Ease.Linear).SetSpeedBased().SetLoops(-1, LoopType.Incremental);
        }

        //
        private void OnDestroy() 
        {
            OnDestroyCallback();
            moveTween.Kill();
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
