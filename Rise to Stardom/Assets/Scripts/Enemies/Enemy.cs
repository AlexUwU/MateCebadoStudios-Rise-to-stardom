using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    public float Speed { get { return speed; } }
    public int Damage { get { return damage; } }

    public IPlayerDetectionHandler playerDetectionHandler;
    private IHealthHandler healthHandler;

    public abstract void Action();
    public abstract void Idle();

    public virtual void Update()
    {
        if (playerDetectionHandler != null && playerDetectionHandler.IsPlayerInRange(transform.position))
        {
            Action();
        }
        else
        {
            Idle();
        }
    }
}