using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMode : MonoBehaviour
{
    void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));

        context.Handle(11);//a
        context.Handle(10);//b
        context.Handle(4);//a
        context.Handle(4);//a
    }
}

public class Context
{
    IState mState;

    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle(int arg)
    {
        mState.Handle(arg);
    }
}

public abstract class IState
{
    public abstract void Handle(int arg);
}

public class ConcreteStateA : IState
{
    Context mContext;
    public ConcreteStateA(Context context)
    {
        mContext = context;
    }

    public override void Handle(int arg)
    {
        Debug.Log("状态A");
        if (arg > 10)
        {
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    Context mContext;
    public ConcreteStateB(Context context)
    {
        mContext = context;
    }

    public override void Handle(int arg)
    {
        Debug.Log("状态B");
        if (arg <= 10)
        {
            mContext.SetState(new ConcreteStateA(mContext));
        }
    }
}