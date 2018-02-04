using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    PlayerControl controller;
    GameObject heldBox = null;
    bool selectTime = false;

    //            Debug.Log("This Ran");

    private void Awake()
    {
        controller = GetComponentInParent<PlayerControl>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Box") && Input.GetKeyDown(KeyCode.E) && heldBox == null && selectTime == false)
        {
            other.transform.SetParent(controller.gameObject.transform, false);
            Destroy(other.GetComponent<Rigidbody2D>());
            other.transform.position = controller.transform.position + new Vector3(1.3f,-0.67f,0);
            Debug.Log("This Ran");
            heldBox = other.gameObject;
            StartCoroutine(WaitForUnselect());
        }
    }

    private void Update()
    {
        if (heldBox != null && selectTime == false)
        {
            if (controller.canJump == false)
            {
                Debug.Log("This Ran Set Null Parent");
                heldBox.gameObject.AddComponent<Rigidbody2D>();

                heldBox.transform.parent = null;
                heldBox = null;

            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("This Ran Set Null Parent");
                heldBox.gameObject.AddComponent<Rigidbody2D>();
                heldBox.transform.parent = null;
                heldBox = null;

            }
        }
    }


    private IEnumerator WaitForUnselect()
    {
        selectTime = true;
        yield return new WaitForSeconds(0.6f);
        selectTime = false;
    }
}