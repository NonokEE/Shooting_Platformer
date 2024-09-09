using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    public class PlayerActionReceiver : MonoBehaviour
    {
        public PlayerInput PlayerInput { get => playerInput; set => playerInput = value; }
        private PlayerInput playerInput;

        public PlayerMovement PlayerMovement { get => playerMovement; set => playerMovement = value; }
        private PlayerMovement playerMovement;

        //

        private InputActionMap actionMap;

        private InputAction moveAction;
        private InputAction jumpAction;

        private InputAction mainFireAction;
        private InputAction subFireAction;

        private InputAction skillOneAction;
        private InputAction skillTwoAction;

        //

        private void Awake()
        {
            if (!Mouse.current.enabled) InputSystem.EnableDevice(Mouse.current);

            playerInput = playerInput != null ? playerInput : GetComponent<PlayerInput>();
            InitiateActions();
            Subscribe();
        }

        public void ChangePlayerInput(PlayerInput playerInput)
        {
            Describe();
            InitiateActions();
            Subscribe();
            this.playerInput = playerInput;
        }

        private void InitiateActions()
        {
            actionMap = playerInput.actions.FindActionMap("Player");

            moveAction = actionMap.FindAction("Move");
            jumpAction = actionMap.FindAction("Jump");

            mainFireAction = actionMap.FindAction("MainFire");
            subFireAction = actionMap.FindAction("SubFire");

            skillOneAction = actionMap.FindAction("SkillOne");
            skillTwoAction = actionMap.FindAction("SkillTwo");
        }

        private void Subscribe()
        {
            moveAction.performed += OnMove;
            jumpAction.performed += OnJump;

            mainFireAction.performed += OnMainFire;
            subFireAction.performed += OnSubFire;

            skillOneAction.performed += OnSkillOne;
            skillTwoAction.performed += OnSkillTwo;
        }

        public void Describe()
        {
            moveAction.performed -= OnMove;
            jumpAction.performed -= OnJump;

            mainFireAction.performed -= OnMainFire;
            subFireAction.performed -= OnSubFire;

            skillOneAction.performed -= OnSkillOne;
            skillTwoAction.performed -= OnSkillTwo;
        }

        private void OnMove(InputAction.CallbackContext val) => playerMovement.OnMove(val.ReadValue<Vector2>());
        private void OnJump(InputAction.CallbackContext val) => playerMovement.OnJump();
        private void OnMainFire(InputAction.CallbackContext val) => playerMovement.OnMainFire();
        private void OnSubFire(InputAction.CallbackContext val) => playerMovement.OnSubFire();
        private void OnSkillOne(InputAction.CallbackContext val) => playerMovement.OnSkillOne();
        private void OnSkillTwo(InputAction.CallbackContext val) => playerMovement.OnSkillTwo();
    }
}