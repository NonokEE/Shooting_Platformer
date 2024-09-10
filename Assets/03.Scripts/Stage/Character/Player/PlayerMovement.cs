using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public abstract class PlayerMovement : CharacterMovement
    {
        public abstract void OnJump();
    }
}