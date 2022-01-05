using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpSubject : MonoBehaviour
{
    [SerializeField] private int pointsPerLevel = 200;
    private int experiencePoints = 0;
    [SerializeField] private UnityEvent onLevelUp;

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
            onLevelUp.Invoke();
        }
    }

    public int GetExperience(){
        return experiencePoints;
    }

    public int GetLevel(){
        return experiencePoints / pointsPerLevel;
    }
}
