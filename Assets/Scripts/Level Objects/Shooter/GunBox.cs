using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : MonoBehaviour
{

    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private bool active = true;
    [SerializeField]
    private Vector2 _direction = new Vector2(1000,0);

    private void Start()
    {
        bullet.direction = _direction;

    }

    private void Update()
    {
        if (active == true)
        {

            Instantiate(bullet, transform);
        }
    }
}