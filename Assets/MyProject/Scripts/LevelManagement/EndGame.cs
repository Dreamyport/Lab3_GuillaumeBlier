using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private LevelManager _levelManager;

    /* ---------------------
     * M�thodes priv�es:
     * ---------------------
     */
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
       // � chaque niveau, on met � jour les statistiques du joueur et on change de sc�ne.
        if (other.gameObject.tag == "Player")
        {
            _levelManager.LevelStatistics();

            int indexScene = SceneManager.GetActiveScene().buildIndex;

            // Si c'est le dernier niveau, on met fin � la partie.
            if (indexScene == 2)
                _levelManager.GameOver();
            else
                SceneManager.LoadScene(indexScene + 1);
        }
        
    }
}
