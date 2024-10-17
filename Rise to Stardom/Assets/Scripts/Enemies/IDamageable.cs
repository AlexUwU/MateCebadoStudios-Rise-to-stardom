using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    Stat Health { get; }
    void TakeDamage(float damage);
}
