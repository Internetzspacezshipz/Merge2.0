using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField]
    private string levelToLoad = "MainMenu";

    [SerializeField]
    private Animator portalAnimator;
    [SerializeField]
    private Animator baseAnimator;
    private PlayerControl playerController;

	private bool alreadyTriggered = false;

    public float portalDelay;
    
    private Vector2 GizmoSize;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
		
			if (other.transform.CompareTag ("Player"))
			{		
			
				if (alreadyTriggered == false)
				{
				
				GameManager.instance.detachCamera = true;
				playerController = other.GetComponent<PlayerControl> ();
				GameManager.instance.OnWin (playerController);
				++GameManager.instance.winzoneCount;

                EnableBase();


				if (GameManager.instance.winzoneCount == 2)
				{
					StartCoroutine (winTimeline ());
				}
			}
		}
    }

    private void EnableBase()
    {
        baseAnimator.SetBool("Load", true);
        alreadyTriggered = true;
        Invoke("EnablePortal", portalDelay);
    }

    private void EnablePortal()
    {
        portalAnimator.SetBool("Load", true);
    }


    private void OnDrawGizmos()
    {
        GizmoSize = GetComponent<BoxCollider2D>().size;
        Gizmos.color = new Color(0,1f,0,0.2f);
        Gizmos.DrawCube(transform.position, new Vector3(GizmoSize.x, GizmoSize.y));
    }


    IEnumerator winTimeline()
    {

        portalAnimator.SetBool("Load", true);
        baseAnimator.SetBool("Load", true);

        yield return new WaitForSeconds(2);
        GameManager.instance.LoadLevel(levelToLoad);
    }
}