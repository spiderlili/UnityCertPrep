using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventsManager : MonoBehaviour
{
    public int deathCount;
    public Text deathCountText;

    private void OnEnable()
    {
        PlayerManager.onPlayerDeath += UpdateDeathCount;
    }

    private void OnDisable()
    {
        PlayerManager.onPlayerDeath -= UpdateDeathCount;
    }

    public void UpdateDeathCount() //signature matches delegate
    {
        deathCount++;
        deathCountText.text = "Death Count: " + deathCount;
    }
}
