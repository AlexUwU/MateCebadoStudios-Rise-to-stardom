using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingAbility : InstrumentAbilityBase
{
    public GameObject fireRingPrefab;
    public Transform playerTransform;
    public float expandSpeed;
    public float expandDuration;
    public int damageInitial;
    public int damageOverTime;
    public float damageOverTimeDuration;

    public void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }
    public override void Activate()
    {
        GameObject fireRing = Instantiate(fireRingPrefab, playerTransform.position, Quaternion.identity);
        fireRing.GetComponent<FireRingAbility>().Initialize(expandSpeed,expandDuration, damageInitial, damageOverTime, damageOverTimeDuration);
    }

    public void Initialize(float expandSpeed, float expandDuration, int damageInitial, int damageOverTime, float damageOverTimeDuration)
    {
        this.expandSpeed = expandSpeed;
        this.expandDuration = expandDuration;
        this.damageInitial = damageInitial;
        this.damageOverTime = damageOverTime;
        this.damageOverTimeDuration = damageOverTimeDuration;

        StartCoroutine(ExpandAndDamage());
    }

    private IEnumerator ExpandAndDamage()
    {
        float timer = expandDuration;
        float currentScale = 0;

        Vector3 initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        while (timer >= 0) 
        {
            float scaleFactor = expandSpeed * Time.deltaTime;
            currentScale += scaleFactor;

            transform.localScale = new Vector3(initialScale.x+currentScale,initialScale.y,initialScale.z+currentScale);

            transform.position = playerTransform.position;

            timer -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IHealthHandler healthHandler = other.gameObject.GetComponent<IHealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.TakeDamage(damageInitial);
                var burnStae = new BurnState(damageOverTime, damageOverTimeDuration);
                other.GetComponent<Enemy>()?.AddSecondaryState(burnStae);
            }
        }
    }
}
