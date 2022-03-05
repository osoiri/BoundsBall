using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInteract : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        MatchManager.resetscore();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        MatchManager.resetscore();
    }
}
