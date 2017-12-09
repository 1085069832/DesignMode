using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("WeaponRocket");
    }
}

