using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Stat health;
    [SerializeField] private Stat moveSpeed;
    [SerializeField] private Stat damage;
    [SerializeField] private Vector3 initialPosition;

    public Stat Health => health;
    public Stat MoveSpeed => moveSpeed;
    public Stat Damage => damage;
    public Vector3 InitialPosition { get { return initialPosition; } }
    public IAttackBehaviour AttackBehaviour { get; set; }

    public IPlayerDetectionHandler playerDetectionHandler;

    public EnemyStateManager enemyStateManager;

    protected virtual void Awake()
    {
        enemyStateManager = GetComponent<EnemyStateManager>();
        initialPosition = transform.position;
        Health.BaseValue = health.BaseValue;
    }
    public void SetState(IEnemyState state)
    {
        enemyStateManager.SetState(state,this);
    }
    public void Start()
    {

    }
    public virtual void Update()
    {
        enemyStateManager.Update();
    }
    public virtual void Move(Vector3 direction)
    {
    }
    public void TakeDamage(float damage)
    {
        Health.BaseValue -= damage;
        if (Health.Value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SetState(new DefeatState());
    }
    public void AddSecondaryState(IEnemyState state)
    {
        enemyStateManager.AddSecondaryState(state, this);
    }
}