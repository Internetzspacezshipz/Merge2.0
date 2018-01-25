using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField]
    private int checkpointNumber = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.currentCheckpoint = checkpointNumber;
        }
    }
}