using System.Collections;
using UnityEngine;
using System;

public class LevelUpVFXSubscriber : MonoBehaviour
{
    [SerializeField] private LevelUpSubject levelUpSubject;
    private void OnEnable()
    {
        if (levelUpSubject != null) {
            levelUpSubject.ONLevelUpAction += PlayLevelUpVFX;
        }
        
    }

    private void OnDisable()
    {
        if (levelUpSubject != null) {
            levelUpSubject.ONLevelUpAction -= PlayLevelUpVFX;
        }
    }

    private void PlayLevelUpVFX()
    {
        this.GetComponent<ParticleSystem>().Play();
    }
}
