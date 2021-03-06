﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

public enum SoldierConditionState
{
    NullCondition,
    SeeEnemy,
    NoEnemy,
    CanAttack,
}

public abstract class ISoldierState
{
    protected SoldierFSMSystem soldierFSMSystem;
    public SoldierStateID stateID;

    public ISoldierState(SoldierFSMSystem soldierFSMSystem)
    {
        this.soldierFSMSystem = soldierFSMSystem;
    }

    Dictionary<SoldierConditionState, SoldierStateID> mMap = new Dictionary<SoldierConditionState, SoldierStateID>();

    public void Add(SoldierConditionState conditionState, SoldierStateID stateID)
    {
        if (conditionState == SoldierConditionState.NullCondition)
        {
            Debug.LogError("conditionState:NullCondition"); return;
        }

        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("stateID:NullState"); return;
        }

        if (mMap.ContainsKey(conditionState))
        {
            Debug.LogError("已经添加了:" + conditionState); return;
        }

        mMap.Add(conditionState, stateID);
    }

    public void Delete(SoldierConditionState conditionState)
    {
        if (conditionState == SoldierConditionState.NullCondition)
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
    public SoldierStateID GetOutPutStateID(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return SoldierStateID.NullState;
        }

        if (mMap.ContainsValue(stateID) == false)
        {
            Debug.LogError("不存在转换到[" + stateID + "]的条件");
            return SoldierStateID.NullState;
        }

        return stateID;
    }

    public virtual void OnStateLeave() { }
    public virtual void OnStateBegin() { }
    public abstract void Reason(List<ICharacter> c);
    public abstract void Act(List<ICharacter> c);
}

