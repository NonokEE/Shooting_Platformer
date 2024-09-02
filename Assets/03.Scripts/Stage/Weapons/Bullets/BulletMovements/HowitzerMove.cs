using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public class HowitzerMove : MonoBehaviour, IBulletMoveType
    {
        public int Force;
        public Vector3 weaponPosition;

        private Rigidbody2D rig;

        private void Start() 
        {
            Vector2 mousePosition = StageTools.MousePosition2D();
            Vector2 targetVector = new(mousePosition.x - weaponPosition.x, mousePosition.y - weaponPosition.y);

            //초기값 설정
            transform.SetPositionAndRotation(weaponPosition, StageTools.GetQuatBy2D(targetVector));

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
