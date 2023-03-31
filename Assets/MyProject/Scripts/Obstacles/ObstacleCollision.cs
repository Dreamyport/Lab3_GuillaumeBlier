using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ObstacleCollision : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private ObstacleMovement _obstacleMovement;
    private CatchingPlayer _catchingPlayer;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        _obstacleMovement = GetComponent<ObstacleMovement>();
        _catchingPlayer = GetComponent<CatchingPlayer>();
    }

    // Gestion de la collision pour des obstacles de base.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_catchingPlayer.GetPlayerCaught())
        {
            _catchingPlayer.CaughtPlayer();
            _obstacleMovement.SetCanMove(false);
        }
    }
}
