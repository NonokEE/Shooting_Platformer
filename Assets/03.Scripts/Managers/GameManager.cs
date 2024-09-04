using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private InputManager inputManager = null;
    public InputManager InputManager { get { return inputManager; } }

    public static GameManager Inst = null;

    //

    private void Awake() 
    {
        SetSingleton();
        InitiateStateMachine();
        InitiateManagers();
    }

    //

    private void SetSingleton()
    {
        if(Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitiateManagers()
    {
        if(inputManager == null)
        {
            inputManager = Instantiate(new GameObject("InputManager")).AddComponent<InputManager>();
            inputManager.gameObject.name = "InputManager";
        }
    }
}