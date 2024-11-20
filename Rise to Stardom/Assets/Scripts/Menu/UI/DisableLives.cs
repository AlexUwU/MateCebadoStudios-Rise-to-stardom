using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLives : MonoBehaviour
{
    public GameObject[] healthImages; // Arreglo de imágenes en el Canvas
    private int currentImageIndex;
    private float lastHealth;

    private void Start()
    {
        currentImageIndex = healthImages.Length - 1; // Iniciar con todas las imágenes activas
        lastHealth = Player.Instance.PlayerStats.CurrentHealth;
    }

    private void Update()
    {
        // Obtenemos la vida actual del jugador
        float currentHealth = Player.Instance.PlayerStats.CurrentHealth;

        // Revisamos si la vida ha disminuido lo suficiente para desactivar una imagen
        if (currentHealth <= lastHealth - 20 && currentImageIndex >= 0)
        {
            // Desactivamos la imagen correspondiente
            healthImages[currentImageIndex].SetActive(false);
            currentImageIndex--; // Pasamos a la siguiente imagen
            lastHealth = currentHealth; // Actualizamos la última vida registrada
        }
    }
}
