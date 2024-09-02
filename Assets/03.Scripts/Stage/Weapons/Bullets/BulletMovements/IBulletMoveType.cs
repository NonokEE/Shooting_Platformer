using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Stage
{
    public interface IBulletMoveType
    {
        public Vector2 StartPosition{ get; set; }
    }

    public class NoMovement : IBulletMoveType
    {
        Vector2 IBulletMoveType.StartPosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
