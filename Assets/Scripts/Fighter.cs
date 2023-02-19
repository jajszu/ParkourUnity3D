using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public int hp = 100;
    public int maxHp = 100;
    [SerializeField]
    private int damage = 10;

    public virtual void RecieveDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
    }

    public int[] getHP()
    {
        return new int[] { hp, maxHp };
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
