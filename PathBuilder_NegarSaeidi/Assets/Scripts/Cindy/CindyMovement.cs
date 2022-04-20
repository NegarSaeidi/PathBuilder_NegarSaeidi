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
    public float aimSensitivity = 5.0f;
    public Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    public Vector2 lookInput = Vector2.zero;

    public bool gameEnd;

    Rigidbody rigidBody;
    Animator playerAnimator;
    //public GameObject gameFinishText;
    //public GameObject mainmenuButton;
   public GameObject pausePanel;
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");

    public readonly int isRunningHash = Animator.StringToHash("IsRunning");

    public GameObject followTarget;


    public static bool IsPaused;
    public static bool startMovement;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        inputVector = Vector2.zero;
      //  mainmenuButton.SetActive(false);
       // pausePanel.SetActive(false);
    }


    void Update()
    {
        if (startMovement && !IsPaused)
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
            //  transform.Rotate(Vector3.up * inputVector.x);



            if (!(inputVector.magnitude > 0))
            {
              
                moveDirection = Vector3.zero;
            }
        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;
        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;
         
        }
    }
    public void OnMovement(InputValue value)
    {
        if (!IsPaused)
        {
            inputVector = value.Get<Vector2>();
            playerAnimator.SetFloat(movementXHash, inputVector.x);
            playerAnimator.SetFloat(movementYHash, inputVector.y);
        }

    }
 
    public void OnRun(InputValue value)
    {
        if (!IsPaused)
        {
            playerController.isRunning = value.isPressed;
            playerAnimator.SetBool(isRunningHash, playerController.isRunning);
        }
    }
   
    public void OnPause(InputValue value)
    {
        playerController.isPaused = value.isPressed;
       pausePanel.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;

    }
    public void OnLook(InputValue value)
    {

        lookInput = value.Get<Vector2>();

    }
    

}