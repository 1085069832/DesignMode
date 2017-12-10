using UnityEngine;
using System.Collections;
using System;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(int critRate)
    {
        return new System.Random().Next(0, 1) * 10;
    }

    public int GetDmg(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHP(int lv)
    {
        return (lv - 1) * 10;
    }
}
