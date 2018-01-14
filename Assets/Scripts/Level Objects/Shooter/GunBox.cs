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
    private bool _destroyOnBox = true;
    [SerializeField]
    private bool _destroyBox = false;
    [SerializeField]
    private Vector2 _direction = new Vector2(1000,0);

    private void Start()
    {
        bullet.direction = _direction;
        bullet.destroyOnBox = _destroyOnBox;
        bullet.destroyBox = _destroyBox;
    }

    private void Update()
    {
        if (active == true)
        {

            Instantiate(bullet, transform);
        }
    }
}