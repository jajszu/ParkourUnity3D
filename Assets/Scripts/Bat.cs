using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    private Vector3 direction = Vector3.forward;
    [SerializeField] private float avoidObstacleDistance = 1f;
    [SerializeField] private LayerMask obstacleMask;
    private bool seeObstacle = false;
    private RaycastHit hit;

    private float focusTimer = 1f;
    private float currentFocusTimer = 0f;

    private Rigidbody rb;
    private Quaternion targetRotation;


    private void Awake()
    {
        rb= GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckTimer();
        CheckForObstacles();
        SetTargetRotation();
    }
    private void FixedUpdate()
    {
        MoveForward();
        Rotate();
    }
    private void MoveForward()
    {
        rb.MovePosition(direction.normalized * speed);
    }
    private void CheckForObstacles()
    {
        seeObstacle = Physics.Raycast(transform.position, transform.forward, out hit, avoidObstacleDistance, obstacleMask);
        if (seeObstacle)
        {
            direction = Vector3.Reflect(direction, hit.normal);
            currentFocusTimer = focusTimer;
        }
    }
    private void CheckTimer()
    {
        if(currentFocusTimer > 0)
        {
            currentFocusTimer -= Time.deltaTime;
        }
        else
        {
            Vector3 playerDirection = GameManager.instance.player.transform.position - transform.position;
            direction = playerDirection;
        }
    }
    private void SetTargetRotation()
    {
        targetRotation = Quaternion.LookRotation(direction, Vector3.up);
    }
    private void Rotate()
    {
        rb.MoveRotation(targetRotation);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject == GameManager.instance.player)
        {
            collision.transform.GetComponent<Player>().RecieveDamage(damage);
        }
    }
}
