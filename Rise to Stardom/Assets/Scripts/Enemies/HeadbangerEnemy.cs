using UnityEngine;

public class HeadbangerEnemy : Enemy
{
    private IMovementHandler movementHandler;
    private Vector3 initialPosition;

    private void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        initialPosition = transform.position;
    }
    public override void Action()
    {
        Vector3 enemyPosition = transform.position;
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = (playerPosition - enemyPosition).normalized;
        Move(direction);
    }

    public override void Idle()
    {
        Vector3 direction = (initialPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, initialPosition) > 0.1f)
        {
            Move(direction);
        }
        else
        {
            movementHandler.Move(Vector3.zero, 0);
        }
    }
    public void Move(Vector3 direction)
    {
        movementHandler.Move(direction, Speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealthHandler healthHandlerPlayer = collision.gameObject.GetComponent<HealthHandler>();
            if(healthHandlerPlayer != null)
            {
                healthHandlerPlayer.TakeDamage(Damage);
            }
        }
    }
}
