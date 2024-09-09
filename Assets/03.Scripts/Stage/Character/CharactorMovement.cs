using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class CharactorMovement : MonoBehaviour
    {
        public Rigidbody2D Rigidbody { get => rigidbody; set => rigidbody = value; }
        protected new Rigidbody2D rigidbody;

        
        public Collider2D Collider { get => collider; set => collider = value; }
        protected new Collider2D collider;
        
        protected virtual void Awake() 
        {
            rigidbody = GetComponent<Rigidbody2D>();
            Collider = GetComponent<Collider2D>();

            Initiate();
        }

        protected abstract void Initiate();
        public abstract void OnMove(Vector2 axis);
    }

    public abstract class PlayerMovement : CharactorMovement
    {
        public abstract void OnJump();
        public abstract void OnMainFire();
        public abstract void OnSubFire();
        public abstract void OnSkillOne();
        public abstract void OnSkillTwo();
    }
}