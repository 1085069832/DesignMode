using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mCharacterAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudio;
    public Vector3 Target { get; set; }

    protected string iconSprite;

    IWeapon mIWeapon;

    public void SetWeapon(IWeapon iWeapon)
    {
        mIWeapon = iWeapon;
    }

    public float AttackDistance()
    {
        if (mIWeapon != null)
            return mIWeapon.iWeaponAttr.AttackDistance;
        else
        {
            Debug.Log("Weapon:" + mIWeapon);
            return 0;
        }
    }

    public void Attack(Vector3 targetPosition)
    {
        if (mIWeapon != null)
            mIWeapon.Fire(targetPosition);
        else
            Debug.Log("Weapon:" + mIWeapon);
    }

    public Vector3 Position()
    {
        return mGameObject.transform.position;
    }

    public void MoveTo(Vector3 targetPosition)
    {

    }
}
