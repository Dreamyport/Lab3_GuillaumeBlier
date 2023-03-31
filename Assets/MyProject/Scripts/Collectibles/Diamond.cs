using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
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

    // D�sactive l'objet et ajoute 1 au compteur du temps gagn�.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            gameObject.SetActive(false);
            _levelManager.AddTime();
        }
    }
}
