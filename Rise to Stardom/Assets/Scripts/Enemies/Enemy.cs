using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    public Transform objetivo;

    public float Speed { get { return speed; } }
    public int Damage { get { return damage; } }

    public IPlayerDetectionHandler playerDetectionHandler;
    private IHealthHandler healthHandler;

    public abstract void Action();
    public abstract void Idle();
    public void Start()
    {
        objetivo = VidaControl.Instance.Jugador.transform;
    }
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