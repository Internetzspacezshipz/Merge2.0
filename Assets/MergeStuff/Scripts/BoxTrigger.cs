using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TriggerableBoxDropScript ActivateTarget;
    [SerializeField]
    protected int numberOfHitsRequired = 1;
    protected bool Activated = false;
    private int numberOfHits = 0;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            ++numberOfHits;
            if (numberOfHits >= numberOfHitsRequired)
            {
                ActivateTarget.Movement();
            }
        }
    }

}
