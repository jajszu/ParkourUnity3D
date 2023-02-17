using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    // Start is called before the first frame update

    private CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeigh = 3f;
    public float groundDistance = 0.4f;

    bool isGrounded;
    Vector3 velocity;
    private void Awake()
    {
        controller= GetComponent<CharacterController>();
    }

    void Start()
    {
        //przypisujšc gracza do tej zmiennej będziemy mogli się do niego odwołać z każdego skryptu
        GameManager.instance.player = this;
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded&&velocity.y< 0)
        {
            velocity.y = -2f;
        }


       float inputX = Input.GetAxisRaw("Horizontal");
       float inputY = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputY;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
