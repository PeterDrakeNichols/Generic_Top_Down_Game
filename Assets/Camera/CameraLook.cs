using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {

    private GameObject playerAvatar;
    private Vector3 offset;

	void Awake () {
        playerAvatar = GameObject.FindWithTag("Player");
        offset = transform.position - playerAvatar.transform.position;
	}

	void LateUpdate () {
        transform.position = playerAvatar.transform.position + offset;
	}
}
