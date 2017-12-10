using UnityEngine;
using System.Collections;
using System;

public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(int critRate)
    {
        return 0;
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
