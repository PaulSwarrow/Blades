using UnityEngine;
using System.Collections;

public class AbstractCameraController : MonoBehaviour
{

    public virtual Vector3 LookDirection
    {
        get
        {
            return Vector3.forward;
        }
    }
}