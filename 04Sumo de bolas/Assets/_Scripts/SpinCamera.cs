using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCamera : MonoBehaviour
{
    public float rotationSpeed;

    private float horizontalInput;
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * rotationSpeed);
    }
}
