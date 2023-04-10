using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleport : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    [Header("References")]
    [SerializeField] private GameObject _teleportObject;
    [SerializeField] private Transform _teleportLocation;

    /* ---------------------
     * M�thodes publiques:
     * ---------------------
     */
    public void Teleport() 
    {
        // T�l�portation de l'objet vers la position voulue. 
        _teleportObject.transform.position = _teleportLocation.position;
    }
}
