using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using Stage;
using DG.Tweening;
using Unity.Burst.Intrinsics;

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
    [SerializeField] private InputAction jumpAction;

    [SerializeField] private InputAction mousePosition;
    [SerializeField] private InputAction mainFireAction;
    [SerializeField] private InputAction subFireAction;


    private void Awake() 
    {
        playerInput = playerInput != null ? playerInput : GetComponent<PlayerInput>();
        actionMap = playerInput.actions.FindActionMap("Player");

        moveAction = actionMap.FindAction("Move");
        jumpAction = actionMap.FindAction("Jump");

        mainFireAction = actionMap.FindAction("MainFire");
        subFireAction = actionMap.FindAction("SubFire");

        mainFireAction.performed += param => Debug.Log("MainFire Performed");

        moveAction.performed += param => Debug.Log(param.ReadValue<Vector2>());
        jumpAction.performed += param => Debug.Log("Jump Performed");

        if(! Mouse.current.enabled) InputSystem.EnableDevice(Mouse.current);
    }

    private void Update()
    {

    }
}