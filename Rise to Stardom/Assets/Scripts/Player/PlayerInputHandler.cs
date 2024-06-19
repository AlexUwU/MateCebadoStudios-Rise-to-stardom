using UnityEngine;

public class PLayerInputHandler : IInputHandler
{
    public Vector3 GetInputMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal,0,vertical);
    }

    public bool IsShooting()
    {
        return Input.GetButtonDown("Fire1");
    }
}