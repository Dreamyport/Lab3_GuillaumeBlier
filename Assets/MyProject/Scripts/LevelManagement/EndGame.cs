using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       // À chaque niveau, on met à jour les statistiques du joueur et on change de scène.
        if (other.gameObject.tag == "Player")
        {
            int indexScene = SceneManager.GetActiveScene().buildIndex;

            // Si c'est le dernier niveau, on met fin à la partie.
            if (indexScene == 3)
            {
                LevelManager levelManager = FindObjectOfType<LevelManager>();

                levelManager.SetEndTime(Time.time);
                SceneManager.LoadScene(5);
            }
            else
                SceneManager.LoadScene(indexScene + 1);
        }
        
    }
}
