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
    Vector2[] locations = new Vector2[numberOfLocations];

    [SerializeField]
    private float duration = 4.0f;

    [SerializeField]
    Ease easeType;

    private Tweener tween;

    private IEnumerator coroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box"))
        {
            other.transform.SetParent(gameObject.transform, true);
        }
    }


    private void Awake()
    {
        coroutine = AutoLoop();
        StartCoroutine(coroutine);
    }

    private void Start()
    {
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
            foreach (Vector2 location in locations)
            {
                transform.DOMove(location, duration).SetEase(easeType);
                yield return new WaitForSeconds(duration);
            }
        }
    }

}