using UnityEngine;
using System.Collections;

public class Backboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts[0];
		print (contact.thisCollider.name);
		//		print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
	}

//	float step = speed * Time.deltaTime;
//	transform.position = Vector3.MoveTowards(transform.position, target.position, step);
}
