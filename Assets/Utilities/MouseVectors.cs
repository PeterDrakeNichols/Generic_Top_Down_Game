using UnityEngine;
using System.Collections;

public class MouseVectors : MonoBehaviour {

    private Camera mainCamera;

    void Awake() {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    //simple raycast that returns mouse position projected to the first collider it hits
    public RaycastHit MouseToGround() {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            return hit;
        }
        return hit;
    }
    // finds the mouse position x and y on a plane fixed to an object's (most likely a player's) y position
    public Vector3 MouseToFeet() {
        Plane plane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));
        float ent;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out ent)) {
            return ray.GetPoint(ent);
        }
        return transform.position;
    }
    //normalizes a requested location as a directional vector based on an object's (most likely a player's) position
    public Vector3 Direction(float magnitude) {
        return transform.position + Vector3.Normalize(MouseToFeet() - transform.position) * magnitude;
    }
    //returns true if selected is within reach of an object (most likely a player)
    public bool WithInReach(Vector3 location, Vector3 requestedLocation, float reach) {
        if (requestedLocation.x - location.x <= reach && requestedLocation.z - requestedLocation.z <= reach)
        {
            return true;
        }
        return false;
    }
}
