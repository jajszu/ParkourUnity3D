using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float inputX;
    // Start is called before the first frame update


    void Start()
    {
        //przypisujšc gracza do tej zmiennej będziemy mogli się do niego odwołać z każdego skryptu
        GameManager.instance.player = this;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
    }
}
