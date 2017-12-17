using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = StateID.Idle;
    }

    public override void Act()
    {
        Debug.Log(stateID);
    }

    public override void Reason()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            soldierFSMSystem.ChangeState(StateID.Chase);
        }
    }
}

