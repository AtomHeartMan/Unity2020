using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField, Range(0,20)]
    private float speed;
    [SerializeField, Range(0,90)]
    private float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        
        //get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward when the player presses down the space key
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }
        

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * verticalInput);
        
        //tilt the plane left/right based on left/right arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
