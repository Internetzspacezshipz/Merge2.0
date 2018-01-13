using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float bulletTime = 1.0f;
    private Rigidbody2D _RB;
    public Vector2 direction;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _RB.AddForce(direction);
    }

    private void Update()
    {
        Destroy(gameObject, bulletTime);
    }

    //Restarts the game if the character enters the trigger area.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.instance.RestartGame();
        }
        else if (collision.transform.tag == "Ground")
        {
            DestroyObject(gameObject);
        }
    }
}