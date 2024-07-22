using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
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
    [Header("Parameters")]
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;

    [Space]
    //~ Bindings ~//
    private Rigidbody2D rig;

    //~ For Funcs ~//
    private int moveDir;
    private bool jumpOrder = false;

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        GetInput();
    }

    private void FixedUpdate() 
    {
        Move();
        Jump();
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
            rig.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Min(rig.velocity.x, maxSpeed), rig.velocity.y);
            break;
            
            case -1: 
            rig.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Max(rig.velocity.x, -maxSpeed), rig.velocity.y);
            break;
            
            case  0: 
            rig.velocity = new Vector2(0, rig.velocity.y);
            break;
        }
    }

    private void Jump()
    {
        if(jumpOrder)
        {
            rig.velocity = new Vector2(rig.velocity.x, 0);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            jumpOrder = false;
        }
    }

    //~ Event Listener ~//

    //~ External ~//
}