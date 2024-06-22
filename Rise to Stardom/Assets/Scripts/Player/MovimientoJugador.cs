using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    /**
     *Vector3.forward
    Vector3.back
    Vector3.up
    Vector3.down
    Vector3.right
    Vector3.left

transform.forward
transform.up
transform.right
    **/
    public int speed = 3;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward.normalized * speed * Time.deltaTime, Space.World);
        };
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward.normalized * -speed * Time.deltaTime, Space.World);
        };
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right.normalized * speed * Time.deltaTime, Space.World);
        };
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right.normalized * -speed * Time.deltaTime, Space.World);
        };
    }
}
