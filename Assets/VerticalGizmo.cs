using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGizmo : MonoBehaviour {

    [SerializeField]
    private Vector2 GizmoSize = new Vector2(10f,1000f);

    [SerializeField]
    Color GizmoColor = new Color(0, 0, 1f, 0.5f);

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(GizmoSize.x, GizmoSize.y));
    }
}
