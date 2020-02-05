using UnityEngine;

public class GroundedLogic: MonoBehaviour
{
    public static implicit operator bool(GroundedLogic logic)
    {
        return logic.IsGrounded;
    }

    CapsuleCollider collider;
    private bool c;
    private bool r;
    private bool j;

    private Collision collision;
    private float jumpTime;

    private bool grounded;

    public float stairHeight = 0.3f;

    public void Awake()
    {
     
        c = false;
        r = false;
        j = false;
        collider = GetComponent<CapsuleCollider>();
    }
    


    private void OnCollisionStay(Collision collision)
    {
        this.collision = collision;
        if(Time.time - jumpTime > 0.3f)
        CheckCollision();
    }

    void CheckCollision()
    {
        if(collision != null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                float angle = Vector3.Angle(Vector3.down, -contact.normal);
                if (angle < 10)
                {
                    c = true;
                    j = false;
                    return;
                }
            }
        }
        c = false;

    }
    

    void CheckRaycast()
    {
        Vector3 point = transform.TransformPoint(collider.center);
        Vector3 dir = Vector3.down;
        float length = collider.height / 2 + stairHeight;

        r = Physics.Raycast(point, dir, length);
        Debug.DrawRay(point, dir, Color.blue);
    }

    void Update()
    {
        CheckRaycast();
        grounded = (!j && r) || c;
        
    }

    public void NotifyJump()
    {
        jumpTime = Time.time;
        c = false;
        j = true;
    }

    public bool IsGrounded
    {
        get { return grounded; }
    }
    
}