using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    //Restarts the game if the character enters the trigger area.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Death Zone");
        if (collision.transform.tag == "Player")
        {
            GameManager.instance.RestartGame();
        }
    }
}