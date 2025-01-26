using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quitted by weakness. Really disgusting.");
    }
}
