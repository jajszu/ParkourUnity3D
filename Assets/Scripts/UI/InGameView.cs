using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : View
{
    [SerializeField]
    private Slider slider;


    public void UpdateUI()
    {

        int[] hp = GameManager.instance.player.getHP();

        slider.value = hp[0];
        slider.maxValue = hp[1];
    }
    public void UpdateUI(int hp, int maxHp)
    {
        slider.maxValue = maxHp;
        slider.value = hp;
    }


    public override void Initialize()
    {
        
    }
}
