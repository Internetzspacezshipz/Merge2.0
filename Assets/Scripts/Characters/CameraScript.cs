using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam0;
    [SerializeField]
    private Camera cam1;
    [SerializeField]
    private GameObject character0;
    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private float maxDistance = 25f;


    private void Update()
    {
        cam0.transform.position = (character0.transform.position + character1.transform.position) / 2;
        cam0.transform.position = new Vector3(cam0.transform.position.x, character0.transform.position.y, -10);
        cam1.transform.position = (character0.transform.position + character1.transform.position) / 2;
        cam1.transform.position = new Vector3(cam1.transform.position.x, character1.transform.position.y, -10);

        if (character0.transform.position.x - character1.transform.position.x >= maxDistance || character0.transform.position.x - character1.transform.position.x <= -maxDistance)
        {
            GameManager.instance.RestartGame();
        }
    }
}