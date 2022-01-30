using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CreditCanvas;
    public GameObject MainMenuCanvas;

    public void OnClickPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("MilawyRunningController");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickCredits()
    {
        CreditCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }
}
