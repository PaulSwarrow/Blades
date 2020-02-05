using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TWP;
using Ps.Utils;
using System;

public class ChacterMotionController : MonoBehaviour {
    private enum AnimParam
    {
        forward, 
        strafe,
        angle
    }

    

    //components:
    CharacterController controller;

    //strategies:
    //GroundedLogic grounded;
    bool grounded;
    CharacterSteering turnController;
    [SerializeField]
    MouseLook cameraController;

    //vars:
    private Vector3 motion = Vector3.zero;
    private Vector3 velocity;
    private float velocityY = 0;
    private Vector3 lastPos;

    //preferences:
    public Transform head;
    public Transform neck;

    public Transform camera;

    public float ikHeadWeight = 1;
    public float ikBodyWeight = 0.3f;

    public float gravity = 0.4f;

    
    public Vector2 jump;
    private float lastGroundedTime;

    public bool Grounded
    {
        get
        {
            return grounded;
        }

        set
        {
            if (value != grounded)
            {
                if(!value)
                {
                    lastGroundedTime = Time.realtimeSinceStartup;
                }
                grounded = value;
            }
        }
    }

    void Awake () {
        //components:
        /*actor = new Actor(GetComponent<Animator>());
        controller = GetComponent<CharacterController>();

        //strategies:
        cameraController = new MouseLook();
        turnController = new CharacterSteering();
        //grounded = gameObject.AddComponent<GroundedLogic>();
        
        //init:
        lastPos = transform.position;
        cameraController.Init(transform, camera);*/
    }
    

    void OnAnimatorIK ()
    {
        //actor.target.SetLookAtWeight(1,ikBodyWeight, ikHeadWeight);
        //actor.target.SetLookAtPosition(head.position + camera.TransformDirection(Vector3.forward));

    }
    // Update is called once per frame
	void Update () {
    }

    private void OnAnimatorMove()
    {
        /*
        //gravity:

        //camera:
        cameraController.LookRotation(camera.parent, camera);

        //LOCOMOTION:
        //input:
        float angle;
        Vector3 selfDirection = transform.TransformDirection(Vector3.forward);
        Vector3 targetDirection;
        float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");
        int speed = (forward != 0 || strafe != 0) ? (Input.GetButton("Run") ? 2 : 1) : 0;
        bool jump = controller.isGrounded && Input.GetButtonDown("Jump");
        bool seat = Input.GetButton("Seat");



        //steer:
        switch(speed)
        {
            case 0:
                targetDirection = camera.parent.TransformDirection(Vector3.forward);
                transform.rotation = actor.target.rootRotation;
                break;
            case 1:
                targetDirection = camera.parent.TransformDirection(Vector3.forward);
                turnController.angularVelocity = 3;
                turnController.Rotate(transform, targetDirection);
                break;
            case 2:
                targetDirection = camera.parent.TransformDirection(new Vector3(strafe, 0, forward));
                turnController.angularVelocity = 2;
                turnController.Rotate(transform, targetDirection);
                break;

            default:
                targetDirection = camera.parent.TransformDirection(Vector3.forward);
                break;

        }

        angle = Angles.SignedAngle(selfDirection, targetDirection);

        //Debug.DrawRay(camera.transform.position, selfDirection,Color.blue, 1);
        //Debug.DrawRay(camera.transform.position, targetDirection,Color.red, 1);

        //move:
        motion = actor.target.deltaPosition;
        if (jump)
        {
            velocity = motion;
            velocityY += 0.2f;
        }
        velocityY -= gravity * Time.deltaTime;


        controller.Move(motion + Vector3.up * velocityY + velocity);

        Grounded = controller.isGrounded;
        
        if (Grounded)
        {
            velocity = Vector3.zero;
            velocityY = -2*gravity * Time.deltaTime;//-controller.stepOffset / Time.deltaTime; 
        }
        else
        {
            velocity *= 0.99f;
        }


        lastPos = transform.position;
        //ANIMATION:
        actor[ActorVar.Bool.grounded] = (Grounded || Time.realtimeSinceStartup - lastGroundedTime < 0.08f);
        //animator.SetTrigger(AvatarController.Trigger.jump);
        //actor[ActorVar.Int.speed] = speed;
        actor[ActorVar.Float.angle] = angle;
        actor[ActorVar.Float.forward] = forward;
        actor[ActorVar.Float.strafe] = strafe;
        actor[ActorVar.Bool.seat] = seat;*/
    }

    void LateUpdate()
    {
        camera.parent.parent.position = head.TransformPoint(Vector3.zero);
        //camera.parent.parent.rotation = neck.rotation;
    }


}
