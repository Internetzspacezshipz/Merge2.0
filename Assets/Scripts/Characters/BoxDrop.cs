using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    PlayerControl controller;
    BoxPull boxPull;


    private void Awake()
    {
        controller = GetComponentInParent<PlayerControl>();
        boxPull = GetComponentInParent<BoxPull>();
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            boxPull.DropBox();
        }
    }
}