using UnityEngine;

public class TriggerScriptMultiTrigger0 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    TriggerScriptMulti MultiTriggerManager;

    protected bool Activated = false;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            MultiTriggerManager.TriggerActive0 = true;
            MultiTriggerManager.CheckIfOpen();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            MultiTriggerManager.TriggerActive0 = false;
            MultiTriggerManager.CheckIfOpen();
        }
    }
}