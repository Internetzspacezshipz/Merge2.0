using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{

    public Transform mainTarget;
    public Transform xTarget;

    private void Update()
    {
        Vector3 newPos = mainTarget.position;
        newPos.x = xTarget.position.x;
        newPos.z = -10;
        transform.position = newPos;
    }

}
