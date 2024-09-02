using System;
using System.Collections;

using UnityEngine;

namespace Stage
{
    public class HitOnEnter : MonoBehaviour, IAttackEnter
    {
        public Attack Attack;
        public int Damage;
        public void Invoke(Collider2D other)
        {
            other.gameObject.GetComponent<Character>().Hit(Attack, Damage);
        }
    }
}