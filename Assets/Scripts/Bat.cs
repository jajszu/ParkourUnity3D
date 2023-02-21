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
        if(GameManager.instance.state != GameState.InGame) { return; }
        //CheckTimer();
        //CheckForObstacles();
        SetTargetRotation();
        CheckPlayerDistance();
    }
    private void FixedUpdate()
    {
        MoveForward();
        Rotate();
        SetDirection();
    }
    private void MoveForward()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
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
    private void SetDirection()
    {
        direction = DirectionToPlayer();
    }
    private void SetTargetRotation()
    {
        targetRotation = Quaternion.LookRotation(direction, Vector3.up);
    }
    private void Rotate()
    {
        if(targetRotation == Quaternion.identity) return; 
        rb.MoveRotation(targetRotation);
    }
    private Vector3 DirectionToPlayer()
    {
        return GameManager.instance.player.transform.position - transform.position;
    }
    private void CheckPlayerDistance()
    {
        if(DistanceFromPlayer() < 0.1f)
        {
            GameManager.instance.player.RecieveDamage(damage);
            Destroy(gameObject);
        }
    }

    private float DistanceFromPlayer()
    {
        var player = GameManager.instance.player.transform.position;
        return Vector3.Distance(player, transform.position);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("hitting player");
            collision.transform.GetComponent<Player>().RecieveDamage(damage);
        }
    }
}
