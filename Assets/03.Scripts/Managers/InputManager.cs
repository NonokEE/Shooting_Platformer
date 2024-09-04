using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> GameManager의 State와 Input에 대응하여, GameManager의 State를 별경 </summary>
public partial class InputManager : MonoBehaviour
{
    private Dictionary<GameManager.GameState, Action> OnUpdate;

    private void Awake()
    {
        Singleton<InputManager>.Inst = this;

        OnUpdate = new Dictionary<GameManager.GameState, Action>();
        foreach(GameManager.GameState gameState in Enum.GetValues(typeof(GameManager.GameState)))
        {
            OnUpdate[gameState] = () => {};
        }
        OnUpdate[GameManager.GameState.GamePlaying] = OnUpdate_GamePlaying;
        OnUpdate[GameManager.GameState.GamePause] = OnUpdate_GamePause;
    }

    private void Update() 
    {
        OnUpdate[Singleton<GameManager>.Inst.State].Invoke();
    }
}