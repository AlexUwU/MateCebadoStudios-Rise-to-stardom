using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FireRingAbility", menuName = "Abilities/FireRingAbility")]
public class FireRingAbility : InstrumentAbilityBase
{
    public GameObject fireRingPrefab;
    public Transform playerTransform;
    public float expandSpeed;
    public float expandDuration;
    public int damageInitial;
    public int damageOverTime;
    public float damageOverTimeDuration;
    public override void Activate()
    {
        playerTransform = Player.Instance.playerTransform;
        GameObject fireRing = Instantiate(fireRingPrefab, playerTransform.transform.position, Quaternion.identity);
        FireRingAbilityHandler handler = fireRing.AddComponent<FireRingAbilityHandler>();
        handler.Initialize(expandSpeed, expandDuration, damageInitial, damageOverTime, damageOverTimeDuration, playerTransform);
    }
}
