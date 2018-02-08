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


    private IEnumerator coroutine;

    internal bool boxHeld = false;

    private Rigidbody2D _RB;
    internal SpriteRenderer _SR;
    [SerializeField]
    private AudioSource _ASWalking;
    [SerializeField]
    private AudioSource _ASJumping;
    [SerializeField]
    private AudioSource _ASDied;

    [SerializeField]
    private Animator _Animator;

    internal bool canJump = false;

    internal float windEffect = 0f;

    private float moreThanX = 1;
    private float moreThanY = 1;

    internal int boxSide;


    private bool direction;

    private bool audioPlaying = false;
    private bool audioOn = true;

    public bool standingOnBox = false;

    internal bool isDead = false;

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
        if (_RB.velocity.x < 0)
        {
            direction = true;
            _SR.flipX = true;
        }
        else if (_RB.velocity.x > 0)
        {
            direction = false;
            _SR.flipX = false;
        }
        else if (_RB.velocity.x == 0)
        {
            _SR.flipX = direction;
        }
    }

    //add jumping velocity
    protected void Jump(float jumpHeight)
    {
        _ASJumping.Play();
        _RB.velocity = new Vector2(_RB.velocity.x, jumpHeight);
    }

    public void Die()
    {
        _ASDied.Play();
        foreach (AnimatorControllerParameter parameter in _Animator.parameters)
        {
            _Animator.SetBool(parameter.name, false);
        }
        _Animator.SetBool("IsDead", true);
    }

    private void Update()
    {
        if (isDead == false)
        {
            //movement inputs
            float movement = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Jump");

            //if movement then move
            if (movement != 0)
            {
                //if (!_ASWalking.isPlaying && canJump == true)
                //{
                //    _ASWalking.Play();
                //}
                if (movement < 0)
                {
                    Move(moveSpeed - windEffect, -1);
                }
                if (movement > 0)
                {
                    Move(moveSpeed + windEffect, 1);
                }
            }
            //Input.GetKeyDown

            else if (movement == 0)
            {
                _ASWalking.Stop();

                _SR.flipX = direction;

                Move(0 + windEffect, 1);
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
            if (_RB.velocity.y > 0 && canJump == false)
            {
                _Animator.SetBool("IsGoingUp", true);

            }

            //animator here pls
            if (_RB.velocity.y < 0 && canJump == false)
            {
                _Animator.SetBool("IsFalling", true);

            }

            if (canJump == true)
            {
                _Animator.SetBool("IsFalling", false);
                _Animator.SetBool("IsGoingUp", false);
            }

            //Animators here
            if (boxHeld == true)
            {
                if (boxSide == -1)
                {
                    _SR.flipX = true;
                }
                else if (boxSide == 1)
                {
                    _SR.flipX = false;
                }
                _Animator.SetBool("IsPushing", true);
            }
            else if (boxHeld == false)
            {
                _Animator.SetBool("IsPushing", false);
            }

            float vectorx = _RB.velocity.x;
            float vectory = _RB.velocity.y;


            if (!_ASWalking.isPlaying && canJump == true && _RB.velocity.x != 0)
            {
                _ASWalking.Play();
            }

            if (vectorx <= moreThanX && vectorx >= -moreThanX && vectory <= moreThanY && vectory >= -moreThanY)
            {
                foreach (AnimatorControllerParameter parameter in _Animator.parameters)
                {
                    _Animator.SetBool(parameter.name, false);
                }
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            standingOnBox = false;

            canJump = true;
        }
        if (other.transform.CompareTag("Platform"))
        {
            standingOnBox = false;

            canJump = true;
            gameObject.transform.parent = other.transform;
        }
        if (other.transform.CompareTag("Box"))
        {
            standingOnBox = true;
            canJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            standingOnBox = false;

            canJump = true;
        }
        if (other.transform.CompareTag("Platform"))
        {
            standingOnBox = false;

            canJump = true;
            gameObject.transform.parent = other.transform;
        }
        if (other.transform.CompareTag("Box"))
        {
            standingOnBox = true;
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _ASWalking.Stop();
        standingOnBox = false;

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