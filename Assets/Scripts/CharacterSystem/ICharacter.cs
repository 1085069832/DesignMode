using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mCharacterAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudio;

    protected string iconSprite;

    IWeapon mIWeapon;

    public void SetWeapon(IWeapon iWeapon)
    {
        mIWeapon = iWeapon;
    }

    public void Attack(Vector3 targetPosition)
    {
        if (mIWeapon != null)
            mIWeapon.Fire(targetPosition);
        else
            Debug.Log("Weapon:" + mIWeapon);
    }
}
