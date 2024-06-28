using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public void Moverse(Vector3 direc, float velocidad)
    {
        transform.Translate(direc * velocidad * Time.deltaTime, Space.World);
    }
}
