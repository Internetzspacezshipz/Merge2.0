using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : MonoBehaviour
{

    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    internal bool active = true;
    [SerializeField]
    private bool _destroyOnBox = true;
    [SerializeField]
    private bool _destroyBox = false;
    [SerializeField]
    private Vector2 _direction = new Vector2(1000, 0);
    [SerializeField]
    private float rateOfFire = 1.0f;

    private Bullet bulletInstance;

    private IEnumerator fire;

    private void Awake()
    {
        if (active == true)
        {
            fire = AutoFire();
            StartCoroutine(fire);
        }
    }

    private IEnumerator AutoFire()
    {
        while (active == true)
        {
            bulletInstance = Instantiate(bullet, transform);
            bulletInstance.direction = _direction;
            bulletInstance.destroyOnBox = _destroyOnBox;
            bulletInstance.destroyBox = _destroyBox;

            yield return new WaitForSeconds(rateOfFire);
        }
    }
}