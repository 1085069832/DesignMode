using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMode : MonoBehaviour
{
    SoldierFSMSystem soldierFSMSystem;
    // Use this for initialization
    void Start()
    {
        soldierFSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(soldierFSMSystem);
        idleState.Add(ConditionState.SeeEnemy, StateID.Chase);
        SoldierChaseState chaseState = new SoldierChaseState(soldierFSMSystem);
        chaseState.Add(ConditionState.CanAttack, StateID.Attack);
        chaseState.Add(ConditionState.NoEnemy, StateID.Idle);
        SoldierAttackState attackState = new SoldierAttackState(soldierFSMSystem);
        attackState.Add(ConditionState.SeeEnemy, StateID.Chase);
        attackState.Add(ConditionState.NoEnemy, StateID.Idle);

        soldierFSMSystem.Add(idleState);
        soldierFSMSystem.Add(chaseState);
        soldierFSMSystem.Add(attackState);
    }

    void FixedUpdate()
    {
        soldierFSMSystem.Reason();
        soldierFSMSystem.Act();
    }
}
