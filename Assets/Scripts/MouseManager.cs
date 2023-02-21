using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public float mouseSensivity = 100f;

    public Transform playerBody;

    [SerializeField] float wallRunRotationSpeed = 150;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.state != GameState.InGame)
        {
            return;
        }
       
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);



        float targetZRotation = playerBody.GetComponent<Player>().GetZRot();

        transform.localRotation = Quaternion.Euler(xRotation, 0, transform.localEulerAngles.z);
        Quaternion targetRotation = Quaternion.Euler(xRotation, 0, targetZRotation);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, wallRunRotationSpeed * Time.deltaTime);



        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
