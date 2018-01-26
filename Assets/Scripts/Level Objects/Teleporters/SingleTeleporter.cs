using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTeleporter : MonoBehaviour
{
    //This is where you want the teleported character to go
    [SerializeField]
    GameObject targetLocation;
    //Allowed you to set the teleported object so you can hit a trigger and teleport the other character to somewhere.
    PlayerControl teleportCharacter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            teleportCharacter = collision.GetComponent<PlayerControl>();

            teleportCharacter.transform.position = targetLocation.transform.position;
        }
    }
}