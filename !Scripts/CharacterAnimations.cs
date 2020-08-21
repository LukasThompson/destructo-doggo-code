using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    public Animator animator;
    public MyCharacterController MCC;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MCC = GetComponent<MyCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MCC.direction.magnitude >= 0.1f)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (MCC.controller.isGrounded && Input.GetButton("Jump") == true)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
