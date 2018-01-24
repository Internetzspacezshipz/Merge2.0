using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float bulletTime = 1.0f;
    private Rigidbody2D _RB;
    public Vector2 direction;
    public bool destroyOnBox = true;
    public bool destroyBox;

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
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.FailUI();
        }
        if (collision.CompareTag("Ground"))
        {
            DestroyObject(gameObject); 
        }
        if (collision.CompareTag("Box"))
        {
            if (destroyOnBox == true)
            {
                DestroyObject(gameObject);
            }
            else if (destroyBox == true)
            {
                DestroyObject(collision.gameObject);
            }
        }
    }
}