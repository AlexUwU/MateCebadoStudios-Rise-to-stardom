using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLogic : MonoBehaviour
{
    public Toggle pantallaCompleta;
    public Toggle vSync;
    public TMP_Dropdown resolutionsDrop;
    public TMP_Dropdown qualityDrop;

    Resolution[] resolutions;
    public int quality;

    void Start()
    {
        int vsyncSetting = PlayerPrefs.GetInt("VSync", 0);
        QualitySettings.vSyncCount = vsyncSetting;

        if (Screen.fullScreen)
        {
            pantallaCompleta.isOn = true;
        }
        else
        {
            pantallaCompleta.isOn = false;
        }

        if (vsyncSetting == 1)
        {
            vSync.isOn = true;
        }
        else
        {
            vSync.isOn = false;
        }

        ReviewResolution();

        quality = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        qualityDrop.value = quality;
        AdjustQuality();
    }

    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ActiveVsync(bool vsync)
    {
        if (vsync)
        {
            QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetInt("VSync", 1);
            Debug.Log("VSync activado");
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            PlayerPrefs.SetInt("VSync", 0);
            Debug.Log("VSync desactivado");
        }
    }

    public void ReviewResolution()
    {
        resolutions = Screen.resolutions;
        resolutionsDrop.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        resolutionsDrop.AddOptions(options);
        resolutionsDrop.value = actualResolution;
        resolutionsDrop.RefreshShownValue();

        resolutionsDrop.value = PlayerPrefs.GetInt("numeroResoluciones", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("numeroResoluciones", resolutionsDrop.value);

        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(qualityDrop.value);
        PlayerPrefs.SetInt("numeroDeCalidad", qualityDrop.value);
        quality = qualityDrop.value;
    }
}