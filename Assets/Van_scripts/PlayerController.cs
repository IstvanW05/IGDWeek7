using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController myCharController;
    //private variables to be used within the script
    private float speed = 7f;

    private Vector3 moving;

    private void Start()
    {
        myCharController = GetComponent<CharacterController>();
        moving = Vector3.zero;
    }
    private void Update()
    {
        Movement();
        Rotation();
    }
    void Movement()
    {
        moving = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moving *= speed;
        moving = transform.rotation * moving;

        //move
        myCharController.Move(moving * Time.deltaTime);
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") *4f, 0));
    }
}
