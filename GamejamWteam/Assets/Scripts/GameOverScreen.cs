using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    
    public void Setup(float score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString(CultureInfo.CurrentCulture ) + " Points";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}



