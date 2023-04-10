using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private float _addTime = 0.0f;
    private float _subTime = 0.0f;
    private float _startTimer = 0.0f;
    private float _endTimer = 0.0f;
    private float _downTime = 0.0f;
    private bool _firstLevel = true;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Awake()
    {
        // On s'assure qu'il y a seulement un gestionnaire de jeu.
        int nLevelManager = FindObjectsOfType<LevelManager>().Length;

        if (nLevelManager > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Si on retourne sur le menu principal, on détruit le gestionnaire.
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(gameObject);
    }

    /* ---------------------
     * Méthodes publiques:
     * ---------------------
     */
    // Le temps ajouté lorsque le joueur se fait capturer.
    public void AddTime()
    {
        _addTime += 1.0f;

        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangeDiamonds(_addTime);
    }

    // Le temps soustrait lorsque le joueur collecte un diamant.
    public void SubTime()
    {
        _subTime += 1.0f;

        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangeObstacles(_subTime);
    }

    // Les Get, Set.
    public float GetDiamonds() 
    {
        return _addTime;
    }

    public float GetObstacles()
    {
        return _subTime;
    }

    public float GetStartTime() 
    {
        return _startTimer;
    }

    public float GetEndTime() 
    {
        return _endTimer;
    }

    public void SetEndTime(float endTimer) 
    {
        _endTimer = (endTimer - _startTimer - _downTime) + (_addTime - _subTime);
    }

    public float GetDownTime() 
    {
        return _downTime;    
    }

    public void SetDownTime(float downTime) 
    {
        if (_firstLevel)
        {
            _startTimer = Time.time;
            _firstLevel = false;
        }
        else 
            _downTime += downTime;
    }
}
