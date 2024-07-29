using System.Collections;
using System.Collections.Generic;
using Stage;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class HitBox : MonoBehaviour
{
    /******* FIELD *******/
    //~ Bindings ~//
    private IStageObject owner;

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        
    }
    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        
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

    //~ Event Listener ~//

    //~ External ~//
}