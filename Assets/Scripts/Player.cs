using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        //przypisuj¹c gracza do tej zmiennej bêdziemy mogli siê do niego odwo³aæ z ka¿dego skryptu
        GameManager.instance.player = this;
    }

    void Update()
    {
        
    }
}
