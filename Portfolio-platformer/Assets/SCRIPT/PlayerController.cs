

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SideScrollerController : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float speed = 6f;
    public float jumpHeight = 1.2f;
    public float gravity = -25f;

    [Tooltip("1 if pressing right should move toward +Z, -1 for -Z. Depends on which side your camera is on.")]
    public int rightDirection = 1;

    [Header("GROUND CHECK")]
    public LayerMask groundLayer = ~0;
    public float groundCheckDistance = 0.5f;

  

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded;
    private float _lockedX;
    




    private int Cam = 1;
    // 1 = Front  2 = Side
    public GameObject FrontCam;
    public GameObject SideCam;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _lockedX = transform.position.x;
    }

    private void Update()
    {
        CheckGround();
        HandleMovement();
        LockXAxis();
        

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Cam == 1)
            {
                FrontCam.SetActive(false);
                SideCam.SetActive(true);
                Cam = 2;

            }

            else if (Cam == 2)
            {
                FrontCam.SetActive(true);
                SideCam.SetActive(false);
                Cam = 1;
            }
        }
    }

    private void CheckGround()
    {
        Vector3 origin = transform.position + Vector3.up * _controller.radius;
        bool hit = Physics.SphereCast(origin, _controller.radius * 0.8f, Vector3.down,
                                      out _, groundCheckDistance, groundLayer);
        _isGrounded = hit || _controller.isGrounded;

        if (_isGrounded && _velocity.y < 0f)
            _velocity.y = -5f;
    }

    private void HandleMovement()
    {

        if (Cam == 2)
        {
            float input = Input.GetAxis("Horizontal");          // A/D or arrows
            float zMove = input * rightDirection * speed;

            if (Input.GetButtonDown("Jump") && _isGrounded)
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            _velocity.y += gravity * Time.deltaTime;

            // Only Z (sideways) and Y (jump/fall). X is never touched.
            Vector3 move = new Vector3(transform.position.x, _velocity.y, zMove);
            _controller.Move(move * Time.deltaTime);

        
        }


        if (Cam == 1)
        {
            // Reverted to Input.GetAxis for smooth built-in interpolation
            Vector3 moveInput = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            if (moveInput.magnitude > 1f) moveInput.Normalize();

            if (Input.GetButtonDown("Jump") && _isGrounded)
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

           

            _controller.Move(moveInput * speed * Time.deltaTime);
            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }

    // Safety net: collisions or slopes can nudge X, so pin it back.
    private void LockXAxis()
    {
        if (Cam == 2)
        {
            Vector3 pos = transform.position;
            if (!Mathf.Approximately(pos.x, _lockedX))
            {
                _controller.enabled = false;   // CharacterController overrides direct position changes
                pos.x = _lockedX;
                transform.position = pos;
                _controller.enabled = true;
            }
        }
    }

    
}
