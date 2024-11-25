using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuController : MonoBehaviour
{
    Rigidbody2D oyuncuHR;
    Animator playerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency =1f ,nextJumpTime; //jump frequency z�plama s�kl��� demek

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    private void Awake()
    {
        
    }
    
    void Start()
    {
        oyuncuHR = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        YatayHareket();
        OnGroundCheck();

        oyuncuHR.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed ,oyuncuHR.velocity.y); //�nput.getaxis horizontal demek bu a - d - -> - <-  tu�lar� bas�ld���nda demek

        if(oyuncuHR.velocity.x < 0 && facingRight)
        {
            flipFace();
        }
        else if(oyuncuHR.velocity.x > 0 && !facingRight)
        {
            flipFace();
        }

        if(Input.GetAxis("Vertical") > 0 && isGrounded && jumpFrequency<Time.timeSinceLevelLoad) //�nput.getaxis vertical w ve �st ok tu�u �al��t���nda demek
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency; 
            Jump();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void YatayHareket()
    {
        oyuncuHR.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, oyuncuHR.velocity.y);
        playerAnimator.SetFloat("playerSpeed",Mathf.Abs(oyuncuHR.velocity.x)); // math.abs mutlak de�eri tan�mlar
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        oyuncuHR.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim",isGrounded);
    }

}
