using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    void Awake()
    {
        //to sprawia �e gdyby by� w scenie drugi game manager to zostanie usuni�ty
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //domy�lnie jak przechodzimy do nowej sceny to wszystko co jest w poprzedniej scenie jest usuwane
        //dzi�ki tej funkcji game manager nie zostanie usuni�ty
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
