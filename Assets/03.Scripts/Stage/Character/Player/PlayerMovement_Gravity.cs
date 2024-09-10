using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    [AddComponentMenu("")]
    public class PlayerMovement_Gravity : PlayerMovement
    {
        [Header("PlayerMovement_Gravity : Parameters")]
        [SerializeField] private float moveAccelration = 10;
        public float MoveAccelration { get => moveAccelration; set => moveAccelration = value; }

        [SerializeField] private float maxSpeed = 20;
        public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

        [Space]
        [SerializeField] private float jumpForce = 20;
        public float JumpForce { get => jumpForce; set => jumpForce = value; }

        [SerializeField] private int maxJumpCount = 1;
        public int MaxJumpCount { get => maxJumpCount; set => maxJumpCount = value; }

        [SerializeField] private float maxFreeFall = -30;
        public float MaxFreeFall { get => maxFreeFall; set => maxFreeFall = value; }

        //

        [Header("Debug : PlayerMovement_Gravity")]
        [SerializeField] private bool isGrounded;
        public bool IsGrounded { get => isGrounded; }

        private int moveDir = 0;
        private bool jumpOrder = false;
        private int leftJumpCount;

        //
        protected override void Initiate()
        {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        private void FixedUpdate() 
        {
            UpdateGrounded();
            Move();
            Jump();
            LimitFreeFall();
        }

        private void UpdateGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0.0f, Vector2.down, 0.01f, LayerMask.GetMask("Ground"));
            isGrounded = raycastHit;
        }

        private void LimitFreeFall()
        {
            if(maxFreeFall != 0)
            {
                if(rigidbody.velocity.y < 0) rigidbody.velocity = new Vector2(rigidbody.velocity.x, Mathf.Max(rigidbody.velocity.y, maxFreeFall));
            }
        }

        private void Move()
        {
            switch(moveDir)
            {
                case  1:
                rigidbody.AddForce(Vector2.right * MoveAccelration, ForceMode2D.Impulse);
                rigidbody.velocity = new Vector2(Mathf.Min(rigidbody.velocity.x, MaxSpeed), rigidbody.velocity.y);
                break;
                
                case -1:
                rigidbody.AddForce(Vector2.left * MoveAccelration, ForceMode2D.Impulse);
                rigidbody.velocity = new Vector2(Mathf.Max(rigidbody.velocity.x, -MaxSpeed), rigidbody.velocity.y);
                break;
                
                case  0:
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                break;
            }
        }

        private void Jump()
        {
            if(isGrounded)
            {
                leftJumpCount = MaxJumpCount;
            }

            if(jumpOrder && (leftJumpCount > 0))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);


                if(!isGrounded) leftJumpCount -= 1;
            }
            jumpOrder = false;
        }

        //

        public override void OnMove(Vector2 axis)
        {
            moveDir = (int)axis.x;
        }


        public override void OnJump()
        {
            jumpOrder = true;
        }
    }
}