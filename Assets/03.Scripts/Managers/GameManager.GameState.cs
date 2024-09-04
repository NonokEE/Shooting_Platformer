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
    public enum GameState { Loading, Playing, Pause }
    public GameState State
    {
        get { return Enum.Parse<GameState>(StateMachine.CurrentState.Name); }
        set { StateMachine.SetStatus(value); }
    }

    public FiniteStateMachine<GameManager, GameState> StateMachine;
    private void InitiateStateMachine()
    {
        StateMachine = new FiniteStateMachine<GameManager, GameState>(this, GameState.Loading);

        StateMachine.AddEvent(GameState.Pause, FiniteStateMachine<GameManager, GameState>.EventType.Enter, () => { Time.timeScale = 0; });
        StateMachine.AddEvent(GameState.Pause, FiniteStateMachine<GameManager, GameState>.EventType.Exit, () => { Time.timeScale = 1.0f; });
        StateMachine.SetStatus(GameState.Playing);
    }
}