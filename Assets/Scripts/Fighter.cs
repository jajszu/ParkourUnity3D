using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;
    [SerializeField]
    private int maxhp = 100;
    [SerializeField]
    private int damage = 10;

    public void RecieveDamage(int amount)
    {
        hp -= amount;
        if(hp< 0) hp = 0;
    }

    public int[] getHP()
    {
        int[] a = { hp, maxhp };
        return a;
    }
}
