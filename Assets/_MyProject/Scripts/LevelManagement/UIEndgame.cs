using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEndgame : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private LevelManager _levelManager;

    [Header("References")]
    [SerializeField] private TMP_Text _timeTxt = default;
    [SerializeField] private TMP_Text _totalTimeTxt = default;
    [SerializeField] private TMP_Text _capturesTxt = default;
    [SerializeField] private TMP_Text _diamondsTxt = default;
    [SerializeField] private TMP_Text _ratingTxt = default;
    [SerializeField] private GameObject[] _featsTwoMin = default;
    [SerializeField] private GameObject[] _featsYeeHaw = default;
    [SerializeField] private GameObject[] _featsDiamonds = default;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        // On va chercher et on affiche les informations sur les statistiques.
        _levelManager = FindObjectOfType<LevelManager>();

        _timeTxt.text = "Temps: " + _levelManager.GetEndTime().ToString("f2") + "s";
        _capturesTxt.text = "Nombre de captures: " + _levelManager.GetObstacles().ToString();
        _diamondsTxt.text = "Nombre de diamants collectés: " + _levelManager.GetDiamonds().ToString();  

        // On applique les pénalités.
        float totalTime = (_levelManager.GetEndTime() - _levelManager.GetDiamonds()) + (_levelManager.GetObstacles() * 5.0f);
        _totalTimeTxt.text = "Temps total: " + totalTime.ToString("f2") + "s";

        // Les accomplissements du joueur, au courant de la partie. (S'il y a lieu)
        FeatManager();

        // Gestion de la cote finale (avec pénalités).
        RatingManager(totalTime);
    }

    // Gestion du différent nombre d'accomplissements.
    private void FeatManager() 
    {
        float[] times = { 120.0f, 180.0f, 300.0f, 420.0f };
        float[] captures = { 0.0f, 5.0f, 10.0f, 30.0f };
        float[] diamonds = { 144.0f, 75.0f, 50.0f, 25.0f };

        Feat(_levelManager.GetEndTime(), _featsTwoMin, times, false);
        Feat(_levelManager.GetObstacles(), _featsYeeHaw, captures, false);
        Feat(_levelManager.GetDiamonds(), _featsDiamonds, diamonds, true);
    }

    // Fait le tour des quatre limites (diamant, or, argent et bronze).
    private void Feat(float nFeat, GameObject[] feat, float[] featLimits, bool diamondFeat) 
    {
        for (int i = 0; i < 5; i++)
        {
            // Si le joueur a atteint une certaine limite, on sort de la boucle et on active la médail reliée.
            if (!diamondFeat)
            {
                if (nFeat <= featLimits[i])
                {
                    feat[i].SetActive(true);
                    break;
                }
            }
            else 
            {
                if (nFeat >= featLimits[i])
                {
                    feat[i].SetActive(true);
                    break;
                }
            }
        }
    }

    // Même principle que la gestion des limites pour les accomplissments, mais donner une cote au temps totale.
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
