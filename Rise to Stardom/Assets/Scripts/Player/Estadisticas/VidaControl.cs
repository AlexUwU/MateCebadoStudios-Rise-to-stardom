using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaControl : MonoBehaviour
{
    #region Singleton
    public static VidaControl Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public GameObject Jugador;
}
