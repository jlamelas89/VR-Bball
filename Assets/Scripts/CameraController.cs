using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject currentBall;

	float distance = .5f;
	float currentPower = 150f;
	Vector3 newPos;
	bool increase = true;


	// Use this for initialization
	void Start () {
		newPos = Camera.main.transform.position + Camera.main.transform.forward * distance;
		InstantiateBall();
	}
	
	// Update is called once per frame
	void Update () {
		newPos = (Camera.main.transform.position - new Vector3(0.0f, .3f, 0.0f)) + Camera.main.transform.forward * distance;
		currentBall.transform.position = newPos;

//		if (Input.GetMouseButton (0)) {
////			InstantiateBall ();
////			LaunchBall ();
////			LaunchBall(currentBall);
//			if (increase == true) {	
//				currentPower += 2f;
////				
////				if (currentPower >= 200f)
////					print ("posd");
////					increase = false;
//			} 
////			else if (increase == false) {
////				currentPower -= 2f;
////				if (currentPower < 50f)
////					increase = true;
////			}
//			print (currentPower);
//		}
//
		if (Input.GetMouseButtonUp (0)) {
			LaunchBall(currentBall);
		}
	}
		
	private void InstantiateBall() {
		GameObject smallBallPrefab = (GameObject)Resources.Load("Objects/BasketBall", typeof(GameObject)); 
//		GameObject smallBall = (GameObject)Instantiate(smallBallPrefab, newPos, Quaternion.identity);
		currentBall = (GameObject)Instantiate(smallBallPrefab, newPos, Quaternion.identity);
		currentBall.GetComponent<Rigidbody> ().useGravity = false;
		currentBall.GetComponent<Rigidbody> ().detectCollisions = false;
//		smallBall.GetComponent<Rigidbody>().

//		LaunchBall (smallBall);

//		smallBall.SetActive (true);
//		Debug.Log (smallBall);
	}

	private void LaunchBall(GameObject ball) {
		Vector3 direction = this.transform.forward + new Vector3 (0, 2.5f, 0);
		currentBall.GetComponent<Rigidbody> ().useGravity = true;
		currentBall.GetComponent<Rigidbody> ().detectCollisions = true;
		ball.GetComponent<Rigidbody>().AddForce(direction * currentPower);
//		currentPower = 50f;
		InstantiateBall ();
//		Debug.Log(smallBall.GetComponent<Rigidbody>());
	}
}
