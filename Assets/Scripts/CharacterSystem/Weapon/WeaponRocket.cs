using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public WeaponRocket(IWeaponAttr iWeaponAttr) : base(iWeaponAttr)
    {
    }

    protected override void DrawLine(Vector3 targetPosition)
    {
        SetLine(targetPosition, 0.04f, 0.04f);
    }
}

