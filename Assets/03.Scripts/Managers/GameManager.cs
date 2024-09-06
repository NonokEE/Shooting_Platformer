using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    //TODO InputStateManager 리워크
    // private InputStateManager inputStateManager = null;
    // public InputStateManager InputStateManager { get { return inputStateManager; } }

    //

    private void Awake() 
    {
        Singleton<GameManager>.Inst = this;
        InitiateStateMachine();
        InitiateManagers();
    }

    //

    
    private void InitiateManagers()
    {
        // if(inputStateManager == null)
        // {
        //     inputStateManager = Instantiate(new GameObject("InputStateManager")).AddComponent<InputStateManager>();
        //     inputStateManager.gameObject.name = "InputStateManager";
        // }
    }
}