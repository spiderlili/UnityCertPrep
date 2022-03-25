using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private LevelUpSubject level; // Dependency on Model
    
    // Updates View: Canvas hierarchy
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private Button increaseXPButton;

    private void Start()
    {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.ONExperienceChange += UpdateUI; // Listen for changes
        UpdateUI(); // Give initial value to UI elements
    }

    private void OnDestroy()
    {
        level.ONExperienceChange -= UpdateUI;
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }
    
    void UpdateUI()
    {
        displayText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"Experience: {level.GetExperience()}";
    }
}
