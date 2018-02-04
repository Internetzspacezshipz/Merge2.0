using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class Lever : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TriggerOn;
    [SerializeField]
    private UnityEvent TriggerOff;
    [SerializeField]
    private bool cannotRetrigger = true;

    [SerializeField]
    private GameObject lever;
    [SerializeField]
    private Ease easeType;


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
                rotateLever();
            }
            else if (alreadyTriggered == true && cannotRetrigger == false && triggerTimeNotUp == false)
            {
                audioSource.Play();
                TriggerOff.Invoke();
                alreadyTriggered = false;
                rotateLever();
            }

            StartCoroutine(WaitTime());
        }
    }


    private void rotateLever()
    {
        if (alreadyTriggered == true)
        {
            lever.transform.DORotate(new Vector3(0,0, -70), 0.3f).SetEase(easeType);
        }
        else
        {
            lever.transform.DORotate(new Vector3(0, 0, 0), 0.3f).SetEase(easeType);
        }
    }

    private IEnumerator WaitTime()
    {
        triggerTimeNotUp = true;
        yield return new WaitForSeconds(0.4f);
        triggerTimeNotUp = false;
    }
}