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
    [SerializeField]
    private float delayBeforeFirstShot = 0.0f;

    private Soul soul;
    private Body body;

    private AudioSource _AS;

    private Bullet bulletInstance;

    private bool shootingSounds = true;

    private IEnumerator fire;

    private bool isFarV;
    private bool isFarS;

    private void Start()
    {
        soul = GameManager.instance.soul;
        body = GameManager.instance.body;
        
        _AS = GetComponent<AudioSource>();
        if (active == true)
        {
            fire = AutoFire();
            StartCoroutine(Delay());
        }
    }


    private void Update()
    {
        if (soul.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).x > 1.3f)
        {
            isFarS = true;
            Debug.Log("Somewhere away SOUL");

        }
        else if (soul.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).x < -0.3f)
        {
            isFarS = true;

            Debug.Log("Somewhere awaySOUL");
        }

        else if (soul.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).y > 1.3f)
        {
            isFarS = true;

            Debug.Log("Somewhere away SOUL");
        }

        else if (soul.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).y < -0.3f)
        {
            isFarS = true;

            Debug.Log("Somewhere awaySOUL");
        }
        else
        {
            isFarS = false;
        }

        if (body.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).x > 1.3f)
        {
            isFarV = true;

            Debug.Log("Somewhere awaBDYy");
        }
        else if (body.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).x < -0.3f)
        {
            isFarV = true;

            Debug.Log("Somewhere awaBDYy");
        }

        else if (body.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).y > 1.3f)
        {
            isFarV = true;

            Debug.Log("Somewhere awaBDTy");
        }

        else if (body.GetComponentInChildren<Camera>().WorldToViewportPoint(gameObject.transform.position).y < -0.3f)
        {
            isFarV = true;

            Debug.Log("Somewhere awaBDYy");
        }
        else
        {
            isFarV = false;
        }
    }

    private IEnumerator AutoFire()
    {
        while (active == true)
        {
            if (isFarV == false || isFarS == false)
            {
                _AS.Play();
            }
            bulletInstance = Instantiate(bullet, transform);
            bulletInstance.direction = _direction;
            bulletInstance.destroyOnBox = _destroyOnBox;
            bulletInstance.destroyBox = _destroyBox;

            yield return new WaitForSeconds(rateOfFire);
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayBeforeFirstShot);
        StartCoroutine(fire);
    }
}