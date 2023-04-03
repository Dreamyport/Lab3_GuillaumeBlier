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
    [SerializeField] private GameObject[] _featsTwoMin = default;
    [SerializeField] private GameObject[] _featsYeeHaw = default;
    [SerializeField] private GameObject[] _featsDiamonds = default;

    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        _timeTxt.text = "Temps: " + _levelManager.GetEndTime().ToString("f2") + "s";
        _capturesTxt.text = "Nombre de captures: " + _levelManager.GetObstacles().ToString();
        _diamondsTxt.text = "Nombre de diamants collectés: " + _levelManager.GetDiamonds().ToString();  

        float totalTime = (_levelManager.GetEndTime() - _levelManager.GetDiamonds()) + (_levelManager.GetObstacles() * 5.0f);
        _totalTimeTxt.text = "Temps total: " + totalTime.ToString("f2") + "s";

        TimeFeat();
        CapturesFeat();
        DiamondsFeat();

        RatingManager(totalTime);
    }

    private void TimeFeat() 
    {
        float time = _levelManager.GetEndTime();
        float[] times = { 120.0f, 180.0f, 300.0f, 420.0f };

        for(int i = 0; i < _featsTwoMin.Length; i++) 
        {
            if (time <= times[i])
            {
                _featsTwoMin[i].SetActive(true);
                break;
            }
        }
    }

    private void CapturesFeat()
    {
        float capture = _levelManager.GetObstacles();
        float[] captures = { 0.0f, 5.0f, 10.0f, 30.0f };

        for (int i = 0; i < _featsYeeHaw.Length; i++)
        {
            if (capture <= captures[i])
            {
                _featsYeeHaw[i].SetActive(true);
                break;
            }
        }
    }

    private void DiamondsFeat()
    {
        float diamond = _levelManager.GetDiamonds();
        float[] diamonds = { 144.0f, 75.0f, 50.0f, 25.0f };

        for (int i = 0; i < _featsDiamonds.Length; i++)
        {
            if (diamond >= diamonds[i])
            {
                _featsDiamonds[i].SetActive(true);
                break;
            }
        }
    }

    private void RatingManager(float totalTime) 
    {
        float time = 120.0f;
        string[] ratings = { "S+", "S", "S-", "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D" };

        for (int i = 0; i < ratings.Length; i++) 
        {
            if(totalTime <= time)
            { 
                _ratingTxt.text = ratings[i];
                break;
            }

            time += 20.0f;
        }
    }

}
