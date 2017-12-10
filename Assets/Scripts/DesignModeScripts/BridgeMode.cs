using UnityEngine;
using System.Collections;

public class BridgeMode : MonoBehaviour
{
    void Start()
    {
        /*
        IRender render = new SuperX();
        Shpere shpere = new Shpere(render);
        shpere.Draw();
        */

        SoldierCaptain soldierCap = new SoldierCaptain();
        soldierCap.SetWeapon(new WeaponRifle());
        soldierCap.Attack(Vector3.zero);

    }
}

public class Shpere
{
    IRender render;
    public Shpere(IRender render)
    {
        this.render = render;
    }

    public void Draw()
    {
        render.Draw("Shpere");
    }
}

public abstract class IRender
{
    public abstract void Draw(string name);
}

public class OpenGL : IRender
{
    public override void Draw(string name)
    {
        Debug.Log("OpenGL " + name);
    }
}

public class Dx : IRender
{
    public override void Draw(string name)
    {
        Debug.Log("Dx " + name);
    }
}

public class SuperX : IRender
{
    public override void Draw(string name)
    {
        Debug.Log("SuperX " + name);
    }
}
