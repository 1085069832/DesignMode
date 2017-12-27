using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = SoldierStateID.Idle;
    }

    public override void Act(List<ICharacter> c)
    {
        Debug.Log(stateID);
    }

    public override void Reason(List<ICharacter> c)
    {
        if (c != null || c.Count > 0)
        {
            float distance = Vector3.Distance(soldierFSMSystem.iSoldier.Position(), c[0].Position());

            if (distance <= soldierFSMSystem.iSoldier.AttackDistance())
            {
                soldierFSMSystem.ChangeState(SoldierStateID.Attack);
            }
            else
            {
                soldierFSMSystem.ChangeState(SoldierStateID.Chase);
            }
        }
    }
}

