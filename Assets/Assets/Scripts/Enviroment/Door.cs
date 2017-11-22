using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{

    public Vector3 endPosition;
    public float duration;
    public Ease easetype;
    public LoopType loopType;
    private Vector3 _StartPosi;

    private void Start()
    {
        _StartPosi = transform.position;
    }


    // Update is called once per frame
    void Update ()
    {
        if (Globals.instance.doorOpen == true)
        {
            Tweener moveTween = transform.DOMove(endPosition, duration);
            moveTween.SetRelative(true);
            moveTween.SetLoops(-1, loopType);
            moveTween.SetEase(easetype);
        }
        else if (Globals.instance.doorOpen == false)
        {
            Tweener moveTween = transform.DOMove(_StartPosi, duration);
        }
    }
}
