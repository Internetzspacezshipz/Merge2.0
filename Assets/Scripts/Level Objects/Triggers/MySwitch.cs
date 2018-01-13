using UnityEngine;
using UnityEngine.Events;

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

    #endregion

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
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
}
