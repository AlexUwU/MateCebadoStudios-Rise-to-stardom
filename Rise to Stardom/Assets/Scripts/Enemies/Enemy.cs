using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Stat health;
    [SerializeField] private Stat moveSpeed;
    [SerializeField] private Stat damage;
    [SerializeField] private Vector3 initialPosition;

    public GameObject coinPrefab;

    public Stat Health => health;
    public Stat MoveSpeed => moveSpeed;
    public Stat Damage => damage;
    public Vector3 InitialPosition { get { return initialPosition; } set { initialPosition = value; } }
    public IAttackBehaviour AttackBehaviour { get; set; }

    public IPlayerDetectionHandler playerDetectionHandler;

    public EnemyStateManager enemyStateManager;

    public SpriteRenderer sprite;
    public CapsuleCollider col;

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
    public virtual void Start()
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
        sprite.color = Color.red;
        StartCoroutine(whitecolor());
    }

    private void Die()
    {
        SetState(new DefeatState());
        SetAllCollidersStatus (false);
        Instantiate(coinPrefab, transform.position, transform.rotation);
        
    }
    public void AddSecondaryState(IEnemyState state)
    {
        enemyStateManager.AddSecondaryState(state, this);
    }


    IEnumerator whitecolor() {
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    private void SetAllCollidersStatus (bool active) {
    foreach(Collider c in GetComponents<Collider> ()) {
        c.isTrigger = active;
    }
}
}