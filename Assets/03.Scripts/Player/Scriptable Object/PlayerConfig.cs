using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Object/PlayerConfig", order = 0)]
public class PlayerConfig : ScriptableObject
{
    [Header("Rigidbody Parameters")]
    public float Mass;
    public float GravityScale;
    public RigidbodyType2D BodyType;

    [Header("Controller Parameters")]
    public float MoveAcceleration;
    public float MaxSpeed;

        [Space]
    public float JumpForce;
    public int MaxJumpCount;
    public float MaxFreeFall;

}