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

				portalAnimator.SetBool ("Load", true);
				baseAnimator.SetBool ("Load", true);
				alreadyTriggered = true;



				if (GameManager.instance.winzoneCount == 2)
				{
					StartCoroutine (winTimeline ());
				}
			}
		}
    }



    private void OnDrawGizmos()
    {
        GizmoSize = GetComponent<BoxCollider2D>().size;
        Gizmos.color = new Color(0,1f,0,0.2f);
        Gizmos.DrawCube(transform.position, new Vector3(GizmoSize.x, GizmoSize.y));
    }


    IEnumerator winTimeline()
    {

        yield return new WaitForSeconds(5);
        GameManager.instance.LoadLevel(levelToLoad);
    }
}