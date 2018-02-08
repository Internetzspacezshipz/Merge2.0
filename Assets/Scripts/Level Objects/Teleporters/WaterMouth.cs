using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMouth : MonoBehaviour
{
    private Animator _Animator;


    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _Animator.SetBool("Animate", true);
    }
}