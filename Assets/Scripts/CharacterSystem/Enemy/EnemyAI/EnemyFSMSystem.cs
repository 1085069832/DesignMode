using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFSMSystem
{
    IEnemyState currentState;//当前的状态
    List<IEnemyState> enemyStateList = new List<IEnemyState>();
    public IEnemy iEnemy;

    public EnemyFSMSystem(IEnemy iEnemy)
    {
        this.iEnemy = iEnemy;
    }

    public void Reason(List<ICharacter> c)
    {
        currentState.Reason(c);
    }

    public void Act(List<ICharacter> c)
    {
        currentState.Act(c);
    }

    public void Add(IEnemyState enemyState)
    {
        if (enemyState == null)
        {
            Debug.LogError("状态为空"); return;
        }

        if (enemyStateList.Contains(enemyState) == true)
        {
            Debug.LogError("状态已经存在"); return;
        }

        if (enemyStateList.Count == 0)
        {
            currentState = enemyState;
            currentState.OnStateBegin(iEnemy.Target);
        }

        enemyStateList.Add(enemyState);
    }

    public void Delete(IEnemyState enemyState)
    {
        if (enemyState == null)
        {
            Debug.LogError("状态为空"); return;
        }

        if (enemyStateList.Contains(enemyState) == false)
        {
            Debug.LogError("状态不存在"); return;
        }

        enemyStateList.Remove(enemyState);
    }

    public void ChangeState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("stateID为NullState"); return;
        }

        EnemyStateID id = currentState.GetOutPutStateID(stateID);

        if (id != EnemyStateID.NullState)
        {
            for (int i = 0; i < enemyStateList.Count; i++)
            {
                if (id == enemyStateList[i].stateID)
                {
                    currentState.OnStateLeave();
                    currentState = enemyStateList[i];
                    currentState.OnStateBegin(iEnemy.Target);
                    break;
                }
            }
        }
    }
}
