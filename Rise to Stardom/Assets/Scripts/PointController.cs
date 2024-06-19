using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public GameObject pointer;
    public LayerMask groundLayer;
    public float yValue;
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray rayCamera = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(rayCamera,out hit,100,groundLayer))
        {
            Vector3 pointerPosition = hit.point;
            pointerPosition.y = yValue;
            pointer.transform.position = pointerPosition;
        }
    }
}
