using System.Collections;
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

    //public AudioClip walk;
    //public AudioClip jump;

    private IEnumerator coroutine;


    private Rigidbody2D _RB;
    private SpriteRenderer _SR;
    [SerializeField]
    private AudioSource _ASWalking;
    [SerializeField]
    private AudioSource _ASJumping;

    [SerializeField]
    private Animator _Animator;

    private bool canJump = false;

    internal float windEffect = 0f;

    private bool direction;

    private bool audioPlaying = false;
    private bool audioOn = true;


    #endregion



    private void Awake()
    {
        //coroutine = audioCoroutine();
        _RB = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
        _SR = GetComponent<SpriteRenderer>();
        //_AS = GetComponent<AudioSource>();
    }


    private void Start()
    {
        //StartCoroutine(coroutine);
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
            direction = true;
            _SR.flipX = true;
        }
        else if (moveDirection > 0)
        {
            direction = false;
            _SR.flipX = false;

        }
    }

    //add jumping velocity
    protected void Jump(float jumpHeight)
    {
        _ASJumping.Play();
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
            if (!_ASWalking.isPlaying && canJump == true)
            {
                _ASWalking.Play();
            }
            if (movement < 0)
            {
                Move(moveSpeed-windEffect, -1);
            }
            if (movement > 0)
            {
                Move(moveSpeed+windEffect, 1);
            }
        }
        //Input.GetKeyDown

        else if (movement == 0)
        {
            _ASWalking.Stop();

            _SR.flipX = direction;

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

        //animator here too pls
        if (_RB.velocity.x == 0)
        {

        }

        //animator here pls
        if (_RB.velocity.y > 0)
        {

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
        _ASWalking.Stop();

        canJump = false;
        gameObject.transform.parent = cameraScript.gameObject.transform;

    }


    //private IEnumerator audioCoroutine()
    //{
    //    while (audioOn == true)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        while (audioPlaying == true)
    //        {
    //            _AS.PlayOneShot(walk);
    //            yield return new WaitForSeconds(walk.length);
    //        }
    //    }
    //}
}