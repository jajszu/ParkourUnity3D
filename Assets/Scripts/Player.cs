using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Player : Fighter
{
    private float zRotation;
    private Transform playerBody;
    private CharacterController controller;
    public Transform groundCheck;
    public Transform wallLeftCheck;
    public Transform wallRightCheck;
    public LayerMask groundMask;
    public LayerMask wallMask;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeigh = 3f;
    public float groundDistance = 0.4f;

    bool isGrounded;
    bool isWallLeft;
    bool isWallRight;
    Vector3 velocity;
    private void Awake()
    {
        playerBody= transform;
        controller= GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isWallLeft = Physics.CheckSphere(wallLeftCheck.position, 0.1f, wallMask);
        isWallRight = Physics.CheckSphere(wallRightCheck.position, 0.1f, wallMask);

        if(isGrounded&&velocity.y< 0)
        {
            velocity.y = -2f;
        }
        

        


       float inputX = Input.GetAxisRaw("Horizontal");
       float inputY = Input.GetAxisRaw("Vertical");

        zRotation = 0f;

        if (isWallLeft && inputX<0)
        {
            inputY = 1f;
            velocity.y = 0f;
            zRotation= inputX;
        }
        if (isWallRight && inputX > 0)
        {
            inputY = 1f;
            velocity.y = 0f;
            zRotation = inputX;
        }
       
        Vector3 move = transform.right * inputX + transform.forward * inputY;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public override void RecieveDamage(int amount)
    {
        base.RecieveDamage(amount);
        GameManager.instance.InvokeUpdateUI();
    }
    protected override void Death()
    {
        base.Death();
        GameManager.instance.GameOverScreen();

    public float GetZRot()
    {
        return zRotation*30f;
    }
}
