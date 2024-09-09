using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerObject Config")]
        [SerializeField] private InputActionAsset playerAction;
        
        private PlayerInput playerInput;
        private PlayerActionReceiver actionReceiver;
        private PlayerMovement playerMovement;

        private void Awake() 
        {
            playerInput = GetComponent<PlayerInput>();
            playerInput.actions = playerAction;

            actionReceiver = gameObject.AddComponent<PlayerActionReceiver>();
            playerMovement = gameObject.AddComponent<PlayerMovement_Gravity>();

            actionReceiver.ApplyPlayerMovement(playerMovement);
            playerMovement.Collider = GetComponent<Collider2D>();
            playerMovement.Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}