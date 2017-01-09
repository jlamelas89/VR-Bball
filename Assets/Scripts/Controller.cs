using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	void Start () {
	}

	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Debug.Log ("works");
		}
	}

	void OnPress(bool isPressed) {
		if (isPressed) {
			Debug.Log ("huh");
		}
	}


}
