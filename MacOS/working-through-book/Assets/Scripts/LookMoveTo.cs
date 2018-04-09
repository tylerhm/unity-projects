using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour {
	public GameObject ground;
	public Transform infoBubble;

	private Text infoText;

	void Start() {
		if (infoBubble != null) {
			infoText = infoBubble.Find ("Text").GetComponent<Text> ();
		}
	}

	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray;
		RaycastHit hit;
		GameObject hitObject;

		Debug.DrawRay (camera.position, camera.rotation * Vector3.forward * 100.0f);

		ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		if (Physics.Raycast (ray, out hit)) {
			hitObject = hit.collider.gameObject;
			if (hitObject == ground) {
				if (infoBubble != null) {
					infoText.text = "X: " + hit.point.x.ToString ("F2") + ", Z: " + hit.point.z.ToString ("F2");

					infoBubble.LookAt (camera.position);
					infoBubble.Rotate (0.0f, 180.0f, 0.0f);
			}
		}
	}
}
}
