using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum StateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

public enum ConditionState
{
    NullCondition,
    SeeEnemy,
    NoEnemy,
    CanAttack,
}

public abstract class ISoldierState
{
    protected SoldierFSMSystem soldierFSMSystem;
    public StateID stateID;

    public ISoldierState(SoldierFSMSystem soldierFSMSystem)
    {
        this.soldierFSMSystem = soldierFSMSystem;
    }

    Dictionary<ConditionState, StateID> mMap = new Dictionary<ConditionState, StateID>();

    public void Add(ConditionState conditionState, StateID stateID)
    {
        if (conditionState == ConditionState.NullCondition)
        {
            Debug.LogError("conditionState:NullCondition"); return;
        }

        if (stateID == StateID.NullState)
        {
            Debug.LogError("stateID:NullState"); return;
        }

        if (mMap.ContainsKey(conditionState))
        {
            Debug.LogError("已经添加了:" + conditionState); return;
        }

        mMap.Add(conditionState, stateID);
    }

    public void Delete(ConditionState conditionState)
    {
        if (conditionState == ConditionState.NullCondition)
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
    public StateID GetOutPutStateID(StateID stateID)
    {
        if (stateID == StateID.NullState)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return StateID.NullState;
        }

        if (mMap.ContainsValue(stateID) == false)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return StateID.NullState;
        }

        return stateID;
    }

    public virtual void OnStateLeave() { }
    public virtual void OnStateBegin() { }
    public abstract void Reason();
    public abstract void Act();
}

