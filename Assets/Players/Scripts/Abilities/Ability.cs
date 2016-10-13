using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour {

//	private float cooldown;
//	private bool onCooldown;

	public abstract void Activate();
	public abstract IEnumerator StartCooldown();
}
