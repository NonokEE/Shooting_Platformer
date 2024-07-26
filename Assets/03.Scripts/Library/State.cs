using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class State<T_Sender> 
{
    //~ Properties ~//
    public int StateValue { get; private set; }
    public string Name { get; private set; }

    public Action OnEnter = ()=>{};
    public Action OnExit = ()=>{};
    public Action OnUpdate = ()=>{};

    //~ Variables ~//
    private T_Sender sender;

    //~ Methods ~//
    public State(T_Sender senderInstance, string name, int stateValue)
    {
        sender = senderInstance;
        Name = name;
        StateValue = stateValue;
    }
}