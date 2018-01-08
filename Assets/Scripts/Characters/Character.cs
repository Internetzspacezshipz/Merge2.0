using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D _RB;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
    }

    //add velocity
    protected void Move(float moveSpeed, int moveDirection)
    {
        _RB.velocity = new Vector2(moveSpeed*moveDirection,_RB.velocity.y);
    }

    //add jumping velocity
    protected void Jump(float jumpHeight)
    {
        _RB.velocity = new Vector2(_RB.velocity.x, jumpHeight);
    }
}