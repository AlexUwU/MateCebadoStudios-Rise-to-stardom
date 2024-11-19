using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePanel : MonoBehaviour
{
    public GameObject objectToDeactivate;  // El objeto que deseas desactivar
    public GameObject objectToActivate;    // El objeto que deseas activar

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
