using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEndgame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _timeTxt = default;
    [SerializeField] private TMP_Text _totalTimeTxt = default;
    [SerializeField] private TMP_Text _capturesTxt = default;
    [SerializeField] private TMP_Text _diamondsTxt = default;
    [SerializeField] private TMP_Text _ratingTxt = default;
    [SerializeField] private GameObject _featsTwoMin = default;
    [SerializeField] private GameObject _featsYeeHaw = default;
    [SerializeField] private GameObject _featsDiamonds = default;

    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        _timeTxt.text = "Temps: " + _levelManager.GetEndTime().ToString("f2") + "s";
        _capturesTxt.text = "Nombre de captures: " + _levelManager.GetObstacles().ToString();
        _diamondsTxt.text = "Nombre de diamants collectés: " + _levelManager.GetDiamonds().ToString();  

        float totalTime = (_levelManager.GetEndTime() - _levelManager.GetDiamonds()) + _levelManager.GetObstacles();
        _totalTimeTxt.text = "Temps total: " + totalTime.ToString("f2") + "s";

        if(_levelManager.GetEndTime() <= 180.0f)
            _featsTwoMin.SetActive(true);

        if (_levelManager.GetObstacles() == 0.0f)
            _featsYeeHaw.SetActive(true);
        
        if (_levelManager.GetDiamonds() >= 144.0f)
            _featsDiamonds.SetActive(true);

        RatingManager(totalTime);
    }

    private void RatingManager(float totalTime) 
    {
        float time = 120.0f;
        string[] ratings = { "S+", "S", "S-", "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D" };

        for (int i = 0; i < ratings.Length; i++) {
            if(totalTime <= time)
            { 
                _ratingTxt.text = ratings[i];
            break;
                }

            time += 10.0f;
        }
    }

}
