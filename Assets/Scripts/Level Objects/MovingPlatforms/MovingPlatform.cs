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
    private Vector3 endPoint;

    [SerializeField]
    Ease easeType;


    private IEnumerator coroutine;

    private void Awake()
    {
        origin = transform.position;
        SpriteRenderer temp = endIndicator.GetComponent<SpriteRenderer>();

        endPoint = endIndicator.transform.position;


        DestroyObject(temp);
        if (autoRun == true)
        {
            StartCoroutine(AutoLoop());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box"))
        {
            other.transform.SetParent(gameObject.transform, true);
        }
    }


    public void MoveToEnd()
    {
        transform.DOMove(endPoint, duration).SetEase(easeType);
    }

    public void MoveToOrigin()
    {
        transform.DOMove(origin, duration).SetEase(easeType);
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