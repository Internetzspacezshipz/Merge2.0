using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour {

    public Vector3 endPosition;
    public float duration;
    public Ease easetype;
    public LoopType loopType;


	// Use this for initialization
	void Start ()
    {
        Tweener moveTween = transform.DOMove(endPosition, duration);
        moveTween.SetRelative(true);
        moveTween.SetLoops(-1, loopType);
        moveTween.SetEase(easetype);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
