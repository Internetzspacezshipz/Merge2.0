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

    
    private Vector2 GizmoSize;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(winTimeline());
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
        GameManager.instance.OnWin();

        portalAnimator.SetBool("Load", true);
        baseAnimator.SetBool("Load", true);

        yield return new WaitForSeconds(3);
        GameManager.instance.LoadLevel(levelToLoad);
    }
}