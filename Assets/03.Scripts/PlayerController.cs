using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

//TODO 중력 구현
/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class PlayerController : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] private float movementSpeed = 0.3f;

    //~ Bindings ~//
    private CharacterController characterController;

    //~ For Funcs ~//
    private int movement;
    private bool isGrounded;

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
        movement = (int)Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        switch(movement)
        {
            case -1: characterController.Move(Vector2.left * movementSpeed); break;
            case  0: characterController.Move(Vector2.zero * movementSpeed); break;
            case  1: characterController.Move(Vector2.right * movementSpeed); break;
        }
    }

    private void Gravity()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down);
    }

    //~ Event Listener ~//

    //~ External ~//
}