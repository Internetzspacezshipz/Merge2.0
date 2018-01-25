using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region variables
    //Movement speed
    [SerializeField]
    private float moveSpeed = 1;
    //Jump force
    [SerializeField]
    private float jumpHeight = 1;
    [SerializeField]
    private CameraScript cameraScript;

    private Rigidbody2D _RB;
    private SpriteRenderer _SR;

    [SerializeField]
    private Animator _Animator;

    private bool canJump = false;

    public bool alive = true;

    internal float windEffect = 0f;

    #endregion



    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
        _SR = GetComponent<SpriteRenderer>();
    }

    //add velocity
    internal void Move(float moveSpeed, int moveDirection)
    {
        _RB.velocity = new Vector2(moveSpeed * moveDirection, _RB.velocity.y);
        if (_RB.velocity.x != 0)
        {
            _Animator.SetBool("IsWalking", true);
        }
        else
        {
            _Animator.SetBool("IsWalking", false);
        }
        if (moveDirection < 0)
        {
            _SR.flipX = true;
        }
        else if (moveDirection > 0)
        {
            _SR.flipX = false;
        }
    }

    //add jumping velocity
    protected void Jump(float jumpHeight)
    {
        _RB.velocity = new Vector2(_RB.velocity.x, jumpHeight);
    }



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
            canJump = true;
            gameObject.transform.parent = other.transform;
        }
        if (other.transform.CompareTag("Box"))
        {
            canJump = true;
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
            canJump = true;
            gameObject.transform.parent = other.transform;
        }
        if (other.transform.CompareTag("Box"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
        gameObject.transform.parent = cameraScript.gameObject.transform;

    }
}