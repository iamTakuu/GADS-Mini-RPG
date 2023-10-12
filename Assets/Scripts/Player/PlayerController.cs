using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private Rigidbody rb;
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private float jumpForce = 5f;
   
   private Vector2 moveInput;
   
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private Transform groundPoint;
   private bool isGrounded;

   [SerializeField] private Animator anim;
   [SerializeField] private SpriteRenderer spriteRenderer;
   private static readonly int MoveSpeed = Animator.StringToHash("moveSpeed");
   private static readonly int OnGround = Animator.StringToHash("onGround");

   private void Update()
   {
      moveInput.x = Input.GetAxisRaw("Horizontal");
      moveInput.y = Input.GetAxisRaw("Vertical");
      moveInput.Normalize();
      
      rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
      anim.SetFloat(MoveSpeed, rb.velocity.magnitude);
      
      GroundCheck();
      
      if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
         rb.velocity += new Vector3(0f, jumpForce, 0f);
      }
      anim.SetBool(OnGround, isGrounded);
      
      if(!spriteRenderer.flipX && moveInput.x > 0)
         spriteRenderer.flipX = true;
      else if(spriteRenderer.flipX && moveInput.x < 0)
         spriteRenderer.flipX = false;
   }
   
   private void GroundCheck()
   {
      isGrounded = Physics.Raycast(groundPoint.position, Vector3.down, out _, 0.3f, groundLayer);
   }
}
