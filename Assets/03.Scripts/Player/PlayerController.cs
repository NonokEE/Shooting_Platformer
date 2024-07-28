using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class PlayerController : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Player Parameters")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerControllerConfig playerControllerConfig;

        [Space]
    //~ Bindings ~//
    private Rigidbody2D rig;
    private Collider2D col;

    //~ For Funcs ~//
    private int moveDir;
    private bool jumpOrder = false;
    private int currentJumpCount = 0;

    //~ Delegate & Event ~//

    //~ Debug ~//
    [Header("Debug")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector2 velocity;

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        rig.mass         = playerControllerConfig.Mass;
        rig.gravityScale = playerControllerConfig.GravityScale;
        rig.bodyType     = playerControllerConfig.BodyType;
    }

    private void Update() 
    {
        GetInput();
        M_Debug();
    }


    private void FixedUpdate() 
    {
        UpdateGrounded();
        Move();
        Jump();
        LimitFreeFall();
    }

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    /// 
    private void GetInput()
    {
        moveDir = (int)Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")) jumpOrder = true;
    }

    private void Move()
    {
        switch(moveDir)
        {
            case  1:
            rig.AddForce(Vector2.right * playerControllerConfig.MoveAcceleration, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Min(rig.velocity.x, playerControllerConfig.MaxSpeed), rig.velocity.y);
            break;
            
            case -1:
            rig.AddForce(Vector2.left * playerControllerConfig.MoveAcceleration, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Max(rig.velocity.x, -playerControllerConfig.MaxSpeed), rig.velocity.y);
            break;
            
            case  0:
            rig.velocity = new Vector2(0, rig.velocity.y);
            break;
        }
    }

    private void Jump()
    {
        if(isGrounded)
        {
            currentJumpCount = playerControllerConfig.MaxJumpCount;
        }

        if(jumpOrder && (currentJumpCount > 0))
        {
            rig.velocity = new Vector2(rig.velocity.x, 0);
            rig.AddForce(new Vector2(0, playerControllerConfig.JumpForce), ForceMode2D.Impulse);


            if(!isGrounded) currentJumpCount -= 1;
        }
        jumpOrder = false;
    }

    private void UpdateGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0.0f, Vector2.down, 0.01f, LayerMask.GetMask("Ground"));
        if(raycastHit) isGrounded = true;
        else           isGrounded = false;
    }

    private void LimitFreeFall()
    {
        if(playerControllerConfig.MaxFreeFall != 0)
        {
            if(rig.velocity.y < 0) rig.velocity = new Vector2(rig.velocity.x, Mathf.Max(rig.velocity.y, playerControllerConfig.MaxFreeFall));
        }
    }

    private void M_Debug()
    {
        velocity = rig.velocity; 
    }

    //~ Event Listener ~//

    //~ External ~//
}