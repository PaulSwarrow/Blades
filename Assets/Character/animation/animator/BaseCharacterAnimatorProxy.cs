using UnityEngine;
using System.Collections;
using Ps.Utils;

public class BaseCharacterAnimatorProxy : AnimatorProxy
{
    //MAP:
    private static int FLOAT_FORWARD = Animator.StringToHash("forward");
    private static int FLOAT_STRAFE = Animator.StringToHash("strafe");
    private static int FLOAT_ANGLE = Animator.StringToHash("angle");

    private static int BOOL_WALK = Animator.StringToHash("walk");
    private static int BOOL_RUN = Animator.StringToHash("run");
    private static int BOOL_SEAT = Animator.StringToHash("seat");
    private static int BOOL_GOUNDED = Animator.StringToHash("grounded");

    private static int FLAG_JUMP_POSSIBLE = Animator.StringToHash("jumpPossible");
    private static int FLAG_IGNORE_GRAVIRTY = Animator.StringToHash("disableGravity");
    
    public float jumpForce = 20;

    private Quaternion steering;
    private Vector3 deltaPostion;

    public override void Update()
    {
    }

    override public void OnAnimatorMove()
    {

        Vector3 selfDirection = Target.transform.TransformDirection(Vector3.forward);
        Camera cam = Camera.main;
        bool walk = forward != 0 || strafe != 0;
        Vector3 lookFlat = lookDirection;
        lookFlat.y = 0;

        Vector3 inputDirection = Quaternion.LookRotation(lookFlat, Vector3.up)*new Vector3(strafe, 0, forward);
        Vector3 targetDirection =  lookDirection;
        targetDirection.y = 0;
        targetDirection.Normalize();

        //rotate:
        float currentAngle = Vector3.Angle(Vector3.forward, selfDirection);
        float targetAngle = Vector3.Angle(Vector3.forward, targetDirection);

        Debug.DrawRay(Target.transform.position, selfDirection, Color.blue);
        Debug.DrawRay(Target.transform.position, inputDirection, Color.red);
        Debug.DrawRay(Target.transform.position, lookFlat, Color.green);
        if (walk)
        {
            float angularSpeed = run ? 2 : 4;
            steering = Quaternion.Slerp(Target.transform.rotation, Quaternion.LookRotation(targetDirection, Vector3.up), Time.deltaTime* angularSpeed);
        }
        else
        {
            steering = Target.targetRotation;
        }
        Target.SetFloat(FLOAT_ANGLE, Angles.SignedAngle(selfDirection, targetDirection));

        //move:
        //deltaPostion = Target.deltaPosition;

        if (GetJumpAvailable() && jump)
        {
            deltaPostion.y += jumpForce * Time.deltaTime;
        }

        //animate:
        Target.SetFloat(FLOAT_FORWARD, forward);
        Target.SetFloat(FLOAT_STRAFE, strafe);

        Target.SetBool(BOOL_WALK, walk);
        Target.SetBool(BOOL_RUN, run);
        Target.SetBool(BOOL_SEAT, seat);
        Target.SetBool(BOOL_GOUNDED, grounded);
    }


    override public void OnAnimatorIK()
    {
        Transform head = Target.GetBoneTransform(HumanBodyBones.Head);
        Target.SetLookAtPosition(head.position + lookDirection);
        Target.SetLookAtWeight(1);
    }

    public override bool GetJumpAvailable()
    {
        return grounded/* & Target.GetBool(FLAG_JUMP_POSSIBLE)*/;
    }

    public override Quaternion GetSteering()
    {
        return steering;
    }

    public override Vector3 GetMovement()
    {
        return deltaPostion;
    }



}
