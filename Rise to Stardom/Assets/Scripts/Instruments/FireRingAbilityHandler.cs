using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingAbilityHandler : MonoBehaviour
{
    public GameObject fireRingPrefab;
    public Transform playerTransform;
    public float expandSpeed;
    public float expandDuration;
    public int damageInitial;
    public int damageOverTime;
    public float damageOverTimeDuration;
    public void Initialize(float expandSpeed, float expandDuration, int damageInitial, int damageOverTime, float damageOverTimeDuration,Transform playerTransform)
    {
        this.expandSpeed = expandSpeed;
        this.expandDuration = expandDuration;
        this.damageInitial = damageInitial;
        this.damageOverTime = damageOverTime;
        this.damageOverTimeDuration = damageOverTimeDuration;
        this.playerTransform = playerTransform;

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

            transform.localScale = new Vector3(initialScale.x + currentScale, initialScale.y, initialScale.z + currentScale);

            transform.position = playerTransform.position;

            timer -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
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
