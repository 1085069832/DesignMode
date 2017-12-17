using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SoldierFSMSystem
{
    ISoldierState currentState;//当前的状态
    List<ISoldierState> soldierStateList = new List<ISoldierState>();

    public void Reason()
    {
        currentState.Reason();
    }

    public void Act()
    {
        currentState.Act();
    }

    public void Add(ISoldierState soldierState)
    {
        if (soldierState == null)
        {
            Debug.LogError("状态为空"); return;
        }

        if (soldierStateList.Contains(soldierState) == true)
        {
            Debug.LogError("状态已经存在"); return;
        }

        if (soldierStateList.Count == 0)
        {
            currentState = soldierState;
        }

        soldierStateList.Add(soldierState);
    }

    public void Delete(ISoldierState soldierState)
    {
        if (soldierState == null)
        {
            Debug.LogError("状态为空"); return;
        }

        if (soldierStateList.Contains(soldierState) == false)
        {
            Debug.LogError("状态不存在"); return;
        }

        soldierStateList.Remove(soldierState);
    }

    public void ChangeState(StateID stateID)
    {
        if (stateID == StateID.NullState)
        {
            Debug.LogError("stateID为NullState"); return;
        }

        StateID id = currentState.GetOutPutStateID(stateID);

        if (id != StateID.NullState)
        {
            for (int i = 0; i < soldierStateList.Count; i++)
            {
                if(id == soldierStateList[i].stateID)
                {
                    currentState.OnStateLeave();
                    currentState = soldierStateList[i];
                    currentState.OnStateBegin();
                    break;
                }
            }
        }
    }
}

