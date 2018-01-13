using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class MySwitch : MonoBehaviour
{

    [SerializeField]
    private bool triggersOnBoxes = true;

    [SerializeField]
    private UnityEvent TriggerEnter;
    [SerializeField]
    private UnityEvent TriggerExit;
    [SerializeField]
    private UnityEvent TriggerStay;
    
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") || other.transform.CompareTag("Box"))
        {
            TriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") || other.transform.CompareTag("Box"))
        {
            TriggerExit.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") || other.transform.CompareTag("Box"))
        {
            TriggerStay.Invoke();
        }
    }
}
