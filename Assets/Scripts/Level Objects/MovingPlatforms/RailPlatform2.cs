using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RailPlatform2 : MonoBehaviour
{
    [SerializeField]
    private static int numberOfLocations = 3;

    public bool active = true;

    [SerializeField]
    Vector3[] locations = new Vector3[numberOfLocations];

    [SerializeField]
    private Ease easeType;

    private Tweener tweener;

    [SerializeField]
    private int loops;

    [SerializeField]
    private float duration = 4.0f;

    private IEnumerator coroutine;

    private void Awake()
    {
        tweener.SetLoops(loops, LoopType.Yoyo);
        tweener.SetEase(easeType);
        transform.DOMove(new Vector3(0, 0, 0), duration);
    }

    private void Start()
    {
        //coroutine = AutoLoop();
        //StartCoroutine(coroutine);
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
                transform.DOMove(location, duration);
                yield return new WaitForSeconds(duration);
            }
        }
    }
}
