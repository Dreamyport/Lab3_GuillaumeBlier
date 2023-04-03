using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeNextScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeInstructionsScene()
    {
        SceneManager.LoadScene(4);
    }
}
