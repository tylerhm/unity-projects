using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public Vector2 touchpad;
	public bool touchpress;
	public bool trigger;
	public bool grip;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device Controller
	{		
		get { return SteamVR_Controller.Input((int)trackedObject.index); }	
	}

	void Awake() {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update() {
		if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchpress = true;
			Debug.Log (touchpress);
		} 

		if (Controller.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchpress = false;
			Debug.Log (touchpress);
		}

		if (Controller.GetAxis() != Vector2.zero) {
			Debug.Log(gameObject.name + Controller.GetAxis());
			touchpad = Controller.GetAxis();
		} else {
			touchpad = new Vector2 (0, 0);
		}

		if (Controller.GetHairTriggerDown()) {
			Debug.Log(gameObject.name + " Trigger Press");
			trigger = true;
		}

		if (Controller.GetHairTriggerUp()) {
			Debug.Log(gameObject.name + " Trigger Release");
			trigger = false;
		}

		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Press");
			grip = true;
		}

		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Release");
			grip = false;
		}
	}
}