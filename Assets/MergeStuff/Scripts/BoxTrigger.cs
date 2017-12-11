using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TriggerableBoxDropScript ActivateTarget;

    protected bool Activated = false;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            ActivateTarget.Movement();
        }
    }

}
