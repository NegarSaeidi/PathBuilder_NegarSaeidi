using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class CindyMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5;
    [SerializeField]
    private float runSpeed = 10;
    [SerializeField]
    private float jumpForce = 5;

    private PlayerController playerController;
    public float aimSensitivity = 1.0f;
    public Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    public bool gameEnd;

    Rigidbody rigidBody;
    Animator playerAnimator;
    //public GameObject gameFinishText;
    //public GameObject mainmenuButton;
   // public GameObject pausePanel;
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");

    public GameObject followTarget;
    //[Header("Ground Detection")]
    //public Transform groundCheck;
    //public float groundRadius = 0.5f;
    //public LayerMask groundMask;
    //public bool isGrounded;

    //public GameObject deathRespawn;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
      //  mainmenuButton.SetActive(false);
       // pausePanel.SetActive(false);
    }

    void Start()
    {
        //gameEnd = false;
        //JimmyAniamtion.win = false;
        //JimmyAniamtion.lose = false;
        //JimmyAniamtion.bulbHit = false;
        //JimmyAniamtion.snowmanHit = false;
        //JimmyAniamtion.deathPlaneHit = false;
        //JimmyAniamtion.inPause = false;

    }


    void Update()
    {
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);

        var angles = followTarget.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTarget.transform.localEulerAngles.x;
        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 70)
        {
            angles.x = 70;
        }

        followTarget.transform.localEulerAngles = angles;
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);
        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
          transform.Rotate(Vector3.up * inputVector.x);


        // if (playerController.isJumping) return;
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;
        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;
        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }
    public void OnMovement(InputValue value)
    {
            inputVector = value.Get<Vector2>();
            playerAnimator.SetFloat(movementXHash, inputVector.x);
           playerAnimator.SetFloat(movementYHash, inputVector.y);
       
    }
    public void OnRun(InputValue value)
    {
            playerController.isRunning = value.isPressed;
          //  playerAnimator.SetBool(isRunningHash, playerController.isRunning);
        
    }
    public void OnJump(InputValue value)
    {
        //if (playerController.isJumping)
        //{
        //    return;
        //}
        //if (!JimmyAniamtion.inPause)
        //{
          //  GetComponent<AudioSource>().Play();
           // playerController.isJumping = value.isPressed;
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 8, GetComponent<Rigidbody>().velocity.z);
            // rigidBody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
          //  playerAnimator.SetBool(isJumpingHash, true);
        //}


    }
    public void OnPause(InputValue value)
    {
        playerController.isPaused = value.isPressed;
        //pausePanel.SetActive(true);
        //JimmyAniamtion.inPause = true;
    }
    public void OnLook(InputValue value)
    {

        lookInput = value.Get<Vector2>();

    }
    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("Ground") && !playerController.isJumping) return;
       // playerController.isJumping = false;
        //playerAnimator.SetBool(isJumpingHash, false);
    }

}