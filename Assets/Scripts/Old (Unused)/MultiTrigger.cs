using UnityEngine;

public class MultiTrigger : MonoBehaviour
{
    [SerializeField]
    private TriggerController triggerController;
    [SerializeField]
    private bool stayActive = false;
    //This will be true if the trigger has already added one to the triggerCount
    private bool hasCounted = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            //if the player has already triggered this they will not be able to do it again.
            if (hasCounted == false)
            {
                ++triggerController.triggerCount;
                triggerController.CheckCount();
                hasCounted = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (stayActive == false)
        {
            if (collision.transform.tag == "Player")
            {
                //if the player has already triggered this they will not be able to do it again.

                if (hasCounted == true)
                {
                    --triggerController.triggerCount;
                    triggerController.CheckCount();
                    hasCounted = false;
                }
            }
        }
    }
}