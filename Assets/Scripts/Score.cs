using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour {

	private Text textField;

	void Awake() {
		textField = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
//		transform.SetParent(Camera.main.GetComponent<Transform>(), true);
		textField.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	private const string DISPLAY_TEXT_FORMAT = "{0} msf\n({1} FPS)";
//	private const string MSF_FORMAT = "#.#";
//	private const float MS_PER_SEC = 1000f;
//
//	private Text textField;
//	private float fps = 60;
//
//	public Camera cam;
//
//	void Awake() {
//		textField = GetComponent<Text>();
//	}
//
//	void Start() {
//		if (cam == null) {
//			cam = Camera.main;
//		}
//
//		if (cam != null) {
//			// Tie this to the camera, and do not keep the local orientation.
//			transform.SetParent(cam.GetComponent<Transform>(), true);
//		}
//	}
//
//	void LateUpdate() {
//		float deltaTime = Time.unscaledDeltaTime;
//		float interp = deltaTime / (0.5f + deltaTime);
//		float currentFPS = 1.0f / deltaTime;
//		fps = Mathf.Lerp(fps, currentFPS, interp);
//		float msf = MS_PER_SEC / fps;
//		textField.text = string.Format(DISPLAY_TEXT_FORMAT,
//			msf.ToString(MSF_FORMAT), Mathf.RoundToInt(fps));
//	}
}
