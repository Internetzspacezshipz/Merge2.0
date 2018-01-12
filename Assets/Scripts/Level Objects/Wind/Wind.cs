using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private PlayerControl player;
    [SerializeField]
    private float windStrength = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.windEffect = windStrength;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.windEffect = 0;
        }
    }
}