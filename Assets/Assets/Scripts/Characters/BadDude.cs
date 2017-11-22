using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDude : BaseUnit
{
    private int direction = 1;



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            direction *= -1;
        }
    }



    private void Update()
    {
        Move(direction);
        if (!IsGrounded (raycastOffset))
        {
            direction = -1;
        }
        else if (!IsGrounded (-raycastOffset))
        {
            direction = 1;
        }

    }

}
