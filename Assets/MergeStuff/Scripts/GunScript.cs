using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    bool gunOn = true;
    [SerializeField]
    float fireRate = 0.5f;

    #endregion

    void Start()
    {
        StartCoroutine("enumerator");
    }

    IEnumerator enumerator()
    {
        while (gunOn == true)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
