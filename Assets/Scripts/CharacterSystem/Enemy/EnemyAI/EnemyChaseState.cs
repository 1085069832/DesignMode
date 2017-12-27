using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemyChaseState : IEnemyState
{
    Vector3 targetPosition;

    public EnemyChaseState(EnemyFSMSystem enemyFSMSystem) : base(enemyFSMSystem)
    {
        stateID = EnemyStateID.Chase;
    }

    public override void OnStateBegin(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public override void Act(List<ICharacter> c)
    {
        if (c == null || c.Count == 0)
        {
            enemyFSMSystem.iEnemy.MoveTo(targetPosition);
        }
        else
        {
            enemyFSMSystem.iEnemy.MoveTo(c[0].Position());
        }
    }

    public override void Reason(List<ICharacter> c)
    {
        if (c == null || c.Count == 0) return;

        float distance = Vector3.Distance(enemyFSMSystem.iEnemy.Position(), c[0].Position());

        if (distance <= enemyFSMSystem.iEnemy.AttackDistance())
        {
            enemyFSMSystem.ChangeState(EnemyStateID.Attack);
        }
    }
}
