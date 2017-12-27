using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IWeapon
{
    public IWeaponAttr iWeaponAttr;

    public IWeapon(IWeaponAttr iWeaponAttr)
    {
        this.iWeaponAttr = iWeaponAttr;
    }

    public void Fire(Vector3 targetPosition)
    {
        Effect();
        DrawLine(targetPosition);
        PlayAudio();
    }

    protected virtual void Effect()
    {
        iWeaponAttr.particleSystem.Stop();
        iWeaponAttr.particleSystem.Play();
        iWeaponAttr.light.enabled = true;
    }

    protected virtual void DrawLine(Vector3 targetPosition)
    {
        SetLine(targetPosition, 0.05f, 0.05f);
    }

    protected void SetLine(Vector3 targetPosition, float startWidth, float endWidth)
    {
        iWeaponAttr.lineRenderer.enabled = true;
        iWeaponAttr.lineRenderer.startWidth = 0.05f; iWeaponAttr.lineRenderer.endWidth = 0.05f;
        iWeaponAttr.lineRenderer.SetPosition(0, iWeaponAttr.gameObject.transform.position);
        iWeaponAttr.lineRenderer.SetPosition(1, targetPosition);
    }

    protected virtual void PlayAudio()
    {
        iWeaponAttr.audioSource.clip = iWeaponAttr.audioClip;
        iWeaponAttr.audioSource.Play();
    }
}
