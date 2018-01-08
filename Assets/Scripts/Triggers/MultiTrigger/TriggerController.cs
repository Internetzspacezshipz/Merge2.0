using UnityEngine;

public class TriggerController : MonoBehaviour
{

    [SerializeField]
    private Triggerable TargetObject;

    //how many triggers are needed to activate the triggerable.
    [SerializeField]
    private int requiredTriggers = 2;
    //how many triggers have been activated so far, MultiTrigger adds one every time they are triggered. They subtract one if they are deactivated.
    internal int triggerCount = 0;

    /*if the trigger controller allows more than the required amount of activated triggers to open the door.
     * For example, if the TriggerController requires two triggers, and three are activated, the door will close.
     * If allowOverCount is true then there will be no concequences for going over the required number.
     * If allowOverCount is false then the door will close when the required number is exceeded.
     */
    [SerializeField]
    private bool allowOverCount = true;

    public void CheckCount()
    {
        if (triggerCount == requiredTriggers)
        {

            TargetObject.TriggerableAction(true);
        }

        if (triggerCount > requiredTriggers)
        {

            TargetObject.TriggerableAction(false);
        }

        if (triggerCount < requiredTriggers && allowOverCount == false)
        {

            TargetObject.TriggerableAction(false);
        }
    }
}