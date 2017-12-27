using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemyAttackState : IEnemyState
{
    public EnemyAttackState(EnemyFSMSystem enemyFSMSystem) : base(enemyFSMSystem)
    {
        stateID = EnemyStateID.Attack;
    }

    public override void Act(List<ICharacter> c)
    {

    }

    public override void Reason(List<ICharacter> c)
    {

    }
}
