using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float lifetime;
    public float damage;
    private GameObject owner;

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }
    public GameObject GetOwner()
    {
        return owner;
    }

    private void Start()
    {
        SetOwner(this.gameObject);
        Destroy(gameObject, lifetime);
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
    }
}
