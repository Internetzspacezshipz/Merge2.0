using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


public class BaseUnit : MonoBehaviour
{
    public float moveSpeed = 5;
    public float raycastOffset = 0.4f;
    public float raycastDistance = 0.1f;
    public float killHeight = -50f;

    protected SpriteRenderer _SR;
    protected Rigidbody2D _RB;
    protected Animator _Anim;

    protected void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
        _SR = GetComponent<SpriteRenderer>();
        _Anim = GetComponent<Animator>();
    }

    protected void Move(float horizontalInput)
    {
        //flip orientation
        if (horizontalInput < 0) _SR.flipX = true;
        else if (horizontalInput > 0) _SR.flipX = false;


        _RB.velocity = new Vector2(moveSpeed * horizontalInput, _RB.velocity.y);
    }

    protected bool IsGrounded(float offsetX)
    {
        Vector2 origin = transform.position;
        origin.x += offsetX;


        RaycastHit2D hitInfo = Physics2D.Raycast(origin, Vector3.down, raycastDistance);

        _Anim.SetBool("NotGrounded", hitInfo);

        //if (hitInfo.transform.CompareTag("SomeTag"))
        //{
        //
        //}

        if (hitInfo.collider == null)
        {
            transform.SetParent(null);
            return false;

        }

        if (hitInfo.collider.GetComponent<MovingPlatform>() != null)
        {
            transform.SetParent(hitInfo.transform);
        }




        return hitInfo;
    }


}
