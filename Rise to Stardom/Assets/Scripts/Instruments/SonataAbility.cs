using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SonataAbility", menuName = "Abilities/SonataAbility")]
public class SonataAbility : InstrumentAbilityBase
{
    public GameObject sonataPrefab;
    public Transform playerTransform;
    public float expandSpeed;
    public float expandDuration;
    public float stateDuration;
    public override void Activate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        GameObject sonata = Instantiate(sonataPrefab, playerTransform.position, Quaternion.identity);
        SonataAbilityHandler handler = sonata.AddComponent<SonataAbilityHandler>();
        handler.Initialize(expandSpeed,expandDuration,stateDuration,playerTransform);
    }
}
