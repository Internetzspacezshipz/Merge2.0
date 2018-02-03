using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lever : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TriggerOn;
    [SerializeField]
    private UnityEvent TriggerOff;
    [SerializeField]
    private bool cannotRetrigger = true;

    private bool alreadyTriggered = false;
    private bool triggerTimeNotUp = false;
    private AudioSource audioSource;




    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && Input.GetKey(KeyCode.E) && triggerTimeNotUp == false)
        {
            if (alreadyTriggered == false && triggerTimeNotUp == false)
            {
                audioSource.Play();

                TriggerOn.Invoke();
                alreadyTriggered = true;
            }
            else if (alreadyTriggered == true && cannotRetrigger == false && triggerTimeNotUp == false)
            {
                audioSource.Play();
                TriggerOff.Invoke();
                alreadyTriggered = false;
            }

            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        triggerTimeNotUp = true;
        yield return new WaitForSeconds(0.4f);
        triggerTimeNotUp = false;
    }
}