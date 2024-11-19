using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField]private AudioClip boton;

    public void ButtonSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(boton, transform, 1f);
    }

}
