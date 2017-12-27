using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class SoldierAttackState : ISoldierState
{

    public SoldierAttackState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = SoldierStateID.Attack;
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            soldierFSMSystem.ChangeState(SoldierStateID.Chase);
        }
    }
}

