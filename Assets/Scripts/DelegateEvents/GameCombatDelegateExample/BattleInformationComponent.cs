using System;
using System.Runtime.Versioning;
using UnityEngine;

public class BattleInformationComponent : MonoBehaviour
{
    public BaseUnit unit;
    
    void Start()
    {
        if (unit == null) {
            this.unit = gameObject.GetComponent<BaseUnit>();
        }
        this.AddListener();
    }

    // Subscribe to the OnSubtractHp event defined by BaseUnit
    private void AddListener()
    {
        // Crete an instance of BaseUnit.SubtractHpHandler's delegate
        // use it to invoke BattleInformationComponent Type's OnSubtractHp method
        // Register this callback method as a subscriber to BaseUnit's OnSubtractHp Event
        this.unit.OnSubtractHp += new BaseUnit.SubtractHpHandler(this.OnSubtractHp);
    }

    // Unsubscribe to the OnSubtractHp event defined by BaseUnit
    private void RemoveListener()
    {
        this.unit.OnSubtractHp -= new BaseUnit.SubtractHpHandler(this.OnSubtractHp);
    }

    // When the BaseUnit is attacked: it will invoke this callback event
    private void OnSubtractHp(
        BaseUnit attackerSource, 
        float subtractHp, 
        BaseUnit.DamageType damageType, 
        BaseUnit.HpDisplayType hpDisplayType)
    {
        string unitName = string.Empty;
        string missedMessage = "Missed!";
        string damageTypeMessage = string.Empty;
        string damageHp = string.Empty;

        if (hpDisplayType == BaseUnit.HpDisplayType.Miss) {
            Debug.Log(missedMessage);
        }
        if (attackerSource.IsHero) {
            unitName = "Hero";
        } else {
            unitName = "Soldier";
        }
        damageTypeMessage = damageType == BaseUnit.DamageType.Critical ? "Critical!" : "Normal Attack";
        damageHp = subtractHp.ToString();
        Debug.Log(unitName + damageTypeMessage + damageHp);
    }
}
