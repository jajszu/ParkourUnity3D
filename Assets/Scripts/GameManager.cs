using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    void Awake()
    {
        //to sprawia ¿e gdyby by³ w scenie drugi game manager to zostanie usuniêty
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //domyœlnie jak przechodzimy do nowej sceny to wszystko co jest w poprzedniej scenie jest usuwane
        //dziêki tej funkcji game manager nie zostanie usuniêty
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
