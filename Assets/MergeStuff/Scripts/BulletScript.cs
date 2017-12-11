using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //How long the object exists for
    [SerializeField]
    private float _LifeSpan = 3f;

    //Destroys object after _LifeSpan
    void Start()
    {
        Destroy(gameObject, _LifeSpan);
    }
}
