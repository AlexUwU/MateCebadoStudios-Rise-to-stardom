using UnityEngine;

public class BulletNote : MonoBehaviour
{
    public float speed;
    public string instrument;
    public float lifetime;
    public int damage;

    private void Start()
    {
        Destroy(gameObject,lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHealthHandler healthHandler = collision.gameObject.GetComponent<IHealthHandler>();
        if (healthHandler != null)
        {
            healthHandler.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
