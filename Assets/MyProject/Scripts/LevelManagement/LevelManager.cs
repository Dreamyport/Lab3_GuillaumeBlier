using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Attributs
    private float _addTime = 0.0f;
    private float _subTime = 0.0f;
    private float _startTimer = 0.0f;
    private float _endTimer = 0.0f;
    private bool _endGame;

    // Méthodes privées:
    private void Awake()
    {
        int nLevelManager = FindObjectsOfType<LevelManager>().Length;

        if (nLevelManager > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _endGame = false;
        _startTimer = Time.time;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(gameObject);

        if (_endGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
     
    // Méthodes publics:
    public void AddTime()
    {
        _addTime += 1.0f;

        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangeDiamonds(_addTime);
    }

    public void SubTime()
    {
        _subTime += 1.0f;

        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangeObstacles(_subTime);
    }


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
        _endTimer = (endTimer - _startTimer) + (_addTime - _subTime);
    }

    public void GameOver()
    {
        _endGame = true;
        FindObjectOfType<PlayerMovement>().GameOver();
    }
}
