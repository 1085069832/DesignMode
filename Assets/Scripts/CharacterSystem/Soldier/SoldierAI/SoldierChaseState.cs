using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem soldierFSMSystem) : base(soldierFSMSystem)
    {
        stateID = StateID.Chase;
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            soldierFSMSystem.ChangeState(StateID.Attack);
        }
    }
}

