using UnityEngine;

public class HealthHandler : MonoBehaviour, IHealthHandler
{
    public GameBehaviour numeroDeEnemigo;
    [SerializeField] private float health;
    public float Health {  get { return health; } }

    private void Start()
    {
        numeroDeEnemigo = FindObjectOfType<GameBehaviour>();
    }

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
            Debug.Log(numeroDeEnemigo.roomEnemy);
            numeroDeEnemigo.roomEnemy--;
        }
    }
}
