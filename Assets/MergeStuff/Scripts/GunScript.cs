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

    #endregion

    void Start()
    {
        StartCoroutine("enumerator");
    }

    IEnumerator enumerator()
    {
        while (gunOn == true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
