using UnityEngine;
using System.Collections;

public class PlayerMoveSimple : MonoBehaviour {
    // simple point and click movement a la league of legends using the NavMeshAgent component

    private NavMeshAgent navMeshAgent;
    private MouseVectors mouseVectors;
    public float stopDuration; //amount of time to stop the player to perform action (i.e spells, heals, foods)
    void Awake () {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        mouseVectors = GetComponent<MouseVectors>() as MouseVectors;
        
    }

	void Update () {
        if (Input.GetMouseButton(1))
        {
            RaycastHit mouseOnGround = mouseVectors.MouseToGround();
            navMeshAgent.SetDestination(mouseOnGround.point);
        }

    }
}
