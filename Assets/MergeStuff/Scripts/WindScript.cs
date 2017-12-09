using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{



    [SerializeField]
    private float windStrengthHorizontal = 1000;
    [SerializeField]
    private float windStrengthVertical = 1000;

    private Rigidbody2D _RBOther;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //_RBOther.gameObject.


        //_RBOther = collision.GetComponent<Rigidbody2D>();
        //_RBOther.AddForce(new Vector2(windStrengthHorizontal, windStrengthVertical), ForceMode2D.Force);
    }
}