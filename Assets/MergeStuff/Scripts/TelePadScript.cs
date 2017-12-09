using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePadScript : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private GameObject Character1;
    [SerializeField]
    private GameObject Character2;

    private Vector3 pointOffset = new Vector3(0,50,0);

    private Vector3 centrePoint;
    #endregion


    private void Awake()
    {
        centrePoint = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TriggerTag")
        {
            Character1.transform.position = centrePoint + pointOffset;
            Character2.transform.position = centrePoint - pointOffset;
        }
    }
}