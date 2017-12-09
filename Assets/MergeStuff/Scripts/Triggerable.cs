using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Triggerable : MonoBehaviour
{
    #region variables

    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float duration;
    [SerializeField]
    private Ease easetype;
    [SerializeField]
    private LoopType loopType;
    [SerializeField]
    private int loopCount = 1;
    //[SerializeField]
    //TriggerScript Trigger;
    public bool activate;
    private Vector3 origin;

    #endregion

    private void Awake()
    {
        origin = transform.position;
    }

    public void Movement()
    {
        Tweener moveTween = transform.DOMove(endPosition, duration);
        moveTween.SetRelative(false);
        moveTween.SetLoops(loopCount, loopType);
        moveTween.SetEase(easetype);
    }

    public void MovementReverse()
    {
        Tweener moveTween = transform.DOMove(origin, duration);
        moveTween.SetRelative(false);
        moveTween.SetLoops(loopCount, loopType);
        moveTween.SetEase(easetype);
    }
}
