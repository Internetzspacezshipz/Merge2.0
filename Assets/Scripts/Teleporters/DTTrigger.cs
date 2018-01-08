using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTTrigger : MonoBehaviour
{
    [SerializeField]
    private DoubleTeleporter teleportManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            teleportManager.ActivateTeleport();
        }
    }
}