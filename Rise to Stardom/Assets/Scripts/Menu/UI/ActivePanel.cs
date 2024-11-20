using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePanel : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Desactivar el primer objeto
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Activar el segundo objeto
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
