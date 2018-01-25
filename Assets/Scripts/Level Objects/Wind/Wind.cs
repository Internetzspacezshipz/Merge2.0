using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private PlayerControl player;
    [SerializeField]
    private float windStrength = 1f;

    private AudioSource _AS;

    private void Awake()
    {
        _AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _AS.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            player = collision.GetComponentInParent<PlayerControl>();
            player.windEffect = windStrength;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _AS.Stop();

            player = collision.GetComponentInParent<PlayerControl>();
            player.windEffect = 0;
        }
    }
}