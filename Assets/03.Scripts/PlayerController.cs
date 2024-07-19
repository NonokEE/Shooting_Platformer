using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Unity.Burst.Intrinsics;
using UnityEngine;

//TODO CharacterController말고 collider rigidbody 기반으로 바꾸기
[RequireComponent(typeof(CharacterController))]
/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class PlayerController : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [Header("Parameters")]
    [SerializeField] private float movementSpeed = 0.3f;
    [SerializeField] private float jumpForce = 1.0f;

    [Space]
    [SerializeField] private Collider2D hitbox;

    //~ Bindings ~//
    private CharacterController characterController;

    //~ For Funcs ~//
    [Header("Debug")]
    private float freefallSpeed = 0;
    private bool jumpOrder;

    private int moveDir;
    private Vector2 moveVector = Vector2.zero;

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        GetKeyInput();
    }

    private void FixedUpdate() 
    {
        Move();
        Gravity();
        Jump();

        characterController.Move(moveVector * Time.deltaTime);
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
    
    private void GetKeyInput()
    {
        moveDir = (int)Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")) jumpOrder = true;
    }

    private void Move()
    {
        moveVector.x = moveDir * movementSpeed;
    }

    private void Gravity()
    {
        Vector2 origin = transform.position;
        origin.y -= characterController.bounds.extents.y;

        RaycastHit2D isGrounded = Physics2D.Raycast(origin, Vector2.down, characterController.skinWidth, LayerMask.GetMask("Ground"));
        if(isGrounded) 
        {
            moveVector.y = 0;
        }
        else
        {
            moveVector += Physics2D.gravity;
        }
    }

    private void Jump()
    {
        if(jumpOrder)
        {
            jumpOrder = false;
            moveVector.y = jumpForce;
        }
    }

    //~ Event Listener ~//

    //~ External ~//
}