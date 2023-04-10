using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _triggered = false;

    [Header("References")]
    [SerializeField] private string _nextObjective;
    [SerializeField] private TMP_Text _objectiveTxt = default;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void OnTriggerEnter(Collider other)
    {
        // On lance le dialogue suivant. (Permet de guider le joueur)
        if (other.gameObject.tag == "Player" && !_triggered) 
        {
            _triggered = true;

            _objectiveTxt.text = _nextObjective;
        }
    }
}
