using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /* ---------------------
    * M�thodes publiques:
    * ---------------------
    */
    // On active la sc�ne suivante.
    public void ChangeNextScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene + 1);
    }

    // Permet de quitter l'application. (Pas l'�diteur)
    public void QuitGame()
    {
        Application.Quit();
    }

    // Permet de charger le menu.
    public void ChangeStartScene()
    {
        SceneManager.LoadScene(0);
    }

    // Permet de charger la sc�ne instructions (4).
    public void ChangeInstructionsScene()
    {
        SceneManager.LoadScene(4);
    }
}
