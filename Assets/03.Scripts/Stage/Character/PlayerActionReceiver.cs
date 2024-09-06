using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class PlayerActionReceiver : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputActionMap actionMap;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction mainFireAction;
    [SerializeField] private InputAction subFireAction;
    [SerializeField] private InputAction jumpAction;
    [SerializeField] private InputAction testAction;

    private void Awake() 
    {
        playerInput = playerInput != null ? playerInput : GetComponent<PlayerInput>();
        actionMap = playerInput.actions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        mainFireAction = actionMap.FindAction("MainFire");
        subFireAction = actionMap.FindAction("SubFire");
        jumpAction = actionMap.FindAction("Jump");
        testAction = actionMap.FindAction("Test");

        moveAction.started += cnt => { Debug.Log("move started"); };
        moveAction.performed += cnt => { Debug.Log("move performed"); };
        moveAction.canceled += cnt => { Debug.Log("move canceled"); };

        testAction.started += cnt => { Debug.Log("test started"); };
        testAction.performed += cnt => { Debug.Log("test performed"); };
        testAction.canceled += cnt => { Debug.Log("test canceled"); };
    }
}