using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Propiedades
    //[HideInInspector]
    [Range(0,20), SerializeField, Tooltip("Velocidad lineal máxima del coche")]
    private float speed = 10f;

    [Range(0, 90), SerializeField, Tooltip("Velocidad de giro máxima del coche")]
    private float turnSpeed = 45f;
    
    private float horizontalInput, verticalInput;
    private void Awake()
    {
        Debug.Log("Awake, my masters! "+gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Esto es el método Start del PC: "+gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
     //Tenemos que mover el vehículo hacia adelante.
     /* Esto es un comentario
      * que puede tener varias líneas,
      * entre símbolo y símbolo.
      */
     
     // S = s0 + V*t*(dirección)

     horizontalInput = Input.GetAxis("Horizontal");
     verticalInput = Input.GetAxis("Vertical");
     this.transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalInput); //0,0,1
     this.transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
    }
}
