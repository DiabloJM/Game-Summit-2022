using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
    [Tooltip("Referencia a Agente del objeto")]
    [SerializeField] NavMeshAgent agent;

    [Tooltip("Referencia en runtime a posicion del objetivo")]
    [SerializeField] Transform targetPosition;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        targetPosition = GameObject.Find("Target").GetComponent<Transform>();
        agent.SetDestination(targetPosition.position);
    }
    
}
