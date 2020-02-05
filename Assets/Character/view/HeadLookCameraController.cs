using UnityEngine;

public class HeadLookCameraController : AbstractCameraController
{
    public Transform camera;
    public Transform head;

    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool lockCursor = true;

    private float steer = 0;
    private float angle = 0;
    private bool cursorIsLocked = true;


    private void Update()
    {
        camera.parent = head;
        camera.rotation = Quaternion.LookRotation(camera.TransformDirection(Vector3.forward), Vector3.up);

        float xRot = Input.GetAxis("Mouse X") * XSensitivity;
        float yRot = -Input.GetAxis("Mouse Y") * YSensitivity;

        steer += xRot;
        angle += yRot;

        if (clampVerticalRotation)
        {
             angle = Mathf.Clamp(angle, MinimumX, MaximumX);
        }

        UpdateCursorLock();
    }

    public override Vector3 LookDirection
    {
        get
        {
            return Quaternion.Euler(angle , steer, 0) * Vector3.forward;
        }
    }


    private void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIsLocked = true;
        }

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}