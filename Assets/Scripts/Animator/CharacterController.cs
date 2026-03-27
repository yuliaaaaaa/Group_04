using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 8.5f;
    
    private Animator animator;
    private GroundChecker groundChecker;
    private Rigidbody rigidbody;
    private float currentRotationY = 0f;

    void Start()
    {
        animator = GetComponent<Animator>(); 
        rigidbody = GetComponent<Rigidbody>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }
    
    void Update()
    {
        HandleInput();
        HandleAnimation();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && groundChecker.isGround)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetInteger("Attack", 1);
        }
        else
        {
            animator.SetInteger("Attack", 0);
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        currentRotationY += horizontal * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
        
        Vector3 direction = vertical * transform.forward * speed;
        direction.y = rigidbody.linearVelocity.y;
        
        rigidbody.linearVelocity = direction; 
    }

    private void HandleAnimation()
    {
        bool isGroundCheck = groundChecker.isGround;
        
        animator.SetBool("isGround", isGroundCheck);
        float horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));
        float vertical = Mathf.Abs(Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", horizontal + vertical);
    }
}
