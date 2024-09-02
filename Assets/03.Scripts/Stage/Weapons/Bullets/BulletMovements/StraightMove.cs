using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

namespace Stage
{
    public class StraightMove : MonoBehaviour, IBulletMoveType
    {
        public Vector2 StartPosition { get => startPosition; set => startPosition = value; }
        private Vector2 startPosition;
        public int BulletSpeed;

        private Tween moveTween;
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

        private void OnDestroy() 
        {
            moveTween.Kill();    
        }
    }
}
