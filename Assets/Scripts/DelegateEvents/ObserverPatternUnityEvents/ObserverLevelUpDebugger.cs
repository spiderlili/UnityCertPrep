using System.Collections;
using UnityEngine;

public class ObserverLevelUpDebugger : MonoBehaviour
{
    IEnumerator Start() {
        HealthSubscriber health = GetComponent<HealthSubscriber>();
        LevelUpSubject level = GetComponent<LevelUpSubject>();
        while(true){
            yield return new WaitForSeconds(1);
            Debug.Log($"Experience: {level.GetExperience()}, Level:{level.GetLevel()}, Health:{health.GetHealth()}");
        }
    }
}
