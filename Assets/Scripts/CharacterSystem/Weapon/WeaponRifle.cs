using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public WeaponRifle(IWeaponAttr iWeaponAttr) : base(iWeaponAttr)
    {
    }

    protected override void DrawLine(Vector3 targetPosition)
    {
        SetLine(targetPosition, 0.03f, 0.03f);
    }
}

