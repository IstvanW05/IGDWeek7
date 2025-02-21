using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_S : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 movement;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float cameraSpeed = 3;

    [SerializeField] private Vector3 jumpForce;
    public bool isGrounded;



    float rotateOffset;


    [SerializeField] private Camera playerCamera;
    public float lookXLimit = 45f;
    private float rotationX = 0;

    #region Monobehaviour methods
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        Jump();
        //RotateCam();
    }


    private void FixedUpdate()
    {
        MovementFixed(movement);
        RotatePlayer();
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckGrounded(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        CheckGrounded(collision, false);
    }

    #endregion

    void MovementUpdate()
    {
        //Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        //Rotation
        rotateOffset = (rotateOffset + Input.GetAxis("Mouse X") * cameraSpeed) % 360f;
    }

    void MovementFixed(Vector3 moveDirection)
    {
        moveDirection = rb.rotation * moveDirection;

        //rb.velocity = moveDirection * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Player rotates with mouse
    /// </summary>
    void RotatePlayer()
    {
        rb.MoveRotation(Quaternion.Euler(0, rotateOffset, 0));
    } //END RotatePlayer()

    /// <summary>
    /// Player jump
    /// </summary>
    /// 

    void RotateCam()
    {
        rotationX += -Input.GetAxis("Mouse Y") * cameraSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    } //END Jump()

    /// <summary>
    /// Change isGrounded
    /// </summary>
    void CheckGrounded(Collision _collision, bool _changeValue)
    {
        if (_collision.gameObject.layer == 7)
        {
            isGrounded = _changeValue;
        }
    } //END CheckGrounded()


}
