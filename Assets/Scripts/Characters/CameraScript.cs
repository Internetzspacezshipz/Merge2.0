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
    private Soul character0;
    [SerializeField]
    private Body character1;
    [SerializeField]
    private float maxDistance = 25f;

    private void Start()
    {
        StartCoroutine(waitForShit());
    }



    private void Update()
    {
		if (GameManager.instance.detachCamera == false) 
		{
			cam0.transform.position = (character0.transform.position + character1.transform.position) / 2;
			cam0.transform.position = new Vector3 (cam0.transform.position.x, character0.transform.position.y, -10);
			cam1.transform.position = (character0.transform.position + character1.transform.position) / 2;
			cam1.transform.position = new Vector3 (cam1.transform.position.x, character1.transform.position.y, -10);

			if (character0.transform.position.x - character1.transform.position.x >= maxDistance || character0.transform.position.x - character1.transform.position.x <= -maxDistance)
            {
				GameManager.instance.RestartGame ();
			}
		}
    }

    private IEnumerator waitForShit()
    {
        yield return new WaitForSeconds(0.1f);

        character0 = GameManager.instance.soul;
        character1 = GameManager.instance.body;
        cam0 = character0.GetComponentInChildren<Camera>();
        cam1 = character1.GetComponentInChildren<Camera>();

        Debug.Log(character0.name);
        Debug.Log(character1.name);

        yield return new WaitForSeconds(0.1f);
    }
}