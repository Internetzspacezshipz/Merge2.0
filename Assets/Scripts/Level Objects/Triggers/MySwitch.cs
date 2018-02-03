using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider2D))]
public class MySwitch : MonoBehaviour
{
    #region variables

    [SerializeField]
    private bool cannotRetrigger = true;
    [SerializeField]
    private bool triggersOnBoxes = true;
    [SerializeField]
    private UnityEvent TriggerEnter;
    [SerializeField]
    private UnityEvent TriggerExit;
    private bool triggered = false;
    [SerializeField]
    private bool playsAudio = true;
    private bool triggerTimeNotUp = false;

    private AudioSource _AS;

    #endregion

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        _AS = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playsAudio == true && triggerTimeNotUp == false)
        {
            _AS.Play();
            StartCoroutine(WaitTime());
        }

        if (other.transform.CompareTag("Player") && triggered == false)
        {
            TriggerEnter.Invoke();
            if (cannotRetrigger == true)
            {
                triggered = true;
            }
        }
        if (other.transform.CompareTag("Box") && triggersOnBoxes == true && triggered == false)
        {
            TriggerEnter.Invoke();
            if (cannotRetrigger == true)
            {
                triggered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.transform.CompareTag("Player"))
        {
            TriggerExit.Invoke();

        }
        if (other.transform.CompareTag("Box") && triggersOnBoxes == true)
        {
            TriggerEnter.Invoke();

        }
    }

    private IEnumerator WaitTime()
    {
        triggerTimeNotUp = true;
        yield return new WaitForSeconds(0.3f);
        triggerTimeNotUp = false;
    }
}
