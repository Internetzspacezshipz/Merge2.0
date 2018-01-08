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
    //How tall the raycasts are for jump detection
    [SerializeField]
    private float RADALT_Jump = 0.1f;
    //Offset for the raycasts
    [SerializeField]
    private float raycastOffsetX = 0.45f;
    [SerializeField]
    private float raycastOffsetY = 0.45f;

    private bool canJump = true;

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
                Move(moveSpeed, -1);
            }
            if (movement > 0)
            {
                Move(moveSpeed, 1);
            }
        }
        else if (movement == 0)
        {
            Move(0, 0);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }
}