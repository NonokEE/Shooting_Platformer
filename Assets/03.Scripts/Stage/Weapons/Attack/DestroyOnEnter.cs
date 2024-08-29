using System;
using System.Collections;

using UnityEngine;

namespace Stage
{
    public class DestroyOnEnter : MonoBehaviour, IAttackEnter
    {
        public Attack Attack;
        public int Damage;
        public int Pierce;
        public Action DestroyCallback = () => {};

        public void Invoke(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                DestroyCallback();
                Destroy(gameObject);
            }
            else if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Character>().Hit(Attack, Damage);
                if(Pierce == -1) return;
                if(Pierce > 0) Pierce -= 1;
                if(Pierce == 0) 
                {
                    DestroyCallback();
                    Destroy(gameObject);
                }
            }
        }
    }
}