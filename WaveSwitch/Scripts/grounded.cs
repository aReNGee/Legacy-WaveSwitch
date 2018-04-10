using UnityEngine;
using System.Collections;

public class grounded : MonoBehaviour {

	//Calling Player script to access it's variables
	private playerMovement playerM;

	// Use this for initialization
	void Start () {
		playerM = gameObject.GetComponentInParent<playerMovement> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		playerM.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col) {
		playerM.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		playerM.grounded = false;
	}
}
