using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SonataAbility : InstrumentAbilityBase
{
    public GameObject sonataPrefab;
    public Transform playerTransform;
    public float expandSpeed;
    public float expandDuration;
    public float stateDuration;
    public void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }
    public override void Activate()
    {
        GameObject sonata = Instantiate(sonataPrefab, playerTransform.position, Quaternion.identity);
        sonata.GetComponent<SonataAbility>().Initialize(expandSpeed, expandDuration, stateDuration);
    }

    public void Initialize(float expandSpeed, float expandDuration, float stateDuration)
    {
        this.expandSpeed = expandSpeed;
        this.expandDuration = expandDuration;

        StartCoroutine(Expand());
    }
    private IEnumerator Expand()
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
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            var confusionState = new ConfusionState(stateDuration,enemy);
            enemy.SetState(confusionState);
        }
    }

}
