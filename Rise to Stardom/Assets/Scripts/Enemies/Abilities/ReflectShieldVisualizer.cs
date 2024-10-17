using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ReflectShieldVisualizer : MonoBehaviour
{
    [SerializeField] private ReflectShieldAbility reflectShieldAbility;

    private void OnDrawGizmos()
    {
        if (reflectShieldAbility != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, reflectShieldAbility.Radius);
        }
    }
}