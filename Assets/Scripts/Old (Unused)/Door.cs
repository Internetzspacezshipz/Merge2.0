using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Triggerable
{

    private Vector2 Origin;

    private void Awake()
    {   
        //So the collider can move back to the original position to close.
        Origin = _Collider.transform.position;
    }

    public override void TriggerableAction(bool openOrClose)
    {
        if (openOrClose == true)
        {
        
            //teleport the collider super far away.
            _Collider.transform.position = new Vector2(1000000,1000000);
        }
        if (openOrClose == false)
        {
        
            //Teleport the collider back to where it was originally.
            _Collider.transform.position = Origin;
        }
    }
}