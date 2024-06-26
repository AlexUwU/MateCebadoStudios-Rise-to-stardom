using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    /// <summary>
    /// No funciona, ver de eliminar o mejorar para que funcione.
    /// </summary>
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
