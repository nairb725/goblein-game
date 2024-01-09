using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private float CharacterSpeed;

    [SerializeField]
    private float verticalSpeed = 2.0F;

    private CharacterController characterController;

    private Vector3 moveDirection;

    public bool crouch = false;

    [SerializeField]
    private float crouchSize= 1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        verticalSpeed = 0.0f;
    }

    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    //Camera range to not spin around you
    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";
    void Update()
    {
        //Camera rotation
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward * moveZ;
        Vector3 right = transform.right * moveX;

        moveDirection = forward + right;
        moveDirection.Normalize();

        // If on the floor
        if (characterController.isGrounded)
        {
            verticalSpeed = 0.0f;
        }
        else
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime;
        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            verticalSpeed = CalculateJumpVerticalSpeed();
        }
        // Crouch 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("au sol");
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - crouchSize, transform.localScale.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("au sol");
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crouchSize, transform.localScale.z);
        }

        moveDirection.y = verticalSpeed;
        characterController.Move(moveDirection * CharacterSpeed * Time.deltaTime);
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * 0.5f);
    }
}