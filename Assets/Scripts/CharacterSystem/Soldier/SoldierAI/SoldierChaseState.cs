using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> c)
    {
        Debug.Log(stateID);
    }

    public override void Reason(List<ICharacter> c)
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            soldierFSMSystem.ChangeState(SoldierStateID.Idle);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            soldierFSMSystem.ChangeState(SoldierStateID.Attack);
        }
    }
}

