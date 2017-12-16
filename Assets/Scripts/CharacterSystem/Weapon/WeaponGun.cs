using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun(IWeaponAttr iWeaponAttr) : base(iWeaponAttr)
    {
    }

    protected override void DrawLine(Vector3 targetPosition)
    {
        SetLine(targetPosition, 0.02f, 0.02f);
    }
}

