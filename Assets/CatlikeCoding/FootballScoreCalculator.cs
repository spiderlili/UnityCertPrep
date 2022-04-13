using System;
using UnityEngine;
using TMPro;

public class FootballScoreCalculator : MonoBehaviour
{
    // TODO: With every 10 minute, calculate the chance to score - 1 team will have a chance to increase score + 1 with the probability of 30%
    // Start is called before the first frame update

    [SerializeField] private int team1StartScore = 3;
    [SerializeField] private int team2StartScore = 2;
    [SerializeField] private TMP_Text team1ScoreText;
    [SerializeField] private TMP_Text team2ScoreText;
    
    void Start()
    {
        team1ScoreText.text = "0" + team1StartScore;
        team2ScoreText.text = "0" + team2StartScore;
    }
}
