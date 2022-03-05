using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInteract : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGameClciked()
    {
        Application.Quit();
    }
}
