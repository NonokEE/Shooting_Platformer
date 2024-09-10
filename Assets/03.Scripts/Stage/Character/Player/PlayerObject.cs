using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Stage
{
    [AddComponentMenu("SquareExtream/Stage/Player Object (Script)")]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerObject : CharacterObject
    {
            [Header("Player Config")]
        [SerializeField] private Weapon weaponPrefab;

            [Space]
        [SerializeField] private InputActionAsset playerAction;

        private PlayerController playerController;
        private PlayerInfo playerInfo;

        private Weapon currentWeapon;
        public Weapon CurrentWeapon => currentWeapon;

        //

        public override int MaxHp => playerInfo.MaxHp;
        public override int CurrentHp => playerInfo.CurrentHp;
        public override HitBox HitBox => playerInfo.HitBox;

        //~~ Evnet Func ~//
        protected override void Awake() 
        {
            currentWeapon = Instantiate(weaponPrefab, transform);
            currentWeapon.AttackInfo.Attacker = this;
            currentWeapon.Initiate();

            playerController = gameObject.AddComponent<PlayerController>();
            playerController.PlayerAction = playerAction;
            playerController.Initiate(this);

            playerInfo = new()
            {
                MaxHp = maxHp,
                CurrentHp = currentHp,
                HitBox = hitBox,
                Weapon = currentWeapon
            };

        }
    }

    public class PlayerInfo : CharacterInfo
    {
        private Weapon weapon;
        public Weapon Weapon { get => weapon; set => weapon = value; }
    }
}