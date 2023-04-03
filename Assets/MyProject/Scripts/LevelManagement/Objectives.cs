using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    private bool _triggered = false;

    [Header("References")]
    [SerializeField] private string _nextObjective;
    [SerializeField] private TMP_Text _objectiveTxt = default;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_triggered) 
        {
            _triggered = true;

            _objectiveTxt.text = _nextObjective;
        }
    }
}
