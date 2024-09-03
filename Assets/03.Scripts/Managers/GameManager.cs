using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public partial class GameManager : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    private InputManager inputManager = null;
    public InputManager InputManager { get { return inputManager; } }

    //~ Bindings ~//
    [SerializeField] private GameObject managerFolder;

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    //~ Singleton ~//
    public static GameManager Inst = null;
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

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        SetSingleton();
        InitiateStateMachine();
        InitiateManagers();
    }

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    private void InitiateManagers()
    {
        if(inputManager == null)
        {
            inputManager = Instantiate(new GameObject("InputManager"), managerFolder.transform).AddComponent<InputManager>();
        }
    }

    //~ Event Listener ~//

    //~ External ~//
}