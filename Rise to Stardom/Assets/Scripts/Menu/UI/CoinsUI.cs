using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro; // Asigna el TextMeshPro desde el Inspector

    private void Update()
    {
        if (Player.Instance != null)
        {
            // Actualiza el texto con el valor del int de Player
            textMeshPro.text = Player.Instance.PlayerStats.Coins.ToString();
        }
    }
}
