using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /* ---------------------
    * Méthodes publiques:
    * ---------------------
    */
    // On active la scène suivante.
    public void ChangeNextScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene + 1);
    }

    // Permet de quitter l'application. (Pas l'éditeur)
    public void QuitGame()
    {
        Application.Quit();
    }

    // Permet de charger le menu.
    public void ChangeStartScene()
    {
        SceneManager.LoadScene(0);
    }

    // Permet de charger la scène instructions (4).
    public void ChangeInstructionsScene()
    {
        SceneManager.LoadScene(4);
    }
}
