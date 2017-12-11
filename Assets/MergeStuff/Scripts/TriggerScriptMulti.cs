using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScriptMulti : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Triggerable ActivateTarget;
    [SerializeField]
    TriggerScriptMultiTrigger0 Trigger0;
    [SerializeField]
    TriggerScriptMultiTrigger1 Trigger1;
    protected bool Activated = false;
    public bool TriggerActive0 = false;
    public bool TriggerActive1 = false;
    #endregion

    public void CheckIfOpen()
    {
        if (TriggerActive0 == true && TriggerActive1 == true)
        {
            ActivateTarget.Movement();
        }
        else
        {
            ActivateTarget.MovementReverse();
        }
    }
}