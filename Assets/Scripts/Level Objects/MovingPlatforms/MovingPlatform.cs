using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float duration = 5f;
    [SerializeField]
    private bool autoRun = false;

    [SerializeField]
    private GameObject endIndicator;
    private Vector3 origin;


    private IEnumerator coroutine;

    private void Awake()
    {
        origin = transform.position;
        SpriteRenderer temp = endIndicator.GetComponent<SpriteRenderer>();
        DestroyObject(temp);
        if (autoRun == true)
        {
            coroutine = AutoLoop();
            StartCoroutine(coroutine);
        }
    }



    public void MoveToEnd()
    {
        transform.DOMove(endIndicator.transform.position, duration);
    }

    public void MoveToOrigin()
    {
        transform.DOMove(origin, duration);
    }


    private IEnumerator AutoLoop()
    {
        while (autoRun == true)
        {
            MoveToEnd();
            yield return new WaitForSeconds(duration);
            MoveToOrigin();
            yield return new WaitForSeconds(duration);
        }
    }
}