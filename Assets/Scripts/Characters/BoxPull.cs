using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    PlayerControl controller;
    GameObject heldBox = null;
    bool selectTime = false;
    [SerializeField]
    private Vector3 holdLocation = new Vector3(1.3f, -0.67f, 0);
    [SerializeField]
    private int side;

    //            Debug.Log("This Ran");

    private void Awake()
    {
        controller = GetComponentInParent<PlayerControl>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box") && Input.GetKeyDown(KeyCode.E) && heldBox == null && selectTime == false && controller.boxHeld == false)
        {
            other.transform.SetParent(controller.gameObject.transform, false);
            Destroy(other.GetComponent<Rigidbody2D>());
            other.transform.position = controller.transform.position + holdLocation;
            heldBox = other.gameObject;
            StartCoroutine(WaitForUnselect());
            controller.boxHeld = true;
            controller.boxSide = side;
        }
    }

    private void Update()
    {
        if (heldBox != null && selectTime == false)
        {
            if (controller.canJump == false)
            {
                DropBox();
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                DropBox();
            }
        }
    }

    public void DropBox()
    {
        heldBox.gameObject.AddComponent<Rigidbody2D>();

        heldBox.transform.parent = null;
        heldBox = null;
        controller.boxHeld = false;
    }


    private IEnumerator WaitForUnselect()
    {
        selectTime = true;
        yield return new WaitForSeconds(0.6f);
        selectTime = false;
    }
}