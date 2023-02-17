using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{

    private Vector2 input;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
        //przypisujšc gracza do tej zmiennej będziemy mogli się do niego odwołać z każdego skryptu
        GameManager.instance.player = this;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
