using System;
using System.Collections.Generic;

using UnityEngine;

public class FiniteStateMachine<T_Sender, T_State> where T_Sender : MonoBehaviour where T_State : Enum
{
    /******* FIELD *******/
    //~ Properties ~//
    public State<T_Sender> CurrentState { get; private set; }
    public enum EventType { Enter, Exit, Update }
    public bool SetUpdate;

    //~ Variables ~//
    private T_Sender sender;
    private Dictionary<T_State, State<T_Sender>> states;
    private Dictionary<T_State, Dictionary<T_State, Action>> transitions;

    /******* METHOD *******/
    public FiniteStateMachine(T_Sender headInstance, T_State startState)
    {
        sender = headInstance;

        states = new Dictionary<T_State, State<T_Sender>>();
        foreach(T_State stateName in Enum.GetValues(typeof(T_State)))
        {
            states.Add(stateName, new State<T_Sender>(sender, stateName.ToString(), Convert.ToInt32(stateName)));
        }
        CurrentState = states[startState];

        transitions = new Dictionary<T_State, Dictionary<T_State, Action>>();
    }

    public void AddEvent(T_State state, EventType eventType, Action action)
    {
        switch(eventType)
        {
            case EventType.Enter : states[state].OnEnter  += action; break;
            case EventType.Exit  : states[state].OnExit   += action; break;
            case EventType.Update: states[state].OnUpdate += action; break;
        }
    }

    //TODO action이 없는 경우에 대한 예외처리
    public void RemoveEvent(T_State state, EventType eventType, Action action)
    {
        switch(eventType)
        {
            case EventType.Enter : states[state].OnEnter  -= action; break;
            case EventType.Exit  : states[state].OnExit   -= action; break;
            case EventType.Update: states[state].OnUpdate -= action; break;
        }
    }

    public void AddTransition(T_State depart, T_State dest, Action action)
    {
        if(Enum.Equals(depart, dest)) 
        {
            Debug.LogWarning(sender.name + "'s FSM of " + nameof(T_State) + " is trying to add transition about same state: " + depart);
            return;
        }

        if(!transitions.ContainsKey(depart)) transitions.Add(depart, new Dictionary<T_State, Action>());    
        if(!transitions[depart].ContainsKey(dest)) transitions[depart].Add(dest, ()=>{});
        
        transitions[depart][dest] += action;
    }

    //TODO transition이 없는 경우에 대한 예외처리
    //TODO action이 없는 경우에 대한 예외처리
    public void RemoveTransition(T_State depart, T_State dest, Action action)
    {
        if(Enum.Equals(depart, dest)) 
        {
            Debug.LogWarning(sender.name + "'s FSM of " + nameof(T_State) + " is trying to operate remove transition about same state: " + depart);
            return;
        }
        transitions[depart][dest] -= action;
    }

    public void SetStatus(T_State next)
    {
        if(string.Equals(next.ToString(), CurrentState.Name))
        {
            Debug.LogWarning(sender.gameObject.name + " is trying to change to same status " + CurrentState);
        }
        else
        {
            T_State cur = (T_State) Enum.Parse(typeof(T_State), CurrentState.Name);

            if(SetUpdate)
            {
                SetUpdate = false;
            }

            CurrentState.OnExit.Invoke();

            if(transitions.ContainsKey(cur) && transitions[cur].ContainsKey(next)) 
            {
                transitions[cur][next].Invoke();
            }

            CurrentState = states[next];
            CurrentState.OnEnter.Invoke();
        }
    }

    /// <summary> This method should be contained in sender's MonoBehaviour.Update() if you want to make FSM executes it's Update function.  </summary>
    public void Update()
    {
        if(SetUpdate) CurrentState.OnUpdate.Invoke();
    }
}