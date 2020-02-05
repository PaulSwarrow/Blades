using UnityEngine;
public class CharacterFacade : MonoBehaviour
{
    [SerializeField]
    private RuntimeAnimatorController defaultAnimatorController;

    private Animator animator;

    private AnimatorProxy actor;
    private AbstractCharacterInput input;
    private CharacterPhysics physics;
    private AbstractCameraController view;
    [SerializeField]
    private CharacterInteractionController interaction;

    private void Awake()
    {
        //init:
        animator = GetComponent<Animator>();
        input = GetComponent<AbstractCharacterInput>(); if (input == null) input = gameObject.AddComponent<AbstractCharacterInput>();
        physics = GetComponent<CharacterPhysics>(); if (physics == null) physics = gameObject.AddComponent<CharacterPhysics>();
        view = GetComponent<AbstractCameraController>(); if (view == null) view = gameObject.AddComponent<AbstractCameraController>();

        interaction.init();
        ResetAnimatorController();
    }

    private void Update()
    {
        Vector3 targetDirection;

        //read input:
        float forward = input.Forward;
        float strafe = input.Strafe;
        bool run = input.Run;
        bool jump = input.Jump;
        bool seat = input.Seat;
        bool use = input.Use;
        
        //read physics
        bool grounded  = physics.IsGrounded;


        //read camera

        targetDirection = view.LookDirection;
        //camera update:


        //animate:
        actor.lookDirection = targetDirection;
        actor.strafe = strafe;
        actor.forward = forward;

        actor.grounded = grounded;
        actor.seat = seat;
        actor.run = run;
        actor.jump = jump;
        actor.Update();
        
        //move & steer:
        Quaternion steering = actor.GetSteering();
        Vector3 movement = actor.GetMovement();

        physics.Move(movement, steering);
        
        if (use)
        {
            interaction.Use();
        }

    }

    private void OnAnimatorIK(int layerIndex)
    {
        actor.OnAnimatorIK();
    }

    private void OnAnimatorMove()
    {
        actor.OnAnimatorMove();
    }

    public void SetAnimatorController(RuntimeAnimatorController controller)
    {
        if (animator.runtimeAnimatorController != controller)
        {
            if(actor != null)
            {
                actor.Destroy();
            }
            animator.runtimeAnimatorController = controller;
            actor = animator.GetBehaviour<AnimatorProxy>();
            actor.Init(animator);
        }
        
    }

    public void ResetAnimatorController()
    {
        SetAnimatorController(defaultAnimatorController);
    }

    private void OnGUI()
    {
        interaction.Draw();
    }
}