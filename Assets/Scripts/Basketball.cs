using UnityEngine;
using System.Collections;

public class Basketball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update() {
		if (this.transform.position.y <= -1.0f)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts[0];

//		if (contact.otherCollider.name == "Floor")
//			Destroy (this.gameObject);
		// Destroy timer???


//		print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
	}
}
