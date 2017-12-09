using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Triggerable ActivateTarget;

    protected bool Activated = false;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            ActivateTarget.Movement();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            ActivateTarget.MovementReverse();
        }
    }
}