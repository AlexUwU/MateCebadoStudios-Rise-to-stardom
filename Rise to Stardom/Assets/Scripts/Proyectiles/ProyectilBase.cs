using UnityEngine;

public class ProyectilBase : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
   public Transform objetivo;

    private void Start()
    {
        objetivo = VidaControl.Instance.Jugador.transform;
        Destroy(gameObject, lifetime);
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
    }
}
