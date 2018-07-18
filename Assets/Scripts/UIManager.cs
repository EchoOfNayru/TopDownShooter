using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthSlider;

    void Awake()
    {
        if (GameManager.instance.uiManager == null)
        {
            GameManager.instance.uiManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateUI()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthSlider.value = GameManager.instance.player.health;
    }
}
