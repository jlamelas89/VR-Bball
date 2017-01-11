using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
	Vector3 newPlayerPos;
	private GameObject playerCam;
	private GameObject playerHead;

	private GameObject currentBall;
	float distance = .5f;
	float currentPower = 150f;
	Vector3 newBallPos;

	// Use this for initialization
	void Start() {
		playerCam = this.transform.Find ("Main Camera").gameObject;
		playerHead = this.transform.Find ("PlayerHead").gameObject;

		if (!isLocalPlayer) {
			playerCam.SetActive (false);
			return;
		}
		
//		playerCam.SetActive (true);
//		CmdInstantiateBall();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
//			newBallPos = (playerCam.transform.position - new Vector3 (0.0f, .3f, 0.0f)) + playerCam.transform.forward * distance;
//			currentBall.transform.position = newBallPos;
			return;
		}

		playerHead.transform.rotation = playerCam.transform.rotation;
//
//		newBallPos = (playerCam.transform.position - new Vector3(0.0f, .3f, 0.0f)) + playerCam.transform.forward * distance;
//		currentBall.transform.position = newBallPos;

		if (Input.GetMouseButtonUp (0)) {
//			CmdLaunchBall(currentBall);
			CmdInstantiateBall();
		}
	}

	[Command]
	void CmdInstantiateBall() {
//		newBallPos = (playerCam.transform.position - new Vector3(0.0f, .3f, 0.0f)) + playerCam.transform.forward * distance;

		GameObject ballPrefab = (GameObject)Resources.Load ("Objects/Network Prefabs/Basketball", typeof(GameObject));
		currentBall = (GameObject)Instantiate (ballPrefab, this.transform.position, Quaternion.identity);
//		currentBall = (GameObject)Instantiate (ballPrefab, newBallPos, Quaternion.identity);
//		currentBall.transform.parent = this.transform;
//		currentBall.GetComponent<Rigidbody> ().useGravity = false;
		currentBall.GetComponent<Rigidbody> ().useGravity = true;
		currentBall.GetComponent<Rigidbody> ().detectCollisions = false;
		
		Vector3 direction = playerCam.transform.forward + new Vector3 (0, 2.5f, 0);
		currentBall.GetComponent<Rigidbody>().AddForce(direction * currentPower);
		NetworkServer.Spawn (currentBall);
	}


//	void InstantiateBall() {
//		newBallPos = (playerCam.transform.position - new Vector3(0.0f, .3f, 0.0f)) + playerCam.transform.forward * distance;
//
//		GameObject ballPrefab = (GameObject)Resources.Load ("Objects/Network Prefabs/Basketball", typeof(GameObject));
//		currentBall = (GameObject)Instantiate (ballPrefab, newBallPos, Quaternion.identity);
//		currentBall.transform.parent = this.transform;
//		currentBall.GetComponent<Rigidbody> ().useGravity = false;
//		currentBall.GetComponent<Rigidbody> ().detectCollisions = false;
//
////		NetworkServer.Spawn (currentBall);
//	}

//	[Command]
//	void CmdLaunchBall(GameObject ball) {
//		Vector3 direction = playerCam.transform.forward + new Vector3 (0, 2.5f, 0);
//		currentBall.GetComponent<Rigidbody> ().useGravity = true;
//		currentBall.GetComponent<Rigidbody> ().detectCollisions = true;
//		ball.GetComponent<Rigidbody>().AddForce(direction * currentPower);
//
//		CmdInstantiateBall ();
//	}

}
