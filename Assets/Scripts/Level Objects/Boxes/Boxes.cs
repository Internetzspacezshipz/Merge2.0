using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private Rigidbody2D _RB;


    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.transform.CompareTag("Platform"))
        //{
        //    gameObject.transform.parent = other.transform;
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            gameObject.transform.parent = other.transform;

            Rigidbody2D _OtherRB = other.GetComponent<Rigidbody2D>();
            _RB.velocity = new Vector2(0, _RB.velocity.y);
        }
        if (other.transform.CompareTag("Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
        if (other.transform.CompareTag("Ground"))
        {
            gameObject.transform.parent = null;
        }

        gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.transform.parent = null;
        gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
}