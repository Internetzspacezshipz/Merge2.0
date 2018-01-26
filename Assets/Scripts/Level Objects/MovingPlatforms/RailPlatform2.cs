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
    Vector2[] locations = new Vector2[numberOfLocations];

    [SerializeField]
    private Ease easeType;

    private Tweener tweener;

    [SerializeField]
    private int loops;

    [SerializeField]
    private float duration = 4.0f;

    private void Awake()
    {

        tweener.SetEase(easeType);

    }

    public void SetActive()
    {
        active = true;
    }

    public void SetInactive()
    {
        active = false;
    }
}
