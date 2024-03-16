using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private KeyCode jumpButton = KeyCode.Space;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D feetCollider;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    private void Flip(float direction)
    {
        if (direction > 0) spriteRenderer.flipX = false;
        if (direction < 0) spriteRenderer.flipX = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
        Flip(playerInput);
        SwitchAnimation(playerInput);
        bool isGrounded = feetCollider.IsTouchingLayers(groundLayer);
        if (Input.GetKeyDown(jumpButton)&&isGrounded) Jump();
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(0f, jumpForce);
        myRigidbody2D.AddForce(jumpVector);
    }

    private void Move(float direction)
    {
        Vector2 velocity = myRigidbody2D.velocity;
        myRigidbody2D.velocity = new Vector2(speed * direction, velocity.y);
    }

    private void SwitchAnimation(float playerInput)
    {
        myAnimator.SetBool("run", playerInput != 0);
    }
}
