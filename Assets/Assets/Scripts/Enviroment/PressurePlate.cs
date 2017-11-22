using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Weight")
        {
            Globals.instance.doorOpen = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            Globals.instance.doorOpen = false;
    }
}
