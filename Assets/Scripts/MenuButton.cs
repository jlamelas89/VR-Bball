using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Collider))]
public class MenuButton : MonoBehaviour {
	public float hoverSelectDistance = .05f;

	// Use this for initialization
	void Start () {
		SetGazedAt(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void SetGazedAt(bool gazedAt) {
		print (gazedAt);
//		if(gazedAt == true)
////			HoverState();
//		if (gazedAt == true)
//			GetComponent<Renderer> ().material.color = Color.green;
//		else
//			GetComponent<Renderer> ().material.color = new Color (0.45f, 0.50f, 0.71f);
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : new Color(0.45f, 0.50f, 0.71f);
		//		Debug.Log(gazedAt);

	}

	private void HoverState() {
		Vector3 newPos = this.transform.position;
		newPos.z -= hoverSelectDistance;
		this.transform.position = newPos;
	}
		
//	public void ToggleDistortionCorrection() {
//		GvrViewer.Instance.DistortionCorrectionEnabled =
//			!GvrViewer.Instance.DistortionCorrectionEnabled;
//	}

	private void PlaySinglePlayer() {
		print ("Swap to Single Player");
		Application.LoadLevel ("Test");
	}

	/* THIS WILL EVENTUALLY BECOME ANOTHER MENU */
	private void PlayTwoPlayer() {
		print ("Swap to Single Player");
		Application.LoadLevel ("Multi");
	}

	#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
//	public void ToggleDirectRender() {
//		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
//	}
	#endif  //  !UNITY_HAS_GOOGLEVR || UNITY_EDITOR

	#region IGvrGazeResponder implementation

	public void OnGazeEnter() {
		SetGazedAt(true);
//		print ("sjdfid");
	}

	public void OnGazeExit() {
		SetGazedAt(false);
	}

	public void OnGazeTrigger() {
		if (this.name == "Single Player")
			PlaySinglePlayer ();
		else if (this.name == "Multi Player")
			PlayTwoPlayer ();
	}

	#endregion
}
