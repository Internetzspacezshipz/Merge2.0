using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text scoreText;

    //LateUpdate updates after everything else.
    private void LateUpdate()
    {
        scoreText.text = "Score:" + Globals.instance.score;
    }

}
