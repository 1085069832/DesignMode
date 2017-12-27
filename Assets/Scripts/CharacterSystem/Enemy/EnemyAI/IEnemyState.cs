using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}

public enum EnemyConditionState
{
    NullCondition,
    CanAttack,
    SeeSoldier
}

public abstract class IEnemyState
{
    protected EnemyFSMSystem enemyFSMSystem;
    public EnemyStateID stateID;

    public IEnemyState(EnemyFSMSystem enemyFSMSystem)
    {
        this.enemyFSMSystem = enemyFSMSystem;
    }

    Dictionary<EnemyConditionState, EnemyStateID> mMap = new Dictionary<EnemyConditionState, EnemyStateID>();

    public void Add(EnemyConditionState conditionState, EnemyStateID stateID)
    {
        if (conditionState == EnemyConditionState.NullCondition)
        {
            Debug.LogError("conditionState:NullCondition"); return;
        }

        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("stateID:NullState"); return;
        }

        if (mMap.ContainsKey(conditionState))
        {
            Debug.LogError("已经添加了:" + conditionState); return;
        }

        mMap.Add(conditionState, stateID);
    }

    public void Delete(EnemyConditionState conditionState)
    {
        if (conditionState == EnemyConditionState.NullCondition)
        {
            Debug.LogError("conditionState:NullCondition"); return;
        }

        if (mMap.ContainsKey(conditionState) == false)
        {
            Debug.LogError("找不到:" + conditionState); return;
        }

        mMap.Remove(conditionState);
    }

    /// <summary>
    /// 是否可以转换
    /// </summary>
    /// <param name="stateID"></param>
    /// <returns></returns>
    public EnemyStateID GetOutPutStateID(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return EnemyStateID.NullState;
        }

        if (mMap.ContainsValue(stateID) == false)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return EnemyStateID.NullState;
        }

        return stateID;
    }

    public virtual void OnStateLeave() { }
    public virtual void OnStateBegin(Vector3 targetPosition) { }
    public abstract void Reason(List<ICharacter> c);
    public abstract void Act(List<ICharacter> c);
}
