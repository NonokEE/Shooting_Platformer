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
        fsm = new FiniteStateMachine<Debugger, TestState>(this, TestState.Idle);
        //fsm = gameObject.AddComponent<FiniteStateMachine<Debugger, TestState>>();

        fsm.AddEvent(TestState.Idle, FiniteStateMachine<Debugger, TestState>.EventType.Enter, EnterTest);
        fsm.AddEvent(TestState.Idle, FiniteStateMachine<Debugger, TestState>.EventType.Exit, ExitTest);

        fsm.AddEvent(TestState.Wait, FiniteStateMachine<Debugger, TestState>.EventType.Enter, EnterTest);
        fsm.AddEvent(TestState.Wait, FiniteStateMachine<Debugger, TestState>.EventType.Update, UpdateTest);
        fsm.AddEvent(TestState.Wait, FiniteStateMachine<Debugger, TestState>.EventType.Exit, ExitTest);
        
        fsm.AddTransition(TestState.Idle, TestState.Wait, Idle_Wait);
        fsm.AddTransition(TestState.Wait, TestState.Attack, Wait_Attack);
        fsm.AddTransition(TestState.Attack, TestState.Idle, Attack_Idle);

        fsm.SetStatus(TestState.Wait);
        fsm.SetStatus(TestState.Attack);
        fsm.SetStatus(TestState.Idle);
        fsm.SetStatus(TestState.Attack);
        fsm.SetStatus(TestState.Idle);
        fsm.SetStatus(TestState.Wait);

        fsm.SetUpdate = true;
    }

    private void Update() 
    {
        fsm.Update();
    }

    private void EnterTest() { Debug.Log("    Entering " + fsm.CurrentState.Name); }
    private void UpdateTest() { Debug.Log("    Updating " + fsm.CurrentState.Name); }
    private void ExitTest() { Debug.Log("    Exiting " + fsm.CurrentState.Name); }

    private void Idle_Wait()   { Debug.Log("Idle -> Wait");}
    private void Wait_Attack() { Debug.Log("Wait -> Attack");}
    private void Attack_Idle() { Debug.Log("Attack -> Idle");}
}

