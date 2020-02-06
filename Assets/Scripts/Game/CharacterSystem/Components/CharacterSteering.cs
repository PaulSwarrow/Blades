using UnityEngine;
using System;
using CharacterSystem.Interfaces;
using Ps.Utils;
using UnityEngine.Experimental.PlayerLoop;

public class CharacterSteering : BaseCharacterComponent
{
    public float blindZone = 0;
    public float angularVelocity = 2;

    public float accurancy = 0.1f;
    public bool rotating = false;


    private void Update()
    {
        Rotate(transform, context.input.LookDrirection);
    }

    public void Rotate(Transform character, Vector3 targetDirection)
    {
        if(targetDirection == Vector3.zero) return;
        Vector3 selfDirection = character.TransformDirection(Vector3.forward);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        float angle = Vector3.Angle(selfDirection, targetDirection);
        if(angle > blindZone && angle > accurancy)
        {
            rotating = true;
        } else if( angle < accurancy)
        {
            rotating = false;
        }

        if (rotating)
        {
            character.rotation = Quaternion.Slerp(character.rotation, targetRotation, Time.deltaTime * angularVelocity);
        }
    }
}