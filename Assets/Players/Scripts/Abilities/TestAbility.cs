using UnityEngine;
using System.Collections;

public class TestAbility : Ability {

	private float cooldown;
	private bool onCooldown;

	void Start () {
		cooldown = 5f;
		onCooldown = false;
	}

	public override void Activate () {
		if (!onCooldown) {
			Debug.Log ("activated");
			StartCoroutine("StartCooldown");
		} else {
			Debug.Log ("still on cooldown");
		}	
	}

	public override IEnumerator StartCooldown() {
		Debug.Log ("on");
		onCooldown = true;
		yield return new WaitForSeconds(cooldown);
		onCooldown = false;
		Debug.Log ("off");
	}
}
