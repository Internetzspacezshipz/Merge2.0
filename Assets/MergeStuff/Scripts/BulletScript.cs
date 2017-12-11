using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //How long the object exists for
    [SerializeField]
    private float _LifeSpan = 3f;
    [SerializeField]
    private float bulletSpeed = 1000f;

    //Destroys object after _LifeSpan
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.right * -bulletSpeed);
        Destroy(gameObject, _LifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyObject(gameObject);
    }

}
