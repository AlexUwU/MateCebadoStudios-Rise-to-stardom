using UnityEngine;

public class HealthHandler : MonoBehaviour, IHealthHandler
{
    [SerializeField] private float health;
    public float Health {  get { return health; } }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        var enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.SetState(new DefeatState());
        }
    }
}
