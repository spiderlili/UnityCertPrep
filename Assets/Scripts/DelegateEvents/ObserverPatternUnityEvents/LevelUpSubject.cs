using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpSubject : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    int experiencePoints = 0;
    [SerializeField] UnityEvent onLevelUp;

    IEnumerator Start(){
        while(true){
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points){
        experiencePoints += points;

        int level = GetLevel();
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
