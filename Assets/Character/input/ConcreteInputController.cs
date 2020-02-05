using UnityEngine;
using System.Collections;

public class ConcreteInputController : AbstractCharacterInput
{
    public override float Strafe
    {
        get { return Input.GetAxis("Horizontal"); }
    }

    public override float Forward
    {
        get { return Input.GetAxis("Vertical"); }
    }

    public override bool Run
    {
        get { return Input.GetButton("Run"); }
    }

    public override bool Seat
    {
        get { return Input.GetButton("Seat"); }
    }

    public override bool Jump
    {
        get { return Input.GetButtonDown("Jump"); }
    }

    public override bool Use
    {
        get { return Input.GetButtonDown("Use"); }
    }
}