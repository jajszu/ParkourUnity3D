using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverView : View
{
    [SerializeField] private Button restartButton;

    public override void Initialize()
    {
        restartButton.onClick.AddListener(() => GameManager.instance.Replay());
    }
}
