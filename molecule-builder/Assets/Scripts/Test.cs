using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (transform.position, transform.forward);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			Destroy (hit.collider.gameObject);
		}
	}
}
