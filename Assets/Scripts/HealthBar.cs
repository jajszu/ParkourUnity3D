using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();

    }
    void Start()
    {
        GameManager.instance.updateUI += UpdateUI;
    }

    public void UpdateUI()
    {
        Debug.Log("function ran");
        int[] hp = GameManager.instance.player.getHP();

        slider.value = hp[0];
        slider.maxValue = hp[1];
    }
    public void UpdateUI(int hp, int maxHp)
    {
        slider.value = hp;
        slider.maxValue = maxHp;
    }

    private void OnDestroy()
    {
        GameManager.instance.updateUI -= UpdateUI;
    }
}
