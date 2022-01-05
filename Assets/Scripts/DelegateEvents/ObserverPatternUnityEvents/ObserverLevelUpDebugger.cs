using System.Collections;
using UnityEngine;
using TMPro;

public class ObserverLevelUpDebugger : MonoBehaviour
{
    [SerializeField] private HealthSubscriber health;
    [SerializeField] private LevelUpSubject level;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text experienceText;
    
    IEnumerator Start() {
        if (health == null) {
            HealthSubscriber health = GetComponent<HealthSubscriber>();
        }
        if (level == null) {
            LevelUpSubject level = GetComponent<LevelUpSubject>();
        }
        while(true){
            yield return new WaitForSeconds(1);
            Debug.Log($"Experience: {level.GetExperience()}, Level:{level.GetLevel()}, Health:{health.GetHealth()}");
            
            if (levelText != null) {
                levelText.text = "Level: " + level.GetLevel();
            }

            if (healthText != null) {
                healthText.text = "Health: " + health.GetHealth();
            }

            if (experienceText != null) {
                experienceText.text = "Experience: " + level.GetExperience();
            }
        }
    }
}
