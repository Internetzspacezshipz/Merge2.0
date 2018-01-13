using UnityEngine;

public class PlayerControl : Character
{
    #region variables
    //Movement speed
    [SerializeField]
    private float moveSpeed = 1;
    //Jump force
    [SerializeField]
    private float jumpHeight = 1;


    private bool canJump = false;


    internal float windEffect = 0f;

    #endregion

    private void Update()
    {
        //movement inputs
        float movement = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Jump");
      
        //if movement then move
        if (movement != 0)
        {

            if (movement < 0)
            {
                Move(moveSpeed-windEffect, -1);
            }
            if (movement > 0)
            {
                Move(moveSpeed+windEffect, 1);
            }
        }
        else if (movement == 0)
        {
            Move(0+windEffect, 1);
        }
        //jumping
        if (vertical != 0)
        {
            if (canJump == true)
            {
                Jump(jumpHeight);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (other.transform.CompareTag("Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (other.transform.CompareTag("Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
        gameObject.transform.parent = null;
    }
}