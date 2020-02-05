using UnityEngine;
using System.Collections;

public class AnimatorProxy: StateMachineBehaviour
{
    //SET:
    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool run = false;
    [HideInInspector]
    public bool seat = false;
    [HideInInspector]
    public bool grounded = false;

    [HideInInspector]
    public Vector3 lookDirection = Vector3.zero;
    [HideInInspector]
    public float strafe = 0;
    [HideInInspector]
    public float forward = 0;

    private Animator target;
    
    //INIT:
    public virtual void Init(Animator actor)
    {
        this.target = actor;
    }

    public virtual void Destroy()
    {
        target = null;
    }

    //UPDATE:
    public virtual void OnAnimatorIK ()
    {

    }

    public virtual void OnAnimatorMove()
    {

    }

    public virtual void Update()
    {

    }

    //GET:
    public virtual bool GetJumpAvailable()    {  return true;    }

    public virtual bool GetUseGravity { get { return true; } }

    public virtual Vector3 GetMovement() { return Vector3.zero; }

    public virtual Quaternion GetSteering() { return Quaternion.identity; }


    //protected:
    protected Animator Target { get { return target; } }

}
