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

    void UpdateUI()
    {
        int[] hp = GameManager.instance.player.getHP();

        slider.value = hp[0];
        slider.maxValue = hp[1];

    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.updateUI += UpdateUI;

    }

    IEnumerator AfterStart()
    {
       
            yield return new WaitForSeconds(1);
          UpdateUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameManager.instance.updateUI -= UpdateUI;
    }
}
