using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("WeaponGun");
    }
}

