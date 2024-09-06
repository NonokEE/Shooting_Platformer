using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using Stage;
using DG.Tweening;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class PlayerActionReceiver : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] private PlayerInput playerInput;
    private InputActionMap actionMap;

    private InputAction moveAction;
    private InputAction jumpAction;

    private InputAction mainFireAction;
    private InputAction subFireAction;

    private void Awake() 
    {
        playerInput = playerInput != null ? playerInput : GetComponent<PlayerInput>();
        actionMap = playerInput.actions.FindActionMap("Player");

        moveAction = actionMap.FindAction("Move");
        jumpAction = actionMap.FindAction("Jump");

        mainFireAction = actionMap.FindAction("MainFire");
        subFireAction = actionMap.FindAction("SubFire");

        mainFireAction.started += param => { Debug.Log("started" );};
        mainFireAction.performed += param => { Debug.Log("performed");};
        mainFireAction.canceled += param => { Debug.Log("canceled");};

        moveAction.performed += param => Debug.Log(param.ReadValue<Vector2>());
    }

    private void Update()
    {
        if (Mouse.current != null)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Debug.Log("Mouse Position: " + mousePosition);
        }
        else
        {
            Debug.LogWarning("Mouse input is not available.");
        }
    }
}