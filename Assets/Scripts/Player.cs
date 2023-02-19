using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Player : Fighter
{
    public float speed = 12f;
    public float gravity = -20f;
    public float wallRunGravity = -10f;
    public float jumpHeigh = 3f;
    public float groundDistance = 0.4f;

    [SerializeField] 
    private Transform groundCheck;
    [SerializeField] 
    private Transform wallLeftCheck;
    [SerializeField] 
    private Transform wallRightCheck;
    [SerializeField] 
    private LayerMask groundMask;
    [SerializeField]
    private LayerMask wallMask;
    private float zRotation;
    private CharacterController controller;

    private bool isGrounded;
    [SerializeField]
    private bool isWallLeft;
    [SerializeField]
    private bool isWallRight;
    public bool isWallRunning;
    Vector3 velocity;

    private float inputX;
    private float inputY;
    private void Awake()
    {
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
        

        


       inputX = Input.GetAxisRaw("Horizontal");
       inputY = Input.GetAxisRaw("Vertical");

        zRotation = 0f;

        if (isWallLeft && inputX<0)
        {
            inputY = 1f;
            velocity.y = -0.5f;
            zRotation= inputX;
            isWallRunning = true;
        }
        else if (isWallRight && inputX > 0)
        {
            inputY = 1f;
            velocity.y = -0.5f;
            zRotation = inputX;
            isWallRunning = true;
        }
        else
        {
            isWallRunning= false;
        }
       
        Vector3 move = transform.right * inputX + transform.forward * inputY;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
        }

        var currentGravity = isWallRunning ? wallRunGravity: gravity;
        velocity.y += currentGravity * Time.deltaTime;
        Debug.Log(velocity.y);

        controller.Move(velocity * Time.deltaTime);
    }

    public override void RecieveDamage(int amount)
    {
        base.RecieveDamage(amount);
        GameManager.instance.InvokeUpdateUI();
    }
    protected override void Death()
    {
        Camera.main.transform.parent = null;
        base.Death();
        GameManager.instance.GameOverScreen();
    }
    public float GetZRot()
    {
        return zRotation * 30f;
    }
}
