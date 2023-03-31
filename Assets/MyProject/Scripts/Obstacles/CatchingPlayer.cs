using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingPlayer : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _playerCaught = false;

    private LevelManager _levelManager;

    [Header("References")]
    [SerializeField] private Material _playerCaughtMat;

    /* ---------------------
     * M�thodes priv�es:
     * ---------------------
     */
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    /* ---------------------
     * M�thodes publiques:
     * ---------------------
     */
    public bool GetPlayerCaught() 
    {
        return _playerCaught;
    }

    public void CaughtPlayer()
    {
        // R�duit le temps total lorsque le joueur touche un obstacle et met le mat�riel de ce dernier, en rouge.
        _playerCaught = true;
        gameObject.GetComponentInChildren<MeshRenderer>().material = _playerCaughtMat;
        _levelManager.SubTime();
    }
}
