using UnityEngine;
using System.Collections;

public interface IAttrStrategy
{
    int GetExtraHP(int lv);
    int GetDmg(int lv);
    int GetCritDmg(int critRate);
}
