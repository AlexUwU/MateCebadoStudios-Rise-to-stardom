using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public OptionsController controller;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Opciones").GetComponent<OptionsController>();
    }

    public void ShowOptions()
    {
        controller.pantallaOpciones.SetActive(true);
    }
    public void DontShowOptions()
    {
        controller.pantallaOpciones.SetActive(false);
    }
}
