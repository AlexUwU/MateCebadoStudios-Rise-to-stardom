using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    private Transform pointRay;
    private Transform transMainCamera;
    public Material materialSaveObjectHit;
    //public Material materialActualyObjectHit;
    public Material materialTransparent;

    public GameObject objectHit;

    public bool canChangeMaterial;

    void Start()
    {
        pointRay = GameObject.Find("Point Ray").GetComponent<Transform>();
        transMainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        canChangeMaterial = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
    }

    private void Ray()
    {
        Vector3 direction = pointRay.position - transMainCamera.position;
        Debug.DrawRay(transMainCamera.position, direction, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transMainCamera.position, direction, out hit) && hit.collider.CompareTag("Transparent"))
        {
            if (canChangeMaterial == true)
            {
                //Activa la transparencia
                objectHit = hit.collider.gameObject;
                materialSaveObjectHit = objectHit.GetComponent<MeshRenderer>().material;
                objectHit.GetComponent<MeshRenderer>().material = materialTransparent;
                canChangeMaterial = false;
            }
        }
        else if (Physics.Raycast(transMainCamera.position, direction, out hit) && hit.collider.tag != "Transparent")
        {
            if (canChangeMaterial == false)
            {
                //Reinicia la Transparencia
                objectHit.GetComponent<MeshRenderer>().material = materialSaveObjectHit;
                objectHit = null;
                materialSaveObjectHit = null;
                canChangeMaterial = true;
            }
        }
    }
}
