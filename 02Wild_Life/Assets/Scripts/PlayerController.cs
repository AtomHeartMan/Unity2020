using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10f;

    public float xRange = 15f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }

       if (Input.GetKeyDown(KeyCode.Space))
       {
           Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
       }
    }
    

}
