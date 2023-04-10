using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    [Header("References")]
    [SerializeField] private TMP_Text _capturedTxt = default;
    [SerializeField] private TMP_Text _diamondsTxt = default;
    [SerializeField] private TMP_Text _timeTxt = default;
    [SerializeField] private GameObject _pauseMenu = default;
    [SerializeField] private GameObject _restMenu = default;

    private bool _paused = false;
    private bool _started = false;

    private LevelManager _levelManager;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        // On affiche les valeurs vident.
        _levelManager = FindObjectOfType<LevelManager>();

        // On affiche le temps initial, seulement si c'est le deuxième niveau.
        if(SceneManager.GetActiveScene().buildIndex > 1)
            GetTime();
        _capturedTxt.text = "Capturé(s): " + _levelManager.GetObstacles();
        _diamondsTxt.text = "Diamant(s): " + _levelManager.GetDiamonds();
        Time.timeScale = 1;
    }

    private void Update()
    {
        // Active l'affichage du temps, seulement si le niveau est commencé.
        if (_started)
            GetTime();

        PauseManager();
    }

    private void GetTime() 
    {
        // Temps réel va être égale au temps présent - le temps de départ - le temps d'inactivité du joueur en début de chaque niveau.
        float time = (Time.time - _levelManager.GetStartTime() - _levelManager.GetDownTime());
        _timeTxt.text = time.ToString("f2");
    }

    private void PauseManager()
    {
        // Gestion des pauses.
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

    public void SetStarted()
    {
        _started = true;
    }
}
