using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class HitBox : MonoBehaviour
    {
        [Header("HitBox Properties")]
        [SerializeField] private IStageObject sender;
        public IStageObject Sender { get => sender; }

        [SerializeField] private Rigidbody2D rigidBody;
        public Rigidbody2D RigidBody { get => rigidBody; }
        
        [SerializeField] private new Collider2D collider;
        public Collider2D Collider { get => collider; }

        private void Awake() 
        {
            rigidBody = rigidBody != null ? rigidBody : GetComponent<Rigidbody2D>();
            collider = collider != null ? collider : GetComponent<Collider2D>();
        }
    }
}
