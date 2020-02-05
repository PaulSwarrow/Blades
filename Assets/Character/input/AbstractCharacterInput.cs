using UnityEngine;
using System.Collections;

public class AbstractCharacterInput : MonoBehaviour
{
    
    public virtual float Strafe { get { return 0; } }

    public virtual float Forward { get{ return 0;} }

    public virtual bool Run { get{ return false;} }

    public virtual bool Seat { get { return false; } }

    public virtual bool Jump { get { return false; } }

    public virtual bool Use { get { return false; } }
}
