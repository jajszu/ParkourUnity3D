using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        //przypisuj�c gracza do tej zmiennej b�dziemy mogli si� do niego odwo�a� z ka�dego skryptu
        GameManager.instance.player = this;
    }

    void Update()
    {
        
    }
}
