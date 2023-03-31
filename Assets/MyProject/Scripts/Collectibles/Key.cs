using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _playerHasKey = false;

    [Header("References")]
    [SerializeField] private Transform _inventory;

    /* ---------------------
     * M�thodes priv�es:
     * ---------------------
     */
    private void FixedUpdate()
    {
        if (_playerHasKey)
            FollowThePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        // S'assurer que le joueur ne trigger pas la zone, quand la cl� est dans l'inventaire.
        if (other.gameObject.tag == "Player" && !_playerHasKey)
            _playerHasKey = true;
    }

    // La cl� suit le joueur, seulement si celui-ci la poss�de.
    private void FollowThePlayer() 
    {
        Transform keyTransform = GetComponent<Transform>();

        keyTransform.position = _inventory.position;
        keyTransform.rotation = _inventory.rotation;
    }
}
