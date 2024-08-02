using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Stage
{
    /// <summary> </summary>
    /// <remarks>
    ///
    /// </remarks>
    public class Enemy : Character
    {
        /******* FIELD *******/
        //~ Properties ~//

        //~ Bindings ~//

        //~ For Funcs ~//
        [Header("Enemy Config")]
        public Text hitIndicatorPrefab;

        //~ Delegate & Event ~//

        //~ Debug ~//

        /******* EVENT FUNC *******/

        /******* INTERFACE IMPLEMENT *******/
        protected override void InitiateHitFeedback()
        {
            hitFeedback.Indicator = gameObject.AddComponent<BasicIndicator>();
            hitFeedback.Indicator.Initiate(this);
            (hitFeedback.Indicator as  BasicIndicator).textPrefab = hitIndicatorPrefab;
            
        }

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
}