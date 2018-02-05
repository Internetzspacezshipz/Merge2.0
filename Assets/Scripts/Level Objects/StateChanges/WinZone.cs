using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField]
    private string levelToLoad = "MainMenu";
    
    private Vector2 GizmoSize;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GameManager.instance.LoadLevel(levelToLoad);
        }
    }

    private void OnDrawGizmos()
    {
        GizmoSize = GetComponent<BoxCollider2D>().size;
        Gizmos.color = new Color(0,1f,0,0.2f);
        Gizmos.DrawCube(transform.position, new Vector3(GizmoSize.x, GizmoSize.y));
    }
}