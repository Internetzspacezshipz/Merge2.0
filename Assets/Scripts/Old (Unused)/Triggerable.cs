using UnityEngine;

public class Triggerable : MonoBehaviour
{
    protected Collider2D _Collider;

    protected bool active;

    //private void Awake()
    //{
    //    _Collider = GetComponent<Collider2D>();
    //}

    public virtual void TriggerableAction(bool openOrClose)
    {
        active = openOrClose;
    }
}