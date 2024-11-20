using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateReturnButton : MonoBehaviour
{
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void ButtonReturn()
    {
        CheckScene();

        if (currentSceneName == "MainMenu")
        {
            this.gameObject.SetActive(true);
        }
        else if (currentSceneName == "Level1")
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ButtonReturnGame()
    {
        CheckScene();

        if (currentSceneName == "Level1")
        {
            this.gameObject.SetActive(true);
        }
        else if (currentSceneName == "MainMenu")
        {
            this.gameObject.SetActive(false);
        }
    }

    public void CheckScene()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }
}
