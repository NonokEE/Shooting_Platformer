using System.Collections;
using System.Collections.Generic;

using TMPro;
using Unity.Burst.Intrinsics;
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
        [Header("Hit Indicator Config")]
        public TMP_Text hitIndicatorPrefab;
        public Vector2 startOffset = Vector2.up;
        public Vector2 endValue = Vector2.up;
        public float Duration = 1;

        //~ Delegate & Event ~//

        //~ Debug ~//

        /******* EVENT FUNC *******/

        /******* INTERFACE IMPLEMENT *******/
        protected override void InitiateHitFeedback()
        {
            hitFeedback.Indicator = gameObject.AddComponent<BasicIndicator>();
            hitFeedback.Indicator.Initiate(this);

            var basicIndicator  = hitFeedback.Indicator as  BasicIndicator;
            basicIndicator.textPrefab = hitIndicatorPrefab;
            basicIndicator.StartOffset = startOffset;
            basicIndicator.EndValue = endValue;
            basicIndicator.Duration = Duration;
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