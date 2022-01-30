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
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex++;
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(nextSceneIndex));

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
