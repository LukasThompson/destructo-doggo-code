using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyCharacterController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Rigidbody rb;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float jumpForce = 4.0f;
    public float gravity = 20.0f;
    public Vector3 jumpDirection = Vector3.zero;
    public Vector3 direction;
    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Atan2 -> Math Func that returns angle of the x-axis and a vector starting at zero and terminating at x, y
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Transform rotation to direction, move along camera angle
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            animator.SetFloat("Walk", vertical);
        }

        if (Input.GetButton("Jump") == true && controller.isGrounded)
        {

            jumpDirection.y = jumpForce;
        }
        jumpDirection.y -= gravity * Time.deltaTime;
        controller.Move(jumpDirection * Time.deltaTime);
    }
}
