using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableCamera : NetworkBehaviour {
	public GameObject thisCamera;

	// Use this for initialization
	void Start () {
//		print (thisCamera);
		if (!isLocalPlayer) {
//			thisCamera.enabled = false;
		}
	}

}
