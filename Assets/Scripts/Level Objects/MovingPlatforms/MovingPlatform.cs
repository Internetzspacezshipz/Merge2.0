using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float duration = 5f;

    [SerializeField]
    private GameObject endIndicator;
    private Vector3 origin;

    private void Awake()
    {
        origin = transform.position;
        SpriteRenderer temp = endIndicator.GetComponent<SpriteRenderer>();
        DestroyObject(temp);
    }

    public void MoveToEnd()
    {
        transform.DOMove(endIndicator.transform.position, duration);
    }

    public void MoveToOrigin()
    {
        transform.DOMove(origin, duration);
    }
}