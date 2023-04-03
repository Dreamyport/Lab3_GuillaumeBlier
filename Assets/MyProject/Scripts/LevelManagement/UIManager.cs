using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _capturedTxt = default;
    [SerializeField] private TMP_Text _diamondsTxt = default;
    [SerializeField] private TMP_Text _timeTxt = default;
    [SerializeField] private GameObject _pauseMenu = default;
    [SerializeField] private GameObject _restMenu = default;

    private bool _paused;

    private LevelManager _levelManager;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _capturedTxt.text = "Capturé(s): " + _levelManager.GetObstacles();
        _diamondsTxt.text = "Diamant(s): " + _levelManager.GetDiamonds();
        Time.timeScale = 1;
        _paused = false;
    }


    private void Update()
    {
        float time = Time.time - _levelManager.GetStartTime();
        _timeTxt.text = time.ToString("f2");
        PauseManager();
    }

    private void PauseManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_paused)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && _paused)
            RemovePause();
    }

    public void ChangeObstacles(float obstacles)
    {
        _capturedTxt.text = "Capturé(s): " + obstacles.ToString();
    }

    public void ChangeDiamonds(float diamonds)
    {
        _diamondsTxt.text = "Diamants(s): " + diamonds.ToString();
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _restMenu.SetActive(false);
        Time.timeScale = 0;
        _paused = true;
    }
    public void RemovePause()
    {
        _pauseMenu.SetActive(false);
        _restMenu.SetActive(true);
        Time.timeScale = 1;
        _paused = false;
    }
}
