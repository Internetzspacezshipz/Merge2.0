using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{

    /*if the trigger controller allows more than the required amount of activated triggers to open the door.
     * For example, if the TriggerController requires two triggers, and three are activated, the door will close.
     * If allowOverCount is true then there will be no concequences for going over the required number.
     * If allowOverCount is false then the door will close when the required number is exceeded.
     */
    [SerializeField]
    private bool allowOverCount = true;

    //how many triggers are needed to activate the triggerable.
    [SerializeField]
    private int requiredTriggers = 2;

    [SerializeField]
    private UnityEvent TriggerActivate;
    [SerializeField]
    private UnityEvent TriggerEnd;
    //how many triggers have been activated so far, MultiTrigger adds one every time they are triggered. They subtract one if they are deactivated.
    internal int triggerCount = 0;

    public void AddOne()
    {
        ++triggerCount;
    }

    public void SubtractOne()
    {
        --triggerCount;
    }

    public void CheckCount()
    {
        if (triggerCount == requiredTriggers)
        {
            TriggerActivate.Invoke();
        }

        if (triggerCount > requiredTriggers)
        {
            TriggerEnd.Invoke();
        }

        if (triggerCount < requiredTriggers && allowOverCount == false)
        {
            TriggerEnd.Invoke();
        }
    }
}