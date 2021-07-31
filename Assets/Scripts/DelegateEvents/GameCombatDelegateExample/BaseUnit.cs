using System;
using UnityEngine;
using Random = System.Random;

public class BaseUnit : MonoBehaviour
{
    public enum DamageType
    {
        Normal,
        Critical
    }

    public enum HpDisplayType
    {
        None, //do not show Hp
        Damage,
        Miss
    }

    public float minDamageValue = 1000.0f;
    public float maxDamageValue = 3000.0f;

    public delegate void SubtractHpHandler(BaseUnit source, float subtractHp, DamageType damageType, HpDisplayType hpDisplayType);
    public event SubtractHpHandler OnSubtractHp;

    public void Attacked()
    {
        float possibility = UnityEngine.Random.value;
        bool isCritical = UnityEngine.Random.value > 0.5f;
        bool isMissed = UnityEngine.Random.value > 0.5f;
        float harmNumber = UnityEngine.Random.Range(minDamageValue, maxDamageValue);
        OnAttacked(harmNumber, isCritical, isMissed);
    }

    protected virtual void OnAttacked(float harmNumber, bool isCritical, bool isMissed)
    {
        DamageType damageType = DamageType.Normal;
        HpDisplayType hpDisplayType = HpDisplayType.Damage;

        if (isCritical) {
            damageType = DamageType.Critical;
        }

        if (isMissed) {
            hpDisplayType = HpDisplayType.Miss;
        }

        // Check if any method subscribed to this event, if yes: notify them
        OnSubtractHp?.Invoke(this, harmNumber, damageType, hpDisplayType);
        /* equivalent
        if (OnSubtractHp != null) {
            OnSubtractHp(this, harmNumber, damageType, hpDisplayType);
        }
        */
        print("harmNumber: " + harmNumber);
        print("damageType: " + damageType);
        print("hpDisplayType: " + hpDisplayType);
    }

    public bool IsHero => true;
}
