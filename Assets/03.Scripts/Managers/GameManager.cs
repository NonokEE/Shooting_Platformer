using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private InputManager inputManager = null;
    public InputManager InputManager { get { return inputManager; } }

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
        if(inputManager == null)
        {
            inputManager = Instantiate(new GameObject("InputManager")).AddComponent<InputManager>();
            inputManager.gameObject.name = "InputManager";
        }
    }
}