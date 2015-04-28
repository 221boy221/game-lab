using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour 
{

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public float jumpSpeed = 20.0f;
    public float upDownRange = 60.0f;
    
    private float _verticalRotation = 0;
    private float _verticalVelocity = 0;

    CharacterController characterController;

    void Start()
    {
        Screen.lockCursor = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        _verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);

        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        _verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetButton("Jump")) 
        {
            _verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(sideSpeed, _verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);
    }

}
