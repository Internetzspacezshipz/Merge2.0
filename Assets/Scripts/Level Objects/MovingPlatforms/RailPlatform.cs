using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RailPlatform : MonoBehaviour
{
    [SerializeField]
    private static int numberOfLocations = 3;

    public bool active = true;

    [SerializeField]
    Vector3[] locations = new Vector3[numberOfLocations];

    [SerializeField]
    private float duration = 4.0f;

    [SerializeField]
    Ease easeType;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box"))
        {
            other.transform.SetParent(gameObject.transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box"))
        {
            other.transform.SetParent(gameObject.transform, true);
        }
    }

    private void Start()
    {
        StartCoroutine(AutoLoop());
    }

    public void SetActive()
    {
        active = true;
    }

    public void SetInactive()
    {
        active = false;
    }

    private IEnumerator AutoLoop()
    {
        while (active == true)
        {
            foreach (Vector3 location in locations)
            {
                transform.DOMove(location, duration).SetEase(easeType);
                yield return new WaitForSeconds(duration);
            }
        }
    }
}