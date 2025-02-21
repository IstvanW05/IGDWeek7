using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float sideOffset; // Bool to determine which side of camera player is on



    private Vector3 offset;
    private Vector3 finalOffset;
    private bool toggleSideOffset; // true right false left


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        toggleSideOffset = true;
        finalOffset.x += sideOffset;
    }

    private void Update()
    {
        ToggleSide();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Rotate();
        transform.position = Vector3.Lerp(transform.position, (player.transform.position + finalOffset),.25f);
        transform.LookAt(player.transform.position);
    }
    void ToggleSide() 
    { 
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(toggleSideOffset)
            {
                toggleSideOffset = false;
                finalOffset.x -= (2 * sideOffset);
            }
            else
            {
                toggleSideOffset = true;
                finalOffset.x += (2 * sideOffset);
            }
        }
    }
    void Rotate()
    {
        finalOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * finalOffset;

    }
}
