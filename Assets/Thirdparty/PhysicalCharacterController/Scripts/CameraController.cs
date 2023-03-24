using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform body;
    public float maxVerticalAngle;
    public float sensitivity;
    public float smoothTime = 0.1f;

    private float mouseX;
    private float mouseY;
    private float smoothX;
    private float smoothY;
    private Vector3 velocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        float vertical = Input.GetAxis("Mouse Y") * sensitivity;

        mouseX += horizontal;
        mouseY -= vertical;
        mouseY = Mathf.Clamp(mouseY, -maxVerticalAngle, maxVerticalAngle);

        smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref velocity.x, smoothTime);
        smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref velocity.y, smoothTime);

        Quaternion finalRotation = Quaternion.Euler(smoothY, smoothX, 0f);
        cameraTransform.rotation = finalRotation;
        body.rotation = Quaternion.Euler(0f, smoothX, 0f);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
