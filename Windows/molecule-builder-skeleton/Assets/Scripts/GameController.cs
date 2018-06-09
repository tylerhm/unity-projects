using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class GameController : MonoBehaviour
{
	public GameObject carbon;
	public GameObject hydrogen;
	public GameObject oxygen;
	public GameObject nitrogen;
	public GameObject phosphorous;
	public GameObject sulfur;
	public GameObject flourine;
	public GameObject chlorine;

	public GameObject bond;

	private float width;

	private int bondNumber;

	private GameObject rightAnchor;
	private GameObject scaler;
	private GameObject movementAxis;

	private GameObject singleIndicator;
	private GameObject doubleIndicator;
	private GameObject tripleIndicator;

	private GameObject gameAtom;
	private GameObject[] gameAtoms;
	private GameObject[] gameBonds;

	private Vector3 pointOne;
	private Vector3 pointTwo;

	private Vector3 scale;
	private Vector3 position;
	private Vector3 doublePosition1;
	private Vector3 doublePosition2;
	private Vector3 triplePosition1;
	private Vector3 triplePosition2;
	private Vector3 triplePosition3;

	private GameObject menu;
	private GameObject trashMenu;
	private GameObject rightHand;

	RaycastHit hit;

	private OVRInput.Button leftTrigger = OVRInput.Button.PrimaryIndexTrigger;
	private OVRInput.Button rightTrigger = OVRInput.Button.SecondaryIndexTrigger;
	private OVRInput.Button leftRelease = OVRInput.Button.PrimaryHandTrigger;
	private OVRInput.Button rightRelease = OVRInput.Button.SecondaryHandTrigger;

	private OVRInput.Axis2D rightThumbVector = OVRInput.Axis2D.SecondaryThumbstick;
	private OVRInput.Button rightThumbButton = OVRInput.Button.SecondaryThumbstick;

	private OVRInput.Button rightA = OVRInput.Button.One;
	private OVRInput.Button rightB = OVRInput.Button.Two;

	private bool menuActivity;
	private bool trashMenuActivity;
	private bool atomSelected;
	private bool drawing;
	private bool scaling;

	void Start ()
	{

		rightAnchor = GameObject.Find ("RightHandAnchor");

		scaler = GameObject.Find ("Scaler");

		movementAxis = GameObject.Find ("MovementAxis");

		singleIndicator = GameObject.Find ("SingleIndicator");
		doubleIndicator = GameObject.Find ("DoubleIndicator");
		tripleIndicator = GameObject.Find ("TripleIndicator");

		menu = GameObject.Find ("Menu");
		trashMenu = GameObject.Find ("TrashMenu");
		rightHand = GameObject.Find ("RightHand");

		menuActivity = false;
		atomSelected = false;
		trashMenuActivity = false;
		drawing = false;
		scaling = false;

		trashMenu.SetActive (false);

		bondNumber = 1;

		singleIndicator.SetActive (true);
		doubleIndicator.SetActive (false);
		tripleIndicator.SetActive (false);
		movementAxis.SetActive (false);

		width = 0.01f;
	}

	void Update ()
	{
		if (drawing == false) {
			if (trashMenuActivity == false) {
				ActivateMenu ();
			}

			if (atomSelected == false) {
				SelectAtom ();
			} else {
				DropAtom ();
			}

			SelectBondNumber ();

			TrashMenuActivation ();

			if (trashMenuActivity == false) {
				TrashMenuActivation ();
			} else {
				TrashScene ();
			}

			DeleteObject ();

			PointOne ();
		} else if (drawing == true) {
			PointTwo ();
		}
			
		GrabMolecule ();

	}

	public void ActivateMenu ()		//activates menu when left finger trigger is pressed
	{

		if (OVRInput.Get (leftTrigger)) {
			menuActivity = true;
		} else if (!OVRInput.Get (leftTrigger)) {
			menuActivity = false;
		}
		menu.SetActive (menuActivity);
	}

	public void SelectAtom ()		//if atom selected, remove right hand, and instantiate a atom to right hand.
	{

		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightTrigger)) {														
			if (hit.collider.tag == "Button") {
				if (hit.transform.name == "CarbonButton") {
					CreateAtom (carbon);
				} else if (hit.transform.name == "HydrogenButton") {
					CreateAtom (hydrogen);
				} else if (hit.transform.name == "OxygenButton") {
					CreateAtom (oxygen);
				} else if (hit.transform.name == "NitrogenButton") {
					CreateAtom (nitrogen);
				} else if (hit.transform.name == "PhosphorousButton") {
					CreateAtom (phosphorous);
				} else if (hit.transform.name == "SulfurButton") {
					CreateAtom (sulfur);
				} else if (hit.transform.name == "FlourineButton") {
					CreateAtom (flourine);
				} else if (hit.transform.name == "ChlorineButton") {
					CreateAtom (chlorine);
				}
			}
		}
	}

	public void CreateAtom (GameObject name)		//function called in SelectAtom, to instantiate an atom
	{
		rightHand.SetActive (false);
		gameAtom = Instantiate (name, rightAnchor.transform.position, rightAnchor.transform.rotation) as GameObject;
		gameAtom.transform.parent = rightAnchor.transform;
		atomSelected = true;
	}

	public void DropAtom ()		//drops the atom, when the right hand trigger is pressed
	{

		if (atomSelected == true && OVRInput.Get (rightRelease)) {
			gameAtom.transform.parent = null;
			atomSelected = false;
			rightHand.SetActive (true);
		}
	}

	public void DeleteObject ()		//deletes object if looking at it, and trigger is pressed
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (leftRelease)) {
			if (hit.collider.tag == "Atom" || hit.collider.tag == "Bond") {
				Destroy (hit.collider.gameObject);
			}
		}
	}

	public void TrashMenuActivation ()		//activates the trash scene menu
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightTrigger)) {
			if (hit.transform.name == "TrashButton") {
				trashMenu.SetActive (true);
				trashMenuActivity = true;
			}
		}
	}

	public void TrashScene ()		//trashes the entire scene, or returns to main menu
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightTrigger)) {
			if (hit.transform.name == "YesButton") {
				
				gameAtoms = GameObject.FindGameObjectsWithTag ("Atom");
				gameBonds = GameObject.FindGameObjectsWithTag ("Bond");

				for (int i = 0; i < gameAtoms.Length; i++) {
					Destroy (gameAtoms [i]);
				}
				for (int i = 0; i < gameBonds.Length; i++) {
					Destroy (gameBonds [i]);
				}
				ResetMenus ();
			} else if (hit.transform.name == "NoButton") {
				ResetMenus ();
			}
		}
	}

	public void SelectBondNumber ()		//dictates how many bonds will be placed
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightTrigger)) {
			if (hit.collider.tag == "Button") {
				if (hit.transform.name == "SingleBondButton") {
					bondNumber = 1;
					IndicateBondNumber (singleIndicator);
				} else if (hit.transform.name == "DoubleBondButton") {
					bondNumber = 2;
					IndicateBondNumber (doubleIndicator);
				} else if (hit.transform.name == "TripleBondButton") {
					bondNumber = 3;
					IndicateBondNumber (tripleIndicator);
				}
			}
		}
	}

	public void IndicateBondNumber (GameObject indicator)		//shows which bond is selected
	{
		singleIndicator.SetActive (false);
		doubleIndicator.SetActive (false);
		tripleIndicator.SetActive (false);

		if (indicator == singleIndicator) {
			singleIndicator.SetActive (true);
		} else if (indicator == doubleIndicator) {
			doubleIndicator.SetActive (true);
		} else if (indicator == tripleIndicator) {
			tripleIndicator.SetActive (true);
		}
	}

	public void PointOne ()		//picks first point for the bond, and then LOCKS everything else until second point is picked
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightA)) {
			if (hit.collider.tag == "Atom") {
				pointOne = hit.transform.position;
				drawing = true;
				ResetMenus ();
			}
		}
	}

	public void PointTwo ()		//creates second point
	{
		Ray ray = new Ray (rightHand.transform.position, rightHand.transform.up);

		if (Physics.Raycast (ray, out hit, Mathf.Infinity) && OVRInput.Get (rightB)) {
			if (hit.collider.tag == "Atom") {
				pointTwo = hit.transform.position;
				drawing = false;
				ResetMenus ();
				CreateBondsBetweenPoints ();
			}
		}
	}

	public void CreateBondsBetweenPoints ()		//creates cyclinder (bond) between point one and two
	{
		Vector3 offset = pointTwo - pointOne;
		scale.x = width;
		scale.y = offset.magnitude / 2;
		scale.z = width;
		position = pointOne + (offset / 2);

		if (bondNumber == 1) {
			
			GameObject newBond = Instantiate (bond, position, Quaternion.identity);
			newBond.transform.up = offset;
			newBond.transform.localScale = scale;

		} else if (bondNumber == 2) {

			doublePosition1 = position;
			doublePosition2 = position;

			doublePosition1.z = position.z + width;
			doublePosition2.z = position.z - width;

			doublePosition1.x = position.x + width;
			doublePosition2.x = position.x - width;

			GameObject newBond1 = Instantiate (bond, doublePosition1, Quaternion.identity);
			newBond1.transform.up = offset;
			newBond1.transform.localScale = scale;

			GameObject newBond2 = Instantiate (bond, doublePosition2, Quaternion.identity);
			newBond2.transform.up = offset;
			newBond2.transform.localScale = scale;

		} else if (bondNumber == 3) {

			triplePosition1 = position;
			triplePosition2 = position;
			triplePosition3 = position;

			triplePosition2.z = position.z + 2f * width;
			triplePosition3.z = position.z - 2f * width;

			triplePosition2.x = position.x + 2f * width;
			triplePosition3.x = position.x - 2f * width;

			GameObject newBond1 = Instantiate (bond, triplePosition1, Quaternion.identity);
			newBond1.transform.up = offset;
			newBond1.transform.localScale = scale;

			GameObject newBond2 = Instantiate (bond, triplePosition2, Quaternion.identity);
			newBond2.transform.up = offset;
			newBond2.transform.localScale = scale;

			GameObject newBond3 = Instantiate (bond, triplePosition3, Quaternion.identity);
			newBond3.transform.up = offset;
			newBond3.transform.localScale = scale;
		}
	}

	public void GrabMolecule ()		//allows user to grab molecule and rotate it
	{
		if (OVRInput.Get (rightThumbButton)) {
			scaling = true;
		} else {
			scaling = false;
		}

		if (scaling == true) {
			
			gameAtoms = GameObject.FindGameObjectsWithTag ("Atom");
			gameBonds = GameObject.FindGameObjectsWithTag ("Bond");

			for (int i = 0; i < gameAtoms.Length; i++) {
				gameAtoms [i].transform.parent = scaler.transform;
			}
			for (int i = 0; i < gameBonds.Length; i++) {
				gameBonds [i].transform.parent = scaler.transform;
			}

			rightHand.SetActive (false);
			movementAxis.SetActive (true);

		} else if (atomSelected == false) {
			
			gameAtoms = GameObject.FindGameObjectsWithTag ("Atom");
			gameBonds = GameObject.FindGameObjectsWithTag ("Bond");

			if (gameAtoms.Length > 0) {
				for (int i = 0; i < gameAtoms.Length; i++) {
					gameAtoms [i].transform.parent = null;
				}
				for (int i = 0; i < gameBonds.Length; i++) {
					gameBonds [i].transform.parent = null;
				}

				rightHand.SetActive (true);
				movementAxis.SetActive (false);

			}
		}

		if (scaling == true) {
			if (OVRInput.Get (rightThumbVector).y > 1) {
				
			}
		}
	}

	public void ResetMenus ()		//brings menus back to game start state
	{
		trashMenu.SetActive (false);
		menu.SetActive (false);
		trashMenuActivity = false;
	}
}