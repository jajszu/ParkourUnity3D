using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{


    void Start()
    {
        //przypisujšc gracza do tej zmiennej będziemy mogli się do niego odwołać z każdego skryptu
        GameManager.instance.player = this;
    }

    void Update()
    {

    }
}
