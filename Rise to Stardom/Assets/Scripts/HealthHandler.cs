using UnityEngine;

public class HealthHandler : MonoBehaviour, IHealthHandler
{
    [SerializeField] private int health;

    public int Health {  get { return health; } }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
