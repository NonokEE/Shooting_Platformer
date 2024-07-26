using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public partial class GameManager
{
    public enum GameState { Playing, Pause }
    public GameState State
    {
        get { return Enum.Parse<GameState>(fsm.CurrentState.Name); }
        set { fsm.SetStatus(value); }
    }

    public FiniteStateMachine<GameManager, GameState> fsm;
    private void InitiateStateMachine()
    {
        fsm = new FiniteStateMachine<GameManager, GameState>(this, GameState.Playing);
    }
}