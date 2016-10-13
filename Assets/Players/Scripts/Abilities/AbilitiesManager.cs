using UnityEngine;
using System.Collections;

public class AbilitiesManager : MonoBehaviour {

	private GameObject playerAvatar;
	public Ability abilityOne;
	public Ability abilityTwo;
	public Ability abilityThree;

	void Awake () {
		playerAvatar = GameObject.FindWithTag ("Player");
	}

	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown( KeyCode.Alpha1 )) {
			abilityOne.Activate();
		}
		if (Input.GetKeyDown( KeyCode.Alpha2 )) {
			abilityTwo.Activate();
		}
		if (Input.GetKeyDown( KeyCode.Alpha2 )) {
			abilityThree.Activate();
		}
	}
}
