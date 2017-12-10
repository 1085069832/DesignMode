using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleMode : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        People people = new People2();
        people.Eat();
    }
}

public abstract class People
{
    public void Eat()
    {
        Check();
        EatSomething();
        Pay();
    }

    private void Check()
    {
        Debug.Log("点菜");
    }

    public virtual void EatSomething()
    {

    }

    private void Pay()
    {
        Debug.Log("支付");
    }
}

public class People1 : People
{
    public override void EatSomething()
    {
        Debug.Log("吃面");
    }
}

public class People2 : People
{
    public override void EatSomething()
    {
        Debug.Log("吃饭");
    }
}