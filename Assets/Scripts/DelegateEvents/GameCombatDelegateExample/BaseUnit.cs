using System;
using UnityEngine;

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

    public delegate void SubtractHpHandler(BaseUnit source, float subtractHp, DamageType damageType, HpDisplayType hpDisplayType);
    public event SubtractHpHandler OnSubtractHp;

    public void Attacked()
    {
        float possibility = UnityEngine.Random.value;
        bool isCritical = UnityEngine.Random.value > 0.5f;
        bool isMissed = UnityEngine.Random.value > 0.5f;
        float harmNumber = 10000f;
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

    }

    public bool IsHero => true;
}
