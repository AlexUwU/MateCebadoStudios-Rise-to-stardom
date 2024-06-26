using UnityEngine;

public class ProyectilBase : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
    }
}
