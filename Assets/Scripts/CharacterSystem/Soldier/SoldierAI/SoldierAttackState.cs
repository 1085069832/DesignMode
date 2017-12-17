using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class SoldierAttackState : ISoldierState
{

    public SoldierAttackState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = StateID.Attack;
    }

    public override void Act()
    {
        Debug.Log(stateID);
    }

    public override void Reason()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            soldierFSMSystem.ChangeState(StateID.Idle);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            soldierFSMSystem.ChangeState(StateID.Chase);
        }
    }
}

