using UnityEngine;

public class RigidbodyMovementHandler : IMovementHandler
{
    private Rigidbody rigidbody;

    public RigidbodyMovementHandler(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Move(Vector3 direction, float speed)
    {
        rigidbody.velocity = direction * speed ;
    }
}
