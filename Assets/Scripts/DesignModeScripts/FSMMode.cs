using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMode : MonoBehaviour
{
    SoldierFSMSystem soldierFSMSystem;
    // Use this for initialization
    void Start()
    {
        soldierFSMSystem = new SoldierFSMSystem(new ISoldier());
        SoldierIdleState idleState = new SoldierIdleState(soldierFSMSystem);
        idleState.Add(SoldierConditionState.SeeEnemy, SoldierStateID.Chase);
        SoldierChaseState chaseState = new SoldierChaseState(soldierFSMSystem);
        chaseState.Add(SoldierConditionState.CanAttack, SoldierStateID.Attack);
        chaseState.Add(SoldierConditionState.NoEnemy, SoldierStateID.Idle);
        SoldierAttackState attackState = new SoldierAttackState(soldierFSMSystem);
        attackState.Add(SoldierConditionState.SeeEnemy, SoldierStateID.Chase);
        attackState.Add(SoldierConditionState.NoEnemy, SoldierStateID.Idle);

        soldierFSMSystem.Add(idleState);
        soldierFSMSystem.Add(chaseState);
        soldierFSMSystem.Add(attackState);
    }

    void FixedUpdate()
    {
        soldierFSMSystem.Reason(null);
        soldierFSMSystem.Act(null);
    }
}
