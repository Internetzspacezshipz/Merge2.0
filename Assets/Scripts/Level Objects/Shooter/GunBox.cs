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
    private Vector2 _direction = new Vector2(1000, 0);
    [SerializeField]
    private float rateOfFire = 1.0f;

    private IEnumerator fire;

    private void Awake()
    {
        if (active == true)
        {
            fire = AutoFire();
            StartCoroutine(fire);
        }
    }

    private void Start()
    {
        bullet.direction = _direction;
        bullet.destroyOnBox = _destroyOnBox;
        bullet.destroyBox = _destroyBox;
    }

    private IEnumerator AutoFire()
    {
        while (active == true)
        {
            Instantiate(bullet, transform);
            yield return new WaitForSeconds(rateOfFire);
        }
    }
}