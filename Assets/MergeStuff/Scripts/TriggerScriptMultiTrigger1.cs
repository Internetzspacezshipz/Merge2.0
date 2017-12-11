using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScriptMultiTrigger1 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TriggerScriptMulti MultiTriggerManager;

    protected bool Activated = false;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            MultiTriggerManager.TriggerActive1 = true;
            MultiTriggerManager.CheckIfOpen();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            MultiTriggerManager.TriggerActive1 = false;
            MultiTriggerManager.CheckIfOpen();
        }
    }
}
