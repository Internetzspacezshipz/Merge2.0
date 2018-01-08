using UnityEngine;

public class Trigger : MonoBehaviour
{
    //Target object to activate (doors, or other things that move and shit)
    [SerializeField]
    private Triggerable TargetObject;
    //Whether the trigger should stay active after a press.
    [SerializeField]
    private bool stayActive = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            TargetObject.TriggerableAction(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the stay active bool is false then do this.
        if (stayActive == false)
        {
            if (collision.transform.tag == "Player")
            {
                TargetObject.TriggerableAction(false);
            }
        }
    }
}