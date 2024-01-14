using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private float CharacterSpeed = 2f;

    [SerializeField]
    private float verticalSpeed = 2.0F;

    private CharacterController characterController;

    private Vector3 moveDirection;

    public bool crouch = false;


    public bool isOnBall = false;
    public string targetTag = "BallPool"; // Define the tag to check against

    [SerializeField]
    private float crouchSize= 1f;

    [SerializeField]
    private AudioSource BallWalkSound;

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private AudioSource FootstepSound;

    [SerializeField]
    private AudioSource crackGlowingStick;

    [SerializeField]
    private int SlowInBallPool;
    private GameManager gameManager;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        verticalSpeed = 0.0f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    private Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";
    void Update()
    {
        // Camera rotation
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
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            verticalSpeed = CalculateJumpVerticalSpeed();
        }
        // Crouch 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - crouchSize, transform.localScale.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crouchSize, transform.localScale.z);
        }

        moveDirection.y = verticalSpeed;
        characterController.Move(moveDirection * CharacterSpeed * Time.deltaTime);
        // When you crack Stick

        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        if (isMoving && isOnBall)
        {
            if (BallWalkSound != null) // Check the audio source
            {
                BallWalkSound.loop = true; // Set sound to loop
                if (!BallWalkSound.isPlaying)
                {
                    BallWalkSound.Play(); // Start playing the sound if not already playing
                }
            }
        }
        else
        {
            if (BallWalkSound != null)
            {
                BallWalkSound.loop = false; // Disable looping
                BallWalkSound.Stop(); // Stop the sound
            }
        }
        if (isMoving && isOnBall == false)
        {
            if (FootstepSound != null) // Check the audio source
            {
                FootstepSound.loop = true; // Set sound to loop
                if (!FootstepSound.isPlaying)
                {
                    FootstepSound.Play(); // Start playing the sound if not already playing
                }
            }
        }
        else
        {
            if (FootstepSound != null)
            {
                FootstepSound.loop = false; // Disable looping
                FootstepSound.Stop(); // Stop the sound
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            crackGlowingStick.Play();
        }
        light.SetActive(gameManager.getIsLightning());
        

    }
    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * 0.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isOnBall = true;
            CharacterSpeed = CharacterSpeed / SlowInBallPool;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isOnBall = false;
            CharacterSpeed = 2f;
        }
    }
}
