using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    public bool IsDead = false;
    
    [Header("Links")]
    public GameObject Text;

    [Header("Stats")]
    public float walkSpeed = 6f;
    public float jumpPower = 5f;
    public float gravity = 10f;

    public float defaultHeight = 2f;
    public float crouchHeight = 1f;

    //Private Variables
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    private bool canMove = true;

    #endregion


    void Start()
    {
        //Get Character Controller
        characterController = GetComponent<CharacterController>();

        //Hide And Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(IsDead)
        {
            Text.gameObject.SetActive(true);
        }

        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (right * curSpeedY);

        //Check For Jump and Apply Force
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        //Add Gravity if Midair
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //Check For Crouch and Shrink and Reduce Speed
        if (Input.GetKey(KeyCode.S) && canMove)
        {
            characterController.height = crouchHeight;
        }
        else
        {
            characterController.height = defaultHeight;
        }

        //Delta Time
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
