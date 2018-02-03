using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lever : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TriggerOn;
    [SerializeField]
    private bool cannotRetrigger = true;
    private bool alreadyTriggered = false;



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (alreadyTriggered == false)
            {
                TriggerOn.Invoke();
                alreadyTriggered = true;
            }
        }
    }
}