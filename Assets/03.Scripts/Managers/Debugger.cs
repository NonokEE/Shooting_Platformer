using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class Debugger : MonoBehaviour
{
    /******* FIELD *******/
    //~ Debug ~//
    public enum TestState { Idle, Wait, Attack }
    public FiniteStateMachine<Debugger, TestState> fsm;

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        Debug.Log(GameManager.Inst.name);
    }
}

