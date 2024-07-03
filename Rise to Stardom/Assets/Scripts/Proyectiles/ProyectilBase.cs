using UnityEngine;

public class ProyectilBase : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
    public Transform objetivo;
    private GameObject owner;

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }
    public GameObject GetOwner()
    {
        return owner;
    }

    private void Start()
    {
        objetivo = VidaControl.Instance.Jugador.transform;
        Destroy(gameObject, lifetime);
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
    }
}
