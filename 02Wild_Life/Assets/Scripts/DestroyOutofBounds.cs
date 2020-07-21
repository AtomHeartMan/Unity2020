using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10f;
    private float rightBound = 30f;
    private float leftBound = -30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound )
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < lowerBound)
        {
            Debug.Log("JUEGO TERMINADO");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
