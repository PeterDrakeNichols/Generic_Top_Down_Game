using UnityEngine;
using System.Collections;

public class PlayerMovementMouse : PlayerMovement {
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
            if(mouseOnGround.point != new Vector3(0, 0, 0)){
                //refactor: for some reason unity returns 0,0,0 instead of null on a missed raycast 
                navMeshAgent.SetDestination(mouseOnGround.point);
            }
        }

    }
}
