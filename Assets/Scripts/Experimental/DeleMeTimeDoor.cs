using UnityEngine;

public class DeleMeTimeDoor : MonoBehaviour
{

    public float timeToWait = 3;
    
    public void StartTimer()
    {
        Invoke("ReEnableDoor", timeToWait);
    }
    
    private void ReEnableDoor()
    {
        EnableDisableDoor(true);
    }
    
    
    public void EnableDisableDoor(bool val)
    {
        GetComponent<Renderer>().enabled = val;
        GetComponent<Collider2D>().enabled = val;
    }
}
