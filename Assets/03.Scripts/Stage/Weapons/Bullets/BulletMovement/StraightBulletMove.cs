using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
namespace Stage
{
    public class StraightBulletMove : MonoBehaviour, IBulletMoveType
    {
        public int BulletSpeed;
        public Vector3 weaponPosition;

        private Tween moveTween;
        private void Start() 
        {
            transform.position = weaponPosition;
            var mousePosition = Tools.MousePosition2D();

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
