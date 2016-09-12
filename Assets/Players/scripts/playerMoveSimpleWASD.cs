using UnityEngine;
using System.Collections;

public class playerMoveSimpleWASD : MonoBehaviour {
    //simple w-a-s-d controls that use the set destination method like a carrot on a stick for the NavMeshAgent Component

    private NavMeshAgent navMeshAgent;
    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
    }

	void Update () {
        navMeshAgent.destination = CalculateDestination();
	}

     private Vector3 CalculateDestination () {
        Vector3 destination;
        destination.x = transform.position.x + Input.GetAxis("Horizontal");
        destination.z = transform.position.z + Input.GetAxis("Vertical");
        destination.y = transform.position.y;
        return destination; 
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        if (navMeshAgent){
            Gizmos.DrawSphere(navMeshAgent.destination, .5f);
        }
    }
}
