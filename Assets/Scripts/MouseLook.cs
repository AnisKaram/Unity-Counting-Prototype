using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    float mouseSensitivity = 100f;
    float xRotation = 0f;

    void Awake()
    {
        // Hide & Lock the Cursor When player Playing
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Look Up & Down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, -90f, 0f);

        // Look Right & Left
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
