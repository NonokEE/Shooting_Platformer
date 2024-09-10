using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerController Config")]
        private InputActionAsset playerAction;
        public InputActionAsset PlayerAction { get => playerAction; set => playerAction = value; }

        private PlayerInput playerInput;
        private PlayerActionReceiver actionReceiver;
        private PlayerMovement playerMovement;

        private PlayerObject sender;
        public PlayerObject Sender => sender;

        public void Initiate(PlayerObject sender) 
        {
            this.sender = sender;

            playerInput = GetComponent<PlayerInput>();
            playerInput.actions = PlayerAction;

            actionReceiver = gameObject.AddComponent<PlayerActionReceiver>();
            playerMovement = gameObject.AddComponent<PlayerMovement_Gravity>();

            actionReceiver.Weapon = sender.CurrentWeapon;
            actionReceiver.ApplyPlayerMovement(playerMovement);

            playerMovement.Collider = GetComponent<Collider2D>();
            playerMovement.Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}