using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private HealthSubscriber healthModel;

    private void Start()
    {
        healthModel.ONHealthChange += UpdateUI;
        UpdateUI(); // Get initial value from health
    }

    private void OnDestroy()
    {
        healthModel.ONHealthChange -= UpdateUI;
    }

    private void UpdateUI()
    {
        healthBarImage.fillAmount = healthModel.GetCurrentHealth() / healthModel.GetFullHealth();
    }
}
