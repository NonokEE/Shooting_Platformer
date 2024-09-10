using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(PlayerInput))]
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

        //TODO 무기 input system 개편때 바꿔야 함.
        public Weapon Weapon { set => weapon = value; }
        private Weapon weapon;

        //

        private void Awake()
        {
            if (!Mouse.current.enabled) InputSystem.EnableDevice(Mouse.current);

            playerInput = playerInput != null ? playerInput : GetComponent<PlayerInput>();
            actionMap = playerInput.actions.FindActionMap("Player");

            moveAction = actionMap.FindAction("Move");
            jumpAction = actionMap.FindAction("Jump");

            mainFireAction = actionMap.FindAction("MainFire");
            subFireAction = actionMap.FindAction("SubFire");

            skillOneAction = actionMap.FindAction("SkillOne");
            skillTwoAction = actionMap.FindAction("SkillTwo");
        }

        private void FixedUpdate() 
        {
            if(mainFireAction.IsPressed()) OnMainHold();
            if(subFireAction.IsPressed()) OnSubHold();
            if(skillOneAction.IsPressed()) OnSkillOneHold();
            if(skillTwoAction.IsPressed()) OnSkillTwoHold();
        }

        //

        public void ApplyPlayerMovement(PlayerMovement playerMovement)
        {
            if(playerMovement != null)
            {
                Describe();
                Destroy(this.playerMovement);
            }
            this.playerMovement = playerMovement;
            Subscribe();
        }

        private void Subscribe()
        {
            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;
            jumpAction.performed += OnJump;

            //TODO Weapon, Skill을 InputSystem 기반으로 리팩토링 할 때 수정 필요. (아마 그냥 삭제하면 될 듯. WeaponActionReceiver에서 입력 처리 할테니까.)
            mainFireAction.started += OnMainDown;
            mainFireAction.canceled += OnMainUp;

            subFireAction.started += OnSubDown;
            subFireAction.canceled += OnSubUp;

            skillOneAction.started += OnSkillOneDown;
            skillOneAction.canceled += OnSkillOneUp;

            skillTwoAction.started += OnSkillTwoDown;
            skillTwoAction.canceled += OnSkillTwoUp;
        }

        public void Describe()
        {
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;
            jumpAction.performed -= OnJump;

            //TODO Weapon, Skill을 InputSystem 기반으로 리팩토링 할 때 수정 필요. (아마 그냥 삭제하면 될 듯. WeaponActionReceiver에서 입력 처리 할테니까.)
            mainFireAction.started -= OnMainDown;
            mainFireAction.canceled -= OnMainUp;

            subFireAction.started -= OnSubDown;
            subFireAction.canceled -= OnSubUp;

            skillOneAction.started -= OnSkillOneDown;
            skillOneAction.canceled -= OnSkillOneUp;

            skillTwoAction.started -= OnSkillTwoDown;
            skillTwoAction.canceled -= OnSkillTwoUp;
        }

        private void OnMove(InputAction.CallbackContext val) => playerMovement.OnMove(val.ReadValue<Vector2>());
        private void OnJump(InputAction.CallbackContext val) => playerMovement.OnJump();
        
        //TODO Weapon, Skill을 InputSystem 기반으로 리팩토링 할 때 수정 필요. (아마 그냥 삭제하면 될 듯. WeaponActionReceiver에서 입력 처리 할테니까.)
        private void OnMainDown(InputAction.CallbackContext val) => weapon.OnLeftDown.Invoke();
        private void OnMainHold() => weapon.OnLeftHold.Invoke();
        private void OnMainUp(InputAction.CallbackContext val) => weapon.OnLeftUp.Invoke();

        private void OnSubDown(InputAction.CallbackContext val) => weapon.OnRightDown.Invoke();
        private void OnSubHold() => weapon.OnRightHold.Invoke();
        private void OnSubUp(InputAction.CallbackContext val) => weapon.OnRightUp.Invoke();

        private void OnSkillOneDown(InputAction.CallbackContext val){}
        private void OnSkillOneHold(){}
        private void OnSkillOneUp(InputAction.CallbackContext val){}

        private void OnSkillTwoDown(InputAction.CallbackContext val){}
        private void OnSkillTwoHold(){}
        private void OnSkillTwoUp(InputAction.CallbackContext val){}
    }
}