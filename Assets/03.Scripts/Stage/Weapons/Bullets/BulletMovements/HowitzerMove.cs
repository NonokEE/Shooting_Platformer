using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public class HowitzerMove : MonoBehaviour, IBulletMoveType
    {
        public Vector2 StartPosition { get => startPosition; set => startPosition = value; }
        private Vector2 startPosition;

        public int Force;

        private Rigidbody2D rig;

        private void Start() 
        {
            Vector2 mousePosition = StageTools.MousePosition2D();
            Vector2 targetVector = new(mousePosition.x - StartPosition.x, mousePosition.y - StartPosition.y);

            //초기값 설정
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
    }
}
