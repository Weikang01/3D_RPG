using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PlayerCameraDistance { get; set; }
    public float PlayerHeightOffset { get; set; }
    public Transform cameraTarget;

    Camera playerCamera;
    float zoomSpeed = 10f;

    private void Start()
    {
        PlayerCameraDistance = 10f;
        PlayerHeightOffset = 1f;
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            PlayerCameraDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            PlayerCameraDistance = Mathf.Clamp(PlayerCameraDistance, 1, 30);
        }
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + PlayerCameraDistance + PlayerHeightOffset, cameraTarget.position.z - PlayerCameraDistance);
    }
}
