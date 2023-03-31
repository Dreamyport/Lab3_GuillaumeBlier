using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private ObjectTeleport _player;

    /* ---------------------
     * M�thodes priv�es:
     * ---------------------
     */
    private void Start()
    {
        _player = GetComponent<ObjectTeleport>();
    }

    // M�thode qui appelle la fonction de t�l�portation.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            _player.Teleport();
        }
    }
}
