using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField, Range(0,180)]
    private float speed, rotSpeed, force;

    private Rigidbody _rigidbody;

    private float verticalInput, horizontalInput;

    public bool physicsEngine;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        //TODO: Refactorizar la posición límite en una variable
        if (Math.Abs(transform.position.x) >= 20 || Math.Abs(transform.position.z) >= 20)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24)
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.y);
            }
            if (transform.position.x < -24)
            {
                transform.position = new Vector3(-24, transform.position.y, transform.position.y);
            }
            if (transform.position.z > 24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y,24);
            }
            if (transform.position.z < -24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24);
            }
            
        }
        
        if (physicsEngine)
        {
            //Si se utiliza la física
            //AddForce sobre el Rigidbody
            //AddTorqur sobre el Rigidbody
            _rigidbody.AddForce(Vector3.forward * force * Time.deltaTime * verticalInput, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * force * Time.deltaTime * horizontalInput, ForceMode.Force);
        }
        else
        {
            //Si no se utiliza la física
            //Translate sobre el transform -> para mover
            //Rotate sobre el transform    -> para rotar

            transform.Translate(Vector3.forward * speed * Time.deltaTime * horizontalInput );
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * verticalInput);
        }
        
    }
}
