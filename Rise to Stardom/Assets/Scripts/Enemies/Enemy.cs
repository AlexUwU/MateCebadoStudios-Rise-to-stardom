using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Vector3 initialPosition;
    public Transform objetivo;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int Damage { get { return damage; } }
    public Vector3 InitialPosition { get { return initialPosition; } }
    public IAttackBehaviour AttackBehaviour { get; set; }

    public IPlayerDetectionHandler playerDetectionHandler;
    public IHealthHandler healthHandler;
    public EnemyStateManager enemyStateManager;


    protected virtual void Awake()
    {
        enemyStateManager = GetComponent<EnemyStateManager>();
        initialPosition = transform.position;
    }
    public void SetState(IEnemyState state)
    {
        enemyStateManager.SetState(state,this);
    }
    public virtual void Start()
    {
        objetivo = VidaControl.Instance.Jugador.transform;
    }
    public virtual void Update()
    {
        enemyStateManager.Update();
    }
    public virtual void Move(Vector3 direction)
    {
    }
    public void AddSecondaryState(IEnemyState state)
    {
        enemyStateManager.AddSecondaryState(state, this);
    }
}