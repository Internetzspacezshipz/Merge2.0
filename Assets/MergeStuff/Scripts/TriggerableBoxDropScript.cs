using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableBoxDropScript : MonoBehaviour
{

    private Rigidbody2D _RB;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
        _RB.gravityScale = 0;
    }

    public void Movement()
    {
        _RB.gravityScale = 1;
    }
}
