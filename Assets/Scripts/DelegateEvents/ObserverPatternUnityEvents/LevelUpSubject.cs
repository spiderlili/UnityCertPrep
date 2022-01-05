using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LevelUpSubject : MonoBehaviour
{
    [SerializeField] private int pointsPerLevel = 200;
    private int experiencePoints = 0;
    [SerializeField] private UnityEvent onLevelUp;
    
    // Alternative way using Event
    public event Action onLevelUpAction; 

    IEnumerator Start(){
        while(true){
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points){
        int level = GetLevel();
        experiencePoints += points;
        if(GetLevel() > level){
            if (onLevelUpAction != null) {
                onLevelUpAction();
            } else {
                onLevelUp.Invoke(); // If nothing is subscribed to onLevelUpAction in code: use UnityEvent instead (inefficient)
            }
            
        }
    }

    public int GetExperience(){
        return experiencePoints;
    }

    public int GetLevel(){
        return experiencePoints / pointsPerLevel;
    }
}
