using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Automatically add these to whatever the script is added to


[RequireComponent(typeof(AudioSource))]

public class Movement : BaseUnit
{
    public float jumpSpeed = 5;
    //public float sprintBonus = 1;
    public AudioClip coinSound;
    public AudioClip deathSound;

    private Transform _Cam;
    private bool isAlive = true;

    private AudioSource _ASource;


    // Use this for initialization
    void Start ()
    {
        _Cam = Camera.main.transform;
        _ASource = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update ()
    {
        //if not alive then return
        if (!isAlive) return;


        //Check if player is on the ground
        bool _canJump = IsGrounded(raycastOffset) || IsGrounded(-raycastOffset);




        //Movement hori
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(horizontalInput);
        }
        _Anim.SetFloat("MoveSpeed", Mathf.Abs(horizontalInput));

        //Jump movement
        if (Input.GetKeyDown(KeyCode.Space) == true && _canJump == true)
        {
            Jump();
        }

        if (transform.position.y < killHeight)
        {
            Die();
        }


    }
    private void Jump(float jumpMult = 1)
    {
        _RB.velocity = new Vector2(_RB.velocity.x, jumpSpeed * jumpMult);
    }

    private void Die()
    {


        //To start a coroutine
        //Use StartCoroutine. If you just call the coroutine it will run like a normal function.
        //Coroutine runs sort of in parallel with the main progrma.
        //coroutines can wait x amount of time if you want them to.
        StartCoroutine(DeathCoroutine());
    }


    //Triggers and tags
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            //++Score is faster in runtime than Score++;
            ++Globals.instance.score;
            Destroy(other.gameObject);
            _ASource.PlayOneShot(coinSound);
        }
        else if (other.CompareTag("EnemyTag"))
        {
            KillEnemy(other.gameObject);
        }
        

    }

    private void KillEnemy(GameObject enemy)
    {
        _RB.velocity = new Vector2(_RB.velocity.x, jumpSpeed/2);
        Destroy(enemy);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("EnemyTag"))
        {
            Die();
        }
    }


    //coroutines


    IEnumerator DeathCoroutine()
    {
        //play death sound
        _ASource.PlayOneShot(deathSound);
        //to make sure you don't stretch on the moving platforms
        transform.SetParent(null);
        //set if you're alive bool to false
        isAlive = false;
        //set animation
        _Anim.SetBool("IsAlive", false);
        //so the camera does not spin around with the character
        _Cam.SetParent(null);
        //so the playermodel can clip through the world
        GetComponent<Collider2D>().enabled = false;
        //to make a jump play at the same time, with a multiplyer of 1.5
        Jump(1.5f);





        //yield return; does not exit the coroutine. yield break; does leave the coroutine

        //waits for real time seconds:
        yield return new WaitForSecondsRealtime(3);

        //reloads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        //waits one frame
        yield return null;



        //waits for scaled time ingame (useful for slow-motion stuff):
        //yield return new WaitForSeconds(3);




        //yield return new <coroutine>; can run a new coroutine

        yield break;
    }
}