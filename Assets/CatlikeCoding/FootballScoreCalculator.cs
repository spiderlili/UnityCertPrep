using System;
using UnityEngine;
using TMPro;
using Random = System.Random;
using System.Collections;

public class FootballScoreCalculator : MonoBehaviour
{
    [SerializeField] private int team1StartScore = 1;
    [SerializeField] private int team2StartScore = 0;
    [SerializeField] private TMP_Text team1ScoreText;
    [SerializeField] private TMP_Text team2ScoreText;
    [SerializeField] private int probabilityToDraw = 33;
    private bool runScoreCheck = true;
    [SerializeField] private float runScoreCheckDurationMinutes = 20f;

    void Start()
    {
        ResetScores();
        StartCoroutine(RunScoreCheck());
    }

    // TODO: ResetScores when CountUpTimer is reset
    private void ResetScores()
    {
        team1ScoreText.text = "0" + team1StartScore;
        team2ScoreText.text = "0" + team2StartScore;
    }
    
    IEnumerator RunScoreCheck()
    {
        while(runScoreCheck) // TODO: Set runScoreCheck to false when CountUpTimer is up
        { 
            DetermineScoreByChance();
            yield return new WaitForSeconds(runScoreCheckDurationMinutes * 60f);
        }
        yield return null;
    }
    
    void DetermineScoreByChance()
    {
        int team1Score = int.Parse(team1ScoreText.text.TrimStart('0'));
        int team2Score = int.Parse(team2ScoreText.text.TrimStart('0'));
            
        Random rand = new Random();
        int chance = rand.Next(1, 101);
        int probabilityToScore = (101 - probabilityToDraw) / 2;
        
        if (chance <= probabilityToDraw) {
            Debug.Log("Draw");
            Debug.Log("Randomly Generated Chance: " +  chance);
            Debug.Log("Probability To Score: " + probabilityToScore);
            return;
        }
        else if(chance > probabilityToDraw && chance < 101 - probabilityToScore) {
            team1Score++;
            team1ScoreText.text = "0" + team1Score;
            Debug.Log("Team1 Score + 1");
            Debug.Log("Randomly Generated Chance: " +  chance);
            Debug.Log("Probability To Score: " + probabilityToScore);
        } else {
            team2Score++;
            team2ScoreText.text = "0" + team2Score;
            Debug.Log("Team2 Score + 1");
            Debug.Log("Randomly Generated Chance: " +  chance);
            Debug.Log("Probability To Score: " + probabilityToScore);
        }
    }
}
