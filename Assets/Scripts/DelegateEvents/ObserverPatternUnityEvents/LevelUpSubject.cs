using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

// Refactored using LevelPresenter.cs
// using UnityEngine.UI;
// using TMPro;

// Call observers when certain relevant events change
public class LevelUpSubject : MonoBehaviour
{
    [SerializeField] private int pointsPerLevel = 200;
    
    // Refactored using LevelPresenter.cs
    // [SerializeField] private TMP_Text displayText;
    // [SerializeField] private TMP_Text experienceText;
    // [SerializeField] private Button increaseXPButton;
    
    private int experiencePoints = 0;
    [SerializeField] private UnityEvent onLevelUp; // Can be safely removed if using Action or Event instead
    
    // Alternative way using Event
    public event Action ONLevelUpAction;
    
    // Use Observer pattern to break the link dependency between Model & Presenter
    public event Action ONExperienceChange;

    delegate void CallbackType();

    // Refactored using LevelPresenter.cs
    /*
    void UpdateUI()
    {
        displayText.text = $"Level: {GetLevel()}";
        experienceText.text = $"Experience: {GetExperience()}";
    }
    */
    
    // Refactored using LevelPresenter.cs
    // UpdateUI();
    // increaseXPButton.onClick.AddListener(() => GainExperience(10));
    /*
    IEnumerator Start()
    {
        while(true){
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }
    */

    public void GainExperience(int points){
        int level = GetLevel();
        experiencePoints += points;
        // UpdateUI();

        if (ONExperienceChange != null) {
            ONExperienceChange();
        }
        
        if(GetLevel() > level){
            if (ONLevelUpAction != null) {
                ONLevelUpAction();
            } else {
                onLevelUp.Invoke(); // If nothing is subscribed to onLevelUpAction in code: use UnityEvent instead (inefficient). Code can be removed if not using UnityEvent
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
