using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTeleporter : MonoBehaviour
{
    [SerializeField]
    private PlayerControl character0;
    [SerializeField]
    private PlayerControl character1;
    [SerializeField]
    private GameObject pad0;
    [SerializeField]
    private GameObject pad1;

    internal void ActivateTeleport()
    {
        Debug.Log("Teleportation");
        character0.transform.position = pad0.transform.position;
        character1.transform.position = pad1.transform.position;
    }
}  