using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private int Velocidad = 5;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(transform.forward.normalized * Velocidad * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(transform.forward.normalized * -Velocidad * Time.deltaTime, Space.World);
        
        if (Input.GetKey(KeyCode.D))
            transform.Translate(transform.right.normalized * Velocidad * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(transform.right.normalized * -Velocidad * Time.deltaTime, Space.World);
    }
}
