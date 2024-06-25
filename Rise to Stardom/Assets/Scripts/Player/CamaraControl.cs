using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset;
    private float currentZoom = 10f;
    public float pitch = 2f;

    private void LateUpdate()
    {
        transform.position = objetivo.position - offset * currentZoom;
        transform.LookAt(transform.position + Vector3.up * pitch);
    }
}
