using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform objectObserved;
    private bool isPlayerInRange;

    public GameEnding gameEnding;
    private void OnTriggerEnter(Collider other){
        if (other.transform == objectObserved)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == objectObserved)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = objectObserved.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.magenta,
                Time.deltaTime, true);
            
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == objectObserved)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, objectObserved.position);
    }

}

