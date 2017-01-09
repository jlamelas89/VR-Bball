using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BackButton : MonoBehaviour {
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
		/// 
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;


		//		Debug.Log(gazedAt);

	}

	private void HoverState() {
		Vector3 newPos = this.transform.position;
		newPos.z -= hoverSelectDistance;
		this.transform.position = newPos;
	}

	public void ToggleDistortionCorrection() {
		GvrViewer.Instance.DistortionCorrectionEnabled =
			!GvrViewer.Instance.DistortionCorrectionEnabled;
	}

	private void MainMenu() {
		print ("Swap to Main Menu");
		Application.LoadLevel ("MainMenu");
	}

	#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
	public void ToggleDirectRender() {
		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
	}
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
		MainMenu();
	}

	#endregion
}
