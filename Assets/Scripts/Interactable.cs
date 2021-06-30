using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    public float StoppingDistance = 3f;
    private bool hasInteracted = true;
    private bool isEnemy;


    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        isEnemy = gameObject.tag == "Enemy";
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = StoppingDistance;
        playerAgent.destination = transform.position + new Vector3(float.Epsilon, float.Epsilon);
    }

    private void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!isEnemy)
                {
                    Interact();
                }
                EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    private void EnsureLookDirection()
    {
        playerAgent.updatePosition = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updatePosition = true;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
