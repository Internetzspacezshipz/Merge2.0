using UnityEngine;

public class Triggerable : MonoBehaviour
{
    private Collider2D _Collider;
    private Vector2 Origin;


    private void Awake()
    {
        _Collider = GetComponent<Collider2D>();
        //So the collider can move back to the original position to close.
        Origin = _Collider.transform.position;
    }

    public void TriggerableAction(bool openOrClose)
    {
        if (openOrClose == true)
        {
            //teleport the collider super far away.
            _Collider.transform.position = new Vector2(1000000,1000000);
        }
        if (openOrClose == false)
        {
            //Teleport the collider back to where it was originally.
            _Collider.transform.position = Origin;
        }
    }
}